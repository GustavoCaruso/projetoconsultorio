﻿using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class MedicoConvenioModel
    {
        public int id { get; set; }
        public int medicoId { get; set; }
        public int convenioId { get; set; }
       

    }
}
