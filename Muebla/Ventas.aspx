﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Ventas.aspx.vb" Inherits="Muebla.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lvProductos"
        ItemType="BE.ListaPrecioDetalleBE" SelectMethod="listarProductos" OnItemCommand="lvProductos_ItemCommand">
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
                        <h3 class="media-heading"><%# Item.producto.descripcion %></h3>
                        <h5 class="media-heading"><%# Item.producto.breveDescripcion %></h5>
                        <asp:Label Text="<%# Item.getPrecio%>" runat="server" id="precioItem" Visible='<%# Not getUsuario() Is Nothing%>'/>
                        <asp:ImageButton runat="server" ID="btnAgregarAlCarrito" ImageUrl="/images/addToCart.png" CssClass="pull-right" CommandName="addToCart" CommandArgument="<%# Item.producto.id %>" Visible='<%# Not getUsuario() Is Nothing%>'/>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            No hay Productos para mostrar.
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
