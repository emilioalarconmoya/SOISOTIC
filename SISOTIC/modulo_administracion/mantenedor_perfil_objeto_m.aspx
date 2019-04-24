<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_perfil_objeto_m.aspx.vb" Inherits="modulo_administracion_mantenedor_perfil_objeto_m" %>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_perfil_objeto.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_perfil_objeto_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table id="TablaMantenedor" width="90%">
                    <tr>
                        <th colspan="3">
                            <asp:Label ID="Label3" runat="server" Text="Perfil y objeto asignado"></asp:Label></th>
                    </tr>
                    <tr>
                        <td>
                            <table id="TablaNuevoPerfil" runat="server" cellpadding="0" cellspacing="0" class="TablaDatosOtec"
                                width="100%" visible="false">
                                <tr>
                                    <td style="width: 10%; height: 22px">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" Text="Nuevo perfil "></asp:Label></td>
                                    <td style="width: 1%; height: 22px">
                                        :</td>
                                    <td style="width: 15%; height: 22px">
                                        <asp:TextBox ID="txtNuevoPerfil" runat="server"></asp:TextBox></td>
                                </tr>
                            </table>
                            <table id="TablaPerfiles" runat="server" cellpadding="0" cellspacing="0" class="TablaDatosOtec"
                                width="100%" visible="false">
                                <tr>
                                    <td style="width: 10%; height: 22px">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Perfil "></asp:Label></td>
                                    <td style="width: 1%; height: 22px">
                                        :</td>
                                    <td style="width: 15%; height: 22px">
                                        <asp:DropDownList ID="ddlPerfiles" runat="server" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                 <table class="TablaMantenedor" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                    <asp:Label ID="lblObjetosDisponibles" runat="server" Font-Bold="False" Style="position: static" Text="Objetos Disponibles" ></asp:Label></td>
                        <td style="width: 100px">
                        </td>
                        <td>
                    <asp:Label ID="lblObjetosAsignados" runat="server" Font-Bold="False" Style="position: static" Text="Objetos Asignados" ></asp:Label></td>
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
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
