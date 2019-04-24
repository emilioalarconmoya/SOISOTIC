Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorCursos
    'Implements IMantenedor
    Private mobjCsql As CSql
    Private mobjCursoContratado As CCursoContratado
    Private mlngRutUsuario As Long
    Private mlngCodCurso As Long
    Private mstrModo As String
    Private mbolAdmNoLineal As Boolean
    Private mintCodEstadoCurso As Integer
    Private mobjCursoSence As CCurso
    Private mobjCliente As CCliente
    Private mdtClienteMoroso As DataTable
    Private mintCodModalidad As Integer


    Public ReadOnly Property CodModalidad() As Integer
        Get
            Return mintCodModalidad
        End Get
    End Property
    Public ReadOnly Property dtClienteMoroso() As DataTable
        Get
            Return mdtClienteMoroso
        End Get
    End Property
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
    Public ReadOnly Property AdmNoLineal() As Boolean
        Get
            Return mbolAdmNoLineal
        End Get
    End Property
    Public ReadOnly Property CodEstadoCurso() As Integer
        Get
            Return mintCodEstadoCurso
        End Get
    End Property
    Public Property CursoSence() As CCurso
        Get
            CursoSence = mobjCursoSence
        End Get
        Set(ByVal value As CCurso)
            mobjCursoSence = value
        End Set
    End Property
    Public Property Cliente() As CCliente
        Get
            Cliente = mobjCliente
        End Get
        Set(ByVal value As CCliente)
            mobjCliente = value
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
#Region "PopUpCursosSence"
    Private mstrCursosSenceCodCurso As String
    Private mstrCursosSenceNombreCurso As String
    Private mstrCursosSenceOtec As String
    Private mdtCursosSence As DataTable
    Public WriteOnly Property CursosSenceCodCurso() As String
        Set(ByVal value As String)
            mstrCursosSenceCodCurso = value
        End Set
    End Property
    Public WriteOnly Property CursosSenceNombreCurso() As String
        Set(ByVal value As String)
            mstrCursosSenceNombreCurso = value
        End Set
    End Property
    Public WriteOnly Property CursosSenceOtec() As String
        Set(ByVal value As String)
            mstrCursosSenceOtec = value
        End Set
    End Property
    Public ReadOnly Property CursosSenceListado() As DataTable
        Get
            CursosSenceListado = mdtCursosSence
        End Get
    End Property
    Public Sub inicializarPopUpCursosSence()
        mstrCursosSenceCodCurso = ""
        mstrCursosSenceNombreCurso = ""
        mstrCursosSenceOtec = ""
        mdtCursosSence = New DataTable
        mdtCursosSence.Columns.Add("cod_sence")
        mdtCursosSence.Columns.Add("nombre_curso")
        mdtCursosSence.Columns.Add("horas")
        mdtCursosSence.Columns.Add("otec")
        mdtCursosSence.Columns.Add("valor_curso")
        mdtCursosSence.Columns.Add("Valor_hora")
    End Sub
    Public Sub ConsultarCursosSence()
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_cursos_sence(mstrCursosSenceCodCurso, mstrCursosSenceNombreCurso, mstrCursosSenceOtec)
            If mobjCsql.Registros > 0 Then
                Dim dr As DataRow
                Dim drCursosSence As DataRow
                For Each dr In dt.Rows
                    drCursosSence = mdtCursosSence.NewRow
                    drCursosSence("cod_sence") = dr("Codigo_sence")
                    drCursosSence("nombre_curso") = dr("nombre")
                    drCursosSence("horas") = dr("horas")
                    drCursosSence("otec") = dr("razon_social")
                    drCursosSence("valor_curso") = dr("valor_curso")
                    drCursosSence("valor_hora") = dr("valor_hora")
                    mdtCursosSence.Rows.Add(drCursosSence)
                Next
            End If
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:ConsultarCursosSence-->" & ex.Message)
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
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_persona_natural(mlngAlumnosRut, mstrAlumnosNombres, mstrAlumnosApellido)
            If mobjCsql.Registros > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    dr("rut") = rutlngausr(dr("rut"))
                Next
                mdtAlumnos = dt
            End If
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:ConsultarCursosSence-->" & ex.Message)
        End Try
    End Sub
