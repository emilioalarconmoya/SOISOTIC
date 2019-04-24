<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_aportes.aspx.vb" Inherits="modulo_aporte_reporte_aportes" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script  type="text/jscript">
        
        function CambiarValor()
        {
           
           if (document.form1.rblCorrelativo_0.checked == true ) 
           {
            document.form1.rblCorrelativo_0.checked = false;
            document.form1.rblCorrelativo_1.checked = true;
           }
        }
     
    </script>
<head runat="server">
    <title>Reporte Aportes</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />

</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario id="datos_personales1" runat="server" />
    </div>
    <div id="menu">
        <div id="header">
            <ul>
                <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplResumenCobranza" runat="server" NavigateUrl="resumen_cobranza.aspx"><b>Resumen de cobranza</b></asp:HyperLink>
               </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Reporte aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscadorAportes" runat="server" NavigateUrl="Reporte_buscar_aportes.aspx"><b>Buscador Aportes</b></asp:HyperLink>
                </li>
               <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="Listado_Facturas.aspx"><b>Listado facturas</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplNuevoAporte" runat="server" NavigateUrl="ingreso_aporte.aspx"><b>Nuevo aporte</b></asp:HyperLink>
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
        &nbsp;
        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
            style="width: 980px; height: 48px">
            <tr>
                <th class="Titulo" colspan="10" style="height: 17px" valign="top" width="970">
                    <asp:Label ID="Label183" runat="server" Text="Filtros de búsqueda"></asp:Label>
                </th>
            </tr>
            <tr>
                <td class="AlineacionCentro" colspan="7" style="height: 19px">
                    <asp:Label ID="Label186" runat="server" Font-Bold="True" Text="Rut Empresa: "></asp:Label>
                    <asp:TextBox
                        ID="txtRutEmpresa" runat="server" MaxLength="12" Width="88px"></asp:TextBox><asp:CustomValidator
                            ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                            ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un rut válido"
                            ValidationGroup="xx">*</asp:CustomValidator><asp:Button ID="btnPopUpEmpresa" runat="server"
                                Text="..." />
                    &nbsp; &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="Aporte: "></asp:Label>
                    <asp:DropDownList ID="ddlAporte" runat="server">
                    </asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Año: " Width="24px"></asp:Label>
                    <asp:DropDownList ID="ddlAgno" runat="server" Width="64px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;<asp:Label ID="lblNumAporte" runat="server" Text="Nº Aporte : "></asp:Label>
                    <asp:TextBox ID="txtNumAporte" runat="server"></asp:TextBox>&nbsp;<asp:RadioButton
                        ID="rbCorrelativo1" runat="server" Checked="True" GroupName="rbCorrelativo" Text="Nada" />
                    <asp:RadioButton ID="rbCorrelativo2" runat="server" GroupName="rbCorrelativo" Text="=" />
                    <asp:RadioButton ID="rbCorrelativo3" runat="server" GroupName="rbCorrelativo" Text=">" />
                    <asp:RadioButton ID="rbCorrelativo4" runat="server" GroupName="rbCorrelativo" Text="<" />
                    <asp:RadioButton ID="rbCorrelativo5" runat="server" GroupName="rbCorrelativo" Text="<>"
                        Width="40px" />
                    &nbsp;&nbsp;&nbsp;<br />
                    &nbsp;<br />
                    &nbsp;<asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" /><br />
                    <asp:CheckBox
                        ID="chkBajarReporte" runat="server" Text="Bajar Reporte" /><br />
                    <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[BajarReporte]</asp:HyperLink><br />
                    <asp:CheckBox
                        ID="chkBajarReporteTxt" runat="server" Text="Bajar Reporte .txt" Visible ="false"  /><br />
                    <asp:HyperLink ID="hplBajarReporteTxt" runat="server" Visible="False">[BajarReporte]</asp:HyperLink><br />
                    &nbsp;
                    <asp:CheckBox
                        ID="chkBajarSence" runat="server" Text="Generar archivo de aportes SENCE " Visible ="false" /><br />
                    <asp:HyperLink ID="hplBajarReporteSence"
                            runat="server" Visible="False">[BajarReporteSence]</asp:HyperLink></td>
            </tr>
            <tr>
                <td align="center" class="AlineacionIzquierda" style="height: 15px" colspan="7">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx"
                        Width="152px" CssClass="margenAdvertencia" />
                </td>
            </tr>
        </table>
        <fieldset id="mantenedor" >
           <%-- <div id="filtrosMantenedor">--%>
                <div>
                <table id="tablaHeader">
                    <tr>
                        <th width="980px" class="TituloGrupo" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="Listado de aportes "></asp:Label>
                            <asp:Label ID="lblTipo" runat="server"></asp:Label></th>                            
                    </tr>
                </table>
                <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid" ShowFooter="True" EmptyDataText="Sin datos para el ciclo seleccionado" width ="960px" OnRowDataBound="grdResultados_RowDataBound">
                   <Columns>
                       <asp:TemplateField HeaderText="  Num. Aporte">
                           <ItemTemplate>
                               <table class="TablaInterior">
                                   <tr>
                                       <td style="width: 100px">
                                           &nbsp;
                                           <asp:HyperLink ID="hplNumAporte" runat="server" Text='<%# bind("num_aporte") %>'></asp:HyperLink><br />
                                           <asp:Label ID="lblEstadoAporte" runat="server" Text='<%# Bind("estado_aporte") %>'></asp:Label></td>
                                   </tr>
                               </table>
                               <asp:HiddenField ID="hdfCodAporte" runat="server" Value='<%# Bind("cod_aporte") %>' />
                               <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# Bind("rut_cliente") %>' />
                               <asp:HiddenField ID="hdfCodEstado" runat="server" Value='<%# Bind("cod_estado") %>'/>
                           </ItemTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" Width="60px" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Empresa">
                           <ItemTemplate>
                               <table class="TablaInterior">
                                   <tr>
                                       <td class="AlineacionIzquierda" colspan="2">
                                           <asp:HyperLink ID="hplRazonSocial" runat="server" Text='<%# Bind("Razon_Social") %>'></asp:HyperLink></td>
                                   </tr>
                                   <tr>
                                       <td class="AlineacionIzquierda" colspan="2">
                               <asp:Label ID="Label2" runat="server" Text="Cuenta destino: " CssClass="dosPuntos" Width="72px"></asp:Label>
                                           <asp:Label ID="lblNombreCuenta" runat="server" Text='<%# Bind("nombre_cuenta") %>'></asp:Label></td>
                                   </tr>
                               </table>
                           </ItemTemplate>
                           <FooterTemplate>
                               &nbsp;
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Width="440px" Height="0px" VerticalAlign="Top" HorizontalAlign="Left" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Aporte">
                           <ItemTemplate>
                               <asp:Label ID="lblAporte" runat="server" Text='<%# Bind("monto_neto") %>'></asp:Label>
                           </ItemTemplate>
                           <FooterTemplate>
                               <asp:Label ID="lblTotAbono" runat="server"></asp:Label>
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Datos Pago">
                           <ItemTemplate>
                               <table class="TablaInterior">
                                   <tr>
                                       <td class="AlineacionIzquierda" style="width: 61px">
                               <asp:Label ID="lblNombreDocumento" runat="server" Text="Tipo doc.:"></asp:Label>&nbsp;</td>
                                       <td class="AlineacionIzquierda" style="width: 144px">
                               <asp:Label ID="lblTipoDocumento" runat="server" Text='<%# bind("nom_tipo_docu") %>'></asp:Label></td>
                                   </tr>
                                   <tr>
                                       <td class="AlineacionIzquierda" style="width: 61px">
                               <asp:Label ID="Label5" runat="server" Text="Nro. doc.:"></asp:Label></td>
                                       <td class="AlineacionIzquierda" style="width: 144px">
                               <asp:Label ID="lblNumeroDocumento" runat="server" Text='<%# bind("nro_documento") %>'></asp:Label>
                                           <asp:Label ID="lblBanco" runat="server" Text='<%# bind("banco") %>'></asp:Label></td>
                                   </tr>
                                   <tr>
                                       <td class="AlineacionIzquierda" style="width: 61px">
                               <asp:Label ID="Label7" runat="server" Text="Vencimiento: "></asp:Label></td>
                                       <td class="AlineacionIzquierda" style="width: 144px">
                               <asp:Label ID="lblFechaVencimineto" runat="server" Text='<%# bind("fecha_venc_doc") %>'></asp:Label></td>
                                   </tr>
                               </table>
                           </ItemTemplate>
                           <FooterTemplate>
                               <asp:Label ID="lblTotCargo" runat="server"></asp:Label>
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" Width="180px" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Control">
                           <ItemTemplate>
                               <table class="TablaInterior">
                                   <tr>
                                       <td class="AlineacionIzquierda" style="width: 61px">
                                           <asp:Label ID="Label6" runat="server" Text="Ingreso:"></asp:Label></td>
                                       <td class="AlineacionIzquierda" style="width: 117px">
                               <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# bind("fecha_ingreso") %>'></asp:Label></td>
                                   </tr>
                                   <tr>
                                       <td class="AlineacionIzquierda" style="width: 61px">
                               <asp:Label ID="Label9" runat="server" Text="Cobro: "></asp:Label></td>
                                       <td class="AlineacionIzquierda" style="width: 117px">
                               <asp:Label ID="lblFechaCobro" runat="server" Text='<%# bind("fecha_cobro") %>'></asp:Label></td>
                                   </tr>
                               </table>
                           </ItemTemplate>
                           <FooterTemplate>
                               <asp:Label ID="lblSaldoAct" runat="server"></asp:Label>
                           </FooterTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Acci&#243;n">
                           <ItemTemplate>
                               <asp:HyperLink ID="hplModicficar" runat="server">Modificar</asp:HyperLink>&nbsp;<br />
                               <asp:HyperLink ID="hplAnular" runat="server">Anular</asp:HyperLink>
                           </ItemTemplate>
                           <FooterStyle CssClass="Footer" />
                           <ItemStyle Height="0px" VerticalAlign="Top" />
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
	            <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="Últ. Pag"  CommandArgument="Last" CssClass="paglast" />
	        </div>
           </PagerTemplate>
           <PagerStyle CssClass="pagerstyle" />
               </asp:GridView>
            </div>
            <%--</div>--%>
        </fieldset>       
    </div>
     <div id="pie" onclick="return pie_onclick()">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>