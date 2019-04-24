<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_cuentas.aspx.vb" Inherits="modulo_cuentas_Reporte_Cuentas" EnableEventValidation="false" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Src="../contenido/ascx/cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

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
                <li>
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
                 <li class="pestanaconsolaseleccionada">
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
    <div id="DatosUsuario">
        <uc2:cabecera1 ID="Cabecera1" runat="server" />
    </div>
    <div id="filtros">
         <asp:Label ID="label4" runat="server" Text="Desde :"></asp:Label>
                                    <ew:CalendarPopup ID="CalFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                        PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                        VisibleDate="">
                                        <TextBoxLabelStyle Width="65px" />
                                    </ew:CalendarPopup>
          <asp:Label ID="Label5" runat="server" Text="Hasta :"></asp:Label>
                                    <ew:calendarpopup id="CalFechaFin" runat="server" cleardatetext="Limpiar fecha" controldisplay="TextBoxImage"
                                        cssclass="Calendar" culture="Spanish (Argentina)" disabletextboxentry="False"
                                        displayprevnextyearselection="True" gototodaytext="Ir al día de hoy" imageurl="~/Contenido/Imagenes/calendario.jpg"
                                        nullable="True" padsingledigits="True" popuplocation="Left" posteddate="" selecteddate=""
                                        showcleardate="True" showgototoday="True" visibledate="">
                             <TextBoxLabelStyle Width="65px"  />
                            </ew:calendarpopup>
                            <asp:Label ID="Label3" runat="server" Text="Cuenta :"></asp:Label>
                                        <asp:DropDownList ID="ddlCuenta" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="1">Capacitacion</asp:ListItem>
                                            <asp:ListItem Value="2">Reparto</asp:ListItem>
                                            <asp:ListItem Value="4">Exc Capacitacion</asp:ListItem>
                                            <asp:ListItem Value="5">Exc Reparto</asp:ListItem>
                                            <asp:ListItem Value="3">Administracion</asp:ListItem>
                                            <asp:ListItem Value="6">Becas</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar Reporte" /><br />
                                        <asp:Button ID="btnBuscar" runat="server" CssClass="btnLogin" Text="Consultar" />&nbsp;
                                        <br />
                                        <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1"
                                            Visible="False"></asp:HyperLink>
                                            
    </div>
        <fieldset id="mantenedor" >
            <%--<div id="filtrosMantenedor">--%>
                <div>
                <table id="tablaHeader">
                    <tr>
                        <th width="980px" class="TituloGrupo" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="Cartola cuenta de"></asp:Label>
                            <asp:Label ID="lblTipo" runat="server"></asp:Label></th>                            
                    </tr>
                </table>
                <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid" ShowFooter="True" EmptyDataText="Sin datos para el ciclo seleccionado" width ="960px" OnRowDataBound="grdResultados_RowDataBound">
                   <Columns>
                       <asp:TemplateField HeaderText="Fecha">
                           <ItemTemplate>
                               <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaHora") %>'></asp:Label>
                               <asp:HiddenField ID="hdfCodAporte" runat="server" Value='<%# Bind("cod_aporte") %>' />
                               <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# Bind("rut_cliente") %>' />
                               <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                               <asp:HiddenField ID="hdfTipoTran" runat="server" Value='<%# Bind("cod_tipo_tran") %>' />
                           </ItemTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" Width="60px" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Movimiento">
                           <ItemTemplate>
                               <asp:Label ID="lblTransaccion" runat="server" Text='<%# Bind("NumTransaccion") %>'></asp:Label>
                               <asp:Label ID="Label2" runat="server" Text=":" CssClass="dosPuntos"></asp:Label>
                               <asp:HyperLink ID="hplDescripcion" runat="server" Text='<%# Bind("DescripcionTipoTran") %>'></asp:HyperLink>
                           </ItemTemplate>
                           <FooterTemplate>
                               <asp:Label ID="Label3" runat="server" Text="Total Mes :"></asp:Label>
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Width="500px" Height="0px" VerticalAlign="Top" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Abono">
                           <ItemTemplate>
                               <asp:Label ID="lblAbono" runat="server" Text='<%# Bind("Abono") %>'></asp:Label>
                           </ItemTemplate>
                           <FooterTemplate>
                               <asp:Label ID="lblTotAbono" runat="server"></asp:Label>
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Cargo">
                           <ItemTemplate>
                               <asp:Label ID="lblCargo" runat="server" Text='<%# Bind("Cargo") %>'></asp:Label>
                           </ItemTemplate>
                           <FooterTemplate>
                               <asp:Label ID="lblTotCargo" runat="server"></asp:Label>
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Saldo">
                           <ItemTemplate>
                               <asp:Label ID="lblSaldo" runat="server" Text='<%# Bind("Saldo") %>'></asp:Label>
                           </ItemTemplate>
                           <FooterTemplate>
                               <asp:Label ID="lblSaldoAct" runat="server"></asp:Label>
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Estado">
                           <ItemTemplate>
                               <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("NombreEstadoTran") %>'></asp:Label>
                           </ItemTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" />
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
           <%-- </div>--%>
        </fieldset>       
    </div>
     <div id="pie" onclick="return pie_onclick()">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>