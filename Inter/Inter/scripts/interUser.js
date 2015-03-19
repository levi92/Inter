//Variavel Global - Usada para acessar todas variaveis
var global = "";

var contador = -1;
var controlarMostra = false;

//FUNCTION INICIA APÓS CAREGAR A PÁGINA
$(document).ready(function () {
    Atualiza();
    Dia();

    if (controlarMostra == false) {
        $("#conteudo").slideUp(500, function () {
            idDiv = "p1";

            global = idDiv;
            $("#" + idDiv).show();
            $("#c" + idDiv).css("visibility", "visible");
            $("#conteudo").slideDown(500);

        });
    }

});

//FUNCTION QUE EXIBE O CONTEUDO DAS DIV'S CONFORME O PARAMETRO UTILIZADO NELA
function Mostra(idDiv) {

    $("#conteudo").slideUp(500, function () {
        $("#" + global).hide();
        $("#c" + global).css("visibility", "hidden");
        global = idDiv;
        $("#" + idDiv).show();
        $("#conteudo").slideDown(500);

    });

}

function etapa2() {
    controlarMostra = true;
    $("#" + global).hide();
    $("#c" + global).css("visibility", "hidden");
    global = "p10";
    $("#p10").show();
    $("#conteudo").slideDown(500);
}

function etapa3() {
    controlarMostra = true;
    Mostra('p12');
}

function etapa4() {
    controlarMostra = true;
    $("#" + global).hide();
    $("#c" + global).css("visibility", "hidden");
    global = "p13";
    $("#p13").show();
    $("#conteudo").slideDown(500);
}



//FUNCTION QUE PEGA A HORA DO SERVIDOR E RETORNA COM ELA TRABALHADA

function myFunction() {
    var dt = new Date();
    var hora = dt.getHours();
    var minuto = dt.getMinutes();
    var currentTime;

    if (minuto < 10) {
        minuto = "0" + dt.getMinutes();
    }

    if (hora < 10) {
        hora = "0" + dt.getHours();
    }

    currentTime = hora + ":" + minuto;
    return currentTime;

}


//FUNCTION QUE PEGA A DATA DO SERVIDOR E RETORNA COM ELA TRABALHADA
function Dia() {
    Hoje = new Date();
    Data = Hoje.getDate();
    Dia = Hoje.getDay();
    Mes = Hoje.getMonth();
    Ano = Hoje.getFullYear();

    if (Data < 10) {
        Data = "0" + Data;
    }

    NomeMes = new Array(12)
    NomeMes[0] = "Janeiro"
    NomeMes[1] = "Fevereiro"
    NomeMes[2] = "Março"
    NomeMes[3] = "Abril"
    NomeMes[4] = "Maio"
    NomeMes[5] = "Junho"
    NomeMes[6] = "Julho"
    NomeMes[7] = "Agosto"
    NomeMes[8] = "Setembro"
    NomeMes[9] = "Outubro"
    NomeMes[10] = "Novembro"
    NomeMes[11] = "Dezembro"

    //Imprime a varivel currentDay na tag dia
    var currentDay = Data + " de " + NomeMes[Mes] + " " + Ano;
    document.getElementById("dia").innerHTML = currentDay;
}

//IMPRIME A VARIVEL MYFUNCTION NA TAG HORA
function Atualiza() {
    document.getElementById("hora").innerHTML = myFunction();
    setTimeout('Atualiza()', 1000);
}


