<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_cursos_internos.aspx.vb" Inherits="modulo_cursos_reporte_cursos_internos" EnableEventValidation="false" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte de cursos no Sence</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
    <script  type="text/jscript">
//       function popup_buscar_empresa() 
//        {
//            //Debe ir en campo el nombre del objeto que aparece en HTML como parametro 
//            btn_buscar_empresa = open('buscador_empresas.aspx?campo=txtRutEmpresa','NewWindow','top=100,left=100,width=700,height=380,status=yes,resizable=no,scrollbars=yes,title="Buscador empresas",closable=no');
//        }
      </script>
      <script language="JavaScript" type="text/javascript">
       function VerificarRut(source, arguments)
	{
	    var rut = arguments.Value;
		var DV="";
		var DVaux="";
		var DI;
		var suma=0;
		var largo;
		var mult=2;
		var rut1;
		var texto = rut;
		var tmpstr = "";
		for ( i=0; i < texto.length ; i++ )
			if ( texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-' )
		tmpstr = tmpstr + texto.charAt(i);
		texto = tmpstr;
		rut = texto;
		if (rut.charAt(rut.length-2) == '-')
			largo=rut.length-2;
		else largo = rut.length-1;

		rut1 = texto.substr(0,texto.length-1);
		//if ((rut.length <= 1) || (isNaN(rut1)))
		//{
		//	arguments.IsValid = false;
		//	return false;
		//}
		if ((rut.length < 1) || (isNaN(rut1)))//= 5) || (isNaN(rut1)))
		{
//			alert("Debe completar correctamente el campo Rut.");
//			C_Rut.value = "";
//			C_Rut.select();
//			C_Rut.focus();
			arguments.IsValid = false;
			return true;
		}
		if ( rut.charAt(rut.length-1) !="0" && rut.charAt(rut.length-1) != "1" && rut.charAt(rut.length-1) !="2" && rut.charAt(rut.length-1) != "3" && rut.charAt(rut.length-1) != "4" && rut.charAt(rut.length-1) !="5" && rut.charAt(rut.length-1) != "6" && rut.charAt(rut.length-1) != "7" && rut.charAt(rut.length-1) !="8" && rut.charAt(rut.length-1) != "9" && rut.charAt(rut.length-1) !="k" && rut.charAt(rut.length-1) != "K" )
		{
			arguments.IsValid = false;
			return false;
		}

	   	for(i=0;i<largo;i++)
	   	{
	   		if(mult==8) mult=2;
      		suma = suma + parseInt(rut.substring(largo-i-1,largo-i))*mult;
	      	mult++;
	   	}

  		DI= 11 + 11*(parseInt(suma/11)) - suma;
   		if(DI!=10) DV=DV+DI;
   		if(DI==10)
   		{
			DV="K";
			DVaux="k";
		}
	   	if(DI==11) DV="0";
	   	if( (rut.charAt(rut.length-1) != DV) && (rut.charAt(rut.length-1) != DVaux) )
		{
	        arguments.IsValid = false;
			return false;
		}
		// desde aqui

		var invertido = "";
		for ( i=(largo),j=0; i>=0; i--,j++ )
		    invertido = invertido + texto.charAt(i);

		var dtexto = "";
		dtexto = dtexto + invertido.charAt(0);
		dtexto = dtexto + '-';
		cnt = 0;
		for ( i=1,j=2; i<largo+1; i++,j++ )
		{
			if ( cnt == 3 )
			{
			   dtexto = dtexto + '.';
			   j++;
			   cnt = 1;
			}
		    else cnt++;
		    dtexto = dtexto + invertido.charAt(i);
		}
		invertido = "";
		for ( i=(dtexto.length-1),j=0; i>=0; i--,j++ )
		    invertido = invertido + dtexto.charAt(i);
		    
		arguments.Value = invertido.Value;
		arguments.IsValid = true;
		return true;
	}
</script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnConsultar">
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
                <li class="pestanaconsolaseleccionada">
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
        <table id="tablaFiltros" runat="server" cellpadding="0" cellspacing="0" class="TablaInterior"
            style="width: 980px">
            <tr>
                <th class="Titulo" colspan="10" style="height: 17px" valign="top" width="970">
                    <asp:Label ID="Label19" runat="server" Text="Filtros de búsqueda"></asp:Label>
                </th>
            </tr>
        </table>
            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="980">
                <tr>
                    <td colspan="5" style="height: 22px" align="center">
                        &nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Rut cliente :"></asp:Label>
                        <asp:TextBox ID="txtRutEmpresa" runat="server" MaxLength="12" Width="88px"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                            ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un RUT válido" ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator>
                        <asp:Button ID="btnPopUpEmpresa" runat="server"
                            Text="..." />
                        &nbsp; &nbsp; &nbsp; &nbsp; <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="Año :"></asp:Label>
                        <asp:DropDownList ID="ddlAgnos" runat="server">
                        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnConsultar" runat="server" Font-Bold="False" Text="Consultar" ValidationGroup="ValidaRutAlumno" />
                        &nbsp;
                        &nbsp;&nbsp;&nbsp;<br />
                        <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" />
                        &nbsp;<br />
                        <asp:HyperLink
                ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink>&nbsp;<br />
                        &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaRutAlumno" />
                        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 
                    </td>
                </tr>
            </table>
            <table id="tablaHeader" style="width: 980px">
                <tr>
                    <th class="TituloGrupo" valign="top" width="980" style="height: 17px">
                        <asp:Label ID="Label1" runat="server" Text="Cartola de actividades contratadas" Width="424px"></asp:Label></th>
                </tr>
            </table>
            <asp:GridView ID="GridResultados" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                BorderWidth="0px" CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado"
                Height="1px" OnRowDataBound="GridResultados_RowDataBound" Width="980px">
                <RowStyle Height="0px" />
                <EmptyDataRowStyle Height="0px" />
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
                        <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# bind("Rut") %>' />
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" Width="10px" />
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Correlativo">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td style="width: 50px" class="AlineacionIzquierda">
                                        <asp:HyperLink ID="hplCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink><br />
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("nombre") %>'></asp:Label><br />
                                        <%--<asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />--%>
                                        <asp:HiddenField ID="hdfCodEstadoCurso" runat="server" Value='<%# bind("cod_estado_curso_interno") %>' />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Height="0px" VerticalAlign="Top" Width="50px" />
                        <HeaderStyle Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cursos y Otec">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 60px">
                                        <asp:Label ID="Label5" runat="server" Text="Curso:" Width="16px"></asp:Label></td>
                                    <td class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="lblNombreCurso" runat="server" Text='<%# bind("nombre_curso") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 60px">
                                        <asp:Label ID="Label6" runat="server" Text="Otec:" Width="16px"></asp:Label></td>
                                    <td class="AlineacionIzquierda" style="width: 100px">
                                        <asp:Label ID="lblEjecutor" runat="server" Text='<%# bind("ejecutor") %>'></asp:Label></td>
                                    <td style="width: 94px">
                                    </td>
                                    <td class="AlineacionIzquierda" style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 60px">
                                        <asp:Label ID="Label7" runat="server" Text="Alumnos:" Width="16px"></asp:Label></td>
                                    <td class="AlineacionIzquierda" style="width: 100px">
                                        <asp:Label ID="lblNumAlumnos" runat="server" Text='<%# bind("num_participantes") %>' Width="96px"></asp:Label></td>
                                    <td style="width: 94px">
                                        <asp:Label ID="Label2" runat="server" Text="Numero interno: " Width="96px"></asp:Label></td>
                                    <td class="AlineacionIzquierda" style="width: 100px">
                                        <asp:Label ID="lblCorrelativoEmp" runat="server" Text='<%# bind("correlativo_empresa") %>'></asp:Label></td>
                                </tr>
                            </table>
                            &nbsp;
                            &nbsp; &nbsp;&nbsp;
                        </ItemTemplate>
                        <ItemStyle Height="0px" VerticalAlign="Top" Width="380px" />
                        <HeaderStyle Width="640px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Costo">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 80px; height: 16px;">
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 38px">
                                        <asp:Label ID="Label8" runat="server" Text="Valor"></asp:Label></td>
                                    <td style="width: 5px">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 70px">
                                        <asp:Label ID="lblValorCurso" runat="server" Text='<%# Bind("valor_curso") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Height="0px" VerticalAlign="Top" Width="110px" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td colspan="3" rowspan="3" style="width: 7px; height: 18px;">
                                        <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar"
                                            Visible="False" Width="112px" Font-Size="X-Small" /></td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="1" style="width: 7px; height: 18px;">
                                        <asp:Button ID="btnAnular" runat="server" OnClick="btnAnular_Click" Text="Anular"
                                            Visible="False" Width="112px" Font-Size="X-Small" />
                                        <asp:Button ID="btncambiarAIngresado" runat="server" OnClick="btncambiarAIngresado_Click"
                                            Text="Cambiar a ingresado" Visible="False" Width="112px" Font-Size="X-Small" /><%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="">LinkButton</asp:LinkButton>--%></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Height="0px" VerticalAlign="Top" Width="120px" />
                        <HeaderStyle Width="100px" />
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
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </div>    
        <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
