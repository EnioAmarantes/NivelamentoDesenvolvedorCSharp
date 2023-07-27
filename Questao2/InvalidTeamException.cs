namespace Questao2
{
    public class InvalidTeamException: Exception
    {
        public InvalidTeamException() : base("O nome do time deve ser informado") { }
    }
}
