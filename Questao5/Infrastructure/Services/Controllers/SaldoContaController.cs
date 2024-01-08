using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Exceptions;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class SaldoContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaldoContaController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [Route("{numeroConta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterSaldoConta(int numeroConta)
        {
            try
            {
                SaldoContaRequest saldoContaRequest = new SaldoContaRequest { NumeroConta = numeroConta };
                var response = await _mediator.Send(saldoContaRequest);
                return Ok(response);
            }
            catch(AccountMovimentException ex)
            {
                return BadRequest(ex.TYPE.ToString() + "\n" + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
