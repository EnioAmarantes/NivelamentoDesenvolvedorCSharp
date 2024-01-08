using Dapper;
using Questao5.Application.Exceptions;
using Questao5.Application.Handlers.Base;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class ContaQueryRequestHandler : CommandQueryBase<ContaQueryStoreRequest, ContaCorrente>
    {
        public ContaQueryRequestHandler(DatabaseConfig databaseConfig)
            : base(databaseConfig) { }

        public override Task<ContaCorrente> Handle(ContaQueryStoreRequest request, CancellationToken cancellationToken)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                ContaCorrente conta = connection.QueryFirstOrDefault<ContaCorrente>(request.GetSql());

                if(conta == null)
                {
                    throw new InvalidAccountException(request.NumeroConta);
                }

                if (!conta.ativo)
                {
                    throw new InactiveAccountException(request.NumeroConta);
                }

                return Task.FromResult(conta);
            }
        }
    }
}
