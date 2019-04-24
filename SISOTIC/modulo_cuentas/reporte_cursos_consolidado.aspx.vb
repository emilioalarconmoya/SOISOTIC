Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_reporte_cursos_consolidado
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As New CReporteCursos
    Dim objLookups As New Clookups
    Private objSessionCliente As CSession

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
        If Not Page.IsPostBack Then
            If objSession.EsClienteIngresoCurso Then
                Me.hplIngresoCurso.Visible = True
            End If
            lblPie.Text = Parametros.p_PIE
            objWeb.SeteaGrilla(GridResultados, TAM_PAG)
            Me.calFechaInicial.SelectedValue = "01/01/" & objSession.Agno
            Me.calFechaFinal.SelectedValue = "31/12/" & objSession.Agno

            objWeb = New CWeb
            objWeb.ChequeaCliente(objSessionCliente)
            If Not objSessionCliente Is Nothing Then
                Consultar()
                'If objSession.EsCliente Then
                '    Me.GridResultados.Columns.Item(4).Visible = False
                'End If

            End If
        End If

        objWeb = New CWeb
        objWeb.ChequeaCliente(objSessionCliente)

        body.Attributes.Clear()
    End Sub
    Private Sub Consultar()
        Try
            
            If Not IsDate(calFechaInicial.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio');")
                Exit Sub
            ElseIf Not EsFechaValidaVB(calFechaInicial.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            If Not IsDate(calFechaFinal.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de fin');")
                Exit Sub
            ElseIf Not EsFechaValidaVB(calFechaFinal.SelectedValue) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha válida');")
                Exit Sub
            End If
            Dim dias As Integer
            dias = DateDiff(DateInterval.Day, FechaUsrAVb(Me.calFechaInicial.SelectedValue), FechaUsrAVb(Me.calFechaFinal.SelectedValue))
            If dias < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una fecha de inicio valida');")
                Exit Sub
            End If
            Dim estados As String
            estados = "1,3,4,5,6,7,9,11"
            objReporte.RutCliente = objSessionCliente.Rut ' objSession.Rut
            objReporte.InfoConsolidada = objSession.InfoConsolidada
            objReporte.Estados = estados
            objReporte.FechaInicio = FechaUsrAVb(Me.calFechaInicial.SelectedValue)
            objReporte.FechaFin = FechaUsrAVb(Me.calFechaFinal.SelectedValue)
            objReporte.CursoInterno = chkCursoInterno.Checked
            objReporte.CursoSence = chkCursoSence.Checked
            objReporte.CursosAnulados = chkAnulados.Checked
            objReporte.CursoEliminados = chkEliminados.Checked
            objReporte.BajarXml = ChkBajar.Checked
            Dim dt As DataTable
            dt = objReporte.Consultar()
            'If Not dt Is Nothing Then
            objWeb.LlenaGrilla(GridResultados, dt)
            'End If
            If ChkBajar.Checked And objReporte.Filas > 0 Then
                HplkBajarArchivo.Target = "_Blank"
                HplkBajarArchivo.Text = "Descargar"
                HplkBajarArchivo.NavigateUrl = objReporte.ArchivoXml
                Me.HplkBajarArchivo.Visible = True

                lblSeparacion.Visible = true

                HplkBajarArchivoCliente.Target = "_Blank"
                HplkBajarArchivoCliente.Text = "Reporte Cliente"
                HplkBajarArchivoCliente.NavigateUrl = objReporte.ArchivoXmlCliente
                Me.HplkBajarArchivoCliente.Visible = True

                If objSession.EsCliente Then
                    HplkBajarArchivoCliente.Visible = True
                    HplkBajarArchivo.Visible = False
                    lblSeparacion.Visible = False
                End If


            End If
        Catch ex As Exception
            EnviaError("reporte_cursos_consolidado.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Consultar()

    End Sub


    Protected Sub GridResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridResultados.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            GridResultados.PageIndex = e.NewPageIndex
            Consultar()
        End If

    End Sub

    Protected Sub GridResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Pager AndAlso Not GridResultados.DataSource Is Nothing Then
                'TRAE EL TOTAL DE PAGINAS
                Dim _TotalPags As Label = e.Row.FindControl("lblTotalNumberOfPages")
                _TotalPags.Text = GridResultados.PageCount.ToString

                'LLENA LA LISTA CON EL NUMERO DE PAGINAS
                Dim list As DropDownList = e.Row.FindControl("paginasDropDownList")
                For i As Integer = 1 To CInt(GridResultados.PageCount)
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
                list.SelectedValue = GridResultados.PageIndex + 1
            End If

            If e.Row.RowType = DataControlRowType.DataRow Then
                'HiperLink ficha curso contratado
                Dim hdfAgno As HiddenField
                hdfAgno = CType(e.Row.FindControl("hdfAgno"), HiddenField)
                Dim hdf As HiddenField
                hdf = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
                Dim hpl As HyperLink
                hpl = CType(e.Row.FindControl("HplkCorrelativo"), HyperLink)
                Dim lblTipo As Label
                lblTipo = CType(e.Row.FindControl("lblTipoCurso"), Label)
                If lblTipo.Text = "Interno" Then
                    hpl.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & hdf.Value & "&Agno=" & hdfAgno.Value
                ElseIf lblTipo.Text = "Sence" Then
                    hpl.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & hdf.Value
                End If
                Dim intTipo As Integer
                If lblTipo.Text = "Interno" Then
                    intTipo = 0
                ElseIf lblTipo.Text = "Sence" Then
                    intTipo = 1
                End If
                Dim hdfEstadoCurso As HiddenField
                hdfEstadoCurso = CType(e.Row.FindControl("hdfEstadoCurso"), HiddenField)
                Dim hplEstado As HyperLink
                hplEstado = CType(e.Row.FindControl("hplEstado"), HyperLink)
                hplEstado.NavigateUrl = "reporte_bitacoras.aspx?codCurso=" & hdf.Value & "&tipo=" & intTipo & "&estado=" & hdfEstadoCurso.Value
                'HiperLink ficha curso sence/Interno
                Dim hdf1 As HiddenField
                hdf1 = CType(e.Row.FindControl("hdfCodSence"), HiddenField)
                Dim hpl1 As HyperLink
                hpl1 = CType(e.Row.FindControl("HplkCurso"), HyperLink)
                
                If lblTipo.Text = "Interno" Then
                    hpl1.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & hdf.Value & "&Agno=" & hdfAgno.Value
                ElseIf lblTipo.Text = "Sence" Then
                    hpl1.NavigateUrl = "ficha_curso_sence.aspx?codSence=" & hdf1.Value
                End If
                'HiperLink ficha otec
                Dim hdf2 As HiddenField
                hdf2 = CType(e.Row.FindControl("hdfRutOtec"), HiddenField)
                Dim hpl2 As HyperLink
                hpl2 = CType(e.Row.FindControl("HplkOtec"), HyperLink)
                hpl2.NavigateUrl = "ficha_otec.aspx?rutOtec=" & hdf2.Value
                'HiperLink listado alumnos
                Dim hdf3 As HiddenField
                hdf3 = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)
                Dim hpl3 As HyperLink
                hpl3 = CType(e.Row.FindControl("HplkAlumnos"), HyperLink)
                If lblTipo.Text = "Interno" Then
                    hpl3.NavigateUrl = "ficha_listado_alumnos_internos.aspx?codCurso=" & hdf3.Value
                ElseIf lblTipo.Text = "Sence" Then
                    hpl3.NavigateUrl = "ficha_listado_alumnos.aspx?codCurso=" & hdf3.Value
                End If

                'Formato de monto a los costos
                Dim lbl As Label
                lbl = CType(e.Row.FindControl("lblValorCurso"), Label)
                If lbl.Text = "" Then
                    lbl.Text = 0
                Else
                    lbl.Text = Replace(lbl.Text, "$", "")
                End If
                lbl.Text = FormatoPeso(lbl.Text)
                Dim lbl1 As Label
                lbl1 = CType(e.Row.FindControl("lblCostoOtic"), Label)
                If lbl1.Text = "" Then
                    lbl1.Text = 0
                Else
                    lbl1.Text = Replace(lbl1.Text, "$", "")
                End If
                lbl1.Text = FormatoPeso(lbl1.Text)
                Dim lbl2 As Label
                lbl2 = CType(e.Row.FindControl("lblGastoEmpresa"), Label)
                If lbl2.Text = "" Then
                    lbl2.Text = 0
                Else
                    lbl2.Text = Replace(lbl2.Text, "$", "")
                End If
                lbl2.Text = FormatoPeso(lbl2.Text)
                Dim lbl3 As Label
                lbl3 = CType(e.Row.FindControl("lblTotalVT"), Label)
                If lbl3.Text = "" Then
                    lbl3.Text = 0
                Else
                    lbl3.Text = Replace(lbl3.Text, "$", "")
                End If
                lbl3.Text = FormatoPeso(lbl3.Text)
                Dim lbl4 As Label
                lbl4 = CType(e.Row.FindControl("lblOticVT"), Label)
                If lbl4.Text = "" Then
                    lbl4.Text = 0
                Else
                    lbl4.Text = Replace(lbl4.Text, "$", "")
                End If
                lbl4.Text = FormatoPeso(lbl4.Text)
                Dim lbl5 As Label
                lbl5 = CType(e.Row.FindControl("lblEmpVT"), Label)
                If lbl5.Text = "" Then
                    lbl5.Text = 0
                Else
                    lbl5.Text = Replace(lbl5.Text, "$", "")
                End If
                lbl5.Text = FormatoPeso(lbl5.Text)
                Dim lbl6 As Label
                lbl6 = CType(e.Row.FindControl("lblCap"), Label)
                If lbl6.Text = "" Then
                    lbl6.Text = 0
                Else
                    lbl6.Text = Replace(lbl6.Text, "$", "")
                End If
                lbl6.Text = FormatoPeso(lbl6.Text)
                Dim lbl7 As Label
                lbl7 = CType(e.Row.FindControl("lblExcCap"), Label)
                If lbl7.Text = "" Then
                    lbl7.Text = 0
                Else
                    lbl7.Text = Replace(lbl7.Text, "$", "")
                End If
                lbl7.Text = FormatoPeso(lbl7.Text)
                'Dim lbl8 As Label
                'lbl8 = CType(e.Row.FindControl("lblCtaBecas"), Label)
                'If lbl8.Text = "" Then
                '    lbl8.Text = 0
                'Else
                '    lbl8.Text = Replace(lbl8.Text, "$", "")
                'End If
                'lbl8.Text = FormatoPeso(lbl8.Text)
                Dim lbl9 As Label
                lbl9 = CType(e.Row.FindControl("lblReparto"), Label)
                If lbl9.Text = "" Then
                    lbl9.Text = 0
                Else
                    lbl9.Text = Replace(lbl9.Text, "$", "")
                End If
                lbl9.Text = FormatoPeso(lbl9.Text)
                Dim lblExcreparto As Label
                lblExcreparto = CType(e.Row.FindControl("lblExcreparto"), Label)
                If lblExcreparto.Text = "" Then
                    lblExcreparto.Text = 0
                Else
                    lblExcreparto.Text = Replace(lblExcreparto.Text, "$", "")
                End If
                lblExcreparto.Text = FormatoPeso(lblExcreparto.Text)
                Dim lbl10 As Label
                lbl10 = CType(e.Row.FindControl("lblCtaAdmin"), Label)
                If lbl10.Text = "" Then
                    lbl10.Text = 0
                Else
                    lbl10.Text = Replace(lbl10.Text, "$", "")
                End If
                lbl10.Text = FormatoPeso(lbl10.Text)

                Dim lbl25 As Label
                lbl25 = CType(e.Row.FindControl("lblDataFactura"), Label)
                If lbl25.Text = 0 Then
                    lbl25.Visible = False
                    Dim lbl26 As Label
                    lbl26 = CType(e.Row.FindControl("lblsf"), Label)
                    If (lbl25.Visible = False) Then
                        lbl26.Visible = True
                        lbl26.Text = "s/f"
                    Else
                        lbl26.Visible = False
                    End If
                Else
                    lbl25.Visible = True
                End If

                Dim lblPorcAdmin As Label
                lblPorcAdmin = CType(e.Row.FindControl("lblPorcAdmin"), Label)
                If CDbl(lblPorcAdmin.Text) >= 0 And CDbl(lblPorcAdmin.Text) <= 1 Then
                    lblPorcAdmin.Text = (lblPorcAdmin.Text * 100)
                ElseIf CDbl(lblPorcAdmin.Text) > 1 And CDbl(lblPorcAdmin.Text) <= 100 Then
                    lblPorcAdmin.Text = lblPorcAdmin.Text
                End If

                Dim hdfCodEstadoCurso As HiddenField
                hdfCodEstadoCurso = CType(e.Row.FindControl("hdfCodEstadoCurso"), HiddenField)

                Dim lblRegistro As Label
                lblRegistro = CType(e.Row.FindControl("lblRegistro"), Label)
                Dim lblNroRegistro As Label
                lblNroRegistro = CType(e.Row.FindControl("lblNroRegistro"), Label)

                If lblNroRegistro.Text = "0" Then
                    lblNroRegistro.Text = "-"
                End If

                If lblTipo.Text = "Interno" Then

                    lblRegistro.Visible = False

                    lblNroRegistro.Visible = False
                    'Ocultando datos correspondientes a un curso sence
                    'Columna Curso y Otec
                    Dim lblOtec1 As Label
                    lblOtec1 = CType(e.Row.FindControl("lblOtec"), Label)
                    lblOtec1.Visible = False
                    Dim lblDsP1 As Label
                    lblDsP1 = CType(e.Row.FindControl("lblDosPnOtec"), Label)
                    lblDsP1.Visible = False
                    Dim hplOtec2 As HyperLink
                    hplOtec2 = CType(e.Row.FindControl("HplkOtec"), HyperLink)
                    hplOtec2.Visible = False

                    'Columna Costo
                    Dim lblOt1 As Label
                    lblOt1 = CType(e.Row.FindControl("Label17"), Label)
                    lblOt1.Visible = False
                    Dim lblDosPunO As Label
                    lblDosPunO = CType(e.Row.FindControl("lblDosPunOt"), Label)
                    lblDosPunO.Visible = False
                    Dim lblOt2 As Label
                    lblOt2 = CType(e.Row.FindControl("lblCostoOtic"), Label)
                    lblOt2.Visible = False
                    Dim lblEmp1 As Label
                    lblEmp1 = CType(e.Row.FindControl("Label18"), Label)
                    lblEmp1.Visible = False
                    Dim lblDosPunE As Label
                    lblDosPunE = CType(e.Row.FindControl("lblDosPunEmp"), Label)
                    lblDosPunE.Visible = False
                    Dim lblEmp2 As Label
                    lblEmp2 = CType(e.Row.FindControl("lblGastoEmpresa"), Label)
                    lblEmp2.Visible = False
                    Dim lblTotVyT1 As Label
                    lblTotVyT1 = CType(e.Row.FindControl("Label19"), Label)
                    'lblTotVyT1.Visible = False
                    Dim lblDosPunTv As Label
                    lblDosPunTv = CType(e.Row.FindControl("lblDosPunTot"), Label)
                    'lblDosPunTv.Visible = False
                    Dim lblTotVyT2 As Label
                    lblTotVyT2 = CType(e.Row.FindControl("lblTotalVT"), Label)
                    'lblTotVyT2.Visible = False
                    Dim lblOtiVyT1 As Label
                    lblOtiVyT1 = CType(e.Row.FindControl("Label20"), Label)
                    lblOtiVyT1.Visible = False
                    Dim lblDosPunOtiTv As Label
                    lblDosPunOtiTv = CType(e.Row.FindControl("lblDosPunOVyT"), Label)
                    lblDosPunOtiTv.Visible = False
                    Dim lblOtiVyT2 As Label
                    lblOtiVyT2 = CType(e.Row.FindControl("lblOticVT"), Label)
                    lblOtiVyT2.Visible = False
                    Dim lblEmpVyT1 As Label
                    lblEmpVyT1 = CType(e.Row.FindControl("Label21"), Label)
                    lblEmpVyT1.Visible = False
                    Dim lblDosPunEmpTv As Label
                    lblDosPunEmpTv = CType(e.Row.FindControl("lblDosPunEVyT"), Label)
                    lblDosPunEmpTv.Visible = False
                    Dim lblEmpVyT2 As Label
                    lblEmpVyT2 = CType(e.Row.FindControl("lblEmpVT"), Label)
                    lblEmpVyT2.Visible = False
                    'Columna Cargos del periodo
                    Dim lblCap1 As Label
                    lblCap1 = CType(e.Row.FindControl("Label28"), Label)
                    lblCap1.Visible = False
                    Dim lblDosPn1 As Label
                    lblDosPn1 = CType(e.Row.FindControl("lblDosP1"), Label)
                    lblDosPn1.Visible = False
                    Dim lblCap2 As Label
                    lblCap2 = CType(e.Row.FindControl("lblCap"), Label)
                    lblCap2.Visible = False
                    Dim lblExcCap1 As Label
                    lblExcCap1 = CType(e.Row.FindControl("Label29"), Label)
                    lblExcCap1.Visible = False
                    Dim lblDosPn2 As Label
                    lblDosPn2 = CType(e.Row.FindControl("lblDosP2"), Label)
                    lblDosPn2.Visible = False
                    Dim lblExcCap2 As Label
                    lblExcCap2 = CType(e.Row.FindControl("lblExcCap"), Label)
                    lblExcCap2.Visible = False
                    'Dim lblBecas1 As Label
                    'lblBecas1 = CType(e.Row.FindControl("Label30"), Label)
                    'lblBecas1.Visible = False
                    'Dim lblDosPn3 As Label
                    'lblDosPn3 = CType(e.Row.FindControl("lblDosP3"), Label)
                    'lblDosPn3.Visible = False
                    'Dim lblBecas2 As Label
                    'lblBecas2 = CType(e.Row.FindControl("lblCtaBecas"), Label)
                    'lblBecas2.Visible = False
                    Dim lblTer1 As Label
                    lblTer1 = CType(e.Row.FindControl("Label31"), Label)
                    lblTer1.Visible = False
                    Dim lblDosPn4 As Label
                    lblDosPn4 = CType(e.Row.FindControl("lblDosP4"), Label)
                    lblDosPn4.Visible = False
                    Dim Label26 As Label
                    Label26 = CType(e.Row.FindControl("Label26"), Label)
                    Label26.Visible = False
                    Dim Label27 As Label
                    Label27 = CType(e.Row.FindControl("Label27"), Label)
                    Label27.Visible = False
                    Dim Label31 As Label
                    Label31 = CType(e.Row.FindControl("Label31"), Label)
                    Label31.Visible = False
                    Dim lblDosP4 As Label
                    lblDosP4 = CType(e.Row.FindControl("lblDosP4"), Label)
                    lblDosP4.Visible = False
                    Dim Label32 As Label
                    Label32 = CType(e.Row.FindControl("Label32"), Label)
                    Label32.Visible = False
                    Dim Label33 As Label
                    Label33 = CType(e.Row.FindControl("Label33"), Label)
                    Label33.Visible = False
                    Dim Label34 As Label
                    Label34 = CType(e.Row.FindControl("Label34"), Label)
                    Label34.Visible = False
                    Dim Label35 As Label
                    Label35 = CType(e.Row.FindControl("Label35"), Label)
                    Label35.Visible = False
                    Dim Label40 As Label
                    Label40 = CType(e.Row.FindControl("Label40"), Label)
                    Label40.Visible = False
                    Dim Label41 As Label
                    Label41 = CType(e.Row.FindControl("Label41"), Label)
                    Label41.Visible = False
                    Dim lbl92 As Label
                    lbl92 = CType(e.Row.FindControl("lblReparto"), Label)
                    lbl92.Visible = False
                    Dim lblExcreparto2 As Label
                    lblExcreparto2 = CType(e.Row.FindControl("lblExcreparto"), Label)
                    lblExcreparto2.Visible = False
                    'Dim lblTer2 As Label
                    'lblTer2 = CType(e.Row.FindControl("lblTerceros"), Label)
                    'lblTer2.Visible = False
                    'Columna Administracion
                    Dim lblCapa1 As Label
                    lblCapa1 = CType(e.Row.FindControl("Label36"), Label)
                    lblCapa1.Visible = False
                    Dim lblDosPn5 As Label
                    lblDosPn5 = CType(e.Row.FindControl("lblDosP5"), Label)
                    lblDosPn5.Visible = False
                    Dim lblCapa2 As Label
                    lblCapa2 = CType(e.Row.FindControl("lblPorcAdmin"), Label)
                    lblCapa2.Visible = False
                    Dim lblPorc1 As Label
                    lblPorc1 = CType(e.Row.FindControl("lblPor1"), Label)
                    lblPorc1.Visible = False
                    Dim lblCapa3 As Label
                    lblCapa3 = CType(e.Row.FindControl("lblCtaAdmin"), Label)
                    lblCapa3.Visible = False

                    Dim lblExcCapa1 As Label
                    lblExcCapa1 = CType(e.Row.FindControl("Label37"), Label)
                    lblExcCapa1.Visible = False
                    Dim lblDosPn6 As Label
                    lblDosPn6 = CType(e.Row.FindControl("lblDosP6"), Label)
                    lblDosPn6.Visible = False
                    Dim lblExcCapa2 As Label
                    lblExcCapa2 = CType(e.Row.FindControl("lblPorcExc"), Label)
                    lblExcCapa2.Visible = False
                    Dim lblPorc2 As Label
                    lblPorc2 = CType(e.Row.FindControl("lblPor2"), Label)
                    lblPorc2.Visible = False
                    Dim lblPes1 As Label
                    lblPes1 = CType(e.Row.FindControl("lblPeso1"), Label)
                    lblPes1.Visible = False
                    Dim lblExcCapa3 As Label
                    lblExcCapa3 = CType(e.Row.FindControl("Label45"), Label)
                    lblExcCapa3.Visible = False

                    'Dim lblBec1 As Label
                    'lblBec1 = CType(e.Row.FindControl("Label38"), Label)
                    'lblBec1.Visible = False
                    'Dim lblDosPn7 As Label
                    'lblDosPn7 = CType(e.Row.FindControl("lblDosP7"), Label)
                    'lblDosPn7.Visible = False
                    'Dim lblBec2 As Label
                    'lblBec2 = CType(e.Row.FindControl("lblPorcBec"), Label)
                    'lblBec2.Visible = False
                    'Dim lblPorc3 As Label
                    'lblPorc3 = CType(e.Row.FindControl("lblPor3"), Label)
                    'lblPorc3.Visible = False
                    'Dim lblPes2 As Label
                    'lblPes2 = CType(e.Row.FindControl("lblPeso2"), Label)
                    'lblPes2.Visible = False
                    'Dim lblBec3 As Label
                    'lblBec3 = CType(e.Row.FindControl("Label46"), Label)
                    'lblBec3.Visible = False

                    Dim lblTerc1 As Label
                    lblTerc1 = CType(e.Row.FindControl("Label39"), Label)
                    lblTerc1.Visible = False
                    Dim lblDosPn8 As Label
                    lblDosPn8 = CType(e.Row.FindControl("lblDosP8"), Label)
                    lblDosPn8.Visible = False
                    Dim lblTerc2 As Label
                    lblTerc2 = CType(e.Row.FindControl("lblPorcTer"), Label)
                    lblTerc2.Visible = False
                    Dim lblPorc4 As Label
                    lblPorc4 = CType(e.Row.FindControl("lblPor4"), Label)
                    lblPorc4.Visible = False
                    Dim lblPes3 As Label
                    lblPes3 = CType(e.Row.FindControl("lblPeso3"), Label)
                    lblPes3.Visible = False
                    Dim lblTerc3 As Label
                    lblTerc3 = CType(e.Row.FindControl("Label47"), Label)
                    lblTerc3.Visible = False
                    Dim btnCerrarCurso As Button
                    btnCerrarCurso = CType(e.Row.FindControl("btnCerrarCurso"), Button)
                    Dim btnModificar As Button
                    btnModificar = CType(e.Row.FindControl("btnModificar"), Button)

                    If hdfCodEstadoCurso.Value = 1 Then
                        btnCerrarCurso.Visible = True
                        btnModificar.Visible = True
                    ElseIf hdfCodEstadoCurso.Value = 1 Then
                        btnCerrarCurso.Visible = False
                        btnModificar.Visible = False
                    End If


                End If

            End If

            If e.Row.RowType = DataControlRowType.Footer Then 'Si es el pie
                'Footer de la columna Costo
                Dim lblValor As Label
                lblValor = CType(e.Row.FindControl("lblTotalValor"), Label)
                lblValor.Text = FormatoPeso(objReporte.TotalValor)
                Dim lblOtic As Label
                lblOtic = CType(e.Row.FindControl("lblTotalOTIC"), Label)
                lblOtic.Text = FormatoPeso(objReporte.TotalOtic)
                Dim lblEmp As Label
                lblEmp = CType(e.Row.FindControl("lblTotalEmp"), Label)
                lblEmp.Text = FormatoPeso(objReporte.TotalEmpresa)
                Dim lblVyT As Label
                lblVyT = CType(e.Row.FindControl("lblTotalVyT"), Label)
                lblVyT.Text = FormatoPeso(objReporte.TotalVyT)
                Dim lblOticVyT As Label
                lblOticVyT = CType(e.Row.FindControl("lblTotalOticVyT"), Label)
                lblOticVyT.Text = FormatoPeso(objReporte.TotalOticVyT)
                Dim lblEmpVyT As Label
                lblEmpVyT = CType(e.Row.FindControl("lblTotalEmpVyT"), Label)
                lblEmpVyT.Text = FormatoPeso(objReporte.TotalEmpresaVyT)

                'Footer de la columna Cargos del Periodo
                Dim lblCap As Label
                lblCap = CType(e.Row.FindControl("lblCargoCap"), Label)
                lblCap.Text = FormatoPeso(objReporte.TotalCapacitacion)
                Dim lblExcCap As Label
                lblExcCap = CType(e.Row.FindControl("lblCargoExcCap"), Label)
                lblExcCap.Text = FormatoPeso(objReporte.TotalExcCapacitacion)
                'Dim lblBecas As Label
                'lblBecas = CType(e.Row.FindControl("lblCargoBecas"), Label)
                'lblBecas.Text = FormatoPeso(objReporte.TotalBecas)
                Dim lblTer As Label
                lblTer = CType(e.Row.FindControl("lblCargoTer"), Label)
                lblTer.Text = FormatoPeso(objReporte.TotalTerceros)

                'Footer de la columna Administración
                Dim lblACap As Label
                lblACap = CType(e.Row.FindControl("lblAdminCap"), Label)
                lblACap.Text = FormatoPeso(objReporte.TotalAdministracion)
                Dim lblAExcCap As Label
                lblAExcCap = CType(e.Row.FindControl("lblAdminExcCap"), Label)
                lblAExcCap.Text = "0"
                Dim lblATer As Label
                lblATer = CType(e.Row.FindControl("lblAdminTer"), Label)
                lblATer.Text = "0"
            End If
        Catch ex As Exception
            EnviaError("reporte_cursos_consolidado.aspx.vb:GridResultados_RowDataBound->" & ex.Message)
        End Try
        
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Session("RutCliente") = CType(Me.Cabecera1.FindControl("txtRutEmpresa"), TextBox).Text
    End Sub

    Protected Sub GoPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oIraPag As DropDownList = DirectCast(sender, DropDownList)
        Dim iNumPag As Integer = 0
        If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= GridResultados.PageCount Then
            If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= GridResultados.PageCount Then
                GridResultados.PageIndex = iNumPag - 1
            Else
                GridResultados.PageIndex = 0
            End If
        End If
        Call Consultar()
    End Sub

    
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnModificar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnModificar.NamingContainer, GridViewRow)
        Dim hdfCodCurso As HiddenField
        hdfCodCurso = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfAgno As HiddenField
        hdfAgno = CType(row.FindControl("hdfAgno"), HiddenField)
        Response.Redirect("mantenedor_cursos_internos.aspx?Correlativo=" & hdfCodCurso.Value & "&Agno=" & hdfAgno.Value)
    End Sub

    Protected Sub btnCerrarCurso_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnCerrarCurso As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnCerrarCurso.NamingContainer, GridViewRow)
        Dim hdfCodCurso As HiddenField
        hdfCodCurso = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfAgno As HiddenField
        hdfAgno = CType(row.FindControl("hdfAgno"), HiddenField)
        Dim objCursoInterno As New CCursoInterno
        Dim lblEstado As Label
        lblEstado = CType(row.FindControl("lblEstado"), Label)

        objCursoInterno.Correlativo = hdfCodCurso.Value
        objCursoInterno.Agno = hdfAgno.Value
        objCursoInterno.RurUsuario = objSession.Rut
        If objCursoInterno.ConsultarEstadoAlumnos Then
            objCursoInterno.CambiaEstadoCerrado()
            lblEstado.Text = "Cerrado"
            body.Attributes.Add("onload", "alert('ATENCIÓN: El curso ha sido cerrado');")
            Consultar()
            Exit Sub
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: El curso no pudo ser cerrado. Hay Participantes con el estado En Curso');")
            Exit Sub
        End If
    End Sub
End Class
