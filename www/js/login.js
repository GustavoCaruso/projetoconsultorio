$(document).ready(function () {
    $("#btnenviar").click(function () {

        const usuario = {
            "id": 0,
            "nome": "string",
            "email": $("#txtemail").val(),
            "senha": $("#txtsenha").val()
        }

        //requisição
        $.ajax({
            type: "POST",
            url: "http://localhost:33186/api/Usuario/validarLogin",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(usuario),
            dataType: "json",
            success: function (jsonResult) {
                console.log("logado!")
                sessionStorage.setItem('token', jsonResult.token);
                window.location.href = "cadproduto.html"
            },
            failure: function (response) {
                alert("Erro ao carregar os dados: " + response);
            }
        });

    });
});