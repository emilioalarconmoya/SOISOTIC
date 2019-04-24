<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_por_tramo.aspx.vb" Inherits="Reportes_reporte_por_tramo" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../contenido/ascx/cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>
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
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>

  </head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
     <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
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
                <li>
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
                </li>
                 <li class="pestanaconsolaseleccionada">
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
      </div>
     <div id="contenido">  
     <div id="resultados">
     <div id="GraficoGrid">
     <table id="tablaHeader">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Análisis Por Franquicia"></asp:Label></th>                            
                        </tr>
                     </table>
        <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado" width ="360px" CellPadding="4" ForeColor="#333333" GridLines="None" Height="104px">
         <Columns>
             <asp:TemplateField HeaderText="Franquicia">
                 <ItemTemplate>
                     <%--<table cellpadding="0" cellspacing="0" class="TablaInterior">
                         <tr>
                             <td style="width: 100px">--%>
                                 <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("franquicia") %>'></asp:Label>%
                             <%--</td>
                         </tr>
                     </table>--%>
                 </ItemTemplate>
                 <ItemStyle Width="120px" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Cantidad Participantes">
                 <ItemTemplate>
                     <%--<table cellpadding="0" cellspacing="0" class="TablaInterior" width="120">
                         <tr>
                             <td style="width: 120px;">--%>
                                 <asp:Label ID="lblCanT" runat="server" Text='<%# Bind("cant_tramo") %>'></asp:Label>
                                 <asp:Label ID="Label4" runat="server" Text="("></asp:Label>
                                 <asp:Label ID="lblPorcP" runat="server" Text='<%# Bind("porcentaje_alumno") %>'></asp:Label>%
                                 <asp:Label ID="Label2" runat="server" Text=")"></asp:Label>
                             <%--</td>
                         </tr>
                     </table>--%>
                 </ItemTemplate>
                 <ItemStyle Width="120px" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Horas Hombre">
                 <ItemTemplate>
                     <%--<table cellpadding="0" cellspacing="0" class="TablaInterior" width="120">
                         <tr>
                             <td style="width: 120px;">--%>
                                 <asp:Label ID="lblHH" runat="server" Text='<%# Bind("HH") %>'></asp:Label>
                                 <asp:Label ID="Label4" runat="server" Text="("></asp:Label>
                                 <asp:Label ID="lblPorcH" runat="server" Text='<%# Bind("porcentaje_horas") %>'></asp:Label>%
                                 <asp:Label ID="Label2" runat="server" Text=")"></asp:Label>
                             <%--</td>
                         </tr>
                     </table>--%>
                 </ItemTemplate>
                 <ItemStyle Width="120px" />
             </asp:TemplateField>
         </Columns>   
            <RowStyle BackColor="#EFF3FB" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
                
        </asp:GridView>
        <br />
          </div>
         <div id="Grafico">
         <table>
             <tr>
                 <td style="width: 440px" rowspan="2">
         <asp:Literal ID="litGrafico" runat="server"></asp:Literal></td>
                 <td rowspan="2" style="width: 440px">
                     <asp:Literal ID="litGrafico2" runat="server"></asp:Literal></td>
             </tr>
             <tr>
             </tr>
         </table>
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
