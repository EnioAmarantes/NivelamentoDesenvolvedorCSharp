namespace Questao5.Application.Commands.Requests
{
    public class MovimentRequest
    {
        public string IdRequisicao { get; set; }
        public int NumeroConta { get; set; }
        public double Valor { get; set; }
        public char TipoMovimentacao { get; set; }
    }
}
