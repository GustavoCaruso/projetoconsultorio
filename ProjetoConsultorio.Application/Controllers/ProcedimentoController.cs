using Microsoft.AspNetCore.Http;
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
    public class ProcedimentoController : ControllerBase
    {
        //dependa sempre de interface
        private IBaseService<Procedimento> _service;

        public ProcedimentoController(IBaseService<Procedimento> service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult inserir(ProcedimentoModel procedimento)
        {
            if (procedimento == null)
                return NotFound();
            else
                return Execute(() => _service.Add<ProcedimentoModel, ProcedimentoValidator>(procedimento));
        }

        [HttpPut]
        public IActionResult alterar(ProcedimentoModel procedimento)
        {
            if (procedimento == null)
                return NotFound();
            else
                return Execute(() => _service.Update<ProcedimentoModel, ProcedimentoValidator>(procedimento));
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

            return Execute(() => _service.GetById<ProcedimentoModel>(id));
        }
        [HttpGet]
        public IActionResult selecionarTodos()
        {

            return Execute(() => _service.Get<ProcedimentoModel>());
        }

        [HttpGet]
        [Route("getProcedimentoFiltro/{nome}")]
        public IActionResult selecionarProcedimentoNome(string nome)
        {
            return Execute(() => _service.GetFiltro<ProcedimentoModel>(p => p.nome.Contains(nome), null, null));

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
