using Dapper;
using Questao5.Application.Handlers.Base;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class MovimentoQueryRequestHandler : CommandQueryBase<MovimentoByIdContaQueryStoreRequest, List<Movimento>>
    {
        public MovimentoQueryRequestHandler(DatabaseConfig databaseConfig)
            :base(databaseConfig) { }

        public override async Task<List<Movimento>> Handle(MovimentoByIdContaQueryStoreRequest request, CancellationToken cancellationToken)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                var movimentos = await connection.QueryAsync<Movimento>(request.GetSql());

                return movimentos.ToList();
            }
        }
    }
}
