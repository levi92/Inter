<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_avaliarGrupo" Codebehind="avaliarGrupo.aspx.cs" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">

     <!-- Alterar cor do ícone no menu lateral -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone8').addClass('corIcone');
        });
    </script>


    <!-- Avaliar Grupos (p8) -->

    <div id="p1" class="first">
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
                                    <input class="textCriterio" type="text" id="criterioPostura" name="" value="" maxlength="3" style="width: 50px;" /></td>
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

</asp:Content>

