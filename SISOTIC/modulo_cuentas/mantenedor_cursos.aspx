<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_cursos.aspx.vb" Inherits="modulo_cuentas_mantenedor_cursos" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BANOTIC</title>
    <link rel="apple-touch-icon" sizes="57x57" href="../favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="../favicon/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="../favicon/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="../favicon/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="../favicon/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="../favicon/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="../favicon/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="../favicon/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="../favicon/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="../favicon/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="../favicon/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="../favicon/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="../favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="../favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="../favicon/mstile-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    
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
     <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script> 
    <script language="javascript" type="text/javascript" >
        function FocoRUT()
        {
            document.getElementById("wizardCurso_hdfFoco").value = 1;
        }
        function FocoSENCE()
        {
            document.getElementById("wizardCurso_hdfFoco").value = 2;
        }
        function abrir_popupDatosEmpresa() 
        {
            knResultados = open('pop_up_empresa.aspx' ,'NewWindow','top=250,left=250,width=328,height=162,status=no,resizable=yes,scrollbars=yes,location=no,title="Filtros dinamicos",closable=no');
        }
//        function abrir_popupDatosEmpresa(p_rut) 
//        {
//            knResultados = open('pop_up_empresa.aspx?rut='+ p_rut +'' ,'NewWindow','top=250,left=250,width=328,height=162,status=no,resizable=yes,scrollbars=yes,location=no,title="Filtros dinamicos",closable=no');
//        }

        function CantidadHoras()
        {
            __doPostBack("CantidadHoras", "");
        }
        
        function RepasarCostos()
        {
            var ValorIngresado = document.getElementById("wizardCurso_txtNumParticipantes").value;
            if (ValorIngresado != document.getElementById("wizardCurso_hdfNumParticipantes").value)
            {
                document.getElementById("wizardCurso_hdfNumParticipantes").value = ValorIngresado;
                if (document.getElementById("wizardCurso_txtValorCurso").value > 0)
                {
                    alert("ATENCION: El número de alumnos ha cambiado, debe repasar los costos del curso.");
                }                
            }
            else
            {
                document.getElementById("wizardCurso_hdfNumParticipantes").value = ValorIngresado;
            }
        }
        
        function CargarEmpresa()
        {
            __doPostBack("CargaEmpresa", "");
        }
        function CargarCursoSence()
        {
            __doPostBack("CargaCursoSence", "");
        }
        function CalculaCostos()
        {
            __doPostBack("CalculaCostos", "");
        }
        function CalculaValorFinal() 
        {
            var valorHora = 0;
            var horas = document.getElementById('hdfHoras').value;
            var participantes = document.form1.<%= txtNumParticipantes.ClientID %>.value;
            var Valor= document.form1.<%= txtValorCurso.ClientID %>.value;
            var Descuento = document.form1.<%= txtDescuento.ClientID %>.value;
            var maxParticipantes = document.getElementById('hdfMAxParticipantes').value;
            var ValorCursoSence = document.getElementById('hdfValorCursoSence').value;
            
            //if (((ValorCursoSence/maxParticipantes)*participantes) < Valor)
            //{
                valorHora = parseFloat(Valor/(horas*participantes));
                document.getElementById('wizardCurso_lblValorHora').innerHTML =  "Valor hora aprox. $" + valorHora.toFixed(2); 
                document.getElementById('wizardCurso_lblValorHora').display = "";
            //}
            //else
            //{
                //document.getElementById('wizardCurso_lblValorHora').display = "none";
            // 
            
            if (document.form1.<%= rdbDescMonto.ClientID %>.checked == true)
            {
                document.form1.<%= txtValorMasDescuento.ClientID %>.value = Valor - Descuento;
            }
            if (document.form1.<%= rdbDescPorcentaje.ClientID %>.checked == true)
            {
                document.form1.<%= txtValorMasDescuento.ClientID %>.value = (Valor - (Valor * Descuento / 100));
            }
        } 
        function CalculaValorFinalP4(gridViewName)
        {
           var tabla = document.getElementById(gridViewName);
           celdas = tabla.cells;
           var total;
           for(i=0;i<celdas.length-1;i++)
           {
            if (celdas[i].firstChild.type=="input")
              {
                 //total += celdas[i].firstChild.value;
                 alert(total);
              }
           }
           document.form1.<%= txtTerceros.ClientID %>.value = total;
        }
        
    function DoScroll()
    {
        document.all("div-datagrid").style.pixelLeft = divScroll.scrollLeft * -2;
    }
    
    function ValorHora()
     { 
            
           var txtValorHora =  document.getElementById('wizardCurso_txtValorHora').value;
            
           var hdfValorHora =  document.getElementById('hdfValorHora').value;
          
            if (confirm('El Valor de la hora sence está a $' + txtValorHora + ',\n¿Desea cambiarla?' ))
            {
            
                document.getElementById('wizardCurso_txtValorHora').value = txtValorHora;
            }
            else
            {
                document.getElementById('wizardCurso_txtValorHora').value = hdfValorHora;
            }
            
         
      }
      
      function replaceAll(text, busca, reemplaza )
      { 
        while (text.toString().indexOf(busca) != -1) 
        { 
            text = text.toString().replace(busca,reemplaza); 
        } return text; 
      } 
      
      function CalcularValoresPaso4()
      {
        
         var lngCtaCap;
         var lngExcCap;
         var lngTerceros;
         var lngCostoOtic  = document.getElementById('wizardCurso_lblCostoOtic').innerHTML;
         lngCostoOtic = replaceAll(lngCostoOtic,".","");  
         var lngSaldoCtaCap = document.getElementById('wizardCurso_lblCtaCapSaldo').innerHTML;
         lngSaldoCtaCap = replaceAll(lngSaldoCtaCap,".",""); 
         var lngSaldoExcCap  = document.getElementById('wizardCurso_lblExcCapSaldo').innerHTML; 
         lngSaldoExcCap = replaceAll(lngSaldoExcCap,".",""); 
         var txtCtaCap1 =  document.getElementById('wizardCurso_txtCtaCap1').value;
         var txtExcCap1 =  document.getElementById('wizardCurso_txtExcCap1').value;
         var txtTerceros =  document.getElementById('wizardCurso_txtTerceros').value;
         var txtPorCubrir1 =  document.getElementById('wizardCurso_txtPorCubrir1').value; 
         var lblVyT1 =  document.getElementById('wizardCurso_lblVyT1').innerHTML; 
         lblVyT1 = replaceAll(lblVyT1,".",""); 
         var txtAdminCtaCap =  document.getElementById('wizardCurso_txtAdminCtaCap').value;
         var txtAporteReq1 =  document.getElementById('wizardCurso_txtAporteReq1').value; 
         var lblGastoEmpresa =  document.getElementById('wizardCurso_lblGastoEmpresa').innerHTML; 
          lblGastoEmpresa = replaceAll(lblGastoEmpresa,".",""); 
         var txtTotalCurso =  document.getElementById('wizardCurso_txtTotalCurso').value; 
         var hdfAdmNoLinial =  document.getElementById('wizardCurso_hdfAdmNoLinial').value; 
         var lblPorcAdmin1 =  document.getElementById('wizardCurso_lblPorcAdmin1').innerHTML; 
         
        
         
         if(txtCtaCap1 != "")
         {
            lngCtaCap = parseInt(txtCtaCap1);
         }
         else
         {
           document.getElementById('wizardCurso_txtCtaCap1').value = 0;
         }
          
        
         if(txtExcCap1 != "")
         {
            lngExcCap = parseInt(txtExcCap1);
         }
         else
         {
           document.getElementById('wizardCurso_txtExcCap1').value = 0;
         }
         
         if(txtTerceros != "")
         {
            lngTerceros = parseInt(txtTerceros);
         }
         else
         {
           document.getElementById('wizardCurso_txtTerceros').value = 0;
         }
         
         if(lngSaldoExcCap < lngExcCap)
         {
            document.getElementById('wizardCurso_txtExcCap1').value = 0;
            alert("ATENCIÓN: No tiene el saldo suficiente en la cuenta de excedentes de capacitación.");
            return;
         }
         if(lngCtaCap < 0)
         {
           document.getElementById('wizardCurso_txtCtaCap1').value = 0;
           alert("ATENCIÓN: El valor ingresado en la cuenta de capacitación no debe ser menor a 0.");
           return; 
         }
         if(lngExcCap < 0)
         {
           document.getElementById('wizardCurso_txtExcCap1').value = 0;
           alert("ATENCIÓN: El valor ingresado en la cuenta de excedentes de capacitación no debe ser menor a 0.");
           return; 
         }
         if((lngCtaCap+lngExcCap+lngTerceros)>lngCostoOtic)
         {
           alert("ATENCIÓN: Los valores ingresados exceden el aporte requerido.");
           return; 
         }
         
         
         
         var AdmNoLineal;
         txtPorCubrir1 = parseInt(lngCostoOtic) - parseInt(lngCtaCap) - parseInt(lngExcCap) - parseInt(lngTerceros);
      
        
         if(hdfAdmNoLinial==true)
         {
            AdmNoLineal = 1;
         }
         else
         {
            AdmNoLineal = 0;
         }
        
         if((1-AdmNoLineal) * lblPorcAdmin1 != 0)
         {
            txtAdminCtaCap = Math.round(lngCtaCap*lblPorcAdmin1) / (1-AdmNoLineal+lblPorcAdmin1);
         }
  
         txtAporteReq1 = lngCtaCap+txtAdminCtaCap;
         
         txtTotalCurso = parseInt(lngCtaCap)+parseInt(lblGastoEmpresa)+parseInt(txtAdminCtaCap);
        
         
         document.getElementById('wizardCurso_txtPorCubrir1').value = txtPorCubrir1;
         document.getElementById('wizardCurso_txtAdminCtaCap').value = parseInt(txtAdminCtaCap);
         document.getElementById('wizardCurso_txtAporteReq1').value = parseInt(txtAporteReq1);
         
         
         
//          ' V y T

         var lblTotalViatico = document.getElementById('wizardCurso_lblTotalViatico').innerHTML; 
         lblTotalViatico = replaceAll(lblTotalViatico,".",""); 
         var lblCostoOticVyT = document.getElementById('wizardCurso_lblCostoOticVyT').innerHTML; 
         lblCostoOticVyT = replaceAll(lblCostoOticVyT,".","");     
         var txtGastoEmpresaVyT = document.getElementById('wizardCurso_txtGastoEmpresaVyT').value;
         var lblCtaCapSaldo2 = document.getElementById('wizardCurso_lblCtaCapSaldo2').innerHTML; 
         lblCtaCapSaldo2 = replaceAll(lblCtaCapSaldo2,".",""); 
         var lblExcCapSaldo2 = document.getElementById('wizardCurso_lblExcCapSaldo2').innerHTML; 
         lblExcCapSaldo2 = replaceAll(lblExcCapSaldo2,".",""); 
         var txtCtaCap2 = document.getElementById('wizardCurso_txtCtaCap2').value;
         var txtExcCap2 = document.getElementById('wizardCurso_txtExcCap2').value;
         var txtAdminCtaCapVyT = document.getElementById('wizardCurso_txtAdminCtaCapVyT').value;
         var txtAporteReq2 = document.getElementById('wizardCurso_txtAporteReq2').value;
         var lngCtaCapVyT = 0;
         var lngExcCapVyT = 0;
         
         if(txtCtaCap2 != "")
         {
            lngCtaCapVyT = parseInt(txtCtaCap2);
         }
         else
         {
           document.getElementById('wizardCurso_txtCtaCap2').value = 0;
         }
        
         
         if(txtExcCap2 != "")
         {
            lngExcCapVyT = parseInt(txtExcCap2);
         }
         else
         {
           document.getElementById('wizardCurso_txtExcCap2').value = 0;
         }
         
         
         if(lblExcCapSaldo2 < lngExcCapVyT)
         {
            document.getElementById('wizardCurso_txtExcCap2').value = 0;
            alert("ATENCIÓN: No tiene el saldo suficiente en la cuenta de excedentes de capacitación (V y T).");
            return;
         }
         if(lngCtaCapVyT < 0)
         {
           document.getElementById('wizardCurso_txtCtaCap2').value = 0;
           alert("ATENCIÓN: El valor ingresado en la cuenta de capacitación (V y T) no debe ser menor a 0.");
           return; 
         }
         if(lngExcCapVyT < 0)
         {
           document.getElementById('wizardCurso_txtExcCap2').value = 0;
           alert("ATENCIÓN: El valor ingresado en la cuenta de excedentes de capacitación (V y T) no debe ser menor a 0.");
           return; 
         }
         
          if((lngCtaCapVyT+lngExcCapVyT)>lblCostoOticVyT)
         {
           alert("ATENCIÓN: Los valores ingresados exceden el aporte requerido (V y T).");
           return; 
         }
         
         if((1-AdmNoLineal) * lblPorcAdmin1 != 0)
         {
            txtAdminCtaCapVyT = Math.round(lngCtaCapVyT*lblPorcAdmin1) / (1-AdmNoLineal+lblPorcAdmin1);
         }
         
         txtGastoEmpresaVyT = parseInt(lblVyT1) - parseInt(lngCtaCapVyT) - parseInt(lngExcCapVyT);
         txtAporteReq2 = parseInt(lngCtaCapVyT) + parseInt(txtAdminCtaCapVyT);

         document.getElementById('wizardCurso_txtAdminCtaCapVyT').value= parseInt(txtAdminCtaCapVyT);
         document.getElementById('wizardCurso_txtGastoEmpresaVyT').value = parseInt(txtGastoEmpresaVyT);
         document.getElementById('wizardCurso_txtAporteReq2').value = parseInt(txtAporteReq2);
                  
      }
    </script>



    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />


