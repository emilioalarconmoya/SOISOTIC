<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_empresa.aspx.vb" Inherits="Reportes_ficha_empresa" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ficha de Empresa</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>

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
                <%--<li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>--%>
                </li>
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
                                <asp:Label ID="Label1" runat="server" Text="Ficha de Empresa"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0" id="tablaPeriodoActual">
            <tr>
                <td class="AlineacionIzquierda" colspan="3" style="width: 200px; height: 15px;">
                    <asp:Label ID="lblRazonSocial" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="titDatos1" style="width: 20px; height: 15px;">
                    <asp:Label ID="Label27" runat="server" Text="Fono" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos" style="width: 2px; height: 15px;">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 150px; height: 15px;">
                    <asp:Label ID="lblFono" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="titDatos1" style="width: 20px; height: 15px;">
                    <asp:Label ID="Label3" runat="server" Text="Sucursal" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos" style="width: 2px; height: 15px;">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 120px; height: 15px;">
                    <asp:Label ID="lblSucursal" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 10px; height: 15px;">
                    <asp:Label ID="Label2" runat="server" Text="Rut" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos" style="width: 3px; height: 15px;" colspan="">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 164px; height: 15px;">
                    &nbsp;<asp:Label ID="lblRut" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="titDatos1" style="width: 20px; height: 15px;" valign="top">
                    <asp:Label ID="Label31" runat="server" Text="Email" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos" style="width: 2px; height: 15px;">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 150px; height: 15px;">
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="titDatos1" style="width: 20px; height: 15px;">
                    <asp:Label ID="Label7" runat="server" Text="Ejecutivo" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos" style="width: 2px; height: 15px;">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 120px; height: 15px;">
                    <asp:Label ID="lblEjecutivo" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            
        </table>
        <table id="tablaFichaEmpresa">
            <tr>
                <td  valign="top" style="height: 97px">
                    <table cellpadding="0" cellspacing="0" class="TablasCuentas">
                        <tr>
                            <th class="TituloIzquierda" colspan="3">
                                <asp:Label ID="Label8" runat="server" Text="Dirección"></asp:Label></th>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3">
                                <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3" >
                                <asp:Label ID="lblComuna" runat="server"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text=","></asp:Label>
                                <asp:Label ID="lblCiudad" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3" >
                                <asp:Label ID="lblRegion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3"">
                                <asp:Label ID="lblSitioWeb" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
           
       
    
                <td valign="top" style="height: 97px">
                    <table cellpadding="0" cellspacing="0" class="TablasCuentas">
                        <tr>
                            <th class="TituloIzquierda" colspan="4" style="width: 50%">
                                <asp:Label ID="Label63" runat="server" Text="Contacto ABIF"></asp:Label></th>
                        </tr>
                        <tr>
                            <td class="TituloIzquierdo" colspan="4" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" colspan="4" style="height: 12px" valign="top">
                                <asp:Label ID="lblContacto" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" colspan="4" valign="top">
                                <asp:Label ID="lblCargo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" colspan="4" style="height: 16px" valign="top">
                                <asp:Label ID="Label68" runat="server" Text="Fono :"></asp:Label>
                                <asp:Label ID="lblFonoContac" runat="server"></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="Anexo :"></asp:Label>
                                <asp:Label ID="lblAnexo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" colspan="4" valign="top">
                                <asp:Label ID="lblEmailContac" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
         
                <td valign="top" style="height: 97px; width: 33%;">
                    <table cellpadding="0" cellspacing="0" class="TablaCuentas">
                        <tr>
                            <th colspan="5" style="width: 20%">
                                <asp:Label ID="Label83" runat="server" Text="Representante Legal"></asp:Label></th>
                        </tr>
                        <tr>
                            <td colspan="5" valign="top" style="width: 20%">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 20%;">
                                <asp:Label ID="Label84" runat="server" Text="Nombre 1"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td colspan="1" style="width: 79%;" valign="top" class="AlineacionIzquierda">
                                <asp:Label ID="lblNombre1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 20%">
                                <asp:Label ID="Label86" runat="server" Text="RUT 1"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td colspan="1" style="width: 79%" valign="top" class="AlineacionIzquierda">
                                <asp:Label ID="lblRut1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 20%">
                                <asp:Label ID="Label88" runat="server" Text="Nombre 2"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%; height: 12px;">
                                :</td>
                            <td colspan="1" style="width: 79%" valign="top" class="AlineacionIzquierda">
                                <asp:Label ID="lblNombre2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 20%">
                                <asp:Label ID="Label90" runat="server" Text="RUT 2"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td colspan="1" style="width: 79%" valign="top" class="AlineacionIzquierda">
                                <asp:Label ID="lblRut2" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" class="TablasCuentas">
                        <tr>
                            <th class="TituloIzquierda" colspan="5" style="width: 50%">
                                <asp:Label ID="Label103" runat="server" Text="Datos Franquicia Tributaria"></asp:Label></th>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                                <asp:Label ID="Label104" runat="server" Text="Nº Empleados"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%; height: 16px">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 50%; height: 16px">
                                <asp:Label ID="lblNumEmpleados" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%">
                                <asp:Label ID="Label106" runat="server" Text="Franquicia Actual"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 50%">
                                <asp:Label ID="lblFranquicia" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 15px;">
                                <asp:Label ID="Label108" runat="server" Text="Tasa Admin. Aportes"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%; height: 15px;">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 50%; height: 15px;">
                                <asp:Label ID="lblTasa" runat="server"></asp:Label><asp:Label ID="Label6" runat="server"
                                    Text="%"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" class="TablasCuentas">
                        <tr>
                            <th class="TituloIzquierda" colspan="5" style="width: 50%">
                                <asp:Label ID="Label123" runat="server" Text="Actividad"></asp:Label></th>
                        </tr>
                        <tr>
                            <td class="TituloIzquierdo" colspan="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3" style="width: 32%; height: 16px">
                                <asp:Label ID="Label124" runat="server" Text="Giro"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%; height: 16px">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 50%; height: 16px">
                                <asp:Label ID="lblGiro" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3" style="width: 32%">
                                <asp:Label ID="Label126" runat="server" Text="Cod.Act.Economica"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 50%">
                                <asp:Label ID="lblCodActEco" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3" style="width: 32%">
                                <asp:Label ID="Label128" runat="server" Text="Rubro Interno"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 50%">
                                <asp:Label ID="lblRubro" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="3" style="width: 32%; height: 16px">
                                <asp:Label ID="Label130" runat="server" Text="Venta Neta Anual"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%; height: 16px">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 50%; height: 16px">
                                <asp:Label ID="lblVentaAnual" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
              
                <td valign="top" style="width: 33%">
                    <table cellpadding="0" cellspacing="0" class="TablasCuentas">
                        <tr>
                            <th class="TituloIzquierda" colspan="5" style="width: 49%">
                                <asp:Label ID="Label143" runat="server" Text="Otros Contactos"></asp:Label></th>
                        </tr>
                        <tr>
                            <td align="left" class="TituloIzquierdo" colspan="5" style="width: 49%;">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 31%;">
                                <asp:Label ID="Label144" runat="server" Text="Gerente general"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 51%;">
                                <asp:Label ID="lblGerenteG" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 31%">
                                <asp:Label ID="Label146" runat="server" Text="Gerente RRHH"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 51%">
                                <asp:Label ID="lblGerenteRH" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 31%">
                                <asp:Label ID="Label148" runat="server" Text="Email Gerente RRHH"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 51%">
                                <asp:Label ID="lblEmailGerenteRRHH" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 31%">
                                <asp:Label ID="Label150" runat="server" Text="Gerente Finanzas"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 51%">
                                <asp:Label ID="lblGerenteF" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 31%">
                                <asp:Label ID="Label152" runat="server" Text="Email Gerente Finanzas"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 51%">
                                <asp:Label ID="lblEmailGerenteF" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 31%">
                                <asp:Label ID="Label154" runat="server" Text="Area Cobranzas"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 51%">
                                <asp:Label ID="lblAreaCob" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 31%">
                                <asp:Label ID="Label157" runat="server" Text="Fono Cobranzas"></asp:Label>
                            </td>
                            <td class="TituloIzquierdo" colspan="1" style="width: 1%">
                                :</td>
                            <td class="AlineacionIzquierda" colspan="1" style="width: 51%">
                                <asp:Label ID="lblFonoCob" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
                <div id="botones">
                          <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                          <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
                </div>
         
         </div>
          
        </div>
       </div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>
    </form>
          <%--</table> --%>
</body>

</html>
             