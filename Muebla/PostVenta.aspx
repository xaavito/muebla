<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PostVenta.aspx.vb" Inherits="Muebla.PostVenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Text1 {
            height: 143px;
            width: 517px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>Nro Factura</td>
            <td class="auto-style1">
                <input id="Text24" type="text" />
                </td>
        </tr>
        <tr>
            <td>Comentarios</td>
            <td class="auto-style1">
               <input id="Text1" type="text" /></td>
        </tr>
        <tr>
            <td>Archivos</td>
            <td class="auto-style1">
                <input type="file" name="datafile"/></td>
        </tr>



    </table>
    <input id="Button2" type="button" value="Confirmar" />
    </div>
    </form>
</body>
</html>
