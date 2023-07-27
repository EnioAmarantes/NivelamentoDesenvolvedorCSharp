using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class MovimentException: Exception
    {
        public string Type
        {
            get { return GetTypeString(); }
        }


        private EMovimentExceptionType type { get; set; }
        public MovimentException(string message, EMovimentExceptionType type) 
            : base(message) 
        {
            this.type = type;
        }
        private string GetTypeString()
        {
            switch (type)
            {
                case EMovimentExceptionType.INVALID_ACCOUNT : return "INVALID_ACCOUNT";
                case EMovimentExceptionType.INACTIVE_ACCOUNT : return "INACTIVE_ACCOUNT";
                case EMovimentExceptionType.INVALID_VALUE: return "INVALID_VALUE";
                case EMovimentExceptionType.INVALID_TYPE: return "INVALID_TYPE";
                default: return "INVALID";
            }
        }
    }
}
