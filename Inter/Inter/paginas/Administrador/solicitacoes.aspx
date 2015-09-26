<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.Master" AutoEventWireup="true" CodeBehind="solicitacoes.aspx.cs" Inherits="paginas_Admin_solicitacoes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">
    <!--
        TABELA DE CORES DO HEADER
        
        * Não aberto: Vermelho Fatec (#960d10)
        * Aberto, em andamento: Azul (#2196F3)
        * Encerrado, não favorável: Amarelo(#FFEB3B)
        * Encerrado, favorável: Verde (#4CAF50)
        -->
    <script type="text/javascript" src="../../scripts/bootstrap.js"></script>
    <script type="text/javascript" src="../../scripts/mostraDiv.js"></script>
    <script type="text/javascript" src="../../scripts/inter.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone2').addClass('corIcone');
        });

        function fechaModalCri() {
            $('#txtAssunto').val(" ");
            $('#lblMsg').html(" ");
        }

        function FechaModalCriacaoCriterio() {
            $('#fecharModal').click();
        }

        function openModal() {
            $('#myModal1').modal('show');
        }
        </script>
    <!--Início do modal de Msg-->
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    
    <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <!--A cor do Header muda de acordo com o status-->
                <div class="modal-header" runat="server" id="mdlHeader" style="background-color: #960d10; color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);">
                    <!--Arrumar o hover aqui-->
                    <button type="button" data-dismiss="modal" style="margin-right: 10px;margin-top: -9px; float: left; border: none; background: none;"><span class="mdi mdi-close" style="font-size: 33px; margin-top: 4.5px;"></span></button>
                    <!--ASSUNTO DO TICKET-->
                    <h4 class="modal-title" id="myModalLabelT1" style="float: left;"><asp:Label ID="lblMsgAssunto" runat="server"></asp:Label> - <asp:Label ID="lblMsgCategoria" runat="server"></asp:Label> (  <asp:Label ID="lblMsgStatus" runat="server"></asp:Label> )</h4>
                    <!--Arrumar  Hover aqui-->
                    <button type="button" id="butMostraMenu" name="subMenu" onclick="mostraDiv1('ConteudoMenu_ConteudoCentral_subMenu')" style="float: right; border: none; background: none; margin-top: -2px;"><span class="mdi mdi-dots-vertical hoverAll" style="font-size: 25px;"></span></button>
                    <!--NOME DO PROFESSOR QUE ABRIU O TICKET-->
                    
                    <h4 style="float: right; margin-top: 0; padding-right: 10px;"><asp:Label ID="lblMsgProfessor" runat="server"></asp:Label></h4>
                </div>
                <!--Início 3-dot menu-->
                <!--Início do submenu-->
                <div class="subMenu" runat="server" id="subMenu">
                    <!--Clicar em um item fecha o menu | ESC fecha o menu sem fechar a modal-->
                    <div><asp:LinkButton runat='server' ID='btnFinaliza' OnClick='btnFinaliza_Click' Text='Finaliza Solicitação'></asp:LinkButton></div>
                    <div><asp:LinkButton runat='server' ID='btnLibera' OnClick="btnLibera_Click" Text='Liberar PI' Visible="false"></asp:LinkButton></div>
                </div>
                <!--Fim do submenu-->
                <!--Fim 3-dot menu-->
                <!--Início do Corpo-->
                <div class="modal-body" style="background-color: whitesmoke;">
                    <div id="msgInsideBox" runat="server" class="insideBox">
                        <!--Mensagem
                            Cada mensagem do banco deve ter seu bloco de mensagem.
                            As mensagens do usuario sempre aparecem à direita e a dos outros à esquerda -->
                    </div>
                </div>
                <!--Fim do corpo-->
                <div class="modal-footer" style="text-align: left; background-color: whitesmoke; border-top: none">
                     <asp:Label runat="server" ID="lblMsgId" Visible="false"></asp:Label>
                    <asp:TextBox runat="server" ID="txtResponder" MaxLength="200" TextMode="MultiLine" CssClass="minimalScrollbar"></asp:TextBox>
                    <!--Colocar hoover aqui-->
                    <div style="float: right; width: 50px; text-align: center; height: 50px; border-radius: 100px; background-color: #960D10; box-shadow: 0 2px 5px 3px rgba(0, 0, 0, 0.16);"><asp:LinkButton ID="btnNovaMsg" runat="server"  Text="Enviar" style="padding-top: 14px;  padding-left: 6px;color: white;float: left;" OnClick="btnNovaMsg_Click"></asp:LinkButton>
                   <!--<spano style='color: #fff; padding-top: 7px; padding-left: 5px; font-size: 35px;'></span>--></div>
                </div>
            </div>
        </div>
         </ContentTemplate>
    </asp:UpdatePanel>
    </div>
   
                         
    <!--Fim do modal de Msg-->
    <!--Início do modal de novo ticket-->

   
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

                    <!-- SOLICITACAO EM ABERTO -->
                    <div role="tabpanel" class="tab-pane fade in active" id="geral"> 
                        <%--Grid com UpdatePanel para não atualizar a página inteira ao editar, inserir e desativar solicitacoes--%>
 
                        <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvRequerimentoAberto" runat="server" CssClass="tableFinalizar" DataKeyNames="req_codigo"
                                    AutoGenerateColumns="false"
                                    
                                    AutoGenerateEditButton="false">


                                    <AlternatingRowStyle CssClass="alt" />

                                    <%-- Configurar colunas do Grid (Cada TemplateField é uma coluna) --%>
                                    <Columns>

                                        <%--Coluna do Código do Requerimento--%>
                                        <asp:TemplateField HeaderText="Código" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval ("req_codigo")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do assunto do Requerimento--%>
                                        <asp:TemplateField HeaderText="Assunto">                                       
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnModal" runat="server" Text='<%#Eval ("req_assunto")%>' CommandArgument='<%#Eval ("req_codigo")%>' OnCommand="btnModal_Command" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da categoria do Requerimento--%>
                                        <asp:TemplateField HeaderText="Categoria">                                       
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategoria1" runat="server" Text='<%#Eval ("req_categoria")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Coluna do usuario do Requerimento--%>
                                        <asp:TemplateField HeaderText="Usuario">                                   
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsuario1" runat="server" Text='<%#Eval ("req_usuario")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Data">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao1" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Ultima Modificação">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao2" runat="server" Text='<%#Eval ("req_dt_modificado")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>
                               
                                <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                        <%--Fim do Grid--%>
                    </div>
                    <!-- TICKETS EM ANDAMENTO -->
                    <div role="tabpanel" class="tab-pane fade in" id="andamento">
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvRequerimentoAndamento" runat="server" CssClass="gridView" DataKeyNames="req_codigo"
                                    AutoGenerateColumns="false"
                                    AutoGenerateEditButton="false">


                                    <AlternatingRowStyle CssClass="alt" />

                                    <%-- Configurar colunas do Grid (Cada TemplateField é uma coluna) --%>
                                    <Columns>

                                        <%--Coluna do Código do Requerimento--%>
                                        <asp:TemplateField HeaderText="Código" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval ("req_codigo")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do assunto do Requerimento--%>
                                        <asp:TemplateField HeaderText="Assunto">                                          
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnModal" runat="server" Text='<%#Eval ("req_assunto")%>' CommandArgument='<%#Eval ("req_codigo")%>' OnCommand="btnModal_Command" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da categoria do Requerimento--%>
                                        <asp:TemplateField HeaderText="Categoria">                                      
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategoria2" runat="server" Text='<%#Eval ("req_categoria")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Coluna do usuario do Requerimento--%>
                                        <asp:TemplateField HeaderText="Usuario">                                      
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsuario2" runat="server" Text='<%#Eval ("req_usuario")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Data">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDa2ta2" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Ultima Modificação">
                                            <ItemTemplate>
                                                <asp:Label ID="lbld3ata2" runat="server" Text='<%#Eval ("req_dt_modificado")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>

                                </asp:GridView>
                                <asp:Label ID="lblQtdRegistroAnd" runat="server"></asp:Label>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                    <!-- TICKETS FINALIZADOS -->
                    <div role="tabpanel" class="tab-pane fade in" id="finalizado">
                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvRequerimentoFinalizado" runat="server" CssClass="gridView" DataKeyNames="req_codigo"
                                    AutoGenerateColumns="false"
                                    AutoGenerateEditButton="false">


                                    <AlternatingRowStyle CssClass="alt" />

                                    <%-- Configurar colunas do Grid (Cada TemplateField é uma coluna) --%>
                                    <Columns>

                                        <%--Coluna do Código do Requerimento--%>
                                        <asp:TemplateField HeaderText="Código" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval ("req_codigo")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do assunto do Requerimento--%>
                                        <asp:TemplateField HeaderText="Assunto">                                       
                                            <ItemTemplate>                                                
                                               <asp:LinkButton ID="btnModal" runat="server" Text='<%#Eval ("req_assunto")%>' CommandArgument='<%#Eval ("req_codigo")%>' OnCommand="btnModal_Command" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da categoria do Requerimento--%>
                                        <asp:TemplateField HeaderText="Categoria">                                       
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategoria3" runat="server" Text='<%#Eval ("req_categoria")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Coluna do usuario do Requerimento--%>
                                        <asp:TemplateField HeaderText="Usuario">                                  
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsuario3" runat="server" Text='<%#Eval ("req_usuario")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Data">
                                            <ItemTemplate>
                                                <asp:Label ID="lblData3" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Ultima Modificação">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao32" runat="server" Text='<%#Eval ("req_dt_modificado")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>
                                <asp:Label ID="lblQtdRegistroFin" runat="server"></asp:Label>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Fim das tabs-->

    
</asp:Content>
