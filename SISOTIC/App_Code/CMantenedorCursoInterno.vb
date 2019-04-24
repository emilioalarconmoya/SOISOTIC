Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorCursoInterno
    Implements IMantenedor
    Private mobjCsql As CSql
    Private mobjCursoInterno As CCursoInterno
    Private mlngRutUsuario As Long
    Private mlngCodCurso As Long
    Private mstrModo As String
    Public WriteOnly Property RutUsuario() As Long
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property CodCurso() As Long
        Get
            CodCurso = mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
        End Set
    End Property
    Public Property Modo() As String
        Get
            Modo = mstrModo
        End Get
        Set(ByVal value As String)
            mstrModo = value
        End Set
    End Property
#Region "PopUpEmpresas"
    Private mlngEmpresasRut As Long
    Private mstrEmpresasRazonSocial As String
    Private mdtEmpresas As DataTable
    Public WriteOnly Property EmpresasRut() As Long
        Set(ByVal value As Long)
            mlngEmpresasRut = value
        End Set
    End Property
    Public WriteOnly Property EmpresasRazonSocial() As String
        Set(ByVal value As String)
            mstrEmpresasRazonSocial = value
        End Set
    End Property
    Public ReadOnly Property EmpresasListado() As DataTable
        Get
            EmpresasListado = mdtEmpresas
        End Get
    End Property
    Public Sub inicializarPopUpEmpresas()
        mlngEmpresasRut = gValorNumNulo
        mstrEmpresasRazonSocial = ""
        mdtEmpresas = New DataTable
        mdtEmpresas.Columns.Add("rut")
        mdtEmpresas.Columns.Add("razon_social")
        mdtEmpresas.Columns.Add("nombre_contacto")
        mdtEmpresas.Columns.Add("fono_contacto")
    End Sub
    Public Sub ConsultarEmpresas()
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_clientes(mlngEmpresasRut, mstrEmpresasRazonSocial, mlngRutUsuario)
            If mobjCsql.Registros > 0 Then
                Dim dr As DataRow
                Dim drEmpresas As DataRow
                For Each dr In dt.Rows
                    drEmpresas = mdtEmpresas.NewRow
                    drEmpresas("rut") = RutLngAUsr(dr("rut"))
                    drEmpresas("razon_social") = dr("razon_social")
                    drEmpresas("nombre_contacto") = dr("nom_contacto")
                    drEmpresas("fono_contacto") = dr("fono_contacto")
                    mdtEmpresas.Rows.Add(drEmpresas)
                Next
            End If
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:ConsultarEmpresas-->" & ex.Message)
        End Try
    End Sub
#End Region
#Region "PopUpAlumnos"
    Private mlngAlumnosRut As Long
    Private mstrAlumnosNombres As String
    Private mstrAlumnosApellido As String
    Private mdtAlumnos As DataTable
    Public WriteOnly Property AlumnosRut() As Long
        Set(ByVal value As Long)
            mlngAlumnosRut = value
        End Set
    End Property
    Public WriteOnly Property AlumnosNombres() As String
        Set(ByVal value As String)
            mstrAlumnosNombres = value
        End Set
    End Property
    Public WriteOnly Property AlumnosApellido() As String
        Set(ByVal value As String)
            mstrAlumnosApellido = value
        End Set
    End Property
    Public ReadOnly Property AlumnosListado() As DataTable
        Get
            AlumnosListado = mdtAlumnos
        End Get
    End Property
    Public Sub inicializarPopUpAlumnos()
        mlngAlumnosRut = gValorNumNulo
        mstrAlumnosNombres = ""
        mstrAlumnosApellido = ""
        mdtAlumnos = New DataTable
        mdtAlumnos.Columns.Add("rut")
        mdtAlumnos.Columns.Add("nombres")
        mdtAlumnos.Columns.Add("apellido_paterno")
        mdtAlumnos.Columns.Add("apellido_materno")
    End Sub
    Public Sub ConsultarAlumnos()

    End Sub
