<%@ Page Language="C#" AutoEventWireup="true" Inherits="Paginas_Usuario_user" Codebehind="user.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <!-- Iconezinho do sistema -->
    <link rel="shortcut icon" type="image/x-icon" href="../../App_Themes/images/inter_iconizinho.png" />

    <meta charset="utf-8" />

    <link href="../../App_Themes/css/bootstrap.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../../App_Themes/css/jquery-ui.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" />
    <link href="../../App_Themes/css/style.css" rel="stylesheet" type="text/css" />


    <script src="../../Scripts/jquery-2.1.1.min.js"></script>
    <script src="../../Scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.skitter.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap.js" type="text/javascript"></script>
    <!-- SORTABLE !-->
    <script type="text/javascript" src="../../Scripts/Sortable/jquery-1.10.2.js"></script>
    <!-- Dialog -->
    <%--<script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>--%>
    <%--<script type="text/javascript" src="../../Scripts/Sortable/jquery-ui.js"></script>--%>
    <script src="../../Scripts/jquery-ui.js"></script>

    <title>INTER. </title>

    <script>
        $(document).ready(function () {
            $("#finalizarCriarPi").click(function () {
                //alert("entrou");
                var dadosUl = "";
                $("#sortable6 > li").each(function () {
                    //alert($(this).html());

                    dadosUl += "|" + $(this).html();
                });

                // alert(dadosUl);
                // alert($("#pegarValor").val());
                $.ajax({
                    type: 'POST',
                    url: 'user.aspx/GetUsuario',
                    data: "{usuario:" + JSON.stringify(dadosUl) + "}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (r) {
                        for (var key in r) {
                            var value = r[key];
                            alert(value);
                        }
                    }
                });
            });
        });
    </script>
    <script>
        //CADASTRAR NOVO CRITÉRIO
        function ul() {
            var nome = $("#txtNomeCriterio").val();
            $("#sortable3").append("<li class=\"ui-state-default\">" + nome + "</li>");
        }
        // function finalizarCadastroPI() {
        //     $("#sortable6 > li").each(function () {
        //             alert($(this).html());
        //     });      
        //}
    </script>

    <script>
        $(function () {
            $("#sortable3, #sortable4").sortable({
                connectWith: ".connectedSortable",
            }).disableSelection();
        });

        $(function () {
            $("#sortable5, #sortable6").sortable({
                connectWith: ".connectedSortable",
            }).disableSelection();
        });
    </script>




