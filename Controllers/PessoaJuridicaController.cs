using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MpCertificadoVrs2.data;
using MpCertificadoVrs2.Models;

namespace MpCertificadoVrs2.Controllers
{
    [Route("api/pessoasjuridicas")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly DataContext _context;

        public PessoaJuridicaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("listagem")]
        public async Task<ActionResult<IEnumerable<PessoaJuridica>>> Listagem()
        {
            var pessoasJuridicas = await _context.PessoasJuridicas.ToListAsync();
            return Ok(pessoasJuridicas);
        }

        [HttpGet("detalhes/{id}")]
        public async Task<ActionResult<PessoaJuridica>> Detalhes(int id)
        {
            var pessoaJuridica = await _context.PessoasJuridicas.FirstOrDefaultAsync(pj => pj.Id == id);

            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return Ok(pessoaJuridica);
        }

        //Opção de criar ja com opção de validar Cnpj
        [HttpPost("criar")]
        public async Task<ActionResult<PessoaJuridica>> Criar(PessoaJuridica pessoaJuridica)
        {
            if (!pessoaJuridica.IsValidCnpj())
            {
                ModelState.AddModelError(nameof(PessoaJuridica.Cnpj), "CNPJ inválido.");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                _context.Add(pessoaJuridica);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Listagem), new { id = pessoaJuridica.Id }, pessoaJuridica);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, PessoaJuridica pessoaJuridica)
        {
            if (id != pessoaJuridica.Id)
            {
                return BadRequest();
            }

            if (!pessoaJuridica.IsValidCnpj())
            {
                ModelState.AddModelError(nameof(PessoaJuridica.Cnpj), "CNPJ inválido.");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                _context.Update(pessoaJuridica);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var pessoaJuridica = await _context.PessoasJuridicas.FirstOrDefaultAsync(pj => pj.Id == id);

            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            _context.PessoasJuridicas.Remove(pessoaJuridica);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}