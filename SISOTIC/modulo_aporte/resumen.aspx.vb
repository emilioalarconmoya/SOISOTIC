Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_aporte_resumen
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objLookUps As Clookups
    Dim objSesion As CSession
    Dim objIndicador As CIndicadores
    Dim objChart As CChart

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSesion)
            objWeb = Nothing
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                objWeb = New CWeb
                objLookUps = New Clookups

                objWeb.LlenaDDL(Me.ddlAgnos, objLookUps.Agnos2, "Agno_v", "Agno_t")
                ddlAgnos.SelectedValue = objSesion.Agno
                objSesion.Agno = ddlAgnos.SelectedValue
                Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_administracion/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
                objWeb = Nothing
                objLookUps = Nothing
                Consultar()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub Consultar()
        Try
            objIndicador = New CIndicadores
            objIndicador.Agno = Me.ddlAgnos.SelectedValue
            objIndicador.RutCliente = RutUsrALng(Me.txtRutEmpresa.Text)
            objIndicador.RutUsuario = objSesion.Rut
            objIndicador.CargarIndicadores3()

            Me.lblAportesIngresados.Text = objIndicador.AportesIngresados
            Me.lblAportesCobrados.Text = objIndicador.AportesCobrados
            Me.lblAportesAnulados.Text = objIndicador.AportesAnulados
            Me.lblTotalAportes.Text = objIndicador.TotalAportes
            'Me.lblAportesPendientesLetra.Text = objIndicador.AportesPendientesLetras
            'Me.lblAportesPendientesCheque.Text = objIndicador.AportesPendientesChequeAFecha

            Me.lblSolicitudAutorizada.Text = objIndicador.SolicitudesAutorizadas
            Me.lblSolicitudRechazada.Text = objIndicador.SolicitudesRechazadas
            Me.lblSolicitudPendiente.Text = objIndicador.SolicitudesPendientes
            Me.lblTotalSolicitudes.Text = objIndicador.TotalSolicitudes

            'If objIndicador.TotalAportes > 0 Then
            objChart = New CChart
            objChart.Alto = 300
            objChart.Ancho = 450
            objChart.TipoChart = 3
            objChart.PreVal = ""
            objChart.PosVal = ""
            objChart.Decimales = 0
            objChart.xAxisName = "Indicador"
            objChart.yAxisName = "Valor"
            objChart.DtDatos = objIndicador.GraficoAportes
            objChart.Titulo = ""
            litGraficoAportes.Visible = True
            litGraficoAportes.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")
            ' Else
            'Me.litGraficoAportes.Visible = False
            ' End If

            'If objIndicador.TotalSolicitudes > 0 Then
            objChart = New CChart
            objChart.Alto = 300
            objChart.Ancho = 400
            objChart.TipoChart = 3
            objChart.PreVal = ""
            objChart.PosVal = ""
            objChart.Decimales = 0
            objChart.xAxisName = "Indicador"
            objChart.yAxisName = "Valor"
            objChart.DtDatos = objIndicador.GraficoSolicitudes
            objChart.Titulo = ""
            litGraficoSolicitudes.Visible = True
            litGraficoSolicitudes.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv3")
            'Else
            'Me.litGraficoSolicitudes.Visible = False
            'End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
End Class
