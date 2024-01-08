namespace Questao2.Exceptions
{
    internal class InvalidTeamException : Exception
    {
        public InvalidTeamException() : base("O nome do time deve ser informado") { }
    }
}
