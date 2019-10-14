
var app = angular.module("pacienteApp", []);
app.controller("myCtrl", function ($scope) {
    $scope.pacientes = consultarPaciente();
});

//Função responsável por retornar todos os pacientes cadastrados no sistema
function consultarPaciente() {

    let url = "Get/GerenciarPaciente"
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
//Função responsável por cadastrar pacientes
function cadastrarPaciente() {

    let url = "Set/GerenciarPaciente"

    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: url,
            data: {
                nomePaciente: document.getElementById("nomePaciente").value,
                nascimentoPaciente: document.getElementById("nascimentoPaciente").value
            },

            success: function (response) {
                if (response) {

                    nomePaciente: document.getElementById("nomePaciente").value = ""
                    nascimentoPaciente: document.getElementById("nascimentoPaciente").value = ""

                    criarAlerta("success", "Sucesso!", "Paciente cadastrado com sucesso")

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

function criarAlerta(tipo, titulo, texto) {

    Swal.fire({
        type: tipo,
        title: titulo,
        text: texto,
    })

}