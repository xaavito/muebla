<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarProductos.aspx.vb" Inherits="Muebla.AdministrarProductos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />

    <asp:Table runat="server" ID="tableAdministrarProductosCriteria">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreProductoLabel" Text="Nombre Producto" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox runat="server" ID="nombreProductoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoProductoLabel" Text="Tipo Producto" />
            </asp:TableCell><asp:TableCell>
                <asp:DropDownList runat="server" ID="tipoProductoDropDownList" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button runat="server" ID="buscarButton" Text="Buscar" OnClick="buscarProductosButton_Click" />

    <asp:GridView runat="server" ID="productosResultadosDataGrid"
        AutoGenerateColumns="false"
        AllowPaging="true" PageSize="12"
        ItemType="BE.ProductoBE"
        ShowFooter="false"
        CssClass="mGrid"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        OnPreRender="productosResultadosDataGrid_PreRender"
        OnPageIndexChanging="productosResultadosDataGrid_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemID" Text="<%# Item.id %>" Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <asp:Image ImageUrl='<%#"getImageHandler.ashx?id=" + Convert.ToString(Eval("id"))%>' runat="server" GenerateEmptyAlternateText="False" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemDescripcion" Text="<%# Item.descripcion %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo Producto">
                <ItemTemplate>
                    <asp:Label runat="server" ID="itemTipo" Text="<%# Item.tipoProducto.descripcion %>" />
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
        <SortedAscendingHeaderStyle CssClass="asc" />
        <SortedDescendingHeaderStyle CssClass="desc" />
        <SortedAscendingCellStyle CssClass="asc" />
        <SortedDescendingCellStyle CssClass="desc" />
        <PagerSettings Mode="Numeric" PageButtonCount="5" Position="TopAndBottom" />
        <PagerStyle CssClass="grid-pager" />
    </asp:GridView>

    <asp:Button ID="Button1" runat="server" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="lnkEdit_ModalPopupExtender" runat="server"
        CancelControlID="ButtonEditCancel"
        TargetControlID="Button1" PopupControlID="DivEditConfirmation"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupEdit" ID="DivEditConfirmation"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    <asp:Label Text="Edicion" ID="edicionLabel" runat="server" />
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    <asp:Table runat="server" ID="tableEditProducto">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="descripcionLabel" Text="Descripcion" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="descripcionTextBox" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="descripcionBreveLabel" Text="Descripcion Breve" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="descripcionBreveTextBox" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="productosLabel" Text="Productos" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="productosPropiosListBox" OnSelectedIndexChanged="productosPropiosListBox_SelectedIndexChanged"/>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ImageButton runat="server" ID="removerProductoButton" ImageUrl="/images/arrowRight.png" OnClick="removerProductoButton_Click" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ImageButton runat="server" ID="agregarProductoButton" ImageUrl="/images/arrowLeft.png" OnClick="agregarProductoButton_Click" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="allProductosListBox" OnSelectedIndexChanged="allProductosListBox_SelectedIndexChanged"/>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="stockLabel" Text="Stock" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="stockTextBox" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="stockMinimoLabel" Text="Stock Minimo" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="stockMinimoTextBox" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="tipoProductoLabel1" Text="Tipo Producto" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList runat="server" ID="tipoProductoDropDown" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ButtonEditOkay" OnClick="ButtonEditOkay_Click" />
                <asp:Button runat="server" Text="Cancelar" ID="ButtonEditCancel" />
            </div>
        </div>
    </asp:Panel>

    <div id="editDataDiv" runat="server">


        <asp:Button runat="server" ID="confirmarButton" Text="Confirmar" OnClick="confirmarEditProductoButton_Click" />
    </div>
    <asp:Button Text="Orden de Compra" ID="generarOrdenCompraButton" runat="server" OnClick="generarOrdenCompraButton_Click" />
    <asp:Button Text="Comparacion Costos" runat="server" ID="compararCostoButton" OnClick="compararCostoButton_Click" />
</asp:Content>
