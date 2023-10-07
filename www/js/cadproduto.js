token = sessionStorage.getItem('token');
if (token == null)
    window.location.href = 'login.html'

const urlAPI = "http://localhost:33186/"


$(document).ready(function () {
    carregarcategoria();
    $("#btnsair").click(function () {
        sessionStorage.setItem('token', "");
        window.location.href= 'login.html'
    });
});

function carregarcategoria() {

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