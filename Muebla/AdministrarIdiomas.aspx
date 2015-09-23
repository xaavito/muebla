﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarIdiomas.aspx.vb" Inherits="Muebla.AdministrarIdiomas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAdministrarIdiomasCriteria">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="idiomaLabel" Text="Idioma" />
            </asp:TableCell><asp:TableCell>
                <asp:DropDownList runat="server" EnableViewState="True" AutoPostBack="True" ID="idiomaDropDownList" OnSelectedIndexChanged="idiomaDropDownList_SelectedIndexChanged" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:GridView runat="server" ID="idiomaResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="false" PageSize="12"
        ItemType="BE.ComponenteBE"
        CssClass="mGrid"  
        PagerStyle-CssClass="pgr"  
        AlternatingRowStyle-CssClass="alt"
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
    </asp:GridView>

    <div runat="server" id="editDiv">
        <asp:Table runat="server" ID="tableEditIdioma">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="textoLabel" Text="texto" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="textoTextBox" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Button runat="server" ID="confirmarButton" Text="Confirmar" OnClick="confirmarButton_Click" />
    </div>
</asp:Content>
