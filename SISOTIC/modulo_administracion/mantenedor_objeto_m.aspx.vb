Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_objeto_m
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantPerfilObjeto As CMantenedorPerfilObjeto
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantPerfilObjeto = New CMantenedorPerfilObjeto
            btnGrabar.OnClientClick = "return confirm('Está apunto de hacer cambios en el objeto seleccionado\n¿Desea continuar?');"
            If Not Page.IsPostBack Then
                'muestra pie de pagina
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                If Request("nuevo") = "no" Then
                    ViewState("modo") = "actualizar"
                    lblTipo.Text = "Actualización de objeto"
                    ViewState("CodObjeto") = Request("codObjeto")
                    objMantPerfilObjeto.CodObjeto = ViewState("CodObjeto")
                    objMantPerfilObjeto.ConsultarObjeto()
                    txtNombreObjeto.Text = objMantPerfilObjeto.NombreObjeto
                    lblCodObjeto.Text = objMantPerfilObjeto.CodObjeto
                    lblCodObjeto.Visible = True
                Else
                    ViewState("modo") = "insertar"
                End If
                objMantPerfilObjeto = Nothing
            End If
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Grabar()
        Try
            objMantPerfilObjeto = New CMantenedorPerfilObjeto
            If ViewState("modo") = "actualizar" Then
                objMantPerfilObjeto.CodObjeto = ViewState("CodObjeto")
                objMantPerfilObjeto.NombreObjeto = Me.txtNombreObjeto.Text
                If objMantPerfilObjeto.ActualizarObjeto() Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Objeto actualizado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido actualizar el objeto!');</script>")
                End If
                objMantPerfilObjeto = Nothing
            Else
                objMantPerfilObjeto = New CMantenedorPerfilObjeto
                objMantPerfilObjeto.NombreObjeto = Me.txtNombreObjeto.Text
                If objMantPerfilObjeto.InsertarObjeto() Then
                    objMantPerfilObjeto.ConsultarObjeto()
                    lblCodObjeto.Text = objMantPerfilObjeto.CodObjeto
                    lblCodObjeto.Visible = True
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Objeto insertado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido insertar el objeto!');</script>")
                End If
                objMantPerfilObjeto = Nothing
            End If
        Catch ex As Exception
            EnviaError("mantenedor_perfil_objeto_m.aspx.vb: Grabar--> " & ex.Message)
        End Try
    End Sub
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_objeto.aspx")
    End Sub
End Class
