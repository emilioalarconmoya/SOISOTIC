<%@ Page Language="VB" AutoEventWireup="false" CodeFile="menu_cargas.aspx.vb" Inherits="modulo_cursos_menu_cargas" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menú de Cargas</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="contenedor">
            <div id="bannner">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
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
                <li class="pestanaconsolaseleccionada">
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
            <div id="contenido">
                <div id="resultados">
                    <table align="center" style="width: 296px">
                        <tr>
                            <td align="center" style="width: 54%">
                                <span style="font-size: 16pt">Menú de Cargas</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 54%">
                                <asp:Menu ID="menuNetCap" runat="server" Style="position: static">
                                    <DynamicMenuStyle CssClass="Menu" />
                                    <Items>
                                        <asp:MenuItem NavigateUrl="~/modulo_cursos/CargaCursos.aspx" Text="Carga de curso mediante archivo xls"
                                            Value="M&#243;dulo Cursos Presenciales"></asp:MenuItem>
                                        <%-- <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_cursos_mdb.aspx" Text="Carga de cursos mediante archivo mdb"
                                            Value="M&#243;dulo Cursos E-Learning (CVC)"></asp:MenuItem>
                                        <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_web_service.aspx" Text="Carga web service" Value="Presupuesto">
                                        </asp:MenuItem>--%>
                                    </Items>
                                </asp:Menu>
                                <asp:Menu ID="Menu1" runat="server" Style="position: static">
                                    <DynamicMenuStyle CssClass="Menu" />
                                    <Items>
                                        <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_curso_interno.aspx" Text="Carga de curso interno mediante archivo xls"
                                            Value="M&#243;dulo Cursos Presenciales"></asp:MenuItem>
                                        <%-- <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_cursos_mdb.aspx" Text="Carga de cursos mediante archivo mdb"
                                            Value="M&#243;dulo Cursos E-Learning (CVC)"></asp:MenuItem>
                                        <asp:MenuItem NavigateUrl="~/modulo_cursos/carga_web_service.aspx" Text="Carga web service" Value="Presupuesto">
                                        </asp:MenuItem>--%>
                                    </Items>
                                </asp:Menu>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="pie">
            <div class="textoPie">
                <asp:Label ID="lblPie" runat="server"></asp:Label>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
