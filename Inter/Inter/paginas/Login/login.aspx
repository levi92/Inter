<%@ Page Language="C#" AutoEventWireup="true" Inherits="Paginas_Login_login" CodeBehind="login.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login INTER.</title>


    <link href="../../App_Themes/css/bootstrap.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../../App_Themes/css/jquery-ui.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" />
    <link href="../../App_Themes/css/style.css" rel="stylesheet" type="text/css" />


    <script src="../../Scripts/jquery-2.1.1.min.js"></script>
    <script src="../../Scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.skitter.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap.js" type="text/javascript"></script>

    <!-- Dialog -->
    <%--<script src="../../Scripts/jquery-ui.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="container-fluid">


                    <!-- Barra de cima onde fica o logo e depois as informações da sessão do usuário // Revisado(?) -->
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <ul class="nav navbar-nav">
                            <li>
                                <span style="margin-left: 20%;">
                                    <img src="../../App_Themes/images/logo_topo.png" />
                                </span>
                            </li>

                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container-fluid -->
            </div>
        </nav>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <div class="rows">
            <div class="col-xs-6 col-md-4"></div>
            <div class="col-xs-6 col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <img src="../../App_Themes/images/fatec_logo.png" /></h3>
                    </div>
                    <div class="panel-body">
                        <ul class="pager">
                            <!--- Login de professor / administrador) !--->
                            <center><asp:TextBox ID="txtLogin" class="form-control"  placeholder="Login" style="width:250px;" runat="server"></asp:TextBox></center>
                            <br>
                            <center><asp:TextBox ID="txtSenha" class="form-control"  placeholder="Senha" style="width:250px;" runat="server" TextMode="Password"></asp:TextBox></center>
                            <br>
                            <asp:Button ID="enviar" class="btn btn-default" Style="width: 250px;" runat="server" Text="Entrar" OnClick="enviar_Click" /><br />
                            <asp:Label ID="lblMsgErro" runat="server" Style="color: #960d10"></asp:Label>
                            <center><a href="#" style="font-size:13px" data-toggle="modal" data-target="#myModal">Problemas com o Login?</a>
                    </div>

                    </ul>
                </div>
            </div>
        </div>
        <div class="col-xs-6 col-md-4"></div>

        <script type="text/javascript">
            

            function EscolherPerfil() {
                $('#MyModalEscolha').modal(
                    {
                        url: 'login.aspx'
                    }
                );
            }
        </script>

        <div class="modal fade" id="MyModalEscolha" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                        <h4 class="modal-title" id="myModalLabel">Escolha o seu perfil:</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Button ID="btnAdministrador" CssClass="btn btn-default" Text="Administrador" runat="server" OnClick="btnAdministrador_Click" />
                        &nbsp
                            <asp:Button ID="btnProfessor" CssClass="btn btn-default" Text="Professor" runat="server" OnClick="btnProfessor_Click1" />

                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>



    </form>
</body>
</html>
