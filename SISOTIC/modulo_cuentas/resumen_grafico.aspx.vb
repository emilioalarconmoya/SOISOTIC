Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_resumen_grafico
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objChart As CChart
    Dim objReporte As CReporteResumen
    Private objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '**************Session***************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objWeb.ChequeaCliente(objSessionCliente)
            'If Not objSession.AccesoObjeto(20) Then
            '    Response.Redirect("../Acceso_Denegado.aspx")
            '    Exit Sub
            'End If
            '************************************
            If Not Page.IsPostBack Then
                'Me.form1.Attributes.Add("defaultbutton", CType(datos_personales1.FindControl("btnCargar"), Button).ClientID)
                If objSession.EsClienteIngresoCurso Then
                    Me.hplIngresoCurso.Visible = True
                End If
                lblPie.Text = Parametros.p_PIE
                objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
                ddlAgnos.SelectedValue = objSession.Agno
                'objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSession.Rut), "rut", "razon_social")
                'Me.ddlEmpresa.SelectedValue = objSession.Rut
                If objSession.EsCliente Then

                    objSessionCliente = New CSession
                    If objSessionCliente.ChequearCliente(RutLngAUsr(objSession.Rut)) Then
                        objWeb.ChequeaCliente(objSessionCliente)
                    End If
                    Session("ModCuentas") = "ModCuentas"
                    consultar()
                End If

            End If
            objWeb = New CWeb
            objWeb.ChequeaCliente(objSessionCliente)
            If Not objSessionCliente Is Nothing Then
                If Not Me.ddlEmpresa.SelectedValue = "" Then
                    If objSessionCliente.RutCliente <> Me.ddlEmpresa.SelectedValue Then
                        objSessionCliente.RutCliente = Me.ddlEmpresa.SelectedValue
                        consultar()

                    End If
                Else
                    'objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.RutCliente), "rut", "razon_social")
                    consultar()
                    '__________________________-

                    If ddlEmpresa.SelectedValue = "" Then
                        If objSessionCliente.TieneHolding(objSessionCliente.Rut) Then
                            If objSessionCliente.Rut = objSessionCliente.RutHolding Then
                                objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.RutHolding), "rut", "razon_social")
                                If ddlEmpresa.Items.Count > 0 Then
                                    ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                    Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                    Me.ddlEmpresa.Visible = True
                                    Me.lblEmpresa.Visible = True
                                End If
                            Else
                                If objSession.EsCliente Or objSession.EsClienteIngresoCurso Then
                                    If objSessionCliente.TieneHolding(objSessionCliente.Rut) Then
                                        If objSession.Rut = objSessionCliente.RutHolding Then
                                            objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.RutHolding), "rut", "razon_social")
                                            If ddlEmpresa.Items.Count > 0 Then
                                                ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                                Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                                Me.ddlEmpresa.Visible = True
                                                Me.lblEmpresa.Visible = True
                                            End If
                                        Else
                                            If objSessionCliente.RutHolding = 0 Then
                                                objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.Rut), "rut", "razon_social")
                                                If ddlEmpresa.Items.Count > 0 Then
                                                    ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                                    Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                                    Me.ddlEmpresa.Visible = True
                                                    Me.lblEmpresa.Visible = True
                                                End If
                                            Else
                                                If objSession.Rut = objSessionCliente.RutHolding Then
                                                    objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.RutHolding), "rut", "razon_social")
                                                    If ddlEmpresa.Items.Count > 0 Then
                                                        ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                                        Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                                        Me.ddlEmpresa.Visible = True
                                                        Me.lblEmpresa.Visible = True
                                                    End If
                                                Else
                                                    objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.Rut), "rut", "razon_social")
                                                    If ddlEmpresa.Items.Count > 0 Then
                                                        ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                                        Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                                        Me.ddlEmpresa.Visible = True
                                                        Me.lblEmpresa.Visible = True
                                                    End If
                                                End If

                                            End If

                                        End If

                                    Else
                                        If objSessionCliente.RutHolding = 0 Then
                                            objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.Rut), "rut", "razon_social")
                                            If ddlEmpresa.Items.Count > 0 Then
                                                ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                                Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                                Me.ddlEmpresa.Visible = True
                                                Me.lblEmpresa.Visible = True
                                            End If
                                        Else
                                            objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.RutHolding), "rut", "razon_social")
                                            If ddlEmpresa.Items.Count > 0 Then
                                                ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                                Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                                Me.ddlEmpresa.Visible = True
                                                Me.lblEmpresa.Visible = True
                                            End If
                                        End If

                                    End If

                                Else
                                    objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.RutHolding), "rut", "razon_social")
                                    If ddlEmpresa.Items.Count > 0 Then
                                        ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                        Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                        Me.ddlEmpresa.Visible = True
                                        Me.lblEmpresa.Visible = True
                                    End If
                                End If

                            End If

                        Else
                            objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.Rut), "rut", "razon_social")
                            If ddlEmpresa.Items.Count > 0 Then
                                ddlEmpresa.Items(0).Attributes.Add("class", "Destacado")
                                Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                                Me.ddlEmpresa.Visible = True
                                Me.lblEmpresa.Visible = True
                            End If
                        End If
                    End If

                    ' ''If ddlEmpresa.SelectedValue = "" Then
                    ' ''    If objSessionCliente.TieneHolding(objSessionCliente.Rut) Then
                    ' ''        objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.RutHolding), "rut", "razon_social")
                    ' ''        If ddlEmpresa.Items.Count > 0 Then
                    ' ''            Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                    ' ''            Me.ddlEmpresa.Visible = True
                    ' ''            Me.lblEmpresa.Visible = True
                    ' ''        End If
                    ' ''    Else
                    ' ''        objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSessionCliente.Rut), "rut", "razon_social")
                    ' ''        If ddlEmpresa.Items.Count > 0 Then
                    ' ''            Me.ddlEmpresa.SelectedValue = objSessionCliente.Rut
                    ' ''            Me.ddlEmpresa.Visible = True
                    ' ''            Me.lblEmpresa.Visible = True
                    ' ''        End If
                    ' ''    End If
                    ' ''End If
                    '' ''____________________________--

                End If

                ''If ddlEmpresa.Items.Count > 0 Then
                ''    Me.ddlEmpresa.SelectedValue = objSessionCliente.RutCliente
                ''    Me.ddlEmpresa.Visible = True
                ''    Me.lblEmpresa.Visible = True
                ''End If

                hplResumen.Enabled = True
                hplAlumnos.Enabled = True
                hplCursos.Enabled = True
                hplAportes.Enabled = True
                hplTerceros.Enabled = True
                hplViaticosyTraslado.Enabled = True
                hplCuentas.Enabled = True
                hplCargaDeCursos.enabled = True
                hplPorTramo.Enabled = True
                hplCertificado.Enabled = True
                resultadosGraficos.Visible = True
                hplCursoInterno.Enabled = True
            Else
                '****MENU*****
                hplResumen.Enabled = False
                hplAlumnos.Enabled = False
                hplCursos.Enabled = False
                hplAportes.Enabled = False
                hplTerceros.Enabled = False
                hplViaticosyTraslado.Enabled = False
                hplCuentas.Enabled = False
                hplCargaDeCursos.enabled = False
                hplPorTramo.Enabled = False
                hplCertificado.Enabled = False
                hplCursoInterno.Enabled = False
                '*****DATOS GRAFICOS********
                litGrafico1.Visible = False
                litGrafico2.Visible = False
                litGrafico3.Visible = False
                lblPregunta1.Visible = False
                Label2.Visible = False
                lblRespuesta1.Visible = False
                Label11.Visible = False
                Label12.Visible = False
                lblRespuesta2.Visible = False
                Label10.Visible = False
                Label13.Visible = False
                lblRespuesta8.Visible = False
                Label18.Visible = False
                Label20.Visible = False
                lblRespuesta4.Visible = False
                Label21.Visible = False
                Label23.Visible = False
                lblRespuesta9.Visible = False
                Label15.Visible = False
                Label16.Visible = False
                lblRespuesta3.Visible = False
                Label24.Visible = False
                Label26.Visible = False
                lblRespuesta5.Visible = False
                Label4.Visible = False
                Label5.Visible = False
                lblRespuesta6.Visible = False
                Label7.Visible = False
                Label8.Visible = False
                lblRespuesta7.Visible = False
                Label27.Visible = False
                lblRespuesta10.Visible = False
                lblRespuesta11.Visible = False
                lblEmpresa.Visible = False
                ddlEmpresa.Visible = False
                lblMensaje.Visible = True
            End If


        Catch ex As Exception
            EnviaError("resumen:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub consultar()
        Try
            objReporte = New CReporteResumen
            objReporte.inicializar()
            If Not objSessionCliente Is Nothing Then
                If objSessionCliente.RutCliente <> 0 Then
                    objReporte.RutCliente = objSessionCliente.RutCliente
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: La empresa no es usaurio cliente');")
                    Exit Sub
                End If

            Else
                objReporte.RutCliente = objSession.Rut

                objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSession.Rut), "rut", "razon_social")
                Me.ddlEmpresa.Visible = True
                Me.lblEmpresa.Visible = True
            End If

            'objReporte.RutCliente = Me.ddlEmpresa.SelectedValue
            objReporte.Agno = objSession.Agno
            objReporte.InfoConsolidada = objSession.InfoConsolidada
            objReporte.Consultar()
            'If Not objReporte.EsEmpresaCliente Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: La empresa no es una empresa cliente');")
            '    Exit Sub
            'End If


            If objReporte.TieneFiliales Then
                Me.chkConsolidada.Visible = True
            Else
                Me.chkConsolidada.Visible = False
            End If


            If Not objReporte.GraficoTortaCursosSence Is Nothing Then
                objChart = New CChart
                objChart.Alto = 260
                objChart.Ancho = 480
                If objReporte.ValMayorAcero Then
                    objChart.TipoChart = 2
                Else
                    objChart.TipoChart = 3
                End If
                objChart.PreVal = ""
                objChart.PosVal = ""
                objChart.Decimales = 0
                objChart.xAxisName = ""
                objChart.yAxisName = ""
                objChart.DtDatos = objReporte.GraficoTortaCursosSence
                objChart.Titulo = "Distribución del dinero en el año"
                litGrafico1.Visible = True
                litGrafico1.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv1")

                objChart = New CChart
                objChart.Alto = 260
                objChart.Ancho = 480
                objChart.TipoChart = 9
                objChart.PreVal = "$"
                objChart.PosVal = ""
                objChart.Decimales = 0
                objChart.xAxisName = "Rango"
                objChart.yAxisName = "Cantidad"
                objChart.DtDatos = objReporte.GraficoBarraCostosAnuales
                objChart.Titulo = "Dinero gastado en cursos por año"
                litGrafico2.Visible = True
                litGrafico2.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv2")

                objChart = New CChart
                objChart.Alto = 260
                objChart.Ancho = 480
                objChart.TipoChart = 9
                objChart.PreVal = ""
                objChart.PosVal = ""
                objChart.Decimales = 0
                objChart.xAxisName = "Rango"
                objChart.yAxisName = "Cantidad"
                objChart.DtDatos = objReporte.GraficoBarraHorasHombre
                objChart.Titulo = "Horas Hombre por año"
                litGrafico3.Visible = True
                litGrafico3.Text = Replace(objChart.CreaChart(), "ChartDiv", "ChartDiv3")
            End If
            lblRespuesta1.Text = "$" & FormatoMonto(objReporte.ValorTotalCursos)
            lblRespuesta2.Text = "$" & FormatoMonto(objReporte.CCabonosXaporte + objReporte.CRabonoXaporte) & " (cifra contempla aportes netos en capacitación y reparto)"
            lblRespuesta3.Text = FormatoMonto(objReporte.EPalumnosCapacitados) & " persona(s) con repetición y " & FormatoMonto(objReporte.EPalumnosCapacitadosSR) & " persona(s) sin repetición."
            If objReporte.CCsaldo + objReporte.CRsaldo + objReporte.CECAPsumSaldos > 0 Then
                'lblRespuesta4.Text = "$" & FormatoMonto(objReporte.CCsaldo + objReporte.CRsaldo + objReporte.CECAPsumSaldos + objReporte.CERsumSaldos)
                If objReporte.CCsaldo < 0 Then
                    lblRespuesta4.Text = "$" & FormatoMonto(objReporte.CECAPsumSaldos)
                Else
                    lblRespuesta4.Text = "$" & FormatoMonto(objReporte.CCsaldo + objReporte.CECAPsumSaldos)
                End If
            Else
                lblRespuesta4.Text = "$0"
                'lblRespuesta4.Text = "$" & FormatoMonto(objReporte.CCsaldo + objReporte.CRsaldo + objReporte.CECAPsumSaldos + objReporte.CERsumSaldos)
                'If (objReporte.CCsaldo + objReporte.CRsaldo + objReporte.CECAPsumSaldos + objReporte.CERsumSaldos) < 0 Then
                '    lblRespuesta4.ForeColor = Drawing.Color.Red
                'End If

            End If
            lblRespuesta5.Text = objReporte.NombreEjecutivo & " su email es "
            hplRespuesta5_1.Text = objReporte.EmailEjecutivo
            hplRespuesta5_1.NavigateUrl = "mailto:" & objReporte.EmailEjecutivo
            lblRespuesta5_2.Text = " y el teléfono para contactarlo es " & objReporte.FonoEjecutivo
            lblRespuesta6.Text = FormatoMonto(objReporte.EPcantCursos) & " curso(s)."
            lblRespuesta7.Text = FormatoMonto(objReporte.CIcantCursosInternos) & " curso(s) en el sistema."
            lblRespuesta8.Text = "$" & FormatoMonto(objReporte.CECAPsumSaldos + objReporte.CERsumSaldos) & " (Excedentes)."
            'lblRespuesta9.Text = "$" & FormatoMonto(objReporte.CERsumCursosTerceros + objReporte.CRterceros)
            lblRespuesta9.Text = "$" & FormatoMonto(objReporte.CERsumAbonoXsaldo)
            lblRespuesta10.Text = "Se han capacitado " & FormatoMonto(objReporte.EPhhCapacitacion) & " horas hombres entre los cursos del año "
            lblRespuesta11.Text = " promediando " & FormatoMonto(objReporte.EPhhParticipantes) & " horas hombre por participante."
            lblRespuesta12.Text = "$" & FormatoMonto(objReporte.GEtotal)
            'lblrespuesta13.Text = "$" & FormatoMonto(objReporte.AportePendienteTotal)
            Me.lblGEcapacitacion.Text = FormatoPeso(objReporte.GEcapacitacion)
            Me.lblGEexCapacitacion.Text = FormatoPeso(objReporte.GEexCapacitacion)
            Me.lblGEterceros.Text = FormatoPeso(objReporte.GEterceros)




            '****************** validacion vyt

            Dim dblPorcAdm As Double
            Dim lngDeudaConVyt As Long
            If objReporte.CCvtCursosPropios > ((objReporte.CCabonosXaporte + objReporte.CRabonoXaporte) * 0.1) Then
                dblPorcAdm = (100 - objReporte.CostoAdministracion) / 100

                'Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal + ((objReporte.CCvtCursosPropios - objReporte.CCvtDisponible) / dblPorcAdm) * 10)
                lngDeudaConVyt = ((objReporte.CCvtCursosPropios - objReporte.CCvtDisponible) / dblPorcAdm) * 10
                'Me.lblAPEcapacitacion.Text = FormatoMonto(objReporte.APEcapacitacion + Me.lblAPETotal.Text)
                'Me.lblAPEcapacitacion.Text = FormatoMonto(objReporte.APEcapacitacion)
            Else
                Me.lblrespuesta13.Text = FormatoPeso(objReporte.APEtotal)
            End If
            'Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal)

            If objReporte.CCcursosPropios = objReporte.CCvtCursosPropios Then
                Me.lblrespuesta13.Text = FormatoPeso(lngDeudaConVyt)
            Else
                If objReporte.CCvtCursosPropios > objReporte.CCvtDisponible Then
                    Me.lblrespuesta13.Text = FormatoPeso(lngDeudaConVyt)
                Else
                    Me.lblrespuesta13.Text = FormatoPeso(objReporte.APEcapacitacion + objReporte.APEreparto + objReporte.APEadministracion + lngDeudaConVyt)
                End If

            End If




            objReporte = Nothing
        Catch ex As Exception
            EnviaError("resumen:consultar-->" & ex.Message)
        End Try
    End Sub

    Protected Sub ddlAgnos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAgnos.SelectedIndexChanged
        objSession.Agno = Me.ddlAgnos.SelectedValue
        consultar()
    End Sub

    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        Session("cliente") = Nothing
        Me.chkConsolidada.Checked = False
        objSession.InfoConsolidada = Me.chkConsolidada.Checked
        objSession.CargaEjecutivoEmpresa(ddlEmpresa.SelectedValue)
        objSessionCliente = New CSession
        If objSessionCliente.ChequearCliente(RutLngAUsr(ddlEmpresa.SelectedValue)) Then
            objWeb.ChequeaCliente(objSessionCliente)   'Carga el objeto session
        End If
        consultar()
        Me.datos_personales1.Cargar(RutLngAUsr(ddlEmpresa.SelectedValue))
        Me.datos_personales1.cargacabecera()

        '__________________________________________
        'Me.chkConsolidada.Checked = False
        'objSession.InfoConsolidada = Me.chkConsolidada.Checked
        'objSession.CargaEjecutivoEmpresa(ddlEmpresa.SelectedValue)
        'objSessionCliente.RutCliente = ddlEmpresa.SelectedValue
        'consultar()
        'Me.datos_personales1.Cargar(RutLngAUsr(ddlEmpresa.SelectedValue))
        'Me.datos_personales1.cargacabecera()
    End Sub

    Protected Sub chkConsolidada_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConsolidada.CheckedChanged
        objSession.InfoConsolidada = Me.chkConsolidada.Checked
        consultar()
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(datos_personales1.FindControl("txtRutEmpresa"), TextBox).Text
    End Sub
End Class

