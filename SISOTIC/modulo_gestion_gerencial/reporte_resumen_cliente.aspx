<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reporte_resumen_cliente.aspx.vb" Inherits="modulo_gestion_gerencial_reporte_resumen_cliente" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Resumen cliente</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
     <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
      <%--<script language="javascript"  type="text/javascript" >
        function ConfirmDelete()
        {
        var confirmed = window.confirm("ATENCIÓN: El curso será anulado si el porcentaje de asistencia\nde todos los alumnos es inferior a 75%.\n¿Desea continuar?")
        return(confirmed);
        }
</script>--%>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_cartera.aspx"><b>Cartera</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_agno.aspx"><b>Mov. x año</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_gestion_gerencial/movimiento_x_mes.aspx"><b>Mov x mes</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_anual.aspx"><b>Gestión anual</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulo_gestion_gerencial/gestion_mensual.aspx"><b>Gestión mensual</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulo_gestion_gerencial/estadisticas.aspx"><b>Estadísticas</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_finan_otic.aspx"><b>Financiamiento otic</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_gestion_gerencial/reporte_resumen_cliente.aspx"><b>Estado Cliente</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/modulo_gestion_gerencial/ranking_otec.aspx"><b>Ranking otec</b></asp:HyperLink>
                </li>
                <li >
                    <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="../menu.aspx"><b>Menú</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
         <div id="contenido">           
            <div id="resultados"> <table cellpadding="0" cellspacing="0" class="TablaInterior" id="tablaFiltros2" runat="server" visible="true">
                    <tr>
                        <th width="970px" valign="top" class="Titulo" colspan="1" style="height: 29px">
                            <asp:Label ID="Label17" runat="server" Text="Filtros de búsqueda"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:Label ID="Label21" runat="server" Font-Bold="False" Text="Rut cliente :"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtRutEmpresa" runat="server" MaxLength="12"></asp:TextBox><asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRutEmpresa" ErrorMessage="Debe ingresar un RUT válido"
                                ValidationGroup="ValidaRutAlumno">*</asp:CustomValidator><asp:Button ID="btnPopUpEmpresa" runat="server" Text="..."/>&nbsp;
                            <asp:Label ID="Label9" runat="server" Text="Nombre cliente"></asp:Label>
                            <asp:TextBox ID="txtNomCliente" runat="server"></asp:TextBox>
                            <asp:Label ID="Label22" runat="server" Font-Bold="False" Text="Año :"></asp:Label>
                            <asp:DropDownList ID="ddlAgnos2" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaRutAlumno" />
                <br />
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" Font-Bold="False" ValidationGroup="ValidaRutAlumno" />
                <br />
                <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" /><br />
                <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink></div> 
                <asp:GridView ID="grdResultados" runat="server" width="980px" AutoGenerateColumns="False" CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado" OnRowDataBound="grdResultados_RowDataBound" BorderWidth="0px" Height="1px">
                    <Columns>
                        <asp:TemplateField HeaderText="Datos empresa">
                            <ItemStyle Width="25%" VerticalAlign="Top" CssClass="AlineacionIzquierda" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 100%">
                                    <tr>
                                        <td  class="AlineacionIzquierda">
                                            <asp:Label ID="lblNomCliente" runat="server" Text='<%# bind("razon_social") %>'></asp:Label><br />
                                            <asp:Label ID="Label1"  runat="server" Text="Rut :"></asp:Label>
                                            <asp:Label ID="lblRutCliente"  runat="server" Text='<%# bind("rut_cliente") %>'></asp:Label><br />
                                            <asp:Label ID="Label3"  runat="server" Text="Fono :"></asp:Label>
                                            <asp:Label ID="lblFonoCliente"  runat="server" Text='<%# bind("fono_contacto") %>'></asp:Label><br />
                                            <asp:Label ID="Label15"  runat="server" Text="Ejecutivo :"></asp:Label>
                                            <asp:Label ID="lblEjecutivo" runat="server" Text='<%# bind("Nombres") %>'></asp:Label><br />
                                            <asp:Label ID="Label23"  runat="server" Text="Sucursal :"></asp:Label>
                                            <asp:Label ID="lblSucursal"  runat="server" Text='<%# bind("Nombre") %>'></asp:Label><br />
                                            <asp:Label ID="Label25"  runat="server" Text="Contacto :"></asp:Label>
                                            <asp:Label ID="lblContacto"  runat="server" Text='<%# bind("nom_contacto") %>'></asp:Label><br />
                                       </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Top" Width="25%" />
                            <FooterStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                    <tr>
                                        <td  class="AlineacionIzquierda">
                                            <asp:Label ID="Label2" runat="server" Text="Adm. :"></asp:Label><asp:Label ID="lblPorcAdm"
                                                runat="server"></asp:Label><br />
                                            <asp:Label ID="Label16" runat="server" Text="Cant. :"></asp:Label>
                                            <asp:Label ID="lblCantParticipantes" runat="server" Text='<%# bind("cant_part") %>'></asp:Label><br />
                                            <asp:Label ID="Label26" runat="server" Text="Horas :"></asp:Label>
                                            <asp:Label ID="lblHoras" runat="server" Text='<%# bind("horas") %>'></asp:Label><br />
                                            <asp:Label ID="Label28" runat="server" Text="HH :"></asp:Label>
                                            <asp:Label ID="lblHH" runat="server" Text='<%# bind("hh") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="10%" VerticalAlign="Top" CssClass="AlineacionIzquierda" HorizontalAlign="Left" />
                            <FooterStyle VerticalAlign="Top" Width="10%" />
                            <HeaderStyle VerticalAlign="Top" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Capacitaci&#243;n">
                            <ItemStyle Width="10%" VerticalAlign="Top" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                    <tr>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="Label5" runat="server" Text="Aportes Abonados :" Width="88px"></asp:Label></td>
                                        <td class="DosPuntos">
                                            $</td>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="lblAporteAbonadoCap" runat="server" Text='<%# bind("abono_cap") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="Label6" runat="server" Text="Cargos por Cursos :" Width="88px"></asp:Label></td>
                                        <td class="DosPuntos" >
                                            $</td>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="lblCargaXCursoCap" runat="server" Text='<%# bind("cargo_cap") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="Label777832" runat="server" Text="Saldo :"></asp:Label></td>
                                        <td class="DosPuntos">
                                            $</td>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="lblSaldoCap" runat="server" Text='<%# bind("saldo_cap") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <FooterStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reparto">
                            <ItemStyle Width="10%" VerticalAlign="Top" />
                            <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="Label569" runat="server" Text="Aportes Abonados :" ></asp:Label></td>
                                    <td class="DosPuntos">
                                        $</td>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="lblAporteAbonadoRep" runat="server" Text='<%# bind("abono_rep") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="Label698" runat="server" Text="Cargos por Cursos :" ></asp:Label></td>
                                    <td class="DosPuntos" >
                                        $</td>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="lblCargaXCursoRep" runat="server" Text='<%# bind("cargo_rep") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="Label798" runat="server" Text="Saldo :"></asp:Label></td>
                                    <td class="DosPuntos" >
                                        $</td>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="lblSaldoRep" runat="server" Text='<%# bind("saldo_rep") %>'></asp:Label></td>
                                </tr>
                            </table>
                            </ItemTemplate>
                            <FooterStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Administraci&#243;n">
                            <ItemStyle Width="10%" VerticalAlign="Top" />
                            <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                    </td>
                                    <td class="DosPuntos" >
                                    </td>
                                    <td class="AlineacionIzquierda" >
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="Label6987" runat="server" Text="Ganancias por Adm." ></asp:Label></td>
                                    <td class="DosPuntos" >
                                        $</td>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="lblGananciaXAdm" runat="server" Text='<%# bind("saldo_adm") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                    </td>
                                    <td class="DosPuntos" >
                                    </td>
                                    <td class="AlineacionIzquierda" >
                                    </td>
                                </tr>
                            </table>
                            </ItemTemplate>
                            <FooterStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ex. Capacitacion">
                            <ItemStyle Width="10%" VerticalAlign="Top" />
                            <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                <tr>
                                    <td class="AlineacionIzquierda">
                                    </td>
                                    <td class="DosPuntos" >
                                    </td>
                                    <td class="AlineacionIzquierda" >
                                    </td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="Label632" runat="server" Text="Saldo" ></asp:Label></td>
                                    <td class="DosPuntos">
                                        $</td>
                                    <td class="AlineacionIzquierda" >
                                        <asp:Label ID="lblSaldoExCap" runat="server" Text='<%# bind("saldo_ex_cap") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" >
                                    </td>
                                    <td class="DosPuntos" >
                                    </td>
                                    <td class="AlineacionIzquierda" >
                                    </td>
                                </tr>
                            </table>
                            </ItemTemplate>
                            <FooterStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ex. Reparto">
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" class="TablaInterior" width="100%">
                                    <tr>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="Label4" runat="server" Text="Saldo"></asp:Label></td>
                                        <td class="DosPuntos" >
                                            $</td>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="lblSaldoExRep" runat="server" Text='<%# bind("saldo_ex_rep") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" >
                                        </td>
                                        <td class="DosPuntos" >
                                        </td>
                                        <td class="AlineacionIzquierda" >
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="Label8" runat="server" Text="Saldo Ex." ></asp:Label></td>
                                        <td class="DosPuntos" >
                                            $</td>
                                        <td class="AlineacionIzquierda" >
                                            <asp:Label ID="lblSaldoExExRep" runat="server" Text='<%# bind("saldo_ex") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="10%" VerticalAlign="Top" HorizontalAlign="Left" CssClass="AlineacionIzquierda" />
                            <FooterStyle Width="10%" />
                            <HeaderStyle Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle Height="0px" />
                    <EmptyDataRowStyle Height="0px" />
                    <PagerStyle Height="0px" />
                    <SelectedRowStyle Height="0px" />
                </asp:GridView>
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
