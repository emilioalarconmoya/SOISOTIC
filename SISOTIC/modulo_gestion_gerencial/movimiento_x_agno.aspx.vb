Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_gestion_gerencial_movimiento_x_agno
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objInforme As CInformeMensual
    Dim curso As New CCursoInterno
    Dim objLookups As New Clookups
    Dim objChart As New CChart

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '*********************************** 
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            Dim lngRut As Long
            lngRut = objSession.Rut
            objWeb.LlenaDDL(ddlCorte, objLookups.corte, "corte_v", "corte_t")
            objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
            objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
            objWeb.AgregaValorDDL(Me.ddlEjecutivo, "Todos", 0)
            objWeb.AgregaValorDDL(Me.ddlSucursal, "Todas", 0)
            'objWeb.AgregaValorDDL(Me.ddlAgno, "Todos", 0)
            ddlCorte.SelectedValue = 2
            ddlEjecutivo.SelectedValue = 0
            ddlSucursal.SelectedValue = 0
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_administracion/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            'ddlAgnos.SelectedValue = objSession.Agno
            'objWeb.SeteaGrilla(GridResultados, TAM_PAG)
            Consultar()
        End If
    End Sub
    Private Sub Consultar()
        objInforme = New CInformeMensual
        objInforme.RutUsuario = objSession.Rut
        If Me.txtRutEmpresa.Text = "" Then
            objInforme.RutCliente = 0
        Else
            objInforme.RutCliente = RutUsrALng(Me.txtRutEmpresa.Text)
        End If


        If Me.ddlEjecutivo.SelectedValue = 0 Then
            objInforme.RutEjecutivo = 0
        Else
            objInforme.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
        End If

        If Me.ddlSucursal.SelectedValue = 0 Then
            objInforme.CodSucursal = 0
        Else
            objInforme.CodSucursal = Me.ddlSucursal.SelectedValue
        End If

        objInforme.PeriodoInt = Me.ddlCorte.SelectedValue

        objInforme.Holding = Me.chkEmp.Checked
        objInforme.Inicializar()

        'Dim dt As DataTable
        objInforme.Cargar(Me.chkEmp.Checked, Me.txtRutEmpresa.Text, Me.ddlSucursal.SelectedValue, Me.ddlEjecutivo.SelectedValue, Me.ddlCorte.SelectedValue)

        Me.lblAgno1.Text = objInforme.ContPeriodo1
        Me.lblAgno2.Text = objInforme.ContPeriodo2
        Me.lblAgno3.Text = objInforme.ContPeriodo3
        Me.lblAgno4.Text = objInforme.ContPeriodo4


        Me.lblCostoOticReal1.Text = FormatoMonto(objInforme.CostoOticReal1)
        Me.lblCostoOticReal2.Text = FormatoMonto(objInforme.CostoOticReal2)
        Me.lblCostoOticReal3.Text = FormatoMonto(objInforme.CostoOticReal3)
        Me.lblCostoOticReal4.Text = FormatoMonto(objInforme.CostoOticReal4)
        'Me.lblCostoOticReal5.Text = FormatoMonto(objInforme.CostoOticReal5)
        'Me.lblCostoOticReal6.Text = FormatoMonto(objInforme.CostoOticReal6)
        'Me.lblCostoOticReal7.Text = FormatoMonto(objInforme.CostoOticReal7)
        'Me.lblCostoOticReal8.Text = FormatoMonto(objInforme.CostoOticReal8)
        'Me.lblCostoOticReal9.Text = FormatoMonto(objInforme.CostoOticReal9)
        'Me.lblCostoOticReal10.Text = FormatoMonto(objInforme.CostoOticReal10)
        'Me.lblCostoOticReal11.Text = FormatoMonto(objInforme.CostoOticReal11)
        'Me.lblCostoOticReal12.Text = FormatoMonto(objInforme.CostoOticReal12)
        'Me.lblTotalCostoOticReal.Text = FormatoMonto(objInforme.CostoOticReal1 + objInforme.CostoOticReal2 + objInforme.CostoOticReal3 + objInforme.CostoOticReal4 + objInforme.CostoOticReal5 + objInforme.CostoOticReal6 + objInforme.CostoOticReal7 + objInforme.CostoOticReal8 + objInforme.CostoOticReal9 + objInforme.CostoOticReal10 + objInforme.CostoOticReal11 + objInforme.CostoOticReal12)

        Me.lblCostoOticExc1.Text = FormatoMonto(objInforme.CostoOticExc1)
        Me.lblCostoOticExc2.Text = FormatoMonto(objInforme.CostoOticExc2)
        Me.lblCostoOticExc3.Text = FormatoMonto(objInforme.CostoOticExc3)
        Me.lblCostoOticExc4.Text = FormatoMonto(objInforme.CostoOticExc4)
        'Me.lblCostoOticExc5.Text = FormatoMonto(objInforme.CostoOticExc5)
        'Me.lblCostoOticExc6.Text = FormatoMonto(objInforme.CostoOticExc6)
        'Me.lblCostoOticExc7.Text = FormatoMonto(objInforme.CostoOticExc7)
        'Me.lblCostoOticExc8.Text = FormatoMonto(objInforme.CostoOticExc8)
        'Me.lblCostoOticExc9.Text = FormatoMonto(objInforme.CostoOticExc9)
        'Me.lblCostoOticExc10.Text = FormatoMonto(objInforme.CostoOticExc10)
        'Me.lblCostoOticExc11.Text = FormatoMonto(objInforme.CostoOticExc11)
        'Me.lblCostoOticExc12.Text = FormatoMonto(objInforme.CostoOticExc12)
        'Me.lblTotalCostoOticExc.Text = FormatoMonto(objInforme.CostoOticExc1 + objInforme.CostoOticExc2 + objInforme.CostoOticExc3 + objInforme.CostoOticExc4 + objInforme.CostoOticExc5 + objInforme.CostoOticExc6 + objInforme.CostoOticExc7 + objInforme.CostoOticExc8 + objInforme.CostoOticExc9 + objInforme.CostoOticExc10 + objInforme.CostoOticExc11 + objInforme.CostoOticExc12)

        Me.lblGastoEmp1.Text = FormatoMonto(objInforme.GastoEmpresa1)
        Me.lblGastoEmp2.Text = FormatoMonto(objInforme.GastoEmpresa2)
        Me.lblGastoEmp3.Text = FormatoMonto(objInforme.GastoEmpresa3)
        Me.lblGastoEmp4.Text = FormatoMonto(objInforme.GastoEmpresa4)
        'Me.lblGastoEmp5.Text = FormatoMonto(objInforme.GastoEmpresa5)
        'Me.lblGastoEmp6.Text = FormatoMonto(objInforme.GastoEmpresa6)
        'Me.lblGastoEmp7.Text = FormatoMonto(objInforme.GastoEmpresa7)
        'Me.lblGastoEmp8.Text = FormatoMonto(objInforme.GastoEmpresa8)
        'Me.lblGastoEmp9.Text = FormatoMonto(objInforme.GastoEmpresa9)
        'Me.lblGastoEmp10.Text = FormatoMonto(objInforme.GastoEmpresa10)
        'Me.lblGastoEmp11.Text = FormatoMonto(objInforme.GastoEmpresa11)
        'Me.lblGastoEmp12.Text = FormatoMonto(objInforme.GastoEmpresa12)
        'Me.lblTotalGastoEmp.Text = FormatoMonto(objInforme.GastoEmpresa1 + objInforme.GastoEmpresa2 + objInforme.GastoEmpresa3 + objInforme.GastoEmpresa4 + objInforme.GastoEmpresa5 + objInforme.GastoEmpresa6 + objInforme.GastoEmpresa7 + objInforme.GastoEmpresa8 + objInforme.GastoEmpresa9 + objInforme.GastoEmpresa10 + objInforme.GastoEmpresa11 + objInforme.GastoEmpresa12)

        Me.lblCostoAdm1.Text = FormatoMonto(objInforme.CostoAdmin1)
        Me.lblCostoAdm2.Text = FormatoMonto(objInforme.CostoAdmin2)
        Me.lblCostoAdm3.Text = FormatoMonto(objInforme.CostoAdmin3)
        Me.lblCostoAdm4.Text = FormatoMonto(objInforme.CostoAdmin4)
        'Me.lblCostoAdm5.Text = FormatoMonto(objInforme.CostoAdmin5)
        'Me.lblCostoAdm6.Text = FormatoMonto(objInforme.CostoAdmin6)
        'Me.lblCostoAdm7.Text = FormatoMonto(objInforme.CostoAdmin7)
        'Me.lblCostoAdm8.Text = FormatoMonto(objInforme.CostoAdmin8)
        'Me.lblCostoAdm9.Text = FormatoMonto(objInforme.CostoAdmin9)
        'Me.lblCostoAdm10.Text = FormatoMonto(objInforme.CostoAdmin10)
        'Me.lblCostoAdm11.Text = FormatoMonto(objInforme.CostoAdmin11)
        'Me.lblCostoAdm12.Text = FormatoMonto(objInforme.CostoAdmin12)
        'Me.lblTotalCostoAdm.Text = FormatoMonto(objInforme.CostoAdmin1 + objInforme.CostoAdmin2 + objInforme.CostoAdmin3 + objInforme.CostoAdmin4 + objInforme.CostoAdmin5 + objInforme.CostoAdmin6 + objInforme.CostoAdmin7 + objInforme.CostoAdmin8 + objInforme.CostoAdmin9 + objInforme.CostoAdmin10 + objInforme.CostoAdmin11 + objInforme.CostoAdmin12)

        Me.lblTotal1.Text = FormatoMonto(objInforme.SumaCostos1)
        Me.lblTotal2.Text = FormatoMonto(objInforme.SumaCostos2)
        Me.lblTotal3.Text = FormatoMonto(objInforme.SumaCostos3)
        Me.lblTotal4.Text = FormatoMonto(objInforme.SumaCostos4)
        'Me.lblTotal5.Text = FormatoMonto(objInforme.SumaCostos5)
        'Me.lblTotal6.Text = FormatoMonto(objInforme.SumaCostos6)
        'Me.lblTotal7.Text = FormatoMonto(objInforme.SumaCostos7)
        'Me.lblTotal8.Text = FormatoMonto(objInforme.SumaCostos8)
        'Me.lblTotal9.Text = FormatoMonto(objInforme.SumaCostos9)
        'Me.lblTotal10.Text = FormatoMonto(objInforme.SumaCostos10)
        'Me.lblTotal11.Text = FormatoMonto(objInforme.SumaCostos11)
        'Me.lblTotal12.Text = FormatoMonto(objInforme.SumaCostos12)
        'Me.lblTotalTotal.Text = FormatoMonto(objInforme.SumaCostos1 + objInforme.SumaCostos2 + objInforme.SumaCostos3 + objInforme.SumaCostos4 + objInforme.SumaCostos5 + objInforme.SumaCostos6 + objInforme.SumaCostos7 + objInforme.SumaCostos8 + objInforme.SumaCostos9 + objInforme.SumaCostos10 + objInforme.SumaCostos11 + objInforme.SumaCostos12)

        Me.lblAportesNeto1.Text = FormatoMonto(objInforme.Aportes1)
        Me.lblAportesNeto2.Text = FormatoMonto(objInforme.Aportes2)
        Me.lblAportesNeto3.Text = FormatoMonto(objInforme.Aportes3)
        Me.lblAportesNeto4.Text = FormatoMonto(objInforme.Aportes4)
        'Me.lblAportesNeto5.Text = FormatoMonto(objInforme.Aportes5)
        'Me.lblAportesNeto6.Text = FormatoMonto(objInforme.Aportes6)
        'Me.lblAportesNeto7.Text = FormatoMonto(objInforme.Aportes7)
        'Me.lblAportesNeto8.Text = FormatoMonto(objInforme.Aportes8)
        'Me.lblAportesNeto9.Text = FormatoMonto(objInforme.Aportes9)
        'Me.lblAportesNeto10.Text = FormatoMonto(objInforme.Aportes10)
        'Me.lblAportesNeto11.Text = FormatoMonto(objInforme.Aportes11)
        'Me.lblAportesNeto12.Text = FormatoMonto(objInforme.Aportes12)
        'Me.lblTotalAportesNeto.Text = FormatoMonto(objInforme.Aportes1 + objInforme.Aportes2 + objInforme.Aportes3 + objInforme.Aportes4 + objInforme.Aportes5 + objInforme.Aportes6 + objInforme.Aportes7 + objInforme.Aportes8 + objInforme.Aportes9 + objInforme.Aportes10 + objInforme.Aportes11 + objInforme.Aportes12)

        Me.lblAdm1.Text = FormatoMonto(objInforme.AdmAportes1)
        Me.lblAdm2.Text = FormatoMonto(objInforme.AdmAportes2)
        Me.lblAdm3.Text = FormatoMonto(objInforme.AdmAportes3)
        Me.lblAdm4.Text = FormatoMonto(objInforme.AdmAportes4)
        'Me.lblAdm5.Text = FormatoMonto(objInforme.AdmAportes5)
        'Me.lblAdm6.Text = FormatoMonto(objInforme.AdmAportes6)
        'Me.lblAdm7.Text = FormatoMonto(objInforme.AdmAportes7)
        'Me.lblAdm8.Text = FormatoMonto(objInforme.AdmAportes8)
        'Me.lblAdm9.Text = FormatoMonto(objInforme.AdmAportes9)
        'Me.lblAdm10.Text = FormatoMonto(objInforme.AdmAportes10)
        'Me.lblAdm11.Text = FormatoMonto(objInforme.AdmAportes11)
        'Me.lblAdm12.Text = FormatoMonto(objInforme.AdmAportes12)
        'Me.lblTotalAdm.Text = FormatoMonto(objInforme.AdmAportes1 + objInforme.AdmAportes2 + objInforme.AdmAportes3 + objInforme.AdmAportes4 + objInforme.AdmAportes5 + objInforme.AdmAportes6 + objInforme.AdmAportes7 + objInforme.AdmAportes8 + objInforme.AdmAportes9 + objInforme.AdmAportes10 + objInforme.AdmAportes11 + objInforme.AdmAportes12)

        Me.lblTotalAportes1.Text = FormatoMonto(objInforme.SumaAportes1)
        Me.lblTotalAportes2.Text = FormatoMonto(objInforme.SumaAportes2)
        Me.lblTotalAportes3.Text = FormatoMonto(objInforme.SumaAportes3)
        Me.lblTotalAportes4.Text = FormatoMonto(objInforme.SumaAportes4)
        'Me.lblTotalAportes5.Text = FormatoMonto(objInforme.SumaAportes5)
        'Me.lblTotalAportes6.Text = FormatoMonto(objInforme.SumaAportes6)
        'Me.lblTotalAportes7.Text = FormatoMonto(objInforme.SumaAportes7)
        'Me.lblTotalAportes8.Text = FormatoMonto(objInforme.SumaAportes8)
        'Me.lblTotalAportes9.Text = FormatoMonto(objInforme.SumaAportes9)
        'Me.lblTotalAportes10.Text = FormatoMonto(objInforme.SumaAportes10)
        'Me.lblTotalAportes11.Text = FormatoMonto(objInforme.SumaAportes11)
        'Me.lblTotalAportes12.Text = FormatoMonto(objInforme.SumaAportes12)
        'Me.lblTotalTotalAportes.Text = FormatoMonto(objInforme.SumaAportes1 + objInforme.SumaAportes2 + objInforme.SumaAportes3 + objInforme.SumaAportes4 + objInforme.SumaAportes5 + objInforme.SumaAportes6 + objInforme.SumaAportes7 + objInforme.SumaAportes8 + objInforme.SumaAportes9 + objInforme.SumaAportes10 + objInforme.SumaAportes11 + objInforme.SumaAportes12)



        '************************

        'objChart.PreVal = ""
        'objChart.PosVal = ""
        'objChart.Decimales = 0
        'objChart.xAxisName = ""
        'objChart.yAxisName = ""
        ''objChart.DtDatos = objReporte.GraficoTortaCursosSence
        'objChart.Titulo = "Distribución del dinero en el año"
        ''litGrafico1.Visible = True
        ''litGrafico1.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")

        objChart = New CChart
        objChart.Alto = 300
        objChart.Ancho = 400
        objChart.TipoChart = 7
        objChart.PreVal = ""
        objChart.PosVal = ""
        objChart.Decimales = 0
        objChart.xAxisName = "Años"
        objChart.yAxisName = "Cantidad"
        objChart.DtDatos = objInforme.GraficoBarras
        objChart.Titulo = ""
        litGrafico.Visible = True
        litGrafico.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv3")

















    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
End Class
