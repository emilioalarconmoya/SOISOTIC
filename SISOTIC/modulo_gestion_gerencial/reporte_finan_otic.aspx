<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_finan_otic.aspx.vb" Inherits="modulo_gestion_gerencial_reporte_finan_otic" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Financiamiento Otic</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js">function pie_onclick() {

}

function mantenedor_onclick() {

}

</script>    
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
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
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_finan_otic.aspx"><b>Financiamiento otic</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_resumen_cliente.aspx"><b>Estado Cliente</b></asp:HyperLink>
                </li>
                <li >
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
        <fieldset id="mantenedor" style="width: 90%" onclick="return mantenedor_onclick()" >
            <div id="filtrosMantenedor" style="width: 100%">
                        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
                            style="width: 960px; height: 48px">
                            <tr>
                                <th class="Titulo" colspan="5" style="height: 17px; width: 970px;" valign="top">
                                    <asp:Label ID="Label183" runat="server" Text="Filtro de búsqueda"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" colspan="2" style="height: 19px">
                                    <asp:Label ID="Label188" runat="server" Font-Bold="True" Text="Año :" Width="40px"></asp:Label><asp:DropDownList
                                        ID="ddlAgnos" runat="server" Width="64px">
                                    </asp:DropDownList>&nbsp;
                                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />&nbsp;<asp:CheckBox
                                        ID="chkBajarReporte" runat="server" Text="Bajar Reporte" />
                                    <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[BajarReporte]</asp:HyperLink></td>
                            </tr>
                        </table>
                <br />
                &nbsp;&nbsp;<asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False"
                    CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado" Height="32px"
                    ShowFooter="True" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Datos Empresa">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 100px">
                                            <asp:Label ID="Label1" runat="server" Text="Rut del Cliente"></asp:Label></td>
                                        <td class="AlineacionIzquierda">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 100px">
                                            <asp:Label ID="lblRutCliente" runat="server" Text='<%# bind("rut") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 100px">
                                            <asp:Label ID="Label2" runat="server" Text="Razon Social del Cliente" Width="112px"></asp:Label></td>
                                        <td class="AlineacionIzquierda">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 100px">
                                            <asp:Label ID="lblRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'
                                                Width="256px"></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Left" Width="70%" Wrap="False" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cta. de financiamiento Otic">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                &nbsp;<table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 37px">
                                            <asp:Label ID="Label3" runat="server" Text="Saldo"></asp:Label></td>
                                        <td style="width: 2px">
                                            :</td>
                                        <td class="AlineacionDerecha" style="width: 100px">
                                            <asp:Label ID="lblSaldo" runat="server" Text='<%# bind("total_monto") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Left" Width="30%" Wrap="False" />
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <br />
                <br />
                &nbsp;<br />
            </div>
        </fieldset>       
    </div>
     <div id="pie" onclick="return pie_onclick()">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>
    </form><%--
                        </td>--%>
</body>
</html>
