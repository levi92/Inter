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
                        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanelBkp" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                 
                                <asp:GridView ID="gdvBkp" runat="server" CellPadding="4" GridLines="None" CssClass="gridView" AllowPaging="true" PageSize="10"
                                    OnRowCommand="gdvBkp_RowCommand"
                                    OnRowDataBound="gdvBkp_RowDataBound"
                                    OnPageIndexChanging="gdvBkp_PageIndexChanging"
                                    AutoGenerateColumns="true"
                                    Visible="true">

                                    <AlternatingRowStyle CssClass="alt" />

                                    <Columns>
                                        <%-- Configurar colunas do Grid --%>
                                    </Columns>
                                    

                                </asp:GridView>
                                <asp:Button ID="btnCriarBackup" runat="server" CssClass="btn btn-default btn-lg" Text="Criar Backup" OnClick="btnCriarBackup_Click" />
                            </ContentTemplate>

                        </asp:UpdatePanel>
                        <br />
                        
                        
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
