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


namespace ProjetoConsultorio.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        //dependa sempre de interface
        private IBaseService<Medico> _service;

        public MedicoController(IBaseService<Medico> service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult inserir(MedicoModel Medico)
        {
            if (Medico == null)
                return NotFound();
            else
                return Execute(() => _service.Add<MedicoModel, MedicoValidator>(Medico));

        }

        [HttpPut]
        public IActionResult alterar(MedicoModel Medico)
        {
            if (Medico == null)
                return NotFound();
            else
                return Execute(() => _service.Update<MedicoModel,
                    MedicoValidator>(Medico));

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
        public IActionResult selecionarTodos()
        {
            //select * from Medicos
            return Execute(() => _service.Get<MedicoModel>());
        }


        [HttpGet]
        [Route("getMedicoFiltro/{crm}")]
        public IActionResult selecionarMedicoNome(String crm)
        {
            
            return Execute(() => _service.GetFiltro<MedicoModel>(
                p => p.crm.Contains(crm), //where
                p => p.OrderBy(p => p.crm),//order by
                null, null)); //include, top

        }




        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => _service.GetById<MedicoModel>(id));
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
