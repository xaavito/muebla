<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaIdioma.aspx.vb" Inherits="Muebla.AltaIdioma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label id="nombreIdiomaLabel" Text="Nombre Idioma" runat="server" />
    <asp:TextBox id="nombreIdiomaTextBox" runat="server" />
    <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="nombreIdiomaTextBox" runat="server" ValidationGroup="altaIdioma"/>
    <asp:Button id="confirmarButton" Text="Confirmar" runat="server" ValidationGroup="altaIdioma" OnClick="confirmarButton_Click"/>
</asp:Content>
