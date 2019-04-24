Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_buscador_alumno
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorCursos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '***********************************************************************************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            '***********************************************************************************
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                campo_padre.Value = Request("campo")
                objweb.seteagrilla(grdAlumnos, tam_pag)
            End If
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_alumno.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        If Me.txtRutAlumno.Text.Trim = "" And Me.txtNombres.Text.Trim = "" And Me.txtApellid.Text.Trim = "" Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar almenos uno de los filtros.');")
            Exit Sub
        End If
        If Me.txtNombres.Text.Trim <> "" And Me.txtNombres.Text.Trim.Length <= 2 Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el nombre a buscar');")
            Exit Sub
        End If
        If Me.txtApellid.Text.Trim <> "" And Me.txtApellid.Text.Trim.Length <= 2 Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el apellido a buscar');")
            Exit Sub
        End If
        objMantenedor = New CMantenedorCursos
        objMantenedor.inicializarPopUpAlumnos()
        If Me.txtRutAlumno.Text.Trim = "" Then
            objMantenedor.AlumnosRut = gvalornumnulo
        Else
            objMantenedor.AlumnosRut = RutUsrALng(Me.txtRutAlumno.Text.Trim)
        End If
        objMantenedor.AlumnosNombres = Me.txtNombres.Text.Trim
        objMantenedor.AlumnosApellido = Me.txtApellid.Text.Trim
        objMantenedor.ConsultarAlumnos()

        Dim bf As BoundField
        bf = CType(Me.grdAlumnos.Columns(1), BoundField)
        bf.DataField = "nombres"

        bf = CType(Me.grdAlumnos.Columns(2), BoundField)
        bf.DataField = "apellido_paterno"

        bf = CType(Me.grdAlumnos.Columns(3), BoundField)
        bf.DataField = "apellido_materno"
        objWeb = New CWeb
        objWeb.LlenaGrilla(Me.grdAlumnos, objMantenedor.AlumnosListado)
        objWeb = Nothing
        objMantenedor = Nothing
    End Sub

    Protected Sub grdAlumnos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAlumnos.PageIndexChanging
        Try
            grdAlumnos.PageIndex = e.NewPageIndex
            Consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_alumno.aspx.vb:grdAlumnos_PageIndexChanging-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdAlumnos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAlumnos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hpl As New HyperLink
            hpl = CType(e.Row.FindControl("hplRutAlumno"), HyperLink)
            hpl.Attributes.Add("onclick", "Cerrar('" & hpl.Text & "');")
        End If
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
           
            Consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_curso_sence.aspx.vb:btnConsultar_Click-->" & ex.Message)
        End Try
    End Sub
End Class
