<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OrdenCompra.aspx.vb" Inherits="Muebla.OrdenCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <h2>ORDEN DE COMPRA </h2>
            <h3>NRO 3456910</h3>
            <h3>CLIENTE: LOGISTICA GOMEZ</h3>
            <h3>CUIT: 20-384628136-9</h3>
            <h3>NRO PEDIDO: 23244</h3>
            <h4>Fecha Confeccion 10/10/2015</h4>

            <h3>Direccion de entrega: Newbery 4321</h3>
            <h3>Horario de entrega: ----</h3>

            <table id="result">
                <tr>
                    <td>Producto</td>
                    <td>Cantidad</td>


                </tr>
                <tr>

                    <td class="auto-style1">Tabla Watamboo 1 x 2</td>
                    <td class="auto-style1">1</td>
                </tr>


            </table>

            <asp:Button Text="Confirmar" runat="server" />
    </div>
    </form>
</body>
</html>
