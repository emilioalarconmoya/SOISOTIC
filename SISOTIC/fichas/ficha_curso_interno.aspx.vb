Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_curso_interno
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    'Dim objReporte As New CCursoInterno
    Dim objReporte As New CFichaCursoInterno
    Dim objCliente As New CCliente
    Dim cursoInterno As New CFichaCursoInterno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        ViewState("CodCurso") = Request("codCurso")
        ViewState("agno") = objSession.Agno


        '************************************
        If Not Page.IsPostBack Then
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
                lblPie.Text = Parametros.p_PIE
            End If
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If

        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Consultar()

    End Sub
    Private Sub Consultar()


        Try
            'objReporte = New CCursoInterno
            objReporte = New CFichaCursoInterno
            objReporte.RutCliente = objSession.Rut
            objReporte.CodCurso = ViewState("CodCurso")
            objReporte.Agno = ViewState("agno")
            objReporte.Consultar()
            objCliente = New CCliente

            objReporte.Agno = objSession.Agno
            'objReporte.Consultar()
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



        Catch ex As Exception

        End Try
    End Sub





    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("reporte_cursos_consolidado.aspx")
    End Sub

    'Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
    '    Try
    '        Me.btnImprimir.Visible = False
    '        Me.btnVolver.Visible = False
    '        Me.btnModificarCurso.Visible = False
    '        Me.btnVerlistadoCurso.Visible = False
    '        Response.Write("<script>window.print();</script>")
    '    Catch ex As Exception
    '        EnviaError("diploma.aspx->btnImprimir_Click->" & ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnVerlistadoCurso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerlistadoCurso.Click
        Response.Redirect("../modulo_cuentas/reporte_cursos_consolidado.aspx")
    End Sub

    Protected Sub btnModificarCurso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificarCurso.Click
        Response.Redirect("../modulo_cursos/mantenedor_cursos_internos.aspx?Correlativo=" & objReporte.Correlativo & "&Agno=" & objSession.Agno)
    End Sub
End Class
