<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BANOTIC</title>
    <link rel="apple-touch-icon" sizes="57x57" href="favicon/apple-touch-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="favicon/apple-touch-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="favicon/apple-touch-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="favicon/apple-touch-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="favicon/apple-touch-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="favicon/apple-touch-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="favicon/apple-touch-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="favicon/apple-touch-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="favicon/apple-touch-icon-180x180.png" />
    <link rel="icon" type="image/png" href="favicon/favicon-32x32.png" sizes="32x32" />
    <link rel="icon" type="image/png" href="favicon/android-chrome-192x192.png" sizes="192x192" />
    <link rel="icon" type="image/png" href="favicon/favicon-96x96.png" sizes="96x96" />
    <link rel="icon" type="image/png" href="favicon/favicon-16x16.png" sizes="16x16" />
    <link rel="manifest" href="favicon/manifest.json" />
    <meta name="msapplication-TileColor" content="#da532c" />
    <meta name="msapplication-TileImage" content="favicon/mstile-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
    <link href="estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">   
    <div id="Login" >
        
        <div id="LoginUsuario">
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName" CssClass="tituloTexto">Usuario:</asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" Width="100px" CssClass="datoTexto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio."
                            ValidationGroup="LoginUsuario">*</asp:RequiredFieldValidator>
            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword" CssClass="tituloTexto">Contraseña:</asp:Label>
             <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100px" CssClass="datoTexto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                            ValidationGroup="LoginUsuario">*</asp:RequiredFieldValidator>
            <br /> 
             
             <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="btnLogin"
                            Text="Ingresar al sistema" ValidationGroup="LoginUsuario" />
                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal><asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>            
                           
                            </div>
    </div>
    
        
    </form>
</body>
</html>

