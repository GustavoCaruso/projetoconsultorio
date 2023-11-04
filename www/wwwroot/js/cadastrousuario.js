const urlAPI = "http://localhost:33186/"

$(document).ready(function () {

   
   
    $("#btnlimpar").click(function () {
        $("#txtnome").val('');
        $("#txtemail").val('');
        $("#txtid").val('0');
        $("#txtsenha").val('');
       

    });



    

    $("#btnsalvar").click(function () {
        // validar
        const obj = {
            id: $("#txtid").val(),
            nome: $("#txtnome").val(),
            email: $("#txtemail").val(),
            senha: $("#txtsenha").val(),
        }

        console.log(JSON.stringify(obj))

        $.ajax({
            type: $("#txtid").val() == "0" ? "POST" : "PUT",
            url: urlAPI + "api/Usuario",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(obj),
            dataType: "json",
            success: function (jsonResult) {
                console.log(jsonResult)
                $("#txtnome").val('');
                $("#txtemail").val('');
                $("#txtid").val('0');
                $("#txtsenha").val('');
                alert("Dados Salvos com sucesso!")
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


    })

});