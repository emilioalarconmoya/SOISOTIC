Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_listado_alumnos
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objAlumno As New CReporteAlumnos
    Dim objCurso As New CCursoContratado
    Dim objLookups As New Clookups

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
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If

        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"

        objWeb.SeteaGrilla(grdResultados, TAM_PAG)
        Consultar()

        'body.Attributes.Clear()
    End Sub

    Public Sub Consultar()
        Dim mobjSql As New CSql
        Dim lngRut As Long
        Dim strRut As String
        lngRut = objSession.Rut
        strRut = RutLngAUsr(lngRut)
        objCurso = New CCursoContratado
        objAlumno = New CReporteAlumnos
        Dim CodCurso As Long
        CodCurso = ViewState("CodCurso")
        'objCurso.CodCurso = CodCurso
        objCurso.Inicializar0(mobjSql, lngRut)
        objCurso.Inicializar1(CodCurso)
        hplCorrelativo.Text = objCurso.Correlativo
        hplCorrelativo.NavigateUrl = "ficha_curso_contratado.aspx?codCurso=" & CodCurso
        lblCorrrelativo.Text = objCurso.CorrEmpresa
        Dim NombreEstado As String
        If Trim(objCurso.CodEstadoCurso) = "0" Then
            NombreEstado = "Incompleto"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "1" Then
            NombreEstado = "Ingresado"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "2" Then
            NombreEstado = "Rechazado"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "3" Then
            NombreEstado = "Autorizado"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "4" Then
            NombreEstado = "Comunicado"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "5" Then
            NombreEstado = "Liquidado"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "6" Then
            NombreEstado = "Pago Por Autorizar"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "7" Then
            NombreEstado = "En Comunicación"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "8" Then
            NombreEstado = "Eliminado"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "9" Then
            NombreEstado = "En Liquidación"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "10" Then
            NombreEstado = "Anulado"
            lblEstadoActual.Text = NombreEstado
        ElseIf Trim(objCurso.CodEstadoCurso) = "11" Then
            NombreEstado = "Con Asistencia"
            lblEstadoActual.Text = NombreEstado
        End If
        lblFecha.Text = objCurso.FechaModificacion
        Dim Origen As String
        If objCurso.CodOrigen = 0 Then
            Origen = "Interno"
            lblOrigen.Text = Origen
        ElseIf objCurso.CodOrigen = 1 Then
            Origen = "Interno"
            lblOrigen.Text = Origen
        End If
        lblFechaIngreso.Text = objCurso.FechaIngreso
        lblNumSence.Text = objCurso.NroRegistro
        lblNumSenceComp.Text = "--"
        'objCurso.CalcularCostos()
        Dim dt As DataTable
        dt = objCurso.ConsultarListado
        objWeb.LlenaGrilla(grdResultados, dt)
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
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

            Dim lblFech As Label
            lblFech = CType(e.Row.FindControl("lblFechNac"), Label)
            lblFech.Text = FechaVbAUsr(lblFech.Text)

            Dim lbl As Label
            lbl = CType(e.Row.FindControl("lblCostoOtic"), Label)
            lbl.Text = FormatoPeso(lbl.Text)

            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblCostoEmp"), Label)
            lbl1.Text = FormatoPeso(lbl1.Text)

            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblViatico"), Label)
            lbl2.Text = FormatoPeso(lbl2.Text)

            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblTraslado"), Label)
            lbl3.Text = FormatoPeso(lbl3.Text)

            Dim lbl4 As Label
            lbl4 = CType(e.Row.FindControl("lblFranquicia"), Label)
            lbl4.Text = CLng(lbl4.Text)

            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("lblAsistencia"), Label)
            lbl5.Text = CLng(lbl5.Text)
        End If
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub
End Class
