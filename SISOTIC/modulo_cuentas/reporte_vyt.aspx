<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_vyt.aspx.vb" Inherits="modulo_cuentas_reporte_vyt" %>
<%@ Register Src="../contenido/ascx/Cabecera.ascx" TagName="Cabecera" TagPrefix="uc2" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
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
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
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
                <li>
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
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
                <uc2:Cabecera ID="Cabecera1" runat="server" />
            </div>
            <div id="filtros">
                <asp:Label ID="label12" runat="server" Text="Desde :"></asp:Label>
                <ew:CalendarPopup ID="CalFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                    ControlDisplay="TextBoxImage" CssClass="Calendar" 
                    DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                    ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                    PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                    VisibleDate="">
                    <TextBoxLabelStyle Width="65px" />
                </ew:CalendarPopup>
                <asp:Label ID="Label7" runat="server" Text="Hasta :"></asp:Label>
                <ew:calendarpopup id="CalFechaFin" runat="server" cleardatetext="Limpiar fecha" controldisplay="TextBoxImage"
                    cssclass="Calendar"  disabletextboxentry="False"
                    displayprevnextyearselection="True" gototodaytext="Ir al día de hoy" imageurl="~/Contenido/Imagenes/calendario.jpg"
                    nullable="True" padsingledigits="True" popuplocation="Left" posteddate="" selecteddate=""
                    showcleardate="True" showgototoday="True" visibledate="">
                    <TextBoxLabelStyle Width="65px"  />
                </ew:calendarpopup><br />
                <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar Reporte" /><br />
                <asp:Button ID="btnBuscar" runat="server" Text="Consultar" />&nbsp;
                <br />
                <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1"
                    Visible="False"></asp:HyperLink>
            </div>
         </div>
         <div id="contenido">            
            <div id="resultados">
                <div>
                    <table id="tablaHeader" width="980px" >
                        <tr>
                            <th class="TituloGrupo">
                                <asp:Label ID="Label1" runat="server" Text="Cartola de Viáticos y Traslado"></asp:Label></th>                            
                        </tr>
                     </table> 
                </div>
                <table id="tablaVyT" runat="server" cellpadding="0" cellspacing="0" class="Grid" visible="true" style="width: 100%;">
                    <tr>
                        <th style="width: 40px; height: 19px;">
                            <asp:Label ID="Label3" runat="server" Text="Fecha"></asp:Label>
                        </th> 
                        <th style="width: 500px; height: 19px;">
                            <asp:Label ID="Label4" runat="server" Text="Curso"></asp:Label>
                        </th>   
                        <th style="width: 110px; height: 19px;">
                            <asp:Label ID="Label5" runat="server" Text="Total VYT"></asp:Label>
                        </th>   
                        <th style="width: 110px; height: 19px;">
                            <asp:Label ID="Label6" runat="server" Text="Costo OTIC VYT"></asp:Label>
                        </th>   
                        <th style="width: 110px; height: 19px;">
                            <asp:Label ID="Label2" runat="server" Text="Gasto Emp. VYT"></asp:Label>
                        </th>   
                        <th style="width: 110px; height: 19px;">
                            <asp:Label ID="Label8" runat="server" Text="Saldo"></asp:Label>
                        </th>                                   
                    </tr>
                    <tr id="trDetalle" runat="server">
                        <td style="width: 40px; height: 14px;" >
                            <asp:Label ID="lblFecha" runat="server"></asp:Label>
                        </td>
                        <td style="width: 500px; height: 14px;">
                            <asp:Label ID="Label9" runat="server" Text="Saldo anterior"></asp:Label>
                        </td>
                        <td style="width: 110px; height: 14px;">
                            <asp:Label ID="Label10" runat="server">-</asp:Label>
                        </td>
                        <td style="width: 110px; height: 14px;">
                            <asp:Label ID="Label11" runat="server">-</asp:Label>
                        </td>
                        <td style="width: 110px; height: 14px;">
                            <asp:Label ID="Label13" runat="server">-</asp:Label>
                        </td>
                        <td style="width: 110px; height: 14px;">
                            <asp:Label ID="lblSaldo" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grdResultadosVyT" runat="server"  AutoGenerateColumns="False" CssClass="Grid" ShowFooter="True" ShowHeader="False"  EmptyDataText="Sin datos para el ciclo seleccionado"  OnRowDataBound="grdResultados_RowDataBound" Width="100%" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblFechaInicio" runat="server" Text='<%# Bind("fecha_inicio") %>'></asp:Label>
                                <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                            </ItemTemplate>
                            <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            <ItemStyle Height="0px" Width="56px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>                            
                                <asp:HyperLink ID="hplCurso" runat="server" Text='<%# Bind("descripcion") %>' Width="400px"></asp:HyperLink>
                            </ItemTemplate>
                            <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            <ItemStyle Height="0px" Width="420px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("total_vyt") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalViatico" runat="server"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            <ItemStyle Height="0px" Width="110px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("costo_otic_vyt") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalTraslado" runat="server"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            <ItemStyle Height="0px" Width="110px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblGastoEmpresa" runat="server" Text='<%# Bind("gasto_empresa_vyt") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalGastoEmpresa" runat="server"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            <ItemStyle Height="0px" Width="110px" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblSaldo" runat="server" Text='<%# Bind("saldo") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblSaldoTotal" runat="server"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle VerticalAlign="Top" CssClass="Footer" />
                            <ItemStyle Height="0px" Width="110px" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>            
    </div>
     <div id="pie" onclick="return pie_onclick()">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
