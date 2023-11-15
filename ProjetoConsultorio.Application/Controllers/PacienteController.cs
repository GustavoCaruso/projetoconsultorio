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
    public class PacienteController : ControllerBase
    {
        private IBaseService<Paciente> _service;
        private IBaseService<PacienteConvenio> _serviceConvenio;

        public PacienteController(IBaseService<Paciente> service, IBaseService<PacienteConvenio> serviceConv)
        {
            _service = service;
            _serviceConvenio = serviceConv;
        }


        [HttpPost]
        public IActionResult inserir(PacienteModel paciente)
        {
            if (paciente == null)
                return NotFound();
            return Execute(() => _service.Add<PacienteModel,
                PacienteValidator>(paciente));

        }

        [HttpPut]
        public IActionResult alterar(PacienteModel paciente)
        {
            if (paciente == null)
                return NotFound();
            else
            {

                var convenioJaSalvo = _serviceConvenio.GetFiltro<PacienteConvenio>(c => c.pacienteId == paciente.id, null, null, null);



                //excluir as classificações que não foram enviadas

                foreach (var item in convenioJaSalvo)
                {
                    var encontrou = paciente.pacienteconvenio.Where(c => c.convenioId == item.convenioId && c.pacienteId == item.pacienteId).ToList();
                    if (encontrou.Count == 0)
                    {
                        _serviceConvenio.Delete(item.id);

                    }
                }

                //incluir as novas
                foreach (var item in paciente.pacienteconvenio)
                {
                    var encontrou = _serviceConvenio.GetFiltro<PacienteConvenio>(c => c.convenioId == item.convenioId && c.pacienteId == item.pacienteId).ToList();
                    if (encontrou.Count == 0)
                    {
                        _serviceConvenio.Add<PacienteConvenioModel,
                           PacienteConvenioValidator>(item);
                    }

                }
                paciente.pacienteconvenio.Clear();

                return Execute(() => _service.Update<PacienteModel,
                    PacienteValidator>(paciente));
            }

        }

        [HttpDelete("{id}")]
        public IActionResult excluir(int id)
        {
            if (id == 0)
                return NotFound();
            
            var convenio = _serviceConvenio.GetFiltro<PacienteConvenio>(c => c.pacienteId == id, null, null, null);
            foreach (var item in convenio)
            {
                _serviceConvenio.Delete(item.id);
            }


            return Execute(() => { _service.Delete(id); return true; });

            //return new NoContentResult();

        }

        [HttpGet]
        public IActionResult selecionarTodos()
        {
            //select * from produtos
            return Execute(() => _service.Get<PacienteModel>());
        }

        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _service.GetFiltro<PacienteModel>(
                p => p.id == id, //where
                p => p.OrderBy(p => p.nome), //order by
                "pacienteconvenio", //include
                null //top 10
                ).FirstOrDefault());
        }





        [HttpGet]
        [Route("selecionarPacienteNome/{nome}")]
        public IActionResult selecionarPacienteNome(string nome)
        {

            //select * from produtos where descricao like '%descricao% order by descricao'

            return Execute(() => _service.GetFiltro<PacienteModel>(
                p => p.nome.Contains(nome), //where
                p => p.OrderBy(p => p.nome), //order by
               
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
