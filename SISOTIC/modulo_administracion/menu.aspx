<%@ Page Language="VB" AutoEventWireup="false" CodeFile="menu.aspx.vb" Inherits="modulo_administracion_menu" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Menu Administración</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="Div1">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>

        <div id="cssmenu">
            <h2>
                Menú de gestión</h2>
            <ul>
                <li class='active'>
                    <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/modulo_administracion/carga_alumnos.aspx">Carga de datos</asp:HyperLink>&nbsp;</li>
                <li>
                    <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/modulo_administracion/asignacion_excedentes.aspx">Asignación de Excedentes</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_usuario_perfil.aspx">Usuario-Perfil</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_perfil_objeto.aspx">Perfil-Objeto</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_objeto.aspx">Objeto</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_sucursales.aspx">Sucursales</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_supervisor_ejecutivos.aspx">Supervisor-Ejecutivos</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_usuario_sucursal.aspx">Usuario-Sucursal</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulo_administracion/listado_generacion_certificados_aporte.aspx">Listado y Generación de Certificados de Aporte</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/modulo_administracion/informes_sence.aspx">Informes Sence</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_cursos_sence.aspx">Mantenedor cursos SENCE</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_empresas.aspx">Mantenedor empresas</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_horas_sence.aspx">Mantenedor horas SENCE</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_param_gen.aspx">Mantenedor parámetros generales</asp:HyperLink></li>    
                <li>
                    <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_rubros.aspx">Mantenedor rubros</asp:HyperLink></li>   
            </ul>
            <p>
                &nbsp;</p>
        </div>
          <asp:HiddenField ID="hdfOrigen" runat="server" Value="Administracion" />
    <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
     </div>
     </div>
    </form>
</body>
</html>
