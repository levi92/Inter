<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuAlterarPerfil.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="paginas_Admin_usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone4').addClass('corIcone');
        });
    </script>

        

    <div id="p1" class="first">

           <asp:UpdateProgress ID="upgAdmin" runat="server" AssociatedUpdatePanelID="UpdatePanelAdmin">
                    <ProgressTemplate>
                        <div class="modalLoader">
                            <div class="modalCenter">
                                <img alt="Carregando" src="../../App_Themes/images/ajax-loader.gif" /><br />
                                
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                 <asp:UpdateProgress ID="upgProf" runat="server" AssociatedUpdatePanelID="UpdatePanelProf">
                    <ProgressTemplate>
                        <div class="modalLoader">
                            <div class="modalCenter">
                              <img alt="Carregando" src="../../App_Themes/images/ajax-loader.gif" />
                              
                         
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

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

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanelAdmin" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblMsgAdmin" Text="" runat="server"></asp:Label>
                                <asp:GridView ID="gdvAdmin" runat="server" CssClass="gridView" AllowPaging="true" DataKeyNames="per_matricula" PageSize="10"
                                    OnRowUpdating="gdvAdmin_RowUpdating"
                                    AutoGenerateColumns="false">

                                    <AlternatingRowStyle CssClass="alt" />


                                    <Columns>
                                        <%--Configurar colunas do Grid --%>

                                        <asp:TemplateField HeaderText="Matrícula">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMatriculaAdmin" Text='<%#Eval ("per_matricula") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNomeAdmin" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkbDesfAdm" runat="server" CssClass="mdi mdi-account-remove" Font-Size="2em" Title="Desativar Admin" CommandName="Update"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>


                                </asp:GridView>
                                <asp:Label ID="lblQtdRegistroAdm" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <!-- Fim Conteudo Aba Admin !-->

                    <!-- Conteudo Aba Professores  !-->

                    <div role="tabpanel" class="tab-pane fade" id="professor">


                        <asp:UpdatePanel ID="UpdatePanelProf" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblMsgProf" Text="" runat="server"></asp:Label>
                                <asp:GridView ID="gdvProf" runat="server" CellPadding="4" GridLines="None" DataKeyNames="pro_matricula" CssClass="gridView" AllowPaging="true" PageSize="10"
                                    OnRowCommand="gdvProf_RowCommand"
                                    OnRowDataBound="gdvProf_RowDataBound"
                                    OnPageIndexChanging="gdvProf_PageIndexChanging"
                                    AutoGenerateColumns="false">

                                    <AlternatingRowStyle CssClass="alt" />


                                    <Columns>
                                        <%-- Configurar colunas do Grid --%>


                                        <asp:BoundField DataField="pro_matricula" HeaderText="Matrícula" />
                                        <asp:BoundField DataField="pes_nome" HeaderText="Nome" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lkbDefAdm" Visible="true" runat="server" CssClass="mdi mdi-account-star" Font-Size="2em" title="Definir como Admin" CommandName="DefinirAdm"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                </asp:GridView>

                                <asp:Label ID="lblQtdRegistroProf" runat="server"></asp:Label>
                            </ContentTemplate>

                        </asp:UpdatePanel>

                    </div>
                </div>
                <!-- Fim Conteudo Aba Professores !-->


            </div>

        </div>
    </div>

</asp:Content>

