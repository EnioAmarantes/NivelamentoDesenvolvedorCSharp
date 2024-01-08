using MediatR;

namespace Questao5.Domain.Entities
{
    public record Movimento : IRequest
    {
        public string Id { get; set; }
        public string idcontacorrente { get; set; }
        public DateTime datamovimento { get; set; }
        public char tipomovimento { get; set; }
        public decimal valor { get; set; }
    }
}
