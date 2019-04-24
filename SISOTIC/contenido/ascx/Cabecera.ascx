<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cabecera.ascx.vb" Inherits="contenido_ascx_cabecera" %>
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    

<table id="cabeceraUsuario" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="8" class="CabeceraRasonSocial">
            <asp:HyperLink ID="HplkRazonSocial" runat="server"></asp:HyperLink></td>
        <td colspan="4" id="td4" runat="server">
            <asp:Label ID="lblFechaActual" runat="server"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="-"></asp:Label>
            <asp:Label ID="lblHoraActual" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="titDatos1" style="width: 60px;">
            <asp:Label ID="lblRut" runat="server" Text="RUT"></asp:Label></td>
        <td class="dosPuntos" style="width: 1px;">
            <asp:Label ID="Label1" runat="server" Text=":"></asp:Label></td>
        <td class="Datos1" colspan="4" style="">
            <asp:Label ID="lblDataRut" runat="server"></asp:Label><asp:TextBox ID="txtRutEmpresa" runat="server" MaxLength="12" Width="70px"></asp:TextBox><asp:CustomValidator
                ID="CustomValidator2" runat="server" ClientValidationFunction="VerificarRut"
                ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un RUT válido"
                ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator>
            <asp:Button ID="btnCargar" runat="server" Text="Cargar" />
            <asp:Button ID="btnPopUpEmpresa" runat="server" Text="..." /></td>
        <td class="titDatos2" style="width: 95px;" id="td1" runat="server">
            <asp:Label ID="lblEjecutivoCuenta" runat="server" Text="Ejecutivo "></asp:Label></td>
        <td class="dosPuntos" style="width: 1px" id="td2" runat="server">
            <asp:Label ID="Label6" runat="server" Text=":"></asp:Label></td>
        <td colspan="4" id="td3" runat="server">
            <asp:Label ID="lblDataNombreEjecutivo" runat="server"></asp:Label></td>
    </tr>
    <tr id="tr1" runat="server">
        <td class="titDatos1" style="width: 60px">
            <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label></td>
        <td class="dosPuntos" style="width: 1px">
            <asp:Label ID="Label2" runat="server" Text=":"></asp:Label></td>
        <td class="Datos1" colspan="4">
            <asp:Label ID="lblDataDireccion" runat="server"></asp:Label></td>
        <td class="titDatos2" style="width: 95px">
            <asp:Label ID="lblFonoEjecutivo" runat="server" Text="Fono"></asp:Label></td>
        <td class="dosPuntos" style="width: 1px">
            <asp:Label ID="Label5" runat="server" Text=":"></asp:Label></td>
        <td class="fono">
            <asp:Label ID="lblDataFonoEjecutivo" runat="server"></asp:Label></td>
        <td class="titFax">
            </td>
        <td class="dosPuntos">
            </td>
        <td class="fax">
            </td>
    </tr>
    <tr id="tr2" runat="server">
        <td class="titDatos1" style="width: 60px">
            <asp:Label ID="lblFono" runat="server" Text="Fono"></asp:Label></td>
        <td class="dosPuntos" style="width: 1px">
            <asp:Label ID="Label3" runat="server" Text=":"></asp:Label></td>
        <td class="fono">
            <asp:Label ID="lblDataFono" runat="server"></asp:Label>
        </td>
        <td class="dosPuntos" style="width: 1px">
            </td>
        <td class="dosPuntos" style="width: 1px">
            </td>
        <td class="fax" style="width: 141px">
            </td>
        <td class="titDatos2" style="width: 95px">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
        <td class="dosPuntos" style="width: 1px">
            &nbsp;<asp:Label ID="Label7" runat="server" Text=":"></asp:Label></td>
        <td colspan="1">
            <asp:HyperLink ID="HplkEmailEjecutivo" runat="server">[HplkEmailEjecutivo]</asp:HyperLink></td>
        <td colspan="4">
            </td>
    </tr>
    <tr>
        <td class="CostoAdministacion" colspan="12">
            <asp:Label ID="lblTitTasaAdmin" runat="server" Text="Tasa de Administración: " Visible="False"></asp:Label>
            <asp:Label ID="lblTasaAdmin" runat="server" Visible="False"></asp:Label><asp:Label
                ID="lblSignoPorcent" runat="server" Text="%" Visible="False"></asp:Label>
<asp:HiddenField ID="hdfMostrarTasa" runat="server" Value="0" />
</td>
    </tr>
</table>

