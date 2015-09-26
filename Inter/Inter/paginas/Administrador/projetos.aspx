<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuCoord.master" AutoEventWireup="true" CodeBehind="projetos.aspx.cs" Inherits="paginas_Admin_projetos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript" src="../../scripts/bootstrap.js"></script>
    <script type="text/javascript">
        $(document).ready(function () { //Função para adicionar cor ao icone de menu onde o usuario está
            $('#icone5').addClass('corIcone');
        });
    </script>

    <script type="text/javascript">
        function openModal() { //Função para abrir a modal
            $('#myModal1').modal('show');
        }

        function fechaModalClick() {
            $('#fecharModal').click();
        }
    </script>

    



    <asp:UpdateProgress ID="upgProjetos" runat="server" AssociatedUpdatePanelID="UpdatePanelAtivados" DisplayAfter="1000">
        <ProgressTemplate>
            <div class="modalLoader">
                <div class="modalCenter">
                    <img alt="Carregando" src="../../App_Themes/images/ajax-loader.gif" /><br />

                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Projetos</h3>
            </div>
            <div class="panel-body">
                <!--Inicio da tabela onde fica os campos para pesquisa -->
                <table class="table" style="margin-left: -10px">
                    <!--OBS: nao precisava necessariamente estar dentro de uma tabela -->
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
                                    <asp:LinkButton ID="lkbBuscar" runat="server" CssClass="btn btn-default" OnClick="lkbBuscar_Click"> <!--Botao de pesquisa avançada -->
                                        <span class="glyphicon glyphicon-search"></span>&nbsp
                                    </asp:LinkButton>
                                </span>
                            </div>
                        </td>
                    </tr>
                </table>
                <!--Fim da tabela -->

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <!--Usado para gerenciar códigos javascript, Exemplo: abrir a modal -->

                <!--Usado para atualizar a grid sem precisar atualizar toda a pagina -->
                <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="row" style="margin-top: 8px; margin-left: 2px;">
                        </div>
                        <asp:Label ID="lblMsg" Text="" runat="server"></asp:Label>
                        <!--Label para exibir se o projeto foi habilitado com sucesso -->

                        <!--Inicio da grid -->
                        <asp:GridView ID="gdvProjetos" runat="server" CssClass="tableFinalizar" AllowCustomPaging="true"
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="false"
                            OnRowDataBound="gdvProjetos_RowDataBound"
                            OnPageIndexChanging="gdvProjetos_PageIndexChanging"
                            OnRowCommand="gdvProjetos_RowCommand">

                            <AlternatingRowStyle CssClass="alt" />

                            <Columns>
                                <asp:TemplateField HeaderText="Codigo do Grupo" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" Text='<%#Eval ("GRU_CODIGO") %>' runat="server"></asp:Label>
                                        <!--EVAL pega o valor da coluna especificada no datasource-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codigo do PI" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigoPI" Text='<%#Eval ("PRI_CODIGO") %>' runat="server"></asp:Label>
                                        <!--EVAL pega o valor da coluna especificada no datasource-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nome do Projeto">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblNome" Text='<%#Eval ("GRU_NOME_PROJETO") %>' runat="server" CommandName="verDetalhes"></asp:LinkButton>
                                        <!--EVAL pega o valor da coluna especificada no datasource-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Curso/Turno"><%--esse campo curso é pego no método RowDataBound no code behind--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurso" Text='<%#Eval ("CUR_NOME") %>' runat="server"></asp:Label>
                                        <!--EVAL pega o valor da coluna especificada no datasource-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semestre Curso">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemestreCurso" Text='<%#Eval ("PRI_SEMESTRE") %>' runat="server"></asp:Label>
                                        <!--EVAL pega o valor da coluna especificada no datasource-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ano/Semestre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAno" Text='<%#Eval ("SAN") %>' runat="server"></asp:Label>
                                        <!--EVAL pega o valor da coluna especificada no datasource-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" Text='<%#Eval ("GRU_FINALIZADO") %>' runat="server"></asp:Label>
                                        <!--EVAL pega o valor da coluna especificada no datasource-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" HeaderText="">
                                    <ItemTemplate>
                                        <!--Linkbutton usado para habilitar o projeto para edição de nota-->
                                        <asp:LinkButton ID="lkbHabilitar" CssClass="glyphicon glyphicon-pencil" Font-Size="1.5em" runat="server" CommandName="projHabilitar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                        <!--Fim da grid -->
                        <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>
                        <!--Exibe a quantidade de registros ou linhas retornadas do dataset -->
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <br />

            <!--Inicio da modal para ver detalhes do projeto ao clicar em um grupo específico-->
            <!--Em protótipo ainda -->
            <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <asp:UpdatePanel ID="UpdatePanelModalNovoCriterio" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" id="fecharModal" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                    <h4 class="modal-title" id="myModalLabel3">Detalhes do Grupo</h4>
                                </div>
                                <br />

                                <div id="info" style="margin-left:15px; margin-right:15px;">
                                    <asp:Label ID="lblInformacoes" runat="server">
                                    </asp:Label>
                                </div>
                                <div id="GridDetalhes" style="margin-left: 15px; margin-right: 15px;">
                                    <asp:GridView ID="gdvDetalhes" runat="server" CssClass="tableFinalizar" AllowCustomPaging="true"
                                        AutoGenerateColumns="false"
                                        AutoGenerateEditButton="false"
                                        OnRowDataBound="gdvProjetos_RowDataBound"
                                        OnPageIndexChanging="gdvProjetos_PageIndexChanging"
                                        OnRowCommand="gdvProjetos_RowCommand">

                                        <AlternatingRowStyle CssClass="alt" />

                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblT" Text='<%#Eval ("T") %>' runat="server"></asp:Label>
                                                    <!--EVAL pega o valor da coluna especificada no datasource-->
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nomes"><%--esse campo curso é pego no método RowDataBound no code behind--%>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDetalhes" Text='<%#Eval ("Detalhes") %>' runat="server"></asp:Label>
                                                    <!--EVAL pega o valor da coluna especificada no datasource-->
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>

                                <div class="form-group">
                                    <div class="controls-row">
                                    </div>
                                    <br />
                                </div>
                                <asp:ValidationSummary ID="vsNovoCriterio" ValidationGroup="NovoCriterio" ForeColor="#960d10" runat="server" DisplayMode="List" Style="margin: 7px; padding: 7px;" />
                                <div class="modal-footer">
                                    <asp:LinkButton type="button" class="btn btn-default" ID="btnCancelarNovoCriterio" runat="server" title="Cancelar Inserção" OnClick="btnCancelarNovoCriterio_Click">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                                  
                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!--Fim da modal -->
        </div>
    </div>
</asp:Content>
