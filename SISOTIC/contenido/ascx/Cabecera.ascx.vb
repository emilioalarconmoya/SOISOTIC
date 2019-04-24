Imports Clases
Imports Clases.Web
Imports Modulos
Imports System.Data
Partial Class contenido_ascx_cabecera
    Inherits System.Web.UI.UserControl
    Private objSessionCliente As CSession
    Private objSession As CSession
    Private objWeb As CWeb
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaCliente(objSessionCliente)
        '************************************
        If Not Page.IsPostBack Then

            cargacabecera()
            Me.lblFechaActual.Text = Now.Date()
            Me.lblHoraActual.Text = DateTime.Now.ToLongTimeString
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('" & Parametros.p_DIRVIRTUALMAIL & "/modulo_administracion/buscador_empresas.aspx?campo=" & Me.txtRutEmpresa.ClientID & "', 'NewWindow1', 380, 700, 100, 100);return false;")
            'Me.txtRutEmpresa.Text = Session("RutCliente")
        End If

    End Sub
    Public Sub Cargar(ByVal strRutCliente As String)
        Session("cliente") = Nothing
        If validarut(strRutCliente) = True Then
            objSessionCliente = New CSession
            If objSessionCliente.ChequearCliente(strRutCliente) Then
                objWeb.ChequeaCliente(objSessionCliente)   'Carga el objeto session

            End If

        End If

        cargacabecera()
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "pos", "<script language='javascript' type='text/javascript'> " & _
                 "window.location.href=document.URL;" & _
                 "</script>")
    End Sub
    Public Sub cargacabecera()
        If objSessionCliente Is Nothing Then
            objWeb = New CWeb
            objWeb.ChequeaSession(objSessionCliente)
            objWeb = Nothing
        End If
        If objSessionCliente.RazonSocial Is Nothing Then
            Me.tr1.Visible = False
            Me.tr2.Visible = False
            Me.td1.Visible = False
            Me.td2.Visible = False
            Me.td3.Visible = False
            Me.td4.Visible = False
        Else
            If objSessionCliente.RazonSocial.Trim = "" Then
                Me.tr1.Visible = False
                Me.tr2.Visible = False
                Me.td1.Visible = False
                Me.td2.Visible = False
                Me.td3.Visible = False
                Me.td4.Visible = False
            Else

                Me.tr1.Visible = True
                Me.tr2.Visible = True
                Me.td1.Visible = True
                Me.td2.Visible = True
                Me.td3.Visible = True
                Me.td4.Visible = True


                'Me.lblDataRut.Text = RutLngAUsr(objSession.Rut)
                Me.txtRutEmpresa.Text = RutLngAUsr(objSessionCliente.RutCliente)
                Me.lblDataDireccion.Text = objSessionCliente.Direccion.Trim
                Me.lblDataFono.Text = objSessionCliente.Fono.Trim
                'Me.lblDataFax.Text = objSessionCliente.Fax.Trim

                'Me.hplEmailEmp.Text = objSessionCliente.EmailEmpresa
                'Dim strMailEmp As String = objSessionCliente.EmailEmpresa
                'hplEmailEmp.NavigateUrl = "mailto:" & strMailEmp.Trim

                Me.lblDataNombreEjecutivo.Text = objSessionCliente.NombreEjecutivo.Trim
                Me.lblDataFonoEjecutivo.Text = objSessionCliente.FonoEjecutivo.Trim
                'Me.lblDataFaxEjecutivo.Text = objSessionCliente.FaxEjecutivo.Trim
                Dim strMail As String
                strMail = objSessionCliente.EmailEjecutivo.Trim
                Me.HplkEmailEjecutivo.Text = objSessionCliente.EmailEjecutivo.Trim
                HplkEmailEjecutivo.NavigateUrl = "mailto:" & strMail.Trim
                Me.HplkRazonSocial.Text = objSessionCliente.RazonSocial.Trim
                'Me.HplkRazonSocial.Text = objSessionCliente.RazonSocial.Trim
                'Me.HplkRazonSocial.NavigateUrl = "~/fichas/ficha_empresa.aspx?rutCliente=" & objSessionCliente.RutCliente
                If Session("ModCuentas") = "ModCuentas" Then
                    Me.HplkRazonSocial.NavigateUrl = "~/modulo_cuentas/ficha_empresa.aspx?rutCliente=" & objSessionCliente.RutCliente
                Else
                    Me.HplkRazonSocial.NavigateUrl = "~/fichas/ficha_empresa.aspx?rutCliente=" & objSessionCliente.RutCliente

                End If
                If Me.hdfMostrarTasa.Value = 1 Then
                    lblTitTasaAdmin.Visible = True
                    lblTasaAdmin.Visible = True
                    lblSignoPorcent.Visible = True
                    lblTasaAdmin.Text = lblTasaAdmin.Text.Trim
                Else
                    lblTitTasaAdmin.Visible = False
                    lblTasaAdmin.Visible = False
                    lblSignoPorcent.Visible = False
                End If
                End If
        End If
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        If objSession.EsCliente Then
            Me.btnPopUpEmpresa.Visible = False
            Me.btnCargar.Visible = False

        End If
        
    End Sub

    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Cargar(Session("RutCliente")) 'Me.txtRutEmpresa.Text.Trim)
    End Sub

End Class
