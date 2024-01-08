using MediatR;

namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public class IdempotencyQueryResponse : IRequest
    {
        public string resultado { get; set; }

        public IdempotencyQueryResponse(string resultado)
        {
            this.resultado = resultado;
        }
    }
}
