<%@ Page Language="VB" AutoEventWireup="false" CodeFile="listado_generacion_certificados_aporte.aspx.vb" Inherits="modulo_administracion_listado_generacion_certificados_aporte" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Listado y generación de certificados de aporte</title>
<script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
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
                <%--<li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="#"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="../modulo_cursos/reporte_cursos.aspx"><b>Reporte cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="#"><b>Buscar curso</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="#"><b>Carga de cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="../modulo_cursos/pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="#"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="../modulo_cursos/mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl="#"><b>Curso no Sence</b></asp:HyperLink>
                </li>--%>
                 <li >
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx"><b>Menú Administración</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table class="TablaInterior" cellpadding="0" cellspacing="0" width="90%" id="tablaFiltro">
                    <tr>
                        <th colspan="6">
                        <asp:Label ID="Label1" runat="server" Text="Buscador"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionCentro" colspan="6" style="height: 25px">
                            <asp:Label ID="Label2" runat="server" Text="Rut empresa : "></asp:Label>
                            <asp:TextBox ID="txtRutEmpresa" runat="server"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRutEmpresa" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Label ID="Label5" runat="server" Text="Razón social :"></asp:Label>
                            <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" Text="Año :"></asp:Label>&nbsp;
                            <asp:DropDownList ID="ddlAgno" runat="server">
                            </asp:DropDownList>&nbsp;<br />
                            </td>
                    </tr>
                    </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
                <asp:Button ID="btnGenerar" runat="server" Text="Genaral Certificado" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
                <br />
                <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" />&nbsp;
                <asp:HyperLink
                    ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink></div>
            <div id="listado">
                <asp:GridView ID="grdResultados" runat="server" Width="90%" AutoGenerateColumns="False" CssClass="Grid" Height="0px" EmptyDataText="Sin datos para el ciclo seleccionado">
                    <Columns>
                        <asp:TemplateField HeaderText="Certificado">
                            <ItemTemplate>
                                <asp:Label ID="lblCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="1%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rut Empresa">
                            <ItemTemplate>
                                <asp:Label ID="lblRutEmpresa" runat="server" Text='<%# Bind("rut") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Razon Social">
                            <ItemTemplate>
                                <asp:Label ID="lblRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="34%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contacto">
                            <ItemTemplate>
                                <asp:Label ID="lblContacto" runat="server" Text='<%# Bind("nom_contacto") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fono Contacto">
                            <ItemTemplate>
                                <asp:Label ID="lblFonoContacto" runat="server" Text='<%# Bind("fono_contacto") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>       
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
