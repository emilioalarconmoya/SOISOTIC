Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_ficha_curso_interno
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    'Dim objReporte As New CCursoInterno
    Dim objReporte As New CFichaCursoInterno
    Dim objCliente As New CCliente
    Dim cursoInterno As New CFichaCursoInterno
    Dim objGeneraFicha As New CGeneraPDF

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        ViewState("CodCurso") = Request("codCurso")
        ViewState("Agno") = Request("Agno")


        '************************************
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            '    If ViewState("PaginasAtras") Is Nothing Then
            '        ViewState("PaginasAtras") = 1
            '    End If
            'Else
            '    ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If

        ' Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Consultar()

    End Sub
    Private Sub Consultar()
        Try
            'objReporte = New CCursoInterno
            objReporte = New CFichaCursoInterno
            objReporte.RutCliente = objSession.Rut
            objReporte.CodCurso = ViewState("CodCurso")
            objReporte.Agno = ViewState("Agno")
            objReporte.Consultar()
            objCliente = New CCliente

            'objReporte.Agno = objSession.Agno
            cursoInterno = New CFichaCursoInterno

            'DC
            Me.lblDCrut.Text = RutLngAUsr(objReporte.RutUsuario)
            Me.lblDCrazonSocial.Text = objReporte.RazonSocial
            Me.lblDCdireccion.Text = objReporte.DireccionCurso
            Me.lblDCcomuna.Text = objReporte.NombreComuna
            Me.lblDCciudad.Text = objReporte.NomRegion

            'DCI
            Me.lblDCIcorrelativo.Text = objReporte.Correlativo
            Me.lblDCIestado.Text = NombreEstadoCurso(objReporte.CodEstadoCurso)
            Me.lblDCIcurso.Text = objReporte.NombreCurso
            Me.lblDCIotec.Text = objReporte.Ejecutor
            Me.lblDCIalumnos.Text = objReporte.NumAlumnos
            Me.lblDCInumeroInterno.Text = objReporte.CorrEmpresa
            Me.lblDCIhorario.Text = objReporte.Horario
            Me.lblDCIhoras.Text = objReporte.Horas
            Me.lblDCIobservaciones.Text = objReporte.Observacion
            Me.lblDCIcosto.Text = FormatoMonto(objReporte.ValorCurso)

            hplCartaInterno.NavigateUrl = "../modulo_cursos/carta_curso_interno.aspx?correlativo=" & objReporte.Correlativo & "&agno=" & ViewState("Agno")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        If objSession.EsCliente Then
            Response.Redirect("../modulo_cuentas/resumen.aspx")
        Else
            Response.Redirect("resumen.aspx")
        End If
    End Sub

    Protected Sub btnModificarCurso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificarCurso.Click
        If objSession.EsCliente Then
            Response.Redirect("../modulo_cuentas/mantenedor_cursos_internos.aspx?Correlativo=" & ViewState("CodCurso") & "&Agno=" & ViewState("Agno"))
        Else
            Response.Redirect("mantenedor_cursos_internos.aspx?Correlativo=" & ViewState("CodCurso") & "&Agno=" & ViewState("Agno"))
        End If
    End Sub

    Protected Sub btnVerlistadoCurso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerlistadoCurso.Click
        If objSession.EsCliente Then
            Response.Redirect("../modulo_cuentas/reporte_cursos.aspx?RutCliente=" & objReporte.RutUsuario & "&Agno=" & ViewState("Agno"))
        Else
            Response.Redirect("reporte_cursos_internos.aspx?RutCliente=" & objReporte.RutUsuario & "&Agno=" & ViewState("Agno"))
        End If
    End Sub

    Protected Sub btnGeneraPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraPDF.Click
        Dim filename As String

        objGeneraFicha.FichaCursoInterno(lblDCrut.Text, lblDCrazonSocial.Text, lblDCdireccion.Text, lblDCcomuna.Text, lblDCciudad.Text, lblDCIcorrelativo.Text, _
                                         lblDCIestado.Text, lblDCIcurso.Text, lblDCIotec.Text, lblDCIalumnos.Text, lblDCInumeroInterno.Text, lblDCIhorario.Text, _
                                         lblDCIhoras.Text, lblDCIobservaciones.Text, lblDCIcosto.Text)

        filename = "Ficha_curso_sence.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        'Response.AppendHeader("content-disposition", "attachment; filename=CartaEvaluacion.pdf")
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
        objGeneraFicha = Nothing
    End Sub
End Class
