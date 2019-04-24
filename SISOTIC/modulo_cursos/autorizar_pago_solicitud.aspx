<%@ Page Language="VB" AutoEventWireup="false" CodeFile="autorizar_pago_solicitud.aspx.vb" Inherits="modulo_cursos_autorizar_pago_solicitud" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Autorizar pago</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
  <%--<script  type="text/jscript">
        
        function CalculaValorFinal() 
        {
            
            var ValorRep= document.form1.<%= txtMontoCuentaReparto.ClientID %>.value;
            var ValorExcRep = document.form1.<%= txtMontoCuentaExcReparto.ClientID %>.value;
            var ValorPorAdm = document.form1.<%= lblPorcAdmin.ClientID %>.value;
            var valorAdm = ((100*ValorRep)/(100-ValorPorAdm))-ValorRep;
            document.form1.<%= txtMontoCuentaAdmin.ClientID %>.value=valorAdm;
//            var valorAdm = document.form1.<%= txtMontoCuentaAdmin.ClientID %>.value;
            document.form1.<%= txtTotalMonto.ClientID %>.value += ValorRep;
            document.form1.<%= txtTotalMonto.ClientID %>.value += ValorExcRep;
            document.form1.<%= txtTotalMonto.ClientID %>.value += valorAdm;
            
        }
    </script>--%>

