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
    <asp:Label Text="" runat="server" ID="mailEnviandose" />
    <asp:Button Text="Recuperar" runat="server" ID="recuperarPassButton" OnClick="recuperarPassButton_Click" />
    <a href="Login.aspx">Login</a>


</asp:Content>