</head>
<body id="body" runat="server">
    <form id="form1" runat="server" >
     <div id="contenedorCS" runat="server" class="CS">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
    <div id="menu">
        <div id="header">
            <ul>
            <li>
                        <asp:HyperLink ID="hplResumenGrafico" runat="server" NavigateUrl="resumen_grafico.aspx"><b>Resumen de gestión</b></asp:HyperLink>
                    </li>
                    <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Cartola resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Aportes</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplCursos" runat="server" NavigateUrl="reporte_cursos_consolidado.aspx"><b>Cursos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTerceros" runat="server" NavigateUrl="reporte_terceros.aspx"><b>Terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAlumnos" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Alumnos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplViaticosyTraslado" runat="server" NavigateUrl="reporte_vyt.aspx"><b>V & T</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplPorTramo" runat="server" NavigateUrl="reporte_por_tramo.aspx"><b>Por Tramo</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplCuentas" runat="server" NavigateUrl="reporte_cuentas.aspx" Visible="true" ><b>Cuentas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCursoInterno" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos_internos.aspx"><b>Curso interno</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Cargas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplIngresoCurso" runat="server" NavigateUrl="~/modulo_cuentas/mantenedor_cursos.aspx" Visible="false"><b>Ingreso curso</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="hplCertificado" runat="server" Target="_blank"  NavigateUrl="certificado_aportes.aspx"><b>Certif. aportes</b></asp:HyperLink>
                </li>                
                <li >
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../menu.aspx"><b>Menú principal</b></asp:HyperLink>
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
        <div id="contenido" runat="server" >            
            <div id="resultados" runat="server" >
                <asp:Wizard id="wizardCurso" runat="server" ActiveStepIndex="0" CssClass="wizardCurso" >
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Datos curso" StepType="Start" >
                            <table cellpadding="0" cellspacing="0" class="Grid" width="840" id="tablaPaso1" runat="server">
                                <tr>
                                    <th id="Th1" runat="server" class="tdTextos" colspan="6" valign="top">
                                        <asp:Label ID="Label35" runat="server" Text="Mantenedor cursos Sence - Paso 1 de 4"></asp:Label>
                                    </th>
                                </tr>
                                <tr id="trCorrelativo" runat="server" visible="false" style="font-weight: bold; font-size: 12px;">
                                    <td class="tdTextos" style="width: 127px" valign="top">
                                        <asp:Label ID="Label34" runat="server" Text="Folio"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="tdTextos" colspan="4" valign="top">
                                        <asp:Label ID="lblFolio" runat="server"></asp:Label>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label1" runat="server" Text="RUT Empresa"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 293px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtRutEmpresa" runat="server" MaxLength="13" TabIndex="1" ></asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" Height="1px" Width="1px" CssClass="invisible"  />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRutEmpresa"
                                            ErrorMessage="Debe ingresar un Rut de empresa." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidatorzz" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un Rut. valido."
                                            ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator>
                                        <asp:Button ID="btnPopUpEmpresa" runat="server" Text="..." TabIndex="2" />
                                        &nbsp;
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label12" runat="server" Text="Codigo Sence"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtCodSence" runat="server" Width="96px" MaxLength="10" TabIndex="15"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCodSence"
                                            ErrorMessage="Debe ingresar un c&#243;digo Sence." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:Button ID="btnPopUpSence" runat="server" Text="..." TabIndex="16" />
                                    </td>
                                </tr>
                                <tr id="Tr1" runat="server">
                                    <td id="Td1" runat="server" class="tdTextos" style="width: 127px" valign="top">
                                        <asp:Label ID="Label25" runat="server" Text="Empresa"></asp:Label>
                                    </td>
                                    <td id="Td2" runat="server" style="width: 2px" valign="top">
                                        :</td>
                                    <td id="Td3" runat="server" class="tdTextos" style="width: 293px" valign="top">
                                        <asp:Label ID="lblNombreEmpresa" runat="server"></asp:Label>
                                    </td>
                                    <td id="Td4" runat="server" class="tdTextos" style="width: 126px" valign="top">
                                        <asp:Label ID="Label26" runat="server" Text="curso"></asp:Label>
                                    </td>
                                    <td id="Td5" runat="server" style="width: 2px" valign="top">
                                        :</td>
                                    <td id="Td6" runat="server" class="tdTextos" style="width: 290px" valign="top">
                                        <asp:Label ID="lblNombreCurso" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="Tr2" runat="server">
                                    <td id="Td7" runat="server" class="tdTextos" style="width: 127px" valign="top">
                                        <asp:Label ID="Label2" runat="server" Text="Tipo actividad"></asp:Label>
                                    </td>
                                    <td id="Td8" runat="server" style="width: 2px" valign="top">
                                        :</td>
                                    <td id="Td9" runat="server" class="tdTextos" style="width: 293px" valign="top">
                                        <asp:DropDownList ID="ddlTipoActividad" runat="server" TabIndex="3">
                                        </asp:DropDownList>
                                    </td>
                                    <td id="Td10" runat="server" class="tdTextos" style="width: 126px" valign="top">
                                        <asp:Label ID="Label24" runat="server" Text="Valor hora"></asp:Label>
                                    </td>
                                    <td id="Td11" runat="server" style="width: 2px" valign="top">
                                        :</td>
                                    <td id="Td12" runat="server" class="tdTextos" style="width: 290px" valign="top">
                                        <asp:TextBox ID="txtValorHora" runat="server" MaxLength="10" Width="64px"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label3" runat="server" Text="Comit&#233; bipartito"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 293px" class="tdTextos" valign="top">
                                        <asp:RadioButton ID="rdbComBipNo" runat="server" Text="No" Checked="True" GroupName="ComBip" TabIndex="4" />
                                        <asp:RadioButton ID="rdbComBipSi" runat="server" Text="Si" GroupName="ComBip" TabIndex="5" />
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label13" runat="server" Text="Inicio del curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtFechaInicio" runat="server" Width="71px" TabIndex="17"></asp:TextBox>
                                        <%--<ew:CalendarPopup ID="calFechaInicio" runat="server" ClearDateText="Limpiar fecha"
                                            ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                            DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al d&#237;a de hoy"
                                            ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                            PopupLocation="Left" SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" TabIndex="17"                                  >
                                            <TextBoxLabelStyle Width="65px" />
                                        </ew:CalendarPopup>--%>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="calFechaInicio"
                                            ErrorMessage="Debe ingresar una fecha de inicio." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label4" runat="server" Text="Det. de necesidades"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 293px" class="tdTextos" valign="top">
                                        <asp:RadioButton ID="rdbDetNecNo" runat="server" Text="No" Checked="True" GroupName="DetNec" TabIndex="6" />
                                        <asp:RadioButton ID="rdbDetNecSi" runat="server" Text="Si" GroupName="DetNec" />
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label14" runat="server" Text="Fin del curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtFechaFin" runat="server" Width="71px" TabIndex="18"></asp:TextBox>
                                        <%--<ew:CalendarPopup ID="calFechaFin" runat="server" ClearDateText="Limpiar fecha" ControlDisplay="TextBoxImage"
                                            CssClass="Calendar" Culture="Spanish (Argentina)" DisableTextBoxEntry="False"
                                            DisplayPrevNextYearSelection="True" GoToTodayText="Ir al d&#237;a de hoy" ImageUrl="~/Contenido/Imagenes/calendario.jpg"
                                            Nullable="True" PadSingleDigits="True" PopupLocation="Left" SelectedDate="" ShowClearDate="True"
                                            ShowGoToToday="True" VisibleDate="" TabIndex="18"                                  >
                                            <TextBoxLabelStyle Width="65px" />
                                        </ew:CalendarPopup>--%>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="calFechaFin"
                                            ErrorMessage="Debe ingresar una fecha de fin." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>--%>
                                        &nbsp;<asp:Label ID="Label21" runat="server" Text="Hrs. comp :"></asp:Label>
                                        <asp:TextBox ID="txtHrsComp" runat="server" Width="30px" MaxLength="3" TabIndex="19">0</asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtHrsComp"
                                            ErrorMessage="Debe ingresar n&#250;mero de horas complementarias." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtHrsComp"
                                            ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                            ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px; height: 22px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label5" runat="server" Text="N&#186; participantes"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 22px;" valign="top">
                                        :</td>
                                    <td style="width: 293px; height: 22px;" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtNumParticipantes" runat="server" Width="30px" MaxLength="4" TabIndex="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumParticipantes"
                                            ErrorMessage="Debe ingresar el n&#250;mero de participantes." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNumParticipantes"
                                            ErrorMessage="El n&#250;mero de participantes debe ser de tipo numerico." ValidationExpression="^(?:\+|-)?\d+$"
                                            ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator>
                                        <asp:HiddenField ID="hdfNumParticipantes" runat="server" Value="0" />
                                    </td>
                                    <td style="width: 126px; height: 22px;" class="tdTextos" valign="top">
                                        <asp:Label ID="Label15" runat="server" Text="Valor total curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px; height: 22px;" valign="top">
                                        :</td>
                                    <td style="width: 290px; height: 22px;" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtValorCurso" runat="server" CssClass="txtNumerico" Width="60px" MaxLength="9" TabIndex="20">0</asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtValorCurso"
                                            ErrorMessage="Debe ingresar el valor del curso." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtValorCurso"
                                            ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                            ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtValorCurso"
                                            ErrorMessage="El valor ingresado es muy alto." ValidationGroup="ValidacionPaso1" MaximumValue="2147481494" MinimumValue="0">*</asp:RangeValidator>--%>
                                        <asp:Label ID="lblValorHora" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label6" runat="server" Text="Direcci&#243;n"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 293px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtDireccion" runat="server" Width="176px" MaxLength="128" TabIndex="9"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDireccion"
                                            ErrorMessage="Debe ingresar una direcci&#243;n." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <asp:Label ID="Label20" runat="server" Text="N&#186;"></asp:Label>
                                        <asp:TextBox ID="txtNumDireccion" runat="server" Width="30px" MaxLength="64" TabIndex="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNumDireccion"
                                            ErrorMessage="Debe ingresar un n&#250;mero de direcci&#243;n." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label16" runat="server" Text="Descuento"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtDescuento" runat="server" CssClass="txtNumerico" Width="60px" MaxLength="9" TabIndex="21">0</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtDescuento"
                                            ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                            ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDescuento"
                                            ErrorMessage="Debe ingresar un valor al descuento." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                        <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtDescuento"
                                            ErrorMessage="El valor ingresado es muy alto." ValidationGroup="ValidacionPaso1" MaximumValue="2147481494" MinimumValue="0">*</asp:RangeValidator>--%>
                                        <asp:RadioButton ID="rdbDescMonto" runat="server" Text="Monto" Checked="True" GroupName="Desc" AutoPostBack="True" TabIndex="22" />
                                        <asp:RadioButton ID="rdbDescPorcentaje" runat="server" Text="Porcentaje" GroupName="Desc" AutoPostBack="True" TabIndex="23" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label7" runat="server" Text="Ciudad"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 293px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtCiudad" runat="server" MaxLength="64" TabIndex="11"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCiudad"
                                            ErrorMessage="Debe ingresar una ciudad." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label17" runat="server" Text="Valor con descuento"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtValorMasDescuento" runat="server" CssClass="txtNumerico" ReadOnly="True" Width="60px" MaxLength="9" TabIndex="24">0</asp:TextBox>
                                        <asp:Button ID="btnTotal" runat="server" Text="Total" TabIndex="25" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 127px" valign="top">
                                        <asp:Label ID="Label8" runat="server" Text="Comuna"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td class="tdTextos" style="width: 293px" valign="top">
                                        <asp:DropDownList ID="ddlComuna" runat="server" TabIndex="12">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="tdTextos" style="width: 126px" valign="top" id="tdPorcAdmin1" runat="server" visible="true">
                                        <asp:Label ID="Label66" runat="server" Text="Porc. admin."></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top" id="tdPorcAdmin2" runat="server" visible="true">
                                        :</td>
                                    <td class="tdTextos" style="width: 290px" valign="top" id="tdPorcAdmin3" runat="server" visible="true">
                                        <asp:TextBox ID="txtPorcAdmin" runat="server" CssClass="txtNumerico"
                                            Width="24px" TabIndex="26"></asp:TextBox>
                                        %<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                            ControlToValidate="txtPorcAdmin" ErrorMessage="Debe ingresar solo n&#250;meros"
                                            ValidationExpression="^[0-9]*(\.[0-9]+)?$" ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPorcAdmin"
                                            ErrorMessage="Debe ingresar el porcentaje de administraci&#243;n." ValidationGroup="ValidacionPaso1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 127px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label9" runat="server" Text="A&#241;o de Inicio"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 293px" class="tdTextos" valign="top">
                                        <asp:DropDownList ID="ddlAgnoInicio" runat="server" TabIndex="13">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 126px" class="tdTextos" valign="top">
                                        <asp:Label ID="Label18" runat="server" Text="Correlativo Empresa"></asp:Label>
                                    </td>
                                    <td style="width: 2px" valign="top">
                                        :</td>
                                    <td style="width: 290px" class="tdTextos" valign="top">
                                        <asp:TextBox ID="txtCorrelEmpresa" runat="server" Width="80px" MaxLength="24" TabIndex="27"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="Tr3" runat="server">
                                    <td id="Td13" runat="server" class="tdTextos" style="width: 127px" valign="top">
                                        <asp:Label ID="Label11" runat="server" Text="Modalidad"></asp:Label>
                                    </td>
                                    <td id="Td14" runat="server" style="width: 2px" valign="top">
                                        :</td>
                                    <td id="Td15" runat="server" class="tdTextos" style="width: 293px" valign="top">
                                        <asp:DropDownList ID="ddlModalidad" runat="server" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                    <td id="Td16" runat="server" class="tdTextos" style="width: 126px" valign="top">
                                        <asp:Label ID="Label77" runat="server" Text="Curso CFT"></asp:Label>
                                    </td>
                                    <td id="Td17" runat="server" style="width: 2px" valign="top">
                                        :</td>
                                    <td id="Td18" runat="server" class="tdTextos" style="width: 290px" valign="top">
                                        <asp:CheckBox ID="chkCursoCFT" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 127px" valign="top" rowspan="3">
                                        <asp:Label ID="Label10" runat="server" Text="Obvervaci&#243;n"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td style="width: 2px" valign="top" rowspan="3">
                                        :</td>
                                    <td class="tdTextos" style="width: 293px" valign="top" rowspan="3">
                                        <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="256px" MaxLength="256" TabIndex="14" Height="64px"></asp:TextBox>
                                        &nbsp;</td>
                                    <td class="tdTextos" rowspan="2" style="width: 126px" valign="top">
                                        <asp:Label ID="Label89" runat="server" Text="CONTACTO PRINCIPAL"></asp:Label>
                                    </td>
                                    <td rowspan="2" style="width: 2px" valign="top">
                                        :</td>
                                    <td class="tdTextos" rowspan="2" style="width: 290px" valign="top">
                                        <asp:Label ID="lblContactoPrincipal" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" class="tdTextos" rowspan="1" style="width: 126px" valign="top">
                                        <asp:Label ID="Label19" runat="server" Text="Contacto Adicional"></asp:Label>
                                    </td>
                                    <td runat="server" rowspan="1" style="width: 2px" valign="top">
                                    </td>
                                    <td runat="server" class="tdTextos" rowspan="1" style="width: 290px" valign="top">
                                        <asp:TextBox ID="txtContactoAdicinal" runat="server" TextMode="MultiLine" Width="255px" Rows="3" MaxLength="256" TabIndex="28"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" valign="top">
                                        <asp:Label ID="Label22" runat="server" Text="Nota: Los campos con &quot;Validaci&#243;n autom&#225;tica&quot; indican cuando el Rut de la Empresa &#243; C&#243;digo Sence no est&#225; registrado en el sistema."></asp:Label>
                                        <asp:HiddenField ID="hdfFoco" runat="server" Value="1" />
                                    </td>
                                </tr>
                            </table>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                                ValidationGroup="ValidacionPaso1" />

                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep2" runat="server" Title="Horario de clases" StepType="Step">
                            <table cellpadding="0" cellspacing="0" class="Grid" width="840" id="tablaPaso2" runat="server">
                                <tr>
                                    <th class="tdTextos" colspan="3">
                                        <asp:Label ID="Label666" runat="server" Text="Mantenedor cursos Sence - Paso 2 de 4"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 80px">
                                        <asp:Label ID="Label23" runat="server" Text="Empresa"></asp:Label>
                                    </td>
                                    <td style="width: 2px">
                                        :</td>
                                    <td class="tdTextos" style="width: 748px">
                                        <asp:Label ID="lblEmpresa" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 80px">
                                        <asp:Label ID="Label27" runat="server" Text="Curso"></asp:Label>
                                    </td>
                                    <td style="width: 2px">
                                        :</td>
                                    <td class="tdTextos" style="width: 748px">
                                        <asp:Label ID="lblCurso" runat="server"></asp:Label>
                                        &nbsp;-
                                        <asp:Label ID="Label30" runat="server" Text="Horas :"></asp:Label>
                                        <asp:Label ID="lblHoras" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 80px">
                                        <asp:Label ID="Label28" runat="server" Text="Otec"></asp:Label>
                                    </td>
                                    <td style="width: 2px">
                                        :</td>
                                    <td class="tdTextos" style="width: 748px">
                                        <asp:Label ID="lblOtec" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="Tr4" runat="server">
                                    <td id="Td19" runat="server" class="tdTextos" style="width: 80px">
                                        <asp:Label ID="Label29" runat="server" Text="Horas curso"></asp:Label>
                                    </td>
                                    <td id="Td20" runat="server" style="width: 2px">
                                        :</td>
                                    <td id="Td21" runat="server" class="tdTextos" style="width: 748px">
                                        <asp:Label ID="lblTotalHoras" runat="server"></asp:Label>
                                        <asp:Button ID="btnCalcularTotalHoras" runat="server" Text="c&#225;lcular total horas" />
                                    </td>
                                </tr>
                            </table>
                            
                            
                            <%--<table cellpadding="0" cellspacing="0" class="Grid" width="840">
                                <tr>
                                    <td class="tdTextos" style="width: 450px" valign="top">
                                        <asp:Label ID="Label24" runat="server" Text="D&#237;as"></asp:Label>
                                        <asp:DropDownList ID="ddlDias" runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="Label25" runat="server" Text="Inicio :"></asp:Label>
                                        <asp:TextBox ID="txtHoraInicio" runat="server" MaxLength="2" Width="23px"></asp:TextBox>
                                        :<asp:TextBox ID="txtMinutoInicio" runat="server" MaxLength="2" Width="23px"></asp:TextBox>
                                        <asp:DropDownList ID="ddlHoraInicio" runat="server" Visible="False">
                                        </asp:DropDownList>
                                        <asp:Label ID="Label26" runat="server" Text="Fin :"></asp:Label>
                                        <asp:TextBox ID="txtHoraFin" runat="server" MaxLength="2" Width="23px"></asp:TextBox>
                                        :<asp:TextBox ID="txtMinutoFin" runat="server" MaxLength="2" Width="23px"></asp:TextBox>
                                        <asp:DropDownList ID="ddlHoraFin" runat="server" Visible="False">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnAgregarHorario" runat="server" Text="Agregar" />
                                    </td>
                                    <td style="width: 380px" valign="top">
                                        <asp:GridView ID="grdHorario" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                            Width="370px">
                                            <Columns>
                                                <asp:BoundField HeaderText="D&#237;a">
                                                    <HeaderStyle Width="120px" />
                                                    <ItemStyle Width="120px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Inicio">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Fin">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle Width="80px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkEliminar" runat="server" />
                                                        <asp:HiddenField ID="hdfDiaValor" runat="server" Value='<%# Bind("Dia") %>' /><asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("CodCurso") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Button ID="btnActualizaLista" runat="server" Text="Actualizar lista" Visible="False" />
                                    </td>
                                </tr>
                            </table>--%>
                            <div id="tablaHorario" runat="server" >
                            <table cellpadding="0" cellspacing="0" class="Grid" width="840">
                                <tr >
                                    <td>DIA</td>
                                    <td>DESDE</td>
                                    <td>HASTA</td>
                                    <td>DESDE</td>
                                    <td>HASTA</td>
                                    <td>DESDE</td>
                                    <td>HASTA</td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:CheckBox ID="chkDia1" runat="server" />
                                        LUNES &nbsp;
                                        <asp:Label ID="lblHorasLun" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHora1_1" runat="server" CssClass="TextoHorario" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin1_1" runat="server" CssClass="TextoHorario" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora2_1" runat="server" CssClass="TextoHorario" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin2_1" runat="server" CssClass="TextoHorario" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora3_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin3_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora4_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin4_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora5_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin5_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora6_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin6_1" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:CheckBox ID="chkDia2" runat="server" />
                                        MARTES &nbsp;
                                        <asp:Label ID="lblHorasMar" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtHora1_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin1_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                   <td><asp:TextBox ID="txtHora2_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin2_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora3_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin3_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora4_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin4_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora5_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin5_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora6_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin6_2" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:CheckBox ID="chkDia3" runat="server" />
                                        MIERCOLES &nbsp;
                                        <asp:Label ID="lblHorasMie" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtHora1_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin1_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora2_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin2_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora3_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin3_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora4_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin4_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora5_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin5_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora6_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin6_3" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:CheckBox ID="chkDia4" runat="server" />
                                        JUEVES &nbsp;
                                        <asp:Label ID="lblHorasJue" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtHora1_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin1_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora2_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin2_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora3_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin3_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora4_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin4_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora5_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin5_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora6_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin6_4" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:CheckBox ID="chkDia5" runat="server" />
                                        VIERNES &nbsp;
                                        <asp:Label ID="lblHorasVie" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtHora1_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin1_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora2_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin2_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora3_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin3_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                   <td><asp:TextBox ID="txtHora4_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin4_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora5_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin5_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora6_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin6_5" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:CheckBox ID="chkDia6" runat="server" />
                                        SABADO &nbsp;
                                        <asp:Label ID="lblHorasSab" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtHora1_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin1_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora2_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin2_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora3_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin3_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora4_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin4_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora5_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin5_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora6_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin6_6" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda">
                                        <asp:CheckBox ID="chkDia7" runat="server" />
                                        DOMINGO &nbsp;
                                        <asp:Label ID="lblHorasDom" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td><asp:TextBox ID="txtHora1_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin1_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora2_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin2_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora3_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin3_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora4_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin4_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora5_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin5_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                    <td><asp:TextBox ID="txtHora6_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                        &nbsp;:
                                        <asp:TextBox ID="txtMin6_7" runat="server" Width="15px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            </div>
                            
                                <asp:Button ID="btnRepetir" runat="server" Text="Repetir horario" />
                                <asp:Button ID="btnBorrarHorario" runat="server" Text="Borrar Horario" />
                            <br />
                            <asp:Label ID="lblRepetirHorario" runat="server" Text ="Agregue un horario en la tabla y luego seleccione solo aquellas filas en las que deba duplicarse."></asp:Label>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep3" runat="server" Title="Alumnos" StepType="Step">
                            <table cellpadding="0" cellspacing="0" class="Grid" width="100%" id="tablaPaso3" runat="server">
                                <tr>
                                    <th class="tdTextos" style="width: 835px; height: 22px;">
                                        <asp:Label ID="Label555" runat="server" Text="Mantenedor cursos Sence - Paso 3 de 4"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td class="tdTextos" style="width: 835px; height: 29px;">
                                        <asp:Label ID="lblRutAlumno" runat="server" Text="Rut. alumno :"></asp:Label>
                                        <asp:TextBox ID="txtRutAlumno" runat="server" MaxLength="13"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Debe Ingresar un Rut." ControlToValidate="txtRutAlumno" ValidationGroup="ValidaRutAlumno">*</asp:RequiredFieldValidator>
                                        &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                            ControlToValidate="txtRutAlumno" ErrorMessage="Debe ingresar un RUT v&#225;lido"
                                            ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator>
                                        <asp:Button ID="btnPopUpAlumno" runat="server" Text="..." />
                                        <asp:Button ID="btnAgregarAlumno" runat="server" Text="Agregar alumno" ValidationGroup="ValidaRutAlumno" />
                                        <asp:FileUpload ID="flpCarga" runat="server" />
                                        &nbsp;<asp:Button ID="btnCargarArchivo" runat="server" Text="Cargar Archivo" />
                                        &nbsp;
                                        <asp:LinkButton ID="LinkButton1" runat="server">Formato carga</asp:LinkButton>
                                        <asp:Button ID="btnSeleccionarTodos" runat="server" Text="Seleccionar todos" />
                                    </td>
                                </tr>
                                <tr>
                                    <td><%--<td style="width: 835px">--%>
                                        <%--<asp:Panel ID="pnlAlumnos" runat="server" ScrollBars="Horizontal" Width="835px">--%>
                                        <div id="divdatagrid" runat="server" class="div-datagrid" >
                                            <asp:GridView ID="grdAlumnos" runat="server" AutoGenerateColumns="False" CssClass="Grid">
                                                <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <table class="TablaInterior">
                                                            <tr>
                                                                <td valign="top" class="AlineacionIzquierda">
                                                                    <asp:Label ID="lblContador" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                    <ItemStyle VerticalAlign="Top" Width="5px" />
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="X" >
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkEliminarAlumno" runat="server" />
                                                            <asp:HiddenField ID="hdfExiste" runat="server" Value='<%# Bind("existe") %>' />
                                                            <asp:HiddenField ID="hdfFranquicia" runat="server" Value='<%# Bind("franquicia") %>' />
                                                            <asp:HiddenField ID="hdfAsistencia" runat="server" Value='<%# Bind("porc_asistencia") %>' />
                                                        </ItemTemplate>

