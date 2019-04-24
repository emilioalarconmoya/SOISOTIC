<%@ Page Language="VB" AutoEventWireup="false" CodeFile="autorizacion_pago_solicitud.aspx.vb" Inherits="modulo_cursos_autorizacion_pago_solicitud" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Autorizar pago</title>
<link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
        
//        
        
    </script>

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor" style="width: 980px; height: 1752px;">
        <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
        </div>
        <div id="cabecera">
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
                    <li class="pestanaconsolaseleccionada">
                        <asp:HyperLink ID="hplReporteCursos" runat="server" NavigateUrl="reporte_cursos.aspx"><b>Reporte Sence</b></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
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
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="../menu.aspx"><b>Menú Principal</b></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="../fin_sesion.aspx"><b>Salir</b></asp:HyperLink>
                    </li>
                </ul>
            </div>
        <table id="tablaDatosCurso">
                        <tr>
                            <th width="980px" class="TituloGrupo" valign="top" style="height: 1px">
                                <asp:Label ID="Label43" runat="server" Text="Autorización de Solicitud de Pago"></asp:Label>
                            </th>                            
                        </tr>
                     </table>
            <br />
            <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" Height="120px" Width="980px">
                <Columns>
                    <asp:TemplateField HeaderText="Datos del curso">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td style="width: 78px" class="AlineacionIzquierda">
                                        <asp:Label ID="Label1" runat="server" Text="Correlativo"></asp:Label></td>
                                    <td style="width: 2px" class="DosPuntos">
                                        :</td>
                                    <td class="AlineacionIzquierda" colspan="2">
                                        <asp:Label ID="lblDCcorrelativo" runat="server" Text='<%# bind("correlativo") %>'></asp:Label></td>
                                    <td style="width: 77px">
                                        <asp:HiddenField ID="hdfCodCurso" runat="server" Value='<%# bind("cod_curso") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 78px" class="AlineacionIzquierda">
                                        <asp:Label ID="Label3" runat="server" Text="Beneficiado"></asp:Label></td>
                                    <td style="width: 2px" class="DosPuntos">
                                        :</td>
                                    <td style="width: 67px" class="AlineacionIzquierda">
                                        <asp:Label ID="lblDCbeneficiado" runat="server" Text='<%# bind("razon_social") %>' Width="240px"></asp:Label></td>
                                    <td style="width: 26px">
                                        <asp:Label ID="Label8" runat="server" Text="Rut: "></asp:Label></td>
                                    <td style="width: 77px" class="AlineacionIzquierda">
                                        <asp:Label ID="lblDCrutBeneficiado" runat="server" Text='<%# bind("rut_cliente") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 78px; height: 18px;" class="AlineacionIzquierda">
                                        <asp:Label ID="Label11" runat="server" Text="Fecha Ingreso" Width="80px"></asp:Label></td>
                                    <td style="width: 2px; height: 18px;" class="DosPuntos">
                                        :</td>
                                    <td style="height: 18px;" class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="lblDCfechaIngreso" runat="server" Text='<%# bind("fecha_ingreso") %>' Width="176px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 78px" class="AlineacionIzquierda">
                                        <asp:Label ID="Label15" runat="server" Text="Fecha Inicio"></asp:Label></td>
                                    <td style="width: 2px" class="DosPuntos">
                                        :</td>
                                    <td class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="lblDCfechaInicio" runat="server" Text='<%# bind("fecha_inicio") %>' Width="176px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 78px" class="AlineacionIzquierda">
                                        <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Aporte Solicitado"
                                            Width="104px"></asp:Label></td>
                                    <td style="width: 2px" class="DosPuntos">
                                        :</td>
                                    <td class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="lblDCaporteSolicitado" runat="server" Text='<%# bind("monto") %>' Font-Bold="True"></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:GridView ID="grdResultados2" runat="server" AutoGenerateColumns="False" Width="980px">
                <Columns>
                    <asp:TemplateField HeaderText="benefactor">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior" style="width: 216px;
                                height: 48px">
                                <tr>
                                    <td class="AlineacionIzquierda" colspan="3">
                                        <asp:Label ID="lblBEnombreBenefactor" runat="server" Font-Bold="True" Text='<%# bind("razon_social_benefactor") %>' Width="176px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="AlineacionIzquierda" style="width: 27px">
                                        <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Rut: "></asp:Label></td>
                                    <td class="DosPuntos">
                                        :</td>
                                    <td class="AlineacionIzquierda" style="width: 100px">
                                        <asp:Label ID="lblBErutBenefactor" runat="server" Font-Bold="True" Text='<%# bind("rut_benefactor") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderStyle Width="400px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="cuentas propias">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td style="width: 288px" class="AlineacionIzquierda" colspan="2">
                                        <asp:Label ID="Label27" runat="server" Text="Cuenta de Reparto: " Width="112px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 288px" class="AlineacionIzquierda" colspan="2">
                                        <asp:Label ID="Label28" runat="server" Text="Cuenta de Excedentes de Reparto: " Width="200px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 288px" class="AlineacionIzquierda" colspan="2">
                                        <asp:Label ID="Label29" runat="server" Text="Cuenta de Administración" Width="144px"></asp:Label>(<asp:Label ID="lblCPporcAdmin" runat="server" Text='<%# bind("porc_adm") %>'></asp:Label>%):</td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="saldo actual">
                        <ItemTemplate>
                            <table style="width: 200px" cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td style="height: 18px;" class="AlineacionIzquierda" colspan="2">
                                        <asp:Label ID="lblSAcuentaReparto" runat="server" Text='<%# Bind("cuenta_reparto") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="height: 29px;" class="AlineacionIzquierda" colspan="2">
                                        <asp:Label ID="lblSAcuentaExcReparto" runat="server" Text='<%# bind("cuenta_exc_reparto") %>'></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Label ID="Label35" runat="server" Font-Bold="True" Text="TOTAL CARGOS:" Width="96px"></asp:Label></td>
                                    <td style="width: 100px" class="AlineacionDerecha">
                                        <asp:Button ID="btnTotal" OnClick="Totalizar" runat="server" Text="Total" Font-Bold="True" ForeColor="Black" Width="56px" /></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="monto a usar">
                        <ItemTemplate>
                            <table style="width: 104px" cellpadding="0" cellspacing="0" class="TablaInterior">
                                <tr>
                                    <td style="width: 100px" class="AlineacionDerecha">
                                        <asp:TextBox ID="txtMontoUsarCuentaReparto" runat="server" Width="80px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px" class="AlineacionDerecha">
                                        <asp:TextBox ID="txtMontoUsarCuentaExcReparto" runat="server" Width="80px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px" class="AlineacionDerecha">
                                        <asp:TextBox ID="txtMontoUsarCuentaAdm" runat="server" Width="80px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px" class="AlineacionDerecha">
                                        <asp:TextBox ID="txtTotalMontoUsar" runat="server" Width="80px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderStyle Width="130px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            
        <div id="contenido">
            <div id="resultados">
                <div id="CuentasPeriodoActual" style="height: 56px">
                    
                    
                    <table width="980" cellpadding="0" cellspacing="0" class="TablaFooter" >
                      <tr>
                            <td class="AlineacionIzquierda" colspan="2" valign="top" style="height: 14px">
                                </td>
                        </tr>
                        <tr>
                            <td class="AlineacionIzquierda" colspan="2" valign="top">
                </td>
                        </tr>
                    </table>
                     <div id="botones">
                         &nbsp;<asp:Button ID="btnVolver" runat="server" Text="Volver" ForeColor="Black" />
                         &nbsp; &nbsp;<asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" ForeColor="Black" /></div>
                    
                    <br />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </div>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;
                <br />
                
            </div>
        </div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server" Text="Miraflores 130, piso 17, of. 1701. Tel. 6395011 e-mail: cmaldonado@oticabif.cl"></asp:Label>
            </div>
        </div>
    </div>
        </div>
            <%--&nbsp;<uc2:cabecera1 id="Cabecera1_1" runat="server"></uc2:cabecera1></div>--%>
    </form>
</body>
</html>
