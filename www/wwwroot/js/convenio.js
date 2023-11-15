const urlAPI = "http://localhost:33186/";

$(document).ready(function () {

    carregarConvenio();

    $("#btnlimpar").click(function () {
        $("#txtnome").val('');
        $("#txtid").val('0');
    });

    $("#tabelaConvenio").on("click", ".alterar", function (elemento) {
        let codigo = $(elemento.target).parent().parent().find(".codigo").text();
        visualizarConvenio(codigo);
    });

    $("#tabelaConvenio").on("click", ".excluir", function (elemento) {
        let codigo = $(elemento.target).parent().parent().find(".codigo").text();
        excluirConvenio(codigo);
    });

    $("#btnsalvar").click(function () {
        const obj = {
            id: $("#txtid").val(),
            nome: $("#txtnome").val(),
        };

        console.log(JSON.stringify(obj));

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Convenio",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(obj),
            dataType: "json",
            success: function (jsonResult) {
                console.log(jsonResult);
                $("#txtnome").val('');
                $("#txtid").val('0');
                alert("Dados Salvos com sucesso!");
                carregarConvenio();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status === 409) {
                    var errorMessage = JSON.parse(jqXHR.responseText);
                    alert("Erro ao salvar os dados: " + errorMessage.message);
                } else {
                    if (jqXHR.status === 400) {
                        var mensagem = "";
                        $(jqXHR.responseJSON.errors).each(function (index, elemento) {
                            mensagem = mensagem + elemento.errorMessage + "\n";
                        });
                        alert(mensagem);
                    } else {
                        alert("Erro ao salvar os dados: " + errorThrown);
                    }
                }
            }
        });
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
                console.log(jsonResult);
                $("#tabelaConvenio").empty();
                $.each(jsonResult, function (index, item) {
                    var linha = $("#linhaConvenio").clone();
                    $(linha).find(".codigo").html(item.id);
                    $(linha).find(".nome").html(item.nome);
                    $("#tabelaConvenio").append(linha);
                });
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });
    }

    function excluirConvenio(codigo) {
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
                console.log(jsonResult);
                if (jsonResult) {
                    alert('Exclusão efetuada!');
                    carregarConvenio();
                } else {
                    alert("Exclusão não pode ser efetuada!");
                }
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });
    }

    function visualizarConvenio(codigo) {
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
                console.log(jsonResult);
                $("#txtid").val(jsonResult.id);
                $("#txtnome").val(jsonResult.nome);
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });
    }
});







