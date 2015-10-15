﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarListaPrecio.aspx.vb" Inherits="Muebla.ModificarListaPrecio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager id="scriptManager" runat="server" />

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
                <asp:Label runat="server" ID="descripcionLabel" Text="Descripcion" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="descripcionTextBox" AutoPostBack="true" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button ID="buscarButton" Text="Buscar" runat="server" OnClick="buscarButton_Click" />

    <asp:GridView runat="server" ID="listaPrecioResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.ListaPrecioBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="listaPrecioResultadosDataGrid_PreRender"
        OnPageIndexChanging="listaPrecioResultadosDataGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemDescripcion" Text="<%# Item.descripcion %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Desde">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemFechaDesde" Text="<%# Item.fechaDesde%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Hasta">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemFechaHasta" Text="<%# Item.fechaHasta%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Activo">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemEstado" Text="<%# Item.activo%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png"
                        OnClick="ibtnEdit_Click" />
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnDelete_Click" />
                    <asp:ImageButton ID="ibtnDetails" runat="server"
                        ImageUrl="/images/detail.png"
                        OnClick="ibtnDetails_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
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
    <div id="detailsData" runat="server">
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
                        <asp:ImageButton ID="ibtnDetailsDetail" runat="server"
                            ImageUrl="/images/detail.png"
                            OnClick="ibtnDetailsDetail_Click" />
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
                        <asp:TextBox ID="valorTextBox" runat="server" />
                    </p>
                </div>
                <div class="popup_Buttons">
                    <asp:Button runat="server" Text="Confirmar" ID="ButtonEditDetailOkay" OnClick="confirmarEdicionButton_Click" />
                    <asp:Button runat="server" Text="Cancelar" ID="ButtonEditDetailCancel" OnClick="ButtonEditDetailCancel_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
