<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cambio_estado_masivo.aspx.vb" Inherits="modulo_cursos_cambio_estado_masivo" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Cambio de estado de cursos</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
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
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
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
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>
    </div>
    <div id="Grafico">
     <table id="tablaDatosAlumno">
                        <tr>
                            <th width="980px" valign="top" class="TituloGrupo">
                                <asp:Label ID="lblTipo" runat="server"></asp:Label>&nbsp;
                            </th>                         
                        </tr>
                     </table>
        <asp:GridView ID="grdCursos" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Correlativo">
                    <ItemTemplate>
                        <asp:Label ID="lblCorrelativo" runat="server" Font-Bold="True" Text='<%# Bind("correlativo") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="0px" VerticalAlign="Top" Width="6%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre curso">
                    <ItemTemplate>
                        <asp:Label ID="lblNombreCurso" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="0px" HorizontalAlign="Left" VerticalAlign="Top" Width="33%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Direcci&#243;n">
                    <ItemTemplate>
                        <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="0px" HorizontalAlign="Left" VerticalAlign="Top" Width="33%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha inicio ">
                    <ItemTemplate>
                        <asp:Label ID="lblFechaInicio" runat="server" Text='<%# Bind("fecha_inicio") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="0px" VerticalAlign="Top" Width="14%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha t&#233;rmino ">
                    <ItemTemplate>
                        <asp:Label ID="lblFechaTermino" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="0px" VerticalAlign="Top" Width="14%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table id="TablaCambioEstado" runat="server" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <th colspan="4">
                cambio de estado</th>
            </tr>
            <tr>
                <td class="AlineacionDerecha" style="width: 10%" valign="top">
                    <asp:Label ID="Label7" runat="server" Text="Fecha actual:" Font-Bold="False"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 10%" valign="top">
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="False"></asp:Label></td>
                <td style="width: 40%" valign="top" class="AlineacionDerecha">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Ingrese glosa asociada al cambio de estado:"></asp:Label></td>
                <td style="width: 40%">
                    <asp:TextBox ID="txtGlosa" runat="server" Height="50px" Width="200px"></asp:TextBox></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%" id="TablaMensaje" runat="server" visible="false" >
            <tr>
                <td style="width: 100%;">
                    *Los cursos detallados en el listado están
                    <asp:Label ID="lblResultado" runat="server"></asp:Label>.</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" Visible="False" />&nbsp;<asp:Button
            ID="btnRechazar" runat="server" Text="Rechazar" Visible="False" />
        <asp:Button ID="btnComunicar" runat="server" Text="En comunicación" Visible="False" />
        <asp:Button ID="btnLiquidar" runat="server" Text="En liquidación" Visible="False" /><br />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" Visible="False" /><br />
        <br />
        <br />
    </div>
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
