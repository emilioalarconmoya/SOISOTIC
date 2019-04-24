<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carta_curso_interno.aspx.vb" Inherits="modulo_cursos_carta_curso_interno" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Carta curso interno</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <asp:literal id="litEstilo" runat="server"></asp:literal>
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
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
//         function abrir_popupCorreo() 
//        {
//            knResultados = window.open('enviar_correo.aspx' ,'NewWindow','top=150,left=150,width=700,height=600,status=no,resizable=yes,scrollbars=yes,location=no,title="Filtros dinamicos",closable=no');
//        }
    </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <div id="contenedor" >  
    <div id="bannner" style="width: 100%">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile" style="width: 100%"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
   
     <div id="menu">
        <div id="header" style="width: 100%">
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
                            <li  class="pestanaconsolaseleccionada">
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
     <div id="contenido">
	<div id="Carta"> 

    	<h1 style=" height: 26px; width: 99%;" class="AlineacionIzquierda TituloGrupo" >
    	 <asp:Label ID="Label1" runat="server" Text="Orden de compra" Font-Size="15px" ForeColor="White"></asp:Label>
    	 </h1>
    	<div id="Membrete" style="width: 324px">
        	<span></span>
            <div class="AlineacionIzquierda">
                Srs.
            <asp:Label ID="lblNombreContacto" runat="server"></asp:Label>&nbsp;
            </div>
        </div>
    	<div id="DatosOC" style="width: 615px">
        	<div id="Datos" class="AlineacionIzquierda">
            	<span>
                	Orden de compra
                </span>
                <asp:Label ID="lblCorrelativo" runat="server"></asp:Label>
                <br />
            	<span>
                	Estado curso
                </span>
                <asp:Label ID="lblEstadoCurso" runat="server"></asp:Label>&nbsp;<br />
                <asp:Label ID="lblFechaImp" runat="server"></asp:Label>            
            </div>
        </div>
        <div id="Alumnos" style="width: 100%">
            <div class="AlineacionIzquierda" style="width: 100%">
                <br />
            	De NUESTRA consideración:
            <p>
            	A través de la presente, solicito a usted inscribir la siguiente nómina de alumnos en el curso que se detalla a continuación según lo ordenado por nuestro cliente:
            </p>
            
            </div>
            <h1 style="width: 94%" class="AlineacionCentro TituloGrupo">
                    <asp:Label ID="Label5" runat="server" Text="Datos Alumnos" Font-Size="15px" ForeColor="White"></asp:Label>
            	</h1>
            <asp:GridView ID="grdListadoAlumnos" runat="server" AutoGenerateColumns="False" CssClass="GridOC" Width="96%">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Label ID="lblContador" runat="server" Text='<%# Bind("rut") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="15px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rut">
                        <ItemTemplate>
                            <div class="AlineacionIzquierda">
                        	<asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <div class="AlineacionIzquierda">
                        	<asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre") %>' ></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Costo">
                        <ItemTemplate>
                            <div class="AlineacionDerecha">
                        	<asp:Label ID="lblCostoOtic" runat="server" Text='<%# Bind("total_costo_alumno") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div id="Curso">
        	<h1 style=" height: 26px; width: 917px" class="AlineacionCentro TituloGrupo">
                <asp:Label ID="Label2" runat="server" Text="Curso"  Font-Size="15px" ForeColor="White"></asp:Label></h1>
            <div id="DatosCurso" class="AlineacionIzquierda">
            	<h1 style="width: 106%" class="AlineacionCentro TituloGrupo" >
                    <asp:Label ID="Label4" runat="server" Text="Datos del curso" Font-Size="15px" ForeColor="White"></asp:Label>
            	</h1>
                <table class="TablaInterior" style="width: 419px">
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px; height: 11px">
                <span class="TitDato" style="width: 57px" >
                	Nombre
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px; height: 11px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px; height: 11px">
                <asp:Label ID="lblTNombre" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px; height: 12px">
                <span class="TitDato" style="width: 75px" >
                	Correlativo
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px; height: 12px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px; height: 12px">
                <asp:Label ID="lblTCorrelativo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px; height: 8px">
                <span class="TitDato" style="width: 70px" >
                	Fecha inicio
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px; height: 8px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px; height: 8px">
                <asp:Label ID="lblTFechaInicio" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px">
                <span class="TitDato" style="width: 62px" >
                	Fecha fin
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px">
                <asp:Label ID="lblTFechaTermino" runat="server" Width="116px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px; height: 18px">
                <span class="TitDato" style="width: 60px" >
                	Duración
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px; height: 18px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px; height: 18px">
                <asp:Label ID="lblTDuracion" runat="server"></asp:Label><span style="font-size: 10px;
                                font-family: 'Trebuchet MS', Verdana, Arial, Helvetica, sans-serif; background-color: #fff">
                                Hrs.</span></td>
                    </tr>
                    <tr style="font-size: 10px; font-family: 'Trebuchet MS', Verdana, Arial, Helvetica, sans-serif">
                        <td class="AlineacionIzquierda" style="width: 47px">
                <span class="TitDato" style="width: 101px" >
                	Lugar de ejecución
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px">
                <asp:Label ID="lblCursoDirecc" runat="server"></asp:Label>
                            -
                <asp:Label ID="lblComuna" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px">
                <span class="TitDato" style="width: 57px" >
                	Empresa
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px">
                <asp:Label ID="lblTEmpresa" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px">
                <span class="TitDato" style="width: 69px" >
                	Rut empresa
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px">
                <asp:Label ID="lblTRutEmpresa" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px">
                            <asp:Label ID="Label6" runat="server" Text="fono"></asp:Label></td>
                        <td class="AlineacionCentro" style="width: 9px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px">
            <asp:Label ID="lblFono" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 47px">
                <span class="TitDato" style="width: 103px" >
                	Observación
                </span>
                        </td>
                        <td class="AlineacionCentro" style="width: 9px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 504px">
                <asp:Label ID="lblObservacion" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <div id="Valores" style="text-align: left; width: 338px;">
                <h1 style="width: 115%" class="AlineacionCentro TituloGrupo">
                <asp:Label ID="Label3" runat="server" Text="Valores asociados" Font-Size="15px" ForeColor="White"></asp:Label>
                </h1>
                <table class="TablaInterior">
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 100px">
                <span class="TitDato" style="width: 80px" >
                	Participantes
                </span>
                        </td>
                        <td class="AlineacionCentro">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 100px">
                <asp:Label ID="lblTParticipantes" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 100px; height: 7px">
                <span class="TitDato" style="width: 63px" >
                	Descuento
                </span>
                        </td>
                        <td class="AlineacionCentro" style="height: 7px">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 100px; height: 7px">
                <asp:Label ID="lblTDescuento" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 100px">
                <span class="TitDato" style="width: 78px" >
                	Valor final *</span></td>
                        <td class="AlineacionCentro">
                            :</td>
                        <td class="AlineacionIzquierda" style="width: 100px">
                            <asp:Label ID="lblTValorFinal" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="3">
                * Incluye Viáticos y traslados.</td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="Requisitos">
            &nbsp;<%--<p>
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
            </p>--%><%--<asp:Label ID="lblDireccionOtic" runat="server"></asp:Label>
            <asp:Label ID="lblOtic2" runat="server"></asp:Label>
            <asp:Label ID="lblDireccClie" runat="server"></asp:Label>
            <asp:Label ID="lblComunaClie" runat="server"></asp:Label>--%><asp:HiddenField ID="lblDireccionOtic" runat="server" />
            <asp:HiddenField ID="lblOtic2" runat="server" />
            <asp:HiddenField ID="lblDireccClie" runat="server" />
            <asp:HiddenField ID="lblComunaClie" runat="server" />
            
            
            <p id="RequisitosPie" >
                <asp:Image ID="Image1" runat="server" ImageUrl="~/contenido/imagenes/empresa/firma_gerente.png" />
            </p>
            <p>
                <asp:Label ID="lblOtic" runat="server" Font-Bold="True" Visible="False"></asp:Label>
            </p>
             </div>
        </div>
        <div id="Botonera">
            <asp:Button ID="btnVolver" runat="server" Text="Volver" />&nbsp;
            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" />&nbsp;
            <asp:Button ID="btnGeneraPDF" runat="server" Text="generar pdf" />
                <asp:HiddenField ID="hdfDireccionEmpresa" runat="server" />
            <asp:HiddenField ID="hdfGiro" runat="server" />
            <asp:HiddenField ID="hdfComunaEmpresa" runat="server" />
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

