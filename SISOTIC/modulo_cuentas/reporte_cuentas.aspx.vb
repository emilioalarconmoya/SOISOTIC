Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_Reporte_Cuentas
    Inherits System.Web.UI.Page

    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As New CReporteCuentas
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
            objWeb.SeteaGrilla(grdResultados, 50)
            Me.CalFechaInicio.SelectedValue = "01/01/" & objSession.Agno
            Me.CalFechaFin.SelectedValue = "31/12/" & objSession.Agno
            '******Popoup*************
            'Dim btn As New Button
            'btn = CType(Cabecera1.FindControl("btnPopUpEmpresa"), Button)
            'Dim txt As New TextBox
            'txt = CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox)
            'btn.Attributes.Add("onclick", "popup_pos('../modulo_cursos/buscador_empresas.aspx?campo=Cabecera1$txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            'Consultar()
            objWeb.SeteaGrilla(Me.grdResultados, TAM_PAG)
        End If

        'objWeb = New CWeb
        objWeb.ChequeaCliente(objSessionCliente)
        If Not objSessionCliente Is Nothing Then
            Consultar()
        End If

        body.Attributes.Clear()
    End Sub

    Public Sub Consultar()
        Try
            If Not IsDate(CalFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio');")
                Exit Sub
            End If
            If Not EsFechaValidaVB(CalFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            If Not IsDate(CalFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de fin');")
                Exit Sub
            End If
            If Not EsFechaValidaVB(CalFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            Dim dias As Integer
            dias = DateDiff(DateInterval.Day, FechaUsrAVb(Me.CalFechaInicio.SelectedValue), FechaUsrAVb(Me.CalFechaFin.SelectedValue))
            If dias < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio valida');")
                Exit Sub
            End If
            'valida opcion seleccionada 
            objReporte.CodCuenta = ddlCuenta.SelectedValue
            If ddlCuenta.SelectedValue = 1 Then
                objReporte.CodCuenta = 1
                lblTipo.Text = "Capacitacion"
            ElseIf ddlCuenta.SelectedValue = 2 Then
                objReporte.CodCuenta = 2
                lblTipo.Text = "Reparto"
            ElseIf ddlCuenta.SelectedValue = 4 Then
                objReporte.CodCuenta = 4
                lblTipo.Text = "Excedente Capacitacion"
            ElseIf ddlCuenta.SelectedValue = 5 Then
                objReporte.CodCuenta = 5
                lblTipo.Text = "Excedente Reparto"
            ElseIf ddlCuenta.SelectedValue = 3 Then
                objReporte.CodCuenta = 3
                lblTipo.Text = "Administracion"
            ElseIf ddlCuenta.SelectedValue = 6 Then
                objReporte.CodCuenta = 6
                lblTipo.Text = "Becas"
            End If
            objReporte.RutUsuario = objSessionCliente.Rut ' objSession.Rut
            objReporte.FechaInicial = FechaUsrAVb(Me.CalFechaInicio.SelectedValue)
            objReporte.FechaFin = FechaUsrAVb(Me.CalFechaFin.SelectedValue)
            objReporte.BajarXml = Me.ChkBajar.Checked
            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdResultados, dt)
            objWeb = Nothing
            'verifica chequeo para bajar reporte
            If ChkBajar.Checked And objReporte.Filas > 0 Then
                HplkBajarArchivo.Target = "_Blank"
                HplkBajarArchivo.Text = "Descargar archivo"
                HplkBajarArchivo.NavigateUrl = objReporte.ArchivoXml
                HplkBajarArchivo.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlCuenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCuenta.SelectedIndexChanged
        Consultar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Consultar()
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
            Dim hdfTipo As HiddenField
            hdfTipo = CType(e.Row.FindControl("hdfTipoTran"), HiddenField)
            If hdfTipo.Value = 1 Then
                Dim hdf As HiddenField
                hdf = CType(e.Row.FindControl("hdfCodAporte"), HiddenField)
                Dim hdf1 As HiddenField
                hdf1 = CType(e.Row.FindControl("hdfRutCliente"), HiddenField)
                Dim hpl As HyperLink
                hpl = CType(e.Row.FindControl("hplDescripcion"), HyperLink)
                hpl.NavigateUrl = "ficha_aporte_ingresado.aspx?codAporte=" & hdf.Value & "&rutCliente=" & hdf1.Value
            ElseIf hdfTipo.Value = 2 Then
                Dim hdf2 As HiddenField
                hdf2 = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
                Dim hpl2 As HyperLink
                hpl2 = CType(e.Row.FindControl("hplDescripcion"), HyperLink)
                hpl2.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & hdf2.Value
            End If
            Dim lbl As Label
            lbl = CType(e.Row.FindControl("lblAbono"), Label)
            If lbl.Text = "" Then
                lbl.Text = 0
            Else
                lbl.Text = Replace(lbl.Text, "$", "")
            End If
            lbl.Text = FormatoPeso(lbl.Text)

            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblCargo"), Label)
            If lbl1.Text = "" Then
                lbl1.Text = 0
            Else
                lbl1.Text = Replace(lbl1.Text, "$", "")
            End If
            lbl1.Text = FormatoPeso(lbl1.Text)

            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblSaldo"), Label)
            If lbl2.Text = "" Then
                lbl2.Text = 0
            Else
                lbl2.Text = Replace(lbl2.Text, "$", "")
            End If
            lbl2.Text = FormatoPeso(lbl2.Text)

        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblTotAbono"), Label)
            lbl3.Text = FormatoPeso(objReporte.SumaAbono)

            Dim lbl4 As Label
            lbl4 = CType(e.Row.FindControl("lblTotCargo"), Label)
            lbl4.Text = FormatoPeso(objReporte.SumaCargo)

            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("lblSaldoAct"), Label)
            lbl5.Text = FormatoPeso(objReporte.SaldoActual)

        End If
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text
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
