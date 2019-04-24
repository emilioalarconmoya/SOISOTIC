<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_cursos_consolidado.aspx.vb" Inherits="Reportes_reporte_cursos_consolidado" EnableEventValidation="false"  %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    
<%@ Register Src="../contenido/ascx/cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script> 

    <link href="http://localhost:4418/estilo.css" rel="Stylesheet" type="text/css" />
    <link href="http://localhost:4418/estilo.css" rel="Stylesheet" type="text/css" />
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
            <uc2:cabecera1 ID="Cabecera1" runat="server" />
        </div>
        <div id="filtros">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <span>
                        </span>&nbsp;&nbsp;<span></span>
                        <span>
                        <asp:Label ID="lblFechaInicial" runat="server" Text="Desde :"></asp:Label></span>
                        <ew:CalendarPopup ID="calFechaInicial" runat="server" ClearDateText="Limpiar fecha"
                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" 
                        Nullable="True" PadSingleDigits="True" PostedDate=""
                        SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                            <TextBoxLabelStyle Width="65px" />
                        </ew:CalendarPopup>
           
                        <span>
                        <asp:Label ID="lblFechaFinal" runat="server" Text="Hasta :"></asp:Label></span>
                        <ew:CalendarPopup ID="calFechaFinal" runat="server" ClearDateText="Limpiar fecha"
                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)" 
                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" 
                        Nullable="True" PadSingleDigits="True" PostedDate=""
                        SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                            <TextBoxLabelStyle Width="65px" />
                        </ew:CalendarPopup>
                        <br />
                        <asp:CheckBox ID="chkCursoInterno" runat="server" Text="Curso no Sence :" TextAlign="Left" Checked="True" />&nbsp;
                        <asp:CheckBox ID="chkCursoSence" runat="server" Text="Curso Sence :" TextAlign="Left" Checked="True" /><br />
                        <asp:Label ID="Label11" runat="server" Text="Incluir cursos"></asp:Label>&nbsp;<asp:CheckBox
                            ID="chkAnulados" runat="server" Text="Anulados" />
                        <asp:CheckBox ID="chkEliminados" runat="server" Text="Eliminados" /><br />
            <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1" Visible="False">[HplkBajarArchivo]</asp:HyperLink>
                        <asp:Label ID="lblSeparacion" runat="server" Text="-"></asp:Label>
                        <asp:HyperLink ID="HplkBajarArchivoCliente" runat="server" meta:resourcekey="hlkBajarResource1"
                            Visible="False">[HplkBajarArchivoCliente]</asp:HyperLink></td>
                </tr>
            </table>
             <div id="Bajar archivo">
            <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar reporte" />
                 &nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Consultar" CssClass="btnLogin" />&nbsp;<br />
        </div>
    </div>
    </div>
    <div id="contenido"> 
    <div id="resultados">
     <table id="tablaHeader">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Cartola de actividades contratadas"></asp:Label></th>                            
                        </tr>
        </table>
     <asp:GridView ID="GridResultados" runat="server" CssClass="Grid" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GridResultados_RowDataBound" Width="100%">
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
                    <ItemStyle VerticalAlign="Top"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correl.">
                    <ItemTemplate>
                        <table class="TablaInterior" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 40px" valign="top" class="AlineacionIzquierda">
                                    <asp:HyperLink ID="HplkCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink>
                                    <asp:HyperLink
                                        ID="d" runat="server" Text='<%# Bind("diferenciacionCurso") %>'></asp:HyperLink></td>  </tr>
                                         
                            <tr>
                                <td style="width: 40px" valign="top" class="AlineacionIzquierda" >
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("estado_curso") %>' Visible="false" ></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 40px" valign="top" class="AlineacionIzquierda">
                                <asp:HyperLink ID="hplEstado" runat="server" Text='<%# Bind("estado_curso")%>'>HyperLink</asp:HyperLink>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 40px" valign="top">
                                    <asp:Label ID="lblTipoCurso" runat="server" Text='<%# Bind("tipo_curso") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                        <td style="width: 40px" valign="top" class="AlineacionIzquierda">
                                    <asp:Label ID="lblRegistro" runat="server" Text="Nº Reg:" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="lblNroRegistro" runat="server" Text='<%# Bind("nro_registro") %>' Font-Bold="true"></asp:Label></td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                        <asp:HiddenField ID="hdfCodSence" runat="server" Value='<%# Bind("codigo_sence") %>' />
                        <asp:HiddenField ID="hdfRutOtec" runat="server" Value='<%# Bind("rut_otec")%>' />
                    <asp:HiddenField ID="hdfEstadoCurso" runat="server" Value='<%# Bind("estado_curso")%>' />
                        <asp:HiddenField ID="hdfAgno" runat="server" Value='<%# bind("año") %>' />
                        <asp:HiddenField ID="hdfCodEstadoCurso" runat="server" Value='<%# bind("cod_estado_curso") %>' />
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top"  />
                    <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Curso y OTEC">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="TablaInterior">
                            <tr>
                                <td style="width: 170px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblCurso" runat="server" Text="Curso"></asp:Label></td>
                                <td style="width: 2px">
                                    <asp:Label ID="Label25" runat="server" Text=":"></asp:Label></td>
                                <td class="AlineacionIzquierda" colspan="4">
                                    <asp:HyperLink ID="HplkCurso" runat="server" Text='<%# Bind("nombre_curso") %>'></asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 170px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblOtec" runat="server" Text="OTEC"></asp:Label></td>
                                <td style="width: 2px">
                                    <asp:Label ID="lblDosPnOtec" runat="server" Text=":"></asp:Label></td>
                                <td class="AlineacionIzquierda" colspan="4">
                                    <asp:HyperLink ID="HplkOtec" runat="server" Text='<%# Bind("razon_social_otec") %>'></asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 170px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblAlumnos" runat="server" Text="Alumnos"></asp:Label></td>
                                <td style="width: 2px">
                                    <asp:Label ID="Label24" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 100px" class="AlineacionIzquierda">
                                    <asp:HyperLink ID="HplkAlumnos" runat="server" Text='<%# Bind("numero_alumnos")%>'></asp:HyperLink></td>
                                <td style="width: 170px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblHorasCurso" runat="server" Text="Horas Curso"></asp:Label></td>
                                <td style="width: 2px">
                                    :</td>
                                <td style="width: 100px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblDataHorasC" runat="server" Text='<%# Bind("horas") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 170px;" class="AlineacionIzquierda">
                                    <asp:Label ID="lblAlumnosFinanciados" runat="server" Text="Alum. Aprobados"></asp:Label></td>
                                <td style="width: 2px;">
                                    <asp:Label ID="Label23" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 100px;" class="AlineacionIzquierda">
                                    <asp:Label ID="lblDataAlumFinan" runat="server" Text='<%# Bind("participantes_aprobado_por_asistencia") %>'></asp:Label></td>
                                <td style="width: 170px;" class="AlineacionIzquierda">
                                    <asp:Label ID="lblHHxPart" runat="server" Text="HH(hrs x part)"></asp:Label></td>
                                <td style="width: 2px;">
                                    :</td>
                                <td style="width: 100px;" class="AlineacionIzquierda">
                                    <asp:Label ID="lblDataHHxPart" runat="server" Text='<%# Bind("HH")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 170px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblNumFactura" runat="server" Text="Nº Factura"></asp:Label></td>
                                <td style="width: 2px">
                                    <asp:Label ID="Label22" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 100px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblDataFactura" runat="server" Text='<%# Bind("numero_factura")%>'></asp:Label>
                                    <asp:Label ID="Lblsf" runat="server"></asp:Label></td>
                                <td style="width: 170px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblHHConAsist" runat="server" Text="Hrs. c/asis."></asp:Label></td>
                                <td style="width: 2px">
                                    :</td>
                                <td style="width: 100px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblDataHHConAsist" runat="server" Text='<%# Bind("hh_con_asistencia_mayor_a_cero")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 170px" class="AlineacionIzquierda">
                                    <asp:Label ID="lblNumeroInterno" runat="server" Text="Número Interno"></asp:Label></td>
                                <td style="width: 2px">
                                    <asp:Label ID="Label6" runat="server" Text=":"></asp:Label></td>
                                <td class="AlineacionIzquierda" colspan="4">
                                    <asp:Label ID="lblDataNumeroIn" runat="server" Text='<%# Bind("correlativo_empresa") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top"  />
                    <FooterTemplate>
                        <table cellpadding="0" cellspacing="0" class="TablaFooter" width="300">
                            <tr>
                                <td class="AlineacionDerecha" style="width: 300px">
                                    <asp:Label ID="lblRegistrosConsultados" runat="server" Text="Totales Registros Consultados :"></asp:Label></td>
                            </tr>
                        </table>
                    </FooterTemplate>
                    <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Costo">
                    <ItemTemplate>
                        <table class="TablaInterior" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 80px" align="left" valign="top" class="titulo2">
                                    <asp:Label ID="Label16" runat="server" Text="Valor"></asp:Label></td>
                                <td align="left" valign="top" class="dosPuntos">
                                    <asp:Label ID="Label5" runat="server" Text=":"></asp:Label></td>
                                <td align="left" valign="top" class="ValorTituloDos">
                                    <asp:Label ID="lblValorCurso" runat="server" Text='<%# Bind("valor_mercado") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 80px" align="left" valign="top" class="titulo2">
                                    <asp:Label ID="Label17" runat="server" Text="OTIC"></asp:Label></td>
                                <td align="left" valign="top" class="dosPuntos">
                                    <asp:Label ID="lblDosPunOt" runat="server" Text=":"></asp:Label></td>
                                <td align="left" valign="top" class="ValorTituloDos">
                                    <asp:Label ID="lblCostoOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 80px" align="left" valign="top" class="titulo2">
                                    <asp:Label ID="Label18" runat="server" Text="Empresa"></asp:Label></td>
                                <td align="left" valign="top" class="dosPuntos">
                                    <asp:Label ID="lblDosPunEmp" runat="server" Text=":"></asp:Label></td>
                                <td align="left" valign="top" class="ValorTituloDos">
                                    <asp:Label ID="lblGastoEmpresa" runat="server" Text='<%# Bind("gasto_empresa") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 80px" align="left" valign="top" class="titulo2">
                                    <asp:Label ID="Label19" runat="server" Text="Tot V&T"></asp:Label></td>
                                <td align="left" valign="top" class="dosPuntos">
                                    <asp:Label ID="lblDosPunTot" runat="server" Text=":"></asp:Label></td>
                                <td align="left" valign="top" class="ValorTituloDos">
                                    <asp:Label ID="lblTotalVT" runat="server" Text='<%# Bind("total_vyt") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 80px" align="left" valign="top" class="titulo2">
                                    <asp:Label ID="Label20" runat="server" Text="Otic V&T"></asp:Label></td>
                                <td align="left" valign="top" class="dosPuntos">
                                    <asp:Label ID="lblDosPunOVyT" runat="server" Text=":"></asp:Label></td>
                                <td align="left" valign="top" class="ValorTituloDos">
                                    <asp:Label ID="lblOticVT" runat="server" Text='<%# Bind("costo_otic_vyt") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 80px" align="left" valign="top" class="titulo2">
                                    <asp:Label ID="Label21" runat="server" Text="Emp V&T"></asp:Label></td>
                                <td align="left" valign="top" class="dosPuntos">
                                    <asp:Label ID="lblDosPunEVyT" runat="server" Text=":"></asp:Label></td>
                                <td align="left" valign="top" class="ValorTituloDos">
                                    <asp:Label ID="lblEmpVT" runat="server" Text='<%# Bind("total_gasto_empresa_vyt")%>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                    <FooterTemplate>
                        <table class="TablaFooter" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 70px" class="AlineacionIzquierda">
                                    <asp:Label ID="Label1" runat="server" Text="Valor"></asp:Label></td>
                                <td style="width: 5px">
                                    :</td>
                                <td style="width: 110px" class="AlineacionDerecha">
                                    <asp:Label ID="lblTotalValor" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 70px" class="AlineacionIzquierda">
                                    <asp:Label ID="Label2" runat="server" Text="OTIC"></asp:Label></td>
                                <td style="width: 5px">
                                    :</td>
                                <td style="width: 110px" class="AlineacionDerecha">
                                    <asp:Label ID="lblTotalOTIC" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 70px" class="AlineacionIzquierda">
                                    <asp:Label ID="Label3" runat="server" Text="Emp "></asp:Label></td>
                                <td style="width: 5px">
                                    :</td>
                                <td style="width: 110px" class="AlineacionDerecha">
                                    <asp:Label ID="lblTotalEmp" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 70px" class="AlineacionIzquierda">
                                    <asp:Label ID="Label4" runat="server" Text="Tot VyT"></asp:Label></td>
                                <td style="width: 5px">
                                    :</td>
                                <td style="width: 110px" class="AlineacionDerecha">
                                    <asp:Label ID="lblTotalVyT" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 70px" class="AlineacionIzquierda">
                                    <asp:Label ID="Label7" runat="server" Text="Otic VyT"></asp:Label></td>
                                <td style="width: 5px">
                                    :</td>
                                <td style="width: 110px" class="AlineacionDerecha">
                                    <asp:Label ID="lblTotalOticVyT" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 70px" class="AlineacionIzquierda">
                                    <asp:Label ID="Label8" runat="server" Text="Emp VyT"></asp:Label></td>
                                <td style="width: 5px">
                                    :</td>
                                <td style="width: 110px" class="AlineacionDerecha">
                                    <asp:Label ID="lblTotalEmpVyT" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </FooterTemplate>
                    <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cargos del Periodo">
                    <ItemTemplate>
                        <table class="TablaInterior" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 48px; height: 18px;" class="ColumnaCargo">
                                    <asp:Label ID="Label28" runat="server" Text="Cap"></asp:Label></td>
                                <td style="width: 2px; height: 18px;" class="dosPuntos">
                                    <asp:Label ID="lblDosP1" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 98px; height: 18px;" class="ValorColumnaCargo">
                                    <asp:Label ID="lblCap" runat="server" Text='<%# Bind("cuenta_capacitacion")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 48px" class="ColumnaCargo">
                                    <asp:Label ID="Label29" runat="server" Text="ExcCap"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="lblDosP2" runat="server" Text=":"></asp:Label></td>
                                <td class="ValorColumnaCargo">
                                    <asp:Label ID="lblExcCap" runat="server" Text='<%# Bind("cuenta_exc_capacitacion")%>'></asp:Label></td>
                            </tr>
                            <%--<tr style="visibility:hidden;">
                                <td style="width: 48px" class="ColumnaCargo">
                                    <asp:Label ID="Label30" runat="server" Text="Becas"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="lblDosP3" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 98px" class="ValorColumnaCargo">
                                    <asp:Label ID="lblCtaBecas" runat="server" Text='<%# Bind("cuenta_becas")%>'></asp:Label></td>
                            </tr>--%>
                            <tr>
                                <td style="width: 48px" class="ColumnaCargo">
                                    <asp:Label ID="Label31" runat="server" Text="Reparto"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="lblDosP4" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 98px" class="ValorColumnaCargo">
                                    <asp:Label ID="lblReparto" runat="server" Text='<%# Bind("cuenta_reparto")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 48px" class="ColumnaCargo">
                                    <asp:Label ID="Label26" runat="server" Text="Exc. Reparto"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="Label27" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 98px" class="ValorColumnaCargo">
                                    <asp:Label ID="lblExcreparto" runat="server" Text='<%# Bind("cuenta_exc_reparto")%>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                    <FooterTemplate>
                        <table class="TablaFooter" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 50px;" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label9" runat="server" Text="Cap"></asp:Label></td>
                                <td style="width: 2px;" valign="top">
                                    :</td>
                                <td style="width: 98px;" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCargoCap" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label10" runat="server" Text="ExcCap"></asp:Label></td>
                                <td style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 98px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCargoExcCap" runat="server"></asp:Label></td>
                            </tr>
                           <%-- <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label11" runat="server" Text="Becas"></asp:Label></td>
                                <td style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 98px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCargoBecas" runat="server"></asp:Label></td>
                            </tr>--%>
                            <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label12" runat="server" Text="Ter"></asp:Label></td>
                                <td style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 98px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCargoTer" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </FooterTemplate>
                    <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Administracion">
                    <ItemTemplate>
                        <table class="TablaInterior" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 20px; height: 18px;" class="ColumnaAdmin1">
                                    <asp:Label ID="Label36" runat="server" Text="Cap"></asp:Label></td>
                                <td style="width: 2px; height: 18px;" class="dosPuntos">
                                    <asp:Label ID="lblDosP5" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 30%; height: 18px;" class="ColumnaAdmin2">
                                    <asp:Label ID="lblPorcAdmin" runat="server" Text='<%# Bind("porcentaje_adm")%>'></asp:Label>
                                    <asp:Label ID="lblPor1" runat="server" Text="%"></asp:Label></td>
                                <td style="width: 38px; height: 18px;" class="ColumnaAdmin2">
                                    <asp:Label ID="lblCtaAdmin" runat="server" Text='<%# Bind("cuenta_adm")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 20px; height: 18px;" class="ColumnaAdmin1">
                                    <asp:Label ID="Label37" runat="server" Text="ExcCap"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="lblDosP6" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 30%; height: 18px;" class="ColumnaAdmin2">
                                    <asp:Label ID="lblPorcExc" runat="server" Text="0"></asp:Label>
                                    <asp:Label ID="lblPor2" runat="server" Text="%"></asp:Label></td>
                                <td style="width: 38px; height: 18px;" class="ColumnaAdmin2">
                                    <asp:Label ID="lblPeso1" runat="server" Text="$"></asp:Label>
                                    <asp:Label ID="Label45" runat="server" Text="0"></asp:Label></td>
                            </tr>
                            <%--<tr>
                                <td style="width: 20px" class="ColumnaAdmin1">
                                    <asp:Label ID="Label38" runat="server" Text="Becas"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="lblDosP7" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 30%" class="ColumnaAdmin2">
                                    <asp:Label ID="lblPorcBec" runat="server" Text="0"></asp:Label>
                                    <asp:Label ID="lblPor3" runat="server" Text="%"></asp:Label></td>
                                <td style="width: 38px" class="ColumnaAdmin2">
                                    <asp:Label ID="lblPeso2" runat="server" Text="$"></asp:Label>
                                    <asp:Label ID="Label46" runat="server" Text="0"></asp:Label></td>
                            </tr>--%>
                            <tr>
                                <td style="width: 20px" class="ColumnaAdmin1">
                                    <asp:Label ID="Label39" runat="server" Text="Reparto"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="lblDosP8" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 30%" class="ColumnaAdmin2">
                                    <asp:Label ID="lblPorcTer" runat="server" Text="0"></asp:Label>
                                    <asp:Label ID="lblPor4" runat="server" Text="%"></asp:Label></td>
                                <td style="width: 38px" class="ColumnaAdmin2">
                                    &nbsp;<asp:Label ID="lblPeso3" runat="server" Text="$"></asp:Label>
                                    <asp:Label ID="Label47" runat="server" Text="0"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 20px" class="ColumnaAdmin1">
                                    <asp:Label ID="Label32" runat="server" Text="Exc Reparto"></asp:Label></td>
                                <td style="width: 2px" class="dosPuntos">
                                    <asp:Label ID="Label33" runat="server" Text=":"></asp:Label></td>
                                <td style="width: 30%" class="ColumnaAdmin2">
                                    <asp:Label ID="Label34" runat="server" Text="0"></asp:Label>
                                    <asp:Label ID="Label35" runat="server" Text="%"></asp:Label></td>
                                <td style="width: 38px" class="ColumnaAdmin2">
                                    &nbsp;<asp:Label ID="Label40" runat="server" Text="$"></asp:Label>
                                    <asp:Label ID="Label41" runat="server" Text="0"></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                    <FooterTemplate>
                        <table class="TablaFooter" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label13" runat="server" Text="Cap"></asp:Label></td>
                                <td style="width: 2px" valign="top" class="dosPuntos">
                                    :</td>
                                <td style="width: 98px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblAdminCap" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label14" runat="server" Text="ExcCap"></asp:Label></td>
                                <td style="width: 2px" valign="top" class="dosPuntos">
                                    :</td>
                                <td style="width: 98px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblAdminExcCap" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label15" runat="server" Text="Ter"></asp:Label></td>
                                <td style="width: 2px" valign="top" class="dosPuntos">
                                    :</td>
                                <td style="width: 98px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblAdminTer" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </FooterTemplate>
                    <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                        <div style="width:100%" >
                        <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td colspan="3" rowspan="3" style="width: 7px; height: 18px;">
                                        <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar"
                                            Width="90px" Font-Size="X-Small" Visible="False" /></td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="1" style="width: 7px; height: 18px;">
                                        <asp:Button ID="btnCerrarCurso" runat="server"
                                            Text="Cerrar Curso" Width="90px" Font-Size="X-Small" OnClick="btnCerrarCurso_Click" Visible="False" /></td>
                                </tr>
                            </table>
                        </div>
                            
                        </ItemTemplate>
                        <ItemStyle Height="0px" VerticalAlign="Top"/>
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <div style="width: 100%; text-align: left;">
                    Página 
                    <asp:DropDownList ID="paginasDropDownList" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="GoPage" runat="server"></asp:DropDownList>
                    de
                    <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" CommandName="Page" ToolTip="Prim. Pag"  CommandArgument="First" CssClass="pagfirst" />                    
                    <asp:Button ID="Button1" runat="server" CommandName="Page" ToolTip="Pág. anterior"  CommandArgument="Prev" CssClass="pagprev" />
                    <asp:Button ID="Button2" runat="server" CommandName="Page" ToolTip="Sig. página" CommandArgument="Next" CssClass="pagnext" />                    
                    <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="últ. Pag"  CommandArgument="Last" CssClass="paglast" />
                </div>
           </PagerTemplate>
           <PagerStyle CssClass="pagerstyle" />
        </asp:GridView>
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
