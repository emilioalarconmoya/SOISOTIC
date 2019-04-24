<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_otec.aspx.vb" Inherits="modulo_administracion_mantenedor_otec" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor Otec</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
    <div>
        <div id="contenedor">
            <div id="bannner">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="menu">
                <div id="header">
                    <ul>
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
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_usuario_perfil.aspx"><b>Datos</b></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_otec_m.aspx?nuevo=si"><b>Mantenedor</b></asp:HyperLink>
                    </li>
                </ul>
            </div>
            <fieldset id="mantenedor">
                <div id="filtrosMantenedor">
                    <table id="tablaFiltro" cellpadding="0" cellspacing="0" class="TablaInterior" width="90%">
                        <tr>
                            <th colspan="6">
                                <asp:Label ID="Label6" runat="server" Text="Buscador de Otec"></asp:Label></th>
                        </tr>
                        <tr>
                            <td class="AlineacionCentro" colspan="6" style="height: 25px">
                                <asp:Label ID="Label7" runat="server" Text="Rut Otec :"></asp:Label>
                                <asp:TextBox ID="txtRutOtec" runat="server" Width="9%"></asp:TextBox>
                                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
                                <asp:Label ID="Label8" runat="server" Text="Razon Social :"></asp:Label>
                                <asp:TextBox ID="txtRazonSocial" runat="server" Width="232px"></asp:TextBox>
                                &nbsp; &nbsp; &nbsp;
                                <asp:Label ID="lblNomFantasia" runat="server" Text="Nombre Fantasia"></asp:Label>
                                <asp:TextBox ID="txtNomFantasia" runat="server" Width="256px"></asp:TextBox></td>
                        </tr>
                    </table>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" Height="1px" Width="157px" />
                    <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" /><br />
                    <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink>
                    <br />
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                    <br />
                </div>
                <hr />
                <div id="listado">
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                        Height="0px" Width="90%">
                        <Columns>
                            <asp:TemplateField HeaderText="Rut Otec">
                                <ItemTemplate>
                                    <asp:Label ID="lblRutOtec" runat="server" Text='<%# Bind("RutOtec") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre Fantasia">
                                <ItemTemplate>
                                    &nbsp;<asp:Label ID="lblNombreFantasia" runat="server" Text='<%# Bind("nom_fantasia") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left"  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Razon Social">
                                <ItemTemplate>
                                    <asp:Label ID="lblRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contacto">
                                <ItemTemplate>
                                    <asp:Label ID="lblContacto" runat="server" Text='<%# Bind("nombre_contacto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cargo contacto">
                                <ItemTemplate>
                                    <asp:Label ID="lblCargoContacto" runat="server" Text='<%# Bind("cargo_contacto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" Width="60%" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar"
                                        Width="60%" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
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
