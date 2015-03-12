<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPage.master" AutoEventWireup="true" Inherits="paginas_Usuario_notificacoes" Codebehind="notificacoes.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Alterar cor do ícone no menu lateral -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone3').addClass('corIcone');
        });
    </script>

    <!-- NOTIFICAÇÕES (P3) -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Notificações</h3>
            </div>
            <div class="panel-body">
                <button type="button" class="btn btn-default" id="btnNovo" data-toggle="modal" data-target="#myModalEnviarSolicita" title="Aqui você pode criar uma Nova solicitação">
                    <span style="color: gray;" class="glyphicon glyphicon-file"></span>&nbsp Novo
                </button>
                <br />
                <br />

                <table class="table">
                    <thead>
                        <tr>
                            <td>Assunto</td>
                            <td>Data</td>
                            <td>Status</td>
                        </tr>
                    </thead>
                    <tr>
                        <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                        <td>12/08/14</td>
                        <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                        <td>10/08/14</td>
                        <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                        <td>05/08/14</td>
                        <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>

                        <td>12/08/14</td>
                        <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>

                        <td>10/08/14</td>
                        <td><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>

                        <td>05/08/14</td>
                        <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>

                        <td>12/08/14</td>
                        <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>

                        <td>10/08/14</td>
                        <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                    </tr>
                    <tr>
                        <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>

                        <td>05/08/14</td>
                        <td><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></td>
                    </tr>

                </table>
                <ul class="pager">
                    <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                    <li class="next"><a href="#">Próximo &rarr;</a></li>
                </ul>

                <span class="glyphicon glyphicon-ok" style="color: #09a01c"></span>&nbsp- Aceita
                            <br />
                <span class="glyphicon glyphicon-remove" style="color: #960d10"></span>&nbsp- Recusada
                            <br />
                <span class="glyphicon glyphicon-refresh" style="color: #428bca"></span>&nbsp- Em andamento
            </div>
        </div>
    </div>


    <!-- Modal enviar solicitação -->
        <div class="modal fade" data-backdrop="static" id="myModalEnviarSolicita" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel4">Enviar solicitação</h4>
                    </div>
                    <div class="modal-body">
                        <table style="width: 70%; margin-left: 5%;">

                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="Label12" runat="server" Style="font-size: 16px; font-weight: bold;" Text="Tipo: "></asp:Label></td>
                                <td></td>
                            </tr>

                            <tr style="text-align: left;">
                                <td>
                                    <%--RepeatDirection="Horizontal"--%>
                                    <asp:RadioButtonList ID="rblTiposSolicita" runat="server" CssClass="radio">
                                        <asp:ListItem>Alteração de notas</asp:ListItem>
                                        <asp:ListItem>Problema com cadastros</asp:ListItem>
                                        <asp:ListItem>Problema com avaliações</asp:ListItem>
                                        <asp:ListItem>Sugestão</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td></td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label13" runat="server" Style="font-size: 16px; font-weight: bold; text-align: left;" Text="Assunto: "></asp:Label>
                                    <asp:TextBox ID="txtAssunto" runat="server"></asp:TextBox>
                                </td>


                            </tr>




                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>

                        </table>

                        <table style="width: 70%; margin-left: 5%;">
                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="Label14" runat="server" Style="font-size: 16px; font-weight: bold; text-align: left;" Text="Comentários: "></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="TextArea1" cols="60" rows="10" placeholder="Digite sua solicitação, problema ou sugestão."></textarea>

                                </td>
                            </tr>

                        </table>



                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Cancelar Inserção">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>

                        <button type="button" class="btn btn-default" id="btnEnviarSolicita" data-dismiss="modal" title="Confirmar Inserção">
                            <span class="glyphicon glyphicon-envelope"></span>&nbsp Enviar</button>


                    </div>



                </div>
            </div>
        </div>


</asp:Content>

