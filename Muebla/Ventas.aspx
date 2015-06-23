<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Ventas.aspx.vb" Inherits="Muebla.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lvProductos"
        ItemType="BE.ProductoBE" SelectMethod="listarProductos">
        <LayoutTemplate>
            <div class="row">
                <div class="btn-group">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Ordenar por nombre" CommandName="Sort" CommandArgument="NombreCompleto" />
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Ordenar por fecha creación" CommandName="Sort" CommandArgument="CreadoFecha" />
                </div>
            </div>
            <div class="row">
                <div runat="server" id="itemPlaceHolder" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div runat="server" class="productos-container">
                <div class="media">
                    <asp:Image ImageUrl='<%#"getImageHandler.ashx?id=" + Convert.ToString(Eval("id"))%>' runat="server" GenerateEmptyAlternateText="False" />
                    <div class="media-body">
                        <h4 class="media-heading"><%# Item.descripcion %></h4>
                        
                        <asp:LinkButton runat="server" ID="btnAgregarAlCarrito" Text="Agregar al Carrito" CssClass="pull-right" CommandName="Agregar al Carrito" CommandArgument="<%# Item.id %>" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            No hay usuarios para mostrar.
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
