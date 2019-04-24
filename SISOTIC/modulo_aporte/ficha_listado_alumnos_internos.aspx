﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_listado_alumnos_internos.aspx.vb" Inherits="Reportes_ficha_listado_alumnos_internos" EnableEventValidation="false"  %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Listado de Alumnos</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
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
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
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
                    <asp:HyperLink ID="hplPorTramo" runat="server" NavigateUrl="reporte_por_tramo.aspx"><b>Por Tramo</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank"  NavigateUrl="certificado_aportes.aspx"><b>Certif. aportes</b></asp:HyperLink>
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
                                <asp:Label ID="Label1" runat="server" Text="Listado de Alumnos Internos"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0">
            <tr>
            <td class="AlineacionIzquierda">
                <asp:Label ID="Label14" runat="server" Text="Correlativo :" Font-Bold="True"></asp:Label>
                <asp:HyperLink ID="hplCorrelativo" runat="server" Font-Bold="True">[hplCorrelativo]</asp:HyperLink></td>
                <td class="AlineacionIzquierda">
                    &nbsp;<asp:Label ID="Label21" runat="server" Text="Fecha Inicio :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblFechaInicio" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
            <td class="AlineacionIzquierda">
                <asp:Label ID="Label6" runat="server" Text="Curso :" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblCursoInterno" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquierda">
                    <asp:Label ID="Label17" runat="server" Text="Fecha Termino :" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblFechaTermino" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="grdResultados" runat="server" Width="980px" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior" width="200">
                            <tr>
                                <td style="width: 200px" valign="top" class="AlineacionIzquierda">
                                    <asp:HyperLink ID="hplNomAlumno" runat="server" Text='<%# Bind("nombre_completo_") %>'></asp:HyperLink><br />
                                    <asp:Label ID="Label3" runat="server" Text="Rut :"></asp:Label>
                                    <asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut") %>'></asp:Label>
                                    <br />
                                    <asp:HiddenField ID="hdfRutAlumno" runat="server" Value='<%# Bind("rut") %>' />
                                    <asp:HiddenField ID="hdfTipo" runat="server" Value="Interno" />
                                </td>
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
                                <td class="AlineacionIzquierda" style="width: 250px" valign="top">
                                    <asp:Label ID="lblNivEducacional" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label8" runat="server" Text="Niv Profesional"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 250px" valign="top">
                                    <asp:Label ID="lblNivProfesional" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha de Nac"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 250px" valign="top">
                                    <asp:Label ID="lblFechNac" runat="server" Text='<%# Bind("fecha_nacim") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior" width="150">
                            <tr>
                                <td style="width: 90px" class="AlineacionIzquierda" valign="top">
                                    <asp:Label ID="Label10" runat="server" Text="Costo curso"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td style="width: 88px" class="AlineacionDerecha" valign="top">
                                    <asp:Label ID="lblCosto" runat="server" Text='<%# Bind("valor_curso") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior" width="150">
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label723" runat="server" Text="Viatico"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 250px" valign="top">
                                    <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlimeacionIzquierda" style="width: 100px" valign="top">
                                    <asp:Label ID="Label823" runat="server" Text="Traslado"></asp:Label></td>
                                <td class="dosPuntos" valign="top">
                                    :</td>
                                <td class="AlineacionIzquierda" style="width: 250px" valign="top">
                                    <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("traslado") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
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
