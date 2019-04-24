Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_gestion_gerencial_reporte_cartera
    Inherits System.Web.UI.Page
    Dim objSession As CSession
    Dim objInforme As New CInformeCartera
    Dim objLookups As New CLookups
    Dim objWeb As CWeb
    Dim objCchart As CChart

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                Dim lngRut As Long
                lngRut = objSession.Rut
                objWeb.LlenaDDL(DdlMes, objLookups.Meses, "Mes_v", "Mes_t")
                objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
                objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
                objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                objWeb.AgregaValorDDL(Me.ddlEjecutivo, "Todos", 0)
                objWeb.AgregaValorDDL(Me.ddlSucursal, "Todas", 0)
                objWeb.AgregaValorDDL(Me.DdlMes, "Todos", 0)
                ddlAgnos.SelectedValue = Now.Year()
                ddlEjecutivo.SelectedValue = 0
                ddlSucursal.SelectedValue = 0
                DdlMes.SelectedValue = 0

                Me.Consultar()
            End If
        Catch ex As Exception
            EnviaError("modulo_gestion_gerencial_reporte_cartera.aspx.vb -->Page_Load-->" & ex.Message)
        End Try    
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        consultar()
    End Sub
    Private Sub Consultar()
        Try
            objInforme = New CInformeCartera
            objInforme.RutUsuario = objSession.Rut
            If Me.ddlSucursal.SelectedValue = 0 Then
                objInforme.CodSucursal = 0
            Else
                objInforme.CodSucursal = Me.ddlSucursal.SelectedValue
            End If
            If Me.ddlEjecutivo.SelectedValue = 0 Then
                objInforme.RutEjecutivo = 0
            Else
                objInforme.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
            End If
            objInforme.Mes = Me.DdlMes.SelectedValue
            objInforme.Agno = Me.ddlAgnos.SelectedValue
            objInforme.Inicializar()
            objInforme.cargar(Me.ddlSucursal.SelectedValue, Me.ddlEjecutivo.SelectedValue, Me.ddlAgnos.SelectedValue, Me.DdlMes.SelectedValue)
            Me.lbEmpresasAdherentes1.Text = objInforme.NumEmpresas
            If objInforme.NumEmpresas > 0 Then
                Me.lbEmpresasAdherentes2.Text = "100%"
            Else
                Me.lbEmpresasAdherentes2.Text = "0%"
            End If
            Me.lbConAportesEnterados1.Text = objInforme.ConAportes
            Me.lbConAportesEnterados2.Text = objInforme.PorcConAportes & "%"
            Me.LbActividadesIniciadas1.Text = objInforme.ConActividadesIni
            Me.LbActividadesIniciadas2.Text = objInforme.PorcConActividadesIni & "%"
            Me.LbAportesPendientes1.Text = objInforme.ConAportesPend
            Me.LbAportesPendientes2.Text = objInforme.PorcConAportesPend & "%"
            Me.LbConSaldoExcCapacitacion1.Text = objInforme.ConSaldoExcCap
            Me.LbConSaldoExcCapacitacion2.Text = objInforme.PorcConSaldoExcCap & "%"
            Me.LbConSaldoExcReparto1.Text = objInforme.ConSaldoExcRep
            Me.LbConSaldoExcReparto2.Text = objInforme.PorcConSaldoExcRep & "%"
            Me.LbOcupada501.Text = objInforme.FranqOcup50
            Me.LbOcupada502.Text = objInforme.PorcFranqOcup50 & "%"
            Me.LbOcupada251.Text = objInforme.FranqOcup25
            Me.LbOcupada252.Text = objInforme.PorcFranqOcup25 & "%"
            'se crea grafico de torTA
            If objInforme.NumEmpresas > 0 Then
                objCchart = New CChart
                objCchart.Alto = 200
                objCchart.Ancho = 400
                objCchart.TipoChart = 2
                objCchart.Titulo = "Empresas Adherentes"
                objCchart.SubTitulo = "activa, pasiva"
                objCchart.MostrarPorcentaje = True
                objCchart.DtDatos = objInforme.Torta
                litGrafico.Visible = True
                litGrafico.Text = objCchart.CreaChart()
            Else
                litGrafico.Text = "No hay datos a graficar"
            End If
            objInforme.Inicializar()
        Catch ex As Exception
            EnviaError("modulo_gestion_gerencial_reporte_cartera.aspx.vb -->Consultar-->" & ex.Message)
        End Try
    End Sub
End Class
