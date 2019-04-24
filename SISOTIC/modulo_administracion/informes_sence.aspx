<%@ Page Language="VB" AutoEventWireup="false" CodeFile="informes_sence.aspx.vb" Inherits="modulo_administracion_informes_sence" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Informes SENCE</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
               <%-- <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl=""><b></b></asp:HyperLink>
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
        <br />
        <table cellpadding="0" cellspacing="0" class="TablaInterior" id="tablaInformeAgno">
            <tr>
            <th style="width: 50%" colspan="3">
                <asp:Label ID="Label2" runat="server" Text="1. Seleccione año"></asp:Label></th>
            </tr>
            <tr>
            <tr>
                <td style="width: 50%">
                    <asp:Label ID="Label1" runat="server" Text="Seleccione el Año para el que desea generar la información "></asp:Label></td>
                <td style="width: 1%">
                    :</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlAgnos" runat="server">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <br />
        <table cellpadding="0" cellspacing="0" class="TablaInterior" id="tablaInforme">
            <tr>
            <th style="width: 40%" colspan="2">
                <asp:Label ID="Label3" runat="server" Text="2. Seleccione informe a generar"></asp:Label></th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 40%">
                    <asp:Label ID="lblCapacitacion" runat="server" Text="Cuenta de capacitación"></asp:Label></td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:CheckBox ID="chkCap" runat="server" /></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 40%">
                    <asp:Label ID="lblReparto" runat="server" Text="Cuenta de reparto"></asp:Label></td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:CheckBox ID="chkRep" runat="server" /></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 40%">
                    <asp:Label ID="lblExcCapacitacion" runat="server" Text="Cuenta de excedentes de capacitación"></asp:Label></td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:CheckBox ID="chkExcCap" runat="server" /></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 40%">
                    <asp:Label ID="lblExcReparto" runat="server" Text="Cuenta de excedentes de reparto"></asp:Label></td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:CheckBox ID="chkExcRep" runat="server" /></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 40%">
                    <asp:Label ID="lblBecas" runat="server" Text="Cuenta de becas"></asp:Label></td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:CheckBox ID="chkBec" runat="server" /></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 40%">
                    <asp:Label ID="lblAportes" runat="server" Text="Informe de aportes a terceros"></asp:Label></td>
                <td style="width: 10%" class="AlineacionIzquierda">
                    <asp:CheckBox ID="chkApor" runat="server" /></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 40%; height: 22px">
                    <asp:Label ID="Label4" runat="server" Text="Informe de aportes SENCE"></asp:Label></td>
                <td class="AlineacionIzquierda" style="width: 10%; height: 22px">
                    <asp:CheckBox ID="chkAporteSence" runat="server" /></td>
            </tr>
        </table>
                    <asp:HyperLink ID="hplBajar" runat="server" Visible="False">[hplBajar]</asp:HyperLink><br />
        <asp:Button ID="btnGenerar" runat="server" Text="Generar" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" /><br />
        <br />
        <br />
        <br />
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
