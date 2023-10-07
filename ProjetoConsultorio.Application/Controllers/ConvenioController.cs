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
        public IActionResult Inserir(ConvenioModel convenioModel)
        {
            try
            {
                if (convenioModel == null)
                    return NotFound();

                // Limpe os campos relacionados que não devem ser inseridos no banco de dados.
                convenioModel.medicoConvenio = null; // Suponhamos que você não queira inserir médicos relacionados.

                // Use o serviço para adicionar o convênio ao banco de dados
                _service.Add<ConvenioModel, ConvenioValidator>(convenioModel);

                return Ok("Convênio inserido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao inserir o convênio: {ex.Message}");
            }
        }



        [HttpPut]
        public IActionResult alterar(ConvenioModel Convenio)
        {
            if (Convenio == null)
                return NotFound();
            else
                return Execute(() => _service.Update<ConvenioModel, ConvenioValidator>(Convenio));
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

            return Execute(() => _service.GetById<ConvenioModel>(id));
        }
        [HttpGet]
        public IActionResult selecionarTodos()
        {

            return Execute(() => _service.Get<ConvenioModel>());
        }

        [HttpGet]
        [Route("getConvenioFiltro/{descricao}")]
        public IActionResult selecionarConvenioNome(string descricao)
        {
            return Execute(() => _service.GetFiltro<ConvenioModel>(p => p.nome.Contains(descricao), null, null));

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