#End Region
#Region "paso1"
    Private mlngRutEmpresa As Long
    Private mintCodEstadoCurso As Integer
    Private mlngCorrelativo As Long
    Private mintNumParticipantes As Integer
    Private mstrDireccion As String
    Private mstrComuna As String
    Private mintAgno As Integer
    Private mstrObservaciones As String
    Private mstrEjecutor As String
    Private mstrNombreCurso As String
    Private mstrHorario As String
    Private mintHoras As Integer
    Private mdtmFechaInicio As Date
    Private mdtmFechaFin As Date
    Private mlngValorCurso As Long
    Private mdblDescuento As Double
    Private mlngValorFinal As Long
    Private mstrCorrEmpresa As String
    Private mdblPorcAdmin As Double

    Public Property RutEmpresa() As Long
        Get
            RutEmpresa = mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property
    Public Property Correlativo() As Long
        Get
            Correlativo = mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    'Public Property TipoActividad() As Integer
    '    Get
    '        TipoActividad = mintTipoActividad
    '    End Get
    '    Set(ByVal value As Integer)
    '        mintTipoActividad = value
    '    End Set
    'End Property
    'Public Property ComBipartito() As Boolean
    '    Get
    '        ComBipartito = mbolComBipartito
    '    End Get
    '    Set(ByVal value As Boolean)
    '        mbolComBipartito = value
    '    End Set
    'End Property
    'Public Property DetNecesidades() As Boolean
    '    Get
    '        DetNecesidades = mbolDetNecesidades
    '    End Get
    '    Set(ByVal value As Boolean)
    '        mbolDetNecesidades = value
    '    End Set
    'End Property
    Public Property NumParticipantes() As Integer
        Get
            NumParticipantes = mintNumParticipantes
        End Get
        Set(ByVal value As Integer)
            mintNumParticipantes = value
        End Set
    End Property
    Public Property CodEstadoCurso() As Integer
        Get
            CodEstadoCurso = mintCodEstadoCurso
        End Get
        Set(ByVal value As Integer)
            mintCodEstadoCurso = value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Direccion = mstrDireccion
        End Get
        Set(ByVal value As String)
            mstrDireccion = value
        End Set
    End Property
    'Public Property NumDireccion() As String
    '    Get
    '        NumDireccion = mstrNumDireccion
    '    End Get
    '    Set(ByVal value As String)
    '        mstrNumDireccion = value
    '    End Set
    'End Property
    'Public Property Ciudad() As String
    '    Get
    '        Ciudad = mstrCiudad
    '    End Get
    '    Set(ByVal value As String)
    '        mstrCiudad = value
    '    End Set
    'End Property
    Public Property Comuna() As String
        Get
            Comuna = mstrComuna
        End Get
        Set(ByVal value As String)
            mstrComuna = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Agno = mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Observaciones = mstrObservaciones
        End Get
        Set(ByVal value As String)
            mstrObservaciones = value
        End Set
    End Property
    Public Property Ejecutor() As String
        Get
            Ejecutor = mstrEjecutor
        End Get
        Set(ByVal value As String)
            mstrEjecutor = value
        End Set
    End Property
    Public Property NombreCurso() As String
        Get
            NombreCurso = mstrNombreCurso
        End Get
        Set(ByVal value As String)
            mstrNombreCurso = value
        End Set
    End Property
    Public Property Horario() As String
        Get
            Horario = mstrHorario
        End Get
        Set(ByVal value As String)
            mstrHorario = value
        End Set
    End Property
    Public Property Horas() As String
        Get
            Horas = mintHoras
        End Get
        Set(ByVal value As String)
            mintHoras = value
        End Set
    End Property

    'Public Property Modalidad() As Integer
    '    Get
    '        Modalidad = mintModalidad
    '    End Get
    '    Set(ByVal value As Integer)
    '        mintModalidad = value
    '    End Set
    'End Property
    'Public Property CodSence() As String
    '    Get
    '        CodSence = mstrCodSence
    '    End Get
    '    Set(ByVal value As String)
    '        mstrCodSence = value
    '    End Set
    'End Property
    Public Property FechaInicio() As Date
        Get
            FechaInicio = mdtmFechaInicio
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = value
        End Set
    End Property
    Public Property FechaFin() As Date
        Get
            FechaFin = mdtmFechaFin
        End Get
        Set(ByVal value As Date)
            mdtmFechaFin = value
        End Set
    End Property
    'Public Property HorasComp() As Integer
    '    Get
    '        HorasComp = mintHorasComp
    '    End Get
    '    Set(ByVal value As Integer)
    '        mintHorasComp = value
    '    End Set
    'End Property
    Public Property ValorCurso() As Long
        Get
            ValorCurso = mlngValorCurso
        End Get
        Set(ByVal value As Long)
            mlngValorCurso = value
        End Set
    End Property
    Public Property Descuento() As Double
        Get
            Descuento = mdblDescuento
        End Get
        Set(ByVal value As Double)
            mdblDescuento = value
        End Set
    End Property
    Public Property ValorFinal() As Long
        Get
            ValorFinal = mlngValorFinal
        End Get
        Set(ByVal value As Long)
            mlngValorFinal = value
        End Set
    End Property
    Public Property CorrEmpresa() As String
        Get
            CorrEmpresa = mstrCorrEmpresa
        End Get
        Set(ByVal value As String)
            mstrCorrEmpresa = value
        End Set
    End Property
    'Public Property ContactoAdicional() As String
    '    Get
    '        ContactoAdicional = mstrContactoAdicional
    '    End Get
    '    Set(ByVal value As String)
    '        mstrContactoAdicional = value
    '    End Set
    'End Property
    Public Property PorcAdmin() As Double
        Get
            PorcAdmin = mdblPorcAdmin
        End Get
        Set(ByVal value As Double)
            mdblPorcAdmin = value
        End Set
    End Property
    Public Sub inicializarPaso1()
        mlngRutEmpresa = gValorNumNulo
        mintNumParticipantes = gValorNumNulo
        mintCodEstadoCurso = 1
        mstrDireccion = ""
        mstrComuna = ""
        mintAgno = gValorNumNulo
        mstrObservaciones = ""
        mstrEjecutor = ""
        mstrNombreCurso = ""
        mstrHorario = ""
        mintHoras = gValorNumNulo
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaFin = FechaMinSistema()
        mlngValorCurso = gValorNumNulo
        mdblDescuento = 0.0
        mlngValorFinal = gValorNumNulo
        mstrCorrEmpresa = ""
        mdblPorcAdmin = 0.0
        mlngCorrelativo = 0
    End Sub
    Public Function ExisteEmpresa(ByVal RutEmpresa As Long) As Boolean
        Try
            mobjCsql = New CSql
            ExisteEmpresa = mobjCsql.ExisteRegistro(RutEmpresa, "empresa_cliente", "rut")
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursosInterno.vb:ExisteEmpresa-->" & ex.Message)
        End Try
    End Function
    Public Sub NombreEmpresa(ByVal RutEmpresa As Long)
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_nombre_empresa(RutEmpresa)
            If mobjCsql.Registros > 0 Then
                Me.mstrEmpresasRazonSocial = dt.Rows(0).Item(1).ToString
                'Me.mstrEmpresa = dt.Rows(0).Item(1).ToString
            End If
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursosInterno.vb:NombreEmpresa-->" & ex.Message)
        End Try
    End Sub
    'Public Sub DatosCurso(ByVal CodSence As String)
    '    Try
    '        mobjCsql = New CSql
    '        Dim dt As New DataTable
    '        dt = mobjCsql.s_datos_curso(CodSence)
    '        If mobjCsql.Registros > 0 Then
    '            Me.mstrCurso = dt.Rows(0).Item(1).ToString
    '            Me.mintHorasCurso = dt.Rows(0).Item(2).ToString
    '            Me.mstrOtec = dt.Rows(0).Item(4).ToString
    '        End If
    '        mobjCsql = Nothing
    '    Catch ex As Exception
    '        EnviaError("CMantenedorCursos.vb:DatosCurso-->" & ex.Message)
    '    End Try
    'End Sub
    Public Sub GrabarPaso1()
        Try
            mobjCursoInterno = New CCursoInterno
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCursoInterno.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCursoInterno.InicializarNuevo()
            mobjCursoInterno.RurUsuario = mlngRutUsuario
            mobjCursoInterno.RutCliente = mlngRutEmpresa
            mobjCursoInterno.CodEstadoCurso = mintCodestadoCurso
            mobjCursoInterno.NumAlumnos = mintNumParticipantes
            mobjCursoInterno.DireccionCurso = mstrDireccion
            mobjCursoInterno.CodComuna = mstrComuna
            mobjCursoInterno.FechaInicio = mdtmFechaInicio
            mobjCursoInterno.FechaTermino = mdtmFechaFin
            mobjCursoInterno.ValorCurso = mlngValorCurso
            mobjCursoInterno.Descuento = mdblDescuento
            mobjCursoInterno.Observacion = mstrObservaciones
            mobjCursoInterno.Agno = mintAgno
            mobjCursoInterno.NombreCurso = mstrNombreCurso
            mobjCursoInterno.Ejecutor = mstrEjecutor
            mobjCursoInterno.Horario = mstrHorario
            mobjCursoInterno.Horas = mintHoras
            mobjCursoInterno.ValorTotalCurso = mlngValorFinal
            mobjCursoInterno.CorrEmpresa = mstrCorrEmpresa
            mobjCursoInterno.Correlativo = mlngCorrelativo

            'mobjCursoInterno.IndDescPorc = mdblPorcAdmin
            
            If mstrModo = "insertar" Then
                mobjCursoInterno.GrabarDatos()
            ElseIf mstrModo = "actualizar" Then
                mobjCursoInterno.ActualizarDatos(1)
            End If
            'mobjCursoInterno.InicializarNuevo()
            mlngCorrelativo = mobjCursoInterno.Correlativo
            'mobjCursoInterno.ObtenerInfoCuentas()
            'mobjCursoInterno.CalcCostoAdm()
            CargaDatos()
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorCursoInterno.vb:GrabarPaso1-->" & ex.Message)
        End Try
    End Sub
    Public Sub InicializarCursoExistente()
        mobjCsql = New CSql
        mobjCursoInterno = New CCursoInterno
        mobjCursoInterno.Inicializar0(mobjCsql, mlngRutUsuario)
        mobjCursoInterno.Inicializar1(mlngCorrelativo, mintAgno)
        'mobjCursoInterno.ObtenerAlumnos()
        ' mobjCursoInterno.CalcCostoAdm()
        CargaDatos() '
        mobjCsql = Nothing
    End Sub
