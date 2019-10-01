using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAgendamentoMedico.Models;

namespace WebAgendamentoMedico.Controllers
{
    public class GerenciarConsultaController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            return View();
        }

        /// <summary>
        /// Metodo responsável por retornar todos as consultas do banco
        /// </summary>
        /// <returns>Json de consultas</returns>
        public string getConsulta()
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
            catch(Exception)
            {

                var retorno = new
                {
                    status = "erro",
                    resultado = "Erro ao consultar base de dados"
                };

                return JsonConvert.SerializeObject(retorno);
            }
        }

        /// <summary>
        /// Metodo responsável por cadastrar usuários no banco
        /// </summary>
        /// <returns>Bool informando se foi inserido ou não</returns>
        public bool setConsulta(string dataConsulta, string observacaoConsulta,
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

                if (ctxAgendamento.Consulta.Where(x => consulta.DataHoraInicialConsulta >= x.DataHoraInicialConsulta &&  x.DataHoraFinalConsulta >= consulta.DataHoraFinalConsulta).Count() > 0)
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

        /// <summary>
        /// Retorna todos os pacientes no sistemas. 
        /// Lembrar: Mudar para uma classe util
        /// </summary>
        /// <returns>Pacientes</returns>
        public string pacientes()
        {
            GerenciarPacienteController paciente = new GerenciarPacienteController();
            return paciente.getPaciente();
        }

    }
}