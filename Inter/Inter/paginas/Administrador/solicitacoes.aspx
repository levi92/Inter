<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.Master" AutoEventWireup="true" CodeBehind="solicitacoes.aspx.cs" Inherits="paginas_Admin_solicitacoes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

   
    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone2').addClass('corIcone');
        });
    </script>


    <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #2196F3;color: #fff;border-bottom: none;height: 54px;position: absolute;z-index: 999;width: 100%;box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);">
                    
                       <button type="button" data-dismiss="modal" style="margin-top: -9px;float:left;border: none;background: none;"><span class="mdi mdi-chevron-left hoverAll" style="font-size: 33px;margin-top: 4.5px;"></span></button>
                                        
                    <h4 class="modal-title" id="myModalLabel1" style="float: left;">Mudança de nota no Projeto</h4>
                    
                 
                    <button type="button" runat="server" id="butMostraMenu" name="subMenu" onclick="mostraDiv1('subMenu')" style="  float: right;border: none;background: none;margin-top: -2px;" ><span class="mdi mdi-dots-vertical hoverAll" style="font-size: 25px;"></span></button>
                
                    <h4 style="float:right;margin-top: 0;padding-right: 10px;"> Claudemir</h4>





                </div>
                <div class="subMenu" id="subMenu">
                    <div onclick="butAcao()">Finalizar Favorável</div>
                    <div onclick="butAcao()">Finalizar Desfavorável</div>
                    <div onclick="butAcao()">PI Finalizado</div>
                    <div onclick="fechaDiv1('subMenu')">Fechar</div>
                </div>
                <div class="modal-body" style="background-color: whitesmoke;">
                    <table style="width: 95%;">  
                    
                    <div class="insideBox">
                      <div class="allMsg" style="float:left"><div class="txtCard" onclick="mostraInfo(1)">Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met.</div> <div id="info1" class="infoMsg">Enviado por Jusjiscreudo - As 20:72</div></div>
                      <div class="allMsg" style="float:right"><div class="txtCard" onclick="mostraInfo(3)">Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met, Lorem ipsum dolor sit a met. </div> <div id="info3" class="infoMsg" style="float:right">Enviado por Jusjiscreudo - As 22:32</div></div>
                     </div>                     

                    </table>
                </div>

                <div class="modal-footer" style="text-align: left;background-color:whitesmoke;border-top:none">                    
                    
                    <asp:TextBox runat="server" ID="txtResponder" TextMode="MultiLine" CssClass="minimalScrollbar"></asp:TextBox>
                    <div style="float: right;width: 50px;text-align: center;height: 50px;border-radius: 100px;background-color: #960D10;  box-shadow: 0 2px 5px 3px rgba(0, 0, 0, 0.16);"><span class="mdi mdi-send" style="color: #fff;padding-top: 7px;padding-left: 5px;font-size: 35px;"></span></div>
                </div>
            </div>
        </div>
    </div>


     <div id="p1" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Solicitações</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#geral" role="tab" data-toggle="tab">Aberto</a></li>
                            <li><a href="#andamento" role="tab" data-toggle="tab">Em Andamento</a></li>
                            <li><a href="#finalizado" role="tab" data-toggle="tab">Finalizado</a></li>
                        </ul>
                        <div class="tab-content">

                            <!-- TICKETS EM ABERTO -->
                            <div role="tabpanel" class="tab-pane fade in active" id="geral">
                                <div class="panel-body">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <td>Assunto</td>
                                                <td>Usuário</td>
                                                <td>Data</td>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td><a href="#" data-toggle='modal' data-target='#myModal1'>Mudança de nota no Projeto [Nome]</a></td>
                                            <td>Fulano Ciclano</td>
                                            <td>12/08/14</td>
                                        </tr>                            

                                    </table>
                                    <ul class="pager">
                                        <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                                        <li class="next disabled"><a href="#">Próximo &rarr;</a></li>
                                    </ul>

                                </div>
                            </div>


                            <!-- TICKETS EM ANDAMENTO -->
                            <div role="tabpanel" class="tab-pane fade in" id="andamento">
                                <div class="panel-body">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <td>Assunto</td>
                                                <td>Usuário</td>
                                                <td>Data</td>
                                            </tr>
                                        </thead>  
                                        <tr>
                                            <td><a href="#"></a></td>
                                            <td></td>
                                            <td></td>
                                        </tr>                       

                                    </table>
                                    <ul class="pager">
                                        <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                                        <li class="next disabled"><a href="#">Próximo &rarr;</a></li>
                                    </ul>

                                </div>
                            </div>

                            <!-- TICKETS FINALIZADOS -->
                            <div role="tabpanel" class="tab-pane fade in" id="finalizado">
                                <div class="panel-body">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <td>Assunto</td>
                                                <td>Usuário</td>
                                                <td>Data</td>
                                            </tr>
                                        </thead>  
                                        <tr>
                                            <td><a href="#"></a></td>
                                            <td></td>
                                            <td></td>
                                        </tr>                       

                                    </table>
                                    <ul class="pager">
                                        <li class="previous disabled"><a href="#">&larr; Anterior</a></li>
                                        <li class="next disabled"><a href="#">Próximo &rarr;</a></li>
                                    </ul>

                                </div>
                             </div>

                            
                        </div>
                    </div>
                </div>
            </div>
       
</asp:Content>
