using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class IdempotencySaveResultStoreRequest : IStore<IdempotencySaveResultStoreResponse>
    {
        private string chave_idempotencia {  get; set; }
        private string resultado { get; set; }

        public IdempotencySaveResultStoreRequest(string chave_idempotencia, string resultado)
        {
            this.chave_idempotencia = chave_idempotencia;
            this.resultado = resultado;
        }

        public string GetSql()
        {
            return $"update idempotencia set resultado = '{resultado}' where chave_idempotencia = '{chave_idempotencia}';";
        }
    }
}
