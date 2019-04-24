
Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cuentas_reporte_alumnos
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As New CReporteAlumnos
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
            Me.calFechaFin.SelectedValue = "31/12/" & objSession.Agno
            'Consultar()

            

            'objWeb = New CWeb
            objWeb.ChequeaCliente(objSessionCliente)
            If Not objSessionCliente Is Nothing Then
                Consultar()
            End If
            
            body.Attributes.Clear()
            
        End If
        objWeb.ChequeaCliente(objSessionCliente)
    End Sub
    Private Sub Consultar()
        Try
            'Validaciones
            If Not IsDate(calFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio');")
                Exit Sub
            ElseIf Not EsFechaValidaVB(calFechaInicio.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            If Not IsDate(calFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de fin');")
                Exit Sub
            ElseIf Not EsFechaValidaVB(calFechaFin.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            Dim dias As Integer
            dias = DateDiff(DateInterval.Day, FechaUsrAVb(Me.calFechaInicio.SelectedValue), FechaUsrAVb(Me.calFechaFin.SelectedValue))
            If dias < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio valida');")
                Exit Sub
            End If
            objReporte.RutCliente = objSessionCliente.Rut 'objSession.Rut
            objReporte.InfoConsolidada = objSession.InfoConsolidada
            objReporte.NombreAlumno = Me.txtNombreAlumno.Text
            objReporte.RutAlumno = Me.txtRutAlumno.Text
            objReporte.FechaInicio = Me.calFechaInicio.SelectedValue
            objReporte.FechaFin = Me.calFechaFin.SelectedValue
            objReporte.BajarXml = ChkBajar.Checked
            objReporte.AlumnoInterno = chkAlumInterno.Checked
            objReporte.AlumnoSence = chkAlumSence.Checked
            objReporte.CursosAnulados = chkAnulados.Checked
            objReporte.CursoEliminados = chkEliminados.Checked
            Dim dt As DataTable
            Dim dr As DataRow
            dt = objReporte.Consultar()
            dt.Columns.Add("nombre_completo")
            For Each dr In dt.Rows
                dr("nombre_completo") = dr("nombre") + " " + dr("apellido_paterno") + " " + dr("apellido_materno")
            Next
            objWeb.LlenaGrilla(grdResultados, dt)
            If ChkBajar.Checked And objReporte.Filas > 0 Then
                HplkBajarArchivo.Target = "_Blank"
                HplkBajarArchivo.Text = "Descargar"
                HplkBajarArchivo.NavigateUrl = objReporte.ArchivoXml
                Me.HplkBajarArchivo.Visible = True



                HplkBajarArchivoCliente.Target = "_Blank"
                HplkBajarArchivoCliente.Text = "Reporte Cliente"
                HplkBajarArchivoCliente.NavigateUrl = objReporte.ArchivoXmlCliente
                Me.HplkBajarArchivoCliente.Visible = True
                If objSession.EsCliente Then
                    HplkBajarArchivoCliente.Visible = True
                    HplkBajarArchivo.Visible = False
                End If

            End If
        Catch ex As Exception
            EnviaError("reporte_alumnos.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Pager AndAlso Not grdResultados.DataSource Is Nothing Then
                'TRAE EL TOTAL DE PAGINAS
                Dim _TotalPags As Label = e.Row.FindControl("lblTotalNumberOfPages")
                _TotalPags.Text = grdResultados.PageCount.ToString

                'LLENA LA LISTA CON EL NUMERO DE PAGINAS
                Dim list As DropDownList = e.Row.FindControl("paginasDropDownList")
                For i As Integer = 1 To CInt(grdResultados.PageCount)
                    Dim it As ListItem
                    Dim Existe As Boolean = False
                    For Each it In list.Items
                        If it.Text = i.ToString Then
                            Existe = True
                        End If
                    Next
                    If Not Existe Then
                        list.Items.Add(i.ToString)
                    End If
                Next
                list.SelectedValue = grdResultados.PageIndex + 1
            End If

            If e.Row.RowType = DataControlRowType.DataRow Then


                Dim lblTip As Label
                lblTip = CType(e.Row.FindControl("lblTipoAlum"), Label)
                If lblTip.Text = "Interno" Then
                    Dim lblOtc As Label
                    lblOtc = CType(e.Row.FindControl("lblOt"), Label)
                    lblOtc.Visible = False
                    Dim lblDosPunOtc As Label
                    lblDosPunOtc = CType(e.Row.FindControl("lblDosPunOt"), Label)
                    lblDosPunOtc.Visible = False
                    Dim hplOtc As HyperLink
                    hplOtc = CType(e.Row.FindControl("hplkNombreOtec"), HyperLink)
                    hplOtc.Visible = False
                    Dim lblHor1 As Label
                    lblHor1 = CType(e.Row.FindControl("lblHor"), Label)
                    lblHor1.Visible = False
                    Dim lblDosPunHor As Label
                    lblDosPunHor = CType(e.Row.FindControl("lblDosPunH"), Label)
                    lblDosPunHor.Visible = False
                    Dim lblHor2 As Label
                    lblHor2 = CType(e.Row.FindControl("lblHoras"), Label)
                    lblHor2.Visible = False
                    Dim lblAcc1 As Label
                    lblAcc1 = CType(e.Row.FindControl("lblAcc"), Label)
                    lblAcc1.Visible = False
                    Dim lblDosPunAc As Label
                    lblDosPunAc = CType(e.Row.FindControl("lblDosPunAcc"), Label)
                    lblDosPunAc.Visible = False
                    Dim lblAcc2 As Label
                    lblAcc2 = CType(e.Row.FindControl("lblAccionSence"), Label)
                    lblAcc2.Visible = False
                    Dim lblAsis1 As Label
                    lblAsis1 = CType(e.Row.FindControl("lblAsis"), Label)
                    lblAsis1.Visible = False
                    Dim lblDosPunAs As Label
                    lblDosPunAs = CType(e.Row.FindControl("lblDosPunAsis"), Label)
                    lblDosPunAs.Visible = False
                    Dim lblAsis2 As Label
                    lblAsis2 = CType(e.Row.FindControl("lblAsistencia"), Label)
                    lblAsis2.Visible = False
                    Dim lblViat As Label
                    lblViat = CType(e.Row.FindControl("lblV"), Label)
                    lblViat.Text = "Costo curso"
                    Dim lblCost1 As Label
                    lblCost1 = CType(e.Row.FindControl("lblCost"), Label)
                    lblCost1.Visible = False
                    Dim lblDosPunC As Label
                    lblDosPunC = CType(e.Row.FindControl("lblDosPunCost"), Label)
                    lblDosPunC.Visible = False
                    Dim lblCost2 As Label
                    lblCost2 = CType(e.Row.FindControl("lblCostOtic"), Label)
                    lblCost2.Visible = False
                    Dim lblEmp1 As Label
                    lblEmp1 = CType(e.Row.FindControl("lblCostEmp"), Label)
                    lblEmp1.Visible = False
                    Dim lblDosPunE As Label
                    lblDosPunE = CType(e.Row.FindControl("lblDosPunEmp"), Label)
                    lblDosPunE.Visible = False
                    Dim lblEmp2 As Label
                    lblEmp2 = CType(e.Row.FindControl("lblCostoEmp"), Label)
                    lblEmp2.Visible = False
                    Dim lblT1 As Label
                    lblT1 = CType(e.Row.FindControl("lblT"), Label)
                    lblT1.Visible = False
                    Dim lblDosPunT As Label
                    lblDosPunT = CType(e.Row.FindControl("lblDosPunTras"), Label)
                    lblDosPunT.Visible = False
                    Dim lblT2 As Label
                    lblT2 = CType(e.Row.FindControl("lblTraslado"), Label)
                    lblT2.Visible = False
                    Dim lblTot1 As Label
                    lblTot1 = CType(e.Row.FindControl("lblTot"), Label)
                    lblTot1.Visible = False
                    Dim lblDosPunTt As Label
                    lblDosPunTt = CType(e.Row.FindControl("lblDosPunTot"), Label)
                    lblDosPunTt.Visible = False
                    Dim lblTot2 As Label
                    lblTot2 = CType(e.Row.FindControl("lblTotal"), Label)
                    lblTot2.Visible = False
                End If
                'HiperLink ficha alumno
                Dim hdf As HiddenField
                hdf = CType(e.Row.FindControl("hdfRutAlumno"), HiddenField)
                Dim lblT As Label
                lblT = CType(e.Row.FindControl("lblTipoAlum"), Label)
                Dim hpl As HyperLink
                hpl = CType(e.Row.FindControl("HyperLinkAlumno"), HyperLink)
                hpl.NavigateUrl = "ficha_alumno.aspx?rutAlumno=" & hdf.Value & "&tipo=" & lblT.Text
                'HyperLink ficha empresa
                Dim hdf1 As HiddenField
                hdf1 = CType(e.Row.FindControl("hdfRutCliente"), HiddenField)
                Dim hpl1 As HyperLink
                hpl1 = CType(e.Row.FindControl("hplkRazonSocial"), HyperLink)
                hpl1.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & hdf1.Value
                'HyperLink ficha otec
                Dim hdf2 As HiddenField
                hdf2 = CType(e.Row.FindControl("hdfRutOtec"), HiddenField)
                Dim hpl2 As HyperLink
                hpl2 = CType(e.Row.FindControl("hplkNombreOtec"), HyperLink)
                hpl2.NavigateUrl = "ficha_otec.aspx?rutOtec=" & hdf2.Value

                'HyperLink ficha cursoSence/Interno
                'HiddenField cursoSence
                Dim hdf3 As HiddenField
                hdf3 = CType(e.Row.FindControl("hdfCodigoSence"), HiddenField)
                'HiddenField cursoInterno
                Dim hdf4 As HiddenField
                hdf4 = CType(e.Row.FindControl("hdfCodCursoInterno"), HiddenField)
                Dim hpl3 As HyperLink
                hpl3 = CType(e.Row.FindControl("hplkNombreCurso"), HyperLink)
                If lblT.Text = "Sence" Then
                    hpl3.NavigateUrl = "ficha_curso_sence.aspx?codSence=" & hdf3.Value
                ElseIf lblT.Text = "Interno" Then
                    hpl3.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & hdf4.Value
                End If

                'HyperLink ficha cursoContratado/Interno
                'HiddenField cursoContratado
                Dim hdf5 As HiddenField
                hdf5 = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
                Dim hpl4 As HyperLink
                hpl4 = CType(e.Row.FindControl("hplkCorrelativo"), HyperLink)
                If lblT.Text = "Sence" Then
                    hpl4.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & hdf5.Value
                ElseIf lblT.Text = "Interno" Then
                    hpl4.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & hdf4.Value
                End If


                Dim lblRut As Label
                lblRut = CType(e.Row.FindControl("lblRutAlumno"), Label)
                lblRut.Text = RutLngAUsr(lblRut.Text)

                Dim lbl1 As Label
                lbl1 = CType(e.Row.FindControl("lblFechaIni"), Label)
                lbl1.Text = FechaVbAUsr(lbl1.Text)

                Dim lbl2 As Label
                lbl2 = CType(e.Row.FindControl("lblFechaFin"), Label)
                lbl2.Text = FechaVbAUsr(lbl2.Text)

                Dim lbl3 As Label
                lbl3 = CType(e.Row.FindControl("lblFecha"), Label)
                lbl3.Text = FechaVbAUsr(lbl3.Text)

                Dim lbl4 As Label
                lbl4 = CType(e.Row.FindControl("lblFranquicia"), Label)
                lbl4.Text = lbl4.Text * 100 & "%"

                Dim lbl5 As Label
                lbl5 = CType(e.Row.FindControl("lblAsistencia"), Label)
                lbl5.Text = lbl5.Text * 100 & "%"

                'Columna Montos
                Dim lblCOtic As Label
                lblCOtic = CType(e.Row.FindControl("lblCostOtic"), Label)
                lblCOtic.Text = FormatoPeso(lblCOtic.Text)

                Dim lblCEmp As Label
                lblCEmp = CType(e.Row.FindControl("lblCostoEmp"), Label)
                lblCEmp.Text = FormatoPeso(lblCEmp.Text)

                Dim lblCVia As Label
                lblCVia = CType(e.Row.FindControl("lblViatico"), Label)
                lblCVia.Text = FormatoPeso(lblCVia.Text)

                Dim lblCTras As Label
                lblCTras = CType(e.Row.FindControl("lblTraslado"), Label)
                lblCTras.Text = FormatoPeso(lblCTras.Text)

                Dim lblCTot As Label
                lblCTot = CType(e.Row.FindControl("lblTotal"), Label)
                lblCTot.Text = FormatoPeso(lblCTot.Text)

            End If

            If e.Row.RowType = DataControlRowType.Footer Then

                'Columna Footer de totales
                Dim lblTCOtic As Label
                lblTCOtic = CType(e.Row.FindControl("lblTotCosto"), Label)
                lblTCOtic.Text = FormatoPeso(objReporte.TotalOtic)

                Dim lblTCEmp As Label
                lblTCEmp = CType(e.Row.FindControl("lblTotGasto"), Label)
                lblTCEmp.Text = FormatoPeso(objReporte.TotalEmp)

                Dim lblCViat As Label
                lblCViat = CType(e.Row.FindControl("lblTotViatico"), Label)
                lblCViat.Text = FormatoPeso(objReporte.TotalViat)

                Dim lblCTras As Label
                lblCTras = CType(e.Row.FindControl("lblTotTraslado"), Label)
                lblCTras.Text = FormatoPeso(objReporte.TotalTras)

                Dim lblCTotales As Label
                lblCTotales = CType(e.Row.FindControl("lblTotales"), Label)
                lblCTotales.Text = FormatoPeso(objReporte.Totales)

            End If
        Catch ex As Exception
            EnviaError("reporte_alumnos.aspx.vb:grdResultados_RowDataBound->" & ex.Message)
        End Try

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            grdResultados.PageIndex = e.NewPageIndex
            Consultar()
        End If
    End Sub

    Protected Sub ChkBajar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBajar.CheckedChanged

    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(Me.datos_personales1.FindControl("txtRutEmpresa"), TextBox).Text
    End Sub

    Protected Sub GoPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oIraPag As DropDownList = DirectCast(sender, DropDownList)
        Dim iNumPag As Integer = 0
        If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultados.PageCount Then
            If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultados.PageCount Then
                grdResultados.PageIndex = iNumPag - 1
            Else
                grdResultados.PageIndex = 0
            End If
        End If
        Call Consultar()
    End Sub
End Class
