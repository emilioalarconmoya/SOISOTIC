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

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
                                <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl="mantenedor_cursos_internos.aspx"><b>Curso no Sence</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="buscador_cursos.aspx"><b>Buscar curso</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                            </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                            <li>
                                <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                            </li>
                <li visible="False">
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Mantenedor Sence</b></asp:HyperLink>
                </li>
                            <li>
                                <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
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
        <table style="width: 980px;" cellpadding="0" cellspacing="0" class="TablaInterior">
            <tr>
                <td class="titDatos1">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Rut" Font-Bold="False"></asp:Label>&nbsp;</td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblDCrut" runat="server" Font-Bold="False"></asp:Label></td>
                <td class="titDatos1">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label27" runat="server" Text="Fono" Font-Bold="False"></asp:Label>
                    &nbsp; &nbsp;
                </td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblFono" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="titDatos1">
                    <asp:Label ID="Label6" runat="server" Text="Razón Social" Font-Bold="False"></asp:Label></td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblDCrazonSocial" runat="server" Font-Bold="False"></asp:Label></td>
                <td class="titDatos1">
                    <asp:Label ID="Label31" runat="server" Text="Email" Font-Bold="False"></asp:Label></td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="titDatos1" colspan="3">
                </td>
                <td class="titDatos1">
                    </td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1" colspan="1">
                    </td>
            </tr>
            
        </table>
        
        <table style="width: 980px;">
           <%-- <tr>
                <th colspan="3" class="AlineacionIzquierda">
                    &nbsp;<asp:Label ID="Label12" runat="server" Text="DATOS CURSO INTERNO"></asp:Label></th>
            </tr>--%>
            <tr>
                <th class="AlineacionIzquierda" valign="top" colspan="3" style="width: 202px">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label17" runat="server" Text="Dirección"></asp:Label>
                    &nbsp;
                </th>
                <th class="AlineacionIzquierda" colspan="2" valign="top">
                    <asp:Label ID="Label18" runat="server" Text="Contacto OTEC"></asp:Label></th>
                <th valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label16" runat="server" Text="Representante Legal"></asp:Label></th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="3" valign="top" style="width: 202px">
                    <asp:Label ID="lblDIdireccion" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="lblDInombreComuna" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="lblDIregion" runat="server" Text="Label"></asp:Label><br />
                    <asp:HyperLink ID="lblDIemail" runat="server">HyperLink</asp:HyperLink></td>
                <td class="AlineacionIzquierda" colspan="2" valign="top">
                    <asp:Label ID="Label9" runat="server" Text="Nombre: "></asp:Label>
                    <asp:Label ID="lblCOnombreContacto" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label13" runat="server" Text="Cargo: "></asp:Label>
                    <asp:Label ID="lblCOcargoOtec" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label43" runat="server" Text="Fono: "></asp:Label>
                    <asp:Label ID="lblCOfonoOtec" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label49" runat="server" Text="Email: "></asp:Label>
                    <asp:Label ID="lblCOemailOtec" runat="server" Text="Label"></asp:Label></td>
                <td valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label15" runat="server" Text="Nombre Rep1: "></asp:Label>
                    <asp:Label ID="lblRLnombreRep1" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label20" runat="server" Text="RUT: "></asp:Label>
                    <asp:Label ID="lblRLrutRep1" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label22" runat="server" Text="Nombre Rep2: "></asp:Label>
                    <asp:Label ID="lblRLnombreRep2" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label24" runat="server" Text="RUT: "></asp:Label>
                    <asp:Label ID="lblRLrutRep2" runat="server" Text="Label"></asp:Label></td>
            </tr>
             <tr>
                <th class="AlineacionIzquierda" valign="top" colspan="3" style="width: 202px">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Datos Convenio"></asp:Label>
                    &nbsp;
                </th>
                <th class="AlineacionIzquierda" colspan="2" valign="top">
                    <asp:Label ID="Label10" runat="server" Text="Actividad"></asp:Label></th>
                <th valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label12" runat="server" Text="Otros Contactos"></asp:Label></th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="3" valign="top" style="width: 202px">
                    <asp:Label ID="Label26" runat="server" Text="Nº Convenio: "></asp:Label>
                    <asp:Label ID="lblDCNumComvenio" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label30" runat="server" Text="Tasa de Descuento: "></asp:Label>
                    <asp:Label ID="lblDCtasaDescuento" runat="server" Text="Label"></asp:Label><br />
                </td>
                <td class="AlineacionIzquierda" colspan="2" valign="top">
                    <asp:Label ID="Label33" runat="server" Text="Giro: "></asp:Label>
                    <asp:Label ID="lblACgiro" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label35" runat="server" Text="Cod. Act. Economica: "></asp:Label>
                    <asp:Label ID="lblACcodActEco" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label45" runat="server" Text="Rubro Interno: "></asp:Label>
                    <asp:Label ID="lblACrubroInterno" runat="server" Text="Label"></asp:Label></td>
                <td valign="top" class="AlineacionIzquierda">
                    <asp:Label ID="Label37" runat="server" Text="Gerente General: "></asp:Label>
                    <asp:Label ID="lblOCgerenteGeneral" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label39" runat="server" Text="Gerente RRHH: "></asp:Label>
                    <asp:Label ID="lblOCgerenteRRHH" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label41" runat="server" Text="Area Cobranza: "></asp:Label>
                    <asp:Label ID="lblOCareaCobranza" runat="server" Text="Label"></asp:Label><br />
                    &nbsp;</td>
            </tr>
             <%--<tr>--%>
        </table>
             <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
                 <asp:Button ID="btnFichaOtecPDF" runat="server" Text="Genera PDF" /></div>
          <%--<asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label28" runat="server" Text="asdsada"></asp:Label><br />
        <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label><br />--%>
        &nbsp;</div>
        </div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
