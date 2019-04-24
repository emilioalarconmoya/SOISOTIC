<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_terceros.aspx.vb" Inherits="modulo_cuentas_reporte_terceros" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
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
</head>
<body id="body" runat="server">
<form id="form2" runat="server" defaultbutton="btnBuscar">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales2" runat="server" />
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
                <li class="pestanaconsolaseleccionada">
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
                        <uc2:cabecera1 ID="datos_personales1" runat="server" />
                    </div>
                    <div id="filtros">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 376px">
                            <tr>
                                <td align="center">
                                    <span></span>&nbsp;&nbsp;<span></span> <span>
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
                                    <ew:CalendarPopup ID="CalFechaFin" runat="server" ClearDateText="Limpiar fecha" ControlDisplay="TextBoxImage"
                                        CssClass="Calendar" Culture="Spanish (Argentina)" DisableTextBoxEntry="False"
                                        DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy" ImageUrl="~/Contenido/Imagenes/calendario.jpg"
                                        Nullable="True" PadSingleDigits="True" PopupLocation="Left" PostedDate="" SelectedDate=""
                                        ShowClearDate="True" ShowGoToToday="True" VisibleDate="">
                                        <TextBoxLabelStyle Width="65px" />
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                        </table>
                        <div id="Bajar archivo">
                            <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar Reporte" /><br />
                            <asp:Button ID="btnBuscar" runat="server" CssClass="btnLogin" Text="Consultar" />&nbsp;
                            <br />
                            <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1"
                                Visible="False">[HplkBajarArchivo]</asp:HyperLink>
                        </div>
                    </div>
                </div>
            <div id="contenido"> 
                
            <div id="resultados">
            <br />
            <table id="tablaHeader">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Cartola de actividades contratadas para terceros"></asp:Label></th>                            
                        </tr>
                     </table>
                <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado" width ="980px">
                 <Columns>
                     <asp:TemplateField HeaderText="Correlativo">
                         <ItemTemplate>
                             <table width="50" class="TablaInterior">
                                 <tr>
                                     <td align="left" class="AlineacionIzquierda">
                                         <asp:HyperLink ID="HyperLinkCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink>
                                         <asp:LinkButton ID="d" runat="server" Text='<%# Bind("diferenciacionCurso") %>'></asp:LinkButton></td>
                                 </tr>
                                 <tr>
                                     <td align="left" class="AlineacionIzquierda">
                                         <asp:Label ID="lblEstadoCurso" runat="server" Text='<%# Bind("estado_curso") %>'></asp:Label><br />
                                         <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# Bind("rut_cliente") %>' />
                                         <asp:HiddenField ID="hdfCodSence" runat="server" Value='<%# Bind("codigo_sence") %>' />
                                         <asp:HiddenField ID="hdfRutOtec" runat="server" Value='<%# Bind("rut") %>' />
                                         <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                                     </td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Empresa beneficiada, curso y otec">
                         <ItemTemplate>
                             <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                 <tr>
                                     <td align="left" colspan="3" style="width: 400px;" valign="top" class="AlineacionIzquierda">
                                         <asp:HyperLink ID="HyperLinkRazonSocial" runat="server" Text='<%# Bind("razon_social_empresa") %>'></asp:HyperLink></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblRut" runat="server" Text="Rut"></asp:Label></td>
                                     <td style="width: 2px" valign="top">
                                         :</td>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblBindRut" runat="server" Text='<%# Bind("rut_cliente") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblCurso" runat="server" Text="Curso"></asp:Label></td>
                                     <td style="width: 2px" valign="top">
                                         :</td>
                                     <td class="AlineacionIzquierda">
                                         <asp:HyperLink ID="HyperLinkCurso" runat="server" Text='<%# Bind("nombre_curso") %>'></asp:HyperLink></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblOtec" runat="server" Text="Otec"></asp:Label></td>
                                     <td style="width: 2px" valign="top">
                                         :</td>
                                     <td class="AlineacionIzquierda">
                                         <asp:HyperLink ID="HyperLinkOtec" runat="server" Text='<%# Bind("razon_social") %>'></asp:HyperLink></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblAlumnos" runat="server" Text="Alumnos"></asp:Label></td>
                                     <td style="width: 2px" valign="top">
                                         :</td>
                                     <td class="AlineacionIzquierda">
                                         <asp:HyperLink ID="hplAlumnos" runat="server" Text='<%# Bind("num_alumnos") %>'></asp:HyperLink></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Costo">
                         <ItemTemplate>
                             <table width="120" class="TablaInterior">
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         &nbsp;<asp:Label ID="lblCosto" runat="server" Text="Valor"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblBindCosto" runat="server" Text='<%# Bind("valor_curso") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         &nbsp;<asp:Label ID="lblOtic" runat="server" Text="Otic"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha" >
                                         <asp:Label ID="lblBindOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         &nbsp;<asp:Label ID="Label2" runat="server" Text="Empresa"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblBindEmpresa" runat="server" Text='<%# Bind("gasto_empresa") %>'></asp:Label></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Cargos periodo">
                         <ItemTemplate>
                             <table class="TablaInterior">
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblReparto" runat="server" Text="Reparto"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha" >
                                         <asp:Label ID="lblBindReparto" runat="server" Text='<%# Bind("monto_rep") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblExcedenteReparto" runat="server" Text="Exc reparto"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblBindExcedente" runat="server" Text='<%# Bind("monto_exc_rep") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblAdmin" runat="server" Text="Administracion"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px;">
                                         :</td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblCostoAdmin" runat="server" Text='<%# Bind("costo_adm") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblBecas" runat="server" Text="Becas"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblBindBecas" runat="server" Text='<%# Bind("monto_becas") %>'></asp:Label></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Complemento">
                         <ItemTemplate>
                             <table width="110" class="TablaInterior">
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 48px">
                                         <asp:Label ID="lblRep" runat="server" Text="Reparto"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha" style="width: 60px">
                                         <asp:Label ID="lblBindRep" runat="server" ></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 48px">
                                         <asp:Label ID="lblExcReparto" runat="server" Text="Exc reparto"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 2px">
                                         :</td>
                                     <td class="AlineacionDerecha" style="width: 60px">
                                         <asp:Label ID="lblBindExcRep" runat="server" ></asp:Label></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                   <ItemStyle VerticalAlign="Top" />
                     </asp:TemplateField>
                 </Columns>          
                </asp:GridView>
            </div>
            </div>
            </div> 
        <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>    
    </form>    
</body>
</html>
