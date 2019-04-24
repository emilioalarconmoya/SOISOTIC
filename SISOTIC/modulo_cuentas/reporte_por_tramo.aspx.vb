Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_reporte_por_tramo
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim objSession As CSession
    Dim objWeb As CWeb
    Dim objLookups As New Clookups
    Dim objReporte As New CInformePorFranquicia
    Dim objChart As New CChart
    Private objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '************************************
        ViewState("RutCliente") = Request("RutCliente")
        ViewState("agno") = objSession.Agno
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            objWeb.SeteaGrilla(grdResultados, TAM_PAG)
            If objSession.EsClienteIngresoCurso Then
                Me.hplIngresoCurso.Visible = True
            End If
            'Consultar()
            'CargaCabecera()
        End If
        'objWeb = New CWeb
        objWeb.ChequeaCliente(objSessionCliente)
        If Not objSessionCliente Is Nothing Then
            Consultar()
        End If
    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CInformePorFranquicia
            objReporte.RutCliente = objSessionCliente.Rut ' objSession.Rut
            objReporte.Agno = objSession.Agno
            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)

            'Gráfico de partcipantes
            If objReporte.Filas > 0 Then
                objChart = New CChart
                objChart.Alto = 300
                objChart.Ancho = 450
                objChart.TipoChart = 2
                objChart.MostrarPorcentaje = True
                objChart.SeparadorDatos = " / "
                objChart.Decimales = 1
                objChart.xAxisName = "Rango"
                objChart.yAxisName = "Cantidad"
                objChart.DtDatos = objReporte.Resultado
                objChart.Titulo = "Porcentaje por participante (Curso sence)"
                litGrafico.Visible = True
                litGrafico.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")
            Else
                litGrafico.Visible = False
            End If

            'Gráfico de HH
            If objReporte.Filas > 0 Then
                objChart = New CChart
                objChart.Alto = 300
                objChart.Ancho = 450
                objChart.TipoChart = 2
                objChart.MostrarPorcentaje = True
                objChart.SeparadorDatos = " / "
                objChart.Decimales = 1
                objChart.xAxisName = "Rango"
                objChart.yAxisName = "Cantidad"
                objChart.DtDatos = objReporte.ResultadoHH
                objChart.Titulo = "Porcentaje por horas hombre (Curso sence)"
                litGrafico2.Visible = True
                litGrafico2.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv2")
            Else
                litGrafico2.Visible = False
            End If
        Catch ex As Exception
            EnviaError("reporte_por_tramo.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub


    Protected Sub grdResultados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdResultados.SelectedIndexChanged
        'grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    'Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound

    'End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(datos_personales1.FindControl("txtRutEmpresa"), TextBox).Text
    End Sub
End Class
