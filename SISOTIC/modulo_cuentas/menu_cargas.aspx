<%@ Page Language="VB" AutoEventWireup="false" CodeFile="menu_cargas.aspx.vb" Inherits="modulo_cursos_menu_cargas" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
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
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="contenedor">
            <div id="bannner">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="menu">
                <div id="header">
                    <ul>
                    <li>
                        <asp:HyperLink ID="hplResumenGrafico" runat="server" NavigateUrl="resumen_grafico.aspx"><b>Resumen de gestión</b></asp:HyperLink>
                    </li>
                    <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Cartola resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplPorTramo" runat="server" NavigateUrl="reporte_por_tramo.aspx"><b>Por Tramo</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplCuentas" runat="server" NavigateUrl="reporte_cuentas.aspx" Visible="true" ><b>Cuentas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursoInterno" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos_internos.aspx"><b>Curso interno</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Cargas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplIngresoCurso" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos.aspx" Visible="false"><b>Ingreso curso</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="hplCertificado" runat="server" Target="_blank"  NavigateUrl="certificado_aportes.aspx"><b>Certif. aportes</b></asp:HyperLink>
                </li>                
                <li >
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../menu.aspx"><b>Menú principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
                </div>
            </div>
            <div id="contenido">
                <div id="resultados">
                    <table align="center" style="width: 296px">
                        <tr>
                            <td align="center" style="width: 54%">
                                <span style="font-size: 16pt">Menú de Cargas</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 54%">
                                <asp:Menu ID="Menu1" runat="server" Style="position: static">
                                    <DynamicMenuStyle CssClass="Menu" />
                                    <Items>
                                        <asp:MenuItem NavigateUrl="~/modulo_cuentas/CargaCursos.aspx" Text="Carga de curso mediante archivo xls"
                                            Value="M&#243;dulo Cursos Presenciales"></asp:MenuItem>
                                        <%-- <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_cursos_mdb.aspx" Text="Carga de cursos mediante archivo mdb"
                                            Value="M&#243;dulo Cursos E-Learning (CVC)"></asp:MenuItem>
                                        <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_web_service.aspx" Text="Carga web service" Value="Presupuesto">
                                        </asp:MenuItem>--%>
                                    </Items>
                                </asp:Menu>
                                <asp:Menu ID="Menu2" runat="server" Style="position: static">
                                    <DynamicMenuStyle CssClass="Menu" />
                                    <Items>
                                        <asp:MenuItem NavigateUrl="~/modulo_cuentas/carga_curso_interno.aspx" Text="Carga de curso interno mediante archivo xls"
                                            Value="M&#243;dulo Cursos Presenciales"></asp:MenuItem>
                                        <%-- <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_cursos_mdb.aspx" Text="Carga de cursos mediante archivo mdb"
                                            Value="M&#243;dulo Cursos E-Learning (CVC)"></asp:MenuItem>
                                        <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_web_service.aspx" Text="Carga web service" Value="Presupuesto">
                                        </asp:MenuItem>--%>
                                    </Items>
                                </asp:Menu>
                            </td>
                        </tr>
                    </table>
                </div>
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
