Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_aporte_ingresado
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objAporte As CAporte
    Dim objCliente As CCliente

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        body.Attributes.Clear()
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        ViewState("CodAporte") = Request("codAporte")
        ViewState("CodRut") = Request("rutCliente")
        '************************************
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            'btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If
        Consultar()
        Me.btnPopupEnviarCorreo.Attributes.Add("onClick", "popup_pos('../modulo_aporte/enviar_correo.aspx?emailEmpresa=" & lblEmail.Text & "&codAporte=" & ViewState("CodAporte") & "&rutUsuario=" & objSession.Rut & "', 'NewWindow1', 600, 900, 100, 100);return false;")
        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"


    End Sub

    Public Sub Consultar()
        objAporte = New CAporte
        objCliente = New CCliente
        Dim CodigoAporte As Long
        CodigoAporte = ViewState("CodAporte")
        objAporte.Inicializar2(CodigoAporte)
        lblAporte.Text = objAporte.NumAporte
        lblFolio.Text = objAporte.Correlativo
        Dim EstadoActual As String
        Dim Estado As Integer
        Estado = objAporte.CodEstado
        If Estado = 0 Or Estado = 1 Then
            EstadoActual = "Por cobrar"
            btnAnular.Visible = True
        End If
        If Estado = 2 Then
            EstadoActual = "Cobrado"
            btnAnular.Visible = True
        End If
        If Estado = 3 Then
            EstadoActual = "Anulado"
        End If
        lblEstado.Text = EstadoActual
        lblFechaIng.Text = objAporte.FechaContableIngreso
        lblOrigen.Text = objAporte.Origen
        Dim lngRut As Long
        Dim strRut As String
        lngRut = ViewState("CodRut")
        strRut = RutLngAUsr(lngRut)
        Dim mobjsql As New CSql
        objCliente.Inicializar0(mobjsql, lngRut)
        objCliente.Inicializar1(strRut)
        hplRazonSocial.Text = objCliente.RazonSocial
        hplRazonSocial.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & lngRut
        lblRutEmpresa.Text = RutLngAUsr(objCliente.Rut)
        lblDireccion.Text = objCliente.Direccion
        lblContacto.Text = objCliente.Contacto
        lblCargo.Text = objCliente.CargoContacto
        lblFono.Text = objCliente.FonoContacto
        lblFax.Text = objCliente.Fax
        lblEmail.Text = objCliente.EmailContacto
        lblMonto.Text = objAporte.MontoCuenta
        lblMonto.Text = FormatoPeso(lblMonto.Text)
        lblAdmin.Text = objAporte.MontoAdmin
        lblAdmin.Text = FormatoPeso(lblAdmin.Text)
        lblTotal.Text = objAporte.MontoTotal
        lblTotal.Text = FormatoPeso(lblTotal.Text)
        Dim CuentaAAbonar As String
        If objAporte.CodCuenta = 1 Then
            CuentaAAbonar = "Capacitacion"
        ElseIf objAporte.CodCuenta = 2 Then
            CuentaAAbonar = "Reparto"
        ElseIf objAporte.CodCuenta = 7 Then
            CuentaAAbonar = "Financiamiento Otic"
        Else
            CuentaAAbonar = "Becas"
        End If
        lblCuenta.Text = CuentaAAbonar
        Dim NombreDocumento As String
        If objAporte.CodTipoDocumento = 1 Then
            NombreDocumento = "Efectivo"
        ElseIf objAporte.CodTipoDocumento = 2 Then
            NombreDocumento = "Cheque al día"
        ElseIf objAporte.CodTipoDocumento = 3 Then
            NombreDocumento = "Cheque a fecha"
        ElseIf objAporte.CodTipoDocumento = 4 Then
            NombreDocumento = "Letra"
        End If
        lblTipoDoc.Text = NombreDocumento
        lblNumDoc.Text = objAporte.NroDocumento
        lblBanco.Text = objAporte.BancoDoc
        lblFechaVen.Text = objAporte.FechaVencDoc
        lblFechCob.Text = objAporte.FechaCobro
        lblFechaCob.Text = objAporte.FechaCobro
        lblObserv.Text = objAporte.Observaciones
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("../modulo_aportes/reporte_aporte.aspx")
    End Sub

    Protected Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            objAporte.RutUsuario = objSession.Rut
            objAporte.Inicializar2(ViewState("CodAporte"))
            objAporte.Anular("", objSession.Rut)
            Me.hdfEnvioDatos.Value = 0
            Consultar()
            body.Attributes.Add("onload", "alert'(ATENCIÓN: El aporte ha sido anulado correctamente.');")
        Catch ex As Exception
            EnviaError("fichas/ficha_aporte_ingresado:btnAnular_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        GenerarComprobante()
    End Sub
    Private Sub GenerarComprobante()
        Dim objGenerarComprobante As New CGeneraComprobanteAporte
        objGenerarComprobante.GenerarComprobanteAporte(lblAporte.Text.Trim.ToUpper, _
                                                       FechaUsrAVb(lblFechaIng.Text.Trim.ToUpper), _
                                                       hplRazonSocial.Text.Trim.ToUpper, _
                                                       RutUsrALng(lblRutEmpresa.Text.Trim.ToUpper), _
                                                       lblDireccion.Text.Trim.ToUpper, _
                                                       Replace(Replace(lblTotal.Text.Trim.ToUpper, "$", ""), ".", ""), _
                                                       lblNumDoc.Text.Trim.ToUpper, _
                                                       lblBanco.Text.Trim.ToUpper, _
                                                       FechaUsrAVb(lblFechaCob.Text.Trim.ToUpper), _
                                                       lblObserv.Text.Trim.ToUpper)
        'Dim direccion As String = Request.QueryString("dir")
        'Dim nombre_archivo As String = Request.QueryString("archivo")
        Response.AppendHeader("content-disposition", "attachment; filename=comprobante_aporte_" & lblAporte.Text.Trim.ToUpper & ".pdf") ' & objGenerarComprobante.RutaArchivo)
        Response.Clear()
        Response.WriteFile(objGenerarComprobante.RutaArchivo)
        Response.End()
    End Sub

    Protected Sub btnEnviaEmail_Click(sender As Object, e As EventArgs) Handles btnPopupEnviarCorreo.Click

    End Sub
End Class
