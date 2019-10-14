using Dados.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicos.GerenciarConsulta
{
    public class BuscarConsulta
    {
        /// <summary>
        /// Metodo responsável por retornar todos as consultas do banco
        /// </summary>
        /// <returns>Json de consultas</returns>
        public string Buscar()
        {
            ContextoAgendamento ctxAgendamento = new ContextoAgendamento();

            try
            {
                var retorno = new
                {
                    status = "sucesso",

                    resultado = ctxAgendamento.Consulta.Select
                    (x => new
                    {
                        x.DataHoraInicialConsulta,
                        x.DataHoraFinalConsulta,
                        Paciente = ctxAgendamento.Paciente.Where(y => y.Id == x.Paciente)
                    }),
                };

                string json = JsonConvert.SerializeObject(retorno);

                return json;
            }
            catch (Exception)
            {

                var retorno = new
                {
                    status = "erro",
                    resultado = "Erro ao consultar base de dados"
                };

                return JsonConvert.SerializeObject(retorno);
            }
        }

    }
}
