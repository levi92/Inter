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
                    <li class="active"><a href="#backup" role="tab" data-toggle="tab">Backup</a></li>
                </ul>
                <div class="tab-content">
                    
                        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanelBkp" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                 <asp:Label ID="lblBackup" runat="server"></asp:Label>
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
                        
                        


                    </div>
                </div>
            </div>
        </div>
   



</asp:Content>
