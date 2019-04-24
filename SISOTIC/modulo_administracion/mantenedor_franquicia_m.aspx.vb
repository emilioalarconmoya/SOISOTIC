Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_franquicia_m
    Inherits System.Web.UI.Page

    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CFranquicia

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantenedor = New CFranquicia

            'btnGrabar.OnClientClick = "return confirm('Está apunto de realizar cambios en los registros\n¿Desea continuar?');"
            If Not Page.IsPostBack Then
                'muestra pie de pagina
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                ViewState("Agno") = Request("agno")
                ViewState("RutCliente") = RutUsrALng(Request("RutCliente"))
                ViewState("nombre") = Request("nombre")
                'If Request("nuevo") = "no" Then
                'ViewState("modo") = "actualizar"
                objMantenedor.Rut = ViewState("RutCliente")
                objMantenedor.Agno = ViewState("Agno")
                'objMantenedor.Consultar2()
                If objMantenedor.Consultar2.Rows.Count > 0 Then
                    ViewState("modo") = "actualizar"
                Else
                    ViewState("modo") = "insertar"
                End If
                Me.lblAgno.Visible = True
                Me.txtValorFranquicia.Text = objMantenedor.Valor
                Me.lblAgno.Text = objMantenedor.Agno
                objMantenedor = Nothing
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            

            ' Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"

        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_franquicia_m:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Guardar()
        Try
            objMantenedor = New CFranquicia
            If ViewState("modo") = "actualizar" Then
                objMantenedor.Agno = ViewState("Agno")
                objMantenedor.Rut = ViewState("RutCliente")
                objMantenedor.Valor = Me.txtValorFranquicia.Text.Trim
                If objMantenedor.Actualizar() Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Valor de la franquicia actualizada exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido actualizar el valor de la franquicia!');</script>")
                End If
            Else
                objMantenedor.Agno = ViewState("Agno")
                objMantenedor.Rut = ViewState("RutCliente")
                objMantenedor.Valor = Me.txtValorFranquicia.Text.Trim
                If objMantenedor.Insertar() Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Valor de la franquicia ingresado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido ingresar el valor de la franquicia!');</script>")
                End If
                'End If
            End If
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_franquicia_m:Guardar--> " & ex.Message)
        End Try

    End Sub
    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
    '    Response.Redirect("mantenedor_franquicia.aspx?RutCliente=" & ViewState("RutCliente") & "&Nombre=" & ViewState("nombre"))
    'End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_franquicia.aspx?RutCliente=" & RutLngAUsr(ViewState("RutCliente")) & "&Nombre=" & ViewState("nombre"))
    End Sub
End Class
