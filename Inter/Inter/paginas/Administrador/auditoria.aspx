<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.master" AutoEventWireup="true" CodeBehind="auditoria.aspx.cs" Inherits="paginas_Admin_auditoria" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone65').addClass('corIcone');
        });
    </script>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Auditoria</h3>
            </div>
            <div class="panel-body">
               

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <asp:UpdatePanel ID="UpdatePanelAuditoria" UpdateMode="Conditional" runat="server">

                            <ContentTemplate>
                                <asp:GridView ID="gdvAud" runat="server" CellPadding="4" GridLines="None" CssClass="gridView" AllowPaging="true" PageSize="10"
                                    OnRowCommand="gdvAud_RowCommand"     
                                    OnRowDataBound="gdvAud_RowDataBound"                         
                                    OnPageIndexChanging="gdvAud_PageIndexChanging"
                                    AutoGenerateColumns="false"
                                    Visible="true">

                                    <AlternatingRowStyle CssClass="alt" />

                                    <Columns>
                                        <%-- Configurar colunas do Grid --%>
                                        
                                        <asp:BoundField DataField="aud_data" HeaderText="Data"/> 
                                        <asp:BoundField DataField="aud_usuario" HeaderText="Usuário"/>
                                        <asp:BoundField DataField="aud_acao" HeaderText="Ação"/>
                                        <asp:BoundField DataField="aud_tabela" HeaderText="Tabela"/>
                                        <asp:BoundField DataField="aud_dados_antes" HeaderText="Dados Anteriores"/>
                                        <asp:BoundField DataField="aud_dados_depois" HeaderText="Dados Posteriores"/>
                                       

                                    </Columns>
                                    

                                </asp:GridView>
                                <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>

                                </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                

              

            
        </div>
    </div>


</asp:Content>
