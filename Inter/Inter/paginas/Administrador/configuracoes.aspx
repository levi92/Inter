<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.Master" AutoEventWireup="true" CodeBehind="configuracoes.aspx.cs" Inherits="paginas_Admin_configuracoes" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone6').addClass('corIcone');
        });
    </script>


    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Configurações</h3>
            </div>
            <div class="panel-body">
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#geral" role="tab" data-toggle="tab">Geral</a></li>
                    <li><a href="#backup" role="tab" data-toggle="tab">Backup</a></li>
                </ul>
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="geral">
                        <br />
                        <strong>URL para Importar Dados Semestrais</strong>
                        <form class="form-inline" role="form">
                            <div class="form-group" style="margin-top: 10px;">
                                <div class="input-group">
                                    <label for="txtEndereco" class="sr-only">URL do Banco</label>
                                    <div class="input-group-addon"><a href="#" title="Sincronizar Dados"><span class="glyphicon glyphicon-retweet"></span></a></div>
                                    <input id="txtEndereco" runat="server" type="url" value="http://localhost:17758/DB" class="form-control" />

                                </div>
                            </div>
                        </form>
                        <%-- <button type="button" class="btn btn-default" name="SincronizarDados" title="Sincronizar Dados">Sincronizar Dados</button>--%>
                        <hr />
                        <button type="button" class="btn btn-default" id="btAdmTrocarSenha" data-toggle="modal" data-target="#alterarSenhaAdm" runat="server" name="alterarSenhaAdm" title="Alterar Senha">Alterar Senha</button><br />
                        <br />


                    </div>

                    <div role="tabpanel" class="tab-pane fade" id="backup">
                        <table class="table">
                            <tr>
                                <td>Nome</td>
                                <td>Data Envio</td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>inter_bkp_00-00-00-00-00-05</td>
                                <td>22-11-2014</td>
                                <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>

                            </tr>
                            <tr>
                                <td>inter_bkp_00-00-00-00-00-04</td>
                                <td>21-11-2014</td>
                                <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>

                            </tr>
                            <tr>
                                <td>inter_bkp_00-00-00-00-00-03</td>
                                <td>20-11-2014</td>
                                <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>

                            </tr>
                            <tr>
                                <td>inter_bkp_00-00-00-00-00-02</td>
                                <td>19-11-2014</td>
                                <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>

                            </tr>
                            <tr>
                                <td>inter_bkp_00-00-00-00-00-01</td>
                                <td>18-11-2014</td>
                                <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>

                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnCriarBackup" runat="server" CssClass="btn btn-default btn-lg" Text="Criar Backup" OnClick="btnCriarBackup_Click" />
                        
                        <button type="button" class="btn btn-default btn-lg" title="Enviar Backup do Computador">
                            <span class="glyphicon glyphicon-upload"></span>&nbsp Enviar Backup...
                        </button>

                        <asp:Label ID="lblBackup" runat="server"></asp:Label>


                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
