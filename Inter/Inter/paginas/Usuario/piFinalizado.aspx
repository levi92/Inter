<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_piFinalizado" CodeBehind="piFinalizado.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- ALTERAR COR DO ÍCONE NO MENU LATERAL -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone4').addClass('corIcone');
        });
    </script>

    <!-- PIS FINALIZADOS (P4) -->

    <asp:UpdateProgress ID="upgPIsFinalizados" runat="server" AssociatedUpdatePanelID="updPIsFinalizados">
        <ProgressTemplate>
            <div class="modalLoader">
                <div class="modalCenter">
                    <img alt="Carregando" src="../../App_Themes/images/ajax-loader.gif" /><br />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">PIs Finalizados</h3>
            </div>



            <div class="panel-body">
                <asp:UpdatePanel ID="updPIsFinalizados" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPesquisar" CssClass="label" runat="server" Text="Pesquisar:"></asp:Label>
                                </td>

                                <td colspan="2">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtPesquisar" CssClass="form-control" runat="server" placeholder="Digite o nome do projeto"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbPesquisar" runat="server" CssClass="btn btn-default" OnClick="lbPesquisar_Click">
                                        <span class="glyphicon glyphicon-search"></span>&nbsp
                                            </asp:LinkButton>
                                        </span>
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblSemestreAno" runat="server" CssClass="label" Text="Semestre/Ano:"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlSemestreAno" ClientIDMode="Static" CssClass="dropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSemestreAno_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>


                        <hr />
                        <asp:GridView ID="gdvPisFinalizados" CssClass="tableFinalizar" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Projeto" DataField="gru_nome_projeto" />
                                <asp:BoundField HeaderText="Semestre" DataField="pri_semestre" />
                                <asp:BoundField HeaderText="Ano" DataField="san_ano" />
                                <asp:TemplateField HeaderText="Detalhes">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDetalhesProjeto" runat="server" ToolTip="Ver detalhes do projeto.">
                                    <span style="font-size:20px" class="glyphicon glyphicon-list-alt"></span>
                                        </asp:LinkButton>
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

