Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_actualizar_sol_pagos_terceros
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As CAutorizarSolicitudPagoTercero
    Dim objCurso As CCursoContratado
    Dim objSolicitud As CSolicitud
    Dim objReporteSoli As CReporteSolicitudes
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
        ViewState("CtaRep") = Request("CtaRep")
        ViewState("rutBenefactor") = Request("rutBenefactor")
        ViewState("rutCliente") = Request("rutCliente")
        ViewState("CtaExcRep") = Request("CtaExcRep")
        ViewState("CtaAdm") = Request("CtaAdm")


        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            'objWeb.SeteaGrilla(grdResultados, TAM_PAG)
            'Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
            Consultar()



        End If
    End Sub
    Private Sub Consultar()
        Try
            objReporte = New CAutorizarSolicitudPagoTercero
            objCurso = New CCursoContratado
            objSolicitud = New CSolicitud
            objReporteSoli = New CReporteSolicitudes
            Dim blnAutExitosa As Boolean

            objReporte.RutUsuario = objSession.Rut
            objReporte.RutCliente = ViewState("rutCliente") 'ViewState("rutBenefactor")
            objReporte.CodCurso = ViewState("CodCurso")
            objReporte.RutBenefactor = ViewState("rutBenefactor")
            objReporte.RutBeneficiado = ViewState("rutCliente")
            objReporte.MontoCtaReparto = ViewState("CtaRep")
            objReporte.MontoCtaExcRep = ViewState("CtaExcRep")
            objReporte.MontoCtaAdm = ViewState("CtaAdm")
            objReporte.Consultar2()
            
            
            If objReporte.Autoriza = True Then
                lblAutoriza.Visible = True
            Else
                lblAutoriza.Visible = False
            End If

            If objReporte.Autoriza = False Then
                lblNoAutoriza.Visible = True
            Else
                lblNoAutoriza.Visible = False
            End If

        Catch ex As Exception
            EnviaError("modulo_cursos_actualizar_sol_pagos_terceros.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub


    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("pagos_terceros.aspx")
    End Sub
End Class
