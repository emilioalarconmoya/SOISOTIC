Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_buscador_curso_sence
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorCursos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '***********************************************************************************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            '***********************************************************************************
            If Not Page.IsPostBack Then
                objWeb = New CWeb
                objWeb.SeteaGrilla(Me.grdCursosSence, TAM_PAG)
                objWeb = Nothing
                campo_padre.Value = Request("campo")
            End If
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_curso_sence.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_curso_sence.aspx.vb:btnConsultar_Click-->" & ex.Message)
        End Try
    End Sub
    Private Sub consultar()
        Try
            If Me.txtCodSence.Text.Trim = "" And Me.txtNomCurso.Text.Trim = "" And Me.txtOtec.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar almenos uno de los filtros.');")
                Exit Sub
            End If
            If Me.txtNomCurso.Text.Trim <> "" And Me.txtNomCurso.Text.Trim.Length <= 2 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el nombre de curso a buscar');")
                Exit Sub
            End If
            If Me.txtOtec.Text.Trim <> "" And Me.txtOtec.Text.Trim.Length <= 2 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el nombre Otec a buscar');")
                Exit Sub
            End If
            objMantenedor = New CMantenedorCursos
            objMantenedor.inicializarPopUpCursosSence()
            objMantenedor.CursosSenceCodCurso = Me.txtCodSence.Text.Trim
            objMantenedor.CursosSenceNombreCurso = Me.txtNomCurso.Text.Trim
            objMantenedor.CursosSenceOtec = Me.txtOtec.Text.Trim
            objMantenedor.ConsultarCursosSence()

            Dim bf As BoundField
            bf = CType(Me.grdCursosSence.Columns(1), BoundField)
            bf.DataField = "nombre_curso"

            bf = CType(Me.grdCursosSence.Columns(2), BoundField)
            bf.DataField = "horas"

            bf = CType(Me.grdCursosSence.Columns(3), BoundField)
            bf.DataField = "otec"
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdCursosSence, objMantenedor.CursosSenceListado)
            objWeb = Nothing
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:consultar-->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdCursosSence_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCursosSence.PageIndexChanging
        Try
            grdCursosSence.PageIndex = e.NewPageIndex
            consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:grdEmpresas_PageIndexChanging-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdCursosSence_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCursosSence.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hpl As New HyperLink
            hpl = CType(e.Row.FindControl("hplCodSence"), HyperLink)
            hpl.Attributes.Add("onclick", "Cerrar('" & hpl.Text & "');")
        End If
    End Sub
End Class
