<%@ Page Language="VB" AutoEventWireup="false" CodeFile="menu_cargas_adm.aspx.vb" Inherits="modulo_administracion_menu_cargas_adm" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Menú de Cargas</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="Div1">
                <img alt="Otichile" src="../include/imagenes/css/fondos/reporte01.jpg" title="Cabecera Otichile" />
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="contenido">    
             
                <div id="menu" class="menu">
                    <h1>
                        Menú de Carga</h1>
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/modulo_administracion/carga_cursos_xls_adm.aspx" >Carga histórica de cursos</asp:HyperLink>
                        </li>
                         <li>
                                    
                            <asp:HyperLink ID="HyperLink143" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx">Menú Administración</asp:HyperLink>
                        </li>
                    </ul>
                </div>
                <br />
        </div>
          <asp:HiddenField ID="hdfOrigen" runat="server" Value="Administracion" />
    <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
     </div>
     </div>
    </form>
</body>
</html>
