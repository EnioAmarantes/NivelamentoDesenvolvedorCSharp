namespace Questao2
{
    public class InvalidYearException: Exception
    {
        public InvalidYearException() : base("O ano deve ser maior que 0 e menor que o ano atual") { }
    }
}
