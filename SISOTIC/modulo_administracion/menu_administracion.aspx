<%@ Page Language="VB" AutoEventWireup="false" CodeFile="menu_administracion.aspx.vb" Inherits="modulo_administracion_menu_administracion" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Menu Administración</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="Div1">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
                <br />
            </div>
            <div id="contenido">    
             
                <div id="cssmenu" >
                    <h2>
                        Menú de administración
                    </h2>
                    <ul>
                        
                        <li id="li1" runat="server"  class='has-sub'>
                            <a href="#">Mantenedor</a>
                                <ul>
                                    <li  id="li1_1" runat="server">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_cursos_sence.aspx" >Mantenedor cursos SENCE</asp:HyperLink>                                            
                                    </li>
                                    <li id="li1_2" runat="server">
                                        <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_empresas.aspx">Mantenedor empresas</asp:HyperLink>
                                    </li>
                                    <%--<li id="li1_3" runat="server" visible = "False">
                                        <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_horas_sence.aspx">Mantenedor valor horas SENCE</asp:HyperLink>
                                    </li>--%>
                                    <%--<li id="li1_4" runat="server">
                                        <asp:HyperLink ID="HyperLink43" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_param_gen.aspx">Mantenedor par&#225;metros generales</asp:HyperLink>
                                    </li>--%>
                                    <li id="li1_5" runat="server">
                                        <asp:HyperLink ID="HyperLink53" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_rubros.aspx">Mantenedor rubros</asp:HyperLink>
                                    </li>
                                    <li id="li1_6" runat="server">
                                        <asp:HyperLink ID="HyperLink63" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_otec.aspx">Mantenedor OTEC</asp:HyperLink>
                                    </li>
                                    <%--<li id="li1_7" runat="server">
                                        <asp:HyperLink ID="HyperLink73" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_clasificador.aspx">Mantenedor clasificador</asp:HyperLink>
                                    </li>--%>
                                    <li id="li1_8" runat="server">
                                        <asp:HyperLink ID="HyperLink83" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_usuario_perfil.aspx">Mantenedor usuarios</asp:HyperLink>
                                    </li>
                                    <li id="li1_9" runat="server">
                                        <asp:HyperLink ID="HyperLink93" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_perfil.aspx">Mantenedor perfil</asp:HyperLink>
                                    </li>
                                    <li id="li1_10" runat="server">
                                        <asp:HyperLink ID="HyperLink103" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_objeto.aspx">Mantenedor objeto</asp:HyperLink>
                                    </li>
                                    <li id="li1_11" runat="server">
                                        <asp:HyperLink ID="HyperLink113" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_perfil_objeto.aspx">Mantenedor perfil - objeto</asp:HyperLink>
                                    </li>
                                    <li id="li1_12" runat="server" visible="false" >
                                        <asp:HyperLink ID="HyperLink123" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_sucursales.aspx">Mantenedor sucursales</asp:HyperLink>
                                    </li>
                                    <li id="li1_13" runat="server">
                                        <asp:HyperLink ID="HyperLink133" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_supervisor_ejecutivos.aspx">Mantenedor supervisor - ejecutivo</asp:HyperLink>
                                    </li>
                                    <li id="li1_14" runat="server">
                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_feriados.aspx">Mantenedor feriados</asp:HyperLink>
                                    </li>
                                    <li id="li1_15" runat="server" >
                                        <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_encargado.aspx">Mantenedor encargado</asp:HyperLink>
                                    </li>
                                   
                                </ul>
                                 
                             
                        </li>
                        <li id="li2" runat="server" >
                            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/modulo_administracion/carga_cursos_xls_adm.aspx" >Carga de cursos</asp:HyperLink>
                        </li>
                        <li id="li3" runat="server">
                            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/modulo_administracion/carga_alumnos.aspx" >Carga de nominas</asp:HyperLink>
                        </li>
                        <%--<li id="li4" runat="server">
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_administracion/carga_transaccion.aspx" >Carga inicial</asp:HyperLink>
                        </li>--%>
                        <li id="li5" runat="server">
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_traspaso_cuentas.aspx" >Traspaso de montos</asp:HyperLink>     
                        </li>
                        <li id="li6" runat="server">
                            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_administracion/comunicar_cursos_sence.aspx" >Comunicar cursos SENCE</asp:HyperLink>
                        </li>
                        <li id="li7" runat="server">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_administracion/asignacion_excedentes.aspx" >Asignación de excedentes</asp:HyperLink>
                        </li>
                        <li id="li8" runat="server">
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulo_administracion/listado_generacion_certificados_aporte.aspx" >Certificados de Aporte</asp:HyperLink>
                        </li>
                        <li id="li9" runat="server">
                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/modulo_administracion/informes_sence.aspx" >Informes Sence</asp:HyperLink>
                        </li>
                         <li id="li10" runat="server">
                            <asp:HyperLink ID="HyperLink143" runat="server" NavigateUrl="~/menu.aspx">Menu principal</asp:HyperLink>
                        </li>
                    </ul>
                </div>
                <br />
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
