<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Factura.aspx.vb" Inherits="Muebla.Factura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>FACTURA</h2>
            <h3>NRO 3456910</h3>
            <h3>CLIENTE: JOSE PEREZ</h3>
            <h3>CUIT: 20-384628136-9</h3>
            <h3>NRO PEDIDO: 23244</h3>
            <h4>Fecha Confeccion 10/10/2015</h4>
            <table id="result">
                <tr>
                    <td>Item</td>
                    <td>Cantidad</td>
                    <td>Descripcion</td>
                    <td>Precio</td>

                </tr>
                <tr>

                    <td class="auto-style1">1</td>
                    <td class="auto-style1">1</td>
                    <td class="auto-style1">Mesa tapa marmol</td>
                    <td class="auto-style1">$9000</td>
                </tr>
                <tr>
                    <td class="auto-style1">2</td>
                    <td class="auto-style1">4</td>
                    <td class="auto-style1">Sillas pana celeste</td>
                    <td class="auto-style1">12000</td>
                </tr>

            </table>
            <h4>Total: $21000</h4>
            <asp:Button Text="Confirmar" runat="server" />
        </div>
    </form>
</body>
</html>
