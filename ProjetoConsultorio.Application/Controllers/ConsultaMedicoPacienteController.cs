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
    [Route("api/consultamedicopaciente")]
    public class ConsultaMedicoPacienteController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public ConsultaMedicoPacienteController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpPost("agendar-consulta")]
        public async Task<IActionResult> AgendarConsulta(int pacienteId, DateTime dataHora, int medicoId)
        {
            try
            {
                var paciente = await _context.paciente.FindAsync(pacienteId);

                if (paciente == null)
                {
                    return NotFound("Paciente não encontrado.");
                }

                var medico = await _context.medico.FindAsync(medicoId);

                if (medico == null)
                {
                    return NotFound("Médico não encontrado.");
                }

               

                var consulta = new ConsultaMedicoPaciente
                {
                    Medico = medico,
                    Paciente = paciente,
                    DataHora = dataHora
                };

                _context.consultamedicopaciente.Add(consulta);
                await _context.SaveChangesAsync();

                return Ok("Consulta agendada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }


        /* private async Task<bool> VerificarDisponibilidadeMedico(Medico medico, DateTime dataHora)
         {
             // Aqui você deve implementar a lógica para verificar a disponibilidade do médico.
             // Por exemplo, consultar as consultas agendadas para o médico na data e hora especificadas.
             // Certifique-se de que o médico não tenha outra consulta no mesmo horário.

             // Exemplo hipotético:
             // var consultasAgendadas = await _context.consultamedicopaciente
             //     .Where(c => c.MedicoId == medico.id && c.DataHora == dataHora)
             //     .ToListAsync();

             // return consultasAgendadas.Count == 0;

             // Neste exemplo, retornamos verdadeiro se não houver consultas agendadas para o médico na mesma data e hora.
             // Você precisa implementar a lógica de disponibilidade de acordo com seu modelo de dados.

             // Este é apenas um exemplo genérico. A implementação real depende de como sua lógica de agendamento funciona.

             return true;
         }*/
    }
}
