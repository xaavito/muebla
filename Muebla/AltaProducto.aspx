<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaProducto.aspx.vb" Inherits="Muebla.AltaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table runat="server" ID="tableAltaProducto">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="descripcionLabel" Text="Descripcion" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="descripcionTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="descripcionTextBox" runat="server" ValidationGroup="altaProducto" />
                <asp:RegularExpressionValidator runat="server"
                    ErrorMessage="Solo Texto"
                    ControlToValidate="descripcionTextBox"
                    ValidationGroup="altaProducto"
                    ValidationExpression="^[a-zA-Z_ ]*$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="descripcionBreveLabel" Text="Descripcion Breve" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="descripcionBreveTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="descripcionBreveTextBox" runat="server" ValidationGroup="altaProducto" />
                <asp:RegularExpressionValidator runat="server"
                    ErrorMessage="Solo Texto"
                    ControlToValidate="descripcionBreveTextBox"
                    ValidationGroup="altaProducto"
                    ValidationExpression="^[a-zA-Z_ ]*$" />
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
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="stockTextBox" runat="server" ValidationGroup="altaProducto" />
                <asp:RegularExpressionValidator runat="server"
                    ErrorMessage="Solo Numeros"
                    ControlToValidate="stockTextBox"
                    ValidationExpression="^[0-9]*$" ValidationGroup="altaProducto" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="stockMinimoLabel" Text="Stock Minimo" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="stockMinimoTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="stockMinimoTextBox" runat="server" ValidationGroup="altaProducto" />
                <asp:RegularExpressionValidator ValidationGroup="altaProducto" runat="server"
                    ErrorMessage="Solo Numeros"
                    ControlToValidate="stockMinimoTextBox"
                    ValidationExpression="^[0-9]*$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="fotoLabel" Text="Foto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload runat="server" ID="fileUpload" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoProductoLabel" Text="Tipo Producto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="tipoProductoDropDown" OnSelectedIndexChanged="tipoProductoDropDown_SelectedIndexChanged" AutoPostBack="true" />
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

    <asp:Button runat="server" ID="confirmarButton" Text="Confirmar" OnClick="confirmarAltaProductoButton_Click" ValidationGroup="altaProducto" />

    <div id="altaProveedor" runat="server">
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
        </asp:Table>

        <asp:Button runat="server" ValidationGroup="altaProveedor" ID="confirmarAltaProveedorButton" Text="Confirmar" OnClick="confirmarAltaProveedorButton_Click" />
    </div>
</asp:Content>
