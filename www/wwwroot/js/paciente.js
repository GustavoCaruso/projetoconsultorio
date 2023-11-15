


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {


    carregarPaciente();
    carregarConvenio();



    $("#btnlimpar").click(function () {

        $("#txtid").val('0');
        $("#txtnome").val('');
        $("#txtrg").val('');
        $("#txtcpf").val('');
        $("#txtgenero").val('');
        $("#txtestadoCivil").val('');
        $("#txttelefone").val('');
        $("#txtemail").val('');
        $('#convenio').prop('selectedIndex', -1);
    });

    //evento visualizar
    //qd ocorrer o evento clique dos elementos que possuem
    //a classe alterar da tabela => a função será executada
    $("#tabela").on("click", ".alterar", function (elemento) {
        //alert('clicou visualizar!')
        //parent: retorna para elemmento pai
        //find: procura nos elementos filhos
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        visualizar(codigo)

    })


    $("#tabela").on("click", ".excluir", function (elemento) {
        //alert('clicou excluir!')
        let codigo = $(elemento.target).parent().parent().find(".codigo").text()
        excluir(codigo)
    })


    $("#btnsalvar").click(function () {
        //validar


        var listapacienteconvenio = new Array();
        $('#convenio option').each(function () {
            console.log($(this))
            if ($(this).is(':selected')) {
                var obj = {
                    "id": 0,
                    "pacienteId": $("#txtid").val(),
                    "convenioId": $(this).val()

                }
                listapacienteconvenio.push(obj);
            }
        });


        const obj = {
            id: $("#txtid").val(),
            nome: $("#txtnome").val(),
            rg: $("#txtrg").val(),
            cpf: $("#txtcpf").val(),
            genero: $("#txtgenero").val(),
            estadoCivil: $("#txtestadoCivil").val(),
            telefone: $("#txttelefone").val(),
            email: $("#txtemail").val(),
           
            pacienteconvenio: listapacienteconvenio
        }

        console.log(JSON.stringify(obj))

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Paciente",
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
                $("#txtrg").val('');
                $("#txtcpf").val('');
                $("#txtgenero").val('');
                $("#txtestadoCivil").val('');
                $("#txttelefone").val('');
                $("#txtemail").val('');
                $('#convenio').prop('selectedIndex', -1);
                alert("Dados Salvos com sucesso!")
                carregarPaciente();

            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });


    })

});



function carregarPaciente() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Paciente",
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
            $("#convenio").empty();


            $.each(jsonResult, function (index, item) {
                var option = $("<option>", { value: item.id, text: item.nome })
                $("#convenio").append(option)
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
        url: urlAPI + "api/Paciente/" + codigo,
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
                carregarPaciente();
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
        url: urlAPI + "api/Paciente/" + codigo,
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

            $("#txtrg").val(jsonResult.rg)
            $("#txtcpf").val(jsonResult.cpf)
            $("#txtgenero").val(jsonResult.genero)
            $("#txtestadoCivil").val(jsonResult.estadoCivil)
            $("#txttelefone").val(jsonResult.telefone)
            $("#txtemail").val(jsonResult.email)
           
            var itensConvenio = [];
            $.each(jsonResult.pacienteconvenio, function (index, item) {
                itensConvenio.push(item.convenioId);
            })

            $('#convenio').val(itensConvenio);

        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}