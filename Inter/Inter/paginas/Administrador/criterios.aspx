<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage.Master" AutoEventWireup="true" CodeBehind="criterios.aspx.cs" Inherits="Inter.paginas.Administrador.criterios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone3').addClass('corIcone');
        });
    </script>

     <div class="container">
        <div id="conteudo">
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
                                <td>Eloquência na apresentação</td>
                                <td><span class="glyphicon glyphicon-pencil"></span></td>
                            </tr>
                            <tr>
                                <td>Vestimenta</td>
                                <td>Roupas adequadas para a apresentação</td>
                                <td><span class="glyphicon glyphicon-pencil"></span></td>
                            </tr>
                            <tr>
                                <td>Postura</td>
                                <td>Linguagem e atitudes formais</td>
                                <td><span class="glyphicon glyphicon-pencil"></span></td>
                            </tr>

                        </table>
                       <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#ModalCadastrarCri" title="Adicionar Novo Critério">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp Novo Critério
                        </button>

                    </div>
                </div>
            </div>
             </div>
            </div>

</asp:Content>
