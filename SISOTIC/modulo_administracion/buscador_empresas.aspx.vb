Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_buscador_empresas
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
                objWeb.SeteaGrilla(Me.grdEmpresas, TAM_PAG)
                objWeb = Nothing
                campo_padre.Value = Request("campo")
            End If
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:btnConsultar_Click-->" & ex.Message)
        End Try
    End Sub
    Private Sub consultar()
        Try
            If Me.txtRutEmpresa.Text.Trim = "" And Me.txtRazonSocial.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar almenos uno de los filtros.');")
                Exit Sub
            End If
            If Me.txtRazonSocial.Text.Trim <> "" And Me.txtRazonSocial.Text.Trim.Length <= 2 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el nombre de a buscar');")
                Exit Sub
            End If
           
            objMantenedor = New CMantenedorCursos
            objMantenedor.inicializarPopUpEmpresas()
            If txtRutEmpresa.Text.Trim <> "" Then
                objMantenedor.EmpresasRut = RutUsrALng(Me.txtRutEmpresa.Text.Trim)
            End If
            objMantenedor.EmpresasRazonSocial = Me.txtRazonSocial.Text.Trim
            objMantenedor.RutUsuario = objSession.Rut
            objMantenedor.ConsultarEmpresas()

            Dim bf As BoundField
            bf = CType(Me.grdEmpresas.Columns(1), BoundField)
            bf.DataField = "razon_social"

            bf = CType(Me.grdEmpresas.Columns(2), BoundField)
            bf.DataField = "nombre_contacto"

            bf = CType(Me.grdEmpresas.Columns(3), BoundField)
            bf.DataField = "fono_contacto"
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdEmpresas, objMantenedor.EmpresasListado)
            objWeb = Nothing
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:consultar-->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdEmpresas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdEmpresas.PageIndexChanging
        Try
            grdEmpresas.PageIndex = e.NewPageIndex
            consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:grdEmpresas_PageIndexChanging-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdEmpresas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmpresas.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hpl As New HyperLink
            hpl = CType(e.Row.FindControl("hplRut"), HyperLink)
            hpl.Attributes.Add("onclick", "Cerrar('" & hpl.Text & "');")
        End If
    End Sub
End Class
