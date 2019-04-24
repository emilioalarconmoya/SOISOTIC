Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_encargado
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorEncargado
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                objWeb.SeteaGrilla(grdResultados, 50)
                btn_buscar_empresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
           

        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_encargado:Page_Load--> " & ex.Message)
        End Try
    End Sub
    Private Sub Consultar()
        Try

            objMantenedor = New CMantenedorEncargado
            If Me.txtRutEmpresa.Text.Trim <> "" Then
                objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text.Trim)
            Else
                objMantenedor.RutEmpresa = 0
            End If
            If Me.txtRutEncargado.Text.Trim <> "" Then
                objMantenedor.RutEncargado = RutUsrALng(Me.txtRutEncargado.Text.Trim)
            Else
                objMantenedor.RutEncargado = 0
            End If

            If Me.txtNombreEncargado.Text.Trim <> "" Then
                objMantenedor.NombreEncargado = Me.txtNombreEncargado.Text.Trim
            Else
                objMantenedor.NombreEncargado = ""
            End If


            Dim dt As DataTable
            dt = objMantenedor.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)

           
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_encargado:Consultar--> " & ex.Message)
        End Try
    End Sub
    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lblRut As Label
                lblRut = CType(e.Row.FindControl("lblRut"), Label)
                lblRut.Text = RutLngAUsr(lblRut.Text)

                Dim lblRutEmp As Label
                lblRutEmp = CType(e.Row.FindControl("lblRutEmp"), Label)
                lblRutEmp.Text = RutLngAUsr(lblRutEmp.Text)


            End If
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_encargado:grdResultados_RowDataBound--> " & ex.Message)
        End Try
        
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_encargado_m.aspx?nuevo=si")
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
 
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblRut As Label = CType(row.FindControl("lblRut"), Label)
        Dim lblRutEmp As Label = CType(row.FindControl("lblRutEmp"), Label)
        Response.Redirect("mantenedor_encargado_m.aspx?rutEncargado=" & lblRut.Text & "&rutEmpresa=" & lblRutEmp.Text & "&nuevo=no")
    End Sub
End Class
