<%@ Page Language="VB" AutoEventWireup="false" CodeFile="movimiento_x_mes.aspx.vb" Inherits="modulo_gestion_gerencial_movimiento_x_mes" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Movimiento por mes</title>
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
                <li class="pestanaconsolaseleccionada">
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
        <%--<fieldset id="mantenedor" >
            <div id="filtrosMantenedor">--%>
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
                            <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Año :" Width="40px"></asp:Label><asp:DropDownList
                                ID="ddlAgno" runat="server" Width="64px">
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
                &nbsp;<table class="TablaMantenedor" width="90%" cellpadding="0" cellspacing="0" id="tablaFiltro">
                    <tr>
                        <th style="height: 16px;" class="AlineacionIzquierda" colspan="15">
                            <asp:Label ID="Label1" runat="server" Text="Gestión Global: Comparación anual igual mes"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 19px">
                            <asp:Label ID="Label2" runat="server" Text="Movimientos (MM$)" Font-Bold="True"></asp:Label><td width="1%">
                            </td>
                            <%--<asp:Label ID="Label185" runat="server" Font-Bold="True" Text="Movimientos (MM$)"></asp:Label>--%><td
                                class="tabla2" style="width: 100px">
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="ENE"></asp:Label></td>
                        <td style="width: 101px; height: 19px">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="FEB"></asp:Label></td>
                        <td colspan="1" style="width: 102px; height: 19px">
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="MAR"></asp:Label></td>
                        <td colspan="1" style="width: 101px; height: 19px">
                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="ABR"></asp:Label></td>
                        <td colspan="1" style="width: 103px; height: 19px">
                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="MAY"></asp:Label></td>
                        <td colspan="1" style="width: 99px; height: 19px">
                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="JUN"></asp:Label></td>
                        <td colspan="1" style="width: 99px; height: 19px">
                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="JUL"></asp:Label></td>
                        <td colspan="1" style="width: 101px; height: 19px">
                            <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="AGO"></asp:Label></td>
                        <td colspan="1" style="width: 102px; height: 19px">
                            <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="SEP"></asp:Label></td>
                        <td colspan="1" style="width: 100px; height: 19px">
                            <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="OCT"></asp:Label></td>
                        <td colspan="1" style="width: 58px; height: 19px">
                            <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="NOV"></asp:Label></td>
                        <td colspan="1" style="width: 101px; height: 19px">
                            <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="DIC"></asp:Label></td>
                        <td colspan="1" style="width: 100px; height: 19px">
                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="TOTAL"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label3" runat="server" Text="Costo OTIC real (1)"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td style="width: 100px" class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOticReal1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 101px">
                            <asp:Label ID="lblCostoOticReal2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCostoOticReal3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticReal4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticReal5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticReal6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticReal7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticReal8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCostoOticReal9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticReal10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticReal11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticReal12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCostoOticReal" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label4" runat="server" Text="Costo OTIC excedido (2)" Width="112px"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticExc1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticExc2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCostoOticExc3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticExc4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticExc5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticExc6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticExc7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticExc8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCostoOticExc9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticExc10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticExc11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticExc12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCostoOticExc" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label5" runat="server" Text="Gasto Empresa (3)"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblGastoEmp1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblGastoEmp2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblGastoEmp3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblGastoEmp4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblGastoEmp5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblGastoEmp6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblGastoEmp7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblGastoEmp8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblGastoEmp9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblGastoEmp10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblGastoEmp11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblGastoEmp12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalGastoEmp" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label8" runat="server" Text="Costo de Administración" Width="112px"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoAdm1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoAdm2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCostoAdm3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoAdm4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoAdm5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoAdm6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoAdm7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoAdm8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCostoAdm9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoAdm10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoAdm11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoAdm12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCostoAdm" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label9" runat="server" Text="Total (1 + 2 + 3)"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotal1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTotal2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblTotal3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTotal4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTotal5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTotal6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTotal7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotal8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblTotal9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTotal10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotal11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTotal12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalTotal" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="15">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label12" runat="server" Text="Aportes Neto"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAportesNeto1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAportesNeto2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblAportesNeto3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblAportesNeto4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblAportesNeto5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAportesNeto6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblAportesNeto7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAportesNeto8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblAportesNeto9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAportesNeto10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAportesNeto11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblAportesNeto12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalAportesNeto" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label7" runat="server" Text="Administración"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAdm1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAdm2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblAdm3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblAdm4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblAdm5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAdm6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblAdm7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAdm8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblAdm9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAdm10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAdm11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblAdm12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalAdm" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label13" runat="server" Text="Total Aportes"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalAportes1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTotalAportes2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblTotalAportes3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTotalAportes4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTotalAportes5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTotalAportes6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTotalAportes7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalAportes8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblTotalAportes9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTotalAportes10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalAportes11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTotalAportes12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalTotalAportes" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
        <br />
        <table>
            <tr>
                <td align="center" rowspan="2" style="width: 440px">
                    <asp:Literal ID="litGrafico" runat="server"></asp:Literal></td>
            </tr>
            <tr>
            </tr>
        </table>
                &nbsp;<br />
                <br />
                <br />
                <br />
                &nbsp;<br />
         <%--   </div>
        </fieldset> --%>      
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

