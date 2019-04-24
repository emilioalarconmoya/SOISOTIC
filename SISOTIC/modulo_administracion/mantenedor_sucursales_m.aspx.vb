Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_sucursales_m
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objMantenedorSucursales As New CMantenedorSucursales
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            '***********************************************************************************
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                ViewState("CodSucursal") = Request("CodSucursal")
                ViewState("NombreSucursal") = Request("NombreSucursal")

                objMantenedorSucursales = New CMantenedorSucursales
                Session("objeto") = objMantenedorSucursales


                If Not ViewState("CodSucursal") Is Nothing Then
                    Me.txtCodigo.Enabled = False
                    ViewState("modo") = "actualizar"
                    objMantenedorSucursales = New CMantenedorSucursales
                    objMantenedorSucursales.CodSucursal = ViewState("CodSucursal")
                    objMantenedorSucursales.NomSucursal = ViewState("NombreSucursal")
                    CargarDatos()
                Else
                    If Request("CodSucursal") = "" Then
                        If Request("nuevo") = "si" Then
                            ViewState("modo") = "insertar"
                            objMantenedorSucursales.InicializarNuevo()
                        End If
                    End If
                    Me.btnGuardar.Attributes.Add("Onclick", "if (typeof(Page_ClientValidate) == 'function')" & _
                                    "Page_ClientValidate();return confirm('" & Me.hdfConfirmacionGuardar.Value & "');")
                    End If
            End If
        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_sucursales_m.aspx:Page_Load->" & ex.Message)
        End Try
    End Sub
    Public Sub CargarDatos()
        Me.txtCodigo.Text = objMantenedorSucursales.CodSucursal
        Me.txtNombre.Text = objMantenedorSucursales.NomSucursal

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim objSql As CSql
            Dim strCodigo As String
            Dim strTabla As String
            Dim strTabla2 As String
            Dim strCampo As String

            objSql = New CSql

            If Me.txtCodigo.Text = "" Then
                body.Attributes.Add("onload", "alert('Debe ingresar un codigo para la Sucursal');")
                Exit Sub

            End If
            strCodigo = Me.txtCodigo.Text
            strTabla = "sucursal"
            strTabla2 = "director_sucursal"
            strCampo = "cod_sucursal"
            If ViewState("modo") = "insertar" Then
                If objSql.ExisteCodigoString(strCodigo, strTabla, strCampo) Then
                    body.Attributes.Add("onload", "alert('El código ingresado ya está en uso. Ingrese otro');")
                    Exit Sub
                End If
           
            End If



            objMantenedorSucursales.NomSucursal = Me.txtNombre.Text
            If Me.txtCodigo.Text > 32767 Then
                body.Attributes.Add("onload", "alert('El código ingresado es demasiado grande');")
            Else
                objMantenedorSucursales.CodSucursal = Me.txtCodigo.Text
            End If



            If Me.RequiredFieldValidator1.IsValid Then

                If ViewState("modo") = "actualizar" Then
                    objMantenedorSucursales.CodSucursal = CInt(Trim(txtCodigo.Text))
                    objMantenedorSucursales.Actualizar()
                    body.Attributes.Add("onload", "alert('" & Me.hdfActualizarExito.Value & "');")
                ElseIf ViewState("modo") = "insertar" Then
                    objMantenedorSucursales.Insertar()
                    body.Attributes.Add("onload", "alert('" & Me.hdfInsertarExito.Value & "');")
                    Me.txtNombre.Text = ""
                Else
                    objMantenedorSucursales.Insertar()
                    body.Attributes.Add("onload", "alert('" & Me.hdfInsertarExito.Value & "');")
                    Me.txtNombre.Text = ""
                End If
            End If
        Catch ex As Exception
            EnviaError("modulo_administracion_mantenedor_sucursales_m.aspx:btnGuardar_Click->" & ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("mantenedor_sucursales.aspx")
    End Sub
End Class
