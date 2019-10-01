using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAgendamentoMedico.Controllers;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Teste verifica se a consulta di�ria est� retornando nula
        /// </summary>
        [TestMethod]
        public void TesteIndex()
        {

            HomeController index = new HomeController();
            string teste = index.ConsultasDia();

            Assert.ThrowsException<NullReferenceException>(() =>

            {
                if (index.ConsultasDia() != null)
                {

                    throw new NullReferenceException("Consultas do dia est�o nulas");
                }

            }

            );

        }

        /// <summary>
        /// Verifica se o sistema est� deixando inserir hora de inicio inferior a data de termino
        /// </summary>
        [TestMethod]
        public void TesteDataSetConsulta()
        {
            GerenciarConsultaController consulta = new GerenciarConsultaController();

            if (consulta.setConsulta("10-10-2019", "Teste", "11:00", "10:00", "Tese"))
            {
                throw new Exception("Hora de inicio de consulta menor que hora de termino");
            }

        }


    }
}
