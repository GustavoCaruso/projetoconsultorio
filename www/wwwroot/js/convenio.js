


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {

   
    carregarConvenio();



    $("#btnlimpar").click(function () {

        $("#txtnome").val('');
        
        $("#txtid").val('0');
        
    });

    //evento visualizar
    //qd ocorrer o evento clique dos elementos que possuem
    //a classe alterar da tabelaConvenio => a função será executada
    $("#tabelaConvenio").on("click", ".alterar", function (elemento) {
        //alert('clicou visualizar!')
        //parent: retorna para elemmento pai
        //find: procura nos elementos filhos
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        visualizar(codigo)

    })


    $("#tabelaConvenio").on("click", ".excluir", function (elemento) {
        //alert('clicou excluir!')
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        excluir(codigo)
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
            url: urlAPI + "api/Convenio",
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
                carregarConvenio();
               
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });


    })

});



function carregarConvenio() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Convenio",
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            //percorrer a lista inserindo no select
            $("#tabelaConvenio").empty();
            $.each(jsonResult, function (index, item) {

                var linha = $("#linhaConvenio").clone()
                $(linha).find(".codigo").html(item.id)
                $(linha).find(".nome").html(item.nome)

                $("#tabelaConvenio").append(linha)
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
        url: urlAPI + "api/Convenio/" + codigo,
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            if (jsonResult) {
                alert('Exclusão efetuada!')
                carregarConvenio();
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
        url: urlAPI + "api/Convenio/" + codigo,
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            $("#txtid").val(jsonResult.id)
            $("#txtnome").val(jsonResult.nome)
           


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}