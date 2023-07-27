namespace Questao2
{
    public record FootballResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public Jogo[] data { get; set; }
    }
}
