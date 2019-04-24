Imports Clases
Imports Clases.Web
Partial Class modulo_cursos_home
    Inherits System.Web.UI.Page
    Dim objSession As CSession
    Dim objWeb As CWeb
    Dim objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        objWeb.ChequeaCliente(objSessionCliente)
        If objSession.EsCliente Then
            Response.Redirect("resumen_grafico.aspx")
        Else
            Response.Redirect("resumen.aspx")
        End If
    End Sub
End Class
