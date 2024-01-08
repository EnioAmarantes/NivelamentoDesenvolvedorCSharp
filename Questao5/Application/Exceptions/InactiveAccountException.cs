namespace Questao5.Application.Exceptions
{
    public class InactiveAccountException : AccountMovimentException
    {
        public InactiveAccountException(int numero)
            : base("INACTIVE_ACCOUNT", $"Conta com o número {numero} encontrasse inativa")
        { }
    }
}
