using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Servicos.GerenciarHome;

namespace WebAgendamentoMedico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string ConsultasDia()
        {
            ConsultasDia consulta = new ConsultasDia();

            return consulta.Buscar();

        }
    }
}
