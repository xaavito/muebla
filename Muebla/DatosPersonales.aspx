<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="DatosPersonales.aspx.vb" Inherits="Muebla.DatosPersonales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:Table runat="server" ID="tableRegistro">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreLabel" Text="Nombre" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="apellidoLabel" Text="Apellido" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="apellidoTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoDocLabel" Text="Tipo Documento" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList EnableViewState="True" runat="server" ID="tipoDocDropDownList" AutoPostBack="true" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="documentoLabel" Text="Nro Documento" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="documentoTextBox" Enabled="false" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="cuilLabel" Text="CUIL" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="cuilTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="mailLabel" Text="Mail" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="mailTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="calleLabel" Text="Calle" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="calleTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="nroCalleLabel" Text="Nro" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nroTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="pisoLabel" Text="Piso" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="pisoTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="dptoLabel" Text="Dpto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="dptoTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="provinciaLabel" Text="Provincia" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList EnableViewState="True" runat="server" ID="provinciaDropDownList" OnSelectedIndexChanged="provinciaDropDownList_SelectedIndexChanged" AutoPostBack="true"  Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="localidadLabel" Text="Localidad" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList AutoPostBack="true" EnableViewState="True" runat="server" ID="localidadDropDownList" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="telefonoLabel" Text="Telefono" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="telefonoTextBox" TextMode="Phone" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="prefijoLabel" Text="Prefijo" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="prefijoTextBox" Enabled="false" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible='<%# Not getUsuario().isAdmin %>'>
            <asp:TableCell>
                <asp:Label runat="server" ID="internoLabel" Text="Interno" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="internoTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usuarioTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="passLabel" Text="Contraseña" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="passTextBox" Enabled="false"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button ID="editarButton" Text="Editar" runat="server" OnClick="editarButton_Click" />

    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="lnkEdit_ModalPopupExtender" runat="server"
        CancelControlID="ButtonEditCancel"
        TargetControlID="Button1" PopupControlID="DivEditConfirmation"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupEditConfirmation" ID="DivEditConfirmation"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Edicion" ID="edicionLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:Table runat="server" ID="table1">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="calleLabel1" Text="Calle" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="calleTextBox1" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="nroCalleLabel1" Text="Nro" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="nroCalleTextBox" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="pisoLabel1" Text="Piso" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="pisoTextBox1" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="dptoLabel1" Text="Dpto" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="dptoTextBox1" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="provinciaLabel1" Text="Provincia" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList EnableViewState="True" runat="server" ID="provinciaDropDownList1" OnSelectedIndexChanged="provinciaDropDownList1_SelectedIndexChanged" AutoPostBack="true" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="localidadLabel1" Text="Localidad" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList AutoPostBack="true" EnableViewState="True" runat="server" ID="localidadDropDownList1" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="telefonoLabel1" Text="Telefono" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="telefonoTextBox1" TextMode="Phone" />

                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="prefijoLabel1" Text="Prefijo" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="prefijoTextBox1" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="internoLabel1" Text="Interno" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="internoTextBox1" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="passLabel1" Text="Contraseña" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="passTextBox1" />
                                <asp:RequiredFieldValidator ValidationGroup="editDatosPersonales" ErrorMessage="Requerido" ControlToValidate="passTextBox1" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ButtonEditOkay" OnClick="ButtonEditOkay_Click" ValidationGroup="editDatosPersonales"/>
                <asp:Button runat="server" Text="Cancelar" ID="ButtonEditCancel" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
