using AgendamentoAPI.DTOs;

namespace AgendamentoAPI.Services
{
    public interface IClienteService
    {
        Task<ClienteResponseDTO> GetById(int id);
        Task<ClienteResponseDTO> Create(ClienteDTO dto);
    }
}
