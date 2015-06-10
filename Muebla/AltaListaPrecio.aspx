<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaListaPrecio.aspx.vb" Inherits="Muebla.AltaListaPrecio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Fecha</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>Tipo Venta</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Mayor</option>
                    <option value="2.htm">Menor</option>
                </select></td>
        </tr>
    </table>
    <table>
        <tr>
            <td>Producto</td>
            <td>Precio</td>
            
        </tr>
        <tr>
            <td class="auto-style1">
                <input id="Text11" type="text" value="Producto 1"/></td>
            <td class="auto-style1">
                <input id="Text2" type="text" value="1000"/></td>
            
        </tr>
        <tr>
            <td class="auto-style1">
                <input id="Text3" type="text" value="Producto 2"/></td>
            <td class="auto-style1">
                <input id="Text4" type="text" value="2000"/></td>
            
        </tr>
    </table>
    <input id="Button2" type="button" value="Confirmar" />
    <input id="Button3" type="button" value="Cancelar" />
</asp:Content>
