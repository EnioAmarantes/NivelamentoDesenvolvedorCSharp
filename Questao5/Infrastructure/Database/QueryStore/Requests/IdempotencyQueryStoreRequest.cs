using Questao5.Infrastructure.Database.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class IdempotencyQueryStoreRequest : IStore<IdempotencyQueryResponse>
    {
        private string chave_idempotencia { get; set; }
        public IdempotencyQueryStoreRequest(string chave_idempotencia)
        {
            this.chave_idempotencia = chave_idempotencia;
        }

        public string GetSql()
        {
            return $"select resultado from idempotencia where chave_idempotencia = '{chave_idempotencia}';";
        }
    }
}
