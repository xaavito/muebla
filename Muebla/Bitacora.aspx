<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Bitacora.aspx.vb" Inherits="Muebla.Bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Table runat="server" ID="tableSearchBitacoraCriteria">
        <asp:TableHeaderRow></asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usuarioTextBox" mask="99/99/9999"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="fechaDesdeLabel" Text="Fecha Desde" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="fechaDesdeDate" mask="99/99/9999"/>       
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="fechaHastaLabel" Text="Fecha Hasta" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="fechaHastaDate"/> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoEventoLabel" Text="Tipo Evento" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="tipoEventoDropDown" EnableViewState="True" OnSelectedIndexChanged="tipoEventoDropDown_SelectedIndexChanged"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button runat="server" ID="buscarButton" Text="Buscar" OnClick="buscarButton_Click"  />

    <asp:GridView runat="server" ID="bitacoraResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="false" PageSize="12"
        ItemType="BE.EventoBE"
        ShowFooter="false" 
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="bitacoraResultadosDataGrid_PreRender"   >
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID"  Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemDescripcion" Text="<%# Item.usr.usuario %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Evento">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTipo"  Text="<%# Item.tipoEvento.texto %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemFecha"  Text="<%# Item.fecha %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
