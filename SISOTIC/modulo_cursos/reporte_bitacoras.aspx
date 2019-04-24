<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_bitacoras.aspx.vb" Inherits="modulo_cursos_reporte_bitacoras" EnableEventValidation="false" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte de bitácora</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
    <div id="contenido">
     <table class="TituloGrupo">
                        <tr>
                            <th width="980px" valign="top" class="TituloGrupo" style="height: 29px">
                                <asp:Label ID="Label4" runat="server" Text="Bitácora"></asp:Label>  </th>                         
                        </tr>
                     </table>
        <table cellpadding="0" cellspacing="0" class="TablaInterior" id="tbBitacoraCurso" runat="server" visible="false" style="width: 976px">
            <tr>
                <td class="Alineacionizquerda" style="width: 13%; height: 17px;">
                    <asp:Label ID="Label2" runat="server" Text="Correlativo" Font-Bold="False"></asp:Label></td>
                <td style="width: 2%; height: 17px;">
                    :</td>
                <td class="Alineacionizquerda" style="width: 10%; height: 17px;">
                    <asp:Label ID="lblCorrelativo" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 10%; height: 17px;">
                    <asp:Label ID="Label6" runat="server" Text="Estado actual"></asp:Label></td>
                <td style="width: 2%; height: 17px;">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 10%; height: 17px;">
                    <asp:Label ID="lblEstado" runat="server"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 10%; height: 17px;">
                    <asp:Label ID="Label12" runat="server" Text="Origen"></asp:Label></td>
                <td style="width: 2%; height: 17px;">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 11%; height: 17px;">
                    <asp:Label ID="lblOrigen" runat="server"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 12%; height: 17px;">
                    <asp:Label ID="Label14" runat="server" Text="NºReg. SENCE" Font-Bold="True"></asp:Label></td>
                <td style="width: 2%; height: 17px;">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 10%; height: 17px;">
                    <asp:Label ID="lblRegSence" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="Alineacionizquerda" style="width: 13%">
                    <asp:Label ID="Label3" runat="server" Text="Correlativo Empresa" Font-Bold="False"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td class="Alineacionizquerda" style="width: 10%">
                    <asp:Label ID="lblCorrelEmp" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 10%">
                    <asp:Label ID="Label7" runat="server" Text="Fecha"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 10%">
                    <asp:Label ID="lblFecha" runat="server"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 10%">
                    <asp:Label ID="Label13" runat="server" Text="Fecha ingreso"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 11%">
                    <asp:Label ID="lblFechIngreso" runat="server"></asp:Label></td>
                <td class="AlineacionDerecha" style="width: 12%">
                    <asp:Label ID="Label15" runat="server" Text="NºReg. SENCE compl"></asp:Label></td>
                <td style="width: 2%">
                    :</td>
                <td class="AlineacionIzquierda" style="width: 10%">
                    <asp:Label ID="lblRegSenCompl" runat="server" Text="-"></asp:Label></td>
            </tr>
        </table><table cellpadding="0" cellspacing="0" class="Grid" style="width: 980px" id="tbBitacoraFactura" runat="server" visible="false">
            <tr>
                <td class="AlineacionIzquerda" style="width: 14%; height: 18px;">
                    <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="Correlativo curso:" Width="88px"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 16%; height: 18px;">
                    <asp:Label ID="lblCorrelativoFactura" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquerda" style="width: 14%; height: 18px;">
                    <asp:Label ID="Label10" runat="server" Text="Estado actual:"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 16%; height: 18px;">
                    <asp:Label ID="lblEstadoFactura" runat="server"></asp:Label></td>
                <td class="AlineacionIzquerda" style="width: 14%; height: 18px;" colspan="3">
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Número factura:"></asp:Label></td>
                <td class="AlineacionIzquerda" style="width: 12%; height: 18px;">
                    <asp:Label ID="lblNumFactura" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquerda" style="width: 14%">
                    <asp:Label ID="Label20" runat="server" Font-Bold="False" Text="Otec:"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 16%">
                    <asp:Label ID="lblNombreOtec" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="AlineacionIzquerda" style="width: 14%">
                    <asp:Label ID="Label24" runat="server" Text="Fecha factura:"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 16%">
                    <asp:Label ID="lblFechaFactura" runat="server"></asp:Label></td>
                <td class="AlineacionIzquerda" style="width: 14%" colspan="3">
                    <asp:Label ID="Label28" runat="server" Text="Monto:"></asp:Label></td>
                <td class="AlineacionIzquerda" style="width: 12%">
                    <asp:Label ID="lblMontoFactura" runat="server" Text="-"></asp:Label></td>
            </tr>
        </table>
        <table id="TablaMensaje" runat="server" cellpadding="0" cellspacing="0" visible="true"
            width="100%">
            <tr>
                <td style="width: 100%">
                    <asp:Label ID="Label21" runat="server" Font-Bold="False" Text="Desde :"></asp:Label>
                    <ew:CalendarPopup ID="calFechaInicial" runat="server" ClearDateText="Limpiar fecha"
                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" 
                        Nullable="True" PadSingleDigits="True" PostedDate=""
                        SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                            <TextBoxLabelStyle Width="65px" />
                        </ew:CalendarPopup>
                    &nbsp;<asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Hasta :"></asp:Label>
                     <ew:CalendarPopup ID="calFechaFinal" runat="server" ClearDateText="Limpiar fecha"
                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)" 
                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" 
                        Nullable="True" PadSingleDigits="True" PostedDate=""
                        SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                            <TextBoxLabelStyle Width="65px" />
                        </ew:CalendarPopup>
                    <br />
                    <asp:Button ID="btnConsultar" runat="server" Font-Bold="False" Text="Consultar" ValidationGroup="ValidaRutAlumno" /></td>
            </tr>
        </table>
        <div id="resultados">
            <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado" Height="1px"
                Width="975px">
                <Columns>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemStyle CssClass="AlineacionIzquierda" Height="0px" HorizontalAlign="Left" VerticalAlign="Top"
                            Width="150px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 30%">
                                        <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label></td>
                                    <td style="width: 2%">
                                        :</td>
                                    <td style="width: 69%">
                                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("fecha_hora") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Autor">
                        <ItemStyle Height="0px" VerticalAlign="Top" Width="150px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 48px">
                                        <asp:Label ID="Label5" runat="server" Text="Autor"></asp:Label></td>
                                    <td class="DosPuntos">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 330px">
                                        &nbsp;<asp:Label ID="lblAutor" runat="server" Text='<%# Bind("nombres") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observaci&#243;n">
                        <ItemStyle Height="0px" HorizontalAlign="Left" VerticalAlign="Top" Width="500px" />
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="600">
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("obs") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
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
            <br />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" /><br />
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
