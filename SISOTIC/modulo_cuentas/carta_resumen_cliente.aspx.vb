Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_carta_resumen_cliente
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objReporte As CReporteResumen
    Private objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '**************Session***************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objWeb.ChequeaCliente(objSessionCliente)
            If Not objSession.AccesoObjeto(20) Then
                Response.Redirect("../Acceso_Denegado.aspx")
                Exit Sub
            End If
            '************************************

            If Not Page.IsPostBack Then
                'If objSession.EsClienteIngresoCurso Then
                '    Me.hplIngresoCurso.Visible = True
                'End If
                lblPie.Text = Parametros.p_PIE
                btnImprimir.Attributes.Add("onclick", "Imprimir();")
                'objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
                'ddlAgnos.SelectedValue = objSession.Agno
                ViewState("RutEmpresa") = Request("RutEmpresa")
                consultar()


                If objSession.Agno = 2010 Then
                    'Me.tablaCongelados2008.Visible = True
                    'Me.tablaCongelados2009.Visible = True
                    'Me.tablaCongelados.Visible = True
                    Me.tablaCER.Visible = False
                    Me.tablaCEC.Visible = False
                ElseIf objSession.Agno = 2009 Then
                    'Me.tablaCongelados2008.Visible = False
                    'Me.tablaCongelados2009.Visible = False
                    'Me.tablaCongelados.Visible = True
                    Me.tablaCER.Visible = True
                    Me.tablaCEC.Visible = True
                Else
                    'Me.tablaCongelados2008.Visible = False
                    'Me.tablaCongelados2009.Visible = False
                    'Me.tablaCongelados.Visible = False
                    Me.tablaCER.Visible = True
                    Me.tablaCEC.Visible = True
                End If

            End If
        Catch ex As Exception
            EnviaError("resumen:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub consultar()
        Try
            'Dim objSessionCliente As New CSession
            objReporte = New CReporteResumen
            objReporte.inicializar()
            'If Not objSessionCliente Is Nothing Then
            objReporte.RutCliente = RutUsrALng(ViewState("RutEmpresa"))
            'Else
            'objReporte.RutCliente = objSession.Rut
            'End If
            'objReporte.RutCliente = objSessionCliente.Rut  ' Me.ddlEmpresa.SelectedValue
            objReporte.Agno = objSession.Agno
            objReporte.InfoConsolidada = objSession.InfoConsolidada
            objReporte.Consultar()

            'If objReporte.TieneFiliales Then
            '    Me.chkConsolidada.Visible = True
            'Else
            '    Me.chkConsolidada.Visible = False
            'End If
            Me.lblNombreEmpresa2.Text = objReporte.RazonSocial
            Me.lblFonoEmpresa.Text = objReporte.FonoEjecutivo
            ' Me.lblFax.Text = objReporte.FaxCliente
            Me.lblFechaImpresion.Text = Now.Date
            Me.lblNombreEmpresa.Text = Parametros.p_EMPRESA
            Me.lblAportePendienteTotal.Text = FormatoPeso(objReporte.AportePendienteTotal)
            Me.lblCostoAdm.Text = objReporte.CostoAdministracion
            Me.lblTelefono.Text = objReporte.FonoCliente
            Me.lblAgno.Text = Year(Now.Date)
            If Month(Now.Date) = 12 Then
                Me.divAgno.Visible = True
            Else
                Me.divAgno.Visible = False
            End If

            'Franquicia del período
            'Aportes por enterar (Deuda Total)
            Me.lblAPEcapacitacion.Text = FormatoMonto(objReporte.APEcapacitacion)
            Me.lblAPErepato.Text = FormatoMonto(objReporte.APEreparto)
            Me.lblAPEadministracion.Text = FormatoMonto(objReporte.APEadministracion)
            Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal)

            'Franquicia(Histórica)
            Me.lblFHfranquicia.Text = FormatoMonto(objReporte.FHfranquicia)
            Me.lblFHsaldo1fecha.Text = FormatoMonto(objReporte.FHsaldo1fecha)
            Me.lblFHPorcfranq.Text = Math.Round(objReporte.FHporcentajeFranquicia, 1) & "%"

            'Aporte(enterados)
            Me.lblAEaportes.Text = FormatoMonto(objReporte.AEaporte)
            Me.lblAEadministracion.Text = FormatoMonto(objReporte.AEadministracion)
            Me.lblAEtotal.Text = FormatoMonto(objReporte.AEtotal)

            'Gasto(Empresa)
            Me.lblGEcapacitacion.Text = FormatoMonto(objReporte.GEcapacitacion)
            Me.lblGEexCapacitacion.Text = FormatoMonto(objReporte.GEexCapacitacion)
            Me.lblGEterceros.Text = FormatoMonto(objReporte.GEterceros)
            Me.lblGEtotal.Text = FormatoMonto(objReporte.GEtotal)

            'Cuenta de capacitación
            Me.lblCCabonosXaportes.Text = FormatoMonto(objReporte.CCabonosXaporte)
            Me.lblCCcursosPropios.Text = FormatoMonto(objReporte.CCcursosPropios)
            Me.lblCCvtCursosPropios.Text = FormatoMonto(objReporte.CCvtCursosPropios)
            Me.lblCCvtDisponible.Text = FormatoMonto(objReporte.CCvtDisponible)
            Me.lblCCsaldo.Text = FormatoMonto(objReporte.CCsaldo)
            Me.lblCCDisponibleCap.Visible = objReporte.CCMostrarTexto

            'Costo Complementario Estimado
            Me.lblCCEcostoOtic.Text = FormatoMonto(objReporte.CCEcostoOtic)
            Me.lblCCEgastoEmpresa.Text = FormatoMonto(objReporte.CCEgastoEmpresa)
            Me.lblCCEsaldoExcedentes.Text = FormatoMonto(objReporte.CCEsaldoExdecentes)
            Me.lblCCEagnoSig1.Text = objReporte.CCEagnoSiguiente & " :"
            Me.lblCCEagnoSig2.Text = objReporte.CCEagnoSiguiente & " :"

            'Cuenta de reparto
            Me.lblCRabonosXaporte.Text = FormatoMonto(objReporte.CRabonoXaporte)
            Me.lblCRcursosTerceros.Text = FormatoMonto(objReporte.CRterceros)
            Me.lblCRsaldo.Text = FormatoMonto(objReporte.CRsaldo)

            'Cursos(Internos)
            Me.lblCIcantCursosInternos.Text = objReporte.CIcantCursosInternos
            Me.lblCItotalCursosInternos.Text = FormatoMonto(objReporte.CItotalCursosInternos)

            'Estadísticas del período
            Me.lblEPcantCursos.Text = objReporte.EPcantCursos
            Me.hplEPalumnosCapacitados.Text = objReporte.EPalumnosCapacitados
            Me.lblEPhhCapacitacion.Text = FormatoMonto(objReporte.EPalumnosCapacitados * objReporte.EPhhParticipantes)
            'Me.lblEPhhCapacitacion.Text = FormatoMonto(objReporte.EPhhCapacitacion)
            Me.lblEPhhParticipantes.Text = objReporte.EPhhParticipantes
            Me.lblEPhhPresenciales.Text = objReporte.EPhhPrecenciales
            Me.lblEPhhElearning.Text = objReporte.EPhhElearning
            Me.lblEPhhAutoInduccion.Text = objReporte.EPhhAutoInduccion

            'Excedentes del período anterior
            'Cuenta de excedente de capacitaci&oacute;n (Totales Generales)
            Me.lblCECAPabonoXsaldo.Text = FormatoMonto(objReporte.CECAPabonoXsaldo)
            Me.lblCECAPsumCursosPropios.Text = FormatoMonto(objReporte.CECAPsumCursosPropios)
            Me.lblCECAPvtCursosPropios.Text = FormatoMonto(objReporte.CECAPvtCursosPropios)
            Me.lblCECAPvtDisponible.Text = FormatoMonto(objReporte.CECAPvtDisponible)
            Me.lblCECAPsumSaldos.Text = FormatoMonto(objReporte.CECAPsumSaldos)

            'Cuenta de excedente de reparto (Totales Generales)
            Me.lblCERsumAbonoXsaldo.Text = FormatoMonto(objReporte.CERsumAbonoXsaldo)
            Me.lblCERsumCursosTerceros.Text = FormatoMonto(objReporte.CERsumCursosTerceros)
            Me.lblCERvtDisponible.Text = FormatoMonto(objReporte.CERvtDisponible)
            Me.lblCERsumSaldos.Text = FormatoMonto(objReporte.CERsumSaldos)

            'Cuenta de Exc. Congelados 2008
            'Me.lblCEC1abonoXsaldo.Text = FormatoMonto(objReporte.CEC1abonoXsaldo)
            'Me.lblCEC1cursosPagados.Text = FormatoMonto(objReporte.CEC1cursosPagados)
            'Me.lblCEC1saldo.Text = FormatoMonto(objReporte.CEC1saldo)

            ''Cuenta de Exc. Congelados 2009
            'Me.lblCEC2abonoXsaldo.Text = FormatoMonto(objReporte.CEC2abonoXsaldo)
            'Me.lblCEC2cursosPagados.Text = FormatoMonto(objReporte.CEC2cursosPagados)
            'Me.lblCEC2saldo.Text = FormatoMonto(objReporte.CEC2saldo)

            ''Cuenta de becas de capacitación (Excedentes año anterior)
            'Me.lblCBCabonosXsaldo.Text = FormatoMonto(objReporte.CBCabonosXsaldo)
            'Me.LblPorTra.Text = FormatoMonto(objReporte.CBCdisponible)
            ''Me.lblCBCcursosComplementarios.Text = FormatoMonto(objReporte.CBCcursosComplementarios)
            'Me.lblCBCdisponible.Text = FormatoMonto(objReporte.CBCdisponible)

            ''Cuenta Financiamiento Otic
            'Me.lblFOaportefinanciamientoOtic.Text = FormatoMonto(objReporte.FOaportefinanciamientoOtic)

            ''Excedentes(Congelados)
            ''Cuenta de Excedentes Congelados 
            'Me.lblCECsaldo1.Text = FormatoMonto(objReporte.CECsaldo1)
            'Me.lblCECsaldo2.Text = FormatoMonto(objReporte.CECsaldo2)

            If objReporte.MostrarExedido Then
                Me.lblSaldo1porcent.Text = Left(Me.lblSaldo1porcent.Text, lblSaldo1porcent.Text.Length - 1)
                Me.lblExedido.Visible = True
                Me.lblExedido.Text = " EXCEDIDO :"
                Me.lblExedido.ForeColor = Drawing.Color.Red
            Else
                Me.lblExedido.Visible = False
                Me.lblExedido.Text = ""
            End If

            If objReporte.AportePendienteTotal > 0 Then
                Me.divAportePendiente.Visible = True
            Else
                Me.divAportePendiente.Visible = False
            End If

            objReporte = Nothing
        Catch ex As Exception
            EnviaError("resumen:consultar-->" & ex.Message)
        End Try
    End Sub
End Class
