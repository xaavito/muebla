<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Carrito.aspx.vb" Inherits="Muebla.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="detalleCarritoResultGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.ListaPrecioDetalleBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="detalleCarritoResultGrid_PreRender"
        OnPageIndexChanging="detalleCarritoResultGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <asp:Image ImageUrl='<%#"getImageHandler.ashx?id=" + Convert.ToString(Eval("producto.id"))%>' runat="server" GenerateEmptyAlternateText="False" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemDescripcion" Text="<%# Item.producto.descripcion%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemPrecio" Text="<%# Item.getPrecio%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEditDetail" runat="server"
                        ImageUrl="/images/editItem.png"
                        OnClick="ibtnEditDetail_Click" />
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnDelete_Click" />
                    <asp:ImageButton ID="ibtnDetailsDetail" runat="server"
                        ImageUrl="/images/detail.png"
                        OnClick="ibtnDetailsDetail_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="tipoEnvioLabel" Text="Tipo Envio" runat="server" />
        <asp:DropDownList ID="tipoEnvio" runat="server">
            <asp:ListItem Text="Lo retiro por mi cuenta" Value="1" />
            <asp:ListItem Text="Quiero que me lo envien a mi domicilio" Value="2" />
        </asp:DropDownList>

        <asp:Label ID="modoPagoLabel" Text="Modo de Pago" runat="server" />
        <asp:DropDownList ID="modoPago" runat="server">
            <asp:ListItem Text="Pago mis Cuentas" Value="1" />
            <asp:ListItem Text="Rapi Pago" Value="2" />
        </asp:DropDownList>

        <asp:Button ID="comprarButton" Text="Comprar" runat="server" OnClick="comprar_Click" />
    </div>
</asp:Content>
