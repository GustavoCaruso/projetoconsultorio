using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class ConsultaValidator : AbstractValidator<Consulta>
    {
        public ConsultaValidator()
        {
          
            RuleFor(p => p.data).NotEmpty().WithMessage("Informe a data!");
            RuleFor(p => p.data).NotNull().WithMessage("Informe a data!");

            RuleFor(p => p.horaInicio).NotEmpty().WithMessage("Informe o horário de início!");
            RuleFor(p => p.horaInicio).NotNull().WithMessage("Informe o horário de início!");

            RuleFor(p => p.horaFim).NotEmpty().WithMessage("Informe o horário de fim!");
            RuleFor(p => p.horaFim).NotNull().WithMessage("Informe o horário de fim!");
        }
    }
}
