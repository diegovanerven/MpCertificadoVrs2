using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpCertificado.Models;
using MpCertificadoVrs2.Dto;
using MpCertificadoVrs2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MpCertificadoVrs2.data;

namespace MpCertificadoVrs2.Controllers
{
    [Route("api/carrinhos")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly DataContext _context;

        public CarrinhoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("listagem")]
        public async Task<ActionResult<IEnumerable<Carrinho>>> Listagem()
        {
            var carrinhos = await _context.Carrinhos
                .Include(c => c.Cliente)
                .Include(c => c.CertificadoAnuncio)
                .ToListAsync();

            return Ok(carrinhos);
        }

        [HttpGet("detalhes/{id}")]
        public async Task<ActionResult<Carrinho>> Detalhes(int id)
        {
            var carrinho = await _context.Carrinhos
                .Include(c => c.Cliente)
                .Include(c => c.CertificadoAnuncio)
                .FirstOrDefaultAsync(c => c.IdCarrinho == id);

            if (carrinho == null)
            {
                return NotFound();
            }

            return Ok(carrinho);
        }

        [HttpPost("criar")]
        public async Task<ActionResult<Carrinho>> Criar([FromBody] CarrinhoCriarDto carrinhoDto)
        {
            if (ModelState.IsValid)
            {
                // Verificar se o Cliente e o CertificadoAnuncio existem
                var cliente = await _context.Clientes.FindAsync(carrinhoDto.ClienteId);
                var certificadoAnuncio = await _context.CertificadoAnuncios.FindAsync(carrinhoDto.CertificadoAnuncioId);

                if (cliente == null || certificadoAnuncio == null)
                {
                    return BadRequest("Cliente ou CertificadoAnuncio não encontrado.");
                }

                // Criar um novo Carrinho com base nos IDs fornecidos
                var novoCarrinho = new Carrinho
                {
                    ClienteId = carrinhoDto.ClienteId,
                    CertificadoAnuncioId = carrinhoDto.CertificadoAnuncioId,
                    // Outras propriedades que você pode querer definir aqui
                };

                _context.Add(novoCarrinho);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Listagem), new { id = novoCarrinho.IdCarrinho }, novoCarrinho);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, Carrinho carrinho)
        {
            if (id != carrinho.IdCarrinho)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(carrinho);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var carrinho = await _context.Carrinhos.FirstOrDefaultAsync(c => c.IdCarrinho == id);

            if (carrinho == null)
            {
                return NotFound();
            }

            _context.Carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}