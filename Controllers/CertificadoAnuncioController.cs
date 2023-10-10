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
    [Route("api/[controller]")]
    [ApiController]
    public class CertificadoAnuncioController : ControllerBase
    {
        private readonly DataContext _context;

        public CertificadoAnuncioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CertificadoAnuncio>> GetCertificados()
        {
            return _context.CertificadoAnuncios.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CertificadoAnuncio> GetCertificado(int id)
        {
            var certificado = _context.CertificadoAnuncios.Find(id);

            if (certificado == null)
            {
                return NotFound();
            }

            return certificado;
        }

        [HttpPost]
        [HttpPost]
        public ActionResult<CertificadoAnuncio> PostCertificado([FromBody] CertificadoAnuncio certificado)
        {
            _context.CertificadoAnuncios.Add(certificado);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCertificado), new { id = certificado.IdCertificadoA }, certificado);
        }

        [HttpPut("{id}")]
        public IActionResult PutCertificado(int id, CertificadoAnuncio certificado)
        {
            if (id != certificado.IdCertificadoA)
            {
                return BadRequest();
            }

            _context.Entry(certificado).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCertificado(int id)
        {
            var certificado = _context.CertificadoAnuncios.Find(id);

            if (certificado == null)
            {
                return NotFound();
            }

            _context.CertificadoAnuncios.Remove(certificado);
            _context.SaveChanges();

            return NoContent();
        }
    }
}