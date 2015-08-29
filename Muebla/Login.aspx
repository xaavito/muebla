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
                        <asp:TextBox runat="server" ID="usr" />
                    </td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td class="auto-style1">
                        <asp:TextBox runat="server" TextMode="Password" ID="pass" />
                    </td>

                </tr>

            </table>
            <asp:Button Text="Confirmar" runat="server" OnClick="login" />
            <a href="RecuperarContrasena.aspx">Olivido su contraseña?</a>
            <a href="Registro.aspx">Registrarse!</a>
        </div>
    </form>
</body>
</html>
