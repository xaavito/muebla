<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Backup.aspx.vb" Inherits="Muebla.Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView runat="server" ID="backupDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="false" PageSize="12"
        ItemType="BE.BackupBE"
        ShowFooter="false" CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="backupDataGrid_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" class="pull-right" Text="<%# Item.id%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemDescripcion" class="pull-right" Text="<%# Item.descripcion%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Path">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemPath" class="pull-right" Text="<%# Item.path %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemFecha" class="pull-right" Text="<%# Item.fecha %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnDelete_Click"   />
                    <asp:ImageButton ID="ibtnRestore" runat="server"
                        ImageUrl="/images/backup-restore.png"
                        OnClick="ibtnRestore_Click"   />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <table>
        <tr>
            <asp:Label ID="nombreLabel" Text="Nombre" runat="server" />
            <asp:TextBox runat="server" ID="backupTextBox" />
        </tr>
    </table>
    <asp:Button Text="Confirmar" id="confirmarButton" runat="server" OnClick="confirmarButton_Click"    />
</asp:Content>
