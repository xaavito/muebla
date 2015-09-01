<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Registro.aspx.vb" Inherits="Muebla.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableRegistro">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreLabel" Text="Nombre" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="nombreTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="apellidoLabel" Text="Apellido" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="apellidoTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="apellidoTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoDocLabel" Text="Tipo Documento" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList EnableViewState="True" runat="server" ID="tipoDocDropDownList" AutoPostBack="true" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="tipoDocDropDownList" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="documentoLabel" Text="Nro Documento" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="documentoTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="documentoTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="cuilLabel" Text="CUIL" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="cuilTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="cuilTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="mailLabel" Text="Mail" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="mailTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="mailTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="calleLabel" Text="Calle" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="calleTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="calleTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nroCalleLabel" Text="Nro" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nroTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="nroTextBox" runat="server" />
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
                <asp:Label runat="server" ID="telefonoLabel" Text="Telefono" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="telefonoTextBox" TextMode="Phone" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="telefonoTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="prefijoLabel" Text="Prefijo" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="prefijoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="internoLabel" Text="Interno" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="internoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usuarioTextBox" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="usuarioTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="passLabel" Text="Contraseña" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="passTextBox" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="passTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button Text="Registrarse" runat="server" ID="registrarseButton" OnClick="registrarseButton_Click" />


</asp:Content>

