Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_otec_m
    Inherits System.Web.UI.Page
    Dim lngRutOtec As Long
    Dim strNuevo As String
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objMantenedor As New CMantenedorOtec
    Dim objLookUps As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'muestra pie de pagina
                lblPie.Text = Parametros.p_PIE
                objWeb.LlenaDDL(Me.ddlComuna, objLookUps.comunas, "cod_comuna", "nombre")
                objWeb.LlenaDDL(Me.ddlRubro, objLookUps.Rubros, "cod_rubro", "nombre")
                lngRutOtec = Request("RutOtec")
                ViewState("RutOtec") = lngRutOtec
                strNuevo = Request("nuevo")
                If strNuevo.Trim.ToUpper = "SI" Then
                    ViewState("Tipo") = "Insertar"
                    Me.txtRegion.Enabled = False
                ElseIf strNuevo.Trim.ToUpper = "NO" Then
                    ViewState("Tipo") = "Modificar"
                    objMantenedor.RutOtec = ViewState("RutOtec")
                    objMantenedor.InicializarNuevo()
                    Me.txtRut.Text = RutLngAUsr(objMantenedor.RutOtec)
                    txtRut.Enabled = False
                    Me.txtSigla.Text = objMantenedor.Sigla
                    Me.txtRazonSocial.Text = objMantenedor.RazonSocial
                    Me.txtNombreFantasia.Text = objMantenedor.Nombre
                    Me.txtDireccion.Text = objMantenedor.Direccion
                    Me.txtNroDireccion.Text = objMantenedor.NroDireccion
                    Me.txtCiudad.Text = objMantenedor.Ciudad
                    Me.ddlComuna.SelectedValue = objMantenedor.CodigoComuna
                    Me.txtRegion.Text = objMantenedor.Region
                    Me.txtRegion.Enabled = False
                    Me.txtDireccionWeb.Text = objMantenedor.SitioWeb
                    Me.txtTelefono1.Text = objMantenedor.Fono
                    Me.txtTelefono2.Text = objMantenedor.Fono2
                    Me.txtFax.Text = objMantenedor.Fax
                    Me.txtEmail.Text = objMantenedor.Email
                    Me.txtCasilla.Text = objMantenedor.Casilla
                    Me.txtNombreContacto.Text = objMantenedor.NombreContacto
                    Me.txtCargoContacto.Text = objMantenedor.CargoContacto
                    Me.txtFonoContacto.Text = objMantenedor.FonoContacto
                    Me.txtEmailContacto.Text = objMantenedor.EmailContacto
                    Me.txtNomRep1.Text = objMantenedor.NombreRep1
                    Me.txtRutRep1.Text = RutLngAUsr(objMantenedor.RutRep1)
                    Me.txtNomRep2.Text = objMantenedor.NombreRep2
                    Me.txtRutRep2.Text = objMantenedor.RutRep2
                    Me.txtGerenteGeneral.Text = objMantenedor.GerenteGeneral
                    Me.txtGerenteRrhh.Text = objMantenedor.GerenteRRHH
                    Me.txtGerenteCobranza.Text = objMantenedor.AreaCobranzas
                    Me.txtGiro.Text = objMantenedor.Giro
                    Me.txtCodActivEconomica.Text = objMantenedor.CodActEconomica
                    Me.ddlRubro.SelectedValue = objMantenedor.CodigoRubro
                    Me.txtNumConvenio.Text = objMantenedor.NumConvenio
                    Me.txtTasaDescuento.Text = objMantenedor.TasaDescuento
                End If
            End If
        Catch ex As Exception
            EnviaError("mantenedor_otec_m:Page_Load-->" & ex.Message)
        End Try
        
    End Sub
    Public Function ValidarDatos() As Boolean
        Try
            ValidarDatos = True

            If Me.txtRut.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:Debe completar correctamente el campo Rut.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtRazonSocial.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Razon Social no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtNombreFantasia.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Nombre fantasia no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtSigla.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Sigla no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtDireccion.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Dirección no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtNroDireccion.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Número de la Dirección no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtCiudad.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Ciudad no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtTelefono1.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo Telefono 1 no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtEmail.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El campo  E-mail Cliente  no debe estar vacío.');")
                ValidarDatos = False
                Exit Function
            End If
            If Me.txtTasaDescuento.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN:El dato ingresado en el campo  Tasa descuento  debe ser un número entero.');")
                ValidarDatos = False
                Exit Function
            End If

        Catch ex As Exception
            EnviaError("mantenedor_otec_m:ValidarDatos-->" & ex.Message)
        End Try
    End Function
    Public Sub Grabar()
        Try
            If Not ValidarDatos() Then
                'Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If


            objMantenedor = New CMantenedorOtec

            'datos pricipales
            objMantenedor.RutOtec = RutUsrALng(Me.txtRut.Text)
            objMantenedor.DigitoOtec = digito_verificador(objMantenedor.RutOtec)
            objMantenedor.RazonSocial = Me.txtRazonSocial.Text
            objMantenedor.Nombre = Me.txtNombreFantasia.Text
            objMantenedor.Sigla = Me.txtSigla.Text

            'direccion
            objMantenedor.Direccion = Me.txtDireccion.Text
            objMantenedor.NroDireccion = Me.txtNroDireccion.Text
            objMantenedor.Ciudad = Me.txtCiudad.Text
            objMantenedor.CodigoComuna = Me.ddlComuna.SelectedValue
            objMantenedor.Region = Me.txtRegion.Text
            objMantenedor.SitioWeb = Me.txtDireccionWeb.Text
            objMantenedor.Fono = Me.txtTelefono1.Text
            objMantenedor.Fono2 = Me.txtTelefono2.Text
            objMantenedor.Fax = Me.txtFax.Text
            objMantenedor.Email = Me.txtEmail.Text
            objMantenedor.Casilla = Me.txtCasilla.Text

            'contacto principal
            objMantenedor.NombreContacto = Me.txtNombreContacto.Text
            objMantenedor.CargoContacto = Me.txtCargoContacto.Text
            objMantenedor.FonoContacto = Me.txtFonoContacto.Text
            objMantenedor.EmailContacto = Me.txtEmailContacto.Text
            objMantenedor.AreaCobranzas = Me.txtGerenteCobranza.Text

            'representates legales
            objMantenedor.NombreRep1 = Me.txtNomRep1.Text
            If Me.txtRutRep1.Text = "" Then
                objMantenedor.RutRep1 = 0
            Else
                objMantenedor.RutRep1 = RutUsrALng(Me.txtRutRep1.Text)
            End If
            If Me.txtRutRep2.Text = "" Then
                objMantenedor.RutRep2 = 0
            Else
                objMantenedor.RutRep2 = RutUsrALng(Me.txtRutRep2.Text)

            End If
            objMantenedor.NombreRep2 = Me.txtNomRep2.Text
            
            'otros contactos
            objMantenedor.GerenteGeneral = Me.txtGerenteGeneral.Text
            objMantenedor.GerenteRRHH = Me.txtGerenteRrhh.Text

            'actividad
            objMantenedor.Giro = Me.txtGiro.Text
            objMantenedor.CodActEconomica = Me.txtCodActivEconomica.Text
            objMantenedor.CodigoRubro = Me.ddlRubro.SelectedValue
            If Me.txtNumConvenio.Text = "" Then
                objMantenedor.NumConvenio = 0
            Else
                objMantenedor.NumConvenio = Me.txtNumConvenio.Text
            End If

            objMantenedor.TasaDescuento = Me.txtTasaDescuento.Text
            If ViewState("Tipo") = "Insertar" Then
                objMantenedor.Insertar()
                body.Attributes.Add("onload", "alert('ATENCIÓN:Se ingreso Otec con exito.');")
            Else
                objMantenedor.Actualizar()
                body.Attributes.Add("onload", "alert('ATENCIÓN:Se actualizaron datos con exito.');")
            End If
        Catch ex As Exception
            EnviaError("mantenedor_otec_m:Grabar-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_otec.aspx")
    End Sub
End Class
