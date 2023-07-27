using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class ContaCorrenteQueryRequest
    {
        private readonly DatabaseConfig databaseConfig;
        private readonly MovimentacaoQueryRequest movimentRequest;

        public ContaCorrenteQueryRequest(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
            this.movimentRequest = new MovimentacaoQueryRequest(databaseConfig);
        }

        public async Task<bool> ContaNaoExiste(int numeroConta)
        {
            using(var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();

                var query = "select idcontacorrente from contacorrente where numero = @NumeroConta;";
                var result = await connection.QuerySingleOrDefaultAsync(query, new {NumeroConta = numeroConta});
                return result == null;
            }
        }

        public async Task<bool> ContaInativa(int numeroConta)
        {
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();

                var query = "select idcontacorrente from contacorrente where ativo = 1 and numero = @NumeroConta;";
                var result = await connection.QuerySingleOrDefaultAsync(query, new { NumeroConta = numeroConta });
                return result == null;
            }
        }

        public async Task<string> getIdContaCorrente(int numeroConta)
        {
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();

                var query = "select idcontacorrente from contacorrente where ativo = 1 and numero = @NumeroConta;";
                var result =  await connection.QuerySingleOrDefaultAsync<string>(query, new { NumeroConta = numeroConta });
                return result;
            }
        }


        public async Task<SaldoContaResponse> ObterSaldoConta(SaldoContaRequest saldoContaRequest)
        {
            if (await ContaNaoExiste(saldoContaRequest.NumeroConta))
                throw new ContaCorrenteException("Apenas contas correntes cadastradas podem consultar o saldo", EContaCorrenteExceptionType.INVALID_ACCOUNT);

            if (await ContaInativa(saldoContaRequest.NumeroConta))
                throw new ContaCorrenteException("Apenas contas correntes ativas podem consultar o saldo", EContaCorrenteExceptionType.INACTIVE_ACCOUNT);

            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();

                var queryConta = "select idcontacorrente as IdContaCorrente, nome, numero as number from contacorrente where ativo = 1 and numero = @NumeroConta;";
                var conta = await connection.QuerySingleOrDefaultAsync<ContaCorrente>(queryConta, new { NumeroConta = saldoContaRequest.NumeroConta });
                var movimentacoes = await movimentRequest.ObterMovimentacoes(conta.IdContaCorrente);

                var saldoAtual = movimentacoes.Where(mov => mov.TipoMovimentacao == EMovimentType.CREDIT).Sum(mov => mov.Valor) - movimentacoes.Where(mov => mov.TipoMovimentacao == EMovimentType.DEBIT).Sum(mov => mov.Valor);

                return new SaldoContaResponse(conta.number, conta.nome, saldoAtual);
            }
        }
    }
}
