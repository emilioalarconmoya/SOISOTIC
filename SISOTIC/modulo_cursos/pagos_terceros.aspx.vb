Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_pagos_terceros
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CReporteSolicitudes
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
        If Not Page.IsPostBack Then
            
            lblPie.Text = Parametros.p_PIE
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            objWeb.SeteaGrilla(grdResultados, TAM_PAG, "No existen solicitudes para este cliente.")
            objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
            ddlAgnos.SelectedValue = objSession.Agno
            ViewState("CodCurso") = 1
            'Consultar()
        End If
        ViewState("CodCurso") = 0
    End Sub

    Private Sub Consultar()
        Try
            objReporte = New CReporteSolicitudes
            objReporte.RutCliente = RutUsrALng(Me.txtRutEmpresa.Text)
            objReporte.CodCurso = ViewState("CodCurso")
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = chkBajarReporte.Checked
            'objReporte.Agno = 2005

            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)

            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Botón Derecho: ""Guardar Destino Como..."" Puede abrirlo en EXCEL."
                hplBajarReporte.NavigateUrl = objReporte.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If

        Catch ex As Exception
            EnviaError("modulo_cursos_pagos_terceros.aspx.vb:Consultar->" & ex.Message)
        End Try


    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hdf1 As HiddenField
            hdf1 = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
            Dim hdf2 As HiddenField
            hdf2 = CType(e.Row.FindControl("hdfRutBenefactor"), HiddenField)
            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblRutBenefactor"), Label)
            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblRutBeneficiado"), Label)
            Dim lbl4 As Label
            lbl4 = CType(e.Row.FindControl("lblNomBenefactor"), Label)
            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("lblNomBeneficiado"), Label)
            'Dim hpl As HyperLink
            'hpl = CType(e.Row.FindControl("hplAceptar"), HyperLink)
            'hpl.NavigateUrl = "autorizar_pago_solicitud.aspx?codCurso=" & hdf1.Value & "&rutBenefactor=" & lbl2.Text & "&rutCliente=" & lbl3.Text & "&nombreBenefactor=" & lbl4.Text & "&nombreBeneficiado=" & lbl5.Text
            Dim hpl2 As Button
            hpl2 = CType(e.Row.FindControl("btnRechazar"), Button)
            'hpl2.NavigateUrl = "rechazar_pago_solicitud.aspx?codCurso=" & hdf1.Value & "&rutBenefactor=" & lbl2.Text & "&rutCliente=" & lbl3.Text

            Dim lblRutBeneficiado As Label
            lblRutBeneficiado = CType(e.Row.FindControl("lblRutBeneficiado"), Label)
            lblRutBeneficiado.Text = RutLngAUsr(lblRutBeneficiado.Text)
            Dim lblRutBenefactor As Label
            lblRutBenefactor = CType(e.Row.FindControl("lblRutBenefactor"), Label)
            lblRutBenefactor.Text = RutLngAUsr(lblRutBenefactor.Text)
            Dim lblFechaIngeso As Label
            lblFechaIngeso = CType(e.Row.FindControl("lblFechIngreso"), Label)
            lblFechaIngeso.Text = FechaVbAUsr(lblFechaIngeso.Text)
            Dim lblMonto As Label
            lblMonto = CType(e.Row.FindControl("lblAporte"), Label)
            lblMonto.Text = FormatoPeso(lblMonto.Text)
            Dim lblCostoOtic As Label
            lblCostoOtic = CType(e.Row.FindControl("lblCostoOtic"), Label)
            lblCostoOtic.Text = FormatoPeso(lblCostoOtic.Text)
            Dim lblFechaInicio As Label
            lblFechaInicio = CType(e.Row.FindControl("lblFechaInicio"), Label)
            lblFechaInicio.Text = FechaVbAUsr(lblFechaInicio.Text)
            hpl2.Attributes.Add("onclick", "return confirm('¿Está seguro de realizar esta operación?');")

        End If
    End Sub

    Protected Sub grdResultados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdResultados.SelectedIndexChanged

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTraerDatos.Click
        Consultar()

    End Sub

   
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnAceptar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnAceptar.NamingContainer, GridViewRow)
        Dim hdf1 As HiddenField
        hdf1 = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdf2 As HiddenField
        hdf2 = CType(row.FindControl("hdfRutBenefactor"), HiddenField)
        Dim lbl2 As Label
        lbl2 = CType(row.FindControl("lblRutBenefactor"), Label)
        lbl2.Text = RutUsrALng(lbl2.Text)
        Dim lbl3 As Label
        lbl3 = CType(row.FindControl("lblRutBeneficiado"), Label)
        lbl3.Text = RutUsrALng(lbl3.Text)
        Dim lbl4 As Label
        lbl4 = CType(row.FindControl("lblNomBenefactor"), Label)
        Dim lbl5 As Label
        lbl5 = CType(row.FindControl("lblNomBeneficiado"), Label)
       
        Response.Redirect("autorizar_pago_solicitud.aspx?codCurso=" & hdf1.Value & "&rutBenefactor=" & lbl2.Text & "&rutCliente=" & lbl3.Text & "&nombreBenefactor=" & lbl4.Text & "&nombreBeneficiado=" & lbl5.Text)
    End Sub

    Protected Sub btnRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim btnRechazar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnRechazar.NamingContainer, GridViewRow)
        Dim hdf1 As HiddenField
        hdf1 = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim lbl2 As Label
        lbl2 = CType(row.FindControl("lblRutBenefactor"), Label)
        lbl2.Text = RutUsrALng(lbl2.Text)
        Dim lbl3 As Label
        lbl3 = CType(row.FindControl("lblRutBeneficiado"), Label)
        lbl3.Text = RutUsrALng(lbl3.Text)
        Response.Redirect("rechazar_pago_solicitud.aspx?codCurso=" & hdf1.Value & "&rutBenefactor=" & lbl2.Text & "&rutCliente=" & lbl3.Text)
    End Sub
End Class
