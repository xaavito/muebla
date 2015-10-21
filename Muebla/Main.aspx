<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Main.aspx.vb" Inherits="Muebla.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="adfile.xml" CssClass="adrotator"/> 
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Tick" ControlID="Timer1" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="3000">
    </asp:Timer>
    <br />
    <asp:ImageButton PostBackUrl="https://www.facebook.com/pages/Muebla/563852150397894?ref=hl"  ImageUrl="/images/facebook.png" runat="server" CssClass="adrotator"/>
    <br />
    <asp:Image ImageUrl="/images/pasosGenerales.png" runat="server" CssClass="adrotator"/>
    <br />  
    <div id="formaPago">
        <asp:Image ImageUrl="/images/mercadopago.png" runat="server" />
        <asp:Image ImageUrl="/images/rapipago.png" runat="server" />
    </div>
    


</asp:Content>
