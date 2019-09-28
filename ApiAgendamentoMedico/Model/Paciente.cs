using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentoMedico.Model
{
    public class Paciente : Pessoa
    {
        private DateTime DataHoraInicialConsulta { get; set; }
        private DateTime DataHoraFinalConsulta { get; set; }


        Paciente(string nome, DateTime nascimento, DateTime dataHoraInicialConsulta, DateTime dataHoraFinalConsulta)
        {
            Nome = nome;
            Nascimento = nascimento;
            DataHoraInicialConsulta = dataHoraInicialConsulta;
            DataHoraFinalConsulta = dataHoraFinalConsulta;
        }
    }


}
