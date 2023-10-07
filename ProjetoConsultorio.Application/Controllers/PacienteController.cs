using Microsoft.AspNetCore.Mvc;
using ProjetoConsultorio.Application.Models;
using ProjetoConsultorio.Domain.entidades;
using ProjetoConsultorio.Domain.interfaces;
using ProjetoConsultorio.Service.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private IBaseService<Paciente> _service;

        public PacienteController(IBaseService<Paciente> service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult inserir(PacienteModel Paciente)
        {
            if (Paciente == null)
                return NotFound();
            return Execute(() => _service.Add<PacienteModel,
                PacienteValidator>(Paciente));

        }

        [HttpPut]
        public IActionResult alterar(PacienteModel Paciente)
        {
            if (Paciente == null)
                return NotFound();
            else
                return Execute(() => _service.Update<PacienteModel,
                    PacienteValidator>(Paciente));

        }

        [HttpDelete("{id}")]
        public IActionResult excluir(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => { _service.Delete(id); return true; });

           

        }

        [HttpGet]
        public IActionResult selecionarTodos()
        {
            //select * from Pacientes
            return Execute(() => _service.Get<PacienteModel>());
        }

        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => _service.GetById<PacienteModel>(id));
        }



        
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
