<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RecuperarContrasena.aspx.vb" Inherits="Muebla.RecuperarContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/MiEstilo.css" rel="stylesheet" />
    <title>Recuperar Contraseña</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="recuperarContrasena">
            <asp:Table runat="server" ID="tableRecuperarUsuario">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="usrTextBox" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server" ID="mailLabel" Text="Mail" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="mailTextBox" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Label Text="" runat="server" ID="mailEnviandose"/>
            <asp:Button Text="Recuperar" runat="server" id="recuperarPassButton" OnClick="recuperarPassButton_Click"/>
            <a href="Login.aspx">Login</a>
        </div>
    </form>
</body>
</html>
