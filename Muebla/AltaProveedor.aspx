<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaProveedor.aspx.vb" Inherits="Muebla.AltaProveedor1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAltaProveedor">
        <asp:TableHeaderRow></asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreLabel" Text="Nombre" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="cuitLabel" Text="CUIT" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="cuitTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="telefonoLabel" Text="Telefono" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="telefonoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="contactoLabel" Text="Contacto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="contactoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="direccionLabel" Text="Direccion" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="direccionTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="emailLabel" Text="Email" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:textbox runat="server" ID="emailTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="productosLabel" Text="Productos" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox runat="server" ID="productosListBox" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="addProductoButton" Text="Manejar Productos" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow></asp:TableFooterRow>
    </asp:Table>

    <asp:Button runat="server" ID="confirmarAltaProveedorButton" Text="Confirmar" OnClick="confirmarAltaProveedorButton_Click" />
    <asp:Button runat="server" ID="cancelarAltaProveedorButton" Text="Cancelar" OnClick="cancelarAltaProveedorButton_Click"  />
</asp:Content>
