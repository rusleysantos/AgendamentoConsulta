using System;
using System.Collections.Generic;

namespace ApiAgendamentoMedico.Models
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHoraInicialConsulta { get; set; }
        public DateTime DataHoraFinalConsulta { get; set; }
        public string Observacoes { get; set; }
        public int Paciente { get; set; }

        public Paciente PacienteNavigation { get; set; }
    }
}
