<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_sucursales.aspx.vb" Inherits="modulo_administracion_mantenedor_sucursales" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sucursales</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
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
                 <li >
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx"><b>Menú Administración</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
         </div>
    </div>
    <div id="PestañasMantenedor">
            <ul>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_sucursales.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="mantenedor_sucursales_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div> 
    <%--<table style="width: 400px; border-color:#000000;" align="center">
            <tr>
                <td style="width: 200px" class="pestana_up">
                        <asp:Label ID="lblDatos" runat="server" meta:resourcekey="lblDatosResource1" Text="Datos"
                            Width="160px"></asp:Label></td>
                <td style="width: 200px" class="pestana_down">
                    <asp:HyperLink ID="hplMantenedor" runat="server" meta:resourcekey="hplMantenedorResource1"
                        NavigateUrl="~/modulo_administracion/mantenedor_sucursales_m.aspx" Width="160px">Mantenedor</asp:HyperLink></td>
            </tr>
        </table>--%>
        <table style="width: 980px" class="tabla">
        <tr>
                        <th class="AlineacionIzquierda" colspan="6">
                            <asp:Label ID="Label1" runat="server" Text="Criterio de busqueda"></asp:Label></th>
                    </tr>
            <tr>
                <td align="center" colspan="3" style="width: 100%; height: 20px" valign="top">
                    &nbsp; &nbsp;
                    <asp:Label ID="lblNombreAtributo" runat="server" Text="Nombre de la sucursal" Width="116px" meta:resourcekey="lblNombreAtributoResource1"></asp:Label>&nbsp;
                    <asp:TextBox ID="txtNombreSucursal" runat="server" Width="210px" MaxLength="60" ValidationGroup="Consultar" meta:resourcekey="txtNombreAtributoResource1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNombreSucursal"
                        ErrorMessage="solo se permiten letras" Height="1px" ValidationExpression="\D*"
                        Width="1px" ValidationGroup="Consultar" meta:resourcekey="RegularExpressionValidator1Resource1" EnableClientScript="False">*</asp:RegularExpressionValidator>&nbsp;
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="Consultar" meta:resourcekey="btnConsultarResource1" />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ValidationGroup="Consultar" meta:resourcekey="ValidationSummary1Resource1" />
                    <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" />&nbsp;
                    <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink></td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="width: 100%; height: 375px" valign="top">
                    <asp:GridView ID="grdSucursal" runat="server" AutoGenerateColumns="False"
                        Width="953px" CssClass="Grid" meta:resourcekey="grdAtributosResource1">
                        <Columns>
                            <asp:TemplateField HeaderText="C&#243;digo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCodSucursal" runat="server" Text='<%# bind("cod_sucursal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sucursal">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNomSucursal" runat="server" Text='<%# bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditar" runat="server" CausesValidation="false" CommandName="Editar"
                                        OnClick="btnEditar_Click" Text="Editar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEliminar" runat="server" meta:resourcekey="chkEliminarResource1" Visible="False" />
                                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" /><br />
                                    <%--<asp:HiddenField ID="hdfCodCaracteristica" runat="server" Value='<%# bind("cod_caracteristica") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar sucursal" meta:resourcekey="btnAgregarResource1" />&nbsp;
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" /><br />
                    <asp:HiddenField ID="hdfAlertSeleccionarAtributo" runat="server" meta:resourcekey="hdfAlertSeleccionarAtributoResource1" Value="¡Debe seleccionar una sucursal para poder eliminar!" />
                    <asp:HiddenField ID="hdfConfirmarEliminar" runat="server" meta:resourcekey="hdfConfirmarEliminarResource1" Value="¿Está seguro de realizar esta acción?" />
                    <asp:HiddenField ID="hdfMenuCabecera" runat="server" meta:resourcekey="hdfMenuCabeceraResource1" Value="Mantenedor de Atributos" />
                    <asp:HiddenField ID="hdfEliminarExito" runat="server" meta:resourcekey="hdfEliminarExitoResource1" Value="¡Los datos fueron eliminados exitosamente!" />
                </td>
            </tr>
            
        </table>    
    </div>   
               
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
           </div>
    </form>    

</body>
</html>
