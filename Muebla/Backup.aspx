<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Backup.aspx.vb" Inherits="Muebla.Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    <table>
        <tr>
            <asp:Label ID="nombreLabel" Text="Nombre" runat="server" />
            <asp:TextBox runat="server" ID="backupTextBox" />
        </tr>

    </table>
    <asp:Button Text="Confirmar" id="confirmarButton" runat="server" OnClick="confirmarButton_Click"    />
</asp:Content>