#End Region
#Region "paso2"
    Private mdtParticipantes As DataTable
    Public Property Participantes() As DataTable
        Get
            Participantes = mdtParticipantes
        End Get
        Set(ByVal value As DataTable)
            mdtParticipantes = value
        End Set
    End Property
    Public Sub inicializarPaso2()
        mdtParticipantes = New DataTable
        mdtParticipantes.Columns.Add("rut")
        mdtParticipantes.Columns.Add("nombres")
        mdtParticipantes.Columns.Add("apellido_paterno")
        mdtParticipantes.Columns.Add("apellido_materno")
        mdtParticipantes.Columns.Add("sexo")
        mdtParticipantes.Columns.Add("cod_region")
        mdtParticipantes.Columns.Add("region")
        mdtParticipantes.Columns.Add("cod_nivel_ocupacional")
        mdtParticipantes.Columns.Add("nivel_ocupacional")
        mdtParticipantes.Columns.Add("franquicia")
        mdtParticipantes.Columns.Add("viatico")
        mdtParticipantes.Columns.Add("traslado")
        mdtParticipantes.Columns.Add("cod_nivel_educacional")
        mdtParticipantes.Columns.Add("nivel_educacional")
        mdtParticipantes.Columns.Add("fecha_nacimiento")
        mdtParticipantes.Columns.Add("cod_comuna")
        mdtParticipantes.Columns.Add("comuna")
        mdtParticipantes.Columns.Add("existe")
        mdtParticipantes.Columns.Add("cod_estado_part")
    End Sub
    Public Sub ConsultaAlumno(ByVal mlngRutAlumno As Long)
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_alumno_interno(mlngRutAlumno)
            If mobjCsql.Registros > 0 Then
                dt.Rows(0).Item(0) = RutLngAUsr(dt.Rows(0).Item(0))
                dt.Rows(0).Item(17) = 1
                mdtParticipantes = dt
            Else
                Dim dr As DataRow
                dr = mdtParticipantes.NewRow
                dr("rut") = RutLngAUsr(mlngRutAlumno)
                dr("nombres") = ""
                dr("apellido_paterno") = ""
                dr("apellido_materno") = ""
                dr("sexo") = ""
                dr("cod_region") = ""
                dr("region") = ""
                dr("cod_nivel_ocupacional") = ""
                dr("nivel_ocupacional") = ""
                dr("franquicia") = ""
                dr("viatico") = 0
                dr("traslado") = 0
                dr("cod_nivel_educacional") = ""
                dr("nivel_educacional") = ""
                dr("fecha_nacimiento") = ""
                dr("cod_comuna") = ""
                dr("comuna") = ""
                dr("existe") = 0
                dr("cod_estado_part") = 3
                mdtParticipantes.Rows.Add(dr)
            End If
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursoInterno.vb:ConsultaAlumno-->" & ex.Message)
        End Try
    End Sub
    Public Sub EliminaAlumnoInterno(ByVal mlngRutAlumno As Long, ByVal mintAgno As Integer, ByVal mlngCorrelativo As Long)
        Try
            mobjCursoInterno = New CCursoInterno
        Catch ex As Exception
            EnviaError("CMantenedorCursoInterno.vb:EliminaAlumnoInterno-->" & ex.Message)
        End Try
    End Sub
    Public Sub GrabarPaso2()
        Try
            mobjCursoInterno = New CCursoInterno
            mobjCursoInterno.InicializarNuevo()
            Dim lngViatico As Long
            Dim lngTraslado As Long
            'mobjCursoContrantado.HorarioCurso = Me.mdtHorario
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCursoInterno.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCursoInterno.RurUsuario = mlngRutUsuario
            mobjCursoInterno.Correlativo = mlngCorrelativo
            mobjCursoInterno.Agno = mintAgno
            mobjCursoInterno.Inicializar1(mlngCorrelativo, mintAgno)
            mobjCsql.u_nro_alumno_curso_interno(mlngCorrelativo, mintAgno, mintNumParticipantes)
            If Not Me.mdtParticipantes Is Nothing Then
                If mdtParticipantes.Rows.Count > 0 Then
                    Dim dr As DataRow
                    Dim col As New Collection

                    For Each dr In mdtParticipantes.Rows
                        If dr("existe") = 0 Then
                            mobjCsql.i_Persona(RutUsrALng(dr("rut")), digito_verificador(RutUsrALng(dr("rut"))), "N")
                            mobjCsql.i_PersonaNatural(RutUsrALng(dr("rut")), dr("apellido_paterno"), _
                                                      dr("apellido_materno"), dr("nombres"), _
                                                      "01/01/1900", dr("sexo"), _
                                                      100, 3, 2, 13, mlngRutEmpresa, 132101, 1, "", "")
                            'mobjCsql.i_PersonaNatural(RutUsrALng(dr("rut")), dr("apellido_paterno"), _
                            '          dr("apellido_materno"), dr("nombres"), _
                            '          dr("fecha_nacimiento"), dr("sexo"), _
                            '          dr("franquicia"), dr("cod_nivel_ocupacional"), _
                            '          dr("cod_nivel_educacional"), dr("cod_region"), _
                            '          mlngRutEmpresa, dr("cod_comuna"))
                            'mobjCsql.i_participante_interno(mlngCorrelativo, mintAgno, RutUsrALng(dr("rut")), dr("viatico"), dr("traslado"))
                        ElseIf dr("existe") = 1 Then

                            'mobjCsql.i_participante_interno(mlngCorrelativo, mintAgno, RutUsrALng(dr("rut")))

                            mobjCsql.u_pers_nat_interno(RutUsrALng(dr("rut")), dr("apellido_paterno"), dr("apellido_materno"), dr("nombres"), dr("sexo"), mlngRutEmpresa)
                            mobjCsql.u_Persona(RutUsrALng(dr("rut")), digito_verificador(RutUsrALng(dr("rut"))), "N")
                            mobjCsql.u_PersonaNatural(RutUsrALng(dr("rut")), dr("apellido_paterno"), _
                                                      dr("apellido_materno"), dr("nombres"), _
                                                      "01/01/1900", dr("sexo"), _
                                                      100, 3, 2, 13, mlngRutEmpresa, 132101, 1, "", "")
                            'mobjCsql.u_PersonaNatural(RutUsrALng(dr("rut")), dr("apellido_paterno"), _
                            '          dr("apellido_materno"), dr("nombres"), _
                            '          dr("fecha_nacimiento"), dr("sexo"), _
                            '          dr("franquicia"), dr("cod_nivel_ocupacional"), _
                            '          dr("cod_nivel_educacional"), dr("cod_region"), _
                            '          mlngRutEmpresa, dr("cod_comuna"))
                            'mobjCsql.u_participante_interno(mlngCorrelativo, IIf(mstrObservaciones Is Nothing, "", mstrObservaciones), _
                            'mintAgno, RutUsrALng(dr("rut")), dr("viatico"), dr("traslado"))
                        End If
                        'If mstrModo = "insertar" Then
                        '    mobjCsql.i_participante_interno(mlngCorrelativo, mintAgno, RutUsrALng(dr("rut")))

                        'End If
                        Dim objAlumno As New CAlumnoInterno
                        objAlumno.Inicializar0(mobjCsql)
                        objAlumno.CorrelativoCurso = mlngCorrelativo
                        objAlumno.RutEmpresa = mlngRutEmpresa
                        objAlumno.PorcAsistencia = 0
                        objAlumno.Inicializar(dr("rut"))
                        objAlumno.Viatico = dr("viatico")
                        lngViatico = lngViatico + dr("viatico")
                        objAlumno.Traslado = dr("traslado")
                        lngTraslado = lngTraslado + dr("traslado")
                        objAlumno.Traslado = dr("traslado")
                        objAlumno.Aprobado = dr("cod_estado_part")
                        col.Add(objAlumno)
                    Next
                    mobjCursoInterno.Alumnos = col
                End If
            End If
            mobjCursoInterno.RutCliente = mlngRutEmpresa
            mobjCursoInterno.GrabarAlumnos()
            mobjCursoInterno.TotalViatico = lngViatico
            mobjCursoInterno.TotalTraslado = lngTraslado
            mobjCursoInterno.NumAlumnos = mintNumParticipantes
            mobjCursoInterno.ValorCurso = mlngValorFinal
            mobjCursoInterno.ActualizarDatos(2)
            mobjCursoInterno.ReInicializar()
            ' mobjCursoInterno.ObtenerInfoCuentas()
            'mobjCursoInterno.CalcCostoAdm()
            CargaDatos()
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorCursoInterno.vb:GrabarPaso2-->" & ex.Message)
        End Try
    End Sub
