Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_mantenedor_cursos_internos
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objMantenedor As CMantenedorCursoInterno
    Private objSessionCliente As CSession
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '***********************************************************************************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            objWeb.ChequeaCliente(objSessionCliente)
            '***********************************************************************************
            body.Attributes.Clear()

            If Not Page.IsPostBack Then
                If objSession.EsClienteIngresoCurso Then
                    Me.hplIngresoCurso.Visible = True
                End If
                lblPie.Text = Parametros.p_PIE

                Me.wizardCursoInterno.ActiveStepIndex = 0

                Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=wizardCursoInterno$txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")

                Me.btnPopUpAlumno.Attributes.Add("onClick", "popup_pos('buscador_alumno.aspx?campo=wizardCursoInterno$txtRutAlumno', 'NewWindow3', 480, 700, 100, 100);return false;")

                If objSession.EsCliente Then
                    btnPopUpEmpresa.Visible = False
                    'Me.txtRutEmpresa.Text = RutLngAUsr(objSession.Rut)
                    Me.txtRutEmpresa.Text = RutLngAUsr(objSessionCliente.Rut)
                    Me.txtRutEmpresa.Enabled = False
                Else
                    btnPopUpEmpresa.Visible = True
                    'Me.txtRutEmpresa.Text = RutLngAUsr(objSessionCliente.Rut)
                    Me.txtRutEmpresa.Text = RutLngAUsr(objSession.Rut)
                    Me.txtRutEmpresa.Enabled = True
                End If

                ViewState("Correlativo") = Request("Correlativo")
                ViewState("Agno") = Request("Agno")
                hdfAgno.Value = Request("Agno")

                '************************  Paso 1  *******************************************************
                objWeb.LlenaDDL(Me.ddlComuna, objLookups.comunas, "cod_comuna", "nombre")
                objWeb.LlenaDDL(Me.ddlAgnoInicio, objLookups.Agnos, "Agno_v", "Agno_t")
                ddlAgnoInicio.SelectedValue = Now.Year()
                '*****************************************************************************************
                '************************  Paso 2  *******************************************************
                objWeb.SeteaGrilla(Me.grdAlumnos, 2500, "")
                '*****************************************************************************************

                objMantenedor = New CMantenedorCursoInterno
                Session("objeto") = objMantenedor
                Me.txtValorCurso.Attributes.Add("onblur", "CalculaValorFinal();")
                Me.txtDescuento.Attributes.Add("onblur", "CalculaValorFinal();")

                If Not ViewState("Correlativo") Is Nothing Then
                    ViewState("modo") = "actualizar"
                    objMantenedor = New CMantenedorCursoInterno
                    objMantenedor.RutUsuario = objSession.Rut
                    objMantenedor.Correlativo = ViewState("Correlativo")
                    objMantenedor.Agno = ViewState("Agno")
                    objMantenedor.InicializarCursoExistente()
                    CargarDatos()
                Else
                    Me.calFechaInicio.SelectedDate = DateAdd(DateInterval.Day, 1, Now.Date)
                    Me.calFechaFin.SelectedDate = DateAdd(DateInterval.Month, 1, Now.Date)
                    Me.ddlComuna.SelectedValue = 132101
                    ViewState("modo") = "insertar"

                End If
            End If
            hdfAgno.Value = Me.ddlAgnoInicio.SelectedValue
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_internos.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub StartNextButton_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            objMantenedor = New CMantenedorCursoInterno
            'objSession = New CSession
            objMantenedor.NombreEmpresa(RutUsrALng(Me.txtRutEmpresa.Text.Trim))
            'objMantenedor.DatosCurso(Me.txtCodSence.Text.Trim)
            If Not ValidaDatosPaso1() Then
                wizardCursoInterno.ActiveStepIndex = 0
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            Else
                objMantenedor.inicializarPaso1()
                objMantenedor.RutUsuario = objSession.Rut
                objMantenedor.RutEmpresa = RutUsrALng(Me.txtRutEmpresa.Text.Trim)
                objMantenedor.NumParticipantes = Me.txtNumParticipantes.Text.Trim
                objMantenedor.Direccion = Me.txtDireccion.Text.Trim
                objMantenedor.Comuna = Me.ddlComuna.SelectedValue
                objMantenedor.Observaciones = Me.txtObservacion.Text.Trim
                objMantenedor.Ejecutor = Me.txtEjecutor.Text.Trim
                objMantenedor.NombreCurso = Me.txtNombreCurso.Text.Trim
                objMantenedor.Horario = Me.txtHorarioCurso.Text.Trim
                objMantenedor.Horas = Me.txtHorasCurso.Text.Trim
                objMantenedor.Agno = Me.ddlAgnoInicio.SelectedValue
                objMantenedor.FechaInicio = FechaUsrAVb(Me.calFechaInicio.SelectedValue)
                objMantenedor.FechaFin = FechaUsrAVb(Me.calFechaFin.SelectedValue)
                objMantenedor.ValorCurso = CLng(Me.txtValorCurso.Text.Trim)
                objMantenedor.Descuento = CLng(Me.txtDescuento.Text.Trim)
                'If Me.txtValorMasDescuento.Text.Trim = 0 Then
                Me.txtValorMasDescuento.Text = CLng(Me.txtValorCurso.Text) + CLng(Me.txtDescuento.Text)
                'End If
                objMantenedor.ValorFinal = CLng(Me.txtValorMasDescuento.Text.Trim)
                objMantenedor.CorrEmpresa = Me.txtCorrelEmpresa.Text.Trim
                If Not ViewState("modo") = "insertar" Then
                    objMantenedor.Correlativo = Me.hdfCorrelativo.Value
                End If

                ViewState("ValorXparticipante") = CLng(Me.txtValorMasDescuento.Text.Trim) / CLng(Me.txtNumParticipantes.Text.Trim)

                objMantenedor.Modo = ViewState("modo")
                objMantenedor.GrabarPaso1()
                CargarDatos()
                ViewState("Correlativo") = objMantenedor.Correlativo
                'ViewState("Agno") = objMantenedor.Agno
                ViewState("modo") = "actualizar"
                wizardCursoInterno.ActiveStepIndex = 1

                '***********************************************************
                Dim dt1 As New DataTable
                Dim dr1 As DataRow
                Dim t As Integer
                dt1 = ViewState("dtAlumnos")

                For t = 1 To (Val(Me.txtNumParticipantes.Text) - Val(Me.grdAlumnos.Rows.Count))
                    dr1 = dt1.NewRow
                    dr1("rut") = ""
                    dr1("nombres") = ""
                    dr1("apellido_paterno") = ""
                    dr1("apellido_materno") = ""
                    dr1("sexo") = "M"
                    dr1("cod_region") = "13"
                    'dr1("region") = ""
                    dr1("cod_nivel_ocupacional") = "0"
                    'dr1("nivel_ocupacional") = "0"
                    dr1("franquicia") = "1"
                    dr1("viatico") = "0"
                    dr1("traslado") = "0"
                    'dr1("porc_asistencia") = 0
                    dr1("cod_nivel_educacional") = 0
                    'dr1("nivel_educacional") = "0"
                    dr1("fecha_nacimiento") = Now()
                    dr1("cod_comuna") = "0"
                    dr1("comuna") = "SANTIAGO"
                    dr1("existe") = "0"
                    dt1.Rows.Add(dr1)
                Next t

                objWeb = New CWeb
                objWeb.LlenaGrilla(Me.grdAlumnos, dt1)
                objWeb = Nothing


                '***********************************************************
            End If
            Session("objeto") = objMantenedor
            Me.hdfEnvioDatos.Value = 0
        Catch ex As Exception
            Me.hdfEnvioDatos.Value = 0
            EnviaError("modulo_cuentas/matenedor_cursos_internos.aspx.vb:StartNextButton_Click-->" & ex.Message)
        End Try
    End Sub


    Protected Sub FinishButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.wizardCursoInterno.ActiveStepIndex = 1 Then
                objMantenedor = New CMantenedorCursoInterno
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
                objMantenedor = Session("objeto")
                objMantenedor.inicializarPaso2()

                objMantenedor.Agno = Me.ddlAgnoInicio.SelectedValue

                Dim dt As New DataTable
                dt.Columns.Add("rut")
                dt.Columns.Add("nombres")
                dt.Columns.Add("apellido_paterno")
                dt.Columns.Add("apellido_materno")
                dt.Columns.Add("sexo")
                dt.Columns.Add("viatico")
                dt.Columns.Add("traslado")
                'dt.Columns.Add("cod_region")
                'dt.Columns.Add("region")
                'dt.Columns.Add("cod_nivel_ocupacional")
                'dt.Columns.Add("nivel_ocupacional")
                'dt.Columns.Add("franquicia")
                'dt.Columns.Add("cod_nivel_educacional")
                'dt.Columns.Add("nivel_educacional")
                'dt.Columns.Add("fecha_nacimiento")
                'dt.Columns.Add("cod_comuna")
                'dt.Columns.Add("comuna")
                dt.Columns.Add("existe")
                dt.Columns.Add("cod_estado_part")
                Dim dr As DataRow
                Dim grdRow As GridViewRow
                For Each grdRow In Me.grdAlumnos.Rows
                    dr = dt.NewRow
                    ' dr("rut") = CType(grdRow.FindControl("lblRut"), Label).Text
                    dr("rut") = CType(grdRow.FindControl("txtRut"), TextBox).Text.Trim
                    If Not validarut(dr("rut")) Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: El rut " & dr("rut") & " no es válido.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    objMantenedor = New CMantenedorCursoInterno
                    objMantenedor.inicializarPaso2()
                    objMantenedor.ConsultaAlumno(RutUsrALng(dr("rut")))


                    If CType(grdRow.FindControl("txtNombres"), TextBox).Text.Trim = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("nombres") = CType(grdRow.FindControl("txtNombres"), TextBox).Text.Trim
                    If CType(grdRow.FindControl("txtApellidoPat"), TextBox).Text = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("apellido_paterno") = CType(grdRow.FindControl("txtApellidoPat"), TextBox).Text.Trim
                    If CType(grdRow.FindControl("txtApellidoMat"), TextBox).Text = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("apellido_materno") = CType(grdRow.FindControl("txtApellidoMat"), TextBox).Text.Trim
                    dr("sexo") = CType(grdRow.FindControl("ddlSexo"), DropDownList).SelectedValue
                    'dr("cod_region") = CType(grdRow.FindControl("ddlRegion"), DropDownList).SelectedValue
                    'dr("region") = CType(grdRow.FindControl("ddlRegion"), DropDownList).SelectedItem
                    ''dr("region") = CType(grdRow.FindControl("lblRegion"), Label).Text
                    'dr("cod_nivel_ocupacional") = CType(grdRow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                    'dr("nivel_ocupacional") = CType(grdRow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                    ''dr("nivel_ocupacional") = CType(grdRow.FindControl("lblNivelOcup"), Label).Text
                    'dr("franquicia") = CType(grdRow.FindControl("ddlFranquicia"), DropDownList).SelectedValue
                    If CType(grdRow.FindControl("txtViatico"), TextBox).Text.Trim = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("viatico") = CType(grdRow.FindControl("txtViatico"), TextBox).Text.Trim
                    If CType(grdRow.FindControl("txtTraslado"), TextBox).Text.Trim = "" Then
                        body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar todos los datos de los participantes.');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                    dr("traslado") = CType(grdRow.FindControl("txtTraslado"), TextBox).Text.Trim
                    'dr("cod_nivel_educacional") = CType(grdRow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                    'dr("nivel_educacional") = CType(grdRow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                    ''dr("nivel_educacional") = CType(grdRow.FindControl("lblNivelEduc"), Label).Text
                    ''dr("fecha_nacimiento") = FechaUsrAVb(CType(grdRow.FindControl("calFechaNac"), eWorld.UI.CalendarPopup).SelectedValue)
                    'dr("fecha_nacimiento") = FechaUsrAVb(CType(grdRow.FindControl("txtFechaNac"), TextBox).Text)
                    'dr("cod_comuna") = CType(grdRow.FindControl("ddlComuna"), DropDownList).SelectedValue
                    'dr("comuna") = CType(grdRow.FindControl("ddlComuna"), DropDownList).SelectedValue
                    ''dr("comuna") = CType(grdRow.FindControl("lblComuna"), Label).Text
                    dr("existe") = objMantenedor.Participantes.Rows(0).Item(17) 'CType(grdRow.FindControl("hdfExiste"), HiddenField).Value
                    dr("cod_estado_part") = CType(grdRow.FindControl("ddlEstadoPart"), DropDownList).SelectedValue
                    'End If
                    dt.Rows.Add(dr)
                Next
                objMantenedor.Participantes = dt
                objMantenedor.Correlativo = ViewState("Correlativo")
                objSession.Agno = ViewState("Agno")
                If objSession.Agno = 0 Then
                    objSession.Agno = hdfAgno.Value
                End If
                objMantenedor.RutUsuario = objSession.Rut
                objMantenedor.Agno = objSession.Agno
                If objSessionCliente.Rut = 0 Then
                    objMantenedor.RutEmpresa = objSession.Rut
                Else
                    objMantenedor.RutEmpresa = objSessionCliente.Rut
                End If
                objMantenedor.NumParticipantes = Me.grdAlumnos.Rows.Count
                objMantenedor.ValorFinal = ViewState("ValorXparticipante") * objMantenedor.NumParticipantes
                objMantenedor.GrabarPaso2()
                CargarDatosAlumnos()
                Session("objeto") = objMantenedor
            End If
            Me.hdfEnvioDatos.Value = 0
        Catch ex As Exception
            Me.hdfEnvioDatos.Value = 0
            EnviaError("modulo_cuentas/matenedor_cursos_internos.aspx.vb:FinishButton_Click-->" & ex.Message)
        End Try
        Response.Redirect("../modulo_cuentas/ficha_curso_interno.aspx?CodCurso=" & objMantenedor.Correlativo & "&Agno=" & objSession.Agno)

    End Sub

    Public Function ValidaDatosPaso1() As Boolean
        Try
            ValidaDatosPaso1 = True

            If Me.txtRutEmpresa.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el rut de la empresa');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Not objMantenedor.ExisteEmpresa(RutUsrALng(Me.txtRutEmpresa.Text.Trim)) Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El Rut de empresa no se encuentra en nuestros registros.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.txtNumParticipantes.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El número de participantes debe ser del al menos 1.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.txtDireccion.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar una dirección');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.txtEjecutor.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un ejecutor');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.txtNombreCurso.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el nombre del curso');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.txtHorarioCurso.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el horario del curso');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If IsNumeric(Me.txtHorasCurso.Text) Then
                If Me.txtHorasCurso.Text.Trim = "" Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar las horas totales del curso');")
                    ValidaDatosPaso1 = False
                    Exit Function
                End If
            Else
                body.Attributes.Add("onload", "alert('ATENCIÓN: Las horas del curso deben ser números enteros');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Not Me.txtNumParticipantes.Text.Trim > 0 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El número de participantes debe ser mayor a 0.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If

            If Me.calFechaInicio.SelectedDate.Year <> Me.ddlAgnoInicio.SelectedValue Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: El año de inicio y la fecha de inicio no concuerdan.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.calFechaInicio.SelectedDate > Me.calFechaFin.SelectedDate Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: La fecha de inicio no puede ser mayor a la fecha de fin.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.calFechaFin.SelectedDate.Year > Me.calFechaInicio.SelectedDate.Year + 1 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: La fecha de término debe estar a lo más dentro año siguiente al de la fecha de inicio.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.calFechaFin.SelectedDate.Year = Me.calFechaFin.SelectedDate.Year + 1 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Si el año de la fecha de fin es mayor al de la fecha de inicio.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            If Me.txtValorCurso.Text.Trim = "" Or Me.txtDescuento.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Los campos 'Valor Curso' y 'Descuento' no deben estar vacios.');")
                ValidaDatosPaso1 = False
                Exit Function
            End If
            'If Not Me.txtValorCurso.Text.Trim > 0 Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: EL valor curso debe ser mayor que 0.');")
            '    ValidaDatosPaso1 = False
            '    Exit Function
            'End If
            'If Me.txtCorrelEmpresa.Text.Trim = "" Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar el correlativo de la empresa');")
            '    ValidaDatosPaso1 = False
            '    Exit Function
            'End If
            'If Not IsNumeric(Me.txtCorrelEmpresa.Text) Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: El correlativo de la empresa debe ser numerico');")
            '    ValidaDatosPaso1 = False
            '    Exit Function
            'End If

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:ValidaDatosPaso1-->" & ex.Message)
        End Try
    End Function
    Public Sub CalculaValorFinal()
        Try
            If Me.rdbDescMonto.Checked Then
                Me.txtValorMasDescuento.Text = Me.txtValorCurso.Text - Me.txtDescuento.Text
            ElseIf Me.rdbDescPorcentaje.Checked Then
                Me.txtValorMasDescuento.Text = Me.txtValorCurso.Text - (Me.txtValorCurso.Text * Me.txtDescuento.Text / 100)
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:CalculaValorFinal-->" & ex.Message)
        End Try
    End Sub
    Protected Sub rdbDescMonto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDescMonto.CheckedChanged
        Try
            CalculaValorFinal()
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:rdbDescMonto_CheckedChanged-->" & ex.Message)
        End Try
    End Sub
    Protected Sub rdbDescPorcentaje_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDescPorcentaje.CheckedChanged
        Try
            CalculaValorFinal()
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:rdbDescPorcentaje_CheckedChanged-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnTotal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTotal.Click
        Try
            CalculaValorFinal()
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:btnTotal_Click-->" & ex.Message)
        End Try
    End Sub
    
    Protected Sub btnAgregarAlumno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarAlumno.Click
        Try
            If Me.txtRutAlumno.Text = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar un Rut de alumno.');")
                Exit Sub
            End If
            'Dim participante As Long
            'If Me.txtNumParticipantes.Text = "" Then
            '    participante = 0
            'Else
            '    Me.txtNumParticipantes.Text = participante
            'End If
            If Me.txtNumParticipantes.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar en el paso anterior la cantidad de alumnos.');")
                Exit Sub
            End If
            'If Me.txtNumParticipantes.Text = Me.grdAlumnos.Rows.Count Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: Ya se ha ingresado el máximo de alumnos permitido para este curso.');")
            '    Exit Sub
            'End If
            'objMantenedor = Session("objeto")
            objMantenedor = New CMantenedorCursoInterno
            objMantenedor.inicializarPaso2()
            objMantenedor.ConsultaAlumno(RutUsrALng(Me.txtRutAlumno.Text))

            Dim dt As New DataTable
            Dim dr As DataRow
            ViewState("dtAlumnos") = Nothing
            If ViewState("dtAlumnos") Is Nothing Then
                dt.Columns.Add("rut")
                dt.Columns.Add("nombres")
                dt.Columns.Add("apellido_paterno")
                dt.Columns.Add("apellido_materno")
                dt.Columns.Add("sexo")
                dt.Columns.Add("cod_region")
                'dt.Columns.Add("region")
                dt.Columns.Add("cod_nivel_ocupacional")
                'dt.Columns.Add("nivel_ocupacional")
                dt.Columns.Add("franquicia")
                dt.Columns.Add("viatico")
                dt.Columns.Add("traslado")
                dt.Columns.Add("cod_nivel_educacional")
                'dt.Columns.Add("nivel_educacional")
                dt.Columns.Add("fecha_nacimiento")
                dt.Columns.Add("cod_comuna")
                'dt.Columns.Add("comuna")
                dt.Columns.Add("existe")
                dt.Columns.Add("cod_estado_part")
            End If
            If grdAlumnos.Rows.Count > 0 Then
                Dim grdRow As GridViewRow
                For Each grdRow In grdAlumnos.Rows
                    dr = dt.NewRow
                    'dr("rut") = CType(grdRow.FindControl("lblRut"), Label).Text
                    dr("rut") = CType(grdRow.FindControl("txtRut"), TextBox).Text.Trim
                    dr("nombres") = CType(grdRow.FindControl("txtNombres"), TextBox).Text.Trim
                    dr("apellido_paterno") = CType(grdRow.FindControl("txtApellidoPat"), TextBox).Text.Trim
                    dr("apellido_materno") = CType(grdRow.FindControl("txtApellidoMat"), TextBox).Text.Trim
                    dr("sexo") = CType(grdRow.FindControl("ddlSexo"), DropDownList).SelectedValue
                    'dr("cod_region") = CType(grdRow.FindControl("ddlRegion"), DropDownList).SelectedValue
                    'dr("region") = CType(grdRow.FindControl("lblRegion"), Label).Text
                    'dr("cod_nivel_ocupacional") = CType(grdRow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                    'dr("nivel_ocupacional") = CType(grdRow.FindControl("lblNivelOcup"), Label).Text
                    'dr("franquicia") = CType(grdRow.FindControl("ddlFranquicia"), DropDownList).SelectedValue
                    dr("viatico") = CType(grdRow.FindControl("txtViatico"), TextBox).Text.Trim
                    dr("traslado") = CType(grdRow.FindControl("txtTraslado"), TextBox).Text.Trim
                    'dr("cod_nivel_educacional") = CType(grdRow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                    'dr("nivel_educacional") = CType(grdRow.FindControl("lblNivelEduc"), Label).Text
                    'dr("fecha_nacimiento") = Left(FechaUsrAVb(CType(grdRow.FindControl("txtFechaNac"), TextBox).Text), 10)
                    'dr("cod_comuna") = CType(grdRow.FindControl("ddlComuna"), DropDownList).SelectedValue
                    'dr("comuna") = CType(grdRow.FindControl("lblComuna"), Label).Text
                    dr("existe") = CType(grdRow.FindControl("hdfExiste"), HiddenField).Value
                    dr("cod_estado_part") = CType(grdRow.FindControl("ddlEstadoPart"), DropDownList).SelectedValue
                    dt.Rows.Add(dr)
                Next
            End If
            dr = dt.NewRow
            dr("rut") = objMantenedor.Participantes.Rows(0).Item(0)
            dr("nombres") = objMantenedor.Participantes.Rows(0).Item(1)
            dr("apellido_paterno") = objMantenedor.Participantes.Rows(0).Item(2)
            dr("apellido_materno") = objMantenedor.Participantes.Rows(0).Item(3)
            dr("sexo") = objMantenedor.Participantes.Rows(0).Item(4)
            dr("cod_region") = objMantenedor.Participantes.Rows(0).Item(5)
            'dr("region") = objMantenedor.Participantes.Rows(0).Item(6)
            dr("cod_nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(7)
            'dr("nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(8)
            dr("franquicia") = objMantenedor.Participantes.Rows(0).Item(9)
            dr("viatico") = objMantenedor.Participantes.Rows(0).Item(10)
            dr("traslado") = objMantenedor.Participantes.Rows(0).Item(11)
            dr("cod_nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(12)
            'dr("nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(13)
            dr("fecha_nacimiento") = Left(objMantenedor.Participantes.Rows(0).Item(14), 10)
            dr("cod_comuna") = objMantenedor.Participantes.Rows(0).Item(15)
            'dr("comuna") = objMantenedor.Participantes.Rows(0).Item(16)
            dr("existe") = objMantenedor.Participantes.Rows(0).Item(17)
            dr("cod_estado_part") = objMantenedor.Participantes.Rows(0).Item(18)
            dt.Rows.Add(dr)
            dt.DefaultView.Sort = "existe asc"
            ViewState("dtAlumnos") = dt
            If dt.Rows.Count > 0 Then
                Me.btnActualizaListaAlumnos.Visible = True
            Else
                Me.btnActualizaListaAlumnos.Visible = True
            End If

            '***********************************************************
            Dim dt1 As New DataTable
            Dim dr1 As DataRow
            Dim t As Integer
            dt1 = ViewState("dtAlumnos")

            For t = 1 To (Val(Me.txtNumParticipantes.Text) - Val(Me.grdAlumnos.Rows.Count))
                dr1 = dt1.NewRow
                dr1("rut") = ""
                dr1("nombres") = ""
                dr1("apellido_paterno") = ""
                dr1("apellido_materno") = ""
                dr1("sexo") = "M"
                dr1("cod_region") = "13"
                'dr1("region") = ""
                dr1("cod_nivel_ocupacional") = "0"
                'dr1("nivel_ocupacional") = "0"
                dr1("franquicia") = "1"
                dr1("viatico") = "0"
                dr1("traslado") = "0"
                'dr1("porc_asistencia") = 0
                dr1("cod_nivel_educacional") = 0
                'dr1("nivel_educacional") = "0"

                dr1("fecha_nacimiento") = Now()


                dr1("cod_comuna") = "0"
                'dr1("comuna") = "SANTIAGO"
                dr1("existe") = "0"
                dr("cod_estado_part") = 3
                dt1.Rows.Add(dr1)
            Next t

            Dim fil_control As Integer
            Dim fila_vacia As Integer
            fila_vacia = 10000
            For fil_control = 0 To dt1.Rows.Count - 1
                If dt1.Rows(fil_control).Item("rut") = "" Then
                    fila_vacia = fil_control
                End If
            Next fil_control
            If fila_vacia <> 10000 Then
                dt1.Rows.Remove(dt1.Rows(fila_vacia))
            End If
            For fil_control = 0 To dt1.Rows.Count - 1
                If dt1.Rows(fil_control).Item("rut") = "" Then
                    fila_vacia = fil_control
                End If
            Next fil_control
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdAlumnos, dt1)
            objWeb = Nothing

            Call btnActualizaListaAlumnos_Click(Me, e)

            '***************************************************************
            txtRutAlumno.Text = ""
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:btnAgregarAlumno_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdAlumnos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAlumnos.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                objWeb = New CWeb
                objLookups = New Clookups
                'CType(e.Row.FindControl("lblRut"), Label).Visible = True
                CType(e.Row.FindControl("txtRut"), TextBox).Visible = True
                CType(e.Row.FindControl("txtNombres"), TextBox).Visible = True
                CType(e.Row.FindControl("txtApellidoPat"), TextBox).Visible = True
                CType(e.Row.FindControl("txtApellidoMat"), TextBox).Visible = True
                CType(e.Row.FindControl("ddlSexo"), DropDownList).Visible = True
                CType(e.Row.FindControl("txtViatico"), TextBox).Visible = True
                CType(e.Row.FindControl("txtTraslado"), TextBox).Visible = True
                objWeb.LlenaDDL(CType(e.Row.FindControl("ddlSexo"), DropDownList), objLookups.sexo, "sexo_v", "sexo_t")
                CType(e.Row.FindControl("ddlEstadoPart"), DropDownList).Visible = True
                objWeb.LlenaDDL(CType(e.Row.FindControl("ddlEstadoPart"), DropDownList), objLookups.estado_participante_interno, "codigo", "descripcion")

                If CType(e.Row.FindControl("hdfExiste"), HiddenField).Value = 1 Then
                    CType(e.Row.FindControl("ddlSexo"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblSexo"), Label).Text
                    CType(e.Row.FindControl("ddlEstadoPart"), DropDownList).SelectedValue = CType(e.Row.FindControl("lblEstadoPart"), Label).Text
                Else
                    CType(e.Row.FindControl("ddlSexo"), DropDownList).SelectedValue = "M"
                    CType(e.Row.FindControl("ddlEstadoPart"), DropDownList).SelectedValue = 3
                  End If
            End If
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos.aspx.vb:grdAlumnos_RowDataBound-->" & ex.Message)
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


            Dim dt As New DataTable
            dt.Columns.Add("rut")
            dt.Columns.Add("nombres")
            dt.Columns.Add("apellido_paterno")
            dt.Columns.Add("apellido_materno")
            dt.Columns.Add("sexo")
            dt.Columns.Add("cod_region")
            'dt.Columns.Add("region")
            dt.Columns.Add("cod_nivel_ocupacional")
            'dt.Columns.Add("nivel_ocupacional")
            dt.Columns.Add("franquicia")
            dt.Columns.Add("viatico")
            dt.Columns.Add("traslado")
            dt.Columns.Add("cod_nivel_educacional")
            'dt.Columns.Add("nivel_educacional")
            dt.Columns.Add("fecha_nacimiento")
            dt.Columns.Add("cod_comuna")
            'dt.Columns.Add("comuna")
            dt.Columns.Add("existe")
            dt.Columns.Add("cod_estado_part")
            dt.Columns.Add("RutLNG", Type.GetType("System.Int32"))

            Dim dr As DataRow
            Dim grow As GridViewRow
            For Each grow In grdAlumnos.Rows
                If Not CType(grow.FindControl("txtRUT"), TextBox).Text.Trim = "" Then
                    If Not CType(grow.FindControl("txtNombres"), TextBox).Text.Trim = "" Then

                        dr = dt.NewRow
                        'dr("rut") = CType(grdRow.FindControl("lblRut"), Label).Text
                        dr("rut") = CType(grow.FindControl("txtRut"), TextBox).Text.Trim
                        dr("nombres") = CType(grow.FindControl("txtNombres"), TextBox).Text.Trim
                        dr("apellido_paterno") = CType(grow.FindControl("txtApellidoPat"), TextBox).Text.Trim
                        dr("apellido_materno") = CType(grow.FindControl("txtApellidoMat"), TextBox).Text.Trim
                        dr("sexo") = CType(grow.FindControl("ddlSexo"), DropDownList).SelectedValue
                        'dr("cod_region") = CType(grdRow.FindControl("ddlRegion"), DropDownList).SelectedValue
                        'dr("region") = CType(grdRow.FindControl("lblRegion"), Label).Text
                        'dr("cod_nivel_ocupacional") = CType(grdRow.FindControl("ddlNivelOcup"), DropDownList).SelectedValue
                        'dr("nivel_ocupacional") = CType(grdRow.FindControl("lblNivelOcup"), Label).Text
                        'dr("franquicia") = CType(grdRow.FindControl("ddlFranquicia"), DropDownList).SelectedValue
                        dr("viatico") = CType(grow.FindControl("txtViatico"), TextBox).Text.Trim
                        dr("traslado") = CType(grow.FindControl("txtTraslado"), TextBox).Text.Trim
                        'dr("cod_nivel_educacional") = CType(grdRow.FindControl("ddlNivelEduc"), DropDownList).SelectedValue
                        'dr("nivel_educacional") = CType(grdRow.FindControl("lblNivelEduc"), Label).Text
                        'dr("fecha_nacimiento") = Left(FechaUsrAVb(CType(grdRow.FindControl("txtFechaNac"), TextBox).Text), 10)
                        'dr("cod_comuna") = CType(grdRow.FindControl("ddlComuna"), DropDownList).SelectedValue
                        'dr("comuna") = CType(grdRow.FindControl("lblComuna"), Label).Text
                        dr("existe") = CType(grow.FindControl("hdfExiste"), HiddenField).Value
                        dr("cod_estado_part") = CType(grow.FindControl("ddlEstadoPart"), DropDownList).SelectedValue
                        dt.Rows.Add(dr)
                    Else
                        If validarut(CType(grow.FindControl("txtRUT"), TextBox).Text.Trim) Then
                            objMantenedor = New CMantenedorCursoInterno
                            objMantenedor.inicializarPaso2()
                            objMantenedor.ConsultaAlumno(RutUsrALng(CType(grow.FindControl("txtRUT"), TextBox).Text.Trim))

                            dr = dt.NewRow
                            dr("rut") = objMantenedor.Participantes.Rows(0).Item(0)
                            dr("nombres") = objMantenedor.Participantes.Rows(0).Item(1)
                            dr("apellido_paterno") = objMantenedor.Participantes.Rows(0).Item(2)
                            dr("apellido_materno") = objMantenedor.Participantes.Rows(0).Item(3)
                            dr("sexo") = objMantenedor.Participantes.Rows(0).Item(4)
                            dr("cod_region") = objMantenedor.Participantes.Rows(0).Item(5)
                            'dr("region") = objMantenedor.Participantes.Rows(0).Item(6)
                            dr("cod_nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(7)
                            'dr("nivel_ocupacional") = objMantenedor.Participantes.Rows(0).Item(8)
                            dr("franquicia") = objMantenedor.Participantes.Rows(0).Item(9)
                            dr("viatico") = objMantenedor.Participantes.Rows(0).Item(10)
                            dr("traslado") = objMantenedor.Participantes.Rows(0).Item(11)
                            dr("cod_nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(12)
                            'dr("nivel_educacional") = objMantenedor.Participantes.Rows(0).Item(13)
                            dr("fecha_nacimiento") = Left(objMantenedor.Participantes.Rows(0).Item(14), 10)
                            dr("cod_comuna") = objMantenedor.Participantes.Rows(0).Item(15)
                            'dr("comuna") = objMantenedor.Participantes.Rows(0).Item(16)
                            dr("existe") = objMantenedor.Participantes.Rows(0).Item(17)
                            dr("cod_estado_part") = objMantenedor.Participantes.Rows(0).Item(18)
                            dt.Rows.Add(dr)
                        Else
                            body.Attributes.Add("onload", "alert('ATENCION: El rut " & CType(grow.FindControl("txtRUT"), TextBox).Text.Trim & " no es Válido');")
                            Exit Sub
                        End If
                    End If
                End If
            Next

            For Each grow In grdAlumnos.Rows
                Dim chk As New CheckBox

                chk = CType(grow.FindControl("chkEliminarAlumno"), CheckBox)
                Dim lbl As New TextBox
                lbl = CType(grow.FindControl("txtRut"), TextBox)
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
            ' '' '' '' '' ''Dim dt As New DataTable
            ' '' '' '' '' ''dt = ViewState("dtAlumnos")
            ' '' '' '' '' ''Dim grdRow As GridViewRow
            ' '' '' '' '' ''For Each grdRow In Me.grdAlumnos.Rows
            ' '' '' '' '' ''    Dim chk As New CheckBox
            ' '' '' '' '' ''    chk = CType(grdRow.FindControl("chkEliminarAlumno"), CheckBox)
            ' '' '' '' '' ''    Dim txt As New TextBox
            ' '' '' '' '' ''    'lbl = CType(grdRow.FindControl("lblRut"), Label)
            ' '' '' '' '' ''    txt = CType(grdRow.FindControl("txtRut"), TextBox)
            ' '' '' '' '' ''    If chk.Checked Then
            ' '' '' '' '' ''        Dim dr As DataRow
            ' '' '' '' '' ''        For Each dr In dt.Rows
            ' '' '' '' '' ''            If txt.Text = dr("rut") Then
            ' '' '' '' '' ''                dt.Rows.Remove(dr)
            ' '' '' '' '' ''                Exit For
            ' '' '' '' '' ''            End If
            ' '' '' '' '' ''        Next
            ' '' '' '' '' ''    End If
            ' '' '' '' '' ''Next
            ' '' '' '' '' ''dt.DefaultView.Sort = "existe asc"
            ' '' '' '' '' ''ViewState("dtAlumnos") = dt
            ' '' '' '' '' ''If dt.Rows.Count > 0 Then
            ' '' '' '' '' ''    Me.btnActualizaListaAlumnos.Visible = True
            ' '' '' '' '' ''Else
            ' '' '' '' '' ''    Me.btnActualizaListaAlumnos.Visible = True
            ' '' '' '' '' ''End If
            ' '' '' '' '' ''objWeb = New CWeb
            ' '' '' '' '' ''objWeb.LlenaGrilla(Me.grdAlumnos, ViewState("dtAlumnos"))
            ' '' '' '' '' ''objWeb = Nothing
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:btnActualizaListaAlumnos_Click-->" & ex.Message)
        End Try
    End Sub
    Public Sub CargarDatos()
        Try
            '******************** PASO 1
            'Me.txtRutEmpresa.Text = RutLngAUsr(objMantenedor.RutEmpresa)
            If objSessionCliente.Rut = 0 Then
                Me.txtRutEmpresa.Text = RutLngAUsr(objSession.Rut)
            Else
                Me.txtRutEmpresa.Text = RutLngAUsr(objSessionCliente.Rut)
            End If
            'Me.txtRutEmpresa.Text = RutLngAUsr(objSession.Rut)
            Me.txtRutEmpresa.Enabled = False
            Me.txtNumParticipantes.Text = objMantenedor.NumParticipantes
            Me.txtDireccion.Text = objMantenedor.Direccion
            Me.ddlComuna.SelectedValue = objMantenedor.Comuna
            Me.ddlAgnoInicio.SelectedValue = objMantenedor.Agno
            Me.txtObservacion.Text = objMantenedor.Observaciones
            Me.txtEjecutor.Text = objMantenedor.Ejecutor
            Me.txtNombreCurso.Text = objMantenedor.NombreCurso
            Me.txtHorarioCurso.Text = objMantenedor.Horario
            Me.txtHorasCurso.Text = objMantenedor.Horas
            Me.calFechaInicio.SelectedValue = objMantenedor.FechaInicio
            Me.calFechaFin.SelectedValue = objMantenedor.FechaFin
            Me.txtValorCurso.Text = objMantenedor.ValorCurso
            Me.txtDescuento.Text = objMantenedor.Descuento
            Me.txtValorMasDescuento.Text = objMantenedor.ValorFinal
            Me.txtCorrelEmpresa.Text = objMantenedor.CorrEmpresa
            Me.hdfCorrelativo.Value = objMantenedor.Correlativo

            CalculaValorFinal()

            '******************** PASO 2
            ViewState("dtAlumnos") = objMantenedor.Participantes
            If objMantenedor.Participantes.Rows.Count > 0 Then
                Me.btnActualizaListaAlumnos.Visible = True
            Else
                Me.btnActualizaListaAlumnos.Visible = True
            End If
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdAlumnos, ViewState("dtAlumnos"))
            objWeb = Nothing

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:CargarDatos-->" & ex.Message)
        End Try
    End Sub
    Public Sub CargarDatosAlumnos()
        Try
            '******************** PASO 2
            ViewState("dtAlumnos") = objMantenedor.Participantes
            If objMantenedor.Participantes.Rows.Count > 0 Then
                Me.btnActualizaListaAlumnos.Visible = True
            Else
                Me.btnActualizaListaAlumnos.Visible = True
            End If
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdAlumnos, ViewState("dtAlumnos"))
            objWeb = Nothing
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:CargarDatosAlumnos-->" & ex.Message)
        End Try
    End Sub
    Protected Sub ddlAgnoInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAgnoInicio.SelectedIndexChanged
        hdfAgno.Value = Me.ddlAgnoInicio.SelectedValue
        ViewState("Agno") = hdfAgno.Value
    End Sub

    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Try
            Dim strRuta As String
            Dim strExtension As String
            Dim fileName As String
            fileName = FileUpload1.FileName
            strExtension = Right(fileName, 3).Trim.ToLower()
            If strExtension <> "xls" Then
                body.Attributes.Add("onload", "alert('ATENCION: El archivo debe ser en formato xls.');")
                Exit Sub
            End If
            strRuta = Me.FileUpload1.FileName
            strRuta = Parametros.p_DIRFISICO & "\contenido\tmp\" & "carga_participantes_internos_" & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & ".xls"
            FileUpload1.SaveAs(strRuta)
            objMantenedor = New CMantenedorCursoInterno
            objMantenedor.inicializarPaso2()
            If IsNumeric(Me.txtNumParticipantes.Text.Trim) Then
                If Not ViewState("dtAlumnos") Is Nothing Then
                    objMantenedor.Participantes = ViewState("dtAlumnos")
                End If
                objMantenedor.CargarParticipantes(Me.grdAlumnos, strRuta, Me.txtNumParticipantes.Text.Trim)
                ViewState("dtAlumnos") = objMantenedor.Participantes

                '***********************************************************
                Dim dt1 As New DataTable
                Dim dr1 As DataRow
                Dim t As Integer
                dt1 = ViewState("dtAlumnos")

                For t = 1 To (Val(Me.txtNumParticipantes.Text) - Val(Me.grdAlumnos.Rows.Count))
                    dr1 = dt1.NewRow
                    dr1("rut") = ""
                    dr1("nombres") = ""
                    dr1("apellido_paterno") = ""
                    dr1("apellido_materno") = ""
                    dr1("sexo") = "M"
                    dr1("cod_region") = "13"
                    'dr1("region") = ""
                    dr1("cod_nivel_ocupacional") = "0"
                    'dr1("nivel_ocupacional") = "0"
                    dr1("franquicia") = "1"
                    dr1("viatico") = "0"
                    dr1("traslado") = "0"
                    'dr1("porc_asistencia") = 0
                    dr1("cod_nivel_educacional") = 0
                    'dr1("nivel_educacional") = "0"
                    dr1("fecha_nacimiento") = Now()
                    dr1("cod_comuna") = "0"
                    dr1("comuna") = "SANTIAGO"
                    dr1("existe") = "0"
                    dt1.Rows.Add(dr1)
                Next t

                Dim fil_control As Integer
                Dim fila_vacia As Integer
                fila_vacia = 10000
                For fil_control = 0 To dt1.Rows.Count - 1
                    If dt1.Rows(fil_control).Item("rut") = "" Then
                        fila_vacia = fil_control
                    End If
                Next fil_control
                If fila_vacia <> 10000 Then
                    dt1.Rows.Remove(dt1.Rows(fila_vacia))
                End If
                For fil_control = 0 To dt1.Rows.Count - 1
                    If dt1.Rows(fil_control).Item("rut") = "" Then
                        fila_vacia = fil_control
                    End If
                Next fil_control
                objWeb = New CWeb
                objWeb.LlenaGrilla(Me.grdAlumnos, dt1)
                objWeb = Nothing

                Call btnActualizaListaAlumnos_Click(Me, e)

                '***************************************************************
                'objWeb.LlenaGrilla(Me.grdAlumnos, ViewState("dtAlumnos"))
            Else
                body.Attributes.Add("onload", "alert('El número de particpantes debe ser en formato numerico.');")
            End If

        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:btnCargar_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnSeleccionarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSeleccionarTodos.Click
        Try
            Dim grdRow As GridViewRow
            For Each grdRow In Me.grdAlumnos.Rows
                Dim chk As New CheckBox
                chk = CType(grdRow.FindControl("chkEliminarAlumno"), CheckBox)
                chk.Checked = True
            Next
            
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:btnSeleccionarTodos_Click-->" & ex.Message)
        End Try
    End Sub
End Class
