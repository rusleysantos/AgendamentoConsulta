using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Servicos.GerenciarPaciente;

namespace WebAgendamentoMedico.Controllers
{
    public class GerenciarPacienteController : Controller
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
            BuscarPaciente paciente = new BuscarPaciente();

            return paciente.Buscar();
        }

        /// <summary>
        /// Metodo responsável por cadastrar usuários no banco
        /// </summary>
        /// <returns>Bool informando se foi inserido ou não</returns>
        public bool Set(string nomePaciente, string nascimentoPaciente)
        {
            InserirPaciente paciente = new InserirPaciente();
            return paciente.Inserir(nomePaciente, nascimentoPaciente);
        }
    }
}