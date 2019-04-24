<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_otec.aspx.vb" Inherits="Reportes_ficha_otec" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Ficha de Otec</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
    <div id="contenido"> 
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
               <li class="pestanaconsolaseleccionada">
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
    <div id="resultados">
        <table id="tablaDatosCurso">
            <tr>
                <th width="980px" class="TituloGrupo" valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Ficha de Otec"></asp:Label>
                </th>                            
            </tr>
         </table>
        <table style="width: 750px;" cellpadding="0" cellspacing="0">
            <tr>
                <td class="AlineacionIzquierda" width="60%">
                    <asp:Label ID="Label2" runat="server" Text="Rut" Font-Bold="True" Width="65px"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblDCrut" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda" width="40%">
                    <asp:Label ID="Label27" runat="server" Text="Fono" Font-Bold="True" Width="45px"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblFono" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" width="60%">
                    <asp:Label ID="Label6" runat="server" Text="Razón Social" Font-Bold="True" Width="65px"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblDCrazonSocial" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda" width="40%">
                    <asp:Label ID="Label31" runat="server" Text="Email" Font-Bold="True" Width="45px"></asp:Label>
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>            
        </table>
        
        <table style="width: 800px;margin-left: auto; margin-right: auto;">
            <tr>
                <th class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="Label17" runat="server" Text="Dirección"></asp:Label>
                </th>
                <th class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="Label18" runat="server" Text="Contacto OTEC"></asp:Label>
                </th>
                <th valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label16" runat="server" Text="Representante Legal"></asp:Label>
                </th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="lblDIdireccion" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="lblDInombreComuna" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="lblDIregion" runat="server" Text="Label"></asp:Label><br />
                    <asp:HyperLink ID="lblDIemail" runat="server">HyperLink</asp:HyperLink></td>
                <td class="AlineacionIzquierda" colspan="" valign="top">
                    <asp:Label ID="Label9" runat="server" Text="Nombre" Width="40px"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblCOnombreContacto" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label13" runat="server" Text="Cargo" Width="40px"></asp:Label>
                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblCOcargoOtec" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label43" runat="server" Text="Fono" Width="40px"></asp:Label>
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblCOfonoOtec" runat="server" Text="Label"></asp:Label>
                    &nbsp;
                    <br />
                    <asp:Label ID="Label49" runat="server" Text="Email" Width="40px"></asp:Label>
                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblCOemailOtec" runat="server" Text="Label"></asp:Label></td>
                <td valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label15" runat="server" Text="Nombre Rep1 " Width="65px"></asp:Label>
                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblRLnombreRep1" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label20" runat="server" Text="RUT" Width="65px"></asp:Label>
                    <asp:Label ID="Label32" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblRLrutRep1" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label22" runat="server" Text="Nombre Rep2" Width="65px"></asp:Label>
                    <asp:Label ID="Label34" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblRLnombreRep2" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label24" runat="server" Text="RUT" Width="65px"></asp:Label>
                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblRLrutRep2" runat="server" Text="Label"></asp:Label></td>
            </tr>
             <tr>
                <th class="AlineacionIzquierda" valign="top">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Datos Convenio"></asp:Label>
                    &nbsp;
                </th>
                <th class="AlineacionIzquierda" colspan="" valign="top">
                    <asp:Label ID="Label10" runat="server" Text="Actividad"></asp:Label></th>
                <th valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label12" runat="server" Text="Otros Contactos"></asp:Label></th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="Label26" runat="server" Text="Nº Convenio" Width="85px"></asp:Label>
                    <asp:Label ID="Label50" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblDCNumComvenio" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label30" runat="server" Text="Tasa de Descuento " Width="85px"></asp:Label>
                    <asp:Label ID="Label51" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblDCtasaDescuento" runat="server" Text="Label"></asp:Label><br />
                </td>
                <td class="AlineacionIzquierda" colspan="" valign="top">
                    <asp:Label ID="Label33" runat="server" Text="Giro" Width="100px"></asp:Label>
                    <asp:Label ID="Label44" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblACgiro" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label35" runat="server" Text="Cod. Act. Economica " Width="100px"></asp:Label>
                    <asp:Label ID="Label46" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblACcodActEco" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label45" runat="server" Text="Rubro Interno" Width="100px"></asp:Label>
                    <asp:Label ID="Label48" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblACrubroInterno" runat="server" Text="Label"></asp:Label></td>
                <td valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label37" runat="server" Text="Gerente General" Width="75px"></asp:Label>
                    <asp:Label ID="Label38" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblOCgerenteGeneral" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label39" runat="server" Text="Gerente RRHH" Width="75px"></asp:Label>
                    <asp:Label ID="Label40" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblOCgerenteRRHH" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label41" runat="server" Text="Area Cobranza" Width="75px"></asp:Label>
                    <asp:Label ID="Label42" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                    <asp:Label ID="lblOCareaCobranza" runat="server" Text="Label"></asp:Label></td>
            </tr>
             <%--<tr>--%>
        </table>
             <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" /></div>
        </div>
        </div>
        </div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
