using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendamentoAPI.Data;
using AgendamentoAPI.Models;
using AgendamentoAPI.DTOs;

namespace AgendamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgendamentoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agendamento = new Agendamento
            {
                ClienteId = dto.ClienteId,
                DataHora = dto.DataHora,
                Servico = dto.Observacoes
            };

            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            var response = new AgendamentoResponseDTO
            {
                Id = agendamento.Id,
                ClienteId = agendamento.ClienteId,
                DataHora = agendamento.DataHora,
                Observacoes = agendamento.Servico
            };

            return Ok(response);
        }
    }
}
