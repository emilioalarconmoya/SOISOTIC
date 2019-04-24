Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_resumen
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objReporte As CReporteResumen
    Private objSessionCliente As CSession
    Dim objExcel As CGenerarExcel
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '**************Session***************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objWeb.ChequeaCliente(objSessionCliente)
            Session("ModCuentas") = "ModCuentas"
            If Not objSession.AccesoObjeto(20) Then
                Response.Redirect("../Acceso_Denegado.aspx")
                Exit Sub
            End If
            '************************************
            If Not Page.IsPostBack Then
                If objSession.EsClienteIngresoCurso Then
                    Me.hplIngresoCurso.Visible = True
                End If
                lblPie.Text = Parametros.p_PIE
                objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
                ddlAgnos.SelectedValue = objSession.Agno
                Me.chkConsolidada.Checked = objSession.InfoConsolidada

                If objSession.EsCliente Then
                    objSessionCliente = New CSession
                    If objSessionCliente.ChequearCliente(RutLngAUsr(objSession.Rut)) Then
                        objWeb.ChequeaCliente(objSessionCliente)
                    End If
                    consultar()
                End If

                If objSession.Agno = 2010 Then
                    Me.tablaCongelados2008.Visible = True
                    Me.tablaCongelados2009.Visible = True
                    Me.tablaCongelados.Visible = True
                    Me.tablaCER.Visible = False
                    Me.tablaCEC.Visible = False
                ElseIf objSession.Agno = 2009 Then
                    Me.tablaCongelados2008.Visible = False
                    Me.tablaCongelados2009.Visible = False
                    Me.tablaCongelados.Visible = True
                    Me.tablaCER.Visible = True
                    Me.tablaCEC.Visible = True
                Else
                    Me.tablaCongelados2008.Visible = False
                    Me.tablaCongelados2009.Visible = False
                    Me.tablaCongelados.Visible = False
                    Me.tablaCER.Visible = True
                    Me.tablaCEC.Visible = True
                End If
            End If

            objWeb = New CWeb
            objWeb.ChequeaCliente(objSessionCliente)
            If Not objSessionCliente Is Nothing Then
                consultar()
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


                hplAlumnos.Enabled = True
                hplCursos.Enabled = True
                hplAportes.Enabled = True
                hplTerceros.Enabled = True
                hplViaticosyTraslado.Enabled = True
                hplCuentas.Enabled = True
                hplPorTramo.Enabled = True
                hplCertificado.Enabled = True
                hplCursoInterno.Enabled = True
                hplCargaDeCursos.Enabled = True
            Else
                hplAlumnos.Enabled = False
                hplCursos.Enabled = False
                hplAportes.Enabled = False
                hplTerceros.Enabled = False
                hplViaticosyTraslado.Enabled = False
                hplCuentas.Enabled = False
                hplPorTramo.Enabled = False
                hplCertificado.Enabled = False
                hplCursoInterno.Enabled = False
                hplCargaDeCursos.Enabled = False
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
            If Not objSessionCliente Is Nothing Then

                'If objSessionCliente.RutCliente = RutUsrALng(CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text) _
                'And CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text <> "" Then
                '    Session("cliente") = Nothing
                '    If validarut(RutUsrALng(CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text)) = True Then
                '        objSessionCliente = New CSession
                '        If objSessionCliente.ChequearCliente(RutUsrALng(CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text)) Then
                '            objWeb.ChequeaCliente(objSessionCliente)   'Carga el objeto session

                '        End If

                '    End If
                '    objReporte.RutCliente = objSessionCliente.RutCliente
                'Else
                '    objReporte.RutCliente = RutUsrALng(CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text)
                'End If
                objReporte.RutCliente = objSessionCliente.RutCliente
            Else
                objReporte.RutCliente = objSession.Rut
                objWeb.LlenaDDL(Me.ddlEmpresa, objLookups.ClientesAsociados(objSession.Rut), "rut", "razon_social")
                Me.ddlEmpresa.Visible = True
                Me.lblEmpresa.Visible = True
            End If
            'objReporte.RutCliente = objSessionCliente.Rut  ' Me.ddlEmpresa.SelectedValue
            objReporte.Agno = objSession.Agno
            objReporte.InfoConsolidada = objSession.InfoConsolidada
            objReporte.Consultar()
            Me.btnGeneraCartola.Visible = True

            If objReporte.TieneFiliales Then
                Me.chkConsolidada.Visible = True
            Else
                Me.chkConsolidada.Visible = False
            End If


            Me.hplCartaResumen.NavigateUrl = "carta_resumen_cliente.aspx?RutEmpresa=" & objReporte.RutClienteCarta
            'Franquicia del período
            'Aportes por enterar (Deuda Total)
            If objSession.InfoConsolidada Then
                objReporte.DeudaConsolidada(objReporte.Filiales, objSession.Agno)
                Me.lblAPEcapacitacion.Text = FormatoMonto(-1 * objReporte.APEcapacitacion)
                Me.lblAPErepato.Text = FormatoMonto(objReporte.APEreparto)
                Me.lblAPEadministracion.Text = FormatoMonto(-1 * objReporte.APEadministracion)
            Else
                Me.lblAPEcapacitacion.Text = FormatoMonto(objReporte.APEcapacitacion)
                Me.lblAPErepato.Text = FormatoMonto(objReporte.APEreparto)
                Me.lblAPEadministracion.Text = FormatoMonto(objReporte.APEadministracion)
            End If
           


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
            'Me.lblGEtotal.Text = FormatoMonto(objReporte.GEcapacitacion + objReporte.GEexCapacitacion + objReporte.GEterceros) 'FormatoMonto(objReporte.GEtotal)

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
            Me.lblCRRecibido.Text = FormatoMonto(objReporte.CRRecibido)

            'Cursos(Internos)
            Me.lblCIcantCursosInternos.Text = objReporte.CIcantCursosInternos
            Me.lblCItotalCursosInternos.Text = FormatoMonto(objReporte.CItotalCursosInternos)
            Me.lblCantidadAlumnosInternos.Text = objReporte.CIAlumnosInternosCapacitados
            Me.lblCantidadAlumnosInternosSR.Text = objReporte.CIAlumnosInternosCapacitadosSR

            'Estadísticas del período
            Me.lblEPcantCursos.Text = objReporte.EPcantCursos
            Me.lblEPcantCursosAnulados.Text = objReporte.EPcantCursosAnulados
            Me.lblEPcantCursosEliminados.Text = objReporte.EPcantCursosEliminados
            Me.hplEPalumnosCapacitados.Text = objReporte.EPalumnosCapacitados

            Me.lblEPalumnosCapacitadosSR.Text = objReporte.EPalumnosCapacitadosSR

            Me.lblEPalumnosCapacitadosCRCero.Text = objReporte.EPalumnosCapacitadosCero

            Me.lblEPalumnosCapacitadosSRCero.Text = objReporte.EPalumnosCapacitadosSRCero

            Me.lblEPalumnosCapacitadosPresencial.Text = objReporte.EPalumnosCapacitadosPresencial
            Me.lblEPalumnosCapacitadosElearning.Text = objReporte.EPalumnosCapacitadosElearning
            Me.lblEPalumnosCapacitadosAutoIntruccion.Text = objReporte.EPalumnosCapacitadosAutoInstruccion
            Me.lblEPalumnosCapacitadosAdistancia.Text = objReporte.EPalumnosCapacitadosDistancia

            'Me.lblEPhhCapacitacion.Text = FormatoMonto(objReporte.EPalumnosCapacitados * objReporte.EPhhParticipantes)
            Me.lblEPhhCapacitacion.Text = FormatoMonto(objReporte.EPhhCapacitacion)
            Me.lblEPhhCapacitacionMayorACero.Text = FormatoMonto(objReporte.EPhhCapacitacionCero)
            Me.lblEPhhCapacitacionMayorIgualA75.Text = FormatoMonto(objReporte.EPhhCapacitacion75)
            Me.lblEPhhParticipantes.Text = objReporte.EPhhParticipantes
            Me.lblEPhhPresenciales.Text = Math.Round(objReporte.EPhhPrecenciales, 1)
            Me.lblEPhhElearning.Text = Math.Round(objReporte.EPhhElearning, 1)
            Me.lblEPhhAutoInduccion.Text = Math.Round(objReporte.EPhhAutoInduccion, 1)
            Me.lblEPhhAdistancia.Text = Math.Round(objReporte.EPhhAdistancia, 1)

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
            Me.lblCERRecibido.Text = FormatoMonto(objReporte.CERRecibido)

            'Cuenta de Exc. Congelados 2008
            Me.lblCEC1abonoXsaldo.Text = FormatoMonto(objReporte.CEC1abonoXsaldo)
            Me.lblCEC1cursosPagados.Text = FormatoMonto(objReporte.CEC1cursosPagados)
            Me.lblCEC1saldo.Text = FormatoMonto(objReporte.CEC1saldo)

            'Cuenta de Exc. Congelados 2009
            Me.lblCEC2abonoXsaldo.Text = FormatoMonto(objReporte.CEC2abonoXsaldo)
            Me.lblCEC2cursosPagados.Text = FormatoMonto(objReporte.CEC2cursosPagados)
            Me.lblCEC2saldo.Text = FormatoMonto(objReporte.CEC2saldo)

            'Cuenta de becas de capacitación (Excedentes año anterior)
            Me.lblCBCabonosXsaldo.Text = FormatoMonto(objReporte.CBCabonosXsaldo)
            Me.LblPorTra.Text = FormatoMonto(objReporte.CBCabonosXsaldo)
            'Me.lblCBCcursosComplementarios.Text = FormatoMonto(objReporte.CBCcursosComplementarios)
            Me.lblCBCdisponible.Text = FormatoMonto(objReporte.CBCdisponible)
            Me.lblCBCabonosXmandato.Text = FormatoMonto(objReporte.CBCabonoXMandato)

            'Cuenta Financiamiento Otic
            Me.lblFOaportefinanciamientoOtic.Text = FormatoMonto(objReporte.FOaportefinanciamientoOtic)

            'Excedentes(Congelados)
            'Cuenta de Excedentes Congelados 
            Me.lblCECsaldo1.Text = FormatoMonto(objReporte.CECsaldo1)
            Me.lblCECsaldo2.Text = FormatoMonto(objReporte.CECsaldo2)

            If objReporte.MostrarExedido Then
                Me.lblSaldo1porcent.Text = Left(Me.lblSaldo1porcent.Text, lblSaldo1porcent.Text.Length - 1)
                Me.lblExedido.Visible = True
                Me.lblExedido.Text = " EXCEDIDO :"
                Me.lblExedido.ForeColor = Drawing.Color.Red
            Else
                Me.lblExedido.Visible = False
                Me.lblExedido.Text = ""
            End If

            Dim dblPorcAdm As Double
            dblPorcAdm = (100 - objReporte.CostoAdministracion) / 100
            Dim lngDeudaConVyt As Long
            If objReporte.CCvtCursosPropios > ((objReporte.CCabonosXaporte + objReporte.CRabonoXaporte) * 0.1) Then
                dblPorcAdm = (100 - objReporte.CostoAdministracion) / 100

                'Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal + ((objReporte.CCvtCursosPropios - objReporte.CCvtDisponible) / dblPorcAdm) * 10)
                lngDeudaConVyt = FormatoMonto(((objReporte.CCvtCursosPropios - objReporte.CCvtDisponible) / dblPorcAdm) * 10)
                'Me.lblAPEcapacitacion.Text = FormatoMonto(objReporte.APEcapacitacion + Me.lblAPETotal.Text)
                Me.lblAPEcapacitacion.Text = FormatoMonto(objReporte.APEcapacitacion)
            Else
                Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal)
            End If
            'Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal)

            If objReporte.CCcursosPropios = objReporte.CCvtCursosPropios Then
                Me.lblAPETotal.Text = FormatoMonto(lngDeudaConVyt)
            Else
                If objReporte.CCcursosPropios > (objReporte.CCvtCursosPropios * 10) And objReporte.CCvtCursosPropios > 0 Then
                    'dblPorcAdm = (100 - objReporte.CostoAdministracion) / 100
                    Me.lblAPETotal.Text = FormatoMonto(((objReporte.CCcursosPropios) / dblPorcAdm) - objReporte.AEaporte)
                    If Me.lblAPETotal.Text = "Infinito" Then
                        Me.lblAPETotal.Text = "0"
                    End If
                    If objSession.InfoConsolidada Then
                        Me.lblCCsaldo.Text = FormatoMonto(objReporte.CCsaldo) ' - objReporte.CCvtCursosPropiosAgnoAnterior)
                    End If
                Else
                    If objReporte.CCvtCursosPropios > objReporte.CCvtDisponible Then
                        Me.lblAPETotal.Text = FormatoMonto(lngDeudaConVyt)
                    Else
                        If objSession.InfoConsolidada Then
                            Me.lblAPETotal.Text = FormatoMonto(-objReporte.APEcapacitacion + objReporte.APEreparto + -objReporte.APEadministracion + lngDeudaConVyt)
                            Me.lblCRsaldo.Text = FormatoMonto(objReporte.CRsaldo - objReporte.CCvtCursosPropiosAgnoAnterior)
                        Else
                            Me.lblAPETotal.Text = FormatoMonto(objReporte.APEcapacitacion + objReporte.APEreparto + objReporte.APEadministracion + lngDeudaConVyt)
                        End If

                    End If
                End If


            End If


            If CLng(Me.lblAPETotal.Text.Replace(".", "").Replace("$", "").Replace(",", "").Replace(" ", "")) < 0 Then
                Me.lblAPETotal.Text = FormatoMonto(0)
            End If

          

            ' ''VALIDACION DEUDA CON VYT

            ''If objReporte.CCvtCursosPropios > ((objReporte.CCabonosXaporte + objReporte.CRabonoXaporte) * 0.1) Then
            ''    If objReporte.CCcursosPropios = objReporte.CCvtCursosPropios Then
            ''        If objReporte.CCvtCursosPropios > objReporte.CCvtDisponible Then

            ''            dblPorcAdm = (100 - objReporte.CostoAdministracion) / 100
            ''            Me.lblAPETotal.Text = FormatoMonto(CLng(((objReporte.CCvtCursosPropios - objReporte.CCvtDisponible) / dblPorcAdm) * 10))

            ''            Me.lblCCvtCursosPropios.Text = FormatoMonto(objReporte.CCvtCursosPropios)
            ''            Me.lblCCvtDisponible.Text = FormatoMonto(objReporte.CCvtDisponible)
            ''        End If
            ''    Else
            ''        If objReporte.CCvtDisponible > 0 Then
            ''            If objReporte.CCvtCursosPropios > objReporte.CCvtDisponible Then

            ''                dblPorcAdm = (100 - objReporte.CostoAdministracion) / 100
            ''                Me.lblAPETotal.Text = FormatoMonto(CLng(((objReporte.CCvtCursosPropios - objReporte.CCvtDisponible) / dblPorcAdm) * 10))

            ''                Me.lblCCvtCursosPropios.Text = FormatoMonto(objReporte.CCvtCursosPropios)
            ''                Me.lblCCvtDisponible.Text = FormatoMonto(objReporte.CCvtDisponible)
            ''            End If
            ''        End If
            ''    End If
            ''End If






            CType(Cabecera1.FindControl("hdfMostrarTasa"), HiddenField).Value = 1
            CType(Cabecera1.FindControl("lblTasaAdmin"), Label).Text = objReporte.CostoAdministracion
            Cabecera1.cargacabecera()

            objReporte = Nothing
        Catch ex As Exception
            EnviaError("resumen:consultar-->" & ex.Message)
        End Try
    End Sub

    Protected Sub ddlAgnos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAgnos.SelectedIndexChanged
        objSession.Agno = Me.ddlAgnos.SelectedValue
        If Not objSessionCliente Is Nothing Then
            consultar()
        End If

        If objSession.Agno = 2010 Then
            Me.tablaCongelados2008.Visible = True
            Me.tablaCongelados2009.Visible = True
            Me.tablaCongelados.Visible = True
            Me.tablaCER.Visible = False
            Me.tablaCEC.Visible = False
        ElseIf objSession.Agno = 2009 Then
            Me.tablaCongelados2008.Visible = False
            Me.tablaCongelados2009.Visible = False
            Me.tablaCongelados.Visible = True
            Me.tablaCER.Visible = True
            Me.tablaCEC.Visible = True
        Else
            Me.tablaCongelados2008.Visible = False
            Me.tablaCongelados2009.Visible = False
            Me.tablaCongelados.Visible = False
            Me.tablaCER.Visible = True
            Me.tablaCEC.Visible = True
        End If
    End Sub

    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        Me.chkConsolidada.Checked = False
        objSession.InfoConsolidada = Me.chkConsolidada.Checked
        objSession.CargaEjecutivoEmpresa(ddlEmpresa.SelectedValue)
        objSessionCliente.RutCliente = ddlEmpresa.SelectedValue
        consultar()
        Me.Cabecera1.Cargar(RutLngAUsr(ddlEmpresa.SelectedValue))
        Me.Cabecera1.cargacabecera()
    End Sub

    Protected Sub chkConsolidada_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConsolidada.CheckedChanged
        objSession.InfoConsolidada = Me.chkConsolidada.Checked
        consultar()
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text
    End Sub

    Protected Sub btnGeneraCartola_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraCartola.Click
        objExcel = New CGenerarExcel
        Dim filename As String
        Try

            If objSession.EsCliente Or objSession.EsClienteIngresoCurso Then
                objExcel.CartolaCliente(Me.lblAPEcapacitacion.Text, Me.lblAPErepato.Text, Me.lblAPEadministracion.Text, Me.lblAPETotal.Text, Me.lblFHfranquicia.Text, _
                            Me.lblFHsaldo1fecha.Text, Me.lblFHPorcfranq.Text, Me.lblAEaportes.Text, Me.lblAEadministracion.Text, _
                            Me.lblAEtotal.Text, Me.lblGEcapacitacion.Text, Me.lblGEexCapacitacion.Text, Me.lblGEterceros.Text, _
                            Me.lblGEtotal.Text, Me.lblCCabonosXaportes.Text, Me.lblCCcursosPropios.Text, Me.lblCCvtCursosPropios.Text, _
                            Me.lblCCvtDisponible.Text, Me.lblCCsaldo.Text, Me.lblCCEcostoOtic.Text, Me.lblCCEgastoEmpresa.Text, _
                            Me.lblCCEsaldoExcedentes.Text, Me.lblCCEagnoSig1.Text, Me.lblCCEagnoSig2.Text, Me.lblCRabonosXaporte.Text, _
                            Me.lblCRcursosTerceros.Text, Me.lblCRsaldo.Text, Me.lblCIcantCursosInternos.Text, Me.lblCItotalCursosInternos.Text, _
                            Me.lblCantidadAlumnosInternos.Text, Me.lblCantidadAlumnosInternosSR.Text, Me.lblEPcantCursos.Text, Me.hplEPalumnosCapacitados.Text, _
                            Me.lblEPalumnosCapacitadosSR.Text, Me.lblEPalumnosCapacitadosPresencial.Text, Me.lblEPalumnosCapacitadosElearning.Text, _
                            Me.lblEPalumnosCapacitadosAutoIntruccion.Text, Me.lblEPalumnosCapacitadosAdistancia.Text, Me.lblEPhhCapacitacion.Text, _
                            Me.lblEPhhParticipantes.Text, Me.lblEPhhPresenciales.Text, Me.lblEPhhElearning.Text, Me.lblEPhhAutoInduccion.Text, _
                            Me.lblEPhhAdistancia.Text, Me.lblCECAPabonoXsaldo.Text, Me.lblCECAPsumCursosPropios.Text, Me.lblCECAPvtCursosPropios.Text, _
                            Me.lblCECAPvtDisponible.Text, Me.lblCECAPsumSaldos.Text, Me.lblCERsumAbonoXsaldo.Text, Me.lblCERsumCursosTerceros.Text, _
                            Me.lblCERvtDisponible.Text, Me.lblCERsumSaldos.Text, Me.lblCBCabonosXsaldo.Text, Me.LblPorTra.Text, _
                            Me.lblCBCdisponible.Text, Me.lblCBCabonosXmandato.Text, Me.lblFOaportefinanciamientoOtic.Text, objSession.Agno, _
                            RutLngAUsr(objSessionCliente.RutCliente), objSessionCliente.RazonSocial, objSessionCliente.Direccion, _
                            objSessionCliente.Fono, CType(Cabecera1.FindControl("lblTasaAdmin"), Label).Text, _
                            objSessionCliente.NombreEjecutivo, objSessionCliente.FonoEjecutivo, objSessionCliente.EmailEjecutivo, _
                            Me.lblEPcantCursosAnulados.Text, Me.lblEPcantCursosEliminados.Text, Me.lblCRRecibido.Text, Me.lblCERRecibido.Text)
            Else
                objExcel.CartolaCliente(Me.lblAPEcapacitacion.Text, Me.lblAPErepato.Text, Me.lblAPEadministracion.Text, Me.lblAPETotal.Text, Me.lblFHfranquicia.Text, _
                            Me.lblFHsaldo1fecha.Text, Me.lblFHPorcfranq.Text, Me.lblAEaportes.Text, Me.lblAEadministracion.Text, _
                            Me.lblAEtotal.Text, Me.lblGEcapacitacion.Text, Me.lblGEexCapacitacion.Text, Me.lblGEterceros.Text, _
                            Me.lblGEtotal.Text, Me.lblCCabonosXaportes.Text, Me.lblCCcursosPropios.Text, Me.lblCCvtCursosPropios.Text, _
                            Me.lblCCvtDisponible.Text, Me.lblCCsaldo.Text, Me.lblCCEcostoOtic.Text, Me.lblCCEgastoEmpresa.Text, _
                            Me.lblCCEsaldoExcedentes.Text, Me.lblCCEagnoSig1.Text, Me.lblCCEagnoSig2.Text, Me.lblCRabonosXaporte.Text, _
                            Me.lblCRcursosTerceros.Text, Me.lblCRsaldo.Text, Me.lblCIcantCursosInternos.Text, Me.lblCItotalCursosInternos.Text, _
                            Me.lblCantidadAlumnosInternos.Text, Me.lblCantidadAlumnosInternosSR.Text, Me.lblEPcantCursos.Text, Me.hplEPalumnosCapacitados.Text, _
                            Me.lblEPalumnosCapacitadosSR.Text, Me.lblEPalumnosCapacitadosPresencial.Text, Me.lblEPalumnosCapacitadosElearning.Text, _
                            Me.lblEPalumnosCapacitadosAutoIntruccion.Text, Me.lblEPalumnosCapacitadosAdistancia.Text, Me.lblEPhhCapacitacion.Text, _
                            Me.lblEPhhParticipantes.Text, Me.lblEPhhPresenciales.Text, Me.lblEPhhElearning.Text, Me.lblEPhhAutoInduccion.Text, _
                            Me.lblEPhhAdistancia.Text, Me.lblCECAPabonoXsaldo.Text, Me.lblCECAPsumCursosPropios.Text, Me.lblCECAPvtCursosPropios.Text, _
                            Me.lblCECAPvtDisponible.Text, Me.lblCECAPsumSaldos.Text, Me.lblCERsumAbonoXsaldo.Text, Me.lblCERsumCursosTerceros.Text, _
                            Me.lblCERvtDisponible.Text, Me.lblCERsumSaldos.Text, Me.lblCBCabonosXsaldo.Text, Me.LblPorTra.Text, _
                            Me.lblCBCdisponible.Text, Me.lblCBCabonosXmandato.Text, Me.lblFOaportefinanciamientoOtic.Text, objSession.Agno, _
                            RutLngAUsr(objSessionCliente.RutCliente), CType(Cabecera1.FindControl("HplkRazonSocial"), HyperLink).Text, _
                            CType(Cabecera1.FindControl("lblDataDireccion"), Label).Text, objSessionCliente.Fono, _
                            CType(Cabecera1.FindControl("lblTasaAdmin"), Label).Text, CType(Cabecera1.FindControl("lblDataNombreEjecutivo"), Label).Text, _
                            CType(Cabecera1.FindControl("lblDataFonoEjecutivo"), Label).Text, CType(Cabecera1.FindControl("HplkEmailEjecutivo"), HyperLink).Text, _
                             Me.lblEPcantCursosAnulados.Text, Me.lblEPcantCursosEliminados.Text, Me.lblCRRecibido.Text, Me.lblCERRecibido.Text)
            End If
            

            ', CType(Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text
            'CType(Cabecera1.FindControl("lblDataFono"), Label).Text

        Catch ex As Exception
            EnviaError("resumen:btnGeneraCartola_Click--> " & ex.Message)
        End Try

        filename = "CARTOLA_CLIENTE.xls"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        Response.Clear()
        Response.WriteFile(objExcel.RutaArchivo)
        Response.End()
        objExcel = Nothing
    End Sub
End Class
