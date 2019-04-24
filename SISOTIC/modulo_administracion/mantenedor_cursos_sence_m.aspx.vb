Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_mantenedor_cursos_sence_m
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorCursosSence
    Dim objLookups As Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objMantenedor = New CMantenedorCursosSence
            objLookups = New Clookups
            body.Attributes.Clear()
            btnGrabar.OnClientClick = "return confirm('Está apunto de hacer cambios en el curso seleccionado\n¿Desea continuar?');"
            If Not Page.IsPostBack Then
              
                'mensaje de pie de pagina 
                lblPie.Text = Parametros.p_PIE

                ViewState("RutSession") = objSession.Rut
                If Request("nuevo") = "no" Then
                    ViewState("modo") = "actualizar"
                    lblTipo.Text = "Actualización de curso SENCE"
                    ViewState("CodSence") = Request("codSence")

                    Consultar()

                    btn_buscar_otec.Attributes.Add("onClick", "popup_pos('buscador_otec.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")
                Else
                    ViewState("modo") = "insertar"
                    objWeb.LlenaDDL(Me.ddlComuna, objLookups.comunas, "cod_comuna", "nombre")
                    objWeb.LlenaDDL(Me.ddlModalidad, objLookups.modalidad, "cod_modalidad", "nombre")
                    btn_buscar_otec.Attributes.Add("onClick", "popup_pos('buscador_otec.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")
                    Me.ddlModalidad.SelectedValue = 1
                    Me.ddlComuna.SelectedValue = 132101
                End If
                objMantenedor = Nothing
                objLookups = Nothing
            End If
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_cursos_sence_m:Page_Load--> " & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            objMantenedor = New CMantenedorCursosSence
            objMantenedor.CodSence = ViewState("CodSence")
            objMantenedor.Consultar()
            Me.txtCodSence.Text = objMantenedor.CodSence
            Me.txtCodSence.Enabled = False
            Me.txtNombreCurso.Text = objMantenedor.NombreCurso
            Me.txtRutEmpresa.Text = objMantenedor.RutOtec
            Me.txtArea.Text = objMantenedor.Area
            Me.txtEspecialidad.Text = objMantenedor.Especialidad
            Me.txtDurCursoTeorico.Text = objMantenedor.DurCurTeorico
            Me.txtDurCursoPractico.Text = objMantenedor.DurCurPractico
            Me.txtHoraElearning.Text = objMantenedor.DurCurElearning
            Me.txtNumParticipantes.Text = objMantenedor.NumMaxParticipantes
            Me.txtNombreSede.Text = objMantenedor.NombreSede
            Me.txtFonoSede.Text = objMantenedor.FonoSede
            Me.txtDireccion.Text = objMantenedor.Direccion
            objWeb.LlenaDDL(Me.ddlComuna, objLookups.comunas, "cod_comuna", "nombre")
            objWeb.LlenaDDL(Me.ddlModalidad, objLookups.modalidad, "cod_modalidad", "nombre")
            Me.ddlComuna.SelectedValue = objMantenedor.CodComuna
            Me.txtValorTotal.Text = objMantenedor.ValorCurso
            Me.txtValorTotal.Text = objMantenedor.ValorCurso
            txtValorHoraSence.Text = objMantenedor.ValorHora
            Me.ddlModalidad.SelectedValue = objMantenedor.CodModalidad
            'Me.chkElearning.Checked = objMantenedor.Elearning
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_cursos_sence_m:Consultar--> " & ex.Message)
        End Try
        
    End Sub
    Public Sub Grabar()
        Try
            objMantenedor = New CMantenedorCursosSence

            If Me.txtCodSence.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un código sence.');")
                Exit Sub
            Else
                objMantenedor.CodSence = Me.txtCodSence.Text
            End If
            If Me.txtNombreCurso.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el nombre del curso sence.');")
                Exit Sub
            Else
                objMantenedor.NombreCurso = Me.txtNombreCurso.Text
            End If
            If Me.txtRutEmpresa.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el rut de la otec.');")
                Exit Sub
            Else
                objMantenedor.RutOtec = Me.txtRutEmpresa.Text
            End If

            If Me.txtArea.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el área del curso.');")
                Exit Sub
            Else
                objMantenedor.Area = Me.txtArea.Text
            End If

            If Me.txtEspecialidad.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar la especialidad del curso.');")
                Exit Sub
            Else
                objMantenedor.Especialidad = Me.txtEspecialidad.Text
            End If

            If Me.txtDurCursoTeorico.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un valor en las horas teóricas.');")
                Exit Sub
            Else
                objMantenedor.DurCurTeorico = CLng(Me.txtDurCursoTeorico.Text.Trim)
            End If
            If Me.txtDurCursoPractico.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un valor en las horas prácticas.');")
                Exit Sub
            Else
                objMantenedor.DurCurPractico = CLng(Me.txtDurCursoPractico.Text.Trim)
            End If
            If Me.txtHoraElearning.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un valor en las horas e-learning.');")
                Exit Sub
            Else
                objMantenedor.DurCurElearning = CLng(Me.txtHoraElearning.Text.Trim)
            End If
            If Me.txtNumParticipantes.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el total de participantes.');")
                Exit Sub
            Else
                objMantenedor.NumMaxParticipantes = CLng(Me.txtNumParticipantes.Text.Trim)
            End If
            If Me.txtNombreSede.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el nombre de la sede.');")
                Exit Sub
            Else
                objMantenedor.NombreSede = Me.txtNombreSede.Text
            End If
            If Me.txtFonoSede.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el fono de la sede.');")
                Exit Sub
            Else
                objMantenedor.FonoSede = Me.txtFonoSede.Text
            End If

            If Me.txtDireccion.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar la direccion de la sede.');")
                Exit Sub
            Else
                objMantenedor.Direccion = Me.txtDireccion.Text
            End If

            objMantenedor.CodComuna = CLng(Me.ddlComuna.SelectedValue.Trim)
            If Me.txtValorTotal.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el valor total del curso');")
                Exit Sub
            Else
                objMantenedor.ValorCurso = CLng(Me.txtValorTotal.Text.Trim)
            End If
            If Me.txtValorHoraSence.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el valor hora sence');")
                Exit Sub
            Else
                objMantenedor.ValorHora = Me.txtValorHoraSence.Text.Trim
            End If
            'objMantenedor.Elearning = Me.chkElearning.Checked
            objMantenedor.CodModalidad = Me.ddlModalidad.SelectedValue

            If ViewState("modo") = "actualizar" Then

                If objMantenedor.Actualizar Then
                    'objMantenedor.ActualizaValorHoraSence(Now.Year, Me.txtValorHoraSence.Text.Trim, Me.ddlModalidad.SelectedValue, Me.txtCodSence.Text.Trim)
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡Curso actualizado exitosamente!');</script>")
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido actualizar el curso!');</script>")
                End If

            Else
                If Not objMantenedor.ExisteCursoSence Then
                    If objMantenedor.Insertar Then
                        'objMantenedor.InsertarValorHoraSence(Now.Year, Me.txtValorHoraSence.Text.Trim, Me.ddlModalidad.SelectedValue, Me.txtCodSence.Text.Trim)
                        Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡Curso SENCE ingresado exitosamente!');</script>")
                        Me.limpiar()
                    Else
                        Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                        & "alert('¡No se ha podido ingresar el curso!');</script>")
                    End If
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " _
                    & "alert('¡No se ha podido ingresar el curso\nYa existe el código SENCE en el sistema!');</script>")
                    objMantenedor = Nothing
                    Exit Sub
                End If
            End If
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_cursos_sence_m:Page_Load--> " & ex.Message)
        End Try
    End Sub
    
    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub
    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("mantenedor_cursos_sence.aspx")
    End Sub
    Public Sub limpiar()
        Try
            Me.txtCodSence.Text = ""
            Me.txtNombreCurso.Text = ""
            Me.txtRutEmpresa.Text = ""
            Me.txtArea.Text = ""
            Me.txtEspecialidad.Text = ""
            Me.txtDurCursoTeorico.Text = ""
            Me.txtDurCursoPractico.Text = ""
            Me.txtHoraElearning.Text = ""
            Me.txtNumParticipantes.Text = ""
            Me.txtNombreSede.Text = ""
            Me.txtFonoSede.Text = ""
            Me.txtDireccion.Text = ""
            Me.txtValorTotal.Text = ""
            Me.txtValorHoraSence.Text = ""
            Me.ddlModalidad.SelectedValue = 1
            Me.ddlComuna.SelectedValue = 132101
        Catch ex As Exception
            EnviaError("modulo_administracion/mantenedor_cursos_sence_m:limpiar--> " & ex.Message)
        End Try
    End Sub

End Class
