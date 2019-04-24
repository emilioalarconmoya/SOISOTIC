Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_cursos_sence
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorCursosSence
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)

            If Not Page.IsPostBack Then
                'mensaje de pie de pagina 
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                objWeb.SeteaGrilla(grdResultados, 50)
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                Me.btnPopUpSence.Attributes.Add("onClick", "popup_pos('buscador_curso_sence.aspx?campo=txtCodSence', 'NewWindow2', 380, 700, 100, 100);return false;")
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            'Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_cursos_sence:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objMantenedor = New CMantenedorCursosSence
            objMantenedor.CodSence = Me.txtCodSence.Text
            Dim dt As DataTable
            dt = objMantenedor.Consultar
            objWeb.LlenaGrilla(grdResultados, dt)
            objMantenedor = Nothing
        Catch ex As Exception
            objMantenedor = Nothing
            EnviaError("mantenedor_cursos_sence:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblCodSence As Label = CType(row.FindControl("lblCodSence"), Label)
        Response.Redirect("mantenedor_cursos_sence_m.aspx?codSence=" & lblCodSence.Text & "&nuevo=no")
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_cursos_sence_m.aspx?nuevo=si")
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
End Class
