<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_usuario_perfil_m.aspx.vb" Inherits="modulo_administracion_mantenedor_usuario_perfil_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
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
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_usuario_perfil.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <%--<li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="mantenedor_supervisor_ejecutivos.aspx"><b>Datos</b></asp:HyperLink>
                </li>--%>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_usuario_perfil_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table class="TablaMantenedor" width="90%" cellpadding="0" cellspacing="0" id="tablaFiltro">
                    <tr>
                        <th style="width: 10%" class="AlineacionIzquierda" colspan="6">
                            <asp:Label ID="Label1" runat="server" Text="Ingreso de nuevo usuario"></asp:Label></th>
                    </tr>
                    <tr>
                        <td style="width: 10%" class="AlineacionIzquierda">
                            <asp:Label ID="Label2" runat="server" Text="Rut"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 40%" class="AlineacionIzquierda">
                            <asp:TextBox ID="txtRut" runat="server" MaxLength="12"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRut" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRut"
                                ErrorMessage="Ingrese rut" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                        <td style="width: 10%" class="AlineacionIzquierda">
                            <asp:Label ID="Label10" runat="server" Text="Teléfono"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 40%" class="AlineacionIzquierda">
                            <asp:TextBox ID="txtTelefono" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 10%" class="AlineacionIzquierda">
                            <asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 40%" class="AlineacionIzquierda">
                            <asp:TextBox ID="txtNombres" runat="server" Width="70%" ValidationGroup="xx" MaxLength="64"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombres"
                                ErrorMessage="Ingrese nombres" ValidationGroup="xx">*</asp:RequiredFieldValidator></td>
                        <td style="width: 10%" class="AlineacionIzquierda">
                            <asp:Label ID="Label11" runat="server" Text="Fax"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 40%" class="AlineacionIzquierda">
                            <asp:TextBox ID="txtFax" runat="server" MaxLength="20"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 10%; height: 23px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label4" runat="server" Text="Clave"></asp:Label></td>
                        <td style="width: 1%; height: 23px;">
                            :</td>
                        <td class="AlineacionIzquierda" colspan="4" style="height: 23px">
                            <asp:TextBox ID="txtPassw" runat="server" EnableViewState="False" TextMode="Password" MaxLength="20"></asp:TextBox>&nbsp;
                            <asp:Label ID="Label6" runat="server" Text="Repetir clave  :"></asp:Label>
                            <asp:TextBox ID="txtPasswRepite" runat="server" EnableViewState="False" TextMode="Password" MaxLength="20"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 10%" class="AlineacionIzquierda">
                            <asp:Label ID="Label5" runat="server" Text="E-mail"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td class="AlineacionIzquierda" colspan="4">
                            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="xx" Width="30%" MaxLength="128"></asp:TextBox></td>
                    </tr>
                </table>
                <br />
                 <table class="TablaMantenedor" cellpadding="0" cellspacing="0" id="tablaList">
                    <tr>
                        <td>
                    <asp:Label ID="lblPerfilesDisponibles" runat="server" Font-Bold="True" Style="position: static" Text="Perfiles Disponibles" ></asp:Label></td>
                        <td style="width: 100px">
                        </td>
                        <td>
                    <asp:Label ID="lblPerfilesAsignados" runat="server" Font-Bold="True" Style="position: static" Text="Perfiles Asignados" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                    <asp:ListBox ID="lbxDisponibles" runat="server" Height="80px" Style="position: static"
                        Width="250px" ></asp:ListBox></td>
                        <td style="width: 100px" align="center">
                    <asp:Button ID="btnVa" runat="server" Style="position: static" Text=">" Width="42px" /><br />
                    <asp:Button ID="btnVaall" runat="server" Style="position: static" Text=">>" Width="42px"  /><br />
                    <asp:Button ID="btnViene" runat="server" Style="position: static" Text="<" Width="42px"  /><br />
                    <asp:Button ID="btnVieneall" runat="server" Style="position: static" Text="<<" Width="42px"  /></td>
                        <td style="width: 100px">
                    <asp:ListBox ID="lbxAsignados" runat="server" Height="80px" Style="position: static"
                        Width="250px"></asp:ListBox></td>
                    </tr>
                </table>
                <br />
                <table id="tablaFiltro" runat="server" cellpadding="0" cellspacing="0" visible="false" class="TablaMantenedor">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Style="position: static" Text="Ejecutivos Disponibles"></asp:Label></td>
                        <td style="width: 100px">
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Style="position: static" Text="Ejecutivos Asignados"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:ListBox ID="lbxEjecDisponibles" runat="server" Height="80px" Style="position: static"
                        Width="250px" ></asp:ListBox></td>
                        <td style="width: 100px" align="center">
                            <asp:Button ID="btnVaEjec" runat="server" Style="position: static" Text=">" Width="42px" /><br />
                            <asp:Button ID="btnVaallEjec" runat="server" Style="position: static" Text=">>" Width="42px"  /><br />
                            <asp:Button ID="btnVieneEjec" runat="server" Style="position: static" Text="<" Width="42px"  /><br />
                            <asp:Button ID="btnVieneallEjec" runat="server" Style="position: static" Text="<<" Width="42px"  /></td>
                        <td style="width: 100px">
                            <asp:ListBox ID="lbxEjecAsignados" runat="server" Height="80px" Style="position: static"
                        Width="250px"></asp:ListBox></td>
                    </tr>
                </table>
                <br />
                <table style="width: 312px" id="tablaSucursal" runat="server" cellpadding="0" cellspacing="0" class="TablaMantenedor" visible="false" >
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 10%; height: 25px;">
                            <asp:Label ID="Label9" runat="server" Text="Ingreso de sucursal"></asp:Label></td>
                    </tr>
                    <tr>
                        <%--<td align="right" colspan="2" style="width: 72px; height: 12px;">
                            &nbsp;<asp:Label ID="lblCodigo" runat="server" meta:resourcekey="lblCodigoResource1"
                                Text="Código :"></asp:Label></td>
                        <td align="left" style="width: 92px; height: 12px;">
                            <asp:TextBox ID="txtCodigo" runat="server" meta:resourcekey="txtCodigoResource1"
                                ValidationGroup="Guardar" Width="60px"></asp:TextBox><br />
                            <asp:DropDownList ID="ddlCodSucursal" runat="server">
                            </asp:DropDownList></td>--%>
                        <td align="right" style="width: 26px; height: 12px;">
                            <asp:Label ID="lblSucursal" runat="server" meta:resourcekey="lblNombreResource1"
                                Text="Sucursal :"></asp:Label></td>
                        <td align="left" colspan="2" style="width: 92px; height: 12px;">
                            <%--<asp:TextBox ID="txtNombreSucursal" runat="server" MaxLength="50" meta:resourcekey="txtNombreResource1"
                                ValidationGroup="Guardar"></asp:TextBox><br />--%>
                            <asp:DropDownList ID="ddlNomSucursal" runat="server">
                            </asp:DropDownList>&nbsp;</td>
                    </tr>
                </table>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="xx" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
                <br />
                <br />
                <br />
                <br />
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
