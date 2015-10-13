<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarProveedores.aspx.vb" Inherits="Muebla.AdministrarProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAdministrarProveedoresCriteria" CssClass="table">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreProveedorLabel" Text="Organizacion/Nombre de fantasia" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="nombreProveedorTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="contactoSearchLabel" Text="Contacto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="contactoSearchTextBox" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button ID="buscarButton" Text="Buscar" runat="server" OnClick="buscarButton_Click" />

    <asp:GridView runat="server" ID="proveedoresResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.ProveedorBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="proveedoresResultadosDataGrid_PreRender"
        OnPageIndexChanging="proveedoresResultadosDataGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razon Social">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemRazonSocial" Text="<%# Item.razonSocial %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CUIT">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemCuit" Text="<%# Item.cuit%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefono">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTelefoni" Text="<%# Item.telefono%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mail">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemMail" Text="<%# Item.mail%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Activo">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemEstado" Text="<%# Item.estado %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png"
                        OnClick="ibtnEdit_Click" />
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnDelete_Click" />
                    <asp:ImageButton ID="ibtnDetails" runat="server"
                        ImageUrl="/images/detail.png"
                        OnClick="ibtnDetails_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div id="editData" runat="server">
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
        <asp:Button Text="Modificar" ID="modificarButton" runat="server" OnClick="modificarButton_Click" />
        <asp:Button Text="Cancelar" ID="cancelarButton" runat="server" OnClick="cancelarButton_Click" />
    </div>
</asp:Content>
