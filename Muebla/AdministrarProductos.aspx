<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarProductos.aspx.vb" Inherits="Muebla.AdministrarProductos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAdministrarProductosCriteria">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreProductoLabel" Text="Nombre Producto" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="nombreProductoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoProductoLabel" Text="Tipo Producto" />
            </asp:TableCell><asp:TableCell>
                <asp:DropDownList runat="server" ID="tipoProductoDropDownList" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" ID="buscarButton" Text="Buscar" OnClick="buscarProductosButton_Click" />

    <asp:GridView runat="server" ID="productosResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="false" PageSize="12"
        ItemType="BE.ProductoBE"
        ShowFooter="false" CssClass="table table-bordered table-condensed"
        EmptyDataRowStyle-CssClass="gvEmpty"
        OnPreRender="productosResultadosDataGrid_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemDescripcion" Text="<%# Item.descripcion %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Producto">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTipo" Text="<%# Item.tipoProducto.descripcion %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png" OnClick="ibtnEdit_Click" />
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnDelete_Click" />
                    <asp:ImageButton ID="ibtnDetails" runat="server"
                        ImageUrl="/images/detail.png"
                        OnClick="ibtnDetails_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SortedAscendingHeaderStyle CssClass="asc" />
        <SortedDescendingHeaderStyle CssClass="desc" />
        <SortedAscendingCellStyle CssClass="asc" />
        <SortedDescendingCellStyle CssClass="desc" />
        <PagerSettings Mode="Numeric" PageButtonCount="5" Position="TopAndBottom" />
        <PagerStyle CssClass="grid-pager" />
    </asp:GridView>
    <div id="editDataDiv" runat="server">
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
                    <asp:Label runat="server" ID="precioLabel" Text="Precio" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="precioTextBox" />
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
                    <asp:Label runat="server" ID="Label1" Text="Tipo Producto" />
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
                    <asp:ListBox runat="server" ID="productosListBox" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="addProductoButton" Text="Manejar Productos" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow></asp:TableFooterRow>
        </asp:Table>

        <asp:Button runat="server" ID="confirmarButton" Text="Confirmar" OnClick="confirmarEditProductoButton_Click" />
    </div>
    <asp:Button Text="Orden de Compra" ID="generarOrdenCompraButton" runat="server" OnClick="generarOrdenCompraButton_Click" />
    <asp:Button Text="Comparacion Costos" runat="server" ID="compararCostoButton" OnClick="compararCostoButton_Click" />
</asp:Content>
