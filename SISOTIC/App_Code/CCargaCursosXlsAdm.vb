Imports Microsoft.VisualBasic
Imports Modulos
Imports Clases
Imports System.Data
Imports System.Web
Imports Clases.Web
Imports System.Globalization
Imports System.Threading

Public Class CCargaCursosXlsAdm
    Private mstrMensaje As String
    Private mlngCorrelEmpresa As Long
    Private mlngRutEmpresa As Long
    Private mstrRutEmpresa As String
    Private mintCodTipoActividad As Integer
    Private mbolComBipartito As Boolean
    Private mbolDetecNecesidades As Boolean
    Private mintCantParticipantes As Integer
    Private mstrLugarEjecucion As String
    Private mstrNumDireccion As String
    Private mstrCiudad As String
    Private mlngCodComuna As Long
    Private mobjCsql As New CSql
    Private mintAnoInicio As Integer
    Private mstrObservacion As String
    Private mintCodModalidad As Integer
    Private mstrCodSence As String
    Private mdtDatosCursoSence As DataTable
    Private mintHrsSence As Integer
    Private mlngRutOtec As Long
    Private mdtmFechaInicio As Date
    Private mdtmFechaFin As Date
    Private mintHrsComplementarias As Integer
    Private mlngTotal As Long
    Private mstrContactoAdicional As String
    Private mdblPorcAdm As Double
    Private mlngCorrelativo As Long
    Private mlngCostoOtic As Long
    Private mlngCostoAdm As Long
    Private mlngGastoEmpresa As Long
    Private mlngCostoOticVYT As Long
    Private mlngCostoAdmVYT As Long
    Private mlngGastoEmpresaVYT As Long
    Private mlngTotalViatico As Long
    Private mlngTotalTraslado As Long
    Private mlngCodCursoIngresado As Long
    Private mlngDescuento As Long
    Private mintCodTipoDescuento As Integer
    Private mintDia As Integer
    Private mstrHoraInicio As String
    Private mstrHoraFin As String
    Private mlngRutEmpleado = 0
    Private mstrNombres As String
    Private mstrApePaterno As String
    Private mstrApeMaterno As String
    Private mstrSexo As String
    Private mintCodRegionPartic As Integer
    Private mintCodOcupacional As Integer
    Private mdblFranquicia As Double
    Private mlngViatico As Long
    Private mbolFlagFranqViatico As Boolean
    Private mlngTraslado As Long
    Private mbolFlagFranqTraslado As Boolean
    Private mintCodEscolaridad As Integer
    Private mdtmFechaNacimiento As Date
    Private mintCodComunaPartic As Integer
    Private mstrCodSenceCurso As String
    Private mstrNombreCurso As String
    Private mstrArea As String
    Private mstrEspecialidad As String
    Private mlngDurCursoTeorico As Long
    Private mlngDurCursoPractico As Long
    Private mlngNumMaxParticip As Long
    Private mstrNombreSede As String
    Private mstrFonoSede As String
    Private mstrDireccion As String
    Private mstrComunaCurso As String
    Private mblnPendiente As Boolean
    Private mstrComuna As String
    Private mlngNumAlumnos As Long
    Private mlngValHoraSence As Double
    Private mlngCostoOticAlumno As Long
    Private mlngCostoOticAlumnoVYT As Long
    Private mlngGastoEmpresaAlumnoVYT As Long
    Private mlngGastoEmpresaAlumno As Long
    Private mlngRut As Long '??
    Private mstrPathXML As String
    Private mstrNombreArchivo As String
    Private mstrResultadoCabecera As String
    Private mstrPathXMLResultado As String
    Private mstrEjecutor As String
    Private mintAgno As Integer
    'Esta dato no va
    Private mlngRutEjecutivo As Long
    ''
    Private mobjSql As New CSql
    Private mobjSqlExcel As New CSql
    Private mobjEnviarCorreo As New CEnviarCorreo
    Private strTError As String
    Public dtErrores As DataTable
    Private mdtMensajes As DataTable
    Public mdtDatAlum As DataTable
    Private mlngRutEmplCoordinador As Long
    Private mlngCodUnidadViene As Long
    Private mstrTipoModalidad As String
    Private mintCodTipoUnidad As Integer
    Private mstrXml As String
    Private blnErrores As Boolean
    Private mblnEnvioCorreo As Boolean
    Private mstrMensajeParaEmail As String
    Private mstrCorrelEmpresa As String
    Private mdblCostoCurso As Double
    Private mstrHorario As String
    Private mintHoras As Integer
    Private mlngValorCuentaOtic As Long
    Private mlngValorCuenta As Long
    Private mintCodCuenta As Integer
    Private mintOrigen As Integer
    Private mdtOtec As DataTable
    Private mlngRutOtec2 As Long
    Private mstrClaseDeCurso As String
    Private mintHrsParciales As Integer
    Private mlngCorrelativoEmpresa As Long
    Private mstrNombreEmpresa As String
    Private mlngNroRegistro As Long

    Private mdtLog As DataTable
    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property
    'Se le agregan registros
    Public ReadOnly Property Mensajes() As DataTable
        Get
            Return Me.mdtMensajes
        End Get
    End Property
    Public Property CodUnidadViene() As Long
        Get
            Return Me.mlngCodUnidadViene
        End Get
        Set(ByVal value As Long)
            mlngCodUnidadViene = value
        End Set
    End Property
    Public Property RutEmpresa() As Long
        Get
            Return Me.mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
            mstrRutEmpresa = RutLngAUsr(mlngRutEmpresa)
        End Set
    End Property
    'mstrTipoModalidad
    Public Property Modalidad() As String
        Get
            Return Me.mstrTipoModalidad
        End Get
        Set(ByVal value As String)
            mstrTipoModalidad = value
        End Set
    End Property
