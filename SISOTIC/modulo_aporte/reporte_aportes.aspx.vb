Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_aporte_reporte_aportes
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objLookUps As Clookups
    Dim objSesion As CSession
    Private mstrBusqueda As String
    Dim objReporte As CReporteAportes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSesion)
            objWeb = Nothing
            body.Attributes.Clear()
            Me.txtNumAporte.Attributes.Add("onFocus", "if (document.form1.rbCorrelativo1.checked == true ){document.form1.rbCorrelativo1.checked = false;document.form1.rbCorrelativo2.checked = true;};")
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                objWeb = New CWeb
                objLookUps = New Clookups
                ViewState("Origen") = Request("Origen")
                ViewState("Filtros") = Request("Filtros")
                objWeb.LlenaDDL(Me.ddlAgno, objLookUps.Agnos2, "Agno_v", "Agno_t")
                objWeb.LlenaDDL(Me.ddlAporte, objLookUps.Aporte, "aporte_v", "aporte_t")
                objWeb.AgregaValorDDL(Me.ddlAporte, "Todos", "4")
                ddlAgno.SelectedValue = objSesion.Agno
                ddlAporte.SelectedValue = 4
                objSesion.Agno = ddlAgno.SelectedValue

                Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_administracion/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
                objWeb.SeteaGrilla(grdResultados, 20)
                objWeb = Nothing
                objLookUps = Nothing
                Dim strOrigen As String
                strOrigen = ViewState("Origen")
                If strOrigen = "BuscarCursos" Then
                    Consultar2()
                End If
            End If
            'Consultar()

        Catch ex As Exception
            EnviaError("modulo_aporte_reporte_aportes:Page_Load->" & ex.Message)
        End Try
    End Sub

    Public Sub Consultar()
        Try
            objReporte = New CReporteAportes
            objWeb = New CWeb

            objReporte.CodCuenta = Me.ddlAporte.SelectedValue
            If ddlAporte.SelectedValue = 1 Then
                lblTipo.Text = "Por Cobrar"
            ElseIf ddlAporte.SelectedValue = 2 Then
                lblTipo.Text = "Cobrados"
            ElseIf ddlAporte.SelectedValue = 3 Then
                lblTipo.Text = "Anulados"
            End If

            If Me.txtRutEmpresa.Text = "" Then
                objReporte.RutCliente = 0
            Else
                objReporte.RutCliente = RutUsrALng(Me.txtRutEmpresa.Text)
            End If


            'If Me.rbCorrelativo1.Checked And Me.TxtNumAporte.Text = "" Then
            If Me.rbCorrelativo2.Checked Then
                If IsNumeric(Me.txtNumAporte.Text) Then
                    objReporte.Busqueda = mstrBusqueda & " and num_aporte = " & Me.txtNumAporte.Text & " "
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Nº Certificado debe contener un dato numerico.');")
                End If
            End If
            If Me.rbCorrelativo3.Checked Then
                If IsNumeric(Me.txtNumAporte.Text) Then
                    objReporte.Busqueda = mstrBusqueda & " and num_aporte > " & Me.txtNumAporte.Text & " "
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Nº Certificado debe contener un dato numerico.');")
                End If
            End If

            If Me.rbCorrelativo4.Checked Then
                If IsNumeric(Me.txtNumAporte.Text) Then
                    objReporte.Busqueda = mstrBusqueda & " and num_aporte < " & Me.txtNumAporte.Text & " "
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN:El campo debe Nº Certificado contener un dato numerico.');")
                End If
            End If

            If Me.rbCorrelativo5.Checked Then
                If IsNumeric(Me.txtNumAporte.Text) Then
                    objReporte.Busqueda = mstrBusqueda & " and num_aporte <> " & Me.txtNumAporte.Text & " "
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN:El campo debe Nº Certificado contener un dato numerico.');")
                End If
            End If

            

            objReporte.Agno = Me.ddlAgno.SelectedValue
            objReporte.BajarXml = Me.chkBajarReporte.Checked
            objReporte.BajarXmlTxt = Me.chkBajarReporteTxt.Checked
            objReporte.BajarXmlSence = Me.chkBajarSence.Checked
            If ViewState("Filtros") = Nothing Then
                objReporte.strWhere = ""
            Else
                objReporte.strWhere = ViewState("Filtros")
            End If


            Dim dt As DataTable

            dt = objReporte.ConsultarAportes()

            objWeb.LlenaGrilla(grdResultados, dt)


            Dim dtSence As DataTable

            dtSence = objReporte.CargaFormatoSence()

            If chkBajarReporte.Checked And objReporte.Filas > 0 Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporte.ArchivoXml
                hplBajarReporte.Visible = True
            End If

            'If chkBajarReporteTxt.Checked And objReporte.Filas > 0 Then
            '    hplBajarReporteTxt.Target = "_Blank"
            '    hplBajarReporteTxt.Text = "Botón Derecho: ""Guardar Destino Como..."" Puede abrirlo en Block de Notas"
            '    hplBajarReporteTxt.NavigateUrl = objReporte.ArchivoXmlTxt
            '    hplBajarReporteTxt.Visible = True
            'End If

            'If chkBajarSence.Checked And objReporte.Filas > 0 Then
            '    hplBajarReporteSence.Target = "_Blank"
            '    hplBajarReporteSence.Text = "Descargar archivo"
            '    hplBajarReporteSence.NavigateUrl = objReporte.ArchivoXmlSence
            '    hplBajarReporteSence.Visible = True
            'End If
        Catch ex As Exception
            EnviaError("modulo_aporte_reporte_aportes:Consultar->" & ex.Message)
        End Try

    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        If ViewState("Origen") = "BuscarCursos" Then
            Consultar2()
        Else
            Consultar()
        End If
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
                Dim hdfCodAporte As HiddenField
                hdfCodAporte = CType(e.Row.FindControl("hdfCodAporte"), HiddenField)
                Dim hdfRutCliente As HiddenField
                hdfRutCliente = CType(e.Row.FindControl("hdfRutCliente"), HiddenField)

                Dim hplNumAporte As HyperLink
                hplNumAporte = CType(e.Row.FindControl("hplNumAporte"), HyperLink)
                hplNumAporte.NavigateUrl = "ficha_aporte_ingresado.aspx?codAporte=" & hdfCodAporte.Value & "&rutCliente=" & hdfRutCliente.Value

                Dim hplRazonSocial As HyperLink
                hplRazonSocial = CType(e.Row.FindControl("hplRazonSocial"), HyperLink)
                hplRazonSocial.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & hdfRutCliente.Value

                Dim hplNombreCuenta As HyperLink
                hplNombreCuenta = CType(e.Row.FindControl("hplNombreCuenta"), HyperLink)


                Dim hdfCodEstado As HiddenField
                hdfCodEstado = CType(e.Row.FindControl("hdfCodEstado"), HiddenField)

                Dim lblAporte As Label
                lblAporte = CType(e.Row.FindControl("lblAporte"), Label)
                If lblAporte.Text = "" Then
                    lblAporte.Text = 0
                Else
                    lblAporte.Text = Replace(lblAporte.Text, "$", "")
                End If
                lblAporte.Text = FormatoPeso(lblAporte.Text)
                Dim lblFechaVencimineto As Label
                lblFechaVencimineto = CType(e.Row.FindControl("lblFechaVencimineto"), Label)
                If lblFechaVencimineto.Text = "" Then
                    lblFechaVencimineto.Text = "--"
                Else
                    lblFechaVencimineto.Text = FechaVbAUsr(lblFechaVencimineto.Text)
                End If


                Dim lblFechaIngreso As Label
                lblFechaIngreso = CType(e.Row.FindControl("lblFechaIngreso"), Label)
                If lblFechaIngreso.Text = "" Then
                    lblFechaIngreso.Text = "--"
                Else
                    lblFechaIngreso.Text = FechaVbAUsr(lblFechaIngreso.Text)
                End If

                Dim lblFechaCobro As Label
                lblFechaCobro = CType(e.Row.FindControl("lblFechaCobro"), Label)
                If lblFechaCobro.Text = "" Then
                    lblFechaCobro.Text = "--"
                Else
                    lblFechaCobro.Text = FechaVbAUsr(lblFechaCobro.Text)
                End If

                Dim hplModicficar As HyperLink
                hplModicficar = CType(e.Row.FindControl("hplModicficar"), HyperLink)
                hplModicficar.NavigateUrl = "ingreso_aporte.aspx?CodAporte=" & hdfCodAporte.Value

                Dim hplAnular As HyperLink
                hplAnular = CType(e.Row.FindControl("hplAnular"), HyperLink)
                hplAnular.NavigateUrl = "anular_aporte.aspx?CodAporte=" & hdfCodAporte.Value

                If ViewState("Origen") = "BuscarCursos" Then
                    If hdfCodEstado.Value = 3 Then
                        hplModicficar.Visible = False
                        hplAnular.Visible = False
                    End If
                Else
                    'If Me.ddlAporte.SelectedValue = 3 Then
                    '    hplModicficar.Visible = False
                    '    hplAnular.Visible = False
                    'End If
                    If hdfCodEstado.Value = 3 Then
                        hplModicficar.Visible = False
                        hplAnular.Visible = False
                    End If
                End If

            End If
        Catch ex As Exception
            EnviaError("modulo_aporte_reporte_aportes:grdResultados_RowDataBound->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Public Sub Consultar2()

        Try
            objReporte = New CReporteAportes
            objWeb = New CWeb
            objReporte.strWhere = ViewState("Filtros")
            Dim dt As DataTable

            dt = objReporte.ConsultarAportes2()
            Me.ddlAporte.SelectedValue = objReporte.CodEstado
            objWeb.LlenaGrilla(grdResultados, dt)
            objWeb.SeteaGrilla(grdResultados, 20)


            If chkBajarReporte.Checked And objReporte.Filas > 0 Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporte.ArchivoXml
                hplBajarReporte.Visible = True
            End If

            If chkBajarReporteTxt.Checked And objReporte.Filas > 0 Then
                hplBajarReporteTxt.Target = "_Blank"
                hplBajarReporteTxt.Text = "Descargar archivo"
                hplBajarReporteTxt.NavigateUrl = objReporte.ArchivoXmlTxt
                hplBajarReporteTxt.Visible = True
            End If

            If chkBajarSence.Checked And objReporte.Filas > 0 Then
                hplBajarReporteSence.Target = "_Blank"
                hplBajarReporteSence.Text = "Descargar archivo"
                hplBajarReporteSence.NavigateUrl = objReporte.ArchivoXmlSence
                hplBajarReporteSence.Visible = True
            End If
        Catch ex As Exception
            EnviaError("modulo_aporte_reporte_aportes:Consultar2->" & ex.Message)
        End Try
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
