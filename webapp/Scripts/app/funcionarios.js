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

$(document).ready(function () {
    var listItems = "";
    listItems += "<option value='" + 1 + "'>" + "Escolha o Estado" + "</option>";
    $("#cidades").html(listItems);

})

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

function preencheEndereco(itemId) {
    var e = document.getElementById("Ceptxtbox");
    var strUser = e.options[e.selectedIndex].value;

    $.ajax({
        type: "Get",
        url: "/ConsultaCEPBrasils/ObterCep/86084835",
        data: "{'itemId':" + (itemId) + "}",
        contentType: "application/json; charset=utf-8",
        global: false,
        async: false,
        dataType: "json",

        success: function (jsonObj) {
            var id_cidade = "";
            var id_uf = "";
            var endereco = "";
            var bairro = "";

            for (i in jsonObj) {
                id_cidade = jsonObj[i].ID_CIDADE;
                id_uf = jsonObj[i].ID_UF;
                endereco = jsonObj[i].ID_ENDERECO;
                bairro = jsonObj[i].BAIRRO;
            }

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



