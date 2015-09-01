<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.vb" Inherits="Muebla.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table runat="server" ID="tableLogin">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usrTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="usrTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="passLabel" Text="Contraseña" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="passTextBox" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="passTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label Text="" runat="server" ID="loginFailed" />
    <asp:Button id="confirmarButton" Text="Confirmar" runat="server" OnClick="login" />
    <a href="RecuperarContrasena.aspx">Olvido su contraseña?</a>
    <a href="Registro.aspx">Registrarse!</a>
</asp:Content>
