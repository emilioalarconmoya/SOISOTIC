Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_param_gen
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorParamGen
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantenedor = New CMantenedorParamGen
            btnGrabar.OnClientClick = "return confirm('Está apunto de hacer cambios en los parámetros generales\n¿Desea continuar?');"
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                objMantenedor.Consultar()
                objWeb.LlenaDDL(ddlJefeFinanzas, objMantenedor.Usuarios, "rut", "nombres")
                objWeb.LlenaDDL(ddlJefeOperaciones, objMantenedor.Usuarios, "rut", "nombres")
                Me.ddlJefeFinanzas.SelectedValue = objMantenedor.RutJefeFinanzas
                Me.ddlJefeOperaciones.SelectedValue = objMantenedor.RutJefeOperaciones
                Me.txtDiasComun.Text = objMantenedor.DiasComunicacion
                Me.txtSrvCorreo.Text = objMantenedor.ServidorCorreo
                Me.txtDirecCorreosOrigen.Text = objMantenedor.DireccionCorreoOrigen
                Me.txtDirecCorreosDestino.Text = objMantenedor.DireccionCorreoDestino
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            objMantenedor = Nothing
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_param_gen:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Grabar()
        Try
            objMantenedor = New CMantenedorParamGen
            objMantenedor.RutJefeFinanzas = Me.ddlJefeFinanzas.SelectedValue
            objMantenedor.RutJefeOperaciones = Me.ddlJefeOperaciones.SelectedValue
            objMantenedor.DiasComunicacion = Me.txtDiasComun.Text
            objMantenedor.ServidorCorreo = Me.txtSrvCorreo.Text
            objMantenedor.DireccionCorreoOrigen = Me.txtDirecCorreosOrigen.Text
            objMantenedor.DireccionCorreoDestino = Me.txtDirecCorreosDestino.Text
            If objMantenedor.Modificar Then
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                   & "alert('¡Parámetros actualizados exitosamente!');</script>")
            Else
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                   & "alert('¡No se ha podido realizar la operación!');</script>")
            End If
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("mantenedor_param_gen:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
End Class
