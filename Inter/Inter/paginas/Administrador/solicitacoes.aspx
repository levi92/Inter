<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.Master" AutoEventWireup="true" CodeBehind="solicitacoes.aspx.cs" Inherits="paginas_Admin_solicitacoes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">
    <!--
        TABELA DE CORES DO HEADER
        
        * Não aberto: Vermelho Fatec (#960d10)
        * Aberto, em andamento: Azul (#2196F3)
        * Encerrado, não favorável: Amarelo(#FFEB3B)
        * Encerrado, favorável: Verde (#4CAF50)
        -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone2').addClass('corIcone');
        });
    </script>
    <!--Início do modal de Msg-->
    <div class="modal fade" data-backdrop="static" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <!--A cor do Header muda de acordo com o status-->
                <div class="modal-header" style="background-color: #960d10; color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);">
                    <!--Arrumar o hover aqui-->
                    <button type="button" data-dismiss="modal" style="margin-top: -9px; float: left; border: none; background: none;"><span class="mdi mdi-chevron-left hoverAll" style="font-size: 33px; margin-top: 4.5px;"></span></button>
                    <!--ASSUNTO DO TICKET<h4 class="modal-title" id="myModalLabel1" style="float: left;">--ASSUNtO_DO_TICKET_AQUI--</h4>-->
                    <!--Arrumar  Hover aqui-->
                    <button type="button" id="butMostraMenu" name="subMenu" onclick="mostraDiv1('subMenu')" style="float: right; border: none; background: none; margin-top: -2px;"><span class="mdi mdi-dots-vertical hoverAll" style="font-size: 25px;"></span></button>
                    <!--NOME DO PROFESSOR QUE ABRIU O TICKET<h4 style="float: right; margin-top: 0; padding-right: 10px;">--NOME_DO_PROFESSOR_AQUI--</h4>-->
                </div>
                <!--Início 3-dot menu-->
                <!--Início do submenu-->
                <div class="subMenu" id="subMenu">
                    <!--Clicar em um item fecha o menu | ESC fecha o menu sem fechar a modal-->
                    <div onclick="butAcao()">Finalizar Favorável</div>
                    <div onclick="butAcao()">Finalizar Desfavorável</div>
                    <div onclick="butAcao()">PI Finalizado</div>
                </div>
                <!--Fim do submenu-->
                <!--Fim 3-dot menu-->
                <!--Início do Corpo-->
                <div class="modal-body" style="background-color: whitesmoke;">
                    <div class="insideBox">
                        <!--Mensagem
                            Cada mensagem do banco deve ter seu bloco de mensagem.
                            As mensagens do usuario sempre aparecem à direita e a dos outros à esquerda
                        <div class="allMsg" style="float: left">
                            <div class="txtCard" onclick="mostraInfo(1)">--MSG_AQUI--.</div>
                            <div id="info1" class="infoMsg">Enviado por Jusjiscreudo - As 20:72</div>
                        </div>-->
                    </div>
                </div>
                <!--Fim do corpo-->
                <div class="modal-footer" style="text-align: left; background-color: whitesmoke; border-top: none">
                    <asp:TextBox runat="server" ID="txtResponder" TextMode="MultiLine" CssClass="minimalScrollbar"></asp:TextBox>
                    <!--Colocar hoover aqui-->
                    <div style="float: right; width: 50px; text-align: center; height: 50px; border-radius: 100px; background-color: #960D10; box-shadow: 0 2px 5px 3px rgba(0, 0, 0, 0.16);"><span class="mdi mdi-send" style="color: #fff; padding-top: 7px; padding-left: 5px; font-size: 35px;"></span></div>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do modal de Msg-->
    <!--Início do modal de novo ticket-->

    


    <div class="modal fade" data-backdrop="static" id="myModal3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 30%;">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #960d10; color: #fff; border-bottom: none; height: 54px; position: absolute; z-index: 999; width: 100%; box-shadow: 0px 2px 10px 0px rgba(0, 0, 0, 0.26);">
                    <!--Arrumar o hover aqui-->
                    <button type="button" data-dismiss="modal" style="margin-top: -9px; float: left; border: none; background: none;"><span class="mdi mdi-chevron-left hoverAll" style="font-size: 33px; margin-top: 4.5px;"></span></button>
                    <h4 class="modal-title" id="myModalLabel1" style="float: left;">Novo Ticket</h4>
                </div>
                <!--Início do Corpo-->
                <div class="modal-body" style="background-color: whitesmoke; padding-top: 100px;">
                    <select id="dropDownListTipoTicket" runat="server" style="border-top: none; border-left: none; border-right: none; border-bottom-color: #2196f3; border-bottom-width: 2px; height: 30px; background-color: whitesmoke;">
                        <option disabled="disabled" selected="selected" value="Tipo"></option>
                        <option value="Alteração de nota" style="background-color: whitesmoke"></option>
                        <option value="Problema com cadastro" style="background-color: whitesmoke"></option>
                        <option value="Problema com avaliações" style="background-color: whitesmoke"></option>
                        <option value="Sugestão" style="background-color: whitesmoke"></option>
                        <option value="Outros" style="background-color: whitesmoke"></option>
                    </select>
                    <asp:Label ID="New" runat="server" placeholder="Assunto" Style="border-top: none; border-left: none; border-right: none; border-bottom-color: #2196f3; background-color: whitesmoke; height: 30px;" ></asp:Label>
                    <asp:ValidationSummary ID="vsNovoTicket" ValidationGroup="NovoTicket" ForeColor="#960d10" runat="server" DisplayMode="List" Style="margin: 7px; padding: 7px;" />
                </div>
                <!--Fim do corpo-->
                <div class="modal-footer" style="text-align: left; background-color: whitesmoke; border-top: none">
                    <asp:LinkButton runat="server" ID="btnCriarNovoTicket" OnClick="btnCriarNovoTicket_Click" data-dismiss="modal"  ToolTip="Confirmar Inserção" CausesValidation="true" ValidationGroup="NovoTicket" data-toggle='modal' data-target='#myModal1' style="float: right; float: right; height: 30px; width: 90px; box-shadow: 0 1px 5px 0px rgba(0, 0, 0, 0.26); color: white; background-color: #2196F3; border: none;">
                        Confirmar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <!--Fim do modal de novo Ticket-->
    <!--Início das Tabs-->
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
                    <!--Placeholder, isso vai no usuário--><li><a data-toggle='modal' data-target='#myModal2'>Nova Solicitação</a></li>
                </ul>
                <div class="tab-content">
                    <!-- SOLICITACAO EM ABERTO -->
                    <div role="tabpanel" class="tab-pane fade in active" id="geral">
                        <%--Grid com UpdatePanel para não atualizar a página inteira ao editar, inserir e desativar solicitacoes--%>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvRequerimentoAberto" runat="server" CssClass="gridView" DataKeyNames="req_codigo"
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
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_assunto")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                         
                                            <ItemTemplate>
                                                <a data-toggle='modal' data-target='#myModal1'><asp:Label ID="lblNome" runat="server" Text='<%#Eval ("req_assunto")%>'></asp:Label></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da categoria do Requerimento--%>
                                        <asp:TemplateField HeaderText="Categoria">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_categoria")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("req_categoria")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Coluna do usuario do Requerimento--%>
                                        <asp:TemplateField HeaderText="Usuario">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("pro_matricula")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("pro_matricula")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Data">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
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
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_assunto")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                         
                                            <ItemTemplate>
                                                <a data-toggle='modal' data-target='#myModal1'><asp:Label ID="lblNome" runat="server" Text='<%#Eval ("req_assunto")%>'></asp:Label></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da categoria do Requerimento--%>
                                        <asp:TemplateField HeaderText="Categoria">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_categoria")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("req_categoria")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Coluna do usuario do Requerimento--%>
                                        <asp:TemplateField HeaderText="Usuario">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("pro_matricula")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("pro_matricula")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Data">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
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
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_assunto")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                         
                                            <ItemTemplate>
                                                <a data-toggle='modal' data-target='#myModal1'><asp:Label ID="lblNome" runat="server" Text='<%#Eval ("req_assunto")%>'></asp:Label></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da categoria do Requerimento--%>
                                        <asp:TemplateField HeaderText="Categoria">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_categoria")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("req_categoria")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Coluna do usuario do Requerimento--%>
                                        <asp:TemplateField HeaderText="Usuario">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("pro_matricula")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("pro_matricula")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Data">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
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

    <div class="modal fade" data-backdrop="static" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
              <asp:UpdatePanel ID="UpdatePanelModalNovoRequerimento" UpdateMode="Conditional" runat="server">
                <ContentTemplate>             
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" id="fecharModal" onclick="fechaModalCri();" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title" id="myModalLabel3">Cadastrar Solicitações</h4>
                            </div>
                            <br />

                            <div class="form-group">
                                <div class="controls-row">
                                    <asp:Label ID="lblAssuntoNovoRequerimento" runat="server" CssClass="control-label col-sm-2" Text="Assunto: "></asp:Label>                                    
                                    <asp:TextBox ID="txtAssunto" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server"></asp:TextBox>
                                    
                                    <%--Validação do Campo Assunto (Verifica se está vazio e se está preenchido com uma string)--%>
                                    &nbsp<asp:RequiredFieldValidator ID="rfvAssuntoNovoRequerimento" runat="server" CssClass="col-sm1" ErrorMessage="O campo Assunto deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtAssunto" ValidationGroup="NovoRequerimento"></asp:RequiredFieldValidator>
                                    
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="controls-row">

                                    <asp:Label ID="lblCategoriaNovoRequerimento" runat="server" CssClass="control-label col-sm-2" Text="Categoria: "></asp:Label></td>    
                                    <asp:DropDownList ID="txtCategoria" ClientIDMode="Static" CssClass="form-control col-sm-9"  Width="50%" runat="server">
                                        <asp:ListItem>Alteração de notas</asp:ListItem>
                                        <asp:ListItem>Problema com cadastros</asp:ListItem>
                                        <asp:ListItem>Problema com avaliações</asp:ListItem>
                                        <asp:ListItem>Sugestão</asp:ListItem>
                                    </asp:DropDownList></td>
                                   
                                     <%--Validação do Campo Categoria (Verifica se está vazio e se está preenchido com uma string)--%>
                                     &nbsp<asp:RequiredFieldValidator ID="rfvCategoriaNovoRequerimento" CssClass="col-sm1" runat="server" ErrorMessage="O campo Categoria deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtCategoria" ValidationGroup="NovoRequerimento"></asp:RequiredFieldValidator>
                                   
                                </div>
                                   <asp:Label ID="lblMsg" ClientIDMode="Static" CssClass="col-sm-12" runat="server" Text="" Style="font-size: 18px;padding-left:30px;"></asp:Label>
                            </div>
                          
                             
                            <asp:ValidationSummary ID="vsNovoRequerimento" ValidationGroup="NovoRequerimento" ForeColor="#960d10" runat="server" DisplayMode="List" Style="margin: 7px; padding: 7px;" />

                            <div class="modal-footer">
                                <asp:LinkButton type="button" class="btn btn-default" ID="btnCancelarNovoRequerimento" runat="server" title="Cancelar Inserção" OnClick="btnCancelarNovoCriterio_Click">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                                <asp:LinkButton ID="btnCriarNovoRequerimento" OnClick="btnCriarNovoTicket_Click" runat="server" CssClass="btn btn-default" ToolTip="Confirmar Inserção" CausesValidation="true" ValidationGroup="NovoRequerimento">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                            </div>

                        </div>
                    </div>
                  </ContentTemplate>
              </asp:UpdatePanel>
        </div>
</asp:Content>
