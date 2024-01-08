using MediatR;

namespace Questao5.Infrastructure.Database.CommandStore.Responses
{
    public class MovimentoCreateStoreResponse : IRequest
    {
        public string idmovimento { get; set; }

        public MovimentoCreateStoreResponse(string idmovimento)
        {
            this.idmovimento = idmovimento;
        }   
    }
}
