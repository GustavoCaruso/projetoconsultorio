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
    public class ProdutoController : ControllerBase
    {
        private IBaseService<Produto> _service;

        public ProdutoController(IBaseService<Produto> service)
        {
            _service = service;

        }

        [HttpPost]
        public IActionResult inserir(ProdutoModel produto)
        {
            if (produto == null)
                return NotFound();
            else
                return Execute(() => _service.Add<ProdutoModel, ProdutoValidator>(produto));
        }


        [HttpGet]
        [Route("getProdutosCategoria/{idCategoria}")]
        public IActionResult GetProdutosCategoria(int idCategoria)
        {
            if (idCategoria == 0)
                return NotFound();
            return Execute(() => _service.GetFiltro<ProdutoModel>(p =>
           p.idCategoria == idCategoria, q => q.OrderBy(s => s.descricao), null, null));

        }



        [HttpGet]
        public IActionResult selecionarProdutoDescricao(string descricao)
        {
            return Execute(() => _service.GetFiltro<ProdutoModel>(
                p=>p.descricao.Contains(descricao),//where
                p=>p.OrderBy(p=>descricao), //order by
                null, //include
                null //top 10
                ));
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
