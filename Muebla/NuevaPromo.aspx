﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NuevaPromo.aspx.vb" Inherits="Muebla.NuevaPromo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Monto Descuento</td>
                    <td class="auto-style1">
                        <input id="Text223" type="text" /></td>
                </tr>
                <tr>
                    <td>Tipo Aumento</td>
                    <td class="auto-style1">
                        <select name="ad">
                            <option value="1.htm">Valor</option>
                            <option value="2.htm">Porcentaje</option>
                        </select></td>
                </tr>
                <tr>
                    <td>Fecha Desde</td>
                    <td class="auto-style1">
                        <input id="Text2213" type="text" /></td>
                </tr>
                <tr>
                    <td>Fecha Hasta</td>
                    <td class="auto-style1">
                        <input id="Text21" type="text" /></td>
                </tr>
            </table>
            <input id="Button2" type="button" value="Confirmar" />
            <input id="Button3" type="button" value="Cancelar" />
        </div>
    </form>
</body>
</html>
