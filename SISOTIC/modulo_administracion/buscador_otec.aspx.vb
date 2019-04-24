Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_buscador_otec
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objOtec As COtec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '***********************************************************************************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            '***********************************************************************************
            If Not Page.IsPostBack Then
                objWeb = New CWeb
                objWeb.SeteaGrilla(Me.grdOtec, TAM_PAG)
                objWeb = Nothing
                campo_padre.Value = Request("campo")
            End If
        Catch ex As Exception
            EnviaError("modulo_administracion_buscador_otec/buscador_otec.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            consultar()
        Catch ex As Exception
            EnviaError("modulo_administracion_buscador_otec/buscador_otec.aspx.vb:btnConsultar_Click-->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdOtec_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdOtec.PageIndexChanging
        Try
            grdOtec.PageIndex = e.NewPageIndex
            consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:grdEmpresas_PageIndexChanging-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdOtec_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdOtec.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hpl As New HyperLink
            hpl = CType(e.Row.FindControl("hplRut"), HyperLink)
            hpl.Attributes.Add("onclick", "Cerrar('" & hpl.Text & "');")
        End If
    End Sub
    Private Function consultar()
        Try
            If Me.txtRutOtec.Text.Trim = "" And Me.txtRazonSocial.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar almenos uno de los filtros.');")
                Exit Function
            End If
            If Me.txtRazonSocial.Text.Trim <> "" And Me.txtRazonSocial.Text.Trim.Length <= 2 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el nombre de a buscar');")
                Exit Function
            End If
            objOtec = New COtec
            objOtec.inicializarPopUpOtec()
            If txtRutOtec.Text.Trim <> "" Then
                objOtec.Rutotec = RutUsrALng(Me.txtRutOtec.Text.Trim)
            End If
            objOtec.RazonSocial = Me.txtRazonSocial.Text.Trim
            objOtec.RutUsuario = objSession.Rut
            objOtec.consultarOtec()
            Dim bf As BoundField
            bf = CType(Me.grdOtec.Columns(1), BoundField)
            bf.DataField = "razon_social"

            bf = CType(Me.grdOtec.Columns(2), BoundField)
            bf.DataField = "nombre_contacto"

            bf = CType(Me.grdOtec.Columns(3), BoundField)
            bf.DataField = "fono"
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdOtec, objOtec.Otec)
            objWeb = Nothing

        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:consultar-->" & ex.Message)
        End Try
    End Function
End Class
