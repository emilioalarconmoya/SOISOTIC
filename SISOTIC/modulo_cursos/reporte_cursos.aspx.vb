Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_reporte_cursos
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objLookups As New Clookups
    Dim objReporteCurso As New CReporteAdminCurso
    Dim objCCambioEstados As New CCambioEstados

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            btnAutorizar.Visible = False
            btnComunicar.Visible = False
            btnLiquidar.Visible = False
            btnRechazar.Visible = False
            btnGenerar.Visible = False
            btnGenerarTodos.Visible = False
            btnGenerarZip.Visible = False
            If Not Page.IsPostBack Then
                
                lblPie.Text = Parametros.p_PIE
                ViewState("Estados") = Request("estados")
                ViewState("Tipo") = Request("tipo")
                ViewState("Origen") = Request("Origen")
                ViewState("Filtros") = Request("Filtros")
                ViewState("agno") = Request("agno")
                ViewState("resumen") = Request("resumen")
                ViewState("voucher") = Request("voucher")


                chkIngresados.Checked = True
                chkAutorizados.Checked = True
                chkComunicados.Checked = True
                chkEnComunicacion.Checked = True
                chkConAsistencia.Checked = True
                chkPagoPorAutorizar.Checked = True
                chkEnLiquidacion.Checked = True
                chkLiquidados.Checked = True

                Dim lngRut As Long
                lngRut = objSession.Rut
                objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")

                objWeb.LlenaDDL(ddlSeleccion, objLookups.Seleccion, "valor", "texto")

                If ViewState("resumen") = "si" Then
                    ddlAgnos.SelectedValue = Request("agno")
                    objReporteCurso.AgnoCurso = Request("agno")
                Else
                    ddlAgnos.SelectedValue = objSession.Agno
                    'objReporteCurso.AgnoCurso = Year(FechaMinSistema())
                End If

                objWeb.AgregaValorDDL(ddlTerceros, "Todos", 0)
                objWeb.AgregaValorDDL(ddlTerceros, "Reparto", 1)
                objWeb.AgregaValorDDL(ddlTerceros, "Exc. Reparto", 2)
                ddlTerceros.SelectedValue = 0
                objWeb.LlenaDDL(ddlEjecutivo, objLookups.Ejecutivo(lngRut), "rut", "nombres")
                objWeb.AgregaValorDDL(ddlEjecutivo, "", "0")
                objWeb.AgregaValorDDL(ddlEjecutivo, "Cursos propios", "1")
                objWeb.AgregaValorDDL(ddlEjecutivo, "Todos los ejecutivos", "2")
                'objWeb.LlenaDDL(ddlAgnos2, objLookups.Agnos2, "Agno_v", "Agno_t")
                'ddlAgnos2.SelectedValue = objSession.Agno
                ddlEjecutivo.SelectedValue = 0
                objWeb.SeteaGrilla(grdResultados, 50)
                ViewState("PrimeraVez") = 1
                btn_buscar_empresa.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow', 380, 700, 100, 100);return false;")
                btn_buscar_empresa2.Attributes.Add("onClick", "popup_pos('buscador_empresas.aspx?campo=txtRutEmpresa2', 'NewWindow', 380, 700, 100, 100);return false;")
                'btnLiqManualGrid.Attributes.Add("onClick", "return ConfirmDelete();")
                Me.calFechaInicio.SelectedDate = "01/01/" & objSession.Agno
                Me.calFechaFin.SelectedDate = "31/12/" & objSession.Agno
                Dim strOrigen As String
                strOrigen = ViewState("Origen")
                If strOrigen = "BuscarCursos" Then
                    objReporteCurso.AgnoCurso = Request("agno")
                    Consultar()
                End If
                Dim strEstados As String
                strEstados = ViewState("Estados")
                If Not strEstados Is Nothing Then
                    chkIngresados.Checked = False
                    chkAutorizados.Checked = False
                    chkComunicados.Checked = False
                    chkConAsistencia.Checked = False
                    chkEnComunicacion.Checked = False
                    chkEnLiquidacion.Checked = False
                    chkLiquidados.Checked = False
                    chkPagoPorAutorizar.Checked = False
                    Consultar()
                End If
                Dim strTipo As String
                strTipo = ViewState("Tipo")
                If Not strTipo Is Nothing Then
                    Consultar()
                End If
            Else
                ViewState("Tipo") = Request("tipo")
                ViewState("PrimeraVez") = 0
                objWeb.AgregaValorDDL(ddlAgnos, "1900", "1900")
                ddlAgnos.SelectedValue = 1900
                If Me.chkTerceros.Checked Then
                    Me.ddlTerceros.Visible = True
                Else
                    Me.ddlTerceros.Visible = False
                End If
            End If

            body.Attributes.Clear()
        Catch ex As Exception
            EnviaError("reporte_cursos:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            Dim strOrigen As String
            Dim strEstadoCursos As String
            Dim strTipoCursos As String
            Dim strEstados As String
            Dim strTipo As String
            Dim EjecutivoSeleccionado As Long
            strOrigen = ViewState("Origen")        
            strEstados = ViewState("Estados")
            strTipo = ViewState("Tipo")
            If strOrigen = "BuscarCursos" Then
                tablaFiltros.Visible = True
                tablaFiltros2.Visible = False
                btnConsultar.Visible = True
                Dim strAgno As String
                strAgno = ddlAgnos2.SelectedValue
                If txtRutEmpresa2.Text = "" Then
                    Dim strFiltros As String
                    strFiltros = ViewState("Filtros")
                    objReporteCurso.Where = strFiltros '& " And cc.agno = " & strAgno
                    objReporteCurso.Voucher = ViewState("voucher")
                Else
                    objReporteCurso.Where = " And cc.rut_cliente = " & RutUsrALng(txtRutEmpresa2.Text) '& " And cc.agno = " & strAgno
                End If
                'objReporteCurso.Tipo = 16
                objReporteCurso.RutUsuario = objSession.Rut
                objReporteCurso.BajarXml = chkBajarReporte.Checked
                objReporteCurso.FechaInicio = "01/01/2001"
                objReporteCurso.FechaFin = "31/12/" & objSession.Agno + 2
                ViewState("Origen") = "reporte"
            Else
                Dim lngPrimeraVez = ViewState("PrimeraVez")
                If lngPrimeraVez = 1 Then
                    EjecutivoSeleccionado = objSession.Rut
                Else
                    If (objSession.EsEjecutivo Or objSession.EsEjecutivoReg Or objSession.EsEjecutivoAutorizacion) And Not objSession.EsSupervisor Then
                        If ViewState("PrimeraVez") = "" Then
                            If objReporteCurso.CursosPropios = "" Then
                                objReporteCurso.CursosPropios = "SI"
                                chkCursosPropios.Checked = True
                            ElseIf objReporteCurso.CursosPropios = "SI" Then
                                chkCursosPropios.Checked = True
                            End If
                            If objReporteCurso.CursosPropios = "NO" Then
                                chkCursosPropios.Checked = False
                            End If
                            objReporteCurso.ProximoDiaHabil = Me.chkProximoDiaHabil.Checked
                        End If
                    Else
                        objReporteCurso.ProximoDiaHabil = Me.chkProximoDiaHabil.Checked
                        chkCursosPropios.Checked = False
                    End If
                    EjecutivoSeleccionado = ddlEjecutivo.SelectedValue
                    If ddlEjecutivo.SelectedValue Is Nothing Or ddlEjecutivo.SelectedValue = 2 Or ddlEjecutivo.SelectedValue = 0 Then
                        EjecutivoSeleccionado = objSession.Rut
                        objReporteCurso.CursosPropios = "NO"
                    Else
                        objReporteCurso.CursosPropios = "SI"
                    End If

                    If ddlEjecutivo.SelectedValue = 1 Then
                        objReporteCurso.EstadosCur = 1
                    ElseIf ddlEjecutivo.SelectedValue = 2 Then
                        objReporteCurso.EstadosCur = 2
                    Else
                        objReporteCurso.EstadosCur = 1
                    End If

                    If (objSession.EsEjecutivo Or objSession.EsEjecutivoReg Or objSession.EsEjecutivoAutorizacion) And Not objSession.EsSupervisor Then
                        If chkCursosPropios.Checked Then
                            objReporteCurso.CursosPropios = "SI"
                        Else
                            objReporteCurso.CursosPropios = "NO"
                        End If
                    End If
                End If



                If lngPrimeraVez = 1 And Not strTipo = Nothing Then
                    If strTipo = "1" Then
                        objReporteCurso.Tipo = 1
                        lblTipo.Text = "Con complemento"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "2" Then
                        objReporteCurso.Tipo = 2
                        lblTipo.Text = "Complementarios"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "3" Then
                        objReporteCurso.Tipo = 3
                        lblTipo.Text = "Iniciados sin comunicar"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "4" Then
                        objReporteCurso.Tipo = 4
                        lblTipo.Text = "Iniciados sin autorizar"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "5" Then
                        objReporteCurso.Tipo = 5
                        lblTipo.Text = "Terminados sin asistencia"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "6" Then
                        objReporteCurso.Tipo = 6
                        lblTipo.Text = "Terminados con asistencia sin liquidar"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "7" Then
                        objReporteCurso.Tipo = 7
                        lblTipo.Text = "Con comunicación atrazada"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "8" Then
                        objReporteCurso.Tipo = 8
                        lblTipo.Text = "Fecha término mayor a hoy"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "9" Then
                        objReporteCurso.Tipo = 9
                        lblTipo.Text = "Con pago de terceros"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "10" Then
                        objReporteCurso.Tipo = 10
                        lblTipo.Text = "Pagados con cuenta de capacitación"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "11" Then
                        objReporteCurso.Tipo = 11
                        lblTipo.Text = "Pagados con cuenta de excedente de capacitación"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "12" Then
                        objReporteCurso.Tipo = 12
                        lblTipo.Text = "Con viáticos y traslados"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "13" Then
                        objReporteCurso.Tipo = 13
                        lblTipo.Text = "No liquidados con fecha de término menor a hoy"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "14" Then
                        objReporteCurso.Tipo = 14
                        lblTipo.Text = "Con precontrato"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "15" Then
                        objReporteCurso.Tipo = 15
                        lblTipo.Text = "Con postcontrato"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                        '______________________________
                    ElseIf strTipo = "16" Then
                        objReporteCurso.Tipo = 16
                        lblTipo.Text = "Precenciales"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                    ElseIf strTipo = "17" Then
                        objReporteCurso.Tipo = 17
                        lblTipo.Text = "E-Learning"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                        '______________________________
                    ElseIf strTipo = "18" Then
                        objReporteCurso.Tipo = 18
                        lblTipo.Text = "A Distancia"
                        tablaFiltros.Visible = True
                        objReporteCurso.BajarXml = True
                        hplBajarReporte.Visible = True
                        chkBajarReporte.Checked = True
                        '______________________________
                    End If
                    btnConsultar.Visible = True
                Else
                    If lngPrimeraVez = 1 And Not strEstados = Nothing Then
                        If strEstados = "0" Then
                            chkIncompletos.Checked = True
                            lblTipo.Text = "Incompletos"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "1" Then
                            chkIngresados.Checked = True
                            lblTipo.Text = "Ingresados"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "2" Then
                            chkRechazados.Checked = True
                            lblTipo.Text = "Rechazados"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "3" Then
                            chkAutorizados.Checked = True
                            lblTipo.Text = "Autorizados"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "6" Then
                            chkPagoPorAutorizar.Checked = True
                            lblTipo.Text = "Pago por autorizar"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "4,11" Then
                            chkComunicados.Checked = True
                            lblTipo.Text = "Comunicados"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "5" Then
                            chkLiquidados.Checked = True
                            lblTipo.Text = "Liquidados"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "7" Then
                            chkEnComunicacion.Checked = True
                            lblTipo.Text = "En comunicación"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "9" Then
                            chkEnLiquidacion.Checked = True
                            lblTipo.Text = "En liquidación"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "8" Then
                            chkEliminados.Checked = True
                            lblTipo.Text = "Eliminados"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        ElseIf strEstados = "10" Then
                            chkAnulados.Checked = True
                            lblTipo.Text = "Anulados"
                            objReporteCurso.Estados = strEstados
                            objReporteCurso.Tipo = 0
                        End If
                    Else
                        If Not strTipo = Nothing Then
                            objReporteCurso.Tipo = strTipo
                            tablaFiltros.Visible = False
                            objReporteCurso.BajarXml = True
                            hplBajarReporte.Visible = True
                            chkBajarReporte.Checked = True
                        Else
                            If chkIncompletos.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "0" & ","
                                strTipoCursos = strTipoCursos & "Incompletos" & "-"
                            End If
                            If chkIngresados.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "1" & ","
                                strTipoCursos = strTipoCursos & "Ingresados" & "-"
                            End If
                            If chkRechazados.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "2" & ","
                                strTipoCursos = strTipoCursos & "Rechazados" & "-"
                            End If
                            If chkAutorizados.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "3" & ","
                                strTipoCursos = strTipoCursos & "Autorizados" & "-"
                            End If
                            If chkComunicados.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "4,11" & ","
                                strTipoCursos = strTipoCursos & "Comunicados" & "-"
                            End If
                            If chkLiquidados.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "5" & ","
                                strTipoCursos = strTipoCursos & "Liquidados" & "-"
                            End If
                            If chkPagoPorAutorizar.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "6" & ","
                                strTipoCursos = strTipoCursos & "Pago por autorizar" & "-"
                            End If
                            If chkEnComunicacion.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "7" & ","
                                strTipoCursos = strTipoCursos & "En comunicación" & "-"
                            End If
                            If chkEliminados.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "8" & ","
                                strTipoCursos = strTipoCursos & "Eliminados" & "-"
                            End If
                            If chkEnLiquidacion.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "9" & ","
                                strTipoCursos = strTipoCursos & "En liquidación" & "-"
                            End If
                            If chkAnulados.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "10" & ","
                                strTipoCursos = strTipoCursos & "Anulados" & "-"
                            End If
                            If chkConAsistencia.Checked Then
                                objReporteCurso.Tipo = 0
                                strEstadoCursos = strEstadoCursos & "11" & ","
                                strTipoCursos = strTipoCursos & "Con asistencia" & "-"
                            End If
                            If strTipoCursos Is Nothing Or strEstadoCursos Is Nothing Then
                                lblTipo.Text = "Ingresados-Autorizados-Comunicados-Liquidados"
                                chkIngresados.Checked = True
                                chkAutorizados.Checked = True
                                chkComunicados.Checked = True
                                chkLiquidados.Checked = True
                                objReporteCurso.Estados = "1,3,4,11,5"
                                objReporteCurso.Tipo = 0
                            Else
                                strTipoCursos = Left(strTipoCursos, strTipoCursos.Length - 1)
                                strEstadoCursos = Left(strEstadoCursos, strEstadoCursos.Length - 1)
                                lblTipo.Text = strTipoCursos
                                objReporteCurso.Estados = strEstadoCursos
                                If chkIncompletos.Checked = False And chkIngresados.Checked = False And chkRechazados.Checked = False And chkAutorizados.Checked = False And chkComunicados.Checked = False And chkLiquidados.Checked = False _
                                    And chkPagoPorAutorizar.Checked = False And chkEnComunicacion.Checked = False And chkEliminados.Checked = False And chkEnLiquidacion.Checked = False And chkAnulados.Checked = False And chkConAsistencia.Checked = False Then
                                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un estado');")
                                    Exit Sub
                                End If
                            End If
                        End If

                    End If
                    chkBajarReporte.Visible = True
                    btnConsultar.Visible = True
                End If
                objReporteCurso.AgnoCurso = ddlAgnos.SelectedValue
                objReporteCurso.RutUsuario = EjecutivoSeleccionado
                objReporteCurso.RutCliente = txtRutEmpresa.Text
                objReporteCurso.BajarXml = chkBajarReporte.Checked
                If Me.calFechaInicio.SelectedValue.HasValue Then
                    objReporteCurso.FechaInicio = Me.calFechaInicio.SelectedValue
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe llenar la fecha de inicio');")
                    Exit Sub
                End If
                If Me.calFechaFin.SelectedValue.HasValue Then
                    objReporteCurso.FechaFin = Me.calFechaFin.SelectedValue
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe llenar la fecha de fin');")
                    Exit Sub
                End If
                If calFechaInicio.SelectedDate > calFechaFin.SelectedDate Then
                    body.Attributes.Add("onload", "alert('ATENCIÓN: La fecha de inicio no debe ser mayor a la fecha de fin');")
                    Exit Sub
                End If
                If Me.chkTerceros.Checked Then
                    objReporteCurso.CuentaTercero = Me.ddlTerceros.SelectedValue
                Else
                    objReporteCurso.CuentaTercero = gValorNumNulo
                End If
                If Me.txtCorrelativo.Text.Trim <> "" Then
                    If IsNumeric(Me.txtCorrelativo.Text.Trim) Then
                        objReporteCurso.Correlativo = Me.txtCorrelativo.Text.Trim
                    Else
                        body.Attributes.Add("onload", "alert('ATENCIÓN: El correlativo debe ser un número entero');")
                        Exit Sub
                    End If
                End If
            End If

            If Me.txtCodigo.Text.Trim = "" Then
                objReporteCurso.CodCurso = 0
            Else
                If IsNumeric(Me.txtCodigo.Text.Trim) Then
                    objReporteCurso.CodCurso = CLng(Me.txtCodigo.Text.Trim)
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El código debe ser numerico');")
                    Exit Sub
                End If
            End If
            If Me.txtRegistro.Text.Trim = "" Then
                objReporteCurso.NroReg = 0
            Else
                If IsNumeric(Me.txtRegistro.Text.Trim) Then
                    objReporteCurso.NroReg = CLng(Me.txtRegistro.Text.Trim)
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: El número de registro debe ser numerico');")
                    Exit Sub
                End If
            End If
            Dim dt As New DataTable
            dt = objReporteCurso.Consultar()
            objWeb.LlenaGrilla(grdResultados, dt)
            If dt Is Nothing Then
                btnGenerar.Visible = False
                btnGenerarTodos.Visible = False
                btnLiquidar.Visible = False
                btnAutorizar.Visible = False
                btnComunicar.Visible = False
                btnRechazar.Visible = False
                btnGenerarZip.Visible = False
            End If
            If chkBajarReporte.Checked Then
                hplBajarReporte.Target = "_Blank"
                hplBajarReporte.Text = "Descargar archivo"
                hplBajarReporte.NavigateUrl = objReporteCurso.ArchivoXml
                Me.hplBajarReporte.Visible = True
            End If
        Catch ex As Exception
            EnviaError("reporte_cursos.aspx.vb:Consultar->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.Pager AndAlso Not grdResultados.DataSource Is Nothing Then
                'TRAE EL TOTAL DE PAGINAS
                Dim _TotalPags As Label = e.Row.FindControl("lblTotalNumberOfPages")
                _TotalPags.Text = grdResultados.PageCount.ToString

                'LLENA LA LISTA CON EL NUMERO DE PAGINAS
                Dim list As DropDownList = e.Row.FindControl("paginasDropDownList")
                For i As Integer = 1 To CInt(grdResultados.PageCount)
                    Dim it As ListItem
                    Dim Existe As Boolean = False
                    For Each it In list.Items
                        If it.Text = i.ToString Then
                            Existe = True
                        End If
                    Next
                    If Not Existe Then
                        list.Items.Add(i.ToString)
                    End If
                Next
                list.SelectedValue = grdResultados.PageIndex + 1
            End If

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim strFecha As String
                Dim Origen As String
                Dim strCodEstadoCurso As String
                Dim lngNroPerfil As Long
                Dim hdfCodCur As HiddenField

                hdfCodCur = CType(e.Row.FindControl("hdfCodCurso"), HiddenField)

                Dim hdfCodEstadoCurso As HiddenField
                hdfCodEstadoCurso = CType(e.Row.FindControl("hdfCodEstadoCurso"), HiddenField)

                Dim hdfNumPerfil As HiddenField
                hdfNumPerfil = CType(e.Row.FindControl("hdfNumPerfil"), HiddenField)

                Dim hdfEstadoCurso As HiddenField
                hdfEstadoCurso = CType(e.Row.FindControl("hdfEstadoCurso"), HiddenField)

                Dim hdfCodSence As HiddenField
                hdfCodSence = CType(e.Row.FindControl("hdfCodSence"), HiddenField)

                Dim hdfRutOtec As HiddenField
                hdfRutOtec = CType(e.Row.FindControl("hdfRutOtec"), HiddenField)

                Dim hdfRutCliente As HiddenField
                hdfRutCliente = CType(e.Row.FindControl("hdfRutCliente"), HiddenField)

                Origen = hdfEstadoCurso.Value
                If Origen = "Con asistencia" Then
                    Origen = "Comunicado"
                End If

                strCodEstadoCurso = hdfCodEstadoCurso.Value
                lngNroPerfil = hdfNumPerfil.Value

                Dim hplEstado As HyperLink
                hplEstado = CType(e.Row.FindControl("hplEstado"), HyperLink)
                hplEstado.NavigateUrl = "reporte_bitacoras.aspx?codCurso=" & hdfCodCur.Value & "&tipo=1" & "&estado=" & hdfEstadoCurso.Value
                If strCodEstadoCurso = "6" Then
                    hplEstado.Text = "Por autorizar"
                End If


                Dim lbl1 As Label
                lbl1 = CType(e.Row.FindControl("lblFechIni"), Label)
                If lbl1.Text = "" Then
                    lbl1.Text = "-"
                Else
                    strFecha = FechaVbAUsr(lbl1.Text)
                    lbl1.Text = strFecha
                End If

                Dim lbl2 As Label
                lbl2 = CType(e.Row.FindControl("lblFechFin"), Label)
                If lbl2.Text = "" Then
                    lbl2.Text = "-"
                Else
                    strFecha = FechaVbAUsr(lbl2.Text)
                    lbl2.Text = strFecha
                End If

                Dim lbl3 As Label
                lbl3 = CType(e.Row.FindControl("lblComun"), Label)
                If lbl3.Text = "" Then
                    lbl3.Text = "-"
                Else
                    strFecha = FechaVbAUsr(lbl3.Text)
                    lbl3.Text = strFecha
                End If

                Dim lbl4 As Label
                lbl4 = CType(e.Row.FindControl("lblLiquida"), Label)
                If lbl4.Text = "" Then
                    lbl4.Text = "-"
                Else
                    strFecha = FechaVbAUsr(lbl4.Text)
                    lbl4.Text = strFecha
                End If

                Dim lbl5 As Label
                lbl5 = CType(e.Row.FindControl("lblIngreso"), Label)
                lbl5.Text = FechaVbAUsr(lbl5.Text)

                Dim lblCorrEmp As Label
                lblCorrEmp = CType(e.Row.FindControl("lblCorrEmp"), Label)
                If lblCorrEmp.Text = "" Then
                    lblCorrEmp.Text = "-"
                End If

                Dim lngRutUsr As Long
                lngRutUsr = objSession.Rut

                'Correlativo
                Dim hplCorrelativo As HyperLink
                hplCorrelativo = CType(e.Row.FindControl("hplCorrelativo"), HyperLink)
                hplCorrelativo.NavigateUrl = "ficha_curso_contratado.aspx?CodCurso=" & hdfCodCur.Value & "&estadoCur=" & hdfEstadoCurso.Value & "&rutUsuario=" & lngRutUsr & "&rutCliente=" & hdfRutCliente.Value

                Dim hplCodCurso As HyperLink
                hplCodCurso = CType(e.Row.FindControl("hplCodCurso"), HyperLink)
                hplCodCurso.NavigateUrl = "ficha_curso_contratado.aspx?CodCurso=" & hdfCodCur.Value & "&estadoCur=" & hdfEstadoCurso.Value & "&rutUsuario=" & lngRutUsr & "&rutCliente=" & hdfRutCliente.Value

                'Empresa
                Dim hplEmpresa As HyperLink
                hplEmpresa = CType(e.Row.FindControl("hplEmpresa"), HyperLink)
                hplEmpresa.NavigateUrl = "ficha_empresa.aspx?rutCliente=" & hdfRutCliente.Value

                'Curso
                Dim hplCurso As HyperLink
                hplCurso = CType(e.Row.FindControl("hplCurso"), HyperLink)
                hplCurso.NavigateUrl = "ficha_curso_sence.aspx?CodSence=" & hdfCodSence.Value & "&rutUsuario=" & lngRutUsr

                'Otec
                Dim hplOtec As HyperLink
                hplOtec = CType(e.Row.FindControl("hplOtec"), HyperLink)
                hplOtec.NavigateUrl = "ficha_otec.aspx?rutOtec=" & hdfRutOtec.Value

                'Modificar
                Dim btnModificarGrid As Button
                btnModificarGrid = CType(e.Row.FindControl("btnModificarGrid"), Button)

                'Anular
                Dim btnAnularGrid As Button
                btnAnularGrid = CType(e.Row.FindControl("btnAnularGrid"), Button)

                'Eliminar
                Dim btnEliminarGrid As Button
                btnEliminarGrid = CType(e.Row.FindControl("btnEliminarGrid"), Button)

                'Autorizar/Rechazar
                Dim btnAutRechGrid As Button
                btnAutRechGrid = CType(e.Row.FindControl("btnAutRechGrid"), Button)

                'Comunicar
                Dim btnComunicarGrid As Button
                btnComunicarGrid = CType(e.Row.FindControl("btnComunicarGrid"), Button)

                'Liquidar
                Dim btnLiquidarGrid As Button
                btnLiquidarGrid = CType(e.Row.FindControl("btnLiquidarGrid"), Button)

                'Asistencia
                Dim btnAsistenciaGrid As Button
                btnAsistenciaGrid = CType(e.Row.FindControl("btnAsistenciaGrid"), Button)

                'Comunicación manual
                Dim btnComunManualGrid As Button
                btnComunManualGrid = CType(e.Row.FindControl("btnComunManualGrid"), Button)

                'Liquidar manual
                Dim btnLiqManualGrid As Button
                btnLiqManualGrid = CType(e.Row.FindControl("btnLiqManualGrid"), Button)

                'chkComunicar
                Dim chkComunica As CheckBox
                chkComunica = CType(e.Row.FindControl("chkComunicar"), CheckBox)

                'chkAutorizar
                Dim chkAutoriza As CheckBox
                chkAutoriza = CType(e.Row.FindControl("chkAutorizar"), CheckBox)

                'chkLiquidar
                Dim chkLiquida As CheckBox
                chkLiquida = CType(e.Row.FindControl("chkLiquidar"), CheckBox)

                'generar bd
                Dim chkGenerar As CheckBox
                chkGenerar = CType(e.Row.FindControl("chkGenerar"), CheckBox)

                If strCodEstadoCurso <> "7" And strCodEstadoCurso <> "10" And objSession.TienePermiso(lngNroPerfil, "Mod") Then 'And objReporteCurso.Tipo = 0 Then
                    If objSession.EsEjecutivoReg And (strCodEstadoCurso = "0" Or strCodEstadoCurso = "1" Or strCodEstadoCurso = "2" Or strCodEstadoCurso = "3") Then 'And objReporteCurso.Tipo = 0 Then
                        btnModificarGrid.Visible = True
                    ElseIf strCodEstadoCurso <> "7" And strCodEstadoCurso <> "8" And strCodEstadoCurso <> "10" And objSession.TienePermiso(lngNroPerfil, "Mod") And Not objSession.EsEjecutivoReg Then
                        btnModificarGrid.Visible = True
                    End If
                End If
                'If strCodEstadoCurso = "5" And objSession.TienePermiso(lngNroPerfil, "Mod") Then 'And objReporteCurso.Tipo = 0 Then
                '    btnModificarGrid.Visible = False
                'End If
                If (strCodEstadoCurso = "5" Or strCodEstadoCurso = "4") And objSession.EsSupervisor Then 'And objReporteCurso.Tipo = 0 Then
                    btnAnularGrid.Visible = True
                End If
                If strCodEstadoCurso <> "4" And strCodEstadoCurso <> "5" And strCodEstadoCurso <> "7" And strCodEstadoCurso <> "8" And strCodEstadoCurso <> "10" And objSession.TienePermiso(lngNroPerfil, "Eli") Then 'And objReporteCurso.Tipo = 0 Then
                    If objSession.EsEjecutivoReg And (strCodEstadoCurso = "0" Or strCodEstadoCurso = "1" Or strCodEstadoCurso = "2" Or strCodEstadoCurso = "3") And objReporteCurso.Tipo = 0 Then
                        btnEliminarGrid.Visible = True
                    ElseIf strCodEstadoCurso <> "4" And strCodEstadoCurso <> "5" And strCodEstadoCurso <> "7" And strCodEstadoCurso <> "8" And strCodEstadoCurso <> "10" And objSession.TienePermiso(lngNroPerfil, "Eli") And Not objSession.EsEjecutivoReg Then 'And objReporteCurso.Tipo = 0 Then
                        btnEliminarGrid.Visible = True
                    End If
                End If
                If (strCodEstadoCurso = "1" Or strCodEstadoCurso = "2" Or strCodEstadoCurso = "6") And objSession.TienePermiso(lngNroPerfil, "Aut") Then 'And objReporteCurso.Tipo = 0 Then
                    btnAutRechGrid.Visible = True
                End If
                If strCodEstadoCurso = "3" And objSession.TienePermiso(lngNroPerfil, "Com") Then 'And objReporteCurso.Tipo = 0 Then
                    btnComunicarGrid.Visible = True
                End If
                If (strCodEstadoCurso = "11") And objSession.TienePermiso(lngNroPerfil, "Liq") Then 'And objReporteCurso.Tipo = 0 Then
                    btnLiquidarGrid.Visible = True
                End If
                If (strCodEstadoCurso = "4" Or strCodEstadoCurso = "11") And objSession.EsOperaciones Then ' And objSession.TienePermiso(lngNroPerfil, "Liq") And objReporteCurso.Tipo = 0 Then
                    btnAsistenciaGrid.Visible = True
                End If
                If (objSession.EsOperaciones) And (Trim(Origen) = "En Comunicacion") Then 'And objReporteCurso.Tipo = 0 Then
                    btnComunManualGrid.Visible = True
                    chkGenerar.Visible = True
                End If
                If (objSession.EsOperaciones) And strCodEstadoCurso = "9" Then 'And objReporteCurso.Tipo = 0 Then
                    btnLiqManualGrid.Visible = True
                    chkGenerar.Visible = True
                End If
                If Origen = "Autorizado" And strCodEstadoCurso = "3" And objSession.TienePermiso(lngNroPerfil, "Com") Then 'And objReporteCurso.Tipo = 0 Then
                    chkComunica.Visible = True
                    btnComunicar.Visible = True
                End If
                If (Trim(Origen) = "Ingresado" Or Trim(Origen) = "Ingresados" Or Trim(Origen) = "Rechazado" Or Trim(Origen) = "PagoPorAutorizar") And (strCodEstadoCurso = "1" Or strCodEstadoCurso = "2" Or strCodEstadoCurso = "6") And objSession.TienePermiso(lngNroPerfil, "Aut") Then 'And objReporteCurso.Tipo = 0 Then
                    chkAutoriza.Visible = True
                    btnAutorizar.Visible = True
                    btnRechazar.Visible = True
                End If
                If Trim(Origen) = "Comunicado" And (strCodEstadoCurso = "11") And objSession.TienePermiso(lngNroPerfil, "Liq") Then 'And objReporteCurso.Tipo = 0 Then
                    chkLiquida.Visible = True
                    btnLiquidar.Visible = True
                End If
                If objSession.EsOperaciones And strCodEstadoCurso = "7" Or strCodEstadoCurso = "9" Then
                    btnGenerar.Visible = True
                    btnGenerarTodos.Visible = True
                    btnGenerarZip.Visible = False 'True
                    btnModificarGrid.Visible = True
                End If
            End If
        Catch ex As Exception
            EnviaError("reporte_cursos.aspx.vb:grdResultados_RowDataBound->" & ex.Message)
        End Try
        
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
    Protected Sub grdResultados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdResultados.PageIndexChanging
        If Not e.NewPageIndex < 0 Then
            grdResultados.PageIndex = e.NewPageIndex
            Consultar()
        End If
    End Sub

    Protected Sub btnAutorizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAutorizar.Click
        Dim dt As New DataTable
        Dim strCodigos As String
        Dim lngRut As Long
        Dim dr As DataRow
        dt.Columns.Add("cod_curso")
        dr = dt.NewRow
        Dim grdRow As GridViewRow
        For Each grdRow In grdResultados.Rows
            Dim chkAutorizar As New CheckBox
            chkAutorizar = CType(grdRow.FindControl("chkAutorizar"), CheckBox)
            Dim chkComunicar As New CheckBox
            chkComunicar = CType(grdRow.FindControl("chkComunicar"), CheckBox)
            Dim chkLiquidar As New CheckBox
            chkLiquidar = CType(grdRow.FindControl("chkLiquidar"), CheckBox)
            Dim hdf As HiddenField
            hdf = CType(grdRow.FindControl("hdfCodCurso"), HiddenField)
            dr("cod_curso") = hdf.Value
            If chkComunicar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede autorizar cursos ingresados');")
                Exit Sub
            ElseIf chkLiquidar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede autorizar cursos ingresados');")
                Exit Sub
            End If
            If chkAutorizar.Checked Then
                strCodigos = strCodigos & dr("cod_curso") & ","
            End If
        Next
        lngRut = objSession.Rut
        If strCodigos Is Nothing Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un curso');")
        Else
            strCodigos = Left(strCodigos, strCodigos.Length - 1)
            Response.Redirect("cambio_estado_masivo.aspx?codCurso=" & strCodigos & "&rutUsuario=" & lngRut & "&tipoCambio=autorizar")
        End If
    End Sub
    Protected Sub btnRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
        Dim dt As New DataTable
        Dim strCodigos As String
        Dim lngRut As Long
        Dim dr As DataRow
        Dim grdRow As GridViewRow
        dt.Columns.Add("cod_curso")
        dr = dt.NewRow
        For Each grdRow In grdResultados.Rows
            Dim chkRechazar As New CheckBox
            chkRechazar = CType(grdRow.FindControl("chkAutorizar"), CheckBox)
            Dim chkComunicar As New CheckBox
            chkComunicar = CType(grdRow.FindControl("chkComunicar"), CheckBox)
            Dim chkLiquidar As New CheckBox
            chkLiquidar = CType(grdRow.FindControl("chkLiquidar"), CheckBox)
            Dim hdf As HiddenField
            hdf = CType(grdRow.FindControl("hdfCodCurso"), HiddenField)
            dr("cod_curso") = hdf.Value
            If chkComunicar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede rechazar cursos ingresados');")
                Exit Sub
            ElseIf chkLiquidar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede rechazar cursos ingresados');")
                Exit Sub
            End If
            If chkRechazar.Checked Then
                strCodigos = strCodigos & dr("cod_curso") & ","
            End If
        Next
        lngRut = objSession.Rut
        If strCodigos Is Nothing Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un curso');")
        Else
            strCodigos = Left(strCodigos, strCodigos.Length - 1)
            Response.Redirect("cambio_estado_masivo.aspx?codCurso=" & strCodigos & "&rutUsuario=" & lngRut & "&tipoCambio=rechazar")
        End If
    End Sub

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim dt As New DataTable
        Dim strCodigos As String = ""
        Dim lngRut As Long
        Dim dr As DataRow
        Dim grdRow As GridViewRow
        dt.Columns.Add("cod_curso")
        dr = dt.NewRow
        For Each grdRow In grdResultados.Rows
            Dim chkRechazar As New CheckBox
            chkRechazar = CType(grdRow.FindControl("chkAutorizar"), CheckBox)
            Dim chkComunicar As New CheckBox
            chkComunicar = CType(grdRow.FindControl("chkComunicar"), CheckBox)
            Dim chkLiquidar As New CheckBox
            chkLiquidar = CType(grdRow.FindControl("chkLiquidar"), CheckBox)
            Dim chkGenerar As New CheckBox
            chkGenerar = CType(grdRow.FindControl("chkGenerar"), CheckBox)
            Dim hdf As HiddenField
            hdf = CType(grdRow.FindControl("hdfCodCurso"), HiddenField)
            dr("cod_curso") = hdf.Value
            If chkComunicar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
                Me.btnGenerar.Visible = True
                Me.btnGenerarTodos.Visible = True
                Me.btnGenerarZip.Visible = False ' True
                Exit Sub
            ElseIf chkLiquidar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
                Me.btnGenerar.Visible = True
                Me.btnGenerarTodos.Visible = True
                Me.btnGenerarZip.Visible = False 'True
                Exit Sub
            End If
            If chkRechazar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
                Me.btnGenerar.Visible = True
                Me.btnGenerarTodos.Visible = True
                Me.btnGenerarZip.Visible = False 'True
                Exit Sub
            End If
            If chkGenerar.Checked Then
                strCodigos = strCodigos & dr("cod_curso") & ","
            End If
        Next
        lngRut = objSession.Rut
        If strCodigos = "" Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un curso');")
            Me.btnGenerar.Visible = True
            Me.btnGenerarTodos.Visible = True
            Me.btnGenerarZip.Visible = False 'True
            Exit Sub
        Else
            strCodigos = Left(strCodigos, strCodigos.Length - 1)
            Response.Redirect("../modulo_cursos/comunicar_cursos_sence.aspx?codCurso=" & strCodigos & "&enComunicacion=" & chkEnComunicacion.Checked & "&enLiquidacion=" & chkEnLiquidacion.Checked)
        End If
        'Response.Redirect("../modulo_administracion/comunicar_cursos_sence.aspx?codCurso=" & strCodigos & "enComunicacion=" & chkEnComunicacion.Checked & "&enLiquidacion=" & chkEnLiquidacion.Checked)
    End Sub

    Protected Sub btnComunicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComunicar.Click
        Dim strCodigosCursos As String
        Dim lngRut As Long
        Dim lngCodEstado As Long
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim grdRow As GridViewRow
        dt.Columns.Add("cod_curso")
        dr = dt.NewRow
        For Each grdRow In grdResultados.Rows
            Dim chkComunicar As New CheckBox
            chkComunicar = CType(grdRow.FindControl("chkComunicar"), CheckBox)
            Dim chkAutorizar As New CheckBox
            chkAutorizar = CType(grdRow.FindControl("chkAutorizar"), CheckBox)
            Dim chkLiquidar As New CheckBox
            chkLiquidar = CType(grdRow.FindControl("chkLiquidar"), CheckBox)
            Dim hdf As HiddenField
            hdf = CType(grdRow.FindControl("hdfCodCurso"), HiddenField)
            Dim hdfCodEstadoCurso As HiddenField
            hdfCodEstadoCurso = CType(grdRow.FindControl("hdfCodEstadoCurso"), HiddenField)
            lngCodEstado = hdfCodEstadoCurso.value
            dr("cod_curso") = hdf.Value
            If chkAutorizar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede comunicar cursos autorizados');")
                Exit Sub
            ElseIf chkLiquidar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede comunicar cursos autorizados');")
                Exit Sub
            End If
            If chkComunicar.Checked Then
                strCodigosCursos = strCodigosCursos & dr("cod_curso") & ","
            End If
        Next
        lngRut = objSession.Rut
        If strCodigosCursos Is Nothing Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un curso');")
        Else
            strCodigosCursos = Left(strCodigosCursos, strCodigosCursos.Length - 1)
            Response.Redirect("cambio_estado_masivo.aspx?codCurso=" & strCodigosCursos & "&rutUsuario=" & lngRut & "&tipoCambio=comunicar" & "&codEstado=" & lngCodEstado)
        End If
    End Sub

    Protected Sub btnLiquida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLiquidar.Click
        Dim strCodigosCursos As String
        Dim lngRut As Long
        Dim lngCodEstado As Long
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim grdRow As GridViewRow
        dt.Columns.Add("cod_curso")
        dr = dt.NewRow
        For Each grdRow In grdResultados.Rows
            Dim chkLiquidar As New CheckBox
            chkLiquidar = CType(grdRow.FindControl("chkLiquidar"), CheckBox)
            Dim chkComunicar As New CheckBox
            chkComunicar = CType(grdRow.FindControl("chkComunicar"), CheckBox)
            Dim chkAutorizar As New CheckBox
            chkAutorizar = CType(grdRow.FindControl("chkAutorizar"), CheckBox)
            Dim hdf As HiddenField
            hdf = CType(grdRow.FindControl("hdfCodCurso"), HiddenField)
            Dim hdfCodEstadoCurso As HiddenField
            hdfCodEstadoCurso = CType(grdRow.FindControl("hdfCodEstadoCurso"), HiddenField)
            lngCodEstado = hdfCodEstadoCurso.value
            dr("cod_curso") = hdf.Value
            If chkAutorizar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede liquidar cursos comunicados(con asistencia aprobada)');")
                Exit Sub
            ElseIf chkComunicar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede liquidar cursos comunicados(con asistencia aprobada)');")
                Exit Sub
            End If
            If chkLiquidar.Checked Then
                strCodigosCursos = strCodigosCursos & dr("cod_curso") & ","
            End If
        Next
        lngRut = objSession.Rut
        If strCodigosCursos Is Nothing Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un curso');")
        Else
            strCodigosCursos = Left(strCodigosCursos, strCodigosCursos.Length - 1)
            Response.Redirect("cambio_estado_masivo.aspx?codCurso=" & strCodigosCursos & "&rutUsuario=" & lngRut & "&tipoCambio=liquidar" & "&codEstado=" & lngCodEstado)
        End If
    End Sub

    Protected Sub btnModificarGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnModificarGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnModificarGrid.NamingContainer, GridViewRow)
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Response.Redirect("mantenedor_cursos.aspx?CodCurso=" & hdfCodCur.Value)
    End Sub

    Protected Sub btnEliminarGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnEliminarGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnEliminarGrid.NamingContainer, GridViewRow)
        Dim lngRutUsr As Long
        lngRutUsr = objSession.Rut
        Dim hplEstado As HyperLink
        hplEstado = CType(row.FindControl("hplEstado"), HyperLink)
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfCodEstadoCurso As HiddenField
        hdfCodEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Response.Redirect("eliminar_curso.aspx?codCurso=" & hdfCodCur.Value & "&estadoCur=" & hplEstado.Text & "&rutUsuario=" & lngRutUsr & "&codEstado=" & hdfCodEstadoCurso.Value)
    End Sub

    Protected Sub btnAnularGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnAnularGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnAnularGrid.NamingContainer, GridViewRow)
        Dim lngRutUsr As Long
        lngRutUsr = objSession.Rut
        Dim hplEstado As HyperLink
        hplEstado = CType(row.FindControl("hplEstado"), HyperLink)
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfCodEstadoCurso As HiddenField
        hdfCodEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Response.Redirect("anular_curso.aspx?codCurso=" & hdfCodCur.Value & "&estadoCur=" & hplEstado.Text & "&rutUsuario=" & lngRutUsr & "&codEstado=" & hdfCodEstadoCurso.Value)
    End Sub

    Protected Sub btnAutRechGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnAutRechGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnAutRechGrid.NamingContainer, GridViewRow)
        Dim lngRutUsr As Long
        lngRutUsr = objSession.Rut
        Dim hplEstado As HyperLink
        hplEstado = CType(row.FindControl("hplEstado"), HyperLink)
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfCodEstadoCurso As HiddenField
        hdfCodEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Response.Redirect("autorizar_rechazar_curso.aspx?codCurso=" & hdfCodCur.Value & "&estadoCur=" & hplEstado.Text & "&rutUsuario=" & lngRutUsr & "&codEstado=" & hdfCodEstadoCurso.Value)
    End Sub

    Protected Sub btnComunicarGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnComunicarGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnComunicarGrid.NamingContainer, GridViewRow)
        Dim lngRutUsr As Long
        lngRutUsr = objSession.Rut
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfCodEstadoCurso As HiddenField
        hdfCodEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Response.Redirect("cambio_estado_masivo.aspx?codCurso=" & hdfCodCur.value & "&rutUsuario=" & lngRutUsr & "&tipoCambio=comunicar" & "&codEstado=" & hdfCodEstadoCurso.Value)
    End Sub

    Protected Sub btnLiquidarGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnLiquidarGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnLiquidarGrid.NamingContainer, GridViewRow)
        Dim lngRutUsr As Long
        lngRutUsr = objSession.Rut
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfCodEstadoCurso As HiddenField
        hdfCodEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Response.Redirect("cambio_estado_masivo.aspx?codCurso=" & hdfCodCur.value & "&rutUsuario=" & lngRutUsr & "&tipoCambio=liquidar" & "&codEstado=" & hdfCodEstadoCurso.Value)
    End Sub

    Protected Sub btnAsistenciaGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnAsistenciaGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnAsistenciaGrid.NamingContainer, GridViewRow)
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfCodEstadoCurso As HiddenField
        hdfCodEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Response.Redirect("mantenedor_asistencias.aspx?codCurso=" & hdfCodCur.Value & "&codEstado=" & hdfCodEstadoCurso.Value)
    End Sub

    Protected Sub btnLiqManualGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnLiqManualGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnLiqManualGrid.NamingContainer, GridViewRow)
        Dim lngRutUsr As Long
        lngRutUsr = objSession.Rut
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        'objCCambioEstados = New CCambioEstados
        'If objCCambioEstados.LiquidarCurso("", lngRutUsr, hdfCodCur.Value) Then
        '    Response.Redirect("reporte_cursos.aspx?estados=9&agno=" & objSession.Agno & "&resumen=si")
        '    body.Attributes.Add("onload", "alert('ATENCIÓN: El curso está liquidado');")
        'Else
        '    body.Attributes.Add("onload", "alert('ATENCIÓN: No se puede liquidar el curso');")
        'End If
        Response.Redirect("liquidacion_manual.aspx?codCurso=" & hdfCodCur.Value & "&rutUsuario=" & lngRutUsr)

    End Sub

    Protected Sub btnComunManualGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnComunManualGrid As Button = CType(sender, Button)
        Dim row As GridViewRow = CType(btnComunManualGrid.NamingContainer, GridViewRow)
        Dim lngRutUsr As Long
        lngRutUsr = objSession.Rut
        Dim hplEstado As HyperLink
        hplEstado = CType(row.FindControl("hplEstado"), HyperLink)
        Dim hdfCodCur As HiddenField
        hdfCodCur = CType(row.FindControl("hdfCodCurso"), HiddenField)
        Dim hdfCodEstadoCurso As HiddenField
        hdfCodEstadoCurso = CType(row.FindControl("hdfCodEstadoCurso"), HiddenField)
        Response.Redirect("comunicacion_manual.aspx?CodCurso=" & hdfCodCur.Value & "&estadoCur=" & hplEstado.Text & "&rutUsuario=" & lngRutUsr & "&codEstado=" & hdfCodEstadoCurso.Value)
    End Sub

    Protected Sub btnGenerarZip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarZip.Click
        Dim dt As New DataTable
        Dim strCodigos As String = ""
        Dim lngRut As Long
        Dim dr As DataRow
        Dim grdRow As GridViewRow
        Dim objComunicarCsv As New CComunicarCsv
        dt.Columns.Add("cod_curso")
        dr = dt.NewRow
        For Each grdRow In grdResultados.Rows
            Dim chkRechazar As New CheckBox
            chkRechazar = CType(grdRow.FindControl("chkAutorizar"), CheckBox)
            Dim chkComunicar As New CheckBox
            chkComunicar = CType(grdRow.FindControl("chkComunicar"), CheckBox)
            Dim chkLiquidar As New CheckBox
            chkLiquidar = CType(grdRow.FindControl("chkLiquidar"), CheckBox)
            Dim chkGenerar As New CheckBox
            chkGenerar = CType(grdRow.FindControl("chkGenerar"), CheckBox)
            Dim hdf As HiddenField
            hdf = CType(grdRow.FindControl("hdfCodCurso"), HiddenField)
            dr("cod_curso") = hdf.Value
            If chkComunicar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
                Me.btnGenerar.Visible = True
                Me.btnGenerarTodos.Visible = True
                Me.btnGenerarZip.Visible = False 'True
                Exit Sub
            ElseIf chkLiquidar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
                Me.btnGenerar.Visible = True
                Me.btnGenerarTodos.Visible = True
                Me.btnGenerarZip.Visible = False 'True
                Exit Sub
            End If
            If chkRechazar.Checked Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
                Me.btnGenerar.Visible = True
                Me.btnGenerarTodos.Visible = True
                Me.btnGenerarZip.Visible = False 'True
                Exit Sub
            End If
            If chkGenerar.Checked Then
                strCodigos = strCodigos & dr("cod_curso") & ","
            End If
        Next
        lngRut = objSession.Rut
        If strCodigos = "" Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un curso');")
            Me.btnGenerar.Visible = True
            Me.btnGenerarTodos.Visible = True
            Me.btnGenerarZip.Visible = False 'True
            Exit Sub
        Else
            strCodigos = Left(strCodigos, strCodigos.Length - 1)
            objComunicarCsv.CodCurso = strCodigos
            objComunicarCsv.Comunicar = chkEnComunicacion.Checked
            objComunicarCsv.Liquidar = chkEnLiquidacion.Checked
            objComunicarCsv.RutUsuario = objSession.Rut
            objComunicarCsv.GenerarCsv()
            Response.Redirect("../modulo_administracion/comunicar_curso_sence_csv.aspx?codCurso=" & strCodigos & "&enComunicacion=" & chkEnComunicacion.Checked & "&enLiquidacion=" & chkEnLiquidacion.Checked)
        End If
    End Sub

    Protected Sub GoPage(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oIraPag As DropDownList = DirectCast(sender, DropDownList)
        Dim iNumPag As Integer = 0
        If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultados.PageCount Then
            If Integer.TryParse(oIraPag.Text.Trim, iNumPag) AndAlso iNumPag > 0 AndAlso iNumPag <= grdResultados.PageCount Then
                grdResultados.PageIndex = iNumPag - 1
            Else
                grdResultados.PageIndex = 0
            End If
        End If
        Call Consultar()
    End Sub

    Protected Sub btnGenerarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarTodos.Click
        Dim dt As New DataTable
        Dim strCodigos As String = ""
        Dim lngRut As Long
        Dim dr As DataRow
        Dim grdRow As GridViewRow
        dt.Columns.Add("cod_curso")
        dr = dt.NewRow
        For Each grdRow In grdResultados.Rows
            Dim hdfCodEstadoCurso As HiddenField
            hdfCodEstadoCurso = CType(grdRow.FindControl("hdfCodEstadoCurso"), HiddenField)

            'Dim chkRechazar As New CheckBox
            'chkRechazar = CType(grdRow.FindControl("chkAutorizar"), CheckBox)
            'Dim chkComunicar As New CheckBox
            'chkComunicar = CType(grdRow.FindControl("chkComunicar"), CheckBox)
            'Dim chkLiquidar As New CheckBox
            'chkLiquidar = CType(grdRow.FindControl("chkLiquidar"), CheckBox)
            'Dim chkGenerar As New CheckBox
            'chkGenerar = CType(grdRow.FindControl("chkGenerar"), CheckBox)
            Dim hdfCodCurso As HiddenField
            hdfCodCurso = CType(grdRow.FindControl("hdfCodCurso"), HiddenField)
            dr("cod_curso") = hdfCodCurso.Value
            'If chkComunicar.Checked Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
            '    Me.btnGenerar.Visible = True
            '    Me.btnGenerarTodos.Visible = True
            '    Me.btnGenerarZip.Visible = False ' True
            '    Exit Sub
            'ElseIf chkLiquidar.Checked Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
            '    Me.btnGenerar.Visible = True
            '    Me.btnGenerarTodos.Visible = True
            '    Me.btnGenerarZip.Visible = False 'True
            '    Exit Sub
            'End If
            'If chkRechazar.Checked Then
            '    body.Attributes.Add("onload", "alert('ATENCIÓN: Sólo puede generar la base con cursos en comunicación o en liquidación');")
            '    Me.btnGenerar.Visible = True
            '    Me.btnGenerarTodos.Visible = True
            '    Me.btnGenerarZip.Visible = False 'True
            '    Exit Sub
            'End If
            If hdfCodEstadoCurso.Value = 7 Or hdfCodEstadoCurso.Value = 9 Then
                strCodigos = strCodigos & dr("cod_curso") & ","
            End If
        Next
        lngRut = objSession.Rut
        'If strCodigos = "" Then
        '    body.Attributes.Add("onload", "alert('ATENCIÓN: Debe seleccionar al menos un curso');")
        '    Me.btnGenerar.Visible = True
        '    Me.btnGenerarTodos.Visible = True
        '    Me.btnGenerarZip.Visible = False 'True
        '    Exit Sub
        'Else
        strCodigos = Left(strCodigos, strCodigos.Length - 1)

        Response.Redirect("../modulo_cursos/comunicar_cursos_sence.aspx?codCurso=" & strCodigos & "&enComunicacion=" & chkEnComunicacion.Checked & "&enLiquidacion=" & chkEnLiquidacion.Checked)

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        chkIngresados.Checked = False
        chkAnulados.Checked = False
        chkAutorizados.Checked = False
        chkComunicados.Checked = False
        chkEnComunicacion.Checked = False
        chkConAsistencia.Checked = False
        chkPagoPorAutorizar.Checked = False
        chkEnLiquidacion.Checked = False
        chkLiquidados.Checked = False
        chkEliminados.Checked = False
        chkIncompletos.Checked = False
        chkRechazados.Checked = False
        chkTerceros.Checked = False

    End Sub

    Protected Sub ddlSeleccion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSeleccion.SelectedIndexChanged
        If ddlSeleccion.SelectedValue = 1 Then
            chkIngresados.Checked = True
            chkAutorizados.Checked = True
            chkComunicados.Checked = True
            chkEnComunicacion.Checked = True
            chkConAsistencia.Checked = True
            chkPagoPorAutorizar.Checked = True
            chkEnLiquidacion.Checked = True
            chkLiquidados.Checked = True
            chkAnulados.Checked = True
            chkEliminados.Checked = True
            chkIncompletos.Checked = True
            chkRechazados.Checked = True
            chkTerceros.Checked = True
        ElseIf ddlSeleccion.SelectedValue = 2 Then
            chkIngresados.Checked = False
            chkAnulados.Checked = False
            chkAutorizados.Checked = False
            chkComunicados.Checked = False
            chkEnComunicacion.Checked = False
            chkConAsistencia.Checked = False
            chkPagoPorAutorizar.Checked = False
            chkEnLiquidacion.Checked = False
            chkLiquidados.Checked = False
            chkEliminados.Checked = False
            chkIncompletos.Checked = False
            chkRechazados.Checked = False
            chkTerceros.Checked = False
        End If
    End Sub
End Class
