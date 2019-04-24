Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_gestion_gerencial_reporte_finan_otic
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CReporteFinanOtic
    Dim objLookups As New Clookups

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            body.Attributes.Clear()
            objWeb = New CWeb
            'objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                'ViewState("RutSession") = objSession.Rut
                objWeb.LlenaDDL(Me.ddlAgnos, objLookups.Agnos, "Agno_v", "Agno_t")
                Me.ddlAgnos.SelectedValue = Now.Year
            End If
        Catch ex As Exception
            EnviaError("reporte_finan_otic:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CReporteFinanOtic
            objReporte.Agno = Me.ddlAgnos.SelectedValue
            objReporte.BajarXml = chkBajarReporte.Checked
            objWeb = New CWeb
            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)
            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporte.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If
        Catch ex As Exception
            EnviaError("reporte_finan_otic:Consultar-->" & ex.Message)
        End Try
        


    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Protected Sub grdResultado_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim rut As Label
                rut = CType(e.Row.FindControl("lblRutCliente"), Label)
                rut.Text = RutLngAUsr(rut.Text)
                Dim saldo As Label
                saldo = CType(e.Row.FindControl("lblSaldo"), Label)
                saldo.Text = FormatoPeso(saldo.Text)


            End If

            If e.Row.RowType = DataControlRowType.Footer Then 'Si es el pie

                e.Row.Cells(0).Text = "Total de la cuenta :"
                e.Row.Cells(0).ForeColor = Drawing.Color.White
                e.Row.Cells(0).BackColor = Drawing.Color.DarkBlue


                e.Row.Cells(1).Text = "$" & FormatoMonto(objReporte.SumTotal)
                e.Row.Cells(1).ForeColor = Drawing.Color.White
                e.Row.Cells(1).BackColor = Drawing.Color.DarkBlue

                ''e.Row.Cells(3).Text = "$" & FormatoMonto(objReporte.TotalAdministracion)
                'e.Row.Cells(3).ForeColor = Drawing.Color.White
                'e.Row.Cells(3).BackColor = Drawing.Color.Gray

                '' e.Row.Cells(4).Text = "$" & FormatoMonto(objReporte.TotalAporteTotal)
                'e.Row.Cells(4).ForeColor = Drawing.Color.White
                'e.Row.Cells(4).BackColor = Drawing.Color.Gray



            End If
        Catch ex As Exception
            EnviaError("reporte_finan_otic:grdResultado_RowDataBound-->" & ex.Message)
        End Try
    End Sub

   
End Class
