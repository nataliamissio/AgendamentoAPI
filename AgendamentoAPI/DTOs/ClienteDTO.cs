using System.ComponentModel.DataAnnotations;

namespace AgendamentoAPI.DTOs
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "O telefone não pode ter mais de 20 caracteres")]
        public string Telefone { get; set; }
    }
}