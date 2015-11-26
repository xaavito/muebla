<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="MisPedidos.aspx.vb" Inherits="Muebla.MisPedidos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />

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
                <asp:TextBox runat="server" ID="fechaDesdeTextBox"  />
                <asp:RegularExpressionValidator ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$" ErrorMessage="Fecha Invalida" ControlToValidate="fechaDesdeTextBox" runat="server" ValidationGroup="buscarVentas" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="fechaHastaLabel" Text="Fecha Hasta" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="fechaHastaTextBox"  />
                <asp:RegularExpressionValidator ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$" ErrorMessage="Fecha Invalida" ControlToValidate="fechaHastaTextBox" runat="server" ValidationGroup="buscarVentas" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button Text="Buscar" ID="buscarButton" runat="server" OnClick="buscarButton_Click" ValidationGroup="buscarVentas"/>

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
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="itemSelected" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Visible="false" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comprador">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemComprador" Text="<%# Item.usr.usuario %>" />
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
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTotal" Text="<%# Item.getTotal %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnCambiarEstado" runat="server"
                        ImageUrl="/images/editItem.png"
                        OnClick="ibtnCambiarEstado_Click" Visible='<%# getUsuario.isAdmin %>'/>
                    <asp:ImageButton ID="ibtnCancelarPedido" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnCancelarPedido_Click" />
                    <asp:ImageButton ID="ibtnCommentarioButton" runat="server"
                        ImageUrl="/images/comentario.png"
                        OnClick="ibtnCommentarioButton_Click" />
                    <asp:ImageButton ID="ibtnVerComentarios" runat="server"
                        ImageUrl="/images/view.png"
                        OnClick="ibtnVerComentarios_Click" />
                    <asp:ImageButton ID="ibtnVerDetalle" runat="server"
                        ImageUrl="/images/detail.png"
                        OnClick="ibtnVerDetalle_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="detailPopup" runat="server"
        CancelControlID="ButtonDetailOK"
        TargetControlID="Button1" PopupControlID="DivDetail"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupComment" ID="DivDetail"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Body">
                <p>
                    <asp:GridView runat="server" ID="detailsPedidos" AutoGenerateColumns="true" ShowHeader="False">
                    </asp:GridView>
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="OK" ID="ButtonDetailOK"/>
            </div>
        </div>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender
        ID="lnkComment_ModalPopupExtender" runat="server"
        CancelControlID="ButtonCommentCancel"
        TargetControlID="Button1" PopupControlID="DivComment"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupComment" ID="DivComment"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Comentario" ID="commentLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:TextBox ID="commentTextBox" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ButtonCommentOkay" OnClick="ButtonCommentOkay_Click" />
                <asp:Button runat="server" Text="Cancelar" ID="ButtonCommentCancel" />
            </div>
        </div>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender
        ID="viewComments" runat="server"
        CancelControlID="okButton"
        TargetControlID="Button1" PopupControlID="panelComentario"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupComment" ID="panelComentario"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader1">
                <div class="TitlebarLeft">
                    <asp:Label Text="Comentarios" ID="comentarioLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <asp:GridView runat="server" ID="comentariosResultGrid"
                    AutoGenerateColumns="false"
                    AllowPaging="false" PageSize="12"
                    ItemType="BE.Comentario">
                    <Columns>
                        <asp:TemplateField HeaderText="" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="itemID" visible="false" Text="<%# Item.id %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="itemUsuario" Text="<%# Item.usuario.usuario %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comentario">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="itemComentario" Text="<%# Item.texto %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" Text="OK" ID="okButton" />
            </div>
        </div>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender
        ID="anularPopup" runat="server"
        CancelControlID="ButtonCommentCancel"
        TargetControlID="Button1" PopupControlID="DivAnularComment"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupComment" ID="DivAnularComment"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader2">
                <div class="TitlebarLeft">
                    <asp:Label Text="Comentario" ID="comentarioAnularLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:TextBox ID="anularCommentTextBox" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="anularCommentTextBox" runat="server" ValidationGroup="confirmarAnular"/>
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Anular" ID="anularButton" OnClick="anularButton_Click" ValidationGroup="confirmarAnular"/>
                <asp:Button runat="server" Text="Cancelar" ID="cancelarButton" />
            </div>
        </div>
    </asp:Panel>
    
    <ajaxToolkit:ModalPopupExtender
        ID="cambiarEstadoPopup" runat="server"
        CancelControlID="ButtonCommentCancel"
        TargetControlID="Button1" PopupControlID="DivEstadoPedido"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupComment" ID="DivEstadoPedido"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader3">
            </div>
            <div class="popup_Body">
                <p>
                    <asp:DropDownList ID="estadoPedidoDropDown" runat="server" />
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="confirmarCambioEstadoButton" OnClick="confirmarCambioEstadoButton_Click" />
                <asp:Button runat="server" Text="Cancelar" ID="cancelarCambioEstadoButton" />
            </div>
        </div>
    </asp:Panel>

    <asp:Button Text="Generar Hoja de ruta" ID="hojaRutaButton" runat="server" OnClick="hojaDeRuta" Visible="<%# Not getUsuario is Nothing and getUsuario.isAdmin = True %>" />
    <asp:Button Text="Generar Remito" ID="remitoButton" runat="server" OnClick="remito" Visible="<%# Not getUsuario() Is Nothing And getUsuario.isAdmin = True%>" />
    <asp:Button Text="Generar Factura" ID="facturaButton" runat="server" OnClick="generarFacturaButton_Click" Visible="<%# Not getUsuario() Is Nothing And getUsuario.isAdmin = True%>" />
    <asp:Button Text="Generar Nota de Credito" ID="ncButton" runat="server" OnClick="notaCredito" Visible="<%# Not getUsuario is Nothing and getUsuario.isAdmin = True%>" />
    <asp:Button Text="Anular Venta" ID="anularVentaButton" runat="server" OnClick="anularVentaButton_Click" Visible="<%# Not getUsuario is Nothing and getUsuario.isAdmin = True%>" />
</asp:Content>
