<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ConfirmarShowroom.aspx.vb" Inherits="Muebla.ConfirmarShowroom" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:GridView runat="server" ID="showroomDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.AsistenciaShowroomBE"
        ShowFooter="false" CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="showroomDataGrid_PreRender"
        OnPageIndexChanging="showroomDataGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label Visible="false" runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemUser" Text="<%# Item.usuario.usuario %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Solicitada">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemFecha" Text="<%# Item.fecha %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Asistio">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemAsistio" Text="<%# Item.cumplido %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Confirmado">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemConfirmacion" Text="<%# Item.confirmado %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png"
                        OnClick="ibtnEdit_Click" />
                    <asp:ImageButton ID="ibtnConfirm" runat="server"
                        ImageUrl="/images/confirm.png"
                        OnClick="ibtnConfirm_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="lnkEdit_ModalPopupExtender" runat="server"
        CancelControlID="ButtonDeleteCancel"
        TargetControlID="Button1" PopupControlID="DivEditConfirmation"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupConfirmation" ID="DivEditConfirmation"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Cambios" ID="cambiosLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:Label ID="fechaSolicLabel" Text="Fecha" runat="server" />
                    <asp:TextBox ID="fechaSolicTextBox" runat="server" />
                    <br />
                    <asp:Label ID="asistioLabel" Text="Asistio" runat="server" />
                    <asp:CheckBox ID="asitioCheckBox" runat="server" />
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="buttonEditOK" OnClick="buttonEditOK_Click" />
                <asp:Button runat="server" Text="Cancelar" ID="ButtonDeleteCancel" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
