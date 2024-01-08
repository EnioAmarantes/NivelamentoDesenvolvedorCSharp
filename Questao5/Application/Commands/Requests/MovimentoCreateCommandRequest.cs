using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentoCreateCommandRequest : IRequest<MovimentoCreateCommandResponse>
    {
        public int NumeroConta { get; set; }
        public decimal Valor { get; set; }
        public char TipoMovimento { get; set; }
    }
}
