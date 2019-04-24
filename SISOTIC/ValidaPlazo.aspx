<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ValidaPlazo.aspx.vb" Inherits="ValidaPlazo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Fecha ingreso"></asp:Label>
        <asp:TextBox ID="txtFechaIngreso" runat="server" Width="100"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Fecha inicio"></asp:Label>
        <asp:TextBox ID="txtFechaInicio" runat="server" Width="100"></asp:TextBox>
        <asp:Button ID="btnValidar" runat="server" Text="Validar" />
    </div>
    </form>
</body>
</html>
