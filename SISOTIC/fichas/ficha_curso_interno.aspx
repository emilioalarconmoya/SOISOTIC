<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_curso_interno.aspx.vb" Inherits="Reportes_ficha_curso_interno" %>

<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ficha de Curso Interno</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
    <div id="contenido"> 
    <div id="botones">
    
        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Ficha de Curso no sence"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0">
            <tr>
                <td class="titDatos1">
                    <asp:Label ID="Label2" runat="server" Text="Rut" Font-Bold="True"></asp:Label>&nbsp;<br />
                    </td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblDCrut" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="titDatos1">
                    <asp:Label ID="Label27" runat="server" Text="Dirección" Font-Bold="True"></asp:Label>
                    &nbsp; &nbsp;
                </td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblDCdireccion" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="titDatos1">
                    <asp:Label ID="Label6" runat="server" Text="Razón Social" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblDCrazonSocial" runat="server" Font-Bold="True"></asp:Label></td>
                <td class="titDatos1">
                    <asp:Label ID="Label29" runat="server" Text="Comuna" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblDCcomuna" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="titDatos1" colspan="3">
                </td>
                <td class="titDatos1">
                    <asp:Label ID="Label31" runat="server" Text="Ciudad" Font-Bold="True"></asp:Label></td>
                <td class="dosPuntos">
                    :</td>
                <td class="Datos1">
                    <asp:Label ID="lblDCciudad" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            
        </table>
        
        <table style="width: 980px;">
           <%-- <tr>
                <th colspan="3" class="AlineacionIzquierda">
                    &nbsp;<asp:Label ID="Label12" runat="server" Text="DATOS CURSO INTERNO"></asp:Label></th>
            </tr>--%>
            <tr>
                <th class="AlineacionIzquierda" valign="top" colspan="3">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label17" runat="server" Text="Correlativo"></asp:Label>
                    &nbsp;
                </th>
                <th class="AlineacionIzquierda" colspan="2" valign="top">
                    <asp:Label ID="Label18" runat="server" Text="Curso y OTEC"></asp:Label></th>
                <th valign="top">
                    <asp:Label ID="Label16" runat="server" Text="Costos"></asp:Label></th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="3" valign="top">
                    <asp:Label ID="lblDCIcorrelativo" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Estado :"></asp:Label>
                    <asp:Label ID="lblDCIestado" runat="server"></asp:Label></td>
                <td class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="Label9" runat="server" Text="Curso : "></asp:Label>
                    <asp:Label ID="lblDCIcurso" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="OTEC : "></asp:Label>
                    <asp:Label ID="lblDCIotec" runat="server"></asp:Label><br />
                    <asp:Label ID="Label14" runat="server" Text="Alumnos : "></asp:Label>
                    <asp:Label ID="lblDCIalumnos" runat="server"></asp:Label></td>
                <td class="AlineacionIzquierda" valign="top">
                    <asp:Label ID="Label5" runat="server" Text="Número Interno :"></asp:Label>
                    <asp:Label ID="lblDCInumeroInterno" runat="server"></asp:Label><br />
                    <asp:Label ID="Label19" runat="server" Text="Horario :"></asp:Label>
                    <asp:Label ID="lblDCIhorario" runat="server"></asp:Label><br />
                    <asp:Label ID="Label7" runat="server" Text="Horas: "></asp:Label>
                    <asp:Label ID="lblDCIhoras" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label21" runat="server" Text="Observaciones :"></asp:Label><asp:Label
                        ID="lblDCIobservaciones" runat="server"></asp:Label></td>
                <td valign="top">
                    <asp:Label ID="Label25" runat="server" Text="$"></asp:Label>
                    <asp:Label ID="lblDCIcosto" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="btnVerlistadoCurso" runat="server" Text="Ver Listado de Cursos" />
        &nbsp;&nbsp;<asp:Button ID="btnModificarCurso" runat="server" Text="Modificar Curso" />
        <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" /></div>   
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
