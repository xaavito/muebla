<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarUsuarios.aspx.vb" Inherits="Muebla.AdministrarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAdministrarUsuariosCriteria">
        <asp:TableHeaderRow></asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usrTextBox" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="mailLabel" Text="Mail" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="mailTextBox" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoUsuarioLabel" Text="Tipo Usuario" /></asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="tipoUsuarioDropDownList" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow></asp:TableFooterRow>
    </asp:Table>
    <asp:Button runat="server" ID="buscarUsuariosButton" Text="Buscar" OnClick="buscarUsuariosButton_Click"/> 
    <asp:Table runat="server" ID="tablaAdministrarUsuariosResultados">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <asp:Label runat="server" ID="usuarioTableLabel" Text="Usuario" />
                </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Label runat="server" ID="tipoUsuarioTableLabel" Text="Tipo Usuario" />
                </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Label runat="server" ID="mailTableLabel" Text="Mail" />
                </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Label runat="server" ID="estadoTableLabel" Text="Estado" />
                </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                <asp:Label runat="server" ID="detalleTableLabel" Text="Detalle" />
                </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableFooterRow></asp:TableFooterRow>
    </asp:Table>
    
    <asp:Button Text="Modificar" runat="server" />
    <asp:Button Text="Baja" runat="server" />
    <asp:Button Text="Desbloquear" runat="server" />
</asp:Content>
