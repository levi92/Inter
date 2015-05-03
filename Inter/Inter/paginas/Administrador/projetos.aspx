<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuCoord.Master" AutoEventWireup="true" CodeBehind="projetos.aspx.cs" Inherits="paginas_Admin_projetos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone5').addClass('corIcone');
        });
    </script>
  
      <div id="p1" class="first">
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
             

</asp:Content>
