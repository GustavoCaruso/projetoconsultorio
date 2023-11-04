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
    public class ConvenioController : Controller
    {
        //dependa sempre de interface
        private IBaseService<Convenio> _service;

        public ConvenioController(IBaseService<Convenio> service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult Inserir(ConvenioModel convenio)
        {
            
                if (convenio == null)
                    return NotFound();

                
                convenio.medicoConvenio = null; 

               
                return Execute(() => _service.Add<ConvenioModel, ConvenioValidator>(convenio));

               
           
            
        }



        [HttpPut]
        public IActionResult alterar(ConvenioModel convenio)
        {
            if (convenio == null)
                return NotFound();
            else
                return Execute(() => _service.Update<ConvenioModel, ConvenioValidator>(convenio));
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
           
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _service.GetById<ConvenioModel>(id));
        }
        [HttpGet]
        public IActionResult selecionarTodos()
        {

            return Execute(() => _service.Get<ConvenioModel>());
        }

        [HttpGet]
        [Route("getConvenioFiltro/{nome}")]
        public IActionResult selecionarConvenioNome(string nome)
        {
            return Execute(() => _service.GetFiltro<ConvenioModel>(p => p.nome.Contains(nome), null, null));

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
