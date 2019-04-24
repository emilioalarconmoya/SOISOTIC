Imports Microsoft.VisualBasic
Imports Modulos
Imports Clases
Imports System.Data
Imports System.Web
Imports Clases.Web
Imports System.Globalization
Imports System.Threading
Imports Microsoft.Office.Interop.Excel

Public Class CCargaCursoInternoXls
    Private mstrMensaje As String
    Private mstrMensajeAcierto As String
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
    Private mintCodCondicion As Integer
    Private mstrCodSence As String
    Private mdtDatosCursoSence As Data.DataTable
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
    Private mlngValHoraSence As Long
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

    Private mstrCodCentroCosto As String
    Private mstrNomCentroCosto As String

    Private mstrCodCargo As String
    Private mstrNomCargo As String

    Private mdblPorcAprobacion As Double = 0.0

    'Esta dato no va
    Private mlngRutEjecutivo As Long
    ''
    Private mobjSql As New CSql
    Private mobjSqlExcel As New CSql
    Private mobjEnviarCorreo As New CEnviarCorreo
    Private strTError As String
    Public dtErrores As Data.DataTable
    Private mdtMensajes As Data.DataTable
    Private mdtMensajeAciertos As Data.DataTable
    Public mdtDatAlum As Data.DataTable
    Private mlngRutEmplCoordinador As Long
    Private mlngCodUnidadViene As Long
    Private mstrTipoModalidad As String
    Private mintCodTipoUnidad As Integer
    Private mstrXml As String
    Private blnErrores As Boolean
    Private mblnEnvioCorreo As Boolean
    Private mstrMensajeParaEmailFallido As String
    Private mstrMensajeParaEmailCorrecto As String
    Private mstrCorrelEmpresa As String
    Private mdblCostoCurso As Double
    Private mstrHorario As String
    Private mintHoras As Integer
    Private mdblPorcAsistencia As Double
    Private mdblNotaObtenida As Double
    Private mdblNotaEvaluacion As Double
    Private mlngRutUsuario As Long
    Private mlngTotalViaticoCurso As Long
    Private mlngTotalTrasladoCurso As Long
    Private mintCodEstadoAprobado As Integer

    Public Property TotalViaticoCurso() As Long
        Get
            Return mlngTotalViaticoCurso
        End Get
        Set(ByVal value As Long)
            mlngTotalViaticoCurso = value
        End Set
    End Property
    Public Property TotalTrasladoCurso() As Long
        Get
            Return mlngTotalTrasladoCurso
        End Get
        Set(ByVal value As Long)
            mlngTotalTrasladoCurso = value
        End Set
    End Property
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property
    'Se le agregan registros
    Public ReadOnly Property Mensajes() As Data.DataTable
        Get
            Return Me.mdtMensajes
        End Get
    End Property
    Public ReadOnly Property Errores() As Boolean
        Get
            Return Me.blnErrores
        End Get
    End Property
    Public ReadOnly Property MensajeAciertos() As Data.DataTable
        Get
            Return Me.mdtMensajeAciertos
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
            mdtMensajes = New Data.DataTable
            Me.mdtMensajes.Columns.Add(New DataColumn("log", GetType(String)))
            mdtMensajeAciertos = New Data.DataTable
            mdtMensajeAciertos.Columns.Add(New DataColumn("log", GetType(String)))
            mstrMensajeParaEmailFallido = ""
            mstrMensajeParaEmailCorrecto = ""
        Catch ex As Exception
            EnviaError("CServicioOtic:inicializar-->" & ex.Message)
        End Try
    End Sub
    Public Function SiguienteCorrelativo(ByVal lngRutCliente As Long) As Long
        mobjCsql = New CSql
        Dim lngCorrelativo As Long
        lngCorrelativo = mobjCsql.s_max_correl_curso_interno(lngRutCliente)
        Return lngCorrelativo + 1
    End Function
    Public Function Cargar_Archivo(ByVal strRuta As String)
        Try
            mobjCsql = New CSql
            Dim dtTemporal, dtTemporalII, dtTemporalIII As Data.DataTable
            Dim dr, drII, drIII As DataRow


            mobjSqlExcel.MotorDb = "excel8"
            mobjSqlExcel.BD = strRuta
            'Dim strNombreHoja1, strNombreHoja2 As String
            'Dim xLibro As Workbook
            'Dim xHoja1, xHoja2, xHoja3 As Worksheet
            'Dim objExcel = New Microsoft.Office.Interop.Excel.Application
            ''Usamos el método open para abrir el archivo que está _   
            '' en el directorio del programa llamado archivo.xls   
            'xLibro = objExcel.Workbooks.Open(strRuta)
            'xHoja1 = CType(xLibro.Worksheets.Item(1), Worksheet)
            'xHoja2 = CType(xLibro.Worksheets.Item(2), Worksheet)
            'xHoja3 = CType(xLibro.Worksheets.Item(3), Worksheet)
            'strNombreHoja1 = xHoja1.Name.ToUpper
            'If strNombreHoja1 <> "CABECERA" Then
            '    mstrMensaje = "La Hoja 1 del archivo debe llamarse Cabecera"
            '    mblnEnvioCorreo = True
            '    EnvioErrores(mstrMensaje)
            '    blnErrores = False
            '    'xLibro.Close()
            '    'objExcel = Nothing
            '    Exit Function
            'End If
            'strNombreHoja2 = xHoja2.Name.ToUpper
            'If strNombreHoja2 <> "ALUMNOS" Then
            '    mstrMensaje = "La Hoja 2 del archivo debe llamarse Alumnos"
            '    mblnEnvioCorreo = True
            '    EnvioErrores(mstrMensaje)
            '    blnErrores = False
            '    'xLibro.Close()
            '    'objExcel = Nothing
            '    Exit Function
            'End If
            dtTemporal = mobjSqlExcel.s_carga_hoja_excel_cabecera("[Cabecera$]")
            If Not dtTemporal Is Nothing Then
                If dtTemporal.Columns.Count < 16 Then
                    mstrMensaje = "A la cabecera del curso le faltan columnas obligatorias"
                    mblnEnvioCorreo = True
                    EnvioErrores(mstrMensaje)
                    blnErrores = False
                    'xLibro.Close()
                    'objExcel = Nothing
                    Exit Function
                End If
            Else
                mstrMensaje = "La cabecera del curso tiene errores"
                mblnEnvioCorreo = True
                EnvioErrores(mstrMensaje)
                blnErrores = False
                'xLibro.Close()
                'objExcel = Nothing
                Exit Function
            End If
            mobjCsql.InicioTransaccion()
            For Each dr In dtTemporal.Rows
                If IsDBNull(dr(0)) And IsDBNull(dr(1)) And IsDBNull(dr(2)) And IsDBNull(dr(3)) And IsDBNull(dr(4)) And IsDBNull(dr(5)) _
                And IsDBNull(dr(6)) And IsDBNull(dr(7)) And IsDBNull(dr(8)) And IsDBNull(dr(9)) And IsDBNull(dr(10)) And IsDBNull(dr(11)) _
                And IsDBNull(dr(12)) And IsDBNull(dr(13)) And IsDBNull(dr(14)) And IsDBNull(dr(15)) Then
                    GoTo siguiente
                Else
                    If Not IsDBNull(dr(14)) Then
                        If EsRut(dr(14)) Then
                            If mobjCsql.s_existe_empresa_cliente(RutUsrALng(dr(14))) Then
                                mlngRutEmpresa = RutUsrALng(dr(14)).ToString.Trim
                            Else
                                mstrMensaje = "El rut de la empresa eno existe en el sistema"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "El rut es erroneo"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            mobjCsql.RollBackTransaccion()
                            'xLibro.Close()
                            'objExcel = Nothing
                            Exit Function
                        End If
                    Else
                        mstrMensaje = "Falta el rut de la empresa"
                        mblnEnvioCorreo = True
                        EnvioErrores(mstrMensaje)
                        blnErrores = False
                        mobjCsql.RollBackTransaccion()
                        'xLibro.Close()
                        'objExcel = Nothing
                        Exit Function
                    End If
                    If Not IsDBNull(dr(0)) Then
                        If Trim(dr(0)).ToUpper = "NO SENCE" Then
                            'NUMERO PARTICIPANTES
                            If Not IsDBNull(dr(1)) Then
                                If IsNumeric(dr(1)) Then
                                    If dr(1) > 0 And dr(1) < 2147483647 Then

                                        mintCantParticipantes = dr(1)
                                    Else
                                        mstrMensaje = "El número de paticipantes no es un valor númerico para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'DIRECCION CURSO
                            If Not IsDBNull(dr(2)) Then
                                mstrDireccion = dr(2)
                            Else
                                mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'CODIGO COMUNA
                            If Not IsDBNull(dr(3)) Then
                                If IsNumeric(dr(4)) Then
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
                                    mstrMensaje = "El código de la comuna debe ser númerico: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                End If

                            Else
                                mlngCodComuna = 132101
                                mstrMensaje = "El código de la comuna no existe para el correlativo: " & dr(9) & " se carga por defecto comuna de Santiago"
                                mblnEnvioCorreo = False
                                EnvioErrores(mstrMensaje)
                                ' blnErrores = False
                                'Exit Function
                            End If

                            'CORELATIVO EMPRESA
                            If Not IsDBNull(dr(9)) Then
                                mstrCorrelEmpresa = dr(9)
                            Else
                                mstrMensaje = "No existe correlativo"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'AÑO
                            If Not IsDBNull(dr(4)) Then
                                If IsNumeric(dr(4)) Then
                                    If Not mobjCsql.Existe_correlativo_empresa_interno(Me.mlngRutEmpresa, dr(4), Me.mstrCorrelEmpresa) Then
                                        If dr(4) > 1900 And dr(4) < 3000 Then
                                            mintAgno = dr(4)
                                        Else
                                            mstrMensaje = "El año esta en rangos incorrectos. En el correlativo " & dr(9)
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "El correlativo " & dr(9) & " ya se ha ingresado este año. "
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If

                                Else
                                    mstrMensaje = "El año del curso no contiene un valor numerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "No existe información del año para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'OBSERVACION
                            If Not IsDBNull(dr(5)) Then
                                mstrObservacion = Trim(dr(5))
                            Else
                                mstrObservacion = ""
                            End If

                            'FECHA INICIO
                            If Not IsDBNull(dr(6)) Then
                                If IsDate(dr(6)) Then
                                    If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                        mdtmFechaInicio = dr(6)
                                    Else
                                        mstrMensaje = "La fecha de inicio del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de inicio del curso no tiene formato correcto en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'FECHA FIN
                            If Not IsDBNull(dr(7)) Then
                                If CDate(dr(7)) >= CDate(dr(6)) Then
                                    If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                        mdtmFechaFin = dr(7)
                                    Else
                                        mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'COSTO TOTAL
                            If Not IsDBNull(dr(8)) Then
                                If IsNumeric(dr(8)) Then
                                    If dr(8) >= 0 And dr(8) < 2147483647 Then
                                        mdblCostoCurso = dr(8)
                                    Else
                                        mstrMensaje = "El costo del curso es menor a cero para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If



                            'NOMBRE CURSO
                            If Not IsDBNull(dr(10)) Then
                                mstrNombreCurso = dr(10)
                            Else
                                mstrMensaje = "El nombre del curso no existe para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'EJECUTOR
                            If Not IsDBNull(dr(11)) Then
                                mstrEjecutor = dr(11)
                            Else
                                mstrMensaje = "El nombre del ejecutor del curso no existe para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'HORARIO
                            If Not IsDBNull(dr(12)) Then
                                mstrHorario = Trim(dr(12))
                            Else
                                mstrHorario = ""
                            End If

                            'HORAS CURSO
                            If Not IsDBNull(dr(13)) Then
                                If IsNumeric(dr(13)) Then
                                    If dr(13) >= 0 And dr(13) <= 3000 Then
                                        mintHoras = Trim(dr(13))
                                    Else
                                        mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "Faltan las horas para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'TOTAL VIATICO
                            If Not IsDBNull(dr(15)) Then
                                If IsNumeric(dr(15)) Then
                                    If dr(15) >= 0 And dr(15) < 2147483647 Then
                                        mlngTotalViaticoCurso = dr(15)
                                    Else
                                        mstrMensaje = "El costo del curso es menor a cero para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            'TOTAL TRASLADO
                            If Not IsDBNull(dr(16)) Then
                                If IsNumeric(dr(16)) Then
                                    If dr(16) >= 0 And dr(16) < 2147483647 Then
                                        mlngTotalTrasladoCurso = dr(16)
                                    Else
                                        mstrMensaje = "El costo del curso es menor a cero para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        'xLibro.Close()
                                        'objExcel = Nothing
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If

                            ''PORCENTAJE APROBACION
                            'If Not IsDBNull(dr(15)) Then
                            '    If IsNumeric(dr(15)) Then
                            '        If CDbl(dr(15)) >= 0 And CDbl(dr(15)) <= 100 Then
                            '            mdblPorcAprobacion = dr(15)
                            '        Else
                            '            mstrMensaje = "El porcentaje de aprobación fuera de los rangos (0-100), correlativo : " & mstrCorrelEmpresa
                            '            mblnEnvioCorreo = True
                            '            EnvioErrores(mstrMensaje)
                            '            mobjCsql.RollBackTransaccion()
                            '            blnErrores = False
                            '            Exit Function
                            '        End If
                            '    Else
                            '        mstrMensaje = "El porcentaje de aprobación debe ser númerica, correlativo : " & mstrCorrelEmpresa
                            '        mblnEnvioCorreo = True
                            '        EnvioErrores(mstrMensaje)
                            '        mobjCsql.RollBackTransaccion()
                            '        blnErrores = False
                            '        Exit Function
                            '    End If
                            'Else
                            '    mstrMensaje = "El curso no tiene el  porcentaje de aprobación, correlativo : " & mstrCorrelEmpresa
                            '    mblnEnvioCorreo = True
                            '    EnvioErrores(mstrMensaje)
                            '    mobjCsql.RollBackTransaccion()
                            '    blnErrores = False
                            '    Exit Function
                            'End If

                            ''NOTA EVALUACION
                            'If Not IsDBNull(dr(16)) Then
                            '    If IsNumeric(dr(16)) Then
                            '        If CDbl(Replace(dr(16), ".", ",")) >= 0 And CDbl(Replace(dr(16), ".", ",")) <= 7.0 Then
                            '            mdblNotaEvaluacion = CDbl(Replace(dr(16), ".", ","))
                            '        Else
                            '            mstrMensaje = "La nota mínima de evaluación está fuera de los rangos (0.0-7.0), correlativo : " & mstrCorrelEmpresa
                            '            mblnEnvioCorreo = True
                            '            EnvioErrores(mstrMensaje)
                            '            mobjCsql.RollBackTransaccion()
                            '            blnErrores = False
                            '            Exit Function
                            '        End If
                            '    Else
                            '        mstrMensaje = "La nota mínima de evaluación debe ser númerica, correlativo : " & mstrCorrelEmpresa
                            '        mblnEnvioCorreo = True
                            '        EnvioErrores(mstrMensaje)
                            '        mobjCsql.RollBackTransaccion()
                            '        blnErrores = False
                            '        Exit Function
                            '    End If
                            'Else
                            '    mstrMensaje = "El curso no tiene la nota mínima de evaluación, correlativo : " & mstrCorrelEmpresa
                            '    mblnEnvioCorreo = True
                            '    EnvioErrores(mstrMensaje)
                            '    mobjCsql.RollBackTransaccion()
                            '    blnErrores = False
                            '    Exit Function
                            'End If
                            '''''''''''''''''''''''''HASTA ACA'''''''''''''''''''''''''''''''''''''
                            'mobjCsql.InicioTransaccion()
                            GrabarDatosII()
                            '***********************************************************************************
                            '******************************DATOS PARTICIPANTES**********************************
                            '***********************************************************************************
                            mlngNumAlumnos = 0
                            dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera3("[Alumnos$]", mstrCorrelEmpresa, dr(14).ToString.Trim)
                            If Not dtTemporalIII Is Nothing Then
                                If dtTemporalIII.Columns.Count < 5 Then
                                    mstrMensaje = "A los participantes del curso le faltan columnas obligatorias"
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "Los participantes del curso tiene errores, correlativo : " & mstrCorrelEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If
                            If Not dtTemporalIII.Rows.Count = mintCantParticipantes Then
                                mstrMensaje = "El numero de participante no coincide con los datos, correlativo : " & mstrCorrelEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                Exit Function
                            End If
                            For Each drIII In dtTemporalIII.Rows
                                If Not dtTemporalIII Is Nothing Then
                                    If dr(9) = drIII(13) And dr(14) = drIII(14) Then
                                        'RUT PARTICIPANTE
                                        If Not Trim(drIII(0)) = "" Then
                                            If validarut(drIII(0)) Then
                                                mlngRutEmpleado = RutUsrALng(drIII(0))
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con rut inválido, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function

                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin rut, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'NOMBRE PARTICIPANTE
                                        If Not IsDBNull(drIII(1)) Then
                                            mstrNombres = drIII(1)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin nombre, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'AP. PATERNO
                                        If Not IsDBNull(drIII(2)) Then
                                            mstrApePaterno = drIII(2)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'AP. MATRENO
                                        If Not IsDBNull(drIII(3)) Then
                                            mstrApeMaterno = drIII(3)
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin apellido materno, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'SEXO
                                        If Not IsDBNull(drIII(4)) Then
                                            If drIII(4).ToString.Trim = "M" Or drIII(4).ToString.Trim = "F" Then
                                                mstrSexo = drIII(4).ToString.Trim
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'CODIGO REGION
                                        If Not IsDBNull(drIII(5)) Then
                                            If IsNumeric(drIII(5)) Then
                                                If drIII(5) >= 1 And drIII(5) <= 15 Then
                                                    mintCodRegionPartic = drIII(5)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    'xLibro.Close()
                                                    'objExcel = Nothing
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas sin código de región, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'FRANQUICIA
                                        If Not IsDBNull(drIII(7)) Then
                                            If IsNumeric(drIII(7)) Then
                                                If drIII(7) >= 0 And drIII(7) <= 100 Then
                                                    mdblFranquicia = drIII(7)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    'xLibro.Close()
                                                    'objExcel = Nothing
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin franquicia, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'CODIGO OCUPACIONAL
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
                                                        mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        'xLibro.Close()
                                                        'objExcel = Nothing
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'VIATICO
                                        If Not IsDBNull(drIII(8)) Then
                                            If IsNumeric(drIII(8)) Then
                                                If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                    mlngViatico = drIII(8)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera del rango, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    'xLibro.Close()
                                                    'objExcel = Nothing
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mlngViatico = 0
                                        End If
                                        'TRASLADO
                                        If Not IsDBNull(drIII(9)) Then
                                            If IsNumeric(drIII(9)) Then
                                                If drIII(8) >= 0 And drIII(8) < 2147483647 Then
                                                    mlngTraslado = drIII(9)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera del rango, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    'xLibro.Close()
                                                    'objExcel = Nothing
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mlngTraslado = 0
                                        End If
                                        'CODIGO ESCOLAR
                                        If Not IsDBNull(drIII(10)) Then
                                            If IsNumeric(drIII(10)) Then
                                                If drIII(10) = 0 Then
                                                    mintCodEscolaridad = 5
                                                Else
                                                    If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                        mintCodEscolaridad = drIII(10)
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        'xLibro.Close()
                                                        'objExcel = Nothing
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'FECHA NACIMIENTO
                                        If Not IsDBNull(drIII(11)) Then
                                            If IsDate(drIII(11)) Then
                                                If CDate(drIII(11)) < CDate(FechaVbAUsr(Now)) Then
                                                    mdtmFechaNacimiento = CDate(drIII(11))
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    'xLibro.Close()
                                                    'objExcel = Nothing
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato incorrecto, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                blnErrores = False
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If
                                        'CODIGO COMUNA
                                        If Not IsDBNull(drIII(12)) Then
                                            If IsNumeric(drIII(12)) Then
                                                If mobjCsql.s_existe_comuna(drIII(12)) Then
                                                    mintCodComunaPartic = drIII(12)
                                                Else
                                                    mintCodComunaPartic = 132101
                                                    mstrMensaje = "No existe código de la comuna para el alumno: " & drIII(0) & " se carga por defecto comuna de Santiago" & ", correlativo: " & Me.mstrCorrelEmpresa
                                                    mblnEnvioCorreo = False
                                                    EnvioErrores(mstrMensaje)
                                                    'blnErrores = False
                                                    'Exit Function
                                                End If
                                            Else
                                                mstrMensaje = "En los participantes el código de la comuna debe ser númerico, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                blnErrores = False
                                                mobjCsql.RollBackTransaccion()
                                                'xLibro.Close()
                                                'objExcel = Nothing
                                                Exit Function
                                            End If
                                        Else
                                            mstrMensaje = "En los participantes del curso existen personas sin código de comuna, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        End If

                                        'CODIO APROBACION
                                        mintCodEstadoAprobado = 1
                                        ' ''If Not IsDBNull(drIII(15)) Then
                                        ' ''    If IsNumeric(drIII(15)) Then
                                        ' ''        If drIII(15) >= 1 And drIII(15) <= 3 Then
                                        ' ''            mintCodEstadoAprobado = drIII(15)
                                        ' ''        Else
                                        ' ''            mstrMensaje = "En los participantes del curso existen personas con código de aprobacion fuera de los rangos, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                        ' ''            mblnEnvioCorreo = True
                                        ' ''            EnvioErrores(mstrMensaje)
                                        ' ''            mobjCsql.RollBackTransaccion()
                                        ' ''            'xLibro.Close()
                                        ' ''            'objExcel = Nothing
                                        ' ''            blnErrores = False
                                        ' ''            Exit Function
                                        ' ''        End If
                                        ' ''    Else
                                        ' ''        mstrMensaje = "En los participantes del curso existen personas con código de aprobacion con valor no numerico, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                        ' ''        mblnEnvioCorreo = True
                                        ' ''        EnvioErrores(mstrMensaje)
                                        ' ''        mobjCsql.RollBackTransaccion()
                                        ' ''        'xLibro.Close()
                                        ' ''        'objExcel = Nothing
                                        ' ''        blnErrores = False
                                        ' ''        Exit Function
                                        ' ''    End If
                                        ' ''Else
                                        ' ''    mstrMensaje = "En los participantes del curso existen personas sin código de aprobacion, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                        ' ''    mblnEnvioCorreo = True
                                        ' ''    EnvioErrores(mstrMensaje)
                                        ' ''    mobjCsql.RollBackTransaccion()
                                        ' ''    'xLibro.Close()
                                        ' ''    'objExcel = Nothing
                                        ' ''    blnErrores = False
                                        ' ''    Exit Function
                                        ' ''End If
                                        '__________________________________________________________________________

                                        'If Not drIII(15).ToString.Trim = "" And Not drIII(16).ToString.Trim = "" Then
                                        '    'mobjCsql = New CSql
                                        '    If mobjCsql.Existe_centro_costo2(mlngRutEmpresa, drIII(15)) Then
                                        '        mstrCodCentroCosto = drIII(15)
                                        '        mstrNomCentroCosto = drIII(16)
                                        '    Else
                                        '        'If Not mobjCsql.Existe_cod_centro_costo(mlngRutEmpresa, drIII(15)) Then 'And Not mobjCsql.Existe_nom_centro_costo(mlngRutEmpresa, drIII(16))
                                        '        '    mstrMensaje = "El código de centro de costo ingresado para el empleado rut " & drIII(0) & " existe para otro nombre, fila : " & mlngNumAlumnos
                                        '        '    mblnEnvioCorreo = True
                                        '        '    EnvioErrores(mstrMensaje)
                                        '        '    mobjCsql.RollBackTransaccion()
                                        '        '    blnErrores = False
                                        '        '    Exit Function
                                        '        'End If
                                        '        'If Not mobjCsql.Existe_cod_centro_costo(mlngRutEmpresa, drIII(15)) Then 'And mobjCsql.Existe_nom_centro_costo(mlngRutEmpresa, drIII(16))
                                        '        '    mstrMensaje = "El nombre de centro de costo ingresado para el empleado rut " & drIII(0) & " existe para otro nombre, fila : " & mlngNumAlumnos
                                        '        '    mblnEnvioCorreo = True
                                        '        '    EnvioErrores(mstrMensaje)
                                        '        '    mobjCsql.RollBackTransaccion()
                                        '        '    blnErrores = False
                                        '        '    Exit Function
                                        '        'End If
                                        '        If Not mobjCsql.Existe_cod_centro_costo(mlngRutEmpresa, drIII(15)) Then 'And Not mobjCsql.Existe_nom_centro_costo(mlngRutEmpresa, drIII(16))
                                        '            mstrCodCentroCosto = drIII(15)
                                        '            mstrNomCentroCosto = drIII(16)
                                        '            mobjCsql.i_centro_costo(mlngRutEmpresa, mstrCodCentroCosto, mstrNomCentroCosto)
                                        '        End If
                                        '    End If
                                        '    'mobjCsql = Nothing
                                        'End If
                                        'If Not drIII(17).ToString.Trim = "" And Not drIII(18).ToString.Trim = "" Then
                                        '    'mobjCsql = New CSql
                                        '    If mobjCsql.Existe_cargo(mlngRutEmpresa, drIII(17)) Then
                                        '        mstrCodCargo = drIII(17)
                                        '        mstrNomCargo = drIII(18)
                                        '    Else
                                        '        'If Not mobjCsql.Existe_cod_cargo(mlngRutEmpresa, drIII(17)) Then 'And Not mobjCsql.Existe_nom_cargo(mlngRutEmpresa, drIII(18))
                                        '        '    mstrMensaje = "El código de cargo ingresado para el empleado rut " & drIII(0) & " existe para otro nombre, fila : " & mlngNumAlumnos
                                        '        '    mblnEnvioCorreo = True
                                        '        '    EnvioErrores(mstrMensaje)
                                        '        '    mobjCsql.RollBackTransaccion()
                                        '        '    blnErrores = False
                                        '        '    Exit Function
                                        '        'End If
                                        '        'If Not mobjCsql.Existe_cod_cargo(mlngRutEmpresa, drIII(17)) And mobjCsql.Existe_nom_cargo(mlngRutEmpresa, drIII(18)) Then
                                        '        '    mstrMensaje = "El nombre de cargo ingresado para el empleado rut " & drIII(0) & " existe para otro nombre, fila : " & mlngNumAlumnos
                                        '        '    mblnEnvioCorreo = True
                                        '        '    EnvioErrores(mstrMensaje)
                                        '        '    mobjCsql.RollBackTransaccion()
                                        '        '    blnErrores = False
                                        '        '    Exit Function
                                        '        'End If
                                        '        If Not mobjCsql.Existe_cod_cargo(mlngRutEmpresa, drIII(17)) Then 'And Not mobjCsql.Existe_nom_cargo(mlngRutEmpresa, drIII(18))
                                        '            mstrCodCargo = drIII(17)
                                        '            mstrNomCargo = drIII(18)
                                        '            mobjCsql.i_cargo(mlngRutEmpresa, mstrCodCargo, mstrNomCargo)
                                        '        End If
                                        '    End If
                                        '    'mobjCsql = Nothing
                                        'End If
                                        'If Not IsDBNull(drIII(19)) Then
                                        '    If IsNumeric(drIII(19)) Then
                                        '        If CDbl(drIII(19)) >= 0 And CDbl(drIII(19)) <= 100 Then
                                        '            mdblPorcAsistencia = drIII(19)
                                        '        Else
                                        '            mstrMensaje = "En los participantes del curso existen personas con porcentaje de asistencia fuera de los rangos (0-100), correlativo : " & mstrCorrelEmpresa
                                        '            mblnEnvioCorreo = True
                                        '            EnvioErrores(mstrMensaje)
                                        '            mobjCsql.RollBackTransaccion()
                                        '            blnErrores = False
                                        '            Exit Function
                                        '        End If
                                        '    Else
                                        '        mstrMensaje = "En los participantes del curso existen personas con porcentaje de asistencia no numerica, correlativo : " & mstrCorrelEmpresa
                                        '        mblnEnvioCorreo = True
                                        '        EnvioErrores(mstrMensaje)
                                        '        mobjCsql.RollBackTransaccion()
                                        '        blnErrores = False
                                        '        Exit Function
                                        '    End If
                                        'Else
                                        '    mstrMensaje = "En los participantes del curso existen personas sin porcentaje de asistencia, correlativo : " & mstrCorrelEmpresa
                                        '    mblnEnvioCorreo = True
                                        '    EnvioErrores(mstrMensaje)
                                        '    mobjCsql.RollBackTransaccion()
                                        '    blnErrores = False
                                        '    Exit Function
                                        'End If
                                        'If Not IsDBNull(drIII(20)) Then
                                        '    If IsNumeric(drIII(20)) Then
                                        '        If CDbl(drIII(20)) >= 0 And CDbl(drIII(20)) <= 7.0 Then
                                        '            mdblNotaObtenida = drIII(20)
                                        '        Else
                                        '            mstrMensaje = "En los participantes del curso existen personas con nota obtenida fuera de los rangos (0-7.0), correlativo : " & mstrCorrelEmpresa
                                        '            mblnEnvioCorreo = True
                                        '            EnvioErrores(mstrMensaje)
                                        '            mobjCsql.RollBackTransaccion()
                                        '            blnErrores = False
                                        '            Exit Function
                                        '        End If
                                        '    Else
                                        '        mstrMensaje = "En los participantes del curso existen personas con nota obtenida no numerica, correlativo : " & mstrCorrelEmpresa
                                        '        mblnEnvioCorreo = True
                                        '        EnvioErrores(mstrMensaje)
                                        '        mobjCsql.RollBackTransaccion()
                                        '        blnErrores = False
                                        '        Exit Function
                                        '    End If
                                        'Else
                                        '    mstrMensaje = "En los participantes del curso existen personas sin porcentaje de aprobación, correlativo : " & mstrCorrelEmpresa
                                        '    mblnEnvioCorreo = True
                                        '    EnvioErrores(mstrMensaje)
                                        '    mobjCsql.RollBackTransaccion()
                                        '    blnErrores = False
                                        '    Exit Function
                                        'End If
                                        '__________________________________________________________________________
                                        mobjCsql.s_partic_curso_interno(Me.mlngCorrelativo, Me.mintAgno, Me.mlngRutEmpleado)
                                        If mobjCsql.Registros > 0 Then
                                            mstrMensaje = "El particiantes se encuentra duplicado, rut : " & drIII(0) & ", correlativo: " & Me.mstrCorrelEmpresa
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            mobjCsql.RollBackTransaccion()
                                            'xLibro.Close()
                                            'objExcel = Nothing
                                            blnErrores = False
                                            Exit Function
                                        Else
                                            GrabarAlumnosII()
                                        End If
                                        mlngNumAlumnos = mlngNumAlumnos + 1
                                    End If
                                Else
                                    mstrMensaje = "No existen alumnos para el curso " & mstrCorrelEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    'xLibro.Close()
                                    'objExcel = Nothing
                                    blnErrores = False
                                    Exit Function
                                End If

                            Next
                            If mlngNumAlumnos = 0 Then
                                mstrMensaje = "No existen alumnos para el curso " & mstrCorrelEmpresa
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                mobjCsql.RollBackTransaccion()
                                'xLibro.Close()
                                'objExcel = Nothing
                                blnErrores = False
                                Exit Function
                            End If
                            Call mobjCsql.i_bitacora(Me.mlngRutEmpresa, "Ingresado", _
                                                        "Ingreso de alumnos del Curso Interno por carga masiva. Cliente: " _
                                                        & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                        6, Me.mlngCodCursoIngresado)
                            'mobjCsql.FinTransaccion()
                            mstrMensaje = "Se ingreso correctamente el curso, correlativo : " & Me.mstrCorrelEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & RutLngAUsr(Me.mlngRutEmpresa)
                            mblnEnvioCorreo = False
                            EnvioAciertos(mstrMensaje)
                        End If
                    End If
                End If

