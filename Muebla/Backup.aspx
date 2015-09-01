<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Backup.aspx.vb" Inherits="Muebla.Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView runat="server" ID="backupDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.BackupBE"
        ShowFooter="false" CssClass="table table-bordered table-condensed"
        EmptyDataText="No record found!"
        EmptyDataRowStyle-CssClass="gvEmpty"
        OnRowDataBound="bitacoraDataGrid_RowDataBound"  >
        <Columns>
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
                        OnClientClick="javascript:return confirm('Do you want to delete it?');"
                        OnClick="ibtnDelete_Click"   />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SortedAscendingHeaderStyle CssClass="asc" />
        <SortedDescendingHeaderStyle CssClass="desc" />
        <SortedAscendingCellStyle CssClass="asc" />
        <SortedDescendingCellStyle CssClass="desc" />
        <PagerSettings Mode="Numeric" PageButtonCount="5" Position="TopAndBottom" />
        <PagerStyle CssClass="grid-pager" />
    </asp:GridView>
    
    <table>
        <tr>
            <asp:Label ID="nombreLabel" Text="Nombre" runat="server" />
            <asp:TextBox runat="server" ID="backupTextBox" />
        </tr>
    </table>
    <asp:Button Text="Confirmar" id="confirmarButton" runat="server" OnClick="confirmarButton_Click"    />
</asp:Content>
