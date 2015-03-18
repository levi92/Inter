<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage.Master" AutoEventWireup="true" CodeBehind="solicitacoes.aspx.cs" Inherits="Inter.paginas.Administrador.solicitacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone2').addClass('corIcone');
        });
    </script>

    <div class="container">
        <div id="conteudo">

            <div id="p1" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Solicitações</h3>
                    </div>
                    <div class="panel-body">
                        <table class="table">
                            <thead>
                                <tr>
                                    <td>Assunto</td>
                                    <td>Usuário</td>
                                    <td>Data</td>
                                    <td>Status</td>
                                </tr>
                            </thead>
                            <tr>
                                <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>12/08/14</td>
                                <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>10/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>05/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>12/08/14</td>
                                <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>10/08/14</td>
                                <td><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>05/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>12/08/14</td>
                                <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>10/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                                <td>Fulano Ciclano</td>
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
        </div>
    </div>


</asp:Content>
