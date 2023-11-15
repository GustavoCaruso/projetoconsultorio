


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {


    carregarStatusConsulta();

    $("#btnlimpar").click(function () {
        $("#txtnome").val('');
       
        $("#txtid").val('0');
       


    });



    //evento visualizar
    $("#tabela").on("click", ".alterar", function (elemento) {
        //alert('cliclou em vizualizar!')
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        visualizar(codigo);
    })

    $("#tabela").on("click", ".excluir", function (elemento) {
        //alert('cliclou excluir!')
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        excluir(codigo);
    })

    $("#btnsalvar").click(function () {
        //validar
        const obj = {
            id: $("#txtid").val(),
            nome: $("#txtnome").val(),
           

        }

        console.log(JSON.stringify(obj))

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/StatusConsulta",
            contentType: "application/json;charset=utf-8",
            /*
            headers: {
                "Authorization": "Bearer " + token
            },*/

            data: JSON.stringify(obj),
            dataType: "json",
            success: function (jsonResult) {

                console.log(jsonResult)
                $("#txtnome").val('');
               
                $("#txtid").val('0');
               

                alert("Dados Salvos com sucesso!")


                carregarStatusConsulta();
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });


    })

});



function carregarStatusConsulta() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/StatusConsulta",
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
                $(linha).find(".nome").html(item.nome)

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
        url: urlAPI + "api/StatusConsulta/" + codigo,
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
                carregarStatusConsulta();

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
        url: urlAPI + "api/StatusConsulta/" + codigo,
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
            $("#txtnome").val(jsonResult.nome)

          



        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}