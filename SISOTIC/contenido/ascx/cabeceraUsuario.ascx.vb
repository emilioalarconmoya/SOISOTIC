Imports Clases
Imports Clases.Web
Imports Modulos
Imports System.Data
Partial Class contenido_ascx_cabeceraUsuario
    Inherits System.Web.UI.UserControl
    Private objSessionCliente As CSession
    Private objSession As CSession
    Private objWeb As CWeb
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        '************************************
        If Not Page.IsPostBack Then
            
            cargacabecera()

            
        End If
    End Sub
    Private Sub cargacabecera()
        Try

            objSession.ChequearCliente(RutLngAUsr(objSession.Rut))
            Me.lblNombreUsuario.Text = objSession.Nombre

            'Me.txtRutEmpresa.Text = RutLngAUsr(objSessionCliente.RutCliente)
        Catch ex As Exception

        End Try
    End Sub
End Class
