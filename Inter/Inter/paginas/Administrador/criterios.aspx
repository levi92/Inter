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
                        <asp:GridView ID="gdv" runat="server" CellPadding="4" GridLines="None" CssClass="gridView"
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="false"
                            OnRowDataBound="gdv_RowDataBound"
                            onRowEditing="gdv_RowEditing">

                            <AlternatingRowStyle CssClass="alt" />

                            <%-- Configurar colunas do Grid --%>
                            <Columns>

                              <%--<asp:TemplateField>
                                  <asp:ItemTemplate>

                                  </asp:ItemTemplate>
                              </asp:TemplateField>--%>



                                <asp:BoundField DataField="cge_nome" HeaderText="Nome do Critério" />
                                <asp:BoundField DataField="cge_descricao" HeaderText="Descrição" />
                                

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
