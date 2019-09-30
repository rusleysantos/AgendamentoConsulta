function consultarPaciente() {

    let url = "getPaciente/GerenciarPaciente"

    $.ajax(
        {
            type: "GET",
            dataType: "json",
            url: url,

            success: function (response) {
                debugger;
            },
            error: function (error) {

                criarAlerta("error", "Erro!", "Não foi possível acessar o servidor")

            }

        });

}

function cadastrarPaciente() {

    let url = "setPaciente/GerenciarPaciente"

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