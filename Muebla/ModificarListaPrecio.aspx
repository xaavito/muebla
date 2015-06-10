<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ModificarListaPrecio.aspx.vb" Inherits="Muebla.ModificarListaPrecio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
       <tr>
            <td>Activo</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Si</option>
                </select></td>
        </tr>
        <tr>
            <td>Tipo Venta</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Mayor</option>
                    <option value="2.htm">Menor</option>
                    <option value="2.htm">Todos</option>
                </select></td>
        </tr>
    </table>
    <input id="Button2" type="button" value="Buscar" />

    <table>
        <tr>
            <td></td>
            <td>Tipo Lista</td>
            <td>Activo</td>
            <td>Fecha desde</td>
            <td>Fecha Hasta</td>
            <td>Accion</td>
            
        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">
                <input id="Text112" type="text" value="Minorista"/></td>
            <td class="auto-style1">
                <input id="Text223" type="text" value="Si"/></td>
            <td class="auto-style1">
                <input id="Text224" type="text" value="01/02/2010"/></td>
            <td class="auto-style1">
                <input id="Text22" type="text" value=""/></td>
            <td class="auto-style1">
                <input id="Button22" type="button" value="Detalle" /></td>
        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">
                <input id="Text111" type="text" value="Mayorista"/></td>
            <td class="auto-style1">
                <input id="Text21" type="text" value="Si"/></td>
            <td class="auto-style1">
                <input id="Text26" type="text" value="01/02/2011"/></td>
            <td class="auto-style1">
                <input id="Text27" type="text" value=""/></td>
            <td class="auto-style1">
                <input id="Button21" type="button" value="Detalle" /></td>
        </tr>
    </table>
    <asp:Button ID="Button3" type="button" text="Modificar" OnClick="Button3_Click" runat="server" />
</asp:Content>
