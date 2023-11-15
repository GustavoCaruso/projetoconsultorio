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
            //descricao nao pode ser vazia
            RuleFor(p => p.diaDaSemana).NotEmpty().WithMessage("Informe um nome!");
            //descricao nao pode ser null
            RuleFor(p => p.diaDaSemana).NotNull().WithMessage("Informe um nome!");
            RuleFor(p => p.horaInicio).NotEmpty().WithMessage("Informe uma senha!");
            //descricao nao pode ser null
            RuleFor(p => p.horaInicio).NotNull().WithMessage("Informe uma senha!");
            RuleFor(p => p.horaFim).NotEmpty().WithMessage("Informe um email!");
            //descricao nao pode ser null
            RuleFor(p => p.horaFim).NotNull().WithMessage("Informe um email!");
        }
    }
}
