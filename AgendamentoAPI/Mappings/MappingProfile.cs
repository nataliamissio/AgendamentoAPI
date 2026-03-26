using AutoMapper;

namespace AgendamentoAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configurações de mapeamento
            CreateMap<Models.Cliente, DTOs.ClienteResponseDTO>();
            CreateMap<DTOs.ClienteDTO, Models.Cliente>();
        }
    }
}