#Region "carga"
    Public Function Cargar_Archivo(ByVal strRuta As String)
        Try

            mobjSql = New CSql
            Dim dtTemporal, dtTemporalII, dtTemporalIII, dtTemporalIV As DataTable
            Dim dr, drII, drIII, drIV As DataRow


            mobjSqlExcel.MotorDb = "excel8"
            mobjSqlExcel.BD = strRuta

            dtTemporal = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Cabecera$]")
            If Not dtTemporal Is Nothing Then
                If dtTemporal.Columns.Count < 24 Then
                    mstrMensaje = "A la cabecera del curso le faltan columnas obligatorias"
                    mblnEnvioCorreo = True
                    EnvioErrores(mstrMensaje)
                    blnErrores = False
                    Exit Function
                End If
            Else
                mstrMensaje = "La cabecera del curso tiene errores"
                mblnEnvioCorreo = True
                EnvioErrores(mstrMensaje)
                blnErrores = False
                Exit Function
            End If

            For Each dr In dtTemporal.Rows
                If Not IsDBNull(dr(23)) Then
                    If EsRut(dr(23)) Then
                        If mobjCsql.s_existe_persona_juridica(RutUsrALng(dr(23))) Then
                            mlngRutEmpresa = RutUsrALng(dr(23))
                        Else

                        End If

                    Else
                        mstrMensaje = "El rut es erroneo"
                        mblnEnvioCorreo = True
                        EnvioErrores(mstrMensaje)
                        blnErrores = False
                        Exit Function
                    End If
                Else
                    mstrMensaje = "Falta el rut de la empresa"
                    mblnEnvioCorreo = True
                    EnvioErrores(mstrMensaje)
                    blnErrores = False
                    Exit Function
                End If
                'mlngRutEmpresa=
                'si tipo de curso es Sence = 1 se efectua el ingreso
                If Not IsDBNull(dr(0)) Then
                    If Trim(dr(0)).ToUpper = "SENCE" Then
                        If Not IsDBNull(dr(9)) Then
                            If Not mobjCsql.Existe_correlativo_empresa(Me.mlngRutEmpresa, dr(9)) Then
                                mstrCorrelEmpresa = dr(9)
                            Else
                                mstrMensaje = "Ya se ingreso el  correlativo empresa"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe correlativo empresa"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(14)) Then
                            If Trim(dr(14)).ToUpper = "NORMAL" Or Trim(dr(14)).ToUpper = "PRECONTRATO" Or Trim(dr(14)).ToUpper = "POSCONTRATO" Then
                                If Trim(dr(14)).ToUpper = "NORMAL" Then
                                    mintCodTipoActividad = 1
                                End If
                                If Trim(dr(14)).ToUpper = "PRECONTRATO" Then
                                    mintCodTipoActividad = 2
                                End If
                                If Trim(dr(14)).ToUpper = "POSCONTRATO" Then
                                    mintCodTipoActividad = 3
                                End If
                            Else
                                mstrMensaje = "No existe el tipo de actividad para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el código de actividad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(15)) Then
                            If Trim(dr(15)).ToUpper = "SI" Or Trim(dr(15)).ToUpper = "NO" Then
                                mbolComBipartito = IIf(Trim(dr(15)).ToUpper = "SI", True, False)
                            Else
                                mstrMensaje = "No existe información del comité bipartito para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del comité bipartito para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(16)) Then
                            If Trim(dr(16)).ToUpper = "SI" Or Trim(dr(16)).ToUpper = "NO" Then
                                Me.mbolDetecNecesidades = IIf(Trim(dr(16)).ToUpper = "SI", True, False)
                            Else
                                mstrMensaje = "No existe información de la detección de necesidades  para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información de la detección de necesidades para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(1)) Then
                            If IsNumeric(dr(1)) Then
                                If dr(1) > 0 And dr(1) < 2147483647 Then
                                    mintCantParticipantes = dr(1)
                                Else
                                    mstrMensaje = "El número de paticipantes no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If

                        If Not IsDBNull(dr(2)) Then
                            mstrLugarEjecucion = dr(2)
                        Else
                            mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(17)) Then
                            mstrNumDireccion = dr(17)
                        Else
                            mstrNumDireccion = "0"
                        End If
                        If Not IsDBNull(dr(18)) Then
                            mstrCiudad = dr(18)
                        Else
                            mstrMensaje = "No existe la ciudad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(3)) Then
                            If mobjCsql.s_existe_comuna(dr(3)) Then
                                mlngCodComuna = dr(3)
                            Else
                                mlngCodComuna = 132101
                                mstrMensaje = "No existe código de la comuna para el correlativo: " & dr(9) & " se carga por defecto Santiago"
                                mblnEnvioCorreo = False
                                EnvioErrores(mstrMensaje)
                                'blnErrores = False
                                'Exit Function
                            End If
                        Else
                            mlngCodComuna = 132101
                            mstrMensaje = "El código de la comuna no existe para el correlativo: " & dr(9) & " se carga por defecto Santiago"
                            mblnEnvioCorreo = False
                            EnvioErrores(mstrMensaje)
                            'blnErrores = False
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(4)) Then
                            If IsNumeric(dr(4)) Then
                                If dr(4) > 1990 And dr(4) < 3000 Then
                                    mintAnoInicio = dr(4)
                                Else
                                    mstrMensaje = "El año de inicio no contiene un valor numerico valido para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function

                                End If
                            Else
                                mstrMensaje = "El año de inicio no contiene un valor numerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del año de inicio para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(5)) Then
                            mstrObservacion = dr(5)
                        Else
                            mstrObservacion = ""
                        End If
                        If Not IsDBNull(dr(19)) Then
                            If Trim(dr(19)).ToUpper = "PRESENCIAL" Or Trim(dr(19)).ToUpper = "E-LEARNING" Or Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Then
                                If Trim(dr(19)).ToUpper = "PRESENCIAL" Then
                                    mintCodTipoActividad = 1
                                End If
                                If Trim(dr(19)).ToUpper = "E-LEARNING" Then
                                    mintCodTipoActividad = 2
                                End If
                                If Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Then
                                    mintCodTipoActividad = 3
                                End If
                            Else
                                mstrMensaje = "La modalidad no esta reconocida para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el código de modalidad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(20)) Then
                            mstrCodSence = dr(20)
                            If Not CargaDatosCurso(mstrCodSence) Then
                                mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No se ha incluido el código sence del curso para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        mdtDatosCursoSence = mobjCsql.s_datos_curso2(mstrCodSence)
                        If Not IsNothing(mdtDatosCursoSence) Then
                            If mdtDatosCursoSence.Rows.Count > 0 Then
                                Me.mintHrsSence = mdtDatosCursoSence.Rows(0).Item("horas_sence")
                                Me.mlngRutOtec = mdtDatosCursoSence.Rows(0).Item("rut_otec")
                            Else
                                mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(6)) Then
                            If IsDate(dr(6)) Then
                                If CDate(dr(6)) > CDate(FechaVbAUsr(Now)) Then
                                    If Not Year(CDate(dr(6))) > Year(Now) + 1 Then
                                        If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                            mdtmFechaInicio = dr(6)
                                        Else
                                            mstrMensaje = "La fecha de inicio del curso esta fuera de los parametros del sistema correlativo: " & dr(9)
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de inicio del curso tiene formato incorrecto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(7)) Then
                            If IsDate(dr(7)) Then
                                If CDate(dr(7)) > CDate(dr(6)) Then
                                    If Not Year(CDate(dr(7))) > Year(Now) + 1 Then
                                        If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                            mdtmFechaFin = dr(7)
                                        Else
                                            mstrMensaje = "La fecha de fin del curso esta fuera de los parametrso del sistema en el correlativo: " & dr(9)
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de fin del curso no tiene el formato correcto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(21)) Then
                            If IsNumeric(dr(21)) Then
                                If dr(21) < 100000 Then
                                    mintHrsComplementarias = dr(21)
                                Else
                                    mstrMensaje = "El valor de las horas sobrepasa lo permitido por el sistema en el correlativo : " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El valor de las horas complementarias debe ser numerico en el correlativo : " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function

                            End If
                        Else
                            mintHrsComplementarias = 0
                        End If
                        If Not IsDBNull(dr(8)) Then
                            If IsNumeric(dr(8)) Then
                                If dr(8) > 0 And dr(8) < 2147483647 Then
                                    mlngTotal = dr(8)
                                Else
                                    mstrMensaje = "El valor total del curso debe ser mayor a cero en el correlativo : " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El valor total del curso debe ser un valor numerico en el correlativo : " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El valor total del curso no existe en el correlativo : " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(22)) Then
                            mstrContactoAdicional = dr(22)
                        Else
                            mstrContactoAdicional = ""
                        End If
                        mdblPorcAdm = mobjCsql.s_porcentaje_administracion(Me.mlngRutEmpresa)
                        mobjCsql.InicioTransaccion()
                        GrabarDatos()
                        '***********************************************************************************
                        '********************************DATOS HORARIO**************************************
                        '***********************************************************************************
                        dtTemporalII = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Horario$]")
                        If Not dtTemporalII Is Nothing Then
                            If dtTemporalII.Columns.Count < 5 Then
                                mstrMensaje = "A horario del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El horario del curso tiene errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        For Each drII In dtTemporalII.Rows
                            If dr(9) = drII(3) And dr(23) = drII(4) Then
                                If Not IsDBNull(drII(0)) Then
                                    If IsNumeric(drII(0)) Then
                                        If drII(0) >= 1 And drII(0) <= 7 Then
                                            mintDia = drII(0)
                                        Else
                                            mstrMensaje = "El horario tiene valores que estan fuera del rango numerico en el campo dia, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "El horario tiene valor que no son numericos en el campo dia, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El horario tiene valores vacios en el campo dia, correlativo : " & mstrCorrelEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                                If Not IsDBNull(drII(1)) And Not IsDBNull(drII(2)) Then
                                    If ValidaHoras(CStr(drII(1)), CStr(drII(2))) Then
                                        mstrHoraInicio = drII(1)
                                        mstrHoraFin = drII(2)
                                    Else
                                        mstrMensaje = "En el horario la hora de incio no puede ser mayor a la hora de fin, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En el horario la hora de incio no puede ser mayor a la hora de fin, correlativo : " & mstrCorrelEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                                GrabarHorario()
                            End If
                        Next
                        '***********************************************************************************
                        '******************************DATOS PARTICIPANTES**********************************
                        '***********************************************************************************
                        mlngNumAlumnos = 0
                        dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Alumnos$]")

                        If Not dtTemporalIII Is Nothing Then
                            If dtTemporalIII.Columns.Count < 5 Then
                                mstrMensaje = "A horario del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El horario del curso tiene errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If dtTemporalIII.Columns.Count < 13 Then
                            mstrMensaje = "Faltan datos de participantes para este curso correlativo: " & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        For Each drIII In dtTemporalIII.Rows
                            If Not dtTemporalIII Is Nothing Then
                                If dr(9) = drIII(13) And dr(23) = drIII(14) Then
                                    If Not Trim(drIII(0)) = "" Then
                                        If EsRut(drIII(0)) Then
                                            mlngRutEmpleado = RutUsrALng(drIII(0))
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin rut, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(1)) Then
                                        mstrNombres = drIII(1)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin nombre, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(2)) Then
                                        mstrApePaterno = drIII(2)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(3)) Then
                                        mstrApeMaterno = drIII(3)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido materno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(4)) Then
                                        If drIII(4) = "M" Or drIII(4) = "F" Then
                                            mstrSexo = drIII(4)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(5)) Then
                                        If IsNumeric(drIII(5)) Then
                                            If drIII(5) >= 1 And drIII(5) <= 15 Then
                                                mintCodRegionPartic = drIII(5)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código de región, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(7)) Then
                                        If IsNumeric(drIII(7)) Then
                                            If drIII(7) >= 0 And drIII(7) <= 100 Then
                                                mdblFranquicia = drIII(7)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin franquicia, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(6)) Then
                                        If IsNumeric(drIII(6)) Then
                                            If drIII(6) = 0 Then
                                                Select Case mdblFranquicia
                                                    Case 100
                                                        mintCodOcupacional = 4
                                                    Case 50
                                                        mintCodOcupacional = 3
                                                    Case 15
                                                        mintCodOcupacional = 1
                                                End Select
                                            Else
                                                If drIII(6) >= 1 And drIII(6) <= 7 Then
                                                    mintCodOcupacional = drIII(6)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(8)) Then
                                        If IsNumeric(drIII(8)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngViatico = drIII(8)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera de los rangos del sistema, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngViatico = 0
                                    End If
                                    If Not IsDBNull(drIII(9)) Then
                                        If IsNumeric(drIII(9)) Then
                                            If drIII(9) >= 0 And drIII(9) < 2147483647 Then
                                                mlngTraslado = drIII(9)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera de los rangos del sistema, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If

                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngTraslado = 0
                                    End If
                                    If Not IsDBNull(drIII(10)) Then
                                        If IsNumeric(drIII(10)) Then
                                            If drIII(10) = 0 Then
                                                mintCodEscolaridad = 5
                                            Else
                                                If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                    mintCodEscolaridad = drIII(10)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If

                                    If Not IsDBNull(drIII(11)) Then
                                        If IsDate(drIII(11)) Then
                                            If CDate(drIII(11)) < CDate(FechaVbAUsr(Now)) Then
                                                If CDate(drIII(11)) > CDate(FechaMinSistema()) And CDate(drIII(11)) < CDate(FechaMaxSistema()) Then
                                                    mdtmFechaNacimiento = CDate(drIII(11))
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function

                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato erroneo, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If

                                    If Not IsDBNull(drIII(12)) Then
                                        If mobjCsql.s_existe_comuna(drIII(12)) Then
                                            mintCodComunaPartic = drIII(12)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de comuna inexistente, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de comuna, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    mlngNumAlumnos = mlngNumAlumnos + 1
                                    CalcTotViaticoTrasl()
                                    GrabarAlumnos()
                                End If
                            Else
                                mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                blnErrores = False
                                Exit Function
                            End If
                        Next
                        If mlngNumAlumnos = 0 Then
                            mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If
                        Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
                                                    "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                                    & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                    1, Me.mlngCodCursoIngresado)
                        CalcularCostos(dtTemporalIII)
                        CalcCostoAdm()
                        ModificarDatos()
                        IngresaTransaccion()


                        '***********************************************************************************
                        '******************************DATOS CUENTAS**********************************
                        '***********************************************************************************
                        Dim intFilas As Integer
                        dtTemporalIV = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Cuentas$]")
                        intFilas = dtTemporalIV.Rows.Count
                        If Not dtTemporalIV Is Nothing Then
                            If dtTemporalIV.Columns.Count < 4 Then
                                mstrMensaje = "A Cuentas del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "Las cuentas del curso tienen errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If
                        If Not dtTemporalIV Is Nothing Then
                            Dim i As Integer = 0
                            Dim j As Integer = 0
                            mlngValorCuentaOtic = 0
                            mlngValorCuenta = 0
                            Dim strCorrelativoEmp As String = ""
                            strCorrelativoEmp = dr(9)
                            For i = 0 To intFilas - 1
                                Dim salir As Integer = 0

                                If Not strCorrelativoEmp = dtTemporalIV.Rows(i).Item(0) Then

                                Else

                                    Do
                                        If dr(9) = dtTemporalIV.Rows(i).Item(0) And dr(23) = dtTemporalIV.Rows(i).Item(3) Then
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(0)) Then
                                                mstrCorrelEmpresa = dtTemporalIV.Rows(i).Item(0)
                                            Else
                                                mstrMensaje = "El correlativo empresa no se encuenta en la hoja cuentas"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(2)) Then
                                                If dtTemporalIV.Rows(i).Item(2) = 1 Or dtTemporalIV.Rows(i).Item(2) = 2 Or dtTemporalIV.Rows(i).Item(2) = 4 _
                                                Or dtTemporalIV.Rows(i).Item(2) = 5 Or dtTemporalIV.Rows(i).Item(2) = 8 Or dtTemporalIV.Rows(i).Item(2) = 9 Then
                                                    mintCodCuenta = dtTemporalIV.Rows(i).Item(2)
                                                Else
                                                    mstrMensaje = "El código de la cuenta no es valido"
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "No tiene asignada un código a la cuenta"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(3)) Then
                                                If dtTemporalIV.Rows(i).Item(3) = dr(23) Then
                                                    mlngRutEmpresa = RutUsrALng(dtTemporalIV.Rows(i).Item(3))
                                                Else
                                                    mstrMensaje = "El rut empresa no coinciden"
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If

                                            Else
                                                mstrMensaje = "No se asignó ningún rut empresa en la hoja cuentas"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(1)) Then
                                                mlngValorCuenta = dtTemporalIV.Rows(i).Item(1)
                                                IngresaTransaccionCuentas()
                                            Else
                                                mstrMensaje = "no tiene asignada un valor a la cuenta"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            mlngValorCuentaOtic = mlngValorCuentaOtic + mlngValorCuenta
                                        End If
                                        i = i + 1
                                        If Not i = intFilas Then
                                            If strCorrelativoEmp <> dtTemporalIV.Rows(i).Item(j) Then
                                                salir = 1
                                                i = i - 1
                                            End If
                                        Else
                                            salir = 1
                                        End If

                                    Loop While salir = 0
                                    If Not mlngValorCuentaOtic = mlngCostoOtic Then
                                        mstrMensaje = "el valor total de la cuenta debe ser igual al monto otic"
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                End If

                            Next
                        Else
                            mstrMensaje = "No existen cuentas para el curso: " & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If

                        mobjCsql.FinTransaccion()
                        blnErrores = True
                        mstrMensaje = "Se ingreso correctamente el curso, correlativo : " & Me.mstrCorrelEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & mstrRutEmpresa
                        mblnEnvioCorreo = False
                        EnvioErrores(mstrMensaje)

                        '*************************************************************************************
                        '*************************************************************************************
                        '******************* CURSO INTERNO ***************************************************
                        '*************************************************************************************
                        '*************************************************************************************
                    ElseIf Trim(dr(0)).ToUpper = "NO SENCE" Then
                        If Not IsDBNull(dr(9)) Then
                            mstrCorrelEmpresa = dr(9)
                        Else
                            mstrMensaje = "No existe correlativo"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(3)) Then
                            If mobjCsql.s_existe_comuna(dr(3)) Then
                                mlngCodComuna = dr(3)
                            Else
                                mlngCodComuna = 132101
                                mstrMensaje = "No existe código de la comuna para el correlativo: " & dr(9) & " se carga por defecto comuna de Santiago"
                                mblnEnvioCorreo = False
                                EnvioErrores(mstrMensaje)
                                'blnErrores = False
                                'Exit Function
                            End If
                        Else
                            mlngCodComuna = 132101
                            mstrMensaje = "El código de la comuna no existe para el correlativo: " & dr(9) & " se carga por defecto comuna de Santiago"
                            mblnEnvioCorreo = False
                            EnvioErrores(mstrMensaje)
                            ' blnErrores = False
                            'Exit Function
                        End If

                        If Not IsDBNull(dr(10)) Then
                            mstrNombreCurso = dr(10)
                        Else
                            mstrMensaje = "El nombre del curso no existe para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(11)) Then
                            mstrEjecutor = dr(11)
                        Else
                            mstrMensaje = "El nombre del ejecutor del curso no existe para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(4)) Then
                            If IsNumeric(dr(4)) Then
                                If Not mobjCsql.Existe_correlativo_empresa_interno(Me.mlngRutEmpresa, dr(4), Me.mstrCorrelEmpresa) Then
                                    If dr(4) > 1900 And dr(4) < 3000 Then
                                        mintAgno = dr(4)
                                    Else
                                        mstrMensaje = "El correlativo " & dr(9) & " el año esta en rangos incorrectos. "
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El correlativo " & dr(9) & " ya se ha ingresado este año. "
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If

                            Else
                                mstrMensaje = "El año del curso no contiene un valor numerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del año para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(1)) Then
                            If IsNumeric(dr(1)) Then
                                If dr(1) > 0 And dr(1) < 2147483647 Then

                                    mintCantParticipantes = dr(1)
                                Else
                                    mstrMensaje = "El número de paticipantes no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(2)) Then
                            mstrDireccion = dr(2)
                        Else
                            mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(6)) Then
                            If IsDate(dr(6)) Then
                                If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaInicio = dr(6)
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de inicio del curso no tiene formato correcto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If

                        If Not IsDBNull(dr(7)) Then
                            If CDate(dr(7)) > CDate(dr(6)) Then
                                If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaFin = dr(7)
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(8)) Then
                            If IsNumeric(dr(8)) Then
                                If dr(8) >= 0 And dr(8) < 2147483647 Then
                                    mdblCostoCurso = dr(8)
                                Else
                                    mstrMensaje = "El costo del curso es menor a cero para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(5)) Then
                            mstrObservacion = Trim(dr(5))
                        Else
                            mstrObservacion = ""
                        End If
                        If Not IsDBNull(dr(12)) Then
                            mstrHorario = Trim(dr(12))
                        Else
                            mstrHorario = ""
                        End If
                        If Not IsDBNull(dr(13)) Then
                            If IsNumeric(dr(13)) Then
                                If dr(13) >= 0 And dr(13) <= 3000 Then
                                    mintHoras = Trim(dr(13))
                                Else
                                    mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "Faltan las horas para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        '''''''''''''''''''''''''HASTA ACA'''''''''''''''''''''''''''''''''''''
                        mobjCsql.InicioTransaccion()
                        GrabarDatosII()
                        '***********************************************************************************
                        '******************************DATOS PARTICIPANTES**********************************
                        '***********************************************************************************
                        mlngNumAlumnos = 0
                        dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Alumnos$]")
                        If Not dtTemporalIII Is Nothing Then
                            If dtTemporalIII.Columns.Count < 5 Then
                                mstrMensaje = "A los participantes del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "Los participantes del curso tiene errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        For Each drIII In dtTemporalIII.Rows
                            If Not dtTemporalIII Is Nothing Then
                                If dr(9) = drIII(13) And dr(23) = drIII(14) Then
                                    If Not Trim(drIII(0)) = "" Then
                                        If EsRut(drIII(0)) Then
                                            mlngRutEmpleado = RutUsrALng(drIII(0))
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function

                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin rut, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(1)) Then
                                        mstrNombres = drIII(1)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin nombre, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(2)) Then
                                        mstrApePaterno = drIII(2)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(3)) Then
                                        mstrApeMaterno = drIII(3)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido materno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(4)) Then
                                        If drIII(4) = "M" Or drIII(4) = "F" Then
                                            mstrSexo = drIII(4)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(5)) Then
                                        If IsNumeric(drIII(5)) Then
                                            If drIII(5) >= 1 And drIII(5) <= 15 Then
                                                mintCodRegionPartic = drIII(5)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código de región, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(7)) Then
                                        If IsNumeric(drIII(7)) Then
                                            If drIII(7) >= 0 And drIII(7) <= 100 Then
                                                mdblFranquicia = drIII(7)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin franquicia, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(6)) Then
                                        If IsNumeric(drIII(6)) Then
                                            If drIII(6) = 0 Then
                                                Select Case mdblFranquicia
                                                    Case 100
                                                        mintCodOcupacional = 4
                                                    Case 50
                                                        mintCodOcupacional = 3
                                                    Case 15
                                                        mintCodOcupacional = 1
                                                End Select
                                            Else
                                                If drIII(6) >= 1 And drIII(6) <= 7 Then
                                                    mintCodOcupacional = drIII(6)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(8)) Then
                                        If IsNumeric(drIII(8)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngViatico = drIII(8)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera del rango, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngViatico = 0
                                    End If
                                    If Not IsDBNull(drIII(9)) Then
                                        If IsNumeric(drIII(9)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngTraslado = drIII(9)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera del rango, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngTraslado = 0
                                    End If
                                    If Not IsDBNull(drIII(10)) Then
                                        If IsNumeric(drIII(10)) Then
                                            If drIII(10) = 0 Then
                                                mintCodEscolaridad = 5
                                            Else
                                                If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                    mintCodEscolaridad = drIII(10)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If

                                    If Not IsDBNull(drIII(11)) Then
                                        If IsDate(drIII(11)) Then
                                            If CDate(drIII(11)) < CDate(FechaVbAUsr(Now)) Then
                                                mdtmFechaNacimiento = CDate(drIII(11))
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato incorrecto, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(12)) Then
                                        If mobjCsql.s_existe_comuna(drIII(12)) Then
                                            mintCodComunaPartic = drIII(12)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de comuna inexistente, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de comuna, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    mlngNumAlumnos = mlngNumAlumnos + 1
                                    GrabarAlumnosII()
                                End If
                            Else
                                mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                blnErrores = False
                                Exit Function
                            End If

                        Next
                        If mlngNumAlumnos = 0 Then
                            mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If
                        Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
                                                    "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                                    & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                    1, Me.mlngCodCursoIngresado)
                        mobjCsql.FinTransaccion()
                        mstrMensaje = "Se ingreso correctamente el curso, correlativo : " & Me.mstrCorrelEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & mstrRutEmpresa
                        mblnEnvioCorreo = False
                        EnvioErrores(mstrMensaje)
                    End If
                End If
            Next
            blnErrores = True
            mblnEnvioCorreo = True
            mstrMensaje = ""
            EnvioErrores(mstrMensaje)
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            EnviaError("CCargaCursosXls:cargar_archivos-->" & ex.Message)
        End Try
    End Function
    Public Function Cargar_Archivo2(ByVal strRuta As String)
        Try

            mobjSql = New CSql
            Dim dtTemporal, dtTemporalII, dtTemporalIII, dtTemporalIV As DataTable
            Dim dr, drII, drIII, drIV As DataRow


            mobjSqlExcel.MotorDb = "excel8"
            mobjSqlExcel.BD = strRuta

            dtTemporal = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Cabecera$]")
            If Not dtTemporal Is Nothing Then
                If dtTemporal.Columns.Count < 24 Then
                    mstrMensaje = "A la cabecera del curso le faltan columnas obligatorias"
                    mblnEnvioCorreo = True
                    EnvioErrores(mstrMensaje)
                    blnErrores = False
                    Exit Function
                End If
            Else
                mstrMensaje = "La cabecera del curso tiene errores"
                mblnEnvioCorreo = True
                EnvioErrores(mstrMensaje)
                blnErrores = False
                Exit Function
            End If

            For Each dr In dtTemporal.Rows
                If Not IsDBNull(dr(23)) Then
                    If EsRut(dr(23)) Then
                        mlngRutEmpresa = RutUsrALng(dr(23))
                    Else
                        mstrMensaje = "El rut es erroneo"
                        mblnEnvioCorreo = True
                        EnvioErrores(mstrMensaje)
                        blnErrores = False
                        Exit Function
                    End If
                Else
                    mstrMensaje = "Falta el rut de la empresa"
                    mblnEnvioCorreo = True
                    EnvioErrores(mstrMensaje)
                    blnErrores = False
                    Exit Function
                End If
                'mlngRutEmpresa=
                'si tipo de curso es Sence = 1 se efectua el ingreso
                If Not IsDBNull(dr(0)) Then
                    If Trim(dr(0)).ToUpper = "SENCE" Then
                        If Not IsDBNull(dr(9)) Then
                            'If Not mobjCsql.Existe_correlativo_empresa(Me.mlngRutEmpresa, dr(9)) Then
                            mstrCorrelEmpresa = dr(9)
                            'Else
                            '    mstrMensaje = "Ya se ingreso el  correlativo empresa"
                            '    mblnEnvioCorreo = True
                            '    EnvioErrores(mstrMensaje)
                            '    blnErrores = False
                            '    Exit Function
                            'End If
                        Else
                            mstrMensaje = "No existe correlativo empresa"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(14)) Then
                            If Trim(dr(14)).ToUpper = "NORMAL" Or Trim(dr(14)).ToUpper = "PRECONTRATO" Or Trim(dr(14)).ToUpper = "POSCONTRATO" Then
                                If Trim(dr(14)).ToUpper = "NORMAL" Then
                                    mintCodTipoActividad = 1
                                End If
                                If Trim(dr(14)).ToUpper = "PRECONTRATO" Then
                                    mintCodTipoActividad = 2
                                End If
                                If Trim(dr(14)).ToUpper = "POSCONTRATO" Then
                                    mintCodTipoActividad = 3
                                End If
                            Else
                                mstrMensaje = "No existe el tipo de actividad para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el código de actividad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(15)) Then
                            If Trim(dr(15)).ToUpper = "SI" Or Trim(dr(15)).ToUpper = "NO" Then
                                mbolComBipartito = IIf(Trim(dr(15)).ToUpper = "SI", True, False)
                            Else
                                mstrMensaje = "No existe información del comité bipartito para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del comité bipartito para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(16)) Then
                            If Trim(dr(16)).ToUpper = "SI" Or Trim(dr(16)).ToUpper = "NO" Then
                                Me.mbolDetecNecesidades = IIf(Trim(dr(16)).ToUpper = "SI", True, False)
                            Else
                                mstrMensaje = "No existe información de la detección de necesidades  para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información de la detección de necesidades para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(1)) Then
                            If IsNumeric(dr(1)) Then
                                If dr(1) > 0 And dr(1) < 2147483647 Then
                                    mintCantParticipantes = dr(1)
                                Else
                                    mstrMensaje = "El número de paticipantes no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If

                        If Not IsDBNull(dr(2)) Then
                            mstrLugarEjecucion = dr(2)
                        Else
                            mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(17)) Then
                            mstrNumDireccion = dr(17)
                        Else
                            mstrNumDireccion = "0"
                        End If
                        If Not IsDBNull(dr(18)) Then
                            mstrCiudad = dr(18)
                        Else
                            mstrMensaje = "No existe la ciudad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(3)) Then
                            If mobjCsql.s_existe_comuna(dr(3)) Then
                                mlngCodComuna = dr(3)
                            Else
                                mlngCodComuna = 132101
                                mstrMensaje = "No existe código de la comuna para el correlativo: " & dr(9) & " se carga por defecto Santiago"
                                mblnEnvioCorreo = False
                                EnvioErrores(mstrMensaje)
                                'blnErrores = False
                                'Exit Function
                            End If
                        Else
                            mlngCodComuna = 132101
                            mstrMensaje = "El código de la comuna no existe para el correlativo: " & dr(9) & " se carga por defecto Santiago"
                            mblnEnvioCorreo = False
                            EnvioErrores(mstrMensaje)
                            'blnErrores = False
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(4)) Then
                            If IsNumeric(dr(4)) Then
                                If dr(4) > 1990 And dr(4) < 3000 Then
                                    mintAnoInicio = dr(4)
                                Else
                                    mstrMensaje = "El año de inicio no contiene un valor numerico valido para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function

                                End If
                            Else
                                mstrMensaje = "El año de inicio no contiene un valor numerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del año de inicio para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(5)) Then
                            mstrObservacion = dr(5)
                        Else
                            mstrObservacion = ""
                        End If
                        If Not IsDBNull(dr(19)) Then
                            If Trim(dr(19)).ToUpper = "PRESENCIAL" Or Trim(dr(19)).ToUpper = "E-LEARNING" Or Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Then
                                If Trim(dr(19)).ToUpper = "NORMAL" Then
                                    mintCodTipoActividad = 1
                                End If
                                If Trim(dr(19)).ToUpper = "E-LEARNING" Then
                                    mintCodTipoActividad = 2
                                End If
                                If Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Then
                                    mintCodTipoActividad = 3
                                End If
                            Else
                                mstrMensaje = "La modalidad no esta reconocida para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No modalidad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(20)) Then
                            mstrCodSence = dr(20)
                            If Not CargaDatosCurso(mstrCodSence) Then
                                mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No se ha incluido el código sence del curso para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        mdtDatosCursoSence = mobjCsql.s_datos_curso2(mstrCodSence)
                        If Not IsNothing(mdtDatosCursoSence) Then
                            If mdtDatosCursoSence.Rows.Count > 0 Then
                                Me.mintHrsSence = mdtDatosCursoSence.Rows(0).Item("horas_sence")
                                Me.mlngRutOtec = mdtDatosCursoSence.Rows(0).Item("rut_otec")
                            Else
                                mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(6)) Then
                            If IsDate(dr(6)) Then
                                'If CDate(dr(6)) > CDate(FechaVbAUsr(Now)) Then
                                'If Not Year(CDate(dr(6))) > Year(Now) + 1 Then
                                If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaInicio = dr(6)
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta fuera de los parametros del sistema correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                                'Else
                                '    mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                '    mblnEnvioCorreo = True
                                '    EnvioErrores(mstrMensaje)
                                '    blnErrores = False
                                '    Exit Function
                                'End If
                                'Else
                                '    mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                '    mblnEnvioCorreo = True
                                '    EnvioErrores(mstrMensaje)
                                '    blnErrores = False
                                '    Exit Function
                                'End If
                            Else
                                mstrMensaje = "La fecha de inicio del curso tiene formato incorrecto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(7)) Then
                            If IsDate(dr(7)) Then
                                If CDate(dr(7)) > CDate(dr(6)) Then
                                    'If Not Year(CDate(dr(7))) > Year(Now) + 1 Then
                                    If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                        mdtmFechaFin = dr(7)
                                    Else
                                        mstrMensaje = "La fecha de fin del curso esta fuera de los parametrso del sistema en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    'Else
                                    '    mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                    '    mblnEnvioCorreo = True
                                    '    EnvioErrores(mstrMensaje)
                                    '    blnErrores = False
                                    '    Exit Function
                                    'End If
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de fin del curso no tiene el formato correcto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(21)) Then
                            If IsNumeric(dr(21)) Then
                                If dr(21) < 100000 Then
                                    mintHrsComplementarias = dr(21)
                                Else
                                    mstrMensaje = "El valor de las horas sobrepasa lo permitido por el sistema en el correlativo : " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El valor de las horas complementarias debe ser numerico en el correlativo : " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function

                            End If
                        Else
                            mintHrsComplementarias = 0
                        End If
                        If Not IsDBNull(dr(8)) Then
                            If IsNumeric(dr(8)) Then
                                If dr(8) > 0 And dr(8) < 2147483647 Then
                                    mlngTotal = dr(8)
                                Else
                                    mstrMensaje = "El valor total del curso debe ser mayor a cero en el correlativo : " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El valor total del curso debe ser un valor numerico en el correlativo : " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El valor total del curso no existe en el correlativo : " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(22)) Then
                            mstrContactoAdicional = dr(22)
                        Else
                            mstrContactoAdicional = ""
                        End If
                        If Not IsDBNull(dr(24)) Then
                            mintOrigen = dr(24)
                        Else
                            mintOrigen = 0
                        End If
                        mdblPorcAdm = mobjCsql.s_porcentaje_administracion(Me.mlngRutEmpresa)
                        mobjCsql.InicioTransaccion()
                        GrabarDatosAdm()
                        '***********************************************************************************
                        '********************************DATOS HORARIO**************************************
                        '***********************************************************************************
                        dtTemporalII = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Horario$]")
                        If Not dtTemporalII Is Nothing Then
                            If dtTemporalII.Columns.Count < 5 Then
                                mstrMensaje = "A horario del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El horario del curso tiene errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        For Each drII In dtTemporalII.Rows
                            If dr(9) = drII(3) And dr(23) = drII(4) Then
                                If Not IsDBNull(drII(0)) Then
                                    If IsNumeric(drII(0)) Then
                                        If drII(0) >= 1 And drII(0) <= 7 Then
                                            mintDia = drII(0)
                                        Else
                                            mstrMensaje = "El horario tiene valores que estan fuera del rango numerico en el campo dia, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "El horario tiene valor que no son numericos en el campo dia, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El horario tiene valores vacios en el campo dia, correlativo : " & mstrCorrelEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                                If Not IsDBNull(drII(1)) And Not IsDBNull(drII(2)) Then
                                    If ValidaHoras(CStr(drII(1)), CStr(drII(2))) Then
                                        mstrHoraInicio = drII(1)
                                        mstrHoraFin = drII(2)
                                    Else
                                        mstrMensaje = "En el horario la hora de incio no puede ser mayor a la hora de fin, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En el horario la hora de incio no puede ser mayor a la hora de fin, correlativo : " & mstrCorrelEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                                GrabarHorario()
                            End If
                        Next
                        '***********************************************************************************
                        '******************************DATOS PARTICIPANTES**********************************
                        '***********************************************************************************
                        mlngNumAlumnos = 0
                        dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Alumnos$]")

                        If dtTemporalIII.Columns.Count < 15 Then
                            mstrMensaje = "Faltan datos de participantes para este curso correlativo: " & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not dtTemporalIII Is Nothing Then
                            For Each drIII In dtTemporalIII.Rows

                                If dr(9) = drIII(13) And dr(23) = drIII(14) Then
                                    If Not Trim(drIII(0)) = "" Then
                                        If EsRut(drIII(0)) Then
                                            mlngRutEmpleado = RutUsrALng(drIII(0))
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin rut, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(1)) Then
                                        mstrNombres = drIII(1)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin nombre, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(2)) Then
                                        mstrApePaterno = drIII(2)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(3)) Then
                                        mstrApeMaterno = drIII(3)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido materno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(4)) Then
                                        If drIII(4) = "M" Or drIII(4) = "F" Then
                                            mstrSexo = drIII(4)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(5)) Then
                                        If IsNumeric(drIII(5)) Then
                                            If drIII(5) >= 1 And drIII(5) <= 15 Then
                                                mintCodRegionPartic = drIII(5)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código de región, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(7)) Then
                                        If IsNumeric(drIII(7)) Then
                                            If drIII(7) >= 0 And drIII(7) <= 100 Then
                                                mdblFranquicia = drIII(7)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin franquicia, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(6)) Then
                                        If IsNumeric(drIII(6)) Then
                                            If drIII(6) = 0 Then
                                                Select Case mdblFranquicia
                                                    Case 100
                                                        mintCodOcupacional = 4
                                                    Case 50
                                                        mintCodOcupacional = 3
                                                    Case 15
                                                        mintCodOcupacional = 1
                                                End Select
                                            Else
                                                If drIII(6) >= 1 And drIII(6) <= 7 Then
                                                    mintCodOcupacional = drIII(6)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(8)) Then
                                        If IsNumeric(drIII(8)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngViatico = drIII(8)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera de los rangos del sistema, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngViatico = 0
                                    End If
                                    If Not IsDBNull(drIII(9)) Then
                                        If IsNumeric(drIII(9)) Then
                                            If drIII(9) >= 0 And drIII(9) < 2147483647 Then
                                                mlngTraslado = drIII(9)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera de los rangos del sistema, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If

                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngTraslado = 0
                                    End If
                                    If Not IsDBNull(drIII(10)) Then
                                        If IsNumeric(drIII(10)) Then
                                            If drIII(10) = 0 Then
                                                mintCodEscolaridad = 5
                                            Else
                                                If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                    mintCodEscolaridad = drIII(10)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If

                                    If Not IsDBNull(drIII(11)) Then
                                        If IsDate(drIII(11)) Then
                                            If CDate(drIII(11)) < CDate(FechaVbAUsr(Now)) Then
                                                If CDate(drIII(11)) > CDate(FechaMinSistema()) And CDate(drIII(11)) < CDate(FechaMaxSistema()) Then
                                                    mdtmFechaNacimiento = CDate(drIII(11))
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function

                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato erroneo, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If

                                    If Not IsDBNull(drIII(12)) Then
                                        If mobjCsql.s_existe_comuna(drIII(12)) Then
                                            mintCodComunaPartic = drIII(12)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de comuna inexistente, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de comuna, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    mlngNumAlumnos = mlngNumAlumnos + 1
                                    CalcTotViaticoTrasl()
                                    GrabarAlumnos()
                                End If

                            Next
                        Else
                            mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function

                        End If
                        If mlngNumAlumnos = 0 Then
                            mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If
                        Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
                                                    "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                                    & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                    1, Me.mlngCodCursoIngresado)
                        CalcularCostos(dtTemporalIII)
                        CalcCostoAdm()
                        ModificarDatos()
                        IngresaTransaccion()


                        '***********************************************************************************
                        '******************************DATOS CUENTAS**********************************
                        '***********************************************************************************
                        Dim intFilas As Integer
                        dtTemporalIV = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Cuentas$]")
                        intFilas = dtTemporalIV.Rows.Count
                        If Not dtTemporalIV Is Nothing Then
                            If dtTemporalIV.Columns.Count < 4 Then
                                mstrMensaje = "A Cuentas del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "Las cuentas del curso tienen errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If
                        If Not dtTemporalIV Is Nothing Then
                            Dim i As Integer = 0
                            Dim j As Integer = 0
                            mlngValorCuentaOtic = 0
                            mlngValorCuenta = 0
                            Dim strCorrelativoEmp As String = ""
                            strCorrelativoEmp = dr(9)
                            For i = 0 To intFilas - 1
                                Dim salir As Integer = 0
                                If strCorrelativoEmp = dtTemporalIV.Rows(i).Item(0) Then
                                    Do
                                        If dr(9) = dtTemporalIV.Rows(i).Item(0) And dr(23) = dtTemporalIV.Rows(i).Item(3) Then
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(0)) Then
                                                mstrCorrelEmpresa = dtTemporalIV.Rows(i).Item(0)
                                            Else
                                                mstrMensaje = "El correlativo empresa no se encuenta en la hoja cuentas"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(2)) Then
                                                If dtTemporalIV.Rows(i).Item(2) = 1 Or dtTemporalIV.Rows(i).Item(2) = 2 Or dtTemporalIV.Rows(i).Item(2) = 4 _
                                                Or dtTemporalIV.Rows(i).Item(2) = 5 Or dtTemporalIV.Rows(i).Item(2) = 8 Or dtTemporalIV.Rows(i).Item(2) = 9 Then
                                                    mintCodCuenta = dtTemporalIV.Rows(i).Item(2)
                                                Else
                                                    mstrMensaje = "El código de la cuenta no es valido"
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "No tiene asignada un código a la cuenta"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(3)) Then
                                                If dtTemporalIV.Rows(i).Item(3) = dr(23) Then
                                                    mlngRutEmpresa = RutUsrALng(dtTemporalIV.Rows(i).Item(3))
                                                Else
                                                    mstrMensaje = "El rut empresa no coinciden"
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "No se asignó ningún rut empresa en la hoja cuentas"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(1)) Then
                                                If dtTemporalIV.Rows(i).Item(1) > 0 Then
                                                    mlngValorCuenta = dtTemporalIV.Rows(i).Item(1)
                                                    IngresaTransaccionCuentas()
                                                End If
                                            Else
                                                mstrMensaje = "no tiene asignada un valor a la cuenta"
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                            mlngValorCuentaOtic = mlngValorCuentaOtic + mlngValorCuenta
                                        End If
                                        i = i + 1
                                        If Not i = intFilas Then
                                            If strCorrelativoEmp <> dtTemporalIV.Rows(i).Item(j) Then
                                                salir = 1
                                                i = i - 1
                                            End If
                                        Else
                                            salir = 1
                                        End If
                                    Loop While salir = 0
                                    If Not mlngValorCuentaOtic = mlngCostoOtic Then
                                        mstrMensaje = "el valor total de la cuenta debe ser igual al monto otic"
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                End If
                            Next
                        Else
                            mstrMensaje = "No existen cuentas para el curso: " & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If

                        mobjCsql.FinTransaccion()
                        blnErrores = True
                        mstrMensaje = "Se ingreso correctamente el curso, correlativo : " & Me.mstrCorrelEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & mstrRutEmpresa
                        mblnEnvioCorreo = False
                        EnvioErrores(mstrMensaje)

                        '*************************************************************************************
                        '*************************************************************************************
                        '******************* CURSO INTERNO ***************************************************
                        '*************************************************************************************
                        '*************************************************************************************
                    ElseIf Trim(dr(0)).ToUpper = "NO SENCE" Then
                        If Not IsDBNull(dr(9)) Then
                            mstrCorrelEmpresa = dr(9)
                        Else
                            mstrMensaje = "No existe correlativo"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(3)) Then
                            If mobjCsql.s_existe_comuna(dr(3)) Then
                                mlngCodComuna = dr(3)
                            Else
                                mlngCodComuna = 132101
                                mstrMensaje = "No existe código de la comuna para el correlativo: " & dr(9) & " se carga por defecto comuna de Santiago"
                                mblnEnvioCorreo = False
                                EnvioErrores(mstrMensaje)
                                'blnErrores = False
                                'Exit Function
                            End If
                        Else
                            mlngCodComuna = 132101
                            mstrMensaje = "El código de la comuna no existe para el correlativo: " & dr(9) & " se carga por defecto comuna de Santiago"
                            mblnEnvioCorreo = False
                            EnvioErrores(mstrMensaje)
                            ' blnErrores = False
                            'Exit Function
                        End If

                        If Not IsDBNull(dr(10)) Then
                            mstrNombreCurso = dr(10)
                        Else
                            mstrMensaje = "El nombre del curso no existe para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(11)) Then
                            mstrEjecutor = dr(11)
                        Else
                            mstrMensaje = "El nombre del ejecutor del curso no existe para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(4)) Then
                            If IsNumeric(dr(4)) Then
                                If Not mobjCsql.Existe_correlativo_empresa_interno(Me.mlngRutEmpresa, dr(4), Me.mstrCorrelEmpresa) Then
                                    If dr(4) > 1900 And dr(4) < 3000 Then
                                        mintAgno = dr(4)
                                    Else
                                        mstrMensaje = "El correlativo " & dr(9) & " el año esta en rangos incorrectos. "
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El correlativo " & dr(9) & " ya se ha ingresado este año. "
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If

                            Else
                                mstrMensaje = "El año del curso no contiene un valor numerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del año para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(1)) Then
                            If IsNumeric(dr(1)) Then
                                If dr(1) > 0 And dr(1) < 2147483647 Then

                                    mintCantParticipantes = dr(1)
                                Else
                                    mstrMensaje = "El número de paticipantes no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(2)) Then
                            mstrDireccion = dr(2)
                        Else
                            mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(6)) Then
                            If IsDate(dr(6)) Then
                                If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaInicio = dr(6)
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de inicio del curso no tiene formato correcto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If

                        If Not IsDBNull(dr(7)) Then
                            If CDate(dr(7)) > CDate(dr(6)) Then
                                If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaFin = dr(7)
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(8)) Then
                            If IsNumeric(dr(8)) Then
                                If dr(8) >= 0 And dr(8) < 2147483647 Then
                                    mdblCostoCurso = dr(8)
                                Else
                                    mstrMensaje = "El costo del curso es menor a cero para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        If Not IsDBNull(dr(5)) Then
                            mstrObservacion = Trim(dr(5))
                        Else
                            mstrObservacion = ""
                        End If
                        If Not IsDBNull(dr(12)) Then
                            mstrHorario = Trim(dr(12))
                        Else
                            mstrHorario = ""
                        End If
                        If Not IsDBNull(dr(13)) Then
                            If IsNumeric(dr(13)) Then
                                If dr(13) >= 0 And dr(13) <= 3000 Then
                                    mintHoras = Trim(dr(13))
                                Else
                                    mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "Faltan las horas para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        '''''''''''''''''''''''''HASTA ACA'''''''''''''''''''''''''''''''''''''
                        mobjCsql.InicioTransaccion()
                        GrabarDatosII()
                        '***********************************************************************************
                        '******************************DATOS PARTICIPANTES**********************************
                        '***********************************************************************************
                        mlngNumAlumnos = 0
                        dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Alumnos$]")
                        If Not dtTemporalIII Is Nothing Then
                            If dtTemporalIII.Columns.Count < 5 Then
                                mstrMensaje = "A los participantes del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "Los participantes del curso tiene errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            Exit Function
                        End If
                        For Each drIII In dtTemporalIII.Rows
                            If Not dtTemporalIII Is Nothing Then
                                If dr(9) = drIII(13) And dr(23) = drIII(14) Then
                                    If Not Trim(drIII(0)) = "" Then
                                        If EsRut(drIII(0)) Then
                                            mlngRutEmpleado = RutUsrALng(drIII(0))
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function

                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin rut, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(1)) Then
                                        mstrNombres = drIII(1)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin nombre, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(2)) Then
                                        mstrApePaterno = drIII(2)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(3)) Then
                                        mstrApeMaterno = drIII(3)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido materno, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(4)) Then
                                        If drIII(4) = "M" Or drIII(4) = "F" Then
                                            mstrSexo = drIII(4)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(5)) Then
                                        If IsNumeric(drIII(5)) Then
                                            If drIII(5) >= 1 And drIII(5) <= 15 Then
                                                mintCodRegionPartic = drIII(5)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código de región, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(7)) Then
                                        If IsNumeric(drIII(7)) Then
                                            If drIII(7) >= 0 And drIII(7) <= 100 Then
                                                mdblFranquicia = drIII(7)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin franquicia, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(6)) Then
                                        If IsNumeric(drIII(6)) Then
                                            If drIII(6) = 0 Then
                                                Select Case mdblFranquicia
                                                    Case 100
                                                        mintCodOcupacional = 4
                                                    Case 50
                                                        mintCodOcupacional = 3
                                                    Case 15
                                                        mintCodOcupacional = 1
                                                End Select
                                            Else
                                                If drIII(6) >= 1 And drIII(6) <= 7 Then
                                                    mintCodOcupacional = drIII(6)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(8)) Then
                                        If IsNumeric(drIII(8)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngViatico = drIII(8)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera del rango, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngViatico = 0
                                    End If
                                    If Not IsDBNull(drIII(9)) Then
                                        If IsNumeric(drIII(9)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngTraslado = drIII(9)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera del rango, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mlngTraslado = 0
                                    End If
                                    If Not IsDBNull(drIII(10)) Then
                                        If IsNumeric(drIII(10)) Then
                                            If drIII(10) = 0 Then
                                                mintCodEscolaridad = 5
                                            Else
                                                If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                    mintCodEscolaridad = drIII(10)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If

                                    If Not IsDBNull(drIII(11)) Then
                                        If IsDate(drIII(11)) Then
                                            If CDate(drIII(11)) < CDate(FechaVbAUsr(Now)) Then
                                                mdtmFechaNacimiento = CDate(drIII(11))
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato incorrecto, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    If Not IsDBNull(drIII(12)) Then
                                        If mobjCsql.s_existe_comuna(drIII(12)) Then
                                            mintCodComunaPartic = drIII(12)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de comuna inexistente, correlativo : " & mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de comuna, correlativo : " & mstrCorrelEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        Exit Function
                                    End If
                                    mlngNumAlumnos = mlngNumAlumnos + 1
                                    GrabarAlumnosII()
                                End If
                            Else
                                mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                blnErrores = False
                                Exit Function
                            End If

                        Next
                        If mlngNumAlumnos = 0 Then
                            mstrMensaje = "No existen alumnos para el curso" & mstrCorrelEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            Exit Function
                        End If
                        Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
                                                    "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                                    & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                    1, Me.mlngCodCursoIngresado)
                        mobjCsql.FinTransaccion()
                        mstrMensaje = "Se ingreso correctamente el curso, correlativo : " & Me.mstrCorrelEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & mstrRutEmpresa
                        mblnEnvioCorreo = False
                        EnvioErrores(mstrMensaje)
                    End If
                End If
            Next
            blnErrores = True
            mblnEnvioCorreo = True
            mstrMensaje = ""
            EnvioErrores(mstrMensaje)
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            EnviaError("CCargaCursosXls:cargar_archivos-->" & ex.Message)
        End Try
    End Function
#End Region

    
    Public Function Cargar_Archivo3(ByVal strRuta As String)
        Try

            mobjSql = New CSql
            Dim dtTemporal, dtTemporalII, dtTemporalIII, dtTemporalIV As DataTable
            Dim dr, drII, drIII, drIV As DataRow


            mobjSqlExcel.MotorDb = "excel8"
            mobjSqlExcel.BD = strRuta

            dtTemporal = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Hoja1$]")
            If Not dtTemporal Is Nothing Then
                If dtTemporal.Columns.Count < 25 Then
                    mstrMensaje = "A la cabecera del curso le faltan columnas obligatorias"
                    mblnEnvioCorreo = True
                    EnvioErrores(mstrMensaje)
                    blnErrores = False
                    Exit Function
                End If
            Else
                mstrMensaje = "La cabecera del curso tiene errores"
                mblnEnvioCorreo = True
                EnvioErrores(mstrMensaje)
                blnErrores = False
                Exit Function
            End If


            For Each dr In dtTemporal.Rows
                If Not IsDBNull(dr(23)) Then
                    If EsRut(dr(23)) Then
                        If mobjCsql.s_existe_persona_juridica(RutUsrALng(dr(23))) Then
                            mlngRutEmpresa = RutUsrALng(dr(23))
                        Else
                            mstrMensaje = "El rut de la empresa no existe en el sistema"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "El rut de la empresa no existe en el sistema")
                            GoTo salir
                        End If

                    Else
                        mstrMensaje = "El rut es erroneo"
                        mblnEnvioCorreo = True
                        EnvioErrores(mstrMensaje)
                        blnErrores = False
                        AgregaLog(dr(9), "rechazado", "El rut es erroneo")
                        GoTo salir
                        ' Exit Function
                    End If
                Else
                    mstrMensaje = "Falta el rut de la empresa"
                    mblnEnvioCorreo = True
                    EnvioErrores(mstrMensaje)
                    blnErrores = False
                    AgregaLog(dr(9), "rechazado", "Falta el rut de la empresa")
                    GoTo salir
                    'Exit Function
                End If
                'mlngRutEmpresa=
                'si tipo de curso es Sence = 1 se efectua el ingreso
                If Not IsDBNull(dr(0)) Then
                    If Trim(dr(0)).ToUpper = "SENCE" Then
                        If Not IsDBNull(dr(9)) Then
                            'If mobjCsql.s_existe_correlativo_emp(dr(9)) Then
                            '    mstrMensaje = "ya se ingresó el curso"
                            '    mblnEnvioCorreo = True
                            '    EnvioErrores(mstrMensaje)
                            '    blnErrores = False
                            '    AgregaLog(dr(9), "rechazado", "ya se ingresó el curso")
                            '    GoTo salir
                            'Else
                            '    mlngCorrelativoEmpresa = dr(9)
                            'End If
                            If Not mobjCsql.Existe_correlativo_empresa(Me.mlngRutEmpresa, dr(9)) Then
                                mlngCorrelativoEmpresa = dr(9)
                            Else
                                mstrMensaje = "ya se ingresó el curso"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "rechazado", "ya se ingresó el curso")
                                GoTo salir
                            End If
                        Else
                            mstrMensaje = "No existe correlativo empresa"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existe correlativo empresa")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(14)) Then
                            If Trim(dr(14)).ToUpper = "NORMAL" Or Trim(dr(14)).ToUpper = "PRECONTRATO" Or Trim(dr(14)).ToUpper = "POSCONTRATO" Then
                                If Trim(dr(14)).ToUpper = "NORMAL" Then
                                    mintCodTipoActividad = 1
                                End If
                                If Trim(dr(14)).ToUpper = "PRECONTRATO" Then
                                    mintCodTipoActividad = 2
                                End If
                                If Trim(dr(14)).ToUpper = "POSCONTRATO" Then
                                    mintCodTipoActividad = 3
                                End If
                            Else
                                mstrMensaje = "No existe el tipo de actividad para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "rechazado", "No existe el tipo de actividad")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el código de actividad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existe el código de actividad")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(15)) Then
                            If Trim(dr(15)).ToUpper = "SI" Or Trim(dr(15)).ToUpper = "NO" Then
                                mbolComBipartito = IIf(Trim(dr(15)).ToUpper = "SI", True, False)
                            Else
                                mstrMensaje = "No existe información del comité bipartito para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "rechazado", "No existe información del comité bipartito")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del comité bipartito para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existe información del comité bipartito")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(16)) Then
                            If Trim(dr(16)).ToUpper = "SI" Or Trim(dr(16)).ToUpper = "NO" Then
                                Me.mbolDetecNecesidades = IIf(Trim(dr(16)).ToUpper = "SI", True, False)
                            Else
                                mstrMensaje = "No existe información de la detección de necesidades  para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "rechazado", "No existe información de la detección de necesidades")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información de la detección de necesidades para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existe información de la detección de necesidades")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(1)) Then
                            If IsNumeric(dr(1)) Then
                                If dr(1) > 0 And dr(1) < 2147483647 Then
                                    mintCantParticipantes = dr(1)
                                Else
                                    mstrMensaje = "El número de paticipantes no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "El número de paticipantes no es un valor númerico")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "rechazado", "No existe el número de paticipantes")
                                GoTo salir
                            End If
                        Else
                            mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existe el número de paticipantes")
                            GoTo salir
                            'Exit Function
                        End If

                        If Not IsDBNull(dr(2)) Then
                            mstrLugarEjecucion = dr(2)
                        Else
                            mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existe la dirección ")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(17)) Then
                            mstrNumDireccion = dr(17)
                        Else
                            mstrNumDireccion = ""
                        End If
                        If Not IsDBNull(dr(18)) Then
                            mstrCiudad = dr(18)
                        Else
                            mstrMensaje = "No existe la ciudad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existe la ciudad")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(3)) Then
                            If IsNumeric(dr(3)) Then
                                If mobjCsql.s_existe_comuna(dr(3)) Then
                                    mlngCodComuna = dr(3)
                                Else
                                    mlngCodComuna = 132101
                                    mstrMensaje = "No existe código de la comuna para el correlativo: " & dr(9) & " se carga por defecto Santiago"
                                    mblnEnvioCorreo = False
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False

                                    'GoTo salir
                                    'Exit Function
                                End If
                            Else
                                Dim dt As DataTable
                                dt = mobjCsql.s_existe_comuna_por_nombre(dr(3))
                                If mobjCsql.Registros > 0 Then
                                    mlngCodComuna = dt.Rows(0)(0)
                                Else
                                    mlngCodComuna = 132101
                                    mstrMensaje = "No existe código de la comuna para el correlativo: " & dr(9) & " se carga por defecto Santiago"
                                    mblnEnvioCorreo = False
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "No existe código de la comuna")
                                    'GoTo salir
                                End If
                            End If
                        Else
                            mlngCodComuna = 132101
                            mstrMensaje = "El código de la comuna no existe para el correlativo: " & dr(9) & " se carga por defecto Santiago"
                            mblnEnvioCorreo = False
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "El código de la comuna no existe")
                            'GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(4)) Then
                            If IsNumeric(dr(4)) Then
                                If dr(4) > 1990 And dr(4) < 3000 Then
                                    mintAnoInicio = dr(4)
                                Else
                                    mstrMensaje = "El año de inicio no contiene un valor numerico valido para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "El año de inicio no contiene un valor numerico valido")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "El año de inicio no contiene un valor numerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "El año de inicio no contiene un valor numerico")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del año de inicio para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No existe información del año de inicio")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(5)) Then
                            mstrObservacion = dr(5)
                        Else
                            mstrObservacion = ""
                        End If
                        If Not IsDBNull(dr(19)) Then
                            If Trim(dr(19)).ToUpper = "PRESENCIAL" Or Trim(dr(19)).ToUpper = "E-LEARNING" Or Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Then
                                If Trim(dr(19)).ToUpper = "PRESENCIAL" Then
                                    mintCodModalidad = 1
                                End If
                                If Trim(dr(19)).ToUpper = "E-LEARNING" Then
                                    mintCodModalidad = 2
                                End If
                                If Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Then
                                    mintCodModalidad = 3
                                End If
                            Else
                                mstrMensaje = "La modalidad no esta reconocida para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "La modalidad no esta reconocida")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No hay modalidad para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No hay modalidad")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(20)) Then
                            mstrCodSence = dr(20)
                            'If Not mobjSql.s_existe_CursosSence(mstrCodSence) Then
                            '    If Not IsDBNull(dr(25)) Then
                            '        mlngRutOtec2 = mobjSql.s_OtecTodos(RutUsrALng(dr(25)))
                            '        If mobjSql.Registros > 0 Then
                            '            mobjSql.i_cursos(dr(20), dr(10), mlngRutOtec2, "...", "...", 50, 0, 1000, "...", "...", "...", 132101, 1, 10)
                            '        End If
                            '    Else
                            '        mstrMensaje = "No existe el rut otec para el correlativo: " & dr(9)
                            '        mblnEnvioCorreo = True
                            '        EnvioErrores(mstrMensaje)
                            '        blnErrores = False
                            '        Exit Function
                            '    End If
                            'End If
                            If Not CargaDatosCurso(mstrCodSence) Then
                                mstrMensaje = "No existe el codigo sence para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "No existe el codigo sence")
                                GoTo salir
                            End If
                        Else
                            mstrMensaje = "No se ha incluido el código sence del curso para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No se ha incluido el código sence del curso")
                            GoTo salir
                            'Exit Function
                        End If
                        mdtDatosCursoSence = mobjCsql.s_datos_curso2(mstrCodSence)
                        If Not IsNothing(mdtDatosCursoSence) Then

                            If mdtDatosCursoSence.Rows.Count > 0 Then
                                Me.mintHrsSence = mdtDatosCursoSence.Rows(0).Item("horas_sence")
                                Me.mlngRutOtec = mdtDatosCursoSence.Rows(0).Item("rut_otec")
                            Else
                                'GoTo salir
                                mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "NNo existe el código sence del curso")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No existe el código sence del curso")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(6)) Then
                            If IsDate(dr(6)) Then
                                'If CDate(dr(6)) > CDate(FechaVbAUsr(Now)) Then
                                'If Not Year(CDate(dr(6))) > Year(Now) + 1 Then
                                If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaInicio = dr(6)
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta fuera de los parametros del sistema correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "La fecha de inicio del curso esta fuera de los parametros del sistema")
                                    GoTo salir
                                    'Exit Function
                                End If
                                'Else
                                '    mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                '    mblnEnvioCorreo = True
                                '    EnvioErrores(mstrMensaje)
                                '    blnErrores = False
                                '    Exit Function
                                'End If
                                'Else
                                '    mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                '    mblnEnvioCorreo = True
                                '    EnvioErrores(mstrMensaje)
                                '    blnErrores = False
                                '    Exit Function
                                'End If
                            Else
                                mstrMensaje = "La fecha de inicio del curso tiene formato incorrecto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "La fecha de inicio del curso tiene formato incorrecto")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "La fecha de inicio del curso esta vacia")
                            GoTo salir
                            ' Exit Function
                        End If
                        If Not IsDBNull(dr(7)) Then
                            If IsDate(dr(7)) Then
                                'If CDate(dr(7)) > CDate(dr(6)) Then
                                'If Not Year(CDate(dr(7))) > Year(Now) + 1 Then
                                If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaFin = dr(7)
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta fuera de los parametrso del sistema en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "La fecha de fin del curso esta fuera de los parametrso del sistema")
                                    GoTo salir
                                    'Exit Function
                                End If
                                'Else
                                '    mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                '    mblnEnvioCorreo = True
                                '    EnvioErrores(mstrMensaje)
                                '    blnErrores = False
                                '    Exit Function
                                'End If
                                'Else
                                '    mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                '    mblnEnvioCorreo = True
                                '    EnvioErrores(mstrMensaje)
                                '    blnErrores = False
                                '    Exit Function
                                'End If
                            Else
                                mstrMensaje = "La fecha de fin del curso no tiene el formato correcto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "La fecha de fin del curso no tiene el formato correcto")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "La fecha de fin del curso esta vacia")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(21)) Then
                            If IsNumeric(dr(21)) Then
                                If dr(21) < 100000 Then
                                    mintHrsComplementarias = dr(21)
                                Else
                                    mstrMensaje = "El valor de las horas sobrepasa lo permitido por el sistema en el correlativo : " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "El valor de las horas sobrepasa lo permitido por el sistema")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "El valor de las horas complementarias debe ser numerico en el correlativo : " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "el valor de las horas complementarias debe ser numerico")
                                GoTo salir
                                'Exit Function

                            End If
                        Else
                            mintHrsComplementarias = 0
                        End If
                        'If Me.mintHrsSence < Me.mintHrsComplementarias Then
                        '    blnErrores = True
                        '    mstrMensaje = "El valor de las horas complementarias no debe ser mayor total de las horas del curso en el correlativo : " & dr(9)
                        '    mblnEnvioCorreo = False
                        '    EnvioErrores(mstrMensaje)
                        '    GoTo salir
                        'End If
                        If Not IsDBNull(dr(8)) Then
                            If IsNumeric(dr(8)) Then
                                If dr(8) > 0 And dr(8) < 2147483647 Then
                                    mlngTotal = dr(8)
                                Else
                                    mstrMensaje = "El valor total del curso debe ser mayor a cero en el correlativo : " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "El valor total del curso debe ser mayor a cero")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "El valor total del curso debe ser un valor numerico en el correlativo : " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "NEl valor total del curso debe ser un valor numerico")
                                GoTo salir
                                ' Exit Function
                            End If
                        Else
                            mstrMensaje = "El valor total del curso no existe en el correlativo : " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "El valor total del curso no existe")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(22)) Then
                            mstrContactoAdicional = dr(22)
                        Else
                            mstrContactoAdicional = ""
                        End If
                        If Not IsDBNull(dr(24)) Then
                            mintOrigen = dr(24)
                        Else
                            mintOrigen = 0
                        End If
                        If Not IsDBNull(dr(13)) Then
                            If IsNumeric(dr(13)) Then
                                If dr(13) >= 0 And dr(13) <= 3000 Then
                                    mintHoras = Trim(dr(13))
                                Else
                                    mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "Las horas deben ser numérica")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "Las horas deben ser numérica")
                                ' Exit Function
                                GoTo salir
                            End If
                        Else
                            mstrMensaje = "Faltan las horas para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "Faltan las horas")
                            'Exit Function
                            GoTo salir
                        End If
                        'If Me.mintHrsSence < Me.mintHoras Then
                        '    blnErrores = True
                        '    mstrMensaje = "El valor de las horas complementarias no debe ser mayor total de las horas del curso en el correlativo : " & dr(9)
                        '    mblnEnvioCorreo = False
                        '    EnvioErrores(mstrMensaje)
                        '    AgregaLog(dr(9), "Rechazado", "El valor de las horas complementarias no debe ser mayor total de las horas")
                        '    GoTo salir
                        'End If
                        If Not IsDBNull(dr(11)) Then
                            mstrEjecutor = dr(11)
                        Else
                            mstrMensaje = "El nombre del ejecutor del curso no existe para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "El nombre del ejecutor del curso no existe")
                            ' Exit Function
                            GoTo salir
                        End If
                        mdblPorcAdm = mobjCsql.s_porcentaje_administracion(Me.mlngRutEmpresa)
                        If Not mobjCsql.s_existe_persona(RutUsrALng(dr(23))) Then
                            GoTo salir

                        End If
                        If Not IsDBNull(dr(27)) Then
                            If IsNumeric(dr(27)) Then
                                Me.mlngNroRegistro = dr(27)
                            Else
                                mstrMensaje = "El numero de registro no es valido para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "El numero de registro no es valido")
                                ' Exit Function
                                GoTo salir
                            End If
                        Else
                            mstrMensaje = "no tiene el numero de registro el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "no tiene el numero de registro")
                            ' Exit Function
                            GoTo salir
                        End If
                        mobjCsql.InicioTransaccion()
                        If Not IsDBNull(dr(26)) Then
                            mstrClaseDeCurso = dr(26)
                            'If Not mobjCsql.s_existe_persona(Me.mlngRutEmpresa) Then

                            '    'mobjCsql.i_Persona(Me.mlngRutEmpresa, digito_verificador(Me.mlngRutEmpresa), "J")
                            'End If
                            'If Not mobjCsql.s_existe_persona_juridica(Me.mlngRutEmpresa) Then
                            '    mobjCsql.i_Persona_Juridica(Me.mlngRutEmpresa,
                            'End If
                            If Not mobjCsql.s_existe_empresa_cliente(Me.mlngRutEmpresa) Then
                                mobjCsql.i_Empresa_Cliente(Me.mlngRutEmpresa, 0, 1, 3, -1, "", "", "", "", "", "", -1, "", "", -1, "", "", "", "", "", "", 1, 1, 1, "", "", "", "", -1, "", "", "", 0, "")
                            End If
                            If Not mobjCsql.s_existe_usuario(Me.mlngRutEmpresa) Then
                                Dim dt As DataTable
                                dt = mobjCsql.s_persona_juridica3(Me.mlngRutEmpresa)
                                If Not IsNothing(dt) Then
                                    If dt.Rows.Count > 0 Then
                                        Me.mstrNombreEmpresa = dt.Rows(0).Item("razon_social")
                                    Else
                                        mstrMensaje = "No existe la empresa para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "No existe información del comité bipartito")
                                        ' Exit Function
                                        GoTo salir
                                    End If
                                Else
                                    mstrMensaje = "No existe la empresa para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "No existe la empresa")
                                    'Exit Function
                                    GoTo salir
                                End If
                                mobjCsql.i_usuario(Me.mlngRutEmpresa, Me.mstrEjecutor, "4C", "pruebas@soleduc.cl", "...", "...")
                            End If
                            If mstrClaseDeCurso.ToUpper = "C" Then
                                mintHrsComplementarias = mintHoras
                                Me.mintHrsParciales = Me.mintHrsSence - Me.mintHrsComplementarias
                                Me.mlngCorrelativoEmpresa = Me.mlngCorrelativoEmpresa
                                ' Me.mintAnoInicio = Me.mintAnoInicio - 1
                                GrabarDatosAdmComp()
                            ElseIf mstrClaseDeCurso.ToUpper = "P" Then
                                mintHrsComplementarias = mintHrsSence - mintHoras
                                GrabarDatosAdmParc()
                            Else
                                GrabarDatosAdm()
                            End If
                        Else
                            mstrMensaje = "No posee el tipo de clase del curso : " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No posee el tipo de clase del curso")
                            GoTo salir
                            'Exit Function
                        End If

                        '***********************************************************************************
                        '********************************DATOS HORARIO**************************************
                        '***********************************************************************************
                        'dtTemporalII = mobjSqlExcel.s_carga_hoja_excel("[Horario$]")
                        'If Not dtTemporalII Is Nothing Then
                        '    If dtTemporalII.Columns.Count < 5 Then
                        '        mstrMensaje = "A horario del curso le faltan columnas obligatorias"
                        '        mblnEnvioCorreo = True
                        '        EnvioErrores(mstrMensaje)
                        '        blnErrores = False
                        '        Exit Function
                        '    End If
                        'Else
                        '    mstrMensaje = "El horario del curso tiene errores"
                        '    mblnEnvioCorreo = True
                        '    EnvioErrores(mstrMensaje)
                        '    blnErrores = False
                        '    Exit Function
                        'End If
                        'For Each drII In dtTemporalII.Rows
                        '    If dr(9) = drII(3) And dr(23) = drII(4) Then
                        '        If Not IsDBNull(drII(0)) Then
                        '            If IsNumeric(drII(0)) Then
                        '                If drII(0) >= 1 And drII(0) <= 7 Then
                        '                    mintDia = drII(0)
                        '                Else
                        '                    mstrMensaje = "El horario tiene valores que estan fuera del rango numerico en el campo dia, correlativo : " & mlngCorrelativoEmpresa
                        '                    mblnEnvioCorreo = True
                        '                    EnvioErrores(mstrMensaje)
                        '                    blnErrores = False
                        '                    Exit Function
                        '                End If
                        '            Else
                        '                mstrMensaje = "El horario tiene valor que no son numericos en el campo dia, correlativo : " & mlngCorrelativoEmpresa
                        '                mblnEnvioCorreo = True
                        '                EnvioErrores(mstrMensaje)
                        '                blnErrores = False
                        '                Exit Function
                        '            End If
                        '        Else
                        '            mstrMensaje = "El horario tiene valores vacios en el campo dia, correlativo : " & mlngCorrelativoEmpresa
                        '            mblnEnvioCorreo = True
                        '            EnvioErrores(mstrMensaje)
                        '            blnErrores = False
                        '            Exit Function
                        '        End If
                        '        If Not IsDBNull(drII(1)) And Not IsDBNull(drII(2)) Then
                        '            If ValidaHoras(CStr(drII(1)), CStr(drII(2))) Then
                        '                mstrHoraInicio = drII(1)
                        '                mstrHoraFin = drII(2)
                        '            Else
                        '                mstrMensaje = "En el horario la hora de incio no puede ser mayor a la hora de fin, correlativo : " & mlngCorrelativoEmpresa
                        '                mblnEnvioCorreo = True
                        '                EnvioErrores(mstrMensaje)
                        '                blnErrores = False
                        '                Exit Function
                        '            End If
                        '        Else
                        '            mstrMensaje = "En el horario la hora de incio no puede ser mayor a la hora de fin, correlativo : " & mlngCorrelativoEmpresa
                        '            mblnEnvioCorreo = True
                        '            EnvioErrores(mstrMensaje)
                        '            blnErrores = False
                        '            Exit Function
                        '        End If
                        'GrabarHorario()
                        '    End If
                        'Next
                        '***********************************************************************************
                        '******************************DATOS PARTICIPANTES**********************************
                        '***********************************************************************************
                        mlngNumAlumnos = 0
                        dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_union("[Hoja2$]", "[Hoja3$]", "[Hoja4$]", Trim(dr(9)))

                        If dtTemporalIII.Columns.Count < 15 Then
                            mstrMensaje = "Faltan datos de participantes para este curso correlativo: " & mlngCorrelativoEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "Faltan datos de participantes para este curso")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not dtTemporalIII Is Nothing Then
                            For Each drIII In dtTemporalIII.Rows
                                If Not Trim(drIII(0)) = "" Then
                                    If EsRut(drIII(0)) Then
                                        mlngRutEmpleado = RutUsrALng(drIII(0))
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con rut inválido")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin rut, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin rut")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(1)) Then
                                    mstrNombres = drIII(1)
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin nombre, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "os participantes del curso existen personas sin nombre")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(2)) Then
                                    mstrApePaterno = drIII(2)
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin apellido paterno")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(3)) Then
                                    mstrApeMaterno = drIII(3)
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin apellido materno, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "En los participantes del curso existen personas sin apellido materno")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(4)) Then
                                    If drIII(4) = "M" Or drIII(4) = "F" Then
                                        mstrSexo = drIII(4)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino)")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin la información del sexo")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(5)) Then
                                    If IsNumeric(drIII(5)) Then
                                        If drIII(5) >= 1 And drIII(5) <= 15 Then
                                            mintCodRegionPartic = drIII(5)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con el código de región fuera del rango (1 al 15)")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de región, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin código de región")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con el código de región como valor no numerico")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(7)) Then
                                    If IsNumeric(drIII(7)) Then
                                        If drIII(7) >= 0 And drIII(7) <= 100 Then
                                            mdblFranquicia = drIII(7)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100)")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con franquicia no numerica")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin franquicia, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin franquicia")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(6)) Then
                                    If IsNumeric(drIII(6)) Then
                                        If drIII(6) = 0 Then
                                            Select Case mdblFranquicia
                                                Case 100
                                                    mintCodOcupacional = 4
                                                Case 50
                                                    mintCodOcupacional = 3
                                                Case 15
                                                    mintCodOcupacional = 1
                                            End Select
                                        Else
                                            If drIII(6) >= 1 And drIII(6) <= 7 Then
                                                mintCodOcupacional = drIII(6)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), correlativo : " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7)")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con código ocupacional con valores no numericos")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin código ocupacional")
                                    GoTo salir
                                    'Exit Function
                                End If
                                If Not IsDBNull(drIII(8)) Then
                                    If IsNumeric(drIII(8)) Then
                                        If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                            mlngViatico = drIII(8)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera de los rangos del sistema, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con valor de viáticos fuera de los rangos del sistema")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con valor de viáticos no numerico")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mlngViatico = 0
                                End If
                                If Not IsDBNull(drIII(9)) Then
                                    If IsNumeric(drIII(9)) Then
                                        If drIII(9) >= 0 And drIII(9) < 2147483647 Then
                                            mlngTraslado = drIII(9)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera de los rangos del sistema, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con valor de traslados fuera de los rangos del sistema")
                                            GoTo salir
                                            'Exit Function
                                        End If

                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con valor de traslados no numerico")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mlngTraslado = 0
                                End If
                                If Not IsDBNull(drIII(10)) Then
                                    If IsNumeric(drIII(10)) Then
                                        If drIII(10) = 0 Then
                                            mintCodEscolaridad = 5
                                        Else
                                            If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                mintCodEscolaridad = drIII(10)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), correlativo : " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9)")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "En los participantes del curso existen personas con código de escolaridad con valor no numerico")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin código de escolaridad")
                                    GoTo salir
                                    'Exit Function
                                End If

                                If Not IsDBNull(drIII(11)) Then
                                    If IsDate(drIII(11)) Then
                                        'If CDate(drIII(11)) < CDate(FechaVbAUsr(Now)) Then
                                        'If CDate(drIII(11)) > CDate(FechaMinSistema()) And CDate(drIII(11)) < CDate(FechaMaxSistema()) Then
                                        mdtmFechaNacimiento = CDate(drIII(11))
                                        'Else
                                        'mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mlngCorrelativoEmpresa
                                        'mblnEnvioCorreo = True
                                        'EnvioErrores(mstrMensaje)
                                        'mobjCsql.RollBackTransaccion()
                                        'blnErrores = False
                                        'AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con fecha de nacimiento incorrecta")
                                        'GoTo salir
                                        'Exit Function

                                        ' End If
                                        'Else
                                        '    mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mlngCorrelativoEmpresa
                                        '    mblnEnvioCorreo = True
                                        '    EnvioErrores(mstrMensaje)
                                        '    mobjCsql.RollBackTransaccion()
                                        '    blnErrores = False
                                        '    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con fecha de nacimiento incorrecta")
                                        '    GoTo salir
                                        '    'Exit Function
                                        'End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato erroneo, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con fecha de nacimiento con formato erroneo")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin fecha de nacimiento")
                                    GoTo salir
                                    'Exit Function
                                End If

                                If Not IsDBNull(drIII(12)) Then
                                    If mobjCsql.s_existe_comuna(drIII(12)) Then
                                        mintCodComunaPartic = drIII(12)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con código de comuna inexistente, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas con código de comuna inexistente")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "En los participantes del curso existen personas sin código de comuna, correlativo : " & mlngCorrelativoEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    AgregaLog(dr(9), "rechazado", "los participantes del curso existen personas sin código de comuna")
                                    GoTo salir
                                    'Exit Function
                                End If
                                mlngNumAlumnos = mlngNumAlumnos + 1
                                CalcTotViaticoTrasl()
                                GrabarAlumnos()
                                'If Trim(dr(9)).ToUpper = Trim(drIII(13)).ToUpper And Trim(RutUsrALng(dr(23))).ToUpper = Trim(RutUsrALng(drIII(14))).ToUpper Then

                                'End If

                            Next
                        Else
                            mstrMensaje = "No existen alumnos para el curso " & mlngCorrelativoEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existen alumnos")
                            GoTo salir
                            'Exit Function

                        End If
                        If mlngNumAlumnos = 0 Then
                            mstrMensaje = "No existen alumnos para el curso " & mlngCorrelativoEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existen alumnos")
                            GoTo salir
                            'Exit Function
                        End If
                        Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
                                                    "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                                    & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                    1, Me.mlngCodCursoIngresado)
                        If mstrClaseDeCurso.ToUpper = "C" Then
                            CalcularCostosComp(dtTemporalIII, mstrCodSence)
                            CalcCostoAdm()
                            ModificarDatos()
                            If Not mobjCsql.s_existe_ejecutivo_empresa(Me.mlngRutEmpresa) Then
                                mobjCsql.i_ejecutivo(Me.mlngRutEmpresa, 10565555) 'rut de pamela celis
                            End If
                            If Not mobjCsql.s_existe_cuenta_cliente(Me.mlngRutEmpresa) Then
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 1)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 2)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 3)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 4)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 5)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 6)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 7)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 8)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 9)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 10)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 11)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 12)
                            End If
                            'IngresaTransaccion()
                        Else
                            CalcularCostos(dtTemporalIII, mstrCodSence)
                            CalcCostoAdm()
                            ModificarDatos()
                            If Not mobjCsql.s_existe_ejecutivo_empresa(Me.mlngRutEmpresa) Then
                                mobjCsql.i_ejecutivo(Me.mlngRutEmpresa, 10565555) 'rut de pamela celis
                            End If
                            If Not mobjCsql.s_existe_cuenta_cliente(Me.mlngRutEmpresa) Then
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 1)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 2)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 3)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 4)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 5)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 6)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 7)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 8)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 9)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 10)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 11)
                                mobjCsql.i_CuentaCliente(Me.mlngRutEmpresa, 12)
                            End If
                            'IngresaTransaccion()
                        End If



                        '***********************************************************************************
                        '******************************DATOS CUENTAS**********************************
                        '***********************************************************************************
                        Dim intFilas As Integer
                        dtTemporalIV = mobjSqlExcel.s_carga_hoja_excel("[Hoja5$]", dr(9))
                        intFilas = dtTemporalIV.Rows.Count
                        If Not dtTemporalIV Is Nothing Then
                            If dtTemporalIV.Columns.Count < 4 Then
                                mstrMensaje = "A las Cuentas del curso le faltan columnas obligatorias para el correlativo " & mlngCorrelativoEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                blnErrores = False
                                AgregaLog(dr(9), "rechazado", "A las Cuentas del curso le faltan columnas obligatorias")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "Las cuentas del curso tienen errores para el correlativo " & mlngCorrelativoEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "Las cuentas del curso tienen errores")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not dtTemporalIV Is Nothing Then
                            Dim i As Integer = 0
                            Dim j As Integer = 0
                            mlngValorCuentaOtic = 0
                            mlngValorCuenta = 0
                            Dim strCorrelativoEmp As String = ""
                            strCorrelativoEmp = dr(9)
                            For i = 0 To intFilas - 1
                                Dim salir As Integer = 0
                                If strCorrelativoEmp = dtTemporalIV.Rows(i).Item(0) Then
                                    Do
                                        If Trim(dr(9)) = Trim(dtTemporalIV.Rows(i).Item(0)) And Trim(dr(23)) = Trim(dtTemporalIV.Rows(i).Item(3)) Then
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(0)) Then
                                                mlngCorrelativoEmpresa = dtTemporalIV.Rows(i).Item(0)
                                            Else
                                                mstrMensaje = "El correlativo empresa no se encuenta en la hoja cuentas para el correlativo " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "rechazado", "El correlativo empresa no se encuenta en la hoja cuentas")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(2)) Then
                                                If dtTemporalIV.Rows(i).Item(2) = 1 Or dtTemporalIV.Rows(i).Item(2) = 2 Or dtTemporalIV.Rows(i).Item(2) = 4 _
                                                Or dtTemporalIV.Rows(i).Item(2) = 5 Or dtTemporalIV.Rows(i).Item(2) = 8 Or dtTemporalIV.Rows(i).Item(2) = 9 Then
                                                    mintCodCuenta = dtTemporalIV.Rows(i).Item(2)
                                                Else
                                                    mstrMensaje = "El código de la cuenta no es valido para el correlativo " & mlngCorrelativoEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    AgregaLog(dr(9), "rechazado", "El código de la cuenta no es valido")
                                                    GoTo salir
                                                    'Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "No tiene asignada un código a la cuenta para el correlativo " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "rechazado", "No tiene asignada un código a la cuenta")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(3)) Then
                                                If dtTemporalIV.Rows(i).Item(3) = dr(23) Then
                                                    mlngRutEmpresa = RutUsrALng(dtTemporalIV.Rows(i).Item(3))
                                                Else
                                                    mstrMensaje = "El rut empresa no coinciden para el correlativo " & mlngCorrelativoEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    AgregaLog(dr(9), "rechazado", "El rut empresa no coinciden")
                                                    GoTo salir
                                                    'Exit Function

                                                End If
                                            Else
                                                mstrMensaje = "No se asignó ningún rut empresa en la hoja cuentas para el correlativo " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "rechazado", "No se asignó ningún rut empresa en la hoja cuentas")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                            If Not IsDBNull(dtTemporalIV.Rows(i).Item(1)) Then
                                                If dtTemporalIV.Rows(i).Item(1) > 0 Then
                                                    mlngValorCuenta = dtTemporalIV.Rows(i).Item(1)
                                                    IngresaTransaccionCuentas()
                                                End If
                                            Else
                                                mstrMensaje = "no tiene asignada un valor a la cuenta para el correlativo " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "rechazado", "No tiene asignada un valor a la cuenta")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                            mlngValorCuentaOtic = mlngValorCuentaOtic + mlngValorCuenta
                                        End If
                                        i = i + 1
                                        If Not i = intFilas Then
                                            If strCorrelativoEmp <> dtTemporalIV.Rows(i).Item(j) Then
                                                salir = 1
                                                i = i - 1
                                            End If
                                        Else
                                            salir = 1
                                        End If
                                    Loop While salir = 0
                                    'If Not mlngValorCuentaOtic = mlngCostoOtic Then
                                    '    mstrMensaje = "el valor total de la cuenta debe ser igual al monto otic"
                                    '    mblnEnvioCorreo = True
                                    '    EnvioErrores(mstrMensaje)
                                    '    mobjCsql.RollBackTransaccion()
                                    '    blnErrores = False
                                    '    Exit Function
                                    'End If
                                End If

                            Next
                        Else
                            mstrMensaje = "No existen cuentas  para el correlativo " & mlngCorrelativoEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            AgregaLog(dr(9), "rechazado", "No existen cuentas  para el correlativo")
                            GoTo salir
                            'Exit Function
                        End If

                        mobjCsql.FinTransaccion()
                        blnErrores = True
                        mstrMensaje = "Se ingreso correctamente el curso, correlativo : " & Me.mlngCorrelativoEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & mstrRutEmpresa
                        mblnEnvioCorreo = False
                        EnvioErrores(mstrMensaje)
                        AgregaLog(dr(9), "Aceptado", "Se ingreso correctamente el curso")

                        '*************************************************************************************
                        '*************************************************************************************
                        '******************* CURSO INTERNO ***************************************************
                        '*************************************************************************************
                        '*************************************************************************************
                    ElseIf Trim(dr(0)).ToUpper = "NO SENCE" Then
                        If Not IsDBNull(dr(9)) Then

                            mstrCorrelEmpresa = dr(9)
                        Else
                            mstrMensaje = "No existe correlativo"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No existe correlativo")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(3)) Then
                            If mobjCsql.s_existe_comuna(dr(3)) Then
                                mlngCodComuna = dr(3)
                            Else
                                mlngCodComuna = 132101
                                mstrMensaje = "No existe código de la comuna para el correlativo: " & dr(9) & " se carga por defecto comuna de Santiago"
                                mblnEnvioCorreo = False
                                EnvioErrores(mstrMensaje)
                                'blnErrores = False
                                'Exit Function
                            End If
                        Else
                            mlngCodComuna = 132101
                            mstrMensaje = "El código de la comuna no existe para el correlativo: " & dr(9) & " se carga por defecto comuna de Santiago"
                            mblnEnvioCorreo = False
                            EnvioErrores(mstrMensaje)
                            ' blnErrores = False
                            'Exit Function
                        End If

                        If Not IsDBNull(dr(10)) Then
                            mstrNombreCurso = dr(10)
                        Else
                            mstrMensaje = "El nombre del curso no existe para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "El nombre del curso no existe")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(11)) Then
                            mstrEjecutor = dr(11)
                        Else
                            mstrMensaje = "El nombre del ejecutor del curso no existe para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "El nombre del ejecutor del curso no existe")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(4)) Then
                            If IsNumeric(dr(4)) Then
                                If Not mobjCsql.Existe_correlativo_empresa_interno(Me.mlngRutEmpresa, dr(4), Me.mstrCorrelEmpresa) Then
                                    If dr(4) > 1900 And dr(4) < 3000 Then
                                        mintAgno = dr(4)
                                    Else
                                        mstrMensaje = "El correlativo " & dr(9) & " el año esta en rangos incorrectos. "
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "El año esta en rangos incorrectos.")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El correlativo " & dr(9) & " ya se ha ingresado este año. "
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "El correlativo ya se ha ingresado este año.")
                                    GoTo salir
                                    'Exit Function
                                End If

                            Else
                                mstrMensaje = "El año del curso no contiene un valor numerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "El año del curso no contiene un valor numerico")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe información del año para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No existe información del año")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(1)) Then
                            If IsNumeric(dr(1)) Then
                                If dr(1) > 0 And dr(1) < 2147483647 Then

                                    mintCantParticipantes = dr(1)
                                Else
                                    mstrMensaje = "El número de paticipantes no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "El número de paticipantes no es un valor númerico")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "No existe el número de participantes")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No existe el número de participantes")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(2)) Then
                            mstrDireccion = dr(2)
                        Else
                            mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No existe la dirección")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(6)) Then
                            If IsDate(dr(6)) Then
                                If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                    mdtmFechaInicio = dr(6)
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "La fecha de inicio del curso esta fuera de los rangos")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de inicio del curso no tiene formato correcto en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "La fecha de inicio del curso no tiene formato correcto")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "La fecha de inicio del curso esta vacia")
                            GoTo salir
                            'Exit Function
                        End If

                        If Not IsDBNull(dr(7)) Then
                            'If CDate(dr(7)) > CDate(dr(6)) Then
                            If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                mdtmFechaFin = dr(7)
                            Else
                                mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "La fecha de fin del curso esta fuera de los rangos")
                                GoTo salir
                                'Exit Function
                            End If
                            'Else
                            '    mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                            '    mblnEnvioCorreo = True
                            '    EnvioErrores(mstrMensaje)
                            '    blnErrores = False
                            '    GoTo salir
                            '    'Exit Function
                            'End If
                        Else
                            mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "La fecha de fin del curso esta vacia")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(8)) Then
                            If IsNumeric(dr(8)) Then
                                If dr(8) >= 0 And dr(8) < 2147483647 Then
                                    mdblCostoCurso = dr(8)
                                Else
                                    mstrMensaje = "El costo del curso es menor a cero para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "El costo del curso es menor a cero")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "El costo del curso no es un valor númerico")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "El costo del curso no es un valor númerico")
                            GoTo salir
                            'Exit Function
                        End If
                        If Not IsDBNull(dr(5)) Then
                            mstrObservacion = Trim(dr(5))
                        Else
                            mstrObservacion = ""
                        End If
                        If Not IsDBNull(dr(12)) Then
                            mstrHorario = Trim(dr(12))
                        Else
                            mstrHorario = ""
                        End If
                        If Not IsDBNull(dr(13)) Then
                            If IsNumeric(dr(13)) Then
                                If dr(13) >= 0 And dr(13) <= 3000 Then
                                    mintHoras = Trim(dr(13))
                                Else
                                    mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    AgregaLog(dr(9), "Rechazado", "Las horas deben ser numéricas")
                                    GoTo salir
                                    'Exit Function
                                End If
                            Else
                                mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "Las horas deben ser numéricas")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "Faltan las horas para el correlativo: " & dr(9)
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "Faltan las horas")
                            GoTo salir
                            'Exit Function
                        End If

                        '''''''''''''''''''''''''HASTA ACA'''''''''''''''''''''''''''''''''''''
                        mobjCsql.InicioTransaccion()
                        GrabarDatosII()
                        '***********************************************************************************
                        '******************************DATOS PARTICIPANTES**********************************
                        '***********************************************************************************
                        mlngNumAlumnos = 0
                        dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_union("[Hoja2$]", "[Hoja3$]", "[Hoja4$]", Trim(dr(9)))
                        If Not dtTemporalIII Is Nothing Then
                            If dtTemporalIII.Columns.Count < 5 Then
                                mstrMensaje = "A los participantes del curso le faltan columnas obligatorias"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "A los participantes del curso le faltan columnas obligatorias")
                                GoTo salir
                                'Exit Function
                            End If
                        Else
                            mstrMensaje = "Los participantes del curso tiene errores"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "Los participantes del curso tiene errores")
                            GoTo salir
                            'Exit Function
                        End If
                        For Each drIII In dtTemporalIII.Rows
                            If Not dtTemporalIII Is Nothing Then
                                If dr(9) = drIII(13) And dr(23) = drIII(14) Then
                                    If Not Trim(drIII(0)) = "" Then
                                        If EsRut(drIII(0)) Then
                                            mlngRutEmpleado = RutUsrALng(drIII(0))
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con rut inválido")
                                            GoTo salir
                                            'Exit Function

                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin rut, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin rut")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(1)) Then
                                        mstrNombres = drIII(1)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin nombre, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin nombre")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(2)) Then
                                        mstrApePaterno = drIII(2)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin apellido paterno")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(3)) Then
                                        mstrApeMaterno = drIII(3)
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin apellido materno, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin apellido materno")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(4)) Then
                                        If drIII(4) = "M" Or drIII(4) = "F" Then
                                            mstrSexo = drIII(4)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino)")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin la información del sexo")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(5)) Then
                                        If IsNumeric(drIII(5)) Then
                                            If drIII(5) >= 1 And drIII(5) <= 15 Then
                                                mintCodRegionPartic = drIII(5)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), correlativo : " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con el código de región fuera del rango (1 al 15)")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código de región, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin código de región")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con el código de región como valor no numerico")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(7)) Then
                                        If IsNumeric(drIII(7)) Then
                                            If drIII(7) >= 0 And drIII(7) <= 100 Then
                                                mdblFranquicia = drIII(7)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), correlativo : " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100)")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con franquicia no numerica")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin franquicia, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin franquicia")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(6)) Then
                                        If IsNumeric(drIII(6)) Then
                                            If drIII(6) = 0 Then
                                                Select Case mdblFranquicia
                                                    Case 100
                                                        mintCodOcupacional = 4
                                                    Case 50
                                                        mintCodOcupacional = 3
                                                    Case 15
                                                        mintCodOcupacional = 1
                                                End Select
                                            Else
                                                If drIII(6) >= 1 And drIII(6) <= 7 Then
                                                    mintCodOcupacional = drIII(6)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), correlativo : " & mlngCorrelativoEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7)")
                                                    GoTo salir
                                                    'Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con código ocupacional con valores no numericos")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin código ocupacional")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(8)) Then
                                        If IsNumeric(drIII(8)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngViatico = drIII(8)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera del rango, correlativo : " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con valor de viáticos fuera del rango")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con valor de viáticos no numerico")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mlngViatico = 0
                                    End If
                                    If Not IsDBNull(drIII(9)) Then
                                        If IsNumeric(drIII(9)) Then
                                            If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                mlngTraslado = drIII(9)
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera del rango, correlativo : " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con valor de traslados fuera del rango")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con valor de traslados no numerico")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mlngTraslado = 0
                                    End If
                                    If Not IsDBNull(drIII(10)) Then
                                        If IsNumeric(drIII(10)) Then
                                            If drIII(10) = 0 Then
                                                mintCodEscolaridad = 5
                                            Else
                                                If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                    mintCodEscolaridad = drIII(10)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), correlativo : " & mlngCorrelativoEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9)")
                                                    GoTo salir
                                                    'Exit Function
                                                End If
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con código de escolaridad con valor no numerico")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin código de escolaridad")
                                        GoTo salir
                                        'Exit Function
                                    End If

                                    If Not IsDBNull(drIII(11)) Then
                                        If IsDate(drIII(11)) Then
                                            If CDate(drIII(11)) < CDate(FechaVbAUsr(Now)) Then
                                                mdtmFechaNacimiento = CDate(drIII(11))
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mlngCorrelativoEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                blnErrores = False
                                                AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con fecha de nacimiento incorrecta")
                                                GoTo salir
                                                'Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato incorrecto, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con fecha de nacimiento con formato incorrecto")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin fecha de nacimiento")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    If Not IsDBNull(drIII(12)) Then
                                        If mobjCsql.s_existe_comuna(drIII(12)) Then
                                            mintCodComunaPartic = drIII(12)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con código de comuna inexistente, correlativo : " & mlngCorrelativoEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            blnErrores = False
                                            AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas con código de comuna inexistente")
                                            GoTo salir
                                            'Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "En los participantes del curso existen personas sin código de comuna, correlativo : " & mlngCorrelativoEmpresa
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        mobjCsql.RollBackTransaccion()
                                        blnErrores = False
                                        AgregaLog(dr(9), "Rechazado", "los participantes del curso existen personas sin código de comuna")
                                        GoTo salir
                                        'Exit Function
                                    End If
                                    mlngNumAlumnos = mlngNumAlumnos + 1
                                    GrabarAlumnosII()
                                End If
                            Else
                                mstrMensaje = "No existen alumnos para el curso" & mlngCorrelativoEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                blnErrores = False
                                AgregaLog(dr(9), "Rechazado", "No existen alumnos para el curso")
                                GoTo salir
                                'Exit Function
                            End If

                        Next
                        If mlngNumAlumnos = 0 Then
                            mstrMensaje = "No existen alumnos para el curso" & mlngCorrelativoEmpresa
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            mobjCsql.RollBackTransaccion()
                            blnErrores = False
                            AgregaLog(dr(9), "Rechazado", "No existen alumnos para el curso")
                            GoTo salir
                            'Exit Function
                        End If
                        Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
                                                    "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                                    & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                    1, Me.mlngCodCursoIngresado)
                        mobjCsql.FinTransaccion()
                        mstrMensaje = "Se ingreso correctamente el curso, correlativo : " & Me.mlngCorrelativoEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & mstrRutEmpresa
                        mblnEnvioCorreo = False
                        EnvioErrores(mstrMensaje)
                        AgregaLog(dr(9), "Aceptado", "Se ingreso correctamente el curso")
                    End If
                End If
