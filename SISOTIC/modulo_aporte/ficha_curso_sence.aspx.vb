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
    Dim objReporte As New CFichaCursoSence
    Dim cursoSence As New CFichaCursoSence
    Dim objLookups As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)

        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        ViewState("CodSence") = Request("CodSence")

        '************************************

        If Not Page.IsPostBack Then
            If objSession.EsClienteIngresoCurso Then
                'Me.hplIngresoCurso.Visible = True
            End If
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
            objReporte.RutUsuario = objSession.Rut
            objReporte.CodSence = ViewState("CodSence")

            objReporte.Consultar()
            cursoSence = New CFichaCursoSence

            Me.lblNombreCurso.Text = objReporte.NombreCurso
            Me.lblCodigoSence.Text = objReporte.CodSence
            Me.lblDChoras.Text = objReporte.DurCurso
            Me.lblDCarea.Text = objReporte.Area
            Me.lblDCespecialidad.Text = objReporte.Especialidad

            Me.hplDOnombreOtec.Text = objReporte.NombreSede
            hplDOnombreOtec.NavigateUrl = "ficha_otec.aspx?rutOtec=" & objReporte.RutOtec
            Me.lblDOrut.Text = RutLngAUsr(objReporte.RutOtec)
            Me.lblDOfono.Text = objReporte.FonoSede
            'Me.lblDOfax.Text = objReporte.Fax
            Me.lblDOemail.Text = objReporte.Email

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
    '        Response.Write("<script>window.print();</script>")
    '    Catch ex As Exception
    '        EnviaError("diploma.aspx->btnImprimir_Click->" & ex.Message)
    '    End Try
    'End Sub
End Class
