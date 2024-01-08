using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Application.Handlers.Base;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class IdempotencyQueryRequestHandler : CommandQueryBase<IdempotencyQueryStoreRequest, IdempotencyQueryResponse>
    {
        public IdempotencyQueryRequestHandler(DatabaseConfig databaseConfig)
            : base(databaseConfig) { }
        public override Task<IdempotencyQueryResponse> Handle(IdempotencyQueryStoreRequest request, CancellationToken cancellationToken)
        {
            using(var connection = GetConnection())
            {
                var response = connection.QueryFirstOrDefaultAsync<IdempotencyQueryResponse>(request.GetSql());

                return response;
            }
        }
    }
}
