<%@ Page Language="VB" AutoEventWireup="false" CodeFile="actualizar_sol_pagos_terceros.aspx.vb" Inherits="modulo_cursos_actualizar_sol_pagos_terceros" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Autorización de solicitud</title>
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
        <%--<div id="contenido">            
            <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 980px">
                <tr>
                    <td style="width: 192px; height: 31px">
                    </td>
                    <td style="width: 100px; height: 31px">
                    </td>
                    <td style="width: 100px; height: 31px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 31px">
                    </td>
                    <td style="width: 100px; height: 31px">
                        <asp:Label ID="lblAutoriza" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Small"
                            Text="Autorizacion Exitosa de Solicitud de Pago." Width="312px"></asp:Label>
                        <asp:Label ID="lblNoAutoriza" runat="server" Font-Bold="True" Font-Size="Small"
                            Text="Problemas al Autorizar la Solicitud de Pago." Width="320px"></asp:Label></td>
                    <td style="width: 100px; height: 31px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 31px">
                    </td>
                    <td style="width: 100px; height: 31px">
                        &nbsp;</td>
                    <td style="width: 100px; height: 31px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 14px;" colspan="2">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" /></td>
                    <td style="width: 100px; height: 14px;">
                    </td>
                </tr>
            </table>
        
    </div>--%>
    <div class="TablaRechazo">
        <asp:Label ID="lblAutoriza" runat="server" Font-Bold="True" Font-Italic="False"
                        Text="Autorizacion Exitosa de Solicitud de Pago."></asp:Label><br />
                    <asp:Label ID="lblNoAutoriza" runat="server" Font-Bold="True" Text="Problemas al Autorizar la Solicitud de Pago."></asp:Label>
           <br />
           <br />
           <br />
           <br />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
       </div>
    </div>
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>    
    </form>
</body>
</html>
