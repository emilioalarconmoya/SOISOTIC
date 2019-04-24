<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Copy of carta_empresa.aspx.vb" Inherits="modulo_cursos_carta_empresa" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Carta de empresa</title>
      <link href="../estilo.css" rel="Stylesheet" type="text/css" />
      <link href="../estilo_imprimir.css" rel="Stylesheet" type="text/css" media="print" />
      <asp:literal id="litEstilo" runat="server"></asp:literal>
       <script type="text/javascript" >
        function Imprimir()
        {
           window.print();
            return false;
        }
        function imprSelec(DivCarta)
        {
            window.print();
            return false;
            /*var ficha=document.getElementById(DivCarta);
            var ventimp=window.open(' ','popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            var css = ventimp.document.createElement("link");
            css.setAttribute("href", "../estilo.css");
            css.setAttribute("rel", "Stylesheet");
            css.setAttribute("type", "text/css");
            ventimp.document.head.appendChild(css);
            ventimp.print();
            ventimp.close();*/
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
    <div id="contenedor">
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
                <li>
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx" Visible="False"><b>Mantenedor Sence</b></asp:HyperLink>
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
                
    <div id="contenido"> 
        <div id="DivCarta">
          <table id="TablaCarta" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="3" valign="top"  style="background-color:#2e74b5; height: 26px;" class="AlineacionIzquierda">
                             <asp:Label ID="Label1" runat="server" Text="Orden de compra" Font-Size="15px" ForeColor="White"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td id="tdTabla1">
                    <table class="TablaDatosOTEC" cellpadding="0" cellspacing="0">
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
    
  
        <table id="TablaCurso">
            <tbody>
                <tr>
                    <td  valign="top" colspan="2" style="background-color:#2e74b5; height: 26px;" class="AlineacionIzquierda">
                        <asp:Label id="Label2" runat="server" Text="Curso inscrito" Font-Size="15px" ForeColor="White"></asp:Label> 
                    </td>
                </tr>
                <tr>
                    <td rowspan="2" valign="top" align="right">
                    <table class="TablaDatosOTEC" cellspacing="0" cellpadding="0">
                    <tbody>
                    <tr>
                    <td valign="top" colspan="3" align="left" style="background-color:#bfbfbf">
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
                    </tbody></table></td><td align="left"><table class="TablaDatosOTEC" cellspacing="0" 
cellpadding="0"><tbody><tr><td valign="top" colspan="3" align="left" style="background-color:#bfbfbf">
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
                <td style="background-color:#2e74b5; height: 26px;" class="AlineacionIzquierda">
                    <asp:Label ID="Label43" runat="server" Text="Horario curso" Font-Size="15px" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table id="table1" runat="server" cellpadding="0" cellspacing="0" class="GridOC" align="center"  >
                        <tr>
                            <th>
                                Lunes
                            </th>
                            <th>
                                Martes
                            </th>
                            <th>
                                Miércoles
                            </th>
                            <th>
                                Jueves
                             </th>
                            <th>
                                Viernes
                             </th>
                            <th>
                                Sábado
                            </th>
                            <th>
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
         <th width="970px" valign="top" style="background-color:#2e74b5; height: 26px;" class="AlineacionIzquierda">
            <asp:Label ID="Label19" runat="server" Text="Listado de alumnos" Font-Size="15px" ForeColor="White"></asp:Label>
         </th>
        </tr>
        <tr>
            <td align="center">
            <asp:GridView ID="grdListadoAlumnos" runat="server" AutoGenerateColumns="False" CssClass="GridOC" Width="95%">
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
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/contenido/imagenes/empresa/firma_gerente.png" Width="180px" Height="105px"/>
                    <asp:Label ID="lblOtic" runat="server" Font-Bold="True" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        
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
