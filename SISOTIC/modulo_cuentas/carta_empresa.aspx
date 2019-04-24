<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carta_empresa.aspx.vb" Inherits="modulo_cursos_carta_empresa" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
    
      <link href="../estilo.css" rel="Stylesheet" media="all" type="text/css" />
      <asp:literal id="litEstilo" runat="server"></asp:literal>
       <script type="text/javascript" >
        function Imprimir()
        {
           window.print();
            return false;
        }
        function imprSelec(DivCarta)
        {
            var ficha=document.getElementById(DivCarta);
            var ventimp=window.open(' ','popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            var css = ventimp.document.createElement("link");
            css.setAttribute("href", "../estilo.css");
            css.setAttribute("rel", "Stylesheet");
            css.setAttribute("type", "text/css");
            ventimp.document.head.appendChild(css);
            ventimp.print();
            ventimp.close();
        }
      </script>
      <style media="print" type="text/css">
        #botones
        {
        display: none;
        }
      </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor"><div id="bannner">
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
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
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
                <li style="display: none;">
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
        <div id="DivCarta">
          <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="3" valign="top"  style="background-color:#21cfe8;" class="AlineacionIzquierda TituloGrupo">
                             <asp:Label ID="Label1" runat="server" Text="Orden de compra"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td id="tdTabla1">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="3" style="padding-left: 20px" align="left">
                                Sr(a).
                                <asp:Label ID="lblNombreContacto" runat="server"></asp:Label><br />
                                <asp:Label ID="lblCargoContacto" runat="server"></asp:Label><br />
                                <asp:Label ID="lblRazonSocial" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td id="tdTabla2" align="right">
                    <table cellpadding="0" cellspacing="0" width="300">
                        <tr>
                            <td colspan="3" align="left">
                                Orden de compra</td>
                            <td class="DosPuntos" style="width: 2%">
                                :</td>
                            <td style="width: 20%" align="left">
                                <asp:Label ID="lblCorrelativo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                         <td colspan="3" align="left">
                             id/registro Sence</td>
                            <td class="DosPuntos" style="width: 2%">
                                :</td>
                            <td style="width: 20%" align="left">
                                <asp:Label ID="lblCorrelativoEmpresa" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left">
                                Estado Curso</td>
                            <td class="DosPuntos" style="width: 2%">
                                :</td>
                            <td style="width: 20%" align="left">
                                <asp:Label ID="lblEstadoCurso" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </td>
                <td id="tdTabla3" rowspan="1">
               <%--<img src="../include/imagenes/css/fondos/reporte06.jpg" alt="Otic Asimet" title="Otic"/>--%>
                    &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/include/imagenes/css/fondos/reporte06.jpg"
                        Width="164px" /></td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 20px" align="left">
                    De mi consideración:
                    <br />
                    A través del presente documento informo a usted que de acuerdo a sus instrucciones,
                    hemos contratado para su empresa el curso que se detalla a continuación:</td>
            </tr>
        </table>       
    <div id="Alumnos" style="width: 95%">
  
        <table width="100%">
            <tbody>
                <tr>
                    <td  valign="top" colspan="2" style="background-color:#21cfe8;" class="AlineacionIzquierda TituloGrupo">
                        <asp:Label id="Label2" runat="server" Text="Curso inscrito"></asp:Label> 
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" valign="top" align="right">
                    <table class="TablaDatosOTEC" cellspacing="0" cellpadding="0">
                    <tbody>
                    <tr>
                    <td valign="top" colspan="3" align="left" style="background-color:#bfbfbf" class="TituloVerde">
                    <asp:Label id="Label3" runat="server" Text="Datos del curso" Font-Size="15px" ForeColor="White"></asp:Label> 
                    </td>
                    </tr>
                    <tr>
                    <td style="WIDth: 25%" align="left">
                    <asp:Label id="Label4" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td style="WIDth: 2%" class="DosPuntos">:</td>
                    <td align="left">
                    <asp:Label id="lblTNombre" runat="server"></asp:Label>
                    </td>
                    </tr>
                         <tr>
        <td style="width: 25%" align="left">
            <asp:Label ID="Label40" runat="server" Text="Modalidad"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%; height: 16px">
            :</td>
        <td style="height: 16px" align="left">
            <asp:Label ID="lblModalidad" runat="server" Font-Bold="true"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 25%" align="left">
            <asp:Label id="Label5" runat="server" Text="Correlativo"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%; height: 16px">
            :</td>
        <td style="height: 16px" align="left">
            <asp:Label id="lblTCorrelativo" runat="server"></asp:Label></td>
    </tr>
    <tr><td style="WIDth: 25%" align="left"><asp:Label id="Label6" runat="server" Text="Fecha inicio"></asp:Label></td><td 
style="WIDth: 2%" class="DosPuntos">:</td><td align="left"><asp:Label id="lblTFechaInicio" runat="server"></asp:Label></td></tr>
    <tr>
        <td style="width: 25%" align="left">
            <asp:Label id="Label7" runat="server" Text="Fecha término"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%">
            :</td>
        <td align="left">
            <asp:Label id="lblTFechaTermino" runat="server"></asp:Label></td>
    </tr>
    <tr><td style="WIDth: 25%" align="left"><asp:Label id="Label8" runat="server" Text="Duración"></asp:Label></td><td 
style="WIDth: 2%; HEIGHT: 12px" class="DosPuntos">:</td><td style="HEIGHT: 12px" align="left"><asp:Label id="lbltduracion" runat="server"></asp:Label> 
hrs. (<asp:Label id="lblthoras" runat="server"></asp:Label> 
hrs. complementarias)</td></tr><tr><td 
style="WIDth: 25%" align="left"><asp:Label id="Label9" runat="server" Text="Código SENCE"></asp:Label></td><td 
style="WIDth: 2%; HEIGHT: 12px" class="DosPuntos">:</td><td style="HEIGHT: 12px" align="left"><asp:Label id="lblTCodSence" runat="server"></asp:Label></td></tr>
    <tr>
        <td style="width: 25%" align="left">
            <asp:Label ID="Label42" runat="server" Text="Nº Registro SENCE"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%; height: 12px">
            :</td>
        <td style="height: 12px" align="left">
            <asp:Label ID="lblNumRegistro" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 25%" align="left">
            <asp:Label ID="Label41" runat="server" Text="Lugar ejecución"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%; height: 12px">
            :</td>
        <td style="height: 12px" align="left">
            <asp:Label ID="lblCursoDirecc" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblNroDireccionCurso" runat="server"></asp:Label>
            -
            <asp:Label ID="lblComuna" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 25%" align="left">
            <asp:Label ID="Label24" runat="server" Text="Organismo ejecutor"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%; height: 12px">
            :</td>
        <td style="height: 12px" align="left">
            <asp:Label ID="lblTOtecRazonsocial" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 25%" align="left">
            <asp:Label ID="Label26" runat="server" Text="Total de participantes"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%; height: 12px">
            :</td>
        <td style="height: 12px" align="left">
            <asp:Label ID="lblTotalParticipantes" runat="server"></asp:Label></td>
    </tr>
    <tr><td style="WIDth: 25%" align="left"><asp:Label id="Label10" runat="server" Text="Comité bipartito"></asp:Label></td><td 
style="WIDth: 2%" class="DosPuntos">:</td><td align="left"><asp:Label id="lblTBipartito" runat="server"></asp:Label></td></tr><tr><td style="WIDth: 25%; height: 19px;" align="left"><asp:Label id="Label18" runat="server" Text="Observación " Font-Bold="False"></asp:Label></td><td 
style="WIDth: 2%; height: 19px;" class="DosPuntos">:</td><td style="height: 19px" align="left">
<asp:Label id="lblObservacion" runat="server"></asp:Label>
    </td></tr>
                        <tr>
                            <td align="left" style="width: 25%; height: 19px">
                                <asp:Label ID="strValorHoraSenceTit" runat="server" Font-Bold="False" Text="Valor Hora Sence"></asp:Label></td>
                            <td class="DosPuntos" style="width: 2%; height: 19px">
                                :</td>
                            <td align="left" style="height: 19px">
                                <asp:Label ID="lblValorHoraSence" runat="server"></asp:Label></td>
                        </tr>
                    </tbody></table></td><td align="left" valign="top"><table class="TablaDatosOTEC" cellspacing="0" 
cellpadding="0"><tbody><tr><td valign="top" colspan="3" align="left" style="background-color:#bfbfbf" class="TituloVerde">
<asp:Label id="Label12" runat="server" Text="Valores asociados" Font-Size="15px" ForeColor="White"></asp:Label> 
</td></tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label11" runat="server" Text="Valor curso"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%">
            :</td>
        <td class="AlineacionDerecha">
            <asp:Label ID="lblTValorCurso" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td style="height: 12px" align="left">
            <asp:Label ID="Label25" runat="server" Text="Costo OTIC"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%; height: 12px">
            :</td>
        <td style="height: 12px" class="AlineacionDerecha">
            <asp:Label ID="lblTCostoOtic" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label27" runat="server" Text="Costo OTIC complemento"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%">
            :</td>
        <td class="AlineacionDerecha">
            <asp:Label ID="lblTCostoOticCom" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label28" runat="server" Text="Costo empresa"></asp:Label></td>
        <td class="DosPuntos" style="width: 2%">
            :</td>
        <td class="AlineacionDerecha">
            <asp:Label ID="lblTCostoEmpresa" runat="server"></asp:Label></td>
    </tr>
    <tr><td style="height: 16px" align="left"><asp:Label id="Label14" runat="server" Text="Total V&T"></asp:Label></td><td 
style="WIDth: 2%; height: 16px;" class="DosPuntos">:</td><td style="height: 16px" class="AlineacionDerecha"><asp:Label id="lblTotalVyT" runat="server"></asp:Label></td></tr><tr><td style="HEIGHT: 12px" align="left"><asp:Label id="Label15" runat="server" Text="Costo OTIC V&T"></asp:Label></td><td 
style="WIDth: 2%; HEIGHT: 12px" class="DosPuntos">:</td><td style="HEIGHT: 12px" class="AlineacionDerecha"><asp:Label id="lblTCostoOticVyT" runat="server"></asp:Label></td></tr><tr><td align="left"><asp:Label id="Label16" runat="server" Text="Costo empresa V&T"></asp:Label></td><td 
style="WIDth: 2%" class="DosPuntos">:</td><td class="AlineacionDerecha"><asp:Label id="lblTCostoEmpVyT" runat="server"></asp:Label></td></tr></tbody>
</table></td></tr>
<%--<tr><td align="left">
<table class="TablaDatosOTEC" cellspacing="0" cellpadding="0"><tbody><tr><td valign="top" colspan="3" align="left" style="background-color:#bfbfbf" >
<asp:Label id="Label13" runat="server" Text="Facturación" Font-Size="15px" ForeColor="White"></asp:Label> 
</td></tr><tr><td align="left"><asp:Label id="Label17" runat="server" Text="Cuenta de capacitación"></asp:Label> </td><td 
style="WIDth: 2%">:</td><td 
class="AlineacionDerecha"><asp:Label id="lblTCapacitacion" runat="server"></asp:Label></td></tr><tr><td align="left"><asp:Label id="Label21" runat="server" Text="Excedente de capacitación"></asp:Label></td><td 
style="WIDth: 2%;">:</td><td 
class="AlineacionDerecha"><asp:Label id="lblTExcCapacitacion" runat="server"></asp:Label></td></tr><tr><td style="HEIGHT: 12px" align="left"><asp:Label id="Label22" runat="server" Text="Becas de capacitación"></asp:Label></td><td 
style="WIDth: 2%">:</td><td 
style="HEIGHT: 12px" class="AlineacionDerecha"><asp:Label id="lblTBecas" runat="server"></asp:Label></td></tr><tr><td style="HEIGHT: 12px" align="left"><asp:Label id="Label23" runat="server" Text="Cuentas de terceros"></asp:Label> </td><td 
style="WIDth: 2%; HEIGHT: 12px">:</td><td
style="HEIGHT: 12px" class="AlineacionDerecha"><asp:Label id="lblTerceros" runat="server"></asp:Label></td></tr>
    <tr>
        <td style="height: 12px" align="left">
        </td>
        <td style="width: 2%; height: 12px">
        </td>
        <td class="AlineacionDerecha" style="height: 12px">
            <asp:Label ID="Label29" runat="server" Font-Bold="true" Text="* Incluyen viáticos y traslados"></asp:Label></td>
    </tr>
</tbody>
</table>
</td></tr>--%>
</tbody></table>
    <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="background-color:#21cfe8;" class="AlineacionIzquierda TituloGrupo">
                    <asp:Label ID="Label43" runat="server" Text="Horario curso"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table id="table1" runat="server" cellpadding="0" cellspacing="0" align="center" class="GridOC"  >
                        <tr>
                            <th style="width: 140px">
                                Lunes
                            </th>
                            <th style="width: 140px">
                                Martes
                            </th>
                            <th style="width: 140px">
                                Miércoles
                            </th>
                            <th style="width: 140px">
                                Jueves
                             </th>
                            <th style="width: 140px">
                                Viernes
                             </th>
                            <th style="width: 140px">
                                Sábado
                            </th>
                            <th style="width: 140px">
                                Domingo
                            </th>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblLunes" runat="server" Text=" "></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblMartes" runat="server" Text=" "></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblMiercoles" runat="server" Text=" "></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblJueves" runat="server" Text=" "></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblViernes" runat="server" Text=" "></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblSabado" runat="server" Text=" "></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lblDomingo" runat="server" Text=" "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table id="TablaTexto"><tbody><tr><td style="padding-left: 20px" align="left">
    En la siguiente tabla se presenta el listado de alumnos que se inscribieron en el
    curso, de acuerdo a la información proporcionada por usted:</td></tr></tbody></table>
        <table>
        <tr>
         <th width="970px" valign="top" style="background-color:#21cfe8;" class="AlineacionIzquierda TituloGrupo">
            <asp:Label ID="Label19" runat="server" Text="Listado de alumnos"></asp:Label>
         </th>
        </tr>
        <tr>
            <td align="center">
            <asp:GridView ID="grdListadoAlumnos" runat="server" AutoGenerateColumns="False" CssClass="GridOC" Width="100%">
                <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td valign="top" class="AlineacionIzquierda">
                                    <asp:Label ID="lblContador" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" Width="10px" />
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Datos alumno">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="200">
                                <tr>
                                    <td class="AlineacionIzquierda" title="width:50px">
                                        <asp:Label ID="lblNombreAlum" runat="server" Text='<%# Bind("nombre_completo") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" title="width:50px">
                                        <asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut_alumno") %>'></asp:Label></td>
                                </tr>
                            </table>
                            &nbsp;
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Height="0px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Franquicia">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 70px" valign="top">
                                        <asp:Label ID="Label20" runat="server" Text="Franquicia"></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 100px" class="AlineacionDerecha">
                            <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label>%</td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 70px" valign="top">
                                        <asp:Label ID="Label30" runat="server" Text="Sexo"></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 70px" valign="top">
                                        <asp:Label ID="Label31" runat="server" Text="Fecha nac."></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lblFechNac" runat="server" Text='<%# Bind("fecha_nacim") %>'></asp:Label></td>
                                </tr>
                            </table>
                            &nbsp;
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Height="0px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Costo OTIC">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 85px" valign="top">
                                        <asp:Label ID="Label32" runat="server" Text="Costo OTIC"></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lblCostoOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 85px" valign="top">
                                        <asp:Label ID="Label33" runat="server" Text="Costo emp."></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lblCostoEmp" runat="server" Text='<%# Bind("gasto_empresa") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 85px" valign="top">
                                        <asp:Label ID="Label34" runat="server" Text="Total"></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                            &nbsp;
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Height="0px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="V &amp; T">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td style="width: 60px" class="AlineacionIzquierda" valign="top">
                                        <asp:Label ID="Label38" runat="server" Text="Viático"></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 60px" valign="top">
                                        <asp:Label ID="Label37" runat="server" Text="traslado"></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lbltraslado" runat="server" Text='<%# Bind("traslado") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 60px" valign="top">
                                        <asp:Label ID="Label44" runat="server" Text="Total Vyt"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 100px">
                                        <asp:Label ID="lblTotalVyT" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Height="0px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td style="width: 82px" class="AlineacionIzquierda" valign="top">
                                        <asp:Label ID="Label35" runat="server" Text="Nivel educ."></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 190px">
                                        <asp:Label ID="lblNivEduc" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 82px" valign="top">
                                        <asp:Label ID="Label36" runat="server" Text="Nivel prof."></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 190px">
                                        <asp:Label ID="lblNivProf" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 82px" valign="top">
                                        <asp:Label ID="Label39" runat="server" Text="Origen"></asp:Label></td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 190px">
                                        <asp:Label ID="lblOrigen" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Height="0px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </td>
        </tr>
        </table>
        <table id="TablaCartaFooter">
            <tr>
                <td>
                    Quedando a su entera disposición para aclarar cualquier duda,<br />
                        <br />
                    Saluda atentamente a usted.<br />
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/contenido/imagenes/empresa/firma_gerente.png" Width="180px" Height="105px" />
                    <asp:Label ID="lblOtic" runat="server" Font-Bold="True" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        </div>
       </div>
       <div id="botones">
            <asp:HyperLink ID="hplGenerar" runat="server" Visible="False">[hplGenerar]</asp:HyperLink><br />
            <asp:CheckBox ID="chkGenerar" runat="server" Text="Generar HTML" ValidationGroup="xx" Visible="False" />&nbsp;
            <br />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" />
            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
            <asp:Button ID="btnGenerar" runat="server" Text="Generar " ValidationGroup="xx" Visible="False" />
            <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" />
            <asp:Button ID="btnCartaExcel" runat="server" Text="Generar EXCEL" /><br />
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