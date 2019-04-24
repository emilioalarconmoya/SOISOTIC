Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_certificado_aportes
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objSessionCliente As CSession
    Dim objCliente As New CCliente
    Dim objClienteAportes As New CClienteAportes
    Dim objLookups As New Clookups
    Dim objSql As New CSql

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        objWeb.ChequeaCliente(objSessionCliente)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '************************************
        If objSessionCliente Is Nothing Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un cliente');")
            Exit Sub
        End If
        If Not Page.IsPostBack Then
            'If objSession.EsClienteIngresoCurso Then
            '    Me.hplIngresoCurso.Visible = True
            'End If
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            lblPie.Text = Parametros.p_PIE
            ViewState("rutCliente") = objSessionCliente.Rut
            ViewState("Agno") = objSession.Agno

        End If
        objWeb = New CWeb
        objWeb.ChequeaCliente(objSessionCliente)
        If Not objSessionCliente Is Nothing Then
            Consultar()
        End If
    End Sub
    Private Sub Consultar()
        Try
            Dim strRut As String
            strRut = RutLngAUsr(ViewState("rutCliente"))
            objCliente.Inicializar(objSql)
            objCliente.Agno = ViewState("Agno")
            objCliente.Inicializar1(strRut)
            objClienteAportes.Consultar(ViewState("Agno"), ViewState("rutCliente"))

            If objClienteAportes.Total > 0 Then
                Me.lblNombreEmpresa.Text = Parametros.p_EMPRESA
                Me.lblRutEmpresa.Text = Parametros.p_RUTEMPRESA
                Me.lblDireccionEmpresa.Text = Parametros.p_DIRECIONEMPRESA
                Me.lblFonoEmpresa.Text = Parametros.p_FONOEMPRESA

                Me.lblAgno.Text = objSession.Agno
                Me.lblNroCertificado.Text = objClienteAportes.NroCertificado
                Me.lblRazonSocial.Text = objCliente.RazonSocial
                Me.lblRut.Text = RutLngAUsr(objCliente.Rut)
                Me.lblDireccion.Text = objCliente.Direccion
                Me.lblComuna.Text = objCliente.Comuna
                Me.lblPersonaQueFirma.Text = Parametros.p_PERSONAFIRMA
                Me.lblFechaDeHoy.Text = Now.Date
                Me.lblNroParticipantes.Text = FormatoMonto(objCliente.NumEmpleados)
                Me.lblPorcFranquicia.Text = FormatoMonto(objCliente.ObjInfoAdicional.FranquiciaActual)

                Me.lblMontoEnero.Text = FormatoMonto(objClienteAportes.MontoEnero)
                Me.lblMontoFebrero.Text = FormatoMonto(objClienteAportes.MontoFebrero)
                Me.lblMontoMarzo.Text = FormatoMonto(objClienteAportes.MontoMarzo)
                Me.lblMontoAbril.Text = FormatoMonto(objClienteAportes.MontoAbril)
                Me.lblMontoMayo.Text = FormatoMonto(objClienteAportes.MontoMayo)
                Me.lblMontoJunio.Text = FormatoMonto(objClienteAportes.MontoJunio)
                Me.lblMontoJulio.Text = FormatoMonto(objClienteAportes.MontoJulio)
                Me.lblMontoAgosto.Text = FormatoMonto(objClienteAportes.MontoAgosto)
                Me.lblMontoSeptiembre.Text = FormatoMonto(objClienteAportes.MontoSeptiembre)
                Me.lblMontoOctubre.Text = FormatoMonto(objClienteAportes.MontoOctubre)
                Me.lblMontoNoviembre.Text = FormatoMonto(objClienteAportes.MontoNoviembre)
                Me.lblMontoDiciembre.Text = FormatoMonto(objClienteAportes.MontoDiciembre)
                Me.lblMontoTotal.Text = FormatoMonto(objClienteAportes.Total)

                Me.lblAgnoNota.Text = objSession.Agno + 1
                Me.lblNombreEmpresaNota.Text = Parametros.p_EMPRESA
                Me.lblDiasCertificado.Text = Parametros.p_DIACERTIFICADOAPORTE
                Me.btnImprimir.Visible = True
            Else
                Me.lblMensajeNoDatos.Visible = True
                Me.lblAgnoNoDatos.Text = objSession.Agno
                Me.lblAgnoNoDatos.Visible = True
                Me.menu.Visible = False
                Me.btnImprimir.Visible = False
            End If

        Catch ex As Exception
            EnviaError("certificado_aportes: Consultar-->" & ex.Message)
        End Try
    End Sub
    Private Sub mensajeError()
     
    End Sub
End Class
