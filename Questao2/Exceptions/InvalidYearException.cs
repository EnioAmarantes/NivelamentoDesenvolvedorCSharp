namespace Questao2.Exceptions
{
    internal class InvalidYearException : Exception
    {
        public InvalidYearException() : base("O ano deve ser maior que 0 e menor que o ano atual") { }
    }
}
