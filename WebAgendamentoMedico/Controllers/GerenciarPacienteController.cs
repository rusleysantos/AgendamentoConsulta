using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAgendamentoMedico.Models;

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

        /// <summary>
        /// Metodo responsável por retornar todos os pacientes do banco
        /// </summary>
        /// <returns>Json de pacientes</returns>
        public string getPaciente()
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

        /// <summary>
        /// Metodo responsável por cadastrar usuários no banco
        /// </summary>
        /// <returns>Bool informando se foi inserido ou não</returns>
        public bool setPaciente(string nomePaciente, string nascimentoPaciente)
        {
            if (nomePaciente != string.Empty && nascimentoPaciente != string.Empty)
            {

                ContextoAgendamento ctxAgendamento = new ContextoAgendamento();
                Paciente paciente = new Paciente();

                paciente.Nome = nomePaciente;
                paciente.Nascimento = nascimentoPaciente;

                try
                {
                    ctxAgendamento.Add(paciente);
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