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

            RuleFor(p => p.cpf).NotEmpty().WithMessage("Informe o cpf!");
            RuleFor(p => p.cpf).NotNull().WithMessage("Informe o cpf!");

            RuleFor(p => p.genero).NotEmpty().WithMessage("Informe o genero!");
            RuleFor(p => p.genero).NotNull().WithMessage("Informe o genero!");

            RuleFor(p => p.estadoCivil).NotEmpty().WithMessage("Informe o estado civil!");
            RuleFor(p => p.estadoCivil).NotNull().WithMessage("Informe o estado civil!");

            RuleFor(p => p.telefone).NotEmpty().WithMessage("Informe o telefone!");
            RuleFor(p => p.telefone).NotNull().WithMessage("Informe o telefone!");

            RuleFor(p => p.email).NotEmpty().WithMessage("Informe o e-mail!");
            RuleFor(p => p.email).NotNull().WithMessage("Informe o e-mail!");

          
        }
    
    }
}
