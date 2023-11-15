using FluentValidation;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Service.validators
{
    public class MedicoConvenioValidator :  AbstractValidator<MedicoConvenio>
    {
        public MedicoConvenioValidator()
        {
            
        }
    }
}
