using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class ContaQueryStoreRequest : IStore<ContaCorrente>
    {
        public readonly int NumeroConta;

        public ContaQueryStoreRequest(int numeroConta)
            => NumeroConta = numeroConta;

        public string GetSql()
        {
            return $"select * from contacorrente where numero = { NumeroConta }";
        }
    }
}
