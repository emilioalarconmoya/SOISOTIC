<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_log.aspx.vb" Inherits="modulo_cursos_reporte_log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BANOTIC</title>
    <link rel="apple-touch-icon" sizes="57x57" href="../favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="../favicon/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="../favicon/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="../favicon/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="../favicon/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="../favicon/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="../favicon/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="../favicon/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="../favicon/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="../favicon/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="../favicon/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="../favicon/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="../favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="../favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="../favicon/mstile-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    
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
