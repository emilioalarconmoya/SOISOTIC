<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ranking_otec.aspx.vb" Inherits="modulo_gestion_gerencial_ranking_otec" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Ranking Otec</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnBuscar">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
    <div id="menu">
        <div id="header">
            <ul>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_cartera.aspx"><b>Cartera</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_agno.aspx"><b>Mov. x año</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_mes.aspx"><b>Mov x mes</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_anual.aspx"><b>Gestión anual</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_mensual.aspx"><b>Gestión mensual</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulo_gestion_gerencial/estadisticas.aspx"><b>Estadísticas</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_finan_otic.aspx"><b>Financiamiento otic</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_resumen_cliente.aspx"><b>Estado Cliente</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/modulo_gestion_gerencial/ranking_otec.aspx"><b>Ranking otec</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="../menu.aspx"><b>Menú</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        <fieldset id="mantenedor" >
                        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
                            style="width: 968px; height: 48px">
                            <tr>
                                <th class="Titulo" colspan="12" style="height: 17px; width: 980px;" valign="top">
                                    <asp:Label ID="Label183" runat="server" Text="Filtros de búsqueda"></asp:Label>
                                </th>
                            </tr>
                        </table>
                <table style="width: 968px" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 63px; height: 15px;">
                            <asp:Label ID="Label1" runat="server" Text="Por HH"></asp:Label>
                            <asp:RadioButton ID="rbtnHH" runat="server" Checked="True" GroupName="*" /></td>
                        <td class="AlineacionIzquierda" style="width: 85px; height: 15px;">
                            <asp:Label ID="Label2" runat="server" Text="Por $ Curso"></asp:Label>
                            <asp:RadioButton ID="rbtnValor" runat="server" GroupName="*" /></td>
                        <td class="AlineacionIzquierda" style="width: 140px; height: 15px;">
                            <asp:Label ID="Label3" runat="server" Text="Por Participantes (C/R)"></asp:Label>
                            <asp:RadioButton ID="rbtnPartiCR" runat="server" GroupName="*" /></td>
                        <td class="AlineacionIzquierda" style="width: 124px; height: 15px;">
                            <asp:Label ID="Label4" runat="server" Text="Por Participantes"></asp:Label>
                            <asp:RadioButton ID="rbtnPariSR" runat="server" GroupName="*" /></td>
                        <td style="width: 100px; height: 15px;">
                            <asp:Label ID="Label5" runat="server" Text="Año"></asp:Label>
                            <asp:DropDownList ID="ddlAgno" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 100px; height: 15px;">
                            <asp:Label ID="Label6" runat="server" Text="Rango"></asp:Label>
                            <asp:DropDownList ID="ddlRango" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 63px; height: 16px;">
                        </td>
                        <td style="width: 85px; height: 16px;">
                        </td>
                        <td colspan="2" style="height: 16px">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" /></td>
                        <td style="width: 100px; height: 16px;">
                        </td>
                        <td style="width: 100px; height: 16px;">
                        </td>
                    </tr>
                </table>
            <br />
            <asp:Label ID="lblNombreRanking" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Arial Black" Font-Size="Large"></asp:Label><br />
            <br />
            <asp:GridView ID="grdResultado" runat="server" AutoGenerateColumns="False" Width="560px" CssClass="Grid" Height="100px" HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <table class="TablaInterior">
                                    <tr>
                                        <td style="width: 100px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblTotal" runat="server" Text='<%# bind("total") %>'></asp:Label>
                                            <%--<asp:Label ID="lblTotalGasto" runat="server" Text='<%# bind("totgasto") %>'></asp:Label>
                                            <asp:Label ID="lblTotalParticipaciones" runat="server" Text='<%# bind("totparticipaciones") %>'></asp:Label>
                                            <asp:Label ID="lblTotalParticipantes" runat="server" Text='<%# bind("partic") %>'></asp:Label>--%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Otec">
                            <ItemTemplate>
                                <table class="TablaInterior" style="width: 208px">
                                    <tr>
                                        <td style="width: 99px">
                                            <asp:Label ID="lblRut" runat="server" Text='<%# bind("rut") %>'></asp:Label></td>
                                        <td style="width: 1px">
                                            -</td>
                                        <td align="left" class="AlineacionIzquierda" style="width: 441px">
                                            <asp:Label ID="lblNombre" runat="server" Text='<%# bind("razon_social") %>' Width="296px"></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle Width="460px" />
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
            <br />
            <table>
                <tr>
                    <td align="center" rowspan="2" style="width: 440px">
                        <asp:Literal ID="litGrafico" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                </tr>
            </table>
        </fieldset>       
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>
    </form><%--
                        </td>--%>
</body>
</html>
