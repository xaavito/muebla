<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarProductos.aspx.vb" Inherits="Muebla.AdministrarProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Nombre Producto</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>Tipo Producto</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Final</option>
                    <option value="2.htm">Materia Prima</option>
                </select></td>
        </tr>
    </table>
    <input id="Button2" type="button" value="Buscar" />

    <table id="result">
        <tr>
            <td>Producto</td>
            <td>Tipo</td>
            <td>Precio</td>
            <td>Accion</td>
        </tr>
        <tr>
            <td class="auto-style1">Mesa</td>
            <td class="auto-style1">Final</td>
            <td class="auto-style1">$1200</td>
            <td class="auto-style1">
                <asp:Button Text="Ver Detalle" runat="server" />
                <asp:Button Text="Modificar" runat="server" />
                <asp:Button Text="Borrar" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Tabla Madera Wengue</td>
            <td class="auto-style1">Materia Prima</td>
            <td class="auto-style1">$120</td>
            <td class="auto-style1">
                <asp:Button Text="Ver Detalle" runat="server" />
                <asp:Button Text="Modificar" runat="server" />
                <asp:Button Text="Borrar" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