</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
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
                <li>
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
                <li class="pestanaconsolaseleccionada">
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
            <table id="tablaHeader" style="width: 980px">
                <tr>
                    <th class="TituloGrupo" style="width: 980px; height: 18px;" valign="top">
                        <asp:Label ID="Label3" runat="server" Text="Autorización de Solicitud de Pago"></asp:Label></th>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 980px">
            <tr>
                <th class="AlineacionIzquierda" colspan="9" style="height: 18px">
                    <asp:Label ID="Label1" runat="server" Text="Datos del Curso"></asp:Label>
                    </th>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 10%; height: 12px">
                    <asp:Label ID="Label2" runat="server" Text="Correlativo"></asp:Label></td>
                        <td class="DosPuntos" style="width: 1%; ">
                            :</td>
                        <td class="AlineacionIzquierda" style=" width: 358px;" colspan="4">
                            <asp:Label ID="lblCorrelativo" runat="server" Text="Label"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="1" style="height: 12px">
                    <asp:Label ID="Label18" runat="server" Text="Fecha Ingreso"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="1" style="height: 12px">
                    :</td>
                <td class="AlineacionIzquierda" colspan="1" style="height: 12px">
                            <asp:Label ID="lblFechaIngreso" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 10%; height: 12px">
                    <asp:Label ID="Label5" runat="server" Text="Beneficiado"></asp:Label></td>
                        <td class="DosPuntos" style="width: 1%; height: 12px">
                            :</td>
                        <td class="AlineacionIzquierda" style="height: 12px; width: 358px;" colspan="4">
                            <asp:Label ID="lblNombreBeneficiado" runat="server" Text="Label"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="1" style="width: 83px; height: 12px">
                    <asp:Label ID="Label19" runat="server" Text="Fecha Inicio"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="1" style="width: 1px; height: 12px">
                    :</td>
                <td class="AlineacionIzquierda" colspan="1" style="width: 346px; height: 12px">
                            <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="width: 10%; height: 12px">
                            <asp:Label ID="Label15" runat="server" Text="Rut : "></asp:Label></td>
                        <td class="DosPuntos" style="width: 1%; height: 12px">
                            :</td>
                        <td class="AlineacionIzquierda" style="height: 12px; width: 358px;" colspan="4">
                            <asp:Label ID="lblRutBeneficiado" runat="server" Text="Label"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="1" style="width: 83px; height: 12px">
                    <asp:Label ID="Label20" runat="server" Text="Aporte Solicitado" Width="96px"></asp:Label></td>
                <td class="AlineacionIzquierda" colspan="1" style="width: 1px; height: 12px">
                    :</td>
                <td class="AlineacionIzquierda" colspan="1" style="width: 346px; height: 12px">
                            <asp:Label ID="lblAporteSolicitado" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
        <br />
            <table cellpadding="0" class="TablaInterior4">
               <%-- <tr>
                    <th class="TituloIzquierda" colspan="6" style="height: 30px">
                        <asp:Label ID="Label46" runat="server" Text="Benefactor"></asp:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<b class="TablaCuentas">Cuentas propias
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; <b>Saldo actual &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                Monto
                                a usar</b></b></th>
                </tr>--%>
                <tr>
                    <th class="AlineacionIzquierda" colspan="2" style="width: 441px; height: 12px">
                        <asp:Label ID="Label13" runat="server" Text="Benefactor"></asp:Label></th>
                    <th class="AlineacionIzquierda" style="width: 164px; height: 12px">
                        <asp:Label ID="Label6" runat="server" Text="Cuentas propias"></asp:Label>
                    </th>
                    <th class="AlineacionIzquierda" style="height: 12px" colspan="2">
                        <asp:Label ID="Label12" runat="server" Text="saldo Actual"></asp:Label></th>
                    <th class="AlineacionIzquierda" style="width: 131px; height: 12px" rowspan="">
                        <asp:Label ID="Label7" runat="server" Text="Monto a Usar"></asp:Label></th>
                </tr>
                <tr>
                    <td class="AlineacionIzquierda" colspan="2" style="width: 441px; height: 19px">
                        <asp:Label ID="lblNombreBenefactor" runat="server" Text="Label"></asp:Label></td>
                    <td class="AlineacionDerecha" style="width: 164px; height: 19px">
                        <asp:Label ID="Label9" runat="server" Text="Cuenta de Reparto:"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 87px; height: 19px">
                            <asp:Label ID="lblCuentaReparto" runat="server" Text="Label"></asp:Label></td>
                    <td class="AlineacionDerecha" style="width: 4%;" rowspan="3">
                    </td>
                        <td class="AlineacionDerecha" style="width: 131px; height: 19px;">
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtMontoCuentaReparto" ErrorMessage="Debe ingresar sólo numeros"
                                ValidationExpression="\d+" ValidationGroup="ValidaNumero">*</asp:RegularExpressionValidator><asp:TextBox ID="txtMontoCuentaReparto" runat="server" Height="16px" Width="104px" MaxLength="9">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="2" style="width: 441px; height: 20px">
                            <asp:Label ID="Label8" runat="server" Text="Rut : "></asp:Label>
                            <asp:Label ID="lblRutBenefactor" runat="server"></asp:Label>
                        </td>
                        <td class="AlineacionDerecha" style="width: 164px; height: 20px">
                            <asp:Label ID="Label10" runat="server" Text="Cuenta de Excedentes de Reparto:"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 87px; height: 20px">
                            <asp:Label ID="lblCuentaExcReparto" runat="server" Text="Label"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 131px; height: 20px;">
                            <asp:TextBox ID="txtMontoCuentaExcReparto" runat="server" Height="16px" Width="104px">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="TituloIzquierdo" colspan="2" style="width: 441px; height: 19px">
                            <asp:HiddenField ID="hdfCodCurso" runat="server" />
                        </td>
                        <td class="AlineacionDerecha" style="width: 164px; height: 19px">
                            <asp:Label ID="Label4" runat="server" Text="Cuenta de Administración ("></asp:Label><asp:Label
                                ID="lblPorcAdmin" runat="server" Text="Label"></asp:Label><asp:Label ID="Label11"
                                    runat="server" Text="%):"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 87px; height: 19px">
                        </td>
                        <td class="AlineacionDerecha" style="width: 131px; height: 19px;">
                            <asp:TextBox ID="txtMontoCuentaAdmin" runat="server" ReadOnly="True" Height="16px" Width="104px">0</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 19px">
                        </td>
                        <td class="AlineacionDerecha" style="width: 87px; height: 19px;">
                            &nbsp;
                            <asp:Label ID="Label14" runat="server" Text="TOTAL CARGOS:"></asp:Label></td>
                        <td class="AlineacionDerecha" style="width: 4%; height: 19px;">
                            <asp:Button ID="btnTotal" runat="server" Text="Total" Height="24px" Width="40px" /></td>
                        <td class="AlineacionDerecha" style="width: 131px; height: 19px;">
                            &nbsp;<asp:TextBox ID="txtTotalMonto" runat="server" ReadOnly="True" Height="16px" Width="104px">0</asp:TextBox></td>
                    </tr>
                </table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                                        <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                            &nbsp;&nbsp; &nbsp;<asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" ValidationGroup="ValidaNumero" />
        &nbsp; &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidaNumero" />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
        </div>
    </div>
    </div>    
    </form>
</body>

</html>
