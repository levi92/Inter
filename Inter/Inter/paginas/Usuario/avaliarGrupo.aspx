<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_avaliarGrupo" CodeBehind="avaliarGrupo.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- ALTERAR COR DO ÍCONE NO MENU LATERAL -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone8').addClass('corIcone');

            //$('[data-toggle="tooltip"]').tooltip();
        });
     
        //FUNÇÃO ZEBRADO NO GRIDVIEW AVALIAR GRUPOS
        function ZebradoGridAvaliar() {
            var countRow = $("#tableAvaliar tr").length - 1;
            for (var i = 0; i < countRow; i++) {
                if (i % 2 != 0) {
                    $("#cphConteudo_cphConteudoCentral_" + i).css("background-color", "rgba(206, 206, 206, 0.31)");
                }
            }
        }

        //CHAMAR MODAL COM MENSAGEM DE NÃO POSSUI GRUPOS PARA AVALIAR
        function msgNaoPossuiGrupos() {
            $("#naoPossuiGrupo").click();
        }
        
        Sys.Application.add_load(BindEvents);
        function BindEvents() {
            $('[data-toggle=tooltip]').tooltip();
            // other bootstrap binding code - see the combined Bootstrap.js for ideas
        }


    </script>
    <button type="button" style="display: none;" id="naoPossuiGrupo" data-toggle="modal" data-target="#myModalNaoPossuiGrupo"></button>
     <asp:UpdateProgress ID="upgAvaliar" runat="server" AssociatedUpdatePanelID="updAvaliar">
        <ProgressTemplate>
            <div class="modalLoader">
                <div class="modalCenter">
                    <img alt="Carregando" src="../../App_Themes/images/ajax-loader.gif" /><br />                    
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Avaliar Grupos (p8) -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Avaliar Grupo</h3>
            </div>
            <div class="panel-body">
                <!-- Abas Superior Inicio !----------->
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#avaliacao" role="tab" data-toggle="tab">Avaliação</a></li>
                    <li><a href="#anotacoes" role="tab" data-toggle="tab">Anotações</a></li>
                </ul>
                <!-- Abas Superior Fim !-------------->

                <!-- Conteudo Aba Avaliacao !-->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="avaliacao">
                        <asp:UpdatePanel ID="updAvaliar" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>

                                <table class="tabelaAvaliar">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGrupo" runat="server" Text="Grupo: "></asp:Label>
                                        </td>
                                        <td colspan="4">
                                            <asp:DropDownList ID="ddlGrupos" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged" AutoPostBack="true" CssClass="dropDown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>

                                <asp:Panel ID="panelAvaliar" ClientIDMode="Static" runat="server"></asp:Panel>

                                <table id="tabelaBotoesAvaliar">
                                    <tr>
                                        <td>
                                            <button type="button" class="btn btn-default" id="" disabled="disabled">
                                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar</button></td>

                                        <td>
                                            <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-default" ToolTip="Salvar a avaliação">
                                        <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp Salvar
                                            </asp:LinkButton></td>

                                        <td>
                                            <asp:LinkButton ID="btnFinalizar" OnClick="btnFinalizar_Click" runat="server" CssClass="btn btn-default" ToolTip="Finalizar a avaliação">
                                        <span class="glyphicon glyphicon-ok-circle"></span>&nbsp Finalizar
                                            </asp:LinkButton>

                                        </td>                                        

                                        <td>
                                            <button type="button" class="btn btn-default" id="btnImprimirAvaliacao" onclick="ImprimirGrupo('panelAvaliar');" title="Imprimir a tabela de atribuição de notas acima">
                                                <span class="glyphicon glyphicon-print"></span>&nbsp Imprimir</button>  
                                                                                      
                                        </td>
                                    </tr>

                                </table>

                                <asp:HiddenField ID="valorPeso" runat="server" ClientIDMode="Static" />

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>

                    <!-- Fim Conteudo Aba Avaliacao !-->

                    <!-- Conteudo Aba Anotações!-->

                    <div role="tabpanel" class="tab-pane fade" id="anotacoes">

                        <asp:TextBox ID="txtAnotacao" CssClass="txtAnotacao" placeholder="Faça aqui suas anotações" TextMode="MultiLine" runat="server"></asp:TextBox>

                    </div>
                    <!-- Fim Conteudo Aba Anotações !-->

                </div>
                <!-- Fim Conteudo Aba Avaliacao !-->
            </div>
        </div>
    </div>

    <!-- MODAL NÃO POSSUI GRUPO PARA AVALIAR -->

    <div class="modal fade" data-backdrop="static" id="myModalNaoPossuiGrupo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                        <span style="color: #960d10;" class="glyphicon glyphicon-remove"></span>&nbsp Sua matéria ainda não possui grupos para avaliar!</h1>
                </div>

                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnVoltarHome2" runat="server" OnClick="btnVoltarHome2_Click" ToolTip="Voltar para a home do sistema">
                        <span class="glyphicon glyphicon-home"></span>&nbsp Voltar para a home</asp:LinkButton>                    
                </div>
            </div>
        </div>
    </div>

</asp:Content>

