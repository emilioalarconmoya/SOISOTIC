<%@ Page Language="VB" AutoEventWireup="false" CodeFile="certificado_aportes.aspx.vb" Inherits="modulo_cuentas_certificado_aportes" %>
<%@ Register Src="../contenido/ascx/Cabecera.ascx" TagName="Cabecera" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

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
    
<link href="../estilo.css" rel="Stylesheet" type="text/css" media="screen" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
    <%--<link href="../../estilo.css" rel="Stylesheet" type="text/css" media="screen" />--%>
    <link href="../estilo_imprimir.css" rel="Stylesheet" type="text/css" media="print"  />
     <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="banner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
    </div>
    <div id="menu" runat="server">
        <%--<table width="100%">
            <tr>
                <td id="tablaCabezara">
                </td>
                <td style="width: 405px">
                    <table border="1" style="width: 136px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100px; height: 29px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table border="1" width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
        <br />
        <table width="980">
            <tr>
                <td style="width: 30px">
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="width: 30px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="width: 30px">
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Organismo Técnico Intermedio Reconocido por resolución N° 237 (exenta) del Servicio Nacional de Capacitación y Empleo, con fecha 14 de marzo de 1980."></asp:Label></td>
            </tr>
        </table>
        <table width="980">
            <tr>
                <td align="center" class="AlineacionIzquierda" style="width: 65px; height: 509px">
                    <table border="1" cellpadding="0" cellspacing="0" style="border-right: black 1px solid;
                        border-top: black 1px solid; border-left: black 1px solid; width: 480px; border-bottom: black 1px solid;
                        height: 488px">
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid">
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 463px; height: 509px">
                    <table border="1" cellpadding="0" cellspacing="0" style="border-right: black 1px solid;
                        border-top: black 1px solid; border-left: black 1px solid; width: 464px; border-bottom: black 1px solid">
                        <tr>
                            <td style="width: 100px; height: 29px">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <table border="1" cellpadding="0" cellspacing="0" style="border-right: black 1px solid;
                        border-top: black 1px solid; border-left: black 1px solid; width: 464px; border-bottom: black 1px solid">
                        <tr>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <table border="1" cellpadding="0" cellspacing="0" style="border-right: black 1px solid;
                        border-top: black 1px solid; border-left: black 1px solid; width: 456px; border-bottom: black 1px solid;
                        height: 160px">
                        <tr>
                            <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                                width: 100px; border-bottom: black 1px solid; height: 30px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px; height: 105px">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>--%>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="GridCertificado">
            <tr>
                <td class="tabla2" colspan="2">
                    <div align="center">
                        <asp:Label ID="lblNombreEmpresa" runat="server" Font-Bold="True" Font-Size="11px"></asp:Label><br />
                        <asp:Label ID="Label61" runat="server" Font-Bold="True" Text="Organismo Técnico Intermediario de Capacitación" Font-Size="11px"></asp:Label><br />
                        <asp:Label ID="Label62" runat="server" Font-Bold="True" Text="R.U.T.:" Font-Size="11px"></asp:Label>
                        <asp:Label ID="lblRutEmpresa" runat="server" Font-Bold="True" Font-Size="11px"></asp:Label><br />
                        <asp:Label ID="lblDireccionEmpresa" runat="server" Font-Bold="True" Font-Size="11px"></asp:Label>,
                        <asp:Label ID="Label63" runat="server" Font-Bold="True" Text="Fono:" Font-Size="11px"></asp:Label>
                        <asp:Label ID="lblFonoEmpresa" runat="server" Font-Bold="True" Font-Size="11px"></asp:Label><br />
                        <asp:Label ID="Label64" runat="server" Font-Bold="True" Text="Santiago" Font-Size="11px"></asp:Label>&nbsp;</div>
                    &nbsp;</td>
                <td width="27%">
                    <table cellpadding="0" cellspacing="0" width="50%" >
                        <tr>
                            <td style="background-color:#76eeff" class="TituloVerde">
                                    <asp:Label ID="Label60" runat="server" Text="Año "></asp:Label>
                                    <asp:Label ID="lblAgno" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="tabla2">
                                <div align="center">
                                    <asp:Label ID="lblNroCertificado" runat="server" Font-Bold="True"></asp:Label>&nbsp;</div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%" class="Grid">
            <tr>
                <td style="background-color:#21cfe8; height: 26px;" class="TituloGrupo">
                    <asp:Label ID="Label1" runat="server" Text="CERTIFICADO DE APORTES" ></asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 56px" class="GridCertificado">
            <tr>
                <td width="9%">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="9%" class="AlineacionIzquierda">
                    <asp:Label ID="Label19" runat="server" Font-Size="12px" Text="Empresa:"></asp:Label></td>
                <td colspan="2" class="AlineacionIzquierda">
                    <asp:Label ID="lblRazonSocial" runat="server" Font-Size="12px"></asp:Label></td>
            </tr>
            <tr>
                <td width="9%" class="AlineacionIzquierda">
                    <asp:Label ID="Label22" runat="server" Font-Size="12px" Text="Dirección: "></asp:Label></td>
                <td width="58%" class="AlineacionIzquierda">
                    <asp:Label ID="lblDireccion" runat="server" Font-Size="12px"></asp:Label></td>
                <td width="33%" class="AlineacionIzquierda">
                    <asp:Label ID="Label28" runat="server" Font-Size="12px" Text="RUT:"></asp:Label>
                    <asp:Label ID="lblRut" runat="server" Font-Size="12px"></asp:Label></td>
            </tr>
            <tr>
                <td width="9%" style="height: 17px" class="AlineacionIzquierda">
                    <asp:Label ID="Label25" runat="server" Font-Size="12px" Text="Comuna:"></asp:Label></td>
                <td colspan="2" class="AlineacionIzquierda" style="height: 17px">
                    <asp:Label ID="lblComuna" runat="server" Font-Size="12px"></asp:Label></td>
            </tr>
            <tr>
                <td width="9%">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;<asp:Label ID="Label2" runat="server" Text="ORGANISMO TECNICO INTERMEDIO RECONOCIDO POR RESOLUCION EXENTA N° 421 DE SENCE, PUBLICADA EN DIARIO OFICIAL CON FECHA 02 DE FEBRERO DE 1996." Font-Size="12px"></asp:Label></td>
            </tr>
            <tr>
                <td class="tabla5" width="9%">
                    &nbsp;</td>
                <td class="tabla5" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="GridCertificado">
            <tr>
                <td width="6%" style="height: 115px">
                    &nbsp;</td>
                <td rowspan="1" valign="top" width="41%">
                    <table cellpadding="0" cellspacing="0" width="100%" >
                        <tr>
                            <td width="51%" style="background-color:#76eeff" class="TituloVerde">
                                <asp:Label ID="Label9" runat="server" Text="Mes"></asp:Label></td>
                            <td colspan="2" style="background-color:#76eeff" class="TituloVerde">
                                <asp:Label ID="Label10" runat="server" Text="APORTES"></asp:Label><br />
                                <asp:Label ID="Label55" runat="server" Text="Cifras Históricas"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label11" runat="server" Text="Enero"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label12" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoEnero" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label14" runat="server" Text="Febrero"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label15" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoFebrero" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label17" runat="server" Text="Marzo"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label18" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoMarzo" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label20" runat="server" Text="Abril"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label21" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoAbril" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label23" runat="server" Text="Mayo"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label24" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoMayo" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label26" runat="server" Text="Junio"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label27" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoJunio" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label29" runat="server" Text="Julio"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label30" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoJulio" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label32" runat="server" Text="Agosto"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label33" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoAgosto" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label35" runat="server" Text="Septiembre"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label36" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoSeptiembre" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label38" runat="server" Text="Octubre"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label39" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoOctubre" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label41" runat="server" Text="Noviembre"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label42" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoNoviembre" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label44" runat="server" Text="Diciembre"></asp:Label>
                            </td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label45" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoDiciembre" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" width="51%">
                                <asp:Label ID="Label47" runat="server" Font-Bold="True" Text="TOTAL APORTES"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                                <asp:Label ID="Label48" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblMontoTotal" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda" colspan="" rowspan="">
                                <asp:Label ID="Label50" runat="server" Text="1% Remuneración imponible anual"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%;">
                                <asp:Label ID="Label51" runat="server" Text="$"></asp:Label></td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblPorcFranquicia" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="51%" class="AlineacionIzquierda">
                                <asp:Label ID="Label53" runat="server" Text="Dotación personal"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 23%">
                            </td>
                            <td width="49%" class="AlineacionDerecha">
                                <asp:Label ID="lblNroParticipantes" runat="server" Text="0"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td width="7%" style="height: 115px">
                    &nbsp;</td>
                <td class="tabla6" width="41%" style="height: 115px">
                    <table border="1" cellpadding="0" cellspacing="0" width="100%" class="Grid">
                        <tr>
                            <td>
                                <asp:Label ID="lblFechaDeHoy" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                    <table cellpadding="0" cellspacing="0" width="100%" >
                        <tr>
                            <td style="background-color:#76eeff" class="TituloVerde">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="USO EXCLUSIVO DE LA EMPRESA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="tabla2">
                                <p class="AlineacionIzquierda">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Los datos contenidos en este documento corresponden a los registrados en nuestra Contabilidad"></asp:Label>&nbsp;</p>
                                <p class="AlineacionIzquierda">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="NOMBRE RESPONSABLE:"></asp:Label>&nbsp;</p>
                                <p class="AlineacionIzquierda">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="FIRMA:"></asp:Label>&nbsp;</p>
                                <p class="AlineacionIzquierda">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="FECHA:"></asp:Label>&nbsp;</p>
                            </td>
                        </tr>
                    </table>
                    <asp:Image ID="Image1" runat="server" Height="105px" ImageUrl="~/contenido/imagenes/empresa/firma_gerente.png"
                        Width="180px" /><br />
                    <br />
                    <table border="1" cellpadding="0" cellspacing="0" width="100%" class="Grid" style="display: none">
                        <tr>
                            <td class="tabla2">
                                <div align="center">
                                    <asp:Label ID="Label56" runat="server" Font-Bold="True" Text="O.T.I.C."></asp:Label><br />
                                    <asp:Label ID="Label57" runat="server" Font-Bold="True" Text="NOMBRE PERSONA QUE FIRMA"></asp:Label><br />
                                    <asp:Label ID="lblPersonaQueFirma" runat="server" Font-Bold="True"></asp:Label><br />
                                    <asp:Label ID="Label59" runat="server" Font-Bold="True" Text="SELLADOR "></asp:Label>&nbsp;</div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="5%" style="height: 115px">
                    &nbsp;</td>
            </tr>
        </table>
        <table border="1" cellpadding="0" cellspacing="0" width="100%" class="Grid" id="tablaMontoMaximo">
            <tr>
                <td>
                    <div align="center">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="EL MONTO MAXIMO IMPUTABLE A LA FRANQUICIA TRIBUTARIA ES"></asp:Label>
                        <asp:Label ID="Label65" runat="server" Font-Bold="True" Text="EL 1% DE LAS REMUNERACIONES IMPONIBLES ANUALES"></asp:Label>
                    </div>
                    <div align="center">
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Nota: Este documento debe ser devuelto a "></asp:Label>
                        <asp:Label ID="lblNombreEmpresaNota" runat="server" Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblDiasCertificado" runat="server" Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblAgnoNota" runat="server" Font-Bold="True"></asp:Label>.
                    </div>
                    <div align="center">
                        <asp:Label ID="lblMensajeNoDatos" runat="server" Text="El cliente no tiene aportes durante el año" Visible="False"></asp:Label>
                        <asp:Label ID="lblAgnoNoDatos" runat="server" Visible="False"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        </div>
            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" /><br />
    </div>
     <div id="pie" onclick="return pie_onclick()">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
