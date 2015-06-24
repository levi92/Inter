<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.Master" AutoEventWireup="true" CodeBehind="configuracoes.aspx.cs" Inherits="paginas_Admin_configuracoes" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript" src="../../scripts/bootstrap.js"></script>
    <script type="text/javascript">
        //ESSA FUNÇÃO ABAIXO DESTACA A PÁGINA CONFIGURACOES NO MENU AO LADO
        $(document).ready(function () {
            $('#icone6').addClass('corIcone');
        });
        //ESSA FUNÇÃO ABAIXO ABRE A MODAL DE CONFIRMAR A SENHA
        function openModal() {
            $('#myModal1').modal('show');
        }

        //ESSA FUNÇÃO ABAIXO QUE FECHA A MODAL DE CONFIRMAR A SENHA
        function fechaModalClick() { 
            $('#fecharModal').click();
        }

        function mudaTituloDownload() {
            $('#TituloModal').text('Baixar Backup');
        }

        function mudaTituloRestaurar() {
            $('#TituloModal').text('Restaurar Backup');
        }

    </script>



    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Configurações</h3>
            </div>
            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Timer runat="server" id="timerDownload" Enabled="false" Interval="4000" OnTick="timerDownload_Tick"></asp:Timer> <%--CONTADOR USADO PARA O DOWNLOAD DO BACKUP--%>
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#backup" role="tab" data-toggle="tab">Backup</a></li>
                </ul>
                <div class="tab-content">

                    <asp:UpdatePanel ID="UpdatePanelBkp" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblBackup" runat="server"></asp:Label>
                            <asp:GridView ID="gdvBkp" runat="server" CellPadding="4" GridLines="None" CssClass="gridView" AllowPaging="true" PageSize="10"
                                OnRowCommand="gdvBkp_RowCommand"
                                OnPageIndexChanging="gdvBkp_PageIndexChanging"
                                AutoGenerateColumns="false"
                                Visible="true">

                                <AlternatingRowStyle CssClass="alt" />
                                
                                <Columns>
                                    <%-- Configurar colunas do Grid --%>

                                    <asp:BoundField DataField="!" HeaderText="Nome" />

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbDownload" CssClass="glyphicon glyphicon-download" Font-Size="1.5em" runat="server" CommandName="bkpDownload"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkbRestaurar" CssClass="glyphicon glyphicon-open" Font-Size="1.5em" runat="server" CommandName="bkpRestaurar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>


                            </asp:GridView>

                            <asp:Label ID="lblQtdRegistros" runat="server"></asp:Label><br />
                            <br />
                            <asp:Button ID="btnCriarBackup" runat="server" CssClass="btn btn-default btn-lg" Text="Criar Backup" OnClick="btnCriarBackup_Click" />


                        </ContentTemplate>

                    </asp:UpdatePanel>

                    <br />




                </div>
            </div>

            <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                <asp:UpdatePanel ID="UpdatePanelModalNovoCriterio" UpdateMode="Conditional" runat="server">
                    
                    <ContentTemplate>
                        
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" id="fecharModal" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                    <h4 class="modal-title" id="TituloModal">Confirmação de Senha</h4>
                                </div>
                                <br />

                                <div class="form-group">
                                    <div class="controls-row">
                                        <asp:Label ID="lblSenha" runat="server" Width="400px" CssClass="control-label col-sm-2" Text="Confirme a senha do administrador:"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtSenha" class="form-control" placeholder="Senha" Style="width: 250px; margin-left: 15px" runat="server" TextMode="Password" MaxLength="63"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="controls-row">
                                    </div>
                                    <br />
                                    <asp:Label ID="lblMsgModal" ClientIDMode="Static" CssClass="col-sm-12" runat="server" Text="" Style="font-size: 18px; padding-left: 30px;"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblMsgModal2" ClientIDMode="Static" CssClass="col-sm-12" runat="server" Text="" Style="font-size: 18px; padding-left: 30px;"></asp:Label>
                                </div>

                                <div class="modal-footer">
                                    <asp:LinkButton type="button" class="btn btn-default" ID="btnCancelarConfirmaSenha" runat="server" title="Cancelar Inserção" OnClick="btnCancelarConfirmaSenha_Click">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                                    <asp:LinkButton ID="lkbConfirmaSenha" runat="server" CssClass="btn btn-default" ClientIDMode="Static"
                                        OnClick="lkbConfirmaSenha_Click" OnClickToolTip="Confirmar">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                                </div>

                            </div>
                        </div>
                    </ContentTemplate>


                </asp:UpdatePanel>
            </div>




        </div>
    </div>




</asp:Content>
