<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_avaliarGrupo" CodeBehind="avaliarGrupo.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- Alterar cor do ícone no menu lateral -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone8').addClass('corIcone');
        });
    </script>


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
                        <table class="tabelaAvaliar table ">
                            <tr>
                                <td><asp:Label ID="lblGrupo" runat="server" Text="Grupo: "></asp:Label> </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="dropDown">
                                        <asp:ListItem>Sistema de Avaliação de interdisciplinar-Usuário</asp:ListItem>
                                        <asp:ListItem>Sistema de Avaliação de interdisciplinar-Admin</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            
                          
                        </table>

                        <asp:GridView ID="gdvAvaliarGrupo" runat="server" CellPadding="4" GridLines="None" CssClass="gridView"
                            AutoGenerateColumns="true">

                            <AlternatingRowStyle CssClass="alt" />
                            
                            
                        </asp:GridView>
                        
                        <table class="tabelaAvaliar table">
                            <tr>
                                <td>
                                    <button type="button" class="btn btn-default" id="" disabled="disabled">
                                        <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar</button></td>

                                <td>
                                    <button type="button" class="btn btn-default" id="">
                                        <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp Salvar</button></td>



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

</asp:Content>

