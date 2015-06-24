<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuCoord.master" AutoEventWireup="true" CodeBehind="projetos.aspx.cs" Inherits="paginas_Admin_projetos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript" src="../../scripts/bootstrap.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone5').addClass('corIcone');
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

                <asp:GridView ID="gdvExemplo" runat="server" AutoGenerateColumns="true">
                <Columns>
                </Columns>
            </asp:GridView>


                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">

                    <ContentTemplate>
                        <div class="row" style="margin-top: 8px; margin-left: 2px;">
                        </div>
                        <asp:Label ID="lblMsg" Text="" runat="server"></asp:Label>
                        <asp:GridView ID="gdvProjetos" runat="server" CssClass="tableFinalizar" AllowCustomPaging="true"
                            AutoGenerateColumns="false"
                            AutoGenerateEditButton="false"
                            OnRowDeleting="gdvProjetos_RowDeleting"
                            OnRowUpdating="gdvProjetos_RowUpdating"
                            OnRowDataBound="gdvProjetos_RowDataBound"
                            OnPageIndexChanging="gdvProjetos_PageIndexChanging"
                            OnRowCommand="gdvProjetos_RowCommand">

                            <AlternatingRowStyle CssClass="alt" />

                            <Columns>
                                <asp:TemplateField HeaderText="Codigo do Grupo" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" Text='<%#Eval ("GRU_CODIGO") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codigo do PI" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigoPI" Text='<%#Eval ("PRI_CODIGO") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nome do Projeto">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblNome" Text='<%#Eval ("GRU_NOME_PROJETO") %>' runat="server" CommandName="verDetalhes"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Curso/Turno"><%--esse campo curso é pego no método RowDataBound no code behind--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurso" Text='<%#Eval ("CUR_NOME") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semestre Curso">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemestreCurso" Text='<%#Eval ("PRI_SEMESTRE") %>' runat="server"></asp:Label>
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
            <br />
          
            <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <asp:UpdatePanel ID="UpdatePanelModalNovoCriterio" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" id="fecharModal" onclick="fechaModalCri();" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                    <h4 class="modal-title" id="myModalLabel3">Detalhes do Grupo</h4>
                                </div>
                                <br />

                                <div class="form-group">
                                    <div class="controls-row">
                                        <asp:Label ID="lblNomeGrupoModal" Style="width:auto" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                        <asp:Label ID="lblCursoModal" Style="width:auto"  runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                        <asp:Label ID="lblSemestreModal" Style="width:auto" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                        <asp:Label ID="lblStatusModal" Style="width:auto" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                        <br />
                                        <br />
                                        <div id="Detalhes" Style="width:100%; text-align:center; margin-top:20px;">
                                        <asp:Label ID="lblDisciplinas" Style="padding-right:100px" runat="server" Text="Disciplinas"></asp:Label>
                                        <asp:Label ID="lblProfessores" Style="padding-right:100px" runat="server" Text="Professores"></asp:Label>
                                        <asp:Label ID="lblAlunos" runat="server" Text="Alunos"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:ListBox ID="lstDisciplinas" runat="server" Style="margin-left:10px; width:120px; height:150px;"></asp:ListBox>
                                        <asp:ListBox ID="lstProfessores" runat="server" Style="margin-left:45px; width:120px; height:150px;"></asp:ListBox>
                                        <asp:ListBox ID="lstAlunos" runat="server" Style="margin-left:45px; width:120px; height:150px;"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="controls-row">

                                        <!--Grid -->

                                    </div>
                                    <br />

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


                    </ContentTemplate>



                </asp:UpdatePanel>


            </div>



        </div>
    </div>


</asp:Content>
