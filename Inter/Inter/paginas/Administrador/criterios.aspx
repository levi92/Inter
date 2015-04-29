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
                        <asp:GridView ID="gdvCriterios" runat="server" GridLines="None" CssClass="gridView" DataKeyNames="cge_codigo"
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="false"
                            OnRowUpdating="gdvCriterios_RowUpdating"
                            OnRowEditing="gdvCriterios_RowEditing"
                            OnRowCancelingEdit="gdvCriterios_RowCancelingEdit">


                            <AlternatingRowStyle CssClass="alt" />

                            <%-- Configurar colunas do Grid --%>
                            <Columns>

                                <asp:TemplateField HeaderText="Nome do Critério" >
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNome" runat="server" Text='<%#Eval ("cge_nome")%>'> </asp:TextBox>
                                    </EditItemTemplate>
                                    <asp:ItemTemplate>
                                        <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("cge_nome")%>'></asp:Label>
                                    </asp:ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Descrição">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'> </asp:TextBox>
                                    </EditItemTemplate>
                                    <asp:ItemTemplate>
                                        <asp:Label ID="lblDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'></asp:Label>
                                    </asp:ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Editar/Desativar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkbEditar" cssClass="glyphicon glyphicon-pencil" runat="server" CommandName="Edit"></asp:LinkButton>

                                        <span onclick="return confirm('Deseja realmente desativar este registro?')">
                                            <asp:LinkButton ID="lkbExcluir"  cssClass="glyphicon glyphicon-remove" runat="server" CommandName="Delete"></asp:LinkButton>
                                        </span>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lkbAtualizar"  cssClass="icon-checkmark"  Text="" CommandName="Update" runat="server"></asp:LinkButton>
                                        <asp:LinkButton ID="lkbCancelar" cssClass="icon-blocked" AlternateText="Cancelar" CommandName="Cancel" runat="server"></asp:LinkButton>
                                    </EditItemTemplate>
                               </asp:TemplateField>

                            </Columns>

                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                  
                <%-- Label com quantidade de registros --%>
                <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>
                <br />
                <br />

            </div>

        </div>
        
    </div>


</asp:Content>
