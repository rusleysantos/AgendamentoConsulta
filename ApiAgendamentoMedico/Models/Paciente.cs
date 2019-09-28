using System;
using System.Collections.Generic;

namespace ApiAgendamentoMedico.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nascimento { get; set; }

        public ICollection<Consulta> Consulta { get; set; }
    }
}
