using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class IdempotencyCommandStoreRequest : IStore<IdempotencyRemoveStoreResponse>
    {
        private readonly string chave_idempotencia;
        public IdempotencyCommandStoreRequest(string chave_idempotencia) 
        {
            this.chave_idempotencia = chave_idempotencia;
        }
        public string GetSql()
        {
            return $"delete from idempotencia where chave_idempotencia = '{chave_idempotencia}';";
        }
    }
}
