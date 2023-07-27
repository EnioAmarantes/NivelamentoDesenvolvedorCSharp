namespace Questao5.Application.Commands.Responses
{
    public class MovimentResponse
    {
        public string IdMovimento { get; set; }
        public MovimentResponse(string id)
        {
            IdMovimento = id;
        }

    }
}
