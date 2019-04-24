Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_generacion_certificados_aporte
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As New CSession
    Dim objLookups As New Clookups
    Dim objCertificadoAporte As New CCertificadosAporte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("Agno") = Request("Agno")
                ViewState("RutEmpresa") = Request("RutEmpresa")
                ViewState("RazonSocial") = Request("RazonSocial")
                ViewState("filas") = Request("filas")
                'objWeb.LlenaDDL(Me.ddlAgno, objLookups.Agnos, "Agno_v", "Agno_t")
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                Me.lblTotalCertificados.Text = ViewState("filas")
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            'Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
            'Consultar()

        Catch ex As Exception
            EnviaError("listado_generacion_certificados_aporte:Page_Load-->" & ex.Message)

        End Try
    End Sub
    Public Sub Consultar()
        Try
            objCertificadoAporte = New CCertificadosAporte
            objCertificadoAporte.Agno = ViewState("Agno")
            objCertificadoAporte.Rut = ViewState("RutEmpresa")
            objCertificadoAporte.Consultar()
            'Dim lngTotal As Long
            Me.lblTotalCertificados.Text = objCertificadoAporte.Filas

        Catch ex As Exception
            EnviaError("listado_generacion_certificados_aporte:Consultar-->" & ex.Message)
        End Try
    End Sub
End Class
