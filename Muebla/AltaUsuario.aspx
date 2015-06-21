<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaUsuario.aspx.vb" Inherits="Muebla.AltaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Usuario</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>Nombre</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>Apellido</td>
            <td class="auto-style1">
                <input id="Text2" type="text" /></td>
        </tr>
        <tr>
            <td>Mail</td>
            <td class="auto-style1">
                <input id="Text3" type="text" /></td>
        </tr>
        <tr>
            <td>Contraseña</td>
            <td class="auto-style1">
                <input id="Text4" type="text" /></td>
        </tr>
        <tr>
            <td>Roles</td>
            <td class="auto-style1">
                <textarea id="TextArea1" name="S1" rows="2"></textarea></td>
            <td class="auto-style2">
                <input id="Button1" type="button" value="Agregar Rol" /></td>
        </tr>
    </table>
    <input id="Button2" type="button" value="Confirmar" />
    <input id="Button3" type="button" value="Cancelar" />
</asp:Content>
