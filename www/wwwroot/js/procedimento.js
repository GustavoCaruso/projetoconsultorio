


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {

   
    carregarProcedimento();

    $("#btnlimpar").click(function () {
        $("#txtnome").val('');
        $("#txtduracao").val('');
        $("#txtid").val('0');
        $("#txtpreco").val('');
        

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
            preco: $("#txtpreco").val(),
            duracao: $("#txtduracao").val(),
           
        }

        console.log(JSON.stringify(obj))

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Procedimento",
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
                $("#txtpreco").val('');
                $("#txtid").val('0');
                $("#txtduracao").val('');
              
                alert("Dados Salvos com sucesso!")
                
               
                carregarProcedimento();
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



function carregarProcedimento() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Procedimento",
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
        url: urlAPI + "api/Procedimento/" + codigo,
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
                carregarProcedimento();

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
        url: urlAPI + "api/Procedimento/" + codigo,
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

            $("#txtpreco").val(jsonResult.preco)
            $("#txtduracao").val(jsonResult.duracao)
           


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}