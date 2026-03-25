namespace AgendamentoAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Servico { get; set; }

        // Relacionamento com Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
