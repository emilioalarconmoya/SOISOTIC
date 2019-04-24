Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_franquicia
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CFranquicia
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)

            If Not Page.IsPostBack Then
                'mensaje de pie de pagina 
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                ViewState("RutCliente") = Request("RutCliente")
                ViewState("Nombre") = Request("Nombre")
                ViewState("Agno") = objSession.Agno
                objWeb.SeteaGrilla(grdResultados, 20)
                Consultar()
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                'Me.btnPopUpSence.Attributes.Add("onClick", "popup_pos('buscador_curso_sence.aspx?campo=txtCodSence', 'NewWindow2', 380, 700, 100, 100);return false;")
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If

            'Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_franquicia:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objMantenedor = New CFranquicia
            objMantenedor.Rut = RutUsrALng(ViewState("RutCliente"))
            Me.lblRazonSocial.Text = ViewState("Nombre")
            Me.lblRutCliente.Text = ViewState("RutCliente")
            Dim dt As DataTable
            dt = objMantenedor.Consultar
            objWeb.LlenaGrilla(grdResultados, dt)
            objMantenedor = Nothing

        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_franquicia:Consultar-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_franquicia_m.aspx?agno=" & ViewState("Agno") & "&RutCliente=" & ViewState("RutCliente") & "&nuevo=no" & "&nombre=" & ViewState("Nombre"))
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_empresas_m.aspx?rutEmpresa=" & ViewState("RutCliente") & "&nuevo=no")
    End Sub

    
    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lblValor As Label
                lblValor = CType(e.Row.FindControl("lblValor"), Label)
                lblValor.Text = FormatoMonto(lblValor.Text)
            End If

        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_franquicia:grdResultados_RowDataBound-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblAgno As Label = CType(row.FindControl("lblAgno"), Label)
        Response.Redirect("mantenedor_franquicia_m.aspx?agno=" & lblAgno.Text & "&RutCliente=" & ViewState("RutCliente") & "&nuevo=no")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        objMantenedor = New CFranquicia
        Dim lblAgno As Label = CType(row.FindControl("lblAgno"), Label)
        objMantenedor.Agno = lblAgno.Text
        objMantenedor.Rut = RutUsrALng(ViewState("RutCliente"))
        If objMantenedor.Eliminar() = True Then
            body.Attributes.Add("onload", "alert('¡Franquicia eliminada exitosamente!');")
        Else
            body.Attributes.Add("onload", "alert('¡No se puede eliminar la franquicia!');")
            Exit Sub
        End If
        Consultar()
    End Sub
End Class
