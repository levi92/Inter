<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_piFinalizado" Codebehind="piFinalizado.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- ALTERAR COR DO ÍCONE NO MENU LATERAL -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone4').addClass('corIcone');
        });
    </script>

    <!-- PIS FINALIZADOS (P4) -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">PIs Finalizados</h3>
            </div>
            <div class="panel-body">
                <table class="table">

                    <tr>
                        <td>
                            <asp:Label ID="lblPesquisar" CssClass="label" runat="server" Text="Pesquisar:"></asp:Label>
                        </td>

                        <td colspan="2">
                            <asp:TextBox ID="txtPesquisar" CssClass="textPesquisa" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:DropDownList ID="ddlCursos" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDisciplinas" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAno" runat="server">
                                
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSemestre" runat="server"></asp:DropDownList>
                        </td>
                        <td>
<%--
                            <button type="button" class="btn btn-default" id="btnPesquisar">
                                <span class="glyphicon glyphicon-search"></span>&nbsp Pesquisar</button>--%>
                            <asp:LinkButton ID="lbPesquisar" runat="server" CssClass="btn btn-default" OnClick="lbPesquisar_Click">
                                 <span class="glyphicon glyphicon-search"></span>&nbsp Pesquisar
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>

                <hr />

                <asp:Panel ID="PanelPIsFinalizados" runat="server"></asp:Panel>
                

            </div>
        </div>
    </div>

</asp:Content>

