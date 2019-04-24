<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pagos_terceros.aspx.vb" Inherits="modulo_cursos_pagos_terceros" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte pago a terceros</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
    <script  type="text/jscript">
//    function popup_buscar_empresa() 
//        {
//            //Debe ir en campo el nombre del objeto que aparece en HTML como parametro 
//            btn_popup_buscar_empresa = open('buscador_empresas.aspx?campo=txtRutEmpresa','NewWindow','top=100,left=100,width=700,height=380,status=yes,resizable=no,scrollbars=yes,title="Buscador empresas",closable=no');
//        }
    </script>
   
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                <li class="pestanaconsolaseleccionada">
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
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
         </div>
    </div>
        <%--<div id="header">--%>
           <%--<%--<%-- <ul>
            <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="resumen_grafico.aspx"><b>Resumen de gestión</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Cartola resumen</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aporte.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplCuentas" runat="server" NavigateUrl="reporte_cuentas.aspx"><b>Cuentas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplPorTramo" runat="server" NavigateUrl="reporte_por_tramo.aspx"><b>Por Tramo</b></asp:HyperLink>
                </li>
                <li >
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="../cliente/menu_cargas.aspx"><b>Cargas</b></asp:HyperLink>
                    </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>--%>
        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
            style="width: 980px">
            <tr>
                <th class="Titulo" colspan="10" style="height: 17px" valign="top" width="970">
                    <asp:Label ID="Label19" runat="server" Text="Filtros de búsqueda"></asp:Label>
                </th>
            </tr>
        </table>
        <table id="tablaHeader" style="width: 980px">
                    <tr>
                        <td valign="top" style="width: 991px; height: 22px;">
                            <asp:Label ID="Label9" runat="server" Text="Seleccionar Cliente :"></asp:Label>
                            &nbsp;&nbsp;<asp:TextBox ID="txtRutEmpresa" runat="server" Width="88px"></asp:TextBox>
                            <asp:Button ID="btnPopUpEmpresa" runat="server" Text="..." />
                            &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Año :" Width="40px"></asp:Label>&nbsp;<asp:DropDownList
                                ID="ddlAgnos" runat="server" Width="64px">
                            </asp:DropDownList>&nbsp;
                            <asp:Button ID="btnTraerDatos" runat="server" Text="Consultar" />
                            &nbsp; &nbsp;&nbsp;<br />
                            <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" />&nbsp;
                            <br />
                            <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink></td>
                    </tr>
                     </table>       <table id="Table1" style="width: 980px">
                         <tr>
                            <th class="TituloGrupo" valign="top" style="width: 991px; height: 17px">
                                <asp:Label ID="Label1" runat="server" Text="Listado de solicitudes de pago"></asp:Label>
                            </th>                            
                         </tr>
                     </table>
                <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid" ShowFooter="True" EmptyDataText="Sin datos para el ciclo seleccionado" width ="980px" Height="80px">
                 <Columns>
                     <asp:TemplateField HeaderText="Datos de la Solicitud">
                         <ItemTemplate>
                             <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 82px">
                                         <asp:Label ID="Label8" runat="server" Text="Aporte solicitado" Width="88px" Font-Bold="True"></asp:Label></td>
                                     <td class="DosPuntos" style="width: 76px">
                                         :</td>
                                     <td class="AlineacionIzquierda" style="width: 96px">
                                         <asp:Label ID="lblAporte" runat="server" Text='<%# bind("monto") %>' Font-Bold="True"></asp:Label></td>
                                     <td colspan="3">
                                         <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# bind("cod_curso") %>' />
                                         <asp:HiddenField ID="hdfRutBenefactor" runat="server" />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 82px; height: 18px;">
                                         <asp:Label ID="Label12" runat="server" Text="Beneficiado"></asp:Label></td>
                                     <td class="DosPuntos" style="height: 18px; width: 76px;">
                                         :</td>
                                     <td class="AlineacionIzquierda" style="width: 96px; height: 18px;">
                                         <asp:Label ID="lblNomBeneficiado" runat="server" Text='<%# bind("razon_social") %>'
                                             Width="248px"></asp:Label></td>
                                     <td style="width: 84px; height: 18px;" class="AlineacionIzquierda">
                                         <asp:Label ID="Label33" runat="server" Text="Rut"></asp:Label></td>
                                     <td class="DosPuntos" style="height: 18px">
                                         :</td>
                                     <td style="width: 100px; height: 18px;" class="AlineacionIzquierda">
                                         <asp:Label ID="lblRutBeneficiado" runat="server" Text='<%# bind("rut_cliente") %>' Width="112px"></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 82px">
                                         <asp:Label ID="Label13" runat="server" Text="Fecha ingreso"></asp:Label></td>
                                     <td class="DosPuntos" style="width: 76px">
                                         :</td>
                                     <td class="AlineacionIzquierda" style="width: 96px">
                                         <asp:Label ID="lblFechIngreso" runat="server" Text='<%# bind("fecha_ingreso") %>'
                                             Width="184px"></asp:Label></td>
                                     <td colspan="3">
                                     </td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 82px">
                                         <asp:Label ID="Label18" runat="server" Text="Benefactor"></asp:Label></td>
                                     <td class="DosPuntos" style="width: 76px">
                                         :</td>
                                     <td class="AlineacionIzquierda" style="width: 96px">
                                         <asp:Label ID="lblNomBenefactor" runat="server" Text='<%# bind("razon_social_benefactor") %>'
                                             Width="280px"></asp:Label></td>
                                     <td style="width: 84px" class="AlineacionIzquierda">
                                         <asp:Label ID="Label35" runat="server" Text="Rut"></asp:Label></td>
                                     <td class="DosPuntos">
                                         :</td>
                                     <td style="width: 100px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblRutBenefactor" runat="server" Text='<%# bind("rut_benefactor") %>' Width="112px"></asp:Label></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="500px" Height="30px" />
                         <FooterStyle CssClass="Footer" Width="578px" Height="30px" />
                         <HeaderStyle Width="578px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Datos del curso">
                         <ItemTemplate>
                             <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 48px">
                                         <asp:Label ID="Label2" runat="server" Text="Correlativo"></asp:Label></td>
                                     <td>
                                         :</td>
                                     <td style="width: 100px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblCorrelativo" runat="server" Text='<%# bind("correlativo") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 48px">
                                         <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label></td>
                                     <td>
                                     </td>
                                     <td class="AlineacionIzquierda" style="width: 100px">
                                         <asp:Label ID="lblNombreCurso" runat="server" Text='<%# bind("nombre") %>' Width="224px"></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 48px">
                                         <asp:Label ID="Label4" runat="server" Text="Costo Otic"></asp:Label></td>
                                     <td>
                                         :</td>
                                     <td style="width: 100px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblCostoOtic" runat="server" Text='<%# bind("costo_otic") %>'></asp:Label></td>
                                 </tr>
                                 <tr>
                                     <td class="AlineacionIzquierda" style="width: 48px; height: 18px">
                                         <asp:Label ID="Label5" runat="server" Text="Fecha inicio" Width="64px"></asp:Label></td>
                                     <td style="height: 18px">
                                         :</td>
                                     <td style="width: 100px; height: 18px" class="AlineacionIzquierda">
                                         <asp:Label ID="lblFechaInicio" runat="server" Text='<%# bind("fecha_inicio") %>' Width="150px" Height="16px"></asp:Label></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="380px" Height="0px" />
                         <FooterStyle CssClass="Footer" />
                         <HeaderStyle Width="200px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Acci&#243;n">
                         <ItemTemplate>
                             <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 104px; height: 56px">
                                 <tr>
                                     <td style="width: 95px">
                                         <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" Width="88px" /></td>
                                 </tr>
                                 <tr>
                                     <td style="width: 95px">
                                         <asp:Button ID="btnRechazar" runat="server" OnClick="btnRechazar_Click" Text="Rechazar" Width="88px" /></td>
                                 </tr>
                             </table>
                         </ItemTemplate>
                         <ItemStyle VerticalAlign="Top" Width="100px" Height="0px" />
                         <FooterStyle CssClass="Footer" />
                         <HeaderStyle Width="40px" />
                     </asp:TemplateField>
                 </Columns>          
                </asp:GridView>
        </div>   
               
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
            </div>
           </div>
    </form>    

</body>
</html>