#End Region
#Region "paso1"
    Private mlngRutEmpresa As Long
    Private mintTipoActividad As Integer
    Private mbolComBipartito As Boolean
    Private mbolDetNecesidades As Boolean
    Private mintNumParticipantes As Integer
    Private mstrDireccion As String
    Private mstrNumDireccion As String
    Private mstrCiudad As String
    Private mlngComuna As String
    Private mintAgno As Integer
    Private mstrObservaciones As String
    Private mintModalidad As Integer
    Private mstrCodSence As String
    Private mdtmFechaInicio As Date
    Private mdtmFechaFin As Date
    Private mdblHorasComp As Integer
    Private mlngValorCurso As Long
    Private mdblDescuento As Double
    Private mbolDescPorc As Boolean
    Private mlngValorFinal As Long
    Private mstrCorrelEmpresa As String
    Private mstrContactoAdicional As String
    Private mdblPorcAdmin As Double
    Private mlngCorrelativo As Long
    Private mdblValorHora As Double
    Private mblnCursoCFT As Boolean
    Private mlngCodCursoParcial As Long
    Private mlngRutEncargado As Long


    Public Property RutEmpresa() As Long
        Get
            RutEmpresa = mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property
    Public Property TipoActividad() As Integer
        Get
            TipoActividad = mintTipoActividad
        End Get
        Set(ByVal value As Integer)
            mintTipoActividad = value
        End Set
    End Property
    Public Property ComBipartito() As Boolean
        Get
            ComBipartito = mbolComBipartito
        End Get
        Set(ByVal value As Boolean)
            mbolComBipartito = value
        End Set
    End Property
    Public Property DetNecesidades() As Boolean
        Get
            DetNecesidades = mbolDetNecesidades
        End Get
        Set(ByVal value As Boolean)
            mbolDetNecesidades = value
        End Set
    End Property
    Public Property NumParticipantes() As Integer
        Get
            NumParticipantes = mintNumParticipantes
        End Get
        Set(ByVal value As Integer)
            mintNumParticipantes = value
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
    Public Property NumDireccion() As String
        Get
            NumDireccion = mstrNumDireccion
        End Get
        Set(ByVal value As String)
            mstrNumDireccion = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Ciudad = mstrCiudad
        End Get
        Set(ByVal value As String)
            mstrCiudad = value
        End Set
    End Property
    Public Property Comuna() As String
        Get
            Comuna = mlngComuna
        End Get
        Set(ByVal value As String)
            mlngComuna = value
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
    Public Property Modalidad() As Integer
        Get
            Modalidad = mintModalidad
        End Get
        Set(ByVal value As Integer)
            mintModalidad = value
        End Set
    End Property
    Public Property CodSence() As String
        Get
            CodSence = mstrCodSence
        End Get
        Set(ByVal value As String)
            mstrCodSence = value
        End Set
    End Property
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
    Public Property HorasComp() As Double
        Get
            HorasComp = mdblHorasComp
        End Get
        Set(ByVal value As Double)
            mdblHorasComp = value
        End Set
    End Property
    Public Property ValorHora() As Double
        Get
            ValorHora = mdblValorHora
        End Get
        Set(ByVal value As Double)
            mdblValorHora = value
        End Set
    End Property

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
    Public Property DescPorc() As Boolean
        Get
            DescPorc = mbolDescPorc
        End Get
        Set(ByVal value As Boolean)
            mbolDescPorc = value
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
    Public Property CorrelEmpresa() As String
        Get
            CorrelEmpresa = mstrCorrelEmpresa
        End Get
        Set(ByVal value As String)
            mstrCorrelEmpresa = value
        End Set
    End Property
    Public Property CursoCFT() As Boolean
        Get
            CursoCFT = mblnCursoCFT
        End Get
        Set(ByVal value As Boolean)
            mblnCursoCFT = value
        End Set
    End Property
    Public Property ContactoAdicional() As String
        Get
            ContactoAdicional = mstrContactoAdicional
        End Get
        Set(ByVal value As String)
            mstrContactoAdicional = value
        End Set
    End Property
    Public Property PorcAdmin() As Double
        Get
            PorcAdmin = mdblPorcAdmin
        End Get
        Set(ByVal value As Double)
            mdblPorcAdmin = value
        End Set
    End Property
    Public Property Correlativo() As String
        Get
            Correlativo = mlngCorrelativo
        End Get
        Set(ByVal value As String)
            mlngCorrelativo = value
        End Set
    End Property
    Public Property CodCursoParcial() As Long
        Get
            Return mlngCodCursoParcial
        End Get
        Set(ByVal value As Long)
            mlngCodCursoParcial = value
        End Set
    End Property
    Public Property RutEncargado() As Long
        Get
            Return mlngRutEncargado
        End Get
        Set(ByVal value As Long)
            mlngRutEncargado = value
        End Set
    End Property

    Public Function CalculaHorasSence() As String
        Try
            mobjCsql = New CSql
            CalculaHorasSence = mobjCsql.s_hora_sence(mstrCodSence)
            mobjCsql = Nothing

        Catch ex As System.Exception
            EnviaError("CSolitudPrestamo:CalculaHorasSence->" & ex.Message)
        End Try
    End Function

    Public Function ConsultarPorcAdmin(ByVal RutCliente As Long) As Double
        Try
            mobjCsql = New CSql
            ConsultarPorcAdmin = mobjCsql.s_porc_admin(RutCliente)
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos:ConsultarPorcAdmin-->" & ex.Message)
        End Try
    End Function
    Public Sub inicializarPaso1()
        mlngRutEmpresa = gValorNumNulo
        mintTipoActividad = gValorNumNulo
        mbolComBipartito = False
        mbolDetNecesidades = False
        mintNumParticipantes = gValorNumNulo
        mstrDireccion = ""
        mstrNumDireccion = ""
        mstrCiudad = ""
        mlngComuna = ""
        mintAgno = gValorNumNulo
        mstrObservaciones = ""
        mintModalidad = 1
        mstrCodSence = ""
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaFin = FechaMinSistema()
        mdblHorasComp = 0
        mlngValorCurso = gValorNumNulo
        mdblDescuento = 0.0
        mbolDescPorc = False
        mlngValorFinal = gValorNumNulo
        mstrCorrelEmpresa = ""
        mstrContactoAdicional = ""
        mdblPorcAdmin = 0.0
        mlngCorrelativo = 0
        mblnCursoCFT = False
    End Sub
    Public Sub InicializarCursoSence()
        Try
            Dim mobjCsql2 As New CSql
            mobjCursoSence = New CCurso
            mobjCursoSence.Inicializar0(mobjCsql2, Me.mlngRutUsuario)
            mobjCursoSence.Inicializar1(mstrCodSence)
            mobjCsql2 = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:InicializarCursoSence-->" & ex.Message)
        End Try
    End Sub
    Public Sub InicializarCliente()
        Try
            Dim mobjCsql2 As New CSql
            mobjCliente = New CCliente
            mobjCliente.Inicializar0(mobjCsql2, Me.mlngRutUsuario)
            mobjCliente.Inicializar1(RutLngAUsr(mlngRutEmpresa))
            mobjCsql2 = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:InicializarCursoSence-->" & ex.Message)
        End Try
    End Sub
    Public Function ExisteEmpresa(ByVal RutEmpresa As Long) As Boolean
        Try
            mobjCsql = New CSql
            ExisteEmpresa = mobjCsql.ExisteRegistro(RutEmpresa, "empresa_cliente", "rut")
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:ExisteEmpresa-->" & ex.Message)
        End Try
    End Function
    Public Function ExisteCursoSence(ByVal CodSence As String) As Boolean
        Try
            mobjCsql = New CSql
            ExisteCursoSence = mobjCsql.ExisteCursoSence(CodSence)
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:ExisteCursoSence-->" & ex.Message)
        End Try
    End Function
    Public Sub NombreEmpresa(ByVal RutEmpresa As Long)
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_nombre_empresa(RutEmpresa)
            If mobjCsql.Registros > 0 Then
                Me.mstrEmpresa = dt.Rows(0).Item(1).ToString
            End If
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:NombreEmpresa-->" & ex.Message)
        End Try
    End Sub
    Public Sub DatosCurso(ByVal CodSence As String)
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_datos_curso(CodSence)
            If mobjCsql.Registros > 0 Then
                Me.mstrCurso = dt.Rows(0).Item(1).ToString
                Me.mintHorasCurso = dt.Rows(0).Item(2).ToString
                Me.mintMaxParticipantes = dt.Rows(0).Item(3).ToString
                Me.mstrOtec = dt.Rows(0).Item(4).ToString
                Me.mlngValorCursoSence = dt.Rows(0).Item(6).ToString
                Me.mintCodModalidad = dt.Rows(0).Item(7).ToString
            End If
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:DatosCurso-->" & ex.Message)
        End Try
    End Sub
    Public Function EsElearning(ByVal CodSence As String) As Boolean
        Try
            mobjCsql = New CSql
            Return mobjCsql.s_es_curso_elearning(CodSence)
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:EsElearning-->" & ex.Message)
        End Try
    End Function
    Public Sub GrabarPaso1()
        Try
            mobjCursoContratado = New CCursoContratado
            mobjCsql = New CSql
            'mobjCsql.InicioTransaccion()

            mobjCursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCursoContratado.InicializarNuevo()
            mobjCursoContratado.CodCurso = mlngCodCurso
            mobjCursoContratado.Correlativo = mlngCorrelativo
            mobjCursoContratado.Inicializar1(mlngCodCurso)
            mobjCursoContratado.Horas = mintHorasCurso
            mobjCursoContratado.Inicializar2(RutLngAUsr(mlngRutEmpresa), mintTipoActividad, mbolComBipartito, mbolDetNecesidades, _
                                            mintNumParticipantes, mstrDireccion, mlngComuna, mstrCodSence, mdtmFechaInicio, _
                                            mdtmFechaFin, mdblHorasComp, mlngValorCurso, mdblDescuento, mstrCorrelEmpresa, _
                                            mbolDescPorc, mstrContactoAdicional, mstrObservaciones, mstrNumDireccion, _
                                            mstrCiudad, mintAgno, mintModalidad, mdblValorHora, mblnCursoCFT)
            mobjCursoContratado.HorarioCurso = Me.mdtHorario
            'If mstrModo = "insertar" Then
            '    mobjCursoContratado.GrabarDatos()
            'ElseIf mstrModo = "actualizar" Then

            mobjCursoContratado.ActualizarDatos(1)
            'End If
            mobjCursoContratado.ReInicializar()
            mlngCodCurso = mobjCursoContratado.CodCurso
            mobjCursoContratado.ObtenerInfoCuentas()
            mobjCursoContratado.CalcCostoAdm()
            CargaDatos()
            ' mobjCsql.FinTransaccion()
            mobjCsql = Nothing
        Catch ex As Exception
            'mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorCursos.vb:GrabarPaso1-->" & ex.Message)
        End Try
    End Sub
    Private Function DuracionCurso(ByVal strCodSence As String) As Long
        Try
            DuracionCurso = mobjCsql.s_duracion_curso(strCodSence)
        Catch ex As Exception

        End Try
    End Function
    Public Sub InicializarCursoExistente()
        Try
            mobjCsql = New CSql
            mobjCursoContratado = New CCursoContratado
            mobjCursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCursoContratado.Inicializar1(mlngCodCurso)
            mintCodEstadoCurso = mobjCursoContratado.CodEstadoCurso
            mdblPorcAdmin = mobjCsql.s_porcentaje_empresa(RutUsrALng(mobjCursoContratado.RutCliente))
            mobjCursoContratado.PorcAdm = mdblPorcAdmin
            mobjCursoContratado.ObtenerInfoCuentas()
            mobjCursoContratado.CalcularCostos()
            mobjCursoContratado.CalcCostoAdm()
            CargaDatos()
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:InicializarCursoExistente-->" & ex.Message)
        End Try

    End Sub
