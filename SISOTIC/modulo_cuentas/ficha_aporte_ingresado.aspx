﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_aporte_ingresado.aspx.vb" Inherits="Reportes_ficha_aporte_ingresado" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BANOTIC</title>
    <link rel="apple-touch-icon" sizes="57x57" href="../favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="../favicon/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="../favicon/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="../favicon/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="../favicon/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="../favicon/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="../favicon/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="../favicon/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="../favicon/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="../favicon/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="../favicon/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="../favicon/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="../favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="../favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="../favicon/mstile-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" ></script>
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
        }
    </script>
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
                        <asp:HyperLink ID="hplResumenGrafico" runat="server" NavigateUrl="resumen_grafico.aspx"><b>Resumen de gestión</b></asp:HyperLink>
                    </li>
                    <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Cartola resumen</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplPorTramo" runat="server" NavigateUrl="reporte_por_tramo.aspx"><b>Por Tramo</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplCuentas" runat="server" NavigateUrl="reporte_cuentas.aspx" Visible="true" ><b>Cuentas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursoInterno" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos_internos.aspx"><b>Curso interno</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Cargas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplIngresoCurso" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos.aspx" Visible="false"><b>Ingreso curso</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="hplCertificado" runat="server" Target="_blank"  NavigateUrl="certificado_aportes.aspx"><b>Certif. aportes</b></asp:HyperLink>
                </li>                
                <li >
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../menu.aspx"><b>Menú principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
                    </div>   
                </div>
        <div id="contenido">       
            <div id="ficha">
                <%--<table id="tablaDatosCurso">
                    <tr>
                        <th width="980px" class="TituloGrupo" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="Ficha de Aporte Ingresado"></asp:Label>
                        </th>                            
                    </tr>
                 </table>--%>
                 <fieldset class="ficha">
		            <legend>Ficha de Aporte Ingresado</legend>
		            <div class="separacion">
		            <asp:Label ID="Label15" runat="server" Text="Num. aporte" Font-Bold="True" Width="80px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text=":" Width="1px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="lblAporte" runat="server" Font-Bold="True" CssClass="AlineacionIzquierda" Width="120px"></asp:Label>
		            <asp:Label ID="Label19" runat="server" Text="Estado actual" Font-Bold="True" Width="80px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="Label27" runat="server" Font-Bold="True" Text=":" Width="1px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="lblEstado" runat="server" Font-Bold="True" CssClass="AlineacionIzquierda" Width="120px"></asp:Label>
		            <asp:Label ID="Label22" runat="server" Text="Origen" Font-Bold="True" Width="80px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="Label29" runat="server" Font-Bold="True" Text=":" Width="1px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="lblOrigen" runat="server" Font-Bold="True" CssClass="AlineacionIzquierda" Width="120px"></asp:Label>
		            </div>
		            <div class="separacion">
		            <asp:Label ID="Label16" runat="server" Text="Folio aporte" Font-Bold="True" Width="80px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text=":" Width="1px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="lblFolio" runat="server" Font-Bold="True" CssClass="AlineacionIzquierda" Width="120px"></asp:Label>
		            <asp:Label ID="Label21" runat="server" Text="Fecha ingreso" Font-Bold="True" Width="80px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="Label28" runat="server" Font-Bold="True" Text=":" Width="1px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="lblFechaIng" runat="server" Font-Bold="True" CssClass="AlineacionIzquierda" Width="120px"></asp:Label>
		            <asp:Label ID="Label23" runat="server" Text="Fecha cobro" Font-Bold="True" Width="80px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="Label30" runat="server" Font-Bold="True" Text=":" Width="1px" CssClass="AlineacionIzquierda"></asp:Label>
		            <asp:Label ID="lblFechCob" runat="server" Font-Bold="True" CssClass="AlineacionIzquierda" Width="120px"></asp:Label>
		            </div>
		            <div class="separacion">
		                <table class="ficha2Tablas" cellpadding="0" cellspacing="0">
		                    <tr>
		                        <td valign="top">
		                            <fieldset>
		                                <legend>Datos Empresa</legend>
		                                <div class="separacion">
		                                    <asp:Label ID="Label31" runat="server" Text="Razón Social" Width="65px"></asp:Label>
                                            <asp:Label ID="Label33" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                            <asp:HyperLink ID="hplRazonSocial" runat="server">Razon Social</asp:HyperLink>
		                                </div>
		                                <div class="separacion">
		                                    <asp:Label ID="Label32" runat="server" Text="Rut empresa" Width="65px"></asp:Label>
                                            <asp:Label ID="Label34" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                            <asp:Label ID="lblRutEmpresa" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
		                                    <asp:Label ID="Label1" runat="server" Text="Dirección" Width="65px"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                            <asp:Label ID="lblDireccion" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                    <asp:Label ID="Label8" runat="server" Text="Contacto" Width="65px"></asp:Label>
                                                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                    <asp:Label ID="lblContacto" runat="server"></asp:Label>
                                                    <asp:Label ID="Label26" runat="server" Text=", ">
                                                    </asp:Label><asp:Label ID="lblCargo" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                    <asp:Label ID="Label2" runat="server" Text="Fono" Width="65px"></asp:Label>
                                                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                    <asp:Label ID="lblFono" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                    <asp:Label ID="Label10" runat="server" Text="Email" Width="65px"></asp:Label>
                                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
		                                </div>
		                            </fieldset>
		                        </td>
		                        <td valign="top">
		                            <fieldset>
		                                <legend>Datos Aporte</legend>
		                                <div class="separacion">
                                                <asp:Label ID="Label20" runat="server" Text="Monto" Width="80px"></asp:Label>
                                                <asp:Label ID="Label38" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                <asp:Label ID="lblMonto" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                <asp:Label ID="Label3" runat="server" Text="Administración" Width="80px"></asp:Label>
                                                <asp:Label ID="Label39" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                <asp:Label ID="lblAdmin" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                <asp:Label ID="Label12" runat="server" Text="Total" Width="80px"></asp:Label>
                                                <asp:Label ID="Label40" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
		                                </div>	
		                                <div class="separacion">
                                                <asp:Label ID="Label17" runat="server" Text="Cuenta destino" Width="80px"></asp:Label>
                                                <asp:Label ID="Label41" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                <asp:Label ID="lblCuenta" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                <asp:Label ID="Label14" runat="server" Text="Tipo documento" Width="80px"></asp:Label>
                                                <asp:Label ID="Label42" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                <asp:Label ID="lblTipoDoc" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                <asp:Label ID="Label25" runat="server" Text="Nº documento" Width="80px"></asp:Label>
                                                <asp:Label ID="Label43" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                <asp:Label ID="lblNumDoc" runat="server"></asp:Label>
                                                <asp:Label ID="lblBanco" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                <asp:Label ID="Label13" runat="server" Text="Vencimiento" Width="80px"></asp:Label>
                                                <asp:Label ID="Label44" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                 <asp:Label ID="lblFechaVen" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                <asp:Label ID="Label11" runat="server" Text="Fecha cobro" Width="80px"></asp:Label>
                                                <asp:Label ID="Label45" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                <asp:Label ID="lblFechaCob" runat="server"></asp:Label>
		                                </div>
		                                <div class="separacion">
                                                 <asp:Label ID="Label24" runat="server" Text="Observaciones" Width="80px"></asp:Label>
                                                <asp:Label ID="Label46" runat="server" Font-Bold="True" Text=":" Width="3px"></asp:Label>
                                                 <asp:Label ID="lblObserv" runat="server"></asp:Label>
		                                </div>	                        
		                            </fieldset>
		                        </td>
		                    </tr>
		                </table>
		            </div>
	            </fieldset>                    <%--<table width="750" cellpadding="0" cellspacing="0" style="margin-left: auto; margin-right: auto">
                        <tr>
                            <td colspan="1" style="width: 250px;" class="AlineacionIzquierda">
                                </td>
                            <td colspan="1" style="width: 250px;" class="AlineacionIzquierda">
                                </td>
                            <td colspan="1" style="width: 250px;" class="AlineacionIzquierda">
                                </td>
                        </tr>
                         <tr>
                             <td colspan="1" style="width: 250px;" class="AlineacionIzquierda">
                                 &nbsp;
                             </td>
                             <td colspan="1" style="width: 250px;" class="AlineacionIzquierda">
                                 &nbsp;
                             </td>
                             <td colspan="1" style="width: 250px;" class="AlineacionIzquierda">
                                 &nbsp;
                             </td>
                          
                         </tr>
                    </table>
                    <table id="tablaPeriodoActual1" style="width: 976px">
                        <tr>
                            <td valign="top" align="center">
                                <table class="GridCertificado" cellpadding="0" cellspacing="0" width="400">
                                    <tr>
                                        <th class="AlineacionIzquierda" width="100%">
                                            <asp:Label ID="Label6" runat="server" Text="Datos de la Empresa"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" width="100%">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" width="100%" >
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" width="100%"></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" width="100%" ></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" width="100%" ></td>
                                    </tr>
                                    
                                </table>
                            </td>
                            <td valign="top" align="center">
                                <table class="GridCertificado" cellpadding="0" cellspacing="0" width="400">
                                <tr>
                                    <th class="AlineacionIzquierda" width="100%">
                                        <asp:Label ID="Label18" runat="server" Text="Datos del Aporte"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%">
                                        </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%">
                                        </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%">
                                        </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%">
                                        </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%" >
                                        </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%" >
                                        </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%"></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" width="100%">
                                    </td>
                                </tr>
                            </table>  
                        </td>                     
                    </tr>
                </table>--%>                
            </div>
            <div id="botonera">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                &nbsp;<asp:Button ID="btnAnular" runat="server" Text="Anular aporte" Visible="false" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de anular el aporte.\n¿Desea continuar?');"  />
                &nbsp;<asp:Button ID="btnPopupEnviarCorreo" runat="server" Text="Enviar email" />
&nbsp;<asp:Button ID="btnImprimir" runat="server" Text="Descargar" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
    <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
