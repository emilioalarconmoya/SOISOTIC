<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_supervisor_ejecutivos_m.aspx.vb" Inherits="modulo_administracion_mantenedor_supervisor_ejecutivos_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mantenedor supervisor-sucursal</title>
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
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_supervisor_ejecutivos.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="mantenedor_supervisor_ejecutivos_m.aspx"><b>Mantenedor</b></asp:HyperLink>
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
        <fieldset id="mantenedor" >
            <div>
            <table class="margenSuperEjec" style="width: 43%">
                    <tr>
                        <th style="width: 10%" class="AlineacionIzquierda" colspan="3">
                            <asp:Label ID="Label4" runat="server" Text="Ingreso de nuevo usuario"></asp:Label></th>
                    </tr>
                    <tr>
                        <td style="width: 10%" class="AlineacionIzquierda">
                            <asp:Label ID="Label5" runat="server" Text="Rut"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 40%" class="AlineacionIzquierda">
                            <asp:DropDownList ID="ddlSupervisor" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                </table>
                <br />
                 <table class="margenSuperEjec">
                    <tr>
                        <td>
                    <asp:Label ID="lblPerfilesDisponibles" runat="server" Font-Bold="True" Style="position: static" Text="Ejecutivos Disponibles" ></asp:Label></td>
                        <td style="width: 100px">
                        </td>
                        <td>
                    <asp:Label ID="lblPerfilesAsignados" runat="server" Font-Bold="True" Style="position: static" Text="Ejecutivos Asignados" ></asp:Label></td>
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
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
            </div>
        </fieldset> 
        
        <%--<table id="TABLE1" style="width: 980px" align="center" class="tabla">
        <tr>
                        <th style="width: 10%;" class="AlineacionIzquierda" colspan="6">
                            <asp:Label ID="Label1" runat="server" Text="Ingreso de nueva sucursal"></asp:Label></th>
                    </tr>
            <tr>
                <td align="center" valign="top">
                    <table style="width: 57%">
                    
                        <tr>
                        <td style="width: 111px;">&nbsp;<asp:Label ID="Label2" runat="server" Text="Supervisor"></asp:Label></td>
                            <td align="right" style="width: 25px;">
                                <asp:Label ID="Label6" runat="server" Text="Rut :"></asp:Label></td>
                            <td align="left" style="width: 116px;">
                                <asp:TextBox ID="txtRutSupervisor" runat="server"></asp:TextBox></td>
                            <td style="width: 46px;">
                                <asp:Label ID="Label7" runat="server" Text="Nombre :"></asp:Label></td>
                            <td colspan="2" style="width: 135px;">
                                <asp:DropDownList ID="ddlNomSupervisor" runat="server">
                                </asp:DropDownList>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 111px;">
                                <asp:Label ID="Label3" runat="server" Text="Ejecutivol"></asp:Label></td>
                            <td align="right" style="width: 25px;">
                                <asp:Label ID="Label4" runat="server" Text="Rut :"></asp:Label></td>
                            <td align="left" style="width: 116px;">
                                <asp:TextBox ID="txtRutEjecutivo" runat="server"></asp:TextBox></td>
                            <td style="width: 46px;">
                                <asp:Label ID="Label5" runat="server" Text="Nombre :"></asp:Label></td>
                            <td colspan="2" style="width: 135px;">
                                <asp:DropDownList ID="ddlNomEjecutivo" runat="server">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" />&nbsp;<br />
                    <br />
                </td>
            </tr>
        </table> --%>    
    </div>   
               
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
           </div>
    </form>    

</body>
</html>
