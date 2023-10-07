using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
        public PacienteValidator()
        {
            RuleFor(p => p.nome).NotEmpty().WithMessage("Informe o nome!");
            RuleFor(p => p.nome).NotNull().WithMessage("Informe o nome!");

            RuleFor(p => p.rg).NotEmpty().WithMessage("Informe o rg!");
            RuleFor(p => p.rg).NotNull().WithMessage("Informe o rg!");
        }
    
    }
}
