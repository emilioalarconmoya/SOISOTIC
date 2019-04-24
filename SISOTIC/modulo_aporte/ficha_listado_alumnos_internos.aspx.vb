Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_listado_alumnos_internos
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objAlumno As New CReporteAlumnos
    Dim objCurso As New CCursoInterno
    Dim objLookups As New Clookups
    Private objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        ViewState("CodCurso") = Request("codCurso")
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
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
            objWeb.ChequeaCliente(objSessionCliente)
            If Not objSessionCliente Is Nothing Then
                Consultar()
            End If
            body.Attributes.Clear()
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            objWeb.ChequeaCliente(objSessionCliente)
        End If

        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"



    End Sub

    Public Sub Consultar()
        Dim mobjSql As New CSql
        Dim Ano As Integer
        Ano = objSession.Agno
        Dim lngRut As Long
        Dim strRut As String
        lngRut = objSession.Rut
        strRut = RutLngAUsr(lngRut)
        objCurso = New CCursoInterno
        objAlumno = New CReporteAlumnos
        Dim CodCurso As Long
        CodCurso = ViewState("CodCurso")
        objCurso.CodCurso = CodCurso
        objCurso.Agno = Ano
        objCurso.Inicializar0(mobjSql, lngRut)
        objCurso.Inicializar1(CodCurso, Ano)
        hplCorrelativo.Text = objCurso.Correlativo
        hplCorrelativo.NavigateUrl = "ficha_curso_interno.aspx?codCurso=" & CodCurso
        lblCursoInterno.Text = objCurso.NombreCurso
        lblFechaInicio.Text = objCurso.FechaInicio
        lblFechaInicio.Text = FechaVbAUsr(lblFechaInicio.Text)
        lblFechaTermino.Text = objCurso.FechaTermino
        lblFechaTermino.Text = FechaVbAUsr(lblFechaTermino.Text)
        Dim dt As DataTable
        dt = objCurso.ConsultarListado
        objWeb.LlenaGrilla(grdResultados, dt)

    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            grdResultados.PageIndex = e.NewPageIndex
            Consultar()
        End If
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
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
            Dim hdf As HiddenField
            hdf = CType(e.Row.FindControl("hdfRutAlumno"), HiddenField)
            Dim hdfTip As HiddenField
            hdfTip = CType(e.Row.FindControl("hdfTipo"), HiddenField)
            Dim hpl As HyperLink
            hpl = CType(e.Row.FindControl("hplNomAlumno"), HyperLink)
            hpl.NavigateUrl = "ficha_alumno.aspx?rutAlumno=" & hdf.Value & "&tipo=" & hdfTip.Value

            Dim lblRut As Label
            lblRut = CType(e.Row.FindControl("lblRut"), Label)
            lblRut.Text = RutLngAUsr(lblRut.Text)

            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblFechNac"), Label)
            lbl1.Text = FechaVbAUsr(lbl1.Text)

            Dim lbl As Label
            lbl = CType(e.Row.FindControl("lblCosto"), Label)
            lbl.Text = FormatoPeso(lbl.Text)

            Dim lblViatico As Label
            lblViatico = CType(e.Row.FindControl("lblViatico"), Label)
            lblViatico.Text = FormatoPeso(lblViatico.Text)

            Dim lblTraslado As Label
            lblTraslado = CType(e.Row.FindControl("lblTraslado"), Label)
            lblTraslado.Text = FormatoPeso(lblTraslado.Text)

        End If
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
