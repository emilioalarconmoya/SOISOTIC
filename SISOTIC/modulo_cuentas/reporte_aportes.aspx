<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_aportes.aspx.vb" Inherits="modulo_cuentas_reporte_aportes" EnableEventValidation="false" %>

<%@ Register Src="../contenido/ascx/Cabecera.ascx" TagName="Cabecera" TagPrefix="uc2" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

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
    <form id="form1" runat="server" defaultbutton="btnConsultar">
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
                <li class="pestanaconsolaseleccionada">
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
            <uc2:Cabecera ID="Cabecera2" runat="server" />
            </div>
            <div id="filtros">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 376px">
                    <tr>
                        <td align="center" >
                           <br />
                                        <asp:Label ID="label2" runat="server" Text="Desde :"></asp:Label>
                                    <ew:CalendarPopup ID="CalFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                        PopupLocation="Left" PostedDate="" SelectedDate="" ShowClearDate="True" ShowGoToToday="True"
                                        VisibleDate="">
                                        <TextBoxLabelStyle Width="65px" />
                                    </ew:CalendarPopup>
                            &nbsp;<asp:Label ID="Label7" runat="server" Text="Hasta :"></asp:Label>
                                    <ew:calendarpopup id="CalFechaFin" runat="server" cleardatetext="Limpiar fecha" controldisplay="TextBoxImage"
                                        cssclass="Calendar" culture="Spanish (Argentina)" disabletextboxentry="False"
                                        displayprevnextyearselection="True" gototodaytext="Ir al día de hoy" imageurl="~/Contenido/Imagenes/calendario.jpg"
                                        nullable="True" padsingledigits="True" popuplocation="Left" posteddate="" selecteddate=""
                                        showcleardate="True" showgototoday="True" visibledate="">
                             <TextBoxLabelStyle Width="65px"  />
                            </ew:calendarpopup>
                                    <br />
                            <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar reporte" /><br />
                                  <asp:Button ID="btnConsultar" runat="server" Text="Consultar" /><br />
                            <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1"
                                Visible="False">[HplkBajarArchivo]</asp:HyperLink><br />
                            </td>
                    </tr>
                </table>
            </div>
                   
        </div>
        
        <div id="contenido"> 
         <div id="resultados">
                <table id="tablaHeader">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label3" runat="server" Text="Cartola de aportes efectuados en el período"></asp:Label></th>                            
                        </tr>
                     </table>
                <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado" width ="100%" Height="32px" ShowFooter="True">
         <Columns>
             <asp:TemplateField HeaderText="Fecha">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="lblFecha" runat="server" Text='<%# bind("fecha_ingreso") %>'></asp:Label>
                 </ItemTemplate>
                 <HeaderStyle Wrap="True" />
                 <ItemStyle Wrap="True" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Movimiento">
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text="Aporte #"></asp:Label>
                     <asp:HyperLink ID="hplAporte" runat="server" Text='<%# bind("num_aporte") %>'></asp:HyperLink>:
                     <asp:Label ID="Label4" runat="server" Text='<%# bind("nombre_cuenta") %>'></asp:Label>&nbsp;<br />
                     <asp:HiddenField ID="hdfCodAporte" runat="server" Value='<%# Bind("cod_aporte") %>' />
                     <br />
                     <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# Bind("rut_cliente") %>' />
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Aporte Neto">
                 <ItemTemplate>
                     <asp:Label ID="lblAporteNeto" runat="server" Text='<%# bind("monto_neto") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Administracion">
                 <ItemTemplate>
                     <asp:Label ID="lblAdministracion" runat="server" Text='<%# bind("monto_adm") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Aporte total">
                 <ItemTemplate>
                     <asp:Label ID="lblMontoTotal" runat="server" Text='<%# bind("monto_total") %>'></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Right" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Estado">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="lblEstado" runat="server" Text='<%# bind("Nombre") %>'></asp:Label>
                 </ItemTemplate>
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Observacion">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="lblObservacion" runat="server" Text='<%# bind("observaciones") %>'></asp:Label>
                 </ItemTemplate>
                 <HeaderStyle Wrap="False" />
                 <ItemStyle Wrap="False" />
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
          <div id="pie" onclick="return pie_onclick()">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
          </div>
        </div>
    </form>
</body>
</html>