#End Region
    Public Sub CargaDatos()
        '************  PASO 1 /*********
        mlngRutEmpresa = mobjCursoInterno.RutCliente
        mintCodestadoCurso = mobjCursoInterno.CodEstadoCurso
        mintNumParticipantes = mobjCursoInterno.NumAlumnos
        mstrDireccion = mobjCursoInterno.DireccionCurso
        mstrComuna = mobjCursoInterno.CodComuna
        mintAgno = mobjCursoInterno.Agno
        mstrObservaciones = mobjCursoInterno.Observacion
        mstrEjecutor = mobjCursoInterno.Ejecutor
        mstrNombreCurso = mobjCursoInterno.NombreCurso
        mstrHorario = mobjCursoInterno.Horario
        mintHoras = mobjCursoInterno.Horas
        mdtmFechaInicio = mobjCursoInterno.FechaInicio
        mdtmFechaFin = mobjCursoInterno.FechaTermino
        mlngValorCurso = mobjCursoInterno.ValorCurso
        mdblDescuento = mobjCursoInterno.Descuento
        mlngValorFinal = mobjCursoInterno.ValorTotalCurso
        mstrCorrEmpresa = mobjCursoInterno.CorrEmpresa
        mlngCorrelativo = mobjCursoInterno.Correlativo
        mdblPorcAdmin = mobjCursoInterno.IndDescPorc

        '¡ ************  PASO 2 ***************
        inicializarPaso2()
        mobjCursoInterno.ObtenerAlumnos()
        Dim col As New Collection
        col = mobjCursoInterno.Alumnos
        If col.Count > 0 Then
            Dim i As Integer
            Dim dr As DataRow
            For i = 0 To col.Count - 1
                dr = mdtParticipantes.NewRow
                dr("rut") = RutLngAUsr(col.Item(i + 1).Rut)
                dr("nombres") = col.Item(i + 1).Nombres
                dr("apellido_paterno") = col.Item(i + 1).ApPaterno
                dr("apellido_materno") = col.Item(i + 1).ApMaterno
                dr("sexo") = col.Item(i + 1).Sexo
                'dr("cod_region") = col.Item(i + 1).CodigoRegion
                'dr("region") = col.Item(i + 1).Region
                'dr("cod_nivel_ocupacional") = col.Item(i + 1).CodigoNivelOcup
                'dr("nivel_ocupacional") = col.Item(i + 1).NivelOcup
                'dr("franquicia") = col.Item(i + 1).PorcFranquicia
                dr("viatico") = col.Item(i + 1).Viatico
                dr("traslado") = col.Item(i + 1).Traslado
                'dr("cod_nivel_educacional") = col.Item(i + 1).CodigoNivelEduc
                'dr("nivel_educacional") = col.Item(i + 1).NivelEduc
                'dr("fecha_nacimiento") = col.Item(i + 1).FechaNacimiento
                'dr("cod_comuna") = col.Item(i + 1).CodigoComuna
                'dr("comuna") = col.Item(i + 1).Comuna
                dr("existe") = 1
                dr("cod_estado_part") = col.Item(i + 1).Aprobado
                mdtParticipantes.Rows.Add(dr)
            Next
        End If
    End Sub

    Public Sub CargaDatosAlumnos()
        '¡ ************  PASO 2 ***************
        inicializarPaso2()
        mobjCursoInterno.ObtenerAlumnos()
        Dim col As New Collection
        col = mobjCursoInterno.Alumnos
        If col.Count > 0 Then
            Dim i As Integer
            Dim dr As DataRow
            For i = 0 To col.Count - 1
                dr = mdtParticipantes.NewRow
                dr("rut") = col.Item(i + 1).Rut
                dr("nombres") = col.Item(i + 1).Nombres
                dr("apellido_paterno") = col.Item(i + 1).ApPaterno
                dr("apellido_materno") = col.Item(i + 1).ApMaterno
                dr("sexo") = col.Item(i + 1).Sexo



                'dr("region") = col.Item(i + 1).CodigoRegion
                'dr("ocupacional") = col.Item(i + 1).CodigoNivelOcup
                dr("franquicia") = col.Item(i + 1).PorcFranquicia
                dr("viatico") = col.Item(i + 1).Viatico
                dr("traslado") = col.Item(i + 1).Traslado
                'dr("escolaridad") = col.Item(i + 1).CodigoNivelEduc
                'dr("fecha_nacimiento") = col.Item(i + 1).FechaNacimiento
                'dr("comuna") = col.Item(i + 1).CodigoComuna
                'dr("empresa") = drTmp(13)


                dr("cod_region") = col.Item(i + 1).CodigoRegion
                'dr("region") = col.Item(i + 1).Region
                dr("cod_nivel_ocupacional") = col.Item(i + 1).CodigoNivelOcup
                'dr("nivel_ocupacional") = col.Item(i + 1).NivelOcup
                dr("franquicia") = col.Item(i + 1).PorcFranquicia
                'dr("viatico") = col.Item(i + 1).Viatico
                'dr("traslado") = col.Item(i + 1).Traslado
                dr("cod_nivel_educacional") = col.Item(i + 1).CodigoNivelEduc
                'dr("nivel_educacional") = col.Item(i + 1).NivelEduc
                dr("fecha_nacimiento") = col.Item(i + 1).FechaNacimiento
                dr("cod_comuna") = col.Item(i + 1).CodigoComuna
                'dr("comuna") = col.Item(i + 1).Comuna
                dr("existe") = 1
                dr("COD_ESTADO_PART") = col.Item(i + 1).Aprobado
                mdtParticipantes.Rows.Add(dr)
            Next
        End If

    End Sub


    Public Function Actualizar() As Boolean Implements Clases.IMantenedor.Actualizar

    End Function

    Public Property colEliminacion() As System.Collections.ArrayList Implements Clases.IMantenedor.colEliminacion
        Get

        End Get
        Set(ByVal value As System.Collections.ArrayList)

        End Set
    End Property

    Public Function Consultar() As System.Data.DataTable Implements Clases.IMantenedor.Consultar

    End Function

    Public Function Eliminar() As Boolean Implements Clases.IMantenedor.Eliminar

    End Function

    Public ReadOnly Property Filas() As Integer Implements Clases.IMantenedor.Filas
        Get

        End Get
    End Property

    Public Sub InicializarNuevo() Implements Clases.IMantenedor.InicializarNuevo

    End Sub

    Public Function Insertar() As Boolean Implements Clases.IMantenedor.Insertar

    End Function
    Public Function CargarParticipantes(ByRef grd As GridView, ByVal strRuta As String, ByVal numParticipantes As Integer) As DataTable
        Try
            'If numParticipantes < grd.Rows.Count Then


            Dim mobjSqlExcel As New CSql
            Dim objCsql As New CSql
            mobjSqlExcel.MotorDb = "excel8"
            mobjSqlExcel.BD = strRuta
            Dim dtTemporal As DataTable
            dtTemporal = mobjSqlExcel.s_carga_hoja_excel("[Hoja1$]")
            Dim drTmp As DataRow
            For Each drTmp In dtTemporal.Rows
                If IsDBNull(drTmp(0)) And IsDBNull(drTmp(1)) And IsDBNull(drTmp(2)) And IsDBNull(drTmp(3)) And IsDBNull(drTmp(4)) _
                And IsDBNull(drTmp(5)) And IsDBNull(drTmp(6)) And IsDBNull(drTmp(7)) And IsDBNull(drTmp(8)) And IsDBNull(drTmp(9)) _
                And IsDBNull(drTmp(10)) And IsDBNull(drTmp(11)) And IsDBNull(drTmp(12)) And IsDBNull(drTmp(13)) And IsDBNull(drTmp(14)) Then
                    GoTo siguiente
                Else
                    Dim blnExiste As Boolean = False
                    Dim grdRow As GridViewRow
                    For Each grdRow In grd.Rows

                        'If drTmp(0) = CType(grdRow.FindControl("lblRut"), Label).Text Then
                        If drTmp(0) = CType(grdRow.FindControl("txtRut"), TextBox).Text Then
                            blnExiste = True
                            Exit For
                        End If
                    Next
                    Dim dr As DataRow
                    If Not blnExiste Then
                        dr = mdtParticipantes.NewRow
                        dr("rut") = drTmp(0)
                        dr("nombres") = drTmp(1)
                        dr("apellido_paterno") = drTmp(2)
                        dr("apellido_materno") = drTmp(3)
                        dr("sexo") = drTmp(4)
                        dr("cod_region") = drTmp(5)
                        dr("cod_nivel_ocupacional") = drTmp(6)
                        dr("franquicia") = drTmp(7)
                        dr("viatico") = drTmp(8)
                        dr("traslado") = drTmp(9)
                        dr("cod_nivel_educacional") = drTmp(10)
                        dr("fecha_nacimiento") = drTmp(11)
                        dr("cod_comuna") = drTmp(12)
                        'dr("empresa") = drTmp(13)
                        If objCsql.ExisteRegistro(RutUsrALng(drTmp(0)), "Persona_natural", "Rut") Then
                            dr("existe") = 1
                        Else
                            dr("existe") = 0
                        End If

                        'If drTmp(14).ToString.ToUpper = "APROBADO" Then
                        '    dr("COD_ESTADO_PART") = drTmp(14)
                        'ElseIf drTmp(14).ToString.ToUpper = "REPROBADO" Then
                        '    dr("COD_ESTADO_PART") = 2
                        'Else
                        '    dr("COD_ESTADO_PART") = 3
                        'End If
                        dr("COD_ESTADO_PART") = drTmp(14)
                        mdtParticipantes.Rows.Add(dr)
                    End If
                End If
siguiente:
            Next

            'Else
            ''
            'End If
            Return mdtParticipantes
        Catch ex As Exception
            EnviaError("modulo_cuentas/matenedor_cursos_interno.aspx.vb:btnCargar_Click-->" & ex.Message)
        End Try
    End Function
End Class
