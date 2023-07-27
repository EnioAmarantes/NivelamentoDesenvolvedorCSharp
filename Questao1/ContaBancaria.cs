namespace Questao1
{
    class ContaBancaria {
        public int NumeroConta { get; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        public double Taxa { get; }
        public char Symbol { get; }

        public ContaBancaria(int numeroConta, string titular, double saldoInicial = 0.0)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldoInicial;
            Taxa = 3.5;
            Symbol = '$';
        }

        public void Deposito(double saldoDeposito)
        {
            Saldo += saldoDeposito;
        }

        public void Saque(double saque)
        {
            Saldo -= (Taxa + saque);
        }

        public override string ToString()
        {
            //Vou utilizar o Symbol para no futuro possa trabalhar com câmbio também, poderia usar o C2
            // no ToString para formatar na moeda corrente do SO do usuário.
            return $"Conta {NumeroConta}, Titular: {Titular}, Saldo: {Symbol} {Saldo.ToString("N2")}";
        }
    }
}
