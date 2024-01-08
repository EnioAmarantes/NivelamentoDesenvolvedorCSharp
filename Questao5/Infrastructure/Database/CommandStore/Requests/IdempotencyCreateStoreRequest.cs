using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class IdempotencyCreateStoreRequest : IStore<IdempotencyCreateStoreResponse>
    {
        private string chave_idempotencia {  get; set; }
        private string requisicao { get; set; }

        public IdempotencyCreateStoreRequest(string chave_idempotencia, string requisicao)
        {
            this.chave_idempotencia = chave_idempotencia;
            this.requisicao = requisicao;
        }

        public string GetSql()
        {
            return $"insert into idempotencia(chave_idempotencia, requisicao) values('{chave_idempotencia}', '{requisicao}');";
        }
    }
}
