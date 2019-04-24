<%@ Page Language="VB" AutoEventWireup="false" CodeFile="gestion_mensual.aspx.vb" Inherits="modulo_gestion_gerencial_gestion_mensual" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Gestión mensual</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>  
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>   
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
    <div id="menu">
        <div id="header">
            <ul>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_cartera.aspx"><b>Cartera</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_agno.aspx"><b>Mov. x año</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_mes.aspx"><b>Mov x mes</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_anual.aspx"><b>Gestión anual</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_mensual.aspx"><b>Gestión mensual</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulo_gestion_gerencial/estadisticas.aspx"><b>Estadísticas</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_finan_otic.aspx"><b>Financiamiento otic</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_resumen_cliente.aspx"><b>Estado Cliente</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/modulo_gestion_gerencial/ranking_otec.aspx"><b>Ranking otec</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="../menu.aspx"><b>Menú</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
      <%--  <fieldset id="mantenedor" >--%>
            <%--<div id="filtrosMantenedor">--%>
        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
            style="width: 980px; height: 48px">
            <tr>
                <th class="Titulo" colspan="12" style="height: 17px" valign="top" width="970">
                    <asp:Label ID="Label183" runat="server" Text="Filtros de búsqueda"></asp:Label>
                </th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 64px; height: 19px">
                    <asp:Label ID="Label184" runat="server" Font-Bold="True" Text="Emp"></asp:Label>
                    <asp:CheckBox ID="chkEmp" runat="server" /></td>
                <td class="AlineacionIzquierda" colspan="2" style="width: 141px; height: 19px">
                    <asp:Label ID="Label186" runat="server" Font-Bold="True" Text="Rut Empresa: "></asp:Label><asp:TextBox
                        ID="txtRutEmpresa" runat="server" MaxLength="12" Width="88px"></asp:TextBox><asp:CustomValidator
                            ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                            ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un rut válido"
                            ValidationGroup="xx">*</asp:CustomValidator><asp:Button ID="btnPopUpEmpresa" runat="server"
                                Text="..." /></td>
                <td colspan="2" style="width: 188px; height: 19px">
                    &nbsp;<asp:Label ID="Label187" runat="server" Font-Bold="True" Text="Ejecutivo"></asp:Label>&nbsp;<asp:DropDownList
                        ID="ddlEjecutivo" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="AlineacionDerecha" colspan="1" style="height: 19px">
                    <asp:Label ID="Label189" runat="server" Text="Sucursal"></asp:Label>
                    <asp:DropDownList ID="ddlSucursal" runat="server">
                    </asp:DropDownList></td>
                <td class="AlineacionDerecha" colspan="2" style="width: 109px; height: 19px">
                    <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Mes :" Width="40px"></asp:Label><asp:DropDownList
                        ID="ddlMeses" runat="server" Width="64px">
                    </asp:DropDownList></td>
                <td colspan="1" style="width: 58px; height: 19px">
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" /></td>
            </tr>
            <tr>
                <td align="center" class="AlineacionIzquierda" style="width: 64px; height: 15px">
                </td>
                <td align="center" class="AlineacionIzquierda" colspan="2" style="width: 141px; height: 15px">
                </td>
                <td align="center" colspan="2" style="width: 188px; height: 15px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx"
                        Width="152px" />
                </td>
                <td align="center" class="AlineacionDerecha" colspan="1" style="height: 15px">
                </td>
                <td align="center" class="AlineacionDerecha" colspan="2" style="width: 109px; height: 15px">
                </td>
                <td align="center" class="AlineacionDerecha" colspan="1" style="width: 58px; height: 15px">
                </td>
            </tr>
        </table>
                <br />
                &nbsp;<table class="TablaMantenedor" width="90%" cellpadding="0" cellspacing="0" id="tablaFiltro">
                    <tr>
                        <th style="height: 16px;" class="AlineacionIzquierda" colspan="6">
                            <asp:Label ID="Label1" runat="server" Text="Gestión Global"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 19px">
                            <asp:Label ID="Label2" runat="server" Text="Movimientos (MM$)" Font-Bold="True"></asp:Label><td width="1%">
                            </td>
                            <%--<asp:Label ID="Label185" runat="server" Font-Bold="True" Text="Movimientos (MM$)"></asp:Label>--%><td
                                class="AlineacionDerecha">
                                <asp:Label ID="lblAgno1" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha">
                            <asp:Label ID="lblAgno2" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAgno3" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAgno4" runat="server" Font-Bold="True" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label3" runat="server" Text="Costo OTIC real"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOtic1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha">
                            <asp:Label ID="lblCostoOtic2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOtic3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOtic4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label4" runat="server" Text="Costo OTIC excedido"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOticEx1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOticEx2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOticEx3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOticEx4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label5" runat="server" Text="Administración"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAdministracion1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAdministracion2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAdministracion3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAdministracion4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label8" runat="server" Text="Aportes enterados"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAportesEnterados1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAportesEnterados2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAportesEnterados3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAportesEnterados4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 19px;">
                            <asp:Label ID="Label9" runat="server" Text="Aportes pendientes"></asp:Label></td>
                        <td style="width: 3%; height: 19px;">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="height: 19px;">
                            <asp:Label ID="lblAportesPendientes1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAportesPendientes2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAportesPendientes3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblAportesPendientes4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label12" runat="server" Text="Facturas pagadas"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasPagadas1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasPagadas2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasPagadas3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasPagadas4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label7" runat="server" Text="Facturas por pagar"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasXPagar1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasXPagar2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasXPagar3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblFacturasXPagar4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 19px;">
                            <asp:Label ID="Label13" runat="server" Text="Cta Capacitacion"></asp:Label></td>
                        <td style="width: 3%; height: 19px;">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="height: 19px;">
                            <asp:Label ID="lblCtaCap1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="height: 19px;">
                            <asp:Label ID="lblCtaCap2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="height: 19px;">
                            <asp:Label ID="lblCtaCap3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCtaCap4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label14" runat="server" Text="Cta Exc Cap"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCtaExCap1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCtaExCap2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCtaExCap3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCtaExCap4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label15" runat="server" Text="Pago a terceros"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoATerceros1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoATerceros2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoATerceros3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoATerceros4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label16" runat="server" Text="Pago de terceros"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoDeTerceros1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoDeTerceros2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoDeTerceros3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblPagoDeTerceros4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
                <br />
                &nbsp;<br />
                <br />
                <br />
                <br />
                &nbsp;<br />
            <%--</div>--%>
        <%--</fieldset>  --%>     
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>
    </form><%--
                        </td>--%>
</body>
</html>