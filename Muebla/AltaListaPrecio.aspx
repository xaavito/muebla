<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaListaPrecio.aspx.vb" Inherits="Muebla.AltaListaPrecio" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager id="scriptManager" runat="server" />

    <asp:Table runat="server" ID="tableAltaListaPrecioCriteria" CssClass="table">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="descripcionLabel" Text="Descripcion" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="descripcionTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaListaPrecio" ErrorMessage="Requerido" ControlToValidate="descripcionTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="fechaDesdeLabel" Text="Fecha Desde" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="fechaDesdeTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaListaPrecio" ErrorMessage="Requerido" ControlToValidate="fechaDesdeTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:GridView runat="server" ID="detalleListaPrecioResultGrid"
        AutoGenerateColumns="false"
        AllowPaging="false" PageSize="12"
        ItemType="BE.ListaPrecioDetalleBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="detalleListaPrecioResultGrid_PreRender"
        OnPageIndexChanging="detalleListaPrecioResultGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Visible="false" text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="productoID" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemProductoID" Visible="false" text="<%# Item.producto.id %>" />
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
            <asp:TemplateField HeaderText="" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" Visible="false" ID="itemPrecioSinFormato" Text="<%# Item.precio%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png"
                        OnClick="ibtnEdit_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />

        <ajaxToolkit:ModalPopupExtender
            ID="lnkEditDetail_ModalPopupExtender" runat="server"
            CancelControlID="ButtonEditDetailCancel"
            TargetControlID="btnShowPopup" PopupControlID="DivEditDetailConfirmation"
            BackgroundCssClass="ModalPopupBG">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel class="popupConfirmation" ID="DivEditDetailConfirmation"
            Style="display: none" runat="server">
            <div class="popup_Container">
                <div class="popup_Titlebar" id="PopupDetailHeader">
                    <div class="TitlebarLeft">
                        <asp:Label Text="Edicion" ID="edicionLabel" runat="server" />
                    </div>
                </div>
                <div class="popup_Body">
                    <p>
                        <asp:Label ID="valoLabel" runat="server" />
                        <asp:TextBox ID="valorTextBox" runat="server" />
                    </p>
                </div>
                <div class="popup_Buttons">
                    <asp:Button runat="server" Text="Confirmar" ID="ButtonEditDetailOkay" OnClick="ButtonEditDetailOkay_Click" />
                    <asp:Button runat="server" Text="Cancelar" ID="ButtonEditDetailCancel" OnClick="ButtonEditDetailCancel_Click" />
                </div>
            </div>
        </asp:Panel>
    <asp:Button ID="confirmarButton" Text="Confirmar" runat="server" OnClick="confirmarButton_Click" ValidationGroup="altaListaPrecio"/>
</asp:Content>
