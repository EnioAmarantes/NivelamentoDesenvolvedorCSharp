using Microsoft.Extensions.Options;
using Questao5.Domain.Enumerators;

namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public class MovimentoSaldo
    {
        public EMovimentType TipoMovimentacao { get; private set; }
        public double Valor { get; private set; }

        public MovimentoSaldo(EMovimentType tipo, double valor)
        {
            this.TipoMovimentacao = tipo;
            this.Valor = valor;
        }

    }
}
