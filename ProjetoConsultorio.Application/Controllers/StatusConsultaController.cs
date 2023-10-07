using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConsultorio.Application.Models;
using ProjetoConsultorio.Domain.interfaces;
using ProjetoConsultorio.Service.validators;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusConsultaController : ControllerBase
    {
        //dependa sempre de interface
        private IBaseService<StatusConsulta> _service;

        public StatusConsultaController(IBaseService<StatusConsulta> service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult inserir(StatusConsultaModel StatusConsulta)
        {
            if (StatusConsulta == null)
                return NotFound();
            else
                return Execute(() => _service.Add<StatusConsultaModel, StatusConsultaValidator>(StatusConsulta));
        }

        [HttpPut]
        public IActionResult alterar(StatusConsultaModel StatusConsulta)
        {
            if (StatusConsulta == null)
                return NotFound();
            else
                return Execute(() => _service.Update<StatusConsultaModel, StatusConsultaValidator>(StatusConsulta));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() =>
            {
                _service.Delete(id);
                return true;
            });
            //return new NoContentResult();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _service.GetById<StatusConsultaModel>(id));
        }
        [HttpGet]
        public IActionResult selecionarTodos()
        {

            return Execute(() => _service.Get<StatusConsultaModel>());
        }

        [HttpGet]
        [Route("getStatusConsultaFiltro/{nome}")]
        public IActionResult selecionarStatusConsultaNome(string nome)
        {
            return Execute(() => _service.GetFiltro<StatusConsultaModel>(p => p.nome.Contains(nome), null, null));

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
