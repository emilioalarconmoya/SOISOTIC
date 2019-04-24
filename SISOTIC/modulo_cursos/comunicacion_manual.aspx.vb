Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data

Partial Class modulo_cursos_comunicacion_manual
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objCambEstados As CCambioEstados
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ViewState("CodCurso") = Request("codCurso")
        ViewState("RutUsuario") = Request("rutUsuario")
        ViewState("EstadoCurso") = Request("estadoCur")
        ViewState("CodEstado") = Request("codEstado")
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            Me.calFechaComunic.SelectedDate = Now.Date
            Consultar()
        End If
    End Sub
    Public Sub Consultar()
        Dim lngCodCurso As Long
        Dim lngRut As Long
        lngCodCurso = ViewState("CodCurso")
        lngRut = ViewState("RutUsuario")
        objCambEstados = New CCambioEstados
        objCambEstados.Inicializar(lngRut, lngCodCurso)
        lblCorrelativo.Text = objCambEstados.Curso.Correlativo
        lblCorrelEmp.Text = objCambEstados.Curso.CorrEmpresa
        lblEstado.Text = ViewState("EstadoCurso")
        lblFecha.Text = objCambEstados.Curso.FechaComunicacion
        lblFechIngreso.Text = objCambEstados.Curso.FechaIngreso
        lblRegSence.Text = objCambEstados.Curso.NroRegistro
        If Trim(objCambEstados.Curso.CodOrigen) = "0" Then
            lblOrigen.Text = "Interno"
        ElseIf Trim(objCambEstados.Curso.CodOrigen) = "1" Then
            lblOrigen.Text = "Cliente"
        Else
            lblOrigen.Text = "--"
        End If
    End Sub

    Protected Sub btnComunicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComunicar.Click
        Dim strGlosa As String
        Dim strFechaComunicacion As String
        Dim lngNroRegistro As Long
        Dim lngCodCurso As Long
        Dim lngRut As Long
        objCambEstados = New CCambioEstados
        If IsNumeric(Me.txtFolio.Text) Then
            lngNroRegistro = txtFolio.Text
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: el folio debe ser un número entero');")
            Exit Sub
        End If
        lngCodCurso = ViewState("CodCurso")
        lngRut = ViewState("RutUsuario")
        strFechaComunicacion = FechaVbAUsr(calFechaComunic.SelectedValue)
        strGlosa = txtGlosa.Text

        If objCambEstados.ComunicacionManual(strFechaComunicacion, lngNroRegistro, strGlosa, lngRut, lngCodCurso) Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: El curso ha sido comunicado');")
            TablaCambioEstado.Visible = False
            btnComunicar.Visible = False
            TablaMensaje.Visible = True
            lblResultado.Text = "comunicado"
            lblEstado.Text = "comunicado"
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: Imposible cambiar de estado');")
            TablaCambioEstado.Visible = False
            btnComunicar.Visible = False
        End If
        btnVolver.Visible = True
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Dim lngCodEstado As Long
        lngCodEstado = ViewState("CodEstado")
        Response.Redirect("reporte_cursos.aspx?estados=" & lngCodEstado)
    End Sub
End Class
