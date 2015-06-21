<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarIdiomas.aspx.vb" Inherits="Muebla.AdministrarIdiomas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="result">
        <tr>
            <td></td>
            <td>Idioma</td>
            
        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Ingles</td>

            

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Español</td>

        </tr>

    </table>
    <input id="Button2" type="button" value="Modificar" />
    <input id="Button3" type="button" value="Eliminar" />
</asp:Content>
