using System.ComponentModel.DataAnnotations;

namespace AgendamentoAPI.DTOs
{
    public class AgendamentoDTO
    {
        [Required(ErrorMessage = "O Id do cliente é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "A data e hora do agendamento são obrigatórias")]
        public DateTime DataHora { get; set; }

        [StringLength(250, ErrorMessage = "As observações não podem ter mais de 250 caracteres")]
        public string Observacoes { get; set; }
    }
}