<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="MisPedidos.aspx.vb" Inherits="Muebla.MisPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAdministrarProveedoresCriteria" CssClass="table">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="estadoLabel" Text="Estado" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="estadoListBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="fechaDesdeLabel" Text="Fecha Desde" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="fechaDesdeTextBox" AutoPostBack="true" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="fechaHastaLabel" Text="Fecha Hasta" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="fechaHastaTextBox" AutoPostBack="true" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button Text="Buscar" id="buscarButton" runat="server" OnClick="buscarButton_Click" />

    <asp:GridView runat="server" ID="detallePedidosResultGrid"
        AutoGenerateColumns="false"
        AllowPaging="false" PageSize="12"
        ItemType="BE.PedidoBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="detallePedidosResultGrid_PreRender"
        OnPageIndexChanging="detallePedidosResultGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Visible="false" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="fecha" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="fecha" Visible="false" Text="<%# Item.fechaCreacion%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Envio">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTipoEnvio" Text="<%# Item.tipoEnvio.texto %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modo Pago">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemModoPago" Text="<%# Item.medioPago.descripcion%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemEstado" Text="<%# Item.estado.descripcion %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnCancelar" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnCancelar_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button Text="Generar Hoja de ruta" runat="server" OnClick="hojaDeRuta" />
    <asp:Button Text="Generar Remito" runat="server" OnClick="remito" />
    <asp:Button Text="Generar Factura" runat="server" OnClick="factura" />
    <asp:Button Text="Generar Nota de Credito" runat="server" OnClick="notaCredito" />
    <asp:Button Text="Generar Comentarios" runat="server" OnClick="comentario" />
    <asp:Button Text="Servicio Post Venta" runat="server" OnClick="postVenta" />
</asp:Content>
