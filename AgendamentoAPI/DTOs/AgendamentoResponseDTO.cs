namespace AgendamentoAPI.DTOs
{
    public class AgendamentoResponseDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataHora { get; set; }
        public string? Observacoes { get; set; }
    }
}
