<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carga_alumnos.aspx.vb" Inherits="modulo_administracion_carga_alumnos" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Carga de alumnos</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="bannner">
                <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile"/>
                <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
            </div>
            <div id="menu" runat="server">
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
            <div id="contenido">
                <div id="PestañasMantenedor">
                    <ul>
                        <li class="PestañasMantenedorseleccionada">
                            <asp:HyperLink id="HyperLink1" runat="server" >Carga alumnos</asp:HyperLink> 
                        </li>
                    </ul>
                </div>             
                <fieldset id="mantenedor" >
                    <div id="CargaAlumno">
                        <asp:Label ID="lblFul" runat="server" Text="Cargar archivo con alumnos"></asp:Label>
                        <asp:FileUpload ID="fulAlumnos" runat="server" Width="250px" /><br />
                        <asp:Button ID="btnCargar" runat="server" Text="Cargar alumnos" Width="120px" />
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" Width="120px" /></div>
                    <div id="divEjemploCarga">
                        <asp:Label ID="lblEjemplo" runat="server" Text="Permite seleccionar a través del botón examinar,
                        un archivo con extensión 'txt' que contiene la información de las personas separadas por el simbolo '|'.
                        por ejemplo: '12363005|k|Rojas|Vilches|Alejandra|29/08/1977|F|100|1|2|3|50298890|132101|1|77639835|xx@xx.com'.
                        Los valores indicados anteriormente corresponden a: Rut, digito verificador,apellido paterno, 
                        apellido materno, nombres , fecha de nacimiento,sexo(F ó M) , porcentaje de franquicia,código nivel ocupacional,
                         código nivel educacional, código región, Rut de la Empresa y código de la comuna de residencia, código de país, teléfono, email 
                         .Una vez seleccionado se debe presionar el botón Subir Archivo , 
                         el cual permite cargar los registros de los alumnos a la base de datos actual."></asp:Label>
                    </div>
                </fieldset>                
            </div>            
        </div>  
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
