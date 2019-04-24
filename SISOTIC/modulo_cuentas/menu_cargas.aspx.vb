Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_menu_cargas
    Inherits System.Web.UI.Page
    Dim objSession As CSession
    Dim objWeb As CWeb

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            If objSession.EsClienteIngresoCurso Then
                Me.hplIngresoCurso.Visible = True
            End If
        End If
    End Sub
End Class
