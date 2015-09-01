<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaProducto.aspx.vb" Inherits="Muebla.AltaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table runat="server" ID="tableAltaProducto">
        <asp:TableHeaderRow></asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="descripcionLabel" Text="Descripcion" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="descripcionTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="proveedorLabel" Text="Proveedor" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="proveedorDropDown" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="addProveedorButton" Text="Agregar Proveedor" OnClick="addProveedorButton_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="stockLabel" Text="Stock" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="stockTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="stockMinimoLabel" Text="Stock Minimo" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="stockMinimoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoProductoLabel" Text="Tipo Producto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="tipoProductoDropDown" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="productosLabel" Text="Productos" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="productosPropiosListBox" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton runat="server" ID="removerProductoButton" ImageUrl="/images/arrowRight.png" OnClick="removerProductoButton_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton runat="server" ID="agregarProductoButton" ImageUrl="/images/arrowLeft.png" OnClick="agregarProductoButton_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="allProductosListBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableFooterRow></asp:TableFooterRow>
    </asp:Table>

    <asp:Button runat="server" ID="confirmarAltaProductoButton" Text="Confirmar" OnClick="confirmarAltaProductoButton_Click" />
    <asp:Button runat="server" ID="cancelarAltaProductoButton" Text="Cancelar" OnClick="cancelarAltaProductoButton_Click" />
</asp:Content>
