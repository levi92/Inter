<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_consultarPi" CodeBehind="consultarPi.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- ALTERAR COR DO ÍCONE NO MENU LATERAL -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone6').addClass('corIcone');
        });
    </script>

      <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <!-- CONSULTAR PI (P6) -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Consultar PI</h3>
            </div>

            <div class="panel-body-usuarios">
                <table id="tabelaConsultarPi" class="table">

                    <tr>
                        <td>
                            <asp:Label ID="lblCodigo" CssClass="label" runat="server" Text="Código PI: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCodigoPI" runat="server" Text=""></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCurso" CssClass="label" runat="server" Text="Curso: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCursoValor" runat="server" Text=""></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblSemestre" CssClass="label" runat="server" Text="Semestre: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblSemestreValor" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAno" CssClass="label" runat="server" Text="Ano: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblAnoValor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSemestreAno" CssClass="label" runat="server" Text="Semestre Ano: "></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSemestreAnoValor" runat="server"></asp:Label>
                        </td>


                        <td colspan="2"></td>
                    </tr>

                </table>

                <table id="tableEventos" style="text-align: justify; width: 60%;">
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Datas de Eventos:</h4>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gdvEventosConsultarPI" CssClass="tableEventos" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="eve_tipo" />
                                    <asp:BoundField DataField="eve_data" DataFormatString="{0:D}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <button type="button" class="btn btn-default" id="btnEditarDatas" onclick="Mostra('p2');">
                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar Datas
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                </table>

                <table id="tableDisciplinas Evolvidas" style="text-align: justify; width: 60%;">
                    <tr>
                        <td>
                            <h4>Disciplinas envolvidas:</h4>
                        </td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gdvDisciplinasEnvolvidas" CssClass="tableEventos" style="text-transform: capitalize;"  AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField HeaderText="" DataField="Disciplinas" />
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>

                </table>

                <!-- Editar Critério-->
                <table style="text-align: justify; width: 30%;">
                    <tr>
                        <td>
                       <asp:GridView ID="gdvCriterios" AutoGenerateColumns="false" CssClass="tableCriterios" runat="server" >
                           <Columns>
                               <asp:BoundField HeaderText="Critérios" DataField="cge_nome" />
                               <asp:BoundField HeaderText="Pesos"   DataField="cpi_peso" />
                           </Columns>
                       </asp:GridView>  
                        </td>                  
                        <td>
                            <button type="button" class="btn btn-default" id="btnCriterio" onclick="Mostra('p10');">
                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar Critérios
                            </button>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <hr />
                        </td>
                    </tr>
                </table>

                <table style="text-align: justify; width: 100%;">
                    <tr>
                        <td colspan="4">
                            <h4>Grupos</h4>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">   
                          
                           <%-- <asp:UpdatePanel runat="server">--%>
                                <%--<ContentTemplate>   --%>                                  
                                    <asp:Panel ID="pnlGrupos" runat="server" > </asp:Panel>
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>       --%>                  
                        </td>
                    </tr>

                  <%--  <tr>
                        <td>
                            <label>Inter - Adiministrador</label></td>
                        <td>
                            <label>Inter - Usuário</label></td>
                        <td>
                            <label>Sam - Adiministrador</label></td>
                        <td>
                            <label>Sam - Usuário</label></td>
                    </tr>

                    <tr>
                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>

                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>

                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>
                        <td style="width: 20%;">
                            <div style="width: 80%; border: 1px solid gray; padding-left: 10px; border-radius: 5px">
                                Aluno1<br />
                                Aluno2<br />
                                Aluno3<br />
                                Aluno4<br />
                                Aluno5<br />
                            </div>
                        </td>
                    </tr>--%>

                    <tr>
                        <td colspan="4" style="padding-left: 10px;">
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3"></td>
                        <td>
                            <button type="button" class="btn btn-default" id="btnGrupo" onclick="Mostra('p13');">
                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar Grupos
                            </button>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </div>


    <!-- EDITAR CADASTRO PI -->
    <asp:HiddenField ID="hdfDescricao" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfDatas" runat="server" ClientIDMode="Static" />

    <div id="p2" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Cadastrar PI</h3>
            </div>
            <div class="panel-body-usuarios">
                <%--LABELS COM ID AUT RECEBERAM OS VALORES AUTOMÁTICO DO BANCO DE DADOS--%>
                <%-- <table id="tabelaCadastrarPi" class="table">

                    <tr>
                        <td>
                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Código PI: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCodigoPiAut" runat="server" Text=""></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="Curso: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCursoAut" runat="server" Text=""></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="Label3" CssClass="label" runat="server" Text="Semestre: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblSemestreAut" runat="server" Text=""></asp:Label>

                        </td>


                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label4" CssClass="label" runat="server" Text="Ano: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblAnoAut" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" CssClass="label" runat="server" Text="Semestre Ano: "></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSemestreAnoAut" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2"></td>
                    </tr>

                </table>


                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblDiscipEnvolvidas" CssClass="label" runat="server" Text="Disciplinas envolvidas: "></asp:Label>
                        </td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>                        
                        <td>
                           <asp:Panel ID="PainelDisciplinas" runat="server">
                               <asp:Table runat="server" ID="tblDisciplinasEnvolvidas"></asp:Table>
                           </asp:Panel>
                        </td>
                    </tr>

                </table>
                <br />--%>


                <table style="width: 50%; margin: auto;">
                    <tr>
                        <td>
                            <asp:Label ID="lblDatas" CssClass="label" runat="server" Text="Data de Eventos: "></asp:Label>
                        </td>
                        <td>
                            <button type="button" class="btn btn-default" id="btnAdicionarDatas" data-toggle="modal" data-target="#myModal1" title="Adicionar evento ao PI">
                                <span class="glyphicon glyphicon-plus"></span>&nbsp Datas</button>
                        </td>
                    </tr>
                </table>
                <br />
                <%--DIV QUE RECEBE AS DATAS INSERIDAS PELO PROFESSOR MÃE--%>
                <div id="containerDatas" style="width: 50%; margin: auto;">
                </div>


                <table class="tableBotoes">
                    <tr>
                        <td class="colunaBotoes"></td>
                        <td class="colunaBotoes"></td>
                        <td class="colunaBotoes">
                            <button id="btnContinuarEtapa2" onclick="Mostra('p10'); return false;" class="btn btn-default" title="Ir para adicionar critérios">Continuar</button>
                        </td>
                    </tr>
                </table>
                <br />
                <p style="text-align: right; font-weight: bold; margin-top: 5px;">Passo 1 de 4</p>
            </div>
        </div>

    </div>

    <!-- MODAL CADASTRAR DATAS DE EVENTOS -->
    <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true" style="font-size: 35px;">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel1">Cadastrar Datas de Eventos</h4>
                </div>
                <div class="modal-body">
                    <table style="width: 95%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblDescricaoData" CssClass="label" runat="server" Text="Descrição da Data: "></asp:Label>
                            </td>

                            <td>
                                <asp:TextBox ID="txtDescricaoData" CssClass="textData" runat="server" ClientIDMode="Static"></asp:TextBox>

                            </td>
                            <td>
                                <asp:Label ID="lblDescDataMsgErro" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>

                        <tr>
                            <td colspan="3">
                                <br />
                            </td>
                        </tr>

                        <tr style="text-align: left;">
                            <td>
                                <asp:Label ID="lblData" runat="server" CssClass="label" Text="Data: "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtData" runat="server" CssClass="textData" Enabled="false" ClientIDMode="Static" Style="width: 50%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblDataMsgErro" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                    <span id="campoObrigatorio" style="font-size: 18px;"></span>
                    <span id="textoCampObrig" style="font-size: 18px;"></span>

                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default" id="btnCancelarData" data-dismiss="modal" title="Cancelar Inserção de Datas">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>

                    <button type="button" class="btn btn-default" id="btnConfirmarData" title="Confirmar Inserção">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar</button>

                </div>
            </div>
        </div>
    </div>

    <!-- MODAL NÃO POSSUI GRUPO PARA AVALIAR -->

    <div class="modal fade" data-backdrop="static" id="myModalNaoPossuiPi" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                        <span style="color: #960d10;" class="glyphicon glyphicon-remove"></span>&nbsp Sua disciplina não possui um PI cadastrado!</h1>
                </div>

                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnVoltarHome" runat="server" OnClick="btnVoltarHome_Click" ToolTip="Voltar para a home do sistema">
                        <span class="glyphicon glyphicon-home"></span>&nbsp Voltar para a home</asp:LinkButton>                    
                </div>
            </div>
        </div>
    </div>

    <!-- dialogs -->
    <div id="boxDesejaExcluir" title="Excluir Evento!" style="display: none;">
        <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Tem certeza que deseja excluir o evento? </p>
    </div>

</asp:Content>

