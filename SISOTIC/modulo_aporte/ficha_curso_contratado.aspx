<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_curso_contratado.aspx.vb" Inherits="Reportes_Ficha_curso_contratado" EnableEventValidation="false" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="../contenido/ascx/cabeceraCurso.ascx" TagName="cabecera" TagPrefix="uc1" %>
<%@ Register Src="../contenido/ascx/cabeceraCurso.ascx" TagName="cabecera1" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Consola de Administración de Aportes</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
        
        function redireccionar()
        {
            window.location.href = "../modulo_cursos/buscador_cursos.aspx"
            return false;
        }
        function imprSelec(Carta)
        {
            var ficha=document.getElementById(Carta);
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

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
    <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label43" runat="server" Text="Ficha de Curso Contratado"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
         <div id="contenido">
            <div id="Carta" runat="server">
            <div id="resultados">
                <div id="CuentasPeriodoActual">
                <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                <tr>
                    <td class="AlineacionDerecha" style="width: 13%">
                        <asp:Label ID="Label38" runat="server" Font-Bold="False" Text="Correlativo"></asp:Label></td>
                    <td style="width: 2%">
                        :</td>
                    <td class="AlineacionIzquierda" style="width: 23%">
                        <asp:Label ID="lblCorrelativo" runat="server" Font-Bold="True"></asp:Label></td>
                    <td class="AlineacionDerecha" style="width: 10%">
                        <asp:Label ID="Label44" runat="server" Text="Estado actual"></asp:Label></td>
                    <td style="width: 2%">
                        :</td>
                    <td class="AlineacionIzquierda" style="width: 10%">
                        <asp:HyperLink ID="hplEstado" runat="server">[hplEstado]</asp:HyperLink></td>
                    <td class="AlineacionDerecha" style="width: 10%">
                        </td>
                    <td style="width: 1%">
                        </td>
                    <td class="AlineacionIzquierda" style="width: 11%">
                        </td>
                    <td class="AlineacionDerecha" style="width: 12%">
                        <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="NºReg. SENCE"></asp:Label></td>
                    <td style="width: 2%">
                        :</td>
                    <td class="AlineacionIzquierda" style="width: 10%">
                        <asp:Label ID="lblRegSence" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td class="AlineacionDerecha" style="width: 13%">
                        <asp:Label ID="Label57" runat="server" Text="FECHA ÚLTIMA ACTUALIZACIÓN" Width="140px"></asp:Label></td>
                    <td style="width: 2%">
                        :</td>
                    <td class="AlineacionIzquierda" style="width: 23%" >
                        <asp:Label ID="lblFecha" runat="server"></asp:Label></td>
                    <td class="AlineacionDerecha" style="width: 10%">
                        <asp:Label ID="Label59" runat="server" Text="Fecha ingreso"></asp:Label></td>
                    <td style="width: 2%">
                        :</td>
                    <td class="AlineacionIzquierda" style="width: 10%">
                        <asp:Label ID="lblFechIngreso" runat="server"></asp:Label></td>
                    <td class="AlineacionDerecha" style="width: 10%">
                        </td>
                    <td style="width: 1%">
                        </td>
                    <td class="AlineacionIzquierda" style="width: 11%">
                        </td>
                    <td class="AlineacionDerecha" style="width: 12%">
                        <asp:Label ID="Label62" runat="server" Text="Correlativo Compl."></asp:Label></td>
                    <td style="width: 2%">
                        :</td>
                    <td class="AlineacionIzquierda" style="width: 10%">
                        <asp:Label ID="lblCorrelCompl" runat="server" Text="-"></asp:Label></td>
                </tr>
            </table>
                    <table id="tablaPeriodoActual">
                        <tr>
                            <td valign="top" style="height: 93px; width: 50%;">
                                <table class="TablasCuentas" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <th class="TituloIzquierda" colspan="3">
                                            <asp:Label ID="Label4" runat="server" Text="Datos de la Empresa"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 7px;" colspan="3">
                                            <asp:HyperLink ID="hplDErazonSocial" runat="server">Razon Social</asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 12px;" colspan="3">
                                            <asp:Label ID="lblDErutEmpresa" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                            <asp:Label ID="Label54" runat="server" Text="DIRECCIÓN :"></asp:Label>
                                            <asp:Label ID="lblDireccionEmpresa" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 12px;" colspan="3">
                                            <asp:Label ID="Label8" runat="server" Text="Contacto: "></asp:Label>
                                            <asp:Label ID="lblDEContacto" runat="server"></asp:Label>
                                            <asp:Label ID="Label5" runat="server" Text=", "></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text="Cargo:"></asp:Label>
                                            <asp:Label ID="lblDEcargo" runat="server" Text="Label"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="height: 4px;" colspan="3">
                                            <asp:Label ID="Label2" runat="server" Text="Fono: "></asp:Label>
                                            <asp:Label ID="lblDEfono" runat="server" Text="Label"></asp:Label>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="AlineacionIzquierda" style="height: 4px;" colspan="3">
                                            <asp:Label ID="Label10" runat="server" Text="email: "></asp:Label>
                                            <asp:HyperLink ID="hplDEemail" runat="server">HyperLink</asp:HyperLink></td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="height: 93px"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="Label18" runat="server" Text="Datos del OTEC"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px;" colspan="3">
                                        <asp:HyperLink ID="hplDOrazonSocial" runat="server">HyperLink</asp:HyperLink></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px" colspan="3">
                                        <asp:Label ID="Label3" runat="server" Text="Rut: "></asp:Label>
                                        <asp:Label ID="lblDOrutOtec" runat="server"></asp:Label></td>
                                        
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px" colspan="3">
                                        <asp:Label ID="Label12" runat="server" Text="Contacto: "></asp:Label>
                                        <asp:Label ID="lblDOcontacto" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="Label15" runat="server" Text=", "></asp:Label>
                                        <asp:Label ID="Label16" runat="server" Text="Cargo: "></asp:Label>
                                        <asp:Label ID="lblDOcargo" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px" colspan="3">
                                        <asp:Label ID="Label19" runat="server" Text="Fono: "></asp:Label>
                                        <asp:Label ID="lblDOfono" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="Label21" runat="server" Text=" - "></asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px" colspan="3">
                                        <asp:Label ID="Label24" runat="server" Text="email: "></asp:Label>
                                        <asp:HyperLink ID="hplDOemail" runat="server">HyperLink</asp:HyperLink></td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="width: 50%; height: 113px;">
                                <table cellpadding="0" cellspacing="0" class="TablasCuentas">
                                    <tr>
                                        <th class="AlineacionIzquierda" colspan="3">
                                            &nbsp;<asp:Label ID="Label14" runat="server" Text="Curso"></asp:Label></th>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                            <asp:HyperLink ID="hplCUnombreCurso" runat="server">HyperLink</asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                            <asp:Label ID="Label49" runat="server" Text="CORRELATIVO EMPRESA: "></asp:Label>
                                            <asp:Label ID="lblCorrelativoEmpresa" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3">
                                            <asp:Label ID="Label23" runat="server" Text="Código SENCE: "></asp:Label>
                                            <asp:Label ID="lblCUcodigosence" runat="server" Text="Label"></asp:Label>
                                            <asp:Label ID="Label13" runat="server" Text=" - "></asp:Label>
                                            <asp:Label ID="Label17" runat="server" Text="Horas: "></asp:Label>
                                            <asp:Label ID="lblCUhoras" runat="server" Text="Label"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text=" - "></asp:Label>
                                            <asp:Label ID="lblModalidad" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                            <asp:Label ID="Label11" runat="server" Text="Lugar de ejecución: "></asp:Label>
                                            <asp:Label ID="lblCUdireccion" runat="server" Text="Label"></asp:Label>
                                            <asp:Label ID="lblCUnumero" runat="server" Text="Label"></asp:Label>
                                       <%--<asp:Label ID="lblCUnumero" runat="server" Text="Label"></asp:Label>--%>
                                            <asp:Label ID="Label26" runat="server" Text="("></asp:Label><asp:Label ID="lblCUciudad"
                                                runat="server" Text="Label"></asp:Label><asp:Label ID="Label28" runat="server" Text=")"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3">
                                            <asp:Label ID="lblCUregion" runat="server" Text="Label"></asp:Label>&nbsp;
                                            <asp:Label ID="lblCUcomuna" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3">
                                            <asp:Label ID="Label27" runat="server" Text="Fecha de Inicio: "></asp:Label>
                                            <asp:Label ID="lblCUfechaInicio" runat="server" Text="Label"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                            <asp:Label ID="Label29" runat="server" Text="Fecha Término: "></asp:Label>
                                            <asp:Label ID="lblCUfechaTermino" runat="server" Text="Label"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                            <asp:Label ID="Label64" runat="server" Text="Observación:"></asp:Label>
                                            <asp:Label ID="lblObservacion" runat="server" Text="Label"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                <asp:HyperLink ID="hplCUverInformacionElearning" runat="server">Ver Información de curso E-Learning</asp:HyperLink></td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="height: 113px">
                            <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="AlineacionIzquierda" colspan="6">
                                        <asp:Label ID="Label46" runat="server" Text="Costo"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        <asp:HyperLink ID="hplCOnumParticipantes" runat="server">Nº Participantes: </asp:HyperLink></td>
                                    <td class="AlineacionDerecha" style="width: 4%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCOnumParticipantes" runat="server" Text="label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 2%; height: 12px">
                                    </td>
                                    <td class="AlineacionIzquierda" style="width: 29%; height: 12px">
                                        <asp:Label ID="Label47" runat="server" Text="VBº Comité Bipartito: "></asp:Label>
                                        &nbsp; &nbsp;</td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        &nbsp; &nbsp;<asp:Label ID="lblCOcomiteBipartito" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px; width: 31%;" >
                                        <asp:Label ID="Label25" runat="server" Text="Valor Curso: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 4%; height: 12px">
                                        <asp:Label ID="Label32" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCOvalorCurso" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 2%; height: 12px">
                                    </td>
                                    <td class="AlineacionIzquierda" style="width: 29%; height: 12px">
                                        <asp:Label ID="Label48" runat="server" Text="Detección necesidades: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblCOdetencionNecesidad" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px;">
                                        <asp:Label ID="Label30" runat="server" Text="Total Viático: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 4%; height: 12px;">
                                        <asp:Label ID="Label34" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 20%; height: 12px;">
                                        <asp:Label ID="lblCOtotalviatico" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 2%; height: 12px">
                                    </td>
                                    <td class="AlineacionIzquierda" style="width: 29%; height: 12px">
                                        <asp:Label ID="Label42" runat="server" Text="Pre Contrato: "></asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblCOpreContrato" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 16px" >
                                        <asp:Label ID="Label31" runat="server" Text="Total Traslado: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 4%; height: 16px">
                                        <asp:Label ID="Label33" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 20%; height: 16px">
                                        <asp:Label ID="lblCOtotalTraslado" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 2%; height: 16px">
                                    </td>
                                    <td class="AlineacionIzquierda" style="width: 29%; height: 16px">
                                        <asp:Label ID="Label50" runat="server" Text="Post contrato: "></asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                                    <td class="AlineacionDerecha" style="height: 16px">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblCOposContrato" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        <asp:Label ID="Label51" runat="server" Text="Porc. Administración: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 4%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCOporcAdmin" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="Label35" runat="server" Text="%"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 2%; height: 12px">
                                    </td>
                                    <td class="AlineacionIzquierda" colspan="1" style="height: 16px; width: 29%;">
                                        <asp:Label ID="Label67" runat="server" Text="Nº Factura:"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 16px" colspan="2">
                                        <asp:Label ID="lblNumFactura" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                               
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="width: 50%; height: 105px">
                            <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="AlineacionIzquierda" colspan="7">
                                        <asp:Label ID="Label36" runat="server" Text="Curso Parcial"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        &nbsp;</td>
                                    <td class="TituloIzquierdo" style="width: 9%; height: 12px">
                                    </td>
                                    <td class="TituloIzquierdo" style="width: 15%; height: 12px">
                                    </td>
                                    <td class="TituloIzquierdo" style="width: 9%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="Label37" runat="server" Text="V&T" Font-Bold="True"></asp:Label></td>
                                    <td class="TituloIzquierdo" style="width: 8%; height: 12px">
                                        </td>
                                    <td class="AlineacionDerecha" style="height: 12px; width: 27%;">
                                        <asp:Label ID="Label39" runat="server" Text="Total" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px; width: 31%;" >
                                        <asp:Label ID="Label40" runat="server" Text="Costo OTIC: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label45" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPcostoOtic" runat="server" Text="Label" CssClass="AlineacionDerecha"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label85" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPcostoOticVyT" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 12px">
                                        <asp:Label ID="Label53" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px; width: 27%;">
                                        <asp:Label ID="lblCPtotalCostoOtic" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px;">
                                        <asp:Label ID="Label55" runat="server" Text="Gasto Empresa: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px;">
                                        <asp:Label ID="Label56" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPgastoEmpresa" runat="server" Text="Label" CssClass="AlineacionDerecha"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label86" runat="server" Height="16px" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px;">
                                        <asp:Label ID="lblCPgastoEmpresaVyT" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 12px">
                                        <asp:Label ID="Label58" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px; width: 27%;">
                                        <asp:Label ID="lblCPTotalGastoEmpresa" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr id="trAdministacion" runat="server">
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 16px" >
                                        <asp:Label ID="Label60" runat="server" Text="Costo Admin: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 16px">
                                        <asp:Label ID="Label61" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 16px">
                                        <asp:Label ID="lblCPCostoAdmin" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 16px">
                                        <asp:Label ID="Label87" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 16px">
                                        <asp:Label ID="lblCPcostoAdminVyT" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 16px">
                                        <asp:Label ID="Label63" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 16px; width: 27%;">
                                        <asp:Label ID="lblCPTotalCostoAdmin" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        <asp:Label ID="Label65" runat="server" Text="Horas: "></asp:Label></td>
                                    <td class="TituloIzquierdo" style="width: 9%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPhoras" runat="server" Text="Label"></asp:Label></td>
                                    <td class="TituloIzquierdo" style="width: 9%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="Label66" runat="server" Text="-"></asp:Label>
                                        </td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="height: 12px; width: 27%;">
                                        <asp:Label ID="Label20" runat="server" Text="-"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px" colspan="7">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        <asp:Label ID="Label72" runat="server" Text="Cuenta de Cap.: "></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label77" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPcuentaCap" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label88" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPTotalesCuentaCapVyT" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 12px">
                                        <asp:Label ID="Label94" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 27%; height: 12px">
                                        <asp:Label ID="lblCPtotalCuentaCapacitacion" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        <asp:Label ID="Label73" runat="server" Text="Cuenta de exc. cap.:"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label78" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPcuentaExcCap" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label89" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPTotalesCuentaExcCapVyT" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 12px">
                                        <asp:Label ID="Label95" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 27%; height: 12px">
                                        <asp:Label ID="lblCPtotalCuentaExcCapacitacion" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        <asp:Label ID="Label75" runat="server" Text="Cuenta de becas:"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label79" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPcuentaBecas" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="Label92" runat="server" Text="-"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 27%; height: 12px">
                                        <asp:Label ID="Label98" runat="server" Text="-"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                <asp:HyperLink ID="hplCPcuentaTerceros" runat="server">Cuentas de terceros:</asp:HyperLink>
                                        <asp:Label ID="lblCPcuentaDeterceros" runat="server" Text="Cuentas de terceros: "></asp:Label>
                                        </td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                        <asp:Label ID="Label80" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="lblCPcuentaTerceros" runat="server" Text="Label"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 9%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 15%; height: 12px">
                                        <asp:Label ID="Label93" runat="server" Text="-"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 8%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 27%; height: 12px">
                                        <asp:Label ID="Label41" runat="server" Text="-"></asp:Label></td>
                                </tr>
                               
                            </table>
                                </td>
                            <td valign="top" style="height: 105px">
                            <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="Label74" runat="server" Text="Curso complementario"></asp:Label></th>
                                </tr>
                                <tr id="Tr1" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCCesComplementario" runat="server" Text="ESTE CURSO ES COMPLEMENTARIO"></asp:Label>
                                        <asp:Label ID="lblCCnoEsComplementario" runat="server" Text="NO TIENE COMPLEMENTARIO "></asp:Label>
                                        <asp:Label ID="lblCCoticEstimado" runat="server" Text="Costo OTIC Estimado:"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCCpeso1" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCcostoOticEstimado" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr id="Tr2" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCCgEmpresa" runat="server" Text="Gasto Empresa:"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCCpeso2" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCgastoEmpresa" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr id="Tr3" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCCcAdmin" runat="server" Text="Costo Admin:"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCCpeso3" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCcostoAdmin" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr id="tr4" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCChora" runat="server" Text="Horas: "></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px" >
                                        </td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCChoras" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr id="tr5" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 12px">
                                        <asp:HyperLink ID="hplCCfichaCursoParcial" runat="server">Ficha Curso Parcial</asp:HyperLink></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        </td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        </td>
                                </tr>
                                <tr id="tr6" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCClistadoCursoCompl" runat="server" Text="Estado Curso Complementario: "></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        </td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCestadoCursoComp" runat="server" Text="-"></asp:Label></td>
                                </tr>
                                <tr id="tr7" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 12px">
                                        <asp:HyperLink ID="hplCCFichaCursoCompl" runat="server">Ficha Curso Complementario   </asp:HyperLink></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                    </td>
                                    <td class="ValorDato" style="height: 12px">
                                        </td>
                                </tr>
                                <tr id="tr8" runat="server">
                                    <td class="AlineacionIzquierda" colspan="3" style="height: 12px">
                                    </td>
                                </tr>
                                <tr id="tr9" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 16px">
                                        </td>
                                    <td class="Indicador" style="width: 20%; height: 16px;">
                                        </td>
                                    <td class="ValorDato" style="height: 16px">
                                        </td>
                                </tr>
                                <tr id="tr10" runat="server">
                                    <td class="AlineacionIzquierda" style="height: 16px">
                                        </td>
                                    <td class="Indicador" style="width: 20%; height: 16px;">
                                        </td>
                                    <td class="ValorDato" style="height: 16px">
                                        </td>
                                </tr>
                            </table>
                          </table>
                            </div>
                             </div>
                            </div>
                          <table class="TablaInterior">
                            <tr>
                            <td class="Alineacionderecha" colspan="2" style="height: 15px" valign="top">
                                comentarios:<br />
                                <asp:TextBox ID="txtComentarios" runat="server" Height="96px" Width="948px" TextMode="MultiLine"></asp:TextBox>
                                <asp:Button ID="btnAgregaComentario" runat="server" Text="agregar comentario" /><br />
                                <br />
                                <asp:GridView ID="grdComentarios" runat="server"  CssClass="Grid" AutoGenerateColumns="False" OnRowDataBound="grdComentarios_RowDataBound" Width="948px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Usuario">
                                            <ItemTemplate>
                                                <div class="AlineacionIzquierda">
                                                    <asp:Label ID="lblNombreUsuario" runat="server" Text='<%# bind("nombres") %>'></asp:Label></div>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha">
                                        <ItemTemplate>
                                                <div class="AlineacionIzquierda">
                                                    <asp:Label ID="lblFecha" runat="server" Text='<%# bind("fecha") %>'></asp:Label></div>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comentario">
                                        <ItemTemplate>
                                                <div class="AlineacionIzquierda">
                                                    <asp:Label ID="lblGlosa" runat="server" Text='<%# bind("glosa") %>'></asp:Label></div>
                                            </ItemTemplate>
                                            <HeaderStyle Width="748px" />
                                        </asp:TemplateField>
                                    </Columns>
                                     <PagerTemplate>
                                    <div style="width: 100%; text-align: left;">
                                        Página 
                                        <asp:DropDownList ID="paginasDropDownList" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="GoPage" runat="server"></asp:DropDownList>
                                        de
                                        <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Button4" runat="server" CommandName="Page" ToolTip="Prim. Pag"  CommandArgument="First" CssClass="pagfirst" />                    
                                        <asp:Button ID="Button1" runat="server" CommandName="Page" ToolTip="Pág. anterior"  CommandArgument="Prev" CssClass="pagprev" />
                                        <asp:Button ID="Button2" runat="server" CommandName="Page" ToolTip="Sig. página" CommandArgument="Next" CssClass="pagnext" />                    
                                        <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="últ. Pag"  CommandArgument="Last" CssClass="paglast" />
                                </div>
                                </PagerTemplate>
                                <PagerStyle CssClass="pagerstyle" />
                                </asp:GridView>
                                </td>
                        </tr>
                              <tr>
                                  <td class="Alineacionderecha" colspan="2" style="height: 15px" valign="top">
                                      <asp:FileUpload ID="fupCertificadoAsist" runat="server" /><asp:Button ID="btnSubirArchivo"
                                          runat="server" Text="subir cert. asistencia" /></td>
                              </tr>
                        <tr>
                            <td style="width: 50%; height: 15px;" valign="top" class="AlineacionIzquierda">
                         <asp:HyperLink ID="hplCartaEmpresa" runat="server">Carta empresa</asp:HyperLink></td>
                            <td valign="top" style="height: 15px" class="AlineacionDerecha">
                                <asp:LinkButton ID="lkbtnBajarCertficado" runat="server" Visible="False">certificado asistencia</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 12px; width: 50%;" class="AlineacionIzquierda">
                         <asp:HyperLink ID="hplCartaOtec" runat="server">Carta OTEC</asp:HyperLink></td>
                            <td valign="top" class="AlineacionDerecha">
                                <asp:LinkButton ID="lkbtnAcuerdo" runat="server">acuerdo fin de semana</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 12px; width: 50%;" class="AlineacionIzquierda">
                                <asp:HyperLink ID="hplFactura" runat="server">Factura</asp:HyperLink></td>
                        </tr>
                    </table>
                    
                    <table width="980" cellpadding="0" cellspacing="0" class="TablaFooter" >
                      <tr>
                            <td class="AlineacionIzquierda" colspan="2" valign="top" style="height: 14px">
                                </td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" colspan="2" valign="top">
                </td>
                        </tr>
                    </table>
                       <br />
               
            </div>
        <div id="botones"><asp:Button ID="BtnVolver3" runat="server" Text="Volver" Visible="False" />
                         <asp:Button ID="BtnVolver2" runat="server" Text="Volver" Visible="False" UseSubmitBehavior="False" />
                         &nbsp;<asp:Button ID="btnVolver" runat="server" Text="Volver" UseSubmitBehavior="False" />
                          <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />&nbsp;<asp:Button ID="btnPopupEnviarCorreo"
                              runat="server" Text="Enviar correo" Visible="False" />
                         <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" />
                         <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" />
                         <asp:Button ID="btnCambiaAIngresado" runat="server" Text="Cambia a estado ingresado" />
                         <asp:Button ID="btnPdfCursoContratado" runat="server" Text="Generar pdf" Visible="False" /></div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
                <asp:HiddenField ID="hdfComunaEmpresa" runat="server" />
            </div>
        </div>
        </div>
    </form>
</body>

</html>
