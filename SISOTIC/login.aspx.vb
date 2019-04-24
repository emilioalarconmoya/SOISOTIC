Imports Clases
Imports Clases.Web
Imports Modulos
Partial Class login
    Inherits System.Web.UI.Page

    Dim objWeb As New CWeb
    'Protected Sub LoginUsuario_LoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginUsuario.LoggingIn

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblError.Text = ""
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Valida logueo
        Dim objSession As New CSession
        Dim objSessionCliente As New CSession
        If validarut(Me.txtUserName.Text) = True Then
            If objSession.ChequearClave(txtUserName.Text, txtPassword.Text) Then
                'Eliminará los temporales de /tmp (Los de 1 día de antigüedad o más)
                EliminaTmp()
                objWeb.ChequeaSession(objSession)
                'objWeb.ChequeaCliente(objSessionCliente)
                'Carga el objeto session
                If objSession.EsCliente Then
                    Response.Redirect("modulo_cuentas/resumen_grafico.aspx")
                Else
                    Response.Redirect("menu.aspx")
                End If
            Else
                'Lanza error automaticamente
                lblError.Text = "El Usuario/Password no son válidos, reintente."
                'e.Cancel = True
            End If
        Else
            lblError.Text = "Rut Incorrecto, reintente."
            'e.Cancel = True
        End If
    End Sub
End Class
