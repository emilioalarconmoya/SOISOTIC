<%@ Page Language="VB" AutoEventWireup="false" CodeFile="acciones_liquidadas.aspx.vb"
    Inherits="modulo_gestion_gerencial_acciones_liquidadas" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Estadísticas</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" src="../include/js/AbrirPopUp.js" type="text/javascript"></script>

    <script language="javascript" src="../include/js/Validacion.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>


    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />

</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="bannner">
                <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="menu">
                <div id="header">
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_cartera.aspx"><b>Cartera</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_agno.aspx"><b>Mov. x año</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_mes.aspx"><b>Mov x mes</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_anual.aspx"><b>Gestión anual</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_mensual.aspx"><b>Gestión mensual</b></asp:HyperLink>
                        </li>
                        <li class="pestanaconsolaseleccionada">
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulo_gestion_gerencial/estadisticas.aspx"><b>Estadísticas</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_finan_otic.aspx"><b>Financiamiento otic</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_resumen_cliente.aspx"><b>Estado Cliente</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/modulo_gestion_gerencial/ranking_otec.aspx"><b>Ranking otec</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="../menu.aspx"><b>Menú</b></asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                        </li>
                    </ul>
                </div>
            </div>
            <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" >
                <tr>
                    <td class="AlineacionDerecha" colspan="2" style="height: 19px; width: 145px;">
                        <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Año :" Width="40px"></asp:Label>
                        <asp:DropDownList ID="ddlAgnos" runat="server" Width="64px">
                        </asp:DropDownList></td>
                    <td colspan="1" style="width: 58px; height: 19px">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" /></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 19px">
                        &nbsp;<asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">Descargar</asp:HyperLink></td>
                </tr>
            </table>
        </div>
        <div id="pie">
            <div class="textoPie">
                <asp:Label ID="lblPie" runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
            </div>
        </div>
    </form>
    <%--
                        </td>--%>
</body>
</html>
