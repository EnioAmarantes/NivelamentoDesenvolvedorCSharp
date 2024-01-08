using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Exceptions;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Application.Handlers
{
    public class MovimentoCreateCommandHandler : IRequestHandler<MovimentoCreateCommandRequest, MovimentoCreateCommandResponse>
    {
        private readonly IMediator mediator;

        public MovimentoCreateCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<MovimentoCreateCommandResponse> Handle(MovimentoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            char[] tiposValidos = { 'C', 'D' };
            if (!tiposValidos.Contains(request.TipoMovimento))
                throw new InvalidTypeMovimentException(request.TipoMovimento);

            if (request.Valor <= 0)
                throw new InvalidValueMovimentException(request.Valor);

            ContaCorrente conta = await mediator.Send(new ContaQueryStoreRequest(request.NumeroConta));

            if (conta == null)
                throw new InvalidAccountException(request.NumeroConta);

            if (!conta.ativo)
                throw new InactiveAccountException(conta.numero);

            MovimentoCreateStoreRequest commandRequest = new MovimentoCreateStoreRequest(
                conta.idcontacorrente,
                request.TipoMovimento,
                request.Valor
                );

            var result = await mediator.Send(commandRequest);
            return new MovimentoCreateCommandResponse(result.idmovimento);
        }
    }
}