#End Region
#Region "paso2"
    Private mstrEmpresa As String
    Private mstrCurso As String
    Private mstrOtec As String
    Private mintHorasCurso As Integer
    Private mintMaxParticipantes As Integer
    Private mlngValorCursoSence As Long
    Private mdtHorario As DataTable
    Public Property Empresa() As String
        Get
            Empresa = mstrEmpresa
        End Get
        Set(ByVal value As String)
            mstrEmpresa = value
        End Set
    End Property
    Public Property Curso() As String
        Get
            Curso = mstrCurso
        End Get
        Set(ByVal value As String)
            mstrCurso = value
        End Set
    End Property
    Public Property Otec() As String
        Get
            Otec = mstrOtec
        End Get
        Set(ByVal value As String)
            mstrOtec = value
        End Set
    End Property
    Public Property HorasCurso() As Integer
        Get
            HorasCurso = mintHorasCurso
        End Get
        Set(ByVal value As Integer)
            mintHorasCurso = value
        End Set
    End Property
    Public Property MaxParticipantes() As Integer
        Get
            MaxParticipantes = mintMaxParticipantes
        End Get
        Set(ByVal value As Integer)
            mintMaxParticipantes = value
        End Set
    End Property
    Public Property ValorCursoSence() As Integer
        Get
            ValorCursoSence = mlngValorCursoSence
        End Get
        Set(ByVal value As Integer)
            mlngValorCursoSence = value
        End Set
    End Property

    Public Property dthorario() As DataTable
        Get
            dthorario = mdtHorario
        End Get
        Set(ByVal value As DataTable)
            mdtHorario = value
        End Set
    End Property
    Public Sub inicializarPaso2()
        mstrEmpresa = ""
        mstrCurso = ""
        mstrOtec = ""
        mintHorasCurso = 0
        mdtHorario = New DataTable
        mdtHorario.Columns.Add("Dia")
        mdtHorario.Columns.Add("DiaNombre")
        mdtHorario.Columns.Add("HoraInicio")
        mdtHorario.Columns.Add("HoraFin")
        mdtHorario.Columns.Add("CodCurso")
    End Sub
    Public Sub GrabarPaso2()
        Try
            mobjCursoContratado = New CCursoContratado
            mobjCursoContratado.InicializarNuevo()
            mobjCsql = New CSql
            ' mobjCsql.InicioTransaccion()
            mobjCursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)

            mobjCursoContratado.Correlativo = Me.mlngCorrelativo
            mobjCursoContratado.CodCurso = mlngCodCurso
            mobjCursoContratado.RutCliente = Me.RutEmpresa
            mobjCursoContratado.Inicializar1(mlngCodCurso)
            mobjCursoContratado.Inicializar2(RutLngAUsr(mlngRutEmpresa), mintTipoActividad, mbolComBipartito, mbolDetNecesidades, _
                                            mintNumParticipantes, mstrDireccion, mlngComuna, mstrCodSence, mdtmFechaInicio, _
                                            mdtmFechaFin, mdblHorasComp, mlngValorCurso, mdblDescuento, mstrCorrelEmpresa, _
                                            mbolDescPorc, mstrContactoAdicional, mstrObservaciones, mstrNumDireccion, _
                                            mstrCiudad, mintAgno, mintModalidad, mdblValorHora, mblnCursoCFT, mlngRutEncargado)
            mobjCursoContratado.HorarioCurso = Me.mdtHorario
            If mstrModo = "insertar" Then
                mobjCursoContratado.GrabarDatos()
                mlngCodCurso = mobjCursoContratado.CodCurso
            End If

            mobjCursoContratado.CodCurso = mlngCodCurso
            mobjCursoContratado.CalcHorasCurso()
            mobjCursoContratado.CalcCostoAdm()

            mobjCursoContratado.ActualizarDatos(1)

            'mobjCursoContratado.CodCurso = mlngCodCurso
            'mobjCursoContratado.GrabarHorario()


            'mobjCursoContratado.ReInicializar()
            'mlngCodCurso = mobjCursoContratado.CodCurso
            'mobjCursoContratado.ObtenerInfoCuentas()
            'mobjCursoContratado.CalcCostoAdm()
            'CargaDatos()


            'mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            InicializarCursoExistente()
        Catch ex As Exception
            'mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorCursos.vb:GrabarPaso2-->" & ex.Message)
        End Try
    End Sub
