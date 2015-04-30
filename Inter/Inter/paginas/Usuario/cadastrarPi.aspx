<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_cadastrarPi" CodeBehind="cadastrarPi.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <script type="text/javascript">

        $(document).ready(function () {
            // ALTERAR COR DO ÍCONE NO MENU LATERAL 
            $('#cphConteudo_icone5').addClass('corIcone');

        });

        // LIMPAR TEXTBOXS MODAL CADASTRAR CRTITÉRIO 
        function fechaModalCri() {
            $('#txtNomeCriterio').val(" ");
            $('#txtDescricaoCriterio').val(" ");
            $('#lblMsgCriterio').html(" ");
        }

        // ABRIR MODAL PESO 1
        function MostraModalPesoUm() {
            $('#btnModalPesoUm').click();
        }

        //FECHAR MODAL CADASTRAR CRTITÉRIO 
        function FechaModalCriacaoCriterio() {
            $('#fecharModal').click();
        }

        function fechaModalPeso1() {
            $('#fecharModalPeso1').click();
        }
        
    </script>

    <button style="display: none" type="button" id="btnModalPesoUm" data-toggle="modal" data-target="#myModalPesoUm"></button>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- CADASTRAR PI -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Cadastrar PI</h3>
            </div>
            <div class="panel-body-usuarios">
                <%--LABELS COM ID AUT RECEBERAM OS VALORES AUTOMÁTICO DO BANCO DE DADOS--%>
                <table id="tabelaCadastrarPi" class="table">

                    <tr>
                        <td>
                            <asp:Label ID="lblCodigoPi" CssClass="label" runat="server" Text="Código PI: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCodigoPiAut" runat="server" Text=""></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCurso" CssClass="label" runat="server" Text="Curso: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblCursoAut" runat="server" Text=""></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblSemestre" CssClass="label" runat="server" Text="Semestre: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblSemestreAut" runat="server" Text=""></asp:Label>

                        </td>


                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblAno" CssClass="label" runat="server" Text="Ano: "></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblAnoAut" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSemestreAno" CssClass="label" runat="server" Text="Semestre Ano: "></asp:Label>
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
                            <div style="text-align: left; margin-left: 20px; border: 1px solid #DDD; padding: 10px;">
                                Banco de Dados<br />
                                Engenharia de Software 3<br />
                                Interação Humano Computador<br />
                                Programação em Scripts<br />
                            </div>
                        </td>
                    </tr>

                </table>
                <br />


                <table>
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

                <%--Div que recebem as datas inseridas pelo professor mãe--%>
                <div id="containerDatas">
                </div>


                <table class="tableBotoes">
                    <tr>
                        <td class="colunaBotoes"></td>
                        <td class="colunaBotoes"></td>
                        <td class="colunaBotoes">
                            <asp:Button ID="btnContinuarEtapa2" OnClientClick="Mostra('p10'); return false;" ClientIDMode="Static"
                                CssClass="btn btn-default" runat="server" Text="Continuar" ToolTip="Ir para adicionar critérios" />
                        </td>
                    </tr>
                </table>
                <br />
                <p style="text-align: right; font-weight: bold; margin-top: 5px;">Passo 1 de 4</p>
            </div>
        </div>

    </div>


    <!-- Adicionar critérios (p10) -->

    <asp:UpdatePanel ID="updPanelCriterio" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="p10" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Adicionar Critérios</h3>
                    </div>
                    <div class="panel-body-usuarios">

                        <table style="width: 60%; margin-left: -10px;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblCriterioGeral" CssClass="label" runat="server" Text="Critérios Gerais"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblCriterioPi" CssClass="label" runat="server" Text="Critérios PI"></asp:Label></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="width: 200px; height: 230px; overflow-y: auto;">
                                        <asp:ListBox ID="listaCritGeral" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="listaCritGeral_SelectedIndexChanged" ClientIDMode="Static"></asp:ListBox>
                                    </div>
                                </td>

                                <td>
                                    <div style="width: 200px; height: 230px; overflow-y: auto;">
                                        <asp:ListBox ID="listaCritPi" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="listaCritPi_SelectedIndexChanged" ClientIDMode="Static"></asp:ListBox>
                                    </div>
                                </td>

                                <td></td>
                            </tr>

                            <tr>
                                <td colspan="3" style="color: red; text-align: left; font-size: 16px;">
                                    <br />
                                    <asp:Label ID="lblMsgErroAdicionarCriterio" runat="server" Visible="false" Text="<span class='glyphicon glyphicon-exclamation-sign' ></span> &nbsp Adicione pelo menos 1 critério ao PI." Style="margin-left: 7%; font-weight: bold"></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <button type="button" class="btn btn-default" id="btnVoltarEtapa2" onclick="Mostra('p1');" title="Voltar ao cadastro de PI">
                                        <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Voltar</button></td>
                                <td>
                                    <button type="button" class="btn btn-default" id="btnCadastrarCriterio" runat="server" data-toggle="modal" data-target="#myModalCadastrarCri" title="Ir para cadastro de critérios">
                                        <span class="glyphicon glyphicon-plus"></span>&nbsp Cadastrar Critérios
                                    </button>
                                </td>
                                <td>
                                    <asp:Button ID="btnContinuarEtapa3" runat="server" Text="Continuar" CssClass="btn btn-default"
                                        ToolTip="Ir para adicionar peso aos critérios" OnClick="btnContinuarEtapa3_Click" />
                                </td>
                            </tr>
                        </table>

                        <p style="text-align: right; font-weight: bold; margin-top: 5px;">Passo 2 de 4</p>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--TRIGGERS USADAS PARA ATUALIZAR SOMENTE OS MÉTODOS QUE ESTIVEREM CONTIDAS NELAS--%>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="listaCritGeral" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="listaCritPi" EventName="SelectedIndexChanged" />
        </Triggers>

    </asp:UpdatePanel>

    <!-- Adicionar peso aos critérios (p12) -->
    <asp:UpdatePanel ID="updPanelPeso" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="p12" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Adicionar Peso aos Critérios</h3>
                    </div>
                    <div class="panel-body-usuarios">
                        <table style="width: 30%; margin-left: 5%;">
                            <tr>
                                <%--PAINEL QUE VAI RECEBER OS CRITÉRIOS PARA INSERÇÃO DOS PESOS--%>
                                <asp:Panel ID="PanelCriterios" runat="server" ClientIDMode="Static"></asp:Panel>
                            </tr>
                        </table>

                        <table style="width: 75%; margin-left: 5%">
                            <tr>
                                <td colspan="2" style="color: red; text-align: left; font-size: 16px; font-weight: bold">
                                    <asp:Label ID="lblMsgPesosCriterios" runat="server" Visible="false" Text="<span class='glyphicon glyphicon-exclamation-sign' ></span> &nbsp Pesos válidos entre os valores 1 e 10."></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 30%; margin-left: 5%">
                            <tr>
                                <td>
                                    <button type="button" class="btn btn-default" id="voltarEtapa2" onclick="Mostra('p10');" title="Voltar para Adicionar Critérios">
                                        <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Voltar</button></td>
                                <td>
                                    <asp:Button ID="ContinuarEtapa4" runat="server" CssClass="btn btn-default" Text="Continuar" OnClick="ContinuarEtapa4_Click"
                                        ToolTip="Ir para Criar Grupos" />
                                </td>
                            </tr>

                        </table>
                        <p style="text-align: right; font-weight: bold;">Passo 3 de 4</p>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Criar Grupos (p13) -->

    <asp:UpdatePanel ID="updPanelGrupos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div id="p13" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Criar Grupos</h3>
                    </div>
                    <div class="panel-body-usuarios">

                        <table style="width: 70%; margin: auto">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNomeGrupo" CssClass="label" runat="server" Text="Nome do Grupo: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtNomeGrupo" CssClass="text" Width="98%" placeholder="Preenchimento obrigatório" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                        </table>

                        <table style="width: 70%; margin: auto">

                            <tr>
                                <td>
                                    <asp:Label ID="lblAlunoDisciplina" CssClass="label" runat="server" Text="Alunos da Disciplina"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblAlunoGrupo" CssClass="label" runat="server" Text="Alunos do Grupo"></asp:Label></td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="width: 100%; height: 230px;">
                                        <asp:ListBox ID="listaAlunoGeral" runat="server"
                                            AutoPostBack="true" OnSelectedIndexChanged="listaAlunoGeral_SelectedIndexChanged" ClientIDMode="Static">
                                            <asp:ListItem Value="1">Bruno</asp:ListItem>
                                            <asp:ListItem Value="2">Felipe</asp:ListItem>
                                            <asp:ListItem Value="3">Higor</asp:ListItem>
                                            <asp:ListItem Value="4">Dayane</asp:ListItem>
                                            <asp:ListItem Value="5">Gabriel</asp:ListItem>
                                        </asp:ListBox>
                                    </div>
                                </td>

                                <td>
                                    <div style="width: 100%; height: 230px;">
                                        <asp:ListBox ID="listaAlunosGrupo" runat="server" OnSelectedIndexChanged="listaAlunosGrupo_SelectedIndexChanged"
                                            AutoPostBack="true" ClientIDMode="Static"></asp:ListBox>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblGrupos" runat="server" CssClass="label" Text="Grupos: "></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:ListBox ID="listaGrupos" runat="server" OnSelectedIndexChanged="listaGrupos_SelectedIndexChanged" AutoPostBack="true" ClientIDMode="Static"></asp:ListBox>

                                </td>

                            </tr>

                            <tr>
                                <td colspan="2">
                                    <br />
                                    <p style="font-size: 15px; font-weight: bold;">
                                        <span class="glyphicon glyphicon-edit"></span>&nbsp Clique em um grupo para poder Editá-lo
                                    </p>
                                    <br />
                                </td>
                            </tr>
                        </table>

                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:LinkButton CssClass="btn btn-default" ID="LkbVoltarEtapa3" runat="server" OnClick="LkbVoltarEtapa3_Click"
                                        ToolTip="Voltar para adicionar peso aos critérios"> <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Voltar</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnExcluirGrupo" Enabled="false" runat="server" OnClick="btnExcluirGrupo_Click" CssClass="btn btn-default" OnClientClick="Disable();" ToolTip="Excluir grupo selecionado">
                                        <span class="glyphicon glyphicon-trash"></span>&nbsp Excluir</asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton ID="btnCancelarEdicao" Enabled="false" runat="server" OnClick="btnCancelarEdicao_Click" CssClass="btn btn-default" ToolTip="Cancelar a Edição do grupo selecionado">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar Edição</asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton ID="btnConfirmarEdicao" Enabled="false" runat="server" OnClick="btnConfirmarEdicao_Click" CssClass="btn btn-default" ToolTip="Confirmar a Edição do grupo selecionado e Criar outro grupo">
                                        <span class="glyphicon glyphicon-edit"></span>&nbsp Confirmar Edição</asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton ID="btnConfirmarGrupo" runat="server" OnClick="btnConfirmarGrupo_Click" CssClass="btn btn-default" ToolTip="Confirmar o grupo atual e Criar outro grupo">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar Grupo</asp:LinkButton></td>
                                <td>
                                    <button type="button" class="btn btn-default" id="finalizarCriarPi" onclick="finalizarCadastroPI();" data-toggle="modal" data-target="#myModalPiCadastrado" title="Finalizar criação de PI">
                                        <span class="glyphicon glyphicon-ok-circle"></span>&nbsp Finalizar</button></td>
                            </tr>


                        </table>

                        <p style="text-align: right; font-weight: bold; margin-top: 5px;">Passo 4 de 4</p>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--TRIGGERS USADAS PARA ATUALIZAR SOMENTO OS MÉTODOS QUE ESTIVEREM CONTIDAS NELAS--%>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="listaAlunoGeral" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="listaAlunosGrupo" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="listaGrupos" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>


    <!-- Modal Cadastrar Datas de  Eventos -->
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

    <!-- Modal Cadastrar Critérios -->
    <div class="modal fade" data-backdrop="static" id="myModalCadastrarCri" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <asp:UpdatePanel ID="updPanelNovoCri" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" id="fecharModal" onclick="fechaModalCri();" class="close" data-dismiss="modal"><span aria-hidden="true" style="font-size: 35px;">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title" id="myModalLabel3">Cadastrar Critérios</h4>
                        </div>
                        <div class="modal-body">
                            <table style="width: 70%; margin-left: 5%;">
                                <tr style="text-align: left;">
                                    <td>
                                        <asp:Label ID="lblNomeCriterio" runat="server" CssClass="label" Text="Nome Critério: "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtNomeCriterio" ClientIDMode="Static" CssClass="textCriterio" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>
                                <tr style="text-align: left;">
                                    <td>
                                        <asp:Label ID="lblDescricaoCriterio" runat="server" CssClass="label" Text="Descrição do Critério: "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtDescricaoCriterio" ClientIDMode="Static" CssClass="textCriterio" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <asp:Label ID="lblMsgCriterio" ClientIDMode="Static" runat="server" Style="font-size: 18px"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </div>


                        <div class="modal-footer">
                            <asp:LinkButton ID="btnCancelarCriterio" CssClass="btn btn-default" ToolTip="Cancelar inserção" runat="server" OnClick="btnCancelarCriterio_Click">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                            <asp:LinkButton ID="btnCriarNovoCriterio" runat="server" CssClass="btn btn-default"
                                OnClick="btnCriarNovoCriterio_Click" ToolTip="Confirmar Inserção">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                        </div>


                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>



    <!-- MODAL ADICIONAR PESO 1 -->
    <asp:UpdatePanel ID="updPeso1" runat="server">
        <ContentTemplate>
            <div class="modal fade" data-backdrop="static" id="myModalPesoUm" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" id="fecharModalPeso1" onclick="fechaModalPeso1();" class="close" data-dismiss="modal"><span aria-hidden="true" style="font-size: 35px;">&times;</span><span class="sr-only">Close</span></button>

                        </div>
                        <div class="modal-body">
                            <h3 style="font-weight: bolder; text-align: center; color: #1f1f1f">
                                <span style="color: #960d10;" class="glyphicon glyphicon-exclamation-sign"></span>&nbsp Deseja atribuir peso "1" aos pesos de critérios não preenchidos?</h3>
                        </div>

                        <div class="modal-footer">

                            <asp:Button ID="btnAdicionarPesoUm" runat="server" OnClick="btnAdicionarPesoUm_Click" CssClass="btn btn-default"
                                Text="Sim" ToolTip="O sistema atribuirá peso 1 aos campos vazios" />

                            <button type="button" class="btn btn-default" id="" data-dismiss="modal">Não</button>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <!-- MODAL PI CADASTRADO -->

    <div class="modal fade" data-backdrop="static" id="myModalPiCadastrado" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                        <span style="color: #09a01c;" class="glyphicon glyphicon-ok-sign"></span>&nbsp PI Cadastrado com Sucesso!</h1>
                </div>

                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnVoltarHome2" runat="server" OnClick="btnVoltarHome2_Click" ToolTip="Voltar para a home do sistema">
                        <span class="glyphicon glyphicon-home"></span>&nbsp Voltar para a home</asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-default" ID="btnVoltarAvaliar" runat="server" OnClick="btnVoltarAvaliar_Click" ToolTip="Ir para a avaliação dos grupos do PI">
                        <span class="glyphicon glyphicon-check"></span>&nbsp Avaliar grupos </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <!-- dialogs -->
    <div id="boxCampoVazio" title="Preencha todos os campos!" style="display: none;">
        <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Todos os campos devem ser preenchidos </p>
    </div>


    <!-- dialogs -->
    <div id="boxDesejaExcluir" title="Excluir Evento!" style="display: none;">
        <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Tem certeza que deseja excluir o evento? </p>
    </div>
</asp:Content>

