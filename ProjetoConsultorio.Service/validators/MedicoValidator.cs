using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class MedicoValidator : AbstractValidator<Medico>
    {
        public MedicoValidator()
        {
            RuleFor(p => p.nome).NotEmpty().WithMessage("Informe um nome!");
            RuleFor(p => p.nome).NotNull().WithMessage("Informe um nome!");
        }
    }
}
