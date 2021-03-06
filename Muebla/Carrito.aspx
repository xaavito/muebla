﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Carrito.aspx.vb" Inherits="Muebla.Carrito" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <asp:Label ID="pasoLabel" Text="" runat="server" />

    <asp:GridView runat="server" ID="detalleCarritoResultGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.PedidoProductoBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="detalleCarritoResultGrid_PreRender"
        OnPageIndexChanging="detalleCarritoResultGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField Visible="false" HeaderText="ID" >
                <ItemTemplate>
                    <asp:Label Visible="false" runat="server" ID="itemID" Text="<%# Item.producto.id %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemCantidad" Text="<%# Item.cantidad%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <asp:Image ImageUrl='<%#"getImageHandler.ashx?id=" + Convert.ToString(Eval("producto.producto.id"))%>' runat="server" GenerateEmptyAlternateText="False" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemDescripcion" Text="<%# Item.producto.producto.descripcion%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Precio Unitario">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemPrecioUnitario" Text="<%# Item.producto.getPrecio%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Precio">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemPrecio" Text="<%# Item.getPrecio()%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnDelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="totalMontoLabel" Text="" runat="server" />
    <asp:Label ID="totalLabel" Text="Total:" runat="server" />

    <br />
    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="lnkDelete_ModalPopupExtender" runat="server"
        CancelControlID="ButtonDeleteCancel"
        TargetControlID="Button1" PopupControlID="DivDeleteConfirmation"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Confirmacion" ID="confirmarLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:Label ID="eliminarLeyendaLabel" Text="Desea Eliminar?" runat="server" />
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ButtonDeleleOkay" OnClick="ButtonDeleleOkay_Click" />
                <asp:Button runat="server" Text="Cancelar" ID="ButtonDeleteCancel" />
            </div>
        </div>
    </asp:Panel>

    <div id="confirmarStepOne" runat="server">
        <asp:Button ID="confirmarCarritoButton" Text="Confirmar" runat="server" OnClick="confirmarCarritoButton_Click" />
    </div>

    <div id="pasoEnvio" runat="server">
        <asp:Label ID="tipoEnvioLabel" Text="Tipo Envio" runat="server" />
        <asp:DropDownList ID="tipoEnvio" runat="server" />
        <asp:Button ID="pasoPagoButton" Text="Confirmar Envio" runat="server" OnClick="pasoPagoButton_Click" />
    </div>

    <div id="pasoPago" runat="server">
        <asp:Label ID="modoPagoLabel" Text="Modo de Pago" runat="server" />
        <asp:DropDownList ID="modoPago" runat="server" />
        <asp:Button ID="pasoConfirmarButton" Text="Confirmar Pago" runat="server" OnClick="pasoConfirmarButton_Click" />
    </div>
    <script>
        function thanks() {
            setTimeout(function () {
                document.location.pathname = "compraRealizada.aspx";
            }, 5000);
        }
    </script>
    <div id="pasoConfirmacion" runat="server">
        <asp:Button ID="confirmarPedidoCompra" Text="Comprar" runat="server" OnClick="comprar_Click" OnClientClick="thanks()" />
    </div>
</asp:Content>
