<%@ Page Language="VB" AutoEventWireup="false" CodeFile="buscador_cursos.aspx.vb" Inherits="modulo_cursos_buscador_cursos" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script  type="text/jscript">
        

    </script>
<head runat="server">
    <title>Buscador de Cursos</title>
    <link href="../estilo.css" rel="stylesheet" type="text/css" />
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>


    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />

</head>
<body id="body" runat="server">
    <form id="form1" runat="server" defaultbutton="btnBuscar">
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
                    <asp:HyperLink ID="hplNuevoSence" runat="server" NavigateUrl="mantenedor_cursos.aspx"><b>Curso Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplNuevoNoSence" runat="server" NavigateUrl="mantenedor_cursos_internos.aspx"><b>Curso no Sence</b></asp:HyperLink>
                </li>
                <li class="pestanaconsolaseleccionada">
                    <asp:HyperLink ID="hplBuscarCurso" runat="server" NavigateUrl="buscador_cursos.aspx"><b>Buscar curso</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
                    </li>
                <li>
                    <asp:HyperLink ID="hplPagosTerceros" runat="server" NavigateUrl="pagos_terceros.aspx"><b>Pagos terceros</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplFacturas" runat="server" NavigateUrl="reporte_factura.aspx"><b>Facturas</b></asp:HyperLink>
                </li>
                <li visible="False">
                    <asp:HyperLink ID="hplMantenedorCursoSence" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Mantenedor Sence</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCargaDeCursos" runat="server" NavigateUrl="menu_cargas.aspx"><b>Carga cursos</b></asp:HyperLink>
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
    
        <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr valign="top">
                <td bgcolor="#000066" class="ND_CabeceraTabla2Bold">
                    Búsqueda de cursos contratados:
                    <asp:DropDownList ID="ddlAgno" runat="server">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <table cellpadding="3" cellspacing="0" style="width: 100%; height: 208px;">
            <tr>
                <td valign="top" >
                    <table  width="100%">
                        <tr >
                            <td style="width: 199px" >                                
                                 Criterios de búsqueda
                            </td>
                            <td style="width: 394px">                                
                                  Operador
                            </td>
                            <td >
                                
                                    Valor
                            </td>
                        </tr>
                    </table>
                    <table >
                       
                        <tr>
                            <td style="height: 10px; width: 366px;" >
                                
                                    Correlativo
                            </td>
                            <td style="height: 10px; width: 790px;" >
                                <div ><asp:RadioButton ID="rbCorrelativo1" runat="server" Checked="True" GroupName="rbCorrelativo" Text="Nada" />
                                    &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelativo2" runat="server" GroupName="rbCorrelativo" Text="=" />
                                    &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelativo3" runat="server" GroupName="rbCorrelativo" Text=">" />
                                    &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelativo4" runat="server" GroupName="rbCorrelativo" Text="<" />
                                    &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelativo5" runat="server" GroupName="rbCorrelativo" Text="<>" /></div>
                            </td>
                            <td class="tabla1"  style="height: 10px; width: 479px;">                                
                                    <asp:TextBox ID="txtCorrelativo" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 366px; height: 8px">
                                Código Curso</td>
                            <td style="width: 790px; height: 8px">
                                <asp:RadioButton ID="rbCodigoCurso1" runat="server" Checked="True" GroupName="rbCodigoCurso" Text="Nada" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCodigoCurso2" runat="server" GroupName="rbCodigoCurso" Text="=" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCodigoCurso3" runat="server" GroupName="rbCodigoCurso" Text=">" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCodigoCurso4" runat="server" GroupName="rbCodigoCurso" Text="<" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCodigoCurso5" runat="server" GroupName="rbCodigoCurso" Text="<>" /></td>
                            <td style="width: 479px; height: 8px">
                                <asp:TextBox ID="txtCodigoCurso" runat="server"></asp:TextBox></td>
                        </tr>
                       
                        <tr>
                            <td style="width: 366px; height: 8px" >
                                
                                    Correlativo Empresa
                            </td>
                            <td style="height: 8px; width: 790px;"  >
                                <asp:RadioButton ID="rbCorrelEmp1" runat="server" Checked="True" GroupName="rbCorrelativoEmp" Text="Nada" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelEmp2" runat="server" GroupName="rbCorrelativoEmp" Text="=" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelEmp3" runat="server" GroupName="rbCorrelativoEmp" Text=">" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelEmp4" runat="server" GroupName="rbCorrelativoEmp" Text="<" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbCorrelEmp5" runat="server" GroupName="rbCorrelativoEmp" Text="<>" /></td>
                            <td style="width: 479px; height: 8px" >
                                
                                    <asp:TextBox ID="txtCorrelativoEmp" runat="server"></asp:TextBox></td>
                        </tr>
                        
                        <tr>
                            <td style="width: 366px; height: 3px" >
                                
                                    Nro. Registro
                            </td>
                            <td style="width: 790px; height: 3px" >
                                <asp:RadioButton ID="rbNroRegistro1" runat="server" Checked="True" GroupName="rbNroRegistro" Text="Nada" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroRegistro2" runat="server" GroupName="rbNroRegistro" Text="=" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroRegistro3" runat="server" GroupName="rbNroRegistro" Text=">" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroRegistro4" runat="server" GroupName="rbNroRegistro" Text="<" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroRegistro5" runat="server" GroupName="rbNroRegistro" Text="<>" /></td>
                            <td style="width: 479px; height: 3px" >                                
                                    <asp:TextBox ID="txtNroRegistro" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 366px; height: 3px" >
                                
                                    Nro. Voucher
                            </td>
                            <td style="width: 790px; height: 3px" >
                                <asp:RadioButton ID="rbNroVoucher1" runat="server" Checked="True" GroupName="rbNroVoucher" Text="Nada" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroVoucher2" runat="server" GroupName="rbNroVoucher" Text="=" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroVoucher3" runat="server" GroupName="rbNroVoucher" Text=">" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroVoucher4" runat="server" GroupName="rbNroVoucher" Text="<" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbNroVoucher5" runat="server" GroupName="rbNroVoucher" Text="<>" /></td>
                            <td style="width: 479px; height: 3px" >                                
                                    <asp:TextBox ID="txtNroVoucher" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr style="display:none;">
                            <td style="width: 366px; height: 3px">
                                Orden de compra</td>
                            <td style="width: 790px; height: 3px">
                                <asp:RadioButton ID="rbOrdenCompra1" runat="server" Checked="True" GroupName="rbOrdenCompra" Text="Nada" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbOrdenCompra2" runat="server" GroupName="rbOrdenCompra" Text="=" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbOrdenCompra3" runat="server" GroupName="rbOrdenCompra" Text=">" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbOrdenCompra4" runat="server" GroupName="rbOrdenCompra" Text="<" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbOrdenCompra5" runat="server" GroupName="rbOrdenCompra" Text="<>" /></td>
                            <td style="width: 479px; height: 3px">
                                <asp:TextBox ID="txtOrdenCompra" runat="server"></asp:TextBox></td>
                        </tr>
                       
                        <tr>
                            <td style="width: 366px; height: 37px;" >
                                
                                    RUT Empresa
                            </td>
                            <td style="width: 790px; height: 37px;" >
                                <asp:RadioButton ID="rbRutEmpresa1" runat="server" Checked="True" GroupName="rbRutEmpresa" Text="Nada" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbRutEmpresa2" runat="server" GroupName="rbRutEmpresa" Text="=" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbRutEmpresa3" runat="server" GroupName="rbRutEmpresa" Text=">" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbRutEmpresa4" runat="server" GroupName="rbRutEmpresa" Text="<" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbRutEmpresa5" runat="server" GroupName="rbRutEmpresa" Text="<>" /></td>
                            <td style="width: 479px; height: 37px;" 
                            >
                                &nbsp;<asp:TextBox ID="txtRutEmp" runat="server"></asp:TextBox>
                                <asp:CustomValidator ID="cvValidaRut" runat="server" ErrorMessage="El rut ingresado es invalido" ClientValidationFunction="VerificarRut" ControlToValidate="txtRutEmp" ValidationGroup="zz">*</asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 366px">
                                Fecha de ingreso</td>
                            <td style="width: 790px">
                                <asp:RadioButton ID="rbFechaIngreso1" runat="server" Checked="True" GroupName="rbFechaIngreso" Text="Nada" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbFechaIngreso2" runat="server" GroupName="rbFechaIngreso" Text="=" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbFechaIngreso3" runat="server" GroupName="rbFechaIngreso" Text=">" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbFechaIngreso4" runat="server" GroupName="rbFechaIngreso" Text="<" />
                                &nbsp; &nbsp;<asp:RadioButton ID="rbFechaIngreso5" runat="server" GroupName="rbFechaIngreso" Text="<>" /></td>
                            <td style="width: 479px">
                                <asp:TextBox ID="txtFechaIngreso" runat="server"></asp:TextBox> <br />
                                (dd/mm/aaaa)</td>
                        </tr>
                        
                        <tr>
                            <td style="width: 366px" >
                                
                                    Nombre empresa
                            </td>
                            <td style="width: 790px" >
                                
                                    Palabra clave: 
                            </td>
                            <td style="width: 479px" >
                                
                                    <asp:TextBox ID="txtNomEmpresa" runat="server"></asp:TextBox></td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
        </table>
        <center><asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="zz" /></center>
        <br />
        <table align="center" border="0" cellpadding="3" cellspacing="0" class="ND_CabeceraTabla1"
            width="100%">
            <tr >
                <td >
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" /></td>
               
                <td >
                    &nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="zz" /></td>
            </tr>
        </table>
    </div>
    
    <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
