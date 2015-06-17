<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuMaster.master" AutoEventWireup="true" CodeBehind="auditoria.aspx.cs" Inherits="paginas_Admin_auditoria" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#icone65').addClass('corIcone');
        });
    </script>

    <div id="p1" class="first">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Auditoria</h3>
            </div>
            <div class="panel-body">
               

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <asp:UpdatePanel ID="UpdatePanelAtivados" UpdateMode="Conditional" runat="server">

                            <ContentTemplate>
                              
                                

                                </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                

              

            
        </div>
    </div>


</asp:Content>
