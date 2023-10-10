using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MpCertificadoVrs2.data;
using MpCertificadoVrs2.Models;

namespace MpCertificadoVrs2.Controllers
{
    [Route("api/pessoasfisicas")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly DataContext _context;

        public PessoaFisicaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("listagem")]
        public async Task<ActionResult<IEnumerable<PessoaFisica>>> Listagem()
        {
            var pessoasFisicas = await _context.PessoasFisicas.ToListAsync();
            return Ok(pessoasFisicas);
        }

        [HttpGet("detalhes/{id}")]
        public async Task<ActionResult<PessoaFisica>> Detalhes(int id)
        {
            var pessoaFisica = await _context.PessoasFisicas.FirstOrDefaultAsync(pf => pf.Id == id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return Ok(pessoaFisica);
        }

        [HttpGet("buscarPorCpf/{cpf}")]
        public async Task<ActionResult<PessoaFisica>> BuscarPorCpf(string cpf)
        {
            var pessoaFisica = await _context.PessoasFisicas.FirstOrDefaultAsync(pf => pf.Cpf == cpf);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return Ok(pessoaFisica);
        }


        //Opção de criar ja com validação de Cpf 
        [HttpPost("criar")]
        public async Task<ActionResult<PessoaFisica>> Create([FromBody] PessoaFisica pessoaFisica)
        {
            if (!pessoaFisica.IsValidCpf())
            {
                ModelState.AddModelError(nameof(PessoaFisica.Cpf), "CPF inválido.");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                _context.Add(pessoaFisica);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Listagem), new { id = pessoaFisica.Id }, pessoaFisica);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Id)
            {
                return BadRequest();
            }

            if (!pessoaFisica.IsValidCpf())
            {
                ModelState.AddModelError(nameof(PessoaFisica.Cpf), "CPF inválido.");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                _context.Update(pessoaFisica);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pessoaFisica = await _context.PessoasFisicas.FirstOrDefaultAsync(pf => pf.Id == id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            _context.PessoasFisicas.Remove(pessoaFisica);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}