Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_usuario_sucursal
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objCSql As New CSql
    Dim objMantenedorUsuSucu As New CMantenedorUsuarioSucursal
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
            EnviaError("modulo_administracion_mantenedor_usuario_sucursal.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objMantenedorUsuSucu.BajarXml = chkBajarReporte.Checked
            If Me.txtRutUsuario.Text = "" Then
                objMantenedorUsuSucu.RutDirector = 0
            Else
                objMantenedorUsuSucu.RutDirector = RutUsrALng(Me.txtRutUsuario.Text)
            End If
            If Me.txtCodSucursal.Text = "" Then
                objMantenedorUsuSucu.CodSucursal = 0
            Else

                If Not IsNumeric(Me.txtCodSucursal.Text) Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                                      & "alert('¡Debe ingresar un numero entero!');</script>")
                    Exit Sub
                End If
                objMantenedorUsuSucu.CodSucursal = Me.txtCodSucursal.Text
            End If
            If Me.txtNombreUsuario.Text = "" Then
                objMantenedorUsuSucu.NombreDir = ""
            Else
                objMantenedorUsuSucu.NombreDir = Me.txtNombreUsuario.Text
            End If
            If Me.txtNombreSucursal.Text = "" Then
                objMantenedorUsuSucu.NombreSuc = ""
            Else
                objMantenedorUsuSucu.NombreSuc = Me.txtNombreSucursal.Text
            End If
            

            Dim dt As DataTable
            dt = objMantenedorUsuSucu.Consultar()
            objWeb.LlenaGrilla(grdSucursal, dt)

            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objMantenedorUsuSucu.ArchivoXml
                Me.hplBajarReporte.Visible = True

            End If
            objMantenedorUsuSucu = Nothing

        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_usuario_sucursal.aspx.vb:Consultar-->" & ex.Message)
        End Try
    End Sub


    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Response.Redirect("mantenedor_usuario_perfil_m.aspx?Nuevo=si")
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("menu.aspx")
    End Sub

    Protected Sub grdSucursal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSucursal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblRutDir As Label
            lblRutDir = CType(e.Row.FindControl("lblRutDir"), Label)
            lblRutDir.Text = RutLngAUsr(lblRutDir.Text)
        End If
    End Sub

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEditar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEditar.NamingContainer, GridViewRow)
        Dim lblRutDir As Label
        lblRutDir = CType(row.FindControl("lblRutDir"), Label)
        Dim lblCodSucursal As Label
        lblCodSucursal = CType(row.FindControl("lblCodSucursal"), Label)

        Response.Redirect("mantenedor_usuario_sucursal_m.aspx?rutUsuario=" & lblRutDir.Text & "&codSucursal=" & lblCodSucursal.Text & "&Nuevo=no")
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminar.NamingContainer, GridViewRow)
        Dim lblRutDir As Label
        lblRutDir = CType(row.FindControl("lblRutDir"), Label)
        Dim lblCodSucursal As Label
        lblCodSucursal = CType(row.FindControl("lblCodSucursal"), Label)
        objMantenedorUsuSucu = New CMantenedorUsuarioSucursal
        objMantenedorUsuSucu.CodSucursal = lblCodSucursal.Text
        objMantenedorUsuSucu.RutDirector = RutUsrALng(lblRutDir.Text)
        objMantenedorUsuSucu.Eliminar()
        Consultar()
    End Sub
End Class
