<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuAlterarPerfil.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="paginas_Admin_usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone4').addClass('corIcone');
        });
    </script>
    

<div id="p1" class="first">
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
            
</asp:Content>

