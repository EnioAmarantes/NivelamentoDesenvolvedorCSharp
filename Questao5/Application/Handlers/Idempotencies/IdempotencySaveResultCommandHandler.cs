using Dapper;
using Questao5.Application.Handlers.Base;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers.Idempotencies
{
    public class IdempotencySaveResultCommandHandler : CommandQueryBase<IdempotencySaveResultStoreRequest, IdempotencySaveResultStoreResponse>
    {
        public IdempotencySaveResultCommandHandler(DatabaseConfig databaseConfig)
            :base(databaseConfig) { }

        public override Task<IdempotencySaveResultStoreResponse> Handle(IdempotencySaveResultStoreRequest request, CancellationToken cancellationToken)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var response = connection.ExecuteScalarAsync<IdempotencySaveResultStoreResponse>(request.GetSql());

                return response;
            }
        }
    }
}
