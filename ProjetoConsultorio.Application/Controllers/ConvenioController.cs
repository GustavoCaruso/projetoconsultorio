using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConsultorio.Domain.entidades;
using ProjetoConsultorio.Service.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoConsultorio.Application.Models;
using ProjetoConsultorio.Domain.interfaces;
using ProjetoConsultorio.Service.validators;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoConsultorio.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        //dependa sempre de interface
        private IBaseService<Convenio> _service;

        public ConvenioController(IBaseService<Convenio> service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult inserir(ConvenioModel Convenio)
        {
            if (Convenio == null)
                return NotFound();
            else
                return Execute(() => _service.Add<ConvenioModel, ConvenioValidator>(Convenio));

        }

        [HttpPut]
        public IActionResult alterar(ConvenioModel Convenio)
        {
            if (Convenio == null)
                return NotFound();
            else
                return Execute(() => _service.Update<ConvenioModel,
                    ConvenioValidator>(Convenio));

        }


        [HttpDelete("{id}")]
        public IActionResult excluir(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => { _service.Delete(id); return true; });

            //return new NoContentResult();

        }


        [HttpGet]
        [Authorize]
        public IActionResult selecionarTodos()
        {
            //select * from Convenios
            return Execute(() => _service.Get<ConvenioModel>());
        }


        [HttpGet]
        [Route("getConvenioFiltro/{descricao}")]
        public IActionResult selecionarConvenioNome(String descricao)
        {
            //select * from Convenios where descricao like '%des%' order by descricao
            return Execute(() => _service.GetFiltro<ConvenioModel>(
                p => p.nome.Contains(descricao), //where
                p => p.OrderBy(p => p.nome),//order by
                null, null)); //include, top

        }




        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => _service.GetById<ConvenioModel>(id));
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
