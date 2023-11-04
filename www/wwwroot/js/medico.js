


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {


    carregarMedico();



    $("#btnlimpar").click(function () {

        $("#txtid").val('0');
        $("#txtnome").val('');
        $("#txtdataNascimento").val('');
        $("#txtgenero").val('');
        $("#txtenderecoResidencial").val('');
        $("#txtnumeroTelefone").val('');
        $("#txtemail").val('');
        $("#txtcrm").val('');
        $("#txtespecializacao").val('');
 
    });

    //evento visualizar
    //qd ocorrer o evento clique dos elementos que possuem
    //a classe alterar da tabelaMedico => a função será executada
    $("#tabelaMedico").on("click", ".alterar", function (elemento) {
        //alert('clicou visualizar!')
        //parent: retorna para elemmento pai
        //find: procura nos elementos filhos
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        visualizar(codigo)

    })


    $("#tabelaMedico").on("click", ".excluir", function (elemento) {
        //alert('clicou excluir!')
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        excluir(codigo)
    })


    $("#btnsalvar").click(function () {
        //validar
        const obj = {
            id: $("#txtid").val(),
            nome: $("#txtnome").val(),
            dataNascimento: $("#txtdataNascimento").val(),
            genero: $("#txtgenero").val(),
            enderecoResidencial: $("#txtenderecoResidencial").val(),
            numeroTelefone: $("#txtnumeroTelefone").val(),
            email: $("#txtemail").val(),
            crm: $("#txtcrm").val(),
            especializacao: $("#txtespecializacao").val()


        }

        console.log(JSON.stringify(obj))

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Medico",
            contentType: "application/json;charset=utf-8",
            /*
            headers: {
                "Authorization": "Bearer " + token
            },*/

            data: JSON.stringify(obj),
            dataType: "json",
            success: function (jsonResult) {

                console.log(jsonResult)
                $("#txtid").val('0');
                $("#txtnome").val('');
                $("#txtdataNascimento").val('');
                $("#txtgenero").val('');
                $("#txtenderecoResidencial").val('');
                $("#txtnumeroTelefone").val('');
                $("#txtemail").val('');
                $("#txtcrm").val('');
                $("#txtespecializacao").val('');

                

                alert("Dados Salvos com sucesso!")
                carregarMedico();

            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });


    })

});



function carregarMedico() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Medico",
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            //percorrer a lista inserindo no select
            $("#tabelaMedico").empty();
            $.each(jsonResult, function (index, item) {

                var linha = $("#linhaMedico").clone()
                $(linha).find(".codigo").html(item.id)
                $(linha).find(".nome").html(item.nome)

                $("#tabelaMedico").append(linha)
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
        url: urlAPI + "api/Medico/" + codigo,
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
                carregarMedico();
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
        url: urlAPI + "api/Medico/" + codigo,
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {

            console.log(jsonResult)
            $("#txtid").val(jsonResult.id);
            $("#txtnome").val(jsonResult.nome);
            $("#txtdataNascimento").val(jsonResult.dataNascimento);
            $("#txtgenero").val(jsonResult.genero);
            $("#txtenderecoResidencial").val(jsonResult.enderecoResidencial);
            $("#txtnumeroTelefone").val(jsonResult.numeroTelefone);
            $("#txtemail").val(jsonResult.email);
            $("#txtcrm").val(jsonResult.crm);
            $("#txtespecializacao").val(jsonResult.especializacao);



        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}