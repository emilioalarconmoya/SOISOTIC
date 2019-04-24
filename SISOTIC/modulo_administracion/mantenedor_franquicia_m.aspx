<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_franquicia_m.aspx.vb" Inherits="modulo_administracion_mantenedor_franquicia_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor franquicia</title>
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
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_franquicia.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_franquicia_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div> 
            <table id="TABLE1" style="width: 980px" align="center" class="tabla">
            <tr>
                <td align="center" style="width: 100%; height: 395px;" valign="top">
                    
                    <table id="tablaSucursal" runat="server" cellpadding="0" cellspacing="0" class="TablaMantenedor"
                        style="width: 432px" visible="true">
                        <tr>
                            <th class="AlineacionIzquierda" colspan="6" style="width: 10%; height: 18px">
                                <asp:Label ID="Label9" runat="server" Text="Franquicia"></asp:Label></th>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" style="width: 72px; height: 12px">
                                &nbsp;<asp:Label ID="lbl1" runat="server" Text="Año :" meta:resourcekey="lblCodigoResource1"></asp:Label>
                                </td>
                            <td align="left" style="width: 136px; height: 12px" class="AlineacionIzquierda">
                                &nbsp;<asp:Label ID="lblAgno" runat="server"></asp:Label></td>
                            <td align="right" style="width: 13px; height: 12px">
                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblNombreResource1" Text="Valor franquicia :" Width="96px"></asp:Label></td>
                            <td style="width: 147px;" class="AlineacionIzquierda">
                                &nbsp;<asp:TextBox ID="txtValorFranquicia" runat="server" MaxLength="50" ValidationGroup="Guardar" meta:resourcekey="txtNombreResource1" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Guardar" meta:resourcekey="btnGuardarResource1" /><br />
                    &nbsp; &nbsp;&nbsp;<asp:HiddenField ID="hdfNombre" runat="server" />
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
