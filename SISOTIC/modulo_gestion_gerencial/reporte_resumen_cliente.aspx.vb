Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_gestion_gerencial_reporte_resumen_cliente
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CReporteResumenCliente
    Dim objLookups As New Clookups

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            body.Attributes.Clear()
            objWeb = New CWeb
            'objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                'ViewState("RutSession") = objSession.Rut
                objWeb.LlenaDDL(Me.ddlAgnos2, objLookups.Agnos2, "Agno_v", "Agno_t")
                Me.ddlAgnos2.SelectedValue = Now.Year
                Me.hplBajarReporte.Visible = False
                Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_administracion/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            End If
           

        Catch ex As Exception
            EnviaError("reporte_finan_otic:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Private Sub Consultar()
        Try

            objWeb = New CWeb
            Dim dt As DataTable
            objReporte = New CReporteResumenCliente
            objReporte.BajarXml = chkBajarReporte.Checked
            objReporte.Agno = Me.ddlAgnos2.SelectedValue

            If Me.txtNomCliente.Text = "" Then
                objReporte.NombreCliente = ""
            Else
                objReporte.NombreCliente = Me.txtNomCliente.Text
            End If
            If Me.txtRutEmpresa.Text = "" Then
                objReporte.RutCliente = 0
            Else
                objReporte.RutCliente = RutUsrALng(Me.txtRutEmpresa.Text)
            End If

            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)
            objWeb.SeteaGrilla(grdResultados, 20)

            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporte.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If

        Catch ex As Exception
            EnviaError("reporte_resumen_cliente:Consultar-->" & ex.Message)
        End Try
        
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                'Dim lblRutCliente As Label
                'lblRutCliente = CType(e.Row.FindControl("lblRutCliente"), Label)
                'lblRutCliente.Text = RutLngAUsr(lblRutCliente.Text)

                Dim aporteAbonadoCap As Label
                aporteAbonadoCap = CType(e.Row.FindControl("lblAporteAbonadoCap"), Label)
                If aporteAbonadoCap.Text < 0 Then
                    aporteAbonadoCap.ForeColor = Drawing.Color.Red
                End If
                aporteAbonadoCap.Text = FormatoMonto(aporteAbonadoCap.Text)

                Dim cargaXCursoCap As Label
                cargaXCursoCap = CType(e.Row.FindControl("lblCargaXCursoCap"), Label)
                If cargaXCursoCap.Text < 0 Then
                    cargaXCursoCap.ForeColor = Drawing.Color.Red
                End If
                cargaXCursoCap.Text = FormatoMonto(cargaXCursoCap.Text)

                Dim saldoCap As Label
                saldoCap = CType(e.Row.FindControl("lblSaldoCap"), Label)
                If saldoCap.Text < 0 Then
                    saldoCap.ForeColor = Drawing.Color.Red
                End If
                saldoCap.Text = FormatoMonto(saldoCap.Text)

                Dim aporteAbonadoRep As Label
                aporteAbonadoRep = CType(e.Row.FindControl("lblAporteAbonadoRep"), Label)
                If aporteAbonadoRep.Text < 0 Then
                    aporteAbonadoRep.ForeColor = Drawing.Color.Red
                End If
                aporteAbonadoRep.Text = FormatoMonto(aporteAbonadoRep.Text)

                Dim cargaXCursoRep As Label
                cargaXCursoRep = CType(e.Row.FindControl("lblCargaXCursoRep"), Label)
                If cargaXCursoRep.Text < 0 Then
                    cargaXCursoRep.ForeColor = Drawing.Color.Red
                End If
                cargaXCursoRep.Text = FormatoMonto(cargaXCursoRep.Text)

                Dim saldoRep As Label
                saldoRep = CType(e.Row.FindControl("lblSaldoRep"), Label)
                If saldoRep.Text < 0 Then
                    saldoRep.ForeColor = Drawing.Color.Red
                End If
                saldoRep.Text = FormatoMonto(saldoRep.Text)

                Dim gananciaXAdm As Label
                gananciaXAdm = CType(e.Row.FindControl("lblGananciaXAdm"), Label)
                If gananciaXAdm.Text = "*" Then

                Else
                    If gananciaXAdm.Text < 0 Then
                        gananciaXAdm.ForeColor = Drawing.Color.Red
                        gananciaXAdm.Text = "*"
                    Else
                        gananciaXAdm.Text = FormatoMonto(gananciaXAdm.Text)

                    End If
                End If



                Dim saldoExCap As Label
                saldoExCap = CType(e.Row.FindControl("lblSaldoExCap"), Label)
                If saldoExCap.Text < 0 Then
                    saldoExCap.ForeColor = Drawing.Color.Red
                End If
                saldoExCap.Text = FormatoMonto(saldoExCap.Text)

                Dim saldoExRep As Label
                saldoExRep = CType(e.Row.FindControl("lblSaldoExRep"), Label)
                If saldoExRep.Text < 0 Then
                    saldoExRep.ForeColor = Drawing.Color.Red
                End If
                saldoExRep.Text = FormatoMonto(saldoExRep.Text)

                Dim saldoExExRep As Label
                saldoExExRep = CType(e.Row.FindControl("lblSaldoExExRep"), Label)
                If saldoExExRep.Text < 0 Then
                    saldoExExRep.ForeColor = Drawing.Color.Red
                End If
                saldoExExRep.Text = FormatoMonto(saldoExExRep.Text)

            End If
        Catch ex As Exception
            EnviaError("reporte_resumen_cliente:grdResultados_RowDataBound-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

  
End Class
