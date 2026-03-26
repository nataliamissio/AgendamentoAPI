using AgendamentoAPI.Data;
using AgendamentoAPI.DTOs;
using AgendamentoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClientesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/clientes
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDTO>> GetById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            var clienteDto = _mapper.Map<ClienteResponseDTO>(cliente);

            return Ok(clienteDto);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = _mapper.Map<Cliente>(dto);

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var clienteResponse = _mapper.Map<ClienteResponseDTO>(cliente);

            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, clienteResponse);
        }
    }
}