#End Region
#Region "paso3"
    Private mdtParticipantes As DataTable
    Public Property Participantes() As DataTable
        Get
            Participantes = mdtParticipantes
        End Get
        Set(ByVal value As DataTable)
            mdtParticipantes = value
        End Set
    End Property
    Public Sub inicializarPaso3()
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
        mdtParticipantes.Columns.Add("porc_asistencia")
        mdtParticipantes.Columns.Add("cod_nivel_educacional")
        mdtParticipantes.Columns.Add("nivel_educacional")
        mdtParticipantes.Columns.Add("fecha_nacimiento")
        mdtParticipantes.Columns.Add("cod_comuna")
        mdtParticipantes.Columns.Add("comuna")
        mdtParticipantes.Columns.Add("existe")
        mdtParticipantes.Columns.Add("cod_pais")
        mdtParticipantes.Columns.Add("pais")
        mdtParticipantes.Columns.Add("fono")
        mdtParticipantes.Columns.Add("email")
        mdtParticipantes.Columns.Add("RutLNG")
    End Sub
    Public Sub ConsultaAlumno(ByVal mlngRutAlumno As Long)
        Try
            mobjCsql = New CSql
            Dim dt As New DataTable
            dt = mobjCsql.s_alumno(mlngRutAlumno)
            If mobjCsql.Registros > 0 Then
                dt.Rows(0).Item(0) = RutLngAUsr(dt.Rows(0).Item(0))
                dt.Rows(0).Item(18) = 1
                dt.Rows(0).Item(15) = Left(dt.Rows(0).Item(15), 10)
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
                dr("porc_asistencia") = 0
                dr("cod_nivel_educacional") = ""
                dr("nivel_educacional") = ""
                dr("fecha_nacimiento") = ""
                dr("cod_comuna") = ""
                dr("comuna") = ""
                dr("existe") = 0
                dr("cod_pais") = ""
                dr("pais") = ""
                dr("fono") = ""
                dr("email") = ""
                dr("RutLNG") = mlngRutAlumno
                mdtParticipantes.Rows.Add(dr)
            End If
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:ConsultaAlumno-->" & ex.Message)
        End Try
    End Sub
    Public Sub GrabarPaso3()
        Try
            mobjCursoContratado = New CCursoContratado
            mobjCursoContratado.InicializarNuevo()
            'mobjCursoContratado.HorarioCurso = Me.mdtHorario
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjCursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCursoContratado.CodCurso = mlngCodCurso
            mobjCursoContratado.Inicializar1(mlngCodCurso)
            If Not Me.mdtParticipantes Is Nothing Then
                If mdtParticipantes.Rows.Count > 0 Then
                    Dim dr As DataRow
                    Dim col As New Collection
                    mobjCsql.d_participante(mlngCodCurso)
                    For Each dr In mdtParticipantes.Rows
                        If dr("existe") = 0 Then
                            If Not mobjCsql.ExisteRegistro(RutUsrALng(dr("rut")), "persona", "rut") Then
                                mobjCsql.i_Persona(RutUsrALng(dr("rut")), digito_verificador(RutUsrALng(dr("rut"))), "N")
                                mobjCsql.i_PersonaNatural(RutUsrALng(dr("rut")), dr("apellido_paterno"), _
                                          dr("apellido_materno"), dr("nombres"), _
                                          dr("fecha_nacimiento"), dr("sexo"), _
                                          dr("franquicia"), dr("cod_nivel_ocupacional"), _
                                          dr("cod_nivel_educacional"), dr("cod_region"), _
                                          mlngRutEmpresa, dr("cod_comuna"), dr("cod_pais"), dr("fono"), dr("email"))
                            Else
                                dr("existe") = 1
                            End If
                            
                        ElseIf dr("existe") = 1 Then
                            mobjCsql.u_Persona(RutUsrALng(dr("rut")), digito_verificador(RutUsrALng(dr("rut"))), "N")
                            mobjCsql.u_PersonaNatural(RutUsrALng(dr("rut")), dr("apellido_paterno"), _
                                      dr("apellido_materno"), dr("nombres"), _
                                      dr("fecha_nacimiento"), dr("sexo"), _
                                      dr("franquicia"), dr("cod_nivel_ocupacional"), _
                                      dr("cod_nivel_educacional"), dr("cod_region"), _
                                      mlngRutEmpresa, dr("cod_comuna"), dr("cod_pais"), dr("fono"), dr("email"))
                        End If
                        Dim objAlumno As New CAlumno
                        objAlumno.Inicializar0(mobjCsql)
                        objAlumno.CodCursoInscrito = mlngCodCurso
                        objAlumno.RutEmpresa = RutLngAUsr(mlngRutEmpresa)
                        'objAlumno.PorcAsistencia = 0

                        objAlumno.Inicializar(dr("rut"))
                        objAlumno.PorcAsistencia = dr("porc_asistencia")
                        objAlumno.Viatico = dr("viatico")
                        objAlumno.Traslado = dr("traslado")
                        objAlumno.PorcFranquicia = dr("franquicia")
                        objAlumno.Fono = dr("fono")
                        objAlumno.Email = dr("email")
                        col.Add(objAlumno)
                    Next
                    mobjCursoContratado.Alumnos = col
                End If
            End If
            mobjCsql.FinTransaccion()
            mobjCursoContratado.RutCliente = mlngRutEmpresa
            mobjCursoContratado.GrabarAlumnos()
            mobjCursoContratado.ReInicializar()
            mobjCursoContratado.ObtenerInfoCuentas()
            mobjCursoContratado.CalcHorasCurso()
            mobjCursoContratado.CalcCostoAdm()
            mobjCursoContratado.NumAlumnos = Me.NumParticipantes

            mobjCursoContratado.ActualizarDatos(1)

            CargaDatos()

            mobjCsql = Nothing
        Catch ex As Exception
            'mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorCursos.vb:GrabarPaso3-->" & ex.Message)
        End Try
    End Sub
