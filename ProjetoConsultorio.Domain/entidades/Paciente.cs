﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public  class Paciente : BaseEntity
    {
        public Paciente()
        {
            this.pacienteconvenio = new HashSet<PacienteConvenio>();
            this.consulta = new HashSet<Consulta>();
        }
        public string nome { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string genero { get; set; }
        public string estadoCivil { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public virtual ICollection<PacienteConvenio> pacienteconvenio { get; set; }
        public virtual ICollection<Consulta> consulta { get; set; }

    }
}
