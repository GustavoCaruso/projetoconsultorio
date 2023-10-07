using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(p => p.descricao).NotEmpty().WithMessage("Informe uma descricao!");
            RuleFor(p => p.descricao).NotNull().WithMessage("Informe uma descricao!");
        }
    }
}
