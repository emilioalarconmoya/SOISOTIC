Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_reporte_terceros
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objCliente As CCliente
    Dim objSql As CSql
    Dim objReporte As New CReporteTerceros
    Dim objLookups As New Clookups
    Private objSessionCliente As CSession
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
            If objSession.EsClienteIngresoCurso Then
                Me.hplIngresoCurso.Visible = True
            End If
            lblPie.Text = Parametros.p_PIE
            objWeb.SeteaGrilla(grdResultados, TAM_PAG)
            Me.calFechaInicio.SelectedValue = "01/01/" & objSession.Agno
            Me.CalFechaFin.SelectedValue = "31/12/" & objSession.Agno

        End If
        objWeb = New CWeb
        objWeb.ChequeaCliente(objSessionCliente)
        If Not objSessionCliente Is Nothing Then
            Consultar()
           
        End If
        body.Attributes.Clear()
    End Sub

    Private Sub Consultar()
        Try
            If Not IsDate(calFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio');")
                Exit Sub
            End If
            If Not EsFechaValidaVB(calFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            If Not IsDate(CalFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de fin');")
                Exit Sub
            End If
            If Not EsFechaValidaVB(CalFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            Dim dias As Integer
            dias = DateDiff(DateInterval.Day, FechaUsrAVb(Me.calFechaInicio.SelectedValue), FechaUsrAVb(Me.CalFechaFin.SelectedValue))
            If dias < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio valida');")
                Exit Sub
            End If
            Dim Estados As String
            Estados = "0,1,3,4,5,6,7,9,11"
            objReporte.RutBenefactor = objSessionCliente.Rut
            objReporte.Estados = Estados
            objReporte.InfoConsolidada = objSession.InfoConsolidada
            objReporte.FechaInicio = FechaUsrAVb(Me.calFechaInicio.SelectedValue)
            objReporte.FechaFin = FechaUsrAVb(Me.CalFechaFin.SelectedValue)
            objReporte.BajarXml = Me.ChkBajar.Checked
            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)
            If ChkBajar.Checked And objReporte.Filas > 0 Then
                HplkBajarArchivo.Target = "_Blank"
                HplkBajarArchivo.Text = "Descargar archivo"
                HplkBajarArchivo.NavigateUrl = objReporte.ArchivoXml
                HplkBajarArchivo.Visible = True
            End If
        Catch ex As Exception
            EnviaError("reporte_terceros.aspx.vb:Consultar->" & ex.Message)
        End Try

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            'HyperLink ficha empresa
            Dim hdf1 As HiddenField
            hdf1 = CType(e.Row.FindControl("hdfRutCliente"), HiddenField)
            Dim hpl1 As HyperLink
            hpl1 = CType(e.Row.FindControl("HyperLinkRazonSocial"), HyperLink)
            hpl1.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & hdf1.Value

            'HyperLink ficha otec
            Dim hdf2 As HiddenField
            hdf2 = CType(e.Row.FindControl("hdfRutOtec"), HiddenField)
            Dim hpl2 As HyperLink
            hpl2 = CType(e.Row.FindControl("HyperLinkOtec"), HyperLink)
            hpl2.NavigateUrl = "ficha_otec.aspx?rutOtec=" & hdf2.Value

            'HyperLink cursoSence
            Dim hdf3 As HiddenField
            hdf3 = CType(e.Row.FindControl("hdfCodSence"), HiddenField)
            Dim hpl3 As HyperLink
            hpl3 = CType(e.Row.FindControl("HyperLinkCurso"), HyperLink)
            hpl3.NavigateUrl = "ficha_curso_sence.aspx?codSence=" & hdf3.Value

            'HiperLink listado alumnos
            Dim hdf4 As HiddenField
            hdf4 = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
            Dim hpl4 As HyperLink
            hpl4 = CType(e.Row.FindControl("hplAlumnos"), HyperLink)
            hpl4.NavigateUrl = "ficha_listado_alumnos.aspx?codCurso=" & hdf4.Value

            'Hyperlink ficha curso
            Dim hpl5 As HyperLink
            hpl5 = CType(e.Row.FindControl("HyperLinkCorrelativo"), HyperLink)
            hpl5.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & hdf4.Value

            Dim lblR As Label
            lblR = CType(e.Row.FindControl("lblBindRut"), Label)
            lblR.Text = RutLngAUsr(lblR.Text)
            Dim lbl As Label
            lbl = CType(e.Row.FindControl("lblBindCosto"), Label)
            If lbl.Text = "" Then
                lbl.Text = 0
            End If
            lbl.Text = FormatoPeso(lbl.Text)
            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblBindOtic"), Label)
            If lbl1.Text = "" Then
                lbl1.Text = 0
            End If
            lbl1.Text = FormatoPeso(lbl1.Text)
            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblBindEmpresa"), Label)
            If lbl2.Text = "" Then
                lbl2.Text = 0
            End If
            lbl2.Text = FormatoPeso(lbl2.Text)
            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblBindReparto"), Label)
            If lbl3.Text = "" Then
                lbl3.Text = 0
            End If
            lbl3.Text = FormatoPeso(lbl3.Text)
            Dim lbl4 As Label
            lbl4 = CType(e.Row.FindControl("lblBindExcedente"), Label)
            If lbl4.Text = "" Then
                lbl4.Text = 0
            End If
            lbl4.Text = FormatoPeso(lbl4.Text)
            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("lblCostoAdmin"), Label)
            If lbl5.Text = "" Then
                lbl5.Text = 0
            End If
            lbl5.Text = FormatoPeso(lbl5.Text)
            Dim lbl6 As Label
            lbl6 = CType(e.Row.FindControl("lblBindBecas"), Label)
            If lbl6.Text = "" Then
                lbl6.Text = 0
            End If
            lbl6.Text = FormatoPeso(lbl6.Text)
            Dim lbl7 As Label
            lbl7 = CType(e.Row.FindControl("lblBindRep"), Label)
            If lbl7.Text = "" Then
                lbl7.Text = 0
            End If
            lbl7.Text = FormatoPeso(lbl7.Text)
            Dim lbl8 As Label
            lbl8 = CType(e.Row.FindControl("lblBindExcRep"), Label)
            If lbl8.Text = "" Then
                lbl8.Text = 0
            End If
            lbl8.Text = FormatoPeso(lbl8.Text)

        End If
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(datos_personales1.FindControl("txtRutEmpresa"), TextBox).Text
    End Sub
End Class
