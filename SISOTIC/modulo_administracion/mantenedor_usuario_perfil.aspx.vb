Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_usuario_perfil
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedorUsuario As CMantenedorUsuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                objWeb.SeteaGrilla(grdResultados, 50)
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        objMantenedorUsuario = New CMantenedorUsuario
        objMantenedorUsuario.RutUsuario = Me.txtRutUsuario.Text
        objMantenedorUsuario.Nombres = Me.txtNombreUsuario.Text
        Dim dt As DataTable
        dt = objMantenedorUsuario.Consultar
        objWeb.LlenaGrilla(grdResultados, dt)
        objMantenedorUsuario = Nothing
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_usuario_perfil_m.aspx?nuevo=si")
    End Sub
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblRut As Label = CType(row.FindControl("lblRut"), Label)
        Response.Redirect("mantenedor_usuario_perfil_m.aspx?rutUsuario=" & lblRut.Text & "&nuevo=no")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        Dim lblRut As Label = CType(row.FindControl("lblRut"), Label)
        objMantenedorUsuario = New CMantenedorUsuario
        objMantenedorUsuario.RutUsuario = lblRut.Text
        objMantenedorUsuario.RutUsuarioSesion = ViewState("RutSession")
        If objMantenedorUsuario.Eliminar() = True Then
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                                & "alert('¡Usuario eliminado exitosamente!');document.location=('./mantenedor_usuario_perfil.aspx');</script>")
        Else
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                                            & "alert('¡No se puede eliminar usuario!');document.location=('./mantenedor_usuario_perfil.aspx');</script>")
        End If
        
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblRut As Label
            lblRut = CType(e.Row.FindControl("lblRut"), Label)
            lblRut.Text = RutLngAUsr(lblRut.Text)

            Dim btnEliminar As Button
            btnEliminar = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.OnClientClick = "return confirm('¿Esta seguro de eliminar este registro?');"
        End If
    End Sub
End Class
