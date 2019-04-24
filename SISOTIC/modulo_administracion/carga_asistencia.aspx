<%@ Page Language="VB" AutoEventWireup="false" CodeFile="carga_asistencia.aspx.vb" Inherits="modulo_administracion_carga_asistencia" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mantenedor de asistencias</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
      <%--<script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>--%>
      <script language="javascript"  type="text/javascript" >
        function ConfirmDelete()
        {
        var confirmed = window.confirm("ATENCIÓN: El curso será anulado si el porcentaje de asistencia\nde todos los alumnos es inferior a 75%.\n¿Desea continuar?")
        return(confirmed);
        }
        function PromedioAsistencia(gridViewName)
        {
            var tabla = document.getElementById(gridViewName);
            var asistencia = document.getElementById(txtAsistencia);
            alert(asistencia);
            var celdas = tabla.cells;
            var total;
            for(i=0;i<celdas.length-1;i++)
            {
                total= total+asistencia;
            }
            total = total/celdas.length;
            document.getElementById(txtMediaAsistencia)=total ;
            
        }
        
</script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
    <div id="Grafico">
     <table id="tablaDatosAlumno">
                        <tr>
                            <th width="980px" valign="top" class="TituloGrupo">
                                <asp:Label ID="Label4" runat="server" Text="Ingreso de la asistencia de alumnos: Listado de alumnos participantes"></asp:Label>  </th>                         
                        </tr>
                     </table>
        <div id="resultados">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Año :"></asp:Label>
            <asp:DropDownList ID="ddlAgno" runat="server">
            </asp:DropDownList>
            <asp:FileUpload ID="fulAsistencia" runat="server" />
            <asp:Button ID="btnCargar" runat="server" Text="Cargar" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
    <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
