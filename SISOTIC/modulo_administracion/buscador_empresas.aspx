<%@ Page Language="VB" AutoEventWireup="false" CodeFile="buscador_empresas.aspx.vb" Inherits="modulo_cursos_buscador_empresas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Buscador empresas</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" >
        function Cerrar(Rut)
        {
            // si existe ventana principal del sistema 
            if (self.opener)
            {	
           
                if (self.opener.document)
                {
                 
                    // si existe el formulario de la ventana principal del sistema 
                    if (self.opener.document.form1) 
                    {
                    
                        // si existe el campo del formulario de la ventana principal del sistema 
                        if (self.opener.document.form1.<%= campo_padre.value.trim %>)
                        {
                   
                            self.opener.document.form1.<%= campo_padre.value.trim %>.value=Rut;
                            self.opener.document.form1.<%= campo_padre.value.trim %>.focus();
                        }	
                    } 
                }
            }
            
            self.close()  
           
        }
    </script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <div id="PopUpEmpresas">
            <%--<h1>Buscador empresas</h1>--%>
            <div id="filtrosBusqueda">
                <asp:Label ID="lblRut" runat="server" Text="Rut empresa :"></asp:Label>
                <asp:TextBox ID="txtRutEmpresa" runat="server" Width="80px"></asp:TextBox>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="El Rut ingresado no es valido" Text="*" ControlToValidate="txtRutEmpresa" ValidationGroup="ValidaRut"></asp:CustomValidator>
                <asp:Label ID="lblRazonSocial" runat="server" Text="Razon social :"></asp:Label>
                <asp:TextBox ID="txtRazonSocial" runat="server" Width="300px"></asp:TextBox>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ValidationGroup="ValidaRut" />
                <br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="ValidaRut" />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClientClick="window.close();" />                
            </div>
            <hr /> 
            <div id="resultadoBusqueda">
                <asp:GridView ID="grdEmpresas" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="650px">
                    <Columns>
                        <asp:TemplateField HeaderText="Rut">
                            <ItemTemplate>
                                <asp:HyperLink ID="hplRut" runat="server" Text='<%# Bind("rut") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Razon social" />
                        <asp:BoundField HeaderText="Nombre contacto" />
                        <asp:BoundField HeaderText="Fono contacto" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="campo_padre" runat="server" />
        </div>    
    </form>
</body>
</html>

