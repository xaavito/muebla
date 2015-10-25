<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Ventas.aspx.vb" Inherits="Muebla.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lvProductos"
        ItemType="BE.ListaPrecioDetalleBE" SelectMethod="listarProductos">
        <LayoutTemplate>
            <div class="row">
                <div runat="server" id="itemPlaceHolder" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div runat="server" class="productos-container">
                <div class="media">
                    <asp:Image ImageUrl='<%#"getImageHandler.ashx?id=" + Convert.ToString(Eval("producto.id"))%>' runat="server" GenerateEmptyAlternateText="False" />
                    <div class="media-body">
                        <asp:Label ID="itemID" Text="<%# Item.id %>" Visible="false" runat="server" />
                        <h3 class="media-heading"><%# Item.producto.descripcion %></h3>
                        <h5 class="media-heading"><%# Item.producto.breveDescripcion %></h5>
                        <asp:Label CssClass="promo" Text="PROMO!!!" runat="server" ID="promoLabel" Visible='<%# Item.esPromo %>' />
                        <asp:Label Text="<%# Item.getPrecio%>" runat="server" ID="precioItem" Visible='<%# Not getUsuario() Is Nothing%>' />
                        <asp:DropDownList runat="server" ID="cantDropDown" Visible='<%# Not getUsuario() Is Nothing%>' DataSource="<%# Util.Util.getCantidadCombo %>" DataTextField="descripcion" DataValueField="id" OnSelectedIndexChanged="cantDropDown_SelectedIndexChanged" />
                        <asp:ImageButton runat="server" ID="btnAgregarAlCarrito" ImageUrl="/images/addToCart.png" CssClass="pull-right" Visible='<%# Not getUsuario() Is Nothing%>' OnClick="btnAgregarAlCarrito_Click" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <asp:Label id="nothingToShowLabel" Text="No hay nada para mostrar" runat="server" />
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
