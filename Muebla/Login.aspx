<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Muebla.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/MiEstilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="login">
            <table id="tableLogin">
                <tr>
                    <td>Usuario</td>
                    <td class="auto-style1">
                        <input id="Text1" type="text" /></td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td class="auto-style1">
                        <input id="Text2" type="text" /></td>
                </tr>
                
            </table>
            <asp:Button Text="Confirmar" runat="server" OnClick="login"/>
            <a href="Login.aspx">Olivido su contraseña?</a>
        </div>
    </form>
</body>
</html>
