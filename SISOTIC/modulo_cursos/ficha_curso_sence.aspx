<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_curso_sence.aspx.vb" Inherits="Reportes_ficha_curso_sence" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ficha Curso Sence</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor"> 
    <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
        <div id="menu">
                    <div id="header">
                        <ul>
                            <li>
                                <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Resumen</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl="mantenedor_cursos_internos.aspx"><b>Curso no Sence</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="buscador_cursos.aspx"><b>Buscar curso</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                            </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                            <li>
                                <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                            </li>
                <li visible="False">
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Mantenedor Sence</b></asp:HyperLink>
                </li>
                            <li>
                                <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                            </li>
                            <li>
                                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                            </li>
                        </ul>
                    </div>   
                </div>
    <div id="contenido"> 
    <div id="resultados">

        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Ficha de Curso Sence"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0" class="TablaInterior">
            <tr>
                <td class="AlineacionIzquierda" colspan="3">
                    <asp:Label ID="lblNombreCurso" runat="server" Width="216px" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3" class="AlineacionIzquierda">
                    &nbsp;<asp:Label ID="Label6" runat="server" Text="Código Sence: " Width="88px" Font-Bold="False"></asp:Label><asp:Label ID="lblCodigoSence" runat="server" Font-Bold="False"></asp:Label></td>
            </tr>
            
        </table>
        
        <table style="width: 980px;">
           <%-- <tr>
                <th colspan="3" class="AlineacionIzquierda">
                    &nbsp;<asp:Label ID="Label12" runat="server" Text="DATOS CURSO INTERNO"></asp:Label></th>
            </tr>--%>
            <tr>
                <th class="AlineacionIzquierda" valign="top" colspan="2" style="width: 490px">
                    <asp:Label ID="Label17" runat="server" Text="Datos Curso"></asp:Label>
                    &nbsp;
                </th>
                <th class="AlineacionIzquierda" colspan="3" valign="top" style="width: 489px">
                    <asp:Label ID="Label18" runat="server" Text="Datos Otec"></asp:Label></th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="2" valign="top" style="width: 490px">
                    <asp:Label ID="Label2" runat="server" Text="Horas: "></asp:Label>
                    <asp:Label ID="lblDChoras" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label4" runat="server" Text="Área: "></asp:Label>
                    <asp:Label ID="lblDCarea" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label7" runat="server" Text="Especialidad: "></asp:Label>
                    <asp:Label ID="lblDCespecialidad" runat="server" Text="Label"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="3" valign="top" style="width: 490px">
                    <asp:HyperLink ID="hplDOnombreOtec" runat="server">HyperLink</asp:HyperLink><br />
                    <asp:Label ID="Label11" runat="server" Text="Rut: "></asp:Label>
                    <asp:Label ID="lblDOrut" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label13" runat="server" Text="Fono: "></asp:Label>
                    <asp:Label ID="lblDOfono" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="Label15" runat="server" Text="Email: "></asp:Label>
                    <asp:Label ID="lblDOemail" runat="server" Text="Label"></asp:Label><br />
                </td>
            </tr>
        </table>
         <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
             <asp:Button ID="btnGeneraPDF" runat="server" Text="Generar PDF" /></div>
        </div>
        </div>
        </div> 
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
