namespace Questao5.Domain.Entities
{
    public record Idempotency
    {
        public string chave_idempotencia { get; set; }
        public string requisicao { get; set; }
        public string resultado { get; set; }
    }
}
