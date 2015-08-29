<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaUsuario.aspx.vb" Inherits="Muebla.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAltaUsuario">
        <asp:TableHeaderRow></asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usrTextBox" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreLabel" Text="Nombre" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreTextBox" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="apellidoLabel" Text="Apellido" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="apellidoTextBox" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="mailLabel" Text="Mail" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="mailTextBox" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="passLabel" Text="Contraseña" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="passTextBox" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="rolesLabel" Text="Roles" /></asp:TableCell>
            <asp:TableCell>
                <asp:ListBox runat="server" ID="TextBox1" /></asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="addRolButton" text="Manejar Roles"/></asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow></asp:TableFooterRow>
    </asp:Table>

    <asp:Button runat="server" ID="confirmarAltaUsuarioButton" Text="Confirmar"/>
    <asp:Button runat="server" ID="cancelarAltaUsuarioButton" text="Cancelar"/>
  
</asp:Content>
