using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicos.GerenciarConsulta;
using Servicos.GerenciarHome;
using System;

namespace Testes
{
    [TestClass]
    public class TesteHome
    {
        /// <summary>
        /// Teste verifica se a consulta diária está retornando nula
        /// </summary>
        [TestMethod]
        public void TesteIndex()
        {

            ConsultasDia index = new ConsultasDia();

            Assert.ThrowsException<NullReferenceException>(() =>

            {
                if (index.Buscar() != null)
                {

                    throw new NullReferenceException("Consultas do dia estão nulas");
                }

            }

            );

        }
    }
}
