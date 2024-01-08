namespace Questao5.Application.Exceptions
{
    public class InvalidValueMovimentException : AccountMovimentException
    {
        public InvalidValueMovimentException(decimal valor) 
            : base("INVALID_VALUE", $"O valor {valor} é inválido")
        {
        }
    }
}
