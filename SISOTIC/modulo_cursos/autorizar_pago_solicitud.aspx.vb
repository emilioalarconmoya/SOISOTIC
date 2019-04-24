Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_autorizar_pago_solicitud
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objReporte As CAutorizarSolicitudPagoTercero
    Dim objReporteSol As CReporteSolicitudes
    Dim objCurso As CCursoContratado
    Dim objSolicitud As CSolicitud 
    Dim objLookups As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        body.Attributes.Clear()
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '************************************
        ViewState("CodCurso") = Request("codCurso")
        ViewState("rutBenefactor") = Request("rutBenefactor")
        ViewState("rutCliente") = Request("rutCliente")
        ViewState("nombreBenefactor") = Request("nombreBenefactor")
        ViewState("nombreBeneficiado") = Request("nombreBeneficiado")


        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
            Consultar()
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If

        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"

    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CAutorizarSolicitudPagoTercero


            objReporte.RutUsuario = objSession.Rut
            objReporte.RutCliente = ViewState("rutCliente")
            'objReporte.Agno = objSession.Agno
            objReporte.CodCurso = ViewState("CodCurso")
            objReporte.RutBenefactor = ViewState("rutBenefactor")
            objReporte.RutBeneficiado = ViewState("rutCliente")
            objReporte.NombreBenefactor = ViewState("nombreBenefactor")
            objReporte.NombreBeneficiado = ViewState("nombreBeneficiado")
            objReporte.Consultar()

            Me.lblCorrelativo.Text = objReporte.Correlativo
            Me.lblNombreBeneficiado.Text = objReporte.NombreBeneficiado
            Me.lblRutBeneficiado.Text = RutLngAUsr(objReporte.RutBeneficiado)
            Me.lblFechaIngreso.Text = objReporte.FechaIngreso
            Me.lblFechaInicio.Text = objReporte.FechaInicio
            Me.lblAporteSolicitado.Text = FormatoPeso(objReporte.MontoSolicitud)

            Me.lblNombreBenefactor.Text = objReporte.NombreBenefactor
            Me.lblRutBenefactor.Text = RutLngAUsr(objReporte.RutBenefactor)
            Me.lblCuentaReparto.Text = FormatoPeso(objReporte.SaldoCtaRep + objReporte.MontoSolicitud)
            Me.lblCuentaExcReparto.Text = FormatoPeso(objReporte.SaldoCtaExcRep)
            Me.lblPorcAdmin.Text = objReporte.PorcAdmin
            Me.txtMontoCuentaReparto.Text = objReporte.MontoSolicitud
            Me.txtMontoCuentaExcReparto.Text = 0 'objReporte.SaldoCtaExcRep
            Me.txtMontoCuentaAdmin.Text = Math.Round(((100 * objReporte.MontoSolicitud) / (100 - Me.lblPorcAdmin.Text)) - objReporte.MontoSolicitud, 0)
            Me.hdfCodCurso.Value = objReporte.CodCurso
            ViewState("PorcAdmin") = objReporte.PorcAdmin


        Catch ex As Exception
            EnviaError("modulo_cursos_autorizacion_pago_solicitud.aspx.vb:Consultar->" & ex.Message)
        End Try


    End Sub
    Public Sub CalculaValorFinal()
        If txtMontoCuentaReparto.Text = "" Then
            txtMontoCuentaReparto.Text = 0
        End If
        If txtMontoCuentaExcReparto.Text = "" Then
            txtMontoCuentaExcReparto.Text = 0
        End If
        If CInt(Me.txtMontoCuentaReparto.Text) > 0 Then
            Me.txtMontoCuentaAdmin.Text = Math.Round(((100 * Me.txtMontoCuentaReparto.Text) / (100 - ViewState("PorcAdmin"))) - Me.txtMontoCuentaReparto.Text, 0)
            Me.txtTotalMonto.Text = CInt(Me.txtMontoCuentaReparto.Text) + CInt(Me.txtMontoCuentaExcReparto.Text) + CInt(Me.txtMontoCuentaAdmin.Text)
        ElseIf CInt(Me.txtMontoCuentaReparto.Text) > 0 And CInt(Me.txtMontoCuentaExcReparto.Text) > 0 Then
            Me.txtMontoCuentaAdmin.Text = Math.Round(((100 * Me.txtMontoCuentaReparto.Text) / (100 - ViewState("PorcAdmin"))) - Me.txtMontoCuentaReparto.Text, 0)
            Me.txtTotalMonto.Text = CInt(Me.txtMontoCuentaReparto.Text) + CInt(Me.txtMontoCuentaExcReparto.Text) + CInt(Me.txtMontoCuentaAdmin.Text)
        ElseIf CInt(Me.txtMontoCuentaReparto.Text) = 0 And CInt(Me.txtMontoCuentaExcReparto.Text) > 0 Then
            Me.txtMontoCuentaAdmin.Text = 0
            Me.txtTotalMonto.Text = CInt(Me.txtMontoCuentaExcReparto.Text)
        End If
    End Sub

    Protected Sub btnTotal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTotal.Click
        CalculaValorFinal()
    End Sub
    Public Sub VerificarDatos()
        If objReporte.SaldoCtaRep = "" Then
            Me.lblCuentaReparto.Text = 0
        End If
        If objReporte.SaldoCtaExcRep = "" Then
            Me.lblCuentaExcReparto.Text = 0
        End If
    End Sub
    Public Sub CalcularTotalCargos()

    End Sub
    Public Function ValidarDatos() As Boolean
        Try
            If txtMontoCuentaReparto.Text = "" Then
                txtMontoCuentaReparto.Text = 0
            End If
            If txtMontoCuentaExcReparto.Text = "" Then
                txtMontoCuentaExcReparto.Text = 0
            End If

            If txtMontoCuentaAdmin.Text = "" Then
                txtMontoCuentaAdmin.Text = 0
            End If
            Dim lngValor1 As Long
            lngValor1 = Me.txtMontoCuentaReparto.Text
            Dim strValor As String
            Dim lngValor2 As Long
            strValor = Me.lblAporteSolicitado.Text
            strValor = Replace(strValor, "$", "")
            lngValor2 = CLng(strValor)
            Dim lngValor3 As Long
            lngValor3 = Me.txtMontoCuentaExcReparto.Text
            ValidarDatos = True

            If Me.txtMontoCuentaReparto.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el monto de la cuenta de reparto');")
                ValidarDatos = False
                Exit Function
            End If
            If lngValor1 <> lngValor2 And lngValor3 <> lngValor2 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El total ingresado no corresponde al monto solicitado.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtTotalMonto.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Presione el botón Total para ver el total de cargos.');")
                ValidarDatos = False
                Exit Function
            End If

        Catch ex As Exception
            EnviaError("modulo_cursos/modulo_cursos_autorizacion_pago_solicitud.aspx.vb:ValidarDatos-->" & ex.Message)
        End Try
    End Function

    Protected Sub btnAutorizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click

        If Not ValidarDatos() Then
            Me.btnAutorizar.Attributes.Add("onclick", "return confirm('¿Está seguro de realizar esta operación?');")
            Exit Sub
        End If

        If txtMontoCuentaReparto.Text = "" Then
            txtMontoCuentaReparto.Text = 0
        End If
        If txtMontoCuentaExcReparto.Text = "" Then
            txtMontoCuentaExcReparto.Text = 0
        End If

        Dim lngValor1 As Long
        lngValor1 = Me.txtMontoCuentaReparto.Text
        Dim strValor As String
        Dim lngValor2 As Long
        strValor = Me.lblAporteSolicitado.Text
        strValor = Replace(strValor, "$", "")
        lngValor2 = CLng(strValor)

        ' Me.btnAutorizar.Attributes.Add("onclick", "return confirm('¿Está seguro de realizar esta operación?');")


        Dim lngCodCurso As Long
        lngCodCurso = Me.hdfCodCurso.Value
        Dim lngCtaRep As Long
        'lngCtaRep = objSolicitud.MontoCtaAdm
        lngCtaRep = Me.txtMontoCuentaReparto.Text
        'lngCtaRep = objReporte.SaldoCtaRep
        Dim lngRutBenefactor As Long
        'Dim lngRutBenefactor2 As Long
        lngRutBenefactor = RutUsrALng(Me.lblRutBenefactor.Text) 'objSolicitud.RutBenefactor  '

        Dim lngRutBeneficiado As Long
        lngRutBeneficiado = RutUsrALng(Me.lblRutBeneficiado.Text) 'objSolicitud.RutBeneficiado  
        Dim lngCtaExcRep As Long
        lngCtaExcRep = Me.txtMontoCuentaExcReparto.Text ' objSolicitud.SaldoCtaExcRep '
        Dim lngCtaAdm As Long
        lngCtaAdm = Me.txtMontoCuentaAdmin.Text
        'Response.Redirect("actualizar_sol_pagos_terceros.aspx?CtaRep=" & lngCtaRep & "&rutBenefactor=" & lngRutBenefactor & "&rutCliente=" & lngRutBeneficiado & "&CtaExcRep=" & lngCtaExcRep)
        Response.Redirect("actualizar_sol_pagos_terceros.aspx?codCurso=" & lngCodCurso & "&CtaRep=" & lngCtaRep & "&rutBenefactor=" & lngRutBenefactor & "&rutCliente=" & lngRutBeneficiado & "&CtaExcRep=" & lngCtaExcRep & "&CtaAdm=" & lngCtaAdm)

    End Sub

End Class
