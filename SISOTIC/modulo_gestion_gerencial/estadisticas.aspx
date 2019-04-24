<%@ Page Language="VB" AutoEventWireup="false" CodeFile="estadisticas.aspx.vb" Inherits="modulo_gestion_gerencial_estadisticas" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Estadísticas</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
<script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script> 
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
                <li >
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_mensual.aspx"><b>Gestión mensual</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
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
                                <td class="AlineacionDerecha" colspan="2" style="height: 19px; width: 109px;">
                                    <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Año :" Width="40px"></asp:Label><asp:DropDownList
                                        ID="ddlAgnos" runat="server" Width="64px">
                                    </asp:DropDownList></td>
                                <td colspan="1" style="width: 58px; height: 19px">
                                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" /></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 64px; height: 15px" align="center">
                                </td>
                                <td class="AlineacionIzquierda" colspan="2" style="width: 141px; height: 15px" align="center">
                                </td>
                                <td colspan="2" style="width: 188px; height: 15px" align="center">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx"
                                        Width="152px" />
                                    </td>
                                <td class="AlineacionDerecha" colspan="1" style="height: 15px" align="center">
                                </td>
                                <td class="AlineacionDerecha" colspan="2" style="height: 15px; width: 109px;" align="center">
                                </td>
                                <td align="center" class="AlineacionDerecha" colspan="1" style="width: 58px; height: 15px">
                                </td>
                            </tr>
                        </table>
                <table class="TablaMantenedor" width="100%" cellpadding="0" cellspacing="0" id="tablaResultados">
                    <tr>
                        <th style="height: 16px;" colspan="15">
                            <asp:Label ID="Label1" runat="server" Text="Gestión Global"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 19px">
                            <asp:Label ID="Label2" runat="server" Text="Estadísticas" Font-Bold="True"></asp:Label><td width="1%">
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
                            <asp:Label ID="Label3" runat="server" Text="Cursos inscritos"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td style="width: 100px" class="AlineacionDerecha" colspan="1">
                            <asp:Label ID="lblCursosInscritos1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCursosInscritos2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblCursosInscritos3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCursosInscritos4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblCursosInscritos5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCursosInscritos6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCursosInscritos7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCursosInscritos8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblCursosInscritos9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblCursosInscritos10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblCursosInscritos11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblCursosInscritos12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalCursosInscritos" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="Label4" runat="server" Text="Participantes"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblParticipantes1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblParticipantes2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblParticipantes3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblParticipantes4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblParticipantes5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblParticipantes6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblParticipantes7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblParticipantes8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblParticipantes9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblParticipantes10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblParticipantes11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblParticipantes12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalParticipantes" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 12%" class="AlineacionIzquierda">
                            <asp:Label ID="lblNivelEdu1" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblSinEscolaridadPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblSinEscolaridadPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblSinEscolaridadPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblSinEscolaridadPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblSinEscolaridadPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblSinEscolaridadPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblSinEscolaridadPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblSinEscolaridadPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblSinEscolaridadPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblSinEscolaridadPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblSinEscolaridadPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblSinEscolaridadPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalSinEscolaridadPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu2" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblBasicaInComplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblBasicaInComplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblBasicaInComplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblBasicaInComplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblBasicaInComplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblBasicaInComplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblBasicaInComplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblBasicaInComplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblBasicaInComplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblBasicaInComplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblBasicaInComplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblBasicaInComplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalBasicaInComplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu3" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblBasicaComplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblBasicaComplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblBasicaComplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblBasicaComplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblBasicaComplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblBasicaComplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblBasicaComplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblBasicaComplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblBasicaComplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblBasicaComplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblBasicaComplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblBasicaComplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalBasicaComplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu4" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            .</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblMediaIncomplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblMediaIncomplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblMediaIncomplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblMediaIncomplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblMediaIncomplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblMediaIncomplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblMediaIncomplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblMediaIncomplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblMediaIncomplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblMediaIncomplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblMediaIncomplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblMediaIncomplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalMediaIncomplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu5" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            .</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblMediaComplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblMediaComplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblMediaComplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblMediaComplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblMediaComplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblMediaComplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblMediaComplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblMediaComplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblMediaComplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblMediaComplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblMediaComplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblMediaComplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalMediaComplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu6" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTecnicaIncomplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTecnicaIncomplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblTecnicaIncomplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTecnicaIncomplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTecnicaIncomplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTecnicaIncomplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTecnicaIncomplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTecnicaIncomplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblTecnicaIncomplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTecnicaIncomplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTecnicaIncomplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTecnicaIncomplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalTecnicaIncomplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu7" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTecnicaComplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTecnicaComplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblTecnicaComplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTecnicaComplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblTecnicaComplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTecnicaComplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTecnicaComplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTecnicaComplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblTecnicaComplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblTecnicaComplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTecnicaComplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblTecnicaComplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalTecnicaComplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu8" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioIncomplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioIncomplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblUniversitarioIncomplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblUniversitarioIncomplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblUniversitarioIncomplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioIncomplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblUniversitarioIncomplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioIncomplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblUniversitarioIncomplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioIncomplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioIncomplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblUniversitarioIncomplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalUniversitarioIncomplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu9" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioComplPart1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioComplPart2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblUniversitarioComplPart3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblUniversitarioComplPart4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblUniversitarioComplPart5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioComplPart6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblUniversitarioComplPart7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioComplPart8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblUniversitarioComplPart9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioComplPart10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioComplPart11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblUniversitarioComplPart12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalUniversitarioComplPart" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                        </td>
                        <td style="width: 3%">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                        </td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="Label5" runat="server" Text="Horas hombre"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblHorasHombre1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblHorasHombre2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblHorasHombre3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblHorasHombre4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblHorasHombre5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblHorasHombre6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblHorasHombre7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblHorasHombre8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblHorasHombre9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblHorasHombre10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblHorasHombre11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblHorasHombre12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalHorasHombre" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu10" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblSinEscolaridadHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblSinEscolaridadHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblSinEscolaridadHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblSinEscolaridadHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblSinEscolaridadHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblSinEscolaridadHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblSinEscolaridadHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblSinEscolaridadHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblSinEscolaridadHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblSinEscolaridadHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblSinEscolaridadHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblSinEscolaridadHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalSinEscolaridadHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 20px">
                            <asp:Label ID="lblNivelEdu11" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%; height: 20px">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblBasicaIncomplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTotalBasicaIncomplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 19px;">
                            <asp:Label ID="lblNivelEdu12" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%; height: 19px;">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 19px;">
                            <asp:Label ID="lblBasicaComplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 19px;">
                            <asp:Label ID="lblTotalBasicaComplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 20px">
                            <asp:Label ID="lblNivelEdu13" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%; height: 20px">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblMediaIncomplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTotalMediaIncomplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 20px">
                            <asp:Label ID="lblNivelEdu14" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%; height: 20px">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblMediaComplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblMediaComplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 20px">
                            <asp:Label ID="lblMediaComplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblMediaComplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblMediaComplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblMediaComplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblMediaComplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblMediaComplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 20px">
                            <asp:Label ID="lblMediaComplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblMediaComplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblMediaComplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblMediaComplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTotalMediaComplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 20px">
                            <asp:Label ID="lblNivelEdu15" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%; height: 20px">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblTecnicaIncomplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTotalTecnicaIncomplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 20px">
                            <asp:Label ID="lblNivelEdu16" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%; height: 20px">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px">
                            <asp:Label ID="lblTecnicaComplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px">
                            <asp:Label ID="lblTotalTecnicaComplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%">
                            <asp:Label ID="lblNivelEdu17" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioIncomplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioIncomplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px">
                            <asp:Label ID="lblUniversitarioIncomplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblUniversitarioIncomplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px">
                            <asp:Label ID="lblUniversitarioIncomplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioIncomplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblUniversitarioIncomplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioIncomplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px">
                            <asp:Label ID="lblUniversitarioIncomplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px">
                            <asp:Label ID="lblUniversitarioIncomplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblUniversitarioIncomplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px">
                            <asp:Label ID="lblUniversitarioIncomplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px">
                            <asp:Label ID="lblTotalUniversitarioIncomplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 12%; height: 20px;">
                            <asp:Label ID="lblNivelEdu18" runat="server" Text="Label"></asp:Label></td>
                        <td style="width: 3%; height: 20px;">
                            :</td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH1" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH2" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 103px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH3" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH4" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 99px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH5" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH6" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH7" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH8" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 58px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH9" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 101px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH10" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH11" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 102px; height: 20px;">
                            <asp:Label ID="lblUniversitarioComplHH12" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" colspan="1" style="width: 100px; height: 20px;">
                            <asp:Label ID="lblTotalUniversitarioComplHH" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                    </tr>
                </table>
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