#End Region
#Region "paso4"
    Private mlngCostoOtic As Long
    Private mlngCtaCapSaldo As Long
    Private mlngCtaCap1 As Long
    Private mlngExcCapSaldo As Long
    Private mlngExcCap1 As Long
    Private mlngBecasSaldo As Long
    Private mlngBecas As Long
    Private mlngTerceros As Long
    Private mlngPorCubrir1 As Long
    Private mlngVyT1 As Long
    Private mlngAdminCtaCap As Long
    Private mlngAporteReq1 As Long
    Private mlngGastoEmpresa As Long
    Private mlngTotalCurso As Long
    Private mlngTotalVyT As Long
    Private mlngCostoOticVyT As Long
    Private mlngGastoEmpresaVyT As Long
    Private mlngCtaCapSaldo2 As Long
    Private mlngCtaCap2 As Long
    Private mlngExcCapSaldo2 As Long
    Private mlngExcCap2 As Long
    Private mlngAdminCtaCapVyT As Long
    Private mlngAporteReq2 As Long
    Private mdtSolicitudes As DataTable
    Private mlngTotalViatico As Long
    Private mlngTotalTraslado As Long
    Private mlngTotalReparto As Long
    Public Property TotalTraslado() As Long
        Get
            TotalTraslado = mlngTotalTraslado
        End Get
        Set(ByVal value As Long)
            mlngTotalTraslado = value
        End Set
    End Property
    Public Property TotalViatico() As Long
        Get
            TotalViatico = mlngTotalViatico
        End Get
        Set(ByVal value As Long)
            mlngTotalViatico = value
        End Set
    End Property
    Public Property CostoOtic() As Long
        Get
            CostoOtic = mlngCostoOtic
        End Get
        Set(ByVal value As Long)
            mlngCostoOtic = value
        End Set
    End Property
    Public Property CtaCapSaldo() As Long
        Get
            CtaCapSaldo = mlngCtaCapSaldo
        End Get
        Set(ByVal value As Long)
            mlngCtaCapSaldo = value
        End Set
    End Property
    Public Property CtaCap1() As Long
        Get
            CtaCap1 = mlngCtaCap1
        End Get
        Set(ByVal value As Long)
            mlngCtaCap1 = value
        End Set
    End Property
    Public Property ExcCapSaldo() As Long
        Get
            ExcCapSaldo = mlngExcCapSaldo
        End Get
        Set(ByVal value As Long)
            mlngExcCapSaldo = value
        End Set
    End Property
    Public Property ExcCap1() As Long
        Get
            ExcCap1 = mlngExcCap1
        End Get
        Set(ByVal value As Long)
            mlngExcCap1 = value
        End Set
    End Property
    Public Property BecasSaldo() As Long
        Get
            BecasSaldo = mlngBecasSaldo
        End Get
        Set(ByVal value As Long)
            mlngBecasSaldo = value
        End Set
    End Property
    Public Property Becas() As Long
        Get
            Becas = mlngBecas
        End Get
        Set(ByVal value As Long)
            mlngBecas = value
        End Set
    End Property
    Public Property Terceros() As Long
        Get
            Terceros = mlngTerceros
        End Get
        Set(ByVal value As Long)
            mlngTerceros = value
        End Set
    End Property
    Public Property PorCubrir1() As Long
        Get
            PorCubrir1 = mlngPorCubrir1
        End Get
        Set(ByVal value As Long)
            mlngPorCubrir1 = value
        End Set
    End Property
    Public Property VyT1() As Long
        Get
            VyT1 = mlngVyT1
        End Get
        Set(ByVal value As Long)
            mlngVyT1 = value
        End Set
    End Property
    Public Property AdminCtaCap() As Long
        Get
            AdminCtaCap = mlngAdminCtaCap
        End Get
        Set(ByVal value As Long)
            mlngAdminCtaCap = value
        End Set
    End Property
    Public Property AporteReq1() As Long
        Get
            AporteReq1 = mlngAporteReq1
        End Get
        Set(ByVal value As Long)
            mlngAporteReq1 = value
        End Set
    End Property
    Public Property GastoEmpresa() As Long
        Get
            GastoEmpresa = mlngGastoEmpresa
        End Get
        Set(ByVal value As Long)
            mlngGastoEmpresa = value
        End Set
    End Property
    Public Property TotalCurso() As Long
        Get
            TotalCurso = mlngTotalCurso
        End Get
        Set(ByVal value As Long)
            mlngTotalCurso = value
        End Set
    End Property
    Public Property TotalVyT() As Long
        Get
            TotalVyT = mlngTotalVyT
        End Get
        Set(ByVal value As Long)
            mlngTotalVyT = value
        End Set
    End Property
    Public Property CostoOticVyT() As Long
        Get
            CostoOticVyT = mlngCostoOticVyT
        End Get
        Set(ByVal value As Long)
            mlngCostoOticVyT = value
        End Set
    End Property
    Public Property GastoEmpresaVyT() As Long
        Get
            GastoEmpresaVyT = mlngGastoEmpresaVyT
        End Get
        Set(ByVal value As Long)
            mlngGastoEmpresaVyT = value
        End Set
    End Property
    Public Property CtaCapSaldo2() As Long
        Get
            CtaCapSaldo2 = mlngCtaCapSaldo2
        End Get
        Set(ByVal value As Long)
            mlngCtaCapSaldo2 = value
        End Set
    End Property
    Public Property CtaCap2() As Long
        Get
            CtaCap2 = mlngCtaCap2
        End Get
        Set(ByVal value As Long)
            mlngCtaCap2 = value
        End Set
    End Property
    Public Property ExcCapSaldo2() As Long
        Get
            ExcCapSaldo2 = mlngExcCapSaldo2
        End Get
        Set(ByVal value As Long)
            mlngExcCapSaldo2 = value
        End Set
    End Property
    Public Property ExcCap2() As Long
        Get
            ExcCap2 = mlngExcCap2
        End Get
        Set(ByVal value As Long)
            mlngExcCap2 = value
        End Set
    End Property
    Public Property AdminCtaCapVyT() As Long
        Get
            AdminCtaCapVyT = mlngAdminCtaCapVyT
        End Get
        Set(ByVal value As Long)
            mlngAdminCtaCapVyT = value
        End Set
    End Property
    Public Property AporteReq2() As Long
        Get
            AporteReq2 = mlngAporteReq2
        End Get
        Set(ByVal value As Long)
            mlngAporteReq2 = value
        End Set
    End Property
    Public Property Solicitudes() As DataTable
        Get
            Solicitudes = mdtSolicitudes
        End Get
        Set(ByVal value As DataTable)
            mdtSolicitudes = value
        End Set
    End Property
    Public Property TotalReparto() As Long
        Get
            TotalReparto = mlngTotalReparto
        End Get
        Set(ByVal value As Long)
            mlngTotalReparto = value
        End Set
    End Property
    Public Sub inicializarPaso4()
        mlngCostoOtic = 0
        mlngCtaCapSaldo = 0
        mlngCtaCap1 = 0
        mlngExcCapSaldo = 0
        mlngExcCap1 = 0
        mlngBecasSaldo = 0
        mlngBecas = 0
        mlngTerceros = 0
        mlngPorCubrir1 = 0
        mlngVyT1 = 0
        mlngAdminCtaCap = 0
        mlngAporteReq1 = 0
        mlngGastoEmpresa = 0
        mlngTotalCurso = 0
        mlngTotalVyT = 0
        mlngCostoOticVyT = 0
        mlngGastoEmpresaVyT = 0
        mlngCtaCapSaldo2 = 0
        mlngCtaCap2 = 0
        mlngExcCapSaldo2 = 0
        mlngExcCap2 = 0
        mlngAdminCtaCapVyT = 0
        mlngAporteReq2 = 0
        mdtSolicitudes = New DataTable
        'mdtSolicitudes.Columns.Add("CodCurso")
        'mdtSolicitudes.Columns.Add("RutEmpresa")
        'mdtSolicitudes.Columns.Add("Monto")

        mdtSolicitudes.Columns.Add("rut_benefactor")
        mdtSolicitudes.Columns.Add("monto")
        mdtSolicitudes.Columns.Add("cod_estado_solicitud")
        mdtSolicitudes.Columns.Add("monto_adm")
        mdtSolicitudes.Columns.Add("monto2")
        mdtSolicitudes.Columns.Add("cta")
        mdtSolicitudes.Columns.Add("cod_curso")
    End Sub
    Public Sub GrabarPaso4()
        Try
            mobjCursoContratado = New CCursoContratado
            mobjCursoContratado.InicializarNuevo()
            'mobjCursoContratado.HorarioCurso = Me.mdtHorario
            mobjCsql = New CSql
            'mobjCsql.InicioTransaccion()
            mobjCursoContratado.Inicializar0(mobjCsql, mlngRutUsuario)
            mobjCursoContratado.Inicializar1(mlngCodCurso)
            mobjCursoContratado.ObtenerInfoCuentas()

            mobjCursoContratado.MontoCtaCap = mlngCtaCap1
            mobjCursoContratado.MontoCtaExcCap = mlngExcCap1
            mobjCursoContratado.TotMontoTerc = mlngTerceros
            mobjCursoContratado.CostoAdm = mlngAdminCtaCap
            mobjCursoContratado.MontoCtaBecas = mlngBecas

            mobjCursoContratado.MontoCtaCapVYT = mlngCtaCap2
            mobjCursoContratado.MontoCtaExcCapVYT = mlngExcCap2
            mobjCursoContratado.MontoCtaAdmVYT = mlngAdminCtaCapVyT

            If Not Me.mdtSolicitudes.Rows.Count > 0 Then
                mobjCursoContratado.Terceros = Nothing
            Else
                mobjCursoContratado.Terceros = Me.mdtSolicitudes
            End If
            mdblPorcAdmin = mobjCsql.s_porcentaje_empresa(RutUsrALng(mobjCursoContratado.RutCliente))
            mobjCursoContratado.PorcAdm = mdblPorcAdmin
            mobjCursoContratado.GrabarInfoCuentas()

            'mobjCursoContratado.GrabarAlumnos()
            mobjCursoContratado.ReInicializar()
            mobjCursoContratado.ObtenerInfoCuentas()
            mobjCursoContratado.CalcCostoAdm()
            CargaDatos()
            'mobjCsql.FinTransaccion()
            'Correo()
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            EnviaError("CMantenedorCursos.vb:GrabarPaso4-->" & ex.Message)
        End Try
    End Sub
