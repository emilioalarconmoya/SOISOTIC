Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Imports System.io
Imports System.Xml
Partial Class modulo_cuentas_mantenedor_cursos
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objMantenedor As CMantenedorCursos
    Dim objCliente As CCliente
    Dim objCurso As CCurso
    Dim objAlumno As CAlumno
    Dim blnBloqueo As Boolean
    Dim intContador As Integer = 1
    Dim objMantenedorINS As CMantenedorCursosSence
    Dim objOtec As COtec

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '***********************************************************************************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            '***********************************************************************************
            body.Attributes.Clear()
            If Not Page.IsPostBack Then
                Me.Form.DefaultButton = Me.Button1.UniqueID
                If objSession.EsClienteIngresoCurso Then
                    Me.hplIngresoCurso.Visible = True
                End If
                Me.btnPopUpEmpresa.Visible = False
                Me.txtRutEmpresa.Text = RutLngAUsr(objSession.Rut)
                Me.txtRutEmpresa.Enabled = False
                objMantenedor = New CMantenedorCursos
                Me.txtPorcAdmin.Text = objMantenedor.ConsultarPorcAdmin(objSession.Rut)
                Me.txtPorcAdmin.Enabled = False
                objMantenedor = Nothing
                'End If
                txtRutEmpresa.Attributes.Add("onfocus", "FocoRUT();")
                Me.txtCodSence.Attributes.Add("onfocus", "FocoSENCE();")
                Me.wizardCurso.ActiveStepIndex = 0
                lblPie.Text = Parametros.p_PIE

                Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=wizardCurso$txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")
                Me.btnPopUpSence.Attributes.Add("onClick", "popup_pos('buscador_curso_sence.aspx?campo=wizardCurso$txtCodSence', 'NewWindow2', 380, 700, 100, 100);return false;")
                Me.btnPopUpAlumno.Attributes.Add("onClick", "popup_pos('buscador_alumno.aspx?campo=wizardCurso$txtRutAlumno', 'NewWindow3', 480, 700, 100, 100);return false;")
                Me.btnPopUpTerceros.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=wizardCurso$txtEmpBenefactora', 'NewWindow4', 380, 700, 100, 100);return false;")


                txtRutEmpresa.Attributes.Add("onblur", "CargarEmpresa();")
                txtCodSence.Attributes.Add("onblur", "CargarCursoSence();")
                txtNumParticipantes.Attributes.Add("onblur", "RepasarCostos();")


                ViewState("CodCurso") = Request("CodCurso") '2150 ' 

                ViewState("CambioxAsistencia") = Request("CambioxAsistencia")

                '************************  Paso 1  *******************************************************
                objWeb.LlenaDDL(Me.ddlTipoActividad, objLookups.tipo_actividad, "cod_tipo_activ", "nombre")
                objWeb.LlenaDDL(Me.ddlComuna, objLookups.comunas, "cod_comuna", "nombre")
                objWeb.LlenaDDL(Me.ddlAgnoInicio, objLookups.Agnos, "Agno_v", "Agno_t")
                ddlAgnoInicio.SelectedValue = Now.Year()
                objWeb.LlenaDDL(Me.ddlModalidad, objLookups.modalidad, "cod_modalidad", "nombre")
                '*****************************************************************************************

                '************************  Paso 2  *******************************************************



                'objWeb.LlenaDDL(Me.ddlDias, objLookups.Dias, "dia_v", "dia_t")
                'ddlDias.SelectedValue = 1


                'objWeb.LlenaDDL(Me.ddlHoraInicio, objLookups.Horas, "hora_v", "hora_t")
                'ddlHoraInicio.SelectedValue = 25
                'objWeb.LlenaDDL(Me.ddlHoraFin, objLookups.Horas, "hora_v", "hora_t")
                'ddlHoraFin.SelectedValue = 27



                'Me.txtHoraInicio.Text = "12"
                'Me.txtMinutoInicio.Text = "00"
                'Me.txtHoraFin.Text = "13"
                'Me.txtMinutoFin.Text = "00"
                'objWeb.SeteaGrilla(Me.grdHorario, TAM_PAG, "")
                '*****************************************************************************************

                '************************  Paso 3  *******************************************************

                objWeb.SeteaGrilla(Me.grdAlumnos, 2500, "")
                '*****************************************************************************************

                '************************  Paso 4  *******************************************************
                objWeb.SeteaGrilla(Me.grdReparto, TAM_PAG, "")
                '*****************************************************************************************

                objMantenedor = New CMantenedorCursos
                Me.txtValorCurso.Attributes.Add("onblur", "CalculaValorFinal();")
                Me.txtDescuento.Attributes.Add("onblur", "CalculaValorFinal();")
                'Me.txtCtaCap1.Attributes.Add("onblur", "CalculaCostos();")
                Me.txtCtaCap1.Attributes.Add("onblur", "CalcularValoresPaso4();")
                Me.txtExcCap1.Attributes.Add("onblur", "CalcularValoresPaso4();")
                Me.txtBecas.Attributes.Add("onblur", "CalcularValoresPaso4();")
                Me.txtCtaCap2.Attributes.Add("onblur", "CalcularValoresPaso4();")
                Me.txtExcCap2.Attributes.Add("onblur", "CalcularValoresPaso4();")


                If Not ViewState("CodCurso") Is Nothing Then
                    ViewState("modo") = "actualizar"
                    objMantenedor = New CMantenedorCursos
                    objMantenedor.RutUsuario = objSession.Rut
                    objMantenedor.CodCurso = ViewState("CodCurso")
                    Me.txtRutEmpresa.Enabled = False
                    Me.btnPopUpEmpresa.Visible = False
                    objMantenedor.InicializarCursoExistente()
                    If objMantenedor.CodEstadoCurso = 5 Or ViewState("CambioxAsistencia") = "si" Then
                        Me.wizardCurso.ActiveStepIndex = 3
                        Me.wizardCurso.SideBarStyle.CssClass = "oculto"
                    End If
                    trCorrelativo.Visible = True
                    CargarDatos()
                    If Me.txtRutEmpresa.Text <> "" Then
                        'If My.Request.Params("__EVENTTARGET") = "CargaEmpresa" Then
                        CargaEmpresa()
                        Me.tdPorcAdmin1.Visible = True
                        Me.tdPorcAdmin2.Visible = True
                        Me.tdPorcAdmin3.Visible = True
                        Me.txtPorcAdmin.Enabled = False
                        'End If
                    End If
                Else
                    'Me.calFechaInicio.SelectedDate = "" 'DateAdd(DateInterval.Day, 1, Now.Date)
                    'Me.calFechaFin.SelectedDate = "" 'DateAdd(DateInterval.Month, 1, Now.Date)
                    trCorrelativo.Visible = False
                    ViewState("modo") = "insertar"
                    Me.ddlComuna.SelectedValue = 132101
                End If
                ViewState("GraboPaso2") = 0
                ViewState("GraboPaso3") = 0
                ViewState("GraboPaso4") = 0
            Else
                If Me.txtRutEmpresa.Text <> "" Then
                    If My.Request.Params("__EVENTTARGET") = "CargaEmpresa" Then
                        CargaEmpresa()
                    End If
                End If
                If Me.txtCodSence.Text <> "" Then
                    If My.Request.Params("__EVENTTARGET") = "CargaCursoSence" Then
                        CargaCursoSence()
                    End If
                End If
                If My.Request.Params("__EVENTTARGET") = "CalculaCostos" Then
                    CalcularMontosCuentas()
                End If
                If My.Request.Params("__EVENTTARGET") = "CantidadHoras" Then
                    CantidadHoras()
                End If
                If hdfFoco.Value = 1 Then
                    ddlTipoActividad.Focus()
                ElseIf hdfFoco.Value = 2 Then
                    txtFechaInicio.Focus()
                Else
                    txtRutAlumno.Focus()
                End If
                Me.txtRutEmpresa.Enabled = False

            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas_mantenedor_cursos.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        StepActivo()
    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Public Sub StepActivo()
        If Me.wizardCurso.ActiveStep.ID = "WizardStep3" Then
            Me.contenedorCS.Attributes.Remove("class")
            Me.contenedorCS.Attributes.Add("class", "CSParticipantes")
            Me.wizardCurso.Attributes.Remove("class")
            Me.wizardCurso.Attributes.Add("class", "wizardCursoParticipantes")
            Me.divdatagrid.Attributes.Remove("class")
            Me.contenedorCS.Attributes.Remove("class")
            Me.contenedorCS.Attributes.Add("class", "CS")
            Me.wizardCurso.Attributes.Remove("class")
            Me.wizardCurso.Attributes.Add("class", "wizardCurso")
            Me.divdatagrid.Attributes.Remove("class")
        End If
    End Sub

    Protected Sub StartNextButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objMantenedor = New CMantenedorCursos
            objMantenedor.NombreEmpresa(RutUsrALng(Me.txtRutEmpresa.Text.Trim))
            objMantenedor.DatosCurso(Me.txtCodSence.Text.Trim)
            objMantenedor.RutUsuario = objSession.Rut
            If Not ValidaDatosPaso1() Then
                body.Attributes.Add("onload", ViewState("MensajeError"))
                If blnBloqueo Then
                    wizardCurso.ActiveStepIndex = 0
                    Exit Sub
                End If
            Else
                Me.hdfNumParticipantes.Value = Me.txtNumParticipantes.Text
                objMantenedor.inicializarPaso1()
                objMantenedor.RutUsuario = objSession.Rut
                objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text.Trim)
                objMantenedor.TipoActividad = Me.ddlTipoActividad.SelectedValue
                objMantenedor.ComBipartito = Me.rdbComBipSi.Checked
                objMantenedor.DetNecesidades = Me.rdbDetNecSi.Checked
                objMantenedor.NumParticipantes = Me.txtNumParticipantes.Text.Trim
                objMantenedor.Direccion = Me.txtDireccion.Text.Trim
                objMantenedor.NumDireccion = Me.txtNumDireccion.Text.Trim
                objMantenedor.Ciudad = Me.txtCiudad.Text.Trim
                objMantenedor.Comuna = Me.ddlComuna.SelectedValue
                objMantenedor.Agno = Me.ddlAgnoInicio.SelectedValue
                objMantenedor.Observaciones = Me.txtObservacion.Text.Trim
                'objMantenedor.Modalidad = Me.ddlModalidad.SelectedValue
                objMantenedor.CodSence = Me.txtCodSence.Text.Trim
                objMantenedor.FechaInicio = Me.txtFechaInicio.Text.Trim 'FechaUsrAVb(Me.calFechaInicio.SelectedValue)
                objMantenedor.FechaFin = Me.txtFechaFin.Text.Trim 'FechaUsrAVb(Me.calFechaFin.SelectedValue)
                objMantenedor.HorasComp = Me.txtHrsComp.Text.Trim
                If Me.txtValorCurso.Text.Trim <> "" Then
                    objMantenedor.ValorCurso = Me.txtValorCurso.Text.Trim
                Else
                    objMantenedor.ValorCurso = 0
                End If
                If Me.txtDescuento.Text.Trim <> "" Then
                    objMantenedor.Descuento = Me.txtDescuento.Text.Trim
                Else
                    objMantenedor.Descuento = 0
                End If

                objMantenedor.DescPorc = Me.rdbDescPorcentaje.Checked
                If Me.txtValorMasDescuento.Text.Trim <> "" Then
                    objMantenedor.ValorFinal = Me.txtValorMasDescuento.Text.Trim
                Else
                    objMantenedor.ValorFinal = 0
                End If
                objMantenedor.CorrelEmpresa = Me.txtCorrelEmpresa.Text.Trim
                objMantenedor.ContactoAdicional = Me.txtContactoAdicinal.Text.Trim
                objMantenedor.Modo = ViewState("modo")
                If objMantenedor.AdmNoLineal Then
                    objMantenedor.PorcAdmin = Me.txtPorcAdmin.Text / 100
                Else
                    If ViewState("modo") = "insertar" Then
                        objMantenedor.PorcAdmin = Math.Round(objMantenedor.ConsultarPorcAdmin(RutUsrALng(Me.txtRutEmpresa.Text.Trim)), 1)
                    Else
                        objMantenedor.PorcAdmin = ViewState("PorcAdmin")
                    End If
                End If
                objMantenedor.CursoCFT = Me.chkCursoCFT.Checked
                CargaHorario()
                CantidadHoras()
                If ViewState("modo") = "actualizar" Then
                    objMantenedor.CodCurso = ViewState("CodCurso")
                    objMantenedor.Correlativo = Me.lblFolio.Text
                    objMantenedor.DatosCurso(Me.txtCodSence.Text.Trim)
                    objMantenedor.GrabarPaso1()
                End If
                trCorrelativo.Visible = True
                wizardCurso.ActiveStepIndex = 1
                If ViewState("advertencia").ToString.Length > 0 Then
                    body.Attributes.Add("onload", ViewState("advertencia"))
                End If
                'If ViewState("advertencia2").ToString.Length > 0 Then
                '    body.Attributes.Add("onload", ViewState("advertencia2"))
                'End If
            End If
        Catch ex As Exception
            Me.hdfEnvioDatos.Value = 0
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:StartNextButton_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub StepNextButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.hdfNumParticipantes.Value = Me.txtNumParticipantes.Text
            objMantenedor = New CMantenedorCursos
            objCurso = New CCurso
            objMantenedor.RutUsuario = objSession.Rut
            If Me.wizardCurso.ActiveStepIndex = 1 Then
                If Not ValidaDatosPaso1() Then
                    wizardCurso.ActiveStepIndex = 0
                    Me.hdfEnvioDatos.Value = 0
                    Exit Sub
                Else
                    If Not ValidaHorario() Then
                        body.Attributes.Add("onload", ViewState("MensajeError"))
                        wizardCurso.ActiveStepIndex = 1
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    'If Not grdHorario.Rows.Count > 0 Then
                    '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar horario para el curso.');")
                    '    wizardCurso.ActiveStepIndex = 1
                    '    Me.hdfEnvioDatos.Value = 0
                    '    Exit Sub
                    'End If
                    objMantenedor.inicializarPaso2()
                    objMantenedor.inicializarPaso1()
                    CargaHorario()
                    If ViewState("modo") = "actualizar" Then
                        objMantenedor.CodCurso = ViewState("CodCurso")
                        objMantenedor.Correlativo = Me.lblFolio.Text
                    End If
                    objMantenedor.CodCurso = ViewState("CodCurso")
                    objMantenedor.RutUsuario = objSession.Rut
                    objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text.Trim)
                    objMantenedor.TipoActividad = Me.ddlTipoActividad.SelectedValue
                    objMantenedor.ComBipartito = Me.rdbComBipSi.Checked
                    objMantenedor.DetNecesidades = Me.rdbDetNecSi.Checked
                    objMantenedor.NumParticipantes = Me.txtNumParticipantes.Text.Trim
                    objMantenedor.Direccion = Me.txtDireccion.Text.Trim
                    objMantenedor.NumDireccion = Me.txtNumDireccion.Text.Trim
                    objMantenedor.Ciudad = Me.txtCiudad.Text.Trim
                    objMantenedor.Comuna = Me.ddlComuna.SelectedValue
                    objMantenedor.Agno = Me.ddlAgnoInicio.SelectedValue
                    objMantenedor.Observaciones = Me.txtObservacion.Text.Trim
                    'objMantenedor.Modalidad = Me.ddlModalidad.SelectedValue
                    objMantenedor.CodSence = Me.txtCodSence.Text.Trim
                    objMantenedor.FechaInicio = FechaUsrAVb(Me.txtFechaInicio.Text.Trim) 'FechaUsrAVb(Me.calFechaInicio.SelectedValue)
                    objMantenedor.FechaFin = FechaUsrAVb(Me.txtFechaFin.Text.Trim) ' FechaUsrAVb(Me.calFechaFin.SelectedValue)
                    objMantenedor.HorasComp = Me.txtHrsComp.Text.Trim
                    objMantenedor.ValorCurso = Me.txtValorCurso.Text.Trim
                    objMantenedor.Descuento = Me.txtDescuento.Text.Trim
                    objMantenedor.DescPorc = Me.rdbDescPorcentaje.Checked
                    objMantenedor.ValorFinal = Me.txtValorMasDescuento.Text.Trim
                    objMantenedor.CorrelEmpresa = Me.txtCorrelEmpresa.Text.Trim
                    objMantenedor.ContactoAdicional = Me.txtContactoAdicinal.Text.Trim
                    objMantenedor.ValorHora = Me.txtValorHora.Text.Trim
                    objMantenedor.CursoCFT = Me.chkCursoCFT.Checked
                    objMantenedor.Modo = ViewState("modo")
                    If objMantenedor.AdmNoLineal Then
                        objMantenedor.PorcAdmin = Me.txtPorcAdmin.Text / 100
                    Else
                        If ViewState("modo") = "insertar" Then
                            objMantenedor.PorcAdmin = Math.Round(objMantenedor.ConsultarPorcAdmin(RutUsrALng(Me.txtRutEmpresa.Text.Trim)), 1)
                        Else
                            objMantenedor.PorcAdmin = ViewState("PorcAdmin")
                        End If
                    End If
                    Dim objCsql = New CSql
                    objCurso.Inicializar0(objCsql, objSession.Rut)
                    objCurso.Inicializar1(Me.txtCodSence.Text.Trim)

                    CantidadHoras()
                    Dim arrHoras
                    arrHoras = lblTotalHoras.Text.Split("'")
                    'If objCurso.DurCurso > CLng(Replace(Left(lblTotalHoras.Text, 2), "'", "")) Then
                    'If objCurso.DurCurso > CLng(Replace(Left(lblTotalHoras.Text, 2), "'", "")) Then
                    If ViewState("modo") = "actualizar" Then
                        If objMantenedor.HorasComp = 0 Then
                            If Me.hdfCodCursoParcial.Value = -1 Then
                                If objCurso.DurCurso > CLng(arrHoras(0)) Then
                                    body.Attributes.Add("onload", "alert('ATENCION: Las horas ingresadas no superan las permitidas por SENCE.');")
                                    wizardCurso.ActiveStepIndex = 1
                                    Me.hdfEnvioDatos.Value = 0
                                    Exit Sub
                                End If
                            End If
                        End If

                    Else
                        If objCurso.DurCurso > CLng(arrHoras(0)) Then
                            body.Attributes.Add("onload", "alert('ATENCION: Las horas ingresadas no superan las permitidas por SENCE.');")
                            wizardCurso.ActiveStepIndex = 1
                            Me.hdfEnvioDatos.Value = 0
                            Exit Sub
                        End If
                    End If


                    If ViewState("GraboPaso2") = 0 And ViewState("modo") = "insertar" Then
                        ViewState("GraboPaso2") = 1
                        objMantenedor.GrabarPaso2()
                        CargarDatos()
                    Else
                        objMantenedor.Correlativo = Me.lblFolio.Text
                        objMantenedor.GrabarPaso2()
                        CargarDatos()
                    End If

                    ViewState("modo") = "actualizar"
                    ViewState("CodCurso") = objMantenedor.CodCurso
                    wizardCurso.ActiveStepIndex = 2

                    '***********************************************************
                    'Dim dt1 As New DataTable
                    'Dim dr1 As DataRow
                    'Dim t As Integer
                    'dt1 = ViewState("dtAlumnos")

                    'For t = 1 To (Val(Me.txtNumParticipantes.Text) - Val(Me.grdAlumnos.Rows.Count))
                    '    dr1 = dt1.NewRow
                    '    dr1("rut") = ""
                    '    dr1("nombres") = ""
                    '    dr1("apellido_paterno") = ""
                    '    dr1("apellido_materno") = ""
                    '    dr1("sexo") = "M"
                    '    dr1("cod_region") = "13"
                    '    dr1("region") = ""
                    '    dr1("cod_nivel_ocupacional") = "0"
                    '    dr1("nivel_ocupacional") = "0"
                    '    dr1("franquicia") = "1"
                    '    dr1("viatico") = "0"
                    '    dr1("traslado") = "0"
                    '    dr1("porc_asistencia") = 0
                    '    dr1("cod_nivel_educacional") = 0
                    '    dr1("nivel_educacional") = "0"

                    '    dr1("fecha_nacimiento") = Date.Today


                    '    dr1("cod_comuna") = "0"
                    '    dr1("comuna") = "SANTIAGO"
                    '    dr1("existe") = "0"
                    '    dt1.Rows.Add(dr1)
                    'Next t

                    'objWeb = New CWeb
                    'objWeb.LlenaGrilla(Me.grdAlumnos, dt1)
                    'objWeb = Nothing


                    '***********************************************************
                End If
            ElseIf Me.wizardCurso.ActiveStepIndex = 2 Then
                objMantenedor = New CMantenedorCursos
                If ViewState("modo") = "insertar" Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe realizar los pasos anteriores antes de continuar.');")
                    Me.hdfEnvioDatos.Value = 0
                    Exit Sub
                End If
                'If Not Me.grdAlumnos.Rows.Count = Me.txtNumParticipantes.Text Then
                '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar " & Me.txtNumParticipantes.Text & " alumno(s) a este curso.');")
                '    Me.hdfEnvioDatos.Value = 0
                '    Exit Sub
                'End If

                objMantenedor.inicializarPaso3()
                Dim dt As New DataTable
                dt.Columns.Add("rut")
                dt.Columns.Add("nombres")
                dt.Columns.Add("apellido_paterno")
                dt.Columns.Add("apellido_materno")
                dt.Columns.Add("sexo")
                dt.Columns.Add("cod_region")
                dt.Columns.Add("region")
                dt.Columns.Add("cod_nivel_ocupacional")
                dt.Columns.Add("nivel_ocupacional")
                dt.Columns.Add("franquicia")
                dt.Columns.Add("viatico")
                dt.Columns.Add("traslado")
                dt.Columns.Add("porc_asistencia")
                dt.Columns.Add("cod_nivel_educacional")
                dt.Columns.Add("nivel_educacional")
                dt.Columns.Add("fecha_nacimiento")
                dt.Columns.Add("cod_comuna")
                dt.Columns.Add("comuna")
                dt.Columns.Add("existe")
                dt.Columns.Add("cod_pais")
                dt.Columns.Add("pais")
                dt.Columns.Add("fono")
                dt.Columns.Add("email")
                dt.Columns.Add("RutLNG", Type.GetType("System.Int32"))
                Dim dr As DataRow
                Dim grdRow As GridViewRow
                For Each grdRow In Me.grdAlumnos.Rows
                    dr = dt.NewRow
                    If validarut(CType(grdRow.FindControl("txtRut"), TextBox).Text) Then
                        dr("rut") = CType(grdRow.FindControl("txtRut"), TextBox).Text
                    Else
                        body.Attributes.Add("onload", "alert('ATENCIÓN: El rut " & CType(grdRow.FindControl("txtRut"), TextBox).Text & " del participante no es válido.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If

                    If CType(grdRow.FindControl("txtNombres"), TextBox).Text = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("nombres") = CType(grdRow.FindControl("txtNombres"), TextBox).Text
                    If CType(grdRow.FindControl("txtApellidoPat"), TextBox).Text = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("apellido_paterno") = CType(grdRow.FindControl("txtApellidoPat"), TextBox).Text
                    If CType(grdRow.FindControl("txtApellidoMat"), TextBox).Text = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("apellido_materno") = CType(grdRow.FindControl("txtApellidoMat"), TextBox).Text
                    dr("sexo") = CType(grdRow.FindControl("ddlSexo"), DropDownList).SelectedValue
                    dr("cod_nivel_ocupacional") = CType(grdRow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                    dr("nivel_ocupacional") = CType(grdRow.FindControl("lblNivelOcup"), Label).Text
                    dr("franquicia") = CType(grdRow.FindControl("ddlFranquicia"), DropDownList).SelectedValue
                    If CType(grdRow.FindControl("txtViatico"), TextBox).Text = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("viatico") = CType(grdRow.FindControl("txtViatico"), TextBox).Text
                    If CType(grdRow.FindControl("txtTraslado"), TextBox).Text = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("traslado") = CType(grdRow.FindControl("txtTraslado"), TextBox).Text
                    'dr("porc_asistencia") = CType(grdRow.FindControl("txtPorcAsistencia"), TextBox).Text
                    'dr("porc_asistencia") = 0
                    If CType(grdRow.FindControl("hdfAsistencia"), HiddenField).Value = "" Then
                        dr("porc_asistencia") = 0
                    Else
                        dr("porc_asistencia") = CType(grdRow.FindControl("hdfAsistencia"), HiddenField).Value
                    End If
                    dr("cod_nivel_educacional") = CType(grdRow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                    dr("nivel_educacional") = CType(grdRow.FindControl("lblNivelEduc"), Label).Text
                    If EsFechaValidaVB(CType(grdRow.FindControl("txtFechaNac"), TextBox).Text) Then
                        dr("fecha_nacimiento") = FechaUsrAVb(CType(grdRow.FindControl("txtFechaNac"), TextBox).Text)
                    Else
                        body.Attributes.Add("onload", "alert('ATENCIÓN: La fecha de nacimiento del particinate " & dr("rut") & " no es válida');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If

                    dr("cod_comuna") = CType(grdRow.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue
                    dr("comuna") = CType(grdRow.FindControl("lblComuna"), Label).Text

                    dr("cod_pais") = CType(grdRow.FindControl("ddlPaisParicipante"), DropDownList).SelectedValue
                    dr("pais") = CType(grdRow.FindControl("lblPais"), Label).Text
                    If CType(grdRow.FindControl("txtFono"), TextBox).Text <> "" Then
                        If Not IsNumeric(CType(grdRow.FindControl("txtFono"), TextBox).Text) Then
                            body.Attributes.Add("onload", "alert('ATENCIÓN: El teléfono debe ser númerico.');")
                            Me.hdfEnvioDatos.Value = 0
                            Exit Sub
                        Else
                            dr("fono") = CType(grdRow.FindControl("txtFono"), TextBox).Text
                        End If
                    Else
                        dr("fono") = ""
                    End If
                    If CType(grdRow.FindControl("txtEmail"), TextBox).Text <> "" Then
                        If validaMail(CType(grdRow.FindControl("txtEmail"), TextBox).Text.Trim) Then
                            dr("email") = CType(grdRow.FindControl("txtEmail"), TextBox).Text
                        Else
                            body.Attributes.Add("onload", "alert('ATENCIÓN: El email del particinate " & dr("rut") & " no es válido');")
                            Me.hdfEnvioDatos.Value = 0
                            Exit Sub
                        End If
                    Else
                        dr("email") = ""
                    End If

                    objLookups = New Clookups
                    Dim dtComuna As DataTable
                    dtComuna = objLookups.RegionComunas(dr("cod_comuna"))
                    dr("cod_region") = dtComuna.Rows(0).Item(1)
                    dr("region") = dtComuna.Rows(0).Item(0)
                    'dr("cod_region") = CType(grdRow.FindControl("ddlRegion"), DropDownList).SelectedValue
                    'dr("region") = CType(grdRow.FindControl("lblRegion"), Label).Text
                    objLookups = Nothing
                    dr("existe") = CType(grdRow.FindControl("hdfExiste"), HiddenField).Value
                    dr("RutLNG") = RutUsrALng(CType(grdRow.FindControl("txtRUT"), TextBox).Text.Trim)
                    dt.Rows.Add(dr)
                Next

                dt.DefaultView.Sort = "RutLNG asc"
                dt.AcceptChanges()

                Me.txtNumParticipantes.Text = dt.Rows.Count
                objMantenedor.Participantes = dt
                objMantenedor.CodCurso = ViewState("CodCurso")
                objMantenedor.RutUsuario = objSession.Rut
                objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text)
                objMantenedor.Correlativo = Me.lblFolio.Text
                objMantenedor.NumParticipantes = Me.txtNumParticipantes.Text.Trim
                If Me.grdAlumnos.Rows.Count = 0 Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar al menos un participante');")
                    Me.hdfEnvioDatos.Value = 0
                    Exit Sub
                End If
                objMantenedor.GrabarPaso3()
                CargarDatos()
                wizardCurso.ActiveStepIndex = 3
            End If
            Me.hdfEnvioDatos.Value = 0
        Catch ex As Exception
            Me.hdfEnvioDatos.Value = 0
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:StepNextButton_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub FinishButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If ViewState("modo") = "insertar" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe realizar los pasos anteriores antes de continuar.');")
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If
            Me.hdfNumParticipantes.Value = Me.txtNumParticipantes.Text
            objMantenedor = New CMantenedorCursos
            objMantenedor.inicializarPaso4()
            objMantenedor.CostoOtic = Me.lblCostoOtic.Text
            objMantenedor.CtaCapSaldo = Me.lblCtaCapSaldo.Text
            If Me.txtCtaCap1.Text <> "" Then
                objMantenedor.CtaCap1 = Me.txtCtaCap1.Text
            Else
                objMantenedor.CtaCap1 = 0
            End If

            objMantenedor.ExcCapSaldo = Me.lblExcCapSaldo.Text
            If Me.txtExcCap1.Text <> "" Then
                objMantenedor.ExcCap1 = Me.txtExcCap1.Text
            Else
                objMantenedor.ExcCap1 = 0
            End If

            objMantenedor.BecasSaldo = Me.lblBecasSaldo.Text
            If Me.txtBecas.Text <> "" Then
                objMantenedor.Becas = Me.txtBecas.Text
            Else
                objMantenedor.Becas = 0
            End If
            If Me.txtTerceros.Text <> "" Then
                objMantenedor.Terceros = Me.txtTerceros.Text
            Else
                objMantenedor.Terceros = 0
            End If

            If CLng(Me.txtCtaCap1.Text) + CLng(Me.txtExcCap1.Text) + CLng(Me.txtTerceros.Text) <> Me.lblCostoOtic.Text Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe cubrir el total del costo otic.');")
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If

            objMantenedor.PorCubrir1 = Me.txtPorCubrir1.Text
            objMantenedor.VyT1 = Me.lblVyT1.Text
            objMantenedor.AdminCtaCap = Me.txtAdminCtaCap.Text
            objMantenedor.AporteReq1 = Me.txtAporteReq1.Text
            objMantenedor.GastoEmpresa = Me.lblGastoEmpresa.Text
            objMantenedor.TotalCurso = Me.txtTotalCurso.Text
            objMantenedor.TotalVyT = Me.lblTotalViatico.Text
            objMantenedor.CostoOticVyT = Me.lblCostoOticVyT.Text
            objMantenedor.GastoEmpresaVyT = Me.txtGastoEmpresaVyT.Text
            objMantenedor.CtaCapSaldo2 = Me.lblCtaCapSaldo2.Text
            If Me.txtCtaCap2.Text <> "" Then
                objMantenedor.CtaCap2 = Me.txtCtaCap2.Text
            Else
                objMantenedor.CtaCap2 = 0
            End If

            objMantenedor.ExcCapSaldo2 = Me.lblExcCapSaldo2.Text
            If Me.txtExcCap2.Text <> "" Then
                objMantenedor.ExcCap2 = Me.txtExcCap2.Text
            Else
                objMantenedor.ExcCap2 = 0
            End If

            objMantenedor.AdminCtaCapVyT = Me.txtAdminCtaCapVyT.Text
            objMantenedor.AporteReq2 = Me.txtAporteReq2.Text

            If Me.txtCtaCap2.Text > 0 And Me.txtExcCap2.Text > 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: No puede cargar los vyt a la cuenta de capaciatación y " _
                & "excedente de capacitación juntas. Agréguelo a una sola cuenta.');")
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If

            If CLng(Me.txtCtaCap2.Text) + CLng(Me.txtExcCap2.Text) <> CLng(Me.lblCostoOticVyT.Text) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe cubrir el total del costo otic de vyt.');")
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If




            Dim dt As New DataTable

            dt.Columns.Add("rut_benefactor")
            dt.Columns.Add("monto")
            dt.Columns.Add("cod_estado_solicitud")
            dt.Columns.Add("monto_adm")
            dt.Columns.Add("monto2")
            dt.Columns.Add("cta")
            dt.Columns.Add("cod_curso")
            Dim dr As DataRow
            Dim grdRow As GridViewRow
            For Each grdRow In Me.grdReparto.Rows
                dr = dt.NewRow

                dr("rut_benefactor") = CType(grdRow.FindControl("lblEmpBenef"), Label).Text
                dr("monto") = CType(grdRow.FindControl("txtMonto"), TextBox).Text
                dr("cod_estado_solicitud") = 1
                dr("monto_adm") = 0
                dr("monto2") = CType(grdRow.FindControl("txtMonto"), TextBox).Text
                dr("cta") = 2
                dr("cod_curso") = CType(grdRow.FindControl("hdfCodCurso"), HiddenField).Value

                dt.Rows.Add(dr)
            Next
            objMantenedor.Solicitudes = dt
            objMantenedor.CodCurso = ViewState("CodCurso")
            objMantenedor.RutUsuario = objSession.Rut
            objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text)
            objMantenedor.GrabarPaso4()
            CargarDatos()
            Me.hdfEnvioDatos.Value = 0
        Catch ex As Exception
            Me.hdfEnvioDatos.Value = 0
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:FinishButton_Click-->" & ex.Message)
        End Try
        Response.Redirect("ficha_curso_contratado.aspx?codCurso=" & ViewState("CodCurso"))
    End Sub

    Private Function ValidaHorario() As Boolean
        Try
            Dim i As Integer
            Dim j As Integer
            Dim inicioHora1 As String = ""
            Dim inicioHora2 As String = ""
            Dim inicioHora3 As String = ""
            Dim inicioHora4 As String = ""
            Dim inicioHora5 As String = ""
            Dim inicioHora6 As String = ""

            Dim inicioMin1 As String = ""
            Dim inicioMin2 As String = ""
            Dim inicioMin3 As String = ""
            Dim inicioMin4 As String = ""
            Dim inicioMin5 As String = ""
            Dim inicioMin6 As String = ""

            ValidaHorario = False

            For i = 1 To 7
                inicioHora1 = CType(Me.tablaHorario.FindControl("txtHora1_" & i), TextBox).Text.Trim
                inicioHora3 = CType(Me.tablaHorario.FindControl("txtHora3_" & i), TextBox).Text.Trim
                inicioHora5 = CType(Me.tablaHorario.FindControl("txtHora5_" & i), TextBox).Text.Trim


                inicioHora2 = CType(Me.tablaHorario.FindControl("txtHora2_" & i), TextBox).Text.Trim
                inicioHora4 = CType(Me.tablaHorario.FindControl("txtHora4_" & i), TextBox).Text.Trim
                inicioHora6 = CType(Me.tablaHorario.FindControl("txtHora6_" & i), TextBox).Text.Trim


                inicioMin1 = CType(Me.tablaHorario.FindControl("txtMin1_" & i), TextBox).Text.Trim
                inicioMin3 = CType(Me.tablaHorario.FindControl("txtMin3_" & i), TextBox).Text.Trim
                inicioMin5 = CType(Me.tablaHorario.FindControl("txtMin5_" & i), TextBox).Text.Trim

                inicioMin2 = CType(Me.tablaHorario.FindControl("txtMin2_" & i), TextBox).Text.Trim
                inicioMin4 = CType(Me.tablaHorario.FindControl("txtMin4_" & i), TextBox).Text.Trim
                inicioMin6 = CType(Me.tablaHorario.FindControl("txtMin6_" & i), TextBox).Text.Trim

                If inicioHora1 <> "" Then
                    ValidaHorario = True
                    If IsNumeric(inicioHora1) Then
                        If inicioHora1.Length = 1 Then
                            inicioHora1 = "0" & inicioHora1
                        End If
                        If inicioMin1 = "" Then
                            ViewState("MensajeError") = "alert('ATENCIÓN: Debe ingresar los minutos.');"
                            ValidaHorario = False
                            blnBloqueo = False
                            Exit Function
                        Else
                            If IsNumeric(inicioMin1) Then
                                If inicioHora2 <> "" Then
                                    ValidaHorario = True
                                    If IsNumeric(inicioHora2) Then
                                        If inicioHora2.Length = 1 Then
                                            inicioHora2 = "0" & inicioHora2
                                        End If
                                        If inicioMin2 = "" Then
                                            ViewState("MensajeError") = "alert('ATENCIÓN:  Debe ingresar los minutos.');"
                                            ValidaHorario = False
                                            blnBloqueo = False
                                            Exit Function
                                        Else
                                            If IsNumeric(inicioMin2) Then
                                                If inicioHora1 > inicioHora2 Then
                                                    ViewState("MensajeError") = "alert('ATENCIÓN:  la hora de inicio no puede ser mayor a la hora de fin');"
                                                    ValidaHorario = False
                                                    blnBloqueo = False
                                                    Exit Function
                                                End If
                                            Else
                                                ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                                ValidaHorario = False
                                                blnBloqueo = False
                                                Exit Function
                                            End If

                                        End If
                                    Else
                                        ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                        ValidaHorario = False
                                        blnBloqueo = False
                                        Exit Function
                                    End If

                                Else
                                    ViewState("MensajeError") = "alert('ATENCIÓN: Debe llenar correctamente el horario.');"
                                    ValidaHorario = False
                                    blnBloqueo = False
                                    Exit Function
                                End If
                            Else
                                ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                ValidaHorario = False
                                blnBloqueo = False
                                Exit Function
                            End If
                        End If
                    Else
                        ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                        ValidaHorario = False
                        blnBloqueo = False
                        Exit Function
                    End If
                End If

                If inicioHora3 <> "" Then
                    ValidaHorario = True
                    If IsNumeric(inicioHora3) Then
                        If inicioHora3.Length = 1 Then
                            inicioHora3 = "0" & inicioHora3
                        End If
                        If inicioMin3 = "" Then
                            ViewState("MensajeError") = "alert('ATENCIÓN: Debe ingresar los minutos.');"
                            ValidaHorario = False
                            blnBloqueo = False
                            Exit Function
                        Else
                            If IsNumeric(inicioMin3) Then
                                If inicioHora4 <> "" Then
                                    ValidaHorario = True
                                    If IsNumeric(inicioHora4) Then
                                        If inicioHora4.Length = 1 Then
                                            inicioHora4 = "0" & inicioHora4
                                        End If
                                        If inicioMin4 = "" Then
                                            ViewState("MensajeError") = "alert('ATENCIÓN:  Debe ingresar los minutos.');"
                                            ValidaHorario = False
                                            blnBloqueo = False
                                            Exit Function
                                        Else
                                            If IsNumeric(inicioMin4) Then
                                                If inicioHora3 > inicioHora4 Then
                                                    ViewState("MensajeError") = "alert('ATENCIÓN:  la hora de inicio no puede ser mayor a la hora de fin');"
                                                    ValidaHorario = False
                                                    blnBloqueo = False
                                                    Exit Function
                                                End If
                                            Else
                                                ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                                ValidaHorario = False
                                                blnBloqueo = False
                                                Exit Function
                                            End If

                                        End If
                                    Else
                                        ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                        ValidaHorario = False
                                        blnBloqueo = False
                                        Exit Function
                                    End If

                                Else
                                    ViewState("MensajeError") = "alert('ATENCIÓN: Debe llenar correctamente el horario.');"
                                    ValidaHorario = False
                                    blnBloqueo = False
                                    Exit Function
                                End If
                            Else
                                ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                ValidaHorario = False
                                blnBloqueo = False
                                Exit Function
                            End If
                        End If
                    Else
                        ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                        ValidaHorario = False
                        blnBloqueo = False
                        Exit Function
                    End If
                End If

                If inicioHora5 <> "" Then
                    ValidaHorario = True
                    If IsNumeric(inicioHora5) Then
                        If inicioHora5.Length = 1 Then
                            inicioHora5 = "0" & inicioHora5
                        End If
                        If inicioMin5 = "" Then
                            ViewState("MensajeError") = "alert('ATENCIÓN: Debe ingresar los minutos.');"
                            ValidaHorario = False
                            blnBloqueo = False
                            Exit Function
                        Else
                            If IsNumeric(inicioMin5) Then
                                If inicioHora6 <> "" Then
                                    ValidaHorario = True
                                    If IsNumeric(inicioHora6) Then
                                        If inicioHora6.Length = 1 Then
                                            inicioHora6 = "0" & inicioHora6
                                        End If
                                        If inicioMin2 = "" Then
                                            ViewState("MensajeError") = "alert('ATENCIÓN:  Debe ingresar los minutos.');"
                                            ValidaHorario = False
                                            blnBloqueo = False
                                            Exit Function
                                        Else
                                            If IsNumeric(inicioMin6) Then
                                                If inicioHora5 > inicioHora6 Then
                                                    ViewState("MensajeError") = "alert('ATENCIÓN:  la hora de inicio no puede ser mayor a la hora de fin');"
                                                    ValidaHorario = False
                                                    blnBloqueo = False
                                                    Exit Function
                                                End If
                                            Else
                                                ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                                ValidaHorario = False
                                                blnBloqueo = False
                                                Exit Function
                                            End If

                                        End If
                                    Else
                                        ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                        ValidaHorario = False
                                        blnBloqueo = False
                                        Exit Function
                                    End If

                                Else
                                    ViewState("MensajeError") = "alert('ATENCIÓN: Debe llenar correctamente el horario.');"
                                    ValidaHorario = False
                                    blnBloqueo = False
                                    Exit Function
                                End If
                            Else
                                ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                                ValidaHorario = False
                                blnBloqueo = False
                                Exit Function
                            End If
                        End If
                    Else
                        ViewState("MensajeError") = "alert('ATENCIÓN: Las horas y minutos del horario deben ser números.');"
                        ValidaHorario = False
                        blnBloqueo = False
                        Exit Function
                    End If
                End If

            Next
            If ValidaHorario = False Then
                ViewState("MensajeError") = "alert('ATENCIÓN: Debe ingresar al menos un horario para el curso.');"
                ValidaHorario = False
                blnBloqueo = False
                Exit Function
            End If
            If validaDiasHorario() = False Then
                ViewState("MensajeError") = "alert('ATENCIÓN: Los horarios ingresados no corresponden a los dias de ejecucion del curso.');"
                ValidaHorario = False
                blnBloqueo = False
                Exit Function
            End If

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:ValidaHorario-->" & ex.Message)
        End Try
    End Function

    Protected Function validaDiasHorario() As Boolean

        Dim fechaInicio As Date = Me.txtFechaInicio.Text
        Dim fechaFin As Date = Me.txtFechaFin.Text
        Dim lun As Integer = 0
        Dim mar As Integer = 0
        Dim mie As Integer = 0
        Dim jue As Integer = 0
        Dim vie As Integer = 0
        Dim sab As Integer = 0
        Dim dom As Integer = 0
        While fechaInicio <= fechaFin
            If fechaInicio.DayOfWeek = DayOfWeek.Monday Then
                lun = lun + 1
            ElseIf fechaInicio.DayOfWeek = DayOfWeek.Tuesday Then
                mar = mar + 1
            ElseIf fechaInicio.DayOfWeek = DayOfWeek.Wednesday Then
                mie = mie + 1
            ElseIf fechaInicio.DayOfWeek = DayOfWeek.Thursday Then
                jue = jue + 1
            ElseIf fechaInicio.DayOfWeek = DayOfWeek.Friday Then
                vie = vie + 1
            ElseIf fechaInicio.DayOfWeek = DayOfWeek.Saturday Then
                sab = sab + 1
            ElseIf fechaInicio.DayOfWeek = DayOfWeek.Sunday Then
                dom = dom + 1
            End If
            fechaInicio = fechaInicio.AddDays(1)
        End While

        If lun = 0 Then
            If txtHora1_1.Text <> "" Or txtHora2_1.Text <> "" Or txtHora3_1.Text <> "" Or txtHora4_1.Text <> "" Or txtHora5_1.Text <> "" _
            Or txtHora6_1.Text <> "" Then
                Return False
            End If
        End If
        If mar = 0 Then
            If txtHora1_2.Text <> "" Or txtHora2_2.Text <> "" Or txtHora3_2.Text <> "" Or txtHora4_2.Text <> "" Or txtHora5_2.Text <> "" _
                       Or txtHora6_2.Text <> "" Then
                Return False
            End If
        End If
        If mie = 0 Then
            If txtHora1_3.Text <> "" Or txtHora2_3.Text <> "" Or txtHora3_3.Text <> "" Or txtHora4_3.Text <> "" Or txtHora5_3.Text <> "" _
                       Or txtHora6_3.Text <> "" Then
                Return False
            End If
        End If
        If jue = 0 Then
            If txtHora1_4.Text <> "" Or txtHora2_4.Text <> "" Or txtHora3_4.Text <> "" Or txtHora4_4.Text <> "" Or txtHora5_4.Text <> "" _
                       Or txtHora6_4.Text <> "" Then
                Return False
            End If
        End If
        If vie = 0 Then
            If txtHora1_5.Text <> "" Or txtHora2_5.Text <> "" Or txtHora3_5.Text <> "" Or txtHora4_5.Text <> "" Or txtHora5_5.Text <> "" _
                       Or txtHora6_5.Text <> "" Then
                Return False
            End If
        End If
        If sab = 0 Then
            If txtHora1_6.Text <> "" Or txtHora2_6.Text <> "" Or txtHora3_6.Text <> "" Or txtHora4_6.Text <> "" Or txtHora5_6.Text <> "" _
                       Or txtHora6_6.Text <> "" Then
                Return False
            End If
        End If
        If dom = 0 Then
            If txtHora1_7.Text <> "" Or txtHora2_7.Text <> "" Or txtHora3_7.Text <> "" Or txtHora4_7.Text <> "" Or txtHora5_7.Text <> "" _
                    Or txtHora6_7.Text <> "" Then
                Return False
            End If
        End If

        Return True

    End Function

    Protected Sub btnRepetir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRepetir.Click
        Try
            If Not ValidaHorario() Then
                body.Attributes.Add("onload", ViewState("MensajeError"))
                wizardCurso.ActiveStepIndex = 1
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If
            Dim i As Integer
            Dim j As Integer

            Dim arr
            Dim strHorario As String
            For i = 1 To 7
                If CType(Me.tablaHorario.FindControl("txtHora1_" & i), TextBox).Text.Trim <> "" Then
                    strHorario = strHorario & "1_" & i & ";"
                End If
                If CType(Me.tablaHorario.FindControl("txtHora3_" & i), TextBox).Text.Trim <> "" Then
                    strHorario = strHorario & "3_" & i & ";"
                End If
                If CType(Me.tablaHorario.FindControl("txtHora5_" & i), TextBox).Text.Trim <> "" Then
                    strHorario = strHorario & "5_" & i & ";"
                End If

            Next
            If strHorario.Length > 0 Then
                strHorario = Left(strHorario, strHorario.Length - 1)
            End If
            arr = Split(strHorario, ";")

            For i = 1 To 7
                Dim bol As Boolean
                bol = CType(Me.tablaHorario.FindControl("chkDia" & i), CheckBox).Checked
                Select Case bol
                    Case True

                        CType(Me.tablaHorario.FindControl("txtHora1_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtMin1_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtHora2_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtMin2_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtHora3_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtMin3_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtHora4_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtMin4_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtHora5_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtMin5_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtHora6_" & i), TextBox).Text = ""
                        CType(Me.tablaHorario.FindControl("txtMin6_" & i), TextBox).Text = ""



                        Dim tamano As Integer = TamanoArreglo1(arr) - 1
                        For j = 0 To tamano
                            CType(Me.tablaHorario.FindControl("txtHora" & Left(arr(j), 1) & "_" & i), TextBox).Text = CType(Me.tablaHorario.FindControl("txtHora" & arr(j)), TextBox).Text
                            CType(Me.tablaHorario.FindControl("txtMin" & Left(arr(j), 1) & "_" & i), TextBox).Text = CType(Me.tablaHorario.FindControl("txtMin" & arr(j)), TextBox).Text


                            CType(Me.tablaHorario.FindControl("txtHora" & (CInt(Left(arr(j), 1)) + 1) & "_" & i), TextBox).Text = CType(Me.tablaHorario.FindControl("txtHora" & (CInt(Left(arr(j), 1)) + 1) & "_" & Right(arr(j), 1)), TextBox).Text
                            CType(Me.tablaHorario.FindControl("txtMin" & (CInt(Left(arr(j), 1)) + 1) & "_" & i), TextBox).Text = CType(Me.tablaHorario.FindControl("txtMin" & (CInt(Left(arr(j), 1)) + 1) & "_" & Right(arr(j), 1)), TextBox).Text

                        Next
                End Select

            Next


            Dim inicioHora1 As String = ""
            Dim inicioHora2 As String = ""
            Dim inicioHora3 As String = ""
            Dim inicioHora4 As String = ""
            Dim inicioHora5 As String = ""
            Dim inicioHora6 As String = ""

            Dim inicioMin1 As String = ""
            Dim inicioMin2 As String = ""
            Dim inicioMin3 As String = ""
            Dim inicioMin4 As String = ""
            Dim inicioMin5 As String = ""
            Dim inicioMin6 As String = ""

            Dim dtHorario As New DataTable
            dtHorario.Columns.Add("Dia")
            dtHorario.Columns.Add("DiaNombre")
            dtHorario.Columns.Add("HoraInicio")
            dtHorario.Columns.Add("HoraFin")
            dtHorario.Columns.Add("CodCurso")

            For i = 1 To 7
                inicioHora1 = CType(Me.tablaHorario.FindControl("txtHora1_" & i), TextBox).Text.Trim
                inicioHora3 = CType(Me.tablaHorario.FindControl("txtHora3_" & i), TextBox).Text.Trim
                inicioHora5 = CType(Me.tablaHorario.FindControl("txtHora5_" & i), TextBox).Text.Trim


                inicioHora2 = CType(Me.tablaHorario.FindControl("txtHora2_" & i), TextBox).Text.Trim
                inicioHora4 = CType(Me.tablaHorario.FindControl("txtHora4_" & i), TextBox).Text.Trim
                inicioHora6 = CType(Me.tablaHorario.FindControl("txtHora6_" & i), TextBox).Text.Trim


                inicioMin1 = CType(Me.tablaHorario.FindControl("txtMin1_" & i), TextBox).Text.Trim
                inicioMin3 = CType(Me.tablaHorario.FindControl("txtMin3_" & i), TextBox).Text.Trim
                inicioMin5 = CType(Me.tablaHorario.FindControl("txtMin5_" & i), TextBox).Text.Trim

                inicioMin2 = CType(Me.tablaHorario.FindControl("txtMin2_" & i), TextBox).Text.Trim
                inicioMin4 = CType(Me.tablaHorario.FindControl("txtMin4_" & i), TextBox).Text.Trim
                inicioMin6 = CType(Me.tablaHorario.FindControl("txtMin6_" & i), TextBox).Text.Trim

                Dim strDia As String = ""
                Select Case i
                    Case 1
                        strDia = "Lunes"
                    Case 2
                        strDia = "Martes"
                    Case 3
                        strDia = "Miercoles"
                    Case 4
                        strDia = "Jueves"
                    Case 5
                        strDia = "viernes"
                    Case 6
                        strDia = "Sabado"
                    Case 7
                        strDia = "Domingo"
                End Select
                Dim dr As DataRow
                If inicioHora1 <> "" Then
                    dr = dtHorario.NewRow
                    dr("Dia") = i
                    dr("HoraInicio") = LlenaCarIzq(inicioHora1, 2, "0") & ":" & LlenaCarIzq(inicioMin1, 2, "0")
                    dr("HoraFin") = LlenaCarIzq(inicioHora2, 2, "0") & ":" & LlenaCarIzq(inicioMin2, 2, "0")
                    dr("CodCurso") = ViewState("CodCurso")
                    dr("DiaNombre") = strDia
                    dtHorario.Rows.Add(dr)
                End If

                If inicioHora3 <> "" Then
                    dr = dtHorario.NewRow
                    dr("Dia") = i
                    dr("HoraInicio") = LlenaCarIzq(inicioHora3, 2, "0") & ":" & LlenaCarIzq(inicioMin3, 2, "0")
                    dr("HoraFin") = LlenaCarIzq(inicioHora4, 2, "0") & ":" & LlenaCarIzq(inicioMin4, 2, "0")
                    dr("CodCurso") = ViewState("CodCurso")
                    dr("DiaNombre") = strDia
                    dtHorario.Rows.Add(dr)
                End If

                If inicioHora5 <> "" Then
                    dr = dtHorario.NewRow
                    dr("Dia") = i
                    dr("HoraInicio") = LlenaCarIzq(inicioHora5, 2, "0") & ":" & LlenaCarIzq(inicioMin5, 2, "0")
                    dr("HoraFin") = LlenaCarIzq(inicioHora6, 2, "0") & ":" & LlenaCarIzq(inicioMin6, 2, "0")
                    dr("CodCurso") = ViewState("CodCurso")
                    dr("DiaNombre") = strDia
                    dtHorario.Rows.Add(dr)
                End If

            Next
            ViewState("Horario") = dtHorario

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnRepetir_Click-->" & ex.Message)
        End Try

    End Sub

    Public Sub CargaHorario()
        Try
            Dim i As Integer
            Dim j As Integer
            Dim inicioHora1 As String = ""
            Dim inicioHora2 As String = ""
            Dim inicioHora3 As String = ""
            Dim inicioHora4 As String = ""
            Dim inicioHora5 As String = ""
            Dim inicioHora6 As String = ""

            Dim inicioMin1 As String = ""
            Dim inicioMin2 As String = ""
            Dim inicioMin3 As String = ""
            Dim inicioMin4 As String = ""
            Dim inicioMin5 As String = ""
            Dim inicioMin6 As String = ""
            Dim dtHorario As New DataTable
            dtHorario.Columns.Add("Dia")
            dtHorario.Columns.Add("DiaNombre")
            dtHorario.Columns.Add("HoraInicio")
            dtHorario.Columns.Add("HoraFin")
            dtHorario.Columns.Add("CodCurso")

            For i = 1 To 7
                inicioHora1 = CType(Me.tablaHorario.FindControl("txtHora1_" & i), TextBox).Text.Trim
                inicioHora3 = CType(Me.tablaHorario.FindControl("txtHora3_" & i), TextBox).Text.Trim
                inicioHora5 = CType(Me.tablaHorario.FindControl("txtHora5_" & i), TextBox).Text.Trim


                inicioHora2 = CType(Me.tablaHorario.FindControl("txtHora2_" & i), TextBox).Text.Trim
                inicioHora4 = CType(Me.tablaHorario.FindControl("txtHora4_" & i), TextBox).Text.Trim
                inicioHora6 = CType(Me.tablaHorario.FindControl("txtHora6_" & i), TextBox).Text.Trim


                inicioMin1 = CType(Me.tablaHorario.FindControl("txtMin1_" & i), TextBox).Text.Trim
                inicioMin3 = CType(Me.tablaHorario.FindControl("txtMin3_" & i), TextBox).Text.Trim
                inicioMin5 = CType(Me.tablaHorario.FindControl("txtMin5_" & i), TextBox).Text.Trim

                inicioMin2 = CType(Me.tablaHorario.FindControl("txtMin2_" & i), TextBox).Text.Trim
                inicioMin4 = CType(Me.tablaHorario.FindControl("txtMin4_" & i), TextBox).Text.Trim
                inicioMin6 = CType(Me.tablaHorario.FindControl("txtMin6_" & i), TextBox).Text.Trim

                Dim strDia As String = ""
                Select Case i
                    Case 1
                        strDia = "Lunes"
                    Case 2
                        strDia = "Martes"
                    Case 3
                        strDia = "Miercoles"
                    Case 4
                        strDia = "Jueves"
                    Case 5
                        strDia = "viernes"
                    Case 6
                        strDia = "Sabado"
                    Case 7
                        strDia = "Domingo"
                End Select
                Dim dr As DataRow
                If inicioHora1 <> "" Then
                    dr = dtHorario.NewRow
                    dr("Dia") = i
                    dr("HoraInicio") = LlenaCarIzq(inicioHora1, 2, "0") & ":" & LlenaCarIzq(inicioMin1, 2, "0")
                    dr("HoraFin") = LlenaCarIzq(inicioHora2, 2, "0") & ":" & LlenaCarIzq(inicioMin2, 2, "0")
                    dr("CodCurso") = ViewState("CodCurso")
                    dr("DiaNombre") = strDia
                    dtHorario.Rows.Add(dr)
                End If

                If inicioHora3 <> "" Then
                    dr = dtHorario.NewRow
                    dr("Dia") = i
                    dr("HoraInicio") = LlenaCarIzq(inicioHora3, 2, "0") & ":" & LlenaCarIzq(inicioMin3, 2, "0")
                    dr("HoraFin") = LlenaCarIzq(inicioHora4, 2, "0") & ":" & LlenaCarIzq(inicioMin4, 2, "0")
                    dr("CodCurso") = ViewState("CodCurso")
                    dr("DiaNombre") = strDia
                    dtHorario.Rows.Add(dr)
                End If

                If inicioHora5 <> "" Then
                    dr = dtHorario.NewRow
                    dr("Dia") = i
                    dr("HoraInicio") = LlenaCarIzq(inicioHora5, 2, "0") & ":" & LlenaCarIzq(inicioMin5, 2, "0")
                    dr("HoraFin") = LlenaCarIzq(inicioHora6, 2, "0") & ":" & LlenaCarIzq(inicioMin6, 2, "0")
                    dr("CodCurso") = ViewState("CodCurso")
                    dr("DiaNombre") = strDia
                    dtHorario.Rows.Add(dr)
                End If

            Next
            objMantenedor.dthorario = dtHorario
            ' ''Dim dt As New DataTable
            ' ''dt.Columns.Add("DiaNombre")
            ' ''dt.Columns.Add("Dia")
            ' ''dt.Columns.Add("HoraInicio")
            ' ''dt.Columns.Add("HoraFin")
            ' ''dt.Columns.Add("CodCurso")
            ' ''Dim dr As DataRow
            ' ''Dim grdRow As GridViewRow
            '' ''For Each grdRow In Me.grdHorario.Rows
            '' ''    dr = dt.NewRow
            '' ''    dr("Dia") = CType(grdRow.FindControl("hdfDiaValor"), HiddenField).Value
            '' ''    dr("HoraInicio") = grdRow.Cells(1).Text
            '' ''    dr("HoraFin") = grdRow.Cells(2).Text
            '' ''    dr("CodCurso") = CType(grdRow.FindControl("hdfCodCurso"), HiddenField).Value
            '' ''    dt.Rows.Add(dr)
            '' ''Next
            ' ''objMantenedor.dthorario = dt
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:CargaHorario-->" & ex.Message)
        End Try
    End Sub

    Public Function ValidaDatosPaso1() As Boolean

        Try
            ValidaDatosPaso1 = True
            If Not objMantenedor.ExisteEmpresa(RutUsrALng(Me.txtRutEmpresa.Text.Trim)) Then
                ViewState("MensajeError") = "alert('ATENCIÓN: El Rut de empresa no se encuentra en nuestros registros.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            If Not Me.txtNumParticipantes.Text.Trim > 0 Then
                ViewState("MensajeError") = "alert('ATENCIÓN: El número de participantes debe ser mayor a 0.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            If Not objMantenedor.ExisteCursoSence(Me.txtCodSence.Text.Trim) Then
                ViewState("MensajeError") = "alert('ATENCIÓN: El código Sence no se encuentra en nuestros registros.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            objMantenedor.CodSence = Me.txtCodSence.Text.Trim
            objMantenedor.InicializarCursoSence()
            If Not objMantenedor.CursoSence.Elearning Then
                If objMantenedor.CursoSence.NumMaxParticip < CLng(Me.txtNumParticipantes.Text) Then
                    ViewState("MensajeError") = "alert('ATENCIÓN: El número de participantes supera los permitidos por Sence.');"
                    ValidaDatosPaso1 = False
                    blnBloqueo = False
                    Exit Function
                End If
            End If
            If CDbl(Me.txtHrsComp.Text.Trim) >= (objMantenedor.CursoSence.DurCursoPractico + objMantenedor.CursoSence.DurCursoTeorico + objMantenedor.CursoSence.DurCurElearning) Then
                ViewState("MensajeError") = "alert('ATENCIÓN: Las horas complementarias no debe ser mayor ó igual al total de horas del curso SENCE');"
                ValidaDatosPaso1 = False
                blnBloqueo = False
                Exit Function
            End If

            'If Me.ddlModalidad.SelectedValue <> 2 Then
            '    If objMantenedor.CursoSence.ValorCurso > 0 Then
            '        If (((CLng(objMantenedor.CursoSence.ValorCurso) / CLng(objMantenedor.CursoSence.NumMaxParticip)) * CLng(Me.txtNumParticipantes.Text)) < CLng(Me.txtValorCurso.Text)) Then
            '            ViewState("advertencia2") = "alert('ATENCIÓN: El valor total del curso supera al valor indicado en Sence.');"
            '        Else
            '            ViewState("advertencia2") = ""
            '        End If
            '    Else
            '        ViewState("advertencia2") = ""
            '    End If
            'Else
            '    ViewState("advertencia2") = ""
            'End If

            'If Me.ddlModalidad.SelectedValue <> 2 Then
            If objMantenedor.CursoSence.ValorCurso > 0 Then
                If (((CLng(objMantenedor.CursoSence.ValorCurso) / CLng(objMantenedor.CursoSence.NumMaxParticip)) * CLng(Me.txtNumParticipantes.Text)) < CLng(Me.txtValorCurso.Text)) Then
                    ViewState("MensajeError") = "alert('ATENCIÓN: El valor total del curso supera al valor indicado en Sence.');"
                    ValidaDatosPaso1 = False
                    blnBloqueo = True
                    Exit Function
                End If
            End If
            'End If

            If Not EsFechaValidaVB(Me.txtFechaInicio.Text.Trim) Then
                ViewState("MensajeError") = "alert('ATENCIÓN: El formato de fecha de inicio debe ser dd/mm/aaaa');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            If Not EsFechaValidaVB(Me.txtFechaFin.Text.Trim) Then
                ViewState("MensajeError") = "alert('ATENCIÓN: El formato de fecha de fin debe ser dd/mm/aaaa');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If

            If ViewState("modo") = "insertar" Then
                Dim fechaInicio As Date
                fechaInicio = Me.txtFechaInicio.Text.Trim
                If DateDiff(DateInterval.Day, Now.Date, fechaInicio) < 2 Then
                    ViewState("MensajeError") = "alert('ATENCIÓN:El curso debe ser inscrito a los menos 2 días antes que comience la actividad.');"
                    ValidaDatosPaso1 = False
                    blnBloqueo = True
                    Exit Function
                End If
            End If


            'If Me.calFechaInicio.SelectedDate.Year <> Me.ddlAgnoInicio.SelectedValue Then
            If Right(Me.txtFechaInicio.Text.Trim, 4) <> Me.ddlAgnoInicio.SelectedValue Then
                ViewState("MensajeError") = "alert('ATENCIÓN: El año de inicio y la fecha de inicio no concuerdan.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            'If Me.calFechaInicio.SelectedDate > Me.calFechaFin.SelectedDate Then
            If FechaUsrAVb(Me.txtFechaInicio.Text.Trim) > FechaUsrAVb(Me.txtFechaFin.Text.Trim) Then
                ViewState("MensajeError") = "alert('ATENCIÓN: La fecha de inicio no puede ser mayor a la de fin.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            'If Me.calFechaFin.SelectedDate.Year > Me.calFechaInicio.SelectedDate.Year + 1 Then
            If FechaUsrAVb(Me.txtFechaFin.Text.Trim).Year > FechaUsrAVb(Me.txtFechaInicio.Text.Trim).Year + 1 Then
                ViewState("MensajeError") = "alert('ATENCIÓN: La fecha de término debe estar a lo más dentro del año siguiente al de la fecha de inicio.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            ' If Me.calFechaFin.SelectedDate.Year > Me.calFechaInicio.SelectedDate.Year And Me.txtHrsComp.Text = 0 Then
            If FechaUsrAVb(Me.txtFechaFin.Text.Trim).Year > FechaUsrAVb(Me.txtFechaInicio.Text.Trim).Year And Me.txtHrsComp.Text = 0 Then
                ViewState("MensajeError") = "alert('ATENCIÓN: Si el año de la fecha de fin es mayor al de la fecha de inicio, la cantidad de horas complementarias debe ser mayor a 0.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If

            'If Me.calFechaInicio.SelectedDate = Now.Day + 1 & "/" & Now.Month & "/" & Now.Year Then
            Dim hora As Integer
            hora = Now.Hour
            Dim minutos As Integer
            minutos = Now.Minute
            If objSession.EsCliente Then
                If hora = 17 And minutos > 30 Then
                    ViewState("MensajeError") = "alert('ATENCIÓN: Este curso debería haber sido ingresado antes del " + Now.Day.ToString + "/" + Now.Month.ToString + "/" + Now.Year.ToString + " a las 17:30 hrs.\nPor favor comuníquese con Operaciones para confirmar el ingreso del curso.');"
                    ValidaDatosPaso1 = False
                    blnBloqueo = True
                    Exit Function
                ElseIf hora > 17 Then
                    ViewState("MensajeError") = "alert('ATENCIÓN: Este curso debería haber sido ingresado antes del a las " + Now.Day.ToString + "/" + Now.Month.ToString + "/" + Now.Year.ToString + " 17:30 hrs.\nPor favor comuníquese con Operaciones para confirmar el ingreso del curso.');"
                    ValidaDatosPaso1 = False
                    blnBloqueo = True
                    Exit Function
                End If
            End If
            If Not IsNumeric(Replace(Me.txtValorHora.Text, ".", ",")) Then
                ViewState("MensajeError") = "alert('ATENCIÓN: El formato del valor hora sence no es correcto.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            Else
                If Not Me.txtValorHora.Text > 0 Then
                    ViewState("MensajeError") = "alert('ATENCIÓN: El valor hora debe ser mayor a cero.');"
                    ValidaDatosPaso1 = False
                    blnBloqueo = True
                    Exit Function
                End If
            End If

            objMantenedor = New CMantenedorCursos

            objMantenedor.CodSence = Me.txtCodSence.Text
            Dim HorasSence As String
            Dim dias As Integer
            Dim TotalHoraDia As Integer
            HorasSence = objMantenedor.CalculaHorasSence()
            'dias = DateDiff(DateInterval.Day, calFechaInicio.SelectedDate, calFechaFin.SelectedDate)
            dias = DateDiff(DateInterval.Day, FechaUsrAVb(Me.txtFechaInicio.Text.Trim), FechaUsrAVb(Me.txtFechaFin.Text.Trim))
            If dias = 0 Then
                TotalHoraDia = HorasSence
            Else
                TotalHoraDia = HorasSence / dias
            End If

            If objSession.EsCliente Then
                If TotalHoraDia > 8 Then
                    ViewState("advertencia") = "alert('ATENCIÓN: Esta ingresando un Curso con mas de 8 horas diarias');"
                Else
                    ViewState("advertencia") = ""
                End If
            Else
                ViewState("advertencia") = ""
            End If


            If Me.txtValorCurso.Text.Trim = "" Or Me.txtDescuento.Text.Trim = "" Then
                ViewState("MensajeError") = "alert('ATENCIÓN: Los campos 'Valor Curso' y 'Descuento' no deben estar vacios.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            If Not Me.txtValorCurso.Text.Trim > 0 Then
                ViewState("MensajeError") = "alert('ATENCIÓN: EL valor curso debe ser mayor que 0.');"
                ValidaDatosPaso1 = False
                blnBloqueo = True
                Exit Function
            End If
            If txtPorcAdmin.Visible Then
                Dim porcAdmin As Double = CDbl(Replace(txtPorcAdmin.Text, ".", ","))
                Dim MAXPORCADMIN As Double = CDbl(Parametros.p_MAXPORCADMIN)
                If porcAdmin > MAXPORCADMIN Then
                    ViewState("MensajeError") = "alert('ATENCIÓN: EL porcentaje de administración no debe ser mayor a " & Parametros.p_MAXPORCADMIN & ".');"
                    ValidaDatosPaso1 = False
                    blnBloqueo = True
                    Exit Function
                End If
            End If
            Return ValidaDatosPaso1
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:ValidaDatosPaso1-->" & ex.Message)
        End Try
    End Function

    Public Sub CalculaValorFinal()
        Try
            If Me.txtValorCurso.Text = "" Then
                Me.txtValorCurso.Text = 0
            End If
            If Me.txtDescuento.Text = "" Then
                Me.txtDescuento.Text = 0
            End If
            If Me.rdbDescMonto.Checked Then
                Me.txtValorMasDescuento.Text = Me.txtValorCurso.Text - Me.txtDescuento.Text
            ElseIf Me.rdbDescPorcentaje.Checked Then
                Me.txtValorMasDescuento.Text = Me.txtValorCurso.Text - (Me.txtValorCurso.Text * Me.txtDescuento.Text / 100)
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:CalculaValorFinal-->" & ex.Message)
        End Try
    End Sub

    Protected Sub rdbDescMonto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDescMonto.CheckedChanged
        Try
            CalculaValorFinal()
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:rdbDescMonto_CheckedChanged-->" & ex.Message)
        End Try
    End Sub

    Protected Sub rdbDescPorcentaje_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDescPorcentaje.CheckedChanged
        Try
            CalculaValorFinal()
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:rdbDescPorcentaje_CheckedChanged-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnTotal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTotal.Click
        Try
            CalculaValorFinal()
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnTotal_Click-->" & ex.Message)
        End Try
    End Sub

    Public Sub LlenaHorario()
        Try
            Dim dtHorario As New DataTable
            dtHorario = ViewState("dtHorario")

            Dim strDia As String = ""
            Dim dr As DataRow
            For Each dr In dtHorario.Rows
                If CType(Me.tablaHorario.FindControl("txtHora1_" & dr("Dia").ToString.Trim), TextBox).Text.Trim = "" Then
                    CType(Me.tablaHorario.FindControl("txtHora1_" & dr("Dia").ToString.Trim), TextBox).Text = Left(dr("HoraInicio"), 2)
                    CType(Me.tablaHorario.FindControl("txtMin1_" & dr("Dia").ToString.Trim), TextBox).Text = Right(dr("HoraInicio"), 2)

                    CType(Me.tablaHorario.FindControl("txtHora2_" & dr("Dia").ToString.Trim), TextBox).Text = Left(dr("HoraFin"), 2)
                    CType(Me.tablaHorario.FindControl("txtMin2_" & dr("Dia").ToString.Trim), TextBox).Text = Right(dr("HoraFin"), 2)
                ElseIf CType(Me.tablaHorario.FindControl("txtHora3_" & dr("Dia").ToString.Trim), TextBox).Text.Trim = "" Then
                    CType(Me.tablaHorario.FindControl("txtHora3_" & dr("Dia").ToString.Trim), TextBox).Text = Left(dr("HoraInicio"), 2)
                    CType(Me.tablaHorario.FindControl("txtMin3_" & dr("Dia").ToString.Trim), TextBox).Text = Right(dr("HoraInicio"), 2)

                    CType(Me.tablaHorario.FindControl("txtHora4_" & dr("Dia").ToString.Trim), TextBox).Text = Left(dr("HoraFin"), 2)
                    CType(Me.tablaHorario.FindControl("txtMin4_" & dr("Dia").ToString.Trim), TextBox).Text = Right(dr("HoraFin"), 2)
                ElseIf CType(Me.tablaHorario.FindControl("txtHora5_" & dr("Dia").ToString.Trim), TextBox).Text.Trim = "" Then
                    CType(Me.tablaHorario.FindControl("txtHora5_" & dr("Dia").ToString.Trim), TextBox).Text = Left(dr("HoraInicio"), 2)
                    CType(Me.tablaHorario.FindControl("txtMin5_" & dr("Dia").ToString.Trim), TextBox).Text = Right(dr("HoraInicio"), 2)

                    CType(Me.tablaHorario.FindControl("txtHora6_" & dr("Dia").ToString.Trim), TextBox).Text = Left(dr("HoraFin"), 2)
                    CType(Me.tablaHorario.FindControl("txtMin6_" & dr("Dia").ToString.Trim), TextBox).Text = Right(dr("HoraFin"), 2)
                End If
            Next
            CantidadHoras()

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:LlenaHorario-->" & ex.Message)
        End Try
    End Sub

    Public Sub limpiaHorario()
        Try
            Dim dtHorario As New DataTable
            dtHorario = ViewState("dtHorario")
            Dim dr As DataRow

            For Each dr In dtHorario.Rows
                CType(Me.tablaHorario.FindControl("txtHora1_" & dr("Dia").ToString.Trim), TextBox).Text = ""
                CType(Me.tablaHorario.FindControl("txtMin1_" & dr("Dia").ToString.Trim), TextBox).Text = ""

                CType(Me.tablaHorario.FindControl("txtHora2_" & dr("Dia").ToString.Trim), TextBox).Text = ""
                CType(Me.tablaHorario.FindControl("txtMin2_" & dr("Dia").ToString.Trim), TextBox).Text = ""

                CType(Me.tablaHorario.FindControl("txtHora3_" & dr("Dia").ToString.Trim), TextBox).Text = ""
                CType(Me.tablaHorario.FindControl("txtMin3_" & dr("Dia").ToString.Trim), TextBox).Text = ""

                CType(Me.tablaHorario.FindControl("txtHora4_" & dr("Dia").ToString.Trim), TextBox).Text = ""
                CType(Me.tablaHorario.FindControl("txtMin4_" & dr("Dia").ToString.Trim), TextBox).Text = ""

                CType(Me.tablaHorario.FindControl("txtHora5_" & dr("Dia").ToString.Trim), TextBox).Text = ""
                CType(Me.tablaHorario.FindControl("txtMin5_" & dr("Dia").ToString.Trim), TextBox).Text = ""

                CType(Me.tablaHorario.FindControl("txtHora6_" & dr("Dia").ToString.Trim), TextBox).Text = ""
                CType(Me.tablaHorario.FindControl("txtMin6_" & dr("Dia").ToString.Trim), TextBox).Text = ""
            Next

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:limpiaHorario-->" & ex.Message)
        End Try
    End Sub

    Public Sub atributosHorario()
        Me.txtHora1_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora2_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora3_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora4_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora5_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora6_1.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtHora1_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora2_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora3_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora4_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora5_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora6_2.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtHora1_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora2_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora3_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora4_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora5_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora6_3.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtHora1_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora2_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora3_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora4_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora5_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora6_4.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtHora1_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora2_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora3_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora4_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora5_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora6_5.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtHora1_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora2_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora3_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora4_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora5_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora6_6.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtHora1_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora2_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora3_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora4_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora5_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtHora6_7.Attributes.Add("onblur", "CantidadHoras();")

        '_______minutos___________________________________________

        Me.txtMin1_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin2_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin3_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin4_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin5_1.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin6_1.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtMin1_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin2_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin3_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin4_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin5_2.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin6_2.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtMin1_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin2_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin3_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin4_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin5_3.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin6_3.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtMin1_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin2_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin3_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin4_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin5_4.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin6_4.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtMin1_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin2_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin3_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin4_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin5_5.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin6_5.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtMin1_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin2_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin3_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin4_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin5_6.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin6_6.Attributes.Add("onblur", "CantidadHoras();")

        Me.txtMin1_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin2_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin3_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin4_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin5_7.Attributes.Add("onblur", "CantidadHoras();")
        Me.txtMin6_7.Attributes.Add("onblur", "CantidadHoras();")
    End Sub

    Public Sub CantidadHoras()
        Try
            If ValidaHorario() Then
                Dim dt As New DataTable
                dt.Columns.Add("dia")
                dt.Columns.Add("hora_inicio")
                dt.Columns.Add("hora_fin")
                Dim dr As DataRow
                For i As Integer = 1 To 7
                    For e As Integer = 1 To 6
                        If CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text <> "" And _
                        CType(Me.tablaHorario.FindControl("txtMin" & e & "_" & i), TextBox).Text <> "" And _
                        IsNumeric(CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text) And _
                        IsNumeric(CType(Me.tablaHorario.FindControl("txtMin" & e & "_" & i), TextBox).Text) Then
                            If CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text.Trim.Length = 1 Then
                                CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text = "0" & CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text
                            ElseIf CType(Me.tablaHorario.FindControl("txtMin" & e & "_" & i), TextBox).Text.Trim.Length = 1 Then
                                CType(Me.tablaHorario.FindControl("txtMin" & e & "_" & i), TextBox).Text = "0" & CType(Me.tablaHorario.FindControl("txtMin" & e & "_" & i), TextBox).Text
                            End If
                            If e Mod 2 = 0 Then
                                If CType(Me.tablaHorario.FindControl("txtHora" & e - 1 & "_" & i), TextBox).Text.Trim <> "" _
                                And IsNumeric(CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text.Trim) Then
                                    dr("hora_fin") = CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text & ":" & CType(Me.tablaHorario.FindControl("txtMin" & e & "_" & i), TextBox).Text
                                    dt.Rows.Add(dr)
                                End If
                            Else
                                dr = dt.NewRow
                                dr("dia") = i
                                dr("hora_inicio") = CType(Me.tablaHorario.FindControl("txtHora" & e & "_" & i), TextBox).Text & ":" & CType(Me.tablaHorario.FindControl("txtMin" & e & "_" & i), TextBox).Text
                            End If
                        End If
                    Next
                Next

                Dim fechaInicio As Date = Me.txtFechaInicio.Text
                Dim fechaFin As Date = Me.txtFechaFin.Text
                Dim lun As Integer = 0
                Dim mar As Integer = 0
                Dim mie As Integer = 0
                Dim jue As Integer = 0
                Dim vie As Integer = 0
                Dim sab As Integer = 0
                Dim dom As Integer = 0
                Dim horasLun As Integer = 0
                Dim horasMar As Integer = 0
                Dim horasMie As Integer = 0
                Dim horasJue As Integer = 0
                Dim horasVie As Integer = 0
                Dim horasSab As Integer = 0
                Dim horasDom As Integer = 0
                Dim minLun As Integer = 0
                Dim minMar As Integer = 0
                Dim minMie As Integer = 0
                Dim minJue As Integer = 0
                Dim minVie As Integer = 0
                Dim minSab As Integer = 0
                Dim minDom As Integer = 0
                While fechaInicio <= fechaFin
                    If fechaInicio.DayOfWeek = DayOfWeek.Monday Then
                        lun = lun + 1
                    ElseIf fechaInicio.DayOfWeek = DayOfWeek.Tuesday Then
                        mar = mar + 1
                    ElseIf fechaInicio.DayOfWeek = DayOfWeek.Wednesday Then
                        mie = mie + 1
                    ElseIf fechaInicio.DayOfWeek = DayOfWeek.Thursday Then
                        jue = jue + 1
                    ElseIf fechaInicio.DayOfWeek = DayOfWeek.Friday Then
                        vie = vie + 1
                    ElseIf fechaInicio.DayOfWeek = DayOfWeek.Saturday Then
                        sab = sab + 1
                    ElseIf fechaInicio.DayOfWeek = DayOfWeek.Sunday Then
                        dom = dom + 1
                    End If
                    fechaInicio = fechaInicio.AddDays(1)
                End While

                Dim dr2 As DataRow

                For Each dr2 In dt.Rows
                    Select Case dr2("dia")
                        Case 1
                            horasLun = horasLun + Left(dr2("hora_fin"), 2) - Left(dr2("hora_inicio"), 2)
                            minLun = minLun + Right(dr2("hora_fin"), 2) - Right(dr2("hora_inicio"), 2)
                        Case 2
                            horasMar = horasMar + Left(dr2("hora_fin"), 2) - Left(dr2("hora_inicio"), 2)
                            minMar = minMar + Right(dr2("hora_fin"), 2) - Right(dr2("hora_inicio"), 2)
                        Case 3
                            horasMie = horasMie + Left(dr2("hora_fin"), 2) - Left(dr2("hora_inicio"), 2)
                            minMie = minMie + Right(dr2("hora_fin"), 2) - Right(dr2("hora_inicio"), 2)
                        Case 4
                            horasJue = horasJue + Left(dr2("hora_fin"), 2) - Left(dr2("hora_inicio"), 2)
                            minJue = minJue + Right(dr2("hora_fin"), 2) - Right(dr2("hora_inicio"), 2)
                        Case 5
                            horasVie = horasVie + Left(dr2("hora_fin"), 2) - Left(dr2("hora_inicio"), 2)
                            minVie = minVie + Right(dr2("hora_fin"), 2) - Right(dr2("hora_inicio"), 2)
                        Case 6
                            horasSab = horasSab + Left(dr2("hora_fin"), 2) - Left(dr2("hora_inicio"), 2)
                            minSab = minSab + Right(dr2("hora_fin"), 2) - Right(dr2("hora_inicio"), 2)
                        Case 7
                            horasDom = horasDom + Left(dr2("hora_fin"), 2) - Left(dr2("hora_inicio"), 2)
                            minDom = minDom + Right(dr2("hora_fin"), 2) - Right(dr2("hora_inicio"), 2)
                    End Select
                Next

                horasLun = ((horasLun * 60) * lun) + (minLun * lun)
                horasMar = ((horasMar * 60) * mar) + (minMar * mar)
                horasMie = ((horasMie * 60) * mie) + (minMie * mie)
                horasJue = ((horasJue * 60) * jue) + (minJue * jue)
                horasVie = ((horasVie * 60) * vie) + (minVie * vie)
                horasSab = ((horasSab * 60) * sab) + (minSab * sab)
                horasDom = ((horasDom * 60) * dom) + (minDom * dom)
                Dim total As Long
                total = horasLun + horasMar + horasMie + horasJue + horasVie + horasSab + horasDom
                Me.lblTotalHoras.Text = String.Format("{0:N0}'{1:N0} h'm", total / 60, total Mod 60)
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas/mantenedor_curso.aspx.vb --> CantidadHoras() " & ex.Message)
        End Try


    End Sub

    Private Sub CargarAlumno(Optional ByVal bol As Boolean = True)
        Try
            Dim mFilas, mb As Long
            If ViewState("CargaMasiva") = "no" Then
                If Me.txtRutAlumno.Text = "" Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un Rut de alumno.');")
                    Exit Sub
                End If

                'If Me.txtNumParticipantes.Text.Trim = "" Then
                '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar primero los datos del curso.');")
                '    Exit Sub
                'End If
                Dim objCurso As New CCursoContratado
                If objCurso.ExisteAlumnoEnCurso(RutUsrALng(Me.txtRutAlumno.Text.Trim), Me.txtCodSence.Text.Trim, Me.ddlAgnoInicio.SelectedValue, RutUsrALng(Me.txtRutEmpresa.Text.Trim)) Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El Alumno ingresado con rut " & Me.txtRutAlumno.Text.Trim & ", no puede realizar el mismo curso 3 veces con la misma empresa');")
                    Exit Sub
                End If

                'If Me.txtNumParticipantes.Text = Me.grdAlumnos.Rows.Count Then
                '    body.Attributes.Add("onload", "alert('ATENCIÓN: Ya se ha ingresado el máximo de alumnos permitido para este curso.');")
                '    Exit Sub
                'End If
            Else
                txtRutAlumno.Text = ViewState("RutParticipante")
            End If

            objMantenedor = New CMantenedorCursos
            objMantenedor.inicializarPaso3()
            objMantenedor.ConsultaAlumno(RutUsrALng(Me.txtRutAlumno.Text))

            'Verificamos si el Rut ya existe en la Grilla
            If bol Then
                If Not grdAlumnos Is Nothing Then
                    For mFilas = 0 To grdAlumnos.Rows.Count - 1
                        'Comparamos el Rut del Nuevo Participante
                        'con los que están en la Grilla
                        mb = RutUsrALng(CType(grdAlumnos.Rows(mFilas).FindControl("txtRut"), TextBox).Text)
                        If RutUsrALng(Me.txtRutAlumno.Text) = mb Then
                            Me.body.Attributes.Add("onload", "alert('ATENCION: El rut " & Me.txtRutAlumno.Text & " ya se encuentra ingresado.');")
                            Exit Sub
                        End If
                    Next
                End If
            End If


            Dim dt As New DataTable
            Dim dr As DataRow

            If ViewState("dtAlumnos") Is Nothing Then
                dt.Columns.Add("rut")
                dt.Columns.Add("nombres")
                dt.Columns.Add("apellido_paterno")
                dt.Columns.Add("apellido_materno")
                dt.Columns.Add("sexo")
                dt.Columns.Add("cod_region")
                dt.Columns.Add("region")
                dt.Columns.Add("cod_nivel_ocupacional")
                dt.Columns.Add("nivel_ocupacional")
                dt.Columns.Add("franquicia")
                dt.Columns.Add("viatico")
                dt.Columns.Add("traslado")
                dt.Columns.Add("porc_asistencia")
                dt.Columns.Add("cod_nivel_educacional")
                dt.Columns.Add("nivel_educacional")
                dt.Columns.Add("fecha_nacimiento")
                dt.Columns.Add("cod_comuna")
                dt.Columns.Add("comuna")
                dt.Columns.Add("existe")
            Else
                dt = ViewState("dtAlumnos")
            End If

            dr = dt.NewRow
            dr("rut") = objMantenedor.Participantes.Rows(0).Item(0)
            dr("nombres") = objMantenedor.Participantes.Rows(0).Item(1)
            dr("apellido_paterno") = objMantenedor.Participantes.Rows(0).Item(2)
            dr("apellido_materno") = objMantenedor.Participantes.Rows(0).Item(3)
            If objMantenedor.Participantes.Rows(0).Item(4) = "" Then
                dr("sexo") = "M"
            Else
                dr("sexo") = objMantenedor.Participantes.Rows(0).Item(4)
            End If
            If objMantenedor.Participantes.Rows(0).Item(5).ToString = "" Then
                dr("cod_region") = 13 'Region Metropolitana
            Else
                dr("cod_region") = objMantenedor.Participantes.Rows(0).Item(5)
            End If
            If objMantenedor.Participantes.Rows(0).Item(6) = "" Then
                dr("region") = "Region Metropolitana"
            Else
                dr("region") = objMantenedor.Participantes.Rows(0).Item(6)
            End If
            If objMantenedor.Participantes.Rows(0).Item(7).ToString = "" Then
                dr("cod_nivel_ocupacional") = 4
            Else
                dr("cod_nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(7)
            End If
            If objMantenedor.Participantes.Rows(0).Item(8) = "" Then
                dr("nivel_ocupacional") = "Administrativos"
            Else
                dr("nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(8)
            End If
            If objMantenedor.Participantes.Rows(0).Item(9).ToString = "" Then
                dr("franquicia") = 100
            Else
                dr("franquicia") = objMantenedor.Participantes.Rows(0).Item(9)
            End If
            dr("viatico") = objMantenedor.Participantes.Rows(0).Item(10)
            dr("traslado") = objMantenedor.Participantes.Rows(0).Item(11)
            dr("porc_asistencia") = objMantenedor.Participantes.Rows(0).Item(12)
            If objMantenedor.Participantes.Rows(0).Item(13).ToString = "" Then
                dr("cod_nivel_educacional") = 5
            Else
                dr("cod_nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(13)
            End If
            If objMantenedor.Participantes.Rows(0).Item(14).ToString = "" Then
                dr("nivel_educacional") = "Licencia Media Completa"
            Else
                dr("nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(14)
            End If
            dr("fecha_nacimiento") = Left(objMantenedor.Participantes.Rows(0).Item(15), 10)
            If objMantenedor.Participantes.Rows(0).Item(16).ToString = "" Then
                dr("cod_comuna") = 132101
            Else
                dr("cod_comuna") = objMantenedor.Participantes.Rows(0).Item(16)
            End If
            If objMantenedor.Participantes.Rows(0).Item(17).ToString = "" Then
                dr("comuna") = "SANTIAGO"
            Else
                dr("comuna") = objMantenedor.Participantes.Rows(0).Item(17)
            End If
            dr("existe") = objMantenedor.Participantes.Rows(0).Item(18)
            dt.Rows.Add(dr)
            Dim filas As Integer
            filas = 1
            If grdAlumnos.Rows.Count > 0 Then
                Dim grdRow As GridViewRow
                For Each grdRow In grdAlumnos.Rows
                    If CType(grdRow.FindControl("txtRut"), TextBox).Text <> "" Then
                        filas = filas + 1
                    End If
                    For Each dr In dt.Rows
                        If dr("rut") = CType(grdRow.FindControl("lblRut"), Label).Text Then
                            dr("nombres") = CType(grdRow.FindControl("txtNombres"), TextBox).Text
                            dr("apellido_paterno") = CType(grdRow.FindControl("txtApellidoPat"), TextBox).Text
                            dr("apellido_materno") = CType(grdRow.FindControl("txtApellidoMat"), TextBox).Text
                            dr("sexo") = CType(grdRow.FindControl("ddlSexo"), DropDownList).SelectedValue
                            dr("cod_region") = CType(grdRow.FindControl("ddlRegion"), DropDownList).SelectedValue
                            dr("region") = CType(grdRow.FindControl("ddlRegion"), DropDownList).Text  ' CType(grdRow.FindControl("lblRegion"), Label).Text
                            dr("cod_nivel_ocupacional") = CType(grdRow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                            dr("nivel_ocupacional") = CType(grdRow.FindControl("ddlNivelOcup"), DropDownList).Text  ' CType(grdRow.FindControl("lblNivelOcup"), Label).Text
                            dr("franquicia") = CType(grdRow.FindControl("ddlFranquicia"), DropDownList).SelectedValue
                            dr("viatico") = CType(grdRow.FindControl("txtViatico"), TextBox).Text
                            dr("traslado") = CType(grdRow.FindControl("txtTraslado"), TextBox).Text
                            dr("porc_asistencia") = CType(grdRow.FindControl("hdfAsistencia"), HiddenField).Value
                            dr("cod_nivel_educacional") = CType(grdRow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                            dr("nivel_educacional") = CType(grdRow.FindControl("ddlNivelEduc"), DropDownList).Text  'CType(grdRow.FindControl("lblNivelEduc"), Label).Text
                            dr("fecha_nacimiento") = Left(FechaUsrAVb(CType(grdRow.FindControl("txtFechaNac"), TextBox).Text), 10)
                            dr("cod_comuna") = CType(grdRow.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue
                            dr("comuna") = CType(grdRow.FindControl("ddlComuna"), DropDownList).Text  ' CType(grdRow.FindControl("lblComuna"), Label).Text
                            dr("existe") = CType(grdRow.FindControl("hdfExiste"), HiddenField).Value
                            Exit For
                        End If
                    Next

                Next
            End If

            dt.DefaultView.Sort = "rut asc"

            If filas = dt.Rows.Count Then
                Me.txtNumParticipantes.Text = dt.Rows.Count
            End If

            ViewState("dtAlumnos") = dt
            If dt.Rows.Count > 0 Then
                Me.btnActualizaListaAlumnos.Visible = True
            Else
                Me.btnActualizaListaAlumnos.Visible = False
            End If

            If bol Then
                objWeb = New CWeb
                objWeb.LlenaGrilla(Me.grdAlumnos, dt)
                objWeb = Nothing
            End If

            txtRutAlumno.Text = ""
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnAgregarAlumno_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnAgregarEmpReparto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarEmpReparto.Click
        Try
            objMantenedor = New CMantenedorCursos
            If Me.txtEmpBenefactora.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el Rut de empresa.');")
                Exit Sub
            End If
            If Not objMantenedor.ExisteEmpresa(RutUsrALng(Me.txtEmpBenefactora.Text.Trim)) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El Rut de empresa no se encuentra en nuestros registros.');")
                Exit Sub
            End If
            Dim dt As New DataTable
            Dim dr As DataRow
            If ViewState("dtReparto") Is Nothing Then
                dt.Columns.Add("rut_benefactor")
                dt.Columns.Add("monto")
                dt.Columns.Add("cod_curso")
                dr = dt.NewRow
                dr("rut_benefactor") = Me.txtEmpBenefactora.Text
                dr("monto") = 0
                dr("cod_curso") = ViewState("CodCurso")
                dt.Rows.Add(dr)
                ViewState("dtReparto") = dt
                'If dt.Rows.Count > 0 Then
                '    Me.btnActualizaLista.Visible = True
                'Else
                '    Me.btnActualizaLista.Visible = False
                'End If
            Else
                dt = ViewState("dtReparto")
                If dt.Rows.Count >= 2 Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: No puede agregar más de dos repartos.');")
                    Exit Sub
                Else
                    For Each dr In dt.Rows
                        If dr("rut_benefactor") = Me.txtEmpBenefactora.Text Then
                            body.Attributes.Add("onload", "alert('ATENCIÓN: Este Rut de empresa ya ha sido ingresado anteriormente');")
                            Exit Sub
                        End If
                    Next
                    dr = dt.NewRow
                    dr("rut_benefactor") = Me.txtEmpBenefactora.Text
                    dr("monto") = 0
                    dt.Rows.Add(dr)
                    ViewState("dtReparto") = dt
                End If
            End If

            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdReparto, ViewState("dtReparto"))
            objWeb = Nothing
            txtEmpBenefactora.Text = ""
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnAgregarEmpReparto_Click-->" & ex.Message)
        End Try
    End Sub

    Public Sub CargarDatos()
        Try
            ViewState("PorcAdmin") = objMantenedor.PorcAdmin
            Select Case objMantenedor.CodEstadoCurso
                Case 0, 1, 2, 3, 7, 9, 11

                Case 5, 6  '4,
                    Me.txtRutEmpresa.Enabled = False
                    Me.ddlTipoActividad.Enabled = False
                    Me.rdbComBipSi.Enabled = False
                    Me.rdbDetNecSi.Enabled = False
                    Me.txtNumParticipantes.Enabled = False
                    Me.txtDireccion.Enabled = False
                    Me.txtNumDireccion.Enabled = False
                    Me.txtCiudad.Enabled = False
                    Me.ddlComuna.Enabled = False
                    Me.ddlAgnoInicio.Enabled = False
                    Me.txtObservacion.Enabled = False
                    Me.ddlModalidad.Enabled = False
                    Me.txtCodSence.Enabled = False
                    Me.txtFechaInicio.Enabled = False
                    Me.txtFechaFin.Enabled = False
                    'Me.calFechaInicio.Enabled = False
                    'Me.calFechaFin.Enabled = False
                    Me.txtHrsComp.Enabled = False
                    Me.txtValorCurso.Enabled = False
                    Me.txtDescuento.Enabled = False
                    Me.txtValorMasDescuento.Enabled = False
                    Me.txtCorrelEmpresa.Enabled = False
                    Me.txtContactoAdicinal.Enabled = False
                    Me.lblFolio.Enabled = False
                    Me.txtPorcAdmin.Enabled = False
                    Me.btnPopUpEmpresa.Enabled = False
                    Me.btnPopUpSence.Enabled = False
                    Me.chkCursoCFT.Enabled = False

                    'Me.ddlDias.Enabled = False
                    'Me.ddlHoraInicio.Enabled = False
                    'Me.txtHoraInicio.Enabled = False
                    'Me.txtMinutoInicio.Enabled = False
                    'Me.txtHoraFin.Enabled = False
                    'Me.txtMinutoFin.Enabled = False
                    'Me.ddlHoraFin.Enabled = False
                    'Me.btnAgregarHorario.Enabled = False
                    'Me.grdHorario.Enabled = False
                    'Me.btnActualizaLista.Enabled = False
                    Me.txtRutAlumno.Enabled = False
                    Me.btnPopUpAlumno.Enabled = False
                    Me.btnAgregarAlumno.Enabled = False
                    Me.grdAlumnos.Enabled = False
                    wizardCurso.ActiveStepIndex = 3
                Case 8, 10
                    Me.txtRutEmpresa.Enabled = False
                    Me.ddlTipoActividad.Enabled = False
                    Me.rdbComBipSi.Enabled = False
                    Me.rdbDetNecSi.Enabled = False
                    Me.txtNumParticipantes.Enabled = False
                    Me.txtDireccion.Enabled = False
                    Me.txtNumDireccion.Enabled = False
                    Me.txtCiudad.Enabled = False
                    Me.ddlComuna.Enabled = False
                    Me.ddlAgnoInicio.Enabled = False
                    Me.txtObservacion.Enabled = False
                    Me.ddlModalidad.Enabled = False
                    Me.txtCodSence.Enabled = False
                    Me.txtFechaInicio.Enabled = False
                    Me.txtFechaFin.Enabled = False
                    'Me.calFechaInicio.Enabled = False
                    'Me.calFechaFin.Enabled = False
                    Me.txtHrsComp.Enabled = False
                    Me.txtValorCurso.Enabled = False
                    Me.txtDescuento.Enabled = False
                    Me.txtValorMasDescuento.Enabled = False
                    Me.txtCorrelEmpresa.Enabled = False
                    Me.txtContactoAdicinal.Enabled = False
                    Me.lblFolio.Enabled = False
                    Me.txtPorcAdmin.Enabled = False
                    Me.btnPopUpEmpresa.Enabled = False
                    Me.btnPopUpSence.Enabled = False
                    Me.chkCursoCFT.Enabled = False

                    'Me.ddlDias.enabled = False
                    'Me.ddlHoraInicio.enabled = False
                    'Me.ddlHoraFin.Enabled = False
                    'Me.txtHoraInicio.Enabled = False
                    'Me.txtMinutoInicio.Enabled = False
                    'Me.txtHoraFin.Enabled = False
                    'Me.txtMinutoFin.Enabled = False
                    'Me.btnAgregarHorario.enabled = False
                    'Me.grdHorario.enabled = False
                    'Me.btnActualizaLista.enabled = False

                    Me.txtRutAlumno.Enabled = False
                    Me.btnPopUpAlumno.Enabled = False
                    Me.btnAgregarAlumno.Enabled = False
                    Me.grdAlumnos.Enabled = False

                    Me.txtCtaCap1.Enabled = False
                    Me.txtExcCap1.Enabled = False
                    Me.txtBecas.Enabled = False
                    Me.txtCtaCap2.Enabled = False
                    Me.txtExcCap2.Enabled = False
                    Me.txtEmpBenefactora.Enabled = False
                    Me.btnPopUpTerceros.Enabled = False
                    Me.btnAgregarEmpReparto.Enabled = False
                    Me.grdReparto.Enabled = False
            End Select
            '******************** PASO 1
            Me.txtRutEmpresa.Text = RutLngAUsr(objMantenedor.RutEmpresa)
            Me.ddlTipoActividad.SelectedValue = objMantenedor.TipoActividad
            Me.rdbComBipSi.Checked = objMantenedor.ComBipartito
            Me.rdbDetNecSi.Checked = objMantenedor.DetNecesidades
            Me.txtNumParticipantes.Text = objMantenedor.NumParticipantes
            Me.hdfNumParticipantes.Value = objMantenedor.NumParticipantes
            Me.txtDireccion.Text = objMantenedor.Direccion
            Me.txtNumDireccion.Text = objMantenedor.NumDireccion
            Me.txtCiudad.Text = objMantenedor.Ciudad
            Me.ddlComuna.SelectedValue = objMantenedor.Comuna
            Me.ddlAgnoInicio.SelectedValue = objMantenedor.Agno
            Me.txtObservacion.Text = objMantenedor.Observaciones
            Me.ddlModalidad.SelectedValue = objMantenedor.Modalidad
            Me.txtCodSence.Text = objMantenedor.CodSence
            Me.txtFechaInicio.Text = objMantenedor.FechaInicio
            Me.txtFechaFin.Text = objMantenedor.FechaFin
            'Me.calFechaInicio.SelectedValue = objMantenedor.FechaInicio
            'Me.calFechaFin.SelectedValue = objMantenedor.FechaFin
            Me.txtHrsComp.Text = objMantenedor.HorasComp
            Me.txtValorCurso.Text = objMantenedor.ValorCurso
            Me.txtValorHora.Text = objMantenedor.ValorHora
            Me.hdfValorHora.Value = objMantenedor.ValorHora
            Me.txtDescuento.Text = objMantenedor.Descuento
            If objMantenedor.DescPorc Then
                Me.rdbDescPorcentaje.Checked = True
            Else
                Me.rdbDescMonto.Checked = True
            End If
            Me.txtValorMasDescuento.Text = objMantenedor.ValorFinal
            Me.txtCorrelEmpresa.Text = objMantenedor.CorrelEmpresa
            Me.txtContactoAdicinal.Text = objMantenedor.ContactoAdicional
            Me.lblFolio.Text = objMantenedor.Correlativo
            Me.txtPorcAdmin.Text = Replace(objMantenedor.PorcAdmin * 100, ",", ".")
            If objMantenedor.AdmNoLineal Then
                Me.tdPorcAdmin1.Visible = False
                Me.tdPorcAdmin2.Visible = False
                Me.tdPorcAdmin3.Visible = False
            Else
                Me.tdPorcAdmin1.Visible = True
                Me.tdPorcAdmin2.Visible = True
                Me.tdPorcAdmin3.Visible = True
            End If

            objMantenedor.InicializarCursoSence()
            objMantenedor.DatosCurso(Me.txtCodSence.Text.Trim)
            Me.lblCurso.Text = objMantenedor.Curso
            Me.lblNombreCurso.Text = objMantenedor.Curso
            Me.lblHoras.Text = objMantenedor.HorasCurso
            Me.hdfHoras.Value = objMantenedor.HorasCurso
            Me.hdfMAxParticipantes.Value = objMantenedor.MaxParticipantes
            Me.hdfValorCursoSence.Value = objMantenedor.ValorCursoSence
            Me.lblOtec.Text = objMantenedor.Otec
            CalculaValorFinal()
            objMantenedor.InicializarCliente()
            objMantenedor.NombreEmpresa(RutUsrALng(Me.txtRutEmpresa.Text.Trim))
            Me.lblEmpresa.Text = objMantenedor.Empresa
            If objMantenedor.CursoCFT = 0 Then
                Me.chkCursoCFT.Checked = False
            Else
                Me.chkCursoCFT.Checked = True
            End If
            Me.hdfCodCursoParcial.Value = objMantenedor.CodCursoParcial


            '******************** PASO 2
            'Me.lblEmpresa.Text = objMantenedor.Empresa
            'Me.lblCurso.Text = objMantenedor.Curso
            'Me.lblHoras.Text = objMantenedor.HorasCurso
            'Me.lblOtec.Text = objMantenedor.Otec
            ViewState("dtHorario") = objMantenedor.dthorario
            'If objMantenedor.dthorario.Rows.Count > 0 Then
            '    btnActualizaLista.Visible = True
            'End If
            limpiaHorario()
            LlenaHorario()
            '******************** PASO 3
            ViewState("dtAlumnos") = objMantenedor.Participantes

            Dim dt As DataTable = ViewState("dtAlumnos")

            dt.DefaultView.Sort = "RutLNG asc"
            dt.AcceptChanges()
            Dim dr As DataRow
            Dim Cant As Integer
            For Cant = dt.Rows.Count To Me.txtNumParticipantes.Text.Trim - 1
                dr = dt.NewRow
                dr("rut") = ""
                dr("nombres") = ""
                dr("apellido_paterno") = ""
                dr("apellido_materno") = ""
                dr("sexo") = ""
                dr("cod_region") = 13
                dr("region") = "Santiago"
                dr("cod_nivel_ocupacional") = 4
                dr("nivel_ocupacional") = "Administrativos"
                dr("franquicia") = 100
                dr("viatico") = 0
                dr("traslado") = 0
                dr("porc_asistencia") = 0
                dr("cod_nivel_educacional") = 5
                dr("nivel_educacional") = "Licencia Media Completa"
                dr("fecha_nacimiento") = Now.Date.ToShortDateString
                dr("cod_comuna") = 132101
                dr("comuna") = "SANTIAGO"
                dr("existe") = 0
                dr("cod_pais") = 1
                dr("pais") = "CHILE"
                dr("fono") = ""
                dr("email") = ""
                dr("RutLNG") = 99999999
                dt.Rows.Add(dr)
            Next
            ViewState("dtAlumnos") = dt




            If objMantenedor.Participantes.Rows.Count > 0 Then
                Me.btnActualizaListaAlumnos.Visible = True
            Else
                Me.btnActualizaListaAlumnos.Visible = False
            End If
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdAlumnos, ViewState("dtAlumnos"))
            objWeb = Nothing
            '******************** PASO 4
            lblCostoOtic.Text = FormatoMonto(objMantenedor.CostoOtic)
            lblCtaCapSaldo.Text = FormatoMonto(objMantenedor.CtaCapSaldo)
            'If objMantenedor.CtaCap1 <> 0 Then
            txtCtaCap1.Text = objMantenedor.CtaCap1
            'Else
            'txtCtaCap1.Text = ""
            'End If

            lblExcCapSaldo.Text = FormatoMonto(objMantenedor.ExcCapSaldo)
            'If objMantenedor.ExcCap1 <> 0 Then
            txtExcCap1.Text = objMantenedor.ExcCap1
            'Else
            '    If objMantenedor.ExcCapSaldo > 0 And objMantenedor.ExcCapSaldo > objMantenedor.PorCubrir1 Then
            '        txtExcCap1.Text = objMantenedor.PorCubrir1
            '        txtPorCubrir1.Text = 0
            '    Else
            '        If objMantenedor.CtaCapSaldo > 0 And objMantenedor.CtaCapSaldo > objMantenedor.PorCubrir1 Then
            '            txtCtaCap1.Text = objMantenedor.PorCubrir1
            '        Else
            '            'txtCtaCap1.Text = ""
            '            txtPorCubrir1.Text = objMantenedor.PorCubrir1
            '        End If
            '        'txtExcCap1.Text = ""
            '        txtPorCubrir1.Text = objMantenedor.PorCubrir1
            '    End If
            'End If
            txtPorCubrir1.Text = objMantenedor.PorCubrir1
            lblBecasSaldo.Text = FormatoMonto(objMantenedor.BecasSaldo)
            'If objMantenedor.Becas <> 0 Then
            txtBecas.Text = objMantenedor.Becas
            'Else
            'txtBecas.Text = ""
            'End If

            ' If objMantenedor.Terceros <> 0 Then
            txtTerceros.Text = objMantenedor.Terceros
            'Else
            ' txtTerceros.Text = ""
            'End If

            lblVyT1.Text = FormatoMonto(objMantenedor.VyT1)
            lblPorcAdmin1.Text = Replace(objMantenedor.PorcAdmin * 100, ",", ".")
            txtAdminCtaCap.Text = objMantenedor.AdminCtaCap
            txtAporteReq1.Text = objMantenedor.AporteReq1
            lblGastoEmpresa.Text = FormatoMonto(objMantenedor.GastoEmpresa)
            txtTotalCurso.Text = objMantenedor.TotalCurso
            lblTotalViatico.Text = FormatoMonto(objMantenedor.TotalViatico)
            lblTotalTraslado.Text = FormatoMonto(objMantenedor.TotalTraslado)
            lblCostoOticVyT.Text = FormatoMonto(objMantenedor.CostoOticVyT)
            txtGastoEmpresaVyT.Text = objMantenedor.GastoEmpresaVyT
            lblCtaCapSaldo2.Text = FormatoMonto(objMantenedor.CtaCapSaldo2)
            'If objMantenedor.CtaCap2 <> 0 Then
            txtCtaCap2.Text = objMantenedor.CtaCap2
            'Else
            '    txtCtaCap2.Text = ""
            'End If

            lblExcCapSaldo2.Text = FormatoMonto(objMantenedor.ExcCapSaldo2)
            'If objMantenedor.ExcCap2 <> 0 Then
            txtExcCap2.Text = objMantenedor.ExcCap2
            'Else
            '    txtExcCap2.Text = ""
            'End If

            lblPorcAdmin2.Text = Replace(objMantenedor.PorcAdmin * 100, ",", ".")
            txtAdminCtaCapVyT.Text = objMantenedor.AdminCtaCapVyT
            txtAporteReq2.Text = objMantenedor.AporteReq2
            hdfAdmNoLinial.Value = objMantenedor.AdmNoLineal
            ViewState("dtReparto") = objMantenedor.Solicitudes
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdReparto, objMantenedor.Solicitudes)
            objWeb = Nothing
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:CargarDatos-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdReparto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdReparto.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim txt As New TextBox
                txt = CType(e.Row.FindControl("txtMonto"), TextBox)
                txt.Attributes.Add("onblur", "CalculaValorFinalP4('grdReparto');")
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:grdReparto_RowDataBound-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnActualizarRepartos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizarRepartos.Click
        Try
            ActualizarRepartos()
            CalcularMontosCuentas()
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnActualizarRepartos_Click-->" & ex.Message)
        End Try
    End Sub

    Public Sub ActualizarRepartos()
        Try
            Dim lngMontoTotal As Long = 0
            Dim dt As New DataTable
            ViewState("dtReparto") = Nothing
            If ViewState("dtReparto") Is Nothing Then
                dt.Columns.Add("rut_benefactor")
                dt.Columns.Add("monto")
                dt.Columns.Add("cod_curso")

            End If
            If Me.grdReparto.Rows.Count > 0 Then
                Dim dr As DataRow
                Dim grdRow As GridViewRow
                For Each grdRow In grdReparto.Rows
                    dr = dt.NewRow
                    dr("rut_benefactor") = CType(grdRow.FindControl("lblEmpBenef"), Label).Text
                    dr("monto") = CType(grdRow.FindControl("txtMonto"), TextBox).Text
                    dr("cod_curso") = CType(grdRow.FindControl("hdfCodCurso"), HiddenField).Value
                    dt.Rows.Add(dr)
                Next
            End If
            ViewState("dtReparto") = dt
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    If Not grdReparto Is Nothing Then
                        Dim grdRow As GridViewRow
                        For Each grdRow In Me.grdReparto.Rows
                            Dim chk As New CheckBox
                            chk = CType(grdRow.FindControl("chkEliminarReparto"), CheckBox)
                            Dim lbl As New Label
                            lbl = CType(grdRow.FindControl("lblEmpBenef"), Label)
                            If chk.Checked Then
                                Dim dr As DataRow
                                For Each dr In dt.Rows
                                    If lbl.Text = dr("rut_benefactor") Then
                                        dt.Rows.Remove(dr)
                                        Exit For
                                    End If
                                Next
                            Else
                                Dim dr As DataRow
                                For Each dr In dt.Rows
                                    If lbl.Text = dr("rut_benefactor") Then
                                        dr("monto") = CType(grdRow.FindControl("txtMonto"), TextBox).Text
                                    End If
                                Next
                                Dim txt As New TextBox
                                txt = CType(grdRow.FindControl("txtMonto"), TextBox)
                                If txt.Text = "" Then
                                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un monto a cada empresa de la lista.');")
                                    Exit Sub
                                Else
                                    If Not IsNumeric(txt.Text) Then
                                        body.Attributes.Add("onload", "alert('ATENCIÓN: El monto ingresado debe ser de tipo numerico.');")
                                        Exit Sub
                                    End If
                                End If
                                lngMontoTotal = lngMontoTotal + CLng(txt.Text)
                            End If
                        Next
                        Me.txtTerceros.Text = lngMontoTotal
                        lblTotalReparto.Text = lngMontoTotal
                        ViewState("dtReparto") = dt
                    End If
                End If
                'If dt.Rows.Count > 0 Then
                '    Me.btnActualizaLista.Visible = True
                'Else
                '    Me.btnActualizaLista.Visible = False
                'End If
            End If
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdReparto, ViewState("dtReparto"))
            objWeb = Nothing
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:ActualizarRepartos-->" & ex.Message)
        End Try
    End Sub

    Public Sub CalcularMontosCuentas()
        Try
            Dim lngCostoOtic As Long = CLng(Me.lblCostoOtic.Text)

            Dim lngSaldoCtaCap As Long = CLng(Me.lblCtaCapSaldo.Text)
            Dim lngSaldoExcCap As Long = CLng(Me.lblExcCapSaldo.Text)
            Dim lngSaldoBecas As Long = CLng(Me.lblBecasSaldo.Text)
            Dim lngCtaCap As Long = 0
            Dim lngExcCap As Long = 0
            Dim lngBecas As Long = 0
            Dim lngTerceros As Long = 0
            If Me.txtCtaCap1.Text <> "" Then
                lngCtaCap = CLng(Me.txtCtaCap1.Text)
            Else
                Me.txtCtaCap1.Text = 0
            End If
            If Me.txtExcCap1.Text <> "" Then
                lngExcCap = CLng(Me.txtExcCap1.Text)
            Else
                Me.txtExcCap1.Text = 0
            End If
            If Me.txtBecas.Text <> "" Then
                lngBecas = CLng(Me.txtBecas.Text)
            Else
                Me.txtBecas.Text = 0
            End If
            If Me.txtTerceros.Text <> "" Then
                lngTerceros = CLng(Me.txtTerceros.Text)
            Else
                Me.txtTerceros.Text = 0
            End If
            Dim lngPorCubrir As Long = CLng(Me.txtPorCubrir1.Text)
            Dim lngVyT As Long = CLng(Me.lblVyT1.Text)
            Dim lngAdmCtaCap As Long = CLng(Me.txtAdminCtaCap.Text)
            Dim lngAporteRequerido As Long = CLng(Me.txtAporteReq1.Text)

            Dim lngGastoEmpresa As Long = CLng(Me.lblGastoEmpresa.Text)
            Dim lngTotalCurso As Long = CLng(Me.txtTotalCurso.Text)

            Dim dblPorcAdmin As Double = CDbl(Me.lblPorcAdmin1.Text)
            Dim lngAdmNoLineal As Long
            If Me.hdfAdmNoLinial.Value Then
                lngAdmNoLineal = 1
            Else
                lngAdmNoLineal = 0
            End If


            'If lngSaldoCtaCap < lngCtaCap Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: No tiene el saldo suficiente en la cuenta de capacitación.');")
            '    Exit Sub
            'End If
            If lngSaldoExcCap < lngExcCap Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: No tiene el saldo suficiente en la cuenta de excedentes de capacitación.');")
                Me.txtExcCap1.Text = 0
                Exit Sub
            End If
            If lngSaldoBecas < lngBecas Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: No tiene el saldo suficiente en la cuenta de becas.');")
                Exit Sub
            End If
            If lngCtaCap < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El valor ingresado en la cuenta de capacitación debe ser mayor a 0.');")
                Exit Sub
            End If
            If lngExcCap < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El valor ingresado en la cuenta de excedentes de capacitación debe ser mayor a 0.');")
                Exit Sub
            End If
            If lngBecas < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El valor ingresado en la cuenta de becas debe ser mayor a 0.');")
                Exit Sub
            End If
            If (lngCtaCap + lngExcCap + lngBecas + lngTerceros) > lngCostoOtic Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Los valores ingresados exceden el aporte requerido.');")
                Exit Sub
            End If
            lngPorCubrir = lngCostoOtic - lngCtaCap - lngExcCap - lngBecas - lngTerceros
            If (1 - lngAdmNoLineal) * dblPorcAdmin <> 0 Then
                lngAdmCtaCap = Math.Round(lngCtaCap * dblPorcAdmin) / (1 - lngAdmNoLineal + dblPorcAdmin)
            End If
            lngAporteRequerido = lngCtaCap + lngAdmCtaCap
            lngTotalCurso = lngCtaCap + lngGastoEmpresa + lngAdmCtaCap
            Me.txtPorCubrir1.Text = lngPorCubrir
            Me.txtAdminCtaCap.Text = lngAdmCtaCap
            Me.txtAporteReq1.Text = lngAporteRequerido
            'Me.txtTotalCurso.Text = lngTotalCurso

            ' V y T
            Dim lngTotalVyT As Long = CDbl(Me.lblTotalViatico.Text)
            Dim lngCostoOticVyT As Long = CDbl(Me.lblCostoOticVyT.Text)
            Dim lngGastoEmpresaVyT As Long = CDbl(Me.txtGastoEmpresaVyT.Text)

            Dim lngSaldoCtaCapVyT As Long = CDbl(Me.lblCtaCapSaldo2.Text)
            Dim lngSaldoExcCapVyT As Long = CDbl(Me.lblExcCapSaldo2.Text)
            Dim lngCtaCapVyT As Long = 0
            Dim lngExcCapVyT As Long = 0
            If Me.txtCtaCap2.Text <> "" Then
                lngCtaCapVyT = CLng(Me.txtCtaCap2.Text)
            Else
                Me.txtCtaCap2.Text = 0
            End If
            If Me.txtExcCap2.Text <> "" Then
                lngExcCapVyT = CLng(Me.txtExcCap2.Text)
            Else
                Me.txtExcCap2.Text = 0
            End If

            Dim lngAdmCtaCapVyT As Long = CDbl(Me.txtAdminCtaCapVyT.Text)
            Dim lngAporteRequeridoVyT As Long = CDbl(Me.txtAporteReq2.Text)

            'If lngSaldoCtaCapVyT < lngCtaCapVyT Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: No tiene el saldo suficiente en la cuenta de capacitación (V y T).');")
            '    Exit Sub
            'End If
            If lngSaldoExcCapVyT < lngExcCapVyT Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: No tiene el saldo suficiente en la cuenta de excedentes de capacitación (V y T).');")
                Exit Sub
            End If
            If lngCtaCapVyT < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El valor ingresado en la cuenta de capacitación (V y T) debe ser mayor a 0.');")
                Exit Sub
            End If
            If lngExcCapVyT < 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El valor ingresado en la cuenta de excedentes de capacitación (V y T) debe ser mayor a 0.');")
                Exit Sub
            End If
            If (1 - lngAdmNoLineal) * dblPorcAdmin <> 0 Then
                lngAdmCtaCap = Math.Round(lngCtaCapVyT * dblPorcAdmin) / (1 - lngAdmNoLineal + dblPorcAdmin)
            End If
            lngGastoEmpresaVyT = lngVyT - lngCtaCapVyT - lngExcCapVyT
            lngAporteRequeridoVyT = lngCtaCapVyT + lngAdmCtaCapVyT
            Me.txtAdminCtaCapVyT.Text = lngAdmCtaCapVyT
            Me.txtGastoEmpresaVyT.Text = lngGastoEmpresaVyT
            Me.txtAporteReq2.Text = lngAporteRequeridoVyT
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:CalcularMontosCuentas-->" & ex.Message)
        End Try
    End Sub

    Public Sub CargaEmpresa()
        Try
            If Not Me.txtRutEmpresa.Text.Trim = "" Then
                objMantenedor = New CMantenedorCursos
                objMantenedor.RutUsuario = objSession.Rut
                objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text.Trim)
                If Not objMantenedor.ExisteEmpresa(RutUsrALng(Me.txtRutEmpresa.Text.Trim)) Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El Rut de empresa no se encuentra en nuestros registros.');")
                    Exit Sub
                Else
                    objMantenedor.InicializarCliente()
                    objCliente = New CCliente
                    objCliente = objMantenedor.Cliente
                    objMantenedor.NombreEmpresa(RutUsrALng(Me.txtRutEmpresa.Text.Trim))
                    Me.lblEmpresa.Text = objMantenedor.Empresa
                    Me.lblNombreEmpresa.Text = objMantenedor.Empresa
                    Me.lblContactoPrincipal.Text = objMantenedor.Cliente.Contacto & " " & objMantenedor.Cliente.ApellidoContacto
                    If objCliente.AdmNoLineal Then
                        Me.tdPorcAdmin1.Visible = False
                        Me.tdPorcAdmin2.Visible = False
                        Me.tdPorcAdmin3.Visible = False
                    Else
                        Me.txtPorcAdmin.Text = Replace(objCliente.CostoAdm, ",", ".")
                        lblPorcAdmin1.Text = Replace(objCliente.CostoAdm, ",", ".")
                        lblPorcAdmin2.Text = Replace(objCliente.CostoAdm, ",", ".")
                        Me.tdPorcAdmin1.Visible = True
                        Me.tdPorcAdmin2.Visible = True
                        Me.tdPorcAdmin3.Visible = True
                    End If


                    If objMantenedor.EsMoroso(RutUsrALng(Me.txtRutEmpresa.Text.Trim)) Then
                        Session("dtClienteMoroso") = objMantenedor.dtClienteMoroso
                        body.Attributes.Add("onload", "abrir_popupDatosEmpresa();")
                    End If
                End If
            End If
            hdfFoco.Value = 1
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:CargaEmpresa-->" & ex.Message)
        End Try
    End Sub

    Public Sub CargaCursoSence()
        Try

            objMantenedor = New CMantenedorCursos
            objMantenedor.RutUsuario = objSession.Rut

            If Not objMantenedor.ExisteCursoSence(Me.txtCodSence.Text.Trim) Then
                If CargaDatosSenceWebService() Then
                    objMantenedor.CodSence = Me.txtCodSence.Text.Trim
                    objMantenedor.RutUsuario = objSession.Rut
                    objMantenedor.InicializarCursoSence()
                    objCurso = New CCurso
                    objCurso = objMantenedor.CursoSence
                    objMantenedor.DatosCurso(Me.txtCodSence.Text.Trim)
                    Me.lblCurso.Text = objMantenedor.Curso
                    Me.lblNombreCurso.Text = objMantenedor.Curso
                    Me.lblHoras.Text = objMantenedor.HorasCurso
                    Me.hdfHoras.Value = objMantenedor.HorasCurso
                    Me.hdfMAxParticipantes.Value = objMantenedor.MaxParticipantes
                    Me.hdfValorCursoSence.Value = objMantenedor.ValorCursoSence
                    Me.lblOtec.Text = objMantenedor.Otec
                    Me.ddlModalidad.SelectedValue = objMantenedor.CodModalidad
                    Me.txtValorHora.Text = objCurso.ValorHora
                    If ViewState("modo") <> "actualizar" Then
                        If objCurso.Otec.TasaDescuento <> 0.0 Then
                            Me.txtDescuento.Text = objCurso.Otec.TasaDescuento
                            Me.rdbDescPorcentaje.Checked = True
                            Me.rdbDescMonto.Checked = False
                            body.Attributes.Add("onload", "alert('ATENCION: Se ha agregado el descuento de la otec.');")
                        Else
                            Me.txtDescuento.Text = "0"
                            Me.rdbDescMonto.Checked = True
                            Me.rdbDescPorcentaje.Checked = False
                        End If
                    End If

                End If
                body.Attributes.Add("onload", ViewState("MensajeWebService"))
                Exit Sub
            Else
                objMantenedor.CodSence = Me.txtCodSence.Text.Trim
                objMantenedor.InicializarCursoSence()
                objCurso = New CCurso
                objCurso = objMantenedor.CursoSence
                objMantenedor.DatosCurso(Me.txtCodSence.Text.Trim)
                Me.lblCurso.Text = objMantenedor.Curso
                Me.lblNombreCurso.Text = objMantenedor.Curso
                Me.lblHoras.Text = objMantenedor.HorasCurso
                Me.hdfHoras.Value = objMantenedor.HorasCurso
                Me.hdfMAxParticipantes.Value = objMantenedor.MaxParticipantes
                Me.hdfValorCursoSence.Value = objMantenedor.ValorCursoSence
                Me.lblOtec.Text = objMantenedor.Otec
                Me.ddlModalidad.SelectedValue = objMantenedor.CodModalidad
                Me.txtValorHora.Text = objCurso.ValorHora
                If ViewState("modo") <> "actualizar" Then
                    If objCurso.Otec.TasaDescuento <> 0.0 Then
                        Me.txtDescuento.Text = objCurso.Otec.TasaDescuento
                        Me.rdbDescPorcentaje.Checked = True
                        Me.rdbDescMonto.Checked = False
                        body.Attributes.Add("onload", "alert('ATENCION: Se ha agregado el descuento de la otec.');")
                    Else
                        Me.txtDescuento.Text = "0"
                        Me.rdbDescMonto.Checked = True
                        Me.rdbDescPorcentaje.Checked = False
                    End If
                End If
            End If

            If ViewState("modo") = "actualizar" Then
                If Not Me.txtValorHora.Text.Trim = Me.hdfValorHora.Value Then
                    body.Attributes.Add("onload", "ValorHora();")
                End If
            End If

            Me.txtRutEmpresa.Enabled = True
            Me.ddlTipoActividad.Enabled = True
            Me.rdbComBipSi.Enabled = True
            Me.rdbDetNecSi.Enabled = True
            Me.txtNumParticipantes.Enabled = True
            Me.txtDireccion.Enabled = True
            Me.txtNumDireccion.Enabled = True
            Me.txtCiudad.Enabled = True
            Me.ddlComuna.Enabled = True
            Me.ddlAgnoInicio.Enabled = True
            Me.txtObservacion.Enabled = True
            Me.ddlModalidad.Enabled = False
            Me.txtCodSence.Enabled = True
            Me.txtFechaInicio.Enabled = True
            Me.txtFechaFin.Enabled = True
            'Me.calFechaInicio.Enabled = True
            'Me.calFechaFin.Enabled = True
            Me.txtHrsComp.Enabled = True
            Me.txtValorCurso.Enabled = True
            Me.txtDescuento.Enabled = True
            Me.txtValorMasDescuento.Enabled = True
            Me.txtCorrelEmpresa.Enabled = True
            Me.txtContactoAdicinal.Enabled = True
            Me.lblFolio.Enabled = True
            Me.txtPorcAdmin.Enabled = True
            Me.btnPopUpEmpresa.Enabled = True
            Me.btnPopUpSence.Enabled = True
            Me.chkCursoCFT.Enabled = True
            hdfFoco.Value = 2
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:CargaCursoSence-->" & ex.Message)
        End Try
    End Sub
    Private Function CargaDatosSenceWebService() As Boolean
        Try

            objMantenedor = New CMantenedorCursos
            objMantenedor.inicializarPopUpCursosSence()
            objMantenedor.CursosSenceCodCurso = Me.txtCodSence.Text.Trim
            objMantenedor.CursosSenceNombreCurso = ""
            objMantenedor.CursosSenceOtec = ""
            objMantenedor.ConsultarCursosSence()
            '*************************************************************************
            Dim respuesta_web As String
            Dim cs_web = New CHTML
            Dim xml_codSence As String
            Dim xml_HorTeoricas As String
            Dim xml_HorPracticas As String
            Dim xml_HorElearning As String
            Dim xml_ValImputable As String
            Dim xml_HorValor As String
            Dim xml_NomCurso As String
            Dim xml_Area As String
            Dim xml_Especialidad As String
            Dim xml_TotalCurso As String
            Dim xml_NumParticip As String
            Dim xml_RutOtec As String = ""
            Dim xml_NombreSede As String
            Dim xml_FonoSede As String
            Dim xml_DireccionSede As String
            Dim xml_CodComunaSede As Long
            Dim xml_CodModalidad As Long
            Dim xml_NombreModalidad As String


            respuesta_web = cs_web.getHTML("http://pruebasphp.soleduc.cl/traedatos_sql.php?curso=" + txtCodSence.Text)

            If respuesta_web <> "SIN_DATA" Then

                Dim objXMLDoc As New XmlDocument
                objXMLDoc.LoadXml(respuesta_web)

                xml_codSence = objXMLDoc.LastChild.ChildNodes(0).InnerText
                xml_HorTeoricas = objXMLDoc.LastChild.ChildNodes(1).InnerText
                xml_HorPracticas = objXMLDoc.LastChild.ChildNodes(2).InnerText
                xml_HorElearning = objXMLDoc.LastChild.ChildNodes(3).InnerText
                xml_ValImputable = objXMLDoc.LastChild.ChildNodes(4).InnerText
                xml_HorValor = objXMLDoc.LastChild.ChildNodes(5).InnerText
                xml_NomCurso = objXMLDoc.LastChild.ChildNodes(6).InnerText
                xml_Area = objXMLDoc.LastChild.ChildNodes(7).InnerText
                xml_Especialidad = objXMLDoc.LastChild.ChildNodes(8).InnerText
                xml_TotalCurso = objXMLDoc.LastChild.ChildNodes(9).InnerText
                If xml_HorElearning > 0 Then
                    xml_NumParticip = "500"
                Else
                    xml_NumParticip = objXMLDoc.LastChild.ChildNodes(10).InnerText
                End If
                If objXMLDoc.LastChild.ChildNodes(11).InnerText.Length = 8 Then
                    xml_RutOtec = RutLngAUsr(objXMLDoc.LastChild.ChildNodes(11).InnerText)
                ElseIf objXMLDoc.LastChild.ChildNodes(11).InnerText.Length > 8 Then
                    xml_RutOtec = objXMLDoc.LastChild.ChildNodes(11).InnerText
                End If

                xml_NombreModalidad = objXMLDoc.LastChild.ChildNodes(12).InnerText

                objOtec = New COtec
                If Not objOtec.Inicializar1(xml_RutOtec) Then
                    ViewState("MensajeWebService") = "alert('ATENCIÓN: No existe el rut de la otec en la base de datos del sistema.');"
                    Exit Function
                Else
                    xml_NombreSede = objOtec.RazonSocial
                    xml_FonoSede = objOtec.Fono.Trim
                    xml_DireccionSede = objOtec.Direccion
                    xml_CodComunaSede = objOtec.CodComuna
                End If



                If xml_NombreModalidad.Contains("Presencial") Or xml_NombreModalidad.Contains("sencial") Then
                    xml_CodModalidad = 1
                ElseIf xml_NombreModalidad.Contains("E-Learning") Or xml_NombreModalidad.Contains("Elearning") Or xml_NombreModalidad.Contains("earning") Then
                    xml_CodModalidad = 2
                ElseIf xml_NombreModalidad.Contains("Intrucción") Or xml_NombreModalidad.Contains("Intruccion") Or xml_NombreModalidad.Contains("truccion") Then
                    xml_CodModalidad = 3
                ElseIf xml_NombreModalidad.Contains("Distancia") Or xml_NombreModalidad.Contains("istancia") Then
                    xml_CodModalidad = 4
                Else
                    xml_CodModalidad = 1
                End If

                If objMantenedor.CursosSenceListado.Rows.Count > 0 Then

                    If xml_HorValor <> Val(objMantenedor.CursosSenceListado.Rows(0).Item(5)) Then
                        ViewState("MensajeWebService") = "alert('ATENCIÓN: Valor Hora Sence Actual distinto al registrado... (SENCE : $" & xml_HorValor & " SISOTIC : $" & objMantenedor.CursosSenceListado.Rows(0).Item(5) & ").');"
                    Else
                        ViewState("MensajeWebService") = ""
                    End If
                Else
                    objMantenedorINS = New CMantenedorCursosSence
                    objMantenedorINS.CodSence = Me.txtCodSence.Text
                    objMantenedorINS.NombreCurso = xml_NomCurso 'Me.txtNombreCurso.Text

                    objMantenedorINS.RutOtec = xml_RutOtec

                    'Me.txtRutEmpresa.Text
                    objMantenedorINS.Area = xml_Area 'Me.txtArea.Text
                    objMantenedorINS.Especialidad = xml_Especialidad 'Me.txtEspecialidad.Text
                    objMantenedorINS.DurCurTeorico = CLng(xml_HorTeoricas) 'CLng(Me.txtDurCursoTeorico.Text.Trim)
                    objMantenedorINS.DurCurPractico = CLng(xml_HorPracticas) 'CLng(Me.txtDurCursoPractico.Text.Trim)
                    objMantenedorINS.NumMaxParticipantes = CLng(xml_NumParticip) 'CLng(Me.txtNumParticipantes.Text.Trim)
                    objMantenedorINS.NombreSede = xml_NombreSede
                    objMantenedorINS.FonoSede = xml_FonoSede.Trim
                    objMantenedorINS.Direccion = xml_DireccionSede
                    objMantenedorINS.CodComuna = CLng(xml_CodComunaSede) 'CLng(Me.ddlComuna.SelectedValue.Trim)
                    objMantenedorINS.ValorCurso = CLng(xml_TotalCurso) 'CLng(Me.txtValorTotal.Text.Trim)
                    objMantenedorINS.ValorHora = CDbl(Replace(xml_HorValor, ".", ","))
                    objMantenedorINS.DurCurElearning = CLng(xml_HorElearning)
                    objMantenedorINS.CodModalidad = CLng(xml_CodModalidad)



                    If objMantenedorINS.Insertar() Then
                        ViewState("MensajeWebService") = "alert('ATENCIÓN: Curso SENCE no existía en la base pero si en SENCE ... y se agregó automaticamente.');"
                        CargaDatosSenceWebService = True
                    Else
                        ViewState("MensajeWebService") = "alert('ATENCIÓN: Curso SENCE no existía en la base pero si en SENCE ... pero hubo problemas al insertar el curso.');"
                        CargaDatosSenceWebService = False
                    End If
                End If
            Else
                If objMantenedor.CursosSenceListado.Rows.Count = 0 Then
                    ViewState("MensajeWebService") = "alert('ATENCIÓN: Curso SENCE no existe en la base ni en SENCE.');"
                    CargaDatosSenceWebService = False
                End If
                'If Me.txtNomCurso.Text.Trim = "" And Me.txtOtec.Text.Trim = "" Then
                '    lblMensaje.Text = "Respuesta NULA desde SENCE..."
                'End If
            End If
            '*************************************************************************
        Catch ex As Exception
            EnviaError("modulo_cursos/matenedor_cursos.aspx.vb:CargaDatosSenceWebService--> " & ex.Message)
        End Try
    End Function
    
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.AppendHeader("content-disposition", "attachment; filename=carga_alumnos.txt")
        Response.Clear()
        Response.WriteFile("../contenido/Plantilla/alumnos.txt")
        Response.End()

    End Sub

    'Protected Sub ddlRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try


    '        Dim ddl As DropDownList = CType(sender, DropDownList) 'Obtengo el boton que ha invocado al método
    '        Dim row As GridViewRow = CType(ddl.NamingContainer, GridViewRow) 'Obtengo la fila que contiene el LinkButton que ha invocado al método

    '        objWeb = New CWeb
    '        objLookups = New Clookups

    '        objWeb.LlenaDDL(CType(row.FindControl("ddlComuna"), DropDownList), objLookups.comunasRegion(ddl.SelectedValue), "cod_comuna", "nombre")
    '        objWeb = Nothing
    '        objLookups = Nothing
    '    Catch ex As Exception
    '        EnviaError("modulo_cursos--mantenedor_cursos -- ddlRegion_SelectedIndexChanged--" & ex.Message)
    '    End Try
    'End Sub
    '' ''Protected Sub ddlComunaParicipante_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '' ''    Try
    '' ''        Dim ddl As DropDownList = CType(sender, DropDownList) 'Obtengo el boton que ha invocado al método
    '' ''        Dim row As GridViewRow = CType(ddl.NamingContainer, GridViewRow) 'Obtengo la fila que contiene el LinkButton que ha invocado al método

    '' ''        objWeb = New CWeb
    '' ''        objLookups = New Clookups

    '' ''        objWeb.LlenaDDL(CType(row.FindControl("ddlRegion"), DropDownList), objLookups.RegionComunas(ddl.SelectedValue), "cod_region", "cod_region")
    '' ''        objWeb = Nothing
    '' ''        objLookups = Nothing
    '' ''    Catch ex As Exception
    '' ''        EnviaError("modulo_cursos--mantenedor_cursos -- ddlComunaParicipante_SelectedIndexChanged--" & ex.Message)
    '' ''    End Try
    '' ''End Sub
    Protected Sub btnCalcularTotalHoras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcularTotalHoras.Click
        CantidadHoras()
    End Sub

    Protected Sub btnSeleccionarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSeleccionarTodos.Click
        Try
            Dim grdRow As GridViewRow
            For Each grdRow In Me.grdAlumnos.Rows
                CType(grdRow.FindControl("chkEliminarAlumno"), CheckBox).Checked = True

            Next
        Catch ex As Exception
            EnviaError("modulo_cuentas/mantenedor_cursos.aspx.vb: btnSeleccionarTodos_Click --> " & ex.Message)
        End Try
    End Sub

    Protected Sub btnAgregarAlumno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarAlumno.Click
        Try


            Dim strRuts(0) As String
            If Not Me.txtRutAlumno.Text.Trim = "" Then
                If validarut(Me.txtRutAlumno.Text.Trim) Then
                    strRuts(0) = Me.txtRutAlumno.Text.Trim
                    AgregarAlumnos(strRuts)
                Else
                    body.Attributes.Add("onload", "alert('ATENCION: El Rut ingresado no es valido.');")
                End If
            Else
                body.Attributes.Add("onload", "alert('ATENCION: Debe ingresar el Rut del alumno.');")
            End If



            ' '' ''Dim NumPartInicial As Integer = Me.txtNumParticipantes.Text

            ' '' ''ViewState("CargaMasiva") = "no"


            ' '' ''Dim CantAlumnosIngresados As Integer = 0
            ' '' ''Dim drtmp1 As DataRow
            ' '' ''For Each drtmp1 In ViewState("dtAlumnos").Rows
            ' '' ''    If drtmp1("rut").ToString.Trim <> "" Then
            ' '' ''        CantAlumnosIngresados = CantAlumnosIngresados + 1
            ' '' ''    End If
            ' '' ''Next

            ' '' ''If CantAlumnosIngresados < Me.hdfMAxParticipantes.Value Then
            ' '' ''    CargarAlumno()
            ' '' ''Else
            ' '' ''    body.Attributes.Add("onload", "alert('ATENCION: Se ha alcanzado el máximo de participantes permitidos por SENCE.');")
            ' '' ''    Exit Sub
            ' '' ''End If



            '' '' ''***********************************************************
            ' '' ''Dim dt1 As New DataTable
            ' '' ''Dim dr1 As DataRow
            ' '' ''Dim t As Integer
            ' '' ''dt1 = ViewState("dtAlumnos")

            ' '' ''For t = 1 To (Val(Me.txtNumParticipantes.Text) - Val(Me.grdAlumnos.Rows.Count))
            ' '' ''    dr1 = dt1.NewRow
            ' '' ''    dr1("rut") = ""
            ' '' ''    dr1("nombres") = ""
            ' '' ''    dr1("apellido_paterno") = ""
            ' '' ''    dr1("apellido_materno") = ""
            ' '' ''    dr1("sexo") = "M"
            ' '' ''    dr1("cod_region") = "13"
            ' '' ''    dr1("region") = ""
            ' '' ''    dr1("cod_nivel_ocupacional") = "0"
            ' '' ''    dr1("nivel_ocupacional") = "0"
            ' '' ''    dr1("franquicia") = "1"
            ' '' ''    dr1("viatico") = "0"
            ' '' ''    dr1("traslado") = "0"
            ' '' ''    dr1("porc_asistencia") = 0
            ' '' ''    dr1("cod_nivel_educacional") = 0
            ' '' ''    dr1("nivel_educacional") = "0"
            ' '' ''    dr1("fecha_nacimiento") = ""
            ' '' ''    dr1("cod_comuna") = "132101"
            ' '' ''    dr1("comuna") = "SANTIAGO"
            ' '' ''    dr1("existe") = "0"
            ' '' ''    dt1.Rows.Add(dr1)
            ' '' ''Next t

            ' '' ''Dim fil_control As Integer
            ' '' ''Dim fila_vacia As Integer
            ' '' ''fila_vacia = 10000
            ' '' ''For fil_control = 0 To dt1.Rows.Count - 1
            ' '' ''    If dt1.Rows(fil_control).Item("rut") = "" Then
            ' '' ''        fila_vacia = fil_control
            ' '' ''    End If
            ' '' ''Next fil_control
            ' '' ''If fila_vacia <> 10000 Then
            ' '' ''    dt1.Rows.Remove(dt1.Rows(fila_vacia))
            ' '' ''End If
            ' '' ''For fil_control = 0 To dt1.Rows.Count - 1
            ' '' ''    If dt1.Rows(fil_control).Item("rut") = "" Then
            ' '' ''        fila_vacia = fil_control
            ' '' ''    End If
            ' '' ''Next fil_control
            ' '' ''objWeb = New CWeb
            ' '' ''objWeb.LlenaGrilla(Me.grdAlumnos, dt1)
            ' '' ''objWeb = Nothing

            ' '' ''Call btnActualizaListaAlumnos_Click(Me, e)





            ' '' ''Dim CantAlumnosIngresados2 As Integer = 0
            ' '' ''Dim drtmp2 As DataRow
            ' '' ''For Each drtmp2 In ViewState("dtAlumnos").Rows
            ' '' ''    If drtmp2("rut").ToString.Trim <> "" Then
            ' '' ''        CantAlumnosIngresados2 = CantAlumnosIngresados2 + 1
            ' '' ''    End If
            ' '' ''Next

            ' '' ''If CantAlumnosIngresados2 > NumPartInicial Then
            ' '' ''    body.Attributes.Add("onload", "alert('ATENCION: La cantidad de participantes ingresados, ha superado el numero ingresado en el paso 1\n, debe repasar el costo del curso conciderando la nueva cantidad de participantes.');")
            ' '' ''    Exit Sub
            ' '' ''End If




            '' '' ''***************************************************************
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnAgregarAlumno_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnCargarArchivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarArchivo.Click
        Try

            Dim strRuts(0) As String


            Dim rutErroneos As String = ""
            Dim strRutsInexistentes As String = ""
            Dim strRutDuplicado As String = ""
            Dim ErrorDuplicado As String = ""

            Dim fileName As String
            Dim len As Integer
            Dim strExtension As String
            Dim arrDatos() As String
            Dim intArreglo As Integer
            Dim strDatos As String
            Dim lngRutPart As Long
            Dim mFilas, mb As Long

            'Toma la Ruta del servidor donde se encuentra la carpeta TMP
            Dim savePath As String = Server.MapPath("~/contenido/tmp/")
            'Obtengo el nombre de archivo.
            fileName = flpCarga.FileName
            'verifico que la extension sea txt
            len = fileName.Length
            'strExtension = fileName.Substring(len, len - 3)
            strExtension = Right(fileName, 3).Trim.ToLower()
            If strExtension <> "txt" Then
                body.Attributes.Add("onload", "alert('ATENCION: El archivo debe ser en formato txt.');")
            Else
                savePath += fileName
                If flpCarga.HasFile Then
                    Dim tempfileName As String
                    Dim counter As Integer = 2
                    While (System.IO.File.Exists(savePath))
                        savePath = Server.MapPath("~/contenido/tmp/")
                        tempfileName = ""
                        tempfileName = counter.ToString() + fileName
                        savePath += tempfileName
                        counter = counter + 1
                    End While
                    fileName = tempfileName
                    flpCarga.SaveAs(savePath)

                    Dim file2 As New FileStream(savePath, FileMode.Open)
                    Dim reader2 As New StreamReader(file2)
                    Dim arrTmp
                    Dim dt As DataTable
                    Dim dr As DataRow
                    Dim LargoArchivo As Integer
                    Dim strDatos2 As String
                    LargoArchivo = 0
                    While Not reader2.EndOfStream
                        strDatos2 = reader2.ReadLine

                        ReDim Preserve strRuts(LargoArchivo)
                        strRuts(LargoArchivo) = strDatos2

                        LargoArchivo = LargoArchivo + 1
                    End While
                    file2.Close()


                    AgregarAlumnos(strRuts)





                    ' '' ''                    If Val(txtNumParticipantes.Text) <= LargoArchivo Then
                    ' '' ''                        body.Attributes.Add("onload", "alert('ATENCION: El archivo tiene mas participantes del mäximo permitido en el curso.');")
                    ' '' ''                        Exit Sub
                    ' '' ''                    End If

                    ' '' ''                    Dim file As New FileStream(savePath, FileMode.Open)

                    ' '' ''                    Dim reader As New StreamReader(file)

                    ' '' ''                    While Not reader.EndOfStream
                    ' '' ''                        strDatos = reader.ReadLine
                    ' '' ''                        If strDatos.Trim.Length = 0 Then
                    ' '' ''                            GoTo moveNext
                    ' '' ''                        End If
                    ' '' ''                        strDatos = strDatos.ToUpper.Trim
                    ' '' ''                        strDatos = Replace(strDatos, ".", "")
                    ' '' ''                        strDatos = Replace(strDatos, " ", "")
                    ' '' ''                        Dim rutConDV As String = Right(strDatos, 1)
                    ' '' ''                        If Not digito_verificador(RutUsrALng(strDatos)).ToString.ToUpper.Trim = rutConDV.ToUpper Then
                    ' '' ''                            rutErroneos = rutErroneos & strDatos & ", "
                    ' '' ''                            GoTo moveNext
                    ' '' ''                        End If
                    ' '' ''                        arrDatos = strDatos.Split(";")
                    ' '' ''                        intArreglo = TamanoArreglo1(arrDatos)
                    ' '' ''                        Dim lngRut As Long = 0
                    ' '' ''                        If intArreglo <> 1 Then 'valida el tamaño
                    ' '' ''                            body.Attributes.Add("onload", "alert('ATENCION: Error en fila. Número de campos distinto al requerido (1).');")
                    ' '' ''                            GoTo moveNext
                    ' '' ''                        Else
                    ' '' ''                            If arrDatos(0).Contains("-") Then
                    ' '' ''                                arrTmp = arrDatos(0).Split("-")
                    ' '' ''                                lngRut = arrTmp(0)
                    ' '' ''                            Else
                    ' '' ''                                lngRut = Left(arrDatos(0), arrDatos(0).Length - 1)
                    ' '' ''                            End If

                    ' '' ''                            lngRutPart = CLng(lngRut)
                    ' '' ''                            'If lngRutPart > 0 Then
                    ' '' ''                            '    If Me.grdAlumnos.Rows.Count >= CLng(txtNumParticipantes.Text) Then
                    ' '' ''                            '        body.Attributes.Add("onload", "alert('ATENCION: Se alcanzó el máximo de participantes permitido.');")
                    ' '' ''                            '        If rutErroneos.Length > 0 Then
                    ' '' ''                            '            If strRutsInexistentes.Length > 0 Then
                    ' '' ''                            '                rutErroneos = Left(rutErroneos, rutErroneos.Length - 2)
                    ' '' ''                            '                strRutsInexistentes = Left(strRutsInexistentes, strRutsInexistentes.Length - 2)
                    ' '' ''                            '                Me.body.Attributes.Add("onload", "alert('ATENCION: Se alcanzó el máximo de participantes permitido.\n Los siguientes participantes no fueron cargados por:\n Rut incorrecto \n" & rutErroneos & "\n No figuran en la nomina \n" & strRutsInexistentes & "');")
                    ' '' ''                            '            Else
                    ' '' ''                            '                rutErroneos = Left(rutErroneos, rutErroneos.Length - 2)
                    ' '' ''                            '                'strRutsInexistentes = Left(strRutsInexistentes, strRutsInexistentes.Length - 2)
                    ' '' ''                            '                Me.body.Attributes.Add("onload", "alert('ATENCION: Se alcanzó el máximo de participantes permitido.\n Los siguientes participantes tienen el Rut incorrecto:\n" & rutErroneos & "');")
                    ' '' ''                            '            End If
                    ' '' ''                            '        End If
                    ' '' ''                            '        Exit Sub
                    ' '' ''                            '    End If
                    ' '' ''                            'End If
                    ' '' ''                            'Verificamos si el Rut ya existe en la Grilla
                    ' '' ''                            dt = ViewState("dtAlumnos")
                    ' '' ''                            If Not dt Is Nothing Then
                    ' '' ''                                For Each dr In dt.Rows
                    ' '' ''                                    If lngRutPart = RutUsrALng(dr("rut")) Then
                    ' '' ''                                        ErrorDuplicado = ErrorDuplicado & RutLngAUsr(lngRutPart) & ", "
                    ' '' ''                                        strRutDuplicado = Left(ErrorDuplicado, ErrorDuplicado.Length)
                    ' '' ''                                        strRutDuplicado = Left(strRutDuplicado, strRutDuplicado.Length)
                    ' '' ''                                        Me.body.Attributes.Add("onload", "alert('ATENCION: Se han cargado correctamente los participantes del curso.\n Los siguientes participantes no fueron cargados por:\n Rut duplicados \n" & strRutDuplicado & "');")
                    ' '' ''                                        GoTo moveNext
                    ' '' ''                                    End If
                    ' '' ''                                Next
                    ' '' ''                            End If

                    ' '' ''                            ''If Not grdAlumnos Is Nothing Then
                    ' '' ''                            ''    For mFilas = 0 To grdAlumnos.Rows.Count - 1
                    ' '' ''                            ''        'Comparamos el Rut del Nuevo Participante
                    ' '' ''                            ''        'con los que están en la Grilla
                    ' '' ''                            ''        mb = RutUsrALng(CType(grdAlumnos.Rows(mFilas).FindControl("lblRut"), Label).Text)
                    ' '' ''                            ''        If lngRutPart = mb Then
                    ' '' ''                            ''            ErrorDuplicado = ErrorDuplicado & RutLngAUsr(mb) & ", "
                    ' '' ''                            ''            strRutDuplicado = Left(ErrorDuplicado, ErrorDuplicado.Length)
                    ' '' ''                            ''            strRutDuplicado = Left(strRutDuplicado, strRutDuplicado.Length)
                    ' '' ''                            ''            Me.body.Attributes.Add("onload", "alert('ATENCION: Se han cargado correctamente los participantes del curso.\n Los siguientes participantes no fueron cargados por:\n Rut duplicados \n" & strRutDuplicado & "');")
                    ' '' ''                            ''            GoTo moveNext
                    ' '' ''                            ''        End If
                    ' '' ''                            ''    Next
                    ' '' ''                            ''End If
                    ' '' ''                            ViewState("RutParticipante") = RutLngAUsr(lngRutPart)
                    ' '' ''                            ViewState("CargaMasiva") = "si"
                    ' '' ''                            CargarAlumno(False)
                    ' '' ''                        End If
                    ' '' ''moveNext:
                    ' '' ''                    End While

                    ' '' ''                    '**************************
                    ' '' ''                    Dim dt1 As New DataTable
                    ' '' ''                    Dim dr1 As DataRow
                    ' '' ''                    Dim t As Integer
                    ' '' ''                    dt1 = ViewState("dtAlumnos")

                    ' '' ''                    For t = 1 To (Val(Me.txtNumParticipantes.Text - 1) - Val(Me.grdAlumnos.Rows.Count))
                    ' '' ''                        dr1 = dt1.NewRow
                    ' '' ''                        dr1("rut") = ""
                    ' '' ''                        dr1("nombres") = ""
                    ' '' ''                        dr1("apellido_paterno") = ""
                    ' '' ''                        dr1("apellido_materno") = ""
                    ' '' ''                        dr1("sexo") = "M"
                    ' '' ''                        dr1("cod_region") = "13"
                    ' '' ''                        dr1("region") = ""
                    ' '' ''                        dr1("cod_nivel_ocupacional") = "0"
                    ' '' ''                        dr1("nivel_ocupacional") = "0"
                    ' '' ''                        dr1("franquicia") = "1"
                    ' '' ''                        dr1("viatico") = "0"
                    ' '' ''                        dr1("traslado") = "0"
                    ' '' ''                        dr1("porc_asistencia") = 0
                    ' '' ''                        dr1("cod_nivel_educacional") = 0
                    ' '' ''                        dr1("nivel_educacional") = "0"
                    ' '' ''                        dr1("fecha_nacimiento") = Now()
                    ' '' ''                        dr1("cod_comuna") = "132101"
                    ' '' ''                        dr1("comuna") = "SANTIAGO"
                    ' '' ''                        dr1("existe") = "0"
                    ' '' ''                        dr1("rutLNG") = ""
                    ' '' ''                        dt1.Rows.Add(dr1)
                    ' '' ''                    Next t

                    ' '' ''                    Dim fil_control As Integer
                    ' '' ''                    Dim fila_vacia As Integer
                    ' '' ''                    fila_vacia = 10000
                    ' '' ''                    For fil_control = 0 To dt1.Rows.Count - 1
                    ' '' ''                        If dt1.Rows(fil_control).Item("rut") = "" Then
                    ' '' ''                            fila_vacia = fil_control
                    ' '' ''                        End If
                    ' '' ''                    Next fil_control
                    ' '' ''                    If fila_vacia <> 10000 Then
                    ' '' ''                        dt1.Rows.Remove(dt1.Rows(fila_vacia))

                    ' '' ''                    End If
                    ' '' ''                    For fil_control = 0 To dt1.Rows.Count - 1
                    ' '' ''                        If dt1.Rows(fil_control).Item("rut") = "" Then
                    ' '' ''                            fila_vacia = fil_control
                    ' '' ''                        End If
                    ' '' ''                    Next fil_control
                    ' '' ''                    '**************************

                    ' '' ''                    objWeb = New CWeb
                    ' '' ''                    objWeb.LlenaGrilla(Me.grdAlumnos, ViewState("dtAlumnos"))
                    ' '' ''                    objWeb = Nothing
                    ' '' ''                    If rutErroneos.Length > 0 Then
                    ' '' ''                        If strRutsInexistentes.Length > 0 Then
                    ' '' ''                            rutErroneos = Left(rutErroneos, rutErroneos.Length - 2)
                    ' '' ''                            strRutsInexistentes = Left(strRutsInexistentes, strRutsInexistentes.Length - 2)
                    ' '' ''                            Me.body.Attributes.Add("onload", "alert('ATENCION: Se han cargado correctamente los participantes del curso.\n Los siguientes participantes no fueron cargados por:\n Rut incorrecto \n" & rutErroneos & "\n No figuran en la nomina \n" & strRutsInexistentes & "');")
                    ' '' ''                        Else
                    ' '' ''                            rutErroneos = Left(rutErroneos, rutErroneos.Length - 2)
                    ' '' ''                            Me.body.Attributes.Add("onload", "alert('ATENCION: Se han cargado correctamente los participantes del curso.\n Los siguientes participantes tienen el Rut incorrecto:\n" & rutErroneos & "');")
                    ' '' ''                        End If

                    ' '' ''                    Else
                    ' '' ''                        If strRutsInexistentes.Length > 0 Then
                    ' '' ''                            strRutsInexistentes = Left(strRutsInexistentes, strRutsInexistentes.Length - 2)
                    ' '' ''                            Me.body.Attributes.Add("onload", "alert('ATENCION: Se han cargado correctamente los participantes del curso.\n Los siguientes participantes no figuran en la nomina:\n" & strRutsInexistentes & "');")
                    ' '' ''                        End If
                    ' '' ''                    End If
                    ' '' ''                    file.Close()
                End If
            End If

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnCargarArchivo_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnActualizaListaAlumnos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizaListaAlumnos.Click
        Try

            Dim CantidadInicial As Integer = 0
            If IsNumeric(Me.hdfNumParticipantes.Value) Then
                CantidadInicial = CInt(Me.hdfNumParticipantes.Value)
            Else
                CantidadInicial = 0
            End If

            Dim strRutsCursoRepetido As String = ""
            Dim strRutsTopeHorario As String = ""


            Dim dt As New DataTable
            dt.Columns.Add("rut")
            dt.Columns.Add("nombres")
            dt.Columns.Add("apellido_paterno")
            dt.Columns.Add("apellido_materno")
            dt.Columns.Add("sexo")
            dt.Columns.Add("cod_region")
            dt.Columns.Add("region")
            dt.Columns.Add("cod_nivel_ocupacional")
            dt.Columns.Add("nivel_ocupacional")
            dt.Columns.Add("franquicia")
            dt.Columns.Add("viatico")
            dt.Columns.Add("traslado")
            dt.Columns.Add("porc_asistencia")
            dt.Columns.Add("cod_nivel_educacional")
            dt.Columns.Add("nivel_educacional")
            dt.Columns.Add("fecha_nacimiento")
            dt.Columns.Add("cod_comuna")
            dt.Columns.Add("comuna")
            dt.Columns.Add("cod_pais")
            dt.Columns.Add("pais")
            dt.Columns.Add("fono")
            dt.Columns.Add("email")
            dt.Columns.Add("existe")
            dt.Columns.Add("RutLNG", Type.GetType("System.Int32"))
            Dim dr As DataRow
            Dim grow As GridViewRow
            For Each grow In grdAlumnos.Rows
                If Not CType(grow.FindControl("txtRUT"), TextBox).Text.Trim = "" Then
                    If Not CType(grow.FindControl("txtNombres"), TextBox).Text.Trim = "" Then

                        dr = dt.NewRow
                        dr("rut") = CType(grow.FindControl("txtRUT"), TextBox).Text.Trim
                        dr("nombres") = CType(grow.FindControl("txtNombres"), TextBox).Text.Trim
                        dr("apellido_paterno") = CType(grow.FindControl("txtApellidoPat"), TextBox).Text.Trim
                        dr("apellido_materno") = CType(grow.FindControl("txtApellidoMat"), TextBox).Text.Trim
                        dr("sexo") = CType(grow.FindControl("ddlSexo"), DropDownList).SelectedValue
                        dr("cod_region") = CType(grow.FindControl("ddlRegion"), DropDownList).SelectedValue
                        dr("region") = CType(grow.FindControl("lblRegion"), Label).Text
                        dr("cod_nivel_ocupacional") = CType(grow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                        dr("nivel_ocupacional") = CType(grow.FindControl("lblNivelOcup"), Label).Text
                        dr("franquicia") = CType(grow.FindControl("ddlFranquicia"), DropDownList).SelectedValue
                        If CType(grow.FindControl("txtViatico"), TextBox).Text = "" Then
                            dr("viatico") = 0
                        Else
                            dr("viatico") = CType(grow.FindControl("txtViatico"), TextBox).Text.Trim
                        End If
                        If CType(grow.FindControl("txtTraslado"), TextBox).Text = "" Then
                            dr("traslado") = 0
                        Else
                            dr("traslado") = CType(grow.FindControl("txtTraslado"), TextBox).Text.Trim
                        End If
                        If CType(grow.FindControl("hdfAsistencia"), HiddenField).Value = "" Then
                            dr("porc_asistencia") = 0
                        Else
                            dr("porc_asistencia") = CType(grow.FindControl("hdfAsistencia"), HiddenField).Value
                        End If

                        dr("cod_nivel_educacional") = CType(grow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                        dr("nivel_educacional") = CType(grow.FindControl("lblNivelEduc"), Label).Text
                        If EsFechaValidaVB(CType(grow.FindControl("txtFechaNac"), TextBox).Text) Then
                            dr("fecha_nacimiento") = Left(FechaUsrAVb(CType(grow.FindControl("txtFechaNac"), TextBox).Text).Date.ToString, 10)
                        Else
                            dr("fecha_nacimiento") = Now.Date
                        End If
                        dr("cod_comuna") = CType(grow.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue
                        dr("comuna") = CType(grow.FindControl("lblComuna"), Label).Text
                        dr("cod_pais") = CType(grow.FindControl("ddlPaisParicipante"), DropDownList).SelectedValue
                        dr("pais") = CType(grow.FindControl("lblPais"), Label).Text
                        dr("existe") = CType(grow.FindControl("hdfExiste"), HiddenField).Value
                        If CType(grow.FindControl("txtFono"), TextBox).Text = "" Then
                            dr("fono") = ""
                        Else
                            If IsNumeric(CType(grow.FindControl("txtFono"), TextBox).Text) Then
                                dr("fono") = CType(grow.FindControl("txtFono"), TextBox).Text.Trim
                            Else
                                dr("fono") = ""
                            End If

                        End If
                        If CType(grow.FindControl("txtEmail"), TextBox).Text = "" Then
                            dr("email") = ""
                        Else
                            dr("email") = CType(grow.FindControl("txtEmail"), TextBox).Text.Trim
                        End If
                        dr("RutLNG") = RutUsrALng(CType(grow.FindControl("txtRUT"), TextBox).Text.Trim)
                        dt.Rows.Add(dr)


                    Else

                        If validarut(CType(grow.FindControl("txtRUT"), TextBox).Text.Trim) Then
                            objMantenedor = New CMantenedorCursos
                            objMantenedor.inicializarPaso3()
                            objMantenedor.ConsultaAlumno(RutUsrALng(CType(grow.FindControl("txtRUT"), TextBox).Text.Trim))

                            dr = dt.NewRow
                            dr("rut") = objMantenedor.Participantes.Rows(0).Item(0)
                            dr("nombres") = objMantenedor.Participantes.Rows(0).Item(1)
                            dr("apellido_paterno") = objMantenedor.Participantes.Rows(0).Item(2)
                            dr("apellido_materno") = objMantenedor.Participantes.Rows(0).Item(3)
                            If objMantenedor.Participantes.Rows(0).Item(4) = "" Then
                                dr("sexo") = "M"
                            Else
                                dr("sexo") = objMantenedor.Participantes.Rows(0).Item(4)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(5).ToString = "" Then
                                dr("cod_region") = 13 'Region Metropolitana
                            Else
                                dr("cod_region") = objMantenedor.Participantes.Rows(0).Item(5)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(6) = "" Then
                                dr("region") = "Region Metropolitana"
                            Else
                                dr("region") = objMantenedor.Participantes.Rows(0).Item(6)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(7).ToString = "" Then
                                dr("cod_nivel_ocupacional") = 4
                            Else
                                dr("cod_nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(7)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(8) = "" Then
                                dr("nivel_ocupacional") = "Administrativos"
                            Else
                                dr("nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(8)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(9).ToString = "" Then
                                dr("franquicia") = 100
                            Else
                                dr("franquicia") = objMantenedor.Participantes.Rows(0).Item(9)
                            End If
                            dr("viatico") = objMantenedor.Participantes.Rows(0).Item(10)
                            dr("traslado") = objMantenedor.Participantes.Rows(0).Item(11)
                            dr("porc_asistencia") = objMantenedor.Participantes.Rows(0).Item(12)
                            If objMantenedor.Participantes.Rows(0).Item(13).ToString = "" Then
                                dr("cod_nivel_educacional") = 5
                            Else
                                dr("cod_nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(13)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(14).ToString = "" Then
                                dr("nivel_educacional") = "Licencia Media Completa"
                            Else
                                dr("nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(14)
                            End If
                            dr("fecha_nacimiento") = Left(objMantenedor.Participantes.Rows(0).Item(15), 10)
                            If objMantenedor.Participantes.Rows(0).Item(16).ToString = "" Then
                                dr("cod_comuna") = 132101
                            Else
                                dr("cod_comuna") = objMantenedor.Participantes.Rows(0).Item(16)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(17).ToString = "" Then
                                dr("comuna") = "SANTIAGO"
                            Else
                                dr("comuna") = objMantenedor.Participantes.Rows(0).Item(17)
                            End If
                            dr("existe") = objMantenedor.Participantes.Rows(0).Item(18)
                            If objMantenedor.Participantes.Rows(0).Item(19).ToString = "" Then
                                dr("cod_pais") = 1
                            Else
                                dr("cod_pais") = objMantenedor.Participantes.Rows(0).Item(19)
                            End If
                            If objMantenedor.Participantes.Rows(0).Item(20).ToString = "" Then
                                dr("pais") = "CHILE"
                            Else
                                dr("pais") = objMantenedor.Participantes.Rows(0).Item(20)
                            End If
                            dr("fono") = objMantenedor.Participantes.Rows(0).Item(21)
                            dr("email") = objMantenedor.Participantes.Rows(0).Item(22)
                            dr("RutLNG") = RutUsrALng(objMantenedor.Participantes.Rows(0).Item(0))
                            dt.Rows.Add(dr)
                        End If
                    End If
                End If
            Next
            For Each grow In grdAlumnos.Rows
                Dim chk As New CheckBox

                chk = CType(grow.FindControl("chkEliminarAlumno"), CheckBox)
                Dim lbl As New TextBox
                lbl = CType(grow.FindControl("txtRut"), TextBox)

                If AlertAlumnoConCursoRepetido(RutUsrALng(lbl.Text.Trim)) Then
                    strRutsCursoRepetido = strRutsCursoRepetido & lbl.Text.Trim & ", "
                End If
                If AlertAlumnoConTopeFechas(RutUsrALng(lbl.Text.Trim)) Then
                    strRutsTopeHorario = strRutsTopeHorario & lbl.Text.Trim & ", "
                End If

                If chk.Checked Then
                    Dim dr2 As DataRow
                    For Each dr2 In dt.Rows
                        If lbl.Text = dr2("rut") Then
                            dt.Rows.Remove(dr2)
                            Exit For
                        End If
                    Next
                End If
               
            Next


            
            ViewState("dtAlumnos") = dt

            objWeb = New CWeb
            objWeb.LlenaGrilla(grdAlumnos, ViewState("dtAlumnos"))
            objWeb = Nothing


            Me.txtNumParticipantes.Text = grdAlumnos.Rows.Count

            Me.txtNumParticipantes.Text = grdAlumnos.Rows.Count
            If CantidadInicial <> txtNumParticipantes.Text Then
                body.Attributes.Add("onload", "alert('ATENCION: El numero de alumnos es distinto al ingresado en el paso 1, debe volver y repasar los costos del curso.');")
            End If

            If strRutsCursoRepetido.Length > 0 Then
                strRutsCursoRepetido = "Los siguientes participantes ya han realizado este curso durante este año:\n" & Left(strRutsCursoRepetido, strRutsCursoRepetido.Length - 2) & "\n"
            End If
            If strRutsTopeHorario.Length > 0 Then
                strRutsTopeHorario = "Los siguientes participantes presentan tope de fechas con otro curso:\n" & Left(strRutsTopeHorario, strRutsTopeHorario.Length - 2) & "\n"
            End If


            If strRutsCursoRepetido.Length > 0 Or strRutsTopeHorario.Length > 0 Then
                Me.body.Attributes.Add("onload", "alert('ATENCION:\n" & strRutsCursoRepetido & strRutsTopeHorario & "');")
            End If

           
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:btnActualizaListaAlumnos_Click-->" & ex.Message)
        End Try
    End Sub
#Region "Alertas"
    Protected Function AlertAlumnoConTopeFechas(ByVal RutAlumno As Long) As Boolean
        Dim blnResultado As Boolean = False
        Try
            objAlumno = New CAlumno
            Return objAlumno.ValidacionAlumnoConTopeFechas(RutAlumno, CDate(Me.txtFechaInicio.Text.Trim), CDate(Me.txtFechaFin.Text.Trim), ViewState("CodCurso"))
        Catch ex As Exception
            EnviaError("modulo_cursos/mantenedor_cursos:AlertAlumnoConTopeFechas-->" & ex.Message)
            Return blnResultado
        End Try
    End Function

    Protected Function AlertAlumnoConCursoRepetido(ByVal RutAlumno As Long) As Boolean
        Dim blnResultado As Boolean = False
        Try
            objAlumno = New CAlumno
            Return objAlumno.ValidacionAlumnoConCursoRepetido(RutAlumno, CDate(Me.txtFechaInicio.Text.Trim).Year, Me.txtCodSence.Text.Trim, ViewState("CodCurso"))
        Catch ex As Exception
            EnviaError("modulo_cursos/mantenedor_cursos:AlertAlumnoConCursoRepetido-->" & ex.Message)
            Return blnResultado
        End Try
    End Function

#End Region
    Protected Sub grdAlumnos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAlumnos.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).CssClass = "locked"
                e.Row.Cells(1).CssClass = "locked"
                e.Row.Cells(2).CssClass = "locked"
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(0).CssClass = "locked"
                e.Row.Cells(1).CssClass = "locked"
                e.Row.Cells(2).CssClass = "locked"

                Dim lblContador As Label
                lblContador = CType(e.Row.FindControl("lblContador"), Label)
                lblContador.Text = intContador

                intContador = intContador + 1

                objWeb = New CWeb
                objLookups = New Clookups
                CType(e.Row.FindControl("txtRut"), TextBox).Visible = True
                CType(e.Row.FindControl("txtNombres"), TextBox).Visible = True
                CType(e.Row.FindControl("txtApellidoPat"), TextBox).Visible = True
                CType(e.Row.FindControl("txtApellidoMat"), TextBox).Visible = True
                CType(e.Row.FindControl("ddlSexo"), DropDownList).Visible = True
                objWeb.LlenaDDL(CType(e.Row.FindControl("ddlSexo"), DropDownList), objLookups.sexo, "sexo_v", "sexo_t")
                CType(e.Row.FindControl("ddlRegion"), DropDownList).Visible = True
                objWeb.LlenaDDL(CType(e.Row.FindControl("ddlRegion"), DropDownList), objLookups.regionesPorCodigos, "cod_region", "nombre")
                CType(e.Row.FindControl("ddlNivelOcup"), DropDownList).Visible = True
                objWeb.LlenaDDL(CType(e.Row.FindControl("ddlNivelOcup"), DropDownList), objLookups.nivel_ocupacional_por_codigo, "cod_nivel_ocup", "nombre")
                CType(e.Row.FindControl("ddlFranquicia"), DropDownList).Visible = True
                objWeb.LlenaDDL(CType(e.Row.FindControl("ddlFranquicia"), DropDownList), objLookups.franquicia, "franquicia_v", "franquicia_t")
                CType(e.Row.FindControl("ddlNivelEduc"), DropDownList).Visible = True
                objWeb.LlenaDDL(CType(e.Row.FindControl("ddlNivelEduc"), DropDownList), objLookups.nivel_educacional_por_codigo, "cod_nivel_educ", "nombre")
                CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList).Visible = True
                CType(e.Row.FindControl("ddlPaisParicipante"), DropDownList).Visible = True
                If CType(e.Row.FindControl("hdfCodRegion"), HiddenField).Value <> "" Then
                    'objWeb.LlenaDDL(CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList), objLookups.comunasRegion(CType(e.Row.FindControl("hdfCodRegion"), HiddenField).Value), "cod_comuna", "nombre")
                    objWeb.LlenaDDL(CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList), objLookups.comunas(), "cod_comuna", "nombre")
                Else
                    objWeb.LlenaDDL(CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList), objLookups.comunas(), "cod_comuna", "nombre")
                End If
                If CType(e.Row.FindControl("hdfCodPais"), HiddenField).Value <> "" Then
                    objWeb.LlenaDDL(CType(e.Row.FindControl("ddlPaisParicipante"), DropDownList), objLookups.pais(), "cod_pais", "nombre_pais")
                Else
                    objWeb.LlenaDDL(CType(e.Row.FindControl("ddlPaisParicipante"), DropDownList), objLookups.pais(), "cod_pais", "nombre_pais")
                End If
                If CType(e.Row.FindControl("txtNombres"), TextBox).Text <> "" Then
                    'CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblFranquicia"), Label).Text
                    If CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 1 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 100 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 100
                    ElseIf CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 0.5 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 50 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 50
                    ElseIf CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 0.15 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 15 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 15
                    End If
                    CType(e.Row.FindControl("ddlSexo"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblSexo"), Label).Text
                    CType(e.Row.FindControl("ddlRegion"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblRegion"), Label).Text
                    CType(e.Row.FindControl("ddlNivelOcup"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblNivelOcup"), Label).Text
                    CType(e.Row.FindControl("ddlNivelEduc"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblNivelOcup"), Label).Text
                    CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblComuna"), Label).Text
                    CType(e.Row.FindControl("ddlPaisParicipante"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblPais"), Label).Text
                End If

                If CType(e.Row.FindControl("hdfExiste"), HiddenField).Value = 1 Then
                    CType(e.Row.FindControl("ddlSexo"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblSexo"), Label).Text
                    CType(e.Row.FindControl("ddlRegion"), DropDownList).SelectedValue = CType(e.Row.FindControl("hdfCodRegion"), HiddenField).Value
                    CType(e.Row.FindControl("ddlNivelOcup"), DropDownList).SelectedValue = CType(e.Row.FindControl("hdfNivelOcup"), HiddenField).Value
                    'CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblFranquicia"), Label).Text
                    If CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 1 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 100 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 100
                    ElseIf CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 0.5 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 50 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 50
                    ElseIf CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 0.15 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 15 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 15
                    End If
                    CType(e.Row.FindControl("ddlNivelEduc"), DropDownList).SelectedValue = CType(e.Row.FindControl("hdfNivelEduc"), HiddenField).Value
                    CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue = CType(e.Row.FindControl("hdfComuna"), HiddenField).Value
                    CType(e.Row.FindControl("ddlPaisParicipante"), DropDownList).SelectedValue = CType(e.Row.FindControl("hdfCodPais"), HiddenField).Value
                Else
                    CType(e.Row.FindControl("ddlSexo"), DropDownList).SelectedValue = "M"
                    CType(e.Row.FindControl("ddlRegion"), DropDownList).SelectedValue = 13
                    CType(e.Row.FindControl("ddlNivelOcup"), DropDownList).SelectedValue = 4
                    CType(e.Row.FindControl("ddlNivelEduc"), DropDownList).SelectedValue = 5
                    CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue = 132101
                    CType(e.Row.FindControl("ddlPaisParicipante"), DropDownList).SelectedValue = 1

                    'CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 100
                    If CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 1 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 100 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 100
                    ElseIf CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 0.5 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 50 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 50
                    ElseIf CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 0.15 Or CType(e.Row.FindControl("hdfFranquicia"), HiddenField).Value = 15 Then
                        CType(e.Row.FindControl("ddlFranquicia"), DropDownList).SelectedValue = 15
                    End If

                    'CType(e.Row.FindControl("ddlComuna"), DropDownList).SelectedValue = 132101
                    If CType(e.Row.FindControl("hdfCodRegion"), HiddenField).Value <> "" Then
                        'objWeb.LlenaDDL(CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList), objLookups.comunasRegion(CType(e.Row.FindControl("ddlRegion"), DropDownList).SelectedValue), "cod_comuna", "nombre")
                        objWeb.LlenaDDL(CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList), objLookups.comunas(), "cod_comuna", "nombre")
                    Else
                        objWeb.LlenaDDL(CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList), objLookups.comunas(), "cod_comuna", "nombre")
                    End If
                    CType(e.Row.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblComuna"), Label).Text
                    CType(e.Row.FindControl("ddlPaisParicipante"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblPais"), Label).Text
                End If
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:grdAlumnos_RowDataBound-->" & ex.Message)
        End Try
    End Sub

    Protected Sub AgregarAlumnos(ByVal strRut() As String)
        Try
            Dim CantidadInicial As Integer = 0
            If IsNumeric(Me.hdfNumParticipantes.Value) Then
                CantidadInicial = CInt(Me.hdfNumParticipantes.Value)
            Else
                CantidadInicial = 0
            End If


            Dim strRutsErroneos As String = ""
            Dim strRutsYaCargados As String = ""

            If PermitirMasParticipantes(strRut) Then
                Dim dt As New DataTable
                dt.Columns.Add("rut")
                dt.Columns.Add("nombres")
                dt.Columns.Add("apellido_paterno")
                dt.Columns.Add("apellido_materno")
                dt.Columns.Add("sexo")
                dt.Columns.Add("cod_region")
                dt.Columns.Add("region")
                dt.Columns.Add("cod_nivel_ocupacional")
                dt.Columns.Add("nivel_ocupacional")
                dt.Columns.Add("franquicia")
                dt.Columns.Add("viatico")
                dt.Columns.Add("traslado")
                dt.Columns.Add("porc_asistencia")
                dt.Columns.Add("cod_nivel_educacional")
                dt.Columns.Add("nivel_educacional")
                dt.Columns.Add("fecha_nacimiento")
                dt.Columns.Add("cod_comuna")
                dt.Columns.Add("comuna")
                dt.Columns.Add("cod_pais")
                dt.Columns.Add("pais")
                dt.Columns.Add("fono")
                dt.Columns.Add("email")
                dt.Columns.Add("existe")
                dt.Columns.Add("RutLNG", Type.GetType("System.Int32"))
                Dim dr As DataRow
                Dim grow As GridViewRow
                For Each grow In grdAlumnos.Rows
                    If Not CType(grow.FindControl("txtRUT"), TextBox).Text.Trim = "" Then
                        If validarut(CType(grow.FindControl("txtRUT"), TextBox).Text.Trim) Then
                            dr = dt.NewRow
                            dr("rut") = CType(grow.FindControl("txtRUT"), TextBox).Text.Trim
                            dr("nombres") = CType(grow.FindControl("txtNombres"), TextBox).Text.Trim
                            dr("apellido_paterno") = CType(grow.FindControl("txtApellidoPat"), TextBox).Text.Trim
                            dr("apellido_materno") = CType(grow.FindControl("txtApellidoMat"), TextBox).Text.Trim
                            dr("sexo") = CType(grow.FindControl("ddlSexo"), DropDownList).SelectedValue
                            dr("cod_region") = CType(grow.FindControl("ddlRegion"), DropDownList).SelectedValue
                            dr("region") = CType(grow.FindControl("lblRegion"), Label).Text
                            dr("cod_nivel_ocupacional") = CType(grow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                            dr("nivel_ocupacional") = CType(grow.FindControl("lblNivelOcup"), Label).Text
                            dr("franquicia") = CType(grow.FindControl("ddlFranquicia"), DropDownList).SelectedValue
                            If CType(grow.FindControl("txtViatico"), TextBox).Text = "" Then
                                dr("viatico") = 0
                            Else
                                dr("viatico") = CType(grow.FindControl("txtViatico"), TextBox).Text.Trim
                            End If
                            If CType(grow.FindControl("txtTraslado"), TextBox).Text = "" Then
                                dr("traslado") = 0
                            Else
                                dr("traslado") = CType(grow.FindControl("txtTraslado"), TextBox).Text.Trim
                            End If
                            If CType(grow.FindControl("hdfAsistencia"), HiddenField).Value = "" Then
                                dr("porc_asistencia") = 0
                            Else
                                dr("porc_asistencia") = CType(grow.FindControl("hdfAsistencia"), HiddenField).Value
                            End If

                            dr("cod_nivel_educacional") = CType(grow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                            dr("nivel_educacional") = CType(grow.FindControl("lblNivelEduc"), Label).Text
                            If EsFechaValidaVB(CType(grow.FindControl("txtFechaNac"), TextBox).Text) Then
                                dr("fecha_nacimiento") = Left(FechaUsrAVb(CType(grow.FindControl("txtFechaNac"), TextBox).Text).Date.ToString, 10)
                            Else
                                dr("fecha_nacimiento") = Now.Date.ToShortDateString
                            End If
                            dr("cod_comuna") = CType(grow.FindControl("ddlComunaParicipante"), DropDownList).SelectedValue
                            dr("comuna") = CType(grow.FindControl("lblComuna"), Label).Text
                            dr("cod_pais") = CType(grow.FindControl("ddlPaisParicipante"), Label).Text
                            dr("pais") = CType(grow.FindControl("lblPais"), Label).Text
                            dr("existe") = CType(grow.FindControl("hdfExiste"), HiddenField).Value
                            If CType(grow.FindControl("txtFono"), TextBox).Text = "" Then
                                dr("fono") = ""
                            Else
                                dr("fono") = CType(grow.FindControl("txtFono"), TextBox).Text.Trim
                            End If
                            If CType(grow.FindControl("txtEmail"), TextBox).Text = "" Then
                                dr("email") = 0
                            Else
                                dr("email") = CType(grow.FindControl("txtEmail"), TextBox).Text.Trim
                            End If
                            dr("RutLNG") = RutUsrALng(CType(grow.FindControl("txtRUT"), TextBox).Text.Trim)
                            dt.Rows.Add(dr)
                        Else
                            strRutsErroneos = strRutsErroneos & CType(grow.FindControl("txtRUT"), TextBox).Text.Trim & ", "
                        End If
                    End If
                Next


                Dim i As Integer
                For i = 0 To TamanoArreglo1(strRut) - 1
                    If validarut(strRut(i).Trim) Then
                        For Each dr In dt.Rows
                            If validarut(strRut(i).Trim) Then
                                If Replace(strRut(i).ToString.ToUpper.Trim, ".", "") = Replace(dr("rut").ToString.ToUpper.Trim, ".", "") Then
                                    strRutsYaCargados = strRutsYaCargados & strRut(i).Trim & ", "
                                    GoTo moveNext
                                End If
                            Else
                                strRutsErroneos = strRutsErroneos & strRut(i).Trim & ", "
                                GoTo moveNext
                            End If
                        Next

                        objMantenedor = New CMantenedorCursos
                        objMantenedor.inicializarPaso3()
                        objMantenedor.ConsultaAlumno(RutUsrALng(strRut(i).Trim))

                        dr = dt.NewRow
                        dr("rut") = objMantenedor.Participantes.Rows(0).Item(0)
                        dr("nombres") = objMantenedor.Participantes.Rows(0).Item(1)
                        dr("apellido_paterno") = objMantenedor.Participantes.Rows(0).Item(2)
                        dr("apellido_materno") = objMantenedor.Participantes.Rows(0).Item(3)
                        If objMantenedor.Participantes.Rows(0).Item(4) = "" Then
                            dr("sexo") = "M"
                        Else
                            dr("sexo") = objMantenedor.Participantes.Rows(0).Item(4)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(5).ToString = "" Then
                            dr("cod_region") = 13 'Region Metropolitana
                        Else
                            dr("cod_region") = objMantenedor.Participantes.Rows(0).Item(5)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(6) = "" Then
                            dr("region") = "Region Metropolitana"
                        Else
                            dr("region") = objMantenedor.Participantes.Rows(0).Item(6)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(7).ToString = "" Then
                            dr("cod_nivel_ocupacional") = 4
                        Else
                            dr("cod_nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(7)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(8) = "" Then
                            dr("nivel_ocupacional") = "Administrativos"
                        Else
                            dr("nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(8)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(9).ToString = "" Then
                            dr("franquicia") = 100
                        Else
                            dr("franquicia") = objMantenedor.Participantes.Rows(0).Item(9)
                        End If
                        dr("viatico") = objMantenedor.Participantes.Rows(0).Item(10)
                        dr("traslado") = objMantenedor.Participantes.Rows(0).Item(11)
                        dr("porc_asistencia") = objMantenedor.Participantes.Rows(0).Item(12)
                        If objMantenedor.Participantes.Rows(0).Item(13).ToString = "" Then
                            dr("cod_nivel_educacional") = 5
                        Else
                            dr("cod_nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(13)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(14).ToString = "" Then
                            dr("nivel_educacional") = "Licencia Media Completa"
                        Else
                            dr("nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(14)
                        End If
                        dr("fecha_nacimiento") = Left(objMantenedor.Participantes.Rows(0).Item(15), 10)
                        If objMantenedor.Participantes.Rows(0).Item(16).ToString = "" Then
                            dr("cod_comuna") = 132101
                        Else
                            dr("cod_comuna") = objMantenedor.Participantes.Rows(0).Item(16)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(17).ToString = "" Then
                            dr("comuna") = "SANTIAGO"
                        Else
                            dr("comuna") = objMantenedor.Participantes.Rows(0).Item(17)
                        End If
                        dr("existe") = objMantenedor.Participantes.Rows(0).Item(18)
                        If objMantenedor.Participantes.Rows(0).Item(19).ToString = "" Then
                            dr("cod_pais") = 1
                        Else
                            dr("cod_pais") = objMantenedor.Participantes.Rows(0).Item(19)
                        End If
                        If objMantenedor.Participantes.Rows(0).Item(20).ToString = "" Then
                            dr("pais") = "CHILE"
                        Else
                            dr("pais") = objMantenedor.Participantes.Rows(0).Item(20)
                        End If
                        dr("fono") = objMantenedor.Participantes.Rows(0).Item(21)
                        dr("email") = objMantenedor.Participantes.Rows(0).Item(22)
                        dr("RutLNG") = RutUsrALng(objMantenedor.Participantes.Rows(0).Item(0))
                        dt.Rows.Add(dr)
                    Else
                        strRutsErroneos = strRutsErroneos & strRut(i).Trim & ", "
                        GoTo moveNext
moveNext:
                    End If

                Next


                'dt.DefaultView.Sort = "RutLNG asc"
                dt.AcceptChanges()

                Dim Cant As Integer
                For Cant = dt.Rows.Count To Me.txtNumParticipantes.Text.Trim - 1
                    dr = dt.NewRow
                    dr("rut") = ""
                    dr("nombres") = ""
                    dr("apellido_paterno") = ""
                    dr("apellido_materno") = ""
                    dr("sexo") = ""
                    dr("cod_region") = 13
                    dr("region") = "Santiago"
                    dr("cod_nivel_ocupacional") = 4
                    dr("nivel_ocupacional") = "Administrativos"
                    dr("franquicia") = 100
                    dr("viatico") = 0
                    dr("traslado") = 0
                    dr("porc_asistencia") = 0
                    dr("cod_nivel_educacional") = 5
                    dr("nivel_educacional") = "Licencia Media Completa"
                    dr("fecha_nacimiento") = Now.Date.ToShortDateString
                    dr("cod_comuna") = 132101
                    dr("comuna") = "SANTIAGO"
                    dr("existe") = 0
                    dr("cod_pais") = 1
                    dr("comuna") = "CHILE"
                    dr("fono") = ""
                    dr("email") = ""
                    dr("RutLNG") = 99999999
                    dt.Rows.Add(dr)
                Next
                ViewState("dtAlumnos") = dt

                objWeb = New CWeb
                objWeb.LlenaGrilla(grdAlumnos, ViewState("dtAlumnos"))
                objWeb = Nothing


                Me.txtNumParticipantes.Text = grdAlumnos.Rows.Count
                If CantidadInicial <> txtNumParticipantes.Text Then
                    body.Attributes.Add("onload", "alert('ATENCION: El número de alumnos es distinto al ingresado en el paso 1, debe volver y repasar los costos del curso.');")
                End If

                If strRutsErroneos.Length > 0 Then
                    If strRutsYaCargados.Length > 0 Then
                        strRutsErroneos = Left(strRutsErroneos, strRutsErroneos.Length - 2)
                        strRutsYaCargados = Left(strRutsYaCargados, strRutsYaCargados.Length - 2)
                        Me.body.Attributes.Add("onload", "alert('ATENCION: Los siguientes participantes no fueron cargados por:\n Rut incorrecto: \n" & strRutsErroneos & "\n Ya figuran en la nomina: \n" & strRutsYaCargados & "');")
                    Else
                        strRutsErroneos = Left(strRutsErroneos, strRutsErroneos.Length - 2)
                        Me.body.Attributes.Add("onload", "alert('ATENCION: Los siguientes participantes tienen el Rut incorrecto:\n" & strRutsErroneos & "');")
                    End If

                Else
                    If strRutsYaCargados.Length > 0 Then
                        strRutsYaCargados = Left(strRutsYaCargados, strRutsYaCargados.Length - 2)
                        Me.body.Attributes.Add("onload", "alert('ATENCION: Los siguientes participantes ya figuran en la nomina:\n" & strRutsYaCargados & "');")
                    End If
                End If

            Else
                body.Attributes.Add("onload", "alert('ATENCION: Ha alcanzado el máximo de participantes permitidos por Sence.');")
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas/mantenedor_cursos:ValidarMaximoPermitido-->" & ex.Message)
        End Try
    End Sub

    Protected Function PermitirMasParticipantes(ByVal strRuts() As String) As Boolean
        Try
            Dim permitir As Boolean = False
            Dim CantidadIngresada As Integer = 0

            Dim dr As DataRow
            For Each dr In ViewState("dtAlumnos").Rows
                If Not dr("rut") = "" Then
                    CantidadIngresada = CantidadIngresada + 1
                End If
            Next
            CantidadIngresada = CantidadIngresada + TamanoArreglo1(strRuts)
            If Me.hdfMAxParticipantes.Value >= CantidadIngresada Then
                permitir = True
            Else
                permitir = False
            End If
            Return permitir
        Catch ex As Exception
            EnviaError("modulo_cuentas/mantenedor_cursos:PermitirMasParticipantes-->" & ex.Message)
        End Try
    End Function
    Protected Sub btnBorrarHorario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBorrarHorario.Click
        Try
            If chkDia1.Checked = False And chkDia2.Checked = False And chkDia3.Checked = False And chkDia4.Checked = False And chkDia5.Checked = False _
            And chkDia6.Checked = False And chkDia7.Checked = False Then
                body.Attributes.Add("onload", "alert('ATENCION: Debe seleccionar los días que desea borrar.');")
                Exit Sub
            Else
                If chkDia1.Checked Then
                    txtHora1_1.Text = ""
                    txtMin1_1.Text = ""
                    txtHora2_1.Text = ""
                    txtMin2_1.Text = ""
                    txtHora3_1.Text = ""
                    txtMin3_1.Text = ""
                    txtHora4_1.Text = ""
                    txtMin4_1.Text = ""
                    txtHora5_1.Text = ""
                    txtMin5_1.Text = ""
                    txtHora6_1.Text = ""
                    txtMin6_1.Text = ""
                End If
                If chkDia2.Checked Then
                    txtHora1_2.Text = ""
                    txtMin1_2.Text = ""
                    txtHora2_2.Text = ""
                    txtMin2_2.Text = ""
                    txtHora3_2.Text = ""
                    txtMin3_2.Text = ""
                    txtHora4_2.Text = ""
                    txtMin4_2.Text = ""
                    txtHora5_2.Text = ""
                    txtMin5_2.Text = ""
                    txtHora6_2.Text = ""
                    txtMin6_2.Text = ""
                End If
                If chkDia3.Checked Then
                    txtHora1_3.Text = ""
                    txtMin1_3.Text = ""
                    txtHora2_3.Text = ""
                    txtMin2_3.Text = ""
                    txtHora3_3.Text = ""
                    txtMin3_3.Text = ""
                    txtHora4_3.Text = ""
                    txtMin4_3.Text = ""
                    txtHora5_3.Text = ""
                    txtMin5_3.Text = ""
                    txtHora6_3.Text = ""
                    txtMin6_3.Text = ""
                End If
                If chkDia4.Checked Then
                    txtHora1_4.Text = ""
                    txtMin1_4.Text = ""
                    txtHora2_4.Text = ""
                    txtMin2_4.Text = ""
                    txtHora3_4.Text = ""
                    txtMin3_4.Text = ""
                    txtHora4_4.Text = ""
                    txtMin4_4.Text = ""
                    txtHora5_4.Text = ""
                    txtMin5_4.Text = ""
                    txtHora6_4.Text = ""
                    txtMin6_4.Text = ""
                End If
                If chkDia5.Checked Then
                    txtHora1_5.Text = ""
                    txtMin1_5.Text = ""
                    txtHora2_5.Text = ""
                    txtMin2_5.Text = ""
                    txtHora3_5.Text = ""
                    txtMin3_5.Text = ""
                    txtHora4_5.Text = ""
                    txtMin4_5.Text = ""
                    txtHora5_5.Text = ""
                    txtMin5_5.Text = ""
                    txtHora6_5.Text = ""
                    txtMin6_5.Text = ""
                End If
                If chkDia6.Checked Then
                    txtHora1_6.Text = ""
                    txtMin1_6.Text = ""
                    txtHora2_6.Text = ""
                    txtMin2_6.Text = ""
                    txtHora3_6.Text = ""
                    txtMin3_6.Text = ""
                    txtHora4_6.Text = ""
                    txtMin4_6.Text = ""
                    txtHora5_6.Text = ""
                    txtMin5_6.Text = ""
                    txtHora6_6.Text = ""
                    txtMin6_6.Text = ""
                End If
                If chkDia7.Checked Then
                    txtHora1_7.Text = ""
                    txtMin1_7.Text = ""
                    txtHora2_7.Text = ""
                    txtMin2_7.Text = ""
                    txtHora3_7.Text = ""
                    txtMin3_7.Text = ""
                    txtHora4_7.Text = ""
                    txtMin4_7.Text = ""
                    txtHora5_7.Text = ""
                    txtMin5_7.Text = ""
                    txtHora6_7.Text = ""
                    txtMin6_7.Text = ""
                End If

            End If

        Catch ex As Exception
            EnviaError("modulo_cuentas/mantenedor_cursos:btnBorrarHorario_Click-->" & ex.Message)
        End Try
    End Sub
    'Protected Sub btnAgregarHorario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarHorario.Click
    '    Try
    '        'If Me.ddlHoraFin.SelectedValue <= Me.ddlHoraInicio.SelectedValue Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: La hora de fin debe ser mayor a la hora de inicio.');")
    '        '    Exit Sub
    '        'End If


    '        'If Me.txtHoraInicio.Text = "" Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar la hora de inicio.');")
    '        '    Me.txtHoraInicio.Focus()
    '        '    Exit Sub
    '        'End If
    '        'If Not IsNumeric(Me.txtHoraInicio.Text) Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar solo numeros.');")
    '        '    Me.txtHoraInicio.Focus()
    '        '    Exit Sub
    '        'End If
    '        'If Me.txtMinutoInicio.Text = "" Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar los minutos de la hora de inicio.');")
    '        '    Me.txtMinutoInicio.Focus()
    '        '    Exit Sub
    '        'End If
    '        'If Not IsNumeric(Me.txtMinutoInicio.Text) Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar solo numeros.');")
    '        '    Me.txtMinutoInicio.Focus()
    '        '    Exit Sub
    '        'End If
    '        'If Me.txtHoraFin.Text = "" Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar la hora de fin.');")
    '        '    Me.txtHoraFin.Focus()
    '        '    Exit Sub
    '        'End If
    '        'If Not IsNumeric(Me.txtHoraFin.Text) Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar solo numeros.');")
    '        '    Me.txtHoraFin.Focus()
    '        '    Exit Sub
    '        'End If
    '        'If Me.txtMinutoFin.Text = "" Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar los minutos de la hora de fin.');")
    '        '    Me.txtMinutoFin.Focus()
    '        '    Exit Sub
    '        'End If
    '        'If Not IsNumeric(Me.txtMinutoFin.Text) Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar solo numeros.');")
    '        '    Me.txtMinutoFin.Focus()
    '        '    Exit Sub
    '        'End If

    '        'If CLng(Me.txtHoraInicio.Text) < 0 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: La hora de inicio debe ser mayor a 0.');")
    '        '    Exit Sub
    '        'End If
    '        'If CLng(Me.txtHoraInicio.Text) > 23 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: La hora de inicio debe ser menor a 23.');")
    '        '    Exit Sub
    '        'End If
    '        'If CLng(Me.txtMinutoInicio.Text) < 0 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Los minutos de la hora de inicio debe ser mayor a 0.');")
    '        '    Exit Sub
    '        'End If
    '        'If CLng(Me.txtMinutoInicio.Text) > 59 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Los minutos de la hora de inicio debe ser menor a 59.');")
    '        '    Exit Sub
    '        'End If

    '        'If CLng(Me.txtHoraFin.Text) < 0 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: La hora de fin debe ser mayor a 0.');")
    '        '    Exit Sub
    '        'End If
    '        'If CLng(Me.txtHoraFin.Text) > 23 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: La hora de fin debe ser menor a 23.');")
    '        '    Exit Sub
    '        'End If
    '        'If CLng(Me.txtMinutoFin.Text) < 0 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Los minutos de la hora de fin debe ser mayor a 0.');")
    '        '    Exit Sub
    '        'End If
    '        'If CLng(Me.txtMinutoFin.Text) > 59 Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Los minutos de la hora de fin debe ser menor a 59.');")
    '        '    Exit Sub
    '        'End If

    '        'If CLng(Me.txtHoraFin.Text & Me.txtMinutoFin.Text) <= CLng(Me.txtHoraInicio.Text & Me.txtMinutoInicio.Text) Then
    '        '    body.Attributes.Add("onload", "alert('ATENCIÓN: La hora de fin debe ser mayor a la hora de inicio.');")
    '        '    Exit Sub
    '        'End If

    '        Dim dt As New DataTable
    '        Dim dr As DataRow
    '        If ViewState("dtHorario") Is Nothing Then
    '            dt.Columns.Add("DiaNombre")
    '            dt.Columns.Add("Dia")
    '            dt.Columns.Add("HoraInicio")
    '            dt.Columns.Add("HoraFin")
    '            dt.Columns.Add("CodCurso")
    '            dr = dt.NewRow
    '            'dr("Dia") = Me.ddlDias.SelectedValue
    '            'dr("DiaNombre") = Me.ddlDias.SelectedItem
    '            ''dr("HoraInicio") = Me.ddlHoraInicio.SelectedItem
    '            ''dr("HoraFin") = Me.ddlHoraFin.SelectedItem
    '            'dr("HoraInicio") = Me.txtHoraInicio.Text & ":" & Me.txtMinutoInicio.Text
    '            'dr("HoraFin") = Me.txtHoraFin.Text & ":" & Me.txtMinutoFin.Text
    '            'dr("CodCurso") = ViewState("CodCurso")
    '            'dt.Rows.Add(dr)
    '            'dt.DefaultView.Sort = "Dia asc"
    '            'ViewState("dtHorario") = dt
    '            'If dt.Rows.Count > 0 Then
    '            '    Me.btnActualizaLista.Visible = True
    '            'Else
    '            '    Me.btnActualizaLista.Visible = False
    '            'End If
    '        Else
    '            dt = ViewState("dtHorario")
    '            For Each dr In dt.Rows
    '                'If dr("Dia") = Me.ddlDias.SelectedValue And dr("HoraInicio") = Me.ddlHoraInicio.SelectedItem.ToString Then
    '                'If dr("Dia") = Me.ddlDias.SelectedValue And dr("HoraInicio") = Me.txtHoraInicio.Text & ":" & Me.txtMinutoInicio.Text Then
    '                '    body.Attributes.Add("onload", "alert('ATENCIÓN: Esta hora de inicio ya ha sido ingresado anteriormente para este día.');")
    '                '    Exit Sub
    '                'End If
    '            Next
    '            dr = dt.NewRow
    '            'dr("Dia") = Me.ddlDias.SelectedValue
    '            'dr("DiaNombre") = Me.ddlDias.SelectedItem
    '            ''dr("HoraInicio") = Me.ddlHoraInicio.SelectedItem
    '            ''dr("HoraFin") = Me.ddlHoraFin.SelectedItem
    '            'dr("HoraInicio") = Me.txtHoraInicio.Text & ":" & Me.txtMinutoInicio.Text
    '            'dr("HoraFin") = Me.txtHoraFin.Text & ":" & Me.txtMinutoFin.Text
    '            'dr("CodCurso") = ViewState("CodCurso")
    '            'dt.Rows.Add(dr)
    '            'dt.DefaultView.Sort = "Dia asc"
    '            'ViewState("dtHorario") = dt
    '            'If dt.Rows.Count > 0 Then
    '            '    Me.btnActualizaLista.Visible = True
    '            'Else
    '            '    Me.btnActualizaLista.Visible = False
    '            'End If
    '        End If
    '        LlenaHorario()
    '    Catch ex As Exception
    '        EnviaError("modulo_cursos/matenedor_cursos.aspx.vb:btnAgregarHorario_Click-->" & ex.Message)
    '    End Try
    'End Sub

    'Protected Sub btnActualizaLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizaLista.Click
    '    Try
    '        Dim dt As New DataTable
    '        dt = ViewState("dtHorario")
    '        Dim grdRow As GridViewRow
    '        'For Each grdRow In Me.grdHorario.Rows
    '        '    Dim chk As New CheckBox
    '        '    chk = CType(grdRow.FindControl("chkEliminar"), CheckBox)
    '        '    If chk.Checked Then
    '        '        Dim dr As DataRow
    '        '        For Each dr In dt.Rows
    '        '            If grdRow.Cells(0).Text = dr("DiaNombre") And grdRow.Cells(1).Text = dr("HoraInicio") And grdRow.Cells(2).Text = dr("HoraFin") Then
    '        '                dt.Rows.Remove(dr)
    '        '                Exit For
    '        '            End If
    '        '        Next
    '        '    End If
    '        'Next
    '        'dt.DefaultView.Sort = "Dia asc"
    '        'ViewState("dtHorario") = dt
    '        'If dt.Rows.Count > 0 Then
    '        '    Me.btnActualizaLista.Visible = True
    '        'Else
    '        '    Me.btnActualizaLista.Visible = False
    '        'End If
    '        LlenaHorario()
    '    Catch ex As Exception
    '        EnviaError("modulo_cursos/matenedor_cursos.aspx.vb:btnActualizaLista_Click-->" & ex.Message)
    '    End Try
    'End Sub

End Class