<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carta_resumen_cliente.aspx.vb" Inherits="modulo_cuentas_carta_resumen_cliente" %>
<%@ Register Src="../contenido/ascx/cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script> 
    <script type="text/javascript" >
        function Imprimir() {
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
       
    </div>
        <div id="Cabecera">
        </div>   
        <div align="left" style="float:left; width:50% ; height:79px; border-bottom:2px solid #808080"> 
                <asp:Label ID="Label45" runat="server" Text="Empresa: " Font-Bold="True"></asp:Label>
            <asp:Label ID="lblNombreEmpresa2" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <asp:Label ID="Label59" runat="server" Text="Teléfono: " Font-Bold="True"></asp:Label>
            <asp:Label ID="lblTelefono" runat="server" Font-Bold="True"></asp:Label>&nbsp;<br />
		</div> 
            <div style="float:right; width:15% ;height:79px; border-bottom:2px solid #808080" align="right" >
                <asp:Image ID="Image1" runat="server" ImageUrl="~/contenido/imagenes/empresa/logo.jpg" Width="114px" Height="77px" />
            </div>
            <div style="float:right ; width:35%; height:79px; border-bottom:2px solid #808080;" align="right"  >
                <asp:Label ID="lblFechaImpresion" runat="server" Font-Bold="True"></asp:Label>                 
            </div> 
                
        <div id="contenido"> 
            <br />
        
            <div align="left">
                <asp:Label ID="Label43" runat="server" Text="Estimado cliente, le saludamos con especial atención y junto con agradecer 
        su preferencia por nuestros servicios, tenemos el agrado de hacerle llegar 
        la información de la cuenta corriente de vuestra empresa con esta corporación, 
        desde enero a la fecha."></asp:Label>
        <br/>
        <br/>
                <asp:Label ID="Label42" runat="server" Text="En la siguiente tabla se presenta el Resumen de los movimientos. En esta 
        se indica el valor imputable de los cursos contratados y la tasa de administración 
        de éstos, de la misma forma, se entrega el total de los aportes efectuados 
        y el respectivo saldo de su cuenta corriente. Para complementar estos 
        datos, en las páginas siguientes, se adjunta el detalle de los cursos 
        y aportes efectuados."></asp:Label>
        </div>          
            <div id="resultados">
                <div id="CuentasPeriodoActual">
                    <table id="tablaPeriodoActual">
                        <tr>
                            <th colspan="2" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Franquicia del período"></asp:Label></th>                            
                        </tr>
                        <tr>
                            <td valign="top">
                                <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <th class="TituloIzquierda">
                                            <asp:Label ID="Label4" runat="server" Text="Aportes por enterar (Deuda Total)"></asp:Label></th>
                                        <th colspan="2" class="TituloDerecha">
                                            <asp:Label ID="Label5" runat="server" Text="Valor"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato" style="height: 12px">
                                            <asp:Label ID="Label6" runat="server" Text="Capacitación :"></asp:Label></td>
                                        <td class="Indicador" style="height: 12px; width: 20%;">
                                            <asp:Label ID="Label10" runat="server" Text="$"></asp:Label></td>
                                        <td class="ValorDato" style="height: 12px">
                                            <asp:Label ID="lblAPEcapacitacion" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato" style="height: 12px">
                                            <asp:Label ID="Label7" runat="server" Text="Reparto :"></asp:Label></td>
                                        <td class="Indicador" style="height: 12px; width: 20%;">
                                            <asp:Label ID="Label11" runat="server" Text="$"></asp:Label></td>
                                        <td class="ValorDato" style="height: 12px">
                                            <asp:Label ID="lblAPErepato" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato">
                                            <asp:Label ID="Label8" runat="server" Text="Administración(Aprox.) :"></asp:Label></td>
                                        <td class="Indicador" style="width: 20%">
                                            <asp:Label ID="Label12" runat="server" Text="$"></asp:Label></td>
                                        <td class="ValorDato">
                                            <asp:Label ID="lblAPEadministracion" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato">
                                            <asp:Label ID="Label9" runat="server" Text="Total aporte adeudado :" CssClass="ValorDestacado"></asp:Label></td>
                                        <td class="Indicador" style="width: 20%">
                                            <asp:Label ID="Label13" runat="server" Text="$" CssClass="ValorDestacado"></asp:Label></td>
                                        <td class="ValorDato">
                                            <asp:Label ID="lblAPETotal" runat="server" Text="0" CssClass="ValorDestacado"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="width: 50%"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label18" runat="server" Text="Franquicia histórica"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label19" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label20" runat="server" Text="Franquicia :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label21" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblFHfranquicia" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="lblSaldo1porcent" runat="server" Text="Saldo 1% a la fecha :"></asp:Label><asp:Label ID="lblExedido" runat="server"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="lblFHPorcfranq" runat="server" CssClass="IndicadorDoble" Text="0.0% "></asp:Label><asp:Label ID="Label24" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblFHsaldo1fecha" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label32" runat="server" Text="Aportes enterados"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label33" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato" style="height: 12px">
                                        <asp:Label ID="Label34" runat="server" Text="Aportes : "></asp:Label></td>
                                    <td class="Indicador" style="height: 12px">
                                        <asp:Label ID="Label35" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="height: 12px">
                                        <asp:Label ID="lblAEaportes" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato" style="height: 12px">
                                        <asp:Label ID="Label37" runat="server" Text="Administración :"></asp:Label></td>
                                    <td class="Indicador" style="height: 12px">
                                        <asp:Label ID="Label38" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="height: 12px">
                                        <asp:Label ID="lblAEadministracion" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label40" runat="server" Text="Total aportes neto :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label41" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblAEtotal" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                            <td valign="top" style="width: 50%"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label46" runat="server" Text="Gasto empresa"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label47" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label48" runat="server" Text="Capacitación :"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%">
                                        <asp:Label ID="Label49" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblGEcapacitacion" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label51" runat="server" Text="Excedentes de capacitación :"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%">
                                        <asp:Label ID="Label52" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblGEexCapacitacion" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label54" runat="server" Text="Terceros :"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%">
                                        <asp:Label ID="Label55" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblGEterceros" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label57" runat="server" Text="Total :"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%">
                                        <asp:Label ID="Label58" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblGEtotal" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label60" runat="server" Text="Cuenta de capacitación"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label61" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label62" runat="server" Text="Abonos por aportes :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label63" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="width: 20%">
                                        <asp:Label ID="lblCCabonosXaportes" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label65" runat="server" Text="Cursos propios pagados : "></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label66" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="width: 20%">
                                        <asp:Label ID="lblCCcursosPropios" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label68" runat="server" Text="[+V&T] Incluido en cursos propios :"></asp:Label></td>
                                    <td class="Indicador">
                                        </td>
                                    <td class="ValorDato" style="width: 20%">
                                        [<asp:Label ID="lblCCvtCursosPropios" runat="server" Text="0"></asp:Label>]</td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label71" runat="server" Text="V&T Disponible para el período :"></asp:Label></td>
                                    <td class="Indicador">
                                        </td>
                                    <td class="ValorDato" style="width: 20%">
                                        <asp:Label ID="lblCCvtDisponible" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato" style="height: 12px">
                                        <asp:Label ID="Label27" runat="server" Text="Saldo :"></asp:Label><asp:Label ID="lblCCDisponibleCap"
                                            runat="server" ForeColor="Blue" Text="(DISPONIBLE PARA TOMAR CURSOS)" Visible="False"></asp:Label></td>
                                    <td class="Indicador" style="height: 12px">
                                        <asp:Label ID="Label28" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="height: 12px; width: 20%;">
                                        <asp:Label ID="lblCCsaldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                            <td valign="top" style="width: 50%"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label74" runat="server" Text="Costo complementario estimado"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label75" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label76" runat="server" Text="Costo otic "></asp:Label><asp:Label
                                            ID="lblCCEagnoSig1" runat="server"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label77" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCCEcostoOtic" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label79" runat="server" Text="Gasto empresa "></asp:Label><asp:Label
                                            ID="lblCCEagnoSig2" runat="server"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label80" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCCEgastoEmpresa" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label82" runat="server" Text="Saldos de excedentes (cap + rep) :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label83" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCCEsaldoExcedentes" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label88" runat="server" Text="Cuenta de reparto"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label89" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato" style="height: 12px">
                                        <asp:Label ID="Label90" runat="server" Text="Abonos por aportes :"></asp:Label></td>
                                    <td class="Indicador" style="height: 12px">
                                        <asp:Label ID="Label91" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCRabonosXaporte" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label93" runat="server" Text="Cursos de terceros pagados :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label94" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="width: 20%">
                                        <asp:Label ID="lblCRcursosTerceros" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato" style="height: 12px">
                                        <asp:Label ID="Label96" runat="server" Text="Saldo :"></asp:Label></td>
                                    <td class="Indicador" style="height: 12px">
                                        <asp:Label ID="Label97" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCRsaldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                            <td rowspan="2" valign="top" style="width: 50%">
                                <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <th class="TituloIzquierda">
                                            <asp:Label ID="Label102" runat="server" Text="Estadísticas del período"></asp:Label></th>
                                        <th colspan="2" class="TituloDerecha">
                                            <asp:Label ID="Label103" runat="server" Text="Valor"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato">
                                            <asp:Label ID="Label104" runat="server" Text="Cantidad de cursos efectuados :"></asp:Label></td>
                                        <td class="Indicador">
                                            </td>
                                        <td class="ValorDato">
                                            <asp:Label ID="lblEPcantCursos" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato" style="height: 12px">
                                            <asp:Label ID="Label107" runat="server" Text="Alumnos capacitados :"></asp:Label></td>
                                        <td class="Indicador" style="height: 12px">
                                            </td>
                                        <td class="ValorDato" style="height: 12px">
                                            <asp:HyperLink ID="hplEPalumnosCapacitados" runat="server" NavigateUrl="reporte_alumnos.aspx">0</asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato">
                                            <asp:Label ID="Label110" runat="server" Text="HH de capacitación :"></asp:Label></td>
                                        <td class="Indicador">
                                            </td>
                                        <td class="ValorDato">
                                            <asp:Label ID="lblEPhhCapacitacion" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato">
                                            <asp:Label ID="Label113" runat="server" Text="Horas por participante :"></asp:Label></td>
                                        <td class="Indicador">
                                            </td>
                                        <td class="ValorDato">
                                            <asp:Label ID="lblEPhhParticipantes" runat="server" Text="0"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato">
                                            <asp:Label ID="Label30" runat="server" Text="Horas presenciales por participante :"></asp:Label></td>
                                        <td class="Indicador">
                                            </td>
                                        <td class="ValorDato">
                                            <asp:Label ID="lblEPhhPresenciales" runat="server" Text="0"></asp:Label>%</td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato">
                                            <asp:Label ID="Label44" runat="server" Text="Horas e-learning por participante :"></asp:Label></td>
                                        <td class="Indicador">
                                            </td>
                                        <td class="ValorDato">
                                            <asp:Label ID="lblEPhhElearning" runat="server" Text="0"></asp:Label>%</td>
                                    </tr>
                                    <tr>
                                        <td class="TituloDato" style="height: 12px">
                                            <asp:Label ID="Label86" runat="server" Text="Horas auto-instrucción por participante :"></asp:Label></td>
                                        <td class="Indicador" style="height: 12px">
                                            </td>
                                        <td class="ValorDato" style="height: 12px">
                                            <asp:Label ID="lblEPhhAutoInduccion" runat="server" Text="0"></asp:Label>%</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label116" runat="server" Text="Cursos no Sence"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label117" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label118" runat="server" Text="Cantidad de Cursos no Sence efectuados :"></asp:Label></td>
                                    <td class="Indicador">
                                        </td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCIcantCursosInternos" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label121" runat="server" Text="Total cursos no Sence (Activos) :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label122" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCItotalCursosInternos" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="CuentasPeriodoAnterior">
                    <table id="tablaPeriodoAnterior">
                        <tr>
                            <th colspan="2" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Excedentes del período anterior"></asp:Label></th>                            
                        </tr>
                        <tr>
                            <td valign="top" style="height: 116px"><table id="tablaCEC" runat="server" class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label14" runat="server" Text="Cuenta de excedente de capacitación"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label15" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label16" runat="server" Text="Abono por saldo :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label17" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCECAPabonoXsaldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label25" runat="server" Text="Cursos propios pagados :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label29" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCECAPsumCursosPropios" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr visible="false">
                                    <td class="TituloDato">
                                        <asp:Label ID="Label22" runat="server" Text="[+V&T] Incluido en Cursos propios:"></asp:Label></td>
                                    <td class="Indicador">
                                        </td>
                                    <td class="ValorDato">
                                        [<asp:Label ID="lblCECAPvtCursosPropios" runat="server" Text="0"></asp:Label>]</td>
                                </tr>
                                <tr visible="false">
                                    <td class="TituloDato" style="height: 12px">
                                        <asp:Label ID="Label39" runat="server" Text="V&T Disponible para el período :"></asp:Label>
                                    </td>
                                    <td class="Indicador" style="height: 12px">
                                        </td>
                                    <td class="ValorDato" style="height: 12px">
                                        <asp:Label ID="lblCECAPvtDisponible" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato" style="height: 12px">
                                        <asp:Label ID="Label50" runat="server" Text="Saldos :"></asp:Label></td>
                                    <td class="Indicador" style="height: 12px">
                                        <asp:Label ID="Label53" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="height: 12px">
                                        <asp:Label ID="lblCECAPsumSaldos" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                            <td valign="top" style="height: 116px"><table id="tablaCER" runat="server"  class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label100" runat="server" Text="Cuenta de excedente de reparto"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label101" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato" >
                                        <asp:Label ID="Label124" runat="server" Text="Abono por saldo :"></asp:Label></td>
                                    <td class="Indicador" >
                                        <asp:Label ID="Label125" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" >
                                        <asp:Label ID="lblCERsumAbonoXsaldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label127" runat="server" Text="Cursos de terceros pagados :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label128" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCERsumCursosTerceros" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr visible="false">
                                    <td class="TituloDato" style="height: 15px">
                                        <asp:Label ID="Label131" runat="server" Text="V&T Disponible para el período :"></asp:Label>
                                    </td>
                                    <td class="Indicador" style="height: 15px">
                                        </td>
                                    <td class="ValorDato" style="width: 20%; height: 15px;">
                                        <asp:Label ID="lblCERvtDisponible" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label130" runat="server" Text="Saldos :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label133" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="width: 20%">
                                        <asp:Label ID="lblCERsumSaldos" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <%--<tr>
                            <td valign="top"><table id="tablaCongelados2008" runat="server" class="TablasCuentas" cellpadding="0" cellspacing="0" visible="false">
                                <tr>
                                    <th colspan="3" class="DestacadoRojo">
                                        <asp:Label ID="Label150" runat="server" Text="Referencia de Exc. Congelados 2008 (Exc. Utilizado)"></asp:Label></th>
                                </tr>
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label136" runat="server" Text="Cuenta de Exc. Congelados 2008"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label137" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label138" runat="server" Text="Abono por saldo[Por Traspaso] :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label139" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCEC1abonoXsaldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label141" runat="server" Text="Cursos pagados :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label142" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCEC1cursosPagados" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label144" runat="server" Text="Saldo :"></asp:Label>
                                    </td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label145" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCEC1saldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                            <td valign="top"><table id="tablaCongelados2009" runat="server"  class="TablasCuentas" cellpadding="0" cellspacing="0" visible="false">
                                <tr>
                                    <th colspan="3" class="DestacadoVerde">
                                        <asp:Label ID="Label147" runat="server" Text="Referencia de Exc. Congelados 2009 (Exc. Actual)"></asp:Label></th>
                                </tr>
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label148" runat="server" Text="Cuenta de Exc. Congelados 2009 "></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label149" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label151" runat="server" Text="Abono por saldo[Por Traspaso] :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label152" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCEC2abonoXsaldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label154" runat="server" Text="Cursos pagados :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label155" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCEC2cursosPagados" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label157" runat="server" Text="Saldo (disponible para el período) :"></asp:Label>
                                    </td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label158" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCEC2saldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                        </tr>--%>
                    </table>
                </div>
                <%--<div id="BecasFinanciamientoOtic" runat="server">
                    <table id="tablaBecas">
                        <tr>
                            <th class="TituloGrupo" valign="top" style="height: 19px">
                                <asp:Label ID="Label43" runat="server" Text="Becas"></asp:Label>
                            </th>
                            <th class="TituloGrupo" valign="top" style="height: 19px">
                                <asp:Label ID="Label84" runat="server" Text="Imputaciones Especiales"></asp:Label>
                            </th>                           
                        </tr>
                        <tr>
                            <td valign="top"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label56" runat="server" Text="Cuenta de becas de capacitación (Excedentes año anterior)"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label59" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label64" runat="server" Text="Abono por saldo[Por aportes] :"></asp:Label></td>
                                    <td class="Indicador">
                                        &nbsp;<asp:Label ID="Label67" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="LblPorTra" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblCBCabonosXsaldo" runat="server" Text="0"></asp:Label></td>
                                </tr>
                               <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label73" runat="server" Text="Cursos complementarios pagados :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label78" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCBCcursosComplementarios" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato" style="height: 16px">
                                        <asp:Label ID="Label85" runat="server" Text="Saldo disponible para becas :"></asp:Label></td>
                                    <td class="Indicador" style="height: 16px">
                                        <asp:Label ID="Label92" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato" style="height: 16px">
                                        <asp:Label ID="lblCBCdisponible" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                            <td valign="top"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label98" runat="server" Text="Imputaciones Especiales Art.11 D.S.122"></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label99" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label106" runat="server" Text="Aporte a Imputaciones Especiales"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label109" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblFOaportefinanciamientoOtic" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="CuentasCongelados">
                    <table id="tablaCongelados" runat="server">
                        <tr>
                            <th colspan="2"  class="TituloGrupo" valign="top" style="height: 26px">
                                <asp:Label ID="Label3" runat="server" Text="Excedentes Congelados"></asp:Label></th>                            
                        </tr>
                        <tr>
                            <td valign="top"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda">
                                        <asp:Label ID="Label160" runat="server" Text="Cuenta de Excedentes Congelados "></asp:Label></th>
                                    <th colspan="2" class="TituloDerecha">
                                        <asp:Label ID="Label161" runat="server" Text="Valor"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label162" runat="server" Text="Saldo exc. congelados 2008 :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label163" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCECsaldo1" runat="server" Text="0"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="TituloDato">
                                        <asp:Label ID="Label165" runat="server" Text="Saldo exc. congelados 2009 :"></asp:Label></td>
                                    <td class="Indicador">
                                        <asp:Label ID="Label166" runat="server" Text="$"></asp:Label></td>
                                    <td class="ValorDato">
                                        <asp:Label ID="lblCECsaldo2" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                            </td>
                            <td valign="top">
                            </td>
                        </tr>
                    </table>
                </div>--%>
            </div>
            <div id="divAportePendiente" runat="server" visible="false" align="left">
                <asp:Label ID="Label3" runat="server" Text="Sírvase extender cheque nominativo y cruzado a nombre de la "></asp:Label>
                <asp:Label ID="lblNombreEmpresa" runat="server" Font-Bold="True"></asp:Label>
                <asp:Label ID="Label23" runat="server" Text=", por el monto de "></asp:Label>
                <asp:Label ID="lblAportePendienteTotal" runat="server" Font-Bold="True"></asp:Label>
                <asp:Label ID="Label26" runat="server" Text=".- asociado al saldo de las cuentas del período y su respectiva tasa de administración ("></asp:Label>
                <asp:Label ID="lblCostoAdm" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label31" runat="server" Text="%). "></asp:Label>
                <br />
                <asp:Label ID="Label36" runat="server" Text="Cualquier información adicional que requiera solicítela a su ejecutivo de cuentas en el teléfono del OTIC: "></asp:Label>
                <asp:Label ID="lblFonoEmpresa" runat="server" Text=""></asp:Label>
                .</div>
            <br />
            <br />
            <div class="AlineacionIzquierda" id="divAgno" runat="server" visible="false" >
                <asp:Label ID="Label56" runat="server" Text="RECORDAMOS a Usted que el monto adeudado debe ser enterado antes del 30 de Diciembre del "></asp:Label>
                <asp:Label ID="lblAgno" runat="server" Text=""></asp:Label>
            </div>
            <div style="background-color:silver" class="AlineacionCentro" >
                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
            </div>
        </div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>
    </div>    
    </form>
</body>
</html>