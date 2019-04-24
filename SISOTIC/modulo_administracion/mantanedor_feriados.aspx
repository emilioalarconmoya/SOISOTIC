<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantanedor_feriados.aspx.vb" Inherits="modulo_administracion_mantanedor_feriados" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Feriados</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
        <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile" width="980"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
         <div id="menu">
             <div id="header">
                 <ul>
                    <li >
                        <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx"><b>Menú Administración</b></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                    </li>
                </ul>
             </div>
        </div>
        <table style="width: 980px" class="tabla">
            <tr>
                <th class="AlineacionIzquierda">
                    <asp:Label ID="Label1" runat="server" Text="Criterio de busqueda"></asp:Label>
                </th>
            </tr>
            <tr>
                <td align="center" colspan="3" style="width: 100%; height: 20px" valign="top">
                    <asp:Label ID="Label5" runat="server" Text="Año :"></asp:Label>
                    <asp:DropDownList ID="ddlAgno" runat="server">
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" meta:resourcekey="btnConsultarResource1" />
                    <asp:Button ID="btnAplicar1" runat="server" Text="Aplicar cambios" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="" style="width: 100%; height: 375px" valign="top" rowspan="">
                    <div style="width: 550px; margin-left: auto; margin-right: auto; text-align: left;">
                        <asp:Label ID="lblAgregarNueva" runat="server" Text="Agregar nuevo día feriado"></asp:Label>
                        <asp:Button ID="btnAgregar" runat="server" Text="+" />
                        <asp:GridView ID="grdFeriados" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Fecha">
                                    <ItemTemplate>
                                        <ew:CalendarPopup ID="calFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                                            ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                            DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                            ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                            PopupLocation="Left" SelectedDate='<%# bind("fecha") %>' ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PostedDate="" UpperBoundDate="12/31/9999 23:59:59"              >
                                            <TextBoxLabelStyle Width="65px" />
                                        </ew:CalendarPopup>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMotivo" runat="server" Width="290px" Text='<%# bind("motivo") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEliminar" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="10px" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <asp:Button ID="btnAplicar2" runat="server" Text="Aplicar cambios" />
                </td>
            </tr>
        </table>    
    </div>
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
