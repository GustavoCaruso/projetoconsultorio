


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {

    carregarCategoria();
    carregarProdutos();

    $("#btnlimpar").click(function () {
        $("#txtdescricao").val('');
        $("#txtquantidade").val('');
        $("#txtid").val('0');
        $("#txtvalor").val('');
        $("#txtdata").val('');
        $("#categoria").val("0");

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
            descricao: $("#txtdescricao").val(),
            valor: $("#txtvalor").val(),
            qtde: $("#txtquantidade").val(),
            datavalidade: $("#txtdata").val(),
            idCategoria: $("#categoria").val()
        }

        console.log(JSON.stringify(obj))

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Produto",
            contentType: "application/json;charset=utf-8",
            /*
            headers: {
                "Authorization": "Bearer " + token
            },*/

            data: JSON.stringify(obj),
            dataType: "json",
            success: function (jsonResult) {

                console.log(jsonResult)
                $("#txtdescricao").val('');
                $("#txtquantidade").val('');
                $("#txtid").val('0');
                $("#txtvalor").val('');
                $("#txtdata").val('');
                alert("Dados Salvos com sucesso!")
                
                $("#catgoria").val("0");
                carregarProdutos();
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });


    })

});


function carregarCategoria() {

    $.ajax({
        type: "GET",
        url: urlAPI + "api/Categoria",
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            //percorrer a lista inserindo no select
            $("#categoria").empty();
            $.each(jsonResult, function (index, item) {
                var option = $("<option>", { value: item.id, text: item.descricao })
                $("#categoria").append(option)
            })


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });

}

function carregarProdutos() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Produto",
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
                $(linha).find(".descricao").html(item.descricao)

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
        url: urlAPI + "api/Produto/" + codigo,
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
                carregarProdutos();

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
        url: urlAPI + "api/Produto/" + codigo,
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
            $("#txtdescricao").val(jsonResult.descricao)
            $("#txtdata").val(jsonResult.datavalidade.substring(0, 10))
            $("#txtvalor").val(jsonResult.valor)
            $("#txtquantidade").val(jsonResult.qtde)
            $("#categoria").val(jsonResult.idCategoria)


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}