#End Region
    Public Sub CargaDatos()
        Try
            '************  PASO 1
            mlngRutEmpresa = RutUsrALng(mobjCursoContratado.RutCliente)
            mintTipoActividad = mobjCursoContratado.CodTipoActiv
            mbolComBipartito = mobjCursoContratado.IndAcuComBip
            mdblValorHora = mobjCursoContratado.ValorHora
            mbolDetNecesidades = mobjCursoContratado.IndDetNece
            mintNumParticipantes = mobjCursoContratado.NumAlumnos
            mstrDireccion = mobjCursoContratado.DireccionCurso
            mstrNumDireccion = mobjCursoContratado.NroDireccionCurso
            mstrCiudad = mobjCursoContratado.Ciudad
            mlngComuna = mobjCursoContratado.CodComuna
            mintAgno = mobjCursoContratado.Agno
            mstrObservaciones = mobjCursoContratado.Observacion
            mintModalidad = mobjCursoContratado.Curso.Modalidad
            mstrCodSence = mobjCursoContratado.CodSence
            mdtmFechaInicio = mobjCursoContratado.FechaInicio
            mdtmFechaFin = mobjCursoContratado.FechaTermino
            mdblHorasComp = mobjCursoContratado.HorasCompl
            mlngValorCurso = mobjCursoContratado.ValorMercado
            mdblDescuento = mobjCursoContratado.Descuento
            mbolDescPorc = mobjCursoContratado.IndDescPorc
            mlngValorFinal = mobjCursoContratado.ValorComunicado
            mstrCorrelEmpresa = mobjCursoContratado.CorrEmpresa
            mstrContactoAdicional = mobjCursoContratado.ContactoAdicional
            'mdblPorcAdmin = mobjCursoContratado.PorcAdm
            mlngCorrelativo = mobjCursoContratado.Correlativo
            If mobjCursoContratado.AdmNoLineal = 1 Then
                mbolAdmNoLineal = True
            ElseIf mobjCursoContratado.AdmNoLineal = 0 Then
                mbolAdmNoLineal = False
            End If
            mintCodEstadoCurso = mobjCursoContratado.CodEstadoCurso
            mblnCursoCFT = mobjCursoContratado.CursoCFT
            mlngCodCursoParcial = mobjCursoContratado.CodCursoParcial
            mlngRutEncargado = mobjCursoContratado.RutEncargado

            '************  PASO 2
            inicializarPaso2()
            mstrEmpresa = mobjCursoContratado.Cliente.RazonSocial
            mstrCurso = mobjCursoContratado.Curso.NombreCurso
            mstrOtec = mobjCursoContratado.Otec.RazonSocial
            mintHorasCurso = mobjCursoContratado.Curso.DurCurso
            Dim dt As New DataTable
            dt = mobjCursoContratado.HorarioCurso
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("DiaNombre")
                Dim dr1 As DataRow
                For Each dr1 In dt.Rows
                    Select Case dr1("Dia")
                        Case 1
                            dr1("DiaNombre") = "Lun"
                        Case 2
                            dr1("DiaNombre") = "Mar"
                        Case 3
                            dr1("DiaNombre") = "Mie"
                        Case 4
                            dr1("DiaNombre") = "Jue"
                        Case 5
                            dr1("DiaNombre") = "Vie"
                        Case 6
                            dr1("DiaNombre") = "Sab"
                        Case 7
                            dr1("DiaNombre") = "Dom"
                    End Select
                Next
                mdtHorario = dt
            End If
            '************  PASO 3
            inicializarPaso3()
            mobjCursoContratado.ObtenerAlumnos()
            Dim col As New Collection
            col = mobjCursoContratado.Alumnos
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
                    dr("cod_region") = col.Item(i + 1).CodigoRegion
                    dr("region") = col.Item(i + 1).Region
                    dr("cod_nivel_ocupacional") = col.Item(i + 1).CodigoNivelOcup
                    dr("nivel_ocupacional") = col.Item(i + 1).NivelOcup
                    dr("franquicia") = col.Item(i + 1).PorcFranquicia
                    dr("viatico") = col.Item(i + 1).Viatico
                    dr("traslado") = col.Item(i + 1).Traslado
                    dr("porc_asistencia") = col.Item(i + 1).PorcAsistencia
                    dr("cod_nivel_educacional") = col.Item(i + 1).CodigoNivelEduc
                    dr("nivel_educacional") = col.Item(i + 1).NivelEduc
                    dr("fecha_nacimiento") = col.Item(i + 1).FechaNacimiento
                    dr("cod_comuna") = col.Item(i + 1).CodigoComuna
                    dr("comuna") = col.Item(i + 1).Comuna
                    dr("cod_pais") = col.Item(i + 1).CodigoPais
                    dr("pais") = col.Item(i + 1).Pais
                    dr("fono") = col.Item(i + 1).Fono
                    dr("email") = col.Item(i + 1).Email
                    dr("existe") = 1
                    mdtParticipantes.Rows.Add(dr)
                Next
            End If
            '************  PASO 4
            inicializarPaso4()
            mlngCostoOtic = mobjCursoContratado.CostoOtic
            If mobjCursoContratado.SaldoCtaCap > 0 Then
                mlngCtaCapSaldo = mobjCursoContratado.SaldoCtaCap + mobjCursoContratado.MontoCtaCap + mobjCursoContratado.MontoCtaCapVYT
            Else
                mlngCtaCapSaldo = mobjCursoContratado.SaldoCtaCap
            End If
            mlngCtaCap1 = mobjCursoContratado.MontoCtaCap
            If mobjCursoContratado.SaldoCtaExcCap > 0 Then
                mlngExcCapSaldo = mobjCursoContratado.SaldoCtaExcCap + mobjCursoContratado.MontoCtaExcCap + mobjCursoContratado.MontoCtaExcCapVYT
            Else
                mlngExcCapSaldo = mobjCursoContratado.SaldoCtaExcCap
            End If

            mlngExcCap1 = mobjCursoContratado.MontoCtaExcCap
            mlngBecasSaldo = mobjCursoContratado.SaldoCtaBecas + mobjCursoContratado.MontoCtaBecas
            mlngBecas = mobjCursoContratado.MontoCtaBecas
            mlngTerceros = mobjCursoContratado.TotMontoTercTransacciones
            If mobjCursoContratado.CostoOtic - mobjCursoContratado.TotMontoTercTransacciones > 0 Then
                If mobjCursoContratado.MontoCtaCap >= 0 And mobjCursoContratado.MontoCtaExcCap >= 0 And mobjCursoContratado.TotMontoTercTransacciones >= 0 Then
                    mlngPorCubrir1 = mobjCursoContratado.CostoOtic - mobjCursoContratado.TotMontoTercTransacciones - mobjCursoContratado.MontoCtaCap - mobjCursoContratado.MontoCtaExcCap
                Else
                    mlngPorCubrir1 = mobjCursoContratado.CostoOtic
                End If
            Else
                mlngPorCubrir1 = 0
            End If
            mlngVyT1 = mobjCursoContratado.TotalViatico + mobjCursoContratado.TotalTraslado
            mlngAdminCtaCap = mobjCursoContratado.CostoAdm
            If mobjCursoContratado.MontoCtaCap > 0 Then
                mlngAporteReq1 = mobjCursoContratado.CostoOtic + mobjCursoContratado.CostoAdm
            Else
                mlngAporteReq1 = mobjCursoContratado.CostoOtic
            End If
            mlngGastoEmpresa = mobjCursoContratado.GastoEmpresa
            mlngTotalCurso = mobjCursoContratado.CostoOtic + mobjCursoContratado.GastoEmpresa + mobjCursoContratado.CostoAdm
            mlngTotalViatico = mobjCursoContratado.TotalViatico
            mlngTotalTraslado = mobjCursoContratado.TotalTraslado
            mlngTotalVyT = mobjCursoContratado.TotalViatico + mobjCursoContratado.TotalTraslado
            mlngCostoOticVyT = mobjCursoContratado.CostoOticVYT
            mlngGastoEmpresaVyT = (mobjCursoContratado.TotalViatico + mobjCursoContratado.TotalTraslado) - mobjCursoContratado.CostoOticVYT '(mobjCursoContratado.MontoCtaCapVYT) - (mobjCursoContratado.MontoCtaExcCapVYT)
            mlngCtaCapSaldo2 = mobjCursoContratado.SaldoCtaCapVYT '+ mobjCursoContratado.MontoCtaCapVYT
            mlngCtaCap2 = mobjCursoContratado.MontoCtaCapVYT
            mlngExcCapSaldo2 = mobjCursoContratado.SaldoCtaExdCApVYT '+ mobjCursoContratado.MontoCtaExcCapVYT '(mobjCursoContratado.SaldoCtaExdCApVYT * 0.1) '+ mobjCursoContratado.MontoCtaExcCapVYT
            mlngExcCap2 = mobjCursoContratado.MontoCtaExcCapVYT
            mlngAdminCtaCapVyT = mobjCursoContratado.MontoCtaAdmVYT
            mlngAporteReq2 = mobjCursoContratado.MontoCtaCapVYT
            Dim dtRep As New DataTable
            dtRep = mobjCursoContratado.Terceros
            Dim drRep As DataRow
            Dim drSolic As DataRow
            If Not dtRep Is Nothing Then
                Dim totalReparto As Long = 0
                For Each drRep In dtRep.Rows
                    drSolic = mdtSolicitudes.NewRow
                    drSolic("cod_curso") = drRep("cod_curso")
                    drSolic("rut_benefactor") = RutLngAUsr(drRep("rut_benefactor"))
                    drSolic("monto") = drRep("monto")
                    mdtSolicitudes.Rows.Add(drSolic)
                    totalReparto = totalReparto + drRep("monto")
                Next
                mlngTotalReparto = totalReparto
            End If
        Catch ex As Exception
            EnviaError("CMantenedorCursos.vb:CargaDatos-->" & ex.Message)
        End Try

    End Sub
    'Retorna true si el rut recibido pertenece a un cliente moroso
    Public Function EsMoroso(ByVal lngRut As Long, Optional ByVal strRut As String = "") As Boolean
        Try
            Dim blnFlag As Boolean, i As Integer
            Dim objCuenta As New CCuenta
            mobjCsql = New CSql
            Call objCuenta.inicializarCsql(mobjCsql)
            Dim dt As New DataTable
            dt.Columns.Add("cuenta")
            dt.Columns.Add("saldo")
            blnFlag = False
            Dim dr As DataRow
            'De la cuenta 1 a la 5------------------------
            'No considera la cuenta Becas
            For i = 1 To 5
                objCuenta.ConsultarSaldoMorosidad = True
                Call objCuenta.Inicializar(lngRut, i, strRut)
                If objCuenta.SaldoMorosidad < 0 Then
                    blnFlag = True
                End If
                'Este saldo no considera los aportes que no han sido cobrados (ch y docs a fecha)
                'mcolInfo.Add("Saldo de cuenta " & NombreCuenta(i) & ": " & objCuenta.SaldoMorosidad)
                dr = dt.NewRow
                dr("cuenta") = "Saldo de cuenta " & NombreCuenta(i)
                dr("saldo") = objCuenta.SaldoMorosidad
                dt.Rows.Add(dr)
            Next
            mdtClienteMoroso = dt
            objCuenta = Nothing
            '---------------------------------------------

            EsMoroso = blnFlag
        Catch ex As Exception

        End Try
    End Function

    Protected Sub Correo()
        Try
            Dim objEnviarEmail As New CEnviarCorreo
            Dim objSql As New CSql
            Dim strSubject As String = ""
            Dim strBody As String = ""
            Dim strTo As String = ""
            Dim strNobreSD As String = ""
            Dim strNobreColaborador As String = ""
            Dim strElElla As String = ""
            Dim consultaJefe As DataTable



            'consultaJefe = objSql.s_notificar_jefe_proyecto(mstrJefeProyecto, mlngIdProyecto)
            strSubject = "Ingreso de curso"
            strTo = Parametros.p_MAILAVISOMDB




            strBody = "Se ha ingresado un curso exitosamente " _
                               & vbCr & "DETALLE: " _
                               & vbCr & "Correlativo curso: " & mlngCorrelativo & " Correlativo empresa: " & mstrCorrelEmpresa & vbCr _
                               & "IMPORTANTE: Este mensaje ha sido generado automáticamente por el sistema, favor NO RESPONDER"


            objEnviarEmail.EnviarCorreo(Parametros.p_USUARIOCORREO, strTo, _
                    strSubject, strBody, Parametros.p_SERVIDORCORREO)
        Catch ex As Exception
            EnviaError("CmantenedorProyectos Correo >" & ex.Message)
        End Try

    End Sub
   
End Class
