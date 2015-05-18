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
                    <!--O ícone de prioridade sera definido com base na opção de prioridade escolhida-->
                    <div onclick="toggleDiv('subMenuPrioridade')">Prioridade<span class="mdi mdi-alert" style="float: right; color: yellow; font-size: 20px"></span></div>
                </div>
                <!--Fim do submenu-->
                <!--Início do submenu de prioridade-->
                <!--Animação de deslizar para abrir e fechar o menu | prioridade que esta escolhida como padrão deve aparecer como desabilitada na hora da escolha-->
                <div id="subMenuPrioridade" class="subMenuPrioridade" style="display: none">
                    <div>Prioridade</div>
                    <div onclick="butAcao()">Normal<span class="mdi mdi-alert" style="float: right; color: green; font-size: 20px"></span></div>
                    <div onclick="butAcao()">Média<span class="mdi mdi-alert" style="float: right; color: yellow; font-size: 20px"></span></div>
                    <div onclick="butAcao()">Alta<span class="mdi mdi-alert" style="float: right; color: red; font-size: 20px"></span></div>
                </div>
                <!--Fim do submenu de prioridade-->
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
                <h3 class="panel-title">Tickets</h3>
            </div>
            <div class="panel-body">
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#geral" role="tab" data-toggle="tab">Aberto</a></li>
                    <li><a href="#andamento" role="tab" data-toggle="tab">Em Andamento</a></li>
                    <li><a href="#finalizado" role="tab" data-toggle="tab">Finalizado</a></li>
                    <!--Placeholder, isso vai no usuário--><li><a data-toggle='modal' data-target='#myModal2'>Novo Ticket</a></li>
                </ul>
                <div class="tab-content">
                    <!-- TICKETS EM ABERTO -->
                    <div role="tabpanel" class="tab-pane fade in active" id="geral">
                        <%--Grid com UpdatePanel para não atualizar a página inteira ao editar, inserir e desativar solicitacoes--%>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <br />
                        <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#myModal2" title="Ir para cadastro de critérios">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp Nova Solicitação
                       
                        </button>
                        <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvCriteriosAtivos" runat="server" CssClass="gridView" DataKeyNames="cge_codigo"
                                    AutoGenerateColumns="false"
                                    AutoGenerateEditButton="false"
                                    OnRowUpdating="gdvCriterios_RowUpdating"
                                    OnRowEditing="gdvCriterios_RowEditing"
                                    OnRowCancelingEdit="gdvCriterios_RowCancelingEdit">


                                    <AlternatingRowStyle CssClass="alt" />

                                    <%-- Configurar colunas do Grid (Cada TemplateField é uma coluna) --%>
                                    <Columns>

                                        <%--Coluna do Código do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Código" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval ("cge_codigo")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do nome do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Assunto"> 
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                         
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("cge_nome")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do nome do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Categoria">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("cge_nome")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--Coluna do nome do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Usuario">  
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>                                        
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("cge_nome")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Data">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'> </asp:TextBox>                                                
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do botão de Editar (o lápis) --%>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="15px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkbEditar" CssClass="glyphicon glyphicon-pencil" title="Editar" runat="server" CommandName="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lkbAtualizar" CssClass="glyphicon glyphicon-ok" title="Confirmar" CommandName="Update" runat="server"></asp:LinkButton>
                                                <%--Essa linha e a debaixo são os botões que aparecem quando se clica no botão Editar de cima--%>
                                                <asp:LinkButton ID="lkbCancelar" CssClass="glyphicon glyphicon-remove" title="Cancelar" CommandName="Cancel" runat="server"></asp:LinkButton>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do botão de desativar --%>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="15px">
                                            <ItemTemplate>
                                                <span onclick="return confirm('Tem certeza que deseja desativar este critério?')">
                                                    <asp:LinkButton ID="lkbExcluir" CssClass="glyphicon glyphicon-trash" Title="Desativar" runat="server" CommandName="Delete"></asp:LinkButton>
                                                </span>
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
                        <div class="panel-body">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <td>Assunto</td>
                                        <td>Tipo</td>
                                        <td>Usuário</td>
                                        <td>Data</td>
                                        <td>Prioridade</td>
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
                                        <td>Tipo</td>
                                        <td>Usuário</td>
                                        <td>Data</td>
                                        <td>Prioridade</td>
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
    <!--Fim das tabs-->

    <div class="modal fade" data-backdrop="static" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
              <asp:UpdatePanel ID="UpdatePanelModalNovoCriterio" UpdateMode="Conditional" runat="server">
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
                                    <asp:Label ID="lblNomeNovoCriterio" runat="server" CssClass="control-label col-sm-2" Text="Nome: "></asp:Label>

                                    <asp:TextBox ID="txtAssunto" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server"></asp:TextBox>
                                    <%--Validação do Campo Nome (Verifica se está vazio e se está preenchido com uma string)--%>
                                    &nbsp<asp:RequiredFieldValidator ID="rfvNomeNovoCriterio" runat="server" CssClass="col-sm1" ErrorMessage="O campo Nome deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtAssunto" ValidationGroup="NovoCriterio"></asp:RequiredFieldValidator>


                                </div>
                            </div>

                            <div class="form-group">
                                <div class="controls-row">

                                    <asp:Label ID="lblDescricaoNovoCriterio" runat="server" CssClass="control-label col-sm-2" Text="Categoria: "></asp:Label></td>
                                            
                                               

                                    <asp:TextBox ID="txtDescricaoNovoCriterio" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server"></asp:TextBox></td>
                                            
                                        

                                    <%--Validação do Campo Descrição (Verifica se está vazio e se está preenchido com uma string)--%>
                                                 &nbsp<asp:RequiredFieldValidator ID="rfvDescricaoNovoCriterio" CssClass="col-sm1" runat="server" ErrorMessage="O campo Descrição deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtDescricaoNovoCriterio" ControlToCompare="txtNomeNovoCriterio" ValidationGroup="NovoCriterio"></asp:RequiredFieldValidator>
                                    
                                  
                                </div>
                                <br />
                                   <asp:Label ID="lblMsg" ClientIDMode="Static" CssClass="col-sm-12" runat="server" Text="" Style="font-size: 18px;padding-left:30px;"></asp:Label>
                            </div>
                          
                             
                            <asp:ValidationSummary ID="vsNovoCriterio" ValidationGroup="NovoCriterio" ForeColor="#960d10" runat="server" DisplayMode="List" Style="margin: 7px; padding: 7px;" />




                            <div class="modal-footer">
                                <asp:LinkButton type="button" class="btn btn-default" ID="btnCancelarNovoCriterio" runat="server" title="Cancelar Inserção">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                                <asp:LinkButton ID="btnCriarNovoCriterio" runat="server" CssClass="btn btn-default"
                                    ToolTip="Confirmar Inserção" CausesValidation="true" ValidationGroup="NovoCriterio">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                            </div>

                        </div>
                    </div>
                    </ContentTemplate>
                 </asp:UpdatePanel>
        </div>
</asp:Content>
