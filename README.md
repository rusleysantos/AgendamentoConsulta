# AgendamentoConsulta

## Observações:
* A aplicação está funcionando, porém devido algumas limitações que não existirão em um projeto de verdade (banco de dados .mdf) alguns itens serão corrigidos na release 1.0.1.

## Alterações futuras:
* Devido o banco ser um .mdf em outra .dll se faz necessária correções na string de conexão que e composta pela caminho do arquivo; 
* Corrigir regra para inserção de usuário, até o momento não consigui debuggar devido o breakpoint estar desincronizado com o bin;
* Loads durante as requisições Ajax;
* Melhorar mascara dos campos de data;
* Fazer Dashboard (Index) pegar valores do banco.

## Alterações sendo executas:
* Correções de erros gramáticais estão sendo feitos e "commitados" sempre que encontrados durantes os testes.


## Orientações Gerais
* O resultado da solução deverá ser publicado no seu GitHub.
* Assim que concluir, envie um e-mail para desafio@itixti.com.br com a URL do repositório da solução.

## Requisitos Funcionais
* O sistema deve apresentar os seguintes campos: Nome do paciente, Data de nascimento, Data e hora inicial da consulta, Data e hora final da consulta, e um campo de Observações.
* O sistema não deve permitir o agendamento de duas ou mais consultas no mesmo range de datas.
* A data final não pode ser menor que a data inicial.

## Requisitos Técnicos
* Linguagem C#.
* Banco de dados MS SQL Server.
* Criar testes unitários para a solução.
* Desenvolver a interface gráfica utilizando o framework Angular.

## Diferencial
* Utilizar o .NET Core
