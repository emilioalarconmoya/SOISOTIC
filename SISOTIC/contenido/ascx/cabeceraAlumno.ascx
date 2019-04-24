<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cabeceraAlumno.ascx.vb" Inherits="contenido_ascx_cabeceraAlumno" %>
<link href="../../estilo.css" rel="Stylesheet" type="text/css" />
<table id="cabeceraUsuario" cellpadding="0" cellspacing="0" width="980">
    <tr>
        <td colspan="12">
            <asp:HyperLink ID="hplNombreAlumno" runat="server">[hplNombreAlumno]</asp:HyperLink>&nbsp;
        </td>
    </tr>
    <tr>
        <td class="titDatos1">
            <asp:Label ID="lblRut" runat="server" Text="RUT"></asp:Label></td>
        <td class="dosPuntos">
            <asp:Label ID="Label1" runat="server" Text=":"></asp:Label></td>
        <td class="Datos1" colspan="4">
            <asp:Label ID="lblDataRut" runat="server"></asp:Label></td>
        <td class="titDatos2">
            <asp:Label ID="lblEmpleador" runat="server" Text="Empleador"></asp:Label></td>
        <td class="dosPuntos">
            <asp:Label ID="Label6" runat="server" Text=":"></asp:Label></td>
        <td colspan="4">
            <asp:HyperLink ID="hplNombreEmpleador" runat="server">[hplNombreEmpleador]</asp:HyperLink></td>
    </tr>
    <tr>
        <td class="titDatos1">
            <asp:Label ID="lblFechNac" runat="server" Text="Fecha de nacimiento"></asp:Label></td>
        <td class="dosPuntos">
            <asp:Label ID="Label2" runat="server" Text=":"></asp:Label></td>
        <td class="Datos1" colspan="4">
            <asp:Label ID="lblDataFechaNac" runat="server"></asp:Label></td>
        <td class="titDatos2">
            <asp:Label ID="lblRutEmpleador" runat="server" Text="Rut"></asp:Label></td>
        <td class="dosPuntos">
            <asp:Label ID="Label5" runat="server" Text=":"></asp:Label></td>
        <td class="fono" colspan="4">
            <asp:Label ID="lblDataRutEmpleador" runat="server"></asp:Label></td>
    </tr>
</table>
