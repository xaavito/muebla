<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaProveedor.aspx.vb" Inherits="Muebla.AltaProveedor1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Nombre Organizacion o Fantasia</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>CUIT</td>
            <td class="auto-style1">
                <input id="Text2" type="text" /></td>
        </tr>
        <tr>
            <td>Telefono</td>
            <td class="auto-style1">
                <input id="Text3" type="text" /></td>
        </tr>
        <tr>
            <td>Nombre de Contacto</td>
            <td class="auto-style1">
                <input id="Text4" type="text" /></td>
        </tr>
        <tr>
            <td>Direccion</td>
            <td class="auto-style1">
                <input id="Text5" type="text" /></td>
        </tr>
        <tr>
            <td>Email</td>
            <td class="auto-style1">
                <input id="Text6" type="text" /></td>
        </tr>
        <tr>
            <td>Productos</td>
            <td class="auto-style1">
                <textarea id="TextArea1" name="S1" rows="2"></textarea></td>
            <td class="auto-style2">
                <input id="Button1" type="button" value="Agregar Producto" /></td>
        </tr>
    </table>
    <input id="Button2" type="button" value="Confirmar" />
    <input id="Button3" type="button" value="Cancelar" />
</asp:Content>
