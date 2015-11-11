<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarProveedores.aspx.vb" Inherits="Muebla.AdministrarProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />

    <asp:Table runat="server" ID="tableAdministrarProveedoresCriteria" CssClass="table">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreProveedorLabel" Text="Organizacion/Nombre de fantasia" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreProveedorTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="contactoSearchLabel" Text="Contacto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="contactoSearchTextBox" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button ID="buscarButton" Text="Buscar" runat="server" OnClick="buscarButton_Click" />

    <asp:GridView runat="server" ID="proveedoresResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.ProveedorBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="proveedoresResultadosDataGrid_PreRender"
        OnPageIndexChanging="proveedoresResultadosDataGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razon Social">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemRazonSocial" Text="<%# Item.razonSocial %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CUIT">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemCuit" Text="<%# Item.cuit%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefono">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTelefono" Text="<%# Item.tel.formatedLine%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mail">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemMail" Text="<%# Item.mail%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Activo">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemEstado" Text="<%# Item.activo %>" />
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
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div id="editData" runat="server">
        <asp:Table runat="server" ID="tableAltaProveedor">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="nombreLabel" Text="Nombre" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="nombreTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="nombreTextBox" runat="server" />
                    <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                        ErrorMessage="Solo Texto"
                        ControlToValidate="nombreTextBox"
                        ValidationExpression="^[a-zA-Z_ ]*$" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="cuitLabel" Text="CUIT" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="cuitTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="cuitTextBox" runat="server" />
                    <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                        ErrorMessage="Solo Numeros"
                        ControlToValidate="cuitTextBox"
                        ValidationExpression="^[0-9]*$" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="telefonoLabel" Text="Telefono" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="telefonoTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="telefonoTextBox" runat="server" />
                    <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                        ErrorMessage="Solo Numeros"
                        ControlToValidate="telefonoTextBox"
                        ValidationExpression="^[0-9]*$" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="internoLabel" Text="Telefono" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="internoTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="internoTextBox" runat="server" />
                    <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                        ErrorMessage="Solo Numeros"
                        ControlToValidate="internoTextBox"
                        ValidationExpression="^[0-9]*$" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="prefijoLabel" Text="Telefono" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="prefijoTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="prefijoTextBox" runat="server" />
                    <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                        ErrorMessage="Solo Numeros"
                        ControlToValidate="prefijoTextBox"
                        ValidationExpression="^[0-9]*$" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="contactoLabel" Text="Contacto" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="contactoTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="contactoTextBox" runat="server" />
                    <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                        ErrorMessage="Solo Texto"
                        ControlToValidate="contactoTextBox"
                        ValidationExpression="^[a-zA-Z_ ]*$" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="direccionLabel" Text="Direccion" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="direccionTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="direccionTextBox" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="nroCalleLabel" Text="Nro" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="nroCalleTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="nroCalleTextBox" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="pisoLabel" Text="Piso" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="pisoTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="pisoTextBox" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="dptoLabel" Text="Dpto" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="dptoTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="dptoTextBox" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="provinciaLabel" Text="Provincia" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList EnableViewState="True" runat="server" ID="provinciaDropDownList" OnSelectedIndexChanged="provinciaDropDownList_SelectedIndexChanged" AutoPostBack="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="localidadLabel" Text="Localidad" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList AutoPostBack="true" EnableViewState="True" runat="server" ID="localidadDropDownList" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="emailLabel" Text="Email" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="emailTextBox" />
                    <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="emailTextBox" runat="server" />
                    <asp:RegularExpressionValidator runat="server"
                        ErrorMessage="Email Invalido"
                        ControlToValidate="emailTextBox"
                        ValidationExpression="\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b" ValidationGroup="altaProveedor" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="productosLabel" Text="Productos" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="productosPropiosListBox" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton runat="server" ID="removerProductoButton" ImageUrl="/images/arrowRight.png" OnClick="removerProductoButton_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton runat="server" ID="agregarProductoButton" ImageUrl="/images/arrowLeft.png" OnClick="agregarProductoButton_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="allProductosListBox" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button Text="Modificar" ID="modificarButton" runat="server" OnClick="modificarButton_Click" />
        <asp:Button Text="Cancelar" ID="cancelarButton" runat="server" OnClick="cancelarButton_Click" />
    </div>

    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="lnkObservaciones_ModalPopupExtender" runat="server"
        CancelControlID="ButtonCancel"
        TargetControlID="Button1" PopupControlID="DivObservaciones"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupConfirmation" ID="DivObservaciones"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Observaciones" ID="observacionLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:Label runat="server" ID="observacionesLabel" Text="Observaciones" />
                    <asp:TextBox TextMode="MultiLine" Rows="4" ID="observacionesTextBox" runat="server" />
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ButtonOkay" OnClick="ButtonOkay_Click" />
                <asp:Button runat="server" Text="Cancelar" ID="ButtonCancel" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
