# AgendamentoConsulta

## Atenção (Alterando string de conexão):
* **Por se tratar de um banco .MDF se faz necessário adicionar o caminho físico até o banco dentro da string de conexão;**

* **No projeto procure o seguinte arquivo:** *C:\git\AgendamentoConsulta\WebAgendamentoMedico\Models\ContextoAgendamento.cs altere o caminho que está na variável "caminho";*
![](https://i.imgur.com/kpASpG9.png)

* **Adicionar o caminho físico do seu computador até Agendamento.mdf EX:**
*(EX: C:\\\ git\\\AgendamentoConsulta\\\Dados\\\Agendamento.mdf)*
![](https://i.imgur.com/88qpceR.png)

## Alterações futuras:
* Loads durante as requisições Ajax;
* Melhorar mascara dos campos de data;

## Requisitos Funcionais
* O sistema deve apresentar os seguintes campos: Nome do paciente, Data de nascimento, Data e hora inicial da consulta, Data e hora final da consulta, e um campo de Observações.
* O sistema não deve permitir o agendamento de duas ou mais consultas no mesmo range de datas.
* A data final não pode ser menor que a data inicial.