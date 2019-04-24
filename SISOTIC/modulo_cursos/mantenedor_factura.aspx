<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_factura.aspx.vb" Inherits="modulo_cursos_mantenedor_factura" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor factura</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" ></script> 
      <script  type="text/jscript">
       function popup_buscar_empresa() 
        {
            //Debe ir en campo el nombre del objeto que aparece en HTML como parametro 
            btn_buscar_empresa = open('buscador_empresas.aspx?campo=txtRutEmpresa','NewWindow','top=100,left=100,width=700,height=380,status=yes,resizable=no,scrollbars=yes,title="Buscador empresas",closable=no');
        }
      </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li visible="False">
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Mantenedor Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        
        <div id="contenido">
            <div id="resultados">
                <div >
               <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label15" runat="server" Text="Factura"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 500px" valign="top">
                     <table cellpadding="0" class="Grid" cellspacing="0" style="width: 100%">
                                     <tr>
                                         <th class="AlineacionIzquierda" colspan="5" style="height: 12px" align="left">
                                             <asp:Label ID="Label16" runat="server" Text="Datos del curso "></asp:Label></th>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 38%; height: 15px;">
                                             <asp:Label ID="Label7" runat="server" Text="Correlativo:"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="4" style="height: 15px">
                                             <asp:Label ID="lblCorrelativo" runat="server" Text="Label"></asp:Label></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 38%;">
                                             <asp:Label ID="Label8" runat="server" Text="Cliente"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                             <asp:Label ID="lblNombreCliente" runat="server" Text="Label"></asp:Label></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 38%; height: 12px">
                                             <asp:Label ID="Label9" runat="server" Text="Curso"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                             <asp:Label ID="lblNombreCurso" runat="server" Text="Label"></asp:Label></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 38%; height: 16px">
                                             <asp:Label ID="Label10" runat="server" Text="Otec"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="4" style="height: 16px">
                                             <asp:Label ID="lblNombreOtec" runat="server" Text="Label"></asp:Label></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 38%; height: 12px">
                                             <asp:Label ID="Label11" runat="server" Text="Período curso"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                             <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label>
                                             <asp:Label
                                                 ID="Label17" runat="server" Text="-"></asp:Label>
                                             <asp:Label ID="lblFechaTermino"
                                                     runat="server" Text="Label"></asp:Label></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 38%; height: 12px">
                                             <asp:Label ID="Label12" runat="server" Text="Participantes"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                             <asp:Label ID="lblNumParticipantes" runat="server" Text="Label"></asp:Label></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 38%; height: 12px">
                                             <asp:Label ID="Label13" runat="server" Text="Costo Otic"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                             <asp:Label ID="lblCostoOtic" runat="server" Text="Label"></asp:Label></td>
                                     </tr>
                         <tr>
                             <td class="AlineacionIzquierda" style="width: 38%; height: 12px">
                                 <asp:Label ID="Label19" runat="server" Text="Nro registro:"></asp:Label></td>
                             <td class="AlineacionIzquierda" colspan="4" style="height: 12px">
                                 <asp:Label ID="lblNroRegistro" runat="server" Text="Label"></asp:Label></td>
                         </tr>
                                 </table>
                            </td>
                            <td style="width: 470px" valign="top">
                     <table cellpadding="0" cellspacing="0" class="Grid" width= "490">
                         <tr>
                             <th class="AlineacionIzquierda" colspan="2" style="height: 17px; width: 98%;">
                                 <asp:Label ID="Label59" runat="server" Text="Datos de la factura"></asp:Label></th>
                         </tr>
                         <tr>
                             <td class="AlineacionIzquierda" colspan="2" style="height: 12px; width: 98%;">
                                 <table cellpadding="0" cellspacing="0" class="Grid" style="width:100% " >
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label1" runat="server" Text="Número de factura"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="height: 12px; width: 50%;">
                                             <asp:TextBox ID="txtNumFactura" runat="server" Width="104px"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNumFactura"
                                                 ErrorMessage="Ingresar solo números enteros" ValidationExpression="\d+" ValidationGroup="ValidaNumero">*</asp:RegularExpressionValidator>&nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label2" runat="server" Text="Fecha factura "></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="height: 12px; width: 50%;">
                                             <ew:CalendarPopup ID="calFechaFactura" runat="server" ClearDateText="Limpiar fecha"
                                                 ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                                 DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                                 ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                                 PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                                 VisibleDate="">
                                                 <TextBoxLabelStyle Width="65px" />
                                             </ew:CalendarPopup>
                                             &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="calFechaFactura"
                                                 ErrorMessage="Debe ingresar una fecha de emisión." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label3" runat="server" Text="Fecha recepción"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="height: 12px; width: 50%;">
                                             <ew:CalendarPopup ID="calFechaRecepcion" runat="server" ClearDateText="Limpiar fecha"
                                                 ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                                 DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                                 ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                                 PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                                 VisibleDate="">
                                                 <TextBoxLabelStyle Width="65px" />
                                             </ew:CalendarPopup>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="calFechaRecepcion"
                                                 ErrorMessage="Debe ingresar una fecha de recepción." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator><%--<ew:calendarpopup id="calFechaRecepcion" runat="server" cleardatetext="Limpiar fecha"
                                                 controldisplay="TextBoxImage" cssclass="Calendar" culture="Spanish (Argentina)"
                                                 disabletextboxentry="False" displayprevnextyearselection="True" gototodaytext="Ir al día de hoy"
                                                 imageurl="~/Contenido/Imagenes/calendario.jpg" nullable="True" padsingledigits="True"
                                                 popuplocation="Left" posteddate="" selecteddate="" showcleardate="True" showgototoday="True"
                                                 visibledate="">
                                             <TextBoxLabelStyle Width="65px" />
                                         </ew:CalendarPopup>--%></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 16px">
                                             <asp:Label ID="Label4" runat="server" Text="Fecha pago"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="height: 16px; width: 50%;">
                                             <ew:CalendarPopup ID="calFechaPago" runat="server" ClearDateText="Limpiar fecha"
                                                 ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                                 DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                                 ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                                 PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                                 VisibleDate="">
                                                 <TextBoxLabelStyle Width="65px" />
                                             </ew:CalendarPopup>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="calFechaPago"
                                                 ErrorMessage="Debe ingresar una fecha de pago.." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator><%--<ew:calendarpopup id="calFechaPago" runat="server" cleardatetext="Limpiar fecha"
                                                 controldisplay="TextBoxImage" cssclass="Calendar" culture="Spanish (Argentina)"
                                                 disabletextboxentry="False" displayprevnextyearselection="True" gototodaytext="Ir al día de hoy"
                                                 imageurl="~/Contenido/Imagenes/calendario.jpg" nullable="True" padsingledigits="True"
                                                 popuplocation="Left" posteddate="" selecteddate="" showcleardate="True" showgototoday="True"
                                                 visibledate="">
                                             <TextBoxLabelStyle Width="65px" />
                                         </ew:CalendarPopup>--%></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label5" runat="server" Text="Monto "></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="height: 12px; width: 50%;">
                                             <asp:TextBox ID="txtMonto" runat="server" Width="104px"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMonto"
                                                 ErrorMessage="Ingresar solo números enteros" ValidationExpression="\d+" ValidationGroup="ValidaNumero">*</asp:RegularExpressionValidator></td>
                                     </tr>
                                     <%--<tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label18" runat="server" Text="Nro documento"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="width: 50%; height: 12px">
                                             <asp:TextBox ID="txtNroDocumento" runat="server" Width="104px"></asp:TextBox></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label20" runat="server" Text="nota de crédito "></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="width: 50%; height: 12px">
                                             <asp:TextBox ID="txtNotaCredito" runat="server" Width="104px"></asp:TextBox></td>
                                     </tr>--%>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label18" runat="server" Text="Nro voucher"></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="width: 50%; height: 12px">
                                             <asp:TextBox ID="txtNroVoucher" runat="server"></asp:TextBox>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNroVoucher"
                                                 ErrorMessage="Ingresar solo números enteros" ValidationExpression="\d+" ValidationGroup="ValidaNumero">*</asp:RegularExpressionValidator></td>
                                     </tr>
                                     <tr>
                                         <td class="AlineacionIzquierda" style="width: 21%; height: 12px">
                                             <asp:Label ID="Label6" runat="server" Text="Estado "></asp:Label></td>
                                         <td class="AlineacionIzquierda" colspan="3" style="height: 12px; width: 50%;">
                                             <asp:DropDownList ID="ddlEstadofactura" runat="server">
                                             </asp:DropDownList></td>
                                     </tr>
                                     
                                 </table>
                                 <table cellpadding="0" cellspacing="0" class="Grid" style="width: 100%">
                         <tr>
                             <th class="AlineacionIzquierda" colspan="6" style="height: 17px; width: 99%;">
                                 <asp:Label ID="Label97" runat="server" Text="Observaciones"></asp:Label></th>
                         </tr>
                         <tr>
                             <td class="AlineacionIzquierda" colspan="6" style="height: 50px; width: 99%;">
                                 <asp:TextBox ID="txtObservacion" runat="server" Height="72px" TextMode="MultiLine"
                                     Width="456px"></asp:TextBox></td>
                         </tr>
                         </table>
                             </td>
                         </tr>
                         <tr>
                             <td class="AlineacionDerecha" colspan="2" style="height: 12px; width: 98%;">
                                 <asp:HyperLink ID="hplBitacoraFactura" runat="server">Ver Bitácora Factura</asp:HyperLink></td>
                         </tr>
                     </table>
                           </td> 
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <br />
      <table cellpadding="0" cellspacing="0" class="TablaFooter" >
                             <tr>
                                 <td class="AlineacionIzquierda" colspan="2" style="height: 14px; width: 970px;" valign="top">
                                 </td>
                             </tr>
         </table>
    <div>  
      <div id="botones">
          <asp:Button ID="btnInsertar" runat="server" Text="Insertar" Visible="False" />
           <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="ValidaNumero" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de enviar la información ingresada.\n¿Desea continuar?');" />
           <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
            <br />
                                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaNumero" Width="256px" />
        </div>
                     
     </div>
    </div>
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text=""></asp:Label>
        </div>
        <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
    </div>    
    </form>
</body>
</html>

