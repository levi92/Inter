<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuCoord.master" AutoEventWireup="true" CodeBehind="projetos.aspx.cs" Inherits="paginas_Admin_projetos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone5').addClass('corIcone');
        });
    </script>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Projetos</h3>
            </div>
            <div class="panel-body">
               

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">

                            <ContentTemplate>
                                <div class="row" style="margin-top:8px;margin-left:2px;">

                                     <div class="col-md-3" style="top:6px;">
                                         Curso
                                        <asp:DropDownList ID="ddlCurso" CssClass="dropdown" ToolTip="Curso" runat="server">
                                        <asp:ListItem>Todos</asp:ListItem>
                                        </asp:DropDownList>                                        
                                    </div>
                                    <div class="col-md-3" style="top:6px;">
                                        Ano
                                        <asp:DropDownList ID="ddlSemestreAno" CssClass="dropdown" runat="server">
                                       <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="input-group">

                                            <asp:TextBox ID="txtBusca" runat="server" CssClass="form-control" TextMode="Search" placeholder="Pesquisa avançada" MaxLength="200"></asp:TextBox>

                                            <div class="input-group-addon">
                                                <asp:LinkButton ID="lkbBuscar" runat="server" CssClass="glyphicon glyphicon-search"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                                                     
                                </div>

                                <asp:GridView ID="gdvProjetos" runat="server" CssClass="gridView" AllowCustomPaging="true"
                                    AutoGenerateColumns="false"
                                    AutoGenerateEditButton="false"
                                    OnRowDataBound="gdvProjetos_RowDataBound">

                                    <AlternatingRowStyle CssClass="alt" />

                                    <Columns>

                                        <asp:BoundField DataField="GRU_NOME_PROJETO" HeaderText="Nome" />

                                        <asp:TemplateField HeaderText="Curso/Turno"><%--esse campo curso/turno é pego no método RowDataBound no code behind--%>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCurso" runat="server"></asp:Label></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="SAN" HeaderText="Ano/Semestre" />

                                       <asp:BoundField Datafield="GRU_FINALIZADO" HeaderText="Status"  />

                                    </Columns>

                                </asp:GridView>



                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                

              

            
        </div>
    </div>


</asp:Content>
