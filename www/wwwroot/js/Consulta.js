


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {

    carregarProcedimento();
    carregarStatusConsulta();
    carregarMedico();
    carregarPaciente();
    carregarConvenio();
    carregarConsulta();



    $("#btnlimpar").click(function () {


        $("#txtid").val('0');
        $("#txtdiaDaSemana").val('');
        $("#txthoraInicio").val('');
        $("#txthoraFim").val('');
        $("#medico").val("0");
        $("#paciente").val("0");
        $("#convenio").val("0");
        $("#procedimento").val("0");
        $("#statusConsulta").val("0");
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
        const obj = {
            id: $("#txtid").val(),
            data: $("#txtdata").val(),
            horaInicio: $("#txthoraInicio").val(),
            horaFim: $("#txthoraFim").val(),
            pacienteId: $("#paciente").val(),
            medicoId: $("#medico").val(),
            procedimentoId: $("#procedimento").val(),
            statusConsultaId: $("#statusConsulta").val(),
            convenioId: $("#convenio").val()
        }


        console.log(JSON.stringify(obj))

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Consulta",
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
                $("#medico").val("0");
                $("#procedimento").val("0");
                $("#statusConsulta").val("0");
                $("#convenio").val("0");
                $("#paciente").val("0");
                $("#txthoraInicio").val('');
                $("#txthoraFim").val('');
                $("#txtdata").val('');
               
                alert("Dados Salvos com sucesso!")
                carregarConsulta();

            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });


    })

});



function carregarConsulta() {
    $.ajax({
        type: "GET",
        url: urlAPI + "api/Consulta",
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
                $(linha).find(".data").html(item.data)

                $("#tabela").append(linha)
            })


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });

}


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
            $("#statusConsulta").empty();

            var option = $("<option>", { value: 0, text: "Selecione um status para a consulta" })
            $("#statusConsulta").append(option)

            $.each(jsonResult, function (index, item) {
                var option = $("<option>", { value: item.id, text: item.nome })
                $("#statusConsulta").append(option)
            })


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });

}

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
            $("#procedimento").empty();

            var option = $("<option>", { value: 0, text: "Selecione um procedimento" })
            $("#procedimento").append(option)

            $.each(jsonResult, function (index, item) {
                var option = $("<option>", { value: item.id, text: item.nome })
                $("#procedimento").append(option)
            })


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });

}


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
            $("#medico").empty();

            var option = $("<option>", { value: 0, text: "Selecione um médico" })
            $("#medico").append(option)

            $.each(jsonResult, function (index, item) {
                var option = $("<option>", { value: item.id, text: item.nome })
                $("#medico").append(option)
            })


        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });

}

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
            $("#paciente").empty();

            var option = $("<option>", { value: 0, text: "Selecione um paciente" })
            $("#paciente").append(option)

            $.each(jsonResult, function (index, item) {
                var option = $("<option>", { value: item.id, text: item.nome })
                $("#paciente").append(option)
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

            var option = $("<option>", { value: 0, text: "Selecione um convenio" })
            $("#convenio").append(option)

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
        url: urlAPI + "api/Consulta/" + codigo,
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
                carregarConsulta();
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
        url: urlAPI + "api/Consulta/" + codigo,
        contentType: "application/json;charset=utf-8",

        headers: {
            "Authorization": "Bearer " + token
        },

        data: {},
        dataType: "json",
        success: function (jsonResult) {
            console.log(jsonResult);

            $("#txtid").val(jsonResult.id || '');
            $("#txtdata").val(jsonResult.data ? jsonResult.data.substring(0, 10) : '');
            $("#txthoraInicio").val(jsonResult.horaInicio || '');
            $("#txthoraFim").val(jsonResult.horaFim || '');
            $("#procedimento").val(jsonResult.procedimentoId || 0);
            $("#medico").val(jsonResult.medicoId || 0);
            $("#convenio").val(jsonResult.convenioId || 0);
            $("#statusConsulta").val(jsonResult.statusConsultaId || 0);
            $("#paciente").val(jsonResult.pacienteId || 0);
        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}
