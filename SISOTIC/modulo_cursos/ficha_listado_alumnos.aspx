<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_listado_alumnos.aspx.vb" Inherits="Reportes_ficha_listado_alumnos" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Listado de Alumnos</title>
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
    <div id="resultados">

        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Listado de Alumnos"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0" class="TablaInterior">
            <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Correlativo :" Font-Bold="False"></asp:Label>
                <asp:HyperLink ID="hplCorrelativo" runat="server" Font-Bold="True">[hplCorrelativo]</asp:HyperLink></td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Estado actual :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblEstadoActual" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="Origen :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblOrigen" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="Nº Reg. SENCE :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblNumSence" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Correlativo empresa :" Font-Bold="False"></asp:Label>
                <asp:Label ID="lblCorrrelativo" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="Fecha :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="Fecha Ingreso :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblFechaIngreso" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Nº Reg. SENCE Comp :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblNumSenceComp" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="grdResultados" runat="server" Width="980px" AutoGenerateColumns="False">
            <Columns>
            <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td valign="top" class="AlineacionIzquierda">
                                    <asp:Label ID="lblContador" runat="server" Text='<%# bind("nFila") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" Width="10px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td style="width: 200px" valign="top" class="AlineacionIzquierda">
                                    <asp:HyperLink ID="hplNomAlumno" runat="server" Text='<%# Bind("nombre_completo") %>'></asp:HyperLink><br />
                                    <asp:Label ID="Label3" runat="server" Text="Rut :"></asp:Label>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut_alumno") %>'></asp:Label>
                                    <br />
                                    <asp:HiddenField ID="hdfRutAlumno" runat="server" Value='<%# Bind("rut_alumno") %>' />
                                    <asp:HiddenField ID="hdfTipo" runat="server" Value="Sence" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label2" runat="server" Text="Franquicia"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 110px" valign="top">
                                    <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Asistencia"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 110px" valign="top">
                                    <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("porc_asistencia") %>'></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label5" runat="server" Text="Origen"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 110px" valign="top">
                                    <asp:Label ID="Label16" runat="server" Text="Region "></asp:Label>
                                    <asp:Label ID="lblOrigen" runat="server" Text='<%# Bind("cod_region") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior" width="300">
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label7" runat="server" Text="Niv Educacional"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 200px" valign="top">
                                    <asp:Label ID="lblNivEducacional" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label8" runat="server" Text="Niv Profesional"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 200px" valign="top">
                                    <asp:Label ID="lblNivProfesional" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha de Nac"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 200px" valign="top">
                                    <asp:Label ID="lblFechNac" runat="server" Text='<%# Bind("fecha_nacim") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior" width="180">
                            <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label10" runat="server" Text="Costo Otic"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td style="width: 58px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCostoOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 50px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label11" runat="server" Text="Costo Emp"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td style="width: 58px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCostoEmp" runat="server" Text='<%# Bind("gasto_empresa") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td style="width: 100px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label12" runat="server" Text="Viático Total"></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 50px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label18" runat="server" Text="Viático OTIC"></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 50px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblViaticoOtic" runat="server" Text='<%# Bind("viatico_otic") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label20" runat="server" Text="Viático Emp."></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 50px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblViaticoEmp" runat="server" Text='<%# Bind("viatico_emp") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label13" runat="server" Text="Traslado Total"></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 50px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("traslado") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label22" runat="server" Text="Traslado OTIC"></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 50px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblTrasladoOtic" runat="server" Text='<%# Bind("traslado_otic") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label24" runat="server" Text="Traslado Emp."></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 50px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblTrasladoEmp" runat="server" Text='<%# Bind("traslado_emp") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HyperLink ID="hplBajarReporte" runat="server"></asp:HyperLink>
        <br />
         <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" /></div>
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
<%--
    <div id="contenido"> 
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
    <div id="resultados">

        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Listado de Alumnos"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0" class="TablaInterior">
            <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Correlativo :" Font-Bold="False"></asp:Label>
                <asp:HyperLink ID="hplCorrelativo" runat="server" Font-Bold="True">[hplCorrelativo]</asp:HyperLink></td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Estado actual :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblEstadoActual" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="Origen :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblOrigen" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="Nº Reg. SENCE :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblNumSence" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Correlativo empresa :" Font-Bold="False"></asp:Label>
                <asp:Label ID="lblCorrrelativo" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="Fecha :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="Fecha Ingreso :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblFechaIngreso" runat="server" Font-Bold="False"></asp:Label></td>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Nº Reg. SENCE Comp :" Font-Bold="False"></asp:Label>
                    <asp:Label ID="lblNumSenceComp" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="grdResultados" runat="server" Width="980px" AutoGenerateColumns="False">
            <Columns>
            <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td valign="top" class="AlineacionIzquierda">
                                    <asp:Label ID="lblContador" runat="server" Text='<%# bind("nFila") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" Width="10px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td style="width: 200px" valign="top" class="AlineacionIzquierda">
                                    <asp:HyperLink ID="hplNomAlumno" runat="server" Text='<%# Bind("nombre_completo") %>'></asp:HyperLink><br />
                                    <asp:Label ID="Label3" runat="server" Text="Rut :"></asp:Label>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut_alumno") %>'></asp:Label>
                                    <br />
                                    <asp:HiddenField ID="hdfRutAlumno" runat="server" Value='<%# Bind("rut_alumno") %>' />
                                    <asp:HiddenField ID="hdfTipo" runat="server" Value="Sence" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label2" runat="server" Text="Franquicia"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 110px" valign="top">
                                    <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Asistencia"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 110px" valign="top">
                                    <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("porc_asistencia") %>'></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label5" runat="server" Text="Origen"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 110px" valign="top">
                                    <asp:Label ID="Label16" runat="server" Text="Region "></asp:Label>
                                    <asp:Label ID="lblOrigen" runat="server" Text='<%# Bind("cod_region") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior" width="300">
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label7" runat="server" Text="Niv Educacional"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 200px" valign="top">
                                    <asp:Label ID="lblNivEducacional" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label8" runat="server" Text="Niv Profesional"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 200px" valign="top">
                                    <asp:Label ID="lblNivProfesional" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha de Nac"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 200px" valign="top">
                                    <asp:Label ID="lblFechNac" runat="server" Text='<%# Bind("fecha_nacim") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior" width="180">
                            <tr>
                                <td style="width: 90px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label10" runat="server" Text="Costo Otic"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td style="width: 88px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCostoOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 90px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label11" runat="server" Text="Costo Emp"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td style="width: 88px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCostoEmp" runat="server" Text='<%# Bind("gasto_empresa") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td style="width: 40px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label12" runat="server" Text="Viático"></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 40px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 40px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label13" runat="server" Text="Traslado"></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 40px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("traslado") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
         <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" /></div>
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
--%>