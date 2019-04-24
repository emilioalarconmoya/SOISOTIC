<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_cursos_sence.aspx.vb" Inherits="modulo_administracion_mantenedor_cursos_sence" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor</title>
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
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
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
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
        <div id="PestañasMantenedor">
            <ul>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_cursos_sence_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table id="tablaFiltro" cellpadding="0" cellspacing="0" class="TablaInterior" width="90%">
                    <tr>
                        <th colspan="6">
                            <asp:Label ID="Label6" runat="server" Text="Buscador de curso SENCE"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionCentro" colspan="6" style="height: 25px">
                            <asp:Label ID="Label7" runat="server" Text="Código SENCE :"></asp:Label>
                            <asp:TextBox ID="txtCodSence" runat="server" MaxLength="10"></asp:TextBox><asp:Button
                                ID="btnPopUpSence" runat="server" Text="..." />
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" Visible="False" />                
                <br />
            </div>
            <hr />          
            <div id="listado">
                <asp:GridView ID="grdResultados" runat="server" Width="90%" AutoGenerateColumns="False" CssClass="Grid" Height="0px">
                    <Columns>
                        <asp:TemplateField HeaderText="C&#243;digo SENCE">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblCodSence" runat="server" Text='<%# Bind("codigo_sence") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre curso">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblNombreCurso" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="40%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OTEC">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreOtec" runat="server" Text='<%# Bind("razon_social") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Horas">
                            <ItemTemplate>
                                <asp:Label ID="lblHoras" runat="server" Text='<%# Bind("horas") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar"
                                    Width="90%" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
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
