<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Main.aspx.vb" Inherits="Muebla.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div id="labelPromoDiv">
        <asp:Label ID="promoLabel" Text="Nuestras Promos!" runat="server" />
    </div>
    <div id="promosDiv">
        <div id="listaPromosDiv">
            <asp:ListView runat="server" ID="lvPromos"
                ItemType="BE.ListaPrecioDetalleBE" SelectMethod="listarPromociones">
                <LayoutTemplate>
                    <div class="row">
                        <div runat="server" id="itemPlaceHolder" />
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div runat="server" class="promos-container">
                        <div class="media">
                            <asp:Image ImageUrl='<%#"getImageHandler.ashx?id=" + Convert.ToString(Eval("producto.id"))%>' runat="server" GenerateEmptyAlternateText="False" />
                            <div class="media-body">
                                <asp:Label ID="itemID" Text="<%# Item.id %>" Visible="false" runat="server" />
                                <h3 class="media-heading"><%# Item.producto.descripcion %></h3>
                                <h5 class="media-heading"><%# Item.producto.breveDescripcion %></h5>
                                <asp:Label CssClass="promo" Text="PROMO!!!" runat="server" ID="promoLabel" Visible='<%# Item.esPromo %>' />
                                <asp:Label Text="<%# Item.getPrecio%>" runat="server" ID="precioItem" Visible='<%# Not getUsuario() Is Nothing%>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <asp:Label ID="nothingToShowLabel" Text="No hay nada para mostrar" runat="server" />
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="adfile.xml" CssClass="adrotator" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Tick" ControlID="Timer1" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="3000">
    </asp:Timer>



    <br />
    <asp:ImageButton PostBackUrl="https://www.facebook.com/pages/Muebla/563852150397894?ref=hl" ImageUrl="/images/facebook.png" runat="server" CssClass="adrotator" />
    <br />
    <asp:Image ImageUrl="/images/pasosGenerales.png" runat="server" CssClass="adrotator" />
    <br />
    <div id="formaPago">
        <asp:Image ImageUrl="/images/mercadopago.png" runat="server" />
        <asp:Image ImageUrl="/images/rapipago.png" runat="server" />
    </div>
</asp:Content>
