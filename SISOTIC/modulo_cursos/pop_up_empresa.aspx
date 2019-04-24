<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pop_up_empresa.aspx.vb" Inherits="modulo_cursos_pop_up_empresa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Datos empresa</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />    
</head>
<body>
    <form id="form1" runat="server">
        <div id="PopUpEmpresa">           
            <div id="resultadoEmpresa">
                <table width="100%">
                    <tr>
                        <th width="100%">
                            Este saldo no considera los aportes que no han sido cobrados (ch y docs a fecha)
                        </th>
                    </tr>
                </table>
                <asp:GridView ID="grdEmpresa" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="300px" ShowHeader="False">
                    <Columns>
                        <asp:BoundField HeaderText="Cuenta" >
                            <ItemStyle Width="75%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Saldo" >
                            <ItemStyle Width="25%" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>    
    </form>
</body>
</html>