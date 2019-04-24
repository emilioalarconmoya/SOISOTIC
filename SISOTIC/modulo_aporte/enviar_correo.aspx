<%@ Page Language="VB" AutoEventWireup="false" CodeFile="enviar_correo.aspx.vb" Inherits="modulo_cursos_enviar_correo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Enviar mail</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
   <%-- <script type="text/javascript" >
        function Imprimir()
        {
           
        }
      </script>--%>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
            <div id="filtrosBusqueda">
                <table style="width: 90%">
                    <tr>
                        <td align="center">
                            <span style="font-size: 16pt">Enviar Correo</span></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center" class="AlineacionIzquierda">
                            &nbsp;<table class="TablaInterior" style="width: 872px">
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 84px">
                            <asp:Label ID="Label1" runat="server" Text="Correo empresa :" Width="80px"></asp:Label></td>
                                    <td class="AlineacionIzquierda">
                            <asp:TextBox ID="txtEmailEmpresas" runat="server" Height="24px" TextMode="MultiLine"
                                Width="512px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionDerecha" colspan="5">
                                        &nbsp;
                                los correos se separan por coma (,)</td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 84px">
                            <asp:Label ID="Label2" runat="server" Text="CC :"></asp:Label></td>
                                    <td class="AlineacionIzquierda">
                            <asp:TextBox ID="txtEmailOtecs" runat="server" Height="24px" TextMode="MultiLine"
                                Width="512px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Asunto:
                            <asp:TextBox ID="txtAsuntoEmail" runat="server" Style="position: static" Width="830px"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <div class="AlineacionIzquierda">
                                Mensaje:</div>
                            <asp:TextBox ID="txtCuerpoEmail" runat="server" Rows="12" Style="position: static"
                                TextMode="MultiLine" Width="864px"></asp:TextBox><br />
                            <asp:Button ID="btnEnviar" runat="server" Style="position: static" Text="Enviar"
                                Width="150px" />&nbsp;
                            <asp:Button ID="btnCerrar" runat="server" Style="position: static" Text="Cerrar"
                                Width="150px" /></td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
