<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarUsuarios.aspx.vb" Inherits="Muebla.AdministrarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
            <td>Nombre Usuario</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>Mail</td>
            <td class="auto-style1">
                <input id="Text2" type="text" /></td>
        </tr>
        <tr>
            <td>Tipo Usuario</td>
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
            <td>Nombre Usuario</td>
            <td>Tipo</td>
            <td>Mail</td>
            <td>Estado</td>
            <td>Acciones</td>
        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">jgonzalez</td>
            <td class="auto-style1">Ventas</td>
            <td class="auto-style1">jgonzalez@gmail.com</td>
            <td class="auto-style1">Activo</td>
            <td class="auto-style1">
                <asp:Button Text="VerDetalle" runat="server" /></td>

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">gperez</td>
            <td class="auto-style1">Cliente</td>
            <td class="auto-style1">gperez@gmail.com</td>
            <td class="auto-style1">Activo</td>

            <td class="auto-style1">
                <asp:Button Text="VerDetalle" runat="server" /></td>

        </tr>

    </table>
    <asp:Button Text="Modificar" runat="server" />
    <asp:Button Text="Baja" runat="server" />
    <asp:Button Text="Desbloquear" runat="server" />
</asp:Content>
