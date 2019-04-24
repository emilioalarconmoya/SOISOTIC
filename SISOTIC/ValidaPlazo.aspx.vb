Imports Modulos
Partial Class ValidaPlazo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        body.Attributes.Clear()
    End Sub

    Protected Sub btnValidar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        If ValidaDiasInscripcion(Me.txtFechaIngreso.Text.Trim, Me.txtFechaInicio.Text.Trim()) Then
            body.Attributes.Add("onload", "alert('PUEDE INSCRIBIR');")
        Else
            body.Attributes.Add("onload", "alert('DEBE INSCRIBIR AL MENOS DOS DIAS ANTES DEL INICIO DEL CURSO');")
        End If
    End Sub

End Class
