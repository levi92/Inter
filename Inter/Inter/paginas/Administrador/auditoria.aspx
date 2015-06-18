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
               
                <table class="table" style="margin-left: -8px">
                            <tr style="text-align: right; padding-left: 0; padding-right: 0;">
                                <td style="text-align: right; padding-left: 0; padding-right: 0;">
                                    <asp:Label Style="line-height: 2.3; vertical-align: middle" ID="lblUsuario" CssClass="label" runat="server" Text="Usuario:"></asp:Label>
                                </td>

                                <td colspan="2" style="padding-left: 0; padding-right: 0;">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtUsuario" Width="150px" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                                <td style="text-align: right; padding-left: 0; padding-right: 0;">
                                    <asp:Label Style="line-height: 2.3; vertical-align: middle" ID="lblData" CssClass="label" runat="server" Text="Data:"></asp:Label>
                                </td>

                                <td colspan="2" style="padding-left: 0; padding-right: 0;">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtData" Width="100px" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </td>
                                <td style="text-align: right; padding-left: 0; padding-right: 0;">
                                    <asp:Label ID="lblAcao" Style="line-height: 2.3; vertical-align: middle" runat="server" CssClass="label" Text="Ação:"></asp:Label></td>
                                <td style="text-align: right; padding-left: 0; padding-right: 0;">
                                    <asp:DropDownList ID="ddlAcao" Style="border: #f8f8f8" Width="100%" Height="33px" ClientIDMode="Static" CssClass="dropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAcao_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right; padding-left: 10px; padding-right: 0;">
                                    <asp:Label ID="lblTabela" Style="line-height: 2.3; vertical-align: middle" runat="server" CssClass="label" Text="Tabela:"></asp:Label></td>
                                <td style="text-align: left; padding-left: 0; padding-right: 0;">
                                    <asp:DropDownList ID="ddlTabela" Style="border: #f8f8f8" Width="100px" Height="33px" ClientIDMode="Static" CssClass="dropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTabela_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding-left: 0; padding-right: 0;">
                                    <asp:LinkButton ID="lkbPesquisar" runat="server" CssClass="btn btn-default" OnClick="lkbPesquisar_Click">
                                        <span class="glyphicon glyphicon-search"></span>&nbsp
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <asp:UpdatePanel ID="UpdatePanelAuditoria" UpdateMode="Conditional" runat="server">

                            <ContentTemplate>
                                <asp:GridView ID="gdvAud" runat="server" CellPadding="4" GridLines="None" CssClass="tableEscolherDisciplina" AllowPaging="true" PageSize="10"
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
