<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carga_web_service.aspx.vb" Inherits="modulo_cursos_carga_web_service" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Carga Web Service</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div>
        <div id="contenedor" align="center">
            <div id="bannner" align="center">
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
                <li  class="pestanaconsolaseleccionada">
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
            <div id="resultadoCarga">
                <table>
                    <tr>
                        <td class="tabla1">
                            <div align="center">
                                <br />
                                <div style="width: 952px">
                                    <div align="left">
                                        &nbsp; &nbsp;
                                    </div>
                                    <div align="left">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    </div>
                                    <div align="left">
                                        <asp:Label ID="lblXML" runat="server" CssClass="titDato" Text="XML Curso"></asp:Label>
                                        <asp:Label ID="lblDosPuntos3" runat="server" CssClass="dosPuntos" Text=":"></asp:Label>
                                        &nbsp; &nbsp;
                                        <asp:FileUpload ID="fulXML" runat="server" CssClass="cargaDato" />
                                        <asp:Button ID="btnCargar" runat="server" CssClass="ND_Botones" Text="Cargar curso"
                                            ValidationGroup="validarRut" />&nbsp;<asp:Button ID="btnVolver" runat="server" Text="Volver" />
                                    </div>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                                        ValidationGroup="validarRut" Width="193" />
                                    <div>
                                        <asp:Label ID="lblResultado" runat="server" CssClass="titResultado" Text="Resultado"></asp:Label>
                                        <%--<asp:TextBox ID="txtResultado" runat="server" CssClass="datoResultado" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>--%>
                                        <asp:Literal ID="lit" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <p>
                                    &nbsp;</p>
                            </div>
                        </td>
                    </tr>
                </table>
                <%--<div id="contenedor">
        <h1>Carga de cursos</h1>
        <div id="contenido">
            
            </div>
        </div>--%>
            </div>
        </div>
        <div id="pie">
            <div class="textoPie">
                <asp:Label ID="lblPie" runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
