Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data

Partial Class modulo_gestion_gerencial_acciones_liquidadas
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objReporte As New CAccionesLiquidadas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                objWeb.LlenaDDL(Me.ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
                Me.ddlAgnos.SelectedValue = Now.Year
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            objReporte.Agno = Me.ddlAgnos.SelectedValue
            objReporte.Consultar()
            hplBajarReporte.Target = "_Blank"
            hplBajarReporte.Text = "Descargar"
            hplBajarReporte.NavigateUrl = objReporte.Ruta
            Me.hplBajarReporte.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class
