
$(document).ready(function () {

    $("#btnenviar").click(function () {

        const usuario = {
            "id": 0,
            "nome": "string",
            "email": $("#txtemail").val(),
            "senha": $("#txtsenha").val()
        }

        //requisicao
        $.ajax({
            type: "POST",
            url: "http://localhost:33186/api/Usuario/validaLogin",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(usuario),
            dataType: "json",
            success: function (jsonResult) {
                console.log(jsonResult)
                sessionStorage.setItem('token', jsonResult.token);
                sessionStorage.setItem('idUsuario', jsonResult.id);
                sessionStorage.setItem('nomeUsuario', jsonResult.nome);
                window.location.href = "/principal"
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });


    });



});