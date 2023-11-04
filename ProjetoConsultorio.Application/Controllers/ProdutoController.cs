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
            return Execute(() => _service.Add<ProdutoModel,
                ProdutoValidator>(produto));

        }

        [HttpPut]
        public IActionResult alterar(ProdutoModel produto)
        {
            if (produto == null)
                return NotFound();
            else
                return Execute(() => _service.Update<ProdutoModel,
                    ProdutoValidator>(produto));

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
            //select * from produtos
            return Execute(() => _service.Get<ProdutoModel>());
        }

        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => _service.GetById<ProdutoModel>(id));
        }



        [HttpGet]
        [Route("getProdutosCategoria/{idCategoria}")]
        public IActionResult selecionarProdutosCategoria(int idCategoria)
        {
            //select * from produtos  where idCategoria =1 order by produtos
            return Execute(() => _service.GetFiltro<ProdutoModel>(
                p => p.idCategoria == idCategoria, //where
                p => p.OrderBy(p => p.descricao),//order by
                "categoria", null)); //include, top

        }


        [HttpGet]
        [Route("selecionarProdutoDescricao/{descricao}")]
        public IActionResult selecionarProdutoDescricao(String descricao)
        {

            //select * from produtos where descricao like '%descricao% order by descricao'

            return Execute(() => _service.GetFiltro<ProdutoModel>(
                p => p.descricao.Contains(descricao), //where
                p => p.OrderBy(p => p.descricao), //order by
                "categoria", //include
                null //top 10
                ));
        }
        /*
        [HttpGet]
        [Route("verificarDisponibilidade/{data}/{idMedico}")]
        private Boolean verificarDisponibilidade(DateTime data, int idmedico)
        {

            //select * from produtos where descricao like '%descricao% order by descricao'
            /*
            List<ConsultaModel> lista=  _service.GetFiltro<ConsultaModel>(
                p =>  p.idmedico == idmedico && data >= p.datavalidade.Value && data <= p.datavalidade.Value.AddMinutes(29), //where
                p => p.OrderBy(p => p.descricao), //order by
                "categoria", //include
                null //top 10
                );

            if (lista == null)
            {
                int diaSemana = ((int)data.DayOfWeek);
                int hora = (data.Hour * 60) + data.Minute;
                List<DisponibilidadeModel> listaDispo = _service.GetFiltro<DisponibilidadeModel>(
                p => p.idmedico == idmedico && diaSemana == p.diaSemana.Value && hora >= ((p.HoraInicio.Hour * 60) + data.Minute) &&
                 hora >= ((p.HoraFinal.Hour * 60) + data.Minute), //where
                p => p.OrderBy(p => p.descricao), //order by
                "categoria", //include
                null //top 10
                );

                if (listaDispo == null)
                    return false;
                else
                    return true;
            }
            else return false;*/
        // }

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
