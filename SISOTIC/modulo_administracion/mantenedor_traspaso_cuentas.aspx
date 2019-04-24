<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_traspaso_cuentas.aspx.vb" Inherits="modulo_administracion_mantenedor_traspaso_cuentas" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Traspaso de Fondos</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
     <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>
      <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
    <div>
        <div id="contenedor">
            <div id="bannner">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="menu">
        <div id="header">
            <ul>
                <%--<li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="#"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="../modulo_cursos/reporte_cursos.aspx"><b>Reporte cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="#"><b>Buscar curso</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="#"><b>Carga de cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="../modulo_cursos/pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="#"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="../modulo_cursos/mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl="#"><b>Curso no Sence</b></asp:HyperLink>
                </li>--%>
                <li >
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx"><b>Menú Administración</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
                        <table id="tablaFiltros2" runat="server" cellpadding="0" cellspacing="0" class="Grid"
                            >
                            <tr>
                                <th class="Titulo" colspan="1" valign="top" style="width: 1006px; height: 9px;">
                                    <asp:Label ID="Label17" runat="server" Text="Filtros de búsqueda"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td style="width: 1006px; height: 25px;">
                                    <asp:Label ID="Label21" runat="server" Font-Bold="False" Text="Rut cliente :"></asp:Label>
                                    &nbsp;
                                    <asp:TextBox ID="txtRutEmpresa" runat="server"></asp:TextBox><asp:CustomValidator
                                        ID="CustomValidator" runat="server" ClientValidationFunction="VerificarRut"
                                        ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un RUT válido"
                                        ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator><asp:Button ID="btnBuscarEmpresa"
                                            runat="server" Text="..." />
                                    <asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Año :"></asp:Label><span
                                        style="color: #ff0000"> </span>
                                    <asp:DropDownList ID="ddlAgnos" runat="server">
                                    </asp:DropDownList>
                                    &nbsp; &nbsp;&nbsp;
                                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="ValidaRutAlumno" /><br />
                                    <br />
                                    <asp:Label ID="lblNombreEmpresa" runat="server" Font-Bold="True" Visible="False"></asp:Label><br />
                                    <br />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaRutAlumno" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   
                                    <div id="datos" style="float: left; margin:0px; padding:0px; border:0px; margin-left:50px; margin-right:5px; margin-top:5px;" >
                                    <table style="width: 288px; margin:0px; padding:0px; border:0px;" cellpadding="0" cellspacing="0" >
                                        <tr>
                                            <th style="width: 145px; height: 17px; text-align: left;">
                                                Cuenta</th>
                                            <th style="width: 325px; height: 17px; text-align: left;">
                                                Saldo</th>
                                        </tr>
                                        <tr>
                                            <td style="width: 145px; text-align: left; height: 18px;">
                                                <span style="color: #ff0000">
                                                Capacitación </span>
                                            </td>
                                            <td style="width: 325px; text-align: left; color: #ff0000; height: 18px;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoCapacitacion" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 145px; text-align: left; height: 10px;">
                                                Reparto</td>
                                            <td style="width: 325px; text-align: left; height: 10px;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoReparto" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 145px; height: 10px; text-align: left">
                                                Administración</td>
                                            <td style="width: 325px; height: 10px; text-align: left" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoAdmin" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 145px; height: 17px; text-align: left;">
                                                Excedente Cap.
                                            </td>
                                            <td style="width: 325px; height: 17px; text-align: left;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoExcCapacitacion" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 145px; height: 17px; text-align: left;">
                                                Excedente Rep.
                                            </td>
                                            <td style="width: 325px; height: 17px; text-align: left;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoExcReparto" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 145px; text-align: left; height: 17px;">
                                                Financiamiento Otic</td>
                                            <td style="width: 325px; text-align: left; height: 17px;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoFinOtic" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 145px; height: 17px; text-align: left;">
                                                Becas</td>
                                            <td style="width: 325px; height: 17px; text-align: left;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoBecas" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr visible="false" runat="server" id="trExcCong2008">
                                            <td style="width: 145px; height: 17px; text-align: left;">
                                                Excedente Cong. 2008</td>
                                            <td style="width: 325px; height: 17px; text-align: left;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoExcCong2008" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr visible="false" runat="server" id="trExcCong2009">
                                            <td style="width: 145px; height: 12px; text-align: left;">
                                                <span style="color: #ff0000">
                                                Excedente Cong. 2009</span></td>
                                            <td style="width: 325px; height: 12px; text-align: left;" class="AlineacionDerecha">
                                                <asp:Label ID="lblSaldoExcCong2009" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                    </table>
                                    </div>
                                    <div id="Traspaso" style="float: left; margin:0px; padding:0px; border:0px;">
                                    <table  cellpadding="0" cellspacing="0" style="width: 576px; margin:0px; padding:0px; border:0px; height: 240px; margin-top:5px;" >
                                        <tr>
                                            <td style="width: 37px; text-align: left; height: 31px;">
                                                <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label></td>
                                            <td style="width: 100px; text-align: left; height: 31px;">
                                                <ew:CalendarPopup ID="clpFecha" runat="server" Width="96px">
                                                </ew:CalendarPopup>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 37px; height: 17px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" Text="Cuenta Origen" Width="64px"></asp:Label></td>
                                            <td style="width: 100px; height: 17px; text-align: left;">
                                                <asp:DropDownList ID="ddlCuentaOrigen" runat="server">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 37px; height: 17px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" Text="Cuenta Destino" Width="72px"></asp:Label></td>
                                            <td style="width: 100px; height: 17px; text-align: left;">
                                                <asp:DropDownList ID="ddlCuentaDestino" runat="server">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 37px; height: 17px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" Text="Monto"></asp:Label></td>
                                            <td style="width: 100px; height: 17px; text-align: left;">
                                                <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 37px; height: 42px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" Text="Observación"></asp:Label></td>
                                            <td style="width: 100px; height: 42px; text-align: left;">
                                                <asp:TextBox ID="txtObservacion" runat="server" Height="88px" TextMode="MultiLine"
                                                    Width="328px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 29px">
                                                <span style="color: #ff0000">Recuerde que cualquier traspaso de montos entre cuentas
                                                    conlleva una serie de variaciones en la cartola del cliente por lo tanto recomendamos
                                                    poner sumo cuidado en la ejecución de esta operación </span>
                                            </td>
                                        </tr>
                                    </table>
                                    </div>
                                    <br />
                                    <br />
                                    
                                    <br />
                                   
                                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar Traspaso" ValidationGroup="ValidaRutAlumno" Width="104px" />&nbsp;
                                    <asp:Button ID="btnVolver" runat="server" Text="Volver" Width="104px" /></td>
                            </tr>
                        </table>
            <br />
        </div>
        <div id="pie">
            <div class="textoPie">
                &nbsp;<asp:Label ID="lblPie" runat="server" Text=""></asp:Label></div>
        </div>
    
    </div>
    </form>
</body>
</html>
