<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Usuario/MasterPage.master" AutoEventWireup="true" Inherits="paginas_Usuario_escolherDisciplina" Codebehind="escolherDisciplina.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
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
                            //alert("Tem certeza?");                                    
                            $(this).dialog("close");
                        }
                    }


                });
            });
        }
    </script>

    <!-- ESCOLHER DISCIPLINA (P1) -->
    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Escolha uma Disciplina</h3>
            </div>

            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gdv" runat="server" CellPadding="4" GridLines="None" CssClass="gridView"
                            AutoGenerateColumns="false"
                            OnRowDataBound="gdv_RowDataBound">

                            <AlternatingRowStyle CssClass="alt" />
                            <HeaderStyle />
                            <FooterStyle />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle />
                            <SelectedRowStyle BackColor="Orange" Font-Bold="True" ForeColor="Navy" />

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

                <asp:Label ID="lblQtdRegistro" runat="server" Text="Label"></asp:Label>
                <br />
                <br />

                <asp:LinkButton ID="btnConfirmar" runat="server" CssClass="btn btn-default" OnClick="btnConfirmar_Click">
                      <i aria-hidden="true" class="glyphicon glyphicon-ok"></i>&nbsp Confirmar
                </asp:LinkButton>

                <section style="float: right; margin-right: 20px; border: 1px solid #CCC; padding: 15px; border-radius: 5px;">
                    <h4 style="margin-top: -7px;">Legenda</h4>
                    <span class="glyphicon glyphicon-star"></span>&nbsp- Disciplina Mãe
                            <br />
                    <span class="glyphicon glyphicon-minus"></span>&nbsp- Disciplina Filha                           
                </section>

            </div>
        </div>
    </div>


    <!-- dialogs -->
    <div id="boxSelecioneDisc" title="Selecione uma disciplina!" style="display: none;">
        <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>&nbsp Para prosseguir você deve selecionar uma disciplina! </p>
    </div>




</asp:Content>

