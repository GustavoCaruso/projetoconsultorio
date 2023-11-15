


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {

    carregarDisponibilidade();

    $("#btnlimpar").click(function () {
        $("#txtid").val('0');
        $("#txtdiaDaSemana").val('');
        $("#txthoraInicio").val('');
        $("#txthoraFim").val('');
    });

    //evento visualizar
    $("#tabela").on("click", ".alterar", function (elemento) {
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        visualizar(codigo);
    })

    $("#tabela").on("click", ".excluir", function (elemento) {
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        excluir(codigo);
    })

    $("#btnsalvar").click(function () {
        //validar
        const diaDaSemana = $("#txtdiaDaSemana").val();
        const horaInicio = $("#txthoraInicio").val();
        const horaFim = $("#txthoraFim").val();

        if (!diaDaSemana || !horaInicio || !horaFim) {
            alert("Preencha todos os campos antes de salvar.");
            return;
        }

        const obj = {
            id: $("#txtid").val(),
            diaDaSemana: diaDaSemana,
            horaInicio: horaInicio,
            horaFim: horaFim
        }

        console.log(JSON.stringify(obj));

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Disponibilidade",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(obj),
            dataType: "json",
            success: function (jsonResult) {
                console.log(jsonResult);
                $("#txtid").val('0');
                $("#txtdiaDaSemana").val('');
                $("#txthoraInicio").val('');
                $("#txthoraFim").val('');
                alert("Dados Salvos com sucesso!");
                carregarDisponibilidade();
            },
            error: function (jqXHR) {
                if (jqXHR.status === 400) {
                    var mensagem = "";
                    $(jqXHR.responseJSON.errors).each(function (index, elemento) {
                        mensagem = mensagem + elemento.errorMessage + "\n";
                    });
                    alert(mensagem);
                } else {
                    alert("Erro ao salvar os dados.");
                }
            }
        });
    })
});





function carregarDisponibilidade() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Disponibilidade",
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            //percorrer a lista inserindo no select
            $("#tabela").empty();
            $.each(jsonResult, function (index, item) {

                var linha = $("#linhaExemplo").clone()
                $(linha).find(".codigo").html(item.id)
                $(linha).find(".nome").html(item.diaDaSemana)

                $("#tabela").append(linha)
            })


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });



}

function excluir(codigo) {
    $.ajax({
        type: "DELETE",
        url: urlAPI + "api/Disponibilidade/" + codigo,
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            //percorrer a lista inserindo no select
            if (jsonResult) {
                alert("Exclusão efetuada!")
                carregarDisponibilidade();

            }
            else
                alert("Exclusão não pode ser efetuada!")


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}


function visualizar(codigo) {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Disponibilidade/" + codigo,
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            //percorrer a lista inserindo no select
            $("#txtid").val(jsonResult.id)
            $("#txtdiaDaSemana").val(jsonResult.diaDaSemana)
            $("#txthoraInicio").val(jsonResult.horaInicio)
            $("#txthoraFim").val(jsonResult.horaFim)
          



        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}