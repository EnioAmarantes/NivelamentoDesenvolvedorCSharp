using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class MovimentacaoQueryRequest
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentacaoQueryRequest(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<MovimentoSaldo>> ObterMovimentacoes(string IdContaCorrente)
        {
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();

                var query = $"select tipomovimento, valor from movimento where idcontacorrente = '{IdContaCorrente}';";
                var result = await connection.QueryAsync<char, double, MovimentoSaldo>(
                    query,
                    map: (tipo, valor) =>
                    {
                        return new MovimentoSaldo((EMovimentType)tipo, valor);
                    },
                    splitOn: "valor"
                    );

                return result.ToList();
            }
        }
    }
}
