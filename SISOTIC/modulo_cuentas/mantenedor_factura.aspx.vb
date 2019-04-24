Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_mantenedor_factura
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objMantenedor As CMantenedorFactura
    Dim objCursoContratador As CCursoContratado
    Dim objReporteFactura As CReporteFactura
    Dim objFactura As CFactura
    Dim objCliente As CCliente
    Dim objCurso As CCurso
    Dim objSql As CSql
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '**************Session***************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()

            'If Not objSession.AccesoObjeto(20) Then
            '    Response.Redirect("../Acceso_Denegado.aspx")
            '    Exit Sub
            'End If

            '************************************
           
            If Not Page.IsPostBack Then
                If objSession.EsClienteIngresoCurso Then
                    Me.hplIngresoCurso.Visible = True
                End If
                lblPie.Text = Parametros.p_PIE
                ViewState("RutUsuario") = objSession.Rut
                ViewState("CodCurso") = Request("codCurso")
                ViewState("EstadosFacturas") = Request("EstadosFacturas")
                ViewState("NumFactura") = Request("NumFactura")
                ViewState("Monto") = Request("Monto")
                ViewState("FechaFactura") = Request("FechaFactura")
                ViewState("FechaRecepcion") = Request("FechaRecepcion")
                ViewState("FechaPago") = Request("FechaPago")
                ViewState("Observaciones") = Request("Observaciones")
                ViewState("Agno") = Request("Agno")

                objWeb.LlenaDDL(ddlEstadofactura, objLookups.EstadoFactura, "cod_estado_fact", "nombre")
                Me.calFechaFactura.SelectedDate = Now.Date
                Me.calFechaPago.SelectedDate = Now.Date
                Me.calFechaRecepcion.SelectedDate = Now.Date
                objMantenedor = New CMantenedorFactura
                CargarDatos()

                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

            End If

            Me.btnCancelar.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"

        Catch ex As Exception
            EnviaError("modulo_cuentas_mantenedor_factura.aspx.vb:Page_Load-->" & ex.Message)
        End Try


    End Sub
    Public Function ValidaDatosPaso1() As Boolean
        Try

            ValidaDatosPaso1 = True

            If Me.txtNumFactura.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:Debe ingresar el número de factura');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.calFechaFactura.SelectedDate > Me.calFechaPago.SelectedDate Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:La fecha de emisión debe ser menor a la fecha de pago.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.calFechaRecepcion.SelectedDate > Me.calFechaPago.SelectedDate Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:La fecha de recepción debe ser menor a la fecha de pago.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If

            Dim lmgCostoOtic As Long
            lmgCostoOtic = Replace(Me.lblCostoOtic.Text, "$", "")

            lmgCostoOtic = Replace(lmgCostoOtic, ".", "")
            If Me.txtMonto.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:Debe ingresar el monto');")
                ValidaDatosPaso1 = False
                Exit Function
            End If

            If Me.txtMonto.Text.Trim <> lmgCostoOtic Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El monto de la factura debe ser ingresado por el total del costo.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If

            If Not IsNumeric(Me.txtNroVoucher.Text.Trim) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El numero de voucher debe ser un número entero.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If

            'If Not IsNumeric(Me.txtNotaCredito.Text.Trim) Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: La nota de crédito debe ser un número entero.');")
            '    ValidaDatosPaso1 = False
            '    Exit Function
            'End If

        Catch ex As Exception
            EnviaError("modulo_cuentas_mantenedor_factura.aspx.vb:ValidaDatosPaso1-->" & ex.Message)
        End Try
    End Function
    Public Sub CargarDatos()
        Try
            objReporteFactura = New CReporteFactura
            objCursoContratador = New CCursoContratado
            objCliente = New CCliente
            objCurso = New CCurso
            objFactura = New CFactura
            objSql = New CSql
            objReporteFactura.RutUsuario = objSession.Rut
            objCursoContratador.RutUsuario = objSession.Rut
            objReporteFactura.CodEstadoFactura = ViewState("EstadosFacturas")
            objReporteFactura.NumFactura = ViewState("NumFactura")
            objReporteFactura.Agno = ViewState("Agno")
            objReporteFactura.CodCurso = ViewState("CodCurso")
            objMantenedor.CodCurso = ViewState("CodCurso")
            objMantenedor.RutUsuario = objSession.Rut
            objReporteFactura.Consultar2()
            objMantenedor.CargarDatos()


            If ViewState("CodCurso") <> 0 Then
                objCursoContratador.Inicializar1(ViewState("CodCurso"))
                Dim strRut As String
                strRut = objCursoContratador.RutCliente
                objCliente.Inicializar0(objSql, objSession.Rut)
                objCliente.Inicializar1(strRut)
                objCurso.Inicializar0(objSql, objSession.Rut)
                objCurso.Inicializar1(objCursoContratador.CodSence)

                objCursoContratador.ObtenerAlumnos()

                objCursoContratador.ObtenerInfoCuentas()

                objFactura = objCursoContratador.Factura

            Else
                If objFactura.CodEstadoFactura <> 0 Then
                    Me.txtNumFactura.Text = objFactura.NumFactura
                    Me.calFechaFactura.SelectedValue = objFactura.Fecha
                    Me.calFechaRecepcion.SelectedValue = objFactura.FechaRecepcion
                    Me.calFechaPago.SelectedValue = objFactura.FechaPago
                    Me.txtMonto.Text = objFactura.Monto
                    Me.ddlEstadofactura.SelectedValue = objFactura.CodEstadoFactura
                    Me.txtObservacion.Text = objReporteFactura.Observacion
                    'Me.txtObservacion.Text = Replace(Replace(Me.txtObservacion.Text, objCursoContratador.Observacion, ""), " - ", "") & " - " & objCursoContratador.Observacion
                    Me.lblNroRegistro.Text = objCursoContratador.NroRegistro
                    Me.txtNroVoucher.Text = objReporteFactura.NroVoucher
                    ' Me.txtNroDocumento.Text = objReporteFactura.NroDocumento
                    ''Me.txtNroEgreso.Text = objReporteFactura.NroEgreso
                    ''If objReporteFactura.NotaCredito = 0 Then
                    ''    Me.txtNotaCredito.Text = ""
                    ''Else
                    ''    Me.txtNotaCredito.Text = objReporteFactura.NotaCredito
                    ''End If
                End If

            End If

            Me.lblCorrelativo.Text = objCursoContratador.Correlativo
            Me.lblNroRegistro.Text = objReporteFactura.Nroregistro
            Me.lblNombreCliente.Text = objCliente.NombreFantasia
            Me.lblNombreCurso.Text = objCurso.NombreCurso
            Me.lblNombreOtec.Text = objCursoContratador.Otec.RazonSocial
            Me.lblFechaInicio.Text = objCursoContratador.FechaInicio
            Me.lblFechaTermino.Text = objCursoContratador.FechaTermino
            Me.lblNumParticipantes.Text = objCursoContratador.NumAlumnos
            Me.lblCostoOtic.Text = FormatoPeso(objCursoContratador.CostoOtic)
            'Me.lblCostoOticComunicado.Text = FormatoPeso(objCursoContratador.ValorComunicado)
            If objReporteFactura.NumFactura = -1 Then
                Me.txtNumFactura.Text = ""
            Else
                Me.txtNumFactura.Text = objReporteFactura.NumFactura
            End If
            If objFactura.Fecha = FechaMinSistema() Then
                Me.calFechaFactura.SelectedValue = Now.Date
            Else
                Me.calFechaFactura.SelectedValue = objReporteFactura.FechaFactura
            End If

            If objFactura.FechaRecepcion = FechaMinSistema() Then
                Me.calFechaRecepcion.SelectedValue = Now.Date
            Else
                Me.calFechaRecepcion.SelectedValue = objReporteFactura.FechaRecepcion
            End If
            If objFactura.FechaPago = FechaMinSistema() Then
                Me.calFechaPago.SelectedValue = Now.Date
            Else
                Me.calFechaPago.SelectedValue = objReporteFactura.FechaPago
            End If


            Me.txtMonto.Text = objReporteFactura.MontoFactura
            Me.ddlEstadofactura.SelectedValue = objReporteFactura.CodEstadoFactura
            Me.txtObservacion.Text = objReporteFactura.Observacion
            Me.txtObservacion.Text = Replace(Replace(Me.txtObservacion.Text, objCursoContratador.Observacion, ""), " - ", "") & " - " & objCursoContratador.Observacion
            Me.lblNroRegistro.Text = objCursoContratador.NroRegistro
            Me.txtNroVoucher.Text = objReporteFactura.NroVoucher
            'Me.txtNroDocumento.Text = objReporteFactura.NroDocumento
            'Me.txtNroEgreso.Text = objReporteFactura.NroEgreso
            'If objReporteFactura.NotaCredito = 0 Then
            '    Me.txtNotaCredito.Text = ""
            'Else
            '    Me.txtNotaCredito.Text = objReporteFactura.NotaCredito
            'End If
            If objReporteFactura.CodEstadoFactura = 0 Then
                btnInsertar.Visible = True
                btnGrabar.Visible = False
            End If

            Dim strEstado As String
            strEstado = ViewState("EstadosFacturas")

            hplBitacoraFactura.NavigateUrl = "../modulo_cursos/reporte_bitacoras.aspx?codCurso=" & ViewState("CodCurso") & "&tipo=3" & "&estado=" & strEstado & "&agno=" & ViewState("Agno")

        Catch ex As Exception
            EnviaError("modulo_cuentas_mantenedor_factura.aspx.vb:CargarDatos-->" & ex.Message)
        End Try

    End Sub


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            objMantenedor = New CMantenedorFactura
            objReporteFactura = New CReporteFactura
            objFactura = New CFactura


            If Not ValidaDatosPaso1() Then
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If

            objMantenedor.Inicializar()
            objMantenedor.Correlativo = Me.lblCorrelativo.Text.Trim
            objMantenedor.NroRegistro = Me.lblNroRegistro.Text.Trim
            objMantenedor.NombreCliente = Me.lblNombreCliente.Text.Trim
            objMantenedor.NombreCurso = Me.lblNombreCurso.Text.Trim
            objMantenedor.NombreOtec = Me.lblNombreOtec.Text.Trim
            objMantenedor.FechaInicio = Me.lblFechaInicio.Text.Trim
            objMantenedor.FechaTermino = Me.lblFechaTermino.Text.Trim
            objMantenedor.NumAlumnos = Me.lblNumParticipantes.Text.Trim
            Me.lblCostoOtic.Text = FormatoPeso(objMantenedor.MontoFactura)
            'Me.lblCostoOticComunicado.Text = FormatoPeso(objMantenedor.ValorComunicado)

            objMantenedor.NumFactura = Me.txtNumFactura.Text.Trim
            objMantenedor.FechaFactura = FechaUsrAVb(Me.calFechaFactura.SelectedValue)
            objMantenedor.FechaRecepcion = Me.calFechaRecepcion.SelectedValue
            objMantenedor.FechaPago = Me.calFechaPago.SelectedValue
            objMantenedor.MontoFactura = Me.txtMonto.Text.Trim
            objMantenedor.Observacion = Me.txtObservacion.Text.Trim
            objMantenedor.NroVoucher = Me.txtNroVoucher.Text.Trim
            'objMantenedor.NroDocumento = Me.txtNroDocumento.Text.Trim
            'objMantenedor.NroEgreso = Me.txtNroEgreso.Text.Trim
            'If Me.txtNotaCredito.Text.Trim = "" Then
            '    objMantenedor.NotaCredito = 0
            'Else
            '    objMantenedor.NotaCredito = Me.txtNotaCredito.Text.Trim
            'End If

            objMantenedor.CodEstadoFactura = Me.ddlEstadofactura.SelectedValue
            objMantenedor.CodCurso = ViewState("CodCurso")
            objMantenedor.RutUsuario = objSession.Rut

            ViewState("CodCurso") = objMantenedor.CodCurso
            ViewState("EstadosFacturas") = objMantenedor.CodEstadoFactura
            ViewState("NumFactura") = objMantenedor.NumFactura
            ViewState("Monto") = objMantenedor.MontoFactura
            ViewState("FechaFactura") = objMantenedor.FechaFactura
            ViewState("FechaRecepcion") = objMantenedor.FechaRecepcion
            ViewState("FechaPago") = objMantenedor.FechaPago
            ViewState("Observaciones") = objMantenedor.Observacion
            objMantenedor.GrabarDatos()
            CargarDatos()

            Session("objeto") = objMantenedor
            Me.hdfEnvioDatos.Value = 0
        Catch ex As Exception
            EnviaError("modulo_cuentas_mantenedor_factura.aspx.vb:btnGrabar_Click-->" & ex.Message)
        End Try
        Response.Redirect("ficha_curso_contratado.aspx?CodCurso=" & ViewState("CodCurso") & "&Origen=factura")
    End Sub
    Protected Sub btnInsertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
        Try
            objMantenedor = New CMantenedorFactura
            objReporteFactura = New CReporteFactura
            objFactura = New CFactura


            If Not ValidaDatosPaso1() Then
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If

            objMantenedor.Inicializar()
            objMantenedor.Correlativo = Me.lblCorrelativo.Text.Trim
            objMantenedor.NroRegistro = Me.lblNroRegistro.Text.Trim
            objMantenedor.NombreCliente = Me.lblNombreCliente.Text.Trim
            objMantenedor.NombreCurso = Me.lblNombreCurso.Text.Trim
            objMantenedor.NombreOtec = Me.lblNombreOtec.Text.Trim
            objMantenedor.FechaInicio = Me.lblFechaInicio.Text.Trim
            objMantenedor.FechaTermino = Me.lblFechaTermino.Text.Trim
            objMantenedor.NumAlumnos = Me.lblNumParticipantes.Text.Trim
            Me.lblCostoOtic.Text = FormatoPeso(objMantenedor.MontoFactura)
            'Me.lblCostoOticComunicado.Text = FormatoPeso(objMantenedor.ValorComunicado)

            objMantenedor.NumFactura = Me.txtNumFactura.Text.Trim
            objMantenedor.FechaFactura = FechaUsrAVb(Me.calFechaFactura.SelectedValue)
            objMantenedor.FechaRecepcion = Me.calFechaRecepcion.SelectedValue
            objMantenedor.FechaPago = Me.calFechaPago.SelectedValue
            objMantenedor.MontoFactura = Me.txtMonto.Text.Trim
            objMantenedor.Observacion = Me.txtObservacion.Text.Trim
            objMantenedor.NroVoucher = Me.txtNroVoucher.Text.Trim
            'objMantenedor.NroDocumento = Me.txtNroDocumento.Text.Trim
            'objReporteFactura.NroEgreso = Me.txtNroEgreso.Text.Trim
            'If Me.txtNotaCredito.Text.Trim = "" Then
            '    objMantenedor.NotaCredito = 0
            'Else
            '    objMantenedor.NotaCredito = Me.txtNotaCredito.Text.Trim
            'End If
            objMantenedor.CodEstadoFactura = Me.ddlEstadofactura.SelectedValue
            objMantenedor.CodCurso = ViewState("CodCurso")
            objMantenedor.RutUsuario = objSession.Rut

            ViewState("CodCurso") = objMantenedor.CodCurso
            ViewState("EstadosFacturas") = objMantenedor.CodEstadoFactura
            ViewState("NumFactura") = objMantenedor.NumFactura
            ViewState("Monto") = objMantenedor.MontoFactura
            ViewState("FechaFactura") = objMantenedor.FechaFactura
            ViewState("FechaRecepcion") = objMantenedor.FechaRecepcion
            ViewState("FechaPago") = objMantenedor.FechaPago
            ViewState("Observaciones") = objMantenedor.Observacion
            objMantenedor.InsertarDatos()
            CargarDatos()

            Session("objeto") = objMantenedor
            Me.hdfEnvioDatos.Value = 0
        Catch ex As Exception
            EnviaError("modulo_cuentas_mantenedor_factura.aspx.vb:btnInsertar_Click-->" & ex.Message)
        End Try
        Response.Redirect("ficha_curso_contratado.aspx?CodCurso=" & ViewState("CodCurso"))
    End Sub
End Class
