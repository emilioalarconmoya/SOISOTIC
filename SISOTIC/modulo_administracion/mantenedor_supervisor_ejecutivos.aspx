<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_supervisor_ejecutivos.aspx.vb" Inherits="modulo_administracion_mantenedor_supervisor_ejecutivos" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mantenedor supervisor-sucursales</title>
     <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>
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
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_supervisor_ejecutivos.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_supervisor_ejecutivos_m.aspx"><b>Mantenedor</b></asp:HyperLink>
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
       <%-- <table style="width: 980px" class="tabla">--%>
        <tr>
                        <th class="AlineacionIzquierda" colspan="6">
                            </th>
                    </tr>
            <tr>
                <td align="center" colspan="3" style="width: 100%; height: 20px" valign="top">
                    <%--<table style="width: 57%">
                        <tr>
                            <td style="width: 111px">
                                &nbsp;<asp:Label ID="Label2" runat="server" Text="Supervisor"></asp:Label></td>
                            <td align="right" style="width: 25px">
                                <asp:Label ID="Label6" runat="server" Text="Rut :"></asp:Label></td>
                            <td align="left" style="width: 116px">
                                <asp:TextBox ID="txtRutSupervisor" runat="server"></asp:TextBox></td>
                            <td style="width: 46px">
                                <asp:Label ID="Label7" runat="server" Text="Nombre :"></asp:Label></td>
                            <td colspan="2" style="width: 135px">
                                <asp:TextBox ID="txtNomSupervisor" runat="server"></asp:TextBox>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 111px">
                                <asp:Label ID="Label3" runat="server" Text="Ejecutivol"></asp:Label></td>
                            <td align="right" style="width: 25px">
                                <asp:Label ID="Label4" runat="server" Text="Rut :"></asp:Label></td>
                            <td align="left" style="width: 116px">
                                <asp:TextBox ID="txtRutEjecutivo" runat="server"></asp:TextBox></td>
                            <td style="width: 46px">
                                <asp:Label ID="Label5" runat="server" Text="Nombre :"></asp:Label></td>
                            <td colspan="2" style="width: 135px">
                                <asp:TextBox ID="txtNomEjecutivo" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>--%>
                    <div id="filtrosMantenedor" style="width: 99%">
                        <table id="tablaFiltro" cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 96%">
                            <tr>
                                <th colspan="6" style="width: 866px">
                                    <asp:Label ID="Label2" runat="server" Text="Buscador de supervisor y ejecutivo"></asp:Label></th>
                            </tr>
                            <tr>
                                <td colspan="6" style="height: 25px; width: 866px;">
                                    <asp:Label ID="Label3" runat="server" Text="Rut supervisor :"></asp:Label>
                                    <asp:TextBox ID="txtRutSupervisor" runat="server" ValidationGroup="xx"></asp:TextBox>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                        ControlToValidate="txtRutSupervisor" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                                    <asp:Label ID="Label5" runat="server" Text="Nombre supervisor :"></asp:Label>
                                    <asp:TextBox ID="txtNombreSupervisor" runat="server"></asp:TextBox>
                                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                    <asp:Label ID="Label4" runat="server" Text="Rut ejecutivo :"></asp:Label>
                                    <asp:TextBox ID="txtRutEjecutivo" runat="server" ValidationGroup="xx"></asp:TextBox>
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="VerificarRut"
                                        ControlToValidate="txtRutEjecutivo" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label6"
                                        runat="server" Text="Nombre ejecutivo :"></asp:Label><asp:TextBox ID="txtNombreEjecutivo" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" ShowMessageBox="True" />
                        <br />
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="xx" />
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar nuevo" />
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                    </div>
                    <asp:CheckBox ID="chkBajarReporte" runat="server" Text="Bajar reporte" />&nbsp;
                    <br />
                    <asp:HyperLink ID="hplBajarReporte" runat="server" Visible="False">[hplBajarReporte]</asp:HyperLink></td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="width: 100%; height: 375px" valign="top">
                    <asp:GridView ID="grdSucursal" runat="server" AutoGenerateColumns="False"
                        Width="953px" CssClass="Grid" meta:resourcekey="grdAtributosResource1">
                        <Columns>
                            <asp:TemplateField HeaderText="Rut supervisor">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRutSupervisor" runat="server" Text='<%# bind("rut_supervisor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre supervisor">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNomSupervisor" runat="server" Text='<%# bind("nomSuper") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rut Ejecutivo" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblRutEjecutivo" runat="server" Text='<%# bind("rut_ejecutivo") %>'></asp:Label>&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre Ejecutivo">
                                <ItemTemplate>
                                    <asp:Label ID="lblNomEjecutivo" runat="server" Text='<%# bind("nomEjec") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar" meta:resourcekey="TemplateFieldResource1">
                                <ItemTemplate>
                                    &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><%--<asp:HiddenField ID="hdfCodCaracteristica" runat="server" Value='<%# bind("cod_caracteristica") %>' />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    &nbsp; &nbsp;<br />
                    &nbsp; &nbsp;
                </td>
            </tr>
            
       <%-- </table> --%>   
    </div>   
               
        <div id="pie" style="width: 980px">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
           </div>
    </form>    

</body>
</html>
