<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_param_gen.aspx.vb" Inherits="modulo_administracion_mantenedor_param_gen" %>
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
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table class="TablaMantenedor" width="90%" cellpadding="0" cellspacing="0" id="tablaFiltro">
                    <tr>
                        <th style="width: 10%" class="AlineacionIzquierda" colspan="6">
                            <asp:Label ID="Label1" runat="server" Text="Mantenedor parámetros generales"></asp:Label></th>
                    </tr>
                    <tr>
                        <td style="width: 15%" class="AlineacionIzquierda">
                            <asp:Label ID="Label2" runat="server" Text="Jefe finanzas"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 20%" class="AlineacionIzquierda">
                            <asp:DropDownList ID="ddlJefeFinanzas" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 20%" class="AlineacionIzquierda">
                            <asp:Label ID="Label10" runat="server" Text="Servidor de correo"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 40%" class="AlineacionIzquierda">
                            <asp:TextBox ID="txtSrvCorreo" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 10%" class="AlineacionIzquierda">
                            <asp:Label ID="Label3" runat="server" Text="Jefe operaciones"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 20%" class="AlineacionIzquierda">
                            <asp:DropDownList ID="ddlJefeOperaciones" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 20%" class="AlineacionIzquierda">
                            <asp:Label ID="Label11" runat="server" Text="Dirección de correos de origen"></asp:Label></td>
                        <td style="width: 1%">
                            :</td>
                        <td style="width: 40%" class="AlineacionIzquierda">
                            <asp:TextBox ID="txtDirecCorreosOrigen" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 10%; height: 27px">
                            <asp:Label ID="Label4" runat="server" Text="Días comunicación"></asp:Label></td>
                        <td style="width: 1%; height: 27px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 20%; height: 27px">
                            <asp:TextBox ID="txtDiasComun" runat="server" Width="20%"></asp:TextBox></td>
                        <td class="AlineacionIzquierda" style="width: 20%; height: 27px">
                            <asp:Label ID="Label5" runat="server" Text="Dirección de correos de destino"></asp:Label></td>
                        <td style="width: 1%; height: 27px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 40%; height: 27px">
                            <asp:TextBox ID="txtDirecCorreosDestino" runat="server" Width="80%"></asp:TextBox></td>
                    </tr>
                </table>
                <br />
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
