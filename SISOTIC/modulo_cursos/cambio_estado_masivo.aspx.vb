Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_cambio_estado_masivo
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objCambioEstado As CCambioEstados
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            Dim strCodigosCursos As String
            Dim strTipo As String
            Dim lngRut As Long
            ViewState("CodCurso") = Request("codCurso")
            ViewState("RutUsuario") = Request("rutUsuario")
            ViewState("TipoCambio") = Request("tipoCambio")
            ViewState("CodEstado") = Request("codEstado")
            strCodigosCursos = ViewState("CodCurso")
            lngRut = ViewState("RutUsuario")
            objCambioEstado = New CCambioEstados
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                lblFecha.Text = FechaVbAUsr(Date.Now)
                strTipo = ViewState("TipoCambio")
                If strTipo = "autorizar" Then
                    lblTipo.Text = "Autorización masiva de cursos"
                    btnAutorizar.Visible = True
                ElseIf strTipo = "rechazar" Then
                    lblTipo.Text = "Rechazo masivo de cursos"
                    btnRechazar.Visible = True
                ElseIf strTipo = "comunicar" Then
                    lblTipo.Text = "Cambio de estado de cursos"
                    btnComunicar.Visible = True
                ElseIf strTipo = "liquidar" Then
                    lblTipo.Text = "Cambio de estado de cursos"
                    btnLiquidar.Visible = True
                End If
                objCambioEstado.Codigos = strCodigosCursos
                Dim dt As New DataTable
                dt = objCambioEstado.ListadoCursos()
                objWeb.LlenaGrilla(grdCursos, dt)
            End If
        Catch ex As Exception
            EnviaError("autorizar_rechazar_curso:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnAutorizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        Dim strGlosa As String
        Dim strCodigosCursos As String
        Dim lngRut As Long
        objCambioEstado = New CCambioEstados
        strGlosa = txtGlosa.Text
        strCodigosCursos = ViewState("CodCurso")
        lngRut = ViewState("RutUsuario")
        If objCambioEstado.CambiarEstAutorizadoMasivo(strCodigosCursos, strGlosa, lngRut) Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Operación exitosa');")
            TablaCambioEstado.Visible = False
            TablaMensaje.Visible = True
            grdCursos.Visible = True
            btnAutorizar.Visible = False
            lblResultado.Text = "autorizados"
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Imposible cambiar de estado');")
        End If
        btnVolver.Visible = True
    End Sub
    Protected Sub btnRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Dim strGlosa As String
        Dim strCodigosCursos As String
        Dim lngRut As Long
        strGlosa = txtGlosa.Text
        strCodigosCursos = ViewState("CodCurso")
        lngRut = ViewState("RutUsuario")
        If objCambioEstado.CambiarEstRechazadoMasivo(strCodigosCursos, strGlosa, lngRut) Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Operación exitosa');")
            TablaCambioEstado.Visible = False
            TablaMensaje.Visible = True
            btnRechazar.Visible = False
            grdCursos.Visible = True
            lblResultado.Text = "rechazados"
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Imposible cambiar de estado');")
        End If
        btnVolver.Visible = True
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Dim strCodEstado As String
        strCodEstado = ViewState("CodEstado")
        If strCodEstado = "4" Or strCodEstado = "11" Then
            strCodEstado = "4,11"
        End If
        Response.Redirect("reporte_cursos.aspx?estados=" & strCodEstado)
    End Sub

    Protected Sub grdCursos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCursos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblFechaInicio"), Label)
            lbl1.Text = FechaVbAUsr(lbl1.Text)

            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblFechaTermino"), Label)
            lbl2.Text = FechaVbAUsr(lbl2.Text)
        End If  
    End Sub

    Protected Sub btnComunicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComunicar.Click
        Dim strGlosa As String
        Dim strCodigosCursos As String
        strGlosa = txtGlosa.Text
        strCodigosCursos = ViewState("CodCurso")
        If objCambioEstado.CambiarEstEnComunicaMasivo(strCodigosCursos, strGlosa, ViewState("RutUsuario")) Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Operación exitosa');")
            TablaCambioEstado.Visible = False
            TablaMensaje.Visible = True
            btnComunicar.Visible = False
            grdCursos.Visible = True
            lblResultado.Text = "en proceso de comunicación"
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Imposible cambiar de estado');")
        End If
        btnVolver.Visible = True
    End Sub

    Protected Sub btnLiquidar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLiquidar.Click
        Dim strGlosa As String
        Dim strCodigosCursos As String
        Dim lngRut As Long
        strGlosa = txtGlosa.Text
        strCodigosCursos = ViewState("CodCurso")
        lngRut = ViewState("RutUsuario")
        If objCambioEstado.CambiarEstEnLiquidaMasivo(strCodigosCursos, strGlosa, lngRut) Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Operación exitosa');")
            TablaCambioEstado.Visible = False
            TablaMensaje.Visible = True
            btnLiquidar.Visible = False
            grdCursos.Visible = True
            lblResultado.Text = "en proceso de liquidación"
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Imposible cambiar de estado');")
        End If
        btnVolver.Visible = True
    End Sub
End Class
