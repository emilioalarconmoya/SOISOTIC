﻿<%@ Page Language="VB" AutoEventWireup="true" CodeFile="reporte_alumnos.aspx.vb"
    Inherits="modulo_cuentas_reporte_alumnos" EnableEventValidation="false" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario"
    TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/contenido/ascx/cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" src="../include/js/AbrirPopUp.js" type="text/javascript"></script>

    <script language="javascript" src="../include/js/Validacion.js" type="text/javascript"></script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnBuscar">
        <div id="contenedor">
            <div id="bannner">
                <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="CabeceraUsuario1" runat="server" />
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
                        <li>
                            <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                        </li>
                        <li class="pestanaconsolaseleccionada">
                            <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplPorTramo" runat="server" NavigateUrl="reporte_por_tramo.aspx"><b>Por Tramo</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplCuentas" runat="server" NavigateUrl="reporte_cuentas.aspx"
                                Visible="true"><b>Cuentas</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplCursoInterno" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos_internos.aspx"><b>Curso interno</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Cargas</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplIngresoCurso" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos.aspx"
                                Visible="false"><b>Ingreso curso</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplCertificado" runat="server" Target="_blank" NavigateUrl="certificado_aportes.aspx"><b>Certif. aportes</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../menu.aspx"><b>Menú principal</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                        </li>
                    </ul>
                </div>
            </div>
            <div id="Cabecera">
                <div id="DatosUsuario">
                    <uc2:cabecera1 ID="datos_personales1" runat="server" />
                </div>
                <div id="filtros">
                    <table cellpadding="0" cellspacing="0" class="TablaInterior">
                        <tr>
                            <td style="width: 88px">
                                <asp:Label ID="lblRutAlumno" runat="server" Text="Rut Alumno"></asp:Label></td>
                            <td style="width: 2px">
                                :</td>
                            <td style="width: 210px" class="AlineacionIzquierda">
                                <asp:TextBox ID="txtRutAlumno" runat="server" Font-Size="Small" Width="150px" MaxLength="12"></asp:TextBox><asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRutAlumno"
                                    ErrorMessage="debe ingresar un rut valido" ValidationExpression="^0*(\d{1,3}(\.?\d{3})*)\-?([\dkK])$"
                                    ValidationGroup="zz">*</asp:RegularExpressionValidator>&nbsp;
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                    ControlToValidate="txtRutAlumno" ErrorMessage="Debe ingresar rut valido" ValidationGroup="gg">*</asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 88px">
                                <asp:Label ID="lblNombreAlumno" runat="server" Text="Nombre Alum."></asp:Label></td>
                            <td style="width: 2px">
                                :</td>
                            <td style="width: 210px" class="AlineacionIzquierda">
                                <asp:TextBox ID="txtNombreAlumno" runat="server" Font-Size="Small" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblFechaInicial" runat="server" Text="Desde :"></asp:Label>
                                <ew:CalendarPopup ID="calFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                                    ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                    DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al d�a de hoy"
                                    ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                    PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate=""
                                    PopupLocation="Left">
                                    <TextBoxLabelStyle Width="65px" />
                                </ew:CalendarPopup>
                                <asp:Label ID="lblFechaFinal" runat="server" Text="Hasta :"></asp:Label>
                                <ew:CalendarPopup ID="calFechaFin" runat="server" ClearDateText="Limpiar fecha" ControlDisplay="TextBoxImage"
                                    CssClass="Calendar" Culture="Spanish (Argentina)" DisableTextBoxEntry="False"
                                    DisplayPrevNextYearSelection="True" GoToTodayText="Ir al d�a de hoy" ImageUrl="~/Contenido/Imagenes/calendario.jpg"
                                    Nullable="True" PadSingleDigits="True" PostedDate="" SelectedDate="" ShowClearDate="True"
                                    ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                                    <TextBoxLabelStyle Width="65px" />
                                </ew:CalendarPopup>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:CheckBox ID="chkAlumSence" runat="server" Checked="True" Text="Alumno Sence" /><asp:CheckBox
                                    ID="chkAlumInterno" runat="server" Checked="True" Text="Alumno no Sence" />
                                <br />
                                <asp:Label ID="Label11" runat="server" Text="Incluir alumnos"></asp:Label>
                                <asp:CheckBox ID="chkAnulados" runat="server" Text="Anulados" />
                                <asp:CheckBox ID="chkEliminados" runat="server" Text="Eliminados" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1"
                                    Visible="False">[HplkBajarArchivo]</asp:HyperLink>
                                <asp:Label ID="lblSeparacion" runat="server" Text="-"></asp:Label>
                                <asp:HyperLink ID="HplkBajarArchivoCliente" runat="server" meta:resourcekey="hlkBajarResource1"
                                    Visible="False">[HplkBajarArchivo]</asp:HyperLink></td>
                        </tr>
                    </table>
                    <div id="Bajar archivo">
                        <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar reporte" />
                        <asp:Button ID="btnBuscar" runat="server" Text="Consultar" ValidationGroup="gg" CssClass="btnLogin" /></div>
                </div>
            </div>
            <div id="contenido">
                <div id="resultados">
                    <table id="tablaHeader">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Alumnos capacitados para una empresa"></asp:Label></th>
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
