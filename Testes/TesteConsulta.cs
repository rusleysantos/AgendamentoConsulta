using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicos.GerenciarConsulta;
using System;

namespace Testes
{
    [TestClass]
    public class TesteConsulta
    {
        /// <summary>
        /// Verifica se o sistema está deixando inserir hora de inicio inferior a data de termino
        /// </summary>
        [TestMethod]
        public void TesteDataSetConsulta()
        {
            InserirConsulta consulta = new InserirConsulta();

            if (consulta.Inserir("10-10-2019", "Teste", "11:00", "10:00", "Tese"))
            {
                throw new Exception("Hora de inicio de consulta menor que hora de termino");
            }

        }
    }
}
