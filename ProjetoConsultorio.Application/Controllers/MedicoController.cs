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
    public class MedicoController : ControllerBase
    {
        private IBaseService<Medico> _service;
        private IBaseService<MedicoConvenio> _serviceConvenio;
        private IBaseService<MedicoDisponibilidade> _serviceDisponibilidade;

        public MedicoController(IBaseService<Medico> service, IBaseService<MedicoConvenio> serviceConv, 
            IBaseService<MedicoDisponibilidade> serviceDisp)
        {
            _service = service;
            _serviceConvenio = serviceConv;
            _serviceDisponibilidade = serviceDisp;
        }

        [HttpPost]
        public IActionResult inserir(MedicoModel medico)
        {
            if (medico == null)
                return NotFound();
            else
                return Execute(() => _service.Add<MedicoModel, MedicoValidator>(medico));
        }

        [HttpPut]
        public IActionResult alterar(MedicoModel medico)
        {
            if (medico == null)
                return NotFound();
            else
            {

                var convenioJaSalvo = _serviceConvenio.GetFiltro<MedicoConvenio>(c => c.medicoId == medico.id, null, null, null);
                var disponibilidadeJaSalvo = _serviceDisponibilidade.GetFiltro<MedicoDisponibilidade>(c => c.medicoId == medico.id, null, null, null);



               

                foreach (var item in convenioJaSalvo)
                {
                    var encontrou = medico.medicoconvenio.Where(c => c.convenioId == item.convenioId && c.medicoId == item.medicoId).ToList();
                    if (encontrou.Count == 0)
                    {
                        _serviceConvenio.Delete(item.id);

                    }
                }

                foreach (var item in disponibilidadeJaSalvo)
                {
                    var encontrou = medico.medicodisponibilidade.Where(c => c.disponibilidadeId == item.disponibilidadeId && c.medicoId == item.medicoId).ToList();
                    if (encontrou.Count == 0)
                    {
                        _serviceDisponibilidade.Delete(item.id);

                    }
                }

                foreach (var item in medico.medicoconvenio)
                {
                    var encontrou = _serviceConvenio.GetFiltro<MedicoConvenio>(c => c.convenioId == item.convenioId && c.medicoId == item.medicoId).ToList();
                    if (encontrou.Count == 0)
                    {
                        // Criar uma instância de MedicoConvenioModel a partir de MedicoConvenio
                        var medicoConvenioModel = new MedicoConvenioModel
                        {
                            medicoId = item.medicoId,
                            convenioId = item.convenioId,
                            // Atribuir outras propriedades relevantes de MedicoConvenio para MedicoConvenioModel
                        };

                        _serviceConvenio.Add<MedicoConvenioModel, MedicoConvenioValidator>(medicoConvenioModel);
                    }
                }

                foreach (var item in medico.medicodisponibilidade)
                {
                    var encontrou = _serviceDisponibilidade.GetFiltro<MedicoDisponibilidade>(c => c.disponibilidadeId == item.disponibilidadeId && c.medicoId == item.medicoId).ToList();
                    if (encontrou.Count == 0)
                    {
                        // Criar uma instância de MedicoConvenioModel a partir de MedicoConvenio
                        var medicoDisponibilidadeModel = new MedicoDisponibilidadeModel
                        {
                            medicoId = item.medicoId,
                            disponibilidadeId = item.disponibilidadeId,
                            // Atribuir outras propriedades relevantes de MedicoConvenio para MedicoConvenioModel
                        };

                        _serviceDisponibilidade.Add<MedicoDisponibilidadeModel, MedicoDisponibilidadeValidator>(medicoDisponibilidadeModel);
                    }
                }

                medico.medicoconvenio.Clear();
                medico.medicodisponibilidade.Clear();

                return Execute(() => _service.Update<MedicoModel,
                    MedicoValidator>(medico));
            }

        }


        [HttpDelete("{id}")]
        public IActionResult excluir(int id)
        {
            if (id == 0)
                return NotFound();
            //excluir as classificações antes
            var convenio = _serviceConvenio.GetFiltro<MedicoConvenio>(c => c.medicoId == id, null, null, null);
            var disponibilidade = _serviceDisponibilidade.GetFiltro<MedicoDisponibilidade>(c => c.medicoId == id, null, null, null);
            foreach (var item in convenio)
            {
                _serviceConvenio.Delete(item.id);
            }

            foreach (var item in disponibilidade)
            {
                _serviceDisponibilidade.Delete(item.id);
            }


            return Execute(() => { _service.Delete(id); return true; });

            //return new NoContentResult();

        }

        [HttpGet]
        [Authorize]
        public IActionResult selecionarTodos()
        {
            return Execute(() => _service.Get<MedicoModel>());
        }

        [HttpGet]
        [Route("selecionarMedicoConvenio/{nome}")]
        public IActionResult selecionarMedicoConvenio(string nome)
        {

            //select * from produtos where descricao like '%descricao% order by descricao'

            return Execute(() => _service.GetFiltro<MedicoModel>(
                p => p.nome.Contains(nome), //where
                p => p.OrderBy(p => p.nome), //include
                null //top 10
                ));
        }

        [HttpGet("{id}")]
        public IActionResult selecionarID(int id)
        {
            if (id == 0)
                return NotFound();

            var medicoModel = _service.GetFiltro<MedicoModel>(
                filter: p => p.id == id,
                orderBy: p => p.OrderBy(p => p.nome),
                includeProperties: "medicoconvenio,medicodisponibilidade"
               
            ).FirstOrDefault();

            if (medicoModel == null)
                return NotFound();

            return Execute(() => medicoModel);
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
