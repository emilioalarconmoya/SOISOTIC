<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_usuario_sucursal_m.aspx.vb" Inherits="modulo_administracion_mantenedor_usuario_sucursal_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mantenedor usuario-sucursal</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
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
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_usuario_sucursal.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="mantenedor_usuario_sucursal_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div> 
    <%--<table style="width: 400px; border-color:#000000;" align="center">
            <tr>
                <td style="width: 200px" class="pestana_down">
                    <asp:HyperLink ID="hplDatos" runat="server" meta:resourcekey="hplDatosResource1"
                        NavigateUrl="~/modulo_administracion/mantenedor_sucursales.aspx" Width="160px">Datos</asp:HyperLink>
                </td>
                <td style="width: 200px" class="pestana_up">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblMantenedorResource1" Text="Mantenedor"
                            Width="160px"></asp:Label></td>
            </tr>
        </table>--%>
        <br />
        <table style="width: 488px" id="tablaSucursal" runat="server" cellpadding="0" cellspacing="0" class="TablaMantenedor" visible="true" >
                    <tr>
                        <th class="AlineacionIzquierda" colspan="6" style="width: 10%; height: 25px;">
                            <asp:Label ID="Label9" runat="server" Text="Ingreso de usuario-sucursal"></asp:Label></th>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="width: 72px; height: 12px;">
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="Director :"></asp:Label></td>
                        <td align="left" style="width: 92px; height: 12px;">
                            <asp:DropDownList ID="ddlDirector" runat="server">
                            </asp:DropDownList></td>
                        <td align="right" style="width: 26px; height: 12px;">
                            <asp:Label ID="lblSucursal" runat="server" meta:resourcekey="lblNombreResource1"
                                Text="Sucursal :"></asp:Label></td>
                        <td align="left" colspan="2" style="width: 92px; height: 12px;">
                            <asp:DropDownList ID="ddlNomSucursal" runat="server">
                            </asp:DropDownList>&nbsp;</td>
                    </tr>
                </table>
        <table id="TABLE1" style="width: 980px" align="center" class="tabla">
            <tr>
                <td align="center" style="width: 100%; height: 395px;" valign="top">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ValidationGroup="Guardar" meta:resourcekey="ValidationSummary1Resource1" />
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Guardar" meta:resourcekey="btnGuardarResource1" /><br />
                    <asp:HiddenField ID="hdfMenuCabecera" runat="server" meta:resourcekey="hdfMenuCabeceraResource1" Value="Mantenedor de Atributos" />
                    <asp:HiddenField ID="hdfConfirmacionGuardar" runat="server" meta:resourcekey="hdfConfirmacionGuardarResource1" Value="¿Está seguro de guardar los cambios?" />
                    <asp:HiddenField ID="hdfInsertarExito" runat="server" meta:resourcekey="hdfInsertarExitoResource1" Value="¡Los datos fueron ingresados exitosamente!" />
                    <asp:HiddenField ID="hdfActualizarExito" runat="server" meta:resourcekey="hdfActualizarExitoResource1" Value="¡Los datos fueron actualizados exitosamente!" />
                </td>
            </tr>
        </table>     
    </div>   
               
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
           </div>
    </form>    

</body>
</html>
