<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rechazar_pago_solicitud.aspx.vb" Inherits="modulo_cursos_rechazar_pago_solicitud" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Rechazar pago de factura</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />

</head>
<body id="body" runat="server">
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
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li visible="False">
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Mantenedor Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
           
        </div>   
    </div>
        <%--<table cellpadding="0" cellspacing="0" class="TablaRechazo">
            <tr>
                <td style="width: 192px; height: 31px">
                </td>
                <td style="width: 98px; height: 31px">
                </td>
                <td style="width: 100px; height: 31px">
                </td>
            </tr>
            <tr>
                <td style="width: 192px; height: 31px">
                </td>
                <td class="AlineacionIzquierda" style="width: 98px; height: 31px">
                    <asp:Label ID="lblRechaza" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Small"
                        Text="La Solicitud de Pago ha sido rechazada." Width="288px"></asp:Label><br />
                    <asp:Label ID="lblNoRechaza" runat="server" Font-Bold="True" Font-Size="Small" Text="Problemas al rechazar la Solicitud de Pago."
                        Width="312px"></asp:Label></td>
                <td style="width: 100px; height: 31px">
                </td>
            </tr>
            <tr>
                <td style="width: 192px; height: 31px">
                </td>
                <td style="width: 98px; height: 31px">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp;</td>
                <td style="width: 100px; height: 31px">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 14px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    &nbsp;<asp:Button ID="btnVolver" runat="server" Text="Volver" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                <td style="width: 100px; height: 14px">
                </td>
            </tr>
        </table>--%>
       <div class="TablaRechazo">
        <asp:Label ID="lblRechaza" runat="server" Font-Bold="True" Font-Italic="False"
                        Text="La Solicitud de Pago ha sido rechazada."></asp:Label><br />
                    <asp:Label ID="lblNoRechaza" runat="server" Font-Bold="True" Text="Problemas al rechazar la Solicitud de Pago."></asp:Label>
           <br />
           <br />
           <br />
           <br />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
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
