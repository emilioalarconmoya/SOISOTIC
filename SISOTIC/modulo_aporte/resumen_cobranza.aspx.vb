Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_aporte_resumen_cobranza
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As New CSession
    Dim objResumenCobranza As New CResumenCobranza
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)

        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            Me.calFechaInicial.SelectedValue = "01/01/" & objSession.Agno
            Me.calFechaFinal.SelectedValue = "31/12/" & objSession.Agno
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_cursos/buscador_empresas.aspx?campo=txtRutCliente', 'NewWindow1', 380, 700, 100, 100);return false;")
            objWeb.SeteaGrilla(grdResultados, 20)
        End If
    End Sub

    Protected Sub BtnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        consultar()
    End Sub

    Private Sub consultar()
        Try
            objResumenCobranza = New CResumenCobranza
            'Validaciones
            If Not IsDate(calFechaInicial.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio');")
                Exit Sub
            ElseIf Not EsFechaValidaVB(calFechaInicial.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            If Me.calFechaInicial.SelectedDate > Me.calFechaFinal.SelectedDate Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: La fecha de inicio no puede ser mayor a la fecha de fin');")
                Exit Sub
            End If
            objResumenCobranza.FechaInicio = Me.calFechaInicial.SelectedValue
            objResumenCobranza.FechaFin = Me.calFechaFinal.SelectedValue
            objResumenCobranza.RutCliente = RutUsrALng(Me.txtRutCliente.Text)
            objResumenCobranza.NombreCliente = Me.TxtNombreCliente.Text
            objResumenCobranza.BajarXml = ChkBajar.Checked

            'RutLngAUsr()
            'FormatoPeso()
            Dim dt As DataTable
            dt = objResumenCobranza.consultar()
            objWeb.LlenaGrilla(grdResultados, dt)
            If ChkBajar.Checked And objResumenCobranza.Filas > 0 Then
                HplkBajarArchivo.Target = "_Blank"
                HplkBajarArchivo.Text = "Descargar archivo"
                HplkBajarArchivo.NavigateUrl = objResumenCobranza.ArchivoXml
                Me.HplkBajarArchivo.Visible = True
            End If

        Catch ex As Exception
            EnviaError("modulo_aporte_resumen_cobranza.aspx:Consultar->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
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
            'datos 
            Dim lblRut As Label
            lblRut = CType(e.Row.FindControl("LblRutClien"), Label)
            lblRut.Text = lblRut.Text
            Dim lblNom As Label
            lblNom = CType(e.Row.FindControl("lblNombreClien"), Label)
            lblNom.Text = lblNom.Text
            Dim LblCont As Label
            LblCont = CType(e.Row.FindControl("LblContacto"), Label)
            LblCont.Text = LblCont.Text
            Dim Lblfon As Label
            Lblfon = CType(e.Row.FindControl("LblFono"), Label)
            Lblfon.Text = Lblfon.Text
            Dim LblEje As Label
            LblEje = CType(e.Row.FindControl("LblEjecutivo"), Label)
            LblEje.Text = LblEje.Text
            Dim LblSuc As Label
            LblSuc = CType(e.Row.FindControl("LblSucursal"), Label)
            LblSuc.Text = LblSuc.Text
            Dim Lbl7 As Label
            Lbl7 = CType(e.Row.FindControl("LblAdm"), Label)
            Lbl7.Text = (Lbl7.Text * 100)
            'Cuenta Capacitacion
            Dim LblAc As Label
            LblAc = CType(e.Row.FindControl("LblAbonoCtaCap"), Label)
            LblAc.Text = FormatoPeso(LblAc.Text)
            Dim LblCc As Label
            LblCc = CType(e.Row.FindControl("LblCargosCtaCap"), Label)
            LblCc.Text = FormatoPeso(LblCc.Text)
            Dim lblCargoCtaCapVyT As Label
            lblCargoCtaCapVyT = CType(e.Row.FindControl("lblCargoCtaCapVyT"), Label)
            lblCargoCtaCapVyT.Text = FormatoPeso(lblCargoCtaCapVyT.Text)
            Dim LblSc As Label
            LblSc = CType(e.Row.FindControl("LblSaldoCtaCap"), Label)
            LblSc.Text = FormatoPeso(LblSc.Text)
            'Cuenta de reparto
            Dim LblAcr As Label
            LblAcr = CType(e.Row.FindControl("LblAbonoCuenRep"), Label)
            LblAcr.Text = FormatoPeso(LblAcr.Text)
            Dim LblCcr As Label
            LblCcr = CType(e.Row.FindControl("LblCargosCuenRep"), Label)
            LblCcr.Text = FormatoPeso(LblCcr.Text)
            Dim LblScr As Label
            LblScr = CType(e.Row.FindControl("LblSaldoCuenRep"), Label)
            LblScr.Text = FormatoPeso(LblScr.Text)
            'Cuenta de Administracion
            Dim LblAbonocadm As Label
            LblAbonocadm = CType(e.Row.FindControl("LblAbonoCuenAdm"), Label)
            LblAbonocadm.Text = FormatoPeso(LblAbonocadm.Text)
            Dim LblCcAdm As Label
            LblCcAdm = CType(e.Row.FindControl("LblCargosCuenAdm"), Label)
            LblCcAdm.Text = FormatoPeso(LblCcAdm.Text)
            Dim LblSca As Label
            LblSca = CType(e.Row.FindControl("LblSaldoCuenAdm"), Label)
            LblSca.Text = FormatoPeso(LblSca.Text)
            Dim LblDca As Label
            LblDca = CType(e.Row.FindControl("LblDeudaCuenAdm"), Label)
            LblDca.Text = FormatoPeso(LblDca.Text)
            'Cuenta de excedentes de cap
            Dim LblAcc As Label
            LblAcc = CType(e.Row.FindControl("LblAbonoCuenExCap"), Label)
            LblAcc.Text = FormatoPeso(LblAcc.Text)
            Dim LblCcec As Label
            LblCcec = CType(e.Row.FindControl("LblCargosCuenExCap"), Label)
            LblCcec.Text = FormatoPeso(LblCcec.Text)
            Dim lblCargoExcCapVyT As Label
            lblCargoExcCapVyT = CType(e.Row.FindControl("lblCargoExcCapVyT"), Label)
            lblCargoExcCapVyT.Text = FormatoPeso(lblCargoExcCapVyT.Text)
            Dim LblScec As Label
            LblScec = CType(e.Row.FindControl("LblSaldoCuenExCap"), Label)
            LblScec.Text = FormatoPeso(LblScec.Text)
            'Cuenta de Excedentes de reparto
            Dim LblAcer As Label
            LblAcer = CType(e.Row.FindControl("LblAbonoCuenExReparto"), Label)
            LblAcer.Text = FormatoPeso(LblAcer.Text)
            Dim LblCcer As Label
            LblCcer = CType(e.Row.FindControl("LblCargosCuenExReparto"), Label)
            LblCcer.Text = FormatoPeso(LblCcer.Text)
            Dim LblScer As Label
            LblScer = CType(e.Row.FindControl("LblSaldoCuenExReparto"), Label)
            LblScer.Text = FormatoPeso(LblScer.Text)
            Dim lblDcer As Label
            lblDcer = CType(e.Row.FindControl("lblDeudaCuenExReparto"), Label)
            lblDcer.Text = FormatoPeso(lblDcer.Text)
            Dim lblAbonoAporteBeca As Label
            lblAbonoAporteBeca = CType(e.Row.FindControl("lblAbonoAporteBeca"), Label)
            lblAbonoAporteBeca.Text = FormatoPeso(lblAbonoAporteBeca.Text)
            Dim lblAbonoMandatoBeca As Label
            lblAbonoMandatoBeca = CType(e.Row.FindControl("lblAbonoMandatoBeca"), Label)
            lblAbonoMandatoBeca.Text = FormatoPeso(lblAbonoMandatoBeca.Text)
            Dim lblSaldoBecas As Label
            lblSaldoBecas = CType(e.Row.FindControl("lblSaldoBecas"), Label)
            lblSaldoBecas.Text = FormatoPeso(lblSaldoBecas.Text)
        End If
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
