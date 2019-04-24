Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_menu_cargas
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        If Not Page.IsPostBack Then
            
            lblPie.Text = Parametros.p_PIE
        End If
    End Sub
End Class
