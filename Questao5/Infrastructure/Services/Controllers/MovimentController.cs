using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentController: ControllerBase
    {
        public readonly CriarMovimentacaoCommand command;

        public MovimentController(DatabaseConfig databaseConfig)
        {
            command = new CriarMovimentacaoCommand(databaseConfig);
        }

        [HttpPost]
        public async Task<ActionResult<MovimentResponse>> Create([FromBody] MovimentRequest movimentRequest)
        {
            try
            {
                MovimentResponse movimentResponse = await command.CriarMovimentacao(movimentRequest);
                return Ok(movimentResponse);
            }
            catch(MovimentException ex)
            {
                return BadRequest(new { ex.Message, ex.Type});
            }
        }

    }
}
