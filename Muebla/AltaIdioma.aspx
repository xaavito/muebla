<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AltaIdioma.aspx.vb" Inherits="Muebla.AltaIdioma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Nombre</td>
            <td class="auto-style1">
                <input id="Text1" type="text" /></td>
        </tr>
        
    </table>

    <table id="result">
        <tr>
            <td></td>
            <td>Formulario</td>
            <td>Componente</td>
            <td>Texto</td>

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Main</td>
            <td class="auto-style1">Boton Aceptar</td>
            <td class="auto-style1"><input id="Text2" type="text" /></td>
            

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Main</td>
            <td class="auto-style1">Boton Cancelar</td>
            <td class="auto-style1"><input id="Text3" type="text" /></td>
        </tr>

    </table>
    <input id="Button2" type="button" value="Confirmar" />
    <input id="Button3" type="button" value="Cancelar" />
</asp:Content>
