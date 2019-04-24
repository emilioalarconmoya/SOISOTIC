Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_gestion_gerencial_gestion_mensual
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As New CSession
    Dim objInforme As New CInformeGestionMensual
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
            lblPie.Text = Parametros.p_PIE
            Dim lngRut As Long
            lngRut = objSession.Rut
            objWeb.LlenaDDL(ddlMeses, objLookups.Meses, "Mes_v", "Mes_t")
            objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
            objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
            objWeb.AgregaValorDDL(Me.ddlEjecutivo, "Todos", 0)
            objWeb.AgregaValorDDL(Me.ddlSucursal, "Todas", 0)
            objWeb.AgregaValorDDL(Me.ddlMeses, "Todos", 0)
            ddlMeses.SelectedValue = 0
            ddlEjecutivo.SelectedValue = 0
            ddlSucursal.SelectedValue = 0
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_administracion/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            'ddlAgnos.SelectedValue = objSession.Agno
            'objWeb.SeteaGrilla(GridResultados, TAM_PAG)
            Consultar()
        End If
    End Sub
    Private Sub Consultar()
        objInforme = New CInformeGestionMensual
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

        objInforme.PeriodoInt = Me.ddlMeses.SelectedValue

        objInforme.Holding = Me.chkEmp.Checked
        objInforme.Inicializar()

        'Dim dt As DataTable
        objInforme.Cargar(Me.chkEmp.Checked, Me.txtRutEmpresa.Text, Me.ddlSucursal.SelectedValue, Me.ddlEjecutivo.SelectedValue, Me.ddlMeses.SelectedValue)

        Me.lblAgno1.Text = objInforme.ContPeriodo1
        Me.lblAgno2.Text = objInforme.ContPeriodo2
        Me.lblAgno3.Text = objInforme.ContPeriodo3
        Me.lblAgno4.Text = objInforme.ContPeriodo4


        Me.lblCostoOtic1.Text = objInforme.CostoOticReal1
        Me.lblCostoOtic2.Text = objInforme.CostoOticReal2
        Me.lblCostoOtic3.Text = objInforme.CostoOticReal3
        Me.lblCostoOtic4.Text = objInforme.CostoOticReal4
        

        Me.lblCostoOticEx1.Text = objInforme.CostoOticExc1
        Me.lblCostoOticEx2.Text = objInforme.CostoOticExc2
        Me.lblCostoOticEx3.Text = objInforme.CostoOticExc3
        Me.lblCostoOticEx4.Text = objInforme.CostoOticExc4
        

        Me.lblAdministracion1.Text = objInforme.CostoAdmin1
        Me.lblAdministracion2.Text = objInforme.CostoAdmin2
        Me.lblAdministracion3.Text = objInforme.CostoAdmin3
        Me.lblAdministracion4.Text = objInforme.CostoAdmin4
        

        Me.lblAportesEnterados1.Text = objInforme.AportesEnterados1
        Me.lblAportesEnterados2.Text = objInforme.AportesEnterados2
        Me.lblAportesEnterados3.Text = objInforme.AportesEnterados3
        Me.lblAportesEnterados4.Text = objInforme.AportesEnterados4
       

        Me.lblAportespendientes1.Text = objInforme.AportesPendientes1
        Me.lblAportespendientes2.Text = objInforme.AportesPendientes2
        Me.lblAportespendientes3.Text = objInforme.AportesPendientes3
        Me.lblAportespendientes4.Text = objInforme.AportesPendientes4
        

        Me.lblfacturasPagadas1.Text = objInforme.FacturasPagadasData1
        Me.lblfacturasPagadas2.Text = objInforme.FacturasPagadasData2
        Me.lblfacturasPagadas3.Text = objInforme.FacturasPagadasData3
        Me.lblfacturasPagadas4.Text = objInforme.FacturasPagadasData4
        

        Me.lblFacturasXPagar1.Text = objInforme.FacturasPorPagarData1
        Me.lblFacturasXPagar2.Text = objInforme.FacturasPorPagarData2
        Me.lblFacturasXPagar3.Text = objInforme.FacturasPorPagarData3
        Me.lblFacturasXPagar4.Text = objInforme.FacturasPorPagarData4
        

        Me.lblCtaCap1.Text = objInforme.CtaCapData1
        Me.lblCtaCap2.Text = objInforme.CtaCapData2
        Me.lblCtaCap3.Text = objInforme.CtaCapData3
        Me.lblCtaCap4.Text = objInforme.CtaCapData4
        

        Me.lblCtaExCap1.Text = objInforme.ExcCap1
        Me.lblCtaExCap2.Text = objInforme.ExcCap2
        Me.lblCtaExCap3.Text = objInforme.ExcCap3
        Me.lblCtaExCap4.Text = objInforme.ExcCap4
       

        Me.lblPagoATerceros1.Text = objInforme.PagoATerceros1
        Me.lblPagoATerceros2.Text = objInforme.PagoATerceros2
        Me.lblPagoATerceros3.Text = objInforme.PagoATerceros3
        Me.lblPagoATerceros4.Text = objInforme.PagoATerceros4
        

        Me.lblPagoDeTerceros1.Text = objInforme.PagoDeTerceros1
        Me.lblPagoDeTerceros2.Text = objInforme.PagoDeTerceros2
        Me.lblPagoDeTerceros3.Text = objInforme.PagoDeTerceros3
        Me.lblPagoDeTerceros4.Text = objInforme.PagoDeTerceros4
       




    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
End Class


