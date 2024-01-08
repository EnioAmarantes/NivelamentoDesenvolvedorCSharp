using MediatR;
using System.Text.Json.Serialization;

namespace Questao5.Application.Commands.Responses
{
    public record MovimentoCreateCommandResponse : IRequest
    {
        [JsonPropertyName("idmovimento")]
        public string idmovimento { get; set; }

        public MovimentoCreateCommandResponse(string idmovimento)
            => this.idmovimento = idmovimento;
    }
}
