using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CriarMovimentacaoCommand
    {
        private readonly DatabaseConfig databaseConfig;
        private readonly ContaCorrenteQueryRequest contaCorrenteQuery;

        public CriarMovimentacaoCommand(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
            this.contaCorrenteQuery = new ContaCorrenteQueryRequest(databaseConfig);
        }

        public async Task<MovimentResponse> CriarMovimentacao(MovimentRequest moviment)
        {
            if (await contaCorrenteQuery.ContaNaoExiste(moviment.NumeroConta))
                throw new MovimentException("Apenas Contas correntes cadastradas podem receber movimentação.", EMovimentExceptionType.INVALID_ACCOUNT);

            if (await contaCorrenteQuery.ContaInativa(moviment.NumeroConta))
                throw new MovimentException("Apenas contas correntes ativas podem receber movimentação", EMovimentExceptionType.INACTIVE_ACCOUNT);

            if (moviment.Valor < 0)
                throw new MovimentException("Apenas valores positivos podem ser recebidos", EMovimentExceptionType.INVALID_VALUE);

            if ((char) moviment.TipoMovimentacao != 'C' && (char) moviment.TipoMovimentacao != 'D')
                throw new MovimentException("Apenas os tipos 'débito' ou 'crédito' podem ser aceitos", EMovimentExceptionType.INVALID_TYPE);

            var query = $"insert into movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) values (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor);";
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();
                using(var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMovimento", Guid.NewGuid().ToString());
                    command.Parameters.AddWithValue("@IdContaCorrente", await contaCorrenteQuery.getIdContaCorrente(moviment.NumeroConta));
                    command.Parameters.AddWithValue("@DataMovimento", DateTime.UtcNow.ToString("dd/MM/yyyy"));
                    command.Parameters.AddWithValue("@TipoMovimento", moviment.TipoMovimentacao);
                    command.Parameters.AddWithValue("@Valor", moviment.Valor);

                    var movimentId =  await command.ExecuteScalarAsync();

                    return new MovimentResponse(movimentId.ToString());
                }
            }
        }


    }
}
