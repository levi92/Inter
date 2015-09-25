<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_notificacoes" CodeBehind="notificacoes.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="server">
    <!--
        TABELA DE CORES DO HEADER
        
        * Não aberto: Vermelho Fatec (#960d10)
        * Aberto, em andamento: Azul (#2196F3)
        * Encerrado, não favorável: Amarelo(#FFEB3B)
        * Encerrado, favorável: Verde (#4CAF50)
        -->
    <script type="text/javascript" src="../../scripts/bootstrap.js"></script>
    <script src="../../scripts/inter.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#cphConteudo_icone3').addClass('corIcone');
        });
        function fechaModalClick() {
            $('#fecharModal').click();
        }
        function openModal() {
            $('#myModal1').modal('show');
        }
        function fechaModalCri() {
            $('#txtAssunto').val(" ");
            $('#lblMsg').html(" ");
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
                            <button type="button" data-dismiss="modal" style="margin-right: 10px; margin-top: -9px; float: left; border: none; background: none;"><span class="mdi mdi-close" style="font-size: 33px; margin-top: 4.5px;"></span></button>
                            <!--ASSUNTO DO TICKET-->
                            <h4 class="modal-title" id="myModalLabelT1" style="float: left;">
                                <asp:Label ID="lblMsgAssunto" runat="server"></asp:Label>
                                -
                                <asp:Label ID="lblMsgCategoria" runat="server"></asp:Label>
                                ( 
                                <asp:Label ID="lblMsgStatus" runat="server"></asp:Label>
                                )</h4>
                            <!--Arrumar  Hover aqui-->
                            <button type="button" id="butMostraMenu" name="subMenu" onclick="mostraDiv1('subMenu')" style="float: right; border: none; background: none; margin-top: -2px;"><span class="mdi mdi-dots-vertical hoverAll" style="font-size: 25px;"></span></button>
                            <!--NOME DO PROFESSOR QUE ABRIU O TICKET-->

                            <h4 style="float: right; margin-top: 0; padding-right: 10px;">
                                <asp:Label ID="lblMsgProfessor" runat="server"></asp:Label></h4>
                        </div>
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
                            <asp:TextBox runat="server" ID="txtResponder" TextMode="MultiLine" CssClass="minimalScrollbar"></asp:TextBox>
                            <!--Colocar hoover aqui-->
                            <div style="float: right; width: 50px; text-align: center; height: 50px; border-radius: 100px; background-color: #960D10; box-shadow: 0 2px 5px 3px rgba(0, 0, 0, 0.16);">
                                <asp:LinkButton ID="btnNovaMsg" runat="server" Text="Enviar" Style="padding-top: 14px; padding-left: 6px; color: white; float: left;" OnClick="btnNovaMsg_Click"></asp:LinkButton>
                                <!--<spano style='color: #fff; padding-top: 7px; padding-left: 5px; font-size: 35px;'></span>-->
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <!--Fim do modal de Msg-->



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

                </ul>
                <div class="tab-content">

                    <!-- SOLICITACAO EM ABERTO -->
                    <div role="tabpanel" class="tab-pane fade in active" id="geral">
                        <%--Grid com UpdatePanel para não atualizar a página inteira ao editar, inserir e desativar solicitacoes--%>

                        <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvRequerimentoAberto" runat="server" CssClass="tableEscolherDisciplina" DataKeyNames="req_codigo"
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
                                        <%--   <asp:TemplateField HeaderText="Usuario">                                   
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsuario1" runat="server" Text='<%#Eval ("req_usuario")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <%--Coluna da descrição da data do Requerimento--%>
                                        <asp:TemplateField HeaderText="Data de Envio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao1" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição da data de última modificação--%>
                                        <asp:TemplateField HeaderText="Ultima Modificação">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescr4icao2" runat="server" Text='<%#Eval ("req_dt_modificado")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>

                                <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                        <%--Fim do Grid--%>
                    </div>
                    <br />

                    <!-- TICKETS EM ANDAMENTO -->
                    <div role="tabpanel" class="tab-pane fade in" id="andamento">
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvRequerimentoAndamento" runat="server" CssClass="tableEscolherDisciplina" DataKeyNames="req_codigo"
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
                                                <asp:Label ID="lblDa3ta2" runat="server" Text='<%#Eval ("req_dt_requisicao")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Ultima Modificação">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDes2cricao2" runat="server" Text='<%#Eval ("req_dt_modificado")%>'></asp:Label>
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
                                <asp:GridView ID="gdvRequerimentoFinalizado" runat="server" CssClass="tableEscolherDisciplina" DataKeyNames="req_codigo"
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
                                                <asp:Label ID="lblDesscricao2" runat="server" Text='<%#Eval ("req_dt_modificado")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>
                                <asp:Label ID="lblQtdRegistroFin" runat="server"></asp:Label>

                            </ContentTemplate>

                        </asp:UpdatePanel>


                    </div>


                    <%--Botão de nova solicitação--%>
                    <div>
                        <button type="button" class="btn btn-default" id="btNovaSolicitacao" data-toggle="modal" data-target="#myModal2" title="Cadastrar Nova Solicitação">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp Nova Solicitação
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Fim das tabs-->

    <!--Início do modal de novo ticket-->
    <div class="modal fade" data-backdrop="static" id="myModal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <asp:UpdatePanel ID="UpdatePanelModalNovoRequerimento" UpdateMode="Conditional" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtCategoria"
                    EventName="SelectedIndexChanged" />
            </Triggers>

            <ContentTemplate>
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" id="fecharModal" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title" id="myModalLabel3">Nova Solicitação</h4>
                        </div>
                        <br />

                        <div class="form-group">
                            <div class="controls-row">

                                <asp:Label ID="lblCategoriaNovoRequerimento" runat="server" CssClass="control-label col-sm-2" Text="Categoria: "></asp:Label></td>    
                                    <asp:DropDownList ID="txtCategoria" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="txtCategoria_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                   
                                     <%--Validação do Campo Categoria (Verifica se está vazio e se está preenchido com uma string)--%>
                                     &nbsp<asp:RequiredFieldValidator ID="rfvCategoriaNovoRequerimento" CssClass="col-sm1" runat="server" ErrorMessage="O campo Categoria deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtCategoria" ValidationGroup="NovoRequerimento"></asp:RequiredFieldValidator>

                            </div>

                        </div>

                        <div class="form-group">
                            <div class="controls-row">
                                <asp:UpdatePanel ID="UpdatePanelGrupos" UpdateMode="Conditional" runat="server">

                                    <ContentTemplate>
                                        <asp:Label ID="lblGrupo" runat="server" CssClass="control-label col-sm-2" Text="Grupo: " Visible="false"></asp:Label></td>    
                                     <asp:DropDownList ID="ddlGrupo" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged" Visible="false">
                                     </asp:DropDownList></td>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%--Validação do Campo Categoria (Verifica se está vazio e se está preenchido com uma string)--%>
                                     &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="col-sm1" runat="server" ErrorMessage="O campo Categoria deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtCategoria" ValidationGroup="NovoRequerimento"></asp:RequiredFieldValidator>

                            </div>

                        </div>

                        <div class="form-group">
                            <div class="controls-row">
                                <asp:Label ID="lblAssuntoNovoRequerimento" runat="server" CssClass="control-label col-sm-2" Text="Assunto: "></asp:Label>
                                <asp:TextBox ID="txtAssunto" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server"></asp:TextBox>

                                <%--Validação do Campo Assunto (Verifica se está vazio e se está preenchido com uma string)--%>
                                    &nbsp<asp:RequiredFieldValidator ID="rfvAssuntoNovoRequerimento" runat="server" CssClass="col-sm1" ErrorMessage="O campo Assunto deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtAssunto" ValidationGroup="NovoRequerimento"></asp:RequiredFieldValidator>
                                &nbsp<asp:RequiredFieldValidator ID="rfvDescricaoNovoRequerimento" runat="server" CssClass="col-sm1" ErrorMessage="O campo Descrição deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtaMsg" ValidationGroup="NovoRequerimento"></asp:RequiredFieldValidator>

                            </div>
                            </br>
                                 <div class="input-group">
                                     <asp:Label ID="lblDescricao" runat="server" CssClass="control-label col-sm-9" Text="Descrição: "></asp:Label>
                                     <textarea id="txtaMsg" cols="20" rows="2" runat="server" cssclass="form-control-sm-2" placeholder="Descreva seu problema aqui..." style="border-top: none; border-left: none; border-right: none; background-color: whitesmoke; width: 120%; height: 150px; margin-left: 40%"></textarea>
                                 </div>
                            <asp:Label ID="lblMsg" ClientIDMode="Static" CssClass="col-sm-12" runat="server" Text="" Style="font-size: 18px; padding-left: 30px;"></asp:Label>
                        </div>

                        <asp:ValidationSummary ID="vsNovoRequerimento" ValidationGroup="NovoRequerimento" ForeColor="#960d10" runat="server" DisplayMode="List" Style="margin: 7px; padding: 7px;" />

                        <div class="modal-footer">
                            <asp:LinkButton type="button" class="btn btn-default" ID="btnCancelarNovoRequerimento" runat="server" title="Cancelar Inserção" OnClick="btnCancelarNovaSolicitacao_Click">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                            <asp:LinkButton ID="btnCriarNovoRequerimento" OnClick="btnCriarNovoTicket_Click" runat="server" CssClass="btn btn-default" ToolTip="Confirmar Inserção" CausesValidation="true" ValidationGroup="NovoRequerimento">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!--Fim do modal de novo ticket-->

</asp:Content>
