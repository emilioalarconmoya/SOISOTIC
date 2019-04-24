Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_rechazar_pago_solicitud
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CRechazarSolicitudPagoTercero
    Dim objCurso As CCursoContratado
    Dim objSolicitud As CSolicitud
    Dim objReporteSoli As CReporteSolicitudes
    Dim objLookups As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '************************************
        ViewState("CodCurso") = Request("codCurso")
        ViewState("rutBenefactor") = Request("rutBenefactor")
        ViewState("rutCliente") = Request("rutCliente")
        

        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            'objWeb.SeteaGrilla(grdResultados, TAM_PAG)
            'Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
            Consultar()



        End If
    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CRechazarSolicitudPagoTercero
            objCurso = New CCursoContratado
            objSolicitud = New CSolicitud
            objReporteSoli = New CReporteSolicitudes
            Dim blnAutExitosa As Boolean

            objReporte.RutUsuario = objSession.Rut
            objReporte.RutCliente = objSession.Rut
            objReporte.CodCurso = ViewState("CodCurso")
            objReporte.RutBenefactor = ViewState("rutBenefactor")
            objReporte.RutBeneficiado = ViewState("rutCliente")
            objReporte.Consultar()

            If objReporte.Rechaza = True Then
                lblRechaza.Visible = True
            Else
                lblRechaza.Visible = False
            End If

            If objReporte.Rechaza = False Then
                lblNoRechaza.Visible = True
            Else
                lblNoRechaza.Visible = False
            End If

        Catch ex As Exception
            EnviaError("modulo_cursos_rechazar_pago_solicitud.aspx.vb:Consultar->" & ex.Message)
        End Try


    End Sub


    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("pagos_terceros.aspx")
    End Sub
End Class


