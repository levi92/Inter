<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPageMenuPadrao.master" AutoEventWireup="true" Inherits="paginas_Usuario_escolherDisciplina" CodeBehind="escolherDisciplina.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudoCentral" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
        // MODAL DIALOG - SOLICITA A ESCOLHA DE UMA DISCIPLINA SE O USUÁRIO NÃO ESCOLHER NENHUMA
        // CHAMANDO ESSA MODAL E CONFIGURANDO 
        // CRIANDO AS CONFIGURAÇÕES DA MODAL
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
                <%-- UPDATEPANEL UTILIZADO POR CAUSA DO RADIO BUTTON QUE ESTAVA ATUALIZANDO A PÁGINA --%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gdv" runat="server" CellPadding="4" GridLines="None" CssClass="tableEscolherDisciplina"
                            AutoGenerateColumns="false"
                            OnRowDataBound="gdv_RowDataBound">

                            <AlternatingRowStyle CssClass="alt" />

                            <%-- CONFIGURAR COLUNAS DO GRID --%>
                            <Columns>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:RadioButton runat="server" ID="rb" GroupName="Grupo"
                                            OnCheckedChanged="rb_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Curso"></asp:TemplateField>

                                <asp:TemplateField HeaderText="Semestre"></asp:TemplateField>

                                <asp:TemplateField HeaderText="Disciplina"></asp:TemplateField>

                                <asp:BoundField DataField="tipo" HeaderText="Mãe / Filha" />

                                <asp:boundfield datafield="atr_codigo" headertext="Código" />


                            </Columns>

                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%-- LABEL COM QUANTIDADE DE REGISTROS --%>
                <asp:Label ID="lblQtdRegistro" runat="server"></asp:Label>
                <br />
                <br />

                <%-- BOTÃO PARA CONFIRMAR --%>
                <asp:LinkButton ID="btnConfirmar" runat="server" CssClass="btn btn-default" OnClick="btnConfirmar_Click">
                      <i aria-hidden="true" class="glyphicon glyphicon-ok"></i>&nbsp Confirmar
                </asp:LinkButton>

                <%-- LEGENDA --%>
                <section style="float: right; margin-right: 20px; border: 1px solid #CCC; padding: 15px; border-radius: 5px;">
                    <h4 style="margin-top: -7px;">Legenda</h4>
                    <span class="glyphicon glyphicon-star"></span>&nbsp- Disciplina Mãe
                            <br />
                    <span class="glyphicon glyphicon-minus"></span>&nbsp- Disciplina Filha                           
                </section>

            </div>
        </div>
    </div>


    <!-- MODAL DIALOG - CONFIGURANDO O TEXTO QUE VAI APARECER -->
    <div id="boxSelecioneDisc" title="Selecione uma disciplina!" style="display: none;">
        <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Para prosseguir você deve selecionar uma disciplina! </p>
    </div>




</asp:Content>
