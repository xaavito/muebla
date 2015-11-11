<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AdministrarProductos.aspx.vb" Inherits="Muebla.AdministrarProductos" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />

    <asp:Table runat="server" ID="tableAdministrarProductosCriteria">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="nombreProductoLabel" Text="Nombre Producto" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="nombreProductoTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="tipoProductoLabel" Text="Tipo Producto" />
            </asp:TableCell>
            <asp:TableCell>
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
                    <asp:ImageButton ID="ibtnComparacion" runat="server"
                        ImageUrl="/images/price_comparison.png"
                        OnClick="ibtnComparacion_Click" 
                        Visible="<%# Item.tipoProducto.id = 1 %>" />
                    <asp:ImageButton ID="ibtnPurchaseOrder" runat="server"
                        ImageUrl="/images/purchaseOrder.png"
                        OnClick="ibtnPurchaseOrder_Click"
                        Visible="<%# Item.tipoProducto.id = 2 %>" />
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
        ID="detailPopup" runat="server"
        CancelControlID="ButtonDetailOK"
        TargetControlID="Button1" PopupControlID="DivDetail"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupComment" ID="DivDetail"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Body">
                <p>
                    <asp:GridView runat="server" ID="detailsPedidos" AutoGenerateColumns="true" ShowHeader="False">
                    </asp:GridView>
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="OK" ID="ButtonDetailOK"/>
            </div>
        </div>
    </asp:Panel>

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
                                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="productosPropiosListBox" OnSelectedIndexChanged="productosPropiosListBox_SelectedIndexChanged" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ImageButton runat="server" ID="removerProductoButton" ImageUrl="/images/arrowRight.png" OnClick="removerProductoButton_Click" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ImageButton runat="server" ID="agregarProductoButton" ImageUrl="/images/arrowLeft.png" OnClick="agregarProductoButton_Click" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:ListBox SelectionMode="Single" EnableViewState="true" AutoPostBack="true" runat="server" ID="allProductosListBox" OnSelectedIndexChanged="allProductosListBox_SelectedIndexChanged" />
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

    <ajaxToolkit:ModalPopupExtender
        ID="comparacionModalPopup" runat="server"
        CancelControlID="okButton"
        TargetControlID="Button1" PopupControlID="DivChart"
        BackgroundCssClass="ModalPopupBG">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupEdit" ID="DivChart"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Body">
                <p>
                    <asp:Chart ID="comparacionChart" runat="server">
                        <Series>
                            <asp:Series Name="Categories" ChartType="Bar" ChartArea="MainChartArea"
                                BorderWidth="2" Color="YellowGreen">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="MainChartArea" Area3DStyle-Enable3D="true"
                                BorderColor="64, 64, 64, 64"
                                BorderDashStyle="Solid" BackSecondaryColor="White"
                                BackColor="64, 165, 191, 228"
                                ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15"
                                    IsRightAngleAxes="False" WallWidth="0" IsClustered="False"></Area3DStyle>
                                <AxisY LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </p>
            </div>
            <div class="popup_Buttons">
                <asp:Button runat="server" UseSubmitBehavior="false" Text="OK" ID="okButton" OnClick="okButton_Click" />
            </div>
        </div>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender
        ID="ordenCompraModal" runat="server"
        CancelControlID="ocCancelButton"
        TargetControlID="Button1" PopupControlID="DivOC"
        BackgroundCssClass="ModalPopupBG"
        BehaviorID="pepe">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel class="popupEdit" ID="DivOC"
        Style="display: none" runat="server">
        <div class="popup_Container">
            <div class="popup_Body">
                <p>
                    <asp:Label runat="server" ID="proveedorLabel" Text="Proveedor" />
                    <asp:DropDownList AutoPostBack="true" ID="proveedorDropDown" runat="server" OnSelectedIndexChanged="proveedorDropDown_SelectedIndexChanged" />
                    <br />
                    <asp:Label ID="precioLabel" Text="Precio" runat="server" />
                    <asp:Label ID="precioProducto" runat="server" />
                    <br />
                    <asp:Label ID="cantidadLabel" Text="Cantidad" runat="server" />
                    <asp:TextBox ID="cantidadTextBox" runat="server" />
                </p>
            </div>
            <div class="popup_Buttons">
                <script>
                    function closePop() {
                        var modalPopupBehavior = $find('pepe');
                        modalPopupBehavior.hide();
                    }
                </script>
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Confirmar" ID="ocOkButton" OnClick="ocOkButton_Click" OnClientClick="closePop()" />
                <asp:Button runat="server" UseSubmitBehavior="false" Text="Cancelar" ID="ocCancelButton" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
