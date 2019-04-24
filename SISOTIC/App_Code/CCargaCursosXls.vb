Imports Microsoft.VisualBasic
Imports Modulos
Imports Clases
Imports System.Data
Imports System.Xml
Imports System.Web
Imports Clases.Web
Imports System.Globalization
Imports System.Threading
Imports Microsoft.Office.Interop.Excel
Namespace Clases

    Public Class CCargaCursosXls
        Dim objMantenedorINS As CMantenedorCursosSence
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
        Private mlngValHoraSence As Double
        Private mlngCostoOticAlumno As Long
        Private mlngCostoOticAlumnoVYT As Long
        Private mlngGastoEmpresaAlumnoVYT As Long
        Private mlngGastoEmpresaAlumno As Long
        Private mlngRut As Long '??
        Private mstrPathXML As String
        Private mdoubValor_hora As Double
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
        Public dtErrores As Data.DataTable
        Private mdtMensajeAciertos As Data.DataTable
        Private mdtMensajes As Data.DataTable
        Public mdtDatAlum As Data.DataTable
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

        Private mlngCodPais As Long
        Private mstrTelefono As String

        Private mstrEmail As String

        'rut usuario
        Private mlngRutUsuario As Long
        Private mstrMensajeParaEmailFallido As String
        Private mstrMensajeParaEmailCorrecto As String
        Private objOtec As COtec
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
        'Se le agregan registros
        Public ReadOnly Property Mensajes() As Data.DataTable
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
        Public Function Cargar_Archivo(ByVal strRuta As String)
            Try

                mobjSql = New CSql
                Dim dtTemporal, dtTemporalII, dtTemporalIII As Data.DataTable
                Dim dr, drII, drIII As DataRow


                mobjSqlExcel.MotorDb = "excel8"
                mobjSqlExcel.BD = strRuta
                'Dim strNombreHoja1, strNombreHoja2, strNombreHoja3 As String
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
                '    Exit Function
                'End If
                'strNombreHoja2 = xHoja2.Name.ToUpper
                'If strNombreHoja2 <> "HORARIO" Then
                '    mstrMensaje = "La Hoja 2 del archivo debe llamarse Horario"
                '    mblnEnvioCorreo = True
                '    EnvioErrores(mstrMensaje)
                '    blnErrores = False
                '    Exit Function
                'End If
                'strNombreHoja3 = xHoja3.Name.ToUpper
                'If strNombreHoja3 <> "ALUMNOS" Then
                '    mstrMensaje = "La Hoja 3 del archivo debe llamarse Alumnos"
                '    mblnEnvioCorreo = True
                '    EnvioErrores(mstrMensaje)
                '    blnErrores = False
                '    Exit Function
                'End If

                dtTemporal = mobjSqlExcel.s_carga_hoja_excel("[Cabecera$]")
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
                mobjCsql.InicioTransaccion()
                For Each dr In dtTemporal.Rows
                    If IsDBNull(dr(0)) And IsDBNull(dr(1)) And IsDBNull(dr(2)) And IsDBNull(dr(3)) And IsDBNull(dr(4)) And IsDBNull(dr(5)) _
                    And IsDBNull(dr(6)) And IsDBNull(dr(7)) And IsDBNull(dr(8)) And IsDBNull(dr(9)) And IsDBNull(dr(10)) And IsDBNull(dr(1)) _
                    And IsDBNull(dr(12)) And IsDBNull(dr(13)) And IsDBNull(dr(14)) And IsDBNull(dr(15)) And IsDBNull(dr(16)) And IsDBNull(dr(17)) _
                    And IsDBNull(dr(18)) And IsDBNull(dr(19)) And IsDBNull(dr(20)) And IsDBNull(dr(21)) And IsDBNull(dr(22)) And IsDBNull(dr(23)) _
                    And IsDBNull(dr(24)) Then
                        GoTo siguiente
                    Else

                        If Not IsDBNull(dr(23)) Then
                            If EsRut(dr(23)) Then
                                If mobjCsql.s_existe_empresa_cliente(RutUsrALng(dr(23))) Then
                                    mlngRutEmpresa = RutUsrALng(dr(23)).ToString.Trim
                                Else
                                    mstrMensaje = "El rut de la empresa eno existe en el sistema"
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                            Else
                                mstrMensaje = "El rut de la empresa es erroneo"
                                mblnEnvioCorreo = True
                                EnvioErrores(mstrMensaje)
                                blnErrores = False
                                mobjCsql.RollBackTransaccion()
                                Exit Function
                            End If
                        Else
                            mstrMensaje = "Falta el rut de la empresa"
                            mblnEnvioCorreo = True
                            EnvioErrores(mstrMensaje)
                            blnErrores = False
                            mobjCsql.RollBackTransaccion()
                            Exit Function
                        End If
                        'si tipo de curso es Sence = 1 se efectua el ingreso
                        If Not IsDBNull(dr(0)) Then
                            If Trim(dr(0)).ToUpper = "SENCE" Then
                                If Not IsDBNull(dr(9)) Then
                                    If Not mobjCsql.Existe_correlativo_empresa(Me.mlngRutEmpresa, dr(9).ToString.Trim) Then
                                        mstrCorrelEmpresa = dr(9).ToString.Trim
                                    Else
                                        mstrMensaje = "Ya se ingreso el  correlativo empresa: " & dr(9).ToString.Trim
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe correlativo empresa"
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe el código de actividad para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe información del comité bipartito para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe información de la detección de necesidades para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe el número de paticipantes para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If

                                If Not IsDBNull(dr(2)) Then
                                    mstrLugarEjecucion = dr(2)
                                Else
                                    mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                    mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function

                                        End If
                                    Else
                                        mstrMensaje = "El año de inicio no contiene un valor numerico para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe información del año de inicio para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(5)) Then
                                    mstrObservacion = dr(5)
                                Else
                                    mstrObservacion = ""
                                End If
                                If Not IsDBNull(dr(19)) Then
                                    If Trim(dr(19)).ToUpper = "PRESENCIAL" Or Trim(dr(19)).ToUpper = "E-LEARNING" Or Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Or Trim(dr(19)).ToUpper = "A DISTANCIA" Then
                                        If Trim(dr(19)).ToUpper = "PRESENCIAL" Then
                                            mintCodModalidad = 1
                                        ElseIf Trim(dr(19)).ToUpper = "E-LEARNING" Then
                                            mintCodModalidad = 2
                                        ElseIf Trim(dr(19)).ToUpper = "AUTO-INSTRUCCION" Then
                                            mintCodModalidad = 3
                                        ElseIf Trim(dr(19)).ToUpper = "A DISTANCIA" Then
                                            mintCodModalidad = 4
                                        Else
                                            mstrMensaje = "La modalidad no esta reconocida para el correlativo: " & dr(9)
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    End If
                                Else
                                    mstrMensaje = "No existe el código de modalidad para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(20)) Then
                                    mstrCodSence = dr(20)
                                    If Not CargaDatosCurso(mstrCodSence) Then
                                        'mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                        'mblnEnvioCorreo = True
                                        'EnvioErrores(mstrMensaje)
                                        'blnErrores = False
                                        'mobjCsql.RollBackTransaccion()
                                        'Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No se ha incluido el código sence del curso para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                mdtDatosCursoSence = mobjCsql.s_datos_curso(mstrCodSence)
                                If Not IsNothing(mdtDatosCursoSence) Then
                                    If mdtDatosCursoSence.Rows.Count > 0 Then
                                        Me.mintHrsSence = mdtDatosCursoSence.Rows(0).Item("horas")
                                        Me.mlngRutOtec = mdtDatosCursoSence.Rows(0).Item("rut_otec")
                                    Else

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
                                        Dim xml_RutOtec As String
                                        Dim xml_NombreSede As String
                                        Dim xml_FonoSede As String
                                        Dim xml_DireccionSede As String
                                        Dim xml_CodComunaSede As Long
                                        Dim xml_CodModalidad As Long
                                        Dim xml_NombreModalidad As String


                                        respuesta_web = cs_web.getHTML("http://pruebasphp.soleduc.cl/traedatos_sql.php?curso=" + mstrCodSence)

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
                                                mstrMensaje = "No existe el rut de la otec en la base de datos del sistema. " & dr(9)
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                blnErrores = False
                                                mobjCsql.RollBackTransaccion()
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



                                            objMantenedorINS = New CMantenedorCursosSence
                                            objMantenedorINS.CodSence = mstrCodSence
                                            objMantenedorINS.NombreCurso = xml_NomCurso 'Me.txtNombreCurso.Text
                                            objMantenedorINS.RutOtec = xml_RutOtec 'Me.txtRutEmpresa.Text
                                            objMantenedorINS.Area = xml_Area 'Me.txtArea.Text
                                            objMantenedorINS.Especialidad = xml_Especialidad 'Me.txtEspecialidad.Text
                                            objMantenedorINS.DurCurTeorico = CLng(xml_HorTeoricas) 'CLng(Me.txtDurCursoTeorico.Text.Trim)
                                            objMantenedorINS.DurCurPractico = CLng(xml_HorPracticas) 'CLng(Me.txtDurCursoPractico.Text.Trim)
                                            objMantenedorINS.NumMaxParticipantes = CLng(xml_NumParticip) 'CLng(Me.txtNumParticipantes.Text.Trim)
                                            objMantenedorINS.NombreSede = "" 'Me.txtNombreSede.Text
                                            objMantenedorINS.FonoSede = "" 'Me.txtFonoSede.Text
                                            objMantenedorINS.Direccion = "" 'Me.txtDireccion.Text
                                            objMantenedorINS.CodComuna = CLng("132101") 'CLng(Me.ddlComuna.SelectedValue.Trim)
                                            objMantenedorINS.ValorCurso = CLng(xml_TotalCurso) 'CLng(Me.txtValorTotal.Text.Trim)
                                            objMantenedorINS.ValorHora = CDbl(Replace(xml_HorValor, ".", ","))
                                            objMantenedorINS.DurCurElearning = CLng(xml_HorElearning)
                                            objMantenedorINS.CodModalidad = CLng(xml_CodModalidad)



                                            If objMantenedorINS.Insertar() Then
                                                Me.mintHrsSence = Val(xml_HorTeoricas) + Val(xml_HorPracticas)
                                                Me.mlngRutOtec = xml_RutOtec
                                            Else
                                                mstrMensaje = "No existe el código sence y hubo problemas al intentar desde SENCE " & dr(9)
                                                mblnEnvioCorreo = True
                                                EnvioErrores(mstrMensaje)
                                                blnErrores = False
                                                mobjCsql.RollBackTransaccion()
                                                Exit Function
                                            End If

                                        Else

                                            mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                        '*************************************************************************


                                        mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe el código sence del curso para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(6)) Then
                                    If IsDate(dr(6)) Then
                                        'If CDate(dr(6)) > CDate(FechaVbAUsr(Now)) Then
                                        mdtmFechaInicio = dr(6)
                                        'If Not Year(CDate(dr(6))) > Year(Now) + 1 Then
                                        '    If CDate(dr(6)) > CDate(FechaMinSistema()) And CDate(dr(6)) < CDate(FechaMaxSistema()) Then
                                        '        mdtmFechaInicio = dr(6)
                                        '    Else
                                        '        mstrMensaje = "La fecha de inicio del curso esta fuera de los parametros del sistema correlativo: " & dr(9)
                                        '        mblnEnvioCorreo = True
                                        '        EnvioErrores(mstrMensaje)
                                        '        blnErrores = False
                                        '        mobjCsql.RollBackTransaccion()
                                        '        Exit Function
                                        '    End If
                                        'Else
                                        '    mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                        '    mblnEnvioCorreo = True
                                        '    EnvioErrores(mstrMensaje)
                                        '    blnErrores = False
                                        '    mobjCsql.RollBackTransaccion()
                                        '    Exit Function
                                        'End If
                                        'Else
                                        '    mstrMensaje = "La fecha de inicio del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                        '    mblnEnvioCorreo = True
                                        '    EnvioErrores(mstrMensaje)
                                        '    blnErrores = False
                                        '    mobjCsql.RollBackTransaccion()
                                        '    Exit Function
                                        'End If
                                    Else
                                        mstrMensaje = "La fecha de inicio del curso tiene formato incorrecto en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(7)) Then
                                    If IsDate(dr(7)) Then
                                        If CDate(dr(7)) >= CDate(dr(6)) Then
                                            mdtmFechaFin = dr(7)
                                            'If Not Year(CDate(dr(7))) > Year(Now) + 1 Then
                                            '    If CDate(dr(7)) > CDate(FechaMinSistema()) And CDate(dr(7)) < CDate(FechaMaxSistema()) Then
                                            '        mdtmFechaFin = dr(7)
                                            '    Else
                                            '        mstrMensaje = "La fecha de fin del curso esta fuera de los parametros del sistema en el correlativo: " & dr(9)
                                            '        mblnEnvioCorreo = True
                                            '        EnvioErrores(mstrMensaje)
                                            '        blnErrores = False
                                            '        mobjCsql.RollBackTransaccion()
                                            '        Exit Function
                                            '    End If
                                            'Else
                                            '    mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                            '    mblnEnvioCorreo = True
                                            '    EnvioErrores(mstrMensaje)
                                            '    blnErrores = False
                                            '    mobjCsql.RollBackTransaccion()
                                            '    Exit Function
                                            'End If
                                        Else
                                            mstrMensaje = "La fecha de fin del curso esta fuera de los plazos para su comunicación en el correlativo: " & dr(9)
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "La fecha de fin del curso no tiene el formato correcto en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "El valor de las horas complementarias debe ser numerico en el correlativo : " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "El valor total del curso debe ser un valor numerico en el correlativo : " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El valor total del curso no existe en el correlativo : " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(22)) Then
                                    mstrContactoAdicional = dr(22)
                                Else
                                    mstrContactoAdicional = ""
                                End If
                                If Not IsDBNull(dr(24)) Then
                                    mdoubValor_hora = dr(24)
                                Else
                                    mdoubValor_hora = 0

                                End If
                                mdblPorcAdm = mobjCsql.s_porcentaje_administracion(Me.mlngRutEmpresa)
                                '  mobjCsql.InicioTransaccion()
                                GrabarDatos()
                                '***********************************************************************************
                                '********************************DATOS HORARIO**************************************
                                '***********************************************************************************
                                If IsNumeric(mstrCorrelEmpresa) Then
                                    dtTemporalII = mobjSqlExcel.s_carga_hoja_excel_cabecera3("[Horario$]", mstrCorrelEmpresa, dr(23))
                                Else
                                    dtTemporalII = mobjSqlExcel.s_carga_hoja_excel_cabecera2("[Horario$]", mstrCorrelEmpresa, dr(23))
                                End If

                                If Not dtTemporalII Is Nothing Then
                                    For Each drII In dtTemporalII.Rows
                                        If Not IsDBNull(drII(3)) Then
                                            If Trim(dr(9)) = Trim(drII(3)) And RutUsrALng(Trim(dr(23))) = RutUsrALng(Trim(drII(4))) Then
                                                If Not IsDBNull(drII(0)) Then
                                                    If IsNumeric(drII(0)) Then
                                                        If drII(0) >= 1 And drII(0) <= 7 Then
                                                            mintDia = drII(0)
                                                        Else
                                                            mstrMensaje = "El horario tiene valores que estan fuera del rango numerico en el campo dia, correlativo : " & mstrCorrelEmpresa
                                                            mblnEnvioCorreo = True
                                                            EnvioErrores(mstrMensaje)
                                                            blnErrores = False
                                                            mobjCsql.RollBackTransaccion()
                                                            Exit Function
                                                        End If
                                                    Else
                                                        mstrMensaje = "El horario tiene valor que no son numericos en el campo dia, correlativo : " & mstrCorrelEmpresa
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        blnErrores = False
                                                        mobjCsql.RollBackTransaccion()
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "El horario tiene valores vacios en el campo dia, correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    blnErrores = False
                                                    mobjCsql.RollBackTransaccion()
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
                                                        mobjCsql.RollBackTransaccion()
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En el horario la hora de incio no puede ser mayor a la hora de fin, correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    blnErrores = False
                                                    mobjCsql.RollBackTransaccion()
                                                    Exit Function
                                                End If
                                                If Not GrabarHorario() Then
                                                    mstrMensaje = "En el horario existen datos duplicados, correlativo : " & mstrCorrelEmpresa
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    blnErrores = False
                                                    mobjCsql.RollBackTransaccion()
                                                    Exit Function
                                                End If
                                            End If
                                        End If
                                    Next
                                Else
                                    mstrMensaje = "No existe el horario para el curso, correlativo : " & mstrCorrelEmpresa
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If

                                '***********************************************************************************
                                '******************************DATOS PARTICIPANTES**********************************
                                '***********************************************************************************
                                mlngNumAlumnos = 0
                                If IsNumeric(mstrCorrelEmpresa) Then
                                    dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera3("[Alumnos$]", mstrCorrelEmpresa, dr(23))
                                Else
                                    dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera2("[Alumnos$]", mstrCorrelEmpresa, dr(23))
                                End If
                                'dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel_cabecera2("[Alumnos$]", mstrCorrelEmpresa, dr(23))
                                If Not dtTemporalIII Is Nothing Then
                                    For Each drIII In dtTemporalIII.Rows
                                        If Not IsDBNull(drIII(13)) Then
                                            If Trim(dr(9)) = Trim(drIII(13)) And RutUsrALng(Trim(dr(23))) = RutUsrALng(Trim(drIII(14))) Then
                                                If Not Trim(drIII(0)) = "" Then
                                                    If validarut(drIII(0).ToString.ToLower.Trim) Then
                                                        mlngRutEmpleado = RutUsrALng(drIII(0).ToString.ToLower.Trim)
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin rut, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                                If Not IsDBNull(drIII(1)) Then
                                                    mstrNombres = drIII(1)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin nombre, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                                If Not IsDBNull(drIII(2)) Then
                                                    mstrApePaterno = drIII(2)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin apellido paterno, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                                If Not IsDBNull(drIII(3)) Then
                                                    mstrApeMaterno = drIII(3)
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin apellido materno, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                                        mstrMensaje = "En los participantes del curso existen personas con el campo sexo sin el formato correspondiente (m:masculino, f:femenino), correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin la información del sexo, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If
                                                If Not IsDBNull(drIII(5)) Then
                                                    If IsNumeric(drIII(5)) Then
                                                        If drIII(5) >= 1 And drIII(5) <= 16 Then
                                                            mintCodRegionPartic = drIII(5)
                                                        Else
                                                            mstrMensaje = "En los participantes del curso existen personas con el código de región fuera del rango (1 al 15), correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                            mblnEnvioCorreo = True
                                                            EnvioErrores(mstrMensaje)
                                                            mobjCsql.RollBackTransaccion()
                                                            blnErrores = False
                                                            Exit Function
                                                        End If
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas sin código de región, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con el código de región como valor no numerico, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                                            mstrMensaje = "En los participantes del curso existen personas con franquicia fuera de los rangos (15-50-100), correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                            mblnEnvioCorreo = True
                                                            EnvioErrores(mstrMensaje)
                                                            mobjCsql.RollBackTransaccion()
                                                            blnErrores = False
                                                            Exit Function
                                                        End If
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con franquicia no numerica, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin franquicia, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                                                mstrMensaje = "En los participantes del curso existen personas con código ocupacional fuera del rango(1 al 7), correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                                mblnEnvioCorreo = True
                                                                EnvioErrores(mstrMensaje)
                                                                mobjCsql.RollBackTransaccion()
                                                                blnErrores = False
                                                                Exit Function
                                                            End If
                                                        End If
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con código ocupacional con valores no numericos, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin código ocupacional, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                                            mstrMensaje = "En los participantes del curso existen personas con valor de viáticos fuera de los rangos del sistema, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                            mblnEnvioCorreo = True
                                                            EnvioErrores(mstrMensaje)
                                                            mobjCsql.RollBackTransaccion()
                                                            blnErrores = False
                                                            Exit Function
                                                        End If
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con valor de viáticos no numerico, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mlngViatico = 0
                                                    drIII(8) = 0
                                                End If
                                                If Not IsDBNull(drIII(9)) Then
                                                    If IsNumeric(drIII(9)) Then
                                                        If drIII(9) >= 0 And drIII(9) < 2147483647 Then
                                                            mlngTraslado = drIII(9)
                                                        Else
                                                            mstrMensaje = "En los participantes del curso existen personas con valor de traslados fuera de los rangos del sistema, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                            mblnEnvioCorreo = True
                                                            EnvioErrores(mstrMensaje)
                                                            mobjCsql.RollBackTransaccion()
                                                            blnErrores = False
                                                            Exit Function
                                                        End If

                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con valor de traslados no numerico, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mlngTraslado = 0
                                                    drIII(9) = 0
                                                End If
                                                If Not IsDBNull(drIII(10)) Then
                                                    If IsNumeric(drIII(10)) Then
                                                        If drIII(10) = 0 Then
                                                            mintCodEscolaridad = 5
                                                        Else
                                                            If drIII(10) >= 1 And drIII(10) <= 9 Then
                                                                mintCodEscolaridad = drIII(10)
                                                            Else
                                                                mstrMensaje = "En los participantes del curso existen personas con código de escolaridad fuera del rango (1 a 9), correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                                mblnEnvioCorreo = True
                                                                EnvioErrores(mstrMensaje)
                                                                mobjCsql.RollBackTransaccion()
                                                                blnErrores = False
                                                                Exit Function
                                                            End If
                                                        End If
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con código de escolaridad con valor no numerico, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin código de escolaridad, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                                                mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                                mblnEnvioCorreo = True
                                                                EnvioErrores(mstrMensaje)
                                                                mobjCsql.RollBackTransaccion()
                                                                blnErrores = False
                                                                Exit Function

                                                            End If
                                                        Else
                                                            mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                            mblnEnvioCorreo = True
                                                            EnvioErrores(mstrMensaje)
                                                            mobjCsql.RollBackTransaccion()
                                                            blnErrores = False
                                                            Exit Function
                                                        End If
                                                    Else
                                                        mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato erroneo, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin fecha de nacimiento, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                                        mstrMensaje = "En los participantes del curso existen personas con código de comuna inexistente, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas sin código de comuna, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                    mblnEnvioCorreo = True
                                                    EnvioErrores(mstrMensaje)
                                                    mobjCsql.RollBackTransaccion()
                                                    blnErrores = False
                                                    Exit Function
                                                End If

                                                ' codigo pais
                                                If Not IsDBNull(drIII(15)) Then
                                                    If IsNumeric(drIII(15)) Then
                                                        If mobjCsql.s_existe_pais(drIII(15)) Then
                                                            mlngCodPais = drIII(15)
                                                        Else
                                                            mlngCodPais = 1
                                                            mstrMensaje = "No existe código del país para el empleado: " & drIII(0) & " se carga por defecto chile"
                                                            mblnEnvioCorreo = False
                                                            EnvioErrores(mstrMensaje)
                                                            blnErrores = False
                                                        End If
                                                    Else
                                                        Dim dtpais As Data.DataTable
                                                        dtpais = mobjCsql.s_existe_pais_por_nombre(drIII(15))
                                                        If mobjCsql.Registros > 0 Then
                                                            mlngCodPais = dtpais.Rows(0)(0)
                                                        Else
                                                            mlngCodPais = 1
                                                            mstrMensaje = "No existe código del país para el empleado: " & drIII(0) & " se carga por defecto chile"
                                                            mblnEnvioCorreo = False
                                                            EnvioErrores(mstrMensaje)
                                                            blnErrores = False

                                                        End If
                                                    End If
                                                Else
                                                    mlngCodPais = 1
                                                    mstrMensaje = "No existe código del país para el empleado: " & drIII(0) & " se carga por defecto chile"
                                                    mblnEnvioCorreo = False
                                                    EnvioErrores(mstrMensaje)
                                                    blnErrores = False
                                                End If

                                                'telefono

                                                If Not IsDBNull(drIII(16)) Then
                                                    If IsNumeric(drIII(16)) Then
                                                        If drIII(16).ToString.Length < 9 Then
                                                            mstrTelefono = drIII(16)
                                                        Else
                                                            mstrMensaje = "En los participantes el telefono  no puede tener mas de 8 digitos, rut alumno: " & drIII(0)
                                                            mblnEnvioCorreo = True
                                                            EnvioErrores(mstrMensaje)
                                                            mobjCsql.RollBackTransaccion()
                                                            blnErrores = False
                                                            Exit Function
                                                        End If

                                                    Else
                                                        mstrMensaje = "En los participantes el telefono debe ser númerico, rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrTelefono = ""
                                                End If

                                                'email

                                                If Not IsDBNull(drIII(17)) Then
                                                    If validaMail(drIII(17)) Then
                                                        mstrEmail = drIII(17)
                                                    Else
                                                        mstrMensaje = "En los participantes el mail tiene formato incorrecto, rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrEmail = ""
                                                End If


                                                mlngNumAlumnos = mlngNumAlumnos + 1
                                                CalcTotViaticoTrasl()
                                                GrabarAlumnos()
                                            End If
                                        End If
                                    Next
                                Else
                                    mstrMensaje = "No existen alumnos para el curso, correlativo " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    mobjCsql.RollBackTransaccion()
                                    blnErrores = False
                                    Exit Function
                                End If
                                If mlngNumAlumnos = 0 Then
                                    mstrMensaje = "No existen alumnos para el curso , correlativo " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                CalcularCostos(dtTemporalIII, mstrCodSence)
                                CalcCostoAdm()
                                ModificarDatos()
                                IngresaTransaccion()

                                blnErrores = True
                                mstrMensajeAcierto = "Se ingreso correctamente el curso, correlativo : " & Me.mstrCorrelEmpresa & ", de la empresa " & mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa) & " Rut: " & RutLngAUsr(Me.mlngRutEmpresa)
                                mblnEnvioCorreo = False
                                EnvioAciertos(mstrMensajeAcierto)
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
                                    mobjCsql.RollBackTransaccion()
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
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(11)) Then
                                    mstrEjecutor = dr(11)
                                Else
                                    mstrMensaje = "El nombre del ejecutor del curso no existe para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(4)) Then
                                    If IsNumeric(dr(4)) Then
                                        'If Not mobjCsql.Existe_correlativo_empresa_interno(Me.mlngRutEmpresa, dr(4), Me.mstrCorrelEmpresa) Then
                                        If dr(4) > 1900 And dr(4) < 3000 Then
                                            mintAgno = dr(4)
                                        Else
                                            mstrMensaje = "El correlativo " & dr(9) & " el año esta en rangos incorrectos. "
                                            mblnEnvioCorreo = True
                                            EnvioErrores(mstrMensaje)
                                            blnErrores = False
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                        'Else
                                        '    mstrMensaje = "El correlativo " & dr(9) & " ya se ha ingresado este año. "
                                        '    mblnEnvioCorreo = True
                                        '    EnvioErrores(mstrMensaje)
                                        '    blnErrores = False
                                        '    mobjCsql.RollBackTransaccion()
                                        '    Exit Function
                                        'End If

                                    Else
                                        mstrMensaje = "El año del curso no contiene un valor numerico para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe información del año para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "No existe el número de participantes para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                If Not IsDBNull(dr(2)) Then
                                    mstrDireccion = dr(2)
                                Else
                                    mstrMensaje = "No existe la dirección para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "La fecha de inicio del curso no tiene formato correcto en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de inicio del curso esta vacia en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If

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
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "La fecha de fin del curso esta fuera de los rangos en el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "La fecha de fin del curso esta vacia en el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "El costo del curso no es un valor númerico para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
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
                                            mobjCsql.RollBackTransaccion()
                                            Exit Function
                                        End If
                                    Else
                                        mstrMensaje = "Las horas deben ser numéricas para el correlativo: " & dr(9)
                                        mblnEnvioCorreo = True
                                        EnvioErrores(mstrMensaje)
                                        blnErrores = False
                                        mobjCsql.RollBackTransaccion()
                                        Exit Function
                                    End If
                                Else
                                    mstrMensaje = "Faltan las horas para el correlativo: " & dr(9)
                                    mblnEnvioCorreo = True
                                    EnvioErrores(mstrMensaje)
                                    blnErrores = False
                                    mobjCsql.RollBackTransaccion()
                                    Exit Function
                                End If
                                '''''''''''''''''''''''''HASTA ACA'''''''''''''''''''''''''''''''''''''
                                'mobjCsql.InicioTransaccion()
                                GrabarDatosII()
                                '***********************************************************************************
                                '******************************DATOS PARTICIPANTES**********************************
                                '***********************************************************************************
                                mlngNumAlumnos = 0
                                dtTemporalIII = mobjSqlExcel.s_carga_hoja_excel("[Alumnos$]")
                                For Each drIII In dtTemporalIII.Rows
                                    If Not dtTemporalIII Is Nothing Then
                                        If dr(9) = drIII(13) And RutUsrALng(dr(23)) = RutUsrALng(drIII(14)) Then
                                            If Not Trim(drIII(0)) = "" Then
                                                If validarut(drIII(0)) Then
                                                    mlngRutEmpleado = RutUsrALng(drIII(0))
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con rut inválido, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                                    If drIII(5) >= 1 And drIII(5) <= 16 Then
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
                                                        mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento incorrecta, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
                                                        mblnEnvioCorreo = True
                                                        EnvioErrores(mstrMensaje)
                                                        mobjCsql.RollBackTransaccion()
                                                        blnErrores = False
                                                        Exit Function
                                                    End If
                                                Else
                                                    mstrMensaje = "En los participantes del curso existen personas con fecha de nacimiento con formato incorrecta, correlativo : " & mstrCorrelEmpresa & ", rut alumno: " & drIII(0)
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
                                Call mobjCsql.i_bitacora(Me.mlngRutUsuario, "Ingresado", _
                                                            "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                                            & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                                            1, Me.mlngCodCursoIngresado)
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
                EnvioErrores(mstrMensaje)
                mobjCsql.FinTransaccion()
            Catch ex As Exception
                mobjCsql.RollBackTransaccion()
                EnviaError("CServicioOtic:Procesar-->" & ex.Message)
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
                mdtMensajes = New Data.DataTable
                Me.mdtMensajes.Columns.Add(New DataColumn("log", GetType(String)))
                mdtMensajeAciertos = New Data.DataTable
                mdtMensajeAciertos.Columns.Add(New DataColumn("log", GetType(String)))
                mstrMensajeParaEmail = ""
                mstrMensajeParaEmailFallido = ""
                mstrMensajeParaEmailCorrecto = ""
            Catch ex As Exception
                EnviaError("CCargaCursoXls:inicializar-->" & ex.Message)
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
                mlngRutOtec = dt.Rows(0).Item(1)
                mstrArea = dt.Rows(0).Item(2)
                mstrEspecialidad = dt.Rows(0).Item(3)
                mlngDurCursoTeorico = dt.Rows(0).Item(4)
                mlngDurCursoPractico = dt.Rows(0).Item(5)
                mlngNumMaxParticip = dt.Rows(0).Item(6)
                mstrNombreSede = dt.Rows(0).Item(7)
                mstrFonoSede = dt.Rows(0).Item(8)
                'mstrDireccion = dt.Rows(0).Item(9)
                'mlngCodComuna = dt.Rows(0).Item(10)
                mblnPendiente = dt.Rows(0).Item(11)
                mstrComunaCurso = dt.Rows(0).Item(12)
                CargaDatosCurso = True
            Catch ex As Exception
                EnviaError("CCargaCursoXls:CargaDatosCurso-->" & ex.Message)
            End Try
        End Function

        Function GrabarDatos() As Boolean
            Try
                Dim dt As Data.DataTable
                mlngCorrelativo = mobjCsql.s_correlativo(Me.mintAnoInicio)
                mobjCsql.i_curso_contr(Me.mlngRutEmpresa, Me.mintCodTipoActividad, _
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
                                           Me.mintCodModalidad, Me.mstrNumDireccion, Me.mstrCiudad, Me.mdoubValor_hora)


                'consultas para determinar el código interno del curso ingresado
                dt = mobjCsql.s_cod_curso_contr()
                mlngCodCursoIngresado = dt.Rows(0)(0)

                Call mobjCsql.i_bitacora(mlngRutUsuario, "Incompleto", "Ingreso del Encabezado del Curso Contratado. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". " & "Realizado por " & RutLngAUsr(Me.mlngRutEjecutivo), _
                                    1, mlngCodCursoIngresado)
                Return True
            Catch ex As Exception
                EnviaError("CCargaCursoXls:GrabarDatos-->" & ex.Message)
            End Try
        End Function
        'funcion para grabar el horario del curso
        Function GrabarHorario() As Boolean
            Try
                If Not mobjCsql.s_existe_horario_curso(mlngCodCursoIngresado, mintDia, Me.mstrHoraInicio) Then
                    mobjCsql.i_horario_curso(Me.mlngCodCursoIngresado, Me.mintDia, Me.mstrHoraInicio, Me.mstrHoraFin)
                    Return True
                Else
                    Return False
                End If
               
            Catch ex As Exception
                EnviaError("CCargaCursoXls:GrabarHorario-->" & ex.Message)
            End Try
        End Function
        'función para grabar la asistencia de alumnos
        Sub GrabarAlumnos()
            Try
                Dim dtTmp As Data.DataTable
                Dim dig_verif As String
                Dim tipo_pers As String

                mlngTotalViatico = 0
                mlngTotalTraslado = 0

                dtTmp = mobjCsql.s_persona(mlngRutEmpleado)
                'If dtTmp Is Nothing Then
                If dtTmp.Rows.Count = 0 Then
                    dig_verif = digito_verificador(mlngRutEmpleado)
                    tipo_pers = "N"
                    mobjCsql.i_Persona(mlngRutEmpleado, dig_verif, tipo_pers)
                End If

                'End If
                dtTmp = New Data.DataTable
                dtTmp = mobjCsql.s_pers_nat(mlngRutEmpleado)

                'If Not dtTmp Is Nothing Then
                If Not dtTmp.Rows.Count = 0 Then
                    Call mobjCsql.u_pers_nat(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                            Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                            Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                            Me.mlngRutEmpresa, Me.mintCodComunaPartic, mlngCodPais, mstrTelefono, mstrEmail) ' 1 codigo pais chile
                Else
                    Call mobjCsql.i_PersonaNatural(Me.mlngRutEmpleado, Me.mstrApePaterno, Me.mstrApeMaterno, Me.mstrNombres, _
                                                            Me.mdtmFechaNacimiento, Me.mstrSexo, Me.mdblFranquicia, _
                                                            Me.mintCodOcupacional, Me.mintCodEscolaridad, Me.mintCodRegionPartic, _
                                                            Me.mlngRutEmpresa, Me.mintCodComunaPartic, mlngCodPais, mstrTelefono, mstrEmail) ' 1 codigo pais chile
                End If
                dtTmp = New Data.DataTable
                dtTmp = mobjCsql.s_partic_curso(Me.mlngCodCursoIngresado, Me.mlngRutEmpleado)
                'If Not dtTmp Is Nothing Then
                If Not dtTmp.Rows.Count = 0 Then
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
                EnviaError("CCargaCursoXls:GrabarAlumnos-->" & ex.Message)
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
                                           0, Me.mlngCorrelativo, -1, Me.mintAnoInicio, _
                                           mdblPorcAdm, mlngCostoOtic, mlngCostoAdm, mlngGastoEmpresa, _
                                           mlngCostoOticVYT, mlngCostoAdmVYT, _
                                           mlngGastoEmpresaVYT, mlngTotalViatico, mlngTotalTraslado, _
                                           1, "", 0, "", Me.mintHrsSence, 0, _
                                           FechaMinSistema, -1, _
                                           0, Me.mstrCorrelEmpresa, FechaMinSistema, FechaMinSistema, _
                                           Me.mlngCodCursoIngresado, Me.mstrContactoAdicional, mstrObservacion, _
                                           Me.mintCodModalidad, _
                                           Me.mstrNumDireccion, Me.mstrCiudad)

            Catch ex As Exception
                EnviaError("CCargaCursoXls:ModificarDatos-->" & ex.Message)
            End Try
        End Sub
        'procedimiento para calcular el costo otic, empresa,
        'y totales de viáticos y traslados
        Sub CalcularCostos(ByVal dtTemporal As Data.DataTable, ByVal CodSence As String)
            Try
                Dim dblTempCostoOtic As Double, dblTempGastoEmpresa As Double
                Dim dblTempCostoOticVYT As Double, dblTempGastoEmpresaVYT As Double
                Dim dr As DataRow
                'actualizar el valor de viáticos y traslados
                CalcTotViaticoTrasl()

                'valor de la hora sence
                'mlngValHoraSence = mobjCsql.s_val_hora_sence_agno(Me.mintAnoInicio)
                If mdoubValor_hora = 0 Then
                    mlngValHoraSence = mobjCsql.s_valor_hora_curso_sence(CodSence)
                Else
                    mlngValHoraSence = mdoubValor_hora
                End If
                'mlngValHoraSence = mobjCsql.s_valor_hora_curso_sence(CodSence)
                dblTempCostoOtic = 0
                dblTempGastoEmpresa = 0

                'costos por Viatico y traslado
                dblTempCostoOticVYT = 0
                dblTempGastoEmpresaVYT = 0

                'en el cálculo de costos por alumno
                Dim i As Integer

                For Each dr In dtTemporal.Rows
                    If Not IsDBNull(dr(13)) Then
                        If Me.mstrCorrelEmpresa = dr(13) Then
                            CalcularCostosAl(mlngValHoraSence, dr(7) / 100, _
                                            dr(8), dr(9))
                            ' nodo.Item("nro_participantes").InnerText
                            dblTempCostoOtic = dblTempCostoOtic + mlngCostoOticAlumno
                            dblTempGastoEmpresa = dblTempGastoEmpresa + mlngGastoEmpresaAlumno
                            dblTempCostoOticVYT = dblTempCostoOticVYT + mlngCostoOticAlumnoVYT
                            dblTempGastoEmpresaVYT = dblTempGastoEmpresaVYT + mlngGastoEmpresaVYT
                        End If
                    End If
                Next

                mlngCostoOtic = Math.Round(dblTempCostoOtic)
                mlngGastoEmpresa = Math.Round(dblTempGastoEmpresa)
                mlngCostoOticVYT = dblTempCostoOticVYT
                mlngGastoEmpresaVYT = dblTempGastoEmpresaVYT
            Catch ex As Exception
                EnviaError("CCargaCursoXls:CalcularCostos-->" & ex.Message)
            End Try
        End Sub
        'calcular costos del alumno: otic, empresa
        Sub CalcularCostosAl(ByVal ValHoraSence As Double, ByVal Franquicia As Double, _
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
                        mlngCodCursoIngresado, 0, mdtmFechaInicio, 0)
                If Me.mlngCostoOticVYT > 0 Then
                    mobjCsql.i_transaccion(Me.mlngRutEmpresa, 1, 5, _
                                        1, Me.mlngCostoOticVYT, _
                                        "Cargo por V&T de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                                        mlngCodCursoIngresado, 0, mdtmFechaInicio, 0)
                End If
                mobjCsql.i_transaccion(Me.mlngRutEmpresa, 3, 2, _
                        1, Me.mlngCostoAdm, _
                         "Cargo por Administración de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                        mlngCodCursoIngresado, 0, mdtmFechaInicio, 0)
                If mlngCostoAdmVYT > 0 Then
                    mobjCsql.i_transaccion(Me.mlngRutEmpresa, 3, 5, _
                                        1, Me.mlngCostoAdmVYT, _
                                        "Cargo por Administración de V&T de Curso, Correlativo: " & Trim(CStr(mlngCorrelativo)), _
                                        mlngCodCursoIngresado, 0, mdtmFechaInicio, 0)
                End If
            Catch ex As Exception
                EnviaError("CServicioOtic:IngresaTransaccion-->" & ex.Message)
            End Try
        End Sub
        'Public Sub EnvioErrores(ByVal strMensaje As String)
        '    Dim dr As DataRow

        '    dr = mdtMensajes.NewRow()
        '    dr("log") = strMensaje
        '    mdtMensajes.Rows.Add(dr)
        '    mstrMensajeParaEmail = mstrMensajeParaEmail & " " & strMensaje
        '    If mblnEnvioCorreo Then
        '        If mlngRutEmpresa > 0 Then
        '            Dim strNombreCliente As String
        '            strNombreCliente = mobjCsql.s_nombre_cliente(Me.mlngRutEmpresa)
        '            mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
        '            "Se han intentado cargar cursos para la empresa " & strNombreCliente, mstrMensajeParaEmail, Parametros.p_SERVIDORCORREO)
        '        Else
        '            mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
        '           "Se han intentado cargar cursos ", mstrMensajeParaEmail, Parametros.p_SERVIDORCORREO)
        '        End If
        '    End If
        'End Sub
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
                    'mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
                    '"Se han intentado cargar cursos para la empresa " & strNombreCliente, mstrMensajeParaEmailFallido, Parametros.p_SERVIDORCORREO)
                Else
                    'mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
                    '"Se han intentado cargar cursos ", mstrMensajeParaEmailFallido, Parametros.p_SERVIDORCORREO)
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
                    'mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
                    '"Se han intentado cargar cursos para la empresa " & strNombreCliente, mstrMensajeParaEmailCorrecto, Parametros.p_SERVIDORCORREO)
                Else
                    'mobjEnviarCorreo.EnviarCorreo(Parametros.p_USUARIOCORREO, Parametros.p_USUARIOCORREO, _
                    '"Se han intentado cargar cursos ", mstrMensajeParaEmailCorrecto, Parametros.p_SERVIDORCORREO)
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

                Call mobjCsql.i_bitacora(Me.mlngRutUsuario, "Incompleto", "Ingreso del Encabezado del Curso Interno. Cliente: " & RutLngAUsr(Me.mlngRutEmpresa) & ". ", _
                                    1, mlngCodCursoIngresado)
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

                mlngTotalViatico = 0
                mlngTotalTraslado = 0

                dtTmp = mobjCsql.s_persona(mlngRutEmpleado)
                'If dtTmp Is Nothing Then
                If dtTmp.Rows.Count = 0 Then
                    dig_verif = digito_verificador(mlngRutEmpleado)
                    tipo_pers = "N"
                    mobjCsql.i_Persona(mlngRutEmpleado, dig_verif, tipo_pers)
                End If
                dtTmp = New Data.DataTable
                dtTmp = mobjCsql.s_pers_nat(mlngRutEmpleado)

                'If Not dtTmp Is Nothing Then
                If Not dtTmp.Rows.Count = 0 Then
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
                dtTmp = New Data.DataTable
                dtTmp = mobjCsql.s_partic_curso(Me.mlngCodCursoIngresado, Me.mlngRutEmpleado)
                'If Not dtTmp Is Nothing Then
                If Not dtTmp.Rows.Count = 0 Then
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
    End Class
End Namespace
