<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_avaliarGrupo" CodeBehind="avaliarGrupo.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- Alterar cor do ícone no menu lateral -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone8').addClass('corIcone');            
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

    </script>
    
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
                                            <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="dropDown">
                                                <asp:ListItem>Sistema de Avaliação de interdisciplinar-Usuário</asp:ListItem>
                                                <asp:ListItem>Sistema de Avaliação de interdisciplinar-Admin</asp:ListItem>
                                            </asp:DropDownList>

                                        </td>
                                    </tr>
                                </table>

                                <asp:Panel ID="panelAvaliar" runat="server"></asp:Panel>

                                <table class="tabelaAvaliar table">
                                    <tr>
                                        <td>
                                            <button type="button" class="btn btn-default" id="" disabled="disabled">
                                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar</button></td>

                                        <td>
                                            <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-default" ToolTip="Salvar a avaliação">
                                        <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp Salvar
                                            </asp:LinkButton></td>
                                        <td>
                                            <button type="button" class="btn btn-default" id="">
                                                <span class="glyphicon glyphicon-ok-circle"></span>&nbsp Finalizar</button></td>
                                        <td></td>

                                        <td>
                                            <button type="button" class="btn btn-default" id="btnImprimirAvaliacao" title="Imprimir a tabela de atribuição de notas acima">
                                                <span class="glyphicon glyphicon-print"></span>&nbsp Imprimir</button>
                                        </td>
                                    </tr>
                                    
                                </table>

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

    <asp:HiddenField ID="valorPeso" runat="server" ClientIDMode="Static" />

</asp:Content>

