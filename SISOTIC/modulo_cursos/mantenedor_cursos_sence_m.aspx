<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mantenedor_cursos_sence_m.aspx.vb" Inherits="modulo_administracion_mantenedor_cursos_sence_m" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantenedor</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>    
    <script language="javascript"  src="../include/js/AbrirPopUp.js" type="text/javascript" ></script>  
    <script language="javascript"  src="../include/js/Validacion.js" type="text/javascript" ></script>  

    <link href="../../estilo.css" rel="Stylesheet" type="text/css" />
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
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="reporte_cursos_internos.aspx"><b>Reporte no Sence</b></asp:HyperLink>
                </li>
                    <li>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="reporte_alumnos.aspx"><b>Reporte Alumnos</b></asp:HyperLink>
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
    </div>
        <div id="PestañasMantenedor">
            <ul>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mantenedor_cursos_sence.aspx"><b>Datos</b></asp:HyperLink>
                </li>
                <li class="PestañasMantenedorseleccionada">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="mantenedor_cursos_sence_m.aspx"><b>Mantenedor</b></asp:HyperLink>
                </li>
            </ul>
        </div>             
        <fieldset id="mantenedor" >
            <div id="filtrosMantenedor">
                <table id="tablaNuevoObjeto" cellpadding="0" cellspacing="0" class="Grid" style="width: 80%">
                    <tr>
                        <th colspan="9" class="AlineacionIzquierda">
                            <asp:Label ID="lblTipo" runat="server" Text="Datos curso"></asp:Label></th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%;">
                            <asp:Label ID="Label1" runat="server" Text="Código SENCE: "></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%;">
                            <asp:TextBox ID="txtCodSence" runat="server" MaxLength="10" TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="debe ingresar codigo sence"
                                ValidationGroup="xx" ControlToValidate="txtCodSence">*</asp:RequiredFieldValidator></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label8" runat="server" Text="Nº máximo participantes:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:TextBox ID="txtNumParticipantes" runat="server" TabIndex="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="debe ingresar numero de participantes"
                                ValidationGroup="xx" ControlToValidate="txtNumParticipantes">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNumParticipantes"
                                ErrorMessage="Ingrese un número válido" ValidationExpression="\d+" ValidationGroup="xx">*</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%;">
                            <asp:Label ID="Label2" runat="server" Text="Nombre curso:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%;">
                            <asp:TextBox ID="txtNombreCurso" runat="server" Width="90%" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="debe ingresar nombre del curso"
                                ValidationGroup="xx" ControlToValidate="txtNombreCurso">*</asp:RequiredFieldValidator></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label9" runat="server" Text="Nombre sede:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:TextBox ID="txtNombreSede" runat="server" TabIndex="9"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="debe ingresar nombre sede"
                                ValidationGroup="xx" ControlToValidate="txtNombreSede">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%;">
                            <asp:Label ID="Label3" runat="server" Text="Rut OTEC:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%;">
                            <asp:TextBox ID="txtRutEmpresa" runat="server" AutoCompleteType="Disabled" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="debe ingresar rut otec"
                                ValidationGroup="xx" ControlToValidate="txtRutEmpresa">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="VerificarRut"
                                ControlToValidate="txtRutEmpresa" ErrorMessage="Ingrese un rut válido" ValidationGroup="xx">*</asp:CustomValidator>
                            <asp:Button ID="btn_buscar_otec" runat="server" Text="..." /></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label10" runat="server" Text="Fono sede:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:TextBox ID="txtFonoSede" runat="server" TabIndex="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="debe ingresar fono sede"
                                ValidationGroup="xx" ControlToValidate="txtFonoSede">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%;">
                            <asp:Label ID="Label4" runat="server" Text="Área:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%;">
                            <asp:TextBox ID="txtArea" runat="server" TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="debe ingresar area"
                                ValidationGroup="xx" ControlToValidate="txtArea">*</asp:RequiredFieldValidator></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label11" runat="server" Text="Dirección:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:TextBox ID="txtDireccion" runat="server" TabIndex="11"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="debe ingresar direccion"
                                ValidationGroup="xx" ControlToValidate="txtDireccion">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%;">
                            <asp:Label ID="Label5" runat="server" Text="Especialidad:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%;">
                            <asp:TextBox ID="txtEspecialidad" runat="server" TabIndex="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="debe ingresar especialidad"
                                ValidationGroup="xx" ControlToValidate="txtEspecialidad">*</asp:RequiredFieldValidator></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label12" runat="server" Text="Comuna:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:DropDownList ID="ddlComuna" runat="server" TabIndex="12">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%;">
                            <asp:Label ID="Label6" runat="server" Text="Horas Teóricas"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%;">
                            <asp:TextBox ID="txtDurCursoTeorico" runat="server" TabIndex="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="debe ingresar duracion del curso teorico"
                                ValidationGroup="xx" ControlToValidate="txtDurCursoTeorico">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDurCursoTeorico"
                                ErrorMessage="Ingrese un número válido" ValidationExpression="\d+" ValidationGroup="xx">*</asp:RegularExpressionValidator></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label13" runat="server" Text="Valor total curso:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:TextBox ID="txtValorTotal" runat="server" TabIndex="13"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Campo obligatorio"
                                ValidationGroup="xx" ControlToValidate="txtValorTotal">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtValorTotal"
                                ErrorMessage="Ingrese un número válido" ValidationExpression="\d+" ValidationGroup="xx">*</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%;">
                            <asp:Label ID="Label7" runat="server" Text="Horas Prácticas"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%;">
                            <asp:TextBox ID="txtDurCursoPractico" runat="server" TabIndex="7"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="debe ingresar duracion curso practico"
                                ValidationGroup="xx" ControlToValidate="txtDurCursoPractico">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDurCursoPractico"
                                ErrorMessage="Ingrese un número válido" ValidationExpression="\d+" ValidationGroup="xx">*</asp:RegularExpressionValidator></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label15" runat="server" Text="Valor hora Sence:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:TextBox ID="txtValorHoraSence" runat="server" Width="53px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%; height: 27px;">
                            <asp:Label ID="Label16" runat="server" Text="Horas E-learning" Width="95px"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%; height: 27px;">
                            <asp:TextBox ID="txtHoraElearning" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtHoraElearning"
                                ErrorMessage="debe ingresar duracion curso practico" ValidationGroup="xx">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtHoraElearning"
                                    ErrorMessage="Ingrese un número válido" ValidationExpression="\d+" ValidationGroup="xx">*</asp:RegularExpressionValidator></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%; height: 27px;">
                            <asp:Label ID="Label14" runat="server" Text="Modalidad"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%; height: 27px;">
                            <asp:DropDownList ID="ddlModalidad" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <%--<tr>
                        <td class="AlineacionIzquierda" colspan="6" style="width: 20%">
                        </td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                        </td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 20%">
                            <asp:Label ID="Label14" runat="server" Text="Modalidad"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="1" style="width: 30%">
                            <asp:DropDownList ID="ddlModalidad" runat="server">
                            </asp:DropDownList>
                            <asp:CheckBox ID="chkElearning" runat="server" Visible="False" /></td>
                    </tr>--%>
                </table>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="xx" />
                <br />
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="xx" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" />                
            </div>
        </fieldset>       
    </div>
     <div id="pie">
        <div class="textoPie" >
            <asp:Label ID="lblPie"  runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
