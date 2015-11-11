<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Login.aspx.vb" Inherits="Muebla.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableLogin" CssClass="table">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usrTextBox" />
                <asp:RequiredFieldValidator ValidationGroup='login' ErrorMessage="Requerido" ControlToValidate="usrTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="passLabel" Text="Contraseña" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="passTextBox" TextMode="Password" />
                <asp:RequiredFieldValidator ValidationGroup='login' ErrorMessage="Requerido" ControlToValidate="passTextBox" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label Text="" runat="server" ID="loginFailed" />
    <asp:Button ID="confirmarButton" Text="Confirmar" runat="server" OnClick="login" ValidationGroup='login' />
    <asp:LinkButton ID="recuperarPassButton" Text="Olvido su contraseña" runat="server" OnClick="recuperarPass_Click" />
    <asp:LinkButton ID="registroButton" Text="Registro" runat="server" OnClick="registroButton_Click" />
</asp:Content>
