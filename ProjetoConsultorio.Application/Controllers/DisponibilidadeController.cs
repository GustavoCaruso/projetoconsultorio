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
    public class DisponibilidadeController : ControllerBase
    {

        private IBaseService<Disponibilidade> _service;

        public DisponibilidadeController(IBaseService<Disponibilidade> service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult inserir(DisponibilidadeModel Disponibilidade)
        {
            if (Disponibilidade == null)
                return NotFound();
            return Execute(() => _service.Add<DisponibilidadeModel,
                DisponibilidadeValidator>(Disponibilidade));

        }

        [HttpPut]
        public IActionResult alterar(DisponibilidadeModel Disponibilidade)
        {
            if (Disponibilidade == null)
                return NotFound();
            else
                return Execute(() => _service.Update<DisponibilidadeModel,
                    DisponibilidadeValidator>(Disponibilidade));

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
            //select * from Disponibilidades
            return Execute(() => _service.Get<DisponibilidadeModel>());
        }

        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => _service.GetById<DisponibilidadeModel>(id));
        }



        [HttpGet]
        [Route("getDisponibilidadesCategoria/{medicoId}")]
        public IActionResult selecionarDisponibilidadesCategoria(int medicoId)
        {
            //select * from Disponibilidades  where idCategoria =1 order by Disponibilidades
            return Execute(() => _service.GetFiltro<DisponibilidadeModel>(
                p => p.medicoId == medicoId, //where
                p => p.OrderBy(p => p.diaDaSemana),//order by
                "categoria", null)); //include, top

        }


        [HttpGet]
        [Route("selecionarDisponibilidadeDiaDaSemana/{diaDaSemana}")]
        public IActionResult selecionarDisponibilidadeDiaDaSemana(string diaDaSemana)
        {
            // Mapeamento de nomes de dias da semana para valores inteiros
            Dictionary<string, int> diaDaSemanaMapping = new Dictionary<string, int>
    {
        { "Segunda-feira", 1 },
        { "Terça-feira", 2 },
        { "Quarta-feira", 3 },
        { "Quinta-feira", 4 },
        { "Sexta-feira", 5 }
     
        // Adicione os outros dias da semana aqui
    };

            // Verifique se o nome do dia da semana está no dicionário
            if (diaDaSemanaMapping.TryGetValue(diaDaSemana, out int diaInt))
            {
                // Agora você pode usar 'diaInt' na sua consulta LINQ
                return Execute(() => _service.GetFiltro<DisponibilidadeModel>(
                    p => p.diaDaSemana == diaInt, // onde 'DiaDaSemana' é uma propriedade numérica
                    p => p.OrderBy(p => p.diaDaSemana), // ordenar por
                    "diaDaSemana", // incluir
                    null // top 10
                ));
            }
            else
            {
                // Dia da semana não encontrado no dicionário, retorne uma resposta de erro
                return BadRequest("Dia da semana inválido.");
            }
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
