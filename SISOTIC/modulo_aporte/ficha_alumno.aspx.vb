Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_alumno
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As New CReporteCursosAlumno
    Dim objAlumno As New CAlumno
    Dim objLookups As New Clookups
    Dim objSessionCliente As CSession

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        objWeb.ChequeaCliente(objSessionCliente)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '************************************

        ViewState("RutAlumno") = Request("rutAlumno")
        ViewState("TipoAlumno") = Request("tipo")
        If Not Page.IsPostBack Then
            If objSession.EsClienteIngresoCurso Then
                'Me.hplIngresoCurso.Visible = True
            End If
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
            lblPie.Text = Parametros.p_PIE
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If

        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        objWeb.SeteaGrilla(grdResultados, TAM_PAG)
        Consultar()
        CargaCabecera()

    End Sub

    Private Sub Consultar()
        Try
            objReporte = New CReporteCursosAlumno
            objReporte.RutAlumno = ViewState("RutAlumno")
            objReporte.RutEmpresa = objSessionCliente.Rut
            objReporte.Tipo = ViewState("TipoAlumno")
            lblTipo.Text = ViewState("TipoAlumno")

            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)
        Catch ex As Exception
            EnviaError("modulo_aporte/ficha_alumno.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub
    Public Sub CargaCabecera()
        Dim lngRut As Long
        Dim lngRutEmpresa As Long
        Dim strRut As String
        lngRut = ViewState("RutAlumno")
        strRut = RutLngAUsr(lngRut)
        objAlumno.Inicializar(strRut)
        Dim hpl1 As HyperLink
        hpl1 = hplNombreEmpleador
        hpl1.Text = objReporte.NombreEmpresa
        lblNombreAlumno.Text = objAlumno.NombreCompleto
        lblDataFechaNac.Text = objAlumno.FechaNacimiento
        If lblDataFechaNac.Text = "" Then
            lblDataFechaNac.Text = ""
        Else
            lblDataFechaNac.Text = FechaVbAUsr(lblDataFechaNac.Text)
        End If
        lblDataRut.Text = objReporte.RutAlumno
        lblDataRut.Text = RutLngAUsr(lblDataRut.Text)
        lblDataRutEmpleador.Text = objReporte.RutEmpresa
        lngRutEmpresa = objReporte.RutEmpresa
        hpl1.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & lngRutEmpresa
        lblDataRutEmpleador.Text = RutLngAUsr(lblDataRutEmpleador.Text)

    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub
    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hpl1 As HyperLink
            Dim hdf1 As HiddenField
            hdf1 = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
            hpl1 = CType(e.Row.FindControl("hplkCorrelativo"), HyperLink)
            If lblTipo.Text = "Interno" Then
                hpl1.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & hdf1.Value
            Else
                hpl1.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & hdf1.Value
            End If
           
            Dim hpl2 As HyperLink
            Dim hdf2 As HiddenField
            hdf2 = CType(e.Row.FindControl("hdfRutEmpresa"), HiddenField)
            hpl2 = CType(e.Row.FindControl("hplkRazonSocial"), HyperLink)
            hpl2.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & hdf2.Value

            Dim hpl3 As HyperLink
            Dim hdf3 As HiddenField
            hdf3 = CType(e.Row.FindControl("hdfCodSence"), HiddenField)
            hpl3 = CType(e.Row.FindControl("hplkNombreCurso"), HyperLink)
            If lblTipo.Text = "Interno" Then
                hpl3.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & hdf1.Value
            Else
                hpl3.NavigateUrl = "ficha_curso_sence.aspx?CodSence=" & hdf3.Value
            End If

            Dim hpl4 As HyperLink
            Dim hdf4 As HiddenField
            hdf4 = CType(e.Row.FindControl("hdfRutOtec"), HiddenField)
            hpl4 = CType(e.Row.FindControl("hplkNombreOtec"), HyperLink)
            hpl4.NavigateUrl = "ficha_otec.aspx?rutOtec=" & hdf4.Value

            If lblTipo.Text = "Interno" Then
                Dim lblOt As Label
                lblOt = CType(e.Row.FindControl("lblOt"), Label)
                lblOt.Visible = False

                Dim lblDsPun As Label
                lblDsPun = CType(e.Row.FindControl("lblDosPunOtec"), Label)
                lblDsPun.Visible = False

                Dim hplNomOt As HyperLink
                hplNomOt = CType(e.Row.FindControl("hplkNombreOtec"), HyperLink)
                hplNomOt.Visible = False

                Dim lblF As Label
                lblF = CType(e.Row.FindControl("lblFran"), Label)
                lblF.Visible = False

                Dim lblP As Label
                lblP = CType(e.Row.FindControl("lblDosPuntos1"), Label)
                lblP.Visible = False

                Dim lblFn As Label
                lblFn = CType(e.Row.FindControl("lblFranquicia"), Label)
                lblFn.Visible = False

                Dim lblPrc As Label
                lblPrc = CType(e.Row.FindControl("lblPorcentaje"), Label)
                lblPrc.Visible = False

                Dim lblAsist As Label
                lblAsist = CType(e.Row.FindControl("lblAsistencia"), Label)
                lblAsist.Visible = False

                Dim lbPasis As Label
                lbPasis = CType(e.Row.FindControl("lbPasis"), Label)
                lbPasis.Visible = False


                Dim lblCos As Label
                lblCos = CType(e.Row.FindControl("lblCost"), Label)
                lblCos.Visible = False

                Dim lblP1 As Label
                lblP1 = CType(e.Row.FindControl("lblDosPunOt"), Label)
                lblP1.Visible = False

                Dim lblCosR As Label
                lblCosR = CType(e.Row.FindControl("lblCostOtic"), Label)
                lblCosR.Visible = False

                Dim lblEmp As Label
                lblEmp = CType(e.Row.FindControl("lblCostEmp"), Label)
                lblEmp.Text = "Costo curso"

                'Dim lblP2 As Label
                'lblP2 = CType(e.Row.FindControl("lblDosPunEmp"), Label)
                'lblP2.Visible = False

                Dim lblVia As Label
                lblVia = CType(e.Row.FindControl("lblV"), Label)
                lblVia.Visible = False

                Dim lblP3 As Label
                lblP3 = CType(e.Row.FindControl("lblDosPunVia"), Label)
                lblP3.Visible = False

                Dim lblViaR As Label
                lblViaR = CType(e.Row.FindControl("lblViatico"), Label)
                lblViaR.Visible = False

                Dim lblTras As Label
                lblTras = CType(e.Row.FindControl("lblT"), Label)
                lblTras.Visible = False

                Dim lblP4 As Label
                lblP4 = CType(e.Row.FindControl("lblDosPunTra"), Label)
                lblP4.Visible = False

                Dim lblTrasR As Label
                lblTrasR = CType(e.Row.FindControl("lblTraslado"), Label)
                lblTrasR.Visible = False

                Dim lblT As Label
                lblT = CType(e.Row.FindControl("lblTot"), Label)
                lblT.Visible = False

                Dim lblP5 As Label
                lblP5 = CType(e.Row.FindControl("lblDosPunTot"), Label)
                lblP5.Visible = False

                Dim lblTR As Label
                lblTR = CType(e.Row.FindControl("lblTotal"), Label)
                lblTR.Visible = False

            End If



            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblFechaIni"), Label)
            lbl1.Text = FechaVbAUsr(lbl1.Text)

            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblFechaFin"), Label)
            lbl2.Text = FechaVbAUsr(lbl2.Text)

            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblCostOtic"), Label)
            lbl3.Text = FormatoPeso(lbl3.Text)

            Dim lbl4 As Label
            lbl4 = CType(e.Row.FindControl("lblCostoEmp"), Label)
            lbl4.Text = FormatoPeso(lbl4.Text)

            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("lblViatico"), Label)
            lbl5.Text = FormatoPeso(lbl5.Text)

            Dim lbl6 As Label
            lbl6 = CType(e.Row.FindControl("lblTraslado"), Label)
            lbl6.Text = FormatoPeso(lbl6.Text)

            Dim lbl7 As Label
            lbl7 = CType(e.Row.FindControl("lblTotal"), Label)
            lbl7.Text = FormatoPeso(lbl7.Text)

            Dim lbl8 As Label
            lbl8 = CType(e.Row.FindControl("lblNumEmp"), Label)
            If lbl8.Text = "" Then
                lbl8.Text = "S/N"
            End If
            'lbl8.Text = lbl8.Text

            Dim hpl As HyperLink
            hpl = CType(e.Row.FindControl("hplkNombreOtec"), HyperLink)
            If hpl.Text = "" Then
                hpl.Text = "S/O"
            End If
            'hpl.Text = hpl.Text

        End If
    End Sub
  
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("../modulo_cuentas/reporte_alumnos.aspx")
    End Sub

End Class
