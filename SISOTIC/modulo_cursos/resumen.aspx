<%@ Page Language="VB" AutoEventWireup="false" CodeFile="resumen.aspx.vb" Inherits="modulo_cursos_resumen" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Resumen cursos</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
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
                <li class="pestanaconsolaseleccionada">
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
                    <asp:HyperLink ID="hplReporteCursosNoSence" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
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
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        <div id="Cabecera">
            <%--<div id="DatosUsuario">
                <uc2:cabecera1 ID="datos_personales1" runat="server" />
            </div>
            <div id="filtros">
                
            </div>--%>
            <div class="AlineacionIzquierda" style="width:50%; float:left;" >
            <asp:Label ID="lblEjecutivos" runat="server" Text="Ejecutivos de cuenta : "></asp:Label>
            <asp:DropDownList ID="ddlEjecutivos" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
                </div>
        <div class="AlineacionDerecha" style="width:48%; float:right;">
            <asp:Label ID="lblAgnos" runat="server" Text="Año : "></asp:Label>
            <asp:DropDownList ID="ddlAgnos" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </div>
            
        </div>        
        <div id="contenido">            
            <div id="resultados">
                <div id="Grafico1" runat="server">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 500px" valign="top">
                    <asp:Literal ID="litGrafico1" runat="server"></asp:Literal></td>
                            <td style="width: 470px" valign="top">
                                <asp:GridView CssClass="Grid" ID="grdIndicadores1" runat="server" AutoGenerateColumns="False" Width="450px" ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Indicador">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIndicador" runat="server" Text='<%# Bind("indicador") %>'></asp:Label>
                                                <asp:HiddenField ID="hdfEstados" runat="server" Value='<%# Bind("estados") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle Width="340px" />
                                            <ItemStyle Width="340px" />
                                            <FooterTemplate>
                                                <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
                                            </FooterTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="N&#186; Cursos">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hplNumCursos" runat="server" Text='<%# Bind("cantidad") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="110px" />
                                            <ItemStyle Width="110px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" valign="top">
                                <asp:Button ID="btnVerMas" runat="server" Text="Mostrar más indicadores" />
                                <asp:Button ID="btnOcultar" runat="server" Text="Ocultar indicadores" Visible="False" />
                                <asp:Label ID="lblAdvertencia" runat="server" CssClass="Advertencia" Text="ATENCIÓN: Este proceso puede tardar unos momentos. Favor esperar."></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div id="Grafico2" runat="server" visible="false" >
                    <asp:Literal ID="litGrafico2" runat="server"></asp:Literal>
                </div>
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
