<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaProducto.aspx.vb" Inherits="Muebla.AltaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Descripcion</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>Precio</td>
            <td class="auto-style1">
                <input id="Text2" type="text" /></td>
        </tr>
        <tr>
            <td>Stock</td>
            <td class="auto-style1">
                <input id="Text3" type="text" /></td>
        </tr>
        <tr>
            <td>Stock Minimo</td>
            <td class="auto-style1">
                <input id="Text4" type="text" /></td>
        </tr>

        <tr>
            <td>Productos</td>
            <td class="auto-style1">
                <textarea id="TextArea1" name="S1" rows="2"></textarea></td>
            <td class="auto-style2">
                <input id="Button1" type="button" value="Agregar Producto" /></td>
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
    <input id="Button2" type="button" value="Confirmar" />
    <input id="Button3" type="button" value="Cancelar" />
</asp:Content>
