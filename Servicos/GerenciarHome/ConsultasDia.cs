using Dados.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicos.GerenciarHome
{
    public class ConsultasDia
    {

        /// <summary>
        /// Consulta na base de dados as consultas do dia
        /// </summary>
        /// <returns>Consultas do dia</returns>
        public string Buscar()
        {
            ContextoAgendamento ctxAgendamento = new ContextoAgendamento();
            Consulta consulta = new Consulta();

            var retorno = new
            {
                status = "sucesso",

                resultado = ctxAgendamento.Consulta.Select
                    (x => new
                    {
                        x.DataHoraInicialConsulta,
                        x.DataHoraFinalConsulta,
                        Paciente = ctxAgendamento.Paciente.Where(y => y.Id == x.Paciente)
                    }).Where(x => x.DataHoraInicialConsulta.Date == DateTime.Now.Date),

                contagemNovas = ctxAgendamento.Consulta.Count(x => x.DataHoraInicialConsulta.Date > DateTime.Now.Date)

            };

            return JsonConvert.SerializeObject(retorno);
        }
    }
}
