<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_finalizarGrupo" CodeBehind="finalizarGrupo.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <script type="text/javascript">
        $(document).ready(function () {
            // ALTERAR COR DO ÍCONE NO MENU LATERAL 
            $('#cphConteudo_icone9').addClass('corIcone');

            $('[data-toggle="tooltip"]').tooltip();
        });

        //CHAMAR MODAL COM MENSAGEM DE NÃO POSSUI GRUPOS PARA FINALIZAR
        function msgNaoPossuiGrupos() {
            $("#naoPossuiGrupo").click();
        }

        //CHAMAR MODAL COM MENSAGEM DE GRUPO FINALIZADO
        function msgGrupoFinalizado() {
            $("#grupoFinalizado").click();
        }

        //CHAMAR MODAL COM MENSAGEM DE TODOS OS GRUPOS FINALIZADOS
        function msgTodosFinalizados() {
            $("#todosFinalizados").click();
        }

        //FUNÇÃO ZEBRADO NO GRIDVIEW AVALIAR GRUPOS
        function ZebradoGridAvaliar() {
            var countRow = $("#tableFinalizarGrupos tr").length - 1;
            for (var i = 0; i < countRow; i++) {
                if (i % 2 != 0) {
                    $("#cphConteudo_cphConteudoCentral_" + i).css("background-color", "rgba(206, 206, 206, 0.31)");
                }
            }
        }

        Sys.Application.add_load(BindEvents);
        function BindEvents() {
            $('[data-toggle=tooltip]').tooltip();
            // other bootstrap binding code - see the combined Bootstrap.js for ideas
        }

    </script>
    
    <button type="button" style="display: none;" id="grupoFinalizado" data-toggle="modal" data-target="#myModalGrupoFinalizado"></button>
    <button type="button" style="display: none;" id="todosFinalizados" data-toggle="modal" data-target="#myModalTodosFinalizados"></button>
    <asp:UpdateProgress ID="upgAvaliar" runat="server" AssociatedUpdatePanelID="updFinalizar">
        <ProgressTemplate>
            <div class="modalLoader">
                <div class="modalCenter">
                    <img alt="Carregando" src="../../App_Themes/images/ajax-loader.gif" /><br />                    
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Finalizar Grupos (p9) -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Finalizar Grupos</h3>
            </div>
            <div class="panel-body-usuarios">
                <button type="button" style="display: none;" id="naoPossuiGrupo" data-toggle="modal" data-target="#myModalNaoPossuiGrupo"></button>

                <asp:UpdatePanel ID="updFinalizar" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table class="tabelaAvaliar">
                            <thead>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblGrupo" runat="server" Text="Grupo: "></asp:Label></td>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddlFinalizarGrupos" runat="server" ClientIDMode="Static" AutoPostBack="true" CssClass="dropDown" OnSelectedIndexChanged="ddlFinalizarGrupos_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </thead>
                        </table>

                        <asp:Panel ID="PanelFinalizarGrupo" runat="server"></asp:Panel>

                        <asp:GridView ID="gdvMediasDisciplinas" CssClass="tableFinalizar" runat="server" Width="50%" Style="margin: 4% 25%;" AutoGenerateColumns="false">
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:BoundField DataField="Disciplinas" HeaderText="Disciplinas" />
                                <asp:BoundField DataField="Media" HeaderText="Média" />
                            </Columns>
                        </asp:GridView>

                        <table class="table" style="width: 50%; margin-left: 25%; border: 1px solid #ddd; text-align: center">
                            <tr>
                                <td>
                                    <label style="font-size: 18px; font-weight: bolder; color: #960d10;">MÉDIA FINAL: </label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMediaGrupos" runat="server" ></asp:Label>
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#myModalLiberarEdicao">
                                        <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar</button></td>

                                <td>                                   
                                <asp:LinkButton id="btnFinalizarGrupos" runat="server" CssClass="btn btn-default" OnClick="btnFinalizarGrupos_Click" >
                                    <span class="glyphicon glyphicon-ok-circle"></span>&nbsp Finalizar
                                </asp:LinkButton></td>

                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


    <%--    <div id="p16" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Confirmar Finalização</h3>
            </div>

            <div class="panel-body">

                <h3 style="color: #960d10;">DESEJA FINALIZAR A AVALIAÇÃO DESSE GRUPO?</h3>
                <br />
                <p style="font-size: 14px;">
                    Ao finalizar a avaliação de um grupo no PI, você afirma ter total ciência da responsabilidade 
                                    da avaliação aqui confirmada e que o projeto finalizado em questão disponibilizará,a partir de então, as seguintes funções:<br />
                    <br />


                    • Gerar relatório do grupo no PI;
                                    <br />
                    • Liberar requerimentos de alteração do PI.
                                    <br />
                    <br />


                    E não disponibilizará das seguintes funções:
                                    <br />
                    <br />

                    • Editar critérios;
                                    <br />
                    • Editar alunos;
                                    <br />
                    • Editar datas.
                                    <br />
                    <br />

                    Caso a avaliação ainda não esteja pronta para finalização, basta clicar no botão "Voltar" (localizado na parte inferior esquerda da página) para retornar a página de finalização do grupo. Caso contrário, marque a confirmação de responsabilidade e clique no botão "Confirmar" (localizado na parte inferior esquerda da página) para encerrar a avaliação.
                </p>

                <hr />

                <br />


                <asp:CheckBox ID="CheckBox2" runat="server" Text=" &nbsp Sim, estou ciente e confirmo minha total responsabilidade na finalização desse projeto." Font-Size="Medium" />


                <br />
                <br />
                <br />

                <table>
                    <tr>
                        <td>
                            <button type="button" class="btn btn-default" id="" onclick="Mostra('p9');" title="Voltar ao Finalizar Grupos ">
                                <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Voltar</button>
                        </td>
                        <td>&nbsp</td>
                        <td>&nbsp</td>

                        <td>

                            <button type="button" class="btn btn-default" id="btnConfirmarFinalizacao" data-toggle="modal" data-target="#myModalFinalizadoSucesso" title="Confirmar a finalização do grupo no PI">
                                <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar</button>


                        </td>

                    </tr>
                </table>

            </div>
        </div>
    </div>--%>


    <!-- MODAL LIBERAR NOTA PARA EDIÇÃO -->

    <div class="modal fade" data-backdrop="static" id="myModalLiberarEdicao" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel14">Liberar disciplinas para edição de notas</h4>
                </div>
                <div class="modal-body">
                    <table style="width: 70%; margin-left: 5%;">
                        <tr style="text-align: left;">
                            <td>
                                <asp:CheckBoxList ID="cblLiberarDisciplinas" runat="server">
                                    <asp:ListItem>&nbsp Banco de Dados (BD)</asp:ListItem>
                                    <asp:ListItem>&nbsp Engenharia de Software 3 (ES3)</asp:ListItem>
                                    <asp:ListItem>&nbsp Interação Humano Computador (IHC)</asp:ListItem>
                                    <asp:ListItem>&nbsp Programação em Scripts (PS)</asp:ListItem>
                                    <asp:ListItem>&nbsp Selecionar Todas</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>

                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Cancelar a liberação de disciplinas para edição">
                        <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>

                    <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Confirmar a escolha de disciplinas para edição das notas">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar</button>


                </div>
            </div>
        </div>
    </div>
   

    <!-- MODAL NÃO POSSUI GRUPO PARA FINALIZAR -->

    <div class="modal fade" data-backdrop="static" id="myModalNaoPossuiGrupo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                        <span style="color: #960d10;" class="glyphicon glyphicon-remove"></span>&nbsp Sua disciplina não possui grupos para finalizar!</h1>
                </div>

                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnVoltarHome2" runat="server" OnClick="btnVoltarHome2_Click" ToolTip="Voltar para a home do sistema">
                        <span class="glyphicon glyphicon-home"></span>&nbsp Voltar para a home</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

     <!-- MODAL GRUPO FINALIZADO -->

    <div class="modal fade" data-backdrop="static" id="myModalGrupoFinalizado" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                        <span style="color: #09a01c;" class="glyphicon glyphicon-ok-sign"></span>&nbsp Grupo Finalizado com Sucesso!</h1>
                </div>

                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnGrupoFinalizado" runat="server" OnClick="btnGrupoFinalizado_Click">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp OK</asp:LinkButton>                    
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL TODOS OS GRUPOS FINALIZADOS -->

    <div class="modal fade" data-backdrop="static" id="myModalTodosFinalizados" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body">
                    <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                        <span style="color: #09a01c;" class="glyphicon glyphicon-ok-sign"></span>&nbsp Todos os grupos foram finalizados com sucesso!</h1>
                </div>

                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnVoltarHome3" runat="server" OnClick="btnVoltarHome2_Click" ToolTip="Voltar para a home do sistema">
                        <span class="glyphicon glyphicon-home"></span>&nbsp Voltar para a home</asp:LinkButton>                    
                </div>
            </div>
        </div>
    </div>


</asp:Content>

