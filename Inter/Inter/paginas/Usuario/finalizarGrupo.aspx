<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_finalizarGrupo" Codebehind="finalizarGrupo.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <script type="text/javascript">
        $(document).ready(function () {

            // ALTERAR COR DO ÍCONE NO MENU LATERAL 
            $('#cphConteudo_icone9').addClass('corIcone');
        });

        //CHAMAR MODAL COM MENSAGEM DE NÃO POSSUI GRUPOS PARA FINALIZAR
        function msgNaoPossuiGrupos() {
            $("#naoPossuiGrupo").click();
        }
    </script>

    <!-- Finalizar Grupos (p9) -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Finalizar Grupos</h3>
            </div>
            <div class="panel-body-usuarios">
                <button type="button" style="display: none;" id="naoPossuiGrupo" data-toggle="modal" data-target="#myModalNaoPossuiGrupo"></button>
                <table class="table">
                    <thead>
                        <tr>
                            <td>Grupo</td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlFinalizarGrupos" runat="server" ClientIDMode="Static" AutoPostBack="true" CssClass="dropDown" OnSelectedIndexChanged="ddlFinalizarGrupos_SelectedIndexChanged">

                                </asp:DropDownList>
                            </td>
                        </tr>
                    </thead>
                </table>

                <asp:Panel ID="PanelFinalizarGrupo" runat="server">
                   
                </asp:Panel>

                <table class="table" style="width: 50%; margin-top: 5%; margin-left: 25%; border: 1px solid #DDD; text-align: center">
                    <thead>
                        <tr>
                            <td colspan="2">
                                <label>MÉDIA NAS DISCIPLINAS</label>
                            </td>
                        </tr>
                    </thead>

                    <tr>
                        <td>
                            <label>Engenharia de Software 3 (ES3): </label>
                        </td>
                        <td>
                            <label>10</label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label>Banco de Dados (BD): </label>
                        </td>
                        <td>
                            <label>10</label>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <label>Interação Humano Computador (IHC): </label>
                        </td>
                        <td>
                            <label>10</label>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <label>Programação em  Scripts (PS): </label>
                        </td>
                        <td>
                            <label>10</label>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <label style="font-size: 18px; font-weight: bolder; color: #960d10;">MÉDIA FINAL: </label>
                        </td>
                        <td>
                            <label style="font-size: 18px; font-weight: bolder; color: #960d10;">10</label>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#myModalLiberarEdicao">
                                <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar</button></td>

                        <td>
                            <button type="button" class="btn btn-default" id="" onclick="Mostra('p16');">
                                <span class="glyphicon glyphicon-ok-circle"></span>&nbsp Finalizar</button></td>

                    </tr>
                </table>
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

    <!-- MODAL FINALIZADO COM SUCESSO -->

        <div class="modal fade" data-backdrop="static" id="myModalFinalizadoSucesso" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <!--   <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button> -->

                    </div>
                    <div class="modal-body">
                        <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                            <span style="color: #09a01c;" class="glyphicon glyphicon-ok-sign"></span>&nbsp Grupo Finalizado com Sucesso!</h1>



                    </div>

                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" id="btnVoltarHome" data-dismiss="modal" onclick="Mostra('p2');" title="Voltar para a Home do sistema ">Voltar para Home</button>

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" onclick="Mostra('p9');" title="Voltar para a finalização dos grupos do PI">Finalizar outro Grupo</button>


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
                        <span style="color: #960d10;" class="glyphicon glyphicon-remove"></span>&nbsp Sua matéria ainda não possui grupos para finalizar!</h1>
                </div>

                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnVoltarHome2" runat="server" OnClick="btnVoltarHome2_Click" ToolTip="Voltar para a home do sistema">
                        <span class="glyphicon glyphicon-home"></span>&nbsp Voltar para a home</asp:LinkButton>                    
                </div>
            </div>
        </div>
    </div>


</asp:Content>

