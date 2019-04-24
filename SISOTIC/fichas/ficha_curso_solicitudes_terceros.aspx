<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ficha_curso_solicitudes_terceros.aspx.vb" Inherits="modulo_cursos_curso_solicitudes_terceros" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pagos terceros</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
    <div id="contenido"> 
    <div id="resultados">

        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Ficha curso pagos terceros"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <asp:GridView ID="grdResultados" runat="server" Width="980px" AutoGenerateColumns="False">
            <Columns>
            <asp:TemplateField ShowHeader="False" HeaderText="Empresa Benefactora">
                    <ItemTemplate>
                                    <asp:Label ID="lblRutCliente" runat="server" Text='<%# bind("rut_benefactor") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" Width="10px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                           <asp:HyperLink ID="hplRazonSocial" runat="server" Text='<%# Bind("razon_social") %>'></asp:HyperLink></td>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="Reparto solicitado">
                    <ItemTemplate>
                        <asp:Label ID="lblReaprtoSolicitado" runat="server" Text='<%# Bind("monto") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="Reparto utilizado">
                    <ItemTemplate>
                        <asp:Label ID="lblReaprtoUtilizado" runat="server" Text='<%# Bind("monto_utilizado") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="Estado">
                    <ItemTemplate>
                                    <asp:Label ID="lblNombreEstado" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
         <div id="botones">
      <asp:Button ID="btnVolver" runat="server" Text="Volver" />
      <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" /></div>
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
