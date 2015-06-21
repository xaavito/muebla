<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="Muebla.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/MiEstilo.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tableLogin">
                <tr>
                    <td>Nombre</td>
                    <td class="auto-style1">
                        <input id="Text1" type="text" /></td>
                </tr>
                <tr>
                    <td>Apellido</td>
                    <td class="auto-style1">
                        <input id="Text2" type="text" /></td>
                </tr>
                <tr>
                    <td>Tipo Documento</td>
                    <td class="auto-style1">
                        <select name="ad">
                            <option value="1.htm">DNI</option>
                            <option value="2.htm">CI</option>
                        </select></td>
                </tr>
                <tr>
                    <td>Nro Documento</td>
                    <td class="auto-style1">
                        <input id="Text3" type="text" /></td>
                </tr>
                <tr>
                    <td>CUIL</td>
                    <td class="auto-style1">
                        <input id="Text4" type="text" /></td>
                </tr>
                <tr>
                    <td>Mail</td>
                    <td class="auto-style1">
                        <input id="Text5" type="text" /></td>
                </tr>
                <tr>
                    <td>Calle</td>
                    <td class="auto-style1">
                        <input id="Text6" type="text" /></td>
                </tr>
                <tr>
                    <td>Numero</td>
                    <td class="auto-style1">
                        <input id="Text7" type="text" /></td>
                </tr>
                <tr>
                    <td>Dpto</td>
                    <td class="auto-style1">
                        <input id="Text8" type="text" /></td>
                </tr>
                <tr>
                    <td>Piso</td>
                    <td class="auto-style1">
                        <input id="Text21" type="text" /></td>
                </tr>
                <tr>
                    <td>Localidad</td>
                    <td class="auto-style1">
                        <select name="ad">
                            <option value="1.htm">CABA</option>
                        </select></td>
                </tr>
                <tr>
                    <td>Provincia</td>
                    <td class="auto-style1">
                        <select name="ad">
                            <option value="1.htm">CABA</option>
                        </select></td>
                </tr>
                <tr>
                    <td>Telefono</td>
                    <td class="auto-style1">
                        <input id="Text22" type="text" /></td>
                </tr>
                <tr>
                    <td>Prefijo</td>
                    <td class="auto-style1">
                        <input id="Text2" type="text" /></td>
                </tr>
                <tr>
                    <td>Interno</td>
                    <td class="auto-style1">
                        <input id="Text23" type="text" /></td>
                </tr>
                <tr>
                    <td>Nombre de Usuario</td>
                    <td class="auto-style1">
                        <input id="Text24" type="text" /></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td class="auto-style1">
                        <input id="Text25" type="text" /></td>
                </tr>
            </table>
            <asp:Button Text="Registrarse" runat="server" />
        </div>
    </form>
</body>
</html>
