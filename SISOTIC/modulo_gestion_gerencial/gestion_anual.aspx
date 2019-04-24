<%@ Page Language="VB" AutoEventWireup="false" CodeFile="gestion_anual.aspx.vb" Inherits="modulo_gestion_gerencial_gestion_anual" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gestión anual</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script> 
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>    

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
                <li class="pestanaconsolaseleccionada" >
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
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior">
                            <tr>
                                <th class="Titulo" colspan="11" style="height: 17px" valign="top" width="970">
                                    <asp:Label ID="Label183" runat="server" Text="Filtros de búsqueda"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td style="width: 25%;">
                                    <asp:Label ID="Label186" runat="server" Font-Bold="True" Text="Rut Empresa: "></asp:Label>&nbsp;
                                    <asp:TextBox
                                        ID="txtRutEmpresa" runat="server" MaxLength="12" Width="88px"></asp:TextBox>
                                    <asp:Button ID="btnPopUpEmpresa" runat="server"
                                                Text="..." /></td>
                                <td colspan="2" style="width: 15%;">
                                    <asp:Label ID="Label184" runat="server" Font-Bold="True" Text="Emp"></asp:Label>
                                    <asp:CustomValidator
                                            ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un rut válido"
                                            ValidationGroup="xx">*</asp:CustomValidator>
                                    <asp:CheckBox ID="chkEmp" runat="server" /></td>
                                <td colspan="2" style="width: 20%;">
                                    &nbsp;<asp:Label ID="Label187" runat="server" Font-Bold="True" Text="Ejecutivo"></asp:Label>&nbsp;<asp:DropDownList
                                        ID="ddlEjecutivo" runat="server">
                                    </asp:DropDownList>
                                    </td>
                                <td class="AlineacionDerecha" colspan="1" style="width: 20%;">
                                    <asp:Label ID="Label189" runat="server" Text="Sucursal"></asp:Label>
                                    <asp:DropDownList ID="ddlSucursal" runat="server">
                                    </asp:DropDownList></td>
                                <td colspan="2" style="width: 20%;">
                                    <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Año :" Width="40px"></asp:Label><asp:DropDownList
                                        ID="ddlAgnos" runat="server" Width="64px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="8" style="height: 19px">
                                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" /></td>
                            </tr>
                        </table>
                <br />
                &nbsp;<table class="TablaMantenedor" width="90%" cellpadding="0" cellspacing="0" id="tablaFiltro">
                    <tr>
                        <th style="width: 10%; height: 16px;" class="AlineacionIzquierda" colspan="3">
                            <asp:Label ID="Label1" runat="server" Text="Gestión Global"></asp:Label></th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 101px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 103px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 99px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 99px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 101px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 102px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 100px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 58px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 101px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 100px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 102px; height: 16px">
                        </th>
                        <th class="AlineacionIzquierda" colspan="1" style="width: 100px; height: 16px;">
                        </th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 19px">
                            <asp:Label ID="Label2" runat="server" Text="Movimientos (MM$)" Font-Bold="True"></asp:Label><td width="1%">
                            </td>
                            <asp:Label ID="Label185" runat="server" Font-Bold="True" Text="Movimientos (MM$)"></asp:Label><td
                                class="tabla2" style="width: 100px">
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="ENE"></asp:Label></td>
                        <td style="width: 101px; height: 19px">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="FEB"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 102px; height: 19px">
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="MAR"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 101px; height: 19px">
                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="ABR"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 103px; height: 19px">
                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="MAY"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 99px; height: 19px">
                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="JUN"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 99px; height: 19px">
                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="JUL"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 101px; height: 19px">
                            <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="AGO"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 102px; height: 19px">
                            <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="SEP"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 100px; height: 19px">
                            <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="OCT"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 58px; height: 19px">
                            <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="NOV"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 101px; height: 19px">
                            <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="DIC"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 100px; height: 19px">
                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="TOTAL"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label3" runat="server" Text="Costo OTIC real"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td style="width: 100px" class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCostoOticReal1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 101px">
                            <asp:Label ID="lblCostoOticReal2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCostoOticReal3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticReal4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticReal5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticReal6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticReal7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticReal8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCostoOticReal9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticReal10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticReal11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticReal12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCostoOticReal" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label4" runat="server" Text="Costo OTIC excedido"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticExc1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticExc2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCostoOticExc3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticExc4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCostoOticExc5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticExc6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticExc7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticExc8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCostoOticExc9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCostoOticExc10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCostoOticExc11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCostoOticExc12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCostoOticExc" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%; height: 15px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label5" runat="server" Text="Administración"></asp:Label></td>
                        <td style="width: 3%; height: 15px;">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblAdmin1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblAdmin2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 15px;">
                            <asp:Label ID="lblAdmin3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblAdmin4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblAdmin5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblAdmin6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 15px;">
                            <asp:Label ID="lblAdmin7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblAdmin8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 15px;">
                            <asp:Label ID="lblAdmin9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblAdmin10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblAdmin11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 15px;">
                            <asp:Label ID="lblAdmin12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblTotalAdmin" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="15" style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label8" runat="server" Text="Aportes enterados"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAporteEntregados1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAporteEntregados2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblAporteEntregados3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblAporteEntregados4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblAporteEntregados5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAporteEntregados6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblAporteEntregados7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAporteEntregados8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblAporteEntregados9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblAporteEntregados10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblAporteEntregados11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblAporteEntregados12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalAporteEntregados" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 15px;">
                            <asp:Label ID="Label9" runat="server" Text="Aportes pendientes"></asp:Label></td>
                        <td style="width: 3%; height: 15px;">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblAportespendientes1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblAportespendientes2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 15px;">
                            <asp:Label ID="lblAportespendientes3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblAportespendientes4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 15px;">
                            <asp:Label ID="lblAportespendientes5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblAportespendientes6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 15px;">
                            <asp:Label ID="lblAportespendientes7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblAportespendientes8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 15px;">
                            <asp:Label ID="lblAportespendientes9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 15px;">
                            <asp:Label ID="lblAportespendientes10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblAportespendientes11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 15px;">
                            <asp:Label ID="lblAportespendientes12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 15px;">
                            <asp:Label ID="lblTotalAportespendientes" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="15">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label12" runat="server" Text="Facturas pagadas"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblfacturasPagadas1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblfacturasPagadas2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblfacturasPagadas3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblfacturasPagadas4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblfacturasPagadas5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblfacturasPagadas6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblfacturasPagadas7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblfacturasPagadas8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblfacturasPagadas9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblfacturasPagadas10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblfacturasPagadas11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblfacturasPagadas12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalfacturasPagadas" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label7" runat="server" Text="Facturas por pagar"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblFacturasXPagar1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblFacturasXPagar2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblFacturasXPagar3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblFacturasXPagar4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblFacturasXPagar5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblFacturasXPagar6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblFacturasXPagar7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblFacturasXPagar8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblFacturasXPagar9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblFacturasXPagar10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblFacturasXPagar11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblFacturasXPagar12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalFacturasXPagar" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="15">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label13" runat="server" Text="Cta Capacitacion"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCtaCap1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCtaCap2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCtaCap3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCtaCap4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCtaCap5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCtaCap6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCtaCap7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCtaCap8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCtaCap9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCtaCap10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCtaCap11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCtaCap12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCtaCap" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label14" runat="server" Text="Cta Exc Cap"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCtaExcCap1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCtaExcCap2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCtaExcCap3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCtaExcCap4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCtaExcCap5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCtaExcCap6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCtaExcCap7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCtaExcCap8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCtaExcCap9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCtaExcCap10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCtaExcCap11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCtaExcCap12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCtaExcCap" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label15" runat="server" Text="Pago a terceros"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblPagoATerceros1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblPagoATerceros2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblPagoATerceros3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblPagoATerceros4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblPagoATerceros5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblPagoATerceros6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblPagoATerceros7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblPagoATerceros8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblPagoATerceros9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblPagoATerceros10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblPagoATerceros11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblPagoATerceros12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalPagoATerceros" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label16" runat="server" Text="Pago de terceros"></asp:Label></td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblPagoDeTerceros1" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblPagoDeTerceros2" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblPagoDeTerceros3" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblPagoDeTerceros4" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblPagoDeTerceros5" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblPagoDeTerceros6" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblPagoDeTerceros7" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblPagoDeTerceros8" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblPagoDeTerceros9" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblPagoDeTerceros10" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblPagoDeTerceros11" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblPagoDeTerceros12" runat="server" Text="0"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalPagoDeTerceros" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </table>
                <br />
                &nbsp;<br />
                <br />
                <br />
                <br />
                &nbsp;<br />
            </div>
        </fieldset>       
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
