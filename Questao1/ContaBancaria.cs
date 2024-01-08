using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria : IContaBancaria {
        public int NumeroConta { get; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numeroConta, string titular, double saldo = 0.0)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldo;
        }

        public void Deposito(double saldoDeposito)
        {
            Saldo += Math.Abs(saldoDeposito);
        }

        public void Saque(double saque)
        {
            Saldo -= (Taxas.TaxaSaque + Math.Abs(saque));
        }

        public override string ToString()
        {
            return $"Conta {NumeroConta}, Titular: {Titular}, Saldo: { Saldo.ToString("C2", new CultureInfo("pt-br")) }";
        }
    }
}
