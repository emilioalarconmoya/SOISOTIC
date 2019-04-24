<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor.aspx.vb" Inherits="modulo_administracion_mantenedor" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mantenedor</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
<uc3:cabeceraUsuario ID="datos_personales1" runat="server" />        
    </div>
    <div id="menu">
        <div id="header">
            <ul>
                <%--<li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="#"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="../modulo_cursos/reporte_cursos.aspx"><b>Reporte cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="#"><b>Buscar curso</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="#"><b>Carga de cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="../modulo_cursos/pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="#"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="../modulo_cursos/mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl="#"><b>Curso no Sence</b></asp:HyperLink>
                </li>--%>
                <li >
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx"><b>Menú Administración</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        <div id="PestañasMantenedor">
            <ul>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_m.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar nuevo" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
            </div>
            <hr />          
            <div id="listado">
                <asp:GridView ID="grdResultados" runat="server" Width="90%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEliminar" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>       
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>


