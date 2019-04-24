Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_perfil
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantPerfilObjeto As CMantenedorPerfilObjeto
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
        objMantPerfilObjeto = New CMantenedorPerfilObjeto
        If Me.txtCodPerfil.Text = "" Then
            objMantPerfilObjeto.CodPerfil = 0
        Else
            objMantPerfilObjeto.CodPerfil = Me.txtCodPerfil.Text
        End If
        objMantPerfilObjeto.NombrePerfil = Me.txtNombrePerfil.Text
        Dim dt As DataTable
        dt = objMantPerfilObjeto.ConsultarPerfil
        objWeb.LlenaGrilla(grdResultados, dt)
        objMantPerfilObjeto = Nothing
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
        Dim lblDescripcionPerfil As Label = CType(row.FindControl("lblDescripcionPerfil"), Label)
        Dim lblCodPerfil As Label = CType(row.FindControl("lblCodPerfil"), Label)
        Response.Redirect("mantenedor_perfil_objeto_m.aspx?nombrePerfil=" & lblDescripcionPerfil.Text & "&codPerfil=" & lblCodPerfil.Text & "&nuevo=no")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        Dim lblCodPerfil As Label = CType(row.FindControl("lblCodPerfil"), Label)
        objMantPerfilObjeto = New CMantenedorPerfilObjeto
        objMantPerfilObjeto.CodPerfil = lblCodPerfil.Text
        objMantPerfilObjeto.Consultar()
        Dim dtObjetos As DataTable = objMantPerfilObjeto.ObjetosAsignados
        If dtObjetos Is Nothing Then
            objMantPerfilObjeto.EliminarPerfil()
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡Perfil eliminado exitosamente!');document.location=('./mantenedor_perfil.aspx');</script>")
            objMantPerfilObjeto = Nothing
        Else
            Dim dr As DataRow
            For Each dr In dtObjetos.Rows
                objMantPerfilObjeto.CodObjeto = dr("cod_objeto")
                objMantPerfilObjeto.Eliminar()
            Next
            objMantPerfilObjeto.EliminarPerfil()
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡Perfil eliminado exitosamente!');document.location=('./mantenedor_perfil.aspx');</script>")
            objMantPerfilObjeto = Nothing
        End If
    End Sub
    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button
            btnEliminar = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.OnClientClick = "return confirm('¿Esta seguro de eliminar este registro?');"
        End If
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_perfil_objeto_m.aspx?nuevo=si")
    End Sub
End Class
