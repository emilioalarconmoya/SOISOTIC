<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_curso_contratado.aspx.vb" Inherits="Reportes_Ficha_curso_contratado" %>

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
    </script>

   
   
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
        <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
        <div id="cabecera">
        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label43" runat="server" Text="Ficha de Curso Contratado"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <uc2:cabecera1 id="Cabecera1_1" runat="server" /></div>
        <%--&nbsp;<uc2:cabecera1 id="Cabecera1_1" runat="server"></uc2:cabecera1></div>--%>
        <div id="contenido">
            <div id="resultados">
                <div id="CuentasPeriodoActual">
                    <table id="tablaPeriodoActual">
                        <tr>
                            <td valign="top" style="height: 93px; width: 50%;">
                                <table class="TablasCuentas" cellpadding="0" cellspacing="0">
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
                                            <asp:Label ID="Label7" runat="server" Text=" - "></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text="Fax: "></asp:Label>&nbsp;
                                            <asp:Label ID="lblDEfax" runat="server" Text="Label"></asp:Label></td>
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
                                    <th class="TituloIzquierda" colspan="3">
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
                                        <asp:Label ID="Label21" runat="server" Text=" - "></asp:Label>
                                        <asp:Label ID="Label22" runat="server" Text="Fax: "></asp:Label>
                                        <asp:Label ID="lblDOfax" runat="server" Text="Label"></asp:Label></td>
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
                            <td valign="top" style="width: 50%; height: 129px;">
                            <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda" colspan="3">
                                        &nbsp;<asp:Label ID="Label14" runat="server" Text="Curso"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="height: 12px" colspan="3">
                                        <asp:HyperLink ID="hplCUnombreCurso" runat="server">HyperLink</asp:HyperLink></td>
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
                                        <asp:Label ID="Label26" runat="server" Text="("></asp:Label><asp:Label ID="lblCUciudad" runat="server" Text="Label"></asp:Label><asp:Label ID="Label28" runat="server" Text=")"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="lblCUregion" runat="server" Text="Label"></asp:Label>&nbsp;
                                        <asp:Label ID="lblCUcomuna" runat="server" Text="Label" Visible="False"></asp:Label></td>
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
                            <td valign="top" style="height: 129px">
                            <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda" colspan="6">
                                        <asp:Label ID="Label46" runat="server" Text="Costo"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 31%; height: 12px">
                                        <asp:HyperLink ID="hplCOnumParticipantes" runat="server">Nº Participantes: </asp:HyperLink></td>
                                    <td class="AlineacionDerecha" style="width: 11%; height: 12px">
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
                                    <td class="AlineacionDerecha" style="width: 11%; height: 12px">
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
                                    <td class="AlineacionDerecha" style="width: 11%; height: 12px;">
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
                                    <td class="AlineacionDerecha" style="width: 11%; height: 16px">
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
                                    <td class="AlineacionDerecha" style="width: 11%; height: 12px">
                                    </td>
                                    <td class="AlineacionDerecha" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCOporcAdmin" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="Label35" runat="server" Text="%"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="width: 2%; height: 12px">
                                    </td>
                                    <td class="AlineacionIzquierda" style="height: 12px" colspan="2">
                                    </td>
                                </tr>
                               
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="width: 50%; height: 105px">
                            <table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda" colspan="7">
                                        <asp:Label ID="Label36" runat="server" Text="Curso Parcial"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td class="TituloIzquierdo" style="width: 31%; height: 12px">
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
                            <td valign="top" style="height: 105px"><table class="TablasCuentas" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th class="TituloIzquierda" colspan="3">
                                        <asp:Label ID="Label74" runat="server" Text="Curso complementario"></asp:Label></th>
                                </tr>
                                <tr runat="server">
                                    <td class="TituloIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCCesComplementario" runat="server" Text="ESTE CURSO ES COMPLEMENTARIO"></asp:Label>
                                        <asp:Label ID="lblCCnoEsComplementario" runat="server" Text="NO TIENE COMPLEMENTARIO "></asp:Label>
                                        <asp:Label ID="lblCCoticEstimado" runat="server" Text="Costo OTIC Estimado:"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCCpeso1" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCcostoOticEstimado" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr runat="server">
                                    <td class="TituloIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCCgEmpresa" runat="server" Text="Gasto Empresa:"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCCpeso2" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCgastoEmpresa" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr runat="server">
                                    <td class="TituloIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCCcAdmin" runat="server" Text="Costo Admin:"></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        <asp:Label ID="lblCCpeso3" runat="server" Text="$"></asp:Label></td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCcostoAdmin" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr id="tr1" runat="server">
                                    <td class="TituloIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCChora" runat="server" Text="Horas: "></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px" >
                                        </td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCChoras" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr id="tr2" runat="server">
                                    <td class="TituloIzquierda" style="height: 12px">
                                        <asp:HyperLink ID="hplCCfichaCursoParcial" runat="server">Ficha Curso Parcial</asp:HyperLink></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        </td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        </td>
                                </tr>
                                <tr id="tr3" runat="server">
                                    <td class="TituloIzquierda" style="height: 12px">
                                        <asp:Label ID="lblCClistadoCursoCompl" runat="server" Text="Estado Curso Complementario: "></asp:Label></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                        </td>
                                    <td class="AlineacionDerecha" style="height: 12px">
                                        <asp:Label ID="lblCCestadoCursoComp" runat="server" Text="-"></asp:Label></td>
                                </tr>
                                <tr id="tr4" runat="server">
                                    <td class="TituloIzquierda" style="height: 12px">
                                        <asp:HyperLink ID="hplCCFichaCursoCompl" runat="server">Ficha Curso Complementario   </asp:HyperLink></td>
                                    <td class="Indicador" style="width: 20%; height: 12px">
                                    </td>
                                    <td class="ValorDato" style="height: 12px">
                                        </td>
                                </tr>
                                <tr id="tr5" runat="server">
                                    <td class="TituloDato" colspan="3" style="height: 12px">
                                    </td>
                                </tr>
                                <tr id="tr6" runat="server">
                                    <td class="TituloIzquierda" style="height: 16px">
                                        </td>
                                    <td class="Indicador" style="width: 20%; height: 16px;">
                                        </td>
                                    <td class="ValorDato" style="height: 16px">
                                        </td>
                                </tr>
                                <tr id="tr7" runat="server">
                                    <td class="TituloIzquierda" style="height: 16px">
                                        </td>
                                    <td class="Indicador" style="width: 20%; height: 16px;">
                                        </td>
                                    <td class="ValorDato" style="height: 16px">
                                        </td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%;" valign="top" class="AlineacionIzquierda">
                                <asp:HyperLink ID="hplCartaEmpresa" runat="server" Font-Bold="True"  Font-Size="XX-Small" ForeColor="DodgerBlue">Ver carta empresa</asp:HyperLink></td> 
                            <%--NavigateUrl="~/modulo_aporte/aviso_inscripcion_de_cursos.aspx"--%>
                            <td valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 12px; width: 50%;" class="AlineacionIzquierda">
                         <asp:HyperLink ID="hplCartaOtec" runat="server">Ver Carta OTEC</asp:HyperLink></td>
                            <td rowspan="2" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 12px; width: 50%;" class="AlineacionIzquierda">
                                <asp:HyperLink ID="hplFactura" runat="server">Factura</asp:HyperLink></td>
                            <td rowspan="2" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 12px; width: 50%;">
                            </td>
                        </tr>
                    </table>
                    
                    <table width="980" cellpadding="0" cellspacing="0" class="TablaFooter" >
                      <tr>
                            <td class="AlineacionIzquierda" colspan="2" valign="top" style="height: 14px">
                                </td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" colspan="2" valign="top" style="height: 14px">
                                </td>
                        </tr>
                    </table>
                     <div id="botones"><asp:Button ID="BtnVolver3" runat="server" Text="Volver" Visible="False" />
                         <asp:Button ID="BtnVolver2" runat="server" Text="Volver" Visible="False" />
                         &nbsp;<asp:Button ID="btnVolver" runat="server" Text="Volver" />
                          <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />&nbsp;<asp:Button ID="btnPopupEnviarCorreo"
                              runat="server" Text="Enviar correo" Visible="False" />
                         <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                         <asp:Button ID="btnCambiaAIngresado" runat="server" Text="Cambia a estado ingresado" />
                         <asp:Button ID="btnPdfCursoContratado" runat="server" Text="Generar pdf" Visible="False" /></div>
                                        
                    <br />
                </div>
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
