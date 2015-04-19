<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/Administrador/MasterPage_MenuAlterarPerfil.Master" AutoEventWireup="true" CodeBehind="alterar_perfil.aspx.cs" Inherits="Inter.paginas.Administrador.AlterarPerfil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoCentral" runat="server">

        <script type="text/javascript">
        $(document).ready(function () {
            $('#icone1').addClass('corIcone');
        });
    </script>

    <div id="p1" class="first">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Escolha um perfil</h3>
                    </div>
                    <div class="panel-body">
                        
                        <table class="table" style="border-top: hidden; width:80%; margin:auto;">
                            <tr style="border-bottom: hidden;" >
                                
                                <td align="center" class="icon icon-eye" style="font-size:100px;"></td>
                                <td align="center" class="icon icon-books" style="font-size:100px;"></td>
                            </tr>
                            <tr><td align="center"><asp:Button CssClass="btn btn-default" runat="server"  Text="Entrar como Admin" OnClick="Btn_Admin"></asp:Button></td>
                                <td align="center"><asp:Button CssClass="btn btn-default" runat="server" Text="Entrar como Professor" OnClick="Btn_Prof"></asp:Button></td>
                            </tr>
                        </table>
                      
                        </div>
                    </div>
        </div>

</asp:Content>
