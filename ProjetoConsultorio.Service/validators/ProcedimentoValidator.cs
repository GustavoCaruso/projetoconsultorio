using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class ProcedimentoValidator : AbstractValidator<Procedimento>
    {
        public ProcedimentoValidator()
        {
            RuleFor(p => p.nome)
            .NotEmpty().WithMessage("Por favor, informe o nome.")
            .NotNull().WithMessage("Por favor, informe o nome.");
            
            RuleFor(p => p.duracao)
            .NotEmpty().WithMessage("Por favor, informe a duração.")
            .NotNull().WithMessage("Por favor, informe a duração.");
            
        }
    }
}
