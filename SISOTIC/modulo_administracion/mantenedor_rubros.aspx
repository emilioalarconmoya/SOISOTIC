<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_rubros.aspx.vb" Inherits="modulo_administracion_mantenedor_rubros" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor</title>
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_rubros.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_rubros_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table id="tablaFiltro" cellpadding="0" cellspacing="0" class="TablaInterior" width="90%">
                    <tr>
                        <th colspan="6">
                            <asp:Label ID="Label6" runat="server" Text="Buscador de rubro"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionCentro" colspan="6" style="height: 25px">
                            <asp:Label ID="Label7" runat="server" Text="Código rubro :"></asp:Label>
                            <asp:TextBox ID="txtCodRubro" runat="server" Width="5%"></asp:TextBox>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="txtCodRubro" ErrorMessage="Ingrese un número entero" ValidationExpression="\d+"
                                ValidationGroup="xx">*</asp:RegularExpressionValidator>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Label ID="Label8" runat="server" Text="Nombre rubro :"></asp:Label>
                            <asp:TextBox ID="txtNombreRubro" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
                <br />
            </div>
            <hr />          
            <div id="listado">
                <asp:GridView ID="grdResultados" runat="server" Width="70%" AutoGenerateColumns="False" CssClass="Grid" Height="0px">
                    <Columns>
                        <asp:TemplateField HeaderText="C&#243;digo">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblCodRubro" runat="server" Text='<%# Bind("cod_rubro") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rubro">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblNombreRubro" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="40%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar"
                                    Width="60%" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar"
                                    Width="60%" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <br />
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
