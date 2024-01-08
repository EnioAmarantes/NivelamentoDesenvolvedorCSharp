using MediatR;

namespace Questao5.Infrastructure.Database.CommandStore.Responses
{
    public record IdempotencyCreateStoreResponse : IRequest
    {
        public string chave_idempotencia { get; set; }
    }
}
