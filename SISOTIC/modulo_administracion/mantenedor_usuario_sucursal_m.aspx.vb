Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_usuario_sucursal_m
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objMantenedorUsuSucu As New CMantenedorUsuarioSucursal
    Dim objMantenedorUsuario As New CMantenedorUsuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            '***********************************************************************************
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("codSucursal") = Request("codSucursal")
                ViewState("rutUsuario") = Request("rutUsuario")

                objMantenedorUsuSucu = New CMantenedorUsuarioSucursal
                Session("objeto") = objMantenedorUsuSucu


                If Not ViewState("codSucursal") Is Nothing Then

                    ViewState("modo") = "actualizar"
                    objMantenedorUsuSucu = New CMantenedorUsuarioSucursal
                    objMantenedorUsuSucu.CodSucursal = ViewState("codSucursal")
                    objMantenedorUsuSucu.RutDirector = RutUsrALng(Request("rutUsuario"))
                    Me.ddlNomSucursal.SelectedValue = ViewState("codSucursal")
                    Me.ddlDirector.SelectedValue = RutUsrALng(Request("rutUsuario"))
                    objWeb.LlenaDDL(Me.ddlNomSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                    objWeb.LlenaDDL(Me.ddlDirector, objLookups.directores, "rut", "nombres")
                Else
                    If Request("codSucursal") = "" Then
                        'If Request("nuevo") = "si" Then
                        ViewState("modo") = "insertar"
                        objWeb.LlenaDDL(Me.ddlNomSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                        objWeb.LlenaDDL(Me.ddlDirector, objLookups.directores, "rut", "nombres")
                        'End If
                    End If
                    Me.btnGuardar.Attributes.Add("Onclick", "if (typeof(Page_ClientValidate) == 'function')" & _
                                    "Page_ClientValidate();return confirm('" & Me.hdfConfirmacionGuardar.Value & "');")
                End If
            End If
        Catch ex As Exception
            EnviaError("mantenedor_usuario_sucursal_m.aspx:Page_Load->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objMantenedorUsuSucu = New CMantenedorUsuarioSucursal
            objMantenedorUsuario = New CMantenedorUsuario
            objMantenedorUsuSucu.NombreDir = Me.ddlDirector.SelectedItem.Text
            objMantenedorUsuSucu.RutDirector = Me.ddlDirector.SelectedValue
            objMantenedorUsuSucu.NombreSuc = Me.ddlNomSucursal.SelectedItem.Text
            objMantenedorUsuSucu.CodSucursal = Me.ddlNomSucursal.SelectedValue

            If ViewState("modo") = "actualizar" Then

                objMantenedorUsuSucu.CodSucursal = ViewState("codSucursal")
                objMantenedorUsuSucu.RutDirector = RutUsrALng(Request("rutUsuario"))
                objMantenedorUsuSucu.Eliminar()
                objMantenedorUsuario.RutUsuario = RutLngAUsr(Me.ddlDirector.SelectedValue)
                objMantenedorUsuario.CodSucursal = Me.ddlNomSucursal.SelectedValue
                objMantenedorUsuario.ActualizarDirector()
            ElseIf ViewState("modo") = "insertar" Then
                objMantenedorUsuario.RutUsuario = RutLngAUsr(Me.ddlDirector.SelectedValue)
                objMantenedorUsuario.CodSucursal = Me.ddlNomSucursal.SelectedValue
                objMantenedorUsuario.InsertarDirector()
            Else
                objMantenedorUsuario.RutUsuario = Me.ddlDirector.SelectedValue
                objMantenedorUsuario.CodSucursal = Me.ddlNomSucursal.SelectedValue
                objMantenedorUsuario.InsertarDirector()

            End If
        Catch ex As Exception
            EnviaError("mantenedor_usuario_sucursal_m.aspx:Consultar->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Consultar()
    End Sub
End Class

