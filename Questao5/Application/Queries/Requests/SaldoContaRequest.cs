using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public record SaldoContaRequest : IRequest<SaldoContaResponse>
    {
        public int NumeroConta { get; set; }
    }
}
