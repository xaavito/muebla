<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaUsuario.aspx.vb" Inherits="Muebla.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAltaUsuario">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usrTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaUsuario" ErrorMessage="Requerido" ControlToValidate="usrTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreLabel" Text="Nombre" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaUsuario" ErrorMessage="Requerido" ControlToValidate="nombreTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="apellidoLabel" Text="Apellido" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="apellidoTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaUsuario" ErrorMessage="Requerido" ControlToValidate="apellidoTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="mailLabel" Text="Mail" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="mailTextBox" />
                <asp:RequiredFieldValidator ValidationGroup="altaUsuario" ErrorMessage="Requerido" ControlToValidate="mailTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="passLabel" Text="Contraseña" /></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="passTextBox" TextMode="Password"/>
                <asp:RequiredFieldValidator ValidationGroup="altaUsuario" ErrorMessage="Requerido" ControlToValidate="passTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="rolesLabel" Text="Roles" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="rolesPropiosListBox" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton runat="server" ID="removerRolButton" ImageUrl="/images/arrowRight.png" OnClick="removerRolButton_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton runat="server" ID="agregarRolButton" ImageUrl="/images/arrowLeft.png" OnClick="agregarRolButton_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="allRolesListBox" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button runat="server" ID="confirmarAltaUsuarioButton" ValidationGroup="altaUsuario" Text="Confirmar" OnClick="confirmarAltaUsuarioButton_Click"/>
    <asp:Button runat="server" ID="cancelarAltaUsuarioButton" text="Cancelar" OnClick="cancelarAltaUsuarioButton_Click"/>
  
</asp:Content>
