﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_alumno.aspx.vb" Inherits="Reportes_ficha_alumno" %>


<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../contenido/ascx/cabeceraAlumno.ascx" TagName="cabeceraAlumno" TagPrefix="uc1" %>
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

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
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
                        <asp:HyperLink ID="hplResumenGrafico" runat="server" NavigateUrl="resumen_grafico.aspx"><b>Resumen de gestión</b></asp:HyperLink>
                    </li>
                    <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Cartola resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
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
        <div id="cabecera">
          <table id="tablaDatosAlumno">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Ficha de Alumno"></asp:Label>
                                <asp:Label ID="lblTipo" runat="server"></asp:Label></th>                            
                        </tr>
                     </table>
            <table width="980px";>
                <tr>
                    <td colspan="6" class="AlineacionIzquierda">
                        <asp:Label ID="lblNombreAlumno" runat="server" Font-Bold="True" Width="300px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 302px" class="AlineacionIzquierda">
                        <asp:Label id="lblRut" runat="server" Text="RUT :" Font-Bold="True"></asp:Label>
                        <asp:Label id="lblDataRut" runat="server" Font-Bold="True"></asp:Label></td>
                    <td class="AlineacionIzquierda">
                        <asp:Label id="lblEmpleador" runat="server" Text="Empleador :" Font-Bold="True"></asp:Label>
                        <asp:HyperLink id="hplNombreEmpleador" runat="server" Font-Bold="True">[hplNombreEmpleador]</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 302px" class="AlineacionIzquierda">
                        <asp:Label id="lblFechNac" runat="server" Text="Fecha de nacimiento :" Font-Bold="True"></asp:Label>
                        <asp:Label id="lblDataFechaNac" runat="server" Font-Bold="True"></asp:Label></td>
                    <td class="AlineacionIzquierda">
                        <asp:Label id="lblRutEmpleador" runat="server" Text="Rut :" Font-Bold="True"></asp:Label>
                        <asp:Label id="lblDataRutEmpleador" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
            </table>

        </div>
        <div id="contenido"> 
            <div id="resultados">
                     <asp:GridView id="grdResultados" runat="server" CssClass="Grid" width="100%" EmptyDataText="Sin datos para el ciclo seleccionado" AutoGenerateColumns="False">
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <table width="60" class="TablaInterior">
                                 <tr>
                                     <td align="left" class="AlineacionIzquierda">
                                         <asp:HyperLink ID="hplkCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="height: 18px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblEstadoCurso" runat="server" Text='<%# Bind("estado_curso") %>'></asp:Label></td>
                                 </tr>
                             </table>
                             <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                             <br />
                             <asp:HiddenField ID="hdfRutEmpresa" runat="server" Value='<%# Bind("rut_cliente") %>' />
                             <asp:HiddenField ID="hdfCodSence" runat="server" Value='<%# Bind("codigo_sence") %>' />
                             <asp:HiddenField ID="hdfRutOtec" runat="server" Value='<%# Bind("rut_otec") %>' />
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="60px"  />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Empresa, otec y curso">
                         <ItemTemplate>
                             <table cellpadding="0" cellspacing="0" class="TablaInterior" width="300">
                                 <tr>
                                     <td align="left" valign="top" class="AlineacionIzquierda">
                                         <asp:Label ID="lblEmp" runat="server" Text="Emp"></asp:Label></td>
                                     <td style="width: 2px" valign="top" >
                                         <asp:Label ID="Label4" runat="server" Text=":"></asp:Label></td>
                                     <td valign="top" class="AlineacionIzquierda">
                                         <asp:HyperLink ID="hplkRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'></asp:HyperLink></td>
                                 </tr>
                                 <tr>
                                     <td align="left" valign="top" class="AlineacionIzquierda">
                                         <asp:Label ID="lblCur" runat="server" Text="Curso"></asp:Label></td>
                                     <td style="width: 2px" valign="top">
                                         <asp:Label ID="Label9" runat="server" Text=":"></asp:Label></td>
                                     <td valign="top" class="AlineacionIzquierda">
                                         <asp:HyperLink ID="hplkNombreCurso" runat="server" Text='<%# Bind("nombre_curso") %>'></asp:HyperLink></td>
                                 </tr>
                                 <tr>
                                     <td align="left" valign="top" class="AlineacionIzquierda" style="height: 18px">
                                         <asp:Label ID="lblOt" runat="server" Text="OTEC"></asp:Label></td>
                                     <td style="width: 2px; height: 18px;" valign="top">
                                         <asp:Label ID="lblDosPunOtec" runat="server" Text=":"></asp:Label></td>
                                     <td valign="top" class="AlineacionIzquierda" style="height: 18px">
                                         <asp:HyperLink ID="hplkNombreOtec" runat="server" Text='<%# Bind("razon_social_otec") %>'></asp:HyperLink></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="300px"  />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Datos Curso">
                         <ItemTemplate>
                             <table class="TablaInterior">
                                 <tr>
                                     <td style="width: 80px" class="AlineacionIzquierda">
                                         &nbsp;<asp:Label ID="lblIni" runat="server" Text="Inicio"></asp:Label></td>
                                     <td>
                                         :</td>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblFechaIni" runat="server" Text='<%# Bind("fecha_inicio") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td style="width: 80px" class="AlineacionIzquierda">
                                         &nbsp;<asp:Label ID="lblFin" runat="server" Text="Fin"></asp:Label></td>
                                     <td>
                                         :</td>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblFechaFin" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td style="width: 80px" class="AlineacionIzquierda">
                                         &nbsp;<asp:Label ID="lblEm" runat="server" Text="#Emp"></asp:Label></td>
                                     <td>
                                         :</td>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("correlativo_empresa") %>'></asp:Label></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="150px"  />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Datos Alumno">
                         <ItemTemplate>
                             <table class="TablaInterior">
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblFran" runat="server" Text="Franquicia"></asp:Label></td>
                                     <td style="width: 7px">
                                         <asp:Label ID="lblDosPuntos1" runat="server" Text=":"></asp:Label></td>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label>
                                         <asp:Label ID="lblPorcentaje" runat="server" Text="%"></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="Label2" runat="server" Text="Asistencia"></asp:Label></td>
                                     <td style="width: 7px">
                                         <asp:Label ID="Label3" runat="server" Text=":"></asp:Label></td>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("porc_asistencia") %>'></asp:Label>
                                         <asp:Label ID="lbPasis" runat="server" Text="%"></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td style="height: 16px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblNivE" runat="server" Text="Nivel Educ"></asp:Label></td>
                                     <td style="width: 7px; height: 16px">
                                         <asp:Label ID="Label7" runat="server" Text=":"></asp:Label></td>
                                     <td style="height: 16px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblNivelEduc" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblNivP" runat="server" Text="Nivel Prof"></asp:Label></td>
                                     <td style="width: 7px">
                                         <asp:Label ID="Label8" runat="server" Text=":"></asp:Label></td>
                                     <td class="AlineacionIzquierda">
                                         <asp:Label ID="lblNivelPro" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="150px"  />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Monto">
                         <ItemTemplate>
                             <table class="TablaInterior">
                                 <tr>
                                     <td style="width: 70px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblCost" runat="server" Text="OTIC"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 10px">
                                         <asp:Label ID="lblDosPunOt" runat="server" Text=":"></asp:Label></td>
                                     <td style="height: 18px" class="AlineacionDerecha">
                                         <asp:Label ID="lblCostOtic" runat="server" Text='<%# Bind("CostoOticAl") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 70px">
                                         <asp:Label ID="lblCostEmp" runat="server" Text="Empresa"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 10px">
                                         <asp:Label ID="lblDosPunEmp" runat="server" Text=":"></asp:Label></td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblCostoEmp" runat="server" Text='<%# Bind("CostoEmpAl") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 70px">
                                         <asp:Label ID="lblV" runat="server" Text="Vitatico"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 10px">
                                         <asp:Label ID="lblDosPunVia" runat="server" Text=":"></asp:Label></td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("Viatico") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 70px;">
                                         <asp:Label ID="lblT" runat="server" Text="Traslado"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 10px">
                                         <asp:Label ID="lblDosPunTra" runat="server" Text=":"></asp:Label></td>
                                     <td style="height: 14px" class="AlineacionDerecha">
                                         <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("Traslado") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td style="width: 70px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblTot" runat="server" Text="Total"></asp:Label></td>
                                     <td class="AlineacionIzquierda" style="width: 10px">
                                         <asp:Label ID="lblDosPunTot" runat="server" Text=":"></asp:Label></td>
                                     <td class="AlineacionDerecha">
                                         <asp:Label ID="lblTotal" runat="server" Text='<%# bind("total") %>'></asp:Label></td>
                                 </tr>
                             </table>
                             
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="140px"  />
                     </asp:TemplateField>
                 </Columns>          
                </asp:GridView>
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
