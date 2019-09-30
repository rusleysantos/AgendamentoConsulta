var app = angular.module("agendamentoApp", []);
app.controller("myCtrl", function ($scope) {
    $scope.pacientes = pacientes();
});

var appConsulta = angular.module("agendamentoAgendaApp", []);
appConsulta.controller("exibirConsulta", function ($scope) {
    $scope.consultas = consultarAgendamentos();
});

//Função responsável por retornar todos os agendamentos cadastrados no sistema
function consultarAgendamentos() {

    let url = "getConsulta/GerenciarConsulta"
    var resultado;

    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: url,
            async: false,

            success: function (response) {

                resultado = response.resultado

            },
            error: function (error) {

                criarAlerta("error", "Erro!", "Não foi possível acessar o servidor")

            }
        });

    return resultado;
}
//Função responsável por cadastrar agendamentos
function cadastrarAgendamento() {

    let url = "setConsulta/GerenciarConsulta"

    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: url,
            data: {
                dataConsulta: document.getElementById("dataConsulta").value,
                horaInicialConsulta: document.getElementById("horaInicialConsulta").value,
                horaFinalConsulta: document.getElementById("horaFinalConsulta").value,
                idPaciente: document.getElementById("idPaciente").value,
                observacaoConsulta: document.getElementById("observacaoConsulta").value
            },

            success: function (response) {
                if (response) {

                    dataConsulta: document.getElementById("dataConsulta").value = ""
                    horaInicialConsulta: document.getElementById("horaInicialConsulta").value = ""
                    horaFinalConsulta: document.getElementById("horaFinalConsulta").value = ""
                    idPaciente: document.getElementById("idPaciente").value = ""
                    observacaoConsulta: document.getElementById("observacaoConsulta").value = ""

                    criarAlerta("success", "Sucesso!", "Consulta cadastrada com sucesso")
                }
                else {

                    criarAlerta("error", "Erro!", "Não foi possível cadastrar")
                }
            },
            error: function (error) {

                criarAlerta("error", "Erro!", "Não foi possível acessar o servidor")

            }

        });

}


function pacientes() {

    let url = "pacientes/GerenciarConsulta"
    var resultado;

    debugger;
    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: url,
            async: false,

            success: function (response) {

                resultado = response.resultado

            },
            error: function (error) {

                criarAlerta("error", "Erro!", "Não foi possível acessar o servidor")

            }
        });


    return resultado;
}


function criarAlerta(tipo, titulo, texto) {

    Swal.fire({
        type: tipo,
        title: titulo,
        text: texto,
    })

}