<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarProveedores.aspx.vb" Inherits="Muebla.AdministrarProveedores" %>

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
            <td>Activo</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Si</option>
                    <option value="2.htm">No</option>
                    <option value="3.htm">Todos</option>
                </select></td>
        </tr>

    </table>
    <input id="Button2" type="button" value="Buscar" />

    <table id="result">
        <tr>
            <td></td>
            <td>Nombre Organizacion o Fantasia</td>
            <td>CUIT</td>
            <td>Telefono</td>
            <td>Nombre de Contacto</td>
            <td>Activo</td>
        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Prueba 1</td>
            <td class="auto-style1">00000000000</td>
            <td class="auto-style1">66666666666</td>
            <td class="auto-style1">Jose Prueba</td>
            <td class="auto-style1">Si</td>

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Prueba 2</td>
            <td class="auto-style1">00000000000</td>
            <td class="auto-style1">66666666666</td>
            <td class="auto-style1">pepe Prueba</td>
            <td class="auto-style1">No</td>

        </tr>

    </table>
    <asp:Button Text="Modificar" runat="server" />
    <asp:Button Text="Baja" runat="server" />
</asp:Content>
