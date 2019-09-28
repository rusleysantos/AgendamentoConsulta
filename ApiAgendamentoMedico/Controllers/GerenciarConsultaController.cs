using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgendamentoMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenciarConsultaController : ControllerBase
    {
        // GET: api/GerenciarConsulta
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GerenciarConsulta/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GerenciarConsulta
        [HttpPost]
        public void Post(string nome, string nascimento, string horaInicialConsulta, string horaFinalConsulta, string dataConsulta)
        {
            //Paciente paciente = new Paciente(nome, nascimento, horaInicialConsulta, horaFinalConsulta, dataConsulta);
        }

        // PUT: api/GerenciarConsulta/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
