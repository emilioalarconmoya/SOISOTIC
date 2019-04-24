<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_empresas_m.aspx.vb" Inherits="modulo_administracion_mantenedor_empresas_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  

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
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_empresas.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_empresas_m.aspx"><b>Mantenedor</b></asp:HyperLink>
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
                            <th colspan="3" style="width: 25%" class="AlineacionIzquierda">
                                <asp:Label ID="Label31" runat="server" Text="Datos principales"></asp:Label>
                            </th>
                            </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label32" runat="server" Text="* RUT"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtRutEmpresa" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRutEmpresa"
                                            ErrorMessage="debe ingresar rut" ValidationGroup="xx">*</asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRutEmpresa" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label33" runat="server" Text="* Razón social"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtRazonSocial" runat="server" Width="70%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRazonSocial"
                                            ErrorMessage="debe ingresar razon social" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%; height: 27px;" class="AlineacionIzquierda">
                                        <asp:Label ID="Label34" runat="server" Text="* Nombre fantasía"></asp:Label></td>
                                    <td style="width: 1%; height: 27px;">
                                        :</td>
                                    <td style="width: 74%; height: 27px;" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtNomFantasia" runat="server" Width="70%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNomFantasia"
                                            ErrorMessage="debe ingresar nombre fantasia" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%; height: 25px;" class="AlineacionIzquierda">
                                        <asp:Label ID="Label35" runat="server" Text="* Sigla"></asp:Label></td>
                                    <td style="width: 1%; height: 25px;">
                                        :</td>
                                    <td style="width: 74%; height: 25px;" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtSigla" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSigla"
                                            ErrorMessage="debe ingresar sigla" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label36" runat="server" Text="RUT Holding"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtRutHolding" runat="server"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRutHolding" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator></td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <th colspan="3" style="width: 25%" class="AlineacionIzquierda">
                                        &nbsp;<asp:Label ID="Label15" runat="server" Text="Direccion"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label16" runat="server" Text="* Dirección"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtDireccion" runat="server" Width="60%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDireccion"
                                            ErrorMessage="debe ingresar direccion" ValidationGroup="xx">*</asp:RequiredFieldValidator>
                                        <asp:Label ID="Label3" runat="server" Text="Número:"></asp:Label>
                                        <asp:TextBox ID="txtNumDireccion" runat="server" Width="15%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label17" runat="server" Text="* Ciudad"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCiudad"
                                            ErrorMessage="debe ingresar ciudad" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label23" runat="server" Text="Comuna"></asp:Label></td>
                                    <td style="width: 1%; height: 25px;">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:DropDownList ID="ddlComunas" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label24" runat="server" Text="Sitio Web"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtSitiosWeb" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label18" runat="server" Text="* Teléfono 1"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtTelefono1" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTelefono1"
                                            ErrorMessage="debe ingresar telefono" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 25%">
                                        <asp:Label ID="Label1" runat="server" Text="Teléfono 2"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 74%">
                                        <asp:TextBox ID="txtTelefono2" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 25%">
                                        <asp:Label ID="Label19" runat="server" Text="Fax"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 74%">
                                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 25%">
                                        <asp:Label ID="Label20" runat="server" Text="* Email"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 74%">
                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="debe ingresar email" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 25%">
                                        <asp:Label ID="Label21" runat="server" Text="Casilla"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 74%">
                                        <asp:TextBox ID="txtCasilla" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 25%">
                                        <asp:Label ID="Label26" runat="server" Text="Sucursal"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 74%">
                                        <asp:DropDownList ID="ddlSucursal" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 25%">
                                        <asp:Label ID="Label27" runat="server" Text="Ejecutivo"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 74%">
                                        <asp:DropDownList ID="ddlEjecutivo" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <th colspan="3" style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label28" runat="server" Text="Datos Franquicia Tributaria"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label29" runat="server" Text="Nº Empleados"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtEmpleados" runat="server" Width="56px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label30" runat="server" Text="* Tasa administración"></asp:Label></td>
                                    <td style="width: 1%; height: 25px;">
                                        :</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtTasaAdministracion" runat="server" Width="56px"></asp:TextBox>%
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTasaAdministracion"
                                            ErrorMessage="debe ingresar tasa administracion" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                                </tr>
                            </table><table cellpadding="0" cellspacing="0" class="TablaInterior" id="TablaFranquiciaAnual" runat="server" width="100%" visible="false">
                                <tr>
                                    <td style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label50" runat="server" Text="Franquicia anual"></asp:Label></td>
                                    <td style="width: 1%; height: 25px">:</td>
                                    <td style="width: 74%" class="AlineacionIzquierda">
                                        <asp:Label ID="lblFranquiciaAnual" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 25%">
                                    </td>
                                    <td style="width: 1%; height: 25px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 74%">
                                        <asp:Button ID="btnFranquicia" runat="server" Text="Ver franquicia" /></td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%" id="TablaObservacion" runat="server" visible="false" >
                                <tr>
                                    <th colspan="3" style="width: 25%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label56" runat="server" Text="Observación de cambios efectuados"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td style="height: 15px;" class="AlineacionIzquierda" colspan="3">
                                        <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" style="width: 50%"><table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
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
                                <td style="width: 30%" class="AlineacionIzquierda">
                                    <asp:Label ID="Label13" runat="server" Text="Nombre"></asp:Label></td>
                                <td style="width: 1%">
                                    :</td>
                                <td style="width: 69%" class="AlineacionIzquierda">
                                    <asp:TextBox ID="txtNombreContacto" runat="server" Width="80%" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNombreContacto"
                                        ErrorMessage="debe ingresar nombre contacto" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 30%">
                                    <asp:Label ID="Label11" runat="server" Text="Apellido"></asp:Label></td>
                                <td style="width: 1%">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 69%">
                                    <asp:TextBox ID="txtApeContactoPrincipal" runat="server" MaxLength="100" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtApeContactoPrincipal"
                                        ErrorMessage="debe ingresar apellido contacto" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%" class="AlineacionIzquierda">
                                    <asp:Label ID="Label8" runat="server" Text="Cargo"></asp:Label></td>
                                <td style="width: 1%">
                                    :</td>
                                <td style="width: 69%" class="AlineacionIzquierda">
                                    <asp:TextBox ID="txtCargoContacto" runat="server" Width="70%" MaxLength="100"></asp:TextBox></td>
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
                        </table>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <th colspan="3" style="width: 30%" class="AlineacionIzquierda">
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="Representantes legales"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label6" runat="server" Text="Representante 1"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtRepresentante1" runat="server" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label7" runat="server" Text="RUT 1"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtRut1" runat="server"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRut1" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label22" runat="server" Text="Representante 2"></asp:Label></td>
                                    <td style="width: 1%; height: 25px;">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtRepresentante2" runat="server" Width="249px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label37" runat="server" Text="RUT 2"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtRut2" runat="server"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRut2" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 30%">
                                    <asp:Label ID="Label12" runat="server" Text="Gerente cobranzas"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 69%">
                                    <asp:TextBox ID="txtGerCobranzas" runat="server" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 30%">
                                    <asp:Label ID="Label14" runat="server" Text="Fono gerente cobranzas"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 69%">
                                    <asp:TextBox ID="txtFonoGerente" runat="server"></asp:TextBox></td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <th colspan="3" style="width: 30%" class="AlineacionIzquierda">
                                        &nbsp;<asp:Label ID="Label25" runat="server" Text="Otros contactos"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label38" runat="server" Text="Gerente general"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtGerGeneral" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label39" runat="server" Text="Gerente RRHH"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtGerRRHH" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label40" runat="server" Text="Email gerente RRHH"></asp:Label></td>
                                    <td style="width: 1%; height: 25px;">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtEmailGerRRHH" runat="server"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label41" runat="server" Text="Gerente finanzas"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtGerFinanzas" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 30%">
                                        <asp:Label ID="Label42" runat="server" Text="Email gerente finanzas"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 69%">
                                        <asp:TextBox ID="txtEmailGerFinanzas" runat="server"></asp:TextBox>
                                        </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <th colspan="3" style="width: 30%" class="AlineacionIzquierda">
                                        &nbsp;<asp:Label ID="Label43" runat="server" Text="Actividad"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label44" runat="server" Text="Giro"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtGiro" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label45" runat="server" Text="Cod. Act. Economica"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtActEconomica" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label46" runat="server" Text="Rubro interno"></asp:Label></td>
                                    <td style="width: 1%; height: 25px;">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:DropDownList ID="ddlRubroInterno" runat="server">
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label47" runat="server" Text="Admin. No lineal"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:DropDownList ID="ddlAdminNoLineal" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 30%">
                                        <asp:Label ID="Label48" runat="server" Text="Estado empresa"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 69%">
                                        <asp:DropDownList ID="ddlEstadoEmpresa" runat="server">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 30%">
                                        <asp:Label ID="Label49" runat="server" Text="Valor venta anual (UF)"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 69%">
                                        <asp:DropDownList ID="ddlValorVentaAnual" runat="server">
                                            <asp:ListItem Value="0">MICRO   0     -   2400</asp:ListItem>
                                            <asp:ListItem Value="1">PEQUE&#209;A 24001 -  25000</asp:ListItem>
                                            <asp:ListItem Value="2">MEDIA   25001 - 100000</asp:ListItem>
                                            <asp:ListItem Value="3">GRANDE 100001 - y m&#225;s</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%" runat="server" visible="false" >
                                <tr>
                                    <th colspan="3" style="width: 30%" class="AlineacionIzquierda">
                                        &nbsp;<asp:Label ID="Label54" runat="server" Text="Contacto principal"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label51" runat="server" Text="Clave Web Service: "></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtClaveWeb" runat="server" TextMode="Password"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="AlineacionIzquierda">
                                        <asp:Label ID="Label52" runat="server" Text="Etiqueta de clasificación de participantes"></asp:Label></td>
                                    <td style="width: 1%">
                                        :</td>
                                    <td style="width: 69%" class="AlineacionIzquierda">
                                        <asp:TextBox ID="txtEtiquetaClasif" runat="server"></asp:TextBox></td>
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