salir:
            Next
            blnErrores = True
            mblnEnvioCorreo = True
            mstrMensaje = ""
            EnvioErrores(mstrMensaje)

            Dim strNombreArchivo As String = ""
            strNombreArchivo = NombreArchivoTmp()
            Me.mstrXml = DIRFISICOAPP() & "\contenido\tmp\" & strNombreArchivo    'carga la ruta en la propiedad

            mdtLog.TableName = "Reporte "
            mdtLog.WriteXml(Me.mstrXml)                                     'genera el xml en la ruta
            Me.mstrXml = "~/contenido/tmp/" & strNombreArchivo
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            EnviaError("CCargaCursosXls:cargar_archivos-->" & ex.Message)
        End Try
    End Function
    Private Function ValidaHoras(ByVal strHora1, ByVal strHora2) As Boolean
        Try
            Dim arrHora1, arrHora2
            If Trim(strHora1) = Trim(strHora2) Then
                ValidaHoras = False
                Exit Function
            End If
            arrHora1 = Split(strHora1, ":")
            arrHora2 = Split(strHora2, ":")
            If TamanoArreglo1(arrHora1) <> 2 Or TamanoArreglo1(arrHora2) <> 2 Then
                ValidaHoras = False
                Exit Function
            End If
            If CInt(arrHora1(0)) < 0 Or CInt(arrHora1(1)) < 0 Or CInt(arrHora2(0)) < 0 Or CInt(arrHora2(1)) < 0 _
                Or CInt(arrHora1(0)) > 23 Or CInt(arrHora1(1)) > 59 Or CInt(arrHora2(0)) > 23 Or CInt(arrHora2(1)) > 59 Then
                ValidaHoras = False
                Exit Function
            End If
            If (CInt(arrHora1(0)) > CInt(arrHora2(0))) Or (CInt(arrHora1(0)) = CInt(arrHora2(0)) And CInt(arrHora1(1)) > CInt(arrHora2(1))) Then
                ValidaHoras = False
                Exit Function
            End If
            ValidaHoras = True
        Catch ex As Exception
            EnviaError("CServicioOtic:ValidaHoras-->" & ex.Message)
        End Try
    End Function
    Sub inicializar()
        Try
            mstrMensaje = ""
            mlngRutEmpresa = 0
            mintCodTipoActividad = 0
            mbolComBipartito = False
            mbolDetecNecesidades = False
            mintCantParticipantes = 0
            mstrLugarEjecucion = ""
            mstrNumDireccion = ""
            mstrCiudad = ""
            mlngCodComuna = 0
            mintAnoInicio = 0
            mstrObservacion = ""
            mintCodModalidad = 0
            mstrCodSence = 0
            mdtmFechaInicio = FechaMinSistema()
            mdtmFechaFin = FechaMinSistema()
            mintHrsComplementarias = 0
            mlngTotal = 0
            mlngDescuento = 0
            mintCodTipoDescuento = 0
            mlngCorrelEmpresa = 0
            mstrContactoAdicional = ""
            mdblPorcAdm = 0
            mintDia = 0
            mstrHoraInicio = ""
            mstrHoraFin = ""
            mlngRutEmpleado = 0
            mstrNombres = ""
            mstrApePaterno = ""
            mstrApeMaterno = ""
            mstrSexo = ""
            mintCodRegionPartic = 0
            mintCodOcupacional = 0
            mdblFranquicia = 0
            mlngViatico = 0
            mbolFlagFranqViatico = False
            mlngTraslado = 0
            mbolFlagFranqTraslado = False
            mintCodEscolaridad = 0
            mdtmFechaNacimiento = FechaMinSistema()
            mintCodComunaPartic = 0
            mstrCodSenceCurso = ""
            mstrNombreCurso = ""
            mlngRutOtec = 0
            mstrArea = ""
            mstrEspecialidad = ""
            mlngDurCursoTeorico = 0
            mlngDurCursoPractico = 0
            mlngNumMaxParticip = 0
            mstrNombreSede = ""
            mstrFonoSede = ""
            mstrDireccion = ""
            mstrComunaCurso = ""
            mblnPendiente = 0
            mstrComuna = ""
            mdtMensajes = New DataTable
            Me.mdtMensajes.Columns.Add(New DataColumn("log", GetType(String)))
            mstrMensajeParaEmail = ""
            '******************* LOG ********************
            mdtLog = New DataTable
            mdtLog.Columns.Add("correlativo")
            mdtLog.Columns.Add("estado")
            mdtLog.Columns.Add("detalle")
        Catch ex As Exception
            EnviaError("CServicioOtic:inicializar-->" & ex.Message)
        End Try
    End Sub
    Function CargaDatosCurso(ByVal strCodSence As String) As Boolean
        Try
            Dim dt As New System.Data.DataTable
            dt = mobjCsql.s_curso_sence(strCodSence)
            If dt Is Nothing Then
                CargaDatosCurso = False
                Exit Function
            End If
            If dt.Rows.Count = 0 Then
                CargaDatosCurso = False
                Exit Function
            End If
            mstrCodSenceCurso = strCodSence
            mstrNombreCurso = dt.Rows(0).Item(0)
            If IsDBNull(dt.Rows(0).Item(1)) Then
                mlngRutOtec = 0
            Else
                mlngRutOtec = dt.Rows(0).Item(1)
            End If
            mstrArea = dt.Rows(0).Item(2)
            mstrEspecialidad = dt.Rows(0).Item(3)
            mlngDurCursoTeorico = dt.Rows(0).Item(4)
            mlngDurCursoPractico = dt.Rows(0).Item(5)
            mlngNumMaxParticip = dt.Rows(0).Item(6)
            mstrNombreSede = dt.Rows(0).Item(7)
            mstrFonoSede = dt.Rows(0).Item(8)
            mstrDireccion = dt.Rows(0).Item(9)
            mlngCodComuna = dt.Rows(0).Item(10)
            mblnPendiente = dt.Rows(0).Item(11)
            mstrComunaCurso = dt.Rows(0).Item(12)
            CargaDatosCurso = True
        Catch ex As Exception
            EnviaError("CServicioOtic:CargaDatosCurso-->" & ex.Message)
        End Try
    End Function

    Function GrabarDatos() As Boolean
        Try
            Dim dt As DataTable
            mlngCorrelativo = mobjCsql.s_correlativo(Me.mintAnoInicio)
            mobjCsql.i_curso_contr2(Me.mlngRutEmpresa, Me.mintCodTipoActividad, _
                                       Me.mbolComBipartito, Me.mbolDetecNecesidades, _
                                       Me.mintCantParticipantes, Me.mstrLugarEjecucion, _
                                       Me.mlngCodComuna, Me.mstrCodSence, _
                                       Me.mdtmFechaInicio, Me.mdtmFechaFin, _
                                       Me.mintHrsComplementarias, Me.mlngTotal, 0, _
                                       Me.mlngCorrelativo, 0, 1, Me.mintAnoInicio, Me.mdblPorcAdm, _
                                       Me.mlngCostoOtic, Me.mlngCostoAdm, Me.mlngGastoEmpresa, _
                                       Me.mlngCostoOticVYT, Me.mlngCostoAdmVYT, Me.mlngGastoEmpresaVYT, _
                                       Me.mlngTotalViatico, Me.mlngTotalTraslado, _
                                       Me.mstrObservacion, 0, "", Me.mintHrsSence, _
                                       0, FechaMinSistema, 0, 0, Me.mstrCorrelEmpresa, 0, "", "", _
                                       Me.mintCodModalidad, Me.mstrNumDireccion, Me.mstrCiudad)


            'consultas para determinar el código interno del curso ingresado
            dt = mobjCsql.s_cod_curso_contr()
            mlngCodCursoIngresado = dt.Rows(0)(0)

            Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Incompleto", "Ingreso del Encabezado del Curso Contratado. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                1, mlngCodCursoIngresado)
            Return True
        Catch ex As Exception
            EnviaError("CServicioOtic:GrabarDatos-->" & ex.Message)
        End Try
    End Function
    Function GrabarDatosAdm() As Boolean
        Try
            Dim dt As DataTable
            mlngCorrelativo = mobjCsql.s_correlativo(Me.mintAnoInicio)
            mobjCsql.i_curso_contr2Adm(Me.mlngRutEmpresa, Me.mintCodTipoActividad, _
                                       Me.mbolComBipartito, Me.mbolDetecNecesidades, _
                                       Me.mintCantParticipantes, Me.mstrLugarEjecucion, _
                                       Me.mlngCodComuna, Me.mstrCodSence, _
                                       Me.mdtmFechaInicio, Me.mdtmFechaFin, _
                                       Me.mintHrsComplementarias, Me.mlngTotal, 0, _
                                       Me.mlngCorrelativo, Me.mlngNroRegistro, 5, Me.mintAnoInicio, Me.mdblPorcAdm, _
                                       Me.mlngCostoOtic, Me.mlngCostoAdm, Me.mlngGastoEmpresa, _
                                       Me.mlngCostoOticVYT, Me.mlngCostoAdmVYT, Me.mlngGastoEmpresaVYT, _
                                       Me.mlngTotalViatico, Me.mlngTotalTraslado, _
                                       Me.mstrObservacion, 0, "", Me.mintHrsSence, _
                                       0, FechaMinSistema, 0, 0, Me.mstrCorrelEmpresa, 0, "", "", _
                                       Me.mintCodModalidad, Me.mstrNumDireccion, Me.mstrCiudad, Me.mintOrigen)


            'consultas para determinar el código interno del curso ingresado
            dt = mobjCsql.s_cod_curso_contr()
            mlngCodCursoIngresado = dt.Rows(0)(0)

            Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Incompleto", "Ingreso del Encabezado del Curso Contratado. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                1, mlngCodCursoIngresado)
            Return True
        Catch ex As Exception
            EnviaError("CServicioOtic:GrabarDatos-->" & ex.Message)
        End Try
    End Function
    Function GrabarDatosAdmComp() As Boolean
        Try
            Dim dt As DataTable
            mlngCorrelativo = mobjCsql.s_correlativo(Me.mintAnoInicio)

            mobjCsql.i_curso_contr2Adm(Me.mlngRutEmpresa, Me.mintCodTipoActividad, _
                                       Me.mbolComBipartito, Me.mbolDetecNecesidades, _
                                       Me.mintCantParticipantes, Me.mstrLugarEjecucion, _
                                       Me.mlngCodComuna, Me.mstrCodSence, _
                                       Me.mdtmFechaInicio, Me.mdtmFechaFin, _
                                       Me.mintHrsComplementarias, Me.mlngTotal, 0, _
                                       Me.mlngCorrelativo, Me.mlngNroRegistro, 5, Me.mintAnoInicio, Me.mdblPorcAdm, _
                                       Me.mlngCostoOtic, Me.mlngCostoAdm, Me.mlngGastoEmpresa, _
                                       Me.mlngCostoOticVYT, Me.mlngCostoAdmVYT, Me.mlngGastoEmpresaVYT, _
                                       Me.mlngTotalViatico, Me.mlngTotalTraslado, _
                                       Me.mstrObservacion, 0, "", Me.mintHrsSence, _
                                       0, FechaMinSistema, 0, 0, Me.mlngCorrelativoEmpresa, 0, "", "", _
                                       Me.mintCodModalidad, Me.mstrNumDireccion, Me.mstrCiudad, Me.mintOrigen)


            'consultas para determinar el código interno del curso ingresado
            dt = mobjCsql.s_cod_curso_contr()
            mlngCodCursoIngresado = dt.Rows(0)(0)

            Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Incompleto", "Ingreso del Encabezado del Curso Contratado. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                1, mlngCodCursoIngresado)
            Return True
        Catch ex As Exception
            EnviaError("CServicioOtic:GrabarDatos-->" & ex.Message)
        End Try
    End Function
    Function GrabarDatosAdmParc() As Boolean
        Try
            Dim dt As DataTable
            mlngCorrelativo = mobjCsql.s_correlativo(Me.mintAnoInicio)
            mobjCsql.i_curso_contr2Adm(Me.mlngRutEmpresa, Me.mintCodTipoActividad, _
                                       Me.mbolComBipartito, Me.mbolDetecNecesidades, _
                                       Me.mintCantParticipantes, Me.mstrLugarEjecucion, _
                                       Me.mlngCodComuna, Me.mstrCodSence, _
                                       Me.mdtmFechaInicio, Me.mdtmFechaFin, _
                                       Me.mintHrsComplementarias, Me.mlngTotal, 0, _
                                       Me.mlngCorrelativo, Me.mlngNroRegistro, 5, Me.mintAnoInicio, Me.mdblPorcAdm, _
                                       Me.mlngCostoOtic, Me.mlngCostoAdm, Me.mlngGastoEmpresa, _
                                       Me.mlngCostoOticVYT, Me.mlngCostoAdmVYT, Me.mlngGastoEmpresaVYT, _
                                       Me.mlngTotalViatico, Me.mlngTotalTraslado, _
                                       Me.mstrObservacion, 0, "", Me.mintHrsSence, _
                                       0, FechaMinSistema, 0, 0, Me.mstrCorrelEmpresa, 0, "", "", _
                                       Me.mintCodModalidad, Me.mstrNumDireccion, Me.mstrCiudad, Me.mintOrigen)


            'consultas para determinar el código interno del curso ingresado
            dt = mobjCsql.s_cod_curso_contr()
            mlngCodCursoIngresado = dt.Rows(0)(0)

            Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Incompleto", "Ingreso del Encabezado del Curso Contratado. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                1, mlngCodCursoIngresado)
            Return True
        Catch ex As Exception
            EnviaError("CServicioOtic:GrabarDatos-->" & ex.Message)
        End Try
    End Function
    'funcion para grabar el horario del curso
    Function GrabarHorario() As Boolean
        Try
            mobjCsql.i_horario_curso(Me.mlngCodCursoIngresado, Me.mintDia, Me.mstrHoraInicio, Me.mstrHoraFin)
            Return True
        Catch ex As Exception
            EnviaError("CServicioOtic:GrabarHorario-->" & ex.Message)
        End Try
    End Function
    'función para grabar la asistencia de alumnos
    Sub GrabarAlumnos()
        Try
            Dim dtTmp As DataTable
            Dim dig_verif As String
            Dim tipo_pers As String

            mlngTotalViatico = 0
            mlngTotalTraslado = 0

            dtTmp = mobjCsql.s_persona(mlngRutEmpleado)
            'If dtTmp Is Nothing Then
            If Not mobjCsql.Registros > 0 Then
                dig_verif = digito_verificador(mlngRutEmpleado)
                tipo_pers = "N"
                mobjCsql.i_Persona(mlngRutEmpleado, dig_verif, tipo_pers)
            End If
            dtTmp = New DataTable
            dtTmp = mobjCsql.s_pers_nat(mlngRutEmpleado)

            'If Not dtTmp Is Nothing Then
            If mobjCsql.Registros > 0 Then
                Call mobjCsql.u_pers_nat(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                        Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                        Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                        Me.mlngRutEmpresa, Me.mintCodComunaPartic, 1, "", "") ' 1 codigo pais chile
            Else
                Call mobjCsql.i_PersonaNatural(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                        Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                        Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                        Me.mlngRutEmpresa, Me.mintCodComunaPartic, 1, "", "") ' 1 codigo pais chile
            End If
            dtTmp = New DataTable
            dtTmp = mobjCsql.s_partic_curso(Me.mlngCodCursoIngresado, Me.mlngRutEmpleado)
            'If Not dtTmp Is Nothing Then
            If mobjCsql.Registros > 0 Then
                mobjCsql.u_participante(Me.mlngCodCursoIngresado, Me.mlngRutEmpleado, Me.mintCodOcupacional, Me.mintCodRegionPartic, _
                                                            Me.mdblFranquicia, Me.mlngViatico, Me.mlngTraslado, 0, _
                                                            Me.mstrObservacion, Me.mintCodEscolaridad, Me.mintCodComunaPartic)
            Else
                mobjCsql.i_participante(Me.mlngCodCursoIngresado, Me.mlngRutEmpleado, Me.mintCodOcupacional, Me.mintCodRegionPartic, _
                                                          Me.mdblFranquicia, Me.mlngViatico, Me.mlngTraslado, 0, _
                                                          Me.mstrObservacion, Me.mintCodEscolaridad, Me.mintCodComunaPartic)
            End If
            mlngTotalViatico = mlngTotalViatico + Me.mlngViatico
            mlngTotalTraslado = mlngTotalTraslado + Me.mlngTraslado
        Catch ex As Exception
            EnviaError("CServicioOtic:GrabarAlumnos-->" & ex.Message)
        End Try
    End Sub
    Sub ModificarDatos()
        Try
            Dim strEstadoCurso As String
            strEstadoCurso = "Ingresado"


            Call mobjCsql.u_curso_contr(Me.mlngRutEmpresa, Me.mintCodTipoActividad, _
                                       Me.mbolComBipartito, Me.mbolDetecNecesidades, _
                                       Me.mlngNumAlumnos, Me.mstrLugarEjecucion, _
                                       Me.mlngCodComuna, Me.mstrCodSence, _
                                       Me.mdtmFechaInicio, Me.mdtmFechaFin, _
                                       Me.mintHrsComplementarias, Me.mlngTotal, _
                                       0, Me.mlngCorrelativo, Me.mlngNroRegistro, Me.mintAnoInicio, _
                                       mdblPorcAdm, mlngCostoOtic, mlngCostoAdm, mlngGastoEmpresa, _
                                       mlngCostoOticVYT, mlngCostoAdmVYT, _
                                       mlngGastoEmpresaVYT, mlngTotalViatico, mlngTotalTraslado, _
                                       1, "", 0, "", Me.mintHrsSence, 0, _
                                       FechaMinSistema, -1, _
                                       0, Me.mlngCorrelativoEmpresa, FechaMinSistema, FechaMinSistema, _
                                       Me.mlngCodCursoIngresado, Me.mstrContactoAdicional, mstrObservacion, _
                                       Me.mintCodModalidad, _
                                       Me.mstrNumDireccion, Me.mstrCiudad)

        Catch ex As Exception
            EnviaError("CServicioOtic:ModificarDatos-->" & ex.Message)
        End Try
    End Sub
    'procedimiento para calcular el costo otic, empresa,
    'y totales de viáticos y traslados
    Sub CalcularCostos(ByVal dtTemporal As DataTable, Optional ByVal CodSence As String = "")
        Try
            Dim dblTempCostoOtic As Double
            Dim dblTempGastoEmpresa As Double
            Dim dblTempCostoOticVYT As Double
            Dim dblTempGastoEmpresaVYT As Double
            Dim dr As DataRow
            'actualizar el valor de viáticos y traslados
            CalcTotViaticoTrasl()

            'valor de la hora sence
            'mlngValHoraSence = mobjCsql.s_val_hora_sence_agno(Me.mintAnoInicio)
            mlngValHoraSence = mobjCsql.s_valor_curso_sence(CodSence)

            dblTempCostoOtic = 0
            dblTempGastoEmpresa = 0

            'costos por Viatico y traslado
            dblTempCostoOticVYT = 0
            dblTempGastoEmpresaVYT = 0

            'en el cálculo de costos por alumno
            Dim i As Integer

            For Each dr In dtTemporal.Rows
                If Me.mlngCorrelativoEmpresa = dr(13) Then
                    CalcularCostosAl(mlngValHoraSence, dr(7) / 100, _
                                    dr(8), dr(9))
                    ' nodo.Item("nro_participantes").InnerText
                    dblTempCostoOtic = dblTempCostoOtic + mlngCostoOticAlumno
                    dblTempGastoEmpresa = dblTempGastoEmpresa + mlngGastoEmpresaAlumno
                    dblTempCostoOticVYT = dblTempCostoOticVYT + mlngCostoOticAlumnoVYT
                    dblTempGastoEmpresaVYT = dblTempGastoEmpresaVYT + mlngGastoEmpresaVYT
                End If
            Next

            mlngCostoOtic = Math.Round(dblTempCostoOtic)
            mlngGastoEmpresa = Math.Round(dblTempGastoEmpresa)
            mlngCostoOticVYT = dblTempCostoOticVYT
            mlngGastoEmpresaVYT = dblTempGastoEmpresaVYT
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostos-->" & ex.Message)
        End Try
    End Sub
    'procedimiento para calcular el costo otic, empresa,
    'y totales de viáticos y traslados
    Sub CalcularCostosCompl(ByVal dtTemporal As DataTable, ByVal CodSence As String)
        Try
            Dim dblTempCostoOtic As Double
            Dim dblTempGastoEmpresa As Double
            Dim dblTempCostoOticVYT As Double
            Dim dblTempGastoEmpresaVYT As Double
            Dim dr As DataRow
            'actualizar el valor de viáticos y traslados
            CalcTotViaticoTrasl()

            'valor de la hora sence
            'mlngValHoraSence = mobjCsql.s_val_hora_sence_agno(Me.mintAnoInicio)
            mlngValHoraSence = mobjCsql.s_valor_curso_sence(CodSence)
            dblTempCostoOtic = 0
            dblTempGastoEmpresa = 0

            'costos por Viatico y traslado
            dblTempCostoOticVYT = 0
            dblTempGastoEmpresaVYT = 0

            'en el cálculo de costos por alumno
            Dim i As Integer

            For Each dr In dtTemporal.Rows
                If Me.mlngCorrelativoEmpresa = dr(13) Then
                    CalcularCostosAlCompl(mlngValHoraSence, dr(7) / 100, _
                                    dr(8), dr(9))
                    ' nodo.Item("nro_participantes").InnerText
                    dblTempCostoOtic = dblTempCostoOtic + mlngCostoOticAlumno
                    dblTempGastoEmpresa = dblTempGastoEmpresa + mlngGastoEmpresaAlumno
                    dblTempCostoOticVYT = dblTempCostoOticVYT + mlngCostoOticAlumnoVYT
                    dblTempGastoEmpresaVYT = dblTempGastoEmpresaVYT + mlngGastoEmpresaVYT
                End If
            Next

            mlngCostoOtic = Math.Round(dblTempCostoOtic)
            mlngGastoEmpresa = Math.Round(dblTempGastoEmpresa)
            mlngCostoOticVYT = dblTempCostoOticVYT
            mlngGastoEmpresaVYT = dblTempGastoEmpresaVYT
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostos-->" & ex.Message)
        End Try
    End Sub
    'procedimiento para calcular el costo otic, empresa,
    'y totales de viáticos y traslados
    Sub CalcularCostosComp(ByVal dtTemporal As DataTable, Optional ByVal CodSence As String = "")
        Try
            Dim dblTempCostoOtic As Double
            Dim dblTempGastoEmpresa As Double
            Dim dblTempCostoOticVYT As Double
            Dim dblTempGastoEmpresaVYT As Double
            Dim dr As DataRow
            'actualizar el valor de viáticos y traslados
            CalcTotViaticoTrasl()

            'valor de la hora sence
            'mlngValHoraSence = mobjCsql.s_val_hora_sence_agno(Me.mintAnoInicio)
            mlngValHoraSence = mobjCsql.s_valor_curso_sence(CodSence)
            dblTempCostoOtic = 0
            dblTempGastoEmpresa = 0

            'costos por Viatico y traslado
            dblTempCostoOticVYT = 0
            dblTempGastoEmpresaVYT = 0

            'en el cálculo de costos por alumno
            Dim i As Integer

            For Each dr In dtTemporal.Rows
                If Me.mlngCorrelativoEmpresa = dr(13) Then
                    CalcularCostosAlCompl(mlngValHoraSence, dr(7) / 100, _
                                    dr(8), dr(9))
                    ' nodo.Item("nro_participantes").InnerText
                    dblTempCostoOtic = dblTempCostoOtic + mlngCostoOticAlumno
                    dblTempGastoEmpresa = dblTempGastoEmpresa + mlngGastoEmpresaAlumno
                    dblTempCostoOticVYT = dblTempCostoOticVYT + mlngCostoOticAlumnoVYT
                    dblTempGastoEmpresaVYT = dblTempGastoEmpresaVYT + mlngGastoEmpresaVYT
                End If
            Next

            mlngCostoOtic = Math.Round(dblTempCostoOtic)
            mlngGastoEmpresa = Math.Round(dblTempGastoEmpresa)
            mlngCostoOticVYT = dblTempCostoOticVYT
            mlngGastoEmpresaVYT = dblTempGastoEmpresaVYT
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostos-->" & ex.Message)
        End Try
    End Sub
    'calcular costos del alumno: otic, empresa
    Sub CalcularCostosAl(ByVal ValHoraSence As Long, ByVal Franquicia As Double, _
                                ByVal Viaticos As Double, ByVal Traslados As Double)
        Try
            'esta función calcula el costo otic del alumno y además devuelve el gasto empresa,
            'que se pasa por referencia
            mlngCostoOticAlumno = CalcularCostoOticAlumno(0, 1, Franquicia, Me.mlngTotal, Me.mintHrsSence)
            mlngCostoOticAlumnoVYT = CalcularCostoOticAlumnoVYT(Me.mintHrsSence, Me.mintHrsComplementarias, Viaticos + Traslados, _
                                                                0, 1, Me.mlngGastoEmpresaAlumnoVYT, Franquicia)
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostosAl-->" & ex.Message)
        End Try
    End Sub
    'calcular costos del alumno: otic, empresa
    Sub CalcularCostosAlCompl(ByVal ValHoraSence As Long, ByVal Franquicia As Double, _
                                ByVal Viaticos As Double, ByVal Traslados As Double)
        Try
            'esta función calcula el costo otic del alumno y además devuelve el gasto empresa,
            'que se pasa por referencia
            mlngCostoOticAlumno = CalcularCostoOticAlumnoCompl(0, 1, Franquicia, Me.mlngTotal, Me.mintHrsSence)
            mlngCostoOticAlumnoVYT = CalcularCostoOticAlumnoVYTCompl(Me.mintHrsSence, Me.mintHrsComplementarias, Viaticos + Traslados, _
                                                                0, 1, Me.mlngGastoEmpresaAlumnoVYT, Franquicia)
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostosAl-->" & ex.Message)
        End Try
    End Sub
    'Función para calcular el costo otic alumno y el gasto empresa,
    'la funcion retorna el costo otic del alumno y el gasto empresa en una variable por referencia
    Function CalcularCostoOticAlumno(ByVal PorcAsistencia As Double, _
                                        ByVal CodEstadoCurso As Integer, _
                                        ByVal Franquicia As Double, ByVal lngValorMercado As Long, ByVal intHoras As Integer) As Double
        Try
            Dim dblMinimo As Double, dblAuxiliar As Double
            Dim dblValHoraCurso As Double, dblValHoraCursoFranquiciable As Double
            Dim lngValRealCurso As Long
            Dim dblValorParticipante As Double
            'curso con complemento: hay que calcular el valor de mercado y descuento,
            'redondeado al número de horas
            If intHoras > 0 Then
                Dim dblFactorHoras As Double
                dblFactorHoras = (intHoras - Me.mintHrsComplementarias) / intHoras
                'dblFactorHoras = Me.mintHrsComplementarias / intHoras
                lngValorMercado = Math.Round(dblFactorHoras * lngValorMercado)

                'considerar las horas correspondientes al año actual
                intHoras = intHoras - Me.mintHrsComplementarias
            End If
            lngValRealCurso = Math.Round(lngValorMercado)
            If intHoras <> 0 And Me.mintCantParticipantes <> 0 Then
                dblValHoraCurso = (lngValRealCurso / intHoras) / Me.mintCantParticipantes
                dblValorParticipante = lngValRealCurso / Me.mintCantParticipantes
            Else
                dblValHoraCurso = -1
                dblValorParticipante = 0
            End If
            Dim intIndAcuComBip As Integer
            If Me.mbolComBipartito Then
                intIndAcuComBip = 1
            Else
                intIndAcuComBip = 0
            End If
            dblAuxiliar = mlngValHoraSence * (1 + (0.2 * intIndAcuComBip))
            If intIndAcuComBip = 1 Then
                'Toma el valor con comite Bº, si se excede del tope por participante se ajusta.
                'El valor hora del curso también es multiplicado por 1.2 (O sea se le suma el 20%)
                If dblAuxiliar <= (dblValHoraCurso * 1.2) Then
                    dblMinimo = dblAuxiliar
                Else
                    dblMinimo = dblValHoraCurso * 1.2
                End If
            Else
                'Si no toma el menor valor, si no es el curso...toma el tope por participante
                If dblAuxiliar <= dblValHoraCurso Then
                    dblMinimo = dblAuxiliar
                Else
                    dblMinimo = dblValHoraCurso
                End If
            End If
            dblValHoraCursoFranquiciable = dblMinimo
            Dim dblTmpCostoOticAl As Double
            dblTmpCostoOticAl = (intHoras * dblValHoraCursoFranquiciable * Franquicia)
            'Si por com. Bº el valor se sobrepasa del tope...se toma hasta el valor del participante
            If dblTmpCostoOticAl > dblValorParticipante Then
                dblTmpCostoOticAl = dblValorParticipante
            End If
            'cálculo del gasto empresa (se devuelve por referencia)
            mlngGastoEmpresaAlumno = lngValRealCurso / Me.mintCantParticipantes - dblTmpCostoOticAl
            CalcularCostoOticAlumno = dblTmpCostoOticAl
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostoOticAlumno-->" & ex.Message)
        End Try
    End Function
    'Función para calcular el costo otic alumno y el gasto empresa,
    'la funcion retorna el costo otic del alumno y el gasto empresa en una variable por referencia
    Function CalcularCostoOticAlumnoCompl(ByVal PorcAsistencia As Double, _
                                        ByVal CodEstadoCurso As Integer, _
                                        ByVal Franquicia As Double, ByVal lngValorMercado As Long, ByVal intHoras As Integer) As Double
        Try
            Dim dblMinimo As Double, dblAuxiliar As Double
            Dim dblValHoraCurso As Double, dblValHoraCursoFranquiciable As Double
            Dim lngValRealCurso As Long
            Dim dblValorParticipante As Double
            'curso con complemento: hay que calcular el valor de mercado y descuento,
            'redondeado al número de horas
            If intHoras > 0 Then
                Dim dblFactorHoras As Double
                'dblFactorHoras = (intHoras - Me.mintHrsComplementarias) / intHoras
                dblFactorHoras = Me.mintHrsComplementarias / intHoras
                lngValorMercado = Math.Round(dblFactorHoras * lngValorMercado)

                'considerar las horas correspondientes al año actual
                intHoras = intHoras - Me.mintHrsComplementarias
            End If
            lngValRealCurso = Math.Round(lngValorMercado)
            If intHoras <> 0 And Me.mintCantParticipantes <> 0 Then
                dblValHoraCurso = (lngValRealCurso / Me.mintHrsComplementarias) / Me.mintCantParticipantes
                dblValorParticipante = lngValRealCurso / Me.mintCantParticipantes
            Else
                dblValHoraCurso = -1
                dblValorParticipante = 0
            End If
            Dim intIndAcuComBip As Integer
            If Me.mbolComBipartito Then
                intIndAcuComBip = 1
            Else
                intIndAcuComBip = 0
            End If
            dblAuxiliar = mlngValHoraSence * (1 + (0.2 * intIndAcuComBip))
            If intIndAcuComBip = 1 Then
                'Toma el valor con comite Bº, si se excede del tope por participante se ajusta.
                'El valor hora del curso también es multiplicado por 1.2 (O sea se le suma el 20%)
                If dblAuxiliar <= (dblValHoraCurso * 1.2) Then
                    dblMinimo = dblAuxiliar
                Else
                    dblMinimo = dblValHoraCurso * 1.2
                End If
            Else
                'Si no toma el menor valor, si no es el curso...toma el tope por participante
                If dblAuxiliar <= dblValHoraCurso Then
                    dblMinimo = dblAuxiliar
                Else
                    dblMinimo = dblValHoraCurso
                End If
            End If
            dblValHoraCursoFranquiciable = dblMinimo
            Dim dblTmpCostoOticAl As Double
            dblTmpCostoOticAl = (intHoras * dblValHoraCursoFranquiciable * Franquicia)
            'Si por com. Bº el valor se sobrepasa del tope...se toma hasta el valor del participante
            If dblTmpCostoOticAl > dblValorParticipante Then
                dblTmpCostoOticAl = dblValorParticipante
            End If
            'cálculo del gasto empresa (se devuelve por referencia)
            mlngGastoEmpresaAlumno = lngValRealCurso / Me.mintCantParticipantes - dblTmpCostoOticAl
            CalcularCostoOticAlumnoCompl = dblTmpCostoOticAl
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostoOticAlumno-->" & ex.Message)
        End Try
    End Function
    'Función para calcular el costo otic alumno y el gasto empresa por viatico y traslado,
    'la funcion retorna el costo otic del alumno y el gasto empresa en una variable por referencia
    Function CalcularCostoOticAlumnoVYT(ByVal lngHoras As Long, _
                                            ByVal lngHorasCompl As Long, _
                                            ByVal dblVYT As Double, _
                                            ByVal dblPorcAsistencia As Double, _
                                            ByVal intCodEstadoCurso As Integer, _
                                            ByRef dblGastoEmpresaAlumnoVYT As Double, _
                                            ByVal dblPorcFranquicia As Double) As Double
        Try
            If dblPorcAsistencia <= 1 Then dblPorcAsistencia = 100 * dblPorcAsistencia
            Dim dblTmpCostoOticAl As Double
            'chequeo de la asistencia del alumno, si corresponde.
            If (intCodEstadoCurso <> 5 And intCodEstadoCurso <> 9 And _
                intCodEstadoCurso <> 10 And intCodEstadoCurso <> 11) _
                Or dblPorcAsistencia >= 75 Then
                'costo franquiciable
                dblTmpCostoOticAl = dblVYT
            Else
                dblTmpCostoOticAl = 0
            End If
            Dim lngTmpCostoOticRealVYT As Long
            lngTmpCostoOticRealVYT = Math.Round(dblTmpCostoOticAl * dblPorcFranquicia)
            CalcularCostoOticAlumnoVYT = lngTmpCostoOticRealVYT
            'cálculo del gasto empresa (se devuelve por referencia)
            dblGastoEmpresaAlumnoVYT = dblTmpCostoOticAl - lngTmpCostoOticRealVYT
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostoOticAlumnoVYT-->" & ex.Message)
        End Try
    End Function
    'Función para calcular el costo otic alumno y el gasto empresa por viatico y traslado,
    'la funcion retorna el costo otic del alumno y el gasto empresa en una variable por referencia
    Function CalcularCostoOticAlumnoVYTCompl(ByVal lngHoras As Long, _
                                            ByVal lngHorasCompl As Long, _
                                            ByVal dblVYT As Double, _
                                            ByVal dblPorcAsistencia As Double, _
                                            ByVal intCodEstadoCurso As Integer, _
                                            ByRef dblGastoEmpresaAlumnoVYT As Double, _
                                            ByVal dblPorcFranquicia As Double) As Double
        Try
            If dblPorcAsistencia <= 1 Then dblPorcAsistencia = 100 * dblPorcAsistencia
            Dim dblTmpCostoOticAl As Double
            'chequeo de la asistencia del alumno, si corresponde.
            If (intCodEstadoCurso <> 5 And intCodEstadoCurso <> 9 And _
                intCodEstadoCurso <> 10 And intCodEstadoCurso <> 11) _
                Or dblPorcAsistencia >= 75 Then
                'costo franquiciable
                dblTmpCostoOticAl = dblVYT
            Else
                dblTmpCostoOticAl = 0
            End If
            Dim lngTmpCostoOticRealVYT As Long
            lngTmpCostoOticRealVYT = Math.Round(dblTmpCostoOticAl * dblPorcFranquicia)
            CalcularCostoOticAlumnoVYTCompl = lngTmpCostoOticRealVYT
            'cálculo del gasto empresa (se devuelve por referencia)
            dblGastoEmpresaAlumnoVYT = dblTmpCostoOticAl - lngTmpCostoOticRealVYT
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcularCostoOticAlumnoVYT-->" & ex.Message)
        End Try
    End Function
    'calcular el total de viáticos y traslados
    Private Sub CalcTotViaticoTrasl()
        Try
            Dim i As Integer
            Dim lngAuxViatico, lngAuxTraslado As Long
            lngAuxViatico = 0
            lngAuxTraslado = 0
            For i = 0 To (mlngNumAlumnos - 1)
                lngAuxViatico = lngAuxViatico + Me.mlngViatico
                lngAuxTraslado = lngAuxTraslado + Me.mlngTraslado
            Next
            mlngTotalViatico = lngAuxViatico
            mlngTotalTraslado = lngAuxTraslado
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcTotViaticoTrasl-->" & ex.Message)
        End Try
    End Sub
    'Antes tiene que haberse calculado el Costo Otic
    Sub CalcCostoAdm()
        Try
            Dim lngMontoCalculoAdm As Long
            Dim lngMontoCalculoAdmVYT As Long
            lngMontoCalculoAdm = Me.mlngCostoOtic
            lngMontoCalculoAdmVYT = Me.mlngCostoOticVYT

            Dim intAdmNoLineal As Integer
            Dim lngCostoAdm As Long
            Dim lngCostoAdmVYT As Long

            intAdmNoLineal = mobjCsql.s_adm_no_lineal(Me.mlngRutEmpresa)

            If Me.mdblPorcAdm >= 0 And Me.mdblPorcAdm <= 1 Then
                If (100 - intAdmNoLineal * (100 * Me.mdblPorcAdm)) <> 0 Then
                    lngCostoAdm = Math.Round(lngMontoCalculoAdm * 100 * Me.mdblPorcAdm / (100 - intAdmNoLineal * (100 * Me.mdblPorcAdm)))
                Else
                    lngCostoAdm = -1
                End If
                'adm viaticos y traslado
                If (100 - intAdmNoLineal * (100 * Me.mdblPorcAdm)) <> 0 Then
                    lngCostoAdmVYT = Math.Round(lngMontoCalculoAdmVYT * 100 * Me.mdblPorcAdm / (100 - intAdmNoLineal * (100 * Me.mdblPorcAdm)))
                Else
                    lngCostoAdmVYT = -1
                End If
            ElseIf Me.mdblPorcAdm > 1 And Me.mdblPorcAdm <= 100 Then
                If (100 - intAdmNoLineal * Me.mdblPorcAdm) <> 0 Then
                    lngCostoAdm = Math.Round(lngMontoCalculoAdm * Me.mdblPorcAdm / (100 - intAdmNoLineal * Me.mdblPorcAdm))
                Else
                    lngCostoAdm = -1
                End If

                'adm viatico y traslado
                If (100 - intAdmNoLineal * Me.mdblPorcAdm) <> 0 Then
                    lngCostoAdmVYT = Math.Round(lngMontoCalculoAdmVYT * Me.mdblPorcAdm / (100 - intAdmNoLineal * Me.mdblPorcAdm))
                Else
                    lngCostoAdmVYT = -1
                End If
            End If
            mlngCostoAdm = lngCostoAdm
            mlngCostoAdmVYT = lngCostoAdmVYT
        Catch ex As Exception
            EnviaError("CServicioOtic:CalcCostoAdm-->" & ex.Message)
        End Try
    End Sub
    Protected Sub IngresaTransaccion()
        Try
            mobjCsql.i_transaccion(Me.mlngRutEmpresa, 1, 2, _
                    1, Me.mlngCostoOtic, _
                    "Cargo por Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                    mlngCodCursoIngresado, 0, Date.Now, 0)
            If Me.mlngCostoOticVYT > 0 Then
                mobjCsql.i_transaccion(Me.mlngRutEmpresa, 1, 5, _
                                    1, Me.mlngCostoOticVYT, _
                                    "Cargo por V&T de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                                    mlngCodCursoIngresado, 0, Date.Now, 0)
            End If
            mobjCsql.i_transaccion(Me.mlngRutEmpresa, 3, 2, _
                    1, Me.mlngCostoAdm, _
                     "Cargo por Administración de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                    mlngCodCursoIngresado, 0, Date.Now, 0)
            If mlngCostoAdmVYT > 0 Then
                mobjCsql.i_transaccion(Me.mlngRutEmpresa, 3, 5, _
                                    1, Me.mlngCostoAdmVYT, _
                                    "Cargo por Administración de V&T de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                                    mlngCodCursoIngresado, 0, Date.Now, 0)
            End If
        Catch ex As Exception
            EnviaError("CServicioOtic:IngresaTransaccion-->" & ex.Message)
        End Try
    End Sub
    Protected Sub IngresaTransaccionCuentas()
        Try
            If Me.mintCodCuenta = 1 Or Me.mintCodCuenta = 2 Or Me.mintCodCuenta = 8 Then
                mobjCsql.i_transaccion(Me.mlngRutEmpresa, Me.mintCodCuenta, 2, _
                                    1, Me.mlngValorCuenta, _
                                    "Cargo por Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                                    mlngCodCursoIngresado, 0, "30/12/" & Me.mintAnoInicio, 0)
            End If
            If Me.mintCodCuenta = 4 Or Me.mintCodCuenta = 5 Or Me.mintCodCuenta = 9 Then
                mobjCsql.i_transaccion(Me.mlngRutEmpresa, Me.mintCodCuenta, 2, _
                                    1, Me.mlngValorCuenta, _
                                    "Cargo por Excedentes, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                                    mlngCodCursoIngresado, 0, "30/12/" & Me.mintAnoInicio, 0)
            End If
            If Me.mintCodCuenta = 1 Or Me.mintCodCuenta = 2 Then
                mobjCsql.i_transaccion(Me.mlngRutEmpresa, 3, 2, _
                                    1, Me.mlngCostoAdm, _
                                     "Cargo por Administración de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                                    mlngCodCursoIngresado, 0, "30/12/" & Me.mintAnoInicio, 0)
            End If

            ''*************************************
            'If Me.mlngCostoOticVYT > 0 Then
            '    mobjCsql.i_transaccion(Me.mlngRutEmpresa, 1, 5, _
            '                        1, Me.mlngCostoOticVYT, _
            '                        "Cargo por V&T de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
            '                        mlngCodCursoIngresado, 0, Date.Now, 0)
            'End If
            'mobjCsql.i_transaccion(Me.mlngRutEmpresa, 3, 2, _
            '        1, Me.mlngCostoAdm, _
            '         "Cargo por Administración de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
            '        mlngCodCursoIngresado, 0, Date.Now, 0)
            'If mlngCostoAdmVYT > 0 Then
            '    mobjCsql.i_transaccion(Me.mlngRutEmpresa, 3, 5, _
            '                        1, Me.mlngCostoAdmVYT, _
            '                        "Cargo por Administración de V&T de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
            '                        mlngCodCursoIngresado, 0, Date.Now, 0)
            'End If


        Catch ex As Exception
            EnviaError("CServicioOtic:IngresaTransaccion-->" & ex.Message)
        End Try
    End Sub
    Public Sub EnvioErrores(ByVal strMensaje As String)
        Dim dr As DataRow

        dr = mdtMensajes.NewRow()
        dr("log") = strMensaje
        mdtMensajes.Rows.Add(dr)
        mstrMensajeParaEmail = mstrMensajeParaEmail & " " & strMensaje
        If mblnEnvioCorreo Then
            If mlngRutEmpresa > 0 Then
                Dim strNombreCliente As String
                strNombreCliente = mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa)
                mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
                "Se han intentado cargar cursos para la empresa " & strNombreCliente, mstrMensajeParaEmail, Parametros.p_SERVIDORCORREO)
            Else
                mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
               "Se han intentado cargar cursos ", mstrMensajeParaEmail, Parametros.p_SERVIDORCORREO)
            End If
        End If
    End Sub
    Function GrabarDatosII() As Boolean
        Try

            mlngCorrelativo = mobjCsql.i_curso_interno(Me.mlngRutEmpresa, 1, Me.mintCantParticipantes, _
            Me.mstrDireccion, Me.mlngCodComuna, Me.mdtmFechaInicio, Me.mdtmFechaFin, _
            Me.mdblCostoCurso, 0, mstrCorrelEmpresa, 0, Me.mstrObservacion, Me.mintAgno, _
            Me.mstrNombreCurso, Me.mstrEjecutor, Me.mstrHorario, Me.mintHoras, 0, 0)
            'consultas para determinar el código interno del curso ingresado

            Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Incompleto", "Ingreso del Encabezado del Curso Interno. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". ", _
                                1, mlngCodCursoIngresado)
            Return True
        Catch ex As Exception
            EnviaError("CCargaCursoInternoXls:GrabarDatos-->" & ex.Message)
        End Try
    End Function

    Sub GrabarAlumnosII()
        Try
            Dim dtTmp As DataTable
            Dim dig_verif As String
            Dim tipo_pers As String

            mlngTotalViatico = 0
            mlngTotalTraslado = 0

            dtTmp = mobjCsql.s_persona(mlngRutEmpleado)
            If dtTmp Is Nothing Then
                dig_verif = digito_verificador(mlngRutEmpleado)
                tipo_pers = "N"
                mobjCsql.i_Persona(mlngRutEmpleado, dig_verif, tipo_pers)
            End If
            dtTmp = New DataTable
            dtTmp = mobjCsql.s_pers_nat(mlngRutEmpleado)

            If Not dtTmp Is Nothing Then
                Call mobjCsql.u_pers_nat(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                        Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                        Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                        Me.mlngRutEmpresa, Me.mintCodComunaPartic, 1, "", "") ' 1 codigo pais chile
            Else
                Call mobjCsql.i_PersonaNatural(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                        Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                        Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                        Me.mlngRutEmpresa, Me.mintCodComunaPartic, 1, "", "") ' 1 codigo pais chile
            End If
            dtTmp = New DataTable
            dtTmp = mobjCsql.s_partic_curso(Me.mlngCodCursoIngresado, Me.mlngRutEmpleado)
            If Not dtTmp Is Nothing Then
                mobjCsql.u_participante_interno(Me.mlngCorrelativo, Me.mstrObservacion, Me.mintAgno, Me.mlngRutEmpleado, Me.mlngViatico, Me.mlngTraslado, True)
            Else
                mobjCsql.i_participante_interno(Me.mlngCorrelativo, Me.mintAgno, Me.mlngRutEmpleado, Me.mlngViatico, Me.mlngTraslado, True)
            End If
            mlngTotalViatico = mlngTotalViatico + Me.mlngViatico
            mlngTotalTraslado = mlngTotalTraslado + Me.mlngTraslado
        Catch ex As Exception
            EnviaError("CCargaCursoInternoXls:GrabarAlumnos-->" & ex.Message)
        End Try
    End Sub
    Public Sub AgregaLog(ByVal correlativo As Long, ByVal estado As String, ByVal detalle As String)
        Dim dr As DataRow
        dr = mdtLog.NewRow
        dr("correlativo") = correlativo
        dr("estado") = estado
        dr("detalle") = detalle
        mdtLog.Rows.Add(dr)
    End Sub
End Class

