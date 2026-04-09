using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendamentoAPI.Data;
using AgendamentoAPI.Models;
using AgendamentoAPI.DTOs;
using AutoMapper;
using AgendamentoAPI.Services;

namespace AgendamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
       private readonly IAgendamentoService _service;

        public AgendamentosController(IAgendamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgendamentoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agendamento = await _service.Create(dto);

            if (agendamento == null)
                return BadRequest("Cliente não encontrado");

            return Ok(agendamento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _service.GetById(id);

            if (agendamento == null)
                return NotFound();

            return Ok(agendamento);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agendamentos = await _service.GetAll();

            return Ok(agendamentos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AgendamentoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agendamento = await _service.Update(id, dto);

            if (agendamento == null)
                return NotFound();

            return Ok(agendamento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.Delete(id);

            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
