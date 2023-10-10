using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MpCertificadoVrs2.data;
using MpCertificadoVrs2.Models;

namespace MpCertificadoVrs2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcCertificadoraController : ControllerBase
    {
        private readonly DataContext _context;

        public AcCertificadoraController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcCertificadoraTeste>>> GetAcCertificadoras()
        {
            var certificadoras = await _context.AcCertificadoraTestes.ToListAsync();
            return Ok(certificadoras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcCertificadoraTeste>> GetAcCertificadora(int id)
        {
            var certificadora = await _context.AcCertificadoraTestes.FindAsync(id);

            if (certificadora == null)
            {
                return NotFound();
            }

            return Ok(certificadora);
        }

        [HttpPost]
        public async Task<ActionResult<AcCertificadoraTeste>> PostAcCertificadora(AcCertificadoraTeste certificadora)
        {
            _context.AcCertificadoraTestes.Add(certificadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcCertificadora", new { id = certificadora.IdCertificadora }, certificadora);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcCertificadora(int id, AcCertificadoraTeste certificadora)
        {
            if (id != certificadora.IdCertificadora)
            {
                return BadRequest();
            }

            _context.Entry(certificadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadoraExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcCertificadora(int id)
        {
            var certificadora = await _context.AcCertificadoraTestes.FindAsync(id);
            if (certificadora == null)
            {
                return NotFound();
            }

            _context.AcCertificadoraTestes.Remove(certificadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificadoraExists(int id)
        {
            return _context.AcCertificadoraTestes.Any(e => e.IdCertificadora == id);
        }
    }
}
