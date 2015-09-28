<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="RecuperarContrasena.aspx.vb" Inherits="Muebla.RecuperarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableRecuperarUsuario">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usrTextBox" />
                <asp:RequiredFieldValidator ValidationGroup='recuperarPass' ErrorMessage="Requerido" ControlToValidate="usrTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="mailLabel" Text="Mail" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="mailTextBox" />
                <asp:RequiredFieldValidator ValidationGroup='recuperarPass' ErrorMessage="Requerido" ControlToValidate="mailTextBox" runat="server" />
                <asp:RegularExpressionValidator runat="server"
                    ErrorMessage="Email Invalido"
                    ControlToValidate="mailTextBox"
                    ValidationExpression="\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b"
                    ValidationGroup='recuperarPass' />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button ValidationGroup='recuperarPass' Text="Recuperar" runat="server" ID="recuperarPassButton" OnClick="recuperarPassButton_Click" />
    <asp:LinkButton ID="loginButton" Text="Login" runat="server" OnClick="loginButton_Click" />

</asp:Content>
