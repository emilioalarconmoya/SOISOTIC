Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_encargado_m
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorEncargado
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantenedor = New CMantenedorEncargado
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("rutEncargado") = RutUsrALng(Request("rutEncargado"))
                ViewState("rutEmpresa") = RutUsrALng(Request("rutEmpresa"))
                btn_buscar_empresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")
                If Request("nuevo") = "no" Then
                    ViewState("modo") = "actualizar"
                    Consultar()
                Else
                    ViewState("modo") = "insertar"
                End If
            End If

            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_encargado_m:Page_Load--> " & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objMantenedor = New CMantenedorEncargado
            objMantenedor.RutEncargado = ViewState("rutEncargado")
            objMantenedor.RutEmpresa = ViewState("rutEmpresa")
            objMantenedor.Consultar()

            Me.txtRutContacto.Text = RutLngAUsr(objMantenedor.RutEncargado)
            Me.txtNombreContacto.Text = objMantenedor.NombreEncargado
            Me.txtApeContactoPrincipal.Text = objMantenedor.ApellidoEncargado
            Me.txtCargoContacto.Text = objMantenedor.CargoEncargado
            Me.txtFonoContacto.Text = objMantenedor.FonoEncargado
            Me.txtEmailContacto.Text = objMantenedor.EmailEncargado
            Me.txtRutEmpresa.Text = RutLngAUsr(objMantenedor.RutEmpresa)
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_encargado_m:Consultar--> " & ex.Message)
        End Try
    End Sub
    Public Sub Grabar()
        Try
            objMantenedor = New CMantenedorEncargado

            If Me.txtRutContacto.Text = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el rut del encargado.');")
                Exit Sub
            Else
                If EsRut(Me.txtRutContacto.Text.Trim) Then
                    objMantenedor.RutEncargado = RutUsrALng(Me.txtRutContacto.Text.Trim)
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El rut del encargado no es válido.');")
                    Exit Sub
                End If
            End If

            If Me.txtNombreContacto.Text = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el nombre del encargado.');")
                Exit Sub
            Else
                objMantenedor.NombreEncargado = Me.txtNombreContacto.Text.Trim
            End If

            If Me.txtApeContactoPrincipal.Text = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el apellido del encargado.');")
                Exit Sub
            Else
                objMantenedor.ApellidoEncargado = Me.txtApeContactoPrincipal.Text.Trim
            End If

            objMantenedor.CargoEncargado = Me.txtCargoContacto.Text.Trim
            If Me.txtFonoContacto.Text.Trim = "" Then
                objMantenedor.FonoEncargado = ""
            Else
                If IsNumeric(Me.txtFonoContacto.Text.Trim) Then
                    objMantenedor.FonoEncargado = Me.txtFonoContacto.Text.Trim
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN:El telefono debe ser nùmerico.');")
                    Exit Sub
                End If
            End If
            

            objMantenedor.EmailEncargado = Me.txtEmailContacto.Text.Trim

            If Me.txtRutEmpresa.Text = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el rut de la empresa.');")
                Exit Sub
            Else
                If EsRut(Me.txtRutEmpresa.Text.Trim) Then
                    objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text.Trim)
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El rut de la empresa no es válido.');")
                    Exit Sub
                End If
            End If

            If ViewState("modo") = "actualizar" Then
                If objMantenedor.Actualizar Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Los datos han sido ingresado correctamente.');")
                    Exit Sub
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Hubo un problema al ingresar los datos.');")
                    Exit Sub
                End If
            Else
                If objMantenedor.Insertar Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Los datos han sido ingresado correctamente.');")
                    Exit Sub
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Hubo un problema al ingresar los datos.');")
                    Exit Sub
                End If
            End If



            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_encargado_m:Grabar--> " & ex.Message)
        End Try
    End Sub
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_encargado.aspx")
    End Sub
End Class
