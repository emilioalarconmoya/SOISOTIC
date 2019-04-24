<%@ Page Language="VB" AutoEventWireup="false" CodeFile="movimiento_x_agno.aspx.vb" Inherits="modulo_gestion_gerencial_movimiento_x_agno" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Movimiento por año</title>
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
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_agno.aspx"><b>Mov. x año</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_mes.aspx"><b>Mov x mes</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_anual.aspx"><b>Gestión anual</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_mensual.aspx"><b>Gestión mensual</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulo_gestion_gerencial/estadisticas.aspx"><b>Estadísticas</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_finan_otic.aspx"><b>Financiamiento otic</b></asp:HyperLink>
                </li>
                <li >
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
        <%--<fieldset id="mantenedor" >
            <div id="filtrosMantenedor">--%>
                <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
                    style="width: 980px; height: 48px">
                    <tr>
                        <th class="Titulo" colspan="11" style="height: 17px" valign="top" width="970">
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
                        <td colspan="2" style="width: 188px; height: 19px" class="AlineacionIzquierda">
                            &nbsp;<asp:Label ID="Label187" runat="server" Font-Bold="True" Text="Ejecutivo"></asp:Label>&nbsp;<asp:DropDownList
                                ID="ddlEjecutivo" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="AlineacionIzquierda" colspan="1" style="height: 19px">
                            <asp:Label ID="Label189" runat="server" Text="Sucursal"></asp:Label>
                            <asp:DropDownList ID="ddlSucursal" runat="server">
                            </asp:DropDownList></td>
                        <td class="AlineacionIzquierda" colspan="2" style="width: 109px; height: 19px">
                            <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Corte :" Width="40px"></asp:Label><asp:DropDownList
                                ID="ddlCorte" runat="server" Width="80px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="center" class="AlineacionIzquierda" style="width: 64px; height: 15px">
                        </td>
                        <td align="center" class="AlineacionIzquierda" colspan="2" style="width: 141px; height: 15px">
                        </td>
                        <td align="center" colspan="2" style="width: 188px; height: 15px">
                            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" /><br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx"
                                Width="152px" />
                        </td>
                        <td align="center" class="AlineacionDerecha" colspan="1" style="height: 15px">
                        </td>
                        <td align="center" class="AlineacionDerecha" colspan="2" style="width: 109px; height: 15px">
                        </td>
                    </tr>
                </table>
                &nbsp;<table class="TablaMantenedor" width="70%" cellpadding="0" cellspacing="0" id="tablaFiltro">
                    <tr>
                        <th style="height: 16px;" class="AlineacionIzquierda" colspan="5">
                            <asp:Label ID="Label1" runat="server" Text="Gestión Global: Comparación anual igual mes"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 13%; height: 19px">
                            <asp:Label ID="Label2" runat="server" Text="Movimientos (MM$)" Font-Bold="True"></asp:Label><%--<asp:Label ID="Label185" runat="server" Font-Bold="True" Text="Movimientos (MM$)"></asp:Label>--%><td
                                class="tabla2" style="width: 100px">
                            <asp:Label ID="lblAgno1" runat="server" Font-Bold="True"></asp:Label></td>
                        <td style="width: 101px; height: 19px">
                            <asp:Label ID="lblAgno2" runat="server" Font-Bold="True"></asp:Label></td>
                        <td colspan="1" style="width: 102px; height: 19px">
                            <asp:Label ID="lblAgno3" runat="server" Font-Bold="True"></asp:Label></td>
                        <td colspan="1" style="width: 101px; height: 19px">
                            <asp:Label ID="lblAgno4" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 13%" class="AlineacionIzquierda">
                            <asp:Label ID="Label3" runat="server" Text="Costo OTIC real (1):"></asp:Label></td>
                        <td style="width: 100px" class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOticReal1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 101px">
                            <asp:Label ID="lblCostoOticReal2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCostoOticReal3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticReal4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 13%" class="AlineacionIzquierda">
                            <asp:Label ID="Label4" runat="server" Text="Costo OTIC excedido (2):" Width="112px"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticExc1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticExc2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCostoOticExc3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticExc4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 13%" class="AlineacionIzquierda">
                            <asp:Label ID="Label5" runat="server" Text="Gasto Empresa (3):"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblGastoEmp1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblGastoEmp2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblGastoEmp3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblGastoEmp4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 13%; height: 15px;">
                            <asp:Label ID="Label8" runat="server" Text="Costo de Administración:" Width="112px"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblCostoAdm1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblCostoAdm2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 15px;">
                            <asp:Label ID="lblCostoAdm3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblCostoAdm4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 13%; height: 15px;">
                            <asp:Label ID="Label9" runat="server" Text="Total (1 + 2 + 3):"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblTotal1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblTotal2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 15px;">
                            <asp:Label ID="lblTotal3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblTotal4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="5">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 13%; height: 15px;">
                            <asp:Label ID="Label12" runat="server" Text="Aportes Neto:"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblAportesNeto1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblAportesNeto2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 15px;">
                            <asp:Label ID="lblAportesNeto3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblAportesNeto4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 13%">
                            <asp:Label ID="Label7" runat="server" Text="Administración:"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAdm1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAdm2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblAdm3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblAdm4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 13%; height: 15px;">
                            <asp:Label ID="Label13" runat="server" Text="Total Aportes:"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblTotalAportes1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblTotalAportes2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 15px;">
                            <asp:Label ID="lblTotalAportes3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblTotalAportes4" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
        <br />
        <table>
            <tr>
                <td align="center" rowspan="2" style="width: 17%">
                    <asp:Literal ID="litGrafico" runat="server"></asp:Literal></td>
            </tr>
            <tr>
            </tr>
        </table>
                &nbsp;<br />
         <%--   </div>
        </fieldset> --%>      
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form><%--
                        </td>--%>
</body>
</html>
