/// <reference path="../paginas/Usuario/escolherDisciplina.aspx" />
//Variavel Global - Usada para acessar todas variaveis
var global = "";
var globalCor = "";
var contador = -1;

//Function inicia após caregar a página
$(document).ready(function () {
    Atualiza();
    Dia();   

    $("#conteudo").slideUp(500, function () {
        idDiv = "p1";

        global = idDiv;
        $("#" + idDiv).show();
        $("#c" + idDiv).css("visibility", "visible");
        $("#conteudo").slideDown(500);
                
    });
    
    //SELECIONAR APENAS UM RADIO
    //$("input[type=radio]").click(function () {
    //    var idRb = $(this).attr('id');
        

    //    if(idRb == "selecionado"){
    //        $(this).attr("checked", true); 
    //    }else{
    //        $('#selecionado').attr("checked", false).attr("id", "rb");  //radio que estava selecionado fica false               
       
    //        $(this).attr('id', 'selecionado');
    //        $(this).attr("checked", true);        
    //    }
    //});
    
});

//Function que exibe o conteudo das Div's conforme o parametro utilizado nela
function Mostra(idDiv) {

    $("#conteudo").slideUp(500, function () {
        $("#" + global).hide();
        $("#c" + global).css("visibility", "hidden");
        global = idDiv;
        $("#" + idDiv).show();
        $("#conteudo").slideDown(500);

    });

}

//Function que pega a hora do servidor e retorna com ela trabalhada

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


//Function que pega a data do servidor e retorna com ela trabalhada
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

//Imprime a varivel myFunction na tag hora
function Atualiza() {
    document.getElementById("hora").innerHTML = myFunction();
    setTimeout('Atualiza()', 1000);
}

//Function que confere login e senha
//$('#enviar').click(function () {
//    var nome = $('#login').val();
//    var idade = $('#senha').val();

//    if ($.trim(nome) == 'administrador') {
//        $('#choose').modal({});
//    } else {
//        if ($.trim(nome) == 'professor') {
//            window.location = "../Usuario/user.aspx";
//        } else {
//            $('#incorreto').modal({});
//        }
//    }
//});

var cont = 1; //para não chamar a tela Home novamente
var iconeClicado = " "; //para voltar nessa página após escolher disciplina
//$('#ContentPlaceHolder1_btnConfirmar').click(function () {
    
    //$(".gridView tr td").each(function () {
    //    if ($('input:radio[name=Grupo]').is(':checked')) {
    //        $(this).css("background-color", "orange");
    //        //$(".gridView tr td").css("background-color", "orange");
    //    }
    //});

    //$(".gridView tr").on('click', function () {
    //    if ($('input:radio[name=Grupo]').is(':checked')) {
    //        $(this).css("background-color", "orange");
    //    }
    //});

    //$('input:radio[name=Grupo]').change(function () {
        //$("select option:selected").each(function () {
           // $(".gridView tr td").css("background-color", "orange");
        //});
        
    //});

        //$(function () {
        //    $("#boxSelecioneDisc").dialog({
        //        width: 400,
        //        height: 200,
        //        modal: true,
        //        resizable: false,
        //        draggable: false,
        //        buttons: {
        //            "OK": function () {
        //                //alert("Tem certeza?");                                    
        //                $(this).dialog("close");
        //            }
        //        }


        //    });
        //});
    //}


//});


//function desabilitarIcones() {
//    for (var i = 2; i <= 10; i++) {
//        $("#icone" + i).css("pointer-events", "none");
//    }
//}

//function habilitarIcones() {
//    for (var i = 2; i <= 10; i++) {
//        $("#icone" + i).css("pointer-events", "all");
//    }
//}


$(document).ready(function () {

    //desabilitarIcones();

    //$('#btnEscolherDisciplina').click(function () {
    //    desabilitarIcones();
        //window.location = "../paginas/Usuario/escolherDisciplina.aspx";
    //});

    //Function alterar a cor do ícone do menu
    //$('#icone2').click(function () {
    //    $(globalCor).removeClass('corIcone');
    //    $('#icone2').addClass('corIcone');
    //    globalCor = "#icone2";
    //    iconeClicado = "p2";
       
    //}); //HOME

    //$('#logoInter').click(function () {
    //    if (cont > 1) {            
    //        window.location = "../Usuario/home.aspx";
    //    }
    //}); //HOME
    

    

    //$('#btnVoltarHome').click(function () {
    //    $(globalCor).removeClass('corIcone');
    //    $('#icone2').addClass('corIcone');
    //    globalCor = "#icone2";
    //    iconeClicado = "p2";
    //});

    //$('#btnVoltarHome2').click(function () {
    //    $(globalCor).removeClass('corIcone');
    //    $('#icone2').addClass('corIcone');
    //    globalCor = "#icone2";
    //    iconeClicado = "p2";
    //});

    //$('#btnVoltarAvaliar').click(function () {
    //    $(globalCor).removeClass('corIcone');
    //    $('#icone8').addClass('corIcone');
    //    globalCor = "#icone8";
    //    iconeClicado = "p8";
    //});


    

    $('#btnContinuarEtapa3').click(function () {
        var dadosCrit = "";

        $('#sortable4 > li').each(function () {
            dadosCrit += $(this).html() + "|";
        });

        $.ajax({
            type: 'POST',
            url: 'user.aspx/GetCriterio',
            data: "{criterio:" + JSON.stringify(dadosCrit) + "}",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (r) {
                for (var key in r) {
                    var value = r[key];
                    alert(value);
                }
            }
        });

        //var criterio = '';
        //var vetCriterio = [];
        //vetCriterio = dadosCrit.split('|');

        //for (var i = 0; i < vetCriterio.length-1; i = i + 1)
        //{
        //    criterio = '<div>' + vetCriterio[i] + '</div>';
        //    console.log(i + "i = " + vetCriterio[i]);
        //    $('div#cri').append(criterio);
        //}



        Mostra('p12');
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
                            $('#txtP').val('1');
                            $('#txtV').val('1');
                            $('#txtF').val('1');
                            $('#txtC').val('1');

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



    //$('#btnConfirmarMateria').click(function () {
    //$(function () {
    //    $("#box").dialog({
    //        width: 400,
    //        height: 200,
    //        modal: true,
    //        resizable: false,
    //        draggable: false,
    //        buttons: {
    //            "Ok": function () {
    //                //alert("Tem certeza?");                                    
    //                $(this).dialog("close");
    //            },
    //            "No!": function () {
    //                $(this).dialog("close");
    //            }
    //        }


    //    });
    //});

    //});


    




});