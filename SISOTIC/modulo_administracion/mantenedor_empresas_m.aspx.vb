Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_empresas_m
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorEmpresas
    Dim objLookups As Clookups
    Dim objCliente As CCliente
    Dim objMantenedorUsuario As CMantenedorUsuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantenedor = New CMantenedorEmpresas
            btnGrabar.OnClientClick = "return confirm('Está apunto de hacer cambios en empresa seleccionada\n¿Desea continuar?');"
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                body.Attributes.Clear()
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                If Request("nuevo") = "no" Then
                    Me.txtActEconomica.Text = " "
                    Me.txtClaveWeb.Text = " "
                    ViewState("modo") = "actualizar"
                    ViewState("RutEmpresa") = Request("rutEmpresa")
                    objMantenedor.Rut = ViewState("RutEmpresa")
                    objMantenedor.RutUsuario = ViewState("RutSession")
                    TablaFranquiciaAnual.Visible = True
                    TablaObservacion.Visible = True
                    objMantenedor.ConsultaActualizacion()
                    objMantenedor.ConsultaCliente()
                    objLookups = New Clookups
                    objMantenedor.Carga_Lookup()
                    objWeb.LlenaDDL(Me.ddlComunas, objLookups.comunas, "cod_comuna", "nombre")
                    objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                    objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
                    objWeb.LlenaDDL(Me.ddlRubroInterno, objLookups.Rubros, "cod_rubro", "nombre")
                    objWeb.LlenaDDL(Me.ddlAdminNoLineal, objMantenedor.LookUpAdmNoLineal, "CodTipoAdm", "NomTipoAdm")
                    objWeb.LlenaDDL(Me.ddlEstadoEmpresa, objMantenedor.LookUpEstadoCliente, "cod_estado_cliente", "nombre")
                    Me.txtRutEmpresa.Text = objMantenedor.Rut
                    Me.txtRazonSocial.Text = objMantenedor.RazonSocial
                    Me.txtNomFantasia.Text = objMantenedor.NombreFantasia
                    Me.txtSigla.Text = objMantenedor.Sigla
                    Me.txtRutHolding.Text = RutLngAUsr(objMantenedor.RutHolding)
                    Me.txtDireccion.Text = objMantenedor.Direccion
                    Me.txtNumDireccion.Text = objMantenedor.NroDireccion
                    Me.txtCiudad.Text = objMantenedor.Ciudad
                    Me.ddlComunas.SelectedValue = objMantenedor.CodComuna
                    Me.txtSitiosWeb.Text = objMantenedor.SitioWeb
                    Me.txtTelefono1.Text = objMantenedor.Fono1
                    Me.txtTelefono2.Text = objMantenedor.Fono2
                    Me.txtFax.Text = objMantenedor.Fax
                    Me.txtEmail.Text = objMantenedor.Email
                    Me.txtCasilla.Text = objMantenedor.Casilla
                    Me.ddlSucursal.SelectedValue = objMantenedor.CodSucursal
                    Me.ddlEjecutivo.SelectedValue = objMantenedor.RutEjecutivo
                    Me.txtEmpleados.Text = objMantenedor.NumEmpleados
                    Me.txtTasaAdministracion.Text = objMantenedor.CostoAdm
                    Me.txtObservacion.Text = objMantenedor.Observacion
                    Me.lblFranquiciaAnual.Text = objMantenedor.FranquiciaActual
                    Me.txtRutContacto.Text = RutLngAUsr(objMantenedor.RutContacto)
                    Me.txtApeContactoPrincipal.Text = objMantenedor.ApellidoContacto
                    Me.txtNombreContacto.Text = objMantenedor.Contacto
                    Me.txtCargoContacto.Text = objMantenedor.Cargo
                    Me.txtFonoContacto.Text = objMantenedor.FonoCargo
                    Me.txtAnexoContacto.Text = objMantenedor.AnexoContacto
                    Me.txtEmailContacto.Text = objMantenedor.EmailContacto
                    Me.txtGerCobranzas.Text = objMantenedor.AreaCobranzas
                    Me.txtFonoGerente.Text = objMantenedor.FonoCobranzas
                    Me.txtRepresentante1.Text = objMantenedor.NombreRepresentante1
                    Me.txtRut1.Text = RutLngAUsr(objMantenedor.RutRepresentante1)
                    Me.txtRepresentante2.Text = objMantenedor.NombreRepresentante2
                    Me.txtRut2.Text = RutLngAUsr(objMantenedor.RutRepresentante2)
                    Me.txtGerGeneral.Text = objMantenedor.GerenteGeneral
                    Me.txtGerRRHH.Text = objMantenedor.GerenteRRHH
                    Me.txtEmailGerRRHH.Text = objMantenedor.EmailGerenteRRHH
                    Me.txtGerFinanzas.Text = objMantenedor.GerenteFinanzas
                    Me.txtEmailGerFinanzas.Text = objMantenedor.EmailGerenteFinanzas
                    Me.txtGiro.Text = objMantenedor.Giro
                    Me.txtActEconomica.Text = objMantenedor.CodActEconomica
                    Me.ddlRubroInterno.SelectedValue = objMantenedor.Rubro
                    Me.ddlAdminNoLineal.SelectedValue = objMantenedor.AdmNoLineal
                    Me.ddlEstadoEmpresa.SelectedValue = objMantenedor.CodEstadoCliente
                    Me.ddlValorVentaAnual.SelectedValue = objMantenedor.VentaAnual
                    Me.txtClaveWeb.Text = objMantenedor.ClaveWebService
                    Me.txtEtiquetaClasif.Text = objMantenedor.EtiquetaClasificador

                    'Me.txtTasaAdministracion.enabled = False

                    objLookups = Nothing
                Else
                    ViewState("modo") = "insertar"
                    objLookups = New Clookups
                    objMantenedor.Carga_Lookup()
                    objWeb.LlenaDDL(Me.ddlComunas, objLookups.comunas, "cod_comuna", "nombre")
                    objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                    objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
                    objWeb.LlenaDDL(Me.ddlRubroInterno, objLookups.Rubros, "cod_rubro", "nombre")
                    objWeb.LlenaDDL(Me.ddlAdminNoLineal, objMantenedor.LookUpAdmNoLineal, "CodTipoAdm", "NomTipoAdm")
                    objWeb.LlenaDDL(Me.ddlEstadoEmpresa, objMantenedor.LookUpEstadoCliente, "cod_estado_cliente", "nombre")
                    Me.txtActEconomica.Text = ""
                    Me.txtClaveWeb.Text = ""
                    Me.txtObservacion.Text = "Ingrese observación"
                    objLookups = Nothing
                End If
                objMantenedor = Nothing
            End If
        Catch ex As Exception
            EnviaError("mantenedor_empresas_m:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Grabar()
        Try
            If ViewState("modo") = "actualizar" Then
                objMantenedor = New CMantenedorEmpresas
                objMantenedor.RutUsuario = ViewState("RutSession")
                objMantenedor.Rut = Me.txtRutEmpresa.Text
                objMantenedor.RazonSocial = Me.txtRazonSocial.Text
                objMantenedor.NombreFantasia = Me.txtNomFantasia.Text
                objMantenedor.Sigla = Me.txtSigla.Text
                objMantenedor.RutHolding = RutUsrALng(Me.txtRutHolding.Text)
                objMantenedor.Direccion = Me.txtDireccion.Text
                objMantenedor.NroDireccion = Me.txtNumDireccion.Text
                objMantenedor.Ciudad = Me.txtCiudad.Text
                objMantenedor.CodComuna = Me.ddlComunas.SelectedValue
                objMantenedor.SitioWeb = Me.txtSitiosWeb.Text
                objMantenedor.Fono1 = Me.txtTelefono1.Text
                objMantenedor.Fono2 = Me.txtTelefono2.Text
                objMantenedor.Fax = Me.txtFax.Text
                objMantenedor.Email = Me.txtEmail.Text
                objMantenedor.Casilla = Me.txtCasilla.Text
                objMantenedor.CodSucursal = Me.ddlSucursal.SelectedValue
                objMantenedor.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
                objMantenedor.NumEmpleados = Me.txtEmpleados.Text
                If IsNumeric(Me.txtTasaAdministracion.Text.Trim) Then
                    If Me.txtTasaAdministracion.Text.Trim > 15 Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: El porcentaje de administración no debe ser mayor a 15%.');")
                        Exit Sub
                    Else
                        objMantenedor.CostoAdm = Me.txtTasaAdministracion.Text.Trim
                    End If

                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El porcentaje de administración debe ser númerico.');")
                    Exit Sub
                End If

                objMantenedor.Observacion = Me.txtObservacion.Text
                If validarut(Me.txtRutContacto.Text.Trim) Then
                    objMantenedor.RutContacto = RutUsrALng(Me.txtRutContacto.Text.Trim)
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un rut válido del contacto principal .');")
                    Exit Sub
                End If

                If Me.txtNombreContacto.Text.Trim = "" Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el nombre del contacto principal .');")
                    Exit Sub
                Else
                    objMantenedor.Contacto = Me.txtNombreContacto.Text.Trim
                End If

                If Me.txtApeContactoPrincipal.Text.Trim = "" Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el apellido del contacto principal .');")
                    Exit Sub
                Else
                    objMantenedor.ApellidoContacto = Me.txtApeContactoPrincipal.Text.Trim
                End If



                objMantenedor.Cargo = Me.txtCargoContacto.Text
                objMantenedor.FonoCargo = Me.txtFonoContacto.Text.Trim
                objMantenedor.AnexoContacto = Me.txtAnexoContacto.Text
                objMantenedor.EmailContacto = Me.txtEmailContacto.Text.Trim
                objMantenedor.AreaCobranzas = Me.txtGerCobranzas.Text
                objMantenedor.FonoCobranzas = Me.txtFonoGerente.Text
                objMantenedor.NombreRepresentante1 = Me.txtRepresentante1.Text
                objMantenedor.RutRepresentante1 = RutUsrALng(Me.txtRut1.Text)
                objMantenedor.NombreRepresentante2 = Me.txtRepresentante2.Text
                objMantenedor.RutRepresentante2 = RutUsrALng(Me.txtRut2.Text)
                objMantenedor.GerenteGeneral = Me.txtGerGeneral.Text
                objMantenedor.GerenteRRHH = Me.txtGerRRHH.Text
                objMantenedor.EmailGerenteRRHH = Me.txtEmailGerRRHH.Text
                objMantenedor.GerenteFinanzas = Me.txtGerFinanzas.Text
                objMantenedor.EmailGerenteFinanzas = Me.txtEmailGerFinanzas.Text
                objMantenedor.Giro = Me.txtGiro.Text
                objMantenedor.CodActEconomica = Me.txtActEconomica.Text
                objMantenedor.Rubro = Me.ddlRubroInterno.SelectedValue
                objMantenedor.AdmNoLineal = Me.ddlAdminNoLineal.SelectedValue
                objMantenedor.CodEstadoCliente = Me.ddlEstadoEmpresa.SelectedValue
                objMantenedor.VentaAnual = Me.ddlValorVentaAnual.SelectedValue
                objMantenedor.ClaveWebService = Me.txtClaveWeb.Text
                objMantenedor.EtiquetaClasificador = Me.txtEtiquetaClasif.Text
                objMantenedor.Observacion = Me.txtObservacion.Text
                If objMantenedor.Actualizar Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Empresa actualizada exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido actualizar la empresa!');</script>")
                End If
                objMantenedor = Nothing
            Else
                objMantenedor = New CMantenedorEmpresas
                objMantenedor.RutUsuario = ViewState("RutSession")
                objMantenedor.Rut = Me.txtRutEmpresa.Text
                objMantenedor.RazonSocial = Me.txtRazonSocial.Text
                objMantenedor.NombreFantasia = Me.txtNomFantasia.Text
                objMantenedor.Sigla = Me.txtSigla.Text
                If Me.txtRutHolding.Text = "" Then
                    objMantenedor.RutHolding = 0
                Else
                    objMantenedor.RutHolding = RutUsrALng(Me.txtRutHolding.Text)
                End If
                objMantenedor.Direccion = Me.txtDireccion.Text
                objMantenedor.NroDireccion = Me.txtNumDireccion.Text
                objMantenedor.Ciudad = Me.txtCiudad.Text
                objMantenedor.CodComuna = Me.ddlComunas.SelectedValue
                objMantenedor.SitioWeb = Me.txtSitiosWeb.Text
                objMantenedor.Fono1 = Me.txtTelefono1.Text
                objMantenedor.Fono2 = Me.txtTelefono2.Text
                If Me.txtFax.Text = "" Then
                    Me.txtFax.Text = "..."
                Else
                    objMantenedor.Fax = Me.txtFax.Text
                End If

                objMantenedor.Email = Me.txtEmail.Text
                objMantenedor.Casilla = Me.txtCasilla.Text
                objMantenedor.CodSucursal = Me.ddlSucursal.SelectedValue
                objMantenedor.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
                If Me.txtEmpleados.Text = "" Then
                    objMantenedor.NumEmpleados = 0
                Else
                    objMantenedor.NumEmpleados = Me.txtEmpleados.Text
                End If
                If IsNumeric(Me.txtTasaAdministracion.Text.Trim) Then
                    If Me.txtTasaAdministracion.Text.Trim > 15 Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: El porcentaje de administración no debe ser mayor a 15%.');")
                        Exit Sub
                    Else
                        objMantenedor.CostoAdm = Me.txtTasaAdministracion.Text.Trim
                    End If

                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El porcentaje de administración debe ser númerico.');")
                    Exit Sub
                End If
                objMantenedor.Observacion = Me.txtObservacion.Text
                If validarut(Me.txtRutContacto.Text.Trim) Then
                    objMantenedor.RutContacto = RutUsrALng(Me.txtRutContacto.Text.Trim)
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un rut válido del contacto principal .');")
                    Exit Sub
                End If

                If Me.txtNombreContacto.Text.Trim = "" Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el nombre del contacto principal .');")
                    Exit Sub
                Else
                    objMantenedor.Contacto = Me.txtNombreContacto.Text.Trim
                End If

                If Me.txtApeContactoPrincipal.Text.Trim = "" Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el apellido del contacto principal .');")
                    Exit Sub
                Else
                    objMantenedor.ApellidoContacto = Me.txtApeContactoPrincipal.Text.Trim
                End If
                objMantenedor.Cargo = Me.txtCargoContacto.Text
                objMantenedor.FonoCargo = Me.txtFonoContacto.Text
                objMantenedor.AnexoContacto = Me.txtAnexoContacto.Text
                objMantenedor.EmailContacto = Me.txtEmailContacto.Text
                objMantenedor.AreaCobranzas = Me.txtGerCobranzas.Text
                objMantenedor.FonoCobranzas = Me.txtFonoGerente.Text
                objMantenedor.NombreRepresentante1 = Me.txtRepresentante1.Text
                If Me.txtRut1.Text = "" Then
                    objMantenedor.RutRepresentante1 = 0
                Else
                    objMantenedor.RutRepresentante1 = RutUsrALng(Me.txtRut1.Text)
                End If
                objMantenedor.NombreRepresentante2 = Me.txtRepresentante2.Text
                If Me.txtRut2.Text = "" Then
                    objMantenedor.RutRepresentante2 = 0
                Else
                    objMantenedor.RutRepresentante2 = RutUsrALng(Me.txtRut2.Text)
                End If
                objMantenedor.GerenteGeneral = Me.txtGerGeneral.Text
                objMantenedor.GerenteRRHH = Me.txtGerRRHH.Text
                objMantenedor.EmailGerenteRRHH = Me.txtEmailGerRRHH.Text
                objMantenedor.GerenteFinanzas = Me.txtGerFinanzas.Text
                objMantenedor.EmailGerenteFinanzas = Me.txtEmailGerFinanzas.Text
                objMantenedor.Giro = Me.txtGiro.Text
                objMantenedor.CodActEconomica = Me.txtActEconomica.Text
                objMantenedor.Rubro = Me.ddlRubroInterno.SelectedValue
                objMantenedor.AdmNoLineal = Me.ddlAdminNoLineal.SelectedValue
                objMantenedor.CodEstadoCliente = Me.ddlEstadoEmpresa.SelectedValue
                objMantenedor.VentaAnual = Me.ddlValorVentaAnual.SelectedValue
                objMantenedor.ClaveWebService = Me.txtClaveWeb.Text
                objMantenedor.EtiquetaClasificador = Me.txtEtiquetaClasif.Text
                If Not objMantenedor.ExisteEmpresa Then
                    If objMantenedor.Insertar Then
                        objMantenedorUsuario = New CMantenedorUsuario
                        Dim strPass As String = ""
                        strPass = EncryptINI("1234")
                        objMantenedorUsuario.InsertarUsuarioEmp(RutUsrALng(Me.txtRutEmpresa.Text.Trim), Me.txtRazonSocial.Text.Trim, strPass, _
                                                            Me.txtEmail.Text.Trim, Me.txtTelefono1.Text.Trim, Me.txtFax.Text.Trim, objSession.Rut)
                        Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡Empresa ingresada exitosamente!');</script>")
                    Else
                        Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡No se ha podido ingresar la empresa!');</script>")
                    End If
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido ingresar la empresa!');</script>")
                    objMantenedor = Nothing
                    Exit Sub
                End If
                objMantenedor = Nothing
            End If
        Catch ex As Exception
            EnviaError("mantenedor_empresas_m:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_empresas.aspx")
    End Sub

    Protected Sub btnFranquicia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFranquicia.Click
        Response.Redirect("mantenedor_franquicia.aspx?RutCliente=" & Me.txtRutEmpresa.Text & "&Nombre=" & Me.txtRazonSocial.Text)
    End Sub
End Class
