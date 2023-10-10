using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MpCertificadoVrs2.data;
using MpCertificadoVrs2.Models;

namespace MpCertificadoVrs2.Controllers
{
    [Route("api/certificadoproduto")]
    [ApiController]
    public class CertificadoProdutoController : ControllerBase
    {
        private readonly DataContext _context;

        public CertificadoProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCertificadoProdutos()
        {
            var certificadoProdutos = await _context.CertificadoProdutos.ToListAsync();
            return Ok(certificadoProdutos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificadoProduto(int id)
        {
            var certificadoProduto = await _context.CertificadoProdutos.FindAsync(id);

            if (certificadoProduto == null)
                return NotFound();

            return Ok(certificadoProduto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCertificadoProduto(CertificadoProduto certificadoProduto)
        {
            _context.CertificadoProdutos.Add(certificadoProduto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCertificadoProduto), new { id = certificadoProduto.IdCertificadoP }, certificadoProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertificadoProduto(int id, CertificadoProduto certificadoProduto)
        {
            if (id != certificadoProduto.IdCertificadoP)
                return BadRequest();

            _context.Entry(certificadoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CertificadoProdutos.Any(e => e.IdCertificadoP == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificadoProduto(int id)
        {
            var certificadoProduto = await _context.CertificadoProdutos.FindAsync(id);

            if (certificadoProduto == null)
                return NotFound();

            _context.CertificadoProdutos.Remove(certificadoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}