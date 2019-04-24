<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comunicacion_manual.aspx.vb" Inherits="modulo_cursos_comunicacion_manual" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Comunicación manual</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        <br />
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
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li visible="False">
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Mantenedor Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>
    </div>
    <div id="Grafico">
     <table id="tablaDatosAlumno">
                        <tr>
                            <th width="980px" valign="top" class="TituloGrupo">
                                <asp:Label ID="Label4" runat="server" Text="Comunicación manual de un curso"></asp:Label>  </th>                         
                        </tr>
                     </table>
        <table cellpadding="0" cellspacing="0" class="TablaInterior" width="980">
            <tr>
                <td style="width: 13%" class="AlineacionDerecha">
                    <asp:Label ID="Label2" runat="server" Text="Correlativo" Font-Bold="False"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:Label ID="lblCorrelativo" runat="server" Font-Bold="True"></asp:Label></td>
                <td style="width: 10%" class="AlineacionDerecha">
                    <asp:Label ID="Label6" runat="server" Text="Estado actual"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:Label ID="lblEstado" runat="server"></asp:Label></td>
                <td style="width: 10%" class="AlineacionDerecha">
                    <asp:Label ID="Label12" runat="server" Text="Origen"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 11%" class="AlineacionIzquierda">
                    <asp:Label ID="lblOrigen" runat="server"></asp:Label></td>
                <td style="width: 12%" class="AlineacionDerecha">
                    <asp:Label ID="Label14" runat="server" Text="NºReg. SENCE" Font-Bold="True"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:Label ID="lblRegSence" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 13%" class="AlineacionDerecha">
                    <asp:Label ID="Label3" runat="server" Text="Correlativo Empresa" Font-Bold="False"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:Label ID="lblCorrelEmp" runat="server" Font-Bold="True"></asp:Label></td>
                <td style="width: 10%" class="AlineacionDerecha">
                    <asp:Label ID="Label7" runat="server" Text="Fecha"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:Label ID="lblFecha" runat="server"></asp:Label></td>
                <td style="width: 10%" class="AlineacionDerecha">
                    <asp:Label ID="Label13" runat="server" Text="Fecha ingreso"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 11%" class="AlineacionIzquierda">
                    <asp:Label ID="lblFechIngreso" runat="server"></asp:Label></td>
                <td style="width: 12%" class="AlineacionDerecha">
                    <asp:Label ID="Label15" runat="server" Text="NºReg. SENCE compl"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:Label ID="lblRegSenCompl" runat="server" Text="-"></asp:Label></td>
            </tr>
        </table>
        <table id="TablaMensaje" runat="server" cellpadding="0" cellspacing="0" visible="false"
            width="100%">
            <tr>
                <td style="width: 100%">
                    <br />
                    *El curso detallado se encuentra
                    <asp:Label ID="lblResultado" runat="server"></asp:Label>.</td>
            </tr>
        </table>
        <div id="resultados">
        <table id="TablaCambioEstado" runat="server" width="100%" cellpadding="0" cellspacing="0">
         <tr>
            <th colspan="2">
                cambio de estado de curso</th>
            </tr>
            <tr>
                <td style="width: 50%" valign="top" class="AlineacionDerecha">
                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="Ingrese la fecha de comunicación que desea asociar: "></asp:Label>
                </td>
                <td style="width: 50%">
                    <ew:calendarpopup id="calFechaComunic" runat="server" ClearDateText="Limpiar fecha"
                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" 
                        Nullable="True" PadSingleDigits="True" PostedDate=""
                        SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                     </ew:calendarpopup>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="calFechaComunic"
                        ErrorMessage="Debe ingresar la fecha de comunicación" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="AlineacionDerecha" style="width: 50%" valign="top">
                    <asp:Label ID="Label5" runat="server" Font-Bold="False" Text="Ingrese el folio de comunicación SENCE del curso:"></asp:Label></td>
                <td style="width: 50%">
                    <asp:TextBox ID="txtFolio" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFolio"
                        ErrorMessage="Debe ingresar el folio de comunicación" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 50%" valign="top" class="AlineacionDerecha">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Ingrese la razón de la comunicación manual: "></asp:Label></td>
                <td style="width: 50%">
                    <asp:TextBox ID="txtGlosa" runat="server" Height="60px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
            </tr>
        </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
        <br />
        <br />
        <asp:Button ID="btnComunicar" runat="server" Text="Comunicar" ValidationGroup="xx" />&nbsp;<br />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" Visible="False" /><br />
        <br />
        <br />
        </div>
    </div>
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text=""></asp:Label>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
