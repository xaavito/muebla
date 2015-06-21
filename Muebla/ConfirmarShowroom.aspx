<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ConfirmarShowroom.aspx.vb" Inherits="Muebla.ConfirmarShowroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table id="result">
        <tr>
            <td></td>
            <td>Cliente</td>
            <td>Ventas</td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" /></td>
            <td class="auto-style1">jgonzalez</td>
            <td class="auto-style1">5</td>

        </tr>
        <tr>
            <td>
                <input type="checkbox" /></td>
            <td class="auto-style1">lsuarez</td>
            <td class="auto-style1">1</td>
        </tr>

    </table>
    <asp:Button Text="Asignar" runat="server" OnClick="asignar"/>
</asp:Content>
