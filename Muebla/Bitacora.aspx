<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Bitacora.aspx.vb" Inherits="Muebla.Bitacora" %>
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
            <td>Fecha Desde</td>
            <td class="auto-style1">
                <input id="Text2" type="text" /></td>
        </tr>
        <tr>
            <td>Fecha Desde</td>
            <td class="auto-style1">
                <input id="Text2" type="text" /></td>
        </tr>
        <tr>
            <td>Tipo Evento</td>
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
            <td>Evento</td>
            <td>Tipo</td>
            <td>Usuario</td>
            <td>Fecha</td>

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Login de Usuario jgonzalez</td>
            <td class="auto-style1">Login</td>
            <td class="auto-style1">jgonzalez</td>
            <td class="auto-style1">10/10/2013 12:53:44</td>
       

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Intento de Logueo</td>
            <td class="auto-style1">Login</td>
            <td class="auto-style1">NULL</td>
            <td class="auto-style1">10/10/2013 12:53:46</td>

        </tr>

    </table>

</asp:Content>
