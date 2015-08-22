<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Carrito.aspx.vb" Inherits="Muebla.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lvProductos"
        ItemType="BE.ListaPrecioDetalleBE" SelectMethod="buscarSeleccionados" OnItemCommand="lvProductos_ItemCommand">
        <LayoutTemplate>
            <div class="row">
                <div runat="server" id="itemPlaceHolder" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div runat="server" class="productos-container">
                <div class="media" id="<%# Item.id %>">
                    <asp:Image ImageUrl='<%#"getImageHandler.ashx?id=" + Convert.ToString(Eval("producto.id"))%>' runat="server" GenerateEmptyAlternateText="False" />
                    <div class="media-body">
                        <h4 class="media-heading"><%# Item.producto.descripcion %></h4>
                        <h4 class="media-heading"><%# Item.precio %></h4>

                        <asp:LinkButton runat="server" ID="btnSacarAlCarrito" Text="Sacar del Carrito" CssClass="pull-right" CommandName="removeFromCart" CommandArgument="<%# Item.id %>" />
                        <asp:Label Text="Cantidad" runat="server" />
                        <asp:Label Text="<%# Item.id %>" runat="server" Visible="false" ID="listaPrecioDetalleId" />
                        <asp:DropDownList ID="cantidad" runat="server">
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            No hay Productos en el Carrito.
        </EmptyDataTemplate>
    </asp:ListView>

    <div>
        <asp:Label Text="Tipo Envio" runat="server" />
        <asp:DropDownList ID="tipoEnvio" runat="server">
            <asp:ListItem Text="Lo retiro por mi cuenta" Value="1" />
            <asp:ListItem Text="Quiero que me lo envien a mi domicilio" Value="2" />
        </asp:DropDownList>

        <asp:Label Text="Modo de Pago" runat="server" />
        <asp:DropDownList ID="modoPago" runat="server">
            <asp:ListItem Text="Pago mis Cuentas" Value="1" />
            <asp:ListItem Text="Rapi Pago" Value="2" />
        </asp:DropDownList>

        <asp:Button Text="Comprar!" runat="server" OnClick="comprar_Click" />
    </div>
</asp:Content>
