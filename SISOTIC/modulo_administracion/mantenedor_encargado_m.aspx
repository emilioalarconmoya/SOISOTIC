<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_encargado_m.aspx.vb" Inherits="modulo_administracion_mantenedor_encargado_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_encargado.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_encargado_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                &nbsp;<table border="0" cellpadding="0" cellspacing="0" style="width: 90%; height: 100%">
                    <tr>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                            <tr>
                                <th colspan="3" style="width: 30%" class="AlineacionIzquierda">
                                    &nbsp;<asp:Label ID="Label2" runat="server" Text="Contacto principal"></asp:Label></th>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 30%">
                                    <asp:Label ID="RUT" runat="server" Text="RUT"></asp:Label></td>
                                <td style="width: 1%">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 69%">
                                    <asp:TextBox ID="txtRutContacto" runat="server" MaxLength="12"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRutContacto"
                                        ErrorMessage="debe ingresar rut del contacto principal" ValidationGroup="xx">*</asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="VerificarRut"
                                        ControlToValidate="txtRutContacto" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%; height: 25px;" class="AlineacionIzquierda">
                                    <asp:Label ID="Label13" runat="server" Text="Nombre"></asp:Label></td>
                                <td style="width: 1%; height: 25px;">
                                    :</td>
                                <td style="width: 69%; height: 25px;" class="AlineacionIzquierda">
                                    <asp:TextBox ID="txtNombreContacto" runat="server" Width="34%" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNombreContacto"
                                        ErrorMessage="debe ingresar nombre contacto" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 30%">
                                    <asp:Label ID="Label11" runat="server" Text="Apellido"></asp:Label></td>
                                <td style="width: 1%">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 69%">
                                    <asp:TextBox ID="txtApeContactoPrincipal" runat="server" MaxLength="100" Width="34%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtApeContactoPrincipal"
                                        ErrorMessage="debe ingresar apellido contacto" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%" class="AlineacionIzquierda">
                                    <asp:Label ID="Label8" runat="server" Text="Cargo"></asp:Label></td>
                                <td style="width: 1%">
                                    :</td>
                                <td style="width: 69%" class="AlineacionIzquierda">
                                    <asp:TextBox ID="txtCargoContacto" runat="server" Width="51%" MaxLength="100"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 30%" class="AlineacionIzquierda">
                                    <asp:Label ID="Label10" runat="server" Text="Celular"></asp:Label></td>
                                <td style="width: 1%; height: 25px;">
                                    :</td>
                                <td style="width: 69%" class="AlineacionIzquierda">
                                    <asp:TextBox ID="txtFonoContacto" runat="server" MaxLength="8"></asp:TextBox>
                                    <asp:Label ID="Label4" runat="server" Text="Anexo:" Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtAnexoContacto" runat="server" Width="48px" Visible="False"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 30%" class="AlineacionIzquierda">
                                    <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label></td>
                                <td style="width: 1%">
                                    :</td>
                                <td style="width: 69%" class="AlineacionIzquierda">
                                    <asp:TextBox ID="txtEmailContacto" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                            </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 30%">
                                        <asp:Label ID="Label3" runat="server" Text="Rut EMPRESA:"></asp:Label>
                                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 69%">
                                        <asp:TextBox ID="txtRutEmpresa" runat="server"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRutEmpresa" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                                          <asp:Button ID="btn_buscar_empresa" runat="server" Text="..." /></td>
                                </tr>
                        </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="Label53" runat="server" Text="(*) Campos Obligatorios "></asp:Label>&nbsp;<br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="xx" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
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
