Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Imports Clases
Partial Class modulo_gestion_gerencial_ranking_otec
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CReporteRankingOtec
    Dim objLookups As New Clookups
    Dim objChart As New CChart
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            body.Attributes.Clear()
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                Dim lngRut As Long
                lngRut = objSession.Rut
                objWeb.LlenaDDL(Me.ddlAgno, objLookups.Agnos2, "Agno_v", "Agno_t")
                'objWeb.LlenaDDL(Me.ddlRango, objLookups.rango, "rango_v", "rango_t")
                Me.ddlAgno.SelectedValue = Now.Year
                'Me.ddlRango.SelectedValue = 1
                objWeb.SeteaGrilla(grdResultado, 10)
            End If

        Catch ex As Exception
            EnviaError("ranking_otec:Page_Load-->" & ex.Message)
        End Try

    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CReporteRankingOtec
            objReporte.RutUsuario = objSession.Rut
            objWeb = New CWeb
            Dim dt As DataTable
            objReporte.Agno = Me.ddlAgno.SelectedValue
            objReporte.Horas = Me.rbtnHH.Checked
            objReporte.GastoEmpresa = Me.rbtnValor.Checked
            objReporte.Participaciones = Me.rbtnPartiCR.Checked
            objReporte.Participantes = Me.rbtnPariSR.Checked
            'objReporte.Rango = Me.ddlRango.SelectedValue

            If Me.rbtnHH.Checked Then
                Me.lblNombreRanking.Text = "Ranking Anual de HorasHombre por Otec"
            End If
            If Me.rbtnValor.Checked Then
                Me.lblNombreRanking.Text = "Ranking Anual valor Cursos por Otec"
            End If
            If Me.rbtnPartiCR.Checked Then
                Me.lblNombreRanking.Text = "Ranking Anual de Participantes (Con Repetición) por Otec"
            End If
            If Me.rbtnPariSR.Checked Then
                Me.lblNombreRanking.Text = "Ranking Anual de Participantes (Sin Repetición) por Otec"
            End If

            

            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultado, dt)

            ''Gráfico de partcipantes
            'If objReporte.Filas > 0 Then
            '    objChart = New CChart
            '    objChart.Alto = 400
            '    objChart.Ancho = 900
            '    objChart.TipoChart = 3
            '    objChart.MostrarPorcentaje = True
            '    objChart.SeparadorDatos = " / "
            '    objChart.Decimales = 1
            '    objChart.xAxisName = ""
            '    objChart.yAxisName = ""
            '    If Me.rbtnHH.Checked Then
            '        objChart.DtDatos = objReporte.HorasData
            '    End If
            '    If Me.rbtnValor.Checked Then
            '        objChart.DtDatos = objReporte.Gasto
            '    End If
            '    If Me.rbtnPartiCR.Checked Then
            '        objChart.DtDatos = objReporte.ParticipacionesData
            '    End If
            '    If Me.rbtnPariSR.Checked Then
            '        objChart.DtDatos = objReporte.ParticipantesData
            '    End If

            '    ' objChart.DtDatos = dt
            '    'objChart.DtDatos = objReporte.HorasData
            '    objChart.Titulo = ""
            '    litGrafico.Visible = True
            '    litGrafico.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")
            'Else
            '    litGrafico.Visible = False
            'End If
            



        Catch ex As Exception
            EnviaError("ranking_otec:Consultar-->" & ex.Message)
        End Try
        



    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Consultar()
        LlenaDatosGrafico()
    End Sub
    Protected Sub grdResultado_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultado.PageIndexChanging
        grdResultado.PageIndex = e.NewPageIndex
        Consultar()
        LlenaDatosGrafico()

    End Sub
    Public Sub LlenaDatosGrafico()
        Dim dt = New DataTable
        dt.columns.add("texto")
        dt.columns.add("valor")

        Dim grdRow As GridViewRow
        For Each grdRow In grdResultado.Rows
            Dim drRow As DataRow
            drRow = dt.newRow
            drRow("texto") = CType(grdRow.FindControl("lblNombre"), Label).Text
            drRow("valor") = CType(grdRow.FindControl("lblTotal"), Label).Text.ToString.Replace("$", "")
            drRow("valor") = drRow("valor").ToString.Replace(".", "") 'CType(grdRow.FindControl("lblTotal"), Label).Text.ToString.Replace(".", "")
            dt.Rows.Add(drRow)
        Next


        'If objReporte.Filas > 0 Then
        objChart = New CChart
        objChart.Alto = 400
        objChart.Ancho = 900
        objChart.TipoChart = 3
        objChart.MostrarPorcentaje = True
        objChart.SeparadorDatos = " / "
        objChart.Decimales = 1
        objChart.xAxisName = ""
        objChart.yAxisName = ""
        'If Me.rbtnHH.Checked Then
        '    objChart.DtDatos = objReporte.HorasData
        'End If
        'If Me.rbtnValor.Checked Then
        '    objChart.DtDatos = objReporte.Gasto
        'End If
        'If Me.rbtnPartiCR.Checked Then
        '    objChart.DtDatos = objReporte.ParticipacionesData
        'End If
        'If Me.rbtnPariSR.Checked Then
        '    objChart.DtDatos = objReporte.ParticipantesData
        'End If

        objChart.DtDatos = dt
        'objChart.DtDatos = objReporte.HorasData
        objChart.Titulo = ""
        litGrafico.Visible = True
        litGrafico.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")
        'Else
        'litGrafico.Visible = False
        'End If

    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultado.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Pager AndAlso Not grdResultado.DataSource Is Nothing Then
                'TRAE EL TOTAL DE PAGINAS
                Dim _TotalPags As Label = e.Row.FindControl("lblTotalNumberOfPages")
                _TotalPags.Text = grdResultado.PageCount.ToString

                'LLENA LA LISTA CON EL NUMERO DE PAGINAS
                Dim list As DropDownList = e.Row.FindControl("paginasDropDownList")
                For i As Integer = 1 To CInt(grdResultado.PageCount)
                    Dim it As ListItem
                    Dim Existe As Boolean = False
                    For Each it In list.Items
                        If it.Text = i.ToString Then
                            Existe = True
                        End If
                    Next
                    If Not Existe Then
                        list.Items.Add(i.ToString)
                    End If
                Next
                list.SelectedValue = grdResultado.PageIndex + 1
            End If

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lblTotal As Label
                lblTotal = CType(e.Row.FindControl("lblTotal"), Label)
                Dim lblRut As Label
                lblRut = CType(e.Row.FindControl("lblRut"), Label)
                lblRut.Text = RutLngAUsr(lblRut.Text)

                If Me.rbtnValor.Checked Then
                    lblTotal.Text = FormatoPeso(lblTotal.Text)
                Else
                    lblTotal.Text = FormatoMonto(lblTotal.Text)
                End If


            End If
        Catch ex As Exception
            EnviaError("ranking_otec.aspx.vb:grdResultados_RowDataBound->" & ex.Message)
        End Try

    End Sub

    Protected Sub GoPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oIraPag As DropDownList = DirectCast(sender, DropDownList)
        Dim iNumPag As Integer = 0
        If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultado.PageCount Then
            If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultado.PageCount Then
                grdResultado.PageIndex = iNumPag - 1
            Else
                grdResultado.PageIndex = 0
            End If
        End If
        Call Consultar()
    End Sub
  
End Class
