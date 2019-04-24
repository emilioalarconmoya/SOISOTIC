Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_aporte_ingreso_aporte
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objLookUps As Clookups
    Dim objSesion As CSession
    Dim objIngresoAporte As New CIngresoAporte
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSesion)
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                objLookUps = New Clookups
                objWeb.LlenaDDL(Me.ddlCuentasAporte, objLookUps.cuentasAportes, "cuenta_v", "cuenta_t")
                objWeb.LlenaDDL(Me.ddlAgno, objLookUps.Agnos2, "Agno_v", "Agno_t")
                Me.ddlAgno.SelectedValue = Now.Year
                objWeb.LlenaDDL(Me.ddlEstado, objLookUps.EstadosAporte, "cod_estado", "nombre")
                objWeb.LlenaDDL(Me.ddlTipoDocs, objLookUps.tipo_documentos, "cod_tipo_doc", "nombre")
                objLookUps = Nothing
                Me.calFechaIngreso.SelectedValue = Now.Date

                If Not Request("CodAporte") Is Nothing Then
                    If Not Request("CodAporte").ToString.Trim = "" Then
                        ViewState("CodAporte") = Request("CodAporte").ToString.Trim
                        ViewState("Modo") = "editar"
                        CargarAporte()
                    Else
                        ViewState("Modo") = "ingresar"
                    End If
                Else
                    ViewState("Modo") = "ingresar"
                End If

                Me.btnBuscar.Attributes.Add("onClick", "popup_pos('" & Parametros.p_DIRVIRTUALMAIL & "/modulo_administracion/buscador_empresas.aspx?campo=" & Me.txtRut.ClientID & "', 'NewWindow1', 380, 700, 100, 100);return false;")
            End If
            If Me.ddlTipoDocs.SelectedValue = 1 Then
                Me.ddlEstado.SelectedValue = 2
            End If
        Catch ex As Exception
            EnviaError("modulo_aporte/ingreso_aporte:Page_load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Try
            If txtRut.Text = "" Then
                body.Attributes.Add("onload", "alert('ATECIÓN: Debe ingresar un rut');")
                Exit Sub
            End If
            objIngresoAporte = New CIngresoAporte
            objIngresoAporte.Inicializar()
            objIngresoAporte.Rut = RutUsrALng(Me.txtRut.Text.Trim)
            objIngresoAporte.Agno = Me.ddlAgno.SelectedValue
            objIngresoAporte.CargaEmpresa()
            Me.lblNombre.Text = objIngresoAporte.Nombre
            Me.lblSaldoCtaCap.Text = objIngresoAporte.SaldoCap
            Me.lblSaldoCtaRep.Text = objIngresoAporte.SaldoRep
            Me.lblSaldoCtaCCL.Text = objIngresoAporte.SaldoCer
            Me.lblSaldoCtaBecas.Text = objIngresoAporte.SaldoBec

            Me.txtNumAporte.Text = objIngresoAporte.NumAporte
            Me.lblCostoAdm.Text = "(" & objIngresoAporte.PorcAdmin & "%)"
            Me.hdfCostoAdmin.Value = objIngresoAporte.PorcAdmin
            Me.hdfAdmNoLineal.Value = objIngresoAporte.AdmNoLineal

        Catch ex As Exception
            EnviaError("modulo_aporte/ingreso_aporte:btnCargar_Click-->" & ex.Message)
        End Try
        
    End Sub

    Protected Sub btnCalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Try
            calcular()
        Catch ex As Exception
            EnviaError("modulo_aporte/ingreso_aporte:btnCalcular_Click-->" & ex.Message)
        End Try
    End Sub
    Public Sub calcular()
        Try
            If txtTotalAporte.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATECIÓN: Debe ingresar un monto al total aporte');")
                Exit Sub
            End If
            If hdfCostoAdmin.Value.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATECIÓN: No se ha cargado el costo de administración.');")
                Exit Sub
            End If
            
            Dim lngAdmin As Long = 0
            Dim lngAporte As Long = 0
            lngAdmin = Math.Round((CInt(Me.txtTotalAporte.Text) * hdfCostoAdmin.Value) / (100 + (1 - hdfAdmNoLineal.Value) * hdfCostoAdmin.Value), 0, MidpointRounding.AwayFromZero)
            lngAporte = Math.Round(CInt(Me.txtTotalAporte.Text) - lngAdmin)

            txtAporteNeto.Text = lngAporte
            txtAdministracion.Text = lngAdmin

        Catch ex As Exception
            EnviaError("modulo_aporte/ingreso_aporte:calcular-->" & ex.Message)
        End Try
    End Sub
    Public Sub CargarAporte()
        Try
            objIngresoAporte = New CIngresoAporte
            objIngresoAporte.Inicializar()
            objIngresoAporte.CodAporte = ViewState("CodAporte")
            objIngresoAporte.RutUsuario = objSesion.Rut
            objIngresoAporte.CargarAporte()

            Me.txtRut.Text = RutLngAUsr(objIngresoAporte.Rut)
            Me.ddlAgno.SelectedValue = objIngresoAporte.Agno
            Me.lblNombre.Text = objIngresoAporte.Nombre
            Me.lblSaldoCtaCap.Text = objIngresoAporte.SaldoCap
            Me.lblSaldoCtaRep.Text = objIngresoAporte.SaldoRep
            Me.lblSaldoCtaCCL.Text = objIngresoAporte.SaldoCer
            Me.lblSaldoCtaBecas.Text = objIngresoAporte.SaldoBec

            Me.txtNumAporte.Text = objIngresoAporte.NumAporte
            Me.txtNumAporte.ReadOnly = True
            Me.txtTotalAporte.Text = objIngresoAporte.TotalAporte
            Me.ddlCuentasAporte.SelectedValue = objIngresoAporte.CodCuenta
            Me.txtAporteNeto.Text = objIngresoAporte.MontoNeto
            Me.txtAdministracion.Text = objIngresoAporte.MontoAdm
            Me.calFechaIngreso.SelectedValue = objIngresoAporte.FechaIngreso
            Me.ddlTipoDocs.SelectedValue = objIngresoAporte.CodTipoDocto
            Me.txtNumDocto.Text = objIngresoAporte.NumDocto
            Me.txtBanco.Text = objIngresoAporte.Banco
            Me.txtFechaVenc.Text = objIngresoAporte.FechaVenc
            Me.ddlEstado.SelectedValue = objIngresoAporte.CodEstado

            If objIngresoAporte.FechaCobro = FechaMinSistema() Then
                Me.txtFechaCobro.Text = ""
            Else
                Me.txtFechaCobro.Text = objIngresoAporte.FechaCobro
            End If
            Me.lblCostoAdm.Text = "(" & objIngresoAporte.PorcAdmin & "%)"
            Me.hdfCostoAdmin.Value = objIngresoAporte.PorcAdmin
            Me.hdfAdmNoLineal.Value = objIngresoAporte.AdmNoLineal
            Me.txtObservaciones.Text = objIngresoAporte.Observaciones

        Catch ex As Exception
            EnviaError("modulo_aporte/ingreso_aporte:CargarAporte-->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click

        If txtRut.Text = "" Then
            body.Attributes.Add("onload", "alert('ATECIÓN: Debe ingresar un rut');")
            Exit Sub
        End If
        If txtTotalAporte.Text.Trim = "" Then
            body.Attributes.Add("onload", "alert('ATECIÓN: Debe ingresar un monto al total aporte');")
            Exit Sub
        End If
        If hdfCostoAdmin.Value.Trim = "" Then
            body.Attributes.Add("onload", "alert('ATECIÓN: No se ha cargado el costo de administración.');")
            Exit Sub
        End If
        If Not IsNumeric(txtTotalAporte.Text.Trim) Then
            body.Attributes.Add("onload", "alert('ATECIÓN: Debe ingresar solo numeros en campo 'Total aportes'.');")
            Exit Sub
        End If
        'calcular()

        objIngresoAporte = New CIngresoAporte
        objIngresoAporte.Inicializar()
        objIngresoAporte.Rut = RutUsrALng(Me.txtRut.Text.Trim)
        objIngresoAporte.Agno = Me.ddlAgno.SelectedValue
        objIngresoAporte.CargaEmpresa()

        objIngresoAporte.CodCuenta = Me.ddlCuentasAporte.SelectedValue
        objIngresoAporte.MontoNeto = Me.txtAporteNeto.Text.Trim
        objIngresoAporte.MontoAdm = Me.txtAdministracion.Text.Trim
        objIngresoAporte.FechaIngreso = FechaUsrAVb(Me.calFechaIngreso.SelectedValue)
        objIngresoAporte.CodTipoDocto = Me.ddlTipoDocs.SelectedValue
        objIngresoAporte.NumDocto = Me.txtNumDocto.Text.Trim
        objIngresoAporte.Banco = Me.txtBanco.Text.Trim
        
        If Me.txtFechaVenc.Text = "" Then
            Me.txtFechaVenc.Text = FechaMinSistema()
        Else
            If EsFechaValidaVB(Me.txtFechaVenc.Text) Then
                objIngresoAporte.FechaVenc = FechaUsrAVb(Me.txtFechaVenc.Text.Trim)
            Else
                body.Attributes.Add("onload", "alert('ATECIÓN: La fecha de vencimiento no es válida.');")
                Exit Sub
            End If

        End If

        If Me.txtFechaCobro.Text = "" Then
            Me.txtFechaCobro.Text = FechaMinSistema()
        Else
            If EsFechaValidaVB(Me.txtFechaCobro.Text) Then
                objIngresoAporte.FechaCobro = FechaUsrAVb(Me.txtFechaCobro.Text.Trim)
            Else
                body.Attributes.Add("onload", "alert('ATECIÓN: La fecha de cobro no es válida.');")
                Exit Sub
            End If

        End If

        objIngresoAporte.NumAporte = Me.txtNumAporte.Text.Trim
        objIngresoAporte.Observaciones = Me.txtObservaciones.Text.Trim
        objIngresoAporte.CodEstado = Me.ddlEstado.SelectedValue
        objIngresoAporte.RutUsuario = objSesion.Rut
        If ViewState("Modo") = "ingresar" Then
            objIngresoAporte.NuevoAporte()
        ElseIf ViewState("Modo") = "editar" Then
            If Me.txtFechaCobro.Text = "" Then
                Me.txtFechaCobro.Text = FechaMinSistema()
            Else
                objIngresoAporte.FechaCobro = FechaUsrAVb(Me.txtFechaCobro.Text.Trim)
            End If

            objIngresoAporte.CodAporte = ViewState("CodAporte")
            objIngresoAporte.ModificarAporte()
        End If
        Me.hdfEnvioDatos.Value = 0
        Response.Redirect("../fichas/ficha_aporte_ingresado.aspx?codAporte=" & objIngresoAporte.NumAporte & "&rutCliente=" & objIngresoAporte.Rut)



    End Sub

   
End Class
'return ConfirmarEnvio('hdfEnvioDatos','ATENCIÓN: Esta a punto de enviar la información ingresada.\n¿Desea continuar?');
