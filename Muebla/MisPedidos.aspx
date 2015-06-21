<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="MisPedidos.aspx.vb" Inherits="Muebla.MisPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Estado de Venta</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Todos</option>
                </select></td>
        </tr>
        <tr>
            <td>Cliente</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Todos</option>
                </select></td>
        </tr>
        <tr>
            <td>Producto</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Todos</option>
                </select></td>
        </tr>
        <tr>
            <td>Tipo de Producto</td>
            <td class="auto-style1">
                <select name="ad">
                    <option value="1.htm">Todos</option>
                </select></td>
        </tr>



    </table>
    <input id="Button2" type="button" value="Buscar" />

    <table id="result">
        <tr>
            <td></td>
            <td>Fecha Venta</td>
            <td>Cliente</td>
            <td>Valor</td>
            <td>Estado</td>
            <td>Accion</td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" /></td>
            <td class="auto-style1">01/02/2010</td>
            <td class="auto-style1">jgonzalez</td>
            <td class="auto-style1">$12345,54</td>
            <td class="auto-style1">Concretada</td>
            <td class="auto-style1"><asp:Button Text="Ver Detalle" runat="server" /></td>

        </tr>
        <tr>
            <td>
                <input type="checkbox" /></td>
            <td class="auto-style1">01/02/2010</td>
            <td class="auto-style1">02/04/2013</td>
            <td class="auto-style1">$432</td>
            <td class="auto-style1">Post Venta</td>
            <td class="auto-style1"><asp:Button Text="Ver Detalle" runat="server" /></td>
        </tr>

    </table>
    <asp:Button Text="Cancelar" runat="server" OnClick="cancelarVenta"/>
    <asp:Button Text="Generar Hoja de ruta" runat="server" OnClick="hojaDeRuta"/>
    <asp:Button Text="Generar Remito" runat="server" OnClick="remito"/>
    <asp:Button Text="Generar Factura" runat="server" OnClick="factura"/>
    <asp:Button Text="Generar Nota de Credito" runat="server" OnClick="notaCredito"/>
    <asp:Button Text="Generar Comentarios" runat="server" OnClick="comentario"/>
    <asp:Button Text="Servicio Post Venta" runat="server" OnClick="postVenta"/>
</asp:Content>
