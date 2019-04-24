<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cabeceraCurso.ascx.vb" Inherits="contenido_ascx_cabeceraCurso" %>
<link href="../../estilo.css" rel="Stylesheet" type="text/css" />
<table id="cabeceraUsuario" cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
    <tr>
                    <td class="AlineacionDerecha">
                        <asp:Label ID="Label38" runat="server" Font-Bold="False" Text="Correlativo"></asp:Label></td>
                    <td>
                        :</td>
                    <td class="AlineacionIzquierda">
                        <asp:Label ID="lblCorrelativo" runat="server" Font-Bold="True"></asp:Label></td>
                    <td class="AlineacionDerecha">
                        <asp:Label ID="Label44" runat="server" Text="Estado actual"></asp:Label></td>
                    <td>
                        :</td>
                    <td class="AlineacionIzquierda">
                        <asp:HyperLink ID="hplEstado" runat="server">[hplEstado]</asp:HyperLink></td>
                    <td class="AlineacionDerecha">
                        </td>
                    <td>
                        </td>
                    <td class="AlineacionIzquierda">
                        </td>
                    <td class="AlineacionDerecha">
                        <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="NºReg. SENCE"></asp:Label></td>
                    <td style="width: 2%">
                        :</td>
                    <td class="AlineacionIzquierda">
                        <asp:Label ID="lblRegSence" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
                <tr>
                    <td class="AlineacionDerecha">
                        <asp:Label ID="Label57" runat="server" Text="Fecha"></asp:Label></td>
                    <td>
                        :</td>
                    <td class="AlineacionIzquierda" >
                        <asp:Label ID="lblFecha" runat="server"></asp:Label></td>
                    <td class="AlineacionDerecha">
                        <asp:Label ID="Label59" runat="server" Text="Fecha ingreso"></asp:Label></td>
                    <td>
                        :</td>
                    <td class="AlineacionIzquierda" style="width: 10%">
                        <asp:Label ID="lblFechIngreso" runat="server"></asp:Label></td>
                    <td class="AlineacionDerecha">
                        </td>
                    <td>
                        </td>
                    <td class="AlineacionIzquierda">
                        </td>
                    <td class="AlineacionDerecha">
                        <asp:Label ID="Label62" runat="server" Text="NºReg. SENCE compl"></asp:Label></td>
                    <td>
                        :</td>
                    <td class="AlineacionIzquierda">
                        <asp:Label ID="lblRegSenCompl" runat="server" Text="-"></asp:Label></td>
                </tr>
</table>
