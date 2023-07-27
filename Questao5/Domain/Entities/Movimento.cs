
using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public string idmovimento { get; set; }
        public int idcontacorrente { get; set; }
        public string datamovimento { get; set; }
        private EMovimentType tipomovimentacao;
        public double valor { get; set; }

        public Movimento(int idcontacorrente, EMovimentType tipomovimentacao, double valor)
        {
            this.idmovimento = String.Empty;
            this.datamovimento = DateTime.UtcNow.ToString("dd/MM/yyyy");
            this.idcontacorrente = idcontacorrente;
            this.tipomovimentacao = tipomovimentacao;
            this.valor = valor;
        }

    }
}
