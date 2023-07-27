using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private ContaCorrenteQueryRequest request;

        public ContaCorrenteController(DatabaseConfig databaseConfig)
        {
            this.request = new ContaCorrenteQueryRequest(databaseConfig);
        }

        [HttpGet]
        public IActionResult ObterSaldoConta([FromQuery] SaldoContaRequest saldoContaRequest)
        {
            try
            {
                var result = request.ObterSaldoConta(saldoContaRequest).Result;
                return Ok(result);
            }
            catch (ContaCorrenteException ex)
            {
                return BadRequest(new { ex.Message, ex.Type});
            }
        }
    }
}
