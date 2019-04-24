<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_curso_interno.aspx.vb" Inherits="Reportes_ficha_curso_interno" %>

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
    
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
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
                <li class="pestanaconsolaseleccionada">
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
                <li>
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
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <th>
                        <asp:Label ID="Label1" runat="server" Text="Ficha de Curso no sence"></asp:Label>
                    </th>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 980px;
                height: 40px">
                <tr>
                    <td class="AlineacionIzquierda" colspan="1" style="width: 185px; height: 11px">
                    </td>
                    <td class="AlineacionIzquierda" colspan="2" style="width: 431px; height: 11px">
                        &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Rut :"></asp:Label><asp:Label
                            ID="lblDCrut" runat="server" Font-Bold="False"></asp:Label></td>
                    <td class="AlineacionDerecha" style="width: 153px; height: 11px">
                        &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label27" runat="server" Font-Bold="False" Text="Dirección : "></asp:Label></td>
                    <td class="AlineacionIzquierda" style="width: 241px; height: 11px">
                        <asp:Label ID="lblDCdireccion" runat="server" Font-Bold="False"></asp:Label></td>
                    <td class="AlineacionIzquierda" style="width: 59px; height: 11px">
                    </td>
                </tr>
                <tr>
                    <td class="AlineacionIzquierda" colspan="1" style="width: 185px; height: 12px">
                    </td>
                    <td class="AlineacionIzquierda" colspan="2" style="width: 431px; height: 12px">
                        &nbsp;<asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Razón Social :"></asp:Label><asp:Label
                            ID="lblDCrazonSocial" runat="server" Font-Bold="False"></asp:Label></td>
                    <td class="AlineacionDerecha" style="width: 153px; height: 12px">
                        <asp:Label ID="Label29" runat="server" Font-Bold="False" Text="Comuna :"></asp:Label></td>
                    <td class="AlineacionIzquierda" style="width: 241px; height: 12px">
                        <asp:Label ID="lblDCcomuna" runat="server" Font-Bold="False"></asp:Label></td>
                    <td class="AlineacionIzquierda" style="width: 59px; height: 12px">
                    </td>
                </tr>
                <tr visible="false">
                    <td class="titDatos1" colspan="1" style="width: 185px; height: 12px">
                    </td>
                    <td class="titDatos1" colspan="2" style="width: 431px; height: 12px">
                    </td>
                    <td class="AlineacionDerecha" style="width: 153px; height: 12px">
                        <asp:Label ID="Label31" runat="server" Font-Bold="False" Text="Ciudad :"></asp:Label></td>
                    <td class="AlineacionIzquierda" style="width: 241px; height: 12px">
                        <asp:Label ID="lblDCciudad" runat="server" Font-Bold="False"></asp:Label></td>
                    <td class="AlineacionIzquierda" style="width: 59px; height: 12px">
                    </td>
                </tr>
            </table>
        
        <table style="width: 980px;">
           <%-- <tr>
                <th colspan="3" class="AlineacionIzquierda">
                    &nbsp;<asp:Label ID="Label12" runat="server" Text="DATOS CURSO INTERNO"></asp:Label></th>
            </tr>--%>
            <tr>
                <th class="AlineacionIzquierda" valign="top" colspan="3">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label17" runat="server" Text="Correlativo"></asp:Label>
                    &nbsp;
                </th>
                <th class="AlineacionIzquierda" colspan="2" valign="top">
                    <asp:Label ID="Label18" runat="server" Text="Curso y OTEC"></asp:Label></th>
                <th valign="top">
                    <asp:Label ID="Label16" runat="server" Text="Costos"></asp:Label></th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="3" valign="top">
                    <asp:Label ID="lblDCIcorrelativo" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Estado :"></asp:Label>
                    <asp:Label ID="lblDCIestado" runat="server"></asp:Label><br />
                    <br />
                    <asp:HyperLink ID="hplCartaInterno" runat="server">Orden de compra</asp:HyperLink></td>
                <td class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="Label9" runat="server" Text="Curso : "></asp:Label>
                    <asp:Label ID="lblDCIcurso" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="OTEC : "></asp:Label>
                    <asp:Label ID="lblDCIotec" runat="server"></asp:Label><br />
                    <asp:Label ID="Label14" runat="server" Text="Alumnos : "></asp:Label>
                    <asp:Label ID="lblDCIalumnos" runat="server"></asp:Label></td>
                <td class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="Label5" runat="server" Text="Número Interno :"></asp:Label>
                    <asp:Label ID="lblDCInumeroInterno" runat="server"></asp:Label><br />
                    <asp:Label ID="Label19" runat="server" Text="Horario :"></asp:Label>
                    <asp:Label ID="lblDCIhorario" runat="server"></asp:Label><br />
                    <asp:Label ID="Label7" runat="server" Text="Horas: "></asp:Label>
                    <asp:Label ID="lblDCIhoras" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label21" runat="server" Text="Observaciones :"></asp:Label><asp:Label
                        ID="lblDCIobservaciones" runat="server"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label25" runat="server" Text="$"></asp:Label>
                    <asp:Label ID="lblDCIcosto" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="btnVerlistadoCurso" runat="server" Text="Ver Listado de Cursos" />
        &nbsp;&nbsp;<asp:Button ID="btnModificarCurso" runat="server" Text="Modificar Curso" />
        <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" /></div>   
        </div>
        </div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>
        
    </form>
</body>
</html>
