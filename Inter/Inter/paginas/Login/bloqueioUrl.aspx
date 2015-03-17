<%@ Page Language="C#" AutoEventWireup="true" Inherits="Paginas_Login_bloqueioUrl" CodeBehind="bloqueioUrl.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../App_Themes/css/style.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../../App_Themes/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" />
    <link href="../../App_Themes/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #ededed;">
    <form id="form1" runat="server">
        <div id="imgBloqueio">
        </div>
        <center><asp:LinkButton ID="btnVoltar" CssClass="btn btn-default" runat="server" OnClick="btnVoltar_Click">
            <i aria-hidden="true" class="glyphicon glyphicon-arrow-left"></i>&nbsp Ir Para Login
                </asp:LinkButton></center>
    </form>
</body>
</html>

