<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_cartera.aspx.vb" Inherits="modulo_gestion_gerencial_reporte_cartera" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Cartera</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
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
               <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_cartera.aspx"><b>Cartera</b></asp:HyperLink>
                </li>
                <li >
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
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
                            style="width:100%; height: 48px">
                            <tr>
                                <th class="Titulo" colspan="10" style="width:90%; height: 17px" valign="top" >
                                    <asp:Label ID="Label183" runat="server" Text="Filtros de búsqueda"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td class="AlineacionDerecha" colspan="2" style="width: 25%; height: 19px">
                                    <asp:Label ID="Label189" runat="server" Text="Sucursal"></asp:Label>
                                    <asp:DropDownList ID="ddlSucursal" runat="server">
                                    </asp:DropDownList></td>
                                <td class="AlineacionDerecha" colspan="2" style="width: 25%; height: 19px">
                                    &nbsp;<asp:Label ID="Label187" runat="server" Font-Bold="True" Text="Ejecutivo"></asp:Label>&nbsp;<asp:DropDownList
                                        ID="ddlEjecutivo" runat="server">
                                    </asp:DropDownList>
                                    </td>
                                <td class="AlineacionDerecha" colspan="1" style="width: 20%;height: 19px">
                                    <asp:Label ID="lbMes" runat="server" Font-Bold="True" Text="Mes :" Width="40px"></asp:Label><asp:DropDownList
                                        ID="DdlMes" runat="server" Width="64px">
                                    </asp:DropDownList>&nbsp;</td>
                                <td class="AlineacionDerecha" colspan="2" style="width: 20%;height: 19px">
                                    <asp:Label ID="lbAño" runat="server" Font-Bold="True" Text="Año :" Width="40px"></asp:Label><asp:DropDownList
                                        ID="ddlAgnos" runat="server" Width="64px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" colspan="2" style="width: 20%; height: 19px">
                                </td>
                                <td colspan="3" style="width: 50%; height: 19px">
                                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" /></td>
                                <td class="AlineacionDerecha" colspan="2" style="width: 20%; height: 19px">
                                </td>
                            </tr>
                        </table>
                <br />
                <table cellpadding="0" cellspacing="0" class="TablaInterior"style="width:100% ; height:200px ">
                    <tr>
                        <td style="width:50%; height: 217px;">
                <table class="TablaMantenedor"  style="width:100%; height:200px  " cellpadding="0" cellspacing="0" id="tablaFiltro">
                    <tr>
                        <th style="height: 17px; width: 60%" class="AlineacionIzquierda" colspan="4">
                            <asp:Label ID="Label1" runat="server" Text="Gestión Global" ></asp:Label></th>
                    </tr>
                    
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="Label2" runat="server" Text="Categoria" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="Label4" runat="server" Text="cantidad" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="Label5" runat="server" Text="porcentaje" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="LbEmpresasAdherentes" runat="server" Text="Empresas adherentes" ></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="lbEmpresasAdherentes1" runat="server" Text="Label" ></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="lbEmpresasAdherentes2" runat="server" Text="Label" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="LbConAportesEnterados" runat="server" Text="Con aportes enterados:" Font-Bold="True"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="lbConAportesEnterados1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="lbConAportesEnterados2" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="LbConActividadIniciales" runat="server" Text="Con actividades iniciadas:" Font-Bold="True"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="LbActividadesIniciadas1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="LbActividadesIniciadas2" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="Label9" runat="server" Text="Con aportes pendientes:" Font-Bold="True"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="LbAportesPendientes1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="LbAportesPendientes2" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="LbConSaldoExcCapacitacion" runat="server" Text="Con saldo exc. capacitacion:" Font-Bold="True"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="LbConSaldoExcCapacitacion1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="LbConSaldoExcCapacitacion2" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="LbConSaldoExcReparto" runat="server" Text="Con saldo exc. reparto:" Font-Bold="True"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="LbConSaldoExcReparto1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="LbConSaldoExcReparto2" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="LbOcupada50" runat="server" Text="FT Ocupada < 50%:" Font-Bold="True"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="LbOcupada501" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="LbOcupada502" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                        <tr>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 16px">
                            <asp:Label ID="LbOcupada25" runat="server" Text="FT Ocupada < 25%:" Font-Bold="True"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width:10%; height: 16px">
                            <asp:Label ID="LbOcupada251" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionIzquierda"style="width:10%; height: 16px">
                            <asp:Label ID="LbOcupada252" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
                        </td>
                        <td style="width: 20%; height: 200px">
                            </td>
                        <td style="width: 30%; height: 200px;">
                            <table style="width: 100%; height:200px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Literal ID="litGrafico" runat="server"></asp:Literal>
                                        </td>
                                </tr>
                            </table>
                            <asp:Label   ID="Label3" runat="server" Font-Bold="True" Text="Activas: con cursos contratados, Pasivas: sin cursos "></asp:Label></td>
                    </tr>
                </table>
            </div>
        </fieldset>       
    </div>
     <div id="pie" onclick="return pie_onclick()">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>

