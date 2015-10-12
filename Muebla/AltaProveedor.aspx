<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaProveedor.aspx.vb" Inherits="Muebla.AltaProveedor1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAltaProveedor">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreLabel" Text="Nombre" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="nombreTextBox" runat="server" />
                <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                    ErrorMessage="Solo Texto"
                    ControlToValidate="nombreTextBox"
                    ValidationExpression="^[a-zA-Z_ ]*$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="cuitLabel" Text="CUIT" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="cuitTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="cuitTextBox" runat="server" />
                <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                    ErrorMessage="Solo Numeros"
                    ControlToValidate="cuitTextBox"
                    ValidationExpression="^[0-9]*$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="telefonoLabel" Text="Telefono" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="telefonoTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="telefonoTextBox" runat="server" />
                <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                    ErrorMessage="Solo Numeros"
                    ControlToValidate="telefonoTextBox"
                    ValidationExpression="^[0-9]*$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="contactoLabel" Text="Contacto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="contactoTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="contactoTextBox" runat="server" />
                <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                    ErrorMessage="Solo Texto"
                    ControlToValidate="contactoTextBox"
                    ValidationExpression="^[a-zA-Z_ ]*$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="direccionLabel" Text="Direccion" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="direccionTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="direccionTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="emailLabel" Text="Email" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="emailTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="emailTextBox" runat="server" />
                <asp:RegularExpressionValidator runat="server"
                    ErrorMessage="Email Invalido"
                    ControlToValidate="emailTextBox"
                    ValidationExpression="\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b" ValidationGroup="altaProveedor" />
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
    </asp:Table>
    
    <div id="valorProducto" runat="server">
        <asp:TextBox runat="server" ID="valorProductoTextBox" />
        <asp:Button Text="Confirmar" ID="confirmarValorButton" runat="server" OnClick="confirmarButton_Click" />
        <asp:Button Text="Cancelar" ID="cancelarValorButton" runat="server" OnClick="cancelarButton_Click" />
    </div>

    <asp:Button runat="server" ValidationGroup="altaProveedor" ID="confirmarButton" Text="Confirmar" OnClick="confirmarAltaProveedorButton_Click" />
</asp:Content>
