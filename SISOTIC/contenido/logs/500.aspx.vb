Imports Modulos
Partial Class logs_500
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblOrigen.Text = "Página de Origen: " & Request("aspxerrorpath")

    End Sub
End Class
