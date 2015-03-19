<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_escolherDisciplina" Codebehind="escolherDisciplina.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">
    <script type="text/javascript">
        
        // Modal Dialog - solicita a escolha de uma disciplina se o usuário não escolher nenhuma
        // Chamando essa modal e configurando 
        // Criando as configurações da modal
        function modalEscolherDis() {
            $(function () {
                $("#boxSelecioneDisc").dialog({
                    width: 400,
                    height: 200,
                    modal: true,
                    resizable: false,
                    draggable: false,
                    buttons: {
                        "OK": function () {
                            $(this).dialog("close");
                        }
                    }


                });
            });
        }
    </script>

    <!-- ESCOLHER DISCIPLINA -->
    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Escolha uma Disciplina</h3>
            </div>

            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <%-- UpdatePanel utilizado por causa do radio button que estava atualizando a página --%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gdv" runat="server" CellPadding="4" GridLines="None" CssClass="gridView"
                            AutoGenerateColumns="false"
                            OnRowDataBound="gdv_RowDataBound">

                            <AlternatingRowStyle CssClass="alt" />

                            <%-- Configurar colunas do Grid --%>
                            <Columns>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:RadioButton runat="server" ID="rb" GroupName="Grupo"
                                            OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="cur_sigla" HeaderText="Curso" />
                                <asp:BoundField DataField="trm_nome" HeaderText="Semestre" />
                                <asp:BoundField DataField="dge_sigla" HeaderText="Disciplina" />
                                <asp:BoundField DataField="adi_mae" HeaderText="Disciplina Mãe" />

                            </Columns>

                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%-- Label com quantidade de registros --%>
                <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>
                <br />
                <br />

                <%-- Botão para confirmar --%>
                <asp:LinkButton ID="btnConfirmar" runat="server" CssClass="btn btn-default" OnClick="btnConfirmar_Click">
                      <i aria-hidden="true" class="glyphicon glyphicon-ok"></i>&nbsp Confirmar
                </asp:LinkButton>

                <%-- Legenda --%>
                <section style="float: right; margin-right: 20px; border: 1px solid #CCC; padding: 15px; border-radius: 5px;">
                    <h4 style="margin-top: -7px;">Legenda</h4>
                    <span class="glyphicon glyphicon-star"></span>&nbsp- Disciplina Mãe
                            <br />
                    <span class="glyphicon glyphicon-minus"></span>&nbsp- Disciplina Filha                           
                </section>

            </div>
        </div>
    </div>

    
    <!-- Modal dialog - configurando o texto que vai aparecer -->
    <div id="boxSelecioneDisc" title="Selecione uma disciplina!" style="display: none;">
        <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Para prosseguir você deve selecionar uma disciplina! </p>
    </div>

    


</asp:Content>
