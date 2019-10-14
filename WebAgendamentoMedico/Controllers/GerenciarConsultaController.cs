using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Servicos.GerenciarConsulta;
using Servicos.GerenciarPaciente;


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

        public string Get()
        {
            BuscarConsulta consulta = new BuscarConsulta();
            
            return consulta.Buscar();
        }

        public bool Set(string dataConsulta, string observacaoConsulta,
        string horaInicialConsulta, string horaFinalConsulta, string idPaciente)
        {
            InserirConsulta consulta = new InserirConsulta();
            
            return consulta.Inserir(dataConsulta, observacaoConsulta, horaInicialConsulta, horaFinalConsulta, idPaciente);

        }

        /// <summary>
        /// Retorna todos os pacientes no sistemas. 
        /// </summary>
        /// <returns>Pacientes</returns>
        public string pacientes()
        {
            BuscarPaciente paciente = new BuscarPaciente();
            return paciente.Buscar();
        }

    }
}