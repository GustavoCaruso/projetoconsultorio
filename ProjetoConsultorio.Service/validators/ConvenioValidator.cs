using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class ConvenioValidator : AbstractValidator<Convenio>
    {
        public ConvenioValidator()
        {
            RuleFor(p => p.nome).NotEmpty().WithMessage("Informe o nome do convênio!");
            RuleFor(p => p.nome).NotNull().WithMessage("Informe o nome do convênio!");
        }
    }
}
