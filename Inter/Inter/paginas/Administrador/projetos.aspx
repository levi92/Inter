<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuCoord.master" AutoEventWireup="true" CodeBehind="projetos.aspx.cs" Inherits="paginas_Admin_projetos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone5').addClass('corIcone');
        });
    </script>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Projetos</h3>
            </div>
            <div class="panel-body">
                <table class="table" style="margin-left: -10px">
                    <tr style="text-align: right; padding-left: 0; padding-right: 0;">
                        <td style="text-align: right; padding-left: 0; padding-right: 0;">
                            <asp:Label ID="lblCurso" Style="line-height: 2.3; vertical-align: middle" runat="server" CssClass="label" Text="Curso:"></asp:Label></td>
                        <td style="text-align: right; padding-left: 0; padding-right: 0;">
                            <asp:DropDownList ID="ddlCurso" Style="border: #f8f8f8" Width="130px" Height="33px" ClientIDMode="Static" CssClass="dropDown" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlCurso_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; padding-left: 0; padding-right: 0;">
                            <asp:Label ID="lblSemestreAno" Style="line-height: 2.3; vertical-align: middle" runat="server" CssClass="label" Text="Semestre/Ano:"></asp:Label></td>
                        <td style="text-align: right; padding-left: 0; padding-right: 0;">
                            <asp:DropDownList ID="ddlSemestreAno" Style="border: #f8f8f8" Width="100px" Height="33px" ClientIDMode="Static" CssClass="dropDown" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlSemestreAno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; padding-left: 10px; padding-right: 0;">
                            <asp:Label ID="lblStatus" Style="line-height: 2.3; vertical-align: middle" runat="server" CssClass="label" Text="Status:"></asp:Label></td>
                        <td style="text-align: left; padding-left: 0; padding-right: 0;">
                            <asp:DropDownList ID="ddlStatus" Style="border: #f8f8f8" Width="110px" Height="33px" ClientIDMode="Static" CssClass="dropDown" runat="server" AutoPostBack="false" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2" style="padding-left: 10px; padding-right: 0;">
                            <div class="input-group">
                                <asp:TextBox ID="txtPesquisa" Width="160px" TextMode="Search" placeholder="Pesquisa avançada" MaxLength="200" CssClass="form-control" runat="server"></asp:TextBox>

                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lkbBuscar" runat="server" CssClass="btn btn-default" OnClick="lkbBuscar_Click">
                                        <span class="glyphicon glyphicon-search"></span>&nbsp
                                    </asp:LinkButton>
                                </span>
                            </div>
                        </td>
                    </tr>
                </table>

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">

                    <ContentTemplate>
                        <div class="row" style="margin-top: 8px; margin-left: 2px;">
                        </div>

                        <asp:GridView ID="gdvProjetos" runat="server" CssClass="gridView" AllowCustomPaging="true"
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="false"
                            OnRowDataBound="gdvProjetos_RowDataBound"
                            OnPageIndexChanging="gdvProjetos_PageIndexChanging"
                            OnRowCommand="gdvProjetos_RowCommand">

                            <AlternatingRowStyle CssClass="alt" />

                            <Columns>
                                <asp:TemplateField HeaderText="Nome do Projeto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" Text='<%#Eval ("GRU_NOME_PROJETO") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ano/Semestre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAno" Text='<%#Eval ("SAN") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" Text='<%#Eval ("GRU_FINALIZADO") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkbHabilitar" CssClass="glyphicon glyphicon-pencil" Font-Size="1.5em" runat="server" CommandName="projHabilitar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                
                            </Columns>

                        </asp:GridView>
                        <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>


                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>





        </div>
    </div>


</asp:Content>
