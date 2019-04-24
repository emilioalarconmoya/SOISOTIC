<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_asistencias.aspx.vb" Inherits="modulo_cursos_mantenedor_asistencias" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mantenedor de asistencias</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <%--<script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" ></script> --%>
      <%--<script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>--%>
      <script language="javascript"  type="text/javascript" >
        function ConfirmDelete()
        {
        var confirmed = window.confirm("ATENCIÓN: El curso será anulado y los gastos de los participantes serán por parte de la empresa, si el porcentaje de asistencia\nde todos los alumnos es inferior a 75%.\n¿Desea continuar?")
        return(confirmed);
        }
        function PromedioAsistencia(gridViewName)
        {
            var tabla = document.getElementById(gridViewName);
            var asistencia = document.getElementById(txtAsistencia);
            alert(asistencia);
            var celdas = tabla.cells;
            var total;
            for(i=0;i<celdas.length-1;i++)
            {
                total= total+asistencia;
            }
            total = total/celdas.length;
            document.getElementById(txtMediaAsistencia)=total ;
            
        }
         function ConfirmarIngreso()
        {
        var confirmed = window.confirm("ATENCIÓN: ¿Está seguro que desea ingresar la asistencia para todos los participantes?")
        return(confirmed);
        }
        
</script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnCargar">
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
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
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
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
     <div id="contenido">
    <div id="Grafico">
     <table id="tablaDatosAlumno">
                        <tr>
                            <th width="980px" valign="top" class="TituloGrupo">
                                <asp:Label ID="Label4" runat="server" Text="Ingreso de la asistencia de alumnos: Listado de alumnos participantes"></asp:Label>  </th>                         
                        </tr>
                     </table>
                    
        <div id="resultados">
            <div class="AlineacionIzquierda">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="correlativo: "></asp:Label>
                <asp:Label ID="lblCorrelativo" runat="server" Font-Bold="True"></asp:Label></div>
            <asp:FileUpload ID="fulAsistencia" runat="server" Visible="False" />
            <asp:Button ID="btnCargar" runat="server" Text="Cargar" Visible="False" />
            <asp:TextBox ID="txtAsistenciaTodos" runat="server" MaxLength="3" Width="25px"></asp:TextBox>
            <asp:Button ID="btnCargarAsistencia" runat="server" Text="Carga Asistencia (todos)" 
            OnClientClick = " return ConfirmarIngreso();" Width="142px" /><br />
            <br />
            <asp:GridView ID="grdAsistencia" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                Width="100%" ShowFooter="True">
                <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td valign="top" class="AlineacionIzquierda">
                                    <asp:Label ID="lblContador" runat="server" Text='<%# bind("nFila") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle Width="10px" />
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rut">
                        <ItemTemplate>
                            <div class="AlineacionIzquierda">
                                <asp:HyperLink ID="hplRutAlumno" runat="server" Text='<%# Bind("rut_alumno") %>'></asp:HyperLink></div>
                        </ItemTemplate>
                        <ItemStyle  Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombres">
                        <ItemTemplate>
                        <div class="AlineacionIzquierda">
                            <asp:Label ID="lblNombres" runat="server" Text='<%# Bind("nombre") %>'></asp:Label><br /></div>
                        </ItemTemplate>
                        <ItemStyle  Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ap. Paterno">
                        <ItemTemplate>
                         <div class="AlineacionIzquierda">
                            <asp:Label ID="lblApPaterno" runat="server" Text='<%# Bind("ap_paterno") %>'></asp:Label><br /></div>
                        </ItemTemplate>
                        <ItemStyle  Width="130px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ap. Materno">
                        <ItemTemplate>
                        <div class="AlineacionIzquierda">
                            <asp:Label ID="lblApMaterno" runat="server" Text='<%# Bind("ap_materno") %>'></asp:Label><br /></div>
                        </ItemTemplate>
                        <ItemStyle  Width="130px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Porcentaje asistencia">
                        <ItemTemplate>
                        <div class="AlineacionCentro">
                            <asp:TextBox ID="txtAsistencia" runat="server" Text='<%# Bind("porc_asistencia") %>' Font-Size="10pt" Width="20px" MaxLength="3" ></asp:TextBox><br /></div>
                        </ItemTemplate>
                        <ItemStyle  Width="60px" />
                        <FooterTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Media de asistencia" Visible="False"></asp:Label>
                            <br />
                            <asp:Button ID="btnCalcularPromedio" runat="server" OnClick="btnCalcularPromedio_Click"
                                Text="Calcular" Visible="False"/>
                            <asp:TextBox ID="txtMediaAsistencia" runat="server" Width="40px" Visible="False"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nota evaluaci&#243;n">
                        <ItemTemplate>
                        <div class="AlineacionCentro">
                            <asp:TextBox ID="txtNotaObtenida" runat="server" Text='<%# bind("nota_obtenida") %>' Width="20px" MaxLength="3"></asp:TextBox></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Franquicia">
                        <ItemTemplate>
                        <div class="AlineacionDerecha">
                            <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label><br />
                            &nbsp;</div>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vi&#225;tico">
                        <ItemTemplate>
                         <div class="AlineacionDerecha">
                           <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label><br /></div>
                        </ItemTemplate>
                        <ItemStyle  Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Traslado">
                        <ItemTemplate>
                         <div class="AlineacionDerecha">
                            <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("traslado") %>'></asp:Label><br /></div>
                        </ItemTemplate>
                        <ItemStyle  Width="70px" />
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <table id="TablaCambioEstado" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="AlineacionDerecha" style="width: 100px">
                        <asp:HiddenField ID="hdfNumParticipantes" runat="server" />
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" />
                    </td>
                </tr>
            </table>
           <br />
        </div>
              </div>
    </div>
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text=""></asp:Label>
        </div>
    </div>
    <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
