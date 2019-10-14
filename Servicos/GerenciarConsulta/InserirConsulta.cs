using Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicos.GerenciarConsulta
{
    public class InserirConsulta
    {
        /// <summary>
        /// Metodo responsável por cadastrar usuários no banco
        /// </summary>
        /// <returns>Bool informando se foi inserido ou não</returns>
        public bool Inserir(string dataConsulta, string observacaoConsulta,
        string horaInicialConsulta, string horaFinalConsulta, string idPaciente)
        {
            if (dataConsulta != string.Empty && idPaciente != string.Empty && horaInicialConsulta != string.Empty)
            {

                ContextoAgendamento ctxAgendamento = new ContextoAgendamento();
                Consulta consulta = new Consulta();

                consulta.DataHoraInicialConsulta = Convert.ToDateTime(String.Format("{0} {1}", dataConsulta, horaInicialConsulta));
                consulta.DataHoraFinalConsulta = Convert.ToDateTime(String.Format("{0} {1}", dataConsulta, horaFinalConsulta));
                if (consulta.DataHoraInicialConsulta > consulta.DataHoraFinalConsulta)
                {
                    return false;
                }
                consulta.Observacoes = observacaoConsulta;
                consulta.Paciente = Convert.ToInt32(idPaciente);

                if (ctxAgendamento.Consulta.Where(x => consulta.DataHoraInicialConsulta >= x.DataHoraInicialConsulta && x.DataHoraFinalConsulta >= consulta.DataHoraFinalConsulta).Count() > 0)
                {
                    return false;
                }

                try
                {
                    ctxAgendamento.Add(consulta);
                    ctxAgendamento.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
