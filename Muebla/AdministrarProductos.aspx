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
    <asp:Button runat="server" ID="buscarProductosButton" Text="Buscar" OnClick="buscarProductosButton_Click" />
    <asp:GridView runat="server" ID="productosResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12" AllowSorting="true"
        ItemType="BE.ProductoBE"
        ShowFooter="false" CssClass="table table-bordered table-condensed"
        EmptyDataText="No record found!"
        EmptyDataRowStyle-CssClass="gvEmpty">
        <Columns>
            <asp:TemplateField HeaderText="ID" SortExpression="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" id="itemID" class="pull-right" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" id="itemDescripcion" class="pull-right" Text="<%# Item.descripcion %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Producto" SortExpression="Tipo Producto">
                <ItemTemplate>
                    <asp:Label runat="server" id="itemTipo" class="pull-right" Text="<%# Item.tipoProducto.descripcion %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png" OnClick="ibtnEdit_Click" />
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClientClick="javascript:return confirm('Do you want to delete it?');"
                        OnClick="ibtnDelete_Click" />
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
    <asp:Button Text="Ver Detalle" runat="server" ID="verDetalleButton" OnClick="verDetalleButton_Click" />
    <asp:Button Text="Modificar" runat="server" ID="modificarButton" OnClick="modificarButton_Click" />
    <asp:Button Text="Borrar" runat="server" ID="eliminarButton" OnClick="eliminarButton_Click" />
    <asp:Button Text="Orden de Compra" ID="generarOrdenCompraButton" runat="server" OnClick="generarOrdenCompraButton_Click" />
    <asp:Button Text="Comparacion Costos" runat="server" ID="compararCostoButton" OnClick="compararCostoButton_Click" />
</asp:Content>
