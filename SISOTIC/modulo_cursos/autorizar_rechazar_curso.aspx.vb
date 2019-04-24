Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_autorizar_rechazar_curso
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objCambioEst As CCambioEstados
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            Dim strCodigosCursos As String
            Dim lngRut As Long
            ViewState("CodCurso") = Request("codCurso")
            ViewState("RutUsuario") = Request("rutUsuario")
            ViewState("EstadoCurso") = Request("estadoCur")
            ViewState("CodEstado") = Request("codEstado")
            strCodigosCursos = ViewState("CodCurso")
            lngRut = ViewState("RutUsuario")
            objCambioEst = New CCambioEstados
            objCambioEst.Inicializar(lngRut, strCodigosCursos)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                lblCorrelativo.Text = objCambioEst.Curso.Correlativo
                lblCorrelEmp.Text = objCambioEst.Curso.CorrEmpresa
                lblEstado.Text = ViewState("EstadoCurso")
                lblFecha.Text = objCambioEst.Curso.FechaModificacion
                lblFechIngreso.Text = objCambioEst.Curso.FechaIngreso
                lblRegSence.Text = objCambioEst.Curso.NroRegistro
                lblPorcentajeAdm.Text = (objCambioEst.Curso.PorcAdm * 100)
                If Trim(objCambioEst.Curso.CodOrigen) = "0" Then
                    lblOrigen.Text = "Interno"
                ElseIf Trim(objCambioEst.Curso.CodOrigen) = "1" Then
                    lblOrigen.Text = "Cliente"
                Else
                    lblOrigen.Text = "--"
                End If
            End If
        Catch ex As Exception
            EnviaError("autorizar_rechazar_curso:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnAutorizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        Dim strGlosa As String
        strGlosa = txtGlosa.Text
        objCambioEst = New CCambioEstados
        Dim lngRut As Long
        lngRut = ViewState("RutUsuario")
        Dim lngCodCurso As Long
        lngCodCurso = ViewState("CodCurso")
        If objCambioEst.CambiarEstAutorizar(strGlosa, lngRut, lngCodCurso) Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: El curso ha sido autorizado');")
            TablaCambioEstado.Visible = False
            TablaMensaje.Visible = True
            btnAutorizar.Visible = False
            btnRechazar.Visible = False
            lblEstado.Text = "autorizado"
            lblResultado.Text = "autorizado"
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Imposible cambiar de estado');")
            TablaCambioEstado.Visible = False
            btnAutorizar.Visible = False
            btnRechazar.Visible = False
        End If
        btnVolver.Visible = True
    End Sub

    Protected Sub btnRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Dim strGlosa As String
        strGlosa = txtGlosa.Text
        Dim lngRut As Long
        lngRut = ViewState("RutUsuario")
        Dim lngCodCurso As Long
        lngCodCurso = ViewState("CodCurso")
        If objCambioEst.CambiarEstRechazar(strGlosa, lngRut, lngCodCurso) Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: El curso ha sido rechazado');")
            TablaCambioEstado.Visible = False
            TablaMensaje.Visible = True
            btnRechazar.Visible = False
            btnAutorizar.Visible = False
            lblEstado.Text = "rechazado"
            lblResultado.Text = "rechazado"
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Imposible cambiar de estado');")
            TablaCambioEstado.Visible = False
            btnRechazar.Visible = False
            btnAutorizar.Visible = False
        End If
        btnVolver.Visible = True
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Dim lngCodEstado As Long
        lngCodEstado = ViewState("CodEstado")
        Response.Redirect("reporte_cursos.aspx?estados=" & lngCodEstado)
    End Sub
End Class
