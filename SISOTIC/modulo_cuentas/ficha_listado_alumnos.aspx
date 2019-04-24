﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_listado_alumnos.aspx.vb" Inherits="Reportes_ficha_listado_alumnos" %>

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
     <script type="text/javascript" >
        function Imprimir()
        {
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
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
    <div id="contenido"> 
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
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos.aspx" Visible="false"><b>Ingreso curso</b></asp:HyperLink>
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
    <div id="resultados">
   
        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Listado de Alumnos"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0">
            <tr>
            <td class="AlineacionIzquierda">
                <asp:Label ID="Label14" runat="server" Text="Correlativo :" Font-Bold="True"></asp:Label>
                <asp:HyperLink ID="hplCorrelativo" runat="server" Font-Bold="True">[hplCorrelativo]</asp:HyperLink></td>
                <td class="AlineacionIzquierda">
                    <asp:Label ID="Label15" runat="server" Text="Estado actual :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblEstadoActual" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda">
                    <asp:Label ID="Label19" runat="server" Text="Origen :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblOrigen" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda">
                    <asp:Label ID="Label23" runat="server" Text="Nº Reg. SENCE :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblNumSence" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
            <td class="AlineacionIzquierda">
                <asp:Label ID="Label6" runat="server" Text="Correlativo empresa :" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblCorrrelativo" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda">
                    <asp:Label ID="Label17" runat="server" Text="Fecha :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda">
                    <asp:Label ID="Label21" runat="server" Text="Fecha Ingreso :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblFechaIngreso" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda">
                    <asp:Label ID="Label25" runat="server" Text="Nº Reg. SENCE Comp :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblNumSenceComp" runat="server" Font-Bold="True"></asp:Label></td>
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
                                <td class="AlineacionIzquierda" style="width: 110px" valign="top">
                                    <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Asistencia"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 110px" valign="top">
                                    <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("porc_asistencia") %>'></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 50px" valign="top">
                                    <asp:Label ID="Label5" runat="server" Text="Origen"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 110px" valign="top">
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
                                <td style="width: 88px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="lblCostoOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 90px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label11" runat="server" Text="Costo Emp"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td style="width: 88px" class="AlineacionIzquierda" valign="top">
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
                                <td style="width: 40px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 40px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label13" runat="server" Text="Traslado"></asp:Label></td>
                                <td class="dosPuntos" style="width: 2px" valign="top">
                                    :</td>
                                <td style="width: 40px" class="AlineacionIzquierda" valign="top">
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
