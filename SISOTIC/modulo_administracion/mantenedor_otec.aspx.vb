Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_otec
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorOtec
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                'muestra pie de pagina
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                objWeb.SeteaGrilla(grdResultados, 50)
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            'Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        objMantenedor = New CMantenedorOtec
        If Me.txtRutOtec.Text = "" Then
            objMantenedor.RutOtec = 0
        Else
            objMantenedor.RutOtec = RutUsrALng(Me.txtRutOtec.Text)
        End If
        objMantenedor.RazonSocial = Me.txtRazonSocial.Text
        objMantenedor.Nombre = Me.txtNomFantasia.Text
        objMantenedor.BajarXml = chkBajarReporte.Checked
        Dim dt As DataTable
        dt = objMantenedor.Consultar
        objWeb.LlenaGrilla(grdResultados, dt)
        If chkBajarReporte.Checked Then
            hplBajarReporte.Target = "_Blank"
            hplBajarReporte.Text = "Descargar archivo"
            hplBajarReporte.NavigateUrl = objMantenedor.ArchivoXml
            Me.hplBajarReporte.Visible = True
        End If
        objMantenedor = Nothing
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblRutOtec As Label = CType(row.FindControl("lblRutOtec"), Label)
        Response.Redirect("mantenedor_otec_m.aspx?RutOtec=" & RutUsrALng(lblRutOtec.Text) & "&nuevo=no")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        Dim lblRutOtec As Label = CType(row.FindControl("lblRutOtec"), Label)
        objMantenedor = New CMantenedorOtec
        objMantenedor.RutOtec = RutUsrALng(lblRutOtec.Text)
        If objMantenedor.Eliminar() = False Then
            body.Attributes.Add("onload", "alert('No se puede eliminar');")
            Consultar()
        Else
            body.Attributes.Add("onload", "alert('Perfil eliminado exitosamente');")
            Consultar()
        End If
        'Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
        '            & "alert('¡Perfil eliminado exitosamente!');document.location=('./mantenedor_perfil.aspx');</script>")
        'body.Attributes.Add("onload", "alert('Perfil eliminado exitosamente');")
        'Consultar()
     
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_otec_m.aspx?nuevo=si")
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
End Class

