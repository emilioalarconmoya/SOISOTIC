<%@ Page Language="VB" AutoEventWireup="false" CodeFile="resumen_cobranza.aspx.vb" Inherits="modulo_aporte_resumen_cobranza" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="../contenido/ascx/cabecera.ascx" TagName="cabecera1" TagPrefix="uc2" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Resumen de cobranza</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />    
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script> 
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script> 
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="BtnConsultar">
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
                <li class="pestanaconsolaseleccionada">
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
                 <li>
                    <asp:HyperLink ID="hplNuevoAporte" runat="server" NavigateUrl="ingreso_aporte.aspx"><b>Nuevo aporte</b></asp:HyperLink>
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
            <tr>
                <td class="AlineacionIzquierda" style="width: 70px; height: 26px">
                    <asp:Label ID="Label2" runat="server" Text="Rut Cliente:"></asp:Label></td>
                <td class="AlineacionIzquierda" style="height: 26px">
                    <asp:TextBox ID="txtRutCliente" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                        ControlToValidate="TxtRutCliente" ErrorMessage="Debe ingresar un rut válido"
                        ValidationGroup="xx">*</asp:CustomValidator>
                    <asp:Button ID="btnPopUpEmpresa" runat="server" Text="..." /></td>
                <td class="AlineacionIzquierda" style="width: 70px; height: 26px">
                    <asp:Label ID="Label3" runat="server" Text="Nombre Cliente:" Width="72px"></asp:Label></td>
                <td class="AlineacionIzquierda" style="height: 26px">
                    &nbsp;<asp:TextBox ID="TxtNombreCliente" runat="server"></asp:TextBox></td>
                <td class="AlineacionIzquierda" style="width: 60px; height: 26px">
                        <asp:Label ID="lblFechaInicial" runat="server" Text="Desde :"></asp:Label></td>
                <td class="AlineacionIzquierda" style="height: 26px">
                        <ew:CalendarPopup ID="calFechaInicial" runat="server" ClearDateText="Limpiar fecha"
                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)"
                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" 
                        Nullable="True" PadSingleDigits="True" PostedDate=""
                        SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                            <TextBoxLabelStyle Width="65px" />
                        </ew:CalendarPopup>
                </td>
                <td class="AlineacionIzquierda" style="width: 60px; height: 26px">
                    &nbsp;
                        <asp:Label ID="lblFechaFinal" runat="server" Text="Hasta :"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="3" style="height: 26px">
                    &nbsp;<ew:CalendarPopup ID="calFechaFinal" runat="server" ClearDateText="Limpiar fecha"
                        ControlDisplay="TextBoxImage" CssClass="Calendar" Culture="Spanish (Argentina)" 
                        DisableTextBoxEntry="False" DisplayPrevNextYearSelection="True" GoToTodayText="Ir al día de hoy"
                        ImageUrl="~/Contenido/Imagenes/calendario.jpg" 
                        Nullable="True" PadSingleDigits="True" PostedDate=""
                        SelectedDate="" ShowClearDate="True" ShowGoToToday="True" VisibleDate="" PopupLocation="Left">
                            <TextBoxLabelStyle Width="65px" />
                        </ew:CalendarPopup></td>
            </tr>
        </table>
       <div class="AlineacionCentro">
           <asp:Button ID="BtnConsultar" runat="server" Text="Consultar" ValidationGroup="xx"  />
           <br />
           <asp:CheckBox ID="ChkBajar" runat="server" Text="Bajar reporte" /><br />
           <asp:HyperLink ID="HplkBajarArchivo" runat="server" meta:resourcekey="hlkBajarResource1"
               Visible="False">[HplkBajarArchivo]</asp:HyperLink><br />
           <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="margenAdvertencia"
               ValidationGroup="xx" Width="152px" />
       </div>
       
    <div id="contenido"> 
    <div id="resultados">
     <table id="tablaHeader">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Resumen de Cobranza"></asp:Label></th>                            
                        </tr>
        </table>
        <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" Width="976px" CssClass="Grid">
            <Columns>
                <asp:TemplateField HeaderText="Datos Empresa">
                    <ItemTemplate>
                        <div class="AlineacionIzquierda">
                            <asp:Label ID="lblNombreClien" runat="server" Text='<%# bind("razon_social") %>'></asp:Label>&nbsp;<br />
                                    <asp:Label ID="rut" runat="server" Text="Rut:"></asp:Label>
                            <asp:Label ID="LblRutClien" runat="server" Text='<%# bind("rut_cliente") %>'></asp:Label><br />
                                    <asp:Label ID="con" runat="server" Text="Contacto:"></asp:Label>
                            <asp:Label ID="LblContacto" runat="server" Text='<%# bind("nom_contacto") %>'></asp:Label><br />
                                    <asp:Label ID="fon" runat="server" Text="Fono:"></asp:Label>
                            <asp:Label ID="LblFono" runat="server" Text='<%# bind("fono_contacto") %>'></asp:Label><br />
                                    <asp:Label ID="eje" runat="server" Text="Ejecutivo:"></asp:Label>
                            <asp:Label ID="LblEjecutivo" runat="server" Text='<%# bind("Nom_ejecutivo") %>'></asp:Label><br />
                                    <asp:Label ID="suc" runat="server" Text="Sucursal:"></asp:Label>
                            <asp:Label ID="LblSucursal" runat="server" Text='<%# bind("Sucursal") %>'></asp:Label><br />
                                    <asp:Label ID="Label16" runat="server" Text="Adm.:"></asp:Label>
                            <asp:Label ID="LblAdm" runat="server" Text='<%# bind("costo_admin") %>'></asp:Label>
                            <asp:Label ID="Label18" runat="server" Text="%"></asp:Label></div>
                    </ItemTemplate>
                    <HeaderStyle VerticalAlign="Top" Width="20%" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cta.Cap.">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda">
                            <asp:Label ID="ab" runat="server" Text="Abonos:"></asp:Label></td>
                                <td style="width: 2px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                            <asp:Label ID="LblAbonoCtaCap" runat="server" Text='<%# bind("AbonoCap") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="ca" runat="server" Text="Cargos:"></asp:Label></td>
                                <td style="width: 2px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                            <asp:Label ID="LblCargosCtaCap" runat="server" Text='<%# bind("CargoCap") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="Label4" runat="server" Text="Cargos vyt:"></asp:Label></td>
                                <td style="width: 2px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                            <asp:Label ID="lblCargoCtaCapVyT" runat="server" Text='<%# bind("CargoCapVyT") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="sa" runat="server" Text="Saldo:"></asp:Label></td>
                                <td style="width: 2px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblSaldoCtaCap" runat="server" Text='<%# bind("SaldoCap") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle VerticalAlign="Top" Width="14%" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cta.Reparto">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="abon" runat="server" Text="Abonos:"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblAbonoCuenRep" runat="server" Text='<%# bind("AbonoRep") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="car" runat="server" Text="Cargos:"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblCargosCuenRep" runat="server" Text='<%# bind("CargoRep") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="sald" runat="server" Text="Saldo"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblSaldoCuenRep" runat="server" Text='<%# bind("SaldoRep") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle VerticalAlign="Top" Width="14%" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cta.Adm.">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="abono" runat="server" Text="Abonos:"></asp:Label>
                                </td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha"  style="width: 106px">
                                    <asp:Label ID="LblAbonoCuenAdm" runat="server" Text='<%# bind("AbonoAdm") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="carg" runat="server" Text="Cargos:"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha"  style="width: 106px">
                                    <asp:Label ID="LblCargosCuenAdm" runat="server" Text='<%# bind("CargoAdm") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="saldo" runat="server" Text="Saldo"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha"  style="width: 106px">
                                    <asp:Label ID="LblSaldoCuenAdm" runat="server" Text='<%# bind("SaldoAdm") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                </td>
                                <td>
                                </td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                </td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="de" runat="server" Text="Deuda:"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 97px">
                            <asp:Label ID="LblDeudaCuenAdm" runat="server" Text='<%# bind("Deuda") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle VerticalAlign="Top" Width="14%" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cta.Ex.Cap">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="abono1" runat="server" Text="Abonos:"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblAbonoCuenExCap" runat="server" Text='<%# bind("AbonoExCap") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="cargo1" runat="server" Text="Cargos:"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblCargosCuenExCap" runat="server" Text='<%# bind("CargoExCap") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="Label6" runat="server" Text="Cargos vyt:"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="lblCargoExcCapVyT" runat="server" Text='<%# bind("CargoExCapVyT") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda">
                                    <asp:Label ID="saldo1" runat="server" Text="Saldo"></asp:Label></td>
                                <td>
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblSaldoCuenExCap" runat="server" Text='<%# bind("SaldoExCap") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle VerticalAlign="Top" Width="14%" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cta.Ex.Reparto">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                    <asp:Label ID="abono2" runat="server" Text="Abonos:"></asp:Label></td>
                                <td style="width: 9px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblAbonoCuenExReparto" runat="server" Text='<%# bind("AbonoExRep") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                    <asp:Label ID="cargos2" runat="server" Text="Cargos:"></asp:Label></td>
                                <td style="width: 9px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblCargosCuenExReparto" runat="server" Text='<%# bind("CargoExRep") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                    <asp:Label ID="saldo2" runat="server" Text="Saldo"></asp:Label></td>
                                <td style="width: 9px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="LblSaldoCuenExReparto" runat="server" Text='<%# bind("SaldoExRep") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                </td>
                                <td style="width: 9px">
                                </td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                </td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                    <asp:Label ID="saldoex" runat="server" Text="Total saldo Ex:" Font-Bold="True" Width="86px"></asp:Label></td>
                                <td style="width: 9px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="lblDeudaCuenExReparto" runat="server" Text='<%# bind("SaldoEx") %>' Font-Bold="True"></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle VerticalAlign="Top" Width="20%" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cta.Becas">
                    <ItemTemplate>
                        <table class="TablaInterior">
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                    <asp:Label ID="abono23" runat="server" Text="Aporte:"></asp:Label></td>
                                <td style="width: 9px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="lblAbonoAporteBeca" runat="server" Text='<%# bind("AbonoAporteBeca") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                    <asp:Label ID="abono33" runat="server" Text="Mand.:"></asp:Label></td>
                                <td style="width: 9px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="lblAbonoMandatoBeca" runat="server" Text='<%# bind("AbonoMandatoBeca") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="AlineacionIzquierda" style="width: 47px">
                                    <asp:Label ID="saldo56" runat="server" Text="Saldo"></asp:Label></td>
                                <td style="width: 9px">
                                    :</td>
                                <td class="AlineacionDerecha" style="width: 106px">
                                    <asp:Label ID="lblSaldoBecas" runat="server" Text='<%# bind("SaldoBeca") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle VerticalAlign="Top" Width="20%" />
                    <ItemStyle VerticalAlign="Top" />
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

