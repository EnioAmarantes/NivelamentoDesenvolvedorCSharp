using MediatR;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente : IRequest
    {
        public string idcontacorrente {  get; set; }
        public int numero { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public List<Movimento> movimentos { get; private set; }

        public void AddMovimentos(List<Movimento> movimentos)
        {
            this.movimentos = new List<Movimento>();
            this.movimentos.AddRange(movimentos);
        }

        public decimal SomaSaldo()
        {
            if (movimentos is null)
                return 0;

            decimal creditos = movimentos.Where(mov => mov.tipomovimento == 'C').Sum(mov => mov.valor);
            decimal debitos = movimentos.Where(mov => mov.tipomovimento == 'D').Sum(mov => mov.valor);

            return creditos - debitos;
        }
    }
}
