using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(c => c.descricao)
            .NotEmpty().WithMessage("Por favor, informe uma descrição.")
            .NotNull().WithMessage("Por favor, informe uma descrição.");
            RuleFor(c => c.idCategoria)
            .NotEmpty().WithMessage("Por favor, informe uma categoria.")
            .NotNull().WithMessage("Por favor, informe uma categoria.");
            RuleFor(c => c.qtde)
            .NotEmpty().WithMessage("Por favor, informe uma qtde.")
            .NotNull().WithMessage("Por favor, informe uma qtde.");
            RuleFor(c => c.valor)
            .NotEmpty().WithMessage("Por favor, informe um valor.")
            .NotNull().WithMessage("Por favor, informe um valor.");
        }
    }
}
