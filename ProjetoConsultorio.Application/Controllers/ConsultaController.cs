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
    public class ConsultaController : ControllerBase
    {
        private IBaseService<Consulta> _service;

        public ConsultaController(IBaseService<Consulta> service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult inserir(ConsultaModel Consulta)
        {
            if (Consulta == null)
                return NotFound();
            return Execute(() => _service.Add<ConsultaModel,
                ConsultaValidator>(Consulta));

        }

        [HttpPut]
        public IActionResult alterar(ConsultaModel Consulta)
        {
            if (Consulta == null)
                return NotFound();
            else
                return Execute(() => _service.Update<ConsultaModel,
                    ConsultaValidator>(Consulta));

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
            //select * from Consultas
            return Execute(() => _service.Get<ConsultaModel>());
        }

        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();
            return Execute(() => _service.GetById<ConsultaModel>(id));
        }



        [HttpGet]
        [Route("getConsultaProcedimento/{procedimentoId}")]
        public IActionResult selecionarConsultaProcedimento(int procedimentoId)
        {
            //select * from Consultas  where idCategoria =1 order by Consultas
            return Execute(() => _service.GetFiltro<ConsultaModel>(
                p => p.procedimentoId == procedimentoId, //where
                p => p.OrderBy(p => p.data),//order by
                "procedimento", null)); //include, top

        }


        
        /*
        [HttpGet]
        [Route("verificarDisponibilidade/{data}/{idMedico}")]
        private Boolean verificarDisponibilidade(DateTime data, int idmedico)
        {

            //select * from Consultas where descricao like '%descricao% order by descricao'
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