</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="pegarValor" />
        <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="container-fluid">
                </div>


                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="navbar navbar-fixed-top">
                    <ul class="nav navbar-nav">
                        <li id="logoInter">
                            <span style="margin-left: 20%; cursor: pointer;">
                                <img src="../../App_Themes/images/logo_topo.png" usemap="logoHome" />

                            </span>
                        </li>

                    </ul>
                    <!-- tabela do topo - informações: Professor, Curso ...  -->
                    <table style="margin-left: auto; margin-right: 40px; text-align: center;">

                        <tr class="tabelaEscolherDis">
                            <td>
                                <asp:Label ID="lblProfessorLogado" runat="server" Text="Professor" Width="100px"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCursoLogado" runat="server" Text="Curso" Width="100px"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblSemestreLogado" runat="server" Text="Semestre" Width="100px"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDisciplinaLogado" runat="server" Text="Disciplina" Width="100px"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblMaeLogado" runat="server" Text="Mãe" Width="100px"></asp:Label></td>
                            <td rowspan="2">
                                <asp:Button ID="btnEscolherDisciplina" class="btn btn-default" OnClientClick="Mostra('p1'); return false;" runat="server" Text="Alterar Disciplina" />
                                <%--<button type="button" class="btn btn-default" id="btnEscolherDisciplina" onclick="Mostra('p1');">Alterar Disciplina</button>--%>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="professorLogado" runat="server" Text="&nbsp"></asp:Label></td>
                            <td>
                                <asp:Label ID="cursoLogado" runat="server" Text="&nbsp"></asp:Label></td>
                            <td>
                                <asp:Label ID="semestreLogado" runat="server" Text="&nbsp"></asp:Label></td>
                            <td>
                                <asp:Label ID="disciplinaLogado" runat="server" Text="&nbsp"></asp:Label></td>
                            <td>
                                <asp:Label ID="maeLogado" runat="server" Text="&nbsp"></asp:Label></td>
                        </tr>
                    </table>
                </div>

                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->


        </nav>

        <!-- Menu Lateral  -->

        <div id="lateral">

            <div id="menu">
                <h1>
                    <asp:Label ID="hora" runat="server" Text=""></asp:Label></h1>
                <h5>
                    <asp:Label ID="dia" runat="server" Text=""></asp:Label></h5>
                <hr />
                <ul class="menu">
                    <%--<li><a id="icone1" onclick="Mostra('p1');" href="#"><span class="glyphicon glyphicon-book"></span>&nbsp Escolher Disciplina</a></li> --%>
                    <li><a id="icone2" onclick="Mostra('p2');" href="#"><span class="glyphicon glyphicon-home"></span>&nbsp Home</a></li>
                    <li><a id="icone3" onclick="Mostra('p3');" href="#"><span class="glyphicon glyphicon-bell"></span>&nbsp Notificações</a></li>
                    <li><a id="icone4" onclick="Mostra('p4');" href="#"><span class="glyphicon glyphicon-folder-open"></span>&nbsp PIs Finalizados</a></li>
                    <li><a id="icone5" onclick="Mostra('p5');" href="#"><span class="glyphicon glyphicon-edit"></span>&nbsp Cadastrar PI</a></li>
                    <li><a id="icone6" onclick="Mostra('p6');" href="#"><span class="glyphicon glyphicon-search"></span>&nbsp Consultar PI</a></li>
                    <%--<li><a id="icone7" onclick="Mostra('p7');" href="#"><span class="glyphicon glyphicon-search"></span>&nbsp Consultar Grupo</a></li>--%>
                    <li><a id="icone8" onclick="Mostra('p8');" href="#"><span class="glyphicon glyphicon-check"></span>&nbsp Avaliar Grupos</a></li>
                    <li><a id="icone9" onclick="Mostra('p9');" href="#"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp Finalizar Grupos</a></li>
                    <hr />
                    <li><a id="icone10" onclick="Mostra('p15');" href="#"><span class="glyphicon glyphicon-question-sign"></span>&nbsp Ajuda</a></li>
                    <li><a id="icone11" data-toggle="modal" data-target="#myModalDesejaSair" href="#" title="Sair do sistema e voltar para o login"><span class="glyphicon glyphicon-off"></span>&nbsp Sair</a></li>

                </ul>
                <!-- mais seções -->

            </div>
            <!-- /#menu -->
        </div>



        <!-- /# Fim menu lateral lateral -->

        <div class="container">
            <div id="conteudo">

                <!-- ESCOLHER DISCIPLINA (P1) -->

                <div id="p1" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Escolha uma Disciplina</h3>
                        </div>

                        <div class="panel-body">

                            <asp:GridView ID="gdv" runat="server" CellPadding="4" GridLines="None" CssClass="gridView" AutoGenerateColumns="true" OnRowCreated="gdv_RowCreated">
                                <AlternatingRowStyle CssClass="alt" />
                                <HeaderStyle />
                                <Columns>
                                    <asp:BoundField DataField="PRO_MATRICULA" HeaderText="Matrícula" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Literal ID="Literal1" runat="server" ></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <%--<RowStyle />--%>
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <%--<SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />--%>
                            </asp:GridView>
                            <asp:LinkButton ID="btnRandom" runat="server" CssClass="btn btn-default" OnClick="btnRandom_Click">
                                <i aria-hidden="true" class="glyphicon glyphicon-ok"></i>&nbsp ButtonASP </asp:LinkButton>

                            <button type="button" class="btn btn-default" id="btnConfirmarMateria"><span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </button>

                            <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>



                <!-- HOME (P2) -->

                <div id="p2" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Home</h3>
                        </div>

                        <div class="panel-body-usuarios">

                            <h2 style="color: #960d10;">Bem-vindo Professor!</h2>
                            <p style="text-align: justify;">
                                O INTER. é um sistema de avaliaçao de trabalhos interdisciplinares que foi desenvolvido pela 7ª turma de 
                                    Análise e Desenvolvimento de Sistemas da FATEC de Guaratinguetá-SP. Esse sistema serve para auxiliar os professores e coordenadores a atribuirem notas aos projetos interdisciplinares (PIs).
                            </p>

                            <h3>Uma gama de <span style="color: #960d10;">possibilidades!</span></h3>
                            <br />
                            <div id="conteudoHome">

                                <div id="crie">
                                    <%--<img src="../../App_Themes/images/crie.png" />--%>
                                </div>
                                <div class="texto">
                                    Com o sistema INTER. você (sendo professor de uma disciplina-mãe) poderá criar seu próprio PI, escolhendo a seu gosto as datas, critérios e grupos vinculados ao projeto.
                                </div>

                                <div id="customize">
                                </div>
                                <div class="texto">
                                    O sistema INTER. permite que um professor vinculado a um PI customize um grupo podendo inserir ou desativar alunos que estão matriculados a sua disciplina.
                                </div>

                                <div id="avalie">
                                </div>
                                <div class="texto" style="margin-bottom: 50px;">
                                    Através do sistema de avaliação do INTER., você poderá avaliar alunos dos grupos de acordo com os critérios de 
                                        avaliação definidos, fazer anotações das apresentações e estabelecer as médias dos alunos. Podendo assim, gerar relatórios das avaliações.
                                </div>

                                <hr style="width: 60%; margin: auto;" />
                                <br />

                            </div>
                            <%--conteudoHome--%>

                            <h3 style="color: #960d10;">Conheça o Sistema INTER.</h3>
                            <p style="text-align: center;">
                                O Sistema INTER. possui diversas funcionalidades que facilitam a criação de projetos interdisciplinares. 
                                        Conheça um pouco mais:
                            </p>
                            <br />

                            <table id="tabelaHome1">
                                <tr>
                                    <td><span class="glyphicon glyphicon-home"></span>&nbsp Home</td>
                                    <td style="border-left: 2px solid #ccc; border-right: 2px solid #ccc;"><span class="glyphicon glyphicon-bell"></span>&nbsp Notificações</td>
                                    <td><span class="glyphicon glyphicon-folder-open"></span>&nbsp PIs Finalizados</td>
                                </tr>
                                <tr>
                                    <td class="colunaHome1">
                                        <p>Página de apresentação e introdução do Sistema INTER.</p>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                    <td class="colunaHome1" style="border-left: 2px solid #ccc; border-right: 2px solid #ccc;">
                                        <p>
                                            Cheque suas solicitações ou se necessário envie uma solicitação de alteração de notas.<br />
                                            <a>Clique aqui e aprenda a enviar uma solicitação!</a>
                                        </p>

                                    </td>
                                    <td class="colunaHome1">
                                        <p>
                                            Acesse todos os seus PIs finalizados de um determinado curso
                                               e com a possibilidade de gerar relatórios.<br />
                                            <a>Clique aqui e aprenda a gerar relatórios de um PI finalizado!</a>
                                        </p>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <hr style="width: 50%; margin: auto;" />
                            <br />

                            <table id="tabelaHome2">
                                <tr>
                                    <td><span class="glyphicon glyphicon-edit"></span>&nbsp Cadastrar PI</td>
                                    <td style="border-left: 2px solid #ccc; border-right: 2px solid #ccc;"><span class="glyphicon glyphicon-search"></span>&nbsp Consultar PI</td>
                                    <td><span class="glyphicon glyphicon-check"></span>&nbsp Avaliar Grupo</td>
                                </tr>
                                <tr>
                                    <td class="colunaHome1">
                                        <p>
                                            Cadastre um PI (se for professor de disciplina-mãe), 
                                            inserindo datas, critérios e criando grupos para o PI em questão.
                                            <br />
                                            <a>Clique aqui e aprenda a cadastrar um PI!</a>
                                        </p>
                                        <br />
                                        <br />

                                    </td>
                                    <td class="colunaHome1" style="border-left: 2px solid #ccc; border-right: 2px solid #ccc;">
                                        <p>
                                            Consulte o PI em andamento. Visualize as datas, critérios e 
                                            grupos do PI. Além disso, edite um PI cadastrado (dentro das normas do sistema).
                                            <br />
                                            <a>Clique aqui e aprenda a incluir e desativar alunos de um grupo!</a>
                                        </p>

                                    </td>
                                    <td class="colunaHome1">
                                        <p>
                                            Avalie um grupo do PI atribuindo notas aos alunos de acordo com os critérios escolhidos.<br />
                                            <a>Clique aqui e aprenda a avaliar um grupo!</a>
                                        </p>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <hr style="width: 50%; margin: auto;" />
                            <br />


                            <table id="tabelaHome3">
                                <tr>
                                    <td><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp Finalizar Grupo</td>
                                    <td style="border-left: 2px solid #ccc; border-right: 2px solid #ccc;"><span class="glyphicon glyphicon-question-sign"></span>&nbsp Ajuda</td>
                                    <td>
                                        <img src="../../App_Themes/images/escolherDisciplinaBotao.png" /></td>
                                </tr>
                                <tr>
                                    <td class="colunaHome1">
                                        <p>
                                            Aqui um professor de disciplina-mãe pode finalizar as médias de um grupo e quando necessário 
                                            liberar para que algum professor do PI altere alguma nota.
                                            <br />
                                            <a>Clique aqui e aprenda a finalizar um grupo!</a>
                                        </p>

                                    </td>
                                    <td class="colunaHome1" style="border-left: 2px solid #ccc; border-right: 2px solid #ccc;">
                                        <p>
                                            Tire suas dúvidas e aprenda o passo-a-passo das principais funcionalidades do sistema.
                                        </p>
                                        <br />
                                        <br />
                                    </td>
                                    <td class="colunaHome1">
                                        <p>
                                            Ao clicar neste botão você é redirecionado para a página de alteração de disciplinas onde você poderá 
                                            escolher entre todas as disciplinas em que você participa de um PI.
                                            <br />
                                            <a>Clique aqui e aprenda a alterar disciplina!</a>
                                        </p>

                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />

                        </div>
                        <%--DIV panel-body-usuarios--%>
                    </div>
                    <%--panel panel-default--%>
                </div>
                <%--first--%>



                <!-- NOTIFICAÇÕES (P3) -->

                <div id="p3" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Notificações</h3>
                        </div>
                        <div class="panel-body">
                            <button type="button" class="btn btn-default" id="btnNovo" data-toggle="modal" data-target="#myModalEnviarSolicita" title="Aqui você pode criar uma Nova solicitação">
                                <span style="color: gray;" class="glyphicon glyphicon-file"></span>&nbsp Novo
                            </button>
                            <br />
                            <br />

                            <table class="table">
                                <thead>
                                    <tr>
                                        <td>Assunto</td>
                                        <td>Data</td>
                                        <td>Status</td>
                                    </tr>
                                </thead>
                                <tr>
                                    <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                                    <td>12/08/14</td>
                                    <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                                    <td>10/08/14</td>
                                    <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                                    <td>05/08/14</td>
                                    <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>

                                    <td>12/08/14</td>
                                    <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>

                                    <td>10/08/14</td>
                                    <td><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>

                                    <td>05/08/14</td>
                                    <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>

                                    <td>12/08/14</td>
                                    <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>

                                    <td>10/08/14</td>
                                    <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>

                                    <td>05/08/14</td>
                                    <td><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></td>
                                </tr>

                            </table>
                            <ul class="pager">
                                <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                                <li class="next"><a href="#">Próximo &rarr;</a></li>
                            </ul>

                            <span class="glyphicon glyphicon-ok" style="color: #09a01c"></span>&nbsp- Aceita
                            <br />
                            <span class="glyphicon glyphicon-remove" style="color: #960d10"></span>&nbsp- Recusada
                            <br />
                            <span class="glyphicon glyphicon-refresh" style="color: #428bca"></span>&nbsp- Em andamento
                        </div>
                    </div>
                </div>

                <!-- PIS FINALIZADOS (P4) -->

                <div id="p4" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">PIs Finalizados</h3>
                        </div>
                        <div class="panel-body">
                            <table class="table">

                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" CssClass="label" runat="server" Text="Pesquisar:"></asp:Label>
                                    </td>

                                    <td colspan="2">
                                        <asp:TextBox ID="TextBox1" CssClass="textPesquisa" runat="server"></asp:TextBox>
                                    </td>

                                    <td>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp Nome" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="&nbsp Disciplina" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBox4" runat="server" Text="&nbsp  Ano" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBox5" runat="server" Text="&nbsp Semestre" />
                                    </td>
                                    <td>

                                        <button type="button" class="btn btn-default" id="btnPesquisar">
                                            <span class="glyphicon glyphicon-search"></span>&nbsp Pesquisar</button>
                                    </td>
                                </tr>
                            </table>

                            <hr />


                            <table class="table">
                                <thead>
                                    <tr>
                                        <td>Projeto</td>
                                        <td>Data de finaização</td>
                                        <td>Disciplina</td>
                                        <td>Semestre</td>
                                        <td>Solicitar alteração</td>
                                    </tr>
                                </thead>
                                <tr>
                                    <td><a href="#">Sistema Inter_Sistema SAM</a></td>
                                    <td>02/12/2014</td>
                                    <td>IHC</td>
                                    <td>4</td>
                                    <td><span style="color: #428bca" class="glyphicon glyphicon-share-alt"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Sistema Aluno Online</a></td>
                                    <td>18/05/2014</td>
                                    <td>Gestão de equipes</td>
                                    <td>6</td>
                                    <td><span style="color: #d7d5d5" class="glyphicon glyphicon-share-alt"></span></td>
                                </tr>
                                <tr>
                                    <td><a href="#">Sistema Viva no Azul</a></td>
                                    <td>27/11/2014</td>
                                    <td>Programação Web</td>
                                    <td>5</td>
                                    <td><span style="color: #428bca" class="glyphicon glyphicon-share-alt"></span></td>
                                </tr>

                            </table>

                        </div>
                    </div>
                </div>

                <!-- CADASTRAR PI (P5) -->

                <div id="p5" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Cadastrar PI</h3>
                        </div>
                        <div class="panel-body-usuarios">

                            <table class="table">

                                <tr>
                                    <td>
                                        <asp:Label ID="lblCodigoPi" CssClass="label" runat="server" Text="Código PI: "></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCodigoPiAut" runat="server" Text="01"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCurso" CssClass="label" runat="server" Text="Curso: "></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblCursoAut" runat="server" Text="ADS"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblSemestre" CssClass="label" runat="server" Text="Semestre: "></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="lblSemestreAut" runat="server" Text="4"></asp:Label>

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
                                        <%--<asp:Button ID="Button2" CssClass="btn btn-default" runat="server" data-toggle="modal" data-target="#myModal1" Text="Button" />--%>
                                        <button type="button" class="btn btn-default" id="btnAdicionarDatas" data-toggle="modal" data-target="#myModal1" title="Adicionar evento ao PI">
                                            <span class="glyphicon glyphicon-plus"></span>&nbsp Datas</button>
                                    </td>
                                </tr>
                            </table>

                            <div id="containerDatas">
                                <%--<asp:Literal ID="litDatas" runat="server"></asp:Literal>--%>
                            </div>


                            <table class="tableBotoes">
                                <tr>
                                    <td class="colunaBotoes"></td>
                                    <td class="colunaBotoes"></td>
                                    <td class="colunaBotoes">
                                        <asp:Button ID="btnContinuarEtapa2" OnClientClick="Mostra('p10'); return false;" CssClass="btn btn-default" runat="server" Text="Continuar" title="Ir para adicionar critérios" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <p style="text-align: right; font-weight: bold; margin-top: 5px;">Passo 1 de 4</p>
                        </div>
                    </div>

                </div>


                <!-- Adicionar critérios (p10) -->

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
                                            <ul id="sortable3" class="connectedSortable">
                                                <%-- <li class="ui-state-default">Postura</li>
                                                <li class="ui-state-default">Vestimeta</li>
                                                <li class="ui-state-default">Fala</li>
                                                <li class="ui-state-default">Conhecimento</li>
                                                <li class="ui-state-default">Sistema</li>--%>
                                                <asp:Literal runat="server" ID="lblCriGerais"></asp:Literal>
                                            </ul>
                                        </div>
                                    </td>

                                    <td>
                                        <div style="width: 200px; height: 230px; overflow-y: auto;">
                                            <ul id="sortable4" class="connectedSortable">
                                            </ul>
                                        </div>
                                    </td>

                                    <td></td>
                                </tr>

                                <tr>
                                    <td colspan="3">
                                        <br />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <button type="button" class="btn btn-default" id="btnVoltarEtapa2" onclick="Mostra('p5');" title="Voltar ao cadastro de PI">
                                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Voltar</button></td>
                                    <td>
                                        <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#myModalCadastrarCri" title="Ir para cadastro de critérios">
                                            <span class="glyphicon glyphicon-plus"></span>&nbsp Cadastrar Critérios
                                        </button>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-default" id="btnContinuarEtapa3" title="Ir para adicionar peso aos critérios">Continuar</button>

                                    </td>
                                </tr>
                            </table>

                            <p style="text-align: right; font-weight: bold; margin-top: 5px;">Passo 2 de 4</p>
                        </div>
                    </div>
                </div>

                <!-- Adicionar peso aos critérios (p12) -->

                <div id="p12" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Adicionar Peso aos Critérios</h3>
                        </div>
                        <div class="panel-body-usuarios">
                            <table style="width: 30%; margin-left: 5%;">
                                <tr style="text-align: left;">
                                    <td>
                                        <asp:Label ID="lblP" runat="server" Text="Postura: "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtP" CssClass="text" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr style="text-align: left;">
                                    <td>
                                        <asp:Label ID="lblV" runat="server" Text="Vestimenta: "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtV" CssClass="text" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr style="text-align: left;">
                                    <td>
                                        <asp:Label ID="lblF" runat="server" Text="Fala: "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtF" CssClass="text" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr style="text-align: left;">
                                    <td>
                                        <asp:Label ID="lblC" runat="server" Text="Conhecimento: "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtC" CssClass="text" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <button type="button" class="btn btn-default" id="" onclick="Mostra('p10');" title="Voltar para Adicionar Critérios">
                                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Voltar</button></td>
                                    <td>
                                        <%--<asp:Button ID="ContinuarEtapa4" OnClientClick="openModal(); return false;" OnClick="ContinuarEtapa4_Click" CssClass="btn btn-default" runat="server" Text="Continuar" title="" />--%>
                                        <button type="button" class="btn btn-default" id="ContinuarEtapa4" title="Ir para Criar Grupos">Continuar</button>
                                    </td>
                                </tr>
                            </table>


                            <p style="text-align: right; font-weight: bold;">Passo 3 de 4</p>
                        </div>
                    </div>
                </div>


                <!-- Criar Grupos (p13) -->

                <div id="p13" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Criar Grupos</h3>
                        </div>
                        <div class="panel-body-usuarios">
                            <table style="width: 70%; margin-left: -10px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNomeGrupo" CssClass="label" runat="server" Text="Nome do Grupo: "></asp:Label></td>
                                    <td colspan="2" style="text-align: start;">
                                        <asp:TextBox ID="txtNomeGrupo" CssClass="text" Width="95%" runat="server"></asp:TextBox></td>

                                </tr>

                                <tr>
                                    <td colspan="3">
                                        <br />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="lblAlunoDisciplina" CssClass="label" runat="server" Text="Alunos da Disciplina"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblAlunoGrupo" CssClass="label" runat="server" Text="Alunos do Grupo"></asp:Label></td>
                                    <td></td>
                                </tr>

                                <tr>
                                    <td>
                                        <div style="width: 200px; height: 230px; overflow-y: auto;">
                                            <ul id="sortable5" class="connectedSortable">
                                                <li class="ui-state-default">Bruno Eduardo</li>
                                                <li class="ui-state-default">Dayane Ferraz</li>
                                                <li class="ui-state-default">Felipe Ayres</li>
                                                <li class="ui-state-default">Higor Gomes</li>
                                            </ul>
                                        </div>
                                    </td>
                                    <td>
                                        <div style="width: 200px; height: 230px; overflow-y: auto;">
                                            <ul id="sortable6" class="connectedSortable">
                                            </ul>
                                        </div>
                                    </td>
                                    <td></td>
                                </tr>

                                <tr>
                                    <td colspan="3">
                                        <br />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <button type="button" class="btn btn-default" id="btnVoltarEtapa3" onclick="Mostra('p12');" title="Voltar para adicionar peso aos critérios ">
                                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Voltar</button></td>
                                    <td>
                                        <button type="button" class="btn btn-default" id="btnAdicionarGrupo" title="Criar outro grupos">
                                            <span class="glyphicon glyphicon-plus"></span>&nbsp Adicionar Grupo</button></td>
                                    <td>
                                        <button type="button" class="btn btn-default" id="finalizarCriarPi" onclick="finalizarCadastroPI();" data-toggle="modal" data-target="#myModalPiCadastrado" title="Finalizar criação de PI">
                                            <span class="glyphicon glyphicon-ok-circle"></span>&nbsp Finalizar</button></td>
                                </tr>
                            </table>

                            <p style="text-align: right; font-weight: bold; margin-top: 5px;">Passo 4 de 4</p>
                        </div>
                    </div>
                </div>


                <!-- Consultar PI (p6) -->

                <div id="p6" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Consultar PI</h3>
                        </div>

                        <div class="panel-body-usuarios">
                            <table class="table">

                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" CssClass="label" runat="server" Text="Código PI: "></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="01"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label3" CssClass="label" runat="server" Text="Curso: "></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="ADS"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label5" CssClass="label" runat="server" Text="Semestre: "></asp:Label>
                                        <!-- CONQUISTA DESBLOQUEADA! Parabéns, seu sistema possui mais de 1000 linhas - 50G -->
                                    </td>

                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="4"></asp:Label>

                                    </td>


                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" CssClass="label" runat="server" Text="Ano: "></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="2014 "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" CssClass="label" runat="server" Text="Semestre Ano: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="02"></asp:Label>
                                    </td>


                                    <td colspan="2"></td>
                                </tr>

                            </table>



                            <table style="text-align: justify; width: 60%;">
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
                                    <td>Prévia 1 - 12/10/2014
                                        <br />
                                        Prévia 2 - 12/11/2014
                                        <br />
                                        Apresentação Final - 12/12/2014 
                                        <br />
                                    </td>

                                    <td>
                                        <button type="button" class="btn btn-default" id="btnEditar" onclick="Mostra('p5');">
                                            <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar Datas
                                        </button>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <h4>Disciplinas envolvidas:</h4>
                                    </td>
                                    <td colspan="2"></td>
                                </tr>

                                <tr>
                                    <td>Banco de Dados
                                        <br />
                                        Engenharia de Software 3
                                        <br />
                                        Interação Humano-Computador
                                        <br />
                                        Programação em Scripts
                                        <br />
                                    </td>
                                    <td></td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>

                            </table>

                            <!-- Editar Critério-->
                            <table style="text-align: justify; width: 60%;">
                                <tr>
                                    <td>
                                        <h4>Critérios</h4>
                                    </td>
                                    <td>
                                        <h4>Pesos</h4>
                                    </td>
                                    <td></td>
                                </tr>

                                <tr>
                                    <td>Postura<br />
                                        Vestimenta<br />
                                        Fala<br />
                                        Sistema<br />
                                        Conhecimento<br />
                                    </td>

                                    <td>2<br />
                                        3<br />
                                        3<br />
                                        1<br />
                                        1<br />
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
                                        <div style="width: 80%; border: 1px solid gray; padding-left: 10px;">
                                            Aluno1<br />
                                            Aluno2<br />
                                            Aluno3<br />
                                            Aluno4<br />
                                            Aluno5<br />
                                        </div>
                                    </td>

                                    <td style="width: 20%;">
                                        <div style="width: 80%; border: 1px solid gray; padding-left: 10px;">
                                            Aluno1<br />
                                            Aluno2<br />
                                            Aluno3<br />
                                            Aluno4<br />
                                            Aluno5<br />
                                        </div>
                                    </td>

                                    <td style="width: 20%;">
                                        <div style="width: 80%; border: 1px solid gray; padding-left: 10px;">
                                            Aluno1<br />
                                            Aluno2<br />
                                            Aluno3<br />
                                            Aluno4<br />
                                            Aluno5<br />
                                        </div>
                                    </td>
                                    <td style="width: 20%;">
                                        <div style="width: 80%; border: 1px solid gray; padding-left: 10px;">
                                            Aluno1<br />
                                            Aluno2<br />
                                            Aluno3<br />
                                            Aluno4<br />
                                            Aluno5<br />
                                        </div>
                                    </td>
                                </tr>

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


                <!-- Avaliar Grupos (p8) -->

                <div id="p8" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Avaliar Grupo</h3>
                        </div>
                        <div class="panel-body">
                            <!-- Abas Superior Inicio !----------->
                            <ul class="nav nav-tabs" role="tablist">
                                <li class="active"><a href="#avaliacao" role="tab" data-toggle="tab">Avaliação</a></li>
                                <li><a href="#anotacoes" role="tab" data-toggle="tab">Anotações</a></li>
                            </ul>
                            <!-- Abas Superior Fim !-------------->

                            <!-- Conteudo Aba Avaliacao !-->
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane fade in active" id="avaliacao">
                                    <table class="tabelaAvaliar table ">
                                        <tr>
                                            <td>Grupo</td>
                                            <td colspan="4">
                                                <select name="projeto" id="" class="dropDown">
                                                    <option>Sistema de Avaliação de interdisciplinar-Usuário</option>
                                                    <option>Sistema de Avaliação de interdisciplinar-Admin</option>
                                                </select>
                                            </td>
                                        </tr>



                                        <tr>
                                            <td>
                                                <label>&nbsp</label></td>
                                            <td>
                                                <label>Bruno</label></td>
                                            <td>
                                                <label>Dayane</label></td>
                                            <td>
                                                <label>Felipe</label></td>
                                            <td>
                                                <label>Higor</label></td>

                                        </tr>
                                        <tr>
                                            <td>Postura </td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioPostura" name="" value="" maxlength="3" required="required" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioVestimenta" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioFala" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioConhecimento" name="" value="" maxlength="3" style="width: 50px;" /></td>

                                        </tr>

                                        <tr>
                                            <td>Vestimenta</td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioPostura2" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioVestimenta2" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioFala2" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioConhecimento2" name="" value="" maxlength="3" style="width: 50px;" /></td>

                                        </tr>

                                        <tr>
                                            <td>Fala </td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioPostura3" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioVestimenta3" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioFala3" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioConhecimento3" name="" value="" maxlength="3" style="width: 50px;" /></td>

                                        </tr>

                                        <tr>
                                            <td>Conhecimento </td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioPostura4" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioVestimenta4" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioFala4" name="" value="" maxlength="3" style="width: 50px;" /></td>
                                            <td>
                                                <input class="textCriterio" type="text" id="criterioConhecimento4" name="" value="" maxlength="3" style="width: 50px;" /></td>

                                        </tr>

                                        <tr>
                                            <td>
                                                <button type="button" class="btn btn-default" id="" disabled="disabled">
                                                    <span class="glyphicon glyphicon-pencil"></span>&nbsp Editar</button></td>

                                            <td>
                                                <button type="button" class="btn btn-default" id="">
                                                    <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp Salvar</button></td>



                                            <td>
                                                <button type="button" class="btn btn-default" id="">
                                                    <span class="glyphicon glyphicon-ok-circle"></span>&nbsp Finalizar</button></td>
                                            <td></td>

                                            <td>
                                                <button type="button" class="btn btn-default" id="btnImprimirAvaliacao" title="Imprimir a tabela de atribuição de notas acima">
                                                    <span class="glyphicon glyphicon-print"></span>&nbsp Imprimir</button>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <!-- Fim Conteudo Aba Avaliacao !-->

                                <!-- Conteudo Aba Anotações!-->

                                <div role="tabpanel" class="tab-pane fade" id="anotacoes">

                                    <asp:TextBox ID="txtAnotacao" CssClass="txtAnotacao" placeholder="Faça aqui suas anotações" TextMode="MultiLine" runat="server"></asp:TextBox>

                                </div>
                                <!-- Fim Conteudo Aba Anotações !-->

                            </div>
                            <!-- Fim Conteudo Aba Avaliacao !-->
                        </div>
                    </div>
                </div>



                <!-- Finalizar Grupos (p9) -->

                <div id="p9" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Finalizar Grupos</h3>
                        </div>
                        <div class="panel-body-usuarios">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <td>Grupo</td>
                                        <td colspan="4">
                                            <select name="grupo" id="" class="dropDown">
                                                <option>Sistema de Avaliação de interdisciplinar-Usuário</option>
                                                <option>Sistema de Avaliação de interdisciplinar-Admin</option>
                                            </select>
                                        </td>
                                    </tr>
                                </thead>


                                <tr style="color: black; font-weight: bolder; font-size: 14px; font: Helvetica, Arial, sans-serif;">
                                    <td>
                                        <label>Integrantes</label></td>
                                    <td>
                                        <label>ES3</label></td>
                                    <td>
                                        <label>BD</label></td>
                                    <td>
                                        <label>IHC</label></td>
                                    <td>
                                        <label>PS</label></td>
                                </tr>

                                <tr>
                                    <td>
                                        <label>Bruno Eduardo</label>
                                    </td>
                                    <td>
                                        <label id="critPostura">10</label></td>
                                    <td>
                                        <label id="critVestimenta">10</label></td>
                                    <td>
                                        <label id="critFala">10</label></td>
                                    <td>
                                        <label id="crit">10</label></td>
                                </tr>

                                <tr>
                                    <td>
                                        <label>Felipe Ayres </label>
                                    </td>
                                    <td>
                                        <label id="critPostura2">10</label></td>
                                    <td>
                                        <label id="critVestimenta2">10</label></td>
                                    <td>
                                        <label id="critFala2">10</label></td>
                                    <td>
                                        <label id="crit2">10</label></td>

                                </tr>

                                <tr>
                                    <td>
                                        <label>Higor Gomes </label>
                                    </td>
                                    <td>
                                        <label id="critPostura3">10</label></td>
                                    <td>
                                        <label id="critVestimenta3">10</label></td>
                                    <td>
                                        <label id="critFala3">10</label></td>
                                    <td>
                                        <label id="crit3">10</label></td>

                                </tr>

                                <tr>
                                    <td>
                                        <label>Dayane Ferraz </label>
                                    </td>
                                    <td>
                                        <label id="critPostura4">10</label></td>
                                    <td>
                                        <label id="critVestimenta4">10</label></td>
                                    <td>
                                        <label id="critFala4">10</label></td>
                                    <td>
                                        <label id="crit4">10</label></td>

                                </tr>
                            </table>

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

                <!-- AJUDA (p15) -->
                <div id="p15" class="first">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Ajuda</h3>
                        </div>
                        <div class="panel-body">
                        </div>
                    </div>
                </div>

                <!-- Confirmar finalização (p16) -->

                <div id="p16" class="first">
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
                </div>

                <div class="clearfooter">
                </div>



            </div>
        </div>


        <!-- MODAL DESEJA SAIR? -->

        <div class="modal fade" id="myModalDesejaSair" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                    </div>
                    <div class="modal-body">
                        <h3 style="font-weight: bolder; text-align: center; color: #1f1f1f">
                            <span style="color: #960d10" class="glyphicon glyphicon-question-sign"></span>&nbsp Deseja Sair do sistema?</h3>
                    </div>

                    <div class="modal-footer">

                        <a href="../Login/login.aspx">
                            <button type="button" class="btn btn-default" id="" title="Sair do sistema e voltar para o login ">Sim</button></a>

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal">Não</button>

                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="sair" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                        <h4 class="modal-title" id="myModalLabel"></h4>
                    </div>
                    <div class="modal-body">
                        Login ou senha Incorreto
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>






        <!-- Modal Cadastrar Datas de  Eventos -->
        <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel1">Cadastrar Datas de Eventos</h4>
                    </div>
                    <div class="modal-body">
                        <table style="width: 70%; margin-left: 5%;">
                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="lblDescricaoData" runat="server" Text="Descrição da Data: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDescricaoData" CssClass="textData" runat="server"></asp:TextBox></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td colspan="3">
                                    <br />
                                </td>
                            </tr>

                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="lblData" runat="server" Text="Data: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtData" CssClass="textData" TextMode="Date" runat="server"></asp:TextBox></td>
                                <td></td>
                            </tr>
                        </table>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Cancelar Inserção de Datas">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>

                        <button type="button" class="btn btn-default" id="btnAdicionarData" title="Adicionar mais Datas">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp Datas
                        </button>

                        <button type="button" class="btn btn-default" id="btnConfirmarData" data-dismiss="modal" title="Confirmar Inserção">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar</button>

                        <%--<button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                        <button type="button" class="btn btn-primary">Enviar</button>--%>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal Cadastrar Critérios -->
        <div class="modal fade" data-backdrop="static" id="myModalCadastrarCri" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel3">Cadastrar Critérios</h4>
                    </div>
                    <div class="modal-body">
                        <table style="width: 70%; margin-left: 5%;">
                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="lblNomeCriterio" runat="server" Text="Nome Critério: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtNomeCriterio" CssClass="textCriterio" runat="server"></asp:TextBox></td>

                            </tr>

                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>

                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="lblDescricaoCriterio" runat="server" Text="Descrição do Critério: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDescricaoCriterio" CssClass="textCriterio" runat="server"></asp:TextBox></td>

                            </tr>


                        </table>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Cancelar Inserção">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>

                        <button type="button" class="btn btn-default" id="AdicionarCriterios" title="Adicionar mais Critérios">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp Critérios
                        </button>

                        <button type="button" class="btn btn-default" id="btnInserirCriterio" data-dismiss="modal" onclick="ul();" title="Confirmar Inserção">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar</button>


                    </div>
                </div>
            </div>
        </div>


        <!-- MODAL ADICIONAR PESO 1 -->

        <div class="modal fade" data-backdrop="static" id="myModalPesoUm" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                    </div>
                    <div class="modal-body">
                        <h3 style="font-weight: bolder; text-align: center; color: #1f1f1f">
                            <span style="color: #960d10;" class="glyphicon glyphicon-exclamation-sign"></span>&nbsp Deseja atribuir peso "1" aos pesos de critérios não preenchidos?</h3>
                    </div>

                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" onclick="Mostra('p13');" title="O sistema atribuirá peso 1 aos campos vazios">Sim</button>

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal">Não</button>

                    </div>
                </div>
            </div>
        </div>



        <!-- MODAL PI CADASTRADO -->

        <div class="modal fade" data-backdrop="static" id="myModalPiCadastrado" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <!--   <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button> -->

                    </div>
                    <div class="modal-body">
                        <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                            <span style="color: #09a01c;" class="glyphicon glyphicon-ok-sign"></span>&nbsp PI Cadastrado com Sucesso!</h1>
                    </div>

                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" id="btnVoltarHome2" data-dismiss="modal" onclick="Mostra('p2');" title="Voltar para a Home do sistema ">Voltar para Home</button>

                        <button type="button" class="btn btn-default" id="btnVoltarAvaliar" data-dismiss="modal" onclick="Mostra('p8');" title="Ir para a avaliação dos grupos do PI">Avaliar grupos</button>

                    </div>
                </div>
            </div>
        </div>



        <!-- MODAL CERTEZA QUE DESEJA ENVIAR AVALIAÇÃO -->

        <div class="modal fade" data-backdrop="static" id="myModalEnviarAvaliacao" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                    </div>
                    <div class="modal-body">
                        <h3 style="font-weight: bolder; text-align: center; color: #1f1f1f">
                            <span style="color: #960d10;" class="glyphicon glyphicon-exclamation-sign"></span>&nbsp Deseja finalizar e enviar a avaliação?</h3>
                    </div>

                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" data-target="#myModalAvaliacaoSucesso" title="">Sim</button>

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal">Não</button>

                    </div>
                </div>
            </div>
        </div>




        <!-- MODAL AVALIAÇÃO FINALIZADA COM SUCESSO -->

        <div class="modal fade" data-backdrop="static" id="myModalAvaliacaoSucesso" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                    </div>
                    <div class="modal-body">
                        <h1 style="font-size: 30px; font-weight: bolder; text-align: center; color: #1f1f1f">
                            <span style="color: #09a01c;" class="glyphicon glyphicon-ok-sign"></span>&nbsp Avaliação concluída com sucesso!</h1>
                    </div>

                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" onclick="Mostra('p2');" title="Voltar para a Home do sistema ">Voltar para Home</button>

                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" onclick="Mostra('p9');" title="Ir para a página de finalização de grupos no PI">Finalizar grupo</button>

                    </div>
                </div>
            </div>
        </div>


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


        <!-- Modal enviar solicitação -->
        <div class="modal fade" data-backdrop="static" id="myModalEnviarSolicita" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel4">Enviar solicitação</h4>
                    </div>
                    <div class="modal-body">
                        <table style="width: 70%; margin-left: 5%;">

                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="Label12" runat="server" Style="font-size: 16px; font-weight: bold;" Text="Tipo: "></asp:Label></td>
                                <td></td>
                            </tr>

                            <tr style="text-align: left;">
                                <td>
                                    <%--RepeatDirection="Horizontal"--%>
                                    <asp:RadioButtonList ID="rblTiposSolicita" runat="server" CssClass="radio">
                                        <asp:ListItem>Alteração de notas</asp:ListItem>
                                        <asp:ListItem>Problema com cadastros</asp:ListItem>
                                        <asp:ListItem>Problema com avaliações</asp:ListItem>
                                        <asp:ListItem>Sugestão</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td></td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label13" runat="server" Style="font-size: 16px; font-weight: bold; text-align: left;" Text="Assunto: "></asp:Label>
                                    <asp:TextBox ID="txtAssunto" runat="server"></asp:TextBox>
                                </td>


                            </tr>




                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>

                        </table>

                        <table style="width: 70%; margin-left: 5%;">
                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label ID="Label14" runat="server" Style="font-size: 16px; font-weight: bold; text-align: left;" Text="Comentários: "></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="TextArea1" cols="60" rows="10" placeholder="Digite sua solicitação, problema ou sugestão."></textarea>

                                </td>
                            </tr>

                        </table>



                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Cancelar Inserção">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>

                        <button type="button" class="btn btn-default" id="btnEnviarSolicita" data-dismiss="modal" title="Confirmar Inserção">
                            <span class="glyphicon glyphicon-envelope"></span>&nbsp Enviar</button>


                    </div>



                </div>
            </div>
        </div>

        <!-- dialogs -->
        <div id="boxSelecioneDisc" title="Selecione uma disciplina!" style="display: none;">
            <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Para prosseguir você deve selecionar uma disciplina! </p>
        </div>

        <div id="boxPesoBranco" title="Preencher campos automaticamente?" style="display: none;">
            <p><span style="color: #960d10;" class="glyphicon glyphicon-question-sign"></span>&nbsp Deseja atribuir peso "1" aos pesos de critérios não preenchidos? </p>
            <%--<p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Para prosseguir você deve selecionar uma disciplina! </p>--%>
        </div>

        <div id="boxCampoVazio" title="Preencha todos os campos!" style="display: none;">
            <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Todos os campos devem ser preenchidos </p>

        </div>




        <script src="../../Scripts/interUser.js" type="text/javascript"></script>


    </form>
</body>
</html>
