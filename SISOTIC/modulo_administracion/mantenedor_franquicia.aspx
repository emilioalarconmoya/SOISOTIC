<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_franquicia.aspx.vb" Inherits="modulo_administracion_mantenedor_franquicia" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Franquicia</title>
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_franquicia.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulo_administracion/mantenedor_franquicia_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table id="tablaFiltro" cellpadding="0" cellspacing="0" class="TablaInterior" width="90%">
                    <tr>
                        <th colspan="6">
                            <asp:Label ID="Label6" runat="server" Text="Franquicia"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="height: 25px">
                            <asp:Label ID="Label7" runat="server" Text="Rut cliente :"></asp:Label>
                            <asp:Label ID="lblRutCliente" runat="server" Text="Label"></asp:Label>&nbsp;<br />
                            <asp:Label ID="Label90" runat="server" Text="Nombre : "></asp:Label>
                            <asp:Label ID="lblRazonSocial" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;<asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
                <br />
            </div>
            <div id="listado">
                &nbsp;<asp:GridView ID="grdResultados" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CssClass="Grid" Width="80%">
                    <Columns>
                        <asp:TemplateField HeaderText="A&#241;o">
                            <ItemTemplate>
                                <asp:Label ID="lblAgno" runat="server" Text='<%# bind("año") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor">
                            <ItemTemplate>
                                <asp:Label ID="lblValor" runat="server" Text='<%# bind("valor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>       
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>

