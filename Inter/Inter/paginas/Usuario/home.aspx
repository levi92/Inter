<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_home" CodeBehind="home.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

    <!-- Alterar cor do ícone no menu lateral do current -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone2').addClass('corIcone');

        });
    </script>

    <!-- HOME -->

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Home</h3>
            </div>

            <div class="panel-body-usuarios">

                <h2 style="color: #960d10;">Bem-vindo
                    <asp:Label ID="lblNomeProf" runat="server"></asp:Label>!</h2>
                <p style="text-align: justify;">
                    O INTER. é um sistema de avaliaçao de trabalhos interdisciplinares que foi desenvolvido pela 7ª turma de 
                                    Análise e Desenvolvimento de Sistemas da FATEC de Guaratinguetá-SP. Esse sistema serve para auxiliar os professores e coordenadores a atribuirem notas aos projetos interdisciplinares (PIs).
                </p>

                <h3>Uma gama de <span style="color: #960d10;">possibilidades!</span></h3>
                <br />
                <div id="conteudoHome">

                    <div id="crie">
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



                </div>
                <%--conteudoHome--%>

                <hr style="width: 60%; margin: auto;" />
                <br />

                <h3 style="color: #960d10;">Conheça o Sistema INTER.</h3>
                <p style="text-align: center;">
                    O Sistema INTER. possui diversas funcionalidades que facilitam a criação de projetos interdisciplinares. 
                                        Conheça um pouco mais:
                </p>
                <br />

                <%-- Links para a página Ajuda --%>

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
</asp:Content>
