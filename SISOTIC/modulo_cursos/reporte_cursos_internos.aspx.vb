Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_reporte_cursos_internos
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objReporte As New CReporteCursoInterno
    Dim curso As New CCursoInterno
    Dim objLookups As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '*********************************** 
        If Not Page.IsPostBack Then
            
            lblPie.Text = Parametros.p_PIE
            ViewState("RutCliente") = RutUsrALng(Me.txtRutEmpresa.Text)
            ViewState("Agno") = Request("agno")
            ViewState("Correlativo") = objReporte.Correlativo
            ViewState("CodEstadoCurso") = objReporte.CodEstadoCurso
            Dim lngRut As Long
            lngRut = objSession.Rut
            objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
            ddlAgnos.SelectedValue = objSession.Agno
            objWeb.SeteaGrilla(GridResultados, TAM_PAG)
        End If
    End Sub
    Private Sub Consultar()
        Try
            
            objReporte.RutCliente = ViewState("RutCliente") Or RutUsrALng(Me.txtRutEmpresa.Text)
            'objReporte.RutCliente = ViewState("RutCliente")
            objReporte.Agno = ddlAgnos.SelectedValue
            objReporte.BajarXml = chkBajarReporte.Checked
            ViewState("Correlativo") = objReporte.Correlativo
            
            objWeb = New CWeb
            Dim dt As DataTable
            dt = objReporte.Consultar()
            objWeb.LlenaGrilla(GridResultados, dt)
            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporte.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If
            
        Catch ex As Exception
            EnviaError("modulo_cursos_reporte_cursos_internos.aspx.vb:Consultar->" & ex.Message)
        End Try
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

                Dim hpl As HyperLink
                hpl = CType(e.Row.FindControl("hplCorrelativo"), HyperLink)
                hpl.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & hpl.Text & "&Agno=" & Me.ddlAgnos.SelectedValue

                Dim lblValor As Label
                lblValor = CType(e.Row.FindControl("lblValorCurso"), Label)
                If lblValor.Text = "" Then
                    lblValor.Text = 0
                Else
                    lblValor.Text = Replace(lblValor.Text, "$", "")
                End If
                lblValor.Text = FormatoPeso(lblValor.Text)

                Dim hplCorrelativo As HyperLink
                hplCorrelativo = CType(e.Row.FindControl("hplCorrelativo"), HyperLink)

                Dim lblEstado As Label
                lblEstado = CType(e.Row.FindControl("lblEstado"), Label)

                Dim hplModificar As HyperLink
                hplModificar = CType(e.Row.FindControl("hplModificar"), HyperLink)

                Dim hplCambiarAIngresado As HyperLink
                hplCambiarAIngresado = CType(e.Row.FindControl("hplCambiarAIngresado"), HyperLink)

                Dim lknbtnCambiarAIngresado As LinkButton
                lknbtnCambiarAIngresado = CType(e.Row.FindControl("lknbtnCambiarAIngresado"), LinkButton)

                Dim lnkbtnAnular As LinkButton
                lnkbtnAnular = CType(e.Row.FindControl("lnkbtnAnular"), LinkButton)

                Dim hdfCodEstado As HiddenField
                hdfCodEstado = CType(e.Row.FindControl("hdfCodEstadoCurso"), HiddenField)

                Dim btnModificar As Button
                btnModificar = CType(e.Row.FindControl("btnModificar"), Button)
                Dim btnAnular As Button
                btnAnular = CType(e.Row.FindControl("btnAnular"), Button)
                Dim btncambiarAIngresado As Button
                btncambiarAIngresado = CType(e.Row.FindControl("btncambiarAIngresado"), Button)

                Select Case hdfCodEstado.Value
                    Case 1
                        btnModificar.Visible = True
                        btnAnular.Visible = True
                        btncambiarAIngresado.Visible = False
                    Case 2
                        btnModificar.Visible = False
                        btnAnular.Visible = False
                        btncambiarAIngresado.Visible = True
                End Select

                btnAnular.Attributes.Add("onclick", "return confirm('¿Está seguro de realizar esta operación?');")  '    OnClientClick=("onclick", "return confirm('¿Seguro de realizar operacion?');") 

                btncambiarAIngresado.Attributes.Add("onclick", "return confirm('¿Está seguro de realizar esta operación?');")  '    OnClientClick=("onclick", "return confirm('¿Seguro de realizar operacion?');") 

            End If
        Catch ex As Exception
            EnviaError("modulo_cursos_reporte_cursos_internos.aspx.vb:GridResultados_RowDataBound->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnModificar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnModificar.NamingContainer, GridViewRow)
        Dim hpl As HyperLink
        hpl = CType(row.FindControl("hplCorrelativo"), HyperLink)
        Response.Redirect("mantenedor_cursos_internos.aspx?Correlativo=" & hpl.Text & "&Agno=" & objSession.Agno)

    End Sub

    Protected Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        curso = New CCursoInterno

        Dim btnAnular As Button = CType(sender, Button) 'Obtengo el DropDownList que ha invocado al método
        Dim row As GridViewRow = CType(btnAnular.NamingContainer, GridViewRow) 'Obtengo la fila que contiene el DropDownList que ha invocado al método
        Dim hdfEstadoCurso As HiddenField
        hdfEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Dim hplCorrelativo As HyperLink
        hplCorrelativo = CType(row.FindControl("hplCorrelativo"), HyperLink)
        Dim lblEstado As Label
        lblEstado = CType(row.FindControl("lblEstado"), Label)
        Dim hplModificar As HyperLink
        hplModificar = CType(row.FindControl("hplModificar"), HyperLink)
        Dim lknbtnCambiarAIngresado As LinkButton
        lknbtnCambiarAIngresado = CType(row.FindControl("lknbtnCambiarAIngresado"), LinkButton)
        Dim hdfRutCliente As HiddenField
        hdfRutCliente = CType(row.FindControl("hdfRutCliente"), HiddenField)

        curso.Correlativo = hplCorrelativo.Text
        curso.RutCliente = hdfRutCliente.Value
        curso.RurUsuario = objSession.Rut
        curso.Correlativo = hplCorrelativo.Text
        curso.CodEstadoCurso = hdfEstadoCurso.Value
        curso.Agno = objSession.Agno
        If hdfEstadoCurso.Value = 1 Then
            curso.CambiaEstadoAnulado()
        Else
            curso.CambiaEstadoIngresado()
        End If

        Consultar()
    End Sub

    Protected Sub btncambiarAIngresado_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'body.Attributes.Add("onload", "alert('ATENCIÓN: Este alumno ya ha sido ingresado anteriormente');")
        curso = New CCursoInterno

        Dim btncambiarAIngresado As Button = CType(sender, Button) 'Obtengo el DropDownList que ha invocado al método
        Dim row As GridViewRow = CType(btncambiarAIngresado.NamingContainer, GridViewRow) 'Obtengo la fila que contiene el DropDownList que ha invocado al método
        Dim hdfEstadoCurso As HiddenField
        hdfEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Dim hplCorrelativo As HyperLink
        hplCorrelativo = CType(row.FindControl("hplCorrelativo"), HyperLink)
        Dim lblEstado As Label
        lblEstado = CType(row.FindControl("lblEstado"), Label)
        Dim hplModificar As HyperLink
        hplModificar = CType(row.FindControl("hplModificar"), HyperLink)
        Dim lknbtnCambiarAIngresado As LinkButton
        lknbtnCambiarAIngresado = CType(row.FindControl("lknbtnCambiarAIngresado"), LinkButton)
        Dim hdfRutCliente As HiddenField
        hdfRutCliente = CType(row.FindControl("hdfRutCliente"), HiddenField)


        curso.Correlativo = hplCorrelativo.Text
        curso.RutCliente = hdfRutCliente.Value
        curso.RurUsuario = objSession.Rut
        curso.Agno = ddlAgnos.SelectedValue
        If hdfEstadoCurso.Value = 1 Then
            curso.CambiaEstadoAnulado()
        Else
            curso.CambiaEstadoIngresado()
        End If

        Consultar()
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
End Class
