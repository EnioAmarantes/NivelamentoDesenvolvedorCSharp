using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Application.Handlers.Base;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class IdempotencyCreateCommandHandler : CommandQueryBase<IdempotencyCreateStoreRequest, IdempotencyCreateStoreResponse>
    {
        public IdempotencyCreateCommandHandler(DatabaseConfig databaseConfig)
            : base(databaseConfig) { }

        public override Task<IdempotencyCreateStoreResponse> Handle(IdempotencyCreateStoreRequest request, CancellationToken cancellationToken)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                var response = connection.ExecuteScalarAsync<IdempotencyCreateStoreResponse>(request.GetSql());

                return response;
            }
        }
    }
}
