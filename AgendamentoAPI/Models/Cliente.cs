namespace AgendamentoAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        // Relacionamento com Agendamento
        public List<Agendamento>? Agendamentos { get; set; }
    }
}
