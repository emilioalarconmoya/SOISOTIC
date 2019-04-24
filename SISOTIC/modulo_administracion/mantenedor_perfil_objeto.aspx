<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_perfil_objeto.aspx.vb" Inherits="modulo_administracion_mantenedor_perfil_objeto" %>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_perfil_objeto.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_perfil_objeto_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table width="90%" id="TablaMantenedor">
                    <tr>
                        <th colspan="3">
                        <asp:Label ID="Label1" runat="server" Text="Buscador de perfil-objeto"></asp:Label></th>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="TablaDatosOtec" width="100%">
                                <tr>
                                    <td style="width: 15%; height: 23px;">
                            <asp:Label ID="Label2" runat="server" Text="Código perfil "></asp:Label></td>
                                    <td style="width: 1%; height: 23px;">
                                        :</td>
                                    <td style="width: 15%; height: 23px;">
                            <asp:TextBox ID="txtCodPerfil" runat="server" Width="50%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCodPerfil"
                                ErrorMessage="Ingrese un número entero" ValidationGroup="xx" ValidationExpression="\d+">*</asp:RegularExpressionValidator></td>
                                    <td style="width: 15%; height: 23px;">
                            <asp:Label ID="Label5" runat="server" Text="Nombre perfil "></asp:Label></td>
                                    <td style="width: 1%; height: 23px;">
                                        :</td>
                                    <td style="width: 45%; height: 23px;">
                            <asp:TextBox ID="txtNombrePerfil" runat="server" Width="80%"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="TablaDatosOtec">
                                <tr>
                                    <td style="width: 15%">
                            <asp:Label ID="Label3" runat="server" Text="Código objeto "></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 15%">
                            <asp:TextBox ID="txtCodObjeto" runat="server" Width="50%"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCodObjeto"
                                ErrorMessage="Ingrese un número entero" ValidationGroup="xx" ValidationExpression="\d+">*</asp:RegularExpressionValidator></td>
                                    <td style="width: 20%">
                            <asp:Label ID="Label4" runat="server" Text="Nombre objeto :"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 40%">
                            <asp:TextBox ID="txtNombreObjeto" runat="server" Width="80%"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />&nbsp;<asp:Button
                    ID="btnAgregar" runat="server" Text="Agregar" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
                <br />
            </div>
            <hr />          
            <div id="listado">
                <asp:GridView ID="grdResultados" runat="server" Width="90%" AutoGenerateColumns="False" CssClass="Grid" Height="0px">
                    <Columns>
                        <asp:TemplateField HeaderText="Perfil">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblCodPerfil" runat="server" Text='<%# Bind("cod_perfil") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripci&#243;n perfil">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblDescripcionPerfil" runat="server" Text='<%# Bind("nombre_perfil") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="35%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Objeto">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblCodObjeto" runat="server" Text='<%# Bind("cod_objeto") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripci&#243;n objeto">
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="lblDescripcionObjeto" runat="server" Text='<%# Bind("nombre_objeto") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="35%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar"
                                    Width="90%" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar"
                                    Width="90%" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
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
