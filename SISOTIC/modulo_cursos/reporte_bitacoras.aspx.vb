Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_reporte_bitacoras
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objBitacora As CReporteBitacora
    Dim objReporte As New CFichaCursoContratado
    Dim objFacura As New CReporteFactura
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("CodCurso") = Request("codCurso")
                ViewState("Tipo") = Request("tipo")
                ViewState("Estado") = Request("estado")
                ViewState("Agno") = Request("Agno")

                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                objWeb.SeteaGrilla(grdResultados, 50)
                Me.calFechaInicial.SelectedValue = "01/01/" & objSession.Agno - 1
                'Me.calFechaFinal.SelectedValue = "31/12/" & objSession.Agno
                Me.calFechaFinal.SelectedValue = Now.Date
                Consultar()
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("reporte_bitacoras:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Dim lngTipo As Long
        Dim lngCodCurso As Long
        lngCodCurso = ViewState("CodCurso")
        lngTipo = ViewState("Tipo")
        objReporte = New CFichaCursoContratado
        objReporte.CodCurso = lngCodCurso
        objReporte.RutCliente = objSession.Rut
        objReporte.Agno = objSession.Agno
        objReporte.Consultar()
        Me.lblCorrelativo.Text = objReporte.Correlativo
        Me.lblCorrelEmp.Text = objReporte.CorrEmpresa
        Me.lblFecha.Text = FechaVbAUsr(objReporte.FechaModificacion)
        If Trim(objReporte.CodOrigen) = "0" Then
            lblOrigen.Text = "Interno"
        ElseIf Trim(objReporte.CodOrigen) = "1" Then
            lblOrigen.Text = "Cliente"
        Else
            lblOrigen.Text = "--"
        End If
        If objReporte.NroRegistro <> "-1" Then
            Me.lblRegSence.Text = objReporte.NroRegistro
        Else
            Me.lblRegSence.Text = "--"
        End If
        Me.lblFechIngreso.Text = objReporte.FechaIngreso
        Me.lblRegSenCompl.Text = "--"
        Me.lblEstado.Text = ViewState("Estado")

        'CABECERA FACTURA
        If ViewState("Tipo") = 3 Then
            objFacura = New CReporteFactura
            objFacura.CodEstadoFactura = ViewState("Estado")
            objFacura.RutUsuario = objSession.Rut
            'objFacura.Agno = objSession.Agno
            objFacura.Agno = Request("Agno")
            objFacura.CodCurso = ViewState("CodCurso")

            objFacura.Consultar2()


            Me.lblCorrelativoFactura.Text = objReporte.Correlativo
            Me.lblNombreOtec.Text = objReporte.NombreOtec
            Me.lblEstadoFactura.Text = objFacura.EstadoFac
            Me.lblFechaFactura.Text = objFacura.FechaFactura
            Me.lblNumFactura.Text = objFacura.NumFactura
            Me.lblMontoFactura.Text = FormatoPeso(objFacura.MontoFactura)
        End If
        'FIN CABECERA

        If ViewState("Tipo") = 1 Then
            Me.tbBitacoraCurso.Visible = True
        End If
        If ViewState("Tipo") = 3 Then
            Me.tbBitacoraFactura.Visible = True
        End If

        objBitacora = New CReporteBitacora
        objBitacora.FechaInicio = calFechaInicial.SelectedValue
        objBitacora.FechaTermino = calFechaFinal.SelectedValue
        objBitacora.TipoReferencia = lngTipo
        objBitacora.RutUsuario = 0 'Esto no es un error, consulta por todos los ruts
        objBitacora.CodCurso = lngCodCurso
        Dim dt As New DataTable
        dt = objBitacora.Consultar()
        objWeb.LlenaGrilla(grdResultados, dt)
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            grdResultados.PageIndex = e.NewPageIndex
            Consultar()
        End If
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

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
        Catch ex As Exception
            EnviaError("reporte_bitacoras:grdResultados_RowDataBound-->" & ex.Message)
        End Try
    End Sub
End Class
