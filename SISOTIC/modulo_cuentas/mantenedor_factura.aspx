<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_factura.aspx.vb" Inherits="modulo_cuentas_mantenedor_factura" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BANOTIC</title>
    <link rel="apple-touch-icon" sizes="57x57" href="../favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="../favicon/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="../favicon/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="../favicon/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="../favicon/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="../favicon/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="../favicon/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="../favicon/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="../favicon/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="../favicon/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="../favicon/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="../favicon/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="../favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="../favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="../favicon/mstile-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" >function TABLE1_onclick() {

}

</script> 
      <script  type="text/jscript">
       function popup_buscar_empresa() 
        {
            //Debe ir en campo el nombre del objeto que aparece en HTML como parametro 
            btn_buscar_empresa = open('../modulo_cursos/buscador_empresas.aspx?campo=txtRutEmpresa','NewWindow','top=100,left=100,width=700,height=380,status=yes,resizable=no,scrollbars=yes,title="Buscador empresas",closable=no');
        }
      </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
                        <asp:HyperLink ID="hplResumenGrafico" runat="server" NavigateUrl="resumen_grafico.aspx"><b>Resumen de gestión</b></asp:HyperLink>
                    </li>
                    <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Cartola resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplPorTramo" runat="server" NavigateUrl="reporte_por_tramo.aspx"><b>Por Tramo</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplCuentas" runat="server" NavigateUrl="reporte_cuentas.aspx" Visible="true" ><b>Cuentas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursoInterno" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos_internos.aspx"><b>Curso interno</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Cargas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplIngresoCurso" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos.aspx" Visible="false"><b>Ingreso curso</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="hplCertificado" runat="server" Target="_blank"  NavigateUrl="certificado_aportes.aspx"><b>Certif. aportes</b></asp:HyperLink>
                </li>                
                <li >
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../menu.aspx"><b>Menú principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        <div id="Cabecera">
                 
         </div>
         <div id="contenido">           
            <div id="resultados"> </div> 
            <table id="tablaDatosAlumno" style="width: 980px">
                        <tr>
                            <th class="TituloGrupo" valign="top" style="height: 18px; width: 980px;">
                                <asp:Label ID="Label15" runat="server" Text="Reporte de cursos"></asp:Label>
                                </th>                            
                        </tr>
                     </table>
             <div id="Div2">
                 <div id="Div1">
                     <div id="CuentasPeriodoActual">
                         <table id="tablaPeriodoActual">
                             <tr>
                                 <td style="height: 86px; width: 490px;" valign="top">
                                                 <table cellpadding="0" class="Grid" style="width: 480px" cellspacing="0">
                                                     <tr>
                                                         <th class="AlineacionIzquierda" colspan="5" style="height: 12px">
                                                             <asp:Label ID="Label16" runat="server" Text="Datos del curso "></asp:Label></th>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%;">
                                                             <asp:Label ID="Label7" runat="server" Text="Correlativo:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                                             <asp:Label ID="lblCorrelativo" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%;">
                                                             <asp:Label ID="Label8" runat="server" Text="Cliente:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                                             <asp:Label ID="lblNombreCliente" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%; height: 12px">
                                                             <asp:Label ID="Label9" runat="server" Text="Curso:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                                             <asp:Label ID="lblNombreCurso" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%; height: 16px">
                                                             <asp:Label ID="Label10" runat="server" Text="Otec:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 16px">
                                                             <asp:Label ID="lblNombreOtec" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%; height: 12px">
                                                             <asp:Label ID="Label11" runat="server" Text="Período curso:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                                             <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label>
                                                             <asp:Label
                                                                 ID="Label17" runat="server" Text="-"></asp:Label>
                                                             <asp:Label ID="lblFechaTermino"
                                                                     runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%; height: 12px">
                                                             <asp:Label ID="Label12" runat="server" Text="Participantes:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                                             <asp:Label ID="lblNumParticipantes" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%; height: 12px">
                                                             <asp:Label ID="Label13" runat="server" Text="Costo Otic:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                                             <asp:Label ID="lblCostoOtic" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td class="AlineacionIzquierda" style="width: 26%; height: 12px">
                                                             <asp:Label ID="Label19" runat="server" Text="Nro registro:"></asp:Label></td>
                                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                                             <asp:Label ID="lblNroRegistro" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                 </table>
                                 </td>
                                 <td style="width: 490px;" valign="top">
                                     <table cellpadding="0" cellspacing="0" style="width: 490px" class="Grid">
                                         <tr>
                                             <th class="AlineacionIzquierda" colspan="2" style="height: 12px">
                                                 <asp:Label ID="Label59" runat="server" Text="Datos de la factura"></asp:Label></th>
                                         </tr>
                                         <tr>
                                             <td class="AlineacionIzquierda">
                                                             <asp:Label ID="Label1" runat="server" Text="Número de factura:"></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                             <asp:TextBox ID="txtNumFactura" runat="server" Width="104px"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNumFactura"
                                                                 ErrorMessage="Ingresar solo números enteros" ValidationExpression="\d+" ValidationGroup="ValidaNumero">*</asp:RegularExpressionValidator></td>
                                             
                                         </tr>
                                         <tr>
                                             <td class="AlineacionIzquierda">
                                                             <asp:Label ID="Label2" runat="server" Text="Fecha factura: "></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                             <ew:CalendarPopup ID="calFechaFactura" runat="server" ClearDateText="Limpiar fecha"
                                                                 ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                                                 DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                                                 ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                                                 PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                                                 VisibleDate="">
                                                                 <TextBoxLabelStyle Width="65px" />
                                                             </ew:CalendarPopup>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="calFechaFactura"
                                                                 ErrorMessage="Debe ingresar una fecha de emisión." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>&nbsp;
                                                 (dd/mm/aaaa)</td>
                                         </tr>
                                         <tr>
                                             <td class="AlineacionIzquierda">
                                                             <asp:Label ID="Label3" runat="server" Text="Fecha recepción:"></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                             <ew:CalendarPopup ID="calFechaRecepcion" runat="server" ClearDateText="Limpiar fecha"
                                                                 ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                                                 DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                                                 ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                                                 PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                                                 VisibleDate="">
                                                                 <TextBoxLabelStyle Width="65px" />
                                                             </ew:CalendarPopup>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="calFechaPago"
                                                                 ErrorMessage="Debe ingresar una fecha de pago.." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>&nbsp;
                                                 (dd/mm/aaaa)</td>
                                         </tr>
                                         <tr>
                                             <td class="AlineacionIzquierda">
                                                             <asp:Label ID="Label4" runat="server" Text="Fecha pago:"></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                             <ew:CalendarPopup ID="calFechaPago" runat="server" ClearDateText="Limpiar fecha"
                                                                 ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                                                 DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                                                 ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                                                 PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                                                 VisibleDate="">
                                                                 <TextBoxLabelStyle Width="65px" />
                                                             </ew:CalendarPopup>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="calFechaRecepcion"
                                                                 ErrorMessage="Debe ingresar una fecha de recepción." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>&nbsp;
                                                 (dd/mm/aaaa)</td>
                                         </tr>
                                         <tr>
                                             <td class="AlineacionIzquierda">
                                                             <asp:Label ID="Label5" runat="server" Text="Monto: "></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                             <asp:TextBox ID="txtMonto" runat="server" Width="104px"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMonto"
                                                                 ErrorMessage="Ingresar solo números enteros" ValidationExpression="\d+" ValidationGroup="ValidaNumero">*</asp:RegularExpressionValidator></td>
                                         </tr>
                                         <%--<tr>
                                             <td class="AlineacionIzquierda">
                                                 <asp:Label ID="Label20" runat="server" Text="Número nota de crédito"></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                 <asp:TextBox ID="txtNroDocumento" runat="server" Width="104px">0</asp:TextBox></td>
                                         </tr>--%>
                                         <%--<tr>
                                             <td class="AlineacionIzquierda">
                                                 <asp:Label ID="Label21" runat="server" Text="Monto nota de crédito"></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                 <asp:TextBox ID="txtNotaCredito" runat="server" Width="104px">0</asp:TextBox></td>
                                         </tr>
                                         <tr>
                                             <td class="AlineacionIzquierda">
                                                 <asp:Label ID="Label22" runat="server" Text="Nro. de egreso"></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                 <asp:TextBox ID="txtNroEgreso" runat="server" Width="104px" MaxLength="10"></asp:TextBox></td>
                                         </tr>--%>
                                         
                                         <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label20" runat="server" Text="Nro voucher"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="width: 50%; height: 12px">
                                             <asp:TextBox ID="txtNroVoucher" runat="server"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNroVoucher"
                                                 ErrorMessage="Ingresar solo números enteros" ValidationExpression="\d+" ValidationGroup="ValidaNumero">*</asp:RegularExpressionValidator></td>
                                     </tr>
                                         <tr>
                                             <td class="AlineacionIzquierda">
                                                             <asp:Label ID="Label6" runat="server" Text="Estado: "></asp:Label></td>
                                             <td class="AlineacionIzquierda">
                                                             <asp:DropDownList ID="ddlEstadofactura" runat="server">
                                                             </asp:DropDownList></td>
                                         </tr>
                                         <tr>
                                            <th class="AlineacionIzquierda" colspan="6" style="height: 12px">
                                                 <asp:Label ID="Label18" runat="server" Text="Observaciones"></asp:Label></th>
                                         </tr>
                                          <tr>
                                             <td class="AlineacionIzquierda" colspan="2">
                                                 <asp:TextBox ID="txtObservacion" runat="server" Height="72px" TextMode="MultiLine"
                                                     Width="472px"></asp:TextBox></td>
                                         </tr>
                                         <tr>
                                             <td class="AlineacionDerecha" colspan="2">
                                                 <asp:HyperLink ID="hplBitacoraFactura" runat="server">Ver Bitácora Factura</asp:HyperLink></td>
                                         </tr>
                                     </table>
                                  </td>
                             </tr>
                         </table>
                         <table cellpadding="0" cellspacing="0" class="TablaFooter" width="980">
                             <tr>
                                 <td class="AlineacionIzquierda" colspan="2" style="height: 14px" valign="top">
                                 </td>
                             </tr>
                         </table>
                         <div id="botones">
                             <asp:Button ID="btnInsertar" runat="server" Text="Insertar" Visible="False" />
                             <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="ValidaNumero" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de enviar la información ingresada.\n¿Desea continuar?');" />
                             <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /><br />
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaNumero" Width="256px" />
                    <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
                        </div>
                     </div>
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

