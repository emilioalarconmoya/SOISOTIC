Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data

Partial Class modulo_cursos_liquidacion_manual
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As New CSession
    Dim objCambEstados As CCambioEstados
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ViewState("CodCurso") = Request("codCurso")
            ViewState("RutUsuario") = Request("rutUsuario")
            'ViewState("EstadoCurso") = Request("estadoCur")
            'ViewState("CodEstado") = Request("codEstado")
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                Consultar()
            End If
        Catch ex As Exception
            EnviaError("modulo_cursos/comunicacion_manual:Page_Load-->" & ex.Message)
        End Try

    End Sub
    Public Sub Consultar()
        Dim lngCodCurso As Long
        Dim lngRut As Long
        lngCodCurso = ViewState("CodCurso")
        lngRut = ViewState("RutUsuario")
        objCambEstados = New CCambioEstados
        If objCambEstados.LiquidarCurso("", lngRut, lngCodCurso) Then
            'body.Attributes.Add("onload", "alert('ATENCIÓN: El curso está liquidado');")
            lblResultado.Text = "El curso está liquidado"
        Else
            'body.Attributes.Add("onload", "alert('ATENCIÓN: No se puede liquidar el curso');")
            lblResultado.Text = "No se puede liquidar el curso"
        End If

    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("reporte_cursos.aspx?estados=9&agno=" & Now.Year & "&resumen=si")
    End Sub
End Class
