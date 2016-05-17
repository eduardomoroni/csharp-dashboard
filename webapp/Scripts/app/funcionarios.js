

function hideTab() {
    if ($("#show-tabs").is(":checked") == true) {
        $('#btnuser').show();
        $('#widget-tab-1 a:last').show()
    } else {
        $('#btnuser').hide();
        $('#widget-tab-1 a:last').hide()
    }
}

$("#show-tabs").click(hideTab);

function filtrarCidades(itemId) {
    var e = document.getElementById("estados");
    var strUser = e.options[e.selectedIndex].value;

    $.ajax({
        type: "Get",
        url: "/Funcionarios/Obtercidades/" + strUser,
        data: "{'itemId':" + (itemId) + "}",
        contentType: "application/json; charset=utf-8",
        global: false,
        async: false,
        dataType: "json",

        success: function (jsonObj) {
            var listItems = "";
            for (i in jsonObj) {
                listItems += "<option value='" + jsonObj[i].Value + "'>" + jsonObj[i].Text + "</option>";
            }
            $("#cidades").html(listItems);
        }
    });
    return false;
}


$("#estados").change(function (itemId) {
    var e = document.getElementById("estados");
    var strUser = e.options[e.selectedIndex].value;

    $.ajax({
        type: "Get",
        url: "/Funcionarios/Obtercidades/" + strUser,
        data: "{'itemId':" + (itemId) + "}",
        contentType: "application/json; charset=utf-8",
        global: false,
        async: true,
        dataType: "json",

        success: function (jsonObj) {
            var listItems = "";
            for (i in jsonObj) {
                listItems += "<option value='" + jsonObj[i].Value + "'>" + jsonObj[i].Text + "</option>";
            }
            $("#cidades").html(listItems);
        }
    });
    return false;
});

 function tratarJsonCep(json){
                    $("#estados").find("option:selected").text(json.estado);
                    $("#endereco").val(json.tipoDeLogradouro + ' ' + json.logradouro);
                    $("#bairro").val(json.bairro);
                    $("#cidades").find("option:selected").text(json.cidade);
                    $("#numero").focus();
                    console.log(json);
                }

                function cepNaoEncontrado() {
                    console.log("CEP não encontrado!!");
                }
                
                $("#cep").change(function () {
                    json = $.ajax({
                        type: "Get",
                        url: 'http://correiosapi.apphb.com/cep/' + $("#cep").val().replace('-', '').replace('.', ''),
                        dataType: 'jsonp',
                        contentType: "application/json",
                        global: false,
                        async: true,
                         success: function (jsonObj) {
                            tratarJsonCep(jsonObj);
                        }
                    });
                });
