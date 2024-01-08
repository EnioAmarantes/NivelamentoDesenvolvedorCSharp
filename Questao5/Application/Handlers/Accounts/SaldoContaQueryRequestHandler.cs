using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Application.Handlers
{
    public class SaldoContaQueryRequestHandler : IRequestHandler<SaldoContaRequest, SaldoContaResponse>
    {
        private readonly IMediator _mediator;

        public SaldoContaQueryRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<SaldoContaResponse> Handle(
            SaldoContaRequest request, 
            CancellationToken cancellationToken)
        {
            try
            {
                ContaCorrente conta = await _mediator.Send(new ContaQueryStoreRequest(request.NumeroConta));

                List<Movimento> movimentos = await _mediator.Send(new MovimentoByIdContaQueryStoreRequest(conta.idcontacorrente));

                conta.AddMovimentos(movimentos);

                var response = new SaldoContaResponse(conta.numero, conta.nome, conta.SomaSaldo());
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
