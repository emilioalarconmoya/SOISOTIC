<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Copy of carta_otec.aspx.vb" Inherits="modulo_cursos_carta_otec" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" > 
<head id="Head1" runat="server">
<title>Carta Otec</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
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
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>

<body>

    <form id="form1" runat="server">
    <div id="contenedor">  <div id="bannner">
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
                
	<div id="Carta" runat="server">
        <table id="TablaCarta" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td  colspan="3" valign="top" style="background-color:#2e74b5; height: 26px;" class="AlineacionIzquierda">
                    <asp:Label ID="Label1" runat="server" Text="Orden de compra" Font-Size="15px" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td id="tdTabla1">
                    <table cellpadding="0" cellspacing="0" class="TablaDatosOTEC">
                        <tr>
                            <td align="left" colspan="3" style="padding-left: 20px">
                Srs.
            <asp:Label ID="lblNombreContacto" runat="server"></asp:Label>
            <asp:Label ID="lblCargoContacto" runat="server"></asp:Label>
                                <br />
            <asp:Label ID="lblRazonSocial" runat="server"></asp:Label>
            <br  />
            <span>
            	Contacto
            </span>
            <asp:Label ID="lblContactoAd" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td id="tdTabla2" align="right" style="width: 26%">
                    <table class="TablaInterior">
                        <tr>
                            <td class="AlineacionDerecha" style="width: 100px">
                                <asp:Label ID="Label28" runat="server" Text="correlatvo"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 100px">
                    <asp:Label ID="lblCorrelativo" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="AlineacionDerecha" style="width: 100px">
                                <asp:Label ID="Label30" runat="server" Text="Nº registro sence"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 100px">
                    <asp:Label ID="lblNroRegistroSence" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="AlineacionDerecha" style="width: 100px">
                                <asp:Label ID="Label31" runat="server" Text="Estado curso"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 100px">
                <asp:Label ID="lblEstadoCurso" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="AlineacionDerecha" style="width: 100px">
                                <asp:Label ID="Label32" runat="server" Text="Tipo Actividad"></asp:Label></td>
                            <td class="AlineacionDerecha" style="width: 100px">
                <asp:Label ID="lblCodTipoAct" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="AlineacionDerecha" colspan="2">
                <asp:Label ID="lblNomEjecutivo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td class="AlineacionDerecha" style="width: 100px">
                <asp:Label ID="lblFechaImp" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    &nbsp;</td>
                <td id="tdTabla3" rowspan="1">
                    <%--<img src="../include/imagenes/css/fondos/reporte06.jpg" alt="Otic Asimet" title="Otic"/>--%>
                    &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/include/imagenes/css/fondos/reporte06.jpg"
                        Width="168px" /></td>
            </tr>
        </table>
        <div id="Alumnos" style="width: 95%">
            <div class="AlineacionIzquierda" style="width: 100%">
            	De mi consideración:
            <p>
            	A través de la presente, solicito a usted inscribir la siguiente nómina de alumnos en el curso que se detalla a continuación según lo ordenado por nuestro cliente:
            </p>
            </div>
            <br />
            <table width="100%" class="SinEspacio">
                <tr>
                    <td  align="left" colspan="3" valign="top"  style="background-color:#2e74b5" class="AlineacionIzquierda" >
                        <asp:Label ID="Label19" runat="server" Text="Listado de alumnos"  Font-Size="15px" ForeColor="White" Height="25px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
            <asp:GridView ID="grdListadoAlumnos" runat="server" AutoGenerateColumns="False" CssClass="GridOC" Width="100%"  >
                <Columns>
                    <asp:TemplateField ShowHeader="False" >
                        <ItemTemplate>
                            <asp:Label ID="lblContador" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rut">
                        <ItemTemplate>
                            <div class="AlineacionDerecha">
                        	<asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut_alumno") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <div class="AlineacionIzquierda">
                        	<asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre_completo") %>' ></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Franquicia">
                        <ItemTemplate>
                            <div class="AlineacionDerecha">
                        	<asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label>%</div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Costo OTIC">
                        <ItemTemplate>
                            <div class="AlineacionDerecha">
                        	<asp:Label ID="lblCostoOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Costo empresa">
                        <ItemTemplate>
                            <div class="AlineacionDerecha">
                        	<asp:Label ID="lblCostoEmpresa" runat="server" Text='<%# Bind("gasto_empresa") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                    </td>
                </tr>
            </table>
            &nbsp;
            <br />
            <div style="width: 100%" class="AlineacionIzquierda">
                <p>
            	    <asp:Label ID="Label47" runat="server" Text="A continuación se presentan los datos relacionados con el curso que deberán ser incluídos obligatoriamente en la glosa de la factura a emitir por su OTEC."></asp:Label>
                </p>
                <p>
                    <asp:Label ID="Label34" runat="server" Text="Una vez finalizado el curso deberá emitir una factura correspondiente al monto especificado en la línea 'Facturación OTIC "></asp:Label>
            	    <asp:Label ID="lblNomOtic" runat="server"></asp:Label>
            	    <asp:Label ID="Label35" runat="server" Text="' de la siguiente tabla, del período respectivo, a nombre de "></asp:Label>
            	    <asp:Label ID="lblRazonSocOtic" runat="server"></asp:Label>
            	    <asp:Label ID="Label36" runat="server" Text=", Rut "></asp:Label>
            	    <asp:Label ID="lblRutOtic" runat="server"></asp:Label>
            	    <asp:Label ID="Label37" runat="server" Text=", "></asp:Label>
            	    <asp:Label ID="lblDireccOtic" runat="server"></asp:Label>
            	    <asp:Label ID="Label38" runat="server" Text=", Santiago."></asp:Label>
                </p>
                <p>
            	    <asp:Label ID="Label39" runat="server" Text="Por otro lado, deberá emitir factura a nombre de "></asp:Label>
            	    <asp:Label ID="lblRazonSocialCli" runat="server"></asp:Label>
            	    <asp:Label ID="Label40" runat="server" Text=", "></asp:Label>
            	    <asp:Label ID="lblRutCli" runat="server"></asp:Label>
            	    <asp:Label ID="Label44" runat="server" Text=", "></asp:Label>
            	    <asp:Label ID="lblDireccCli" runat="server"></asp:Label>
            	    <asp:Label ID="Label46" runat="server" Text=", por el monto especificado en la línea 'Facturación empresa' de la siguiente tabla."></asp:Label>
                </p>
            </div>
            <p>
            </p>
        </div>
        <div id="Curso"  width="100%">
            <table id="TablaCurso">
                <tbody>
                    <tr>
                        <td colspan="2" valign="top" style="background-color:#2e74b5" class="AlineacionIzquierda">
                            <asp:Label ID="Label2" runat="server" Text="Curso inscrito" Font-Size="15px" ForeColor="White" Height="25px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" rowspan="2" valign="top" style="width: 50%">
                            <table cellpadding="0" cellspacing="0" class="TablaDatosOTEC" style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="3" valign="top" style="background-color:#bfbfbf" >
                                            <asp:Label ID="Label3" runat="server" Text="Datos del curso" Font-Size="15px" ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%">
                                            :</td>
                                        <td align="left">
                <asp:Label ID="lblTNombre" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label5" runat="server" Text="Correlativo"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 16px">
                                            :</td>
                                        <td align="left" style="height: 16px">
                <asp:Label ID="lblTCorrelativo" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label6" runat="server" Text="Fecha inicio"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%">
                                            :</td>
                                        <td align="left">
                <asp:Label ID="lblTFechaInicio" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label7" runat="server" Text="Fecha término"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%">
                                            :</td>
                                        <td align="left">
                <asp:Label ID="lblTFechaTermino" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label8" runat="server" Text="Duración"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                <asp:Label ID="lblTDuracion" runat="server"></asp:Label>
                <span>
                	hrs. (
                </span>
                <asp:Label ID="lblTHoras" runat="server"></asp:Label>
                <span>
                	hrs. complementarias)
                </span>
                </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label9" runat="server" Text="Código SENCE"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                <asp:Label ID="lblTCodSence" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label42" runat="server" Text="Nº Registro SENCE"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                <asp:Label ID="lblNumRegistro" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label41" runat="server" Text="Lugar ejecución"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                <asp:Label ID="lblCursoDirecc" runat="server"></asp:Label>
                <asp:Label ID="lblNroDireccionCurso" runat="server"></asp:Label>
                <span>
                	-
                <asp:Label ID="lblComuna" runat="server"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label24" runat="server" Text="Empresa"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                <asp:Label ID="lblTEmpresa" runat="server"></asp:Label>
                </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label26" runat="server" Text="Rut empresa"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                <asp:Label ID="lblTRutEmpresa" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="Label23" runat="server" Text="Modalidad"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                                            <asp:Label ID="lblModalidad" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 25%">
                                            <asp:Label ID="lblValorHoratit" runat="server" Text="Valor Hora Sence"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td align="left" style="height: 12px">
                                            <asp:Label ID="lblValorHora" runat="server"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" class="TablaDatosOTEC" style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="3" valign="top" style="background-color:#bfbfbf">
                                            <asp:Label ID="Label15" runat="server" Text="Valores asociados" Font-Size="15px" ForeColor="White" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label16" runat="server" Text="Descuento "></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%">
                                            :</td>
                                        <td class="AlineacionDerecha">
                <asp:Label ID="lblTDescuento" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 12px">
                                            <asp:Label ID="Label25" runat="server" Text="Participantes "></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%; height: 12px">
                                            :</td>
                                        <td class="AlineacionDerecha" style="height: 12px">
                <asp:Label ID="lblTParticipantes" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label27" runat="server" Text="Valor final "></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 2%">
                                            :</td>
                                        <td class="AlineacionDerecha">
                <asp:Label ID="lblTValorFinal" runat="server"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:HiddenField ID="hdfComiteBipartito" runat="server" />
                        </td>
                    </tr>
                    
                </tbody>
                <tr>
                        <td class="AlineacionCentro">
                            <div>
                <table cellpadding="0" cellspacing="0" style="width: 179%">
                    <tr>
                        <td style="background-color:#2e74b5; height: 26px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label43" runat="server" Text="Horario curso" Font-Size="15px" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
            <table id="Table2" runat="server" cellpadding="0" cellspacing="0" class="GridOC" align="center"  >
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
                    <td valign="top" style="width: 270px">
                        <br />
                        <asp:Label ID="lblLunes" runat="server" Text=" "></asp:Label>
                    </td>
                    <td valign="top" style="width: 399px">
                        <asp:Label ID="lblMartes" runat="server" Text=" "></asp:Label>
                    </td>
                    <td valign="top" style="width: 299px">
                        <asp:Label ID="lblMiercoles" runat="server" Text=" "></asp:Label>
                    </td>
                    <td valign="top" style="width: 328px">
                        <asp:Label ID="lblJueves" runat="server" Text=" "></asp:Label>
                    </td>
                    <td valign="top" style="width: 290px">
                        <asp:Label ID="lblViernes" runat="server" Text=" "></asp:Label>
                    </td>
                    <td valign="top" style="width: 362px">
                        <asp:Label ID="lblSabado" runat="server" Text=" "></asp:Label>
                    </td>
                    <td valign="top" style="width: 445px">
                        <asp:Label ID="lblDomingo" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
            </table>
                            <div class="AlineacionIzquierda">
                                            <asp:Label ID="Label18" runat="server" Font-Bold="False" Text="Observación :"></asp:Label>
                <asp:Label ID="lblObservacion" runat="server"></asp:Label><br />
                            </div>
                        </td>
                    </tr>
                </table>
                            <table cellpadding="0" cellspacing="0" class="TablaDatosOTEC" style="width: 179%">
                                <tbody>
                                
                                    <tr>
                                   
                            <td style="background-color:#2e74b5; height: 26px;" class="AlineacionIzquierda" colspan="6">
                            <asp:Label ID="Label29" runat="server" Text="Facturación" Font-Size="15px" ForeColor="White" Height="11px"></asp:Label>
                            </td>
                            </tr>
                             <tr>
                                        <td align="left" colspan="6" valign="top" style="background-color:#bfbfbf">
                                            <asp:Label ID="Label22" runat="server" Text="OTIC - Empresa" Font-Size="15px" ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%; height: 14px">
                                            <asp:Label ID="Label10" runat="server" Text="Rut  "></asp:Label></td>
                                        <td style="width: 1%; height: 14px;" class="AlineacionCentro">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%; height: 14px">
                    <asp:Label ID="lblTRutOtic" runat="server"></asp:Label>
                    </td>
                                        <td class="AlineacionDerecha" style="width: 29%; height: 14px; border-left: black 1px solid;">
                    <asp:Label ID="lblTNombreOtic" runat="server"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%; height: 14px">
                                        </td>
                                        <td class="AlineacionDerecha" style="width: 38%; height: 14px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%; height: 15px">
                                            <asp:Label ID="Label11" runat="server" Text="Dirección"></asp:Label></td>
                                        <td style="width: 1%; height: 15px;" class="AlineacionCentro">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%; height: 15px">
                    <asp:Label ID="lblTDireccionOtic" runat="server"></asp:Label></td>
                                        <td class="AlineacionDerecha" style="width: 29%; height: 15px; border-left: black 1px solid;">
                        Monto 
                        <asp:Label ID="lblTOtic" runat="server"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%; height: 15px">
                                            :</td>
                                        <td class="AlineacionDerecha" style="width: 38%; height: 15px">
                    <asp:Label ID="lblTCostoOtic" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                            <asp:Label ID="Label12" runat="server" Text="Giro"></asp:Label></td>
                                        <td style="width: 1%" class="AlineacionCentro">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                    <asp:Label ID="lblTGiroOtic" runat="server"></asp:Label></td>
                                        <td class="AlineacionDerecha" style="width: 29%; border-left: black 1px solid; height: 14px;">
                	*Costo Otic estimado año 
                    <asp:Label ID="lblTAgno" runat="server"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            :</td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                	<asp:Label ID="lblTCostoOticCompl" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                            <asp:Label ID="Label13" runat="server" Text="Teléfono"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                    <asp:Label ID="lblTFonoOtic" runat="server"></asp:Label></td>
                                        <td class="AlineacionDerecha" style="width: 29%; border-left: black 1px solid; height: 14px;">
                                        </td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                        </td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%; height: 15px;">
                                        </td>
                                        <td class="AlineacionCentro" style="width: 1%; height: 15px;">
                                        </td>
                                        <td class="AlineacionIzquierda" style="width: 42%; height: 15px;">
                                        </td>
                                        <td class="AlineacionDerecha" colspan="3" style="border-left: black 1px solid; width: 29%; height: 15px">
                                            <span id="Span1">
                	* El Monto del costo complementario estimado debe ser facturado el año
                                        <asp:Label ID="lblAgno" runat="server"></asp:Label>&nbsp;</span></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                            <asp:Label ID="Label14" runat="server" Text="Rut  "></asp:Label></td>
                                        <td style="width: 1%;" class="AlineacionCentro">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                    <asp:Label ID="lblRutEmpresa" runat="server"></asp:Label></td>
                                        <td class="AlineacionDerecha" style="width: 29%; border-left: black 1px solid; height: 14px;">
                                            <span id="Span3">&nbsp;<span id="Span2"></span></span></td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            </td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                            <asp:Label ID="Label17" runat="server" Text="Dirección   "></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                    <asp:Label ID="lblDireccionEmpresa" runat="server"></asp:Label>
                    <asp:Label ID="lblNroDireccionEmpresa" runat="server"></asp:Label>
                                        </td>
                                        <td class="AlineacionDerecha" style="width: 29%; border-left: black 1px solid; height: 14px;">
                                        </td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                        </td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                            <asp:Label ID="Label20" runat="server" Text="Giro  "></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                    <asp:Label ID="lblGiroEmpresa" runat="server"></asp:Label></td>
                                        <td class="AlineacionDerecha" style="width: 29%; border-left: black 1px solid; height: 14px;">
                    <asp:Label ID="lblNombreEmpresa" runat="server"></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                        </td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                            <asp:Label ID="Label21" runat="server" Text="Teléfono  "></asp:Label></td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                    <asp:Label ID="lblFonoEmpresa" runat="server"></asp:Label></td>
                                        <td class="AlineacionDerecha" style="width: 29%; border-left: black 1px solid; height: 14px;">
                        Monto Empresa&nbsp;</td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            :</td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                    <asp:Label ID="lblTGastoEmpresa" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                        </td>
                                        <td style="width: 1%">
                                        </td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                                        </td>
                                        <td class="AlineacionDerecha" style="width: 29%; border-left: black 1px solid; height: 14px;">
                        Valor total del curso&nbsp;
                                        </td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                            :</td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                    <asp:Label ID="lblTTotalValor" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 8%">
                                        </td>
                                        <td style="width: 1%;">
                                        </td>
                                        <td class="AlineacionIzquierda" style="width: 42%">
                                            </td>
                                        <td class="AlineacionDerecha" style="width: 29%">
                                        </td>
                                        <td class="AlineacionCentro" style="width: 1%">
                                        </td>
                                        <td class="AlineacionDerecha" style="width: 38%">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            </div>
                        </td>
                    </tr>
            </table>
        </div>
        <div>
            <div id="Otic">
                &nbsp;</div>
        </div>
        <div id="Requisitos">
        	<h1 style="background-color:#bfbfbf;" class="AlineacionIzquierda">
                <asp:Label ID="Label33" runat="server" Text="Requisitos y condiciones de cancelación" ForeColor="White"></asp:Label></h1>
            <asp:Literal ID="litRequisitos" runat="server"></asp:Literal>
            <%--<p>
            	1° El correspondiente pago de la actividad, se realizará una vez que esta se encuentre finalizada, y los participantes deberán tener registrada una asistencia equivalente al 75% de su duración total. En caso contrario, el importe correspondiente será de cargo de la empresa a la que pertenecen. En caso que el o los cursos sean e-learning o a distancia, se requiere la respectiva Declaración Jurada simple de “Aprobado” o “Reprobado” por los participantes
            </p>
            <p>
            	2° Se considerará actividad no ejecutada, si dentro de los 20 días hábiles siguientes a la fecha de termino del curso, no se han recepcionado la(s) factura(s) y el respectivo Informe de Asistencia. 
            </p>
            <p>
            	3° Será requisito indispensable para la cancelación de la factura, adjuntar a esta el Informe de Asistencia de los alumnos inscritos en esta carta. IMPORTANTE: En caso de participantes que no cumplan con la asistencia mínima exigida por SENCE (Ley 19.518), se deberá rebajar de la facturación del monto franquiciable (OTIC), los valores correspondientes por este concepto. La diferencia producida no afecta a franquicia tributaria, deberá facturarse a la Empresa como gasto. 
            </p>
            <p>
            	4° Las Facturas Costo Otic (Valor Sence) deben enviarse a <asp:Label ID="lblDireccionOtic" runat="server"></asp:Label>, Santiago (Dirección del Otic <asp:Label ID="lblOtic2" runat="server"></asp:Label>), adjuntando copia de esta Orden de Compra. Las facturas de Costo empresa deben enviarse directamente a la dirección de la Empresa:  <asp:Label ID="lblDireccClie" runat="server"></asp:Label>,<asp:Label ID="lblComunaClie" runat="server"></asp:Label>. Con fotocopia al Otic. 
            </p>
            <p>
            	5° Para consultas sobre el pago de facturas por favor comunicarse al fono 4216559 - Señor Luis Nuñez, <a href="mailto:tecnologia@soleduc.cl" >tecnologia@soleduc.cl</a>
            </p>
            <p>
            	6º Se debe traer cuarta copia de la factura al momento del pago y sin estos documentos no se recibiran facturas. 
            </p>
            <p>
            	Quedando a su entera disposición para aclarar cualquier duda, 
            </p>--%>
            <%--<asp:Label ID="lblDireccionOtic" runat="server"></asp:Label>
            <asp:Label ID="lblOtic2" runat="server"></asp:Label>
            <asp:Label ID="lblDireccClie" runat="server"></asp:Label>
            <asp:Label ID="lblComunaClie" runat="server"></asp:Label>--%>
            <asp:HiddenField ID="lblDireccionOtic" runat="server" />
            <asp:HiddenField ID="lblOtic2" runat="server" />
            <asp:HiddenField ID="lblDireccClie" runat="server" />
            <asp:HiddenField ID="lblComunaClie" runat="server" />
            <asp:HiddenField ID="hdfGiroCliente" runat="server" />
            <asp:HiddenField ID="hdfFonoCliente" runat="server" />
            
            
            <p id="RequisitosPie" >
                <asp:Image ID="Image1" runat="server" ImageUrl="~/contenido/imagenes/empresa/firma_gerente.png" />
            </p>
            <p>
                <asp:Label ID="lblOtic" runat="server" Font-Bold="True" Visible="False"></asp:Label>
            </p>
        </div>
        
        
    </div>
    <div id="Botonera">
        	<asp:HyperLink ID="hplGenerar" runat="server" Visible="False">[hplGenerar]</asp:HyperLink>
            <br />
            <asp:CheckBox ID="chkGenerar" runat="server" Text="Generar HTML" Visible="False" />
            <br />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" />
            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
        	<asp:Button ID="btnGenerar" runat="server" Text="Generar" Visible="False" />
            <asp:Button ID="btnGenerarPdf" runat="server" Text="Generar PDF" />
            <asp:Button ID="btnGenerarExcel" runat="server" Text="Generar Excel" />
            </div>
       <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>     
    </div>
    </div>
    </form>
</body>
</html>
