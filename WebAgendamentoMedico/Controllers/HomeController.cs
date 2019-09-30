using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAgendamentoMedico.Models;

namespace WebAgendamentoMedico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
         {
            Paciente paciente = new Paciente();
            ContextoAgendamento ctxAgendamento = new ContextoAgendamento();
            

            //paciente.Nome = "Guilherme Briggs";
            //paciente.Nascimento = "10101995";

            //ctxAgendamento.Add(paciente);
            //ctxAgendamento.SaveChanges();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
