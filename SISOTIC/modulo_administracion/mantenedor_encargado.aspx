<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_encargado.aspx.vb" Inherits="modulo_administracion_mantenedor_encargado" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor</title>
   <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera"/>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_encargado.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_encargado_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table class="TablaInterior" cellpadding="0" cellspacing="0" width="90%" id="tablaFiltro">
                    <tr>
                        <th colspan="6">
                        <asp:Label ID="Label1" runat="server" Text="Buscador de empresas"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionCentro" colspan="6" style="height: 25px">
                            &nbsp; &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="Rut encargado :"></asp:Label>
                            <asp:TextBox ID="txtRutEncargado" runat="server"></asp:TextBox>
                             <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRutEncargado" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                            <asp:Label ID="Label2" runat="server" Text="Rut empresa :"></asp:Label>
                            <asp:TextBox ID="txtRutEmpresa" runat="server"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRutEmpresa" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                            <asp:Button ID="btn_buscar_empresa" runat="server" Text="..." />
                            &nbsp; &nbsp;
                            &nbsp; &nbsp;
                            <asp:Label ID="Label4" runat="server" Text="Nombre encargado:"></asp:Label>
                            <asp:TextBox ID="txtNombreEncargado" runat="server"></asp:TextBox></td>
                    </tr>
                    </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" />
                <br />
                <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink><br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar nuevo" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
            </div>
            <hr />          
            <div id="listado">
                &nbsp;<asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False"
                    CssClass="Grid" Height="0px" Width="100%" EmptyDataText="La consulta no trae datos">
                    <Columns>
                        <asp:TemplateField HeaderText="Rut">
                            <ItemTemplate>
                                <asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut_encargado") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreFantasia" runat="server" Text='<%# Bind("nombre_encargado") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <ItemTemplate>
                                <asp:Label ID="lblRazonSocial" runat="server" Text='<%# Bind("apellido_encargado") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cargo">
                            <ItemTemplate>
                                <asp:Label ID="lblSigla" runat="server" Text='<%# Bind("cargo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tel&#233;fono">
                            <ItemTemplate>
                                <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("fono") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblDireccion" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Rut Emp">
                            <ItemTemplate>
                                <asp:Label ID="lblRutEmp" runat="server" Text='<%# Bind("rut_empresa") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar"
                                    Width="90%" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar"
                                    Width="90%" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                        </asp:TemplateField>--%>
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