siguiente:
            Next
            blnErrores = True
            mblnEnvioCorreo = True
            mstrMensaje = ""
            mobjCsql.FinTransaccion()
            EnvioErrores(mstrMensaje)

        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            EnviaError("CCargaCursoInternoXls:GrabarDatos-->" & ex.Message)
        End Try
    End Function
    Public Sub EnvioErrores(ByVal strMensaje As String)
        Dim dr As DataRow

        dr = mdtMensajes.NewRow()
        dr("log") = strMensaje
        mdtMensajes.Rows.Add(dr)
        mstrMensajeParaEmailFallido = mstrMensajeParaEmailFallido & " " & strMensaje
        If mblnEnvioCorreo Then
            If mlngRutEmpresa > 0 Then
                Dim strNombreCliente As String
                strNombreCliente = mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa)
                mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
                "Se han intentado cargar cursos para la empresa " & strNombreCliente, mstrMensajeParaEmailFallido, Parametros.p_SERVIDORCORREO)
            Else
                mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
               "Se han intentado cargar cursos ", mstrMensajeParaEmailFallido, Parametros.p_SERVIDORCORREO)
            End If
        End If
    End Sub
    Public Sub EnvioAciertos(ByVal mstrMensajeAcierto As String)
        Dim dr As DataRow

        dr = mdtMensajeAciertos.NewRow()
        dr("log") = mstrMensajeAcierto
        mdtMensajeAciertos.Rows.Add(dr)
        mstrMensajeParaEmailCorrecto = mstrMensajeParaEmailCorrecto & " " & mstrMensajeAcierto
        If mblnEnvioCorreo Then
            If mlngRutEmpresa > 0 Then
                Dim strNombreCliente As String
                strNombreCliente = mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa)
                mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
                "Se han intentado cargar cursos para la empresa " & strNombreCliente, mstrMensajeParaEmailCorrecto, Parametros.p_SERVIDORCORREO)
            Else
                mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
               "Se han intentado cargar cursos ", mstrMensajeParaEmailCorrecto, Parametros.p_SERVIDORCORREO)
            End If
        End If
    End Sub
    Function GrabarDatosII() As Boolean
        Try

            mlngCorrelativo = mobjCsql.i_curso_interno(Me.mlngRutEmpresa, 1, Me.mintCantParticipantes, _
            Me.mstrDireccion, Me.mlngCodComuna, Me.mdtmFechaInicio, Me.mdtmFechaFin, _
            Me.mdblCostoCurso, 0, mstrCorrelEmpresa, 0, Me.mstrObservacion, Me.mintAgno, _
            Me.mstrNombreCurso, Me.mstrEjecutor, Me.mstrHorario, Me.mintHoras, Me.mlngTotalViaticoCurso, Me.mlngTotalTrasladoCurso)
            'consultas para determinar el código interno del curso ingresado

            Call mobjCsql.i_bitacora(Me.mlngRutUsuario, "Incompleto", "Ingreso del Encabezado del Curso Interno. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". ", _
                                6, mlngCorrelativo)
            Return True
        Catch ex As Exception
            EnviaError("CCargaCursoInternoXls:GrabarDatos-->" & ex.Message)
        End Try
    End Function

    Sub GrabarAlumnosII()
        Try
            Dim dtTmp As Data.DataTable
            Dim dig_verif As String
            Dim tipo_pers As String
            Dim viatico As Long
            Dim traslado As Long


            If Me.mlngTotalViaticoCurso > 0 Then
                viatico = (Me.mlngTotalViaticoCurso / Me.mintCantParticipantes)
            Else
                viatico = Me.mlngViatico
            End If

            If Me.mlngTotalTrasladoCurso > 0 Then
                traslado = (Me.mlngTotalTrasladoCurso / Me.mintCantParticipantes)
            Else
                traslado = Me.mlngTraslado
            End If

            dtTmp = mobjCsql.s_persona(mlngRutEmpleado)
            If mobjCsql.Registros = 0 Then
                dig_verif = digito_verificador(mlngRutEmpleado)
                tipo_pers = "N"
                mobjCsql.i_Persona(mlngRutEmpleado, dig_verif, tipo_pers)

            End If
            dtTmp = New Data.DataTable
            dtTmp = mobjCsql.s_pers_nat(mlngRutEmpleado)

            If mobjCsql.Registros > 0 Then
                Call mobjCsql.u_pers_nat(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                        Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                        Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                        Me.mlngRutEmpresa, Me.mintCodComunaPartic, 1, "", "") '1 codigo pais chile
            Else
                Call mobjCsql.i_PersonaNatural(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                        Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                        Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                        Me.mlngRutEmpresa, Me.mintCodComunaPartic, 1, "", "") '1 codigo pais chile
            End If
            dtTmp = New Data.DataTable
            dtTmp = mobjCsql.s_partic_curso_interno(Me.mlngCorrelativo, Me.mintAgno, Me.mlngRutEmpleado)
            If mobjCsql.Registros > 0 Then
                mobjCsql.u_participante_interno(Me.mlngCorrelativo, Me.mstrObservacion, Me.mintAgno, Me.mlngRutEmpleado, viatico, traslado, Me.mintCodEstadoAprobado)
            Else
                mobjCsql.i_participante_interno(Me.mlngCorrelativo, Me.mintAgno, Me.mlngRutEmpleado, viatico, traslado, Me.mintCodEstadoAprobado)
            End If
            mlngTotalViatico = mlngTotalViatico + Me.mlngViatico
            mlngTotalTraslado = mlngTotalTraslado + Me.mlngTraslado

            If mlngTotalViatico > 0 Or mlngTotalTraslado > 0 Then
                mobjCsql.u_vyt_curso_interno(Me.mlngCorrelativo, Me.mintAgno, mlngTotalViatico, mlngTotalTraslado)
            End If

            'Call mobjCsql.i_bitacora(Me.mlngRutUsuario, "Ingresado", "Ingreso de alumnos del Curso Interno. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". ", _
            '                    6, mlngCorrelativo)
        Catch ex As Exception
            EnviaError("CCargaCursoInternoXls:GrabarAlumnos-->" & ex.Message)
        End Try
    End Sub
End Class
