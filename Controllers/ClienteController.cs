using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpCertificadoVrs2.Models;
using MpCertificadoVrs2.data;


namespace MpCertificadoVrs2.Controllers 
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetListagem()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("detalhes/{id}")]
        public async Task<IActionResult> GetDetalhes(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(cliente);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> PostCriar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetListagem), new { id = cliente.Id }, cliente);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> PutEditar(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("IDs não correspondem.");
            }

            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> DeleteExcluir(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}