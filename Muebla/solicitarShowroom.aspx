﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="solicitarShowroom.aspx.vb" Inherits="Muebla.solicitarShowroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="fechaSolicitadaLabel" Text="Fecha Solicitada: " runat="server" />
    <asp:TextBox ID="fechaSolicitadaTexBox" runat="server" />
    <asp:RequiredFieldValidator ErrorMessage="Requerido" ControlToValidate="fechaSolicitadaTexBox" runat="server" ValidationGroup="confirmar" />
    <asp:Button id="confirmarButton" Text="Confirmar" runat="server" ValidationGroup="confirmar" OnClick="confirmarButton_Click"/>
</asp:Content>
