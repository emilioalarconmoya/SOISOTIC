<%@ Page Language="VB" AutoEventWireup="false" CodeFile="menu.aspx.vb" Inherits="menu" %>

<%--<%@ Register Src="../contenido/ascx/cabeceraUsuario.ascx" TagName="cabecerausuario" TagPrefix="uc2" %>--%>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BANOTIC</title>
    <link rel="apple-touch-icon" sizes="57x57" href="favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="favicon/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="favicon/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="favicon/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="favicon/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="favicon/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="favicon/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="favicon/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="favicon/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="favicon/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="favicon/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="favicon/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="favicon/mstile-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    <link href="estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="bannner">
                <img src="include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="menu">
                <div id="header">
                </div>
            </div>
            <div id="Cabecera">
                <div id="DatosUsuario">
                </div>
                <div id="filtros">
                </div>
            </div>
            <div id="contenido">
                <div id="cssmenu">
                    <h2>
                        Menú de Administración
                    </h2>
                    <ul>
                        <li id="liModAdm" runat="server" class='active'><a href="modulo_administracion/menu_administracion.aspx">
                            Módulo de administración </a></li>
                        <li id="liModCue" runat="server"><a href="modulo_cuentas/home.aspx">Módulo de cuentas
                        </a></li>
                        <li id="liModCur" runat="server"><a href="modulo_cursos/reporte_cursos.aspx">Módulo
                            de cursos </a></li>
                        <li id="liModApo" runat="server"><a href="modulo_aporte/resumen.aspx">Módulo de aportes
                        </a></li>
                        <li id="liModGes" runat="server"><a href="modulo_gestion_gerencial/acciones_liquidadas.aspx">
                            Módulo de gestión gerencial </a></li>
                        <li><a href="fin_sesion.aspx">Terminar sesión y salir </a></li>
                    </ul>
                </div>
            </div>
            <div id="pie">
                <div class="textoPie">
                    <asp:Label ID="lblPie" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
