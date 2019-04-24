<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Reporte_buscar_aportes.aspx.vb" Inherits="modulo_aporte_Reporte_buscar_aportes" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<%--<script  type="text/jscript">
        
        function CambiarValor()
        {
           alert" funcion  "
           if (document.form1.RbnumeroAporte_0.checked == true ) 
           {
           alert "if " 
            document.form1.RbnumeroAporte_0.checked = false;
            document.form1.RbnumeroAporte_1.checked = true;
           }
        }
        function CambiarValor1()
        {
           
           if (document.form1.rbRutEmpresa_0.checked == true ) 
           {
            document.form1.rbRutEmpresa_0.checked = false;
            document.form1.rbRutEmpresa_1.checked = true;
           }
        }
        
    </script>--%>
<head id="Head1" runat="server">
    <title>Reporte buscar aportes</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script language="javascript"  src="../include/js/Confirmacion.js" type="text/javascript" ></script>
     <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="BtnBuscar">
    <div id="contenedor">
    <div id="bannner">
            <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
            <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
     <div id="menu">
        <div id="header">
           <ul>
                <li>
                    <asp:HyperLink ID="hplResumen" runat="server" NavigateUrl="resumen.aspx"><b>Resumen</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplResumenCobranza" runat="server" NavigateUrl="resumen_cobranza.aspx"><b>Resumen de cobranza</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAportes" runat="server" NavigateUrl="reporte_aportes.aspx"><b>Reporte aportes</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplBuscadorAportes" runat="server" NavigateUrl="Reporte_buscar_aportes.aspx"><b>Buscador Aportes</b></asp:HyperLink>
                </li>
               <li>
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="Listado_Facturas.aspx"><b>Listado facturas</b></asp:HyperLink>
                </li>
                 <li>
                    <asp:HyperLink ID="hplNuevoAporte" runat="server" NavigateUrl="ingreso_aporte.aspx"><b>Nuevo aporte</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                </li>
             
            </ul>
        </div>   
    </div>
    <div id="contenido"> 
    <div id="resultados">
        &nbsp;
        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top">
                                <asp:Label ID="Label1" runat="server" Text="Busqueda de aportes ingresados:"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
        <table id="tablaVyT" runat="server" cellpadding="0" cellspacing="0" class="Grid"
            style="width: 980px; height: 100px;" visible="true">
            <tr>
                <th style="width: 156px; height: 20px">
                    <asp:Label ID="Label3" runat="server" Text="Criterio de busqueda"></asp:Label>
                </th>
                <th style="width: 160px; height: 20px">
                    <asp:Label ID="Label4" runat="server" Text="Operador"></asp:Label>
                </th>
                <th style="width: 144px; height: 20px">
                    <asp:Label ID="Label5" runat="server" Text="Valor"></asp:Label>
                </th>
            </tr>
            <tr>
                <td style="width: 156px; height: 20px" class="AlineacionIzquierda">
                    <asp:Label ID="LbNumeroAporte" runat="server" Text="Nuemero Aporte"></asp:Label></td>
                <td style="width: 160px; height: 20px" class="AlineacionIzquierda">
                    <asp:RadioButton ID="RbNumeroAporte1" runat="server" Text="Nada" Checked="True" GroupName="RbnumeroAporte" />
                    <asp:RadioButton ID="RbNumeroAporte2" runat="server" Text="="  GroupName="RbnumeroAporte" />
                    <asp:RadioButton ID="RbNumeroAporte3" runat="server" Text=">" GroupName="RbnumeroAporte" />
                    <asp:RadioButton ID="RbNumeroAporte4" runat="server" Text="<" GroupName="RbnumeroAporte" />
                    <asp:RadioButton ID="RbNumeroAporte5" runat="server" Text="<>" GroupName="RbnumeroAporte"  /></td>
                <td style="width: 144px; height: 20px" class="AlineacionIzquierda">
                    <asp:TextBox ID="TxtNumeroAporte" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 156px; height: 20px" class="AlineacionIzquierda">
                    <asp:Label ID="LbRutEmpresa" runat="server" Text="Rut Empresa"></asp:Label></td>
                <td style="width: 160px; height: 20px" class="AlineacionIzquierda">
                    <asp:RadioButton ID="RbRutEmpresa1" runat="server" Text="Nada" Checked="True" GroupName="rbRutEmpresa" />
                    <asp:RadioButton ID="RbRutEmpresa2" runat="server" Text="="  GroupName="rbRutEmpresa"/>
                    <asp:RadioButton ID="RbRutEmpresa3" runat="server" Text=">"  GroupName="rbRutEmpresa"/>
                    <asp:RadioButton ID="rbRutEmpresa4" runat="server" Text="<" GroupName="rbRutEmpresa"/>
                    <asp:RadioButton ID="RbRutEmpresa5" runat="server" Text="<>" GroupName="rbRutEmpresa"/></td>
                <td style="width: 144px; height: 20px" class="AlineacionIzquierda">
                    <asp:TextBox ID="TxtRutEmpresa" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                        ControlToValidate="TxtRutEmpresa" ErrorMessage="Debe ingresar un rut válido"
                        ValidationGroup="xx">*</asp:CustomValidator></td>
            </tr>
            <tr>
                <td style="width: 156px; height: 20px" class="AlineacionIzquierda">
                    <asp:Label ID="LbCuentaDestino" runat="server" Text="Cuenta Destino"></asp:Label></td>
                <td style="width: 160px; height: 20px">
                </td>
                <td style="width: 144px; height: 20px" class="AlineacionIzquierda">
                    <asp:DropDownList ID="DdlCuentaDestino" runat="server" Width="112px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 156px; height: 20px">
                    <asp:Label ID="Label2" runat="server" Text="Ejecutivo"></asp:Label></td>
                <td style="width: 160px; height: 20px">
                </td>
                <td class="AlineacionIzquierda" style="width: 144px; height: 20px">
                    <asp:DropDownList ID="ddlEjecutivos" runat="server" Width="112px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 156px; height: 20px" class="AlineacionIzquierda">
                    <asp:Label ID="LbNombreEmpresa" runat="server" Text="Nombre Empresa"></asp:Label></td>
                <td style="width: 160px; height: 20px" class="AlineacionIzquierda">
                    <asp:Label ID="LbPalabraClave" runat="server" Text="Palabra Clave:"></asp:Label></td>
                <td style="width: 144px; height: 20px" class="AlineacionIzquierda">
                    <asp:TextBox ID="TxtPalabraClave" runat="server"></asp:TextBox></td>
            </tr>
        </table>
     
        <br />
         <div id="botones">
             <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" ValidationGroup="xx" /><br />
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="margenAdvertencia"
                 ValidationGroup="xx" Width="152px" />
             &nbsp;</div>
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
