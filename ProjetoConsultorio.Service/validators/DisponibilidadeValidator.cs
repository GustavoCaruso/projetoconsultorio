using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProjetoConsultorio.Domain.entidades;


namespace ProjetoConsultorio.Service.validators
{
    public class DisponibilidadeValidator : AbstractValidator<Disponibilidade>
    {
        public DisponibilidadeValidator()
        {
         
            RuleFor(p => p.diaDaSemana).NotEmpty().WithMessage("Informe um diaDaSemana!");
            RuleFor(p => p.diaDaSemana).NotNull().WithMessage("Informe um diaDaSemana!");

            RuleFor(p => p.horaInicio).NotEmpty().WithMessage("Informe uma horaInicio!");
            RuleFor(p => p.horaInicio).NotNull().WithMessage("Informe uma horaInicio!");

            RuleFor(p => p.horaFim).NotEmpty().WithMessage("Informe um horaFim!");
            RuleFor(p => p.horaFim).NotNull().WithMessage("Informe um horaFim!");
        }
    }
}
