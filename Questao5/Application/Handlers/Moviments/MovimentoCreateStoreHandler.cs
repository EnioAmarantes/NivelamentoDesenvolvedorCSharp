using Dapper;
using Questao5.Application.Handlers.Base;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class MovimentoCreateStoreHandler : CommandQueryBase<MovimentoCreateStoreRequest, MovimentoCreateStoreResponse>
    {
        public MovimentoCreateStoreHandler(DatabaseConfig databaseConfig)
            : base(databaseConfig) { }

        public override async Task<MovimentoCreateStoreResponse> Handle(MovimentoCreateStoreRequest request, CancellationToken cancellationToken)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                var response = await connection.ExecuteScalarAsync<string>(request.GetSql());
                MovimentoCreateStoreResponse movimentoResponse = new MovimentoCreateStoreResponse(request.GetIdMovimento());

                return movimentoResponse;
            }
        }
    }
}
