<%@ Page Language="VB" AutoEventWireup="false" CodeFile="comunicar_curso_sence_csv.aspx.vb" Inherits="modulo_administracion_comunicar_curso_sence_csv" %>
<%@ Register Src="~/contenido/ascx/cabeceraUsuario.ascx" TagName="cabeceraUsuario" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Comunicar cursos Sence</title>
    <link href="../estilo.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../include/js/FusionCharts.js"></script>  
</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <div id="contenedor">
    <div id="bannner">
        <img src="../include/imagenes/css/fondos/reporte01.jpg" alt="Otichile" title="Cabecera Otichile"/>
        <uc3:cabeceraUsuario ID="datos_personales1" runat="server" />
    </div>
    <div id="menu" runat="server">
        <div id="header">
            <ul >
                <li >
                    <asp:HyperLink ID="hplMenúPrincipal" runat="server" NavigateUrl="~/modulo_administracion/menu_administracion.aspx" Visible="false" ><b>Menú Administración</b></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplSalir" runat="server" NavigateUrl="../fin_sesion.aspx" Visible="false" ><b>Salir</b></asp:HyperLink>
                </li>
            </ul>
        </div>   
    </div>
        <div id="Cabecera">
            
        </div>        
        <div id="contenido">            
            <div id="resultados">
                <div id="Comunicacion" runat="server">
                    <div class="paso1">
                        <asp:Label ID="Label1" runat="server" Text="1.-"></asp:Label>
                        <asp:LinkButton ID="LinkButton1" runat="server">Bajar archivo para comunicación Batch.</asp:LinkButton>
                    </div>
                    <div class="paso2">
                        <asp:Label ID="Label2" runat="server" Text="2.-"></asp:Label>
                        <asp:LinkButton ID="hplPaso2" runat="server">Respaldar Archivo con lista de acciones</asp:LinkButton></div>
                    <div class="paso3">
                        <asp:Label ID="Label3" runat="server" Text="3.-"></asp:Label>
                        <asp:HyperLink ID="hplPaso3" runat="server" NavigateUrl="http://www2.sence.cl/otic.htm" Target="_blank">Conectarse al sence</asp:HyperLink>
                    </div>
                    <div class="paso4">
                        <asp:Label ID="Label4" runat="server" Text="4.-"></asp:Label>
                        <asp:Label ID="lblPaso4" runat="server" Text="Enviar Archivo de Respuesta '.txt'"></asp:Label>
                        <asp:FileUpload ID="fulRespuesta" runat="server" />
                        <asp:Button ID="btnComunicar" runat="server" Text="Comunicar" />&nbsp;<br />
                        <br />
                        <div class="AlineacionCentro">
                            &nbsp;</div>
                    </div>
                </div>
                &nbsp;
                <br />
                <br />
                <div>
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" /></div>
                <br />
                <div id="Div1" runat="server">
                    <asp:GridView ID="grdResultados" runat="server" AutoGenerateColumns="False" CssClass="Grid" HorizontalAlign="Center" Width="820px">
                        <Columns>
                            <asp:TemplateField HeaderText="Folio">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hplFolio" runat="server" Text='<%# bind("folio") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="60px" />
                                <ItemStyle VerticalAlign="Top" Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Empresa, Curso y OTEC">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text="Emp.: "></asp:Label>
                                    <asp:HyperLink ID="hplEmpresa" runat="server" Text='<%# bind("empresa") %>'></asp:HyperLink><br />
                                    <asp:Label ID="Label6" runat="server" Text="Curso: "></asp:Label>
                                    <asp:HyperLink ID="hplCurso" runat="server" Text='<%# bind("curso") %>'></asp:HyperLink><br />
                                    <asp:Label ID="Label7" runat="server" Text="Otec: "></asp:Label>
                                    <asp:HyperLink ID="hplOtec" runat="server" Text='<%# bind("otec") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Width="300px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="300px" CssClass="AlineacionIzquierda" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Datos curso">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text="Alumnos:"></asp:Label>
                                    <asp:Label ID="lblAlumnos" runat="server" Text='<%# Bind("alumnos") %>'></asp:Label><br />
                                    <asp:Label ID="Label10" runat="server" Text="Inicio:"></asp:Label>
                                    <asp:Label ID="lblInicio" runat="server" Text='<%# bind("inicio") %>'></asp:Label><br />
                                    <asp:Label ID="Label12" runat="server" Text="Fin:"></asp:Label>
                                    <asp:Label ID="lblFin" runat="server" Text='<%# bind("fin") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="150px" CssClass="AlineacionIzquierda" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado Curso">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("strEstadoCurso") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="300px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="300px" CssClass="AlineacionIzquierda" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table cellpadding="0" cellspacing="0" class="Grid" width="820" id="tblErrores" runat="server" visible="false">
                        <tr>
                            <th style="width: 100%">
                                <asp:Label ID="Label9" runat="server" Text="Errores encontrados :"></asp:Label>
                                <asp:Label ID="lblNumErrores" runat="server" Text=""></asp:Label>
                            </th>
                        </tr>
                    </table>
                    <asp:GridView ID="grdErrores" runat="server" CssClass="grid" Width="820px" AutoGenerateColumns="False"  visible="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Detalle error">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetalleError" runat="server" Text='<%# Bind("log") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                </div> 
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
