using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class StatusConsultaValidator : AbstractValidator<StatusConsulta>
    {
        public StatusConsultaValidator()
        {
            RuleFor(p => p.nome).NotEmpty().WithMessage("Informe o nome do status da consulta!");
            RuleFor(p => p.nome).NotNull().WithMessage("Informe o nome do status da consulta!");
        }
    }
}
