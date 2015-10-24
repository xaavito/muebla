<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarUsuarios.aspx.vb" Inherits="Muebla.AdministrarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAdministrarUsuariosCriteria">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="usuarioLabel" Text="Usuario" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="usrTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="mailLabel" Text="Mail" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="mailTextBox" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" ID="buscarButton" Text="Buscar" OnClick="buscarUsuariosButton_Click" />

    <asp:GridView runat="server" ID="usuariosResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.UsuarioBE"
        ShowFooter="false" CssClass="mGrid"  
        PagerStyle-CssClass="pgr"  
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="usuariosResultadosDataGrid_PreRender"
        OnPageIndexChanging="usuariosResultadosDataGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemUser" Text="<%# Item.usuario %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mail">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemMail" Text="<%# Item.mail %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Activo">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemActivo" Text="<%# Item.activo %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtnEdit" runat="server"
                        ImageUrl="/images/editItem.png" OnClick="ibtnEdit_Click" />
                    <asp:ImageButton ID="ibtnDelete" runat="server"
                        ImageUrl="/images/deleteItem.png"
                        OnClick="ibtnDelete_Click" />
                    <asp:ImageButton ID="ibtnDetails" runat="server"
                        ImageUrl="/images/detail.png"
                        OnClick="ibtnDetails_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div id="editDataDiv" runat="server">
        <asp:Table runat="server" ID="tableAdminUsuario">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="userLabel" Text="Usuario" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="userTextBox" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="estadoLabel" Text="Estado" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox runat="server" ID="estadoUsuarioCheck" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="permisosLabel" Text="Permisos" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="permisosPropiosListBox" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton runat="server" ID="removerPermisoButton" ImageUrl="/images/arrowRight.png" OnClick="removerPermisoButton_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton runat="server" ID="agregarPermisoButton" ImageUrl="/images/arrowLeft.png" OnClick="agregarPermisoButton_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="allPermisosListBox" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Button runat="server" ID="confirmarButton" Text="Confirmar" OnClick="confirmarButton_Click" />
        <asp:Button runat="server" ID="cancelarButton" Text="Confirmar" OnClick="cancelarButton_Click" />
    </div>
</asp:Content>
