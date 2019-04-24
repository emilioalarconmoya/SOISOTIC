<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_cursos.aspx.vb" Inherits="modulo_cursos_reporte_cursos" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Src="../contenido/ascx/Cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte de cursos</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
     <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
      <script language="javascript"  type="text/javascript" >
        function ConfirmDelete()
        {
        var confirmed = window.confirm("ATENCIÓN: El curso será anulado si el porcentaje de asistencia\nde todos los alumnos es inferior a 75%.\n¿Desea continuar?")
        return(confirmed);
        }
</script>



    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />


</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
          <uc3:cabeceraUsuario ID="CabeceraUsuario1" runat="server" />  
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
            <div id="resultados"> 
                <table cellpadding="0" cellspacing="0" class="TablaInterior" id="tablaFiltros" runat="server">
                    <tr>
                        <th width="970px" valign="top" class="Titulo" colspan="8" >
                            <asp:Label ID="Label19" runat="server" Text="Filtros de búsqueda"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td style="text-align: center;">
                        <asp:Label ID="Label1" runat="server" Text="Ejecutivo:" Font-Bold="False"></asp:Label><%--&nbsp;</td>
                        <td style="width: 100px">--%>
                        <asp:DropDownList ID="ddlEjecutivo" runat="server" CssClass="MaxWidth100">
                        </asp:DropDownList><%--</td>
                        <td style="width: 100px" class="AlineacionDerecha">--%>
                        <asp:CheckBox ID="chkCursosPropios" runat="server" Visible="False" />
                        <asp:Label ID="Label2" runat="server" Text="Rut cliente:" Font-Bold="False"></asp:Label><%--</td>
                        <td style="width: 120px" class="AlineacionIzquierda">--%>
                        <asp:TextBox ID="txtRutEmpresa" runat="server" Width="80px"></asp:TextBox><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un RUT válido"
                                ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator>
                        <asp:Button ID="btn_buscar_empresa" runat="server" Text="..."/><%--</td>
                        <td style="width: 120px">--%>
                            <asp:Label ID="Label23" runat="server" Text="Correlativo: " Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="txtCorrelativo" runat="server" Width="30px"></asp:TextBox>
                            <asp:Label ID="Label24" runat="server" Text="Registro: " Font-Bold="False"></asp:Label>
                            <asp:TextBox ID="txtRegistro" runat="server" Width="50px"></asp:TextBox>
                        <%--</td>
                        <td class="AlineacionDerecha" style="width: 100px">--%>
                            <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Código: "></asp:Label><asp:TextBox
                                ID="txtCodigo" runat="server" MaxLength="10" Width="30px"></asp:TextBox><%--</td>
                        <td style="width: 120px" class="AlineacionDerecha">--%>
                            Desde
                        <asp:Label ID="Label4" runat="server" Text="Año:" Font-Bold="False" Visible="False"></asp:Label>
                        <ew:calendarpopup
                            id="calFechaInicio" runat="server" cleardatetext="Limpiar fecha" controldisplay="TextBoxImage"
                            cssclass="Calendar" culture="Spanish (Argentina)" disabletextboxentry="False"
                            displayprevnextyearselection="True" gototodaytext="Ir al día de hoy" imageurl="~/Contenido/Imagenes/calendario.jpg"
                            nullable="True" padsingledigits="True" popuplocation="Left" posteddate="" selecteddate=""
                            showcleardate="True" showgototoday="True" upperbounddate="12/31/9999 23:59:59"
                            visibledate="" Text=""> <TEXTBOXLABELSTYLE Width="60px" /></ew:calendarpopup><%--</td>
                        <td style="width: 120px" class="AlineacionIzquierda">--%>
                            Hasta<asp:DropDownList ID="ddlAgnos" runat="server" Visible="False">
                        </asp:DropDownList>
                            <ew:calendarpopup
                            id="calFechaFin" runat="server" cleardatetext="Limpiar fecha" controldisplay="TextBoxImage"
                            cssclass="Calendar" culture="Spanish (Argentina)" disabletextboxentry="False"
                            displayprevnextyearselection="True" gototodaytext="Ir al día de hoy" imageurl="~/Contenido/Imagenes/calendario.jpg"
                            nullable="True" padsingledigits="True" popuplocation="Left" posteddate="" selecteddate=""
                            showcleardate="True" showgototoday="True" upperbounddate="12/31/9999 23:59:59"
                            visibledate="" Text=""><TEXTBOXLABELSTYLE Width="60px" /></ew:calendarpopup>
                        </td>
                    </tr>
                     <tr>
                        <td width="970px" valign="top" colspan="8" style="text-align: center;">
                            <asp:Label ID="Label16" runat="server" Text="Estados: "></asp:Label>
                            <asp:DropDownList ID="ddlSeleccion" runat="server" AutoPostBack="true" >
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkIngresados" runat="server" Text="Ingresados" Checked="True" />&nbsp;
                            <asp:CheckBox ID="chkAutorizados" runat="server" Text="Autorizados" Checked="True" />
                            <asp:CheckBox ID="chkEnComunicacion" runat="server" Text="En comunicación" Checked="True" />&nbsp;
                            <asp:CheckBox ID="chkComunicados" runat="server" Text="Comunicados" Checked="True" />
                            <asp:CheckBox ID="chkConAsistencia" runat="server" Text="Con asistencia" Checked="True" />
                            <asp:CheckBox ID="chkPagoPorAutorizar" runat="server" Text="Pago por autorizar" Checked="True" />
                            <asp:CheckBox ID="chkEnLiquidacion" runat="server" Text="En liquidación" Checked="True" />&nbsp;
                            <asp:CheckBox ID="chkLiquidados" runat="server" Text="Liquidados" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <asp:CheckBox ID="chkAnulados" runat="server" Text="Anulados" />
                            <asp:CheckBox ID="chkEliminados" runat="server" Text="Eliminados" />
                            <asp:CheckBox ID="chkIncompletos" runat="server" Text="Incompletos" />
                            &nbsp;
                            <asp:CheckBox ID="chkRechazados" runat="server" Text="Rechazados" />&nbsp;
                            <asp:CheckBox ID="chkTerceros" runat="server" Text="Terceros" AutoPostBack="True" />&nbsp;<asp:DropDownList
                                ID="ddlTerceros" runat="server" Visible="False">
                            </asp:DropDownList>
                            &nbsp; &nbsp; &nbsp;
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="deseleccionar  todos" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <asp:CheckBox ID="chkProximoDiaHabil" runat="server" Text="Mostrar solo los cursos que comiencen el próximo día hábil" Visible="False" /></td>
                    </tr>
                </table><table cellpadding="0" cellspacing="0" class="TablaInterior" id="tablaFiltros2" runat="server" visible="false">
                    <tr>
                        <th width="970px" valign="top" class="Titulo" colspan="1">
                            <asp:Label ID="Label17" runat="server" Text="Filtros de búsqueda"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:Label ID="Label21" runat="server" Font-Bold="False" Text="Rut cliente :"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtRutEmpresa2" runat="server"></asp:TextBox><asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRutEmpresa2" ErrorMessage="Debe ingresar un RUT válido"
                                ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator><asp:Button ID="btn_buscar_empresa2" runat="server" Text="..."/>
                            <asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Año :"></asp:Label>
                            <asp:DropDownList ID="ddlAgnos2" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaRutAlumno" />
                <br />
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" Font-Bold="False" ValidationGroup="ValidaRutAlumno" />
                <br />
                <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink><br />
                <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" /></div> 
            <table id="tablaDatosAlumno">
                        <tr>
                            <th width="980px" class="Titulo" valign="top">
                                <asp:Label ID="Label15" runat="server" Text="Reporte de cursos"></asp:Label>
                                <asp:Label ID="lblTipo" runat="server"></asp:Label></th>                            
                        </tr>
                     </table>
                <asp:GridView ID="grdResultados" runat="server" width="975px" AutoGenerateColumns="False" CssClass="Grid" OnRowDataBound="grdResultados_RowDataBound" BorderWidth="0px" PageSize="10" AllowPaging="true">
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
                    <ItemStyle VerticalAlign="Top" Width="10px" />
                   </asp:TemplateField>
                        <asp:TemplateField HeaderText="Folio">
                            <ItemStyle Width="90px" VerticalAlign="Top" Height="0px" CssClass="AlineacionIzquierda" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td style="width: 90px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label25" runat="server" Text="Correl.:"></asp:Label>
                                            <asp:HyperLink ID="hplCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink>
                                            <asp:HyperLink ID="D" runat="server" Text='<%# Bind("diferenciacionCurso") %>'></asp:HyperLink>
                                            <br />
                                            <asp:Label ID="Label26" runat="server" Text="Código:"></asp:Label>
                                            <asp:HyperLink ID="hplCodCurso" runat="server" Text='<%# Bind("cod_curso") %>'></asp:HyperLink>
                                            <br />
                                            <asp:HyperLink ID="hplEstado" runat="server" Text='<%# Bind("estado_curso") %>'></asp:HyperLink><br />
                                            <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                                            <asp:HiddenField ID="hdfCodEstadoCurso" runat="server" Value='<%# Bind("cod_estado_curso") %>' />
                                            <asp:HiddenField ID="hdfNumPerfil" runat="server" Value='<%# Bind("nro_perfil") %>' />
                                            <asp:HiddenField ID="hdfCodSence" runat="server" Value='<%# Bind("codigo_sence") %>' />
                                            <asp:HiddenField ID="hdfRutOtec" runat="server" Value='<%# Bind("rut_otec")%>' />
                                            <asp:HiddenField ID="hdfEstadoCurso" runat="server" Value='<%# Bind("estado_curso") %>' />
                                            <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# Bind("rut_cliente") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Empresa, curso y OTEC">
                            <ItemStyle Width="350px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px">
                                            <asp:Label ID="Label5" runat="server" Text="Emp"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 330px">
                                            <asp:HyperLink ID="hplEmpresa" runat="server" Text='<%# Bind("nombre_empresa") %>'></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px;">
                                            <asp:Label ID="Label6" runat="server" Text="Curso"></asp:Label></td>
                                        <td class="DosPuntos" style="height: 18px">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 330px;">
                                            <asp:HyperLink ID="hplCurso" runat="server" Text='<%# Bind("nombre_curso") %>'></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px">
                                            <asp:Label ID="Label7" runat="server" Text="OTEC"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 330px">
                                            <asp:HyperLink ID="hplOtec" runat="server" Text='<%# Bind("nombre_otec") %>'></asp:HyperLink></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Datos curso">
                            <ItemStyle Width="110px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td style="width: 38px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label8" runat="server" Text="Alumnos"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblAlunmos" runat="server" Text='<%# Bind("numero_alumnos")%>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 38px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label9" runat="server" Text="Inicio"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblFechIni" runat="server" Text='<%# Bind("fecha_inicio") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 38px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label10" runat="server" Text="Fin"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblFechFin" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Datos SENCE">
                            <ItemStyle Width="120px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td style="width: 48px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label11" runat="server" Text="Comun"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionDerecha">
                                            <asp:Label ID="lblComun" runat="server" Text='<%# Bind("fecha_comunicacion") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 48px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label12" runat="server" Text="Liquida"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionDerecha">
                                            <asp:Label ID="lblLiquida" runat="server" Text='<%# Bind("fecha_liquidacion") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 48px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label13" runat="server" Text="Nº Reg"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionDerecha">
                                            <asp:Label ID="lblReg" runat="server" Text='<%# Bind("nro_registro") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 48px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label14" runat="server" Text="Compl"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionDerecha">
                                            <asp:Label ID="lblCompl" runat="server" Text='<%# Bind("cod_curso_compl") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Control">
                            <ItemStyle Width="150px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td style="width: 68px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label18" runat="server" Text="Origen"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblOrigen" runat="server" Text='<%# Bind("origen") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 68px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label19" runat="server" Text="Ingreso"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblIngreso" runat="server" Text='<%# Bind("fecha_ingreso") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 68px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label20" runat="server" Text="Nº Interno"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblCorrEmp" runat="server" Text='<%# Bind("correlativo_empresa") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acci&#243;n">
                            <ItemStyle Width="80px" VerticalAlign="Top" Height="0px" HorizontalAlign="Left" CssClass="AlineacionIzquierda" />
                            <ItemTemplate>
                                            <asp:Button ID="btnModificarGrid" runat="server" Font-Size="X-Small" OnClick="btnModificarGrid_Click"
                                                Text="Modificar" Visible="False" Width="95px" Height="19px" /><br />
                                            <asp:Button ID="btnEliminarGrid" runat="server" Font-Size="X-Small" OnClick="btnEliminarGrid_Click"
                                                Text="Eliminar" Visible="False" Width="95px" Height="19px" /><asp:Button ID="btnAnularGrid" runat="server" Font-Size="X-Small" OnClick="btnAnularGrid_Click"
                                                Text="Anular" Visible="False" Width="95px" Height="19px" /><br />
                                            <asp:Button ID="btnAutRechGrid" runat="server" Font-Size="X-Small" OnClick="btnAutRechGrid_Click"
                                                Text="Autorizar/Rechazar" Visible="False" Width="95px" Height="19px" /><asp:Button ID="btnComunicarGrid" runat="server" Font-Size="X-Small" OnClick="btnComunicarGrid_Click"
                                                Text="Comunicar" Visible="False" Width="95px" Height="19px" /><asp:Button ID="btnLiquidarGrid" runat="server" Font-Size="X-Small" OnClick="btnLiquidarGrid_Click"
                                                Text="Liquidar" Visible="False" Width="95px" Height="19px" /><br />
                                            <asp:Button ID="btnAsistenciaGrid" runat="server" Font-Size="X-Small" OnClick="btnAsistenciaGrid_Click"
                                                Text="Asistencia" Visible="False" Width="95px" Height="19px" /><asp:Button ID="btnLiqManualGrid" runat="server" Font-Size="X-Small" OnClick="btnLiqManualGrid_Click"
                                                Text="Liq.Manual" Visible="False" Width="95px" Height="19px" /><asp:Button ID="btnComunManualGrid" runat="server" Font-Size="X-Small" OnClick="btnComunManualGrid_Click"
                                                Text="Com.Manual" Visible="False" Width="95px" Height="19px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                            <asp:CheckBox ID="chkComunicar" runat="server" Visible="False" /><asp:CheckBox ID="chkAutorizar" runat="server" Visible="False" /><asp:CheckBox ID="chkLiquidar" runat="server" Visible="False" />
                                <asp:CheckBox ID="chkGenerar" runat="server" Visible="False" />
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
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
                            <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="Últ. Pag"  CommandArgument="Last" CssClass="paglast" />
                        </div>
                   </PagerTemplate>
                   <PagerStyle CssClass="pagerstyle" />
                </asp:GridView>
                <div id = "botones">
                <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" Visible="False" Font-Bold="False" />
                <asp:Button ID="btnComunicar" runat="server" Text="Comunicar" Visible="False" Font-Bold="False" />
                <asp:Button ID="btnLiquidar" runat="server" Text="En liquidación" Visible="False" Font-Bold="False" />
                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" Visible="False" Font-Bold="False" />
                <asp:Button ID="btnGenerar" runat="server" Text="Generar base de datos" Visible="False" Font-Bold="False" />
                    <asp:Button ID="btnGenerarTodos" runat="server" Text="Generar base de datos (todos)" Visible="False" Font-Bold="False" />&nbsp;
                    <asp:Button ID="btnGenerarZip" runat="server" Font-Bold="False" Text="Generar archivos csv"
                        Visible="False" />
                </div>
            </div>
        </div>
        <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>    
    </form>
</body>
</html>
