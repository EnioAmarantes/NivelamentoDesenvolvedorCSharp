namespace Questao5.Application.Queries.Responses
{
    public class SaldoContaResponse
    {
        public int NumeroConta { get; set; }
        public string Titular { get; set; }
        public DateTime DataRequisicao { get; set; }
        public double Saldo { get; set; }

        public SaldoContaResponse(int numeroConta, string titular, double saldo)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            DataRequisicao = DateTime.UtcNow;
            Saldo = saldo;
        }
    }
}
