Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_empresas
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorEmpresas
    Dim objLookups As Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objLookups = New Clookups
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
                objWeb.AgregaValorDDL(Me.ddlEjecutivo, "", gValorNumNulo)
                objWeb.SeteaGrilla(grdResultados, 50)
                ddlEjecutivo.SelectedValue = gValorNumNulo
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                btn_buscar_empresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            ' Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_empresas:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try

            objMantenedor = New CMantenedorEmpresas
            objMantenedor.BajarXml = chkBajarReporte.Checked
            objMantenedor.Rut = Me.txtRutEmpresa.Text
            objMantenedor.RazonSocial = Me.txtRazonSocial.Text
            objMantenedor.NombreFantasia = Me.txtNomFantasia.Text
            objMantenedor.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
            Dim dt As DataTable
            dt = objMantenedor.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)

            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objMantenedor.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_empresas.aspx:Consultar->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        grdResultados.PageIndex = e.NewPageIndex
        Consultar()
    End Sub
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblRut As Label = CType(row.FindControl("lblRut"), Label)
        Response.Redirect("mantenedor_empresas_m.aspx?rutEmpresa=" & lblRut.Text & "&nuevo=no")
    End Sub
    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        Dim lblRut As Label = CType(row.FindControl("lblRut"), Label)
        objMantenedor = New CMantenedorEmpresas
        objMantenedor.Rut = lblRut.Text
        If objMantenedor.Eliminar() Then
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡Empresa eliminado exitosamente!');document.location=('./mantenedor_empresas.aspx');</script>")
            objMantenedor = Nothing
        Else
            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡No se ha podido realizar la operación!');document.location=('./mantenedor_empresas.aspx');</script>")
            objMantenedor = Nothing
        End If
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_empresas_m.aspx?nuevo=si")
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblRut As Label
            lblRut = CType(e.Row.FindControl("lblRut"), Label)
            lblRut.Text = RutLngAUsr(lblRut.Text)

            Dim btnEliminar As Button
            btnEliminar = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.OnClientClick = "return confirm('¿Esta seguro de eliminar este registro?');"
        End If
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
End Class
