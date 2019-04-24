<%@ Page Language="VB" AutoEventWireup="false" CodeFile="anular_aporte.aspx.vb" Inherits="modulo_aporte_anular_aporte" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Anular aporte</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" ></script>
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
                    <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplResumenCobranza" runat="server" NavigateUrl="resumen_cobranza.aspx"><b>Resumen de cobranza</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Reporte aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscadorAportes" runat="server" NavigateUrl="Reporte_buscar_aportes.aspx"><b>Buscador Aportes</b></asp:HyperLink>
                </li>
               <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="Listado_Facturas.aspx"><b>Listado facturas</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplNuevoAporte" runat="server" NavigateUrl="ingreso_aporte.aspx"><b>Nuevo aporte</b></asp:HyperLink>
                </li>
                <%--<li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>--%>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
                </ul>
            </div>   
        </div>
        <div id="contenido">
            <div id="Aporte">
                <div>
                    <asp:Label ID="lblTitFolio" runat="server" Text="Folio Aporte" CssClass="Tit"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=":" CssClass="DosPuntos"></asp:Label>
                    <asp:Label ID="lblFolio" runat="server" Text="" CssClass="Dato"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblTitEstado" runat="server" Text="Estado actual" CssClass="Tit"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text=":" CssClass="DosPuntos"></asp:Label>
                    <asp:Label ID="lblEstado" runat="server" Text="" CssClass="Dato"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblTitFecha" runat="server" Text="Fecha" CssClass="Tit"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text=":" CssClass="DosPuntos"></asp:Label>
                    <asp:Label ID="lblfecha" runat="server" Text="" CssClass="Dato"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblTitOrigen" runat="server" Text="Origen" CssClass="Tit"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Text=":" CssClass="DosPuntos"></asp:Label>
                    <asp:Label ID="lblOrigen" runat="server" Text="" CssClass="Dato"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblTitFechaIngreso" runat="server" Text="Fecha Ingreso" CssClass="Tit"></asp:Label>
                    <asp:Label ID="Label12" runat="server" Text=":" CssClass="DosPuntos"></asp:Label>
                    <asp:Label ID="lblFechaIngreso" runat="server" Text="" CssClass="Dato"></asp:Label>
                </div>
                <hr />
            </div>
            <div id="AnularAporte">
                <asp:Label ID="lblMotivo" runat="server" Text="Ingrese el motivo de eliminación del aporte :"></asp:Label>                
                <br />
                <asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine" Rows="5" Width="400px"></asp:TextBox>
            </div>
            <asp:Button ID="btnAnular" runat="server" Text="Anular aporte" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de anular el aporte.\n¿Desea continuar?');" />
        </div>
    </div>
    <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
