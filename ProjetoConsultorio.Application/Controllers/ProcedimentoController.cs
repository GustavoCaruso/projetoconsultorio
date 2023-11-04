using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private IBaseService<Categoria> _service;

        public CategoriaController(IBaseService<Categoria> service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult inserir(CategoriaModel categoria)
        {
            if (categoria == null)
                return NotFound();
            else
                return Execute(() => _service.Add<CategoriaModel, CategoriaValidator>(categoria));
        }

        [HttpPut]
        public IActionResult alterar(CategoriaModel categoria)
        {
            if (categoria == null)
                return NotFound();
            else
                return Execute(() => _service.Update<CategoriaModel, CategoriaValidator>(categoria));
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

            return Execute(() => _service.GetById<CategoriaModel>(id));
        }
        [HttpGet]
        public IActionResult selecionarTodos()
        {

            return Execute(() => _service.Get<CategoriaModel>());
        }

        [HttpGet]
        [Route("getCategoriaFiltro/{descricao}")]
        public IActionResult selecionarCategoriaNome(string descricao)
        {
            return Execute(() => _service.GetFiltro<CategoriaModel>(p => p.descricao.Contains(descricao), null, null));

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
