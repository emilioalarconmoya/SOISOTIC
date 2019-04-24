Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_reporte_vyt
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objVyT As New CReporteVyT
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
            objWeb.SeteaGrilla(grdResultadosVyT, 50)
            Me.CalFechaInicio.SelectedValue = "01/01/" & objSession.Agno
            Me.CalFechaFin.SelectedValue = "31/12/" & objSession.Agno
            '******Popoup*************
            Dim btn As New Button
            btn = CType(Cabecera1.FindControl("btnPopUpEmpresa"), Button)
            Dim txt As New TextBox
            txt = CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox)
            btn.Attributes.Add("onclick", "popup_pos('../modulo_cursos/buscador_empresas.aspx?campo=Cabecera1$txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            'Consultar()
        End If
        objWeb = New CWeb
        objWeb.ChequeaCliente(objSessionCliente)
        If Not objSessionCliente Is Nothing Then
            Consultar()
        End If
        body.Attributes.Clear()
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
            objVyT.FechaInicio = CalFechaInicio.SelectedValue
            objVyT.FechaFin = CalFechaFin.SelectedValue
            objVyT.RutCliente = objSessionCliente.Rut ' objSession.Rut
            objVyT.BajarXml = ChkBajar.Checked
            objVyT.InfoConsolidada = objSession.InfoConsolidada
            lblFecha.Text = objVyT.FechaInicio
            lblSaldo.Text = objVyT.Saldo
            lblSaldo.Text = FormatoPeso(lblSaldo.Text)
            Dim dt As DataTable
            dt = objVyT.Consultar()
            If dt Is Nothing Then
                trDetalle.Visible = False
            Else
                If dt.Rows.Count <= 0 Then
                    trDetalle.Visible = False
                End If
            End If
            objWeb.LlenaGrilla(grdResultadosVyT, dt)
            If dt Is Nothing Then
                tablaVyT.Visible = False
            Else
                tablaVyT.Visible = True
            End If
            'verifica chequeo para bajar reporte
            If ChkBajar.Checked And objVyT.Filas > 0 Then
                HplkBajarArchivo.Target = "_Blank"
                HplkBajarArchivo.Text = "Descargar archivo"
                HplkBajarArchivo.NavigateUrl = objVyT.ArchivoXml
                Me.HplkBajarArchivo.Visible = True
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas_reporte_vyt.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultadosVyT.PageIndexChanging
        grdResultadosVyT.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultadosVyT.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hdf As HiddenField
            hdf = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
            Dim hpl As HyperLink
            hpl = CType(e.Row.FindControl("hplCurso"), HyperLink)
            hpl.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & hdf.Value

            Dim lbl As Label
            lbl = CType(e.Row.FindControl("lblFechaInicio"), Label)
            lbl.Text = FechaVbAUsr(lbl.Text)

            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblViatico"), Label)
            If lbl1.Text = "" Then
                lbl1.Text = 0
            Else
                lbl1.Text = Replace(lbl1.Text, "$", "")
            End If
            lbl1.Text = FormatoPeso(lbl1.Text)

            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblTraslado"), Label)
            If lbl2.Text = "" Then
                lbl2.Text = 0
            Else
                lbl2.Text = Replace(lbl2.Text, "$", "")
            End If
            lbl2.Text = FormatoPeso(lbl2.Text)

            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblSaldo"), Label)
            If lbl3.Text = "" Then
                lbl3.Text = 0
            Else
                lbl3.Text = Replace(lbl3.Text, "$", "")
            End If
            lbl3.Text = FormatoPeso(lbl3.Text)
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            'Footer
            Dim lbl4 As Label
            lbl4 = CType(e.Row.FindControl("lblTotalViatico"), Label)
            lbl4.Text = FormatoPeso(objVyT.TotalViat)

            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("lblTotalTraslado"), Label)
            lbl5.Text = FormatoPeso(objVyT.TotalTras)

            Dim lbl6 As Label
            lbl6 = CType(e.Row.FindControl("lblSaldoTotal"), Label)
            lbl6.Text = FormatoPeso(objVyT.Saldo)
        End If
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text
    End Sub
End Class

