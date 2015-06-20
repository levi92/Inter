<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.Master" AutoEventWireup="true" CodeBehind="configuracoes.aspx.cs" Inherits="paginas_Admin_configuracoes" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript" src="../../scripts/bootstrap.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone2').addClass('corIcone');
        });
    </script>

    <script type="text/javascript">
        function openModal() {
            $('#myModal1').modal('show');
        }
    </script>

    
    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Configurações</h3>
            </div>
            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#backup" role="tab" data-toggle="tab">Backup</a></li>
                </ul>
                <div class="tab-content">


                    <asp:UpdatePanel ID="UpdatePanelBkp" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblBackup" runat="server"></asp:Label>
                            <asp:GridView ID="gdvBkp" runat="server" CellPadding="4" GridLines="None" CssClass="gridView" AllowPaging="true" PageSize="10"
                                OnRowCommand="gdvBkp_RowCommand"
                                OnRowDataBound="gdvBkp_RowDataBound"
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
                            <asp:Button ID="btnCriarBackup" runat="server" CssClass="btn btn-default btn-lg" Text="Criar Backup" OnClick="btnCriarBackup_Click" />


                        </ContentTemplate>

                    </asp:UpdatePanel>

                    <br />




                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanelModalNovoCriterio" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" id="fecharModal" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                    <h4 class="modal-title" id="myModalLabel3">Cadastrar Critérios</h4>
                                </div>
                                <br />

                                <div class="form-group">
                                    <div class="controls-row">
                                        <asp:Label ID="lblNomeNovoCriterio" runat="server" CssClass="control-label col-sm-2" Text="Nome: "></asp:Label>

                                        <asp:TextBox ID="txtNomeNovoCriterio" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server" MaxLength="50"></asp:TextBox>
                                        <%--Validação do Campo Nome (Verifica se está vazio e se está preenchido com uma string)--%>
                                    &nbsp<asp:RequiredFieldValidator ID="rfvNomeNovoCriterio" runat="server" CssClass="col-sm1" ErrorMessage="O campo Nome deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtNomeNovoCriterio" ValidationGroup="NovoCriterio"></asp:RequiredFieldValidator>


                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="controls-row">
                                        <asp:Label ID="lblDescricaoNovoCriterio" runat="server" CssClass="control-label col-sm-2" Text="Descrição: "></asp:Label></td>

                                        <asp:TextBox ID="txtDescricaoNovoCriterio" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server" MaxLength="200"></asp:TextBox></td>

                                        <%--Validação do Campo Descrição (Verifica se está vazio e se está preenchido com uma string)--%>
                                                 &nbsp<asp:RequiredFieldValidator ID="rfvDescricaoNovoCriterio" CssClass="col-sm1" runat="server" ErrorMessage="O campo Descrição deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtDescricaoNovoCriterio" ControlToCompare="txtNomeNovoCriterio" ValidationGroup="NovoCriterio"></asp:RequiredFieldValidator>
                                    </div>
                                    <br />
                                    <asp:Label ID="lblMsg" ClientIDMode="Static" CssClass="col-sm-12" runat="server" Text="" Style="font-size: 18px; padding-left: 30px;"></asp:Label>
                                </div>


                                <asp:ValidationSummary ID="vsNovoCriterio" ValidationGroup="NovoCriterio" ForeColor="#960d10" runat="server" DisplayMode="List" Style="margin: 7px; padding: 7px;" />




                                <div class="modal-footer">
                                    <asp:LinkButton type="button" class="btn btn-default" ID="btnCancelarNovoCriterio" runat="server" title="Cancelar Inserção" OnClick="btnCancelarNovoCriterio_Click">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                                    <asp:LinkButton ID="btnCriarNovoCriterio" runat="server" CssClass="btn btn-default"
                                        OnClick="btnCriarNovoCriterio_Click" ToolTip="Confirmar Inserção" CausesValidation="true" ValidationGroup="NovoCriterio">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                                </div>

                            </div>
                        </div>

                    </div>
                </ContentTemplate>



            </asp:UpdatePanel>



        </div>
    </div>




</asp:Content>
