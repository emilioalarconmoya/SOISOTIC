Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data

Partial Class Reportes_ficha_curso_sence
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objCurso As New CCurso
    Dim objOtec As New COtec
    Dim objGeneraFicha As New CGeneraPDF
    Dim objReporte As New CFichaCursoSence
    Dim cursoSence As New CFichaCursoSence
    Dim objLookups As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        ViewState("CodSence") = Request("CodSence")
        ViewState("RutUsuario") = Request("rutUsuario")
        '************************************
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
        End If
        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        consultar()
    End Sub
    Public Sub consultar()
        Try
            objReporte = New CFichaCursoSence
            objReporte.RutUsuario = ViewState("RutUsuario")
            objReporte.CodSence = ViewState("CodSence")
            objReporte.Consultar()
            cursoSence = New CFichaCursoSence
            Me.lblNombreCurso.Text = objReporte.NombreCurso
            Me.lblCodigoSence.Text = objReporte.CodSence
            Me.lblDChoras.Text = objReporte.DurCurso
            If Me.lblDChoras.Text = "" Then
                Me.lblDChoras.Text = "--"
            End If
            Me.lblDCarea.Text = objReporte.Area
            If Me.lblDCarea.Text = "" Then
                Me.lblDCarea.Text = "--"
            End If
            Me.lblDCespecialidad.Text = objReporte.Especialidad
            If Me.lblDCespecialidad.Text = "" Then
                Me.lblDCespecialidad.Text = "--"
            End If
            Me.hplDOnombreOtec.Text = objReporte.NombreSede
            If Me.hplDOnombreOtec.Text = "" Then
                Me.hplDOnombreOtec.Text = "--"
            End If
            hplDOnombreOtec.NavigateUrl = "ficha_otec.aspx?rutOtec=" & objReporte.RutOtec
            Me.lblDOrut.Text = RutLngAUsr(objReporte.RutOtec)
            Me.lblDOfono.Text = objReporte.FonoSede
            If Me.lblDOfono.Text = "" Then
                Me.lblDOfono.Text = "--"
            End If
            'Me.lblDOfax.Text = objReporte.Fax
            'If Me.lblDOfax.Text = "" Then
            '    Me.lblDOfax.Text = "--"
            'End If
            Me.lblDOemail.Text = objReporte.Email
            If Me.lblDOemail.Text = "" Then
                Me.lblDOemail.Text = "--"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGeneraPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraPDF.Click
        Dim filename As String

        ValoresPdf()
        objGeneraFicha.FichaCursoSence()

        filename = "Ficha_curso_sence.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        'Response.AppendHeader("content-disposition", "attachment; filename=CartaEvaluacion.pdf")
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
        objGeneraFicha = Nothing
    End Sub
   

    Protected Sub ValoresPdf()

        objGeneraFicha.NombreCurso = Me.lblNombreCurso.Text
        objGeneraFicha.CodigoSenceCurso = Me.lblCodigoSence.Text
        objGeneraFicha.NombreEmpresa = Me.hplDOnombreOtec.Text
        objGeneraFicha.HorasCurso = Me.lblDChoras.Text
        objGeneraFicha.AreaCurso = Me.lblDCarea.Text
        objGeneraFicha.EspecialidadCurso = Me.lblDCespecialidad.Text
        objGeneraFicha.RutOtec = Me.lblDOrut.Text
        objGeneraFicha.FonoOtec = Me.lblDOfono.Text
        'objGeneraFicha.FaxOtec = Me.lblDOfax.Text
        objGeneraFicha.MailOtec = Me.lblDOemail.Text

    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("reporte_cursos_consolidado.aspx")
    End Sub

    
End Class
