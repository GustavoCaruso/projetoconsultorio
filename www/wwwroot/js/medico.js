


const urlAPI = "http://localhost:33186/"

$(document).ready(function () {


    carregarMedico();
    carregarConvenio();
    carregarDisponibilidade();



    $("#btnlimpar").click(function () {

        $("#txtnome").val('');
        $("#txtdataNascimento").val('');
        $("#txtgenero").val('0');
        $("#txtenderecoResidencial").val('');
        $("#txtnumeroTelefone").val('');
        $("#txtemail").val('');
        $("#txtcrm").val('');
        $("#txtespecializacao").val('');
        $('#convenio').prop('selectedIndex', -1);
        $('#disponibilidade').prop('selectedIndex', -1);
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


        var listamedicoconvenio = new Array();
        $('#convenio option').each(function () {
            console.log($(this))
            if ($(this).is(':selected')) {
                var obj = {
                    "id": 0,
                    "medicoId": $("#txtid").val(),
                    "convenioId": $(this).val()

                }
                listamedicoconvenio.push(obj);
            }
        });

        var listamedicodisponibilidade = new Array();
        $('#disponibilidade option').each(function () {
            console.log($(this))
            if ($(this).is(':selected')) {
                var obj = {
                    "id": 0,
                    "medicoId": $("#txtid").val(),
                    "disponibilidadeId": $(this).val()

                }
                listamedicodisponibilidade.push(obj);
            }
        });

        const obj = {
            id: $("#txtid").val(),
            nome: $("#txtnome").val(),
            dataNascimento: $("#txtdataNascimento").val(),
            genero: $("#txtgenero").val(),
            enderecoResidencial: $("#txtenderecoResidencial").val(),
            numeroTelefone: $("#txtnumeroTelefone").val(),
            email: $("#txtemail").val(),
            crm: $("#txtcrm").val(),
            especializacao: $("#txtespecializacao").val(),
            medicoconvenio: listamedicoconvenio,
            medicodisponibilidade: listamedicodisponibilidade
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
                $("#txtnome").val('');
                $("#txtdataNascimento").val('');
                $("#txtid").val('0');
                $("#txtgenero").val('');
                $("#txtenderecoResidencial").val('');
                $("#txtnumeroTelefone").val('');
                $("#txtemail").val('');
                $("#txtcrm").val('');
                $("#txtespecializacao").val('');
                $('#convenio').prop('selectedIndex', -1);
                $('#disponibilidade').prop('selectedIndex', -1);
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
            $("#txtid").val(jsonResult.id)
            $("#txtnome").val(jsonResult.nome)
            $("#txtdataNascimento").val(jsonResult.dataNascimento.substring(0, 10))
            $("#txtgenero").val(jsonResult.genero)
            $("#txtenderecoResidencial").val(jsonResult.enderecoResidencial)
            $("#txtnumeroTelefone").val(jsonResult.numeroTelefone)
            $("#txtemail").val(jsonResult.email)
            $("#txtcrm").val(jsonResult.crm)
            $("#txtespecializacao").val(jsonResult.especializacao)

            var itensConvenio = [];
            $.each(jsonResult.medicoconvenio, function (index, item) {
                itensConvenio.push(item.convenioId);
            })

            $('#convenio').val(itensConvenio);

            var itensDisponibilidade = [];
            $.each(jsonResult.medicodisponibilidade, function (index, item) {
                itensDisponibilidade.push(item.disponibilidadeId);
            })
            $('#disponibilidade').val(itensDisponibilidade);

        },
        failure: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}

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
            $("#disponibilidade").empty();

            $.each(jsonResult, function (index, item) {
                var option = $("<option>", { value: item.id }).text(item.diaDaSemana);
                $("#disponibilidade").append(option);
            });
        },
        error: function (response) {
            alert("Erro ao carregar os dados: " + response);
        }
    });
}
