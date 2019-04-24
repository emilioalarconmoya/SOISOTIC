<%@ Page Language="VB" AutoEventWireup="false" CodeFile="asignacion_excedentes.aspx.vb" Inherits="modulo_administracion_asignacion_excedentes" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Excedentes</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
<script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
<form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile" width="980"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
     <div id="menu">
         <div id="header">
             <ul>
                <li >
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx"><b>Menú Administración</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
         </div>
    </div>
        <table style="width: 980px" class="tabla">
        <tr>
                        <th class="AlineacionIzquierda">
                            <asp:Label ID="Label1" runat="server" Text="Criterio de busqueda"></asp:Label></th>
                    </tr>
            <tr>
                <td align="center" colspan="3" style="width: 100%; height: 20px" valign="top">
                    &nbsp; &nbsp;
                    <asp:Label ID="lblNombreAtributo" runat="server" Text="Rut Empresa :" meta:resourcekey="lblNombreAtributoResource1"></asp:Label>&nbsp;
                    <asp:TextBox ID="txtRutEmpresa" runat="server" Width="80px" MaxLength="60" ValidationGroup="xx" meta:resourcekey="txtNombreAtributoResource1"></asp:TextBox>
                    &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                        ControlToValidate="txtRutEmpresa" ErrorMessage="¡Ingrese un rut válido!" ValidationGroup="xx">*</asp:CustomValidator>
                    <asp:Button ID="btn_buscar_empresa" runat="server" Text="..." />
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Nombre :"></asp:Label>
                    <asp:TextBox ID="txtNomEmpresa" runat="server"></asp:TextBox>
                    &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="Ejecutivo :"></asp:Label>
                    <asp:DropDownList ID="ddlEjecutivo" runat="server">
                    </asp:DropDownList>
                    &nbsp; &nbsp;<asp:Label ID="Label4" runat="server" Text="Sucursal :"></asp:Label>
                    <asp:DropDownList ID="ddlSucursal" runat="server">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Año :"></asp:Label>
                    <asp:DropDownList ID="ddlAgno" runat="server">
                    </asp:DropDownList><br />
                    &nbsp;<asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" />&nbsp;
                    <br />
                    <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink><br />
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" meta:resourcekey="btnConsultarResource1" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" /><br />
                    <asp:Button ID="btnMofidicarTodos" runat="server" Text="Modificar todo" />&nbsp;<asp:Button
                        ID="btnTraspasarTodos" runat="server" Text="Traspasar todo" /><br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ValidationGroup="xx" meta:resourcekey="ValidationSummary1Resource1" />
                    </td>
            </tr>
            <tr>
                <td align="left" colspan="" style="width: 100%; height: 375px" valign="top" rowspan="">
                    &nbsp;<asp:Label ID="Label11" runat="server" Text="* Si desea agregar Becas por Mandato, debe hacerlo desde el traspaso de fondos, esto puede hacerlo desde "></asp:Label>
                    <asp:LinkButton ID="lnkTraspasoFondos" runat="server">aca.</asp:LinkButton>
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CssClass="Grid" EmptyDataText="Sin datos para el ciclo seleccionado"
                        Height="0px" OnRowDataBound="grdResultados_RowDataBound" Width="100%">
                        <RowStyle Height="0px" />
                        <EmptyDataRowStyle Height="0px" />
                        <Columns>
                            <asp:TemplateField HeaderText="empresa">
                                <ItemTemplate><table cellpadding="0" cellspacing="0" class="TablaInterior">
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px; height: 18px">
                                                <asp:HyperLink ID="hplRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px; height: 20px">
                                                <asp:Label ID="lblRutEmpresa" runat="server" Text='<%# bind("rut_cliente") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px">
                                                <asp:Label ID="lblEjecutivo" runat="server" Text='<%# bind("ejecutivo") %>' Width="208px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="AlineacionIzquierda" style="width: 48px">
                                                <asp:Label ID="lblSucursal" runat="server" Text='<%# bind("sucursal") %>'></asp:Label></td>
                                    </tr>
                                </table>
                                </ItemTemplate>
                                <ItemStyle Height="0px" VerticalAlign="Top" Width="50px" />
                                <HeaderStyle Width="40%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="saldo cuentas">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 48px; height: 18px">
                                                <asp:Label ID="Label5" runat="server" Text="Cta. Capacitación" Width="80px"></asp:Label></td>
                                            <td class="DosPuntos" style="width: 11px; height: 18px">
                                                :</td>
                                            <td class="AlineacionIzquierda">
                                                <asp:Label ID="lblSaldoCap" runat="server" Text='<%# bind("SaldoCap") %>'></asp:Label></td>
                                            <td class="AlineacionIzquierda">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 48px; height: 20px">
                                                <asp:Label ID="Label6" runat="server" Text="Cta. Reparto" Width="64px"></asp:Label></td>
                                            <td class="DosPuntos" style="width: 11px; height: 20px">
                                                :</td>
                                            <td class="AlineacionIzquierda">
                                                <asp:Label ID="lblSaldoRep" runat="server" Text='<%# bind("SaldoRep") %>'></asp:Label></td>
                                            <td class="AlineacionIzquierda">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 48px">
                                                <asp:Label ID="Label7" runat="server" Text="Cta. Administración" Width="96px"></asp:Label></td>
                                            <td class="DosPuntos" style="width: 11px">
                                                :</td>
                                            <td class="AlineacionIzquierda">
                                                <asp:Label ID="lblSaldoAdm" runat="server" Text='<%# bind("SaldoAdm") %>'></asp:Label></td>
                                            <td class="AlineacionIzquierda">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 48px; height: 18px;">
                                                <asp:Label ID="Label16" runat="server" Text="Exc (cap + rep) compl." Width="104px"></asp:Label></td>
                                            <td class="DosPuntos" style="width: 11px; height: 18px;">
                                                :</td>
                                            <td class="AlineacionIzquierda" style="height: 18px">
                                                <asp:Label ID="lblExcCompl" runat="server" Text='<%# bind("MontoTraspasable") %>'></asp:Label></td>
                                            <td class="AlineacionIzquierda" style="height: 18px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 48px">
                                                <asp:Label ID="Label15" runat="server" Text="Exc (cap + rep) becas" Width="104px"></asp:Label></td>
                                            <td class="DosPuntos" style="width: 11px">
                                                :</td>
                                            <td class="AlineacionIzquierda">
                                                <asp:Label ID="lblExcBecas" runat="server" Text='<%# bind("MontoNoTraspasable") %>'></asp:Label></td>
                                            <td class="AlineacionIzquierda">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 48px">
                                                <asp:Label ID="Label14" runat="server" Text="Total"></asp:Label></td>
                                            <td class="DosPuntos" style="width: 11px">
                                                :</td>
                                            <td class="AlineacionIzquierda" style="width: 304px">
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# bind("TotalAsignar") %>'></asp:Label></td>
                                            <td class="AlineacionIzquierda">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 48px; height: 24px;">
                                            </td>
                                            <td class="DosPuntos" style="width: 11px; height: 24px;">
                                            </td>
                                            <td class="AlineacionIzquierda" style="width: 304px; height: 24px;">
                                            </td>
                                            <td class="AlineacionIzquierda" style="height: 24px">
                                                <asp:Button ID="btnTraspasar" runat="server" OnClick="btnTraspasar_Click" Text="Traspasar Total >>" /></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Height="0px" VerticalAlign="Top" Width="380px" />
                                <HeaderStyle Width="30%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="asignar a :">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 134px">
                                                <asp:Label ID="Label8" runat="server" Text="Excedente Capacitación" Width="112px"></asp:Label></td>
                                            <td class="DosPuntos">
                                                :</td>
                                            <td class="AlineacionIzquierda" style="width: 70px">
                                                <asp:TextBox ID="txtExcCap" runat="server" Width="72px" Text='<%# bind("AbonoExCap") %>'></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 134px">
                                                <asp:Label ID="Label9" runat="server" Text="Excedente Reparto" Width="96px"></asp:Label></td>
                                            <td class="DosPuntos">
                                                :</td>
                                            <td class="AlineacionIzquierda" style="width: 70px">
                                                <asp:TextBox ID="txtExcRep" runat="server" Width="72px" Text='<%# bind("SaldoExRep") %>'></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 134px;">
                                                <asp:Label ID="Label10" runat="server" Text="Administración  ("></asp:Label><asp:Label
                                                    ID="lblPorcAdmin" runat="server" Text='<%# bind("PorcAdm") %>'></asp:Label><asp:Label
                                                        ID="Label17" runat="server" Text="%)"></asp:Label></td>
                                            <td class="DosPuntos" style="height: 18px">
                                                :</td>
                                            <td class="AlineacionIzquierda" style="width: 70px; height: 18px;">
                                                <asp:TextBox ID="txtAdmin" runat="server" Width="72px" Text='<%# bind("AbonoAdm") %>'></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 134px">
                                                <asp:Label ID="Label21" runat="server" Text="Becas"></asp:Label></td>
                                            <td class="DosPuntos" style="height: 18px">
                                                :</td>
                                            <td class="AlineacionIzquierda" style="width: 70px; height: 18px">
                                                <asp:TextBox ID="txtBecas" runat="server" Width="72px" Text='<%# bind("AbonoBeca") %>'></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="AlineacionIzquierda" style="width: 134px">
                                                <asp:Label ID="Label22" runat="server" Text="Saldo por asigna"></asp:Label></td>
                                            <td class="DosPuntos" style="height: 18px">
                                                :</td>
                                            <td class="AlineacionIzquierda" style="width: 70px; height: 18px">
                                                <asp:TextBox ID="txtSaldoAsignar" runat="server" Width="72px" Text='<%# bind("SaldoPorAsignar") %>'></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle Height="0px" VerticalAlign="Top" Width="110px" />
                                <HeaderStyle Width="30%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acci&#243;n">
                                <ItemTemplate>
                                    &nbsp;<asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle Height="0px" />
                        <SelectedRowStyle Height="0px" />
                    </asp:GridView>
                    - En este listado sólo aparecen los clientes que tienen saldo mayor o igual que
                    cero en sus cuentas de Capacitación, Reparto y Administración. &nbsp; &nbsp; &nbsp;<br />
                    - Exc trasp: corresponden a los excedentes que pueden utilizarse para pagar sólo
                    cursos complementarios.
                    <br />
                    - Exc becas: corresponden a los excedentes que no pueden utilizarse para pagar cursos,
                    y deben ser asignados a Becas.</td>
            </tr>
            
        </table>    
    </div>   
               
        <div id="pie">
            <div class="textoPie" >
                &nbsp;<asp:Label ID="lblPie" runat="server" Text=""></asp:Label></div>
           </div>
    </form>    

</body>
</html>
