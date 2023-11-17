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
    [Route("MpCertificadoAnuncio/[controller]")]
    [ApiController]
    public class CertificadoAnuncioController : ControllerBase
    {
        private readonly DataContext _context;

        public CertificadoAnuncioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public ActionResult<IEnumerable<CertificadoAnuncio>> ListarCertificados()
        {
            return _context.CertificadoAnuncios.ToList();
        }

        [HttpGet("Buscar/{idCertificadoA}")]
        public ActionResult<CertificadoAnuncio> BuscarCertificado(int idCertificadoA)
        {
            var certificado = _context.CertificadoAnuncios.Find(idCertificadoA);

            if (certificado == null)
            {
                return NotFound();
            }

            return certificado;
        }

        [HttpPost("Cadastrar")]
        public ActionResult<CertificadoAnuncio> CadastrarCertificado([FromBody] CertificadoAnuncio certificado)
        {
            _context.CertificadoAnuncios.Add(certificado);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarCertificado), new { id = certificado.IdCertificadoA }, certificado);
        }

        [HttpPut("Atualizar/{idCertificadoA}")]
        public IActionResult AtualizarCertificado(int idCertificadoA, CertificadoAnuncio certificado)
        {
            if (idCertificadoA != certificado.IdCertificadoA)
            {
                return BadRequest();
            }

            _context.Entry(certificado).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("Excluir/{idCertificadoA}")]
        public IActionResult ExcluirCertificado(int idCertificadoA)
        {
            var certificado = _context.CertificadoAnuncios.Find(idCertificadoA);

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
