<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ingreso_aporte.aspx.vb" Inherits="modulo_aporte_ingreso_aporte" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nuevo aporte</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script> 
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>
    <script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" ></script>
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
                    <asp:HyperLink ID="hplResumenCobranza" runat="server" NavigateUrl="resumen_cobranza.aspx"><b>Resumen de cobranza</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Reporte aportes</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplBuscadorAportes" runat="server" NavigateUrl="Reporte_buscar_aportes.aspx"><b>Buscador Aportes</b></asp:HyperLink>
                </li>
               <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="Listado_Facturas.aspx"><b>Listado facturas</b></asp:HyperLink>
                </li>
                 <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplNuevoAporte" runat="server" NavigateUrl="ingreso_aporte.aspx"><b>Nuevo aporte</b></asp:HyperLink>
                </li>
                <%--<li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
                </li>--%>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
                </ul>
            </div>   
        </div>
        <%--<div id="Cabecera">
            <div id="DatosUsuario">
                <uc2:cabecera1 ID="Cabecera1" runat="server" />
            </div>
            <div id="filtros">
                <asp:Label ID="lblAgno" runat="server" Text="Año :"></asp:Label>
                <asp:DropDownList ID="ddlAgnos" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>--%>
        <div id="contenido">
            <div id="DatosAporte">
                <div id="empresa">
                    <h3>
                        <asp:Label ID="Label8" runat="server" Text="EMPRESA"></asp:Label>
                    </h3>
                    <asp:Label ID="lblRut" runat="server" Text="RUT" CssClass="MargenIzq"></asp:Label>
                    <asp:Label ID="lblDosPuntos1" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtRut" runat="server" MaxLength="12"></asp:TextBox><asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtRut"
                        ErrorMessage="Debe ingresar un rut válido" Text="*" ValidationGroup="xx" ClientValidationFunction="VerificarRut"></asp:CustomValidator><asp:Button ID="btnBuscar" runat="server" Text="..." />
                    <asp:Button ID="btnCargar" runat="server" Text="Cargar" ValidationGroup="xx" />
                    <asp:Label ID="lblAgno" runat="server" Text="año"></asp:Label>
                    <asp:Label ID="lblDosPuntos2" runat="server" Text=":"></asp:Label>
                    <asp:DropDownList ID="ddlAgno" runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Nombre" CssClass="MargenIzq"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Text=":"></asp:Label>
                    <asp:Label ID="lblNombre" runat="server" Text="0"></asp:Label>              
                    <h4>
                        <asp:Label ID="Label6" runat="server" Text="Saldos actuales"></asp:Label>
                    </h4>                
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Cta. capacitación" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Text=":"></asp:Label>
                    <asp:Label ID="lblSaldoCtaCap" runat="server" Text="0"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Cta. reparto" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label11" runat="server" Text=":"></asp:Label>
                    <asp:Label ID="lblSaldoCtaRep" runat="server" Text="0"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Cta. certificación de competencias laborales" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text=":"></asp:Label>
                    <asp:Label ID="lblSaldoCtaCCL" runat="server" Text="0"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Cta. becas" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label12" runat="server" Text=":"></asp:Label>
                    <asp:Label ID="lblSaldoCtaBecas" runat="server" Text="0"></asp:Label>
                    <br />
                    <br />                    
                    <asp:Label ID="Label38" runat="server" Text="Observaciones" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label39" runat="server" Text=":"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtObservaciones" runat="server" Rows="5" TextMode="MultiLine" Width="300px" CssClass="MargenIzq2"></asp:TextBox>
                    <br />
                </div>
                <div id="aportes">
                    <h3>
                        <asp:Label ID="Label13" runat="server" Text="APORTE"></asp:Label>
                    </h3>
                    <asp:Label ID="Label15" runat="server" Text="Nº Aporte" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label16" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtNumAporte" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtNumAporte"
                        ErrorMessage="Debe ingresar solo números" ValidationExpression="^(?:\+|-)?\d+$"
                        ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator><br />
                    <asp:Label ID="Label18" runat="server" Text="Total aporte" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label19" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtTotalAporte" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTotalAporte"
                        ErrorMessage="Debe ingresar solo números" ValidationExpression="^(?:\+|-)?\d+$"
                        ValidationGroup="ValidacionPaso1">*</asp:RegularExpressionValidator><br />                
                    <asp:Label ID="Label21" runat="server" Text="Cta. a abonar" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label22" runat="server" Text=":"></asp:Label>
                    <asp:DropDownList ID="ddlCuentasAporte" runat="server"></asp:DropDownList>
                    <br />
                    <div id="boton">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" />
                    </div>
                    <asp:Label ID="Label17" runat="server" Text="Aporte neto" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label20" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtAporteNeto" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="Administración" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label24" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtAdministracion" runat="server"></asp:TextBox>                
                    <asp:Label ID="lblCostoAdm" runat="server"></asp:Label>
                    <asp:HiddenField ID="hdfAdmNoLineal" runat="server" />
                    <asp:HiddenField ID="hdfCostoAdmin" runat="server" />
                    <br />    
                    <asp:Label ID="Label26" runat="server" Text="Fecha contable de ingreso" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label27" runat="server" Text=":"></asp:Label>&nbsp;<ew:calendarpopup
                        id="calFechaIngreso" runat="server" cleardatetext="Limpiar fecha" controldisplay="TextBoxImage"
                        cssclass="Calendar" culture="Spanish (Argentina)" disabletextboxentry="False"
                        displayprevnextyearselection="True" gototodaytext="Ir al día de hoy" imageurl="~/Contenido/Imagenes/calendario.jpg"
                        nullable="True" padsingledigits="True" popuplocation="Left" posteddate="" selecteddate=""
                        showcleardate="True" showgototoday="True" visibledate=""> <TEXTBOXLABELSTYLE Width="65px" /></ew:calendarpopup>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="esFechaValida"
                        ControlToValidate="calFechaIngreso" ErrorMessage="La fecha ingresada no es valida"
                        Text="*" ValidationGroup="xx"></asp:CustomValidator><br />    
                </div>
                <div id="documentos">
                    <h3>
                        <asp:Label ID="Label14" runat="server" Text="DOCUMENTOS"></asp:Label>
                    </h3>
                    <asp:Label ID="Label28" runat="server" Text="Tipo de documento" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label29" runat="server" Text=":"></asp:Label>
                    <asp:DropDownList ID="ddlTipoDocs" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <br />
                    <asp:Label ID="Label30" runat="server" Text="Nº Dcto / Banco" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label31" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtNumDocto" runat="server" Width="50px"></asp:TextBox>
                    <asp:TextBox ID="txtBanco" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label32" runat="server" Text="Fecha vencimiento" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label33" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtFechaVenc" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="esFechaValida"
                        ControlToValidate="txtFechaVenc" ErrorMessage="La fecha ingresada no es valida"
                        Text="*" ValidationGroup="xx"></asp:CustomValidator><br />
                    <asp:Label ID="Label36" runat="server" Text="Fecha cobro" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label37" runat="server" Text=":"></asp:Label>
                    <asp:TextBox ID="txtFechaCobro" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="esFechaValida"
                        ControlToValidate="txtFechaCobro" ErrorMessage="La fecha ingresada no es valida"
                        Text="*" ValidationGroup="xx"></asp:CustomValidator><br />
                    <asp:Label ID="Label34" runat="server" Text="Estado actual" CssClass="titCuenta"></asp:Label>
                    <asp:Label ID="Label35" runat="server" Text=":"></asp:Label>
                    <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
                    
                </div>
            </div>
            <div id="ingresar">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" ValidationGroup="xx" />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="margenAdvertencia"
                    ValidationGroup="xx" Width="152px" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdfEnvioDatos" runat="server" Value="0" />
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
