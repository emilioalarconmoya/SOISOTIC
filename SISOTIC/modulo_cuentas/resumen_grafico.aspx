<%@ Page Language="VB" AutoEventWireup="false" CodeFile="resumen_grafico.aspx.vb" Inherits="modulo_cuentas_resumen_grafico" %>
<%@ Register Src="../contenido/ascx/cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>
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
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script> 
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>


    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />

</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="Button1">
        <asp:Button ID="Button1" runat="server" Text="" Width="1px" Height="1px"/>
        <div id="contenedor">
            <div id="bannner">
                <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
                <uc3:cabeceraUsuario ID="CabeceraUsuario1" runat="server" />
            </div>
            <div id="menu">
                <div id="header">
                    <ul>
                    <li class="pestanaconsolaseleccionada">
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
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../menu.aspx"><b>Menú principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
                    </ul>
            </div> 
        </div>
        <div id="Cabecera">
            <div id="DatosUsuario">
                <uc2:cabecera1 ID="datos_personales1" runat="server" />
            </div>
            <div id="filtros">
                <asp:Label ID="lblEmpresa" runat="server" Text="Cliente :"></asp:Label>
                <asp:DropDownList ID="ddlEmpresa" runat="server" AutoPostBack="True">
                </asp:DropDownList><br />
                <asp:CheckBox ID="chkConsolidada" runat="server" AutoPostBack="True" Text="Información consolidada"
                    Visible="False" /><br />
                <asp:Label ID="lblAgno" runat="server" Text="Año :"></asp:Label>
                <asp:DropDownList ID="ddlAgnos" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>        
        <div id="contenido"> 
            <asp:Label id="lblMensaje" runat="server" Text="Ingrese un Cliente para ver sus datos" Visible="False" Font-Bold="True" Font-Size="Large" CssClass="mensajeGrafico"></asp:Label><div id="resultadosGraficos" runat="server" visible="false">
                <div id="graficos">
                    <div id="grafico1">
                        <asp:Literal ID="litGrafico1" runat="server"></asp:Literal></div>
                    <div id="grafico2">
                        <asp:Literal ID="litGrafico2" runat="server"></asp:Literal></div>
                    <div id="grafico3">
                        <asp:Literal ID="litGrafico3" runat="server"></asp:Literal></div>
                </div> 
                <div id="resumen">
                    <asp:Label ID="lblPregunta1" runat="server" Font-Bold="True" Text="¿Cuanto dinero he utilizado en capacitación durante el año ? "></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="El total del dinero utilizado en capacitación incluyendo, sence, terceros (mas adm) es"></asp:Label>
                    <asp:Label ID="lblRespuesta1" runat="server"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="¿Cuanto dinero he utilizado en concepto de gasto empresa? "></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="El total del dinero en concepto de gasto empresa es"></asp:Label>
                    <asp:Label ID="lblRespuesta12" runat="server"></asp:Label><br />
                    <asp:Label ID="Label6" runat="server" Text="siendo  "></asp:Label>
                    <asp:Label ID="lblGEcapacitacion" runat="server"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Text="por conceptos de capacitación, "></asp:Label>
                    <asp:Label ID="lblGEexCapacitacion" runat="server"></asp:Label>
                    <asp:Label ID="Label19" runat="server" Text="por exc. de capacitación y "></asp:Label>
                    <asp:Label ID="lblGEterceros" runat="server"></asp:Label>
                    <asp:Label ID="Label25" runat="server" Text="por terceros."></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="¿Cuanto dinero he aportado al Otic en el año ?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="El dinero total aportado durante el año es"></asp:Label>
                    <asp:Label ID="lblRespuesta2" runat="server"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="¿Cuanto dinero tengo disponible del año anterior para tomar cursos?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="El dinero restante del periódo anterior es"></asp:Label>
                    <asp:Label ID="lblRespuesta8" runat="server"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="¿Cuanto dinero tengo disponible para mis cursos en el año?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label20" runat="server" Text="El saldo total es de "></asp:Label>
                    <asp:Label ID="lblRespuesta4" runat="server"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="¿Cual es mi deuda a la fecha?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Su deuda es de:  "></asp:Label>
                    <asp:Label ID="lblrespuesta13" runat="server"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="¿Cuanto dinero he invertido en cursos para otras empresas?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="Se han invertido "></asp:Label>
                    <asp:Label ID="lblRespuesta9" runat="server"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="¿Cuantas personas he capacitado durante el año con y sin repetición?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Durante el año se capacitaron "></asp:Label>
                    <asp:Label ID="lblRespuesta3" runat="server"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="¿Quién es mi ejecutivo en el Otic y como lo puedo contactar?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label26" runat="server" Text="El ejecutivo a cargo de la cuenta es" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblRespuesta5" runat="server" Font-Bold="True"></asp:Label><asp:HyperLink
                        ID="hplRespuesta5_1" runat="server">HyperLink</asp:HyperLink>
                    <asp:Label ID="lblRespuesta5_2" runat="server" Text="Label"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="¿Cuantos cursos Sence he gestionado con el otic ?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="El año en curso se han tomado "></asp:Label>
                    <asp:Label ID="lblRespuesta6" runat="server"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="¿Cuantos cursos no sence he gestionado  con el otic?"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Este año se han reflejado"></asp:Label>
                    <asp:Label ID="lblRespuesta7" runat="server"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label27" runat="server" Text="¿Cuantas horas hombre he capacitado en el período?" Font-Bold="True"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblRespuesta10" runat="server"></asp:Label>
                    <asp:Label ID="lblRespuesta11" runat="server"></asp:Label><br />
                </div>
            </div>
        </div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>
        </div>
    </form>    
</body>
</html>
