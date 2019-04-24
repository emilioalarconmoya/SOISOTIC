<%@ Page Language="VB" AutoEventWireup="false" CodeFile="aviso_inscripcion_de_cursos.aspx.vb" Inherits="modulo_aporte_aviso_inscripcion_de_cursos" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>Aviso de inscripcion de cursos</title>
     <link href="../estilo.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" >
        function Imprimir()
        {
            window.print();
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">    
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
    <div id="cabecera">
        <table id="tabladt" class="TablaInterior">
            <tr>
                <th width="980px" class="TituloGrupo" valign="top">
                    <asp:Label ID="Label1" runat="server" Text="Aviso de inscripcion de curso"></asp:Label>
                </th>                            
            </tr>
         </table>
        <table style="width: 980px;" cellpadding="0" cellspacing="0" id="tablaPeriodoActual">
            <tr>
                <td class="AlineacionIzquierda" colspan="2" style="width: 391px; height: 15px;">
                    &nbsp;<asp:Label ID="Label30" runat="server" Text="Sr(a)."></asp:Label>
                    <asp:Label ID="lblContacto" runat="server"></asp:Label>
                </td>
                <td class="AlineacionIzquierda" colspan="3" style="width: 200px; height: 15px;">
                    <asp:Label ID="lblFehca" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" style="height: 15px; width: 391px;" colspan="2">
                    <asp:Label ID="lblCargo" runat="server"></asp:Label>
                </td>
                <td class="AlineacionIzquierda" style="height: 15px;" colspan="3">
                    <asp:Label ID="Label35" runat="server" Text="Correlativo:"></asp:Label>
                    <asp:Label ID="lblCorrelativo1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="2" style="width: 391px; height: 12px">
                    <asp:Label ID="lblRazonSocial" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td class="AlineacionIzquierda" colspan="3" style="width: 40px; height: 12px">
                    <asp:Label ID="Label31" runat="server" Text="Correlativo Empresa:" Width="96px"></asp:Label>
                    <asp:Label ID="lblCorrelativoEmp" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="6" style="height: 12px; width: 29%;">
                    <hr style="width: 100%" />
                </td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="6" style="height: 12px">
                    &nbsp;<asp:Label ID="Label8" runat="server" Text="De mi consideración:" Font-Bold="True" Font-Size="X-Small" ForeColor="Black"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="6" style="height: 12px">
                    &nbsp;<asp:Label ID="Label10" runat="server" Text="A través del presente documento informo a usted que de acuerdo a sus instrucciones, hemos contratado para su empresa el curso que se detalla a continuación:" Font-Bold="True" Font-Size="X-Small" ForeColor="Black"></asp:Label></td>
            </tr>
            <tr>
                <td class="AlineacionIzquierda" colspan="6" style="height: 12px">
                </td>
            </tr>
        </table>
    </div>
    <div id="contenido">
        <div id="resultados">
            <div id="tablas" style="width: 976px; height: 320px;">
            <div class="AvisoDatosIzq" style="width: 504px" >
                <table  cellpadding="0" cellspacing="0" style="width:504px;" class="Grid"  >
                    <tr>
                        <th class="TituloIzquierda" colspan="2" style="height: 29px">
                            <asp:Label ID="Label14" runat="server" Text="Datos del Curso"></asp:Label>
                            &nbsp;</th>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            <asp:Label ID="Lbl" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                        <td class="AlineacionIzquierda">
                            <asp:Label ID="LblNombreCurso" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            <asp:Label ID="Label3" runat="server" Text="Correlativo:"></asp:Label>
                            </td>
                        <td class="AlineacionIzquierda">
                            <asp:Label ID="lblCorrelativo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Label27" runat="server" Text="Fecha de Inicio: "></asp:Label></td>
                        <td class="AlineacionIzquierda">
                            <asp:Label ID="lblCUfechaInicio" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Label29" runat="server" Text="Fecha Término: "></asp:Label></td>
                        <td class="AlineacionIzquierda">
                            &nbsp;<asp:Label ID="lblCUfechaTermino" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Label7" runat="server" Text="Duración:"></asp:Label></td>
                        <td class="AlineacionIzquierda">
                            <asp:Label ID="LblDuracion" runat="server"></asp:Label>
                             <asp:Label ID="Label34" runat="server" Text="hrs. (0 hrs. complementarias)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Label6" runat="server" Text="Codigo Sence:"></asp:Label></td>
                        <td class="AlineacionIzquierda">
                            <asp:Label ID="LblCodigoSence" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Label9" runat="server" Text="Organismo ejecutor:"></asp:Label></td>
                        <td class="AlineacionIzquierda">
                            <asp:Label ID="LblorganismoEjecutor" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Lbl2" runat="server" Text="Total participantes:"></asp:Label></td>
                         <td class="AlineacionIzquierda">
                            <asp:Label ID="LblTotalParticipantes" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Label32" runat="server" Text="Comité Bibartito:"></asp:Label></td>
                         <td class="AlineacionIzquierda">
                             &nbsp;<asp:Label ID="LblComite" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            &nbsp;<asp:Label ID="Label11" runat="server" Text="Lugar de ejecución: "></asp:Label></td>
                         <td class="AlineacionIzquierda">
                            <asp:Label ID="lblCUdireccion" runat="server"></asp:Label>
                            <asp:Label ID="lblCUnumero" runat="server"></asp:Label>

                            <asp:Label ID="lblCUciudad" runat="server"></asp:Label>
                            <asp:Label ID="Label26" runat="server" Text="("></asp:Label>
                            <asp:Label ID="lblCUcomuna" runat="server"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblCUregion" runat="server"></asp:Label>
                            <asp:Label ID="Label28" runat="server" Text=")"></asp:Label></td>
                    </tr>
                     <tr>
                        <td class="AlineacionIzquierda" style="width: 98px; height: 18px;">
                            <asp:Label ID="Label4" runat="server" Text="Nro Registro Sence:"></asp:Label>
                            </td>
                         <td class="AlineacionIzquierda">
                            <asp:Label ID="LblRegistroSence" runat="server"></asp:Label></td>
                    </tr>    
              </table>     
            </div>
            <div class="AvisoDatosDer">
                <table cellpadding="0" cellspacing="0" class="Grid" style="width:464px ; height: 312px;">
                    <tr>
                        <th colspan="2" >
                            <asp:Label ID="Label83" runat="server" Text="Valores Asociados"></asp:Label></th>
                    </tr>
                    <tr>
                        <td colspan="" style="width:36% " class="AlineacionIzquierda">
                            <asp:Label ID="Label12" runat="server" Text="Valor Curso:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%">
                            <asp:Label ID="LblValorCurso" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" colspan=""style="width:36% " class="AlineacionIzquierda">
                            &nbsp;<asp:Label ID="Label13" runat="server" Text="Costo OTIC:"></asp:Label></td>
                        <td align="left" class="AlineacionIzquierda" colspan="" style="width: 100%">
                            <asp:Label ID="LblCostoOtic" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td  colspan=""style="width:36% ; height: 19px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label15" runat="server" Text="Costo OTIC complemento:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%; height: 19px">
                            <asp:Label ID="LblCostoOticCom" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td  colspan="" style="width:36% ; height: 19px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label16" runat="server" Text="Costo empresa:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%; height: 19px">
                            <asp:Label ID="LblCostoEmp" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td  colspan="" style="width:36% " class="AlineacionIzquierda">
                            <asp:Label ID="Label17" runat="server" Text="Total V&T &#9;"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%">
                            <asp:Label ID="LblTotalVyT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="" style="width: 36%; height: 19px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label18" runat="server" Text="Costo Otic V&T:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%; height: 19px">
                            <asp:Label ID="LblCostoOticVyT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="" style="width: 36%" class="AlineacionIzquierda">
                            <asp:Label ID="Label19" runat="server" Text="Costo Empresa V&T:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%">
                            <asp:Label ID="LblCostoEmpVyT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <th  colspan="2" align="center">
                        <asp:Label ID="Label5" runat="server" Text="Cargos"></asp:Label>
                          </th>
                    </tr>
                    <tr>
                        <td  colspan="" style="width:36% ; height: 19px;" class="AlineacionIzquierda">
                            <asp:Label ID="Label20" runat="server" Text="Cuenta de capacitación:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%; height: 19px">
                            <asp:Label ID="LblCuentaCapa" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="" style="width: 36%">
                            <asp:Label ID="Label22" runat="server" Text="Excedente de capacitación:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%">
                            <asp:Label ID="LblExDeCap" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td  colspan="" style="width:36% " class="AlineacionIzquierda">
                            <asp:Label ID="Label21" runat="server" Text="Becas de capacitación:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%">
                            <asp:Label ID="LblBecasDeCapa" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionIzquierda" colspan="" style="width: 36%">
                            <asp:Label ID="Label23" runat="server" Text="Cuentas de terceros:"></asp:Label></td>
                        <td class="AlineacionIzquierda" colspan="" style="width: 100%">
                            <asp:Label ID="LblCuentasDeTerceros" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="AlineacionDerecha" colspan="2">
                            <asp:Label ID="Label24" runat="server" Text="* Incluyen Viático y Traslado."></asp:Label></td>
                    </tr>
                </table>
           </div>
            
           </div>
            <div class= "AlineacionIzquierda" >
                <asp:Label ID="Label25" runat="server" Text="En la siguiente tabla se presenta el listado de alumnos que se inscribieron en el curso, de acuerdo a la información proporcionada por usted:" Font-Bold="True" Font-Size="X-Small" ForeColor="Black"></asp:Label>
            </div>
          <div >
              <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" Width="976px">
                  <Columns>
                      <asp:TemplateField HeaderText="Listado de Alumnos">
                          <EditItemTemplate>
                              &nbsp;
                          </EditItemTemplate>
                          <ItemTemplate>
                              &nbsp;<table class="TablaInterior">
                                  <tr>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label36" runat="server" Text="Rut:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="lblRutAlumno" runat="server" Text='<%# bind("rut_alumno") %>'></asp:Label></td>
                                      <td rowspan="3" style="width: 100px">
                                      </td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label49" runat="server" Text="Franq:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblFranq" runat="server" Text='<%# Bind("porc_franquicia") %>'></asp:Label>
                                          <asp:Label ID="Label39" runat="server" Text="%"></asp:Label></td>
                                      <td rowspan="3" style="width: 100px">
                                      </td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label40" runat="server" Text="Costo Otic:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblCostoOtic" runat="server" Text='<%# Bind("costo_otic") %>'></asp:Label></td>
                                      <td rowspan="3" style="width: 100px">
                                      </td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label43" runat="server" Text="Viatico:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblViatico" runat="server" Text='<%# Bind("viatico") %>'></asp:Label></td>
                                      <td rowspan="3" style="width: 100px">
                                      </td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblNivelEdu" runat="server" Text="Nivel Educ:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblNvEdu" runat="server" Text='<%# Bind("nivel_educacional") %>'></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td class="AlineacionIzquierda" colspan="2">
                                          <asp:Label ID="LblNombreCom" runat="server" Text='<%# bind("nombre_completo") %>'></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label38" runat="server" Text="Sexo:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblSexo" runat="server" Text='<%# bind("sexo") %>'></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label41" runat="server" Text="Costo Emp:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblCostoEmp" runat="server" Text='<%# Bind("gasto_empresa") %>'></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label44" runat="server" Text="Traslado:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblTraslado" runat="server" Text='<%# bind("traslado") %>'></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label46" runat="server" Text="Nivel Prof:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblNivelProf" runat="server" Text='<%# Bind("nivel_ocupacional") %>'></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td colspan="2">
                                      </td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label37" runat="server" Text="Fecha Nac:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblFechaNac" runat="server" Text='<%# Bind("fecha_nacim") %>'></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label42" runat="server" Text="Total:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblTotal" runat="server" Text='<%# bind("total") %>'></asp:Label></td>
                                      <td class="AlineacionIzquierda" colspan="2">
                                      </td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="Label47" runat="server" Text="Origen:"></asp:Label></td>
                                      <td class="AlineacionIzquierda" style="width: 100px">
                                          <asp:Label ID="LblOrigen" runat="server" Text='<%# bind("cod_comuna") %>'></asp:Label></td>
                                  </tr>
                              </table>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                      <table>
                          <tr>
                              <td>
                                  <asp:Label ID="Label33" runat="server" Text="Rut:"></asp:Label></td>
                              <td style="width: 100px">
                              </td>
                          </tr>
                          <tr>
                              <td colspan="2">
                              </td>
                          </tr>
                      </table>
                  </EmptyDataTemplate>
              </asp:GridView>
             <div class="AlineacionIzquierda">
                 <asp:Label ID="Label45" runat="server" Text="Quedando a su entera disposición para aclarar cualquier duda," Font-Bold="True" Font-Size="X-Small" ForeColor="Black"></asp:Label>
             </div>
             <div class="AlineacionIzquierda">
                 <asp:Label ID="Label48" runat="server" Text="Saluda atentamente a usted." Font-Bold="True" Font-Size="X-Small" ForeColor="Black"></asp:Label>
             </div>
             
          </div>
                <div id="botones" >
                    <br />
                          <asp:Button ID="btnVolver" runat="server" Text="Volver" />
                          <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
                </div>
         
         </div></div></div>
        <div id="pie">
            <div class="textoPie" >
                <asp:Label ID="lblPie"  runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>