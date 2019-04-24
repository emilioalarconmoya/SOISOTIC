<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carga_cursos_xls_adm.aspx.vb" Inherits="modulo_administracion_carga_cursos_xls_adm" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Carga de Cursos</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
    <script type="text/javascript" >
        function Abrir()
        {
            window.open("../reportes/reporte_log.aspx","Mensajes",top=0,left=0,width=880,height=560,status=no,toolbar=no,menubar=no,location=no,resizable=no,scrollbars=yes);
            return false;
        }
    </script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div>
        <div id="contenedor" align="center">
            <div id="bannner" align="center">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="menu">
                <div id="header">
                    <ul>
                <%--<li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl="mantenedor_cursos_internos.aspx"><b>Curso no Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="buscador_cursos.aspx"><b>Buscar curso</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>--%>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx"><b>Menú administración</b></asp:HyperLink>
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
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/contenido/Plantilla/Instructivo de creación Planilla de Cursos.pdf">instructivo</asp:HyperLink><br />
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/contenido/Plantilla/Codigos Comunas.doc">Archivo con  código sence de comunas</asp:HyperLink><br />
                <br />
                <br />
                <br />
                <br />
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
