using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAgendamentoMedico.Models;

namespace WebAgendamentoMedico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Consulta na base de dados as consultas do dia
        /// </summary>
        /// <returns>Consultas do dia</returns>
        public string ConsultasDia()
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
