Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data


Partial Class modulo_cursos_autorizacion_pago_solicitud
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CAutorizarSolicitudPagoTercero
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
        ViewState("nombreBenefactor") = Request("nombreBenefactor")
        ViewState("nombreBeneficiado") = Request("nombreBeneficiado")


        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            'objWeb.SeteaGrilla(grdResultados, TAM_PAG)
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
            Consultar()

        End If
    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CAutorizarSolicitudPagoTercero

            objReporte.RutUsuario = objSession.Rut
            objReporte.RutCliente = objSession.Rut
            'objReporte.Agno = objSession.Agno
            objReporte.CodCurso = ViewState("CodCurso")
            objReporte.RutBenefactor = ViewState("rutBenefactor")
            objReporte.RutBeneficiado = ViewState("rutCliente")
            objReporte.NombreBenefactor = ViewState("nombreBenefactor")
            objReporte.NombreBeneficiado = ViewState("nombreBeneficiado")


            'Dim dt As DataTable
            'dt = objReporte.Consultar2()
            'objWeb.LlenaGrilla(grdResultados, dt)
            'objWeb.LlenaGrilla(grdResultados2, dt)

        Catch ex As Exception
            EnviaError("modulo_cursos_autorizacion_pago_solicitud.aspx.vb:Consultar->" & ex.Message)
        End Try


    End Sub
    'Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
    '    'grdResultados.PageIndex = e.NewPageIndex
    '    Consultar()
    'End Sub
    'Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim lblDCfechaIngreso As Label
    '        lblDCfechaIngreso = CType(e.Row.FindControl("lblDCfechaIngreso"), Label)
    '        lblDCfechaIngreso.Text = FechaVbAUsr(lblDCfechaIngreso.Text)
    '        Dim lblDCfechaInicio As Label
    '        lblDCfechaInicio = CType(e.Row.FindControl("lblDCfechaInicio"), Label)
    '        lblDCfechaInicio.Text = FechaVbAUsr(lblDCfechaInicio.Text)
    '        Dim lblDCrutBeneficiado As Label
    '        lblDCrutBeneficiado = CType(e.Row.FindControl("lblDCrutBeneficiado"), Label)
    '        lblDCrutBeneficiado.Text = RutLngAUsr(lblDCrutBeneficiado.Text)
    '        Dim lblDCaporteSolicitado As Label
    '        lblDCaporteSolicitado = CType(e.Row.FindControl("lblDCaporteSolicitado"), Label)
    '        lblDCaporteSolicitado.Text = FormatoPeso(lblDCaporteSolicitado.Text)
    '    End If
    'End Sub
    'Protected Sub grdResultados2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados2.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim lblBErutBenefactor As Label
    '        lblBErutBenefactor = CType(e.Row.FindControl("lblBErutBenefactor"), Label)
    '        lblBErutBenefactor.Text = RutLngAUsr(lblBErutBenefactor.Text)
    '        Dim lblSAcuentaReparto As Label
    '        lblSAcuentaReparto = CType(e.Row.FindControl("lblSAcuentaReparto"), Label)
    '        lblSAcuentaReparto.Text = FormatoPeso(lblSAcuentaReparto.Text)
    '        Dim lblSAcuentaExcReparto As Label
    '        lblSAcuentaExcReparto = CType(e.Row.FindControl("lblSAcuentaExcReparto"), Label)
    '        lblSAcuentaExcReparto.Text = FormatoPeso(lblSAcuentaExcReparto.Text)
    '        Dim lblCPporcAdmin As Label
    '        lblCPporcAdmin = CType(e.Row.FindControl("lblCPporcAdmin"), Label)
    '        lblCPporcAdmin.Text = lblCPporcAdmin.Text * 100


    '    End If
    'End Sub

    Public Sub CalculaValorFinal()

        'Me.txtTotalMontoUsar.Text = Me.txtMontoUsarCuentaReparto.Text + Me.txtMontoUsarCuentaExcReparto.Text + Me.txtMontoUsarCuentaAdm.Text

    End Sub
    Public Sub Sumar()

        'Me.txtTotalMontoUsar.Text = Me.txtMontoUsarCuentaReparto.Text + Me.txtMontoUsarCuentaExcReparto.Text

    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    CalculaValorFinal()

    'End Sub

    Protected Sub Totalizar(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btn.NamingContainer, GridViewRow)
        Dim txtMontoUsarCuentaReparto As New TextBox
        txtMontoUsarCuentaReparto = CType(row.FindControl("txtMontoUsarCuentaReparto"), TextBox)



    End Sub
End Class
