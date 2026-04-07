using System.ComponentModel.DataAnnotations;

namespace AgendamentoAPI.DTOs
{
    public class AgendamentoDTO
    {
        public int ClienteId { get; set; }
        public DateTime DataHora { get; set; }
        public string? Servico { get; set; }
    }
}