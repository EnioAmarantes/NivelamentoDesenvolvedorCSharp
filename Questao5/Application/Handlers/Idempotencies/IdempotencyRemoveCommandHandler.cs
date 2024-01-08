using Dapper;
using Questao5.Application.Handlers.Base;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers.Idempotencies
{
    public class IdempotencyRemoveCommandHandler : CommandQueryBase<IdempotencyCommandStoreRequest, IdempotencyRemoveStoreResponse>
    {
        public IdempotencyRemoveCommandHandler(DatabaseConfig databaseConfig)
            : base(databaseConfig) { }

        public override async Task<IdempotencyRemoveStoreResponse> Handle(IdempotencyCommandStoreRequest request, CancellationToken cancellationToken)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                var response = await connection.ExecuteScalarAsync<IdempotencyRemoveStoreResponse>(request.GetSql());

                return response;
            }
        }
    }
}
