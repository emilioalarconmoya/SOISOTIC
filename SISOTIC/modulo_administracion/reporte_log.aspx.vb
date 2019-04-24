Imports Clases
Imports Modulos
Imports Clases.Web
Imports System.Data
Imports System.Globalization
Imports System.Threading
Partial Class modulo_cursos_reporte_log
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim dtLog As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim intTamPag As Integer = 50
            objWeb.SeteaGrilla(grdResultados, intTamPag)
            consultar()
        End If
    End Sub
    Public Sub consultar()
        Dim bfCampo As BoundField
       
        dtLog = Session("dt_log1")

        'Columna asistencia o avance
        bfCampo = CType(grdResultados.Columns(0), BoundField)
        bfCampo.DataField = "log"
        bfCampo.HeaderText = "Mensaje"

        'consulta y llenado grilla
        objWeb.LlenaGrilla(grdResultados, dtLog)
        'Session("otic.dtLog") = Nothing
        'If Not dtLog Is Nothing Then
        '    dtLog.Dispose()
        '    dtLog = Nothing
        'End If
    End Sub

    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Text = HttpUtility.HtmlDecode(e.Row.Cells(0).Text)
        End If
    End Sub
End Class
