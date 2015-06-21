<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="DatosPersonales.aspx.vb" Inherits="Muebla.DatosPersonales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableLogin">
        <tr>
            <td>Calle</td>
            <td class="auto-style1">
                <input id="Text6" type="text" /></td>
        </tr>
        <tr>
            <td>Numero</td>
            <td class="auto-style1">
                <input id="Text7" type="text" /></td>
        </tr>
        <tr>
            <td>Dpto</td>
            <td class="auto-style1">
                <input id="Text8" type="text" /></td>
        </tr>
        <tr>
            <td>Piso</td>
            <td class="auto-style1">
                <input id="Text21" type="text" /></td>
        </tr>
        <tr>
            <td>Localidad</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">CABA</option>
                </select></td>
        </tr>
        <tr>
            <td>Provincia</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">CABA</option>
                </select></td>
        </tr>
        <tr>
            <td>Telefono</td>
            <td class="auto-style1">
                <input id="Text22" type="text" /></td>
        </tr>
        <tr>
            <td>Prefijo</td>
            <td class="auto-style1">
                <input id="Text2" type="text" /></td>
        </tr>
        <tr>
            <td>Interno</td>
            <td class="auto-style1">
                <input id="Text23" type="text" /></td>
        </tr>

        <tr>
            <td>Password</td>
            <td class="auto-style1">
                <input id="Text25" type="text" /></td>
        </tr>
    </table>
    <asp:Button Text="Confirmar" runat="server" />
</asp:Content>
