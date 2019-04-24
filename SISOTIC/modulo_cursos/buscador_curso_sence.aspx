<%@ Page Language="VB" AutoEventWireup="false" CodeFile="buscador_curso_sence.aspx.vb" Inherits="modulo_cursos_buscador_curso_sence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Buscador cursos Sence</title>
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
        <div id="PopUpCursoSence">
            <%--<h1>Buscador cursos Sence</h1>--%>
            <div id="filtrosBusqueda"> 
                <asp:Label ID="lblCodSence" runat="server" Text="Cod. Sence :"></asp:Label>
                <asp:TextBox ID="txtCodSence" runat="server" Width="60px"></asp:TextBox>
                <asp:Label ID="lblNomCurso" runat="server" Text="Nom. curso :"></asp:Label>
                <asp:TextBox ID="txtNomCurso" runat="server" Width="180px"></asp:TextBox>                
                <asp:Label ID="lblOtec" runat="server" Text="Otec :"></asp:Label>
                <asp:TextBox ID="txtOtec" runat="server" Width="180px"></asp:TextBox>
                <br />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="ValidaRut" />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClientClick="window.close();" />             
            </div>  
            <hr />     
            <div id="resultadoBusqueda">
                <asp:GridView ID="grdCursosSence" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="650px">
                    <Columns>
                        <asp:TemplateField HeaderText="Cod. Sence">
                            <ItemTemplate>
                                <asp:HyperLink ID="hplCodSence" runat="server" Text='<%# Bind("cod_sence") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nombre curso" />
                        <asp:BoundField HeaderText="Horas" />
                        <asp:BoundField HeaderText="Otec" />
                        <asp:TemplateField HeaderText="Valor total">
                            <ItemTemplate>
                                <asp:Label ID="lblValorCurso" runat="server" Text='<%# Bind("valor_curso") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:HiddenField ID="campo_padre" runat="server" />
            <asp:Label ID="lblMensaje" runat="server" Width="624px"></asp:Label></div>    
    </form>
</body>
</html>