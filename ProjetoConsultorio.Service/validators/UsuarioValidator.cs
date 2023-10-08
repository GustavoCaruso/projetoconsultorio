using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProjetoConsultorio.Domain.entidades;


namespace ProjetoConsultorio.Service.validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            //descricao nao pode ser vazia
            RuleFor(p => p.nome).NotEmpty().WithMessage("Informe um nome!");
            //descricao nao pode ser null
            RuleFor(p => p.nome).NotNull().WithMessage("Informe um nome!");
            RuleFor(p => p.senha).NotEmpty().WithMessage("Informe um senha!");
            //descricao nao pode ser null
            RuleFor(p => p.senha).NotNull().WithMessage("Informe um senha!");
            RuleFor(p => p.email).NotEmpty().WithMessage("Informe um email!");
            //descricao nao pode ser null
            RuleFor(p => p.email).NotNull().WithMessage("Informe um email!");
        }
    }
}
