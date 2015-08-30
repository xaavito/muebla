<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Muebla.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="/css/MiEstilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="login">
            <asp:Table runat="server" ID="tableLogin">
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
                        <asp:Label runat="server" ID="passLabel" Text="Contraseña" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="passTextBox" TextMode="Password"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Label Text="" runat="server" ID="loginFailed"/>
            <asp:Button Text="Confirmar" runat="server" OnClick="login" />
            <a href="RecuperarContrasena.aspx">Olvido su contraseña?</a>
            <a href="Registro.aspx">Registrarse!</a>
        </div>
    </form>
</body>
</html>
