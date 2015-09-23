<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarIdiomas.aspx.vb" Inherits="Muebla.AdministrarIdiomas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAdministrarIdiomasCriteria">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="idiomaLabel" Text="Idioma" />
            </asp:TableCell><asp:TableCell>
                <asp:DropDownList runat="server" ID="idiomaDropDownList" OnSelectedIndexChanged="idiomaDropDownList_SelectedIndexChanged" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button runat="server" ID="buscarButton" Text="Buscar" OnClick="buscarButton_Click" />

    <asp:GridView runat="server" ID="idiomaResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="false" PageSize="12"
        ItemType="BE.ComponenteBE"
        ShowFooter="false" CssClass="table table-bordered table-condensed"
        EmptyDataRowStyle-CssClass="gvEmpty"
        OnPreRender="idiomaResultadosDataGrid_PreRender">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemNombre" Text="<%# Item.nombre %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Texto">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTexto" Text="<%# Item.texto %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png" OnClick="ibtnEdit_Click" />
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
</asp:Content>
