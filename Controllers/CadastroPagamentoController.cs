using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpCertificadoVrs2.data;
using MpCertificadoVrs2.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MpCertificadoVrs2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroPagamentoController : ControllerBase
    {
        private readonly DataContext _context;

        public CadastroPagamentoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CadastroPagamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroPagamento>>> GetCadastroPagamentos()
        {
            return await _context.CadastroPagamentos.ToListAsync();
        }

        // GET: api/CadastroPagamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroPagamento>> GetCadastroPagamento(int id)
        {
            var cadastroPagamento = await _context.CadastroPagamentos.FindAsync(id);

            if (cadastroPagamento == null)
            {
                return NotFound();
            }

            return cadastroPagamento;
        }

        // POST: api/CadastroPagamento
        [HttpPost]
        public async Task<ActionResult<CadastroPagamento>> PostCadastroPagamento(CadastroPagamento cadastroPagamento)
        {
            _context.CadastroPagamentos.Add(cadastroPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastroPagamento", new { id = cadastroPagamento.IdCartao }, cadastroPagamento);
        }

        // PUT: api/CadastroPagamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastroPagamento(int id, CadastroPagamento cadastroPagamento)
        {
            if (id != cadastroPagamento.IdCartao)
            {
                return BadRequest();
            }

            _context.Entry(cadastroPagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroPagamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/CadastroPagamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CadastroPagamento>> DeleteCadastroPagamento(int id)
        {
            var cadastroPagamento = await _context.CadastroPagamentos.FindAsync(id);
            if (cadastroPagamento == null)
            {
                return NotFound();
            }

            _context.CadastroPagamentos.Remove(cadastroPagamento);
            await _context.SaveChangesAsync();

            return cadastroPagamento;
        }

        private bool CadastroPagamentoExists(int id)
        {
            return _context.CadastroPagamentos.Any(e => e.IdCartao == id);
        }
    }
}
