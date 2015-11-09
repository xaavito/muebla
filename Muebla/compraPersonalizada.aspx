<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="compraPersonalizada.aspx.vb" Inherits="Muebla.compraPersonalizada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tableAltaPedidoPersonalizado">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="descripcionLabel" Text="Descripcion" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="descripcionTextBox" TextMode="multiline" Columns="50" Rows="5" />
                <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="descripcionTextBox" runat="server" ValidationGroup="altaProducto" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="imagenLabel" Text="Imagen" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload runat="server" ID="fileUpload" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button Text="Confirmar" id="confirmarButton" OnClick="confirmarButton_Click" runat="server" />
</asp:Content>
