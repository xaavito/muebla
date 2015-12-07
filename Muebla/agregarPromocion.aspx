<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="agregarPromocion.aspx.vb" Inherits="Muebla.agregarPromocion" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />

    <asp:GridView runat="server" ID="detalleListaPrecioResultGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
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
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" Visible="false" />
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
                    <asp:ImageButton ID="ibtnAddPromo" runat="server"
                        ImageUrl="/images/addImage.png"
                        OnClick="ibtnAddPromo_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="lnkAddPromo_ModalPopupExtender" runat="server"
        CancelControlID="ButtonCancel"
        TargetControlID="Button1" PopupControlID="DivAddPromoConfirmation"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupEdit" ID="DivAddPromoConfirmation"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Agregar Promo" ID="addPromoLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="precioActualLabel" Text="Precio Actual" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="precioActualTextBox" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="precioPromoLabel" Text="Precio Promo" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="precioPromoTextBox" />
                                <asp:RequiredFieldValidator ValidationGroup="altaPromo" ErrorMessage="Requerido" ControlToValidate="precioPromoTextBox" runat="server" />
                                <asp:RegularExpressionValidator ValidationGroup="altaPromo" runat="server"
                                    ErrorMessage="Solo Numeros"
                                    ControlToValidate="precioPromoTextBox"
                                    ValidationExpression="^[0-9]*$" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="fechaDesdeLabel1" Text="Fecha Desde" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="fechaDesdeTextBox1" />
                                <asp:RequiredFieldValidator ValidationGroup="altaPromo" ErrorMessage="Requerido" ControlToValidate="fechaDesdeTextBox1" runat="server" />
                                <asp:RegularExpressionValidator ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$" ErrorMessage="Fecha Invalida" ControlToValidate="fechaDesdeTextBox1" runat="server" ValidationGroup="altaPromo" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="fechaHastaLabel1" Text="Fecha Hasta" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="fechaHastaTextBox1" />
                                <asp:RequiredFieldValidator ValidationGroup="altaListaPrecio" ErrorMessage="Requerido" ControlToValidate="fechaHastaTextBox1" runat="server" />
                                <asp:RegularExpressionValidator ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$" ErrorMessage="Fecha Invalida" ControlToValidate="fechaHastaTextBox1" runat="server" ValidationGroup="altaPromo" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ButtonConfirmarOkay" OnClick="ButtonConfirmarOkay_Click" ValidationGroup="altaPromo" />
                <asp:Button runat="server" Text="Cancelar" ID="ButtonCancel" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
