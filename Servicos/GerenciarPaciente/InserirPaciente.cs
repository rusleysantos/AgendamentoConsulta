using Dados.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.GerenciarPaciente
{
    public class InserirPaciente
    {
        public bool Inserir(string nomePaciente, string nascimentoPaciente)
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
