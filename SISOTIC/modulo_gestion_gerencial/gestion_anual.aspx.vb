Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_gestion_gerencial_gestion_anual
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objInforme As New CInformeGestionAnual
    Dim curso As New CCursoInterno
    Dim objLookups As New Clookups
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
            
            Dim lngRut As Long
            'lngRut = objSession.Rut
            objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
            objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
            objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
            objWeb.AgregaValorDDL(Me.ddlEjecutivo, "Todos", 0)
            objWeb.AgregaValorDDL(Me.ddlSucursal, "Todas", 0)
            ddlAgnos.SelectedValue = Now.Year()
            ddlEjecutivo.SelectedValue = 0
            ddlSucursal.SelectedValue = 0
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_administracion/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1_', 380, 700, 100, 100);return false;")
            'Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            'ddlAgnos.SelectedValue = objSession.Agno
            'objWeb.SeteaGrilla(GridResultados, TAM_PAG)
        End If
    End Sub
    Private Sub Consultar()
        objInforme = New CInformeGestionAnual


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

        objInforme.PeriodoInt = Me.ddlAgnos.SelectedValue

        objInforme.Holding = Me.chkEmp.Checked
        objInforme.Inicializar()

        'Dim dt As DataTable
        objInforme.Cargar(Me.chkEmp.Checked, Me.txtRutEmpresa.Text, Me.ddlSucursal.SelectedValue, Me.ddlEjecutivo.SelectedValue, Me.ddlAgnos.SelectedValue)

        Me.lblCostoOticReal1.Text = objInforme.CostoOticReal1
        Me.lblCostoOticReal2.Text = objInforme.CostoOticReal2
        Me.lblCostoOticReal3.Text = objInforme.CostoOticReal3
        Me.lblCostoOticReal4.Text = objInforme.CostoOticReal4
        Me.lblCostoOticReal5.Text = objInforme.CostoOticReal5
        Me.lblCostoOticReal6.Text = objInforme.CostoOticReal6
        Me.lblCostoOticReal7.Text = objInforme.CostoOticReal7
        Me.lblCostoOticReal8.Text = objInforme.CostoOticReal8
        Me.lblCostoOticReal9.Text = objInforme.CostoOticReal9
        Me.lblCostoOticReal10.Text = objInforme.CostoOticReal10
        Me.lblCostoOticReal11.Text = objInforme.CostoOticReal11
        Me.lblCostoOticReal12.Text = objInforme.CostoOticReal12
        Me.lblTotalCostoOticReal.Text = objInforme.TotalCostoOticReal

        Me.lblCostoOticExc1.Text = objInforme.CostoOticExc1
        Me.lblCostoOticExc2.Text = objInforme.CostoOticExc2
        Me.lblCostoOticExc3.Text = objInforme.CostoOticExc3
        Me.lblCostoOticExc4.Text = objInforme.CostoOticExc4
        Me.lblCostoOticExc5.Text = objInforme.CostoOticExc5
        Me.lblCostoOticExc6.Text = objInforme.CostoOticExc6
        Me.lblCostoOticExc7.Text = objInforme.CostoOticExc7
        Me.lblCostoOticExc8.Text = objInforme.CostoOticExc8
        Me.lblCostoOticExc9.Text = objInforme.CostoOticExc9
        Me.lblCostoOticExc10.Text = objInforme.CostoOticExc10
        Me.lblCostoOticExc11.Text = objInforme.CostoOticExc11
        Me.lblCostoOticExc12.Text = objInforme.CostoOticExc12
        Me.lblTotalCostoOticExc.Text = objInforme.TotalCostoOticExc

        Me.lblAdmin1.Text = objInforme.CostoAdmin1
        Me.lblAdmin2.Text = objInforme.CostoAdmin2
        Me.lblAdmin3.Text = objInforme.CostoAdmin3
        Me.lblAdmin4.Text = objInforme.CostoAdmin4
        Me.lblAdmin5.Text = objInforme.CostoAdmin5
        Me.lblAdmin6.Text = objInforme.CostoAdmin6
        Me.lblAdmin7.Text = objInforme.CostoAdmin7
        Me.lblAdmin8.Text = objInforme.CostoAdmin8
        Me.lblAdmin9.Text = objInforme.CostoAdmin9
        Me.lblAdmin10.Text = objInforme.CostoAdmin10
        Me.lblAdmin11.Text = objInforme.CostoAdmin11
        Me.lblAdmin12.Text = objInforme.CostoAdmin12
        Me.lblTotalAdmin.Text = objInforme.TotalCostoAdmin

        Me.lblAporteEntregados1.Text = objInforme.AportesEnterados1
        Me.lblAporteEntregados2.Text = objInforme.AportesEnterados2
        Me.lblAporteEntregados3.Text = objInforme.AportesEnterados3
        Me.lblAporteEntregados4.Text = objInforme.AportesEnterados4
        Me.lblAporteEntregados5.Text = objInforme.AportesEnterados5
        Me.lblAporteEntregados6.Text = objInforme.AportesEnterados6
        Me.lblAporteEntregados7.Text = objInforme.AportesEnterados7
        Me.lblAporteEntregados8.Text = objInforme.AportesEnterados8
        Me.lblAporteEntregados9.Text = objInforme.AportesEnterados9
        Me.lblAporteEntregados10.Text = objInforme.AportesEnterados10
        Me.lblAporteEntregados11.Text = objInforme.AportesEnterados11
        Me.lblAporteEntregados12.Text = objInforme.AportesEnterados12
        Me.lblTotalAporteEntregados.Text = objInforme.TotalAportesEnt

        Me.lblAportespendientes1.Text = objInforme.AportesPendientes1
        Me.lblAportespendientes2.Text = objInforme.AportesPendientes2
        Me.lblAportespendientes3.Text = objInforme.AportesPendientes3
        Me.lblAportespendientes4.Text = objInforme.AportesPendientes4
        Me.lblAportespendientes5.Text = objInforme.AportesPendientes5
        Me.lblAportespendientes6.Text = objInforme.AportesPendientes6
        Me.lblAportespendientes7.Text = objInforme.AportesPendientes7
        Me.lblAportespendientes8.Text = objInforme.AportesPendientes8
        Me.lblAportespendientes9.Text = objInforme.AportesPendientes9
        Me.lblAportespendientes10.Text = objInforme.AportesPendientes10
        Me.lblAportespendientes11.Text = objInforme.AportesPendientes11
        Me.lblAportespendientes12.Text = objInforme.AportesPendientes12
        Me.lblTotalAportespendientes.Text = objInforme.TotalAportesPend

        Me.lblfacturasPagadas1.Text = objInforme.FacturasPagadasData1
        Me.lblfacturasPagadas2.Text = objInforme.FacturasPagadasData2
        Me.lblfacturasPagadas3.Text = objInforme.FacturasPagadasData3
        Me.lblfacturasPagadas4.Text = objInforme.FacturasPagadasData4
        Me.lblfacturasPagadas5.Text = objInforme.FacturasPagadasData5
        Me.lblfacturasPagadas6.Text = objInforme.FacturasPagadasData6
        Me.lblfacturasPagadas7.Text = objInforme.FacturasPagadasData7
        Me.lblfacturasPagadas8.Text = objInforme.FacturasPagadasData8
        Me.lblfacturasPagadas9.Text = objInforme.FacturasPagadasData9
        Me.lblfacturasPagadas10.Text = objInforme.FacturasPagadasData10
        Me.lblfacturasPagadas11.Text = objInforme.FacturasPagadasData11
        Me.lblfacturasPagadas12.Text = objInforme.FacturasPagadasData12
        Me.lblTotalfacturasPagadas.Text = objInforme.FacturasPagadas

        Me.lblFacturasXPagar1.Text = objInforme.FacturasPorPagarData1
        Me.lblFacturasXPagar2.Text = objInforme.FacturasPorPagarData2
        Me.lblFacturasXPagar3.Text = objInforme.FacturasPorPagarData3
        Me.lblFacturasXPagar4.Text = objInforme.FacturasPorPagarData4
        Me.lblFacturasXPagar5.Text = objInforme.FacturasPorPagarData5
        Me.lblFacturasXPagar6.Text = objInforme.FacturasPorPagarData6
        Me.lblFacturasXPagar7.Text = objInforme.FacturasPorPagarData7
        Me.lblFacturasXPagar8.Text = objInforme.FacturasPorPagarData8
        Me.lblFacturasXPagar9.Text = objInforme.FacturasPorPagarData9
        Me.lblFacturasXPagar10.Text = objInforme.FacturasPorPagarData10
        Me.lblFacturasXPagar11.Text = objInforme.FacturasPorPagarData11
        Me.lblFacturasXPagar12.Text = objInforme.FacturasPorPagarData12
        Me.lblTotalFacturasXPagar.Text = objInforme.FacturasPorPagar

        Me.lblCtaCap1.Text = objInforme.CtaCapData1
        Me.lblCtaCap2.Text = objInforme.CtaCapData2
        Me.lblCtaCap3.Text = objInforme.CtaCapData3
        Me.lblCtaCap4.Text = objInforme.CtaCapData4
        Me.lblCtaCap5.Text = objInforme.CtaCapData5
        Me.lblCtaCap6.Text = objInforme.CtaCapData6
        Me.lblCtaCap7.Text = objInforme.CtaCapData7
        Me.lblCtaCap8.Text = objInforme.CtaCapData8
        Me.lblCtaCap9.Text = objInforme.CtaCapData9
        Me.lblCtaCap10.Text = objInforme.CtaCapData10
        Me.lblCtaCap11.Text = objInforme.CtaCapData11
        Me.lblCtaCap12.Text = objInforme.CtaCapData12
        Me.lblTotalCtaCap.Text = objInforme.CtaCap

        Me.lblCtaExcCap1.Text = objInforme.ExcCap1
        Me.lblCtaExcCap2.Text = objInforme.ExcCap2
        Me.lblCtaExcCap3.Text = objInforme.ExcCap3
        Me.lblCtaExcCap4.Text = objInforme.ExcCap4
        Me.lblCtaExcCap5.Text = objInforme.ExcCap5
        Me.lblCtaExcCap6.Text = objInforme.ExcCap6
        Me.lblCtaExcCap7.Text = objInforme.ExcCap7
        Me.lblCtaExcCap8.Text = objInforme.ExcCap8
        Me.lblCtaExcCap9.Text = objInforme.ExcCap9
        Me.lblCtaExcCap10.Text = objInforme.ExcCap10
        Me.lblCtaExcCap11.Text = objInforme.ExcCap11
        Me.lblCtaExcCap12.Text = objInforme.ExcCap12
        Me.lblTotalCtaExcCap.Text = objInforme.CtaExcCap

        Me.lblPagoATerceros1.Text = objInforme.PagoATerceros1
        Me.lblPagoATerceros2.Text = objInforme.PagoATerceros2
        Me.lblPagoATerceros3.Text = objInforme.PagoATerceros3
        Me.lblPagoATerceros4.Text = objInforme.PagoATerceros4
        Me.lblPagoATerceros5.Text = objInforme.PagoATerceros5
        Me.lblPagoATerceros6.Text = objInforme.PagoATerceros6
        Me.lblPagoATerceros7.Text = objInforme.PagoATerceros7
        Me.lblPagoATerceros8.Text = objInforme.PagoATerceros8
        Me.lblPagoATerceros9.Text = objInforme.PagoATerceros9
        Me.lblPagoATerceros10.Text = objInforme.PagoATerceros10
        Me.lblPagoATerceros11.Text = objInforme.PagoATerceros11
        Me.lblPagoATerceros12.Text = objInforme.PagoATerceros12
        Me.lblTotalPagoATerceros.Text = objInforme.ATerceros

        Me.lblPagoDeTerceros1.Text = objInforme.PagoDeTerceros1
        Me.lblPagoDeTerceros2.Text = objInforme.PagoDeTerceros2
        Me.lblPagoDeTerceros3.Text = objInforme.PagoDeTerceros3
        Me.lblPagoDeTerceros4.Text = objInforme.PagoDeTerceros4
        Me.lblPagoDeTerceros5.Text = objInforme.PagoDeTerceros5
        Me.lblPagoDeTerceros6.Text = objInforme.PagoDeTerceros6
        Me.lblPagoDeTerceros7.Text = objInforme.PagoDeTerceros7
        Me.lblPagoDeTerceros8.Text = objInforme.PagoDeTerceros8
        Me.lblPagoDeTerceros9.Text = objInforme.PagoDeTerceros9
        Me.lblPagoDeTerceros10.Text = objInforme.PagoDeTerceros10
        Me.lblPagoDeTerceros11.Text = objInforme.PagoDeTerceros11
        Me.lblPagoDeTerceros12.Text = objInforme.PagoDeTerceros12
        Me.lblTotalPagoDeTerceros.Text = objInforme.DeTerceros




    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
End Class
