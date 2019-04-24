<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_otec_m.aspx.vb" Inherits="modulo_administracion_mantenedor_otec_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor Otec</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
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
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_otec.aspx"><b>Datos</b></asp:HyperLink>
                    </li>
                    <li class="PestañasMantenedorseleccionada">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_usuario_perfil_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                    </li>
                </ul>
            </div>
            <fieldset id="mantenedor">
                <div id="filtrosMantenedor">
                    <table id="TablaMantenedor" width="90%">
                        <%--<tr>
                            <th colspan="2" style="height: 29px">
                                <asp:Label ID="Label3" runat="server" Text="Otec"></asp:Label></th>
                        </tr>--%>
                        <tr>
                            <td style="height: 562px">
                                <table id="TablaNuevoPerfil" runat="server" cellpadding="0" cellspacing="0" class="Grid"
                                    width="100%">
                                    <tr>
                                        <th colspan="2">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Datos Principales" Width="176px"></asp:Label></th>
                                        <th colspan="2">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Contacto Principal"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 4px; text-align: left;">
                                            <asp:Label ID="lblRut" runat="server" Text="Rut:"></asp:Label></td>
                                        <td style="width: 20%; height: 4px; text-align: left;">
                                            <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRut"
                                                ErrorMessage="debe ingresar rut" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                        <td style="width: 9%; height: 4px; text-align: left;">
                                            <asp:Label ID="lblNombreContacto" runat="server" Text="Nombre:"></asp:Label></td>
                                        <td style="width: 15%; height: 4px; text-align: left;">
                                            <asp:TextBox ID="txtNombreContacto" runat="server" Height="16px" Width="224px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 18px; text-align: left;">
                                            <asp:Label ID="lblRazonSocial" runat="server" Text="Razon social:"></asp:Label></td>
                                        <td style="width: 20%; height: 18px; text-align: left;">
                                            <asp:TextBox ID="txtRazonSocial" runat="server" Width="264px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRazonSocial"
                                                ErrorMessage="debe ingresar un nombre" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                        <td style="width: 9%; height: 18px; text-align: left;">
                                            <asp:Label ID="lblCargoContacto" runat="server" Text="Cargo contacto:"></asp:Label></td>
                                        <td style="width: 15%; height: 18px; text-align: left;">
                                            <asp:TextBox ID="txtCargoContacto" runat="server" Width="224px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblNomFantasia" runat="server" Text="Nombre Fantasia:"></asp:Label></td>
                                        <td style="width: 20%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtNombreFantasia" runat="server" Width="264px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreFantasia"
                                                ErrorMessage="debe ingresar un nombre" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                        <td style="width: 9%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblFonoContacto" runat="server" Text="Fono/Anexo:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtFonoContacto" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblSigla" runat="server" Text="Sigla:"></asp:Label></td>
                                        <td style="width: 20%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtSigla" runat="server" Width="208px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSigla"
                                                ErrorMessage="debe ingresar un nombre" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                        <td style="width: 9%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblEmailContacto" runat="server" Text="Email:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtEmailContacto" runat="server" Width="232px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <th colspan="2">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Dirección"></asp:Label></th>
                                        <th colspan="2">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Representante Legal"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 12px; text-align: left;">
                                            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label></td>
                                        <td style="width: 20%; height: 12px; text-align: left;">
                                            <asp:TextBox ID="txtDireccion" runat="server"
                                                Width="136px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDireccion"
                                                ErrorMessage="debe ingresar direccion" ValidationGroup="xx">*</asp:RequiredFieldValidator>
                                            <asp:Label ID="Label3" runat="server" Text="Nro.:"></asp:Label>
                                            <asp:TextBox ID="txtNroDireccion" runat="server" Width="48px"></asp:TextBox></td>
                                        <td style="width: 9%; height: 12px; text-align: left;">
                                            <asp:Label ID="lblNomRep1" runat="server" Text="Nombrerepresentante 1:"></asp:Label></td>
                                        <td style="width: 15%; height: 12px; text-align: left;">
                                            <asp:TextBox ID="txtNomRep1" runat="server" Height="16px" Width="232px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 16px; text-align: left;">
                                            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
                                        </td>
                                        <td style="width: 20%; height: 16px; text-align: left;">
                                            <asp:TextBox ID="txtCiudad" runat="server" Width="208px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCiudad"
                                                ErrorMessage="debe ingresar una ciudad" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                        <td style="width: 9%; height: 16px; text-align: left;">
                                            <asp:Label ID="lblRutRep1" runat="server" Text="Rut representante 1:"></asp:Label></td>
                                        <td style="width: 15%; height: 16px; text-align: left;">
                                            <asp:TextBox ID="txtRutRep1" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblComuna" runat="server" Text="Comuna:"></asp:Label></td>
                                        <td style="width: 20%; height: 22px; text-align: left;">
                                            <asp:DropDownList ID="ddlComuna" runat="server" Width="216px">
                                            </asp:DropDownList></td>
                                        <td style="width: 9%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblNomRep2" runat="server" Text="Nombre representante 2:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtNomRep2" runat="server" Height="16px" Width="232px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblRegion" runat="server" Text="Región:"></asp:Label>
                                        </td>
                                        <td style="width: 20%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtRegion" runat="server" Width="264px"></asp:TextBox></td>
                                        <td style="width: 9%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblRutRep2" runat="server" Text="Rut representante 2:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtRutRep2" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 19px; text-align: left;">
                                            <asp:Label ID="lblSitioWeb" runat="server" Text="Sitio Web:"></asp:Label></td>
                                        <td style="width: 20%; height: 19px; text-align: left;">
                                            <asp:TextBox ID="txtDireccionWeb" runat="server" Width="264px"></asp:TextBox></td>
                                        <th colspan="2">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Otros Contactos"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono 1:"></asp:Label>
                                        </td>
                                        <td style="width: 20%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtTelefono1" runat="server" Width="80px"></asp:TextBox>
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                            <asp:Label ID="lblTelefono2" runat="server" Text="Teléfono 2"></asp:Label>
                                            <asp:TextBox ID="txtTelefono2" runat="server" Width="88px"></asp:TextBox>
                                            </td>
                                        <td style="width: 9%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblGerenteGeneral" runat="server" Text="Gerente general:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtGerenteGeneral" runat="server" Width="232px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblFax" runat="server" Text="Fax:"></asp:Label></td>
                                        <td style="width: 20%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox></td>
                                        <td style="width: 9%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblGerenteRRHH" runat="server" Text="Gerente RRHH:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtGerenteRrhh" runat="server" Width="232px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label></td>
                                        <td style="width: 20%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtEmail" runat="server" Width="264px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="debe ingresar mail" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                        <td style="width: 9%; height: 22px; text-align: left;">
                                            <asp:Label ID="lblGerenteCobranza" runat="server" Text="Gerente cobranzas:" Width="88px"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left;">
                                            <asp:TextBox ID="txtGerenteCobranza" runat="server" Width="232px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7%; height: 19px; text-align: left;">
                                            <asp:Label ID="lblCasilla" runat="server" Text="Casilla:"></asp:Label></td>
                                        <td style="width: 20%; height: 19px; text-align: left;">
                                            <asp:TextBox ID="txtCasilla" runat="server" Width="264px"></asp:TextBox></td>
                                        <th colspan="2">
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Actividad"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td colspan="2" rowspan="5" style="text-align: left">
                                        </td>
                                        <td style="width: 9%; height: 22px; text-align: left">
                                            <asp:Label ID="lblGiro" runat="server" Text="Giro:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left">
                                            <asp:TextBox ID="txtGiro" runat="server" Width="232px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9%; height: 24px; text-align: left">
                                            <asp:Label ID="lblCodActivEconomica" runat="server" Text="Código act. economica:"></asp:Label></td>
                                        <td style="width: 15%; height: 24px; text-align: left">
                                            <asp:TextBox ID="txtCodActivEconomica" runat="server" Width="64px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9%; height: 22px; text-align: left">
                                            <asp:Label ID="txtRubro" runat="server" Text="Rubro:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left">
                                            <asp:DropDownList ID="ddlRubro" runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9%; height: 22px; text-align: left">
                                            <asp:Label ID="lblNumConvenio" runat="server" Text="Número de convenio:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left">
                                            <asp:TextBox ID="txtNumConvenio" runat="server" Width="64px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 9%; height: 22px; text-align: left">
                                            <asp:Label ID="lblTasaDescuento" runat="server" Text="Tasa de descuento:"></asp:Label></td>
                                        <td style="width: 15%; height: 22px; text-align: left">
                                            <asp:TextBox ID="txtTasaDescuento" runat="server" Width="40px"></asp:TextBox>&nbsp;
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTasaDescuento"
                                                ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+" ValidationGroup="xx">*</asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTasaDescuento"
                                                ErrorMessage="debe ingresar un valor" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;<asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="xx" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
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
