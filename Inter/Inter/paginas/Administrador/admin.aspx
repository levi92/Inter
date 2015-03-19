<%@ Page Language="C#" AutoEventWireup="true" Inherits="Páginas_Administrador_admin" Codebehind="admin.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">

    <title>INTER.</title>

    <link rel="shortcut icon" type="image/x-icon" href="../../App_Themes/images/inter_iconizinho.png" />

   
    <link href="../../App_Themes/css/bootstrap.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" />
    <link href="../../App_Themes/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-2.1.1.min.js"></script>
    <script src="../../Scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.skitter.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
    
    <script>
    //Cadastrar novo Critério
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

    
</head>
<body>

    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="container-fluid">


                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="navbar navbar-fixed-top">
                    <ul class="nav navbar-nav">
                        <li>
                            <span style="margin-left: 20%;">
                                <img src="../../App_Themes/images/logo_topo.png" /></span>

                        </li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </div>
    </nav>

    <!-- Menu Lateral  -->

    <div id="lateral">

        <div id="menu">
            <h1>
                <p id="hora"></p>
            </h1>
            <h5>
                <p id="dia"></p>
            </h5>
            <hr>
            <ul class="menu">
                <li><a id="icone1" onclick="Mostra('p1');" href="#"><span class="glyphicon glyphicon-bullhorn"></span>&nbsp Solicitações</a></li>

                <li><a id="icone2" onclick="Mostra('p2');" href="#"><span class="glyphicon glyphicon-list"></span>&nbsp Critérios</a></li>

                <li><a id="icone4" onclick="Mostra('p4');" href="#"><span class="glyphicon glyphicon-user"></span>&nbsp Usuários</a></li>
                <li><a id="icone5" onclick="Mostra('p5');" href="#"><span class="glyphicon glyphicon-folder-open"></span>&nbsp Projetos</a></li>
                <hr>
                <li><a id="icone6" onclick="Mostra('p6');" href="#"><span class="glyphicon glyphicon-cog"></span>&nbsp Configurações</a></li>
                <li><a id="icone7" onclick="Mostra('p7');" href="#"><span class="glyphicon glyphicon-question-sign"></span>&nbsp Ajuda</a></li>
                <hr>
                <li><a id="icone8" data-toggle="modal" data-target="#myModalDesejaSair" href="#" title="Sair do sistema e voltar para o login"><span class="glyphicon glyphicon-off"></span>&nbsp Sair</a></li>
            </ul>
            <!-- mais seções -->

        </div>
        <!-- /#menu -->
    </div>
    <!-- vazio -->
    <!-- /# Fim menu lateral lateral -->

    <div class="container">
        <div id="conteudo">

            <div id="p1" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Solicitações</h3>
                    </div>
                    <div class="panel-body">
                        <table class="table">
                            <thead>
                                <tr>
                                    <td>Assunto</td>
                                    <td>Usuário</td>
                                    <td>Data</td>
                                    <td>Status</td>
                                </tr>
                            </thead>
                            <tr>
                                <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>12/08/14</td>
                                <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>10/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>05/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>12/08/14</td>
                                <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>10/08/14</td>
                                <td><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>05/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança de nota no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>12/08/14</td>
                                <td><span style="color: #428bca" class="glyphicon glyphicon-refresh"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Alteração de grupo no Projeto [Nome]</a></td>
                                <td>Fulano Ciclano</td>
                                <td>10/08/14</td>
                                <td><span style="color: #09a01c" class="glyphicon glyphicon-ok"></span></td>
                            </tr>
                            <tr>
                                <td><a href="#">Mudança em atribuição de [Professor] [Matéria]</a></td>
                                <td>Fulano Ciclano</td>
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

            <div id="p2" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Critérios</h3>
                    </div>
                    <div class="panel-body">


                        <table class="table">
                            <tr>
                                <td>Critério</td>
                                <td>Descricao</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>Fala</td>
                                <td>1</td>
                                <td><span class="glyphicon glyphicon-pencil"></span></td>
                            </tr>
                            <tr>
                                <td>Vestimenta</td>
                                <td>1</td>
                                <td><span class="glyphicon glyphicon-pencil"></span></td>
                            </tr>
                            <tr>
                                <td>Postura</td>
                                <td>1</td>
                                <td><span class="glyphicon glyphicon-pencil"></span></td>
                            </tr>

                        </table>
                       <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#ModalCadastrarCri" title="Adicionar Novo Critério">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp Novo Critério
                        </button>

                    </div>
                </div>
            </div>


            <div id="p4" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Usuários</h3>

                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#admin" role="tab" data-toggle="tab">Administradores</a></li>
                            <li><a href="#professor" role="tab" data-toggle="tab">Professores</a></li>

                        </ul>

                            <!-- Conteudo Aba Admin  !-->
                            <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade in active" id="admin">

                                <table class="table">
                                    <tr>
                                        <td>Nome</td>
                                        <td>Login</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Fulano da silva</td>  
                                        <td>fulanosilva@gmail.com</td>                                             
                                        <td><a href="#" title="Editar Usuário"><span class="glyphicon glyphicon-pencil"></span></a> &nbsp &nbsp <a href="#" title="Desativar Usuário"><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></a></td>
                                    </tr>
                                    <tr>
                                       <td>Fulano da silva</td>
                                       <td>fulanosilva@gmail.com</td>  
                                       <td><a href="#" title="Editar Usuário"><span class="glyphicon glyphicon-pencil"></span></a> &nbsp &nbsp <a href="#" title="Desativar Usuário"><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></a></td>
                                    </tr>
                                    <tr>
                                       <td>Fulano da silva</td>
                                       <td>fulanosilva@gmail.com</td>  
                                       <td><a href="#" title="Editar Usuário"><span class="glyphicon glyphicon-pencil"></span></a> &nbsp &nbsp <a href="#" title="Desativar Usuário"><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></a></td>
                                    </tr>


                                </table>
                                
                            </div>
                        
                        <!-- Fim Conteudo Aba Admin !-->
                        
                    <!-- Conteudo Aba Professores  !-->

                            <div role="tabpanel" class="tab-pane fade" id="professor">

                                <table class="table">
                                    <tr>
                                        <td>Nome</td>
                                        <td>Login</td>
                                        <td>Admin?</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Ciclano da Silva</td>  
                                        <td>ciclanodasilva@gmail.com</td>   
                                        <td>Não</td>                                          
                                        <td><a href="#" title="Editar Usuário"><span class="glyphicon glyphicon-pencil"></span></a> &nbsp &nbsp <a href="#" title="Desativar Usuário"><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></a></td>
                                    </tr>
                                    <tr>
                                       <td>Ciclano da Silva</td>
                                       <td>ciclanodasilva@gmail.com</td> 
                                       <td>Não</td>
                                       <td><a href="#" title="Editar Usuário"><span class="glyphicon glyphicon-pencil"></span></a> &nbsp &nbsp <a href="#" title="Desativar Usuário"><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></a></td>
                                    </tr>
                                    <tr>
                                       <td>Silvana Correventofffff</td>
                                       <td>ciclanodasilva@gmail.com</td> 
                                       <td>Sim</td>   
                                       <td><a href="#" title="Editar Usuário"><span class="glyphicon glyphicon-pencil"></span></a> &nbsp &nbsp <a href="#" title="Desativar Usuário"><span class="glyphicon glyphicon-remove" style="color: #960d10"></span></a></td>
                                    </tr>


                                </table>
                                
                                

                            </div>
                                </div>
                        <!-- Fim Conteudo Aba Professores !-->
                        </div>
                        
                </div>
                </div>
            

            <div id="p5" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Projetos</h3>
                    </div>
                    <div class="panel-body">

                        <ul class="nav nav-tabs" role="tablist">
                            <li><a href="#todos" role="tab" data-toggle="tab">Todos</a></li>
                            <li class="active"><a href="#ads" role="tab" data-toggle="tab">ADS</a></li>
                            <li><a href="#gemp" role="tab" data-toggle="tab">GEMP</a></li>
                            <li><a href="#gfin" role="tab" data-toggle="tab">GFIN</a></li>
                            <li><a href="#gti" role="tab" data-toggle="tab">GTI</a></li>
                            <li><a href="#log" role="tab" data-toggle="tab">LOG</a></li>
                        </ul>

                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade in active" id="ads">
                                <table class="table">
                                    <tr>
                                        <td>Projeto</td>
                                        <td>Semestre</td>
                                        <td>Disciplina Mãe</td>
                                        <td>Finalizado?</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Sistema de Gestão de Projetos Inter.</td>
                                        <td>2014-2</td>
                                        <td>IHC</td>
                                        <td>Não</td>
                                        <td><a href="#"><span class="glyphicon glyphicon-pencil" title="Editar"></span></a></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="p6" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Configurações</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#geral" role="tab" data-toggle="tab">Geral</a></li>
                            <li><a href="#backup" role="tab" data-toggle="tab">Backup</a></li>
                        </ul>
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade in active" id="geral">
                                <br />
                                <strong>URL para Importar Dados Semestrais</strong>
                                <form class="form-inline" role="form">
                                    <div class="form-group" style="margin-top: 10px;">
                                        <div class="input-group">
                                            <label for="txtEndereco" class="sr-only">URL do Banco</label>
                                            <div class="input-group-addon"><a href="#" title="Sincronizar Dados"><span class="glyphicon glyphicon-retweet"></span></a></div>
                                            <input id="txtEndereco" runat="server" type="url" value="http://localhost:17758/DB" class="form-control" />

                                        </div>
                                    </div>
                                </form>
                                <%-- <button type="button" class="btn btn-default" name="SincronizarDados" title="Sincronizar Dados">Sincronizar Dados</button>--%>
                                <hr />
                                <button type="button" class="btn btn-default" id="btAdmTrocarSenha" data-toggle="modal" data-target="#alterarSenhaAdm" runat="server" name="alterarSenhaAdm" title="Alterar Senha">Alterar Senha</button><br />
                                <br />


                            </div>

                            <div role="tabpanel" class="tab-pane fade" id="backup">
                                <table class="table">
                                    <tr>
                                        <td>Nome</td>
                                        <td>Data Envio</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>inter_bkp_00-00-00-00-00-05</td>
                                        <td>22-11-2014</td>
                                        <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>
                                            
                                    </tr>
                                    <tr>
                                        <td>inter_bkp_00-00-00-00-00-04</td>
                                        <td>21-11-2014</td>
                                        <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>
                                            
                                    </tr>
                                    <tr>
                                        <td>inter_bkp_00-00-00-00-00-03</td>
                                        <td>20-11-2014</td>
                                        <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>inter_bkp_00-00-00-00-00-02</td>
                                        <td>19-11-2014</td>
                                        <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a>&nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td>
                                        
                                    </tr>
                                    <tr>
                                        <td>inter_bkp_00-00-00-00-00-01</td>
                                        <td>18-11-2014</td>
                                        <td><a href="#"><span class="glyphicon glyphicon-download" title="Baixar Backup"></span></a>&nbsp &nbsp <a href="#" class="restaurar"><span class="glyphicon glyphicon-open" title="Restaurar o Sistema"></span></a> &nbsp &nbsp <a href="#"><span class="glyphicon glyphicon-trash" title="Remover Backup"></span></a></td> 
                                        
                                    </tr>
                                </table>
                                <br />
                                <button type="button" class="btn btn-default btn-lg" title="Criar novo Backup">
                                    <span class="glyphicon glyphicon-plus"></span>&nbsp Novo Backup
                                </button>
                                <button type="button" class="btn btn-default btn-lg" title="Enviar Backup do Computador">
                                    <span class="glyphicon glyphicon-upload"></span>&nbsp Enviar Backup...
                                </button>
                              

                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div id="p7" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Ajuda</h3>
                    </div>
                    <div class="panel-body">
                    </div>

                </div>
            </div>

            <!-- Modal Cadastrar Critérios -->
            <div class="modal fade" data-backdrop="static" id="ModalCadastrarCri" tabindex="-1" role="dialog" aria-labelledby="ModalCadastrarCri" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title" id="TituloCadastrarCri">Cadastrar Critérios</h4>
                        </div>
                        <div class="modal-body">
                            <form id="formCadastrarCri" runat="server">
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
                                </form>
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

            <!-- Modal Trocar Senha Adm -->
            <div class="modal fade" data-backdrop="static" id="alterarSenhaAdm" tabindex="-1" role="dialog" aria-labelledby="alterarSenhaAdm" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Alterar Senha</h4>
                        </div>
                        <div class="modal-body">
                            <form role="form">
                                <div class="form-group">
                                    <label id="lblSenhaAtual" for="txtSenhaAtual">Senha Atual</label>
                                    <input id="txtSenhaAtual" type="password" class="form-control" placeholder="Digite a senha atual" />
                                </div>
                                <div class="form-group">
                                    <label id="lblSenhaNova" for="txtSenhaNova">Senha Nova</label>
                                    <input id="txtSenhaNova" type="password" class="form-control" placeholder="Digite a senha nova" />
                                </div>
                                <div class="form-group">
                                    <label id="lblConfirmarSenha" for="txtConfirmarSenha">Confirmar Senha</label>
                                    <input id="txtConfirmarSenha" type="password" class="form-control" placeholder="Digite novamente a senha nova" />
                                </div>
                            </form>

                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" id="" data-dismiss="modal" title="Cancelar Inserção de Datas">
                                <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</button>



                            <button type="button" class="btn btn-default" id="btnSalvar" data-dismiss="modal" title="Salvar">
                                <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp Salvar</button>


                        </div>
                    </div>
                </div>
            </div>

            <!-- MODAL DESEJA SAIR? -->

            <div class="modal fade" id="myModalDesejaSair" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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



        </div>
        </div>
  
        <!-- dialogs -->
        <div id="boxRestauraSistema" title="Restauração do Sistema" style="display: none;">
            <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Tem CERTEZA que deseja restaurar o sistema para o estado do dia 22/11/14? </p>
        </div>

    <script type="text/javascript" src="../../Scripts/inter.js"></script>


</body>
</html>
