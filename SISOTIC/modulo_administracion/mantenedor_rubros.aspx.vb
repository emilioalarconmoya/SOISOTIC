Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_rubros
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorRubros
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                'muestra pie de pagina
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                objWeb.SeteaGrilla(grdResultados, 50)
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            'Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        objMantenedor = New CMantenedorRubros
        If Me.txtCodRubro.Text = "" Then
            objMantenedor.CodRubro = 0
        Else
            objMantenedor.CodRubro = Me.txtCodRubro.Text
        End If
        objMantenedor.Nombre = Me.txtNombreRubro.Text
        Dim dt As DataTable
        dt = objMantenedor.Consultar
        objWeb.LlenaGrilla(grdResultados, dt)
        objMantenedor = Nothing
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblCodRubro As Label = CType(row.FindControl("lblCodRubro"), Label)
        Response.Redirect("mantenedor_rubros_m.aspx?codRubro=" & lblCodRubro.Text & "&nuevo=no")
    End Sub
    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        Dim lblCodRubro As Label = CType(row.FindControl("lblCodRubro"), Label)
        objMantenedor = New CMantenedorRubros
        objMantenedor.CodRubro = lblCodRubro.Text
        If objMantenedor.Eliminar Then
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                       & "alert('¡Registro eliminado exitosamente!');document.location=('./mantenedor_rubros.aspx');</script>")
        Else
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                       & "alert('¡Imposible realizar la operación!');document.location=('./mantenedor_rubros.aspx');</script>")
        End If
        objMantenedor = Nothing
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_rubros_m.aspx?nuevo=si")
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button
            btnEliminar = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.OnClientClick = "return confirm('¿Esta seguro de eliminar este registro?');"
        End If
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
End Class
