namespace Questao5.Application.Exceptions
{
    public abstract class AccountMovimentException : Exception
    {
        public readonly string TYPE;

        public AccountMovimentException(string type, string message) : base(message)
        {
            TYPE = type;
        }
    }
}
