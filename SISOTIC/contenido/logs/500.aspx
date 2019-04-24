<%@ Page Language="VB" AutoEventWireup="false" CodeFile="500.aspx.vb" Inherits="logs_500" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página de Servicio</title>
    <link href="../../estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <table border="1" style="width: 780px">
            <caption style="text-align: center">
                <span style="font-size: 24pt">Se ha presentado una dificultad en el sitio o el sistema
                    permanecido inactivo por un largo periodo de tiempo, sírvase contactar
                    al administrador
                    en caso de error en el sistema</span></caption>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Favor, en caso de error enviar el siguiente archivo comentando lo sucedido:&nbsp; </strong><a href="errapp.txt"><strong>
                        Bitacora</strong></a><strong> (Botón Derecho: Guardar Destino Como...)</strong></td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <strong>MENSAJE 500/SISCAP en</strong><br />
        <br />
        <asp:Label ID="lblOrigen" runat="server" Text="..."></asp:Label></div>
    </form>
</body>
</html>
