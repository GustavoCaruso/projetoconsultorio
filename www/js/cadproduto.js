token = sessionStorage.getItem('token');

if (token == null || token == "")
    window.location.href = 'login.html'


const urlAPI = "https://localhost:44353/"

$(document).ready(function () {

    carregarCategoria();

    $("#btnsalvar").click(function () {
        //validar
        const obj = {
            id: 0,
            descricao: $("#txtdescricao").val(),
            valor: 10, //$("#txtvalor").val()
            qtde: $("#txtquantidade").val(),
            datavalidade: "2023-10-07T00:22:26.511Z", //$("#txtdata").val()
            idCategoria: $("#categoria").val()
        }

        $.ajax({
            type: "POST",
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
                alert("Dados Salvos com sucesso!")


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