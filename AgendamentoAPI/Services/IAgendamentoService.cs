using AgendamentoAPI.DTOs;

namespace AgendamentoAPI.Services
{
    public interface IAgendamentoService
    {
        Task<List<AgendamentoResponseDTO>> GetAll();
        Task<AgendamentoResponseDTO> GetById(int id);
        Task<AgendamentoResponseDTO> Create(AgendamentoDTO dto);
    }
}
