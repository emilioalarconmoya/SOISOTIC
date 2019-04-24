<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_alumnos.aspx.vb"
    Inherits="modulo_cursos_reporte_alumnos" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario"
    TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte de alumnos</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" src="../include/js/AbrirPopUp.js" type="text/javascript"></script>

    <script language="javascript" src="../include/js/Validacion.js" type="text/javascript"></script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="bannner">
                <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera" />
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
                    <li class="pestanaconsolaseleccionada">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx" Visible="False"><b>Mantenedor Sence</b></asp:HyperLink>
                </li>
                <li visible="False">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Mantenedor Sence</b></asp:HyperLink>
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
                    <table cellpadding="0" cellspacing="0" class="TablaInterior" id="tablaFiltros" runat="server">
                        <tr>
                            <th width="970px" valign="top" class="Titulo" colspan="7">
                                <asp:Label ID="Label19" runat="server" Text="Filtros de búsqueda"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <td class="AlineacionCentro" colspan="7">
                                &nbsp;&nbsp;
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td rowspan="">
                                            <span>&nbsp;<asp:Label ID="lblRutAlumno" runat="server" Text="Rut Alumno: "></asp:Label><asp:TextBox
                                                ID="txtRutAlumno" runat="server" Font-Size="Small" MaxLength="12" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRutAlumno"
                                                    ErrorMessage="debe ingresar un rut valido" ValidationExpression="^0*(\d{1,3}(\.?\d{3})*)\-?([\dkK])$"
                                                    ValidationGroup="zz">*</asp:RegularExpressionValidator><asp:CustomValidator ID="CustomValidator1"
                                                        runat="server" ClientValidationFunction="VerificarRut" ControlToValidate="txtRutAlumno"
                                                        ErrorMessage="Debe ingresar rut valido" ValidationGroup="gg">*</asp:CustomValidator>
                                                <asp:Label ID="lblNombreAlumno" runat="server" Text="Nombre Alumno: "></asp:Label><asp:TextBox
                                                    ID="txtNombreAlumno" runat="server" Font-Size="Small" Width="150px"></asp:TextBox>&nbsp;
                                                <asp:Label ID="lblFechaInicial" runat="server" Text="Desde :"></asp:Label>&nbsp;</span>
                                            <ew:CalendarPopup ID="calFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                                                ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                                DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                                ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                                PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                                VisibleDate="">
                                                <TextBoxLabelStyle Width="65px" />
                                            </ew:CalendarPopup>
                                            <span>
                                                <asp:Label ID="lblFechaFinal" runat="server" Text="Hasta :"></asp:Label></span>
                                            <ew:CalendarPopup ID="calFechaFin" runat="server" ClearDateText="Limpiar fecha" ControlDisplay="TextBoxImage"
                                                CssClass="Calendar" Culture="Spanish (Argentina)" DisableTextBoxEntry="False"
                                                DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy" ImageUrl="~/Contenido/Imagenes/calendario.jpg"
                                                Nullable="True" PadSingleDigits="True" PopupLocation="Left" PostedDate="" SelectedDate=""
                                                ShowClearDate="True" ShowGoToToday="True" VisibleDate="">
                                                <TextBoxLabelStyle Width="65px" />
                                            </ew:CalendarPopup>
                                            &nbsp;Correlativo:
                                            <asp:TextBox ID="txtCorrelativo" runat="server" Width="33px"></asp:TextBox>&nbsp;<br />
                                            <asp:CheckBox ID="chkAlumSence" runat="server" Checked="True" Text="Alumno Sence" />
                                            <asp:CheckBox ID="chkAlumInterno" runat="server" Checked="True" Text="Alumno no Sence" /><br />
                                            <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar reporte" Checked="True" />
                                            <asp:LinkButton ID="lnkDescargar" runat="server" Visible="False">Descargar</asp:LinkButton>
                                            <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1"
                                                Visible="False">[HplkBajarArchivo]</asp:HyperLink><br />
                                            <asp:Button ID="btnBuscar" runat="server" CssClass="btnLogin" Text="Consultar" ValidationGroup="gg" /><br />
                                            &nbsp;<br />
                                            &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="zz"
                                                DisplayMode="List" />
                                            &nbsp; &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<asp:Button ID="Button1" runat="server" Text="Consultar" ValidationGroup="gg" CssClass="btnLogin" />--%>
                    </table>
                    <table id="tablaHeader">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Alumnos capacitados"></asp:Label></th>
                        </tr>
                    </table>
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                        ShowFooter="True" EmptyDataText="Sin datos para el ciclo seleccionado" Width="100%">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <table class="TablaInterior">
                                        <tr>
                                            <td valign="top" class="AlineacionIzquierda">
                                                <asp:Label ID="lblContador" runat="server" Text='<%# bind("nFila") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="10px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="180" class="TablaInterior">
                                        <tr>
                                            <td align="left" class="AlineacionIzquierda">
                                                <asp:HyperLink ID="HyperLinkAlumno" runat="server" Text='<%# bind("nombre_completo") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="AlineacionIzquierda">
                                                <asp:Label ID="lblRutAlumno" runat="server" Text='<%# Bind("rut_alumno") %>'></asp:Label><br />
                                                <asp:Label ID="lblTipoAlum" runat="server" Text='<%# Bind("tipo_alumno") %>'></asp:Label><br />
                                                <asp:HiddenField ID="hdfRutAlumno" runat="server" Value='<%# Bind("rut_alumno") %>' />
                                                <asp:HiddenField ID="hdfCodigoSence" runat="server" Value='<%# Bind("codigo_sence") %>' />
                                                <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                                                <asp:HiddenField ID="hdfRutOtec" runat="server" Value='<%# Bind("rut_otec") %>' />
                                                <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# Bind("rut_cliente") %>' />
                                                <asp:HiddenField ID="hdfCodCursoInterno" runat="server" Value='<%# Bind("correlativo") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="180px" />
                                <FooterStyle CssClass="Footer" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Empresa, otec y curso">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" class="TablaInterior" width="250">
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblEmp" runat="server" Text="Emp"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="Label8" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblOt" runat="server" Text="OTEC"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunOt" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkNombreOtec" runat="server" Text='<%# Bind("nombre_otec") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblCur" runat="server" Text="Curso"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="Label10" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkNombreCurso" runat="server" Text='<%# Bind("nombre_curso") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblCorr" runat="server" Text="Correlativo"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="Label11" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="200px" />
                                <FooterStyle CssClass="Footer" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Datos Curso">
                                <ItemTemplate>
                                    <table class="TablaInterior">
                                        <tr>
                                            <td style="width: 148px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblIni" runat="server" Text="Inicio"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label13" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblFechaIni" runat="server" Text='<%# Bind("fecha_inicio") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 148px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblFin" runat="server" Text="Fin"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label12" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 148px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblEm" runat="server" Text="#Emp"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label9" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("correlativo_empresa") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 148px">
                                                <asp:Label ID="lblHor" runat="server" Text="Horas"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="lblDosPunH" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblHoras" runat="server" Text='<%# Bind("horas") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 148px">
                                                <asp:Label ID="lblAcc" runat="server" Text="Acci�n Sence"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="lblDosPunAcc" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblAccionSence" runat="server" Text='<%# Bind("nro_registro") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="150px" />
                                <FooterStyle CssClass="Footer" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Datos Alumno">
                                <ItemTemplate>
                                    <table class="TablaInterior">
                                        <tr>
                                            <td class="AlineacionDerecha">
                                                <asp:Label ID="lblFran" runat="server" Text="Franquicia"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label14" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha">
                                                <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda">
                                                <asp:Label ID="lblNivE" runat="server" Text="Nivel Educ"></asp:Label></td>
                                            <td style="width: 2px;">
                                                <asp:Label ID="Label15" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha">
                                                <asp:Label ID="lblNivelEduc" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda">
                                                <asp:Label ID="lblNivP" runat="server" Text="Nivel Prof"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label16" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha">
                                                <asp:Label ID="lblNivelPro" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda">
                                                <asp:Label ID="lblAsis" runat="server" Text="Asistencia"></asp:Label></td>
                                            <td style="width: 2px;">
                                                <asp:Label ID="lblDosPunAsis" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha">
                                                <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("porc_asistencia") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="210px" />
                                <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                                <FooterTemplate>
                                    <table cellpadding="0" cellspacing="0" class="TablaFooter" width="225">
                                        <tr>
                                            <td class="AlineacionDerecha" style="width: 225px">
                                                <asp:Label ID="Label7" runat="server" Text="Total Registros Consultados:"></asp:Label></td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Monto">
                                <ItemTemplate>
                                    <table class="TablaInterior">
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblCost" runat="server" Text="OTIC"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunCost" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 100px;" class="AlineacionDerecha" valign="top">
                                                <asp:Label ID="lblCostOtic" runat="server" Text='<%# Bind("costo_otic_curso") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 100px">
                                                <asp:Label ID="lblCostEmp" runat="server" Text="Empresa"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunEmp" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 100px" valign="top">
                                                <asp:Label ID="lblCostoEmp" runat="server" Text='<%# Bind("gasto_emp_curso") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 100px">
                                                <asp:Label ID="lblV" runat="server" Text="Vitatico"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="Label17" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 100px" valign="top">
                                                <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico_otic") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 100px;">
                                                <asp:Label ID="lblT" runat="server" Text="Traslado"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunTras" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 100px;" class="AlineacionDerecha" valign="top">
                                                <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("traslado_otic") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblTot" runat="server" Text="Total"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunTot" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 100px" valign="top">
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("total_alumno") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="90px" />
                                <FooterTemplate>
                                    <table class="TablaFooter" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label2" runat="server" Text="Costo OTIC"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotCosto" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label3" runat="server" Text="Gasto Empresa"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotGasto" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label4" runat="server" Text="Viático"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotViatico" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label5" runat="server" Text="Traslado"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotTraslado" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label6" runat="server" Text="Total"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotales" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                                <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div style="width: 100%; text-align: left;">
                                Página
                                <asp:DropDownList ID="paginasDropDownList" Font-Size="12px" AutoPostBack="true" 
                                    runat="server">
                                </asp:DropDownList>
                                de
                                <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Button4" runat="server" CommandName="Page" ToolTip="Prim. Pag" CommandArgument="First"
                                    CssClass="pagfirst" />
                                <asp:Button ID="Button1" runat="server" CommandName="Page" ToolTip="Pág. anterior"
                                    CommandArgument="Prev" CssClass="pagprev" />
                                <asp:Button ID="Button2" runat="server" CommandName="Page" ToolTip="Sig. página"
                                    CommandArgument="Next" CssClass="pagnext" />
                                <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="últ. Pag" CommandArgument="Last"
                                    CssClass="paglast" />
                            </div>
                        </PagerTemplate>
                        <PagerStyle CssClass="pagerstyle" />
                    </asp:GridView>
                    <%--<asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                        ShowFooter="True" EmptyDataText="Sin datos para el ciclo seleccionado" Width="99%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="180" class="TablaInterior" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" class="AlineacionIzquierda">
                                                <asp:HyperLink ID="HyperLinkAlumno" runat="server" Text='<%# bind("nombre_completo") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="AlineacionIzquierda">
                                                <asp:Label ID="lblRutAlumno" runat="server" Text='<%# Bind("rut_alumno") %>'></asp:Label><br />
                                                <asp:Label ID="lblTipoAlum" runat="server" Text='<%# Bind("tipo_alumno") %>'></asp:Label><br />
                                                <asp:HiddenField ID="hdfRutAlumno" runat="server" Value='<%# Bind("rut_alumno") %>' />
                                                <asp:HiddenField ID="hdfCodigoSence" runat="server" Value='<%# Bind("codigo_sence") %>' />
                                                <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                                                <asp:HiddenField ID="hdfRutOtec" runat="server" Value='<%# Bind("rut_otec") %>' />
                                                <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# Bind("rut_cliente") %>' />
                                                <asp:HiddenField ID="hdfCodCursoInterno" runat="server" Value='<%# Bind("correlativo") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="180px" />
                                <FooterStyle CssClass="Footer" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Empresa, otec y curso">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" class="TablaInterior" width="250">
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblEmp" runat="server" Text="Emp"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="Label8" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblOt" runat="server" Text="OTEC"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunOt" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkNombreOtec" runat="server" Text='<%# Bind("nombre_otec") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblCur" runat="server" Text="Curso"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="Label10" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkNombreCurso" runat="server" Text='<%# Bind("nombre_curso") %>'></asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 50px; text-align: left" valign="top">
                                                <asp:Label ID="lblCorr" runat="server" Text="Correlativo"></asp:Label></td>
                                            <td style="width: 2px" valign="top">
                                                <asp:Label ID="Label11" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 248px; text-align: left" valign="top">
                                                <asp:HyperLink ID="hplkCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink>
                                                <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="200px" />
                                <FooterStyle CssClass="Footer" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Datos Curso">
                                <ItemTemplate>
                                    <table class="TablaInterior" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 62px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblIni" runat="server" Text="Inicio"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label13" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblFechaIni" runat="server" Text='<%# Bind("fecha_inicio") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 62px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblFin" runat="server" Text="Fin"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label12" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 62px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblEm" runat="server" Text="#Emp"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label9" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("correlativo_empresa") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 62px">
                                                <asp:Label ID="lblHor" runat="server" Text="Horas"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="lblDosPunH" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblHoras" runat="server" Text='<%# Bind("horas") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 62px">
                                                <asp:Label ID="lblAcc" runat="server" Text="Acción Sence"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="lblDosPunAcc" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 50px">
                                                <asp:Label ID="lblAccionSence" runat="server" Text='<%# Bind("nro_registro") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="150px" />
                                <FooterStyle CssClass="Footer" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Datos Alumno">
                                <ItemTemplate>
                                    <table class="TablaInterior" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 75px">
                                                <asp:Label ID="lblFran" runat="server" Text="Franquicia"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label14" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 120px">
                                                <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 75px;" class="AlineacionIzquierda">
                                                <asp:Label ID="lblNivE" runat="server" Text="Nivel Educ"></asp:Label></td>
                                            <td style="width: 2px;">
                                                <asp:Label ID="Label15" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 120px;" class="AlineacionDerecha">
                                                <asp:Label ID="lblNivelEduc" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 75px">
                                                <asp:Label ID="lblNivP" runat="server" Text="Nivel Prof"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label16" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 120px">
                                                <asp:Label ID="lblNivelPro" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 75px">
                                                <asp:Label ID="Label18" runat="server" Text="Centro de costo"></asp:Label></td>
                                            <td style="width: 2px">
                                                <asp:Label ID="Label20" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 120px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 75px;" class="AlineacionIzquierda">
                                                <asp:Label ID="lblAsis" runat="server" Text="Asistencia"></asp:Label></td>
                                            <td style="width: 2px;">
                                                <asp:Label ID="lblDosPunAsis" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 120px;" class="AlineacionDerecha">
                                                <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("porc_asistencia") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="210px" />
                                <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                                <FooterTemplate>
                                    <table cellpadding="0" cellspacing="0" class="TablaFooter" width="225">
                                        <tr>
                                            <td class="AlineacionDerecha" style="width: 225px">
                                                <asp:Label ID="Label7" runat="server" Text="Total Registros Consultados:"></asp:Label></td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Monto">
                                <ItemTemplate>
                                    <table class="TablaInterior" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 75px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblCost" runat="server" Text="OTIC"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunCost" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 90px;" class="AlineacionDerecha" valign="top">
                                                <asp:Label ID="lblCostOtic" runat="server" Text='<%# Bind("gasto_otic") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 75px">
                                                <asp:Label ID="lblCostEmp" runat="server" Text="Empresa"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunEmp" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 90px" valign="top">
                                                <asp:Label ID="lblCostoEmp" runat="server" Text='<%# Bind("gasto_emp") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 75px">
                                                <asp:Label ID="lblV" runat="server" Text="Vitatico"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="Label17" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 90px" valign="top">
                                                <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 75px;">
                                                <asp:Label ID="lblT" runat="server" Text="Traslado"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunTras" runat="server" Text=":"></asp:Label></td>
                                            <td style="width: 90px;" class="AlineacionDerecha" valign="top">
                                                <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("traslado") %>'></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 75px" class="AlineacionIzquierda">
                                                <asp:Label ID="lblTot" runat="server" Text="Total"></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="width: 2px" valign="top">
                                                <asp:Label ID="lblDosPunTot" runat="server" Text=":"></asp:Label></td>
                                            <td class="AlineacionDerecha" style="width: 90px" valign="top">
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("total") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Top" Width="90px" />
                                <FooterTemplate>
                                    <table class="TablaFooter" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label2" runat="server" Text="Costo OTIC"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotCosto" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label3" runat="server" Text="Gasto Empresa"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotGasto" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label4" runat="server" Text="Viático"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotViatico" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label5" runat="server" Text="Traslado"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotTraslado" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px" class="AlineacionIzquierda">
                                                <asp:Label ID="Label6" runat="server" Text="Total"></asp:Label></td>
                                            <td style="width: 10px">
                                                :</td>
                                            <td style="width: 100px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotales" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                                <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                </div>
            </div>
        </div>
        <div id="pie">
            <div class="textoPie">
                <asp:Label ID="lblPie" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
