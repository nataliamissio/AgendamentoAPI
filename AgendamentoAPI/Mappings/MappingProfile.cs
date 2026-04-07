using AgendamentoAPI.DTOs;
using AgendamentoAPI.Models;
using AutoMapper;

namespace AgendamentoAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configurações de mapeamento
            CreateMap<Cliente, ClienteResponseDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Agendamento, AgendamentoResponseDTO>();
            CreateMap<AgendamentoDTO, Agendamento>();
        }
    }
}
