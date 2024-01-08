namespace Questao5.Application.Exceptions
{
    public class InvalidAccountException : AccountMovimentException
    {
        public InvalidAccountException(int numero)
            : base("INVALID_ACCOUNT", $"Conta com o número {numero} não encontrada")
        { }
    }
}
