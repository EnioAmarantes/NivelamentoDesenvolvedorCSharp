using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class ContaCorrenteException : Exception
    {
        private EContaCorrenteExceptionType type;
        public string Type { get { return GetTypeString(); } }

        public ContaCorrenteException(string message, EContaCorrenteExceptionType type)
            : base(message)
        {
            this.type = type;
        }

        private string GetTypeString()
        {
            switch (type)
            {
                case EContaCorrenteExceptionType.INVALID_ACCOUNT: return "INVALID_ACCOUNT";
                case EContaCorrenteExceptionType.INACTIVE_ACCOUNT: return "INACTIVE_ACCOUNT";
                default: return "INVALID";
            }
        }
    }
}
