Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_usuario_perfil_m
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedorUsuario As CMantenedorUsuario
    Dim objLookups As Clookups
    Dim objMantenedorUsuSucu As CMantenedorUsuarioSucursal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                'muestra pie de pagina
                lblPie.Text = Parametros.p_PIE
                ViewState("RutSession") = objSession.Rut
                objMantenedorUsuario = New CMantenedorUsuario
                objMantenedorUsuSucu = New CMantenedorUsuarioSucursal
                objLookups = New Clookups
                If Request("nuevo") = "no" Then
                    ViewState("modo") = "actualizar"
                    objMantenedorUsuario.RutUsuario = Request("rutUsuario")
                    objMantenedorUsuSucu.RutDirector = RutUsrALng(Request("rutUsuario"))
                    objMantenedorUsuSucu.CodSucursal = Request("codSucursal")
                    objMantenedorUsuario.Consultar()
                    objMantenedorUsuSucu.Consultar()
                    Me.txtRut.Text = objMantenedorUsuario.RutUsuario
                    Me.txtNombres.Text = objMantenedorUsuario.Nombres
                    Me.txtEmail.Text = objMantenedorUsuario.Email
                    Me.txtTelefono.Text = objMantenedorUsuario.Telefono.Trim
                    Me.txtFax.Text = objMantenedorUsuario.Fax.Trim
                    Me.txtPassw.Text = ""
                    Me.txtPasswRepite.Text = ""
                    ' Me.txtCodigo.Text = objMantenedorUsuario.CodSucursal
                    'Me.txtNombreSucursal.Text = objMantenedorUsuario.NomSucursal
                    objWeb.LlenaDDL(Me.ddlNomSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                    Me.ddlNomSucursal.SelectedValue = objMantenedorUsuSucu.CodSucursal
                    objWeb.LlenaLSTaux(lbxDisponibles, objMantenedorUsuario.PerfilesNoAsignados, "cod_perfil", "nombre")
                    objWeb.LlenaLSTaux(lbxAsignados, objMantenedorUsuario.PerfilesAsignados, "cod_perfil", "nombre")
                    objWeb.LlenaLSTaux(lbxEjecDisponibles, objMantenedorUsuario.EjecutivosNoAsignados, "rut", "nombres")
                    objWeb.LlenaLSTaux(lbxEjecAsignados, objMantenedorUsuario.EjecutivosAsignados, "rut", "nombres")
                    Dim i As Integer
                    Dim strCodPerfil As String
                    For i = 0 To Me.lbxAsignados.Items.Count - 1
                        strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
                        If strCodPerfil = "4" Then
                            tablaFiltro.Visible = False
                        End If
                    Next
                    For i = 0 To Me.lbxAsignados.Items.Count - 1
                        strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
                        If strCodPerfil = "8" Then
                            tablaSucursal.Visible = True
                        End If
                    Next
                Else
                    ViewState("modo") = "insertar"
                    Me.txtPassw.Text = ""
                    Me.txtFax.Text = ""
                    objMantenedorUsuario.InicializarNuevo()

                    objWeb.LlenaDDL(Me.ddlNomSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
                    objWeb.LlenaLSTaux(lbxDisponibles, objMantenedorUsuario.PerfilesTodos, "cod_perfil", "nombre")
                    objWeb.LlenaLSTaux(lbxEjecDisponibles, objMantenedorUsuario.EjecutivosTodos, "rut", "nombres")
                End If
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
                objMantenedorUsuario = Nothing
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1
            End If
            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Public Sub Grabar()
        Dim i As Integer
        Dim e As Integer
        Dim strValidaPass As String
        Dim strValidaLista As String
        Dim strCodPerfil As String
        Dim strRutEjec As String
        Try
            Dim dt As New DataTable
            Dim dtEjec As New DataTable
            AddColumnDataTable(dt, "cod_perfil", "integer")
            AddColumnDataTable(dtEjec, "rut_ejecutivo", "long")
            Dim dr As DataRow
            dr = dt.NewRow
            'If txtPassw.Text.Trim <> "" Or txtPasswRepite.Text.Trim <> "" Then
            'If txtPassw.Text.Trim.Length >= 4 Then
            strValidaPass = Me.txtPasswRepite.Text.Trim
            If txtPassw.Text.Trim <> strValidaPass Then
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
          & "alert('¡El password no coincide con su repetición!');</script>")
                Exit Sub
            End If
            '  Else
            '  Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
            '& "alert('¡El password no puede ser menor de 4 caractéres!');</script>")
            'Exit Sub
            'End If
            'End If
            'Llenando propiedades
            objMantenedorUsuario = New CMantenedorUsuario
            objMantenedorUsuario.RutUsuarioSesion = ViewState("RutSession")
            objMantenedorUsuario.RutUsuario = Me.txtRut.Text
            objMantenedorUsuario.Nombres = Me.txtNombres.Text
            objMantenedorUsuario.Clave = Me.txtPassw.Text.Trim
            objMantenedorUsuario.Email = Me.txtEmail.Text
            objMantenedorUsuario.Telefono = Me.txtTelefono.Text
            objMantenedorUsuario.Fax = Me.txtFax.Text
            For i = 0 To Me.lbxAsignados.Items.Count - 1
                If Me.lbxAsignados.Items(i).Value.Trim = 2 Then
                    objMantenedorUsuario.Tipo = "J"
                Else
                    objMantenedorUsuario.Tipo = "N"
                End If
            Next
            objMantenedorUsuario.InsertaPersona()
            If Not objMantenedorUsuario.ConsultarExisteUsuario() Then 'And objMantenedorUsuario.InsertaPersona() Then
                If txtPassw.Text.Trim <> "" Or txtPasswRepite.Text.Trim <> "" Then
                    If txtPassw.Text.Trim.Length >= 4 Then
                        strValidaPass = Me.txtPasswRepite.Text.Trim
                        If txtPassw.Text.Trim <> strValidaPass Then
                            Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                      & "alert('¡El password no coincide con su repetición!');</script>")
                            Exit Sub
                        End If
                    Else
                        Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                      & "alert('¡El password no puede ser menor de 4 caractéres!');</script>")
                        Exit Sub
                    End If
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                                         & "alert('¡Debe ingresar una clave!');</script>")
                    Me.txtPassw.Focus()
                    Exit Sub
                End If
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strValidaLista = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strValidaLista)
                Next
                objMantenedorUsuario.Traspaso = dt
                objMantenedorUsuario.Insertar()

                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strCodPerfil)
                    If strCodPerfil = "4" Then
                        For e = 0 To Me.lbxEjecAsignados.Items.Count - 1
                            strRutEjec = Me.lbxEjecAsignados.Items(e).Value.Trim
                            dtEjec.Rows.Add(strRutEjec)
                        Next
                        objMantenedorUsuario.TtraspasoEjecutivo = dtEjec
                        objMantenedorUsuario.InsertarEjecutivo()
                    End If
                Next
                Dim objSql As CSql
                Dim strCodigo As String
                Dim strTabla As String
                Dim strCampo As String

                objSql = New CSql

                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strCodPerfil)
                    If strCodPerfil = "8" Then
                        objMantenedorUsuario.CodSucursal = Me.ddlNomSucursal.SelectedValue 'Me.txtCodigo.Text
                        objMantenedorUsuario.RutUsuario = Me.txtRut.Text
                        objMantenedorUsuario.InsertarDirector()
                    End If
                Next

                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
          & "alert('¡Usuario insertado exitosamente!');</script>")
                objMantenedorUsuario.InicializarNuevo()
                LimpiaControles()
                LimpiaList()
                objWeb.LlenaLSTaux(lbxDisponibles, objMantenedorUsuario.PerfilesTodos, "cod_perfil", "nombre")
                objWeb.LlenaLSTaux(lbxEjecDisponibles, objMantenedorUsuario.EjecutivosTodos, "rut", "nombres")
            Else 'Usuario existe entonces se actualiza
                If ViewState("modo") = "insertar" Then
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
           & "alert('¡Ya existe un usuario con el mismo Rut en el sistema!');</script>")
                    Exit Sub
                End If
                ''Grabación de Perfiles 
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strValidaLista = Trim(Me.lbxAsignados.Items(i).Value)
                    dt.Rows.Add(strValidaLista)
                Next
                'recibe el conjunto de perfiles seleccionados
                objMantenedorUsuario.Traspaso = dt
                objMantenedorUsuario.Actualizar()

                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strCodPerfil)
                    If strCodPerfil = "4" Then
                        For e = 0 To Me.lbxEjecAsignados.Items.Count - 1
                            strRutEjec = Me.lbxEjecAsignados.Items(e).Value.Trim
                            dtEjec.Rows.Add(strRutEjec)
                        Next
                        objMantenedorUsuario.TtraspasoEjecutivo = dtEjec
                        objMantenedorUsuario.ActualizarSupervisor()
                    End If
                Next
                For i = 0 To Me.lbxAsignados.Items.Count - 1
                    strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
                    dt.Rows.Add(strCodPerfil)
                    If strCodPerfil = "8" Then
                        objMantenedorUsuario.RutUsuario = Request("rutUsuario")
                        objMantenedorUsuario.CodSucursal = Request("codSucursal")
                        objMantenedorUsuario.EliminarSucursal()
                        objMantenedorUsuario.CodSucursal = Me.ddlNomSucursal.SelectedValue 'Me.txtCodigo.Text
                        objMantenedorUsuario.NomSucursal = Me.ddlNomSucursal.SelectedItem.Text    'Me.txtNombreSucursal.Text

                        objMantenedorUsuario.ActualizarSucursal()
                        objMantenedorUsuario.ActualizarDirector()
                    End If
                Next
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
           & "alert('¡Usuario actualizado exitosamente!');</script>")
            End If
        Catch ex As Exception
            EnviaError("mantenedor_usuario_perfil_m.aspx.vb: Grabar--> " & ex.Message)
        End Try
    End Sub
    Protected Sub btnVa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVa.Click
        objWeb.CargaLst(Me.lbxDisponibles, Me.lbxAsignados)
        Dim i As Integer
        Dim strCodPerfil As String
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "4" Then
                tablaFiltro.Visible = False
            End If
        Next
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "8" Then
                tablaSucursal.Visible = True
            End If
        Next
    End Sub
    Protected Sub btnViene_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViene.Click
        objWeb.CargaLst(lbxAsignados, lbxDisponibles)
        Dim i As Integer
        Dim strCodPerfil As String
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "4" Then
                tablaFiltro.Visible = False
            End If
        Next
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "8" Then
                tablaSucursal.Visible = False
            End If
        Next
    End Sub
    Protected Sub btnVieneall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVieneall.Click
        objWeb.CargaLstcompleta(lbxAsignados, lbxDisponibles)
        Dim i As Integer
        Dim strCodPerfil As String
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "4" Then
                tablaFiltro.Visible = False

            End If
        Next
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "8" Then
                tablaSucursal.Visible = False
            End If
        Next
    End Sub
    Protected Sub btnVaall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVaall.Click
        objWeb.CargaLstcompleta(lbxDisponibles, lbxAsignados)
        Dim i As Integer
        Dim strCodPerfil As String
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "4" Then
                tablaFiltro.Visible = False

            End If
        Next
        For i = 0 To Me.lbxAsignados.Items.Count - 1
            strCodPerfil = Me.lbxAsignados.Items(i).Value.Trim
            If strCodPerfil = "8" Then
                tablaSucursal.Visible = True
            End If
        Next
    End Sub
    Sub LimpiaControles()
        Me.txtEmail.Text = ""
        Me.txtNombres.Text = ""
        Me.txtPassw.Text = ""
        Me.txtPasswRepite.Text = ""
        Me.txtRut.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtFax.Text = ""
    End Sub
    Sub LimpiaList()
        Me.lbxAsignados.Items.Clear()
        Me.lbxDisponibles.Items.Clear()
        Me.lbxEjecAsignados.Items.Clear()
        Me.lbxEjecDisponibles.Items.Clear()
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub

    
    Protected Sub btnVaEjec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVaEjec.Click
        objWeb.CargaLst(Me.lbxEjecDisponibles, Me.lbxEjecAsignados)
    End Sub

    Protected Sub btnVaallEjec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVaallEjec.Click
        objWeb.CargaLstcompleta(Me.lbxEjecDisponibles, Me.lbxEjecAsignados)
    End Sub

    Protected Sub btnVieneEjec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVieneEjec.Click
        objWeb.CargaLst(Me.lbxEjecAsignados, Me.lbxEjecDisponibles)
    End Sub

    Protected Sub btnVieneallEjec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVieneallEjec.Click
        objWeb.CargaLstcompleta(Me.lbxEjecAsignados, Me.lbxEjecDisponibles)
    End Sub
End Class
