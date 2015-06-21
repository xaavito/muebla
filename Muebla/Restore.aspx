<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Restore.aspx.vb" Inherits="Muebla.Restore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table id="result">
        <tr>
            <td></td>
            <td>Nombre</td>
            <td>Fecha</td>
            
        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Cierre Mes</td>
            <td class="auto-style1">10/10/2013 10:12:23</td>
        

        </tr>
        <tr>
            <td> <input type="checkbox" /></td>
            <td class="auto-style1">Cierre Mes</td>
            <td class="auto-style1">10/10/2014 10:12:23</td>

        </tr>

    </table>
    <asp:Button Text="Confirmar" runat="server" />
    <asp:Button Text="Cancelar" runat="server" />
</asp:Content>
