<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_factura.aspx.vb" Inherits="modulo_cursos_reporte_factura" EnableEventValidation="false" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Reporte de facturas</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
      <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
      <script  type="text/jscript">
      //esta funcion solo deja ingresar numeros enteros
      function entero(e)
	{
		var caracter 
            	caracter = e.keyCode 
            	status = caracter 
        
        	if (caracter>47 && caracter <58)
            	{
                	return true
            	}
            	return false
   
        }

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
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
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
                <table cellpadding="0" cellspacing="0" class="TablaInterior" id="tablaFiltros" runat="server" style="width: 980px">
                    <tr>
                        <th width="970px" valign="top" class="Titulo" colspan="10" style="height: 17px">
                        <asp:Label ID="Label19" runat="server" Text="Filtros de búsqueda"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 80px; height: 26px;" class="AlineacionIzquierda">
                        <asp:Label ID="Label1" runat="server" Text="Estado Factura: " Font-Bold="True"></asp:Label></td>
                        <td style="width: 62px; height: 26px;">
                        <asp:DropDownList ID="ddlEstadofactura" runat="server" Width="88px">
                        </asp:DropDownList></td>
                        <td style="width: 57px; height: 26px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label2" runat="server" Text="Nº Factura: " Font-Bold="True"></asp:Label></td>
                        <td style="width: 102px; height: 26px;" class="AlineacionIzquierda">
                        <asp:TextBox ID="txtNumFactura" runat="server" Width="88px" MaxLength="18"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNumFactura"
                                ErrorMessage="Debe ingresar sólo números" ValidationExpression="\d+" ValidationGroup="xx">*</asp:RegularExpressionValidator></td>
                        <td class="AlineacionIzquierda" style="width: 78px; height: 26px">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Rut Empresa: "></asp:Label></td>
                        <td class="AlineacionIzquierda" style="width: 120px; height: 26px">
                            <asp:TextBox ID="txtRutEmpresa" runat="server" Width="88px" MaxLength="12"></asp:TextBox><asp:CustomValidator
                                ID="CustomValidator1" runat="server" ErrorMessage="Debe ingresar un rut válido"
                                ValidationGroup="xx" ClientValidationFunction="VerificarRut" ControlToValidate="txtRutEmpresa">*</asp:CustomValidator><asp:Button ID="btnPopUpEmpresa" runat="server" Text="..." /></td>
                        <td style="width: 51px; height: 26px;">
                            &nbsp;<asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Rut Otec: "></asp:Label>
                        </td>
                        <td style="width: 18px; height: 26px">
                            <asp:TextBox ID="txtRutOtec" runat="server" Width="88px" MaxLength="12"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Debe ingresar un rut válido" ClientValidationFunction="VerificarRut" ControlToValidate="txtRutOtec" ValidationGroup="xx">*</asp:CustomValidator></td>
                        <td style="width: 23px; height: 26px;" class="AlineacionDerecha">
                        <asp:Label ID="Label4" runat="server" Text="Año :" Font-Bold="True" Width="40px"></asp:Label></td>
                        <td style="width: 65px; height: 26px;" class="AlineacionIzquierda">
                        <asp:DropDownList ID="ddlAgnos" runat="server" Width="64px">
                        </asp:DropDownList></td>
                    </tr>
                </table>
                &nbsp; &nbsp; <asp:CheckBox ID="chkBajarReporte"
                    runat="server" Text="Bajar reporte" />
                &nbsp;
                <br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
                <br />
                <asp:HyperLink ID="hplBajarReporte" runat="server"
                        Visible="False">[hplBajarReporte]</asp:HyperLink><br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
        <table id="tablaDatosAlumno" style="width: 980px">
            <tr>
                <th class="TituloGrupo" valign="top" width="980" style="height: 17px">
                    <asp:Label ID="Label15" runat="server" Text="Listado de facturas"></asp:Label>
                </th>
            </tr>
        </table>
                <asp:GridView ID="grdResultados" runat="server" width="980px" AutoGenerateColumns="False" CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado" OnRowDataBound="grdResultados_RowDataBound" BorderWidth="0px" Height="0px">
                    <Columns>
                        <asp:TemplateField HeaderText="Folio">
                            <ItemStyle Width="50px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td style="width: 50px" class="AlineacionIzquierda">
                                            <asp:HyperLink ID="hplCorrelativo" runat="server" Text='<%# Bind("correlativo") %>'></asp:HyperLink><br />
                                            <asp:HyperLink ID="hplEstado" runat="server" Text='<%# Bind("nombre_factura") %>'></asp:HyperLink>
                                            <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Empresa, curso y OTEC">
                            <ItemStyle Width="380px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px; height: 18px;">
                                            <asp:Label ID="Label5" runat="server" Text="Emp"></asp:Label></td>
                                        <td class="DosPuntos" style="height: 18px">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 300px; height: 18px;">
                                            <asp:HyperLink ID="hplEmpresa" runat="server" Text='<%# Bind("nombre_persona_juridica") %>'></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px;">
                                            <asp:Label ID="Label6" runat="server" Text="Curso"></asp:Label></td>
                                        <td class="DosPuntos" style="height: 18px">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 300px;">
                                            <asp:HyperLink ID="hplCurso" runat="server" Text='<%# Bind("nombre_curso") %>'></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px">
                                            <asp:Label ID="Label7" runat="server" Text="OTEC"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td class="AlineacionIzquierda" style="width: 300px">
                                            <asp:HyperLink ID="hplOtec" runat="server" Text='<%# Bind("nombre_otec") %>'></asp:HyperLink></td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfNumPerfil" runat="server" Value='<%# bind("num_perfil") %>' />
                                <asp:HiddenField ID="hdfRutOtec" runat="server" Value='<%# bind("rut_otec") %>' />
                                <asp:HiddenField ID="hdfCodSence" runat="server" Value='<%# bind("codigo_sence") %>' />
                                <asp:HiddenField ID="hdfCodEstadoFactura" runat="server" Value='<%# bind("cod_estado_fact") %>' />
                                <asp:HiddenField ID="hdfRutCliente" runat="server" Value='<%# bind("rut_cliente") %>' />
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
                                            <asp:Label ID="lblAlunmos" runat="server" Text='<%# Bind("num_alumnos") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 38px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label9" runat="server" Text="Inicio"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblFechInicio" runat="server" Text='<%# Bind("fecha_inicio") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 38px; height: 18px;" class="AlineacionIzquierda">
                                            <asp:Label ID="Label10" runat="server" Text="Fin"></asp:Label></td>
                                        <td class="DosPuntos" style="height: 18px">
                                            :</td>
                                        <td style="width: 70px; height: 18px;" class="AlineacionIzquierda">
                                            <asp:Label ID="lblFechFin" runat="server" Text='<%# Bind("fecha_termino") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Datos factura">
                            <ItemStyle Width="120px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 96px; height: 56px;">
                                    <tr>
                                        <td style="width: 48px; height: 18px;" class="AlineacionIzquierda">
                                            <asp:Label ID="Label11" runat="server" Text="Nro."></asp:Label></td>
                                        <td style="height: 18px; width: 5px;">
                                            :</td>
                                        <td style="width: 131px; height: 18px;" class="AlineacionIzquierda">
                                            <asp:HyperLink ID="hplNumFactura" runat="server" Text='<%# bind("num_factura") %>'></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 48px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label12" runat="server" Text="Estado"></asp:Label></td>
                                        <td style="width: 5px">
                                            :</td>
                                        <td style="width: 131px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblEstadoFactura" runat="server" Text='<%# Bind("nombre_factura") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 48px; height: 18px;" class="AlineacionIzquierda">
                                            <asp:Label ID="Label13" runat="server" Text="Monto"></asp:Label></td>
                                        <td style="height: 18px; width: 5px;">
                                            :</td>
                                        <td style="width: 131px; height: 18px;" class="AlineacionIzquierda">
                                            <asp:Label ID="lblMontoFactura" runat="server" Text='<%# Bind("monto") %>'></asp:Label></td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfNumFactura" runat="server" Value='<%# bind("num_factura") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fechas factura">
                            <ItemStyle Width="140px" VerticalAlign="Top" Height="0px" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td style="width: 46px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label18" runat="server" Text="Emisión"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblFechaEmision" runat="server" Text='<%# Bind("fecha") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 46px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label19" runat="server" Text="Recep"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblFechaRecepcion" runat="server" Text='<%# Bind("fecha_recepcion") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 46px" class="AlineacionIzquierda">
                                            <asp:Label ID="Label20" runat="server" Text="Pago"></asp:Label></td>
                                        <td class="DosPuntos">
                                            :</td>
                                        <td style="width: 70px" class="AlineacionIzquierda">
                                            <asp:Label ID="lblFechaPago" runat="server" Text='<%# Bind("fecha_pago") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
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
        <br />
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
