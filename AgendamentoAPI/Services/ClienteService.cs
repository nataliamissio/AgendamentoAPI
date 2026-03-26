using AgendamentoAPI.Data;
using AgendamentoAPI.DTOs;
using AgendamentoAPI.Models;
using AgendamentoAPI.Services;
using AutoMapper;

public class ClienteService : IClienteService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ClienteService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ClienteResponseDTO> GetById(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
            return null;

        return _mapper.Map<ClienteResponseDTO>(cliente);
    }

    public async Task<ClienteResponseDTO> Create(ClienteDTO dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return _mapper.Map<ClienteResponseDTO>(cliente);
    }
}