using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpCertificadoVrs2.data;
using MpCertificadoVrs2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MpCertificadoVrs2.Controllers
{
    [Route("Pagamento/[controller]")]
    [ApiController]
    public class CadastroPagamentoController : ControllerBase
    {
        private readonly DataContext _context;

        public CadastroPagamentoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<CadastroPagamento>>> ListarCadastroPagamentos()
        {
            return await _context.CadastroPagamentos.ToListAsync();
        }

        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult<CadastroPagamento>> BuscarCadastroPagamento(int id)
        {
            var cadastroPagamento = await _context.CadastroPagamentos.FindAsync(id);

            if (cadastroPagamento == null)
            {
                return NotFound();
            }

            return cadastroPagamento;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<CadastroPagamento>> CadastrarCadastroPagamento(CadastroPagamento cadastroPagamento)
        {
            _context.CadastroPagamentos.Add(cadastroPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarCadastroPagamento), new { id = cadastroPagamento.IdCartao }, cadastroPagamento);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> AtualizarCadastroPagamento(int id, CadastroPagamento cadastroPagamento)
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

        [HttpDelete("Excluir/{id}")]
        public async Task<ActionResult<CadastroPagamento>> ExcluirCadastroPagamento(int id)
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
