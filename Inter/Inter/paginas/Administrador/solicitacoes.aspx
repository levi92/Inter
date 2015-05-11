<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.Master" AutoEventWireup="true" CodeBehind="solicitacoes.aspx.cs" Inherits="paginas_Admin_solicitacoes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">
    <!--
        TABELA DE CORES DO HEADER
        
        * Não aberto: Vermelho Fatec (#960d10)
        * Aberto, em andamento: Azul (#2196F3)
        * Encerrado, não favorável: Amarelo(#FFEB3B)
        * Encerrado, favorável: Verde (#4CAF50)
        -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone2').addClass('corIcone');
        });
    </script>
    <!--Início do modal de Msg-->
    <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <!--A cor do Header muda de acordo com o status-->
                <div class="modal-header" style="background-color: #960d10; color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);">
                    <!--Arrumar o hover aqui-->
                    <button type="button" data-dismiss="modal" style="margin-top: -9px; float: left; border: none; background: none;"><span class="mdi mdi-chevron-left hoverAll" style="font-size: 33px; margin-top: 4.5px;"></span></button>
                    <!--ASSUNTO DO TICKET<h4 class="modal-title" id="myModalLabel1" style="float: left;">--ASSUNtO_DO_TICKET_AQUI--</h4>-->
                    <!--Arrumar  Hover aqui-->
                    <button type="button" id="butMostraMenu" name="subMenu" onclick="mostraDiv1('subMenu')" style="float: right; border: none; background: none; margin-top: -2px;"><span class="mdi mdi-dots-vertical hoverAll" style="font-size: 25px;"></span></button>
                    <!--NOME DO PROFESSOR QUE ABRIU O TICKET<h4 style="float: right; margin-top: 0; padding-right: 10px;">--NOME_DO_PROFESSOR_AQUI--</h4>-->
                </div>
                <!--Início 3-dot menu-->
                <!--Início do submenu-->
                <div class="subMenu" id="subMenu">
                    <!--Clicar em um item fecha o menu | ESC fecha o menu sem fechar a modal-->
                    <div onclick="butAcao()">Finalizar Favorável</div>
                    <div onclick="butAcao()">Finalizar Desfavorável</div>
                    <div onclick="butAcao()">PI Finalizado</div>
                    <!--O ícone de prioridade sera definido com base na opção de prioridade escolhida-->
                    <div onclick="toggleDiv('subMenuPrioridade')">Prioridade<span class="mdi mdi-alert" style="float: right; color: yellow; font-size: 20px"></span></div>
                </div>
                <!--Fim do submenu-->
                <!--Início do submenu de prioridade-->
                <!--Animação de deslizar para abrir e fechar o menu | prioridade que esta escolhida como padrão deve aparecer como desabilitada na hora da escolha-->
                <div id="subMenuPrioridade" class="subMenuPrioridade" style="display: none">
                    <div>Prioridade</div>
                    <div onclick="butAcao()">Normal<span class="mdi mdi-alert" style="float: right; color: green; font-size: 20px"></span></div>
                    <div onclick="butAcao()">Média<span class="mdi mdi-alert" style="float: right; color: yellow; font-size: 20px"></span></div>
                    <div onclick="butAcao()">Alta<span class="mdi mdi-alert" style="float: right; color: red; font-size: 20px"></span></div>
                </div>
                <!--Fim do submenu de prioridade-->
                <!--Fim 3-dot menu-->
                <!--Início do Corpo-->
                <div class="modal-body" style="background-color: whitesmoke;">
                    <div class="insideBox">
                        <!--Mensagem
                            Cada mensagem do banco deve ter seu bloco de mensagem.
                            As mensagens do usuario sempre aparecem à direita e a dos outros à esquerda
                        <div class="allMsg" style="float: left">
                            <div class="txtCard" onclick="mostraInfo(1)">--MSG_AQUI--.</div>
                            <div id="info1" class="infoMsg">Enviado por Jusjiscreudo - As 20:72</div>
                        </div>-->
                    </div>
                </div>
                <!--Fim do corpo-->
                <div class="modal-footer" style="text-align: left; background-color: whitesmoke; border-top: none">
                    <asp:TextBox runat="server" ID="txtResponder" TextMode="MultiLine" CssClass="minimalScrollbar"></asp:TextBox>
                    <!--Colocar hoover aqui-->
                    <div style="float: right; width: 50px; text-align: center; height: 50px; border-radius: 100px; background-color: #960D10; box-shadow: 0 2px 5px 3px rgba(0, 0, 0, 0.16);"><span class="mdi mdi-send" style="color: #fff; padding-top: 7px; padding-left: 5px; font-size: 35px;"></span></div>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do modal de Msg-->
    <!--Início do modal de novo ticket-->
    <div class="modal fade" data-backdrop="static" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 30%;">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #960d10; color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);">
                    <!--Arrumar o hover aqui-->
                    <button type="button" data-dismiss="modal" style="margin-top: -9px; float: left; border: none; background: none;"><span class="mdi mdi-chevron-left hoverAll" style="font-size: 33px; margin-top: 4.5px;"></span></button>
                    <h4 class="modal-title" id="myModalLabel1" style="float: left;">Novo Ticket</h4>
                </div>
                <!--Início do Corpo-->
                <div class="modal-body" style="background-color: whitesmoke; padding-top: 100px;">
                    <select id="dropDownListTipoTicket" runat="server" style="border-top: none; border-left: none; border-right: none; border-bottom-color: #2196f3; border-bottom-width: 2px; height: 30px; background-color: whitesmoke;">
                        <option disabled="disabled" selected="selected" value="Tipo"></option>
                        <option value="Alteração de nota" style="background-color: whitesmoke"></option>
                        <option value="Problema com cadastro" style="background-color: whitesmoke"></option>
                        <option value="Problema com avaliações" style="background-color: whitesmoke"></option>
                        <option value="Sugestão" style="background-color: whitesmoke"></option>
                        <option value="Outros" style="background-color: whitesmoke"></option>
                    </select>
                    <input autofocus="autofocus" type="text" id="newMsgSubject" runat="server" placeholder="Assunto" style="border-top: none; border-left: none; border-right: none; border-bottom-color: #2196f3; background-color: whitesmoke; height: 30px;" />
                </div>
                <!--Fim do corpo-->
                <div class="modal-footer" style="text-align: left; background-color: whitesmoke; border-top: none">
                    <button type="button" data-dismiss="modal" data-toggle='modal' data-target='#myModal1' style="float: right; float: right; height: 30px; width: 90px; box-shadow: 0 1px 5px 0px rgba(0, 0, 0, 0.26); color: white; background-color: #2196F3; border: none;">
                        Confirmar</button>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do modal de novo Ticket-->
    <!--Início das Tabs-->
    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Tickets</h3>
            </div>
            <div class="panel-body">
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#geral" role="tab" data-toggle="tab">Aberto</a></li>
                    <li><a href="#andamento" role="tab" data-toggle="tab">Em Andamento</a></li>
                    <li><a href="#finalizado" role="tab" data-toggle="tab">Finalizado</a></li>
                    <!--Placeholder, isso vai no usuário--><li><a data-toggle='modal' data-target='#myModal2'>Novo Ticket</a></li>
                </ul>
                <div class="tab-content">
                    <!-- TICKETS EM ABERTO -->
                    <div role="tabpanel" class="tab-pane fade in active" id="geral">
                        <div class="panel-body">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <td>Assunto</td>
                                        <td>Tipo</td>
                                        <td>Usuário</td>
                                        <td>Data</td>
                                        <td>Prioridade</td>
                                    </tr>
                                </thead>
                                <!--Constroi os tickets que estao no banco de dados<tr>
                                    <td><a href="#" data-toggle='modal' data-target='#myModal1'>Mudança de nota no Projeto [Nome]</a></td>
                                    <td>Fulano Ciclano</td>
                                    <td>12/08/14</td>
                                </tr>-->
                            </table>
                            <ul class="pager">
                                <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                                <li class="next disabled"><a href="#">Próximo &rarr;</a></li>
                            </ul>
                        </div>
                    </div>
                    <!-- TICKETS EM ANDAMENTO -->
                    <div role="tabpanel" class="tab-pane fade in" id="andamento">
                        <div class="panel-body">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <td>Assunto</td>
                                        <td>Tipo</td>
                                        <td>Usuário</td>
                                        <td>Data</td>
                                        <td>Prioridade</td>
                                    </tr>
                                </thead>
                                <tr>
                                    <td><a href="#"></a></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                            <ul class="pager">
                                <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                                <li class="next disabled"><a href="#">Próximo &rarr;</a></li>
                            </ul>
                        </div>
                    </div>
                    <!-- TICKETS FINALIZADOS -->
                    <div role="tabpanel" class="tab-pane fade in" id="finalizado">
                        <div class="panel-body">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <td>Assunto</td>
                                        <td>Tipo</td>
                                        <td>Usuário</td>
                                        <td>Data</td>
                                        <td>Prioridade</td>
                                    </tr>
                                </thead>
                                <tr>
                                    <td><a href="#"></a></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                            <ul class="pager">
                                <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                                <li class="next disabled"><a href="#">Próximo &rarr;</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Fim das tabs-->
</asp:Content>
