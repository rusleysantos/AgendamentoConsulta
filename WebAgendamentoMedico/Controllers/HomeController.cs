using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAgendamentoMedico.Models;

namespace WebAgendamentoMedico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
         {
            return View();
        }
    }
}
