using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dados.Models;
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
            

            paciente.Nome = "Guilherme Briggs";
            paciente.Nascimento = "10101995";

            ctxAgendamento.Add(paciente);
            ctxAgendamento.SaveChanges();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
