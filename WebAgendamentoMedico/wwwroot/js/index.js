var app = angular.module("indexApp", []);
app.controller("myCtrl", function ($scope) {
    $scope.consultas = consultasIndex("listaDia");
});

app.controller("contagemNovas", function ($scope) {
    $scope.contagem = consultasIndex("contagem");
});

function consultasIndex(tipo) {

    let url = "Home/ConsultasDia"
    var resultado;
    var contagem;

    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: url,
            async: false,

            success: function (response) {
                if (response) {
                   
                    resultado = response.resultado
                    contagem = response.contagemNovas

                }
                else {

                    criarAlerta("error", "Erro!", "Não foi possível cadastrar")
                }
            },
            error: function (error) {

                criarAlerta("error", "Erro!", "Não foi possível acessar o servidor")

            }
        });

    if (tipo == "listaDia") {

        return resultado
    }

    if (tipo = "contagem") {
        return contagem
    }
}

function criarAlerta(tipo, titulo, texto) {

    Swal.fire({
        type: tipo,
        title: titulo,
        text: texto,
    })

}