$(document).ready(function () {

    // ZERAR VALORES DATAS DE EVENTOS
    $("#btnAdicionarDatas").click(function () {
        $("#txtDescricaoData").val("");
        $("#txtData").val("");
        contr = false;
        $("#btnConfirmarData").removeAttr("data-dismiss");
    });


    // DATAS DE EVENTOS
    var i = 0;
    var dadosDatas = "";
    var contr = false; //PARA SABER SE IRÁ ATUALIZAR OU CRIAR UMA DATA
    var indiceId;


    $("#btnConfirmarData").click(function () {
        var descricaoData = $("#txtDescricaoData").val();
        var data = $("#txtData").val().split('-');

        //MENSAGENS DE ERRO
        if (descricaoData == "" && data == "") {
            //$("#btnConfirmarData").removeAttr("data-dismiss");
            $("#lblDescDataMsgErro").html("&nbsp &nbsp  Preenchimento obrigatório!");
            $("#lblDataMsgErro").html("&nbsp &nbsp  Preenchimento obrigatório!");

        } else
            if (descricaoData == "") {  //MENSAGEM DE ERRO
                //$("#btnConfirmarData").removeAttr("data-dismiss");
                $("#lblDescDataMsgErro").html("&nbsp &nbsp  Preenchimento obrigatório!");
                $("#lblDataMsgErro").html("");
            } else
                if (data == "") { //MENSAGEM DE ERRO
                    //$("#btnConfirmarData").removeAttr("data-dismiss");
                    $("#lblDataMsgErro").html("&nbsp &nbsp  Preenchimento obrigatório!");
                    $("#lblDescDataMsgErro").html("");
                } else {
                    //$("#btnConfirmarData").attr("data-dismiss", "modal");

                    var formatDate = data[2] + '/' + data[1] + '/' + data[0];

                    var btnExcluir = $('<button/>', {
                        type: 'button',
                        id: 'btnExcluir' + i,
                        value: 'Excluir',
                        title: 'Excluir',
                        class: 'btn btn-default btnExcluir',
                        click: function () {
                            var parentBotao = $(this).parent();

                            $(function () {
                                $("#boxDesejaExcluir").dialog({
                                    width: 400,
                                    height: 200,
                                    modal: true,
                                    resizable: false,
                                    draggable: false,
                                    buttons: {
                                        "Sim": function () {
                                            parentBotao.remove();
                                            $(this).dialog("close");
                                        },
                                        "Não": function () {
                                            $(this).dialog("close");
                                        }
                                    }

                                });
                            });

                        }
                    });

                    var div = '<div class="data" id="div' + i + '"> <b> <label id="descData' + i + '">' + descricaoData + '</label></b>' +
                        ': <label id="data' + i + '">' + formatDate + '</label>  </div> ';


                    var btnEditar = $('<button/>', {
                        type: 'button',
                        id: 'btnEditar-' + i,
                        value: 'Editar',
                        title: 'Editar',
                        class: 'btn btn-default btnEditar',
                        click: function () {
                            //$("#ContentPlaceHolder1_txtDescricaoData").val("");
                            $("#txtData").val("");
                            indiceId = $(this).attr('id').split('-');

                            $("#txtDescricaoData").val($('#descData' + indiceId[1]).html());
                            dtUSA = $('#data' + indiceId[1]).html().split('/');
                            dtUSA = dtUSA[2] + '-' + dtUSA[1] + '-' + dtUSA[0];
                            $("#txtData").val(dtUSA);
                            contr = true;
                            $("#btnConfirmarData").attr("data-dismiss", "modal");
                        }
                    });

                    btnEditar.attr({ 'data-toggle': 'modal', 'data-target': '#myModal1' });

                    if (contr == false) {
                        $("#containerDatas").append(div);
                        $("#div" + i).append(btnExcluir);
                        $("#div" + i).append(btnEditar);

                        var ed = document.getElementById('btnEditar-' + i);
                        ed.insertAdjacentHTML('afterbegin', '<span class="glyphicon glyphicon-pencil"></span>');

                        var ex = document.getElementById('btnExcluir' + i);
                        ex.insertAdjacentHTML('afterbegin', '<span class="glyphicon glyphicon-trash"></span>');

                        i++;
                    } else { //SOMENTE EDITAR
                        $('#descData' + indiceId[1]).html($("#txtDescricaoData").val());
                        data = $("#txtData").val().split('-');
                        formatDate = data[2] + '/' + data[1] + '/' + data[0];
                        $('#data' + indiceId[1]).html(formatDate);
                    }

                    $("#lblDescDataMsgErro").html("");
                    $("#lblDataMsgErro").html("");
                    $("#txtDescricaoData").val("");
                    $("#txtData").val("");
                }

    });

    //CONTINUAR ETAPA 2 - PEGAR DADOS DATAS
    $("#btnContinuarEtapa2").click(function () {
        var auxData = "";
        dadosDatas = "";

        for (var index = 0; index < i; index++) {
            auxData = "";
            auxData = $('#descData' + index).html();

            if (typeof (auxData) != "undefined") {
                dadosDatas += $('#descData' + index).html() + "-" + $('#data' + index).html() + "|";
            }

        }

        alert(dadosDatas);

    });


    $("#ContinuarEtapa4").click(function () {
        var msgErro = false;
        txtPostura = $('#txtP').val();
        txtVestimenta = $('#txtV').val();
        txtfala = $('#txtF').val();
        txtConhecimento = $('#txtC').val();

        if ($.trim(txtPostura) == '' || $.trim(txtVestimenta) == '' || $.trim(txtfala) == '' || $.trim(txtConhecimento) == '') {
            $(function () {
                $("#boxPesoBranco").dialog({
                    width: 400,
                    height: 200,
                    modal: true,
                    resizable: false,
                    draggable: false,
                    buttons: {
                        "Sim": function () {
                            Mostra('p13'); //criar Grupo
                            $(this).dialog("close");

                        },
                        "Não": function () {
                            $(this).dialog("close");
                        }
                    }


                });
            });
        } else {
            Mostra('p13'); //criar Grupo
        }
    });






    ////sortable mover com duplo clique
    //$("ul#sortable3 li").dblclick(function () {
    //    $(this).appendTo("ul#sortable4");
    //});










});