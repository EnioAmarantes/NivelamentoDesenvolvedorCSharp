using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Exceptions;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    public class MovimentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ActionName("Registrar Movimentação")]
        public async Task<IActionResult> MovimentacaoFinanceira(
            [FromHeader] [Required] string idempotencyKey,
            [FromBody] MovimentoCreateCommandRequest request)
        {
            try
            {
                var idempotency = await _mediator.Send(new IdempotencyQueryStoreRequest(idempotencyKey));

                if(idempotency is null)
                {
                    var requestSerialized = JsonConvert.SerializeObject(request);
                    var idempotencyResponse = await _mediator.Send(new IdempotencyCreateStoreRequest(idempotencyKey, requestSerialized)); 
                    MovimentoCreateCommandResponse response = await _mediator.Send(request);
                    var responseSerialized = JsonConvert.SerializeObject(response);
                    var idempotencyResultado = await _mediator.Send(new IdempotencySaveResultStoreRequest(idempotencyKey, responseSerialized));
                    return Ok(response);
                }
                var responseDeserialized = JsonConvert.DeserializeObject<MovimentoCreateCommandResponse>(idempotency.resultado);
                return Ok(responseDeserialized);
            }
            catch (AccountMovimentException ex)
            {
                await _mediator.Send(new IdempotencyCommandStoreRequest(idempotencyKey));
                return BadRequest(ex.TYPE.ToString() + "\n" + ex.Message);
            }
            catch (Exception ex)
            {
                await _mediator.Send(new IdempotencyCommandStoreRequest(idempotencyKey));
                return BadRequest(ex.Message);
            }
        }
    }
}
