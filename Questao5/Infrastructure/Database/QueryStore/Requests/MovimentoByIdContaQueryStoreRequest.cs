using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class MovimentoByIdContaQueryStoreRequest : IStore<List<Movimento>>
    {
        private readonly string IdContaCorrente;

        public MovimentoByIdContaQueryStoreRequest(string idcontacorrente)
        {
            IdContaCorrente = idcontacorrente;
        }
        public string GetSql()
        {
            return $"select * from movimento where idcontacorrente = '{IdContaCorrente}'";
        }
    }
}
