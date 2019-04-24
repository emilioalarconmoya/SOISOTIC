<%@ Page Language="VB" AutoEventWireup="false" CodeFile="resumen.aspx.vb" Inherits="modulo_aporte_resumen" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Resumen Aportes</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script> 
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
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Resumen</b></asp:HyperLink>
                </li>
               <li>
                    <asp:HyperLink ID="hplResumenCobranza" runat="server" NavigateUrl="resumen_cobranza.aspx"><b>Resumen de cobranza</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Reporte aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscadorAportes" runat="server" NavigateUrl="Reporte_buscar_aportes.aspx"><b>Buscador Aportes</b></asp:HyperLink>
                </li>
               <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="Listado_Facturas.aspx"><b>Listado facturas</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplNuevoAporte" runat="server" NavigateUrl="ingreso_aporte.aspx"><b>Nuevo aporte</b></asp:HyperLink>
                </li>
               
                <%--<li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>--%>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        <div id="Cabecera">
            <%--<div id="DatosUsuario">
                <uc2:cabecera1 ID="datos_personales1" runat="server" />
            </div>
            <div id="filtros">
                
            </div>--%>
            <asp:Label ID="Label186" runat="server" Font-Bold="True" Text="Rut Empresa: "></asp:Label><asp:TextBox
                ID="txtRutEmpresa" runat="server" MaxLength="12" Width="88px"></asp:TextBox><asp:CustomValidator
                    ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                    ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un rut válido"
                    ValidationGroup="xx">*</asp:CustomValidator><asp:Button ID="btnPopUpEmpresa" runat="server"
                        Text="..." />
            &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;&nbsp;
            <asp:Label ID="lblAgnos" runat="server" Text="Año :"></asp:Label>
            <asp:DropDownList ID="ddlAgnos" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx"
                Width="152px" CssClass="margenAdvertencia" />
        </div>        
        <div id="contenido">            
            <div id="resultados">
                <br />
                <div id="Grafico1" runat="server">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 500px" valign="top">
                                <table cellpadding="0" cellspacing="0" class="Grid" style="width: 456px">
                                    <tr>
                                        <th class="TituloIzquierda">
                                            <asp:Label ID="Label4" runat="server" Text="Indicador "></asp:Label></th>
                                        <th class="TituloDerecha" colspan="2">
                                            <asp:Label ID="Label5" runat="server" Text="Valor"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 12px">
                                            <asp:Label ID="Label6" runat="server" Text="Aportes Ingresados"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2" style="height: 12px">
                                            <asp:Label ID="lblAportesIngresados" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 12px">
                                            <asp:Label ID="Label7" runat="server" Text="Aportes Cobrados"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2" style="height: 12px">
                                            <asp:Label ID="lblAportesCobrados" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda">
                                            <asp:Label ID="Label8" runat="server" Text="Aportes Anulados"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2">
                                            <asp:Label ID="lblAportesAnulados" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Total Aportes"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2">
                                            <asp:Label ID="lblTotalAportes" runat="server" Font-Bold="True" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda">
                                            <asp:Label ID="Label1" runat="server" Text="Aportes Pendientes (Letra)"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2">
                                            <asp:Label ID="lblAportesPendientesLetra" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda">
                                            <asp:Label ID="Label3" runat="server" Text="Aportes Pendientes (Cheque a fecha)"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2">
                                            <asp:Label ID="lblAportesPendientesCheque" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                </table>
                    </td>
                            <td style="width: 470px" valign="top">
                                <table cellpadding="0" cellspacing="0" class="Grid" style="width: 456px">
                                    <tr>
                                        <th class="TituloIzquierda">
                                            <asp:Label ID="Label12" runat="server" Text="Indicador "></asp:Label></th>
                                        <th class="TituloDerecha" colspan="2">
                                            <asp:Label ID="Label13" runat="server" Text="Valor"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 12px">
                                            <asp:Label ID="Label14" runat="server" Text="Solicitudes Autorizadas"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2" style="height: 12px">
                                            <asp:Label ID="lblSolicitudAutorizada" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 12px">
                                            <asp:Label ID="Label16" runat="server" Text="Solicitudes Rechazadas"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2" style="height: 12px">
                                            <asp:Label ID="lblSolicitudRechazada" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda">
                                            <asp:Label ID="Label19" runat="server" Text="Solicitudes Pendientes"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2">
                                            <asp:Label ID="lblSolicitudPendiente" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda">
                                            <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Total Solicitudes"></asp:Label></td>
                                        <td class="AlineacionDerecha" colspan="2">
                                            <asp:Label ID="lblTotalSolicitudes" runat="server" Font-Bold="True" Text="0"></asp:Label></td>
                                    </tr>
                                </table>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 500px" valign="top">
                                <table>
                                    <tr>
                                        <td align="center" rowspan="2" style="width: 440px">
                                            <asp:Literal ID="litGraficoAportes" runat="server"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 470px" valign="top">
                                <table>
                                    <tr>
                                        <td align="center" rowspan="2" style="width: 440px">
                                            <asp:Literal ID="litGraficoSolicitudes" runat="server"></asp:Literal></td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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
