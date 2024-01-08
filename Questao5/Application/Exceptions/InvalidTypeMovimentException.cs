namespace Questao5.Application.Exceptions
{
    public class InvalidTypeMovimentException : AccountMovimentException
    {
        public InvalidTypeMovimentException(char type) 
            : base("INVALIDTYPE", "O tipo de movimentação deve ser 'C' para Crédito ou 'D' para Depósito")
        {
        }
    }
}
