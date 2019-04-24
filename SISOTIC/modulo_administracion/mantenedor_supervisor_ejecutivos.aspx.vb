
Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_supervisor_ejecutivos
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objCSql As New CSql
    Dim objMantenedorSuperEjec As New CMantenedorSupervisorEjecutivo
    Dim objMantenedorUsuario As New CMantenedorUsuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()

            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE

            End If

        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_supervisor_ejecutivos.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Public Sub Consultar()
        Try
            objMantenedorSuperEjec.BajarXml = chkBajarReporte.Checked
            If Me.txtRutSupervisor.Text = "" Then
                objMantenedorSuperEjec.RutSupervisor = 0
            Else
                objMantenedorSuperEjec.RutSupervisor = RutUsrALng(Me.txtRutSupervisor.Text)
            End If
            If Me.txtRutEjecutivo.Text = "" Then
                objMantenedorSuperEjec.RutEjecutivo = 0
            Else
                objMantenedorSuperEjec.RutEjecutivo = RutUsrALng(Me.txtRutEjecutivo.Text)
            End If
            If Me.txtNombreSupervisor.Text = "" Then
                objMantenedorSuperEjec.NombreSupervisor = ""
            Else
                objMantenedorSuperEjec.NombreSupervisor = Me.txtNombreSupervisor.Text
            End If
            If Me.txtNombreEjecutivo.Text = "" Then
                objMantenedorSuperEjec.NombreEjecutivo = ""
            Else
                objMantenedorSuperEjec.NombreEjecutivo = Me.txtNombreEjecutivo.Text
            End If





            Dim dt As DataTable
            dt = objMantenedorSuperEjec.Consultar()
            objWeb.LlenaGrilla(grdSucursal, dt)

            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objMantenedorSuperEjec.ArchivoXml
                Me.hplBajarReporte.Visible = True

            End If
            objMantenedorSuperEjec = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_supervisor_ejecutivos.aspx.vb:Consultar-->" & ex.Message)
        End Try
        
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_supervisor_ejecutivos_m.aspx?nuevo=si")
    End Sub

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblRut As Label = CType(row.FindControl("lblRutSupervisor"), Label)
        lblRut.Text = RutUsrALng(lblRut.Text)
        Response.Redirect("mantenedor_supervisor_ejecutivos_m.aspx?RutSupervisor=" & lblRut.Text & "&nuevo=no")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        Dim lblRutSupervisor As Label = CType(row.FindControl("lblRutSupervisor"), Label)
        Dim lblRutEjecutivo As Label = CType(row.FindControl("lblRutEjecutivo"), Label)
        objMantenedorUsuario = New CMantenedorUsuario
        objMantenedorUsuario.RutSupervisor = RutUsrALng(lblRutSupervisor.Text)
        objMantenedorUsuario.RutEjecutivo = RutUsrALng(lblRutEjecutivo.Text)
        objMantenedorUsuario.EliminarSupervisor()
        Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                            & "alert('¡Usuario eliminado exitosamente!');document.location=('./mantenedor_supervisor_ejecutivos.aspx');</script>")


    End Sub

    Protected Sub grdSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblRutSupervisor As Label
            lblRutSupervisor = CType(e.Row.FindControl("lblRutSupervisor"), Label)
            lblRutSupervisor.Text = RutLngAUsr(lblRutSupervisor.Text)
            Dim lblRutEjecutivo As Label
            lblRutEjecutivo = CType(e.Row.FindControl("lblRutEjecutivo"), Label)
            lblRutEjecutivo.Text = RutLngAUsr(lblRutEjecutivo.Text)

            Dim btnEliminar As Button
            btnEliminar = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.OnClientClick = "return confirm('¿Esta seguro de eliminar este registro?');"
        End If
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu_administracion.aspx")
    End Sub
End Class
