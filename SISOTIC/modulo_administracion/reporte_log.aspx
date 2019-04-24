<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_log.aspx.vb" Inherits="modulo_cursos_reporte_log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div align="center" class="fondoGris">
            <h1 style="height: 21px">
                <asp:Label ID="lblMensajesDelProceso" runat="server" meta:resourcekey="lblMensajesDelProcesoResource1"
                    Text="Mensajes del proceso"></asp:Label>
            </h1>
            <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                FooterStyle-Font-Bold="true" meta:resourcekey="grdResultadosResource1" ShowFooter="True"
                Width="780px">
                <FooterStyle Font-Bold="True" />
                <Columns>
                    <asp:BoundField HeaderText="Mensajes" meta:resourcekey="BoundFieldResource1" />
                </Columns>
                <HeaderStyle Wrap="False" />
            </asp:GridView>
            <br />
            <br />
            <input id="btnCerrar" onclick="self.close();" type="button" value="Cerrar" />
        </div>
    
    </div>
    </form>
</body>
</html>
