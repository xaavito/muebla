<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RecuperarContrasena.aspx.vb" Inherits="Muebla.RecuperarContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tableLogin">

                <tr>
                    <td>Mail</td>
                    <td class="auto-style1">
                        <input id="Text5" type="text" /></td>
                </tr>

                <tr>
                    <td>Nombre de Usuario</td>
                    <td class="auto-style1">
                        <input id="Text24" type="text" /></td>
                </tr>

            </table>
            <asp:Button Text="Recuperar" runat="server" />
        </div>
    </form>
</body>
</html>
