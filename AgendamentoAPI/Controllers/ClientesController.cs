using AgendamentoAPI.Data;
using AgendamentoAPI.DTOs;
using AgendamentoAPI.Models;
using AgendamentoAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;


        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        // GET: api/clientes
        [HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
{
    var cliente = await _service.GetById(id);

    if (cliente == null)
        return NotFound();

    return Ok(cliente);
}

        // POST: api/clientes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = await _service.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }
    }
}