Imports System.Data
Imports System.Data.OleDb
Imports Modulos
Imports Clases
Imports Clases.Web
Partial Class modulo_administracion_mantenedor_traspaso_cuentas
    Inherits System.Web.UI.Page
    Dim objCliente As New CCliente
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objmantenedor As New CTraspasoSaldosManual
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '***********************************************************************************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        '***********************************************************************************
        body.Attributes.Clear()
        If Not IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
            objWeb.LlenaDDL(Me.ddlCuentaDestino, objLookups.Cuentas, "cod_cuenta", "nombre")
            objWeb.LlenaDDL(Me.ddlCuentaOrigen, objLookups.Cuentas, "cod_cuenta", "nombre")
            objmantenedor.RutUsuario = objSession.Rut
            clpFecha.SelectedDate = Date.Now
            ddlAgnos.SelectedValue = objSession.Agno
            If Not Request("rut_empresa") Is Nothing Then
                Me.txtRutEmpresa.Text = Request("rut_empresa")
                Consultar()
            End If
        End If
        If Me.ddlAgnos.SelectedValue = 2010 Then
            Me.trExcCong2008.Visible = True
            Me.trExcCong2009.Visible = True
        Else
            Me.trExcCong2008.Visible = False
            Me.trExcCong2009.Visible = False
        End If
        btnBuscarEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_Cursos/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        consultar()
    End Sub
    Private Sub Consultar()
        Try

            objCliente.Agno = Me.ddlAgnos.SelectedValue
            objmantenedor.RutUsuario = objSession.Rut
            objmantenedor.Cliente.Agno = Me.ddlAgnos.SelectedValue
            If Me.txtRutEmpresa.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('Debe ingresar un rut de empresa');")
                txtRutEmpresa.Focus()
                Exit Sub
            End If
            objmantenedor.inicializarCliente()
            If objmantenedor.Cliente.Inicializar3(Me.txtRutEmpresa.Text.Trim) Then
                'Modificar = True
                ' = objCliente.RazonSocial
                lblNombreEmpresa.Text = objmantenedor.Cliente.RazonSocial
                lblNombreEmpresa.Visible = True
                Me.lblSaldoCapacitacion.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaCap.SumaSaldoPend)
                Me.lblSaldoReparto.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaRep.SaldoActual)
                'Me.lblSaldoB = objCliente.ObjCuentaAdm.SaldoActual
                Me.lblSaldoAdmin.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaAdm.SaldoActual)
                Me.lblSaldoExcCapacitacion.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaExcCap.SaldoActual)
                Me.lblSaldoExcReparto.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaExcRep.SaldoActual)
                Me.lblSaldoFinOtic.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaFinanciamientoOtic.SaldoActual)
                Me.lblSaldoExcCong2008.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaExcCon2008.SaldoActual)
                Me.lblSaldoExcCong2009.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaExcCon2009.SaldoActual)
                Me.lblSaldoBecas.Text = FormatoMonto(objmantenedor.Cliente.ObjCuentaBecas.SaldoActual + objmantenedor.Cliente.ObjCuentaBecas.SumaAbonoXMandato)
            End If
        Catch ex As Exception
            EnviaError("modulo_administracio;mantendor_traspaso_cuentas.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.txtRutEmpresa.Text.Trim = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar un rut de empresa');")
            txtRutEmpresa.Focus()
            Exit Sub
        End If
        If Me.txtMonto.Text.Trim = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar monto');")
            txtMonto.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtMonto.Text.Trim) Then
            body.Attributes.Add("onload", "alert('Debe ingresar monto numérico');")
            txtMonto.Focus()
            Exit Sub
        End If
        If Me.txtObservacion.Text.Trim = "" Then
            body.Attributes.Add("onload", "alert('Debe ingresar observación');")
            txtObservacion.Focus()
            Exit Sub
        End If
        If Me.ddlCuentaDestino.SelectedValue = Me.ddlCuentaOrigen.SelectedValue Then
            body.Attributes.Add("onload", "alert('Las cuentas de origen y destino no pueden ser la misma');")
            ddlCuentaOrigen.Focus()
            Exit Sub
        End If
        ' Consultar()
        Dim lngSaldoCapacitacion As Long = Replace(lblSaldoCapacitacion.Text, ".", "")
        Dim lngSaldoReparto As Long = Replace(lblSaldoReparto.Text, ".", "")
        Dim lngSaldoExcCapacitacion As Long = Replace(lblSaldoExcCapacitacion.Text, ".", "")
        Dim lngSaldoExcReparto As Long = Replace(lblSaldoExcReparto.Text, ".", "")
        Dim lngSaldoBecas As Long = Replace(lblSaldoBecas.Text, ".", "")
        Dim lngSaldoFinOtic As Long = Replace(lblSaldoFinOtic.Text, ".", "")
        Dim lngSaldoExcCong2008 As Long = Replace(lblSaldoExcCong2008.Text, ".", "")
        Dim lngSaldoExcCong2009 As Long = Replace(lblSaldoExcCong2009.Text, ".", "")

        If Me.ddlCuentaOrigen.SelectedValue = 1 And txtMonto.Text > lngSaldoCapacitacion Then
            body.Attributes.Add("onload", "alert('El saldo de la cuenta es menor al valor ingresado');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlCuentaOrigen.SelectedValue = 2 And txtMonto.Text > lngSaldoReparto Then
            body.Attributes.Add("onload", "alert('El saldo de la cuenta es menor al valor ingresado');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlCuentaOrigen.SelectedValue = 4 And txtMonto.Text > lngSaldoExcCapacitacion Then
            body.Attributes.Add("onload", "alert('El saldo de la cuenta es menor al valor ingresado');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlCuentaOrigen.SelectedValue = 5 And txtMonto.Text > lngSaldoExcReparto Then
            body.Attributes.Add("onload", "alert('El saldo de la cuenta es menor al valor ingresado');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlCuentaOrigen.SelectedValue = 6 And txtMonto.Text > lngSaldoBecas Then
            body.Attributes.Add("onload", "alert('El saldo de la cuenta es menor al valor ingresado');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlCuentaOrigen.SelectedValue = 7 And txtMonto.Text > lngSaldoFinOtic Then
            body.Attributes.Add("onload", "alert('El saldo de la cuenta es menor al valor ingresado');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlCuentaOrigen.SelectedValue = 10 And txtMonto.Text > lngSaldoExcCong2008 Then
            body.Attributes.Add("onload", "alert('El saldo de la cuenta es menor al valor ingresado');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlCuentaOrigen.SelectedValue = 11 And txtMonto.Text > lngSaldoExcCong2009 Then
            body.Attributes.Add("onload", "alert('Debe ingresar monto numérico');")
            txtMonto.Focus()
            Exit Sub
        ElseIf Me.ddlAgnos.SelectedValue <> Year(Me.clpFecha.SelectedValue) Then
            body.Attributes.Add("onload", "alert('El año de consulta debe ser igual al de la fecha');")
            txtMonto.Focus()
            Exit Sub
        End If


        objmantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text)
        objmantenedor.CodCtaOrigen = Me.ddlCuentaOrigen.SelectedValue
        objmantenedor.CodCtaDestino = Me.ddlCuentaDestino.SelectedValue
        objmantenedor.Observacion = Me.txtObservacion.Text
        objmantenedor.MontoTraspaso = Me.txtMonto.Text
        objmantenedor.RutUsuario = objSession.Rut
        objmantenedor.FechaContTraspaso = Me.clpFecha.SelectedDate
        Call objmantenedor.InsertarTraspaso()
        Consultar()
        If objmantenedor.InsertarExitoso Then
            body.Attributes.Add("onload", "alert('La Información ha sido ingresada correctamente.');")
            txtMonto.Focus()
        Else
            body.Attributes.Add("onload", "alert('Hubo un error al ingresar los datos.');")
            txtMonto.Focus()
        End If
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
End Class
