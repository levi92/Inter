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
                            <asp:Label ID="Label11" CssClass="label" runat="server" Text="Pesquisar:"></asp:Label>
                        </td>

                        <td colspan="2">
                            <asp:TextBox ID="TextBox1" CssClass="textPesquisa" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp Nome" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox3" runat="server" Text="&nbsp Disciplina" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox4" runat="server" Text="&nbsp  Ano" />
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox5" runat="server" Text="&nbsp Semestre" />
                        </td>
                        <td>

                            <button type="button" class="btn btn-default" id="btnPesquisar">
                                <span class="glyphicon glyphicon-search"></span>&nbsp Pesquisar</button>
                        </td>
                    </tr>
                </table>

                <hr />


                <table class="table">
                    <thead>
                        <tr>
                            <td>Projeto</td>
                            <td>Data de finaização</td>
                            <td>Disciplina</td>
                            <td>Semestre</td>
                            <td>Solicitar alteração</td>
                        </tr>
                    </thead>
                    <tr>
                        <td><a href="#">Sistema Inter_Sistema SAM</a></td>
                        <td>02/12/2014</td>
                        <td>IHC</td>
                        <td>4</td>
                        <td><span style="color: #428bca" class="glyphicon glyphicon-share-alt"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Sistema Aluno Online</a></td>
                        <td>18/05/2014</td>
                        <td>Gestão de equipes</td>
                        <td>6</td>
                        <td><span style="color: #d7d5d5" class="glyphicon glyphicon-share-alt"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Sistema Viva no Azul</a></td>
                        <td>27/11/2014</td>
                        <td>Programação Web</td>
                        <td>5</td>
                        <td><span style="color: #428bca" class="glyphicon glyphicon-share-alt"></span></td>
                    </tr>

                </table>

            </div>
        </div>
    </div>

</asp:Content>

