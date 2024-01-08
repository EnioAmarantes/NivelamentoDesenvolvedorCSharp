using NSubstitute.Routing.Handlers;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Database.Interfaces;
using System.Globalization;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class MovimentoCreateStoreRequest : IStore<MovimentoCreateStoreResponse>
    {
        private readonly Guid idmovimento;
        private readonly string idcontacorrente;
        private readonly char tipomovimento;
        private readonly decimal valor;

        public string GetIdMovimento()
            => idmovimento.ToString();

        public MovimentoCreateStoreRequest(string idcontacorrente, char tipomovimento, decimal valor)
        {
            this.idmovimento = Guid.NewGuid();
            this.idcontacorrente = idcontacorrente;
            this.tipomovimento = tipomovimento;
            this.valor = valor;
        }

        public string GetSql()
        {
            return $"insert into movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) values('{idmovimento.ToString()}','{idcontacorrente}', '{DateTime.Now.ToString("dd/MM/yyyy")}', '{tipomovimento}', {valor.ToString("N2", new CultureInfo("en-us"))});";
        }
    }
}
