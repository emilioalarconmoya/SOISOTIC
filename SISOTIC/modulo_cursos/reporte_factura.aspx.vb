Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_reporte_factura
    Inherits System.Web.UI.Page
    Public KeyAscii As Short
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objReporte As New CReporteFactura
    Dim objOtec As New COtec
    Dim objCSql As New CSql
    Dim objCCambioEstados As New CCambioEstados
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                
                ViewState("RutCliente") = 0
                'ViewState("Agno") = objSession.Agno 'Request("Agno")
                Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
                lblPie.Text = Parametros.p_PIE
                Dim lngRut As Long
                lngRut = objSession.Rut
                objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
                ddlAgnos.SelectedValue = objSession.Agno
                objWeb.LlenaDDL(ddlEstadofactura, objLookups.EstadoFactura, "cod_estado_fact", "nombre")
                objWeb.AgregaValorDDL(ddlEstadofactura, "Todas", "0")
                ddlEstadofactura.SelectedValue = 0
                objWeb.SeteaGrilla(grdResultados, 50)

                ' Consultar()

            End If
            ViewState("RutCliente") = objSession.Rut

        Catch ex As Exception
            EnviaError("modulo_cursos_reporte_factura:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objReporte = New CReporteFactura
            ' objReporte.RutCliente = RutUsrALng(Me.txtNumFactura.Text)
            'objReporte.Agno = 2005
            objReporte.RutUsuario = ViewState("RutCliente")
            objReporte.CodEstadoFactura = ddlEstadofactura.SelectedValue
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = chkBajarReporte.Checked
            If Me.txtNumFactura.Text = "" Then
                objReporte.NumFactura = 0
            Else
                objReporte.NumFactura = Me.txtNumFactura.Text
            End If
            If Me.txtRutEmpresa.Text = "" Then
                objReporte.RutEmpresa = 0
            Else
                objReporte.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text)
            End If
            If Me.txtRutOtec.Text = "" Then
                objReporte.RutOtec = 0
            Else
                objReporte.RutOtec = RutUsrALng(Me.txtRutOtec.Text)
            End If


            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)

            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporte.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If

        Catch ex As Exception
            EnviaError("modulo_cursos_reporte_factura.aspx.vb:Consultar->" & ex.Message)
        End Try


    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            grdResultados.PageIndex = e.NewPageIndex
            Consultar()
        End If
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Pager AndAlso Not grdResultados.DataSource Is Nothing Then
                'TRAE EL TOTAL DE PAGINAS
                Dim _TotalPags As Label = e.Row.FindControl("lblTotalNumberOfPages")
                _TotalPags.Text = grdResultados.PageCount.ToString

                'LLENA LA LISTA CON EL NUMERO DE PAGINAS
                Dim list As DropDownList = e.Row.FindControl("paginasDropDownList")
                For i As Integer = 1 To CInt(grdResultados.PageCount)
                    Dim it As ListItem
                    Dim Existe As Boolean = False
                    For Each it In list.Items
                        If it.Text = i.ToString Then
                            Existe = True
                        End If
                    Next
                    If Not Existe Then
                        list.Items.Add(i.ToString)
                    End If
                Next
                list.SelectedValue = grdResultados.PageIndex + 1
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim lngMonto As Long
                Dim strFecha As String
                'HiddenField
                Dim hdf1 As New HiddenField
                hdf1 = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
                Dim hdf2 As New HiddenField
                hdf2 = CType(e.Row.FindControl("hdfNumPerfil"), HiddenField)
                Dim hdf3 As New HiddenField
                hdf3 = CType(e.Row.FindControl("hdfCodSence"), HiddenField)
                Dim hdf4 As New HiddenField
                hdf4 = CType(e.Row.FindControl("hdfRutOtec"), HiddenField)
                Dim hdf5 As New HiddenField
                hdf5 = CType(e.Row.FindControl("hdfCodEstadoFactura"), HiddenField)
                Dim hdf6 As New HiddenField
                hdf6 = CType(e.Row.FindControl("hdfRutCliente"), HiddenField)
                Dim hdf7 As New HiddenField
                hdf7 = CType(e.Row.FindControl("hdfNumFactura"), HiddenField)

                'label
                Dim lbl1 As New Label
                lbl1 = CType(e.Row.FindControl("lblMontoFactura"), Label)
                If lbl1.Text = "" Then
                    lbl1.Text = 0
                Else
                    lbl1.Text = Replace(lbl1.Text, "$", "")
                End If
                lbl1.Text = FormatoPeso(lbl1.Text)


                Dim lbl2 As New Label
                lbl2 = CType(e.Row.FindControl("lblFechaEmision"), Label)
                lbl2.Text = FechaVbAUsr(lbl2.Text)
                Dim lbl3 As New Label
                lbl3 = CType(e.Row.FindControl("lblFechaRecepcion"), Label)
                lbl3.Text = FechaVbAUsr(lbl3.Text)
                Dim lbl4 As New Label
                lbl4 = CType(e.Row.FindControl("lblFechaPago"), Label)
                lbl4.Text = FechaVbAUsr(lbl4.Text)
                Dim lbl5 As New Label
                lbl5 = CType(e.Row.FindControl("lblFechInicio"), Label)
                lbl5.Text = FechaVbAUsr(lbl5.Text)
                Dim lbl6 As New Label
                lbl6 = CType(e.Row.FindControl("lblFechFin"), Label)
                lbl6.Text = FechaVbAUsr(lbl6.Text)
                Dim hdfCodEstadoFactura As HiddenField
                hdfCodEstadoFactura = CType(e.Row.FindControl("hdfCodEstadoFactura"), HiddenField)







                Dim hplEstado As HyperLink
                hplEstado = CType(e.Row.FindControl("hplEstado"), HyperLink)
                hplEstado.NavigateUrl = "reporte_bitacoras.aspx?codCurso=" & hdf1.Value & "&tipo=3" & "&estado=" & hdfCodEstadoFactura.Value

                Dim hpl1 As New HyperLink
                hpl1 = CType(e.Row.FindControl("hplCorrelativo"), HyperLink)
                hpl1.NavigateUrl = "ficha_curso_contratado.aspx?CodCurso=" & hdf1.Value

                Dim hpl2 As New HyperLink
                hpl2 = CType(e.Row.FindControl("hplEmpresa"), HyperLink)
                hpl2.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & hdf6.Value & "&NumPerfil=" & hdf2.Value 'FICHA EMPRESA
                Dim hpl3 As New HyperLink
                hpl3 = CType(e.Row.FindControl("hplCurso"), HyperLink)
                hpl3.NavigateUrl = "ficha_curso_sence.aspx?CodSence=" & hdf3.Value  'FICHA CURSO SENCE
                Dim hpl4 As New HyperLink
                hpl4 = CType(e.Row.FindControl("hplOtec"), HyperLink)
                hpl4.NavigateUrl = "ficha_otec.aspx?rutOtec=" & hdf4.Value  'FICHA OTEC

                Dim hpl5 As New HyperLink
                hpl5 = CType(e.Row.FindControl("hplNumFactura"), HyperLink)
                hpl5.NavigateUrl = "mantenedor_factura.aspx?CodCurso=" & hdf1.Value & "&EstadosFacturas=" & hdf5.Value & "&NumFactura=" & hdf7.Value & "&Monto=" & lbl1.Text & "&FechaFactura=" & lbl2.Text & "&FechaRecepcion=" & lbl3.Text & "&FechaPago=" & lbl4.Text & "&Observaciones=&Agno=" & Me.ddlAgnos.SelectedValue
                'MANTENEDOR FACTURA"


                ' btnAnu.Attributes.Add("onclick", "return confirm('¿Está seguro de realizar esta operación?');")  '    OnClientClick=("onclick", "return confirm('¿Seguro de realizar operacion?');") 




            End If
        Catch ex As Exception
            EnviaError("modulo_cursos_reporte_factura.aspx.vb:grdResultados_RowDataBound->" & ex.Message)
        End Try
        
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()

    End Sub

    'Protected Sub txtNumFactura_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumFactura.TextChanged
    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    KeyAscii = CShort(SoloNumeros(KeyAscii))
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If

    'End Sub
    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Protected Sub GoPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oIraPag As DropDownList = DirectCast(sender, DropDownList)
        Dim iNumPag As Integer = 0
        If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultados.PageCount Then
            If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultados.PageCount Then
                grdResultados.PageIndex = iNumPag - 1
            Else
                grdResultados.PageIndex = 0
            End If
        End If
        Call Consultar()
    End Sub

  
End Class
