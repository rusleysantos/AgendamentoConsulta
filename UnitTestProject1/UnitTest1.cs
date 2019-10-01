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
    }
}
