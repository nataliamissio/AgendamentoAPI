using AgendamentoAPI.Data;
using AgendamentoAPI.DTOs;
using AgendamentoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDTO>> GetById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            var clienteDto = new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };

            return Ok(clienteDto);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var clienteResponse = new ClienteResponseDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };

            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, clienteResponse);
        }
    }
}