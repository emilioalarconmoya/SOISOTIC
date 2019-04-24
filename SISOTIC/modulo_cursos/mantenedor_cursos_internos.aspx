<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_cursos_internos.aspx.vb" Inherits="modulo_cursos_mantenedor_cursos_internos" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>Mantenedor curso interno</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
     <!-- El JS siguiente sirve para realizar la confirmación de los botones de envio de datos a base de datos.
         Para usarlo se debe crear un control de tipo HiddenFiel con valor 0 (este se utilizara para comprobar si
         ya ha sido presionado el boton), luego en el boton que se desee aplicar se debe agregar el llamado a la
         funcion 'return ConfirmarEnvio' con los parametros siguientes: 1. nombre del campo hiddenfield y 2. El texto que
         aparecera en la pantalla de confirmacion. ejemplo: return ConfirmarEnvio('hdfEnvioDatos','¿Esta seguro de enviar estos datos?');
         y por ultimo se debe volver al valor 0 el hiddenfield en la funcion de servidor que se este realizando (esto se debe
         realizar luego de que se completen todos los procesos que esta funcion deba hacer)
         PD: Si la funcion de servidor realiza validaciones y contiene alguna salida del metodo antes de que este termine, tambien se
         debe cambiar del valor al hiddenfield antes de que este salga-->
    <script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" ></script> 
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
    <script  type="text/jscript">

        function CalculaValorFinal() 
        {
             
            var Valor= document.form1.<%= txtValorCurso.ClientID %>.value;
            var Descuento = document.form1.<%= txtDescuento.ClientID %>.value;
            //document.form1.<%= txtValorMasDescuento.ClientID %>.value = Valor - Descuento;
            if (document.form1.<%= rdbDescMonto.ClientID %>.checked == true)
            {
                document.form1.<%= txtValorMasDescuento.ClientID %>.value = Valor - Descuento;
            }
            if (document.form1.<%= rdbDescPorcentaje.ClientID %>.checked == true)
            {
                document.form1.<%= txtValorMasDescuento.ClientID %>.value = (Valor - (Valor * Descuento / 100));
            }
            var valorMasDescuento = document.form1.<%= txtValorMasDescuento.ClientID %>.value;
        }
    </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
                <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
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
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
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
        <div id="Cabecera">
            <div id="DatosUsuario">
                <%--<uc2:cabecera1 ID="datos_personales1" runat="server" />--%>
            </div>
            <div id="filtros">
                
            </div>
        </div>        
        <div id="contenido">            
            <div id="resultados">
                <asp:Wizard id="wizardCursoInterno" runat="server" ActiveStepIndex="1" Width="98%">
                    <StartNavigationTemplate>
                        <asp:Button ID="StartNextButton" runat="server" CssClass="NavigationButtom"
                            Text="Siguiente" OnClick="StartNextButton_Click1" ValidationGroup="ValidarNumero" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de enviar la información ingresada.\n¿Desea continuar?');" />
                    </StartNavigationTemplate>
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Datos curso" StepType="Start" >
                            <table cellpadding="0" cellspacing="0" class="Grid" style="width: 825px">
                                <tr>
                                    <th class="tdTextos" valign="top" colspan="6">
                                        Datos del curso - paso 1 de 2
                                    </th>
                                </tr>
                                <tr>
                                    <td class="tdTextos" valign="top">
                                        <asp:Label ID="Label1" runat="server" Text="RUT Empresa"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 25px;" valign="top">
                                        :</td>
                                    <td style="width: 273px; height: 25px;" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtRutEmpresa" runat="server" Height="16px" MaxLength="12" Width="88px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRutEmpresa"
                                            ErrorMessage="Debe ingresar un Rut de empresa." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:Button ID="btnPopUpEmpresa" runat="server" Text="..." />
                                        
                                    </td>
                                    <td style="width: 126px; height: 25px;" class="tdTextos" valign="top" rowspan="1">
                                        <asp:Label ID="Label9" runat="server" Text="A&#241;o de Inicio"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 25px;" valign="top" rowspan="1">
                                        :</td>
                                    <td style="width: 290px; height: 25px;" class="tdTextos" valign="top" rowspan="1">
                                        <asp:DropDownList ID="ddlAgnoInicio" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px; height: 28px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label2" runat="server" Text="N&#186; Participantes"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 28px;" valign="top">
                                        :</td>
                                    <td style="width: 273px; height: 28px;" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtNumParticipantes" runat="server" Width="30px" Height="16px" MaxLength="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumParticipantes"
                                            ErrorMessage="Debe ingresar el n&#250;mero de participantes." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNumParticipantes"
                                            ErrorMessage="El n&#250;mero de participantes debe ser de tipo numerico." ValidationExpression="^(?:\+|-)?\d+$"
                                            ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator>
                                        <asp:HiddenField ID="hdfNumParticipantes" runat="server" Value="0" />
                                    </td>
                                    <td style="width: 126px; height: 28px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label13" runat="server" Text="Inicio del curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 28px;" valign="top">
                                        :</td>
                                    <td style="width: 290px; height: 28px;" class="tdTextos" valign="top">
                                        <ew:CalendarPopup ID="calFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                                            ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                            DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al d&#237;a de hoy"
                                            ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                            PopupLocation="Left" SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate=""                  >
                                            <TextBoxLabelStyle Width="65px" />
                                        </ew:CalendarPopup>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="calFechaInicio"
                                            ErrorMessage="Debe ingresar una fecha de inicio." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px; height: 38px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label6" runat="server" Text="Direcci&#243;n"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 38px;" valign="top">
                                        :</td>
                                    <td style="width: 273px; height: 38px;" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtDireccion" runat="server" Width="258px" Height="16px" MaxLength="256"></asp:TextBox>
                                    </td>
                                    <td style="width: 126px; height: 38px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label14" runat="server" Text="Fin del curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 38px;" valign="top">
                                        :</td>
                                    <td style="width: 290px; height: 38px;" class="tdTextos" valign="top">
                                        <ew:CalendarPopup ID="calFechaFin" runat="server" ClearDateText="Limpiar fecha" ControlDisplay="TextBoxImage"
                                            CssClass="Calendar" Culture="Spanish (Argentina)" DisableTextBoxEntry="False"
                                            DisplayPrevNextYearSelection="True" GoToTodayText="Ir al d&#237;a de hoy" ImageUrl="~/Contenido/Imagenes/calendario.jpg"
                                            Nullable="True" PadSingleDigits="True" PopupLocation="Left" SelectedDate="" ShowClearDate="True"
                                            ShowGoToToday="True" VisibleDate=""                  >
                                            <TextBoxLabelStyle Width="65px" />
                                        </ew:CalendarPopup>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="calFechaFin"
                                            ErrorMessage="Debe ingresar una fecha de fin." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label8" runat="server" Text="Comuna"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 273px" class="tdTextos" valign="top">
                                        <asp:DropDownList ID="ddlComuna" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label15" runat="server" Text="Valor total curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtValorCurso" runat="server" CssClass="txtNumerico" Height="16px" Width="88px" MaxLength="9">0</asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtValorCurso"
                                            ErrorMessage="Debe ingresar s&#243;lo n&#250;meros enteros" ValidationExpression="\d+"
                                            ValidationGroup="ValidarNumero">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label5" runat="server" Text="Observaci&#243;n"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 273px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="255px" MaxLength="256"></asp:TextBox>
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label16" runat="server" Text="Descuento"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtDescuento" runat="server" CssClass="txtNumerico" Height="16px" Width="88px" MaxLength="9">0</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDescuento"
                                            ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="\d+"
                                            ValidationGroup="ValidarNumero">*</asp:RegularExpressionValidator>
                                        <asp:RadioButton ID="rdbDescMonto" runat="server" Text="Monto" Checked="True" GroupName="Desc" AutoPostBack="True" />
                                        <asp:RadioButton ID="rdbDescPorcentaje" runat="server" Text="Porcentaje" GroupName="Desc" AutoPostBack="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px; height: 28px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label3" runat="server" Text="Ejecutor"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 28px;" valign="top">
                                        :</td>
                                    <td style="width: 273px; height: 28px;" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtEjecutor" runat="server" Height="16px" MaxLength="256" Width="259px"></asp:TextBox>
                                    </td>
                                    <td style="width: 126px; height: 28px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label17" runat="server" Text="Valor con descuento"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 28px;" valign="top">
                                        :</td>
                                    <td style="width: 290px; height: 28px;" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtValorMasDescuento" runat="server" CssClass="txtNumerico" ReadOnly="True" Height="16px" Width="88px" MaxLength="9">0</asp:TextBox>
                                        <asp:Button ID="btnTotal" runat="server" Text="Total" ValidationGroup="ValidarNumero" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label7" runat="server" Text="Nombre curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 273px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtNombreCurso" runat="server" Height="16px" MaxLength="256" Width="259px"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label18" runat="server" Text="Correlativo Empresa"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtCorrelEmpresa" runat="server" Height="16px" Width="88px" MaxLength="256"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCorrelEmpresa"
                                            ErrorMessage="Debe ingresar el correlativo empresa." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 127px" valign="top">
                                        <asp:Label ID="Label4" runat="server" Text="Horario curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="tdTextos" style="width: 273px" valign="top">
                                        <asp:TextBox ID="txtHorarioCurso" runat="server" Height="16px" MaxLength="256" Width="257px"></asp:TextBox>
                                    </td>
                                    <td class="tdTextos" rowspan="2" valign="top" colspan="3">
                                        <asp:HiddenField ID="hdfCorrelativo" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label10" runat="server" Text="Horas curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 273px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtHorasCurso" runat="server" Height="16px" MaxLength="5" Width="67px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" valign="top" style="height: 14px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" valign="top">
                                        <asp:Label ID="Label22" runat="server" Text="Nota: Los campos con &quot;Validaci&#243;n autom&#225;tica&quot; indican cuando el Rut de la Empresa &#243; C&#243;digo Sence no est&#225; registrado en el sistema."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                                ValidationGroup="ValidarNumero" Width="200px" />
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep2" runat="server" Title="Alumnos" StepType="Finish" >
                            <table id="alumnos" cellpadding="0" cellspacing="0" class="Grid" runat="server">
                             <tr>
                                    <th class="tdTextos" valign="top" colspan="6">
                                        Datos del alumno - paso 2 de 2
                                    </th>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 835px">
                                        <asp:Label ID="Label29" runat="server" Text="Rut. alumno :"></asp:Label>
                                        <asp:TextBox ID="txtRutAlumno" runat="server" Height="16px" MaxLength="12" Width="88px"></asp:TextBox>
                                        &nbsp;
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Debe ingresar un Rut. valido." ControlToValidate="txtRutAlumno" ValidationGroup="ValidaRutAlumno" ClientValidationFunction="VerificarRut">*</asp:CustomValidator>
                                        <asp:Button ID="btnPopUpAlumno" runat="server" Text="..." />
                                        <asp:Button ID="btnAgregarAlumno" runat="server" Text="Agregar alumno" ValidationGroup="ValidaRutAlumno" Width="112px" />
                                        &nbsp;
                                        <asp:Label ID="lblCarga" runat="server" Text="Cargar participantes"></asp:Label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:Button ID="btnCargar" runat="server" Text="Cargar" />
                                            &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/contenido/Plantilla/participantes.xls">formato carga</asp:HyperLink>
                                        <br />
                                        <asp:Button ID="btnSeleccionarTodos" runat="server" Text="Seleccionar todos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 835px" valign="top">
                                        <asp:Panel ID="pnlAlumnos" runat="server" ScrollBars="Horizontal" Width="820px">
                                            <asp:GridView ID="grdAlumnos" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="820px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Elim.">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkEliminarAlumno" runat="server" />
                                                            <asp:HiddenField ID="hdfExiste" runat="server" Value='<%# Bind("existe") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rut">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut") %>' Visible="False"></asp:Label>--%>
                                                            <asp:TextBox ID="txtRut" runat="server" Text='<%# Bind("rut") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle  />
                                                        <ItemStyle />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombres">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNombres" runat="server" Text='<%# Bind("nombres") %>' Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtNombres" runat="server" Text='<%# Bind("nombres") %>'  Visible="False" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Apellido Pat.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApellidoPat" runat="server" Text='<%# Bind("apellido_paterno") %>' Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtApellidoPat" runat="server" Text='<%# Bind("apellido_paterno") %>' Visible="False"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Apellido Mat.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApellidoMat" runat="server" Text='<%# Bind("apellido_materno") %>' Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtApellidoMat" runat="server" Text='<%# Bind("apellido_materno") %>' Visible="False"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sexo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("sexo") %>' Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlSexo" runat="server"  Visible="False">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Viatico">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblViatico" runat="server" Text='<%# Bind("viatico") %>' Visible="False" ></asp:Label>
                                                            <asp:TextBox ID="txtViatico" runat="server" Text='<%# Bind("viatico") %>' Visible="False" Width="70px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Traslado">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTraslado" runat="server" Text='<%# Bind("traslado") %>' Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtTraslado" runat="server" Text='<%# Bind("traslado") %>' Visible="False" Width="70px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Estado">
                                                        <ItemTemplate>
                                                            <%--<asp:HiddenField ID="hdfAprobado" runat="server" Value='<%# Bind("flag_aprobado") %>' Visible="False" />--%>
                                                            <asp:Label ID="lblEstadoPart" runat="server" Text='<%# Bind("cod_estado_part") %>' Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlEstadoPart" runat="server"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            &nbsp;
                                        </asp:Panel>
                                        &nbsp; &nbsp;
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="ValidaRutAlumno" DisplayMode="List" />
                                        <br />
                                        <asp:Button ID="btnActualizaListaAlumnos" runat="server" Text="Actualiza lista" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </asp:WizardStep>
                    </WizardSteps>
                    <SideBarButtonStyle CssClass="sideBarButtom"  />
                    <NavigationButtonStyle CssClass="NavigationButtom"  />
                    <SideBarStyle CssClass="sideBar"  />
                    <FinishNavigationTemplate>
                        <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                            CssClass="NavigationButtom" Text="Anterior" />
                        <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" CssClass="NavigationButtom"
                            Text="Grabar y Finalizar" OnClick="FinishButton_Click" ValidationGroup="ValidacionPaso2" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de enviar la información ingresada.\n¿Desea continuar?');" />
                    </FinishNavigationTemplate>
                </asp:Wizard>
            </div>
        </div>
        <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
        <asp:HiddenField ID="hdfAgno" runat="server" />
    </div>   
    </form>
                    <%--<NavigationStyle CssClass="navigation"  />
                    <StepStyle CssClass="Steps"  />--%>
                    <%--<StartNavigationTemplate>
                        <asp:Button ID="StartNextButton" runat="server" CssClass="NavigationButtom"
                            Text="Siguiente" ValidationGroup="ValidacionPaso1" OnClick="StartNextButton_Click" />
                    </StartNavigationTemplate>
                    <StepNavigationTemplate>
                        <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                            CssClass="NavigationButtom" Text="Anterior" />
                       <asp:Button ID="StepNextButton" runat="server" CssClass="NavigationButtom"
                            OnClick="StepNextButton_Click" Text="Siguiente" />
                    </StepNavigationTemplate>--%>
</body>
</html>
