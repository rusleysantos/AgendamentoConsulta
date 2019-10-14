using Dados.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicos.GerenciarPaciente
{
    public class BuscarPaciente
    {

        /// <summary>
        /// Metodo responsável por retornar todos os pacientes do banco
        /// </summary>
        /// <returns>Json de pacientes</returns>
        public string Buscar()
        {
            ContextoAgendamento ctxAgendamento = new ContextoAgendamento();

            try
            {
                var retorno = new
                {
                    status = "sucesso",
                    resultado = ctxAgendamento.Paciente.Select(x => new { x.Nome, x.Nascimento, x.Id }).ToList()
                };

                string json = JsonConvert.SerializeObject(retorno);

                return json;
            }
            catch
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
