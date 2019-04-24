<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carga_cursos.aspx.vb" Inherits="modulo_cuentas_carga_cursos" %>

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
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
    <script type="text/javascript" >
        function Abrir()
        {
            alert("Llegue");
            window.open("../reportes/reporte_log.aspx","Mensajes",top=0,left=0,width=880,height=560,status=no,toolbar=no,menubar=no,location=no,resizable=no,scrollbars=yes);
            return false;
        }
    </script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" align="center" >
    <div id="contenedor" align="center">
        <div id="bannner" align="center">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
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
        <br />
        <div id="resultadoCarga">
        <asp:FileUpload ID="flpCarga" runat="server" meta:resourcekey="flpCargaResource1" />
        &nbsp;&nbsp;
        <asp:Button ID="btnSubir" runat="server" CausesValidation="False" meta:resourcekey="btnSubirResource1"
            Text="Subir Archivo" Width="88px" />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Volver" Width="88px" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/contenido/Plantilla/Formato Carga.xls">Archivo con formato de la carga</asp:HyperLink><br />
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/contenido/Plantilla/Instructivo de creación Planilla de Cursos.pdf">Archivo con formato para el uso y construcción del archivo para carga</asp:HyperLink><br />
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/contenido/Plantilla/Codigos Comunas.doc">Archivo con  código sence de comunas</asp:HyperLink></div>
    </div>
        <div id="pie">
            <asp:Label ID="lblPie" runat="server" CssClass="textoPie" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: mvaras@oticabif.cl"></asp:Label>
        </div>    
     
    </form>
</body>
</html>
