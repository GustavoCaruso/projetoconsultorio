using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoConsultorio.Domain.entidades;
using ProjetoConsultorio.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Controllers
{
    [ApiController]
    [Route("api/medicoconvenio")]
    public class MedicoConvenioController : Controller
    {


        private readonly SqlServerContext _context;

        public MedicoConvenioController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpPost("associar")]
        public async Task<IActionResult> AssociarMedicoAConvenio(int medicoId, int convenioId)
        {
            try
            {
                // Verifique se o médico e o convênio existem no banco de dados
                var medico = await _context.medico.FindAsync(medicoId);
                var convenio = await _context.convenio.FindAsync(convenioId);

                if (medico == null || convenio == null)
                {
                    return NotFound("Médico ou convênio não encontrado.");
                }

                // Crie uma nova instância de MedicoConvenio e associe os IDs
                var medicoConvenio = new MedicoConvenio
                {
                    medicoId = medico.id,
                    convenioId = convenio.id
                };

                _context.medicoconvenio.Add(medicoConvenio);
                await _context.SaveChangesAsync();

          

                return Ok("Convênio associado ao médico com sucesso.");
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "";
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}. Inner Exception: {innerException}");
                
            }
        }



        [HttpGet("medicosporconvenio/{convenioId}")]
        public IActionResult ObterMedicosPorConvenio(int convenioId)
        {
            var medicosDoConvenio = _context.medicoconvenio
                .Include(mc => mc.medico)
                .Where(mc => mc.convenioId == convenioId)
                .Select(mc => mc.medico)
                .ToList();

            return Ok(medicosDoConvenio);
        }

        [HttpGet("conveniospormedico/{medicoId}")]
        public IActionResult ObterConveniosPorMedico(int medicoId)
        {
            var conveniosDoMedico = _context.medicoconvenio
                .Include(mc => mc.convenio)
                .Where(mc => mc.medicoId == medicoId)
                .Select(mc => mc.convenio)
                .ToList();

            return Ok(conveniosDoMedico);
        }
    }
}