<ItemStyle Width="4px"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rut" >
                                                        <ItemTemplate >
                                                            <asp:Label ID="lblRut" runat="server" Text='<%# Bind("rut") %>' Visible="False" Width="80px"></asp:Label>
                                                            <asp:TextBox ID="txtRUT" runat="server" Text='<%# Bind("rut") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nombres">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNombres" runat="server" Text='<%# Bind("nombres") %>' Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtNombres" runat="server" Visible="False" Text='<%# Bind("nombres") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate >
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Apellido Pat.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApellidoPat" runat="server" Text='<%# Bind("apellido_paterno") %>'
                                                                Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtApellidoPat" runat="server" Visible="False" Text='<%# Bind("apellido_paterno") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Apellido Mat.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApellidoMat" runat="server" Text='<%# Bind("apellido_materno") %>'
                                                                Visible="False"></asp:Label>
                                                            <asp:TextBox ID="txtApellidoMat" runat="server" Visible="False" Text='<%# Bind("apellido_materno") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Franq.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFranquicia" runat="server" Text='<%# Bind("franquicia") %>' Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlFranquicia" runat="server" Visible="False">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Viatico">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtViatico" runat="server" Text='<%# bind("viatico") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Traslado">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtTraslado" runat="server" Text='<%# Bind("traslado") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sexo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("sexo") %>' Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlSexo" runat="server" Visible="False">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Regi&#243;n">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRegion" runat="server" Text='<%# Bind("region") %>' Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlRegion" runat="server" Visible="False">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdfCodRegion" runat="server" Value='<%# Bind("cod_region") %>' />
                                                        </ItemTemplate >
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comuna">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComuna" runat="server" Text='<%# Bind("comuna") %>' Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlComunaParicipante" runat="server" Visible="False" AutoPostBack="false" >
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdfComuna" runat="server" Value='<%# Bind("cod_comuna") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="País">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPais" runat="server" Text='<%# Bind("pais") %>' Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlPaisParicipante" runat="server" Visible="False" AutoPostBack="false">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdfCodPais" runat="server" Value='<%# Bind("cod_pais") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nivel ocup.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNivelOcup" runat="server" Text='<%# Bind("nivel_ocupacional") %>'
                                                                Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlNivelOcup" runat="server" Visible="False">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdfNivelOcup" runat="server" Value='<%# Bind("cod_nivel_ocupacional") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Porcentaje asistencia" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPorcAsistencia" runat="server" Width="56px" Text='<%# bind("porc_asistencia") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nivel educ.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNivelEduc" runat="server" Text='<%# Bind("nivel_educacional") %>'
                                                                Visible="False"></asp:Label>
                                                            <asp:DropDownList ID="ddlNivelEduc" runat="server" Visible="False">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdfNivelEduc" runat="server" Value='<%# Bind("cod_nivel_educacional") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha nac.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFechaNac" runat="server" Text='<%# Bind("fecha_nacimiento") %>'
                                                                Visible="False"></asp:Label>
                                                            <ew:CalendarPopup ID="calFechaNac" runat="server" ClearDateText="Limpiar fecha" Width="100px"
                                            ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                                            DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                                            ImageUrl="~/Contenido/Imagenes/calendario.jpg" Nullable="True" PadSingleDigits="True"
                                            PopupLocation="Left" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" Visible="false" PostedDate="" UpperBoundDate="12/31/9999 23:59:59"    >
                                                                <TextBoxLabelStyle Width="65px" />
                                                            </ew:CalendarPopup>
                                                            <asp:TextBox ID="txtFechaNac" runat="server" Text='<%# Bind("fecha_nacimiento") %>' Width="75px"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtFechaNac" ValidationExpression="/^((([0][1-9]|[12][\d])|[3][01])[-\/]([0][13578]|[1][02])[-\/][1-9]\d\d\d)|((([0][1-9]|[12][\d])|[3][0])[-\/]([0][13456789]|[1][012])[-\/][1-9]\d\d\d)|(([0][1-9]|[12][\d])[-\/][0][2][-\/][1-9]\d([02468][048]|[13579][26]))|(([0][1-9]|[12][0-8])[-\/][0][2][-\/][1-9]\d\d\d)$/">*</asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtFechaNac">*</asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="esFechaValida"
                                                                ControlToValidate="txtFechaNac" ErrorMessage="La fecha de nacimiento ingresada no es valida." ValidationGroup="ValidarPaso3">*</asp:CustomValidator>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Fono Cel.">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtFono" runat="server" Text='<%# Bind("fono") %>' Width="50px" MaxLength="8"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            </div>
                                        <%--</asp:Panel>--%>
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="ValidaRutAlumno" />
                                        <br />
                                        <asp:Button ID="btnActualizaListaAlumnos" runat="server" Text="Actualizar lista" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep4" runat="server" Title="Cuentas" StepType="Finish">
                            <table cellpadding="0" cellspacing="0" class="Grid" width="840" id="tablaPaso4" runat="server">
                                <tr>
                                    <th  class="tdTextos" colspan="3" valign="top">
                                        <asp:Label ID="Label444" runat="server" Text="Mantenedor cursos Sence - Paso 4 de 4"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td style="width: 280px; height: 328px;" valign="top">
                                        <table cellpadding="0" cellspacing="0" class="Grid" width="270">
                                            <tr>
                                                <th colspan="5">
                                                    <asp:Label ID="Label59" runat="server" Text="Montos a cargar curso"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td class="AlineacionDerecha" colspan="4">
                                                    <asp:Label ID="Label61" runat="server" Text="Costo OTIC del curso :"></asp:Label>
                                                    <asp:Label ID="Label62" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:Label ID="lblCostoOtic" runat="server" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th colspan="3">
                                                    <asp:Label ID="Label58" runat="server" Text="Cuentas propias "></asp:Label>
                                                </th>
                                                <th style="width: 65px">
                                                    <asp:Label ID="Label37" runat="server" Text="Saldo"></asp:Label>
                                                </th>
                                                <th style="width: 65px" class="AlineacionDerecha">
                                                    <asp:Label ID="Label36" runat="server" Text="Monto"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px">
                                                    <asp:Label ID="Label43" runat="server" Text="Cta. de Cap."></asp:Label>
                                                </td>
                                                <td style="width: 3px">
                                                    <asp:Label ID="Label40" runat="server" Text=":"></asp:Label>
                                                </td>
                                                <td style="width: 3px">
                                                    <asp:Label ID="Label38" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:Label ID="lblCtaCapSaldo" runat="server" Text="0"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCtaCap1"
                                                        ErrorMessage="Este dato no debe estar vacio." ValidationGroup="ValidacionPaso4">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCtaCap1"
                                                        ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                                        ValidationGroup="ValidacionPaso4">*</asp:RegularExpressionValidator>
                                                    <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCtaCap1"
                                                        ErrorMessage="El valor ingresado es muy alto." ValidationGroup="ValidacionPaso4" MaximumValue="2147481494" MinimumValue="0">*</asp:RangeValidator>--%>
                                                    <asp:TextBox ID="txtCtaCap1" runat="server" Width="50px" CssClass="txtNumerico"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px">
                                                    <asp:Label ID="Label48" runat="server" Text="Exc. de Cap."></asp:Label>
                                                </td>
                                                <td style="width: 3px">
                                                    <asp:Label ID="Label41" runat="server" Text=":"></asp:Label>
                                                </td>
                                                <td style="width: 3px">
                                                    <asp:Label ID="Label39" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:Label ID="lblExcCapSaldo" runat="server" Text="0"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtExcCap1"
                                                        ErrorMessage="Este dato no debe estar vacio." ValidationGroup="ValidacionPaso4">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtExcCap1"
                                                        ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                                        ValidationGroup="ValidacionPaso4">*</asp:RegularExpressionValidator>
                                                    <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtExcCap1"
                                                        ErrorMessage="El valor ingresado es muy alto." ValidationGroup="ValidacionPaso4" MaximumValue="2147481494" MinimumValue="0">*</asp:RangeValidator>--%>
                                                    <asp:TextBox ID="txtExcCap1" runat="server" Width="50px" CssClass="txtNumerico"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trBecas" runat="server" visible="false">
                                                <td style="width: 150px" id="Td22">
                                                    <asp:Label ID="Label31" runat="server" Text="Cta. Becas"></asp:Label>
                                                </td>
                                                <td style="width: 3px" id="Td23">
                                                    <asp:Label ID="Label32" runat="server" Text=":"></asp:Label>
                                                </td>
                                                <td style="width: 3px" id="Td24">
                                                    <asp:Label ID="Label33" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td class="AlineacionDerecha" style="width: 65px" id="Td25">
                                                    <asp:Label ID="lblBecasSaldo" runat="server" Text="0"></asp:Label>
                                                </td>
                                                <td class="AlineacionDerecha" style="width: 65px" id="Td26">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtBecas"
                                                        ErrorMessage="Este dato no debe estar vacio." ValidationGroup="ValidacionPaso4">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtBecas"
                                                        ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                                        ValidationGroup="ValidacionPaso4">*</asp:RegularExpressionValidator>
                                                    <%--<asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtBecas"
                                                        ErrorMessage="El valor ingresado es muy alto." ValidationGroup="ValidacionPaso4" MaximumValue="2147481494" MinimumValue="0">*</asp:RangeValidator>--%>
                                                    <asp:TextBox ID="txtBecas" runat="server" CssClass="txtNumerico" Width="50px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px">
                                                    <asp:Label ID="Label49" runat="server" Text="Cta. terceros"></asp:Label>
                                                </td>
                                                <td style="width: 3px">
                                                    <asp:Label ID="Label42" runat="server" Text=":"></asp:Label>
                                                </td>
                                                <td style="width: 3px">
                                                    <asp:Label ID="Label73" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:TextBox ID="txtTerceros" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="AlineacionDerecha" colspan="4">
                                                    <asp:Label ID="Label50" runat="server" Text="Por cubrir: "></asp:Label>
                                                    <asp:Label ID="Label44" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:TextBox ID="txtPorCubrir1" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True">0</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="AlineacionDerecha" colspan="4">
                                                    <asp:Label ID="Label51" runat="server" Text="Vi&#225;ticos y Traslados: "></asp:Label>
                                                    <asp:Label ID="Label45" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:Label ID="lblVyT1" runat="server" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="AlineacionDerecha" colspan="4">
                                                    <asp:Label ID="Label52" runat="server" Text="Admin. Cta. Cap.("></asp:Label>
                                                    <asp:Label ID="lblPorcAdmin1" runat="server" Text="0"></asp:Label>
                                                    <asp:Label ID="Label85" runat="server" Text="%):"></asp:Label>
                                                    <asp:Label ID="Label46" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:TextBox ID="txtAdminCtaCap" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True">0</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="AlineacionDerecha" colspan="4">
                                                    <asp:Label ID="Label53" runat="server" Text="Aporte requerido: "></asp:Label>
                                                    <asp:Label ID="Label47" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:TextBox ID="txtAporteReq1" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True">0</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th colspan="5">
                                                    <asp:Label ID="Label60" runat="server" Text="Otros"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td class="AlineacionDerecha" colspan="4">
                                                    <asp:Label ID="Label54" runat="server" Text="Gasto Empresa: "></asp:Label>
                                                    <asp:Label ID="Label56" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:Label ID="lblGastoEmpresa" runat="server" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="AlineacionDerecha" colspan="4">
                                                    <asp:Label ID="Label55" runat="server" Text="Valor Total Curso: "></asp:Label>
                                                    <asp:Label ID="Label57" runat="server" Text="$"></asp:Label>
                                                </td>
                                                <td style="width: 65px" class="AlineacionDerecha">
                                                    <asp:TextBox ID="txtTotalCurso" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True">0</asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 280px; height: 328px;" valign="top"><table cellpadding="0" cellspacing="0" class="Grid" width="270">
                                        <tr>
                                            <th colspan="5">
                                                <asp:Label ID="Label63" runat="server" Text="Montos a cargar por V y T"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionDerecha" colspan="4">
                                                <asp:Label ID="Label64" runat="server" Text="Total VYT :"></asp:Label>
                                                <asp:Label ID="Label65" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td style="width: 65px" class="AlineacionDerecha">
                                                <asp:Label ID="lblTotalViatico" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionDerecha" colspan="4">
                                                <asp:Label ID="Label78" runat="server" Text="Total Traslado :"></asp:Label>
                                                <asp:Label ID="Label84" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td class="AlineacionDerecha" style="width: 65px">
                                                <asp:Label ID="lblTotalTraslado" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionDerecha" colspan="4">
                                                <asp:Label ID="Label95" runat="server" Text="Costo OTIC VYT :"></asp:Label>
                                                <asp:Label ID="Label96" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td class="AlineacionDerecha" style="width: 65px">
                                                <asp:Label ID="lblCostoOticVyT" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionDerecha" colspan="4">
                                                <asp:Label ID="Label98" runat="server" Text="Gasto empresa VYT :"></asp:Label>
                                                <asp:Label ID="Label97" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td class="AlineacionDerecha" style="width: 65px">
                                                <asp:TextBox ID="txtGastoEmpresaVyT" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th colspan="3">
                                                <asp:Label ID="Label67" runat="server" Text="Cuentas propias "></asp:Label>
                                            </th>
                                            <th style="width: 65px">
                                                <asp:Label ID="Label68" runat="server" Text="Saldo Franq."></asp:Label>
                                            </th>
                                            <th style="width: 65px" class="AlineacionDerecha">
                                                <asp:Label ID="Label69" runat="server" Text="Monto"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label70" runat="server" Text="Cta. de Cap."></asp:Label>
                                            </td>
                                            <td style="width: 3px">
                                                <asp:Label ID="Label71" runat="server" Text=":"></asp:Label>
                                            </td>
                                            <td style="width: 3px">
                                                <asp:Label ID="Label72" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td style="width: 65px" class="AlineacionDerecha">
                                                <asp:Label ID="lblCtaCapSaldo2" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td style="width: 65px" class="AlineacionDerecha">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtCtaCap2"
                                                    ErrorMessage="Este dato no debe estar vacio." ValidationGroup="ValidacionPaso4">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtCtaCap2"
                                                    ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                                    ValidationGroup="ValidacionPaso4">*</asp:RegularExpressionValidator>
                                                <%--<asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtCtaCap2"
                                                    ErrorMessage="El valor ingresado es muy alto." ValidationGroup="ValidacionPaso4" MaximumValue="2147481494" MinimumValue="0">*</asp:RangeValidator>--%>
                                                <asp:TextBox ID="txtCtaCap2" runat="server" Width="50px" CssClass="txtNumerico"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trExc2" runat="server">
                                            <td style="width: 150px; height: 43px;">
                                                <asp:Label ID="Label74" runat="server" Text="Exc. de Cap."></asp:Label>
                                            </td>
                                            <td style="width: 3px; height: 43px;">
                                                <asp:Label ID="Label75" runat="server" Text=":"></asp:Label>
                                            </td>
                                            <td style="width: 3px; height: 43px;">
                                                <asp:Label ID="Label76" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td style="width: 65px; height: 43px;" class="AlineacionDerecha">
                                                <asp:Label ID="lblExcCapSaldo2" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td style="width: 65px; height: 43px;" class="AlineacionDerecha">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtExcCap2"
                                                    ErrorMessage="Este dato no debe estar vacio." ValidationGroup="ValidacionPaso4">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtCtaCap2"
                                                    ErrorMessage="Debe ingresar solo n&#250;meros" ValidationExpression="^(?:\+|-)?\d+$"
                                                    ValidationGroup="ValidacionPaso4">*</asp:RegularExpressionValidator>
                                                <%--<asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtExcCap2"
                                                    ErrorMessage="El valor ingresado es muy alto." ValidationGroup="ValidacionPaso4" MaximumValue="2147481494" MinimumValue="0">*</asp:RangeValidator>--%>
                                                <asp:TextBox ID="txtExcCap2" runat="server" Width="50px" CssClass="txtNumerico"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionDerecha" colspan="4">
                                                <asp:Label ID="Label80" runat="server" Text="Adm. Cta. Cap. VYT ("></asp:Label>
                                                <asp:Label ID="lblPorcAdmin2" runat="server" Text="0"></asp:Label>
                                                <asp:Label ID="Label86" runat="server" Text="%):"></asp:Label>
                                                <asp:Label ID="Label81" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td style="width: 65px" class="AlineacionDerecha">
                                                <asp:TextBox ID="txtAdminCtaCapVyT" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionDerecha" colspan="4">
                                                <asp:Label ID="Label87" runat="server" Text="Aporte requerido: "></asp:Label>
                                                <asp:Label ID="Label88" runat="server" Text="$"></asp:Label>
                                            </td>
                                            <td style="width: 65px" class="AlineacionDerecha">
                                                <asp:TextBox ID="txtAporteReq2" runat="server" Width="50px" CssClass="txtNumerico" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                        <br />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="List"
                                            ValidationGroup="ValidacionPaso4" />
                                    </td>
                                    <td style="width: 280px;" valign="top">
                                        <table cellpadding="0" cellspacing="0" class="Grid" width="270">
                                            <tr>
                                                <th style="width: 270px">
                                                    <asp:Label ID="Label79" runat="server" Text="Solicitar reparto"></asp:Label>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="width: 270px">
                                                    <asp:Label ID="Label82" runat="server" Text="Rut empresa :"></asp:Label>
                                                    <asp:TextBox ID="txtEmpBenefactora" runat="server" Width="70px" MaxLength="13"></asp:TextBox>
                                                    <asp:Button ID="Button2" runat="server" Height="1px" Width="1px" CssClass="invisible"  />
                                                    <asp:CustomValidator ID="CustomValidator1xx" runat="server" ClientValidationFunction="VerificarRut"
                                                        ControlToValidate="txtEmpBenefactora" ErrorMessage="Debe ingresar un Rut. valido."
                                                        ValidationGroup="ValidaRutTercero">*</asp:CustomValidator>
                                                    <asp:Button ID="btnPopUpTerceros" runat="server" Text="..." />
                                                    &nbsp;<asp:Button ID="btnAgregarEmpReparto" runat="server" Text="Agregar" ValidationGroup="ValidaRutTercero" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 270px">
                                                    <asp:GridView ID="grdReparto" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="270px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Elim.">
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkEliminarReparto" runat="server" />
                                                                    <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# Bind("cod_curso") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Empresa">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmpBenef" runat="server" Text='<%# Bind("rut_benefactor") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                                <FooterStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Monto">
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtMonto" runat="server" Width="50px" CssClass="txtNumerico" Text='<%# bind("monto") %>'></asp:TextBox>
                                                                </ItemTemplate>
                                                                <FooterStyle CssClass="AlineacionDerecha" />
                                                                <ItemStyle CssClass="AlineacionDerecha" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <table cellpadding="0" cellspacing="0" class="Grid" width="270">
                                                        <tr style="font-weight: bold;">
                                                            <td class="AlineacionDerecha" style="width: 185px">
                                                                    <asp:Label ID="Label83" runat="server" Text="Total :"></asp:Label>
                                                            </td>
                                                            <td class="AlineacionDerecha" style="width: 85px">
                                                                    <asp:Label ID="lblTotalReparto" runat="server" Text="0"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp; &nbsp;&nbsp; &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfAdmNoLinial" runat="server" />
                                                    <asp:Button ID="btnActualizarRepartos" runat="server" Text="Actualizar lista y recalcular " />
                                    </td>
                                </tr>
                            </table>
                        </asp:WizardStep>
                    </WizardSteps>
                    <NavigationStyle CssClass="navigation"  />
                    <SideBarButtonStyle CssClass="sideBarButtom"  />
                    <NavigationButtonStyle CssClass="NavigationButtom"  />
                    <SideBarStyle CssClass="sideBar"  />
                    <StepStyle CssClass="Steps"  />
                    <StartNavigationTemplate>
                        <asp:Button ID="StartNextButton" runat="server" CssClass="NavigationButtom"
                            Text="Siguiente" ValidationGroup="ValidacionPaso1" OnClick="StartNextButton_Click" />
                    </StartNavigationTemplate>
                    <StepNavigationTemplate>
                        <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                            CssClass="NavigationButtom" Text="Anterior" />
                        <asp:Button ID="StepNextButton" runat="server" CssClass="NavigationButtom"
                            OnClick="StepNextButton_Click" Text="Siguiente" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de enviar la información ingresada.\n¿Desea continuar?');" />
                    </StepNavigationTemplate>
                    <FinishNavigationTemplate>
                        <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                            CssClass="NavigationButtom" Text="Anterior" />
                        <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" CssClass="NavigationButtom"
                            OnClick="FinishButton_Click" Text="Finalizar" ValidationGroup="ValidacionPaso4" OnClientClick="return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de enviar la información ingresada.\n¿Desea continuar?');" />
                    </FinishNavigationTemplate>
                </asp:Wizard>
            </div>
        </div>
        <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text=""></asp:Label>
        </div>
    </div>
        <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
        <asp:HiddenField ID="hdfValorHora" runat="server" />
        <asp:HiddenField ID="hdfHoras" runat="server" />
        <asp:HiddenField ID="hdfMAxParticipantes" runat="server" />
        <asp:HiddenField ID="hdfValorCursoSence" runat="server" />
        <asp:HiddenField ID="hdfCodCursoParcial" runat="server" />
    </div>    
    </form>
</body>
</html>
