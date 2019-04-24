Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_rubros_m
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorRubros
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantenedor = New CMantenedorRubros
            btnGrabar.OnClientClick = "return confirm('Está apunto de hacer cambios en el rubro seleccionado\n¿Desea continuar?');"
            If Not Page.IsPostBack Then
                'muestra pie de pagina
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                If Request("nuevo") = "no" Then
                    ViewState("modo") = "actualizar"
                    lblTipo.Text = "Actualización de rubro"
                    ViewState("CodRubro") = Request("codRubro")
                    objMantenedor.CodRubro = ViewState("CodRubro")
                    objMantenedor.Consultar()
                    Me.txtNombreRubro.Text = objMantenedor.Nombre
                    Me.lblCodRubro.Text = objMantenedor.CodRubro
                    Me.lblCodRubro.Visible = True
                Else
                    ViewState("modo") = "insertar"
                End If
                objMantenedor = Nothing
            End If
        Catch ex As Exception
            EnviaError("mantenedor_rubros_m:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Grabar()
        Try
            objMantenedor = New CMantenedorRubros
            If ViewState("modo") = "actualizar" Then
                objMantenedor.CodRubro = Me.lblCodRubro.Text
                objMantenedor.Nombre = Me.txtNombreRubro.Text
                If objMantenedor.Actualizar() Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Rubro actualizado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido actualizar el rubro!');</script>")
                End If
                objMantenedor = Nothing
            Else
                objMantenedor.Nombre = Me.txtNombreRubro.Text
                If objMantenedor.Insertar Then
                    objMantenedor.Consultar()
                    Me.lblCodRubro.Text = objMantenedor.CodRubro
                    Me.lblCodRubro.Visible = True
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Rubro insertado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido insertar el rubro!');</script>")
                End If
                objMantenedor = Nothing
            End If
        Catch ex As Exception
            EnviaError("mantenedor_rubros_m.aspx.vb: Grabar--> " & ex.Message)
        End Try
    End Sub
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_rubros.aspx")
    End Sub
End Class
