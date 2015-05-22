<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuAlterarPerfil.Master" AutoEventWireup="true" CodeBehind="criterios.aspx.cs" Inherits="paginas_Admin_criterios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone3').addClass('corIcone');
        });

        // LIMPAR TEXTBOXS MODAL CADASTRAR CRTITÉRIO 

        function fechaModalCri() {
            $('#txtNomeNovoCriterio').val(" ");
            $('#txtDescricaoNovoCriterio').val(" ");
            $('#lblMsg').html(" ");
        }

        function FechaModalCriacaoCriterio() {
            $('#fecharModal').click();
        }

        function MostraMsgAlerta(){
            $('#alerta').fadeIn(1000);
        }



    </script>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Critérios</h3>
            </div>
            <div class="panel-body">

                <%-- Abas que ficam no topo para escolher entre critérios ativos e desativados--%>
                <ul class="nav nav-tabs" role="tablist">
                    <li class="active"><a href="#ativos" role="tab" data-toggle="tab">Ativos</a></li>
                    <li><a href="#desativados" role="tab" data-toggle="tab">Desativados</a></li>
                </ul>
                <div class="tab-content">

                    <%-- Início do conteúdo da aba Ativos--%>
                    <div role="tabpanel" class="tab-pane fade in active" id="ativos">


                        <%--Grid com UpdatePanel para não atualizar a página inteira ao editar, inserir e desativar critérios--%>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <br />
                                <div class="alert alert-success" role="alert">                                    
                                    <span class="glyphicon glyphicon-ok-circle"></span>
                                <asp:Label ID="lblMsgCriterio" Text="Critério cadastrado com sucesso!" ClientIDMode="Static" runat="server"></asp:Label>
                                <button style="float: right;" data-dismiss="alert"> &times</button>
                                </div>
                                <asp:GridView ID="gdvCriteriosAtivos" runat="server" CssClass="gridView" DataKeyNames="cge_codigo"
                                    AutoGenerateColumns="false"
                                    AutoGenerateEditButton="false"
                                    OnRowUpdating="gdvCriterios_RowUpdating"
                                    OnRowEditing="gdvCriterios_RowEditing"
                                    OnRowCancelingEdit="gdvCriterios_RowCancelingEdit"
                                    OnRowDeleting="gdvCriterios_RowDeleting">


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
                                        <asp:TemplateField HeaderText="Nome do Critério">                                          
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("cge_nome")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Descrição">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>' Width="100%"> </asp:TextBox>
                                                <%--Essa textbox existe para quando for editar aparecer a descrição do critério(O width = 100% deixa a caixa no tamanho máximo até a coluna seguinte--%>
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

                        <%-- Label com quantidade de registros --%>
                        
                        <br />


                        <%--Botão de novo critério--%>
                        <button type="button" class="btn btn-default" id="" data-toggle="modal" data-target="#myModalCadastrarCri" title="Ir para cadastro de critérios">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp Novo Critério
                       
                        </button>
                    </div>



                    <%--Início conteúdo da aba Desativados--%>
                    <div role="tabpanel" class="tab-pane fade" id="desativados">


                        <br />

                        <%--Grid com UpdatePanel para não atualizar a página inteira ao ativar critérios--%>

                        <asp:UpdatePanel ID="UpdatePanelDesativados" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="gdvCriteriosDesativados" runat="server" CssClass="gridView" DataKeyNames="cge_codigo"
                                    AutoGenerateColumns="false"
                                    AutoGenerateEditButton="false"
                                    OnRowUpdating="gdvCriteriosDesativados_RowUpdating">


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
                                        <asp:TemplateField HeaderText="Nome do Critério">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNome" runat="server" Text='<%#Eval ("cge_nome")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna da descrição do Critério Geral--%>
                                        <asp:TemplateField HeaderText="Descrição">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescricao" runat="server" Text='<%#Eval ("cge_descricao")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Coluna do botão de Ativar --%>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="15px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkbAtivar" CssClass="mdi mdi-keyboard-return" title="Reativar" runat="server" CommandName="Update"></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>

                                        </asp:TemplateField>


                                    </Columns>

                                </asp:GridView>
                                <asp:Label ID="lblQtdRegistro2" runat="server"></asp:Label>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                        <%--Fim do Grid--%>

                        <%-- Label com quantidade de registros --%>
                        <asp:Label ID="lblMsg2" Text="" runat="server"></asp:Label><br />
                        
                        <br />

                    </div>
                </div>

            </div>
        </div>


        <!-- Modal Cadastrar Critérios -->

        <div class="modal fade" data-backdrop="static" id="myModalCadastrarCri" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <asp:UpdatePanel ID="UpdatePanelModalNovoCriterio" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" id="fecharModal" onclick="fechaModalCri();" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title" id="myModalLabel3">Cadastrar Critérios</h4>
                            </div>
                            <br />

                            <div class="form-group">
                                <div class="controls-row">
                                    <asp:Label ID="lblNomeNovoCriterio" runat="server" CssClass="control-label col-sm-2" Text="Nome: "></asp:Label>

                                    <asp:TextBox ID="txtNomeNovoCriterio" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server"></asp:TextBox>
                                    <%--Validação do Campo Nome (Verifica se está vazio e se está preenchido com uma string)--%>
                                    &nbsp<asp:RequiredFieldValidator ID="rfvNomeNovoCriterio" runat="server" CssClass="col-sm1" ErrorMessage="O campo Nome deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtNomeNovoCriterio" ValidationGroup="NovoCriterio"></asp:RequiredFieldValidator>


                                </div>
                            </div>

                            <div class="form-group">
                                <div class="controls-row">
                                    <asp:Label ID="lblDescricaoNovoCriterio" runat="server" CssClass="control-label col-sm-2" Text="Descrição: "></asp:Label></td>
                                            
                                               

                                    <asp:TextBox ID="txtDescricaoNovoCriterio" ClientIDMode="Static" CssClass="form-control col-sm-9" Width="50%" runat="server"></asp:TextBox></td>
                                            
                                        

                                    <%--Validação do Campo Descrição (Verifica se está vazio e se está preenchido com uma string)--%>
                                                 &nbsp<asp:RequiredFieldValidator ID="rfvDescricaoNovoCriterio" CssClass="col-sm1" runat="server" ErrorMessage="O campo Descrição deve ser preenchido." ForeColor="#960d10" Text="*" Display="Dynamic" ControlToValidate="txtDescricaoNovoCriterio" ControlToCompare="txtNomeNovoCriterio" ValidationGroup="NovoCriterio"></asp:RequiredFieldValidator>
                                    
                                  
                                </div>
                                <br />
                                   <asp:Label ID="lblMsg" ClientIDMode="Static" CssClass="col-sm-12" runat="server" Text="" Style="font-size: 18px;padding-left:30px;"></asp:Label>
                            </div>
                          
                             
                            <asp:ValidationSummary ID="vsNovoCriterio" ValidationGroup="NovoCriterio" ForeColor="#960d10" runat="server" DisplayMode="List" Style="margin: 7px; padding: 7px;" />




                            <div class="modal-footer">
                                <asp:LinkButton type="button" class="btn btn-default" ID="btnCancelarNovoCriterio" runat="server" title="Cancelar Inserção" OnClick="btnCancelarNovoCriterio_Click">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar</asp:LinkButton>

                                <asp:LinkButton ID="btnCriarNovoCriterio" runat="server" CssClass="btn btn-default"
                                    OnClick="btnCriarNovoCriterio_Click" ToolTip="Confirmar Inserção" CausesValidation="true" ValidationGroup="NovoCriterio">
                                   <span class="glyphicon glyphicon-ok"></span>&nbsp Confirmar </asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>



    </div>

</asp:Content>
