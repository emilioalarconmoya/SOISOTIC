Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_reporte_aportes
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As New CReporteAportes
    Dim objLookups As New Clookups
    Private objSessionCliente As CSession

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        
        If Not Page.IsPostBack Then
            If objSession.EsClienteIngresoCurso Then
                Me.hplIngresoCurso.Visible = True
            End If
            lblPie.Text = Parametros.p_PIE
            objWeb.SeteaGrilla(grdResultados, TAM_PAG)
            Me.CalFechaInicio.SelectedValue = "01/01/" & objSession.Agno
            Me.CalFechaFin.SelectedValue = "31/12/" & objSession.Agno
            'Consultar()   
            objWeb = New CWeb
            objWeb.ChequeaCliente(objSessionCliente)
            If Not objSessionCliente Is Nothing Then
                Consultar()
            End If
        End If
        
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Private Sub Consultar()
        Try
            'Validaciones
            If Not IsDate(CalFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio');")
                Exit Sub
            ElseIf Not EsFechaValidaVB(CalFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            If Not IsDate(CalFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de fin');")
                Exit Sub
            ElseIf Not EsFechaValidaVB(CalFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            Dim dias As Integer
            dias = DateDiff(DateInterval.Day, FechaUsrAVb(Me.CalFechaInicio.SelectedValue), FechaUsrAVb(Me.CalFechaFin.SelectedValue))
            If dias < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio valida');")
                Exit Sub
            End If
            objWeb = New CWeb
            objWeb.ChequeaCliente(objSessionCliente)
            objReporte.RutCliente = objSessionCliente.Rut 'Me.txtRutCliente.Text
            objReporte.Estados = objReporte.Estados  'Me.txtEstado.Text
            'objReporte.FechaIni = "" 'Me.txtFechaIni.Text
            objReporte.RutEmp = objSessionCliente.Rut
            objReporte.InfoConsolidada = objSession.InfoConsolidada
            objReporte.CodCuenta = objReporte.CodCuenta
            objReporte.NombreEmpresa = objSessionCliente.RazonSocial   'Me.txtNombreEmpresa.Text
            objReporte.CondRutEmp = objSessionCliente.Rut
            objReporte.FechaIni = FechaUsrAVb(Me.CalFechaInicio.SelectedValue)
            objReporte.FechaFin = FechaUsrAVb(Me.CalFechaFin.SelectedValue) 'Me.TxtCondRutEmp.Text
            objReporte.BajarXml = ChkBajar.Checked
            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)
      

            'consulta y llenado grilla
            objWeb.SeteaGrilla(grdResultados, 20)
            If ChkBajar.Checked And objReporte.Filas > 0 Then
                HplkBajarArchivo.Target = "_Blank"
                HplkBajarArchivo.Text = "Descargar archivo"
                HplkBajarArchivo.NavigateUrl = objReporte.ArchivoXml
                Me.HplkBajarArchivo.Visible = True
            End If
        Catch ex As Exception
            EnviaError("reporte_aporte.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            grdResultados.PageIndex = e.NewPageIndex
            Consultar()
        End If
    End Sub
    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound

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
            'HiperLink ficha alumno
            Dim hdf As HiddenField
            hdf = CType(e.Row.FindControl("hdfCodAporte"), HiddenField)
            Dim hdf1 As HiddenField
            hdf1 = CType(e.Row.FindControl("hdfRutCliente"), HiddenField)
            Dim hpl As HyperLink
            hpl = CType(e.Row.FindControl("hplAporte"), HyperLink)
            hpl.NavigateUrl = "ficha_aporte_ingresado.aspx?codAporte=" & hdf.Value & "&rutCliente=" & hdf1.Value

            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblMontoTotal"), Label)
            If lbl1.Text = "" Then
                lbl1.Text = 0
            Else
                lbl1.Text = Replace(lbl1.Text, "$", "")
            End If
            lbl1.Text = FormatoPeso(lbl1.Text)

            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblAporteNeto"), Label)
            If lbl2.Text = "" Then
                lbl2.Text = 0
            Else
                lbl2.Text = Replace(lbl2.Text, "$", "")
            End If
            lbl2.Text = FormatoPeso(lbl2.Text)

            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblAdministracion"), Label)
            If lbl3.Text = "" Then
                lbl3.Text = 0
            Else
                lbl3.Text = Replace(lbl3.Text, "$", "")
            End If
            lbl3.Text = FormatoPeso(lbl3.Text)
            'Dim lbl4 As Label
            'Dim i As Integer
            'lbl4 = CType(e.Row.FindControl("lblNombre"), Label)
            'If lbl4.Text = "Anulado" Then
            '    e.Row.Cells.Item(i).Visible = False
            'End If

            'Dim i As Integer
            'If e.Row.Cells.Item(i).Text = "Anulado" Then
            '    e.Row.Cells.Item(i).Visible = False
            'End If
            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("lblFecha"), Label)
            If lbl5.Text = "" Then
                lbl5.Text = FechaMinSistema()
            Else
                lbl5.Text = FechaVbAUsr(lbl5.Text)
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then 'Si es el pie
            e.Row.Cells(1).Text = "Total Período :"
            e.Row.Cells(1).ForeColor = Drawing.Color.White
            e.Row.Cells(1).BackColor = Drawing.Color.Gray
            e.Row.Cells(2).Text = "$" & FormatoMonto(objReporte.TotalAporteNeto)
            e.Row.Cells(2).ForeColor = Drawing.Color.White
            e.Row.Cells(2).BackColor = Drawing.Color.Gray
            e.Row.Cells(3).Text = "$" & FormatoMonto(objReporte.TotalAdministracion)
            e.Row.Cells(3).ForeColor = Drawing.Color.White
            e.Row.Cells(3).BackColor = Drawing.Color.Gray
            e.Row.Cells(4).Text = "$" & FormatoMonto(objReporte.TotalAporteTotal)
            e.Row.Cells(4).ForeColor = Drawing.Color.White
            e.Row.Cells(4).BackColor = Drawing.Color.Gray
        End If
        'Dim row As System.Data.DataRowView = e.Row.DataItem
        'Catch ex As Exception
        '    EnviaError("reporte_actividad_uso.aspx-> grdResultados_RowDataBound" & ex.Message)
        'End Try
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(Cabecera2.FindControl("txtRutEmpresa"), TextBox).Text
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
End Class
