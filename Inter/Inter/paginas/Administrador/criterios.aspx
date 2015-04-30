<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuAlterarPerfil.Master" AutoEventWireup="true" CodeBehind="criterios.aspx.cs" Inherits="paginas_Admin_criterios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone3').addClass('corIcone');
        });
    </script>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Critérios</h3>
            </div>
            <div class="panel-body">

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gdvCriterios" runat="server" CssClass="gridView" DataKeyNames="cge_codigo"
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="false"
                            OnRowUpdating="gdvCriterios_RowUpdating"
                            OnRowEditing="gdvCriterios_RowEditing"
                            OnRowCancelingEdit="gdvCriterios_RowCancelingEdit"
                            OnRowDeleting="gdvCriterios_RowDeleting">


                            <AlternatingRowStyle CssClass="alt" />

                            <%-- Configurar colunas do Grid (Cada TemplateField é uma coluna) --%>
                            <Columns>

                                <%--Coluna do Código do Critério Geral--%>
                                <asp:TemplateField HeaderText="Código" Visible="false">                                
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval ("cge_codigo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--Coluna do nome do Critério Geral--%>
                                <asp:TemplateField HeaderText="Nome do Critério">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNome" runat="server" Text='<%#Eval ("cge_nome")%>'> </asp:TextBox> <%--Essa textbox existe para quando for editar aparecer o nome do critério--%>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("cge_nome")%>'></asp:Label> 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                  <%--Coluna da descrição do Critério Geral--%>
                                <asp:TemplateField HeaderText="Descrição">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>' Width="100%"> </asp:TextBox> <%--Essa textbox existe para quando for editar aparecer a descrição do critério(O width = 100% deixa a caixa no tamanho máximo até a coluna seguinte--%>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--Coluna do botão de Editar (o lápis) --%>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="15px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkbEditar" CssClass="glyphicon glyphicon-pencil" title="Editar" runat="server" CommandName="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lkbAtualizar" CssClass="icon-checkmark" title="Confirmar" CommandName="Update" runat="server"></asp:LinkButton> <%--Essa linha e a debaixo são os botões que aparecem quando se clica no botão Editar de cima--%>
                                        <asp:LinkButton ID="lkbCancelar" CssClass="icon-blocked" title="Cancelar" CommandName="Cancel" runat="server"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <%--Coluna do botão de desativar --%>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="15px">
                                    <ItemTemplate>
                                        <span onclick="return confirm('Tem certeza que deseja desativar este critério?')">
                                            <asp:LinkButton ID="lkbExcluir" CssClass="glyphicon glyphicon-remove" Title="Desativar" runat="server" CommandName="Delete"></asp:LinkButton>
                                        </span>
                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--Fim do Grid--%>  

                <%-- Label com quantidade de registros --%>
                <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <br />

                <%--Botão de novo critério--%>
                <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#myModalCadastrarCri" title="Ir para cadastro de critérios">
                    <span class="glyphicon glyphicon-plus"></span>&nbsp Novo Critério
                </button>
            </div>

        </div>

    </div>



      <!-- Modal Cadastrar Critérios -->
    <div class="modal fade" data-backdrop="static" id="myModalCadastrarCri" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel3">Cadastrar Critérios</h4>
                </div>
                <div class="modal-body">
                    <table style="width: 70%; margin-left: 5%;">
                        <tr style="text-align: left;">
                            <td>
                                <asp:Label ID="lblNomeNovoCriterio" runat="server" CssClass="label" Text="Nome Critério: " ></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtNomeNovoCriterio" CssClass="textCriterio" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                            </td>
                        </tr>
                        <tr style="text-align: left;">
                            <td>
                                <asp:Label ID="lblDescricaoNovoCriterio" runat="server" CssClass="label" Text="Descrição do Critério: "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDescricaoNovoCriterio" CssClass="textCriterio" runat="server"></asp:TextBox></td>

                        </tr>

                    </table>
                </div>
               
                 <asp:UpdatePanel ID="updPanelNovoCri" runat="server">
                    <ContentTemplate>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Cancelar Inserção">
                                <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>                      

                            <asp:LinkButton ID="btnCriarNovoCriterio" runat="server" CssClass="btn btn-default"
                                OnClick="btnCriarNovoCriterio_Click" ToolTip="Confirmar Inserção">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

</asp:Content>
