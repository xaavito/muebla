<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Remito.aspx.vb" Inherits="Muebla.Remito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>REMITO</h2>
            <h3>NRO 3456910</h3>
            <h4>Fecha Confeccion 10/10/2015</h4>
            <table id="result">
                <tr>
                    <td>Envio</td>
                    <td>Bultos</td>
                    <td>Direccion</td>
                    <td>Contacto</td>

                </tr>
                <tr>

                    <td class="auto-style1">1</td>
                    <td class="auto-style1">1 Mesa</td>
                    <td class="auto-style1">Boyaca 3455 dpto 1</td>
                    <td class="auto-style1">Jose Lopez</td>
                </tr>
                <tr>
                    <td class="auto-style1">2</td>
                    <td class="auto-style1">Sillas rojas</td>
                    <td class="auto-style1">Miralla 2345</td>
                    <td class="auto-style1">Jorge Mario</td>
                </tr>

            </table>
            <asp:Button Text="Confirmar" runat="server" />
        </div>
    </form>
</body>
</html>
