<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_curso_interno.aspx.vb" Inherits="modulo_cursos_ficha_curso_interno" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Ficha de Curso Interno</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
               <div id ="cabecera">
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
                            <li  class="pestanaconsolaseleccionada">
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                            </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                            <li>
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
                                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                            </li>
                        </ul>
                    </div>   
                </div>
            </div>
            <table cellpadding = "0" cellspacing ="0" style="width :100%">
               <tr>
                  <th >
                      <asp:Label ID="Label1" runat="server" Text="Ficha de Curso no sence"></asp:Label>
                  </th>                            
               </tr>
        </table>
    <div id="contenido"> 
         
    <div id="botones">
        <table style="width: 980px; height: 40px;" cellpadding="0" cellspacing="0" class="TablaInterior">
                <tr>
                <td class="AlineacionIzquierda" colspan="1" style="width: 185px; height: 11px">
                </td>
                <td class="AlineacionIzquierda" colspan="2" style="width: 431px; height: 11px">
                    &nbsp;<asp:Label ID="Label2" runat="server" Text="Rut :" Font-Bold="False"></asp:Label><asp:Label ID="lblDCrut" runat="server" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 153px; height: 11px">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label27" runat="server" Text="Dirección : " Font-Bold="False"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 241px; height: 11px">
                    <asp:Label ID="lblDCdireccion" runat="server" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 59px; height: 11px">
                </td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="1" style="width: 185px; height: 12px">
                </td>
                <td class="AlineacionIzquierda" colspan="2" style="width: 431px; height: 12px">
                    &nbsp;<asp:Label ID="Label6" runat="server" Text="Razón Social :" Font-Bold="False"></asp:Label><asp:Label ID="lblDCrazonSocial" runat="server" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 153px; height: 12px">
                    <asp:Label ID="Label29" runat="server" Text="Comuna :" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 241px; height: 12px">
                    <asp:Label ID="lblDCcomuna" runat="server" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 59px; height: 12px">
                </td>
            </tr>
            <tr visible="false">
                <td class="titDatos1" colspan="1" style="width: 185px; height: 12px">
                </td>
                <td class="titDatos1" colspan="2" style="height: 12px; width: 431px;">
                </td>
                <td class="AlineacionDerecha" style="height: 12px; width: 153px;">
                    <asp:Label ID="Label31" runat="server" Text="Ciudad :" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionIzquierda" style="height: 12px; width: 241px;">
                    <asp:Label ID="lblDCciudad" runat="server" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 59px; height: 12px">
                </td>
            </tr>
            
        </table>
        
        <table style="width: 980px;" cellpadding="0" cellspacing="0">
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
                <td valign="top" class="AlineacionDerecha">
                    <asp:Label ID="Label25" runat="server" Text="$"></asp:Label>
                    <asp:Label ID="lblDCIcosto" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="btnVerlistadoCurso" runat="server" Text="Ver Listado de Cursos" />
        &nbsp;&nbsp;<asp:Button ID="btnModificarCurso" runat="server" Text="Modificar Curso" />
        <div id="Div1">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
            <asp:Button ID="btnGeneraPDF" runat="server" Text="Generar PDF" />
      </div>   
        </div>
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
