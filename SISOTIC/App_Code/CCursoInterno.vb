Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CCursoInterno
    'declaraciones
    Private mobjSql As CSql
    Private mlngFilas As Long
    'rut del usuario conectado
    Private mlngRutUsuario As Long
    'Nombre del curso
    Private mstrNombreCurso As String
    'El Número Correlativo del Curso
    Private mlngCorrelativo As Long
    'El Número de que representa los perfiles que el usuario tiene
    Private mlngNroPerfil As Long
    'Nombre del ejecutor
    Private mstrEjecutor As String
    'horario del curso
    Private mstrHorario As String
    'Rut del Cliente
    Private mlngRutCliente As Long
    'Código del Estado del Curso
    Private mintCodEstadoCurso As Integer
    'Año
    Private mintAgno As Integer
    'Fecha de Inicio del Curso
    Private mdtmFechaInicio As Date
    'Fecha de Fin del Curso
    Private mdtmFechaTermino As Date
    'Valor del curso en el mercado
    Private mlngValorCurso As Long
    'Descuento
    Private mlngDescuento As Long
    'Indicador si el descuento es monto (0) o porcentaje (1)
    Private mintIndDescPorc As Integer
    'Direccion donde se dara el curso
    Private mlngValorTotalCurso As Long
    Private mstrDireccionCurso As String
    'Código de la Comuna
    Private mlngCodComuna As Long
    'Código de la Region
    Private mlngCodRegion As Long
    'Arreglo con todas las comunas
    Private mdtComunas As DataTable
    'Nombre de la Region
    Private mstrNomRegion As String
    'Correlativo Interno de la Empresa Cliente
    Private mstrCorrEmpresa As String
    'Observación
    Private mstrObservacion As String
    'Numero de Participantes del curso
    Private mlngNumAlumnos As Long
    'Objeto Cliente
    Private mobjCliente As cCliente
    'Declaracion de un arreglo de Alumnos
    Private mcolAlumnos As Collection
    Private mlngCodCurso As Long
    Private mintHoras As Integer
    Private mlngTotalViatico As Long
    Private mlngTotalTraslado As Long
    Private mdtParticipantes As DataTable
    Private mstrNombreCliente As String
    Private mlngTotalVyT As Long
    Public Property NombreCliente() As String
        Get
            Return mstrNombreCliente
        End Get
        Set(ByVal value As String)
            mstrNombreCliente = value
        End Set
    End Property
    Public Property Participantes() As DataTable
        Get
            Return mdtParticipantes
        End Get
        Set(ByVal value As DataTable)
            mdtParticipantes = value
        End Set
    End Property
    Public Property TotalVyT() As Long
        Get
            Return Me.mlngTotalVyT
        End Get
        Set(ByVal value As Long)
            Me.mlngTotalVyT = value
        End Set
    End Property
    Public Property TotalViatico() As Long
        Get
            Return Me.mlngTotalViatico
        End Get
        Set(ByVal value As Long)
            Me.mlngTotalViatico = value
        End Set
    End Property
    Public Property TotalTraslado() As Long
        Get
            Return Me.mlngTotalTraslado
        End Get
        Set(ByVal value As Long)
            Me.mlngTotalTraslado = value
        End Set
    End Property
    Public Property CodCurso() As Long
        Get
            Return Me.mlngCodCurso
        End Get
        Set(ByVal value As Long)
            Me.mlngCodCurso = value
        End Set
    End Property
    Public Property RurUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property NombreCurso() As String
        Get
            Return mstrNombreCurso
        End Get
        Set(ByVal value As String)
            mstrNombreCurso = value
        End Set
    End Property
    Public Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    Public Property NroPerfil() As Long
        Get
            Return mlngNroPerfil
        End Get
        Set(ByVal value As Long)
            mlngNroPerfil = value
        End Set
    End Property
    Public Property Ejecutor() As String
        Get
            Return mstrEjecutor
        End Get
        Set(ByVal value As String)
            mstrEjecutor = value
        End Set
    End Property
    Public Property Horario() As String
        Get
            Return mstrHorario
        End Get
        Set(ByVal value As String)
            mstrHorario = value
        End Set
    End Property
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property CodEstadoCurso() As Integer
        Get
            Return mintCodEstadoCurso
        End Get
        Set(ByVal value As Integer)
            mintCodEstadoCurso = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public Property FechaInicio() As Date
        Get
            Return mdtmFechaInicio
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = value
        End Set
    End Property
    Public Property FechaTermino() As Date
        Get
            Return mdtmFechaTermino
        End Get
        Set(ByVal value As Date)
            mdtmFechaTermino = value
        End Set
    End Property
    Public Property ValorCurso() As Long
        Get
            Return mlngValorCurso
        End Get
        Set(ByVal value As Long)
            mlngValorCurso = value
        End Set
    End Property
    Public Property ValorTotalCurso() As Long
        Get
            Return mlngValorTotalCurso
        End Get
        Set(ByVal value As Long)
            mlngValorTotalCurso = value
        End Set
    End Property

    Public Property Descuento() As Long
        Get
            Return mlngDescuento
        End Get
        Set(ByVal value As Long)
            mlngDescuento = value
        End Set
    End Property
    Public Property IndDescPorc() As Integer
        Get
            Return mintIndDescPorc
        End Get
        Set(ByVal value As Integer)
            mintIndDescPorc = value
        End Set
    End Property
    Public Property DireccionCurso() As String
        Get
            Return mstrDireccionCurso
        End Get
        Set(ByVal value As String)
            mstrDireccionCurso = value
        End Set
    End Property
    Public Property CodComuna() As Long
        Get
            Return mlngCodComuna
        End Get
        Set(ByVal value As Long)
            mlngCodComuna = value
        End Set
    End Property
    Public Property CodRegion() As Long
        Get
            Return mlngCodRegion
        End Get
        Set(ByVal value As Long)
            mlngCodRegion = value
        End Set
    End Property
    Public ReadOnly Property LookUpComunas() As DataTable
        Get
            LookUpComunas = mdtComunas
        End Get
    End Property
    Public ReadOnly Property NombreComuna() As String
        Get
            NombreComuna = mobjSql.s_comuna(mlngCodComuna)
        End Get
    End Property
    Public Property NomRegion() As String
        Get
            Return mstrNomRegion
        End Get
        Set(ByVal value As String)
            mstrNomRegion = value
        End Set
    End Property
    Public Property Alumnos() As Collection
        Get
            Return mcolAlumnos
        End Get
        Set(ByVal value As Collection)
            mcolAlumnos = value
        End Set
    End Property
    Public Property CorrEmpresa() As String
        Get
            Return mstrCorrEmpresa
        End Get
        Set(ByVal value As String)
            mstrCorrEmpresa = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return mstrObservacion
        End Get
        Set(ByVal value As String)
            mstrObservacion = value
        End Set
    End Property
    Public Property NumAlumnos() As Long
        Get
            Return mlngNumAlumnos
        End Get
        Set(ByVal value As Long)
            mlngNumAlumnos = value
        End Set
    End Property
    Public Property Horas() As Integer
        Get
            Return mintHoras
        End Get
        Set(ByVal value As Integer)
            mintHoras = value
        End Set
    End Property
    Public ReadOnly Property Cliente() As CCliente
        Get
            Return mobjCliente
        End Get
    End Property
    Public Sub Inicializar0(ByRef objSql As CSql, _
                            ByVal lngRutUsuario As Long)
        Try
            mobjSql = objSql
            If lngRutUsuario <= 0 Then

                Exit Sub
            End If
            mlngRutUsuario = lngRutUsuario

            mdtComunas = mobjSql.s_comunas_todos
        Catch ex As Exception
            EnviaError("cCursoInterno:Inicializar0---->" & ex.Message)
        End Try
        
    End Sub



    'Inicializar1: Inicializa el objeto Curso Interno leyendo el codigo de un
    'curso existente en la Base de Datos. Retona True si el curso existe en la
    'BD y False si no existe
    Public Function Inicializar1(ByVal Correlativo As Long, _
                                 ByVal intAgno As Integer) As Boolean
        Try
            'inicializar todas las variables
            Initializa()

            Dim dtTemporal As DataTable
            Dim dtRegion As DataTable
            Dim varAuxiliar As Long
            Dim tam1_arrTemp, tam2_arrTemp As Integer
            Dim existe_curso As Boolean
           


            dtTemporal = mobjSql.s_curso_interno(Correlativo, intAgno)

            mcolAlumnos = New Collection
            mlngNumAlumnos = mobjSql.s_nro_participantes_interno(Correlativo, intAgno)

            
           

            tam1_arrTemp = mobjSql.Registros 

            If tam1_arrTemp = 0 Then
                existe_curso = False
            Else
                mlngCorrelativo = Correlativo
                mlngRutCliente = dtTemporal.Rows(0)(0)
                mstrDireccionCurso = dtTemporal.Rows(0)(1)
                mlngCodComuna = dtTemporal.Rows(0)(2) '(2, 0)
                mdtmFechaInicio = dtTemporal.Rows(0)(3) '(3, 0)
                mdtmFechaTermino = dtTemporal.Rows(0)(4) '(4, 0)
                mlngValorCurso = dtTemporal.Rows(0)(5) '('5, 0)
                mlngDescuento = dtTemporal.Rows(0)(6) '(6, 0)
                mintCodEstadoCurso = dtTemporal.Rows(0)(8)   '(8, 0)
                mintAgno = dtTemporal.Rows(0)(9) '(9, 0)
                mintIndDescPorc = dtTemporal.Rows(0)(10) '(10, 0)
                mstrCorrEmpresa = dtTemporal.Rows(0)(11) '(11, 0)
                mstrObservacion = dtTemporal.Rows(0)(12) '(12, 0)
                mstrNombreCurso = dtTemporal.Rows(0)(13) '(13, 0)
                mstrEjecutor = dtTemporal.Rows(0)(14) '(14, 0)  
                mstrHorario = dtTemporal.Rows(0)(15) '(15, 0)
                mintHoras = dtTemporal.Rows(0)(16) '(16, 0)
                mlngNumAlumnos = dtTemporal.Rows(0)(17) '(16, 0)

                varAuxiliar = mobjSql.s_cliente_nroperfil(mlngRutCliente, mlngRutUsuario)
                If Not IsDBNull(varAuxiliar) Then
                    mlngNroPerfil = mobjSql.s_cliente_nroperfil(mlngRutCliente, mlngRutUsuario)
                Else
                    mlngNroPerfil = 0
                End If

                dtRegion = mobjSql.s_region(mlngCodComuna)
                mlngCodRegion = dtRegion.Rows(0)(0) '(0, 0)
                mstrNomRegion = dtRegion.Rows(0)(1) '(1, 0)

                mdtParticipantes = mobjSql.s_partic_curso_interno3(Correlativo, intAgno)
                If mobjSql.Registros > 0 Then
                    Dim dr As DataRow
                    For Each dr In mdtParticipantes.Rows
                        mlngTotalVyT = mlngTotalVyT + dr("total_vyt")
                    Next
                End If

                existe_curso = True
            End If

           

            Dim blnInicCliente As Boolean
            mobjCliente = New CCliente
            mobjCliente.Agno = mintAgno
            mobjCliente.Inicializar0(mobjSql, mlngRutUsuario)
            blnInicCliente = mobjCliente.Inicializar1(RutLngAUsr(mlngRutCliente))

            If Not blnInicCliente Then
                Inicializar1 = False
                Exit Function
            End If

            mstrNombreCliente = mobjSql.s_nombre_cliente(mlngRutCliente)

            Inicializar1 = existe_curso

            Exit Function
        Catch ex As Exception
            EnviaError("cCursoInterno:Inicializar1 ------> " & ex.Message)
        End Try

    End Function

    'Inicializar2: Inicializa el objeto CursoInterno
    Public Sub Inicializar2(ByVal strRutCliente As String, _
                            ByVal lngParticipantes As Long, _
                            ByVal strDireccionCurso As String, _
                            ByVal lngCodComuna As Long, _
                            ByVal dtmFechaInicio As String, _
                            ByVal dtmFechaTermino As String, _
                            ByVal lngValorCurso As Long, _
                            ByVal lngDescuento As Long, _
                            ByVal strCorrEmpresa As String, _
                            ByVal intIndDescPorc As Integer, _
                            ByVal strObservacion As String, _
                            ByVal intAgno As Integer, _
                            ByVal strNombreCurso As String, _
                            ByVal strEjecutor As String, _
                            ByVal strHorario As String, _
                            ByVal intHoras As Integer)
        Try
            Dim dtRegion As DataTable
            mlngRutCliente = RutUsrALng(strRutCliente)
            mlngNumAlumnos = lngParticipantes
            mstrDireccionCurso = strDireccionCurso
            mlngCodComuna = lngCodComuna
            mdtmFechaInicio = FechaUsrAVb(dtmFechaInicio)
            mdtmFechaTermino = FechaUsrAVb(dtmFechaTermino)
            mlngValorCurso = lngValorCurso
            mlngDescuento = lngDescuento
            mstrCorrEmpresa = strCorrEmpresa
            mstrObservacion = strObservacion
            mintIndDescPorc = intIndDescPorc
            mstrNombreCurso = strNombreCurso
            mstrEjecutor = strEjecutor
            mstrHorario = strHorario
            mintHoras = intHoras
            dtRegion = mobjSql.s_region(mlngCodComuna)
            mlngCodRegion = dtRegion.Rows(0)(0) '(0, 0)
            mstrNomRegion = dtRegion.Rows(0)(1) '(1, 0)
            If intAgno = 0 Then
                mintAgno = Year(mdtmFechaInicio)
            Else
                mintAgno = intAgno
            End If


            Dim blnInicCliente As Boolean
            mobjCliente = New CCliente
            Call mobjCliente.Inicializar0(mobjSql, mlngRutUsuario)
            mobjCliente.Agno = intAgno
            blnInicCliente = mobjCliente.Inicializar1(RutLngAUsr(mlngRutCliente))
            If Not blnInicCliente Then
                EnviaError("cCursoInterno:Inicilizar2 - ERROR: Cliente Mal Inicializado")
                Exit Sub
            End If
            'Estos son los valores que despues se deben llenar en la
            'construccion de los diferentes objetos. Por ahora se les
            'dan valores constantes.

            If mlngCorrelativo = 0 Then
                mintCodEstadoCurso = 1      '0 corresponde al estado "Incompleto" del curso
            End If
            Exit Sub
        Catch ex As Exception
            EnviaError("cCursoInterno:Inicializar2 ----->" & ex.Message)
        End Try
    End Sub

  
    Private Sub Terminate()

        mlngRutCliente = 0
        mlngNumAlumnos = 0
        mstrDireccionCurso = ""
        mlngCodComuna = 0
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaTermino = FechaMaxSistema()
        mlngValorCurso = 0
        mlngDescuento = 0
        mlngCorrelativo = 0
        mintCodEstadoCurso = 0
        mintAgno = 0
        mintIndDescPorc = 0
        mstrCorrEmpresa = ""
        mlngCodRegion = 0
        mstrNomRegion = ""
        mintHoras = 0
        mcolAlumnos = New Collection
        mobjCliente = Nothing

    End Sub


    Private Sub Initializa()

        mlngRutCliente = 0
        mlngNumAlumnos = 0
        mstrDireccionCurso = ""
        mlngCodComuna = 0
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaTermino = FechaMaxSistema()
        mlngValorCurso = 0
        mlngDescuento = 0
        mlngCorrelativo = 0
        mintCodEstadoCurso = 0
        mintAgno = 0
        mintIndDescPorc = 0
        mstrCorrEmpresa = ""
        mlngCodRegion = 0
        mstrNomRegion = ""
        mcolAlumnos = New Collection
        mobjCliente = Nothing
        'mlngRutUsuario = 0
        mstrNombreCurso = ""
        mlngNroPerfil = 0
        mstrEjecutor = ""
        mstrHorario = ""
        mdtComunas = New DataTable
        mstrObservacion = ""
        mintHoras = 0

    End Sub

    Public Function GrabarDatos() As Boolean

        Try
            Dim dtCorrelativo As DataTable
            Dim aux As Long
            'abrir conexion y transaccion
            ' Call mobjSql.InicioTransaccion()

            mlngCorrelativo = mobjSql.i_curso_interno(mlngRutCliente, _
                                        mintCodEstadoCurso, _
                                         mlngNumAlumnos, _
                                         mstrDireccionCurso, _
                                         mlngCodComuna, _
                                         mdtmFechaInicio, _
                                         mdtmFechaTermino, _
                                         mlngValorCurso, _
                                         mlngDescuento, _
                                         mstrCorrEmpresa, _
                                         mintIndDescPorc, _
                                         mstrObservacion, _
                                         mintAgno, _
                                         mstrNombreCurso, _
                                         mstrEjecutor, _
                                         mstrHorario, _
                                         mintHoras, mlngTotalViatico, mlngTotalTraslado)

            dtCorrelativo = mobjSql.s_correlativo_curso_interno_max_ano2(mintAgno)

            If mobjSql.Registros = 0 Then
                aux = -1
            ElseIf mobjSql.Registros = 1 Then
                aux = dtCorrelativo.Rows(0)(0)
                mlngCorrelativo = CLng(aux)
            ElseIf mobjSql.Registros > 1 Then
                aux = -1
            End If

            Call mobjSql.i_bitacora(mlngRutUsuario, "Ingresado", _
                                "Ingreso del Encabezado del Curso Interno. Cliente: " & RutLngAUsr(mlngRutCliente), _
                                6, mlngCorrelativo)
            'cerrar transacción y conexion
            'mobjSql.FinTransaccion()
            GrabarDatos = True
            Exit Function
        Catch ex As Exception

            EnviaError("cCursoInterno:GrabarDatos -----> " & ex.Message)
        End Try

    End Function



    Public Function ObtenerAlumnos(Optional ByVal dblRutAlumno As Double = 0) As Object
        Try
            Dim i, intTamArrAls, intTamArrRuts As Integer
            Dim r_inic As Boolean
            Dim dtTemporal As New DataTable
            Dim dtRutAlumnos As New DataTable
            dtRutAlumnos = mobjSql.s_rut_partic_interno(mlngCorrelativo, mintAgno, dblRutAlumno)
            If mobjSql.Registros > 0 Then
                mcolAlumnos = New Collection
                Dim dr As DataRow
                For Each dr In dtRutAlumnos.Rows
                    Dim objCalumno As New CAlumnoInterno
                    Dim strRut As String
                    objCalumno.Inicializar0(mobjSql)
                    objCalumno.CorrelativoCurso = mlngCorrelativo
                    objCalumno.Agno = mintAgno
                    objCalumno.RutEmpresa = mlngRutCliente
                    strRut = RutLngAUsr(dr.Item(0))
                    objCalumno.Inicializar(strRut)
                    mcolAlumnos.Add(objCalumno)
                Next
            End If
            ObtenerAlumnos = mcolAlumnos
        Catch ex As Exception
            EnviaError("cCursoInterno:ObtenerAlumnos ---->" & ex.Message)
        End Try
    End Function

    Public Sub CambiaEstadoAnulado()
        mobjSql = New CSql
        Dim strEstadoCurso, strGlosa As String
        Call mobjSql.u_cambio_estado_curso_interno(mlngCorrelativo, mintAgno, 2)
        'If mintCodEstadoCurso = 1 Then
        'strEstadoCurso = "Ingresado"
        'ElseIf mintCodEstadoCurso = 2 Then
        strEstadoCurso = "Anulado"
        'End If

        Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, _
                            "Cambio al estado Anulado del Curso. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ".", _
                            6, mlngCorrelativo)
    End Sub
    Public Sub CambiaEstadoCerrado()
        mobjSql = New CSql
        Dim strEstadoCurso, strGlosa As String
        Call mobjSql.u_cambio_estado_curso_interno(mlngCorrelativo, mintAgno, 3)
        'If mintCodEstadoCurso = 1 Then
        'strEstadoCurso = "Ingresado"
        'ElseIf mintCodEstadoCurso = 2 Then
        strEstadoCurso = "Cerrado"
        'End If

        Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, _
                            "Cambio al estado Cerrado del Curso. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ".", _
                            6, mlngCorrelativo)
    End Sub
    Public Sub CambiaEstadoIngresado()
        mobjSql = New CSql
        Dim strEstadoCurso, strGlosa As String
        Call mobjSql.u_cambio_estado_curso_interno(mlngCorrelativo, mintAgno, 1)
        'If mintCodEstadoCurso = 1 Then
        strEstadoCurso = "Ingresado"
        'ElseIf mintCodEstadoCurso = 2 Then
        'strEstadoCurso = "Anulado"
        'End If

        Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, _
                            "Cambio al estado Ingresado del Curso. Cliente: " _
                            & RutLngAUsr(mlngRutCliente) & ".", _
                            6, mlngCorrelativo)
    End Sub


    'actualiza los datos en la base
    Public Function ActualizarDatos(ByVal intCasoBitacora As Integer) As Boolean

        Try
            Dim strEstadoCurso, strGlosa As String

            If mintCodEstadoCurso = 1 Then
                strEstadoCurso = "Ingresado"
            ElseIf mintCodEstadoCurso = 2 Then
                strEstadoCurso = "Anulado"
            ElseIf mintCodEstadoCurso = 3 Then
                strEstadoCurso = "Cerrado"
            End If
            'abrir conexion y transaccion
            'Call mobjSql.InicioTransaccion()

            mobjSql.u_curso_interno(mlngCorrelativo, _
                                         mlngRutCliente, _
                                         mlngNumAlumnos, _
                                         mstrDireccionCurso, _
                                         mlngCodComuna, _
                                         mdtmFechaInicio, _
                                         mdtmFechaTermino, _
                                         mlngValorCurso, _
                                         mlngDescuento, _
                                         mstrCorrEmpresa, _
                                         mintIndDescPorc, _
                                         mstrObservacion, _
                                         mintAgno, _
                                         mstrNombreCurso, _
                                         mstrEjecutor, _
                                         mstrHorario, _
                                         mintHoras, _
                                         mlngTotalViatico, _
                                         mlngTotalTraslado)


            Select Case intCasoBitacora
                Case 0          'No se escribe en la bitacora
                    strGlosa = ""
                Case 1          'Se actualizan los datos de encabezado del curso
                    strGlosa = "Actualizacion de los datos del Curso Interno. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 2          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de los Alumnos del Curso Interno. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 3          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso/Modif de asistencia. Cliente: " & RutLngAUsr(mlngRutCliente)
                Case 4          'Se actualizan los datos luego de ingresar los alumnos
                    strGlosa = "Ingreso de Nro de registro por liquidación de Curso Parcial. Cliente: " & RutLngAUsr(mlngRutCliente)
            End Select

            If intCasoBitacora > 0 Then
                Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, strGlosa, 6, mlngCorrelativo)
            End If

            'cerrar transacción y conexion
            'mobjSql.FinTransaccion()


            ActualizarDatos = True
            Exit Function


            'ActualizarDatos = False
            'Call mobjSql.RollBackTransaccion()
        Catch ex As Exception
            EnviaError("cCursoInterno:ActualizarDatos ----->" & ex.Message)
        End Try


    End Function

    Public Sub InicializarNuevo()
        mlngRutCliente = 0
        mlngNumAlumnos = 0
        mstrDireccionCurso = ""
        mlngCodComuna = 0
        mdtmFechaInicio = FechaMinSistema
        mdtmFechaTermino = FechaMaxSistema
        mlngValorCurso = 0
        mlngDescuento = 0
        mlngCorrelativo = 0
        mintCodEstadoCurso = 0
        mintAgno = 0
        mintIndDescPorc = 0
        mstrCorrEmpresa = ""
        mlngCodRegion = 0
        mstrNomRegion = ""
        mcolAlumnos = New Collection
        mobjCliente = Nothing
        'mlngRutUsuario = 0
        mstrNombreCurso = ""
        mlngNroPerfil = 0
        mstrEjecutor = ""
        mstrHorario = ""
        mstrObservacion = ""
        mintHoras = 0
    End Sub
    'función para grabar la asistencia de alumnos
    'Public Sub GrabarAlumnos()

    '    Try
    '        Dim i, tamanoAlumno, tam_arrtemp1, tam_arrtemp2 As Integer
    '        Dim dtTemporal As DataTable
    '        Dim dig_verif As String
    '        Dim tipo_pers, strEstadoCurso As String

    '        tamanoAlumno = mcolAlumnos.Count 'TamanoArreglo1(mcolAlumnos)

    '        ''abrir transacción
    '        'Call mobjSql.InicioTransaccion()
    '        mobjSql.d_participante_interno_todos(mlngCorrelativo, mintAgno)
    '        For i = 0 To (tamanoAlumno - 1)
    '            If Not IsDBNull(mcolAlumnos.Item(i + 1)) And Not IsNothing(mcolAlumnos.Item(i + 1)) Then
    '                dtTemporal = mobjSql.s_persona(RutUsrALng(mcolAlumnos.Item(i + 1).Rut))

    '                If mobjSql.Registros = 0 Then
    '                    dig_verif = digito_verificador(RutUsrALng(mcolAlumnos.Item(i + 1).Rut))
    '                    tipo_pers = "N"
    '                    Call mobjSql.i_Persona(RutUsrALng(mcolAlumnos.Item(i + 1).Rut), dig_verif, tipo_pers)
    '                End If

    '                dtTemporal = New DataTable
    '                dtTemporal = mobjSql.s_pers_nat(RutUsrALng(mcolAlumnos.Item(i + 1).Rut))

    '                If mobjSql.Registros <> 0 Then
    '                    mobjSql.u_pers_nat_interno(RutUsrALng(mcolAlumnos.Item(i + 1).Rut), mcolAlumnos.Item(i + 1).ApPaterno, _
    '                                                    mcolAlumnos.Item(i + 1).ApMaterno, mcolAlumnos.Item(i + 1).Nombres, _
    '                                                    mcolAlumnos.Item(i + 1).Sexo, _
    '                                                    mlngRutCliente)
    '                Else
    '                    mobjSql.i_PersonaNatural(RutUsrALng(mcolAlumnos.Item(i + 1).Rut), mcolAlumnos.Item(i + 1).ApPaterno, _
    '                                                  mcolAlumnos.Item(i + 1).ApMaterno, mcolAlumnos.Item(i + 1).Nombres, _
    '                                                  "01/01/1900", mcolAlumnos.Item(i + 1).Sexo, _
    '                                                  100, 3, 2, 13, mlngRutCliente, 132101)
    '                End If

    '                dtTemporal = New DataTable
    '                dtTemporal = mobjSql.s_partic_curso_interno(mlngCorrelativo, mintAgno, RutUsrALng(mcolAlumnos.Item(i + 1).Rut))
    '                'dtTemporal = mobjSql.s_partic_curso_interno2(mlngCorrelativo, mintAgno, RutUsrALng(mcolAlumnos(i + 1).Rut))

    '                'tam_arrtemp1 = TamanoArreglo1(dtTemporal)
    '                'tam_arrtemp2 = TamanoArreglo2(dtTemporal)

    '                If mobjSql.Registros <> 0 Then
    '                    'nada
    '                    Call mobjSql.u_participante_interno(mlngCorrelativo, mstrObservacion, mintAgno, RutUsrALng(mcolAlumnos.Item(i + 1).Rut), _
    '                                                        mcolAlumnos.Item(i + 1).Viatico, mcolAlumnos.Item(i + 1).Traslado, _
    '                                                        mcolAlumnos.Item(i + 1).Aprobado)
    '                Else
    '                    mobjSql.i_participante_interno(mlngCorrelativo, mintAgno, RutUsrALng(mcolAlumnos.Item(i + 1).Rut), _
    '                                                        mcolAlumnos.Item(i + 1).Viatico, mcolAlumnos.Item(i + 1).Traslado, _
    '                                                         mcolAlumnos.Item(i + 1).Aprobado)
    '                End If
    '            End If

    '        Next
    '        'commit
    '        'mobjSql.FinTransaccion()

    '        Exit Sub
    '    Catch ex As Exception
    '        'mobjSql.RollBackTransaccion()
    '        EnviaError("cCursoInterno:GrabarAlumnos ---->" & ex.Message)
    '    End Try
    'End Sub
    Public Sub GrabarAlumnos()

        Try
            Dim i, tamanoAlumno, tam_arrtemp1, tam_arrtemp2 As Integer
            Dim dtTemporal As DataTable
            Dim dig_verif As String
            Dim tipo_pers, strEstadoCurso As String
           

            tamanoAlumno = mcolAlumnos.Count 'TamanoArreglo1(mcolAlumnos)

            ''abrir transacción
            'Call mobjSql.InicioTransaccion()
            mobjSql.d_participante_interno_todos(mlngCorrelativo, mintAgno)
            For i = 0 To (tamanoAlumno - 1)
                If Not IsDBNull(mcolAlumnos.Item(i + 1)) And Not IsNothing(mcolAlumnos.Item(i + 1)) Then
                    dtTemporal = mobjSql.s_persona(mcolAlumnos.Item(i + 1).Rut)

                    If mobjSql.Registros = 0 Then
                        dig_verif = digito_verificador(mcolAlumnos.Item(i + 1).Rut)
                        tipo_pers = "N"
                        Call mobjSql.i_Persona(mcolAlumnos.Item(i + 1).Rut, dig_verif, tipo_pers)
                    End If

                    dtTemporal = New DataTable
                    dtTemporal = mobjSql.s_pers_nat(mcolAlumnos.Item(i + 1).Rut)

                    If mobjSql.Registros <> 0 Then
                        mobjSql.u_pers_nat_interno(mcolAlumnos.Item(i + 1).Rut, mcolAlumnos.Item(i + 1).ApPaterno, _
                                                        mcolAlumnos.Item(i + 1).ApMaterno, mcolAlumnos.Item(i + 1).Nombres, _
                                                        mcolAlumnos.Item(i + 1).Sexo, _
                                                        mlngRutCliente)
                    Else
                        mobjSql.i_PersonaNatural(mcolAlumnos.Item(i + 1).Rut, mcolAlumnos.Item(i + 1).ApPaterno, _
                                                      mcolAlumnos.Item(i + 1).ApMaterno, mcolAlumnos.Item(i + 1).Nombres, _
                                                      "01/01/1900", mcolAlumnos.Item(i + 1).Sexo, _
                                                      100, 3, 2, 13, mlngRutCliente, 132101, 1, "", "")
                    End If

                    dtTemporal = New DataTable
                    dtTemporal = mobjSql.s_partic_curso_interno(mlngCorrelativo, mintAgno, mcolAlumnos.Item(i + 1).Rut)
                    'dtTemporal = mobjSql.s_partic_curso_interno2(mlngCorrelativo, mintAgno, RutUsrALng(mcolAlumnos(i + 1).Rut))

                    'tam_arrtemp1 = TamanoArreglo1(dtTemporal)
                    'tam_arrtemp2 = TamanoArreglo2(dtTemporal)

                    If mobjSql.Registros <> 0 Then
                        'nada
                        Call mobjSql.u_participante_interno(mlngCorrelativo, mstrObservacion, mintAgno, mcolAlumnos.Item(i + 1).Rut, _
                                                            mcolAlumnos.Item(i + 1).Viatico, mcolAlumnos.Item(i + 1).Traslado, _
                                                            mcolAlumnos.Item(i + 1).Aprobado)
                    Else
                        mobjSql.i_participante_interno(mlngCorrelativo, mintAgno, mcolAlumnos.Item(i + 1).Rut, _
                                                            mcolAlumnos.Item(i + 1).Viatico, mcolAlumnos.Item(i + 1).Traslado, _
                                                             mcolAlumnos.Item(i + 1).Aprobado)
                    End If
                End If

            Next

            If mintCodEstadoCurso = 1 Then
                strEstadoCurso = "Ingresado"
            ElseIf mintCodEstadoCurso = 2 Then
                strEstadoCurso = "Anulado"
            ElseIf mintCodEstadoCurso = 3 Then
                strEstadoCurso = "Cerrado"
            End If

            Call mobjSql.i_bitacora(mlngRutUsuario, strEstadoCurso, _
                                "Ingreso/Actualización de datos de los Alumnos del Curso. Cliente: " _
                                & RutLngAUsr(mlngRutCliente) & ".", _
                                6, mlngCorrelativo)
            'commit
            'mobjSql.FinTransaccion()

            Exit Sub
        Catch ex As Exception
            'mobjSql.RollBackTransaccion()
            EnviaError("cCursoInterno:GrabarAlumnos ---->" & ex.Message)
        End Try
    End Sub
    'reinicialización del curso
    Function ReInicializar() As Boolean
        Try
            ReInicializar = Inicializar1(mlngCorrelativo, mintAgno)
        Catch ex As Exception
            EnviaError("cCursoContratado:ReInicializar-->" & ex.Message)
        End Try

    End Function
    Public Function ConsultarListado() As DataTable
        Try
            Dim dtAlumnosInterno As New DataTable
            dtAlumnosInterno = mobjSql.s_alumno_curso_interno(mlngCodCurso, mlngRutCliente, mintAgno)
            dtAlumnosInterno.Columns.Add("nombre_completo_")
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtAlumnosInterno.Rows
                    dr("nombre_completo_") = dr("nombre") & " " & dr("ap_paterno") & " " & dr("ap_materno")
                Next
            End If
            Return dtAlumnosInterno
        Catch ex As Exception
            EnviaError("cCursoContratado:ConsultarListado-->" & ex.Message)
        End Try
        
    End Function
    Public Function ConsultarEstadoAlumnos() As Boolean
        Try
            Dim dtAlumnosInterno As New DataTable
            mobjSql = New CSql
            dtAlumnosInterno = mobjSql.s_estado_alumno_curso_interno(mlngCorrelativo, mintAgno)
            If mobjSql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dtAlumnosInterno.Rows
                    If (dr("cod_estado_part") = 1 Or dr("cod_estado_part") = 2) Then
                        ConsultarEstadoAlumnos = True
                    Else
                        ConsultarEstadoAlumnos = False
                        Exit Function
                    End If
                Next
            End If
        Catch ex As Exception
            EnviaError("cCursoContratado:ConsultarEstadoAlumnos-->" & ex.Message)
        End Try
        
    End Function
  

End Class
