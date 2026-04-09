using AgendamentoAPI.Data;
using AgendamentoAPI.DTOs;
using AgendamentoAPI.Models;
using AgendamentoAPI.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class AgendamentoService : IAgendamentoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AgendamentoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AgendamentoResponseDTO>> GetAll()
    {
        var agendamentos = await _context.Agendamentos.ToListAsync();

        return _mapper.Map<List<AgendamentoResponseDTO>>(agendamentos);
    }

    public async Task<AgendamentoResponseDTO> GetById(int id)
    {
        var agendamento = await _context.Agendamentos.FindAsync(id);

        if (agendamento == null)
            return null;

        return _mapper.Map<AgendamentoResponseDTO>(agendamento);
    }

    public async Task<AgendamentoResponseDTO> Create(AgendamentoDTO dto)
    {
        var clienteExiste = await _context.Clientes
            .AnyAsync(c => c.Id == dto.ClienteId);

        if (!clienteExiste)
            return null;

        var agendamento = _mapper.Map<Agendamento>(dto);

        _context.Agendamentos.Add(agendamento);
        await _context.SaveChangesAsync();

        return _mapper.Map<AgendamentoResponseDTO>(agendamento);
    }

    public async Task<AgendamentoResponseDTO> Update(int id, AgendamentoDTO dto)
    {
        var agendamento = await _context.Agendamentos.FindAsync(id);

        if (agendamento == null)
            return null;

        var clienteExiste = await _context.Clientes
            .AnyAsync(c => c.Id == dto.ClienteId);

        if (!clienteExiste)
            return null;

        // Atualiza os dados
        agendamento.ClienteId = dto.ClienteId;
        agendamento.DataHora = dto.DataHora;
        agendamento.Servico = dto.Servico;

        await _context.SaveChangesAsync();

        return _mapper.Map<AgendamentoResponseDTO>(agendamento);
    }

    public async Task<bool> Delete(int id)
    {
        var agendamento = await _context.Agendamentos.FindAsync(id);

        if (agendamento == null)
            return false;

        _context.Agendamentos.Remove(agendamento);
        await _context.SaveChangesAsync();

        return true;
    }
}