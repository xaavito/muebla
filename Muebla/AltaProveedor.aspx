<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaProveedor.aspx.vb" Inherits="Muebla.AltaProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
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
                    ValidationExpression="^[0-9]{10,11}$" />
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
                    ValidationExpression="^[0-9]{6,8}$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="internoLabel" Text="Interno" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="internoTextBox" />
                <asp:RegularExpressionValidator ValidationGroup="altaProveedor" runat="server"
                    ErrorMessage="Solo Numeros"
                    ControlToValidate="internoTextBox"
                    ValidationExpression="^[0-9]*$" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="prefijoLabel" Text="Prefijo" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="prefijoTextBox" />
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
                <asp:Label runat="server" ID="calleLabel" Text="Calle" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="calleTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaProveedor" ErrorMessage="Requerido" ControlToValidate="calleTextBox" runat="server" />
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
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="dptoLabel" Text="Dpto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="dptoTextBox" />
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

    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="lnkValor_ModalPopupExtender" runat="server"
        CancelControlID="ButtonCancel"
        TargetControlID="Button1" PopupControlID="DivValorConfirmation"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupConfirmation" ID="DivValorConfirmation"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Edicion" ID="edicionLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:Label ID="valorLabel" Text="Valor" runat="server" />
                    <asp:TextBox ID="valorProductoTextBox" runat="server" />
                    <asp:RequiredFieldValidator ValidationGroup="altaValor" ErrorMessage="Requerido" ControlToValidate="valorProductoTextBox" runat="server" />
                    <asp:RegularExpressionValidator ValidationGroup="altaValor" runat="server"
                        ErrorMessage="Solo Numeros"
                        ControlToValidate="valorProductoTextBox"
                        ValidationExpression="^[0-9]*$" />
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ButtonOkay" OnClick="ButtonOkay_Click" ValidationGroup="altaValor" />
                <asp:Button runat="server" Text="Cancelar" ID="ButtonCancel" />
            </div>
        </div>
    </asp:Panel>
    
    <asp:Button id="altaProductoButton" Text="Alta Producto" runat="server" OnClick="altaProductoButton_Click"/>
    <br />
    <asp:Button runat="server" ValidationGroup="altaProveedor" ID="confirmarButton" Text="Confirmar" OnClick="confirmarAltaProveedorButton_Click" />
</asp:Content>
