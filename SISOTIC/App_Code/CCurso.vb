Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CCurso
    Implements IReporte
    Private objSession As New CSession
    'consultas sql y objetos de conexion
    Private mblnBajarXml As Boolean
    Private mstrXml As String
    Private mlngFilas As Long
    'objeto de coneccion a bd y de implements ireporte
    Private mobjSql As CSql

    'código sence
    Private mstrCodSence As String
    'nombre del curso
    Private mstrNombreCurso As String
    Private mlngRutOtec As Long
    'string con el area asignada por el Sence
    Private mstrArea As String
    'string con la especialidad asignada por el Sence
    Private mstrEspecialidad As String
    'duración de curso teorico
    Private mlngDurCursoTeorico As Long
    'duración curso practico
    Private mlngDurCursoPractico As Long
    'número máximo de participantes
    Private mlngNumMaxParticip As Long
    'Nombre sede
    Private mstrNombreSede As String
    'Fono sede
    Private mstrFonoSede As String
    'Direccion
    Private mstrDireccion As String
    'Codigo Comuna
    Private mlngCodComuna As Long
    'Nombre Comuna
    Private mstrComuna As String
    'indica si el curso existe en la base de datos del sence
    Private mblnPendiente As Boolean
    'Valor del curso
    Private mlngValorCurso As Long
    'arreglo para el lookup de comunas
    Private mdtLookUpComunas As DataTable
    'otec
    Private mobjOtec As COtec
    'consultas sql
    Private mlngRutUsuario As Long
    'es curso e-learning
    Private mblnElearning As Boolean
    Private mlngDurCurElearning As Long

    Private mintCodModalidad As Integer
    Private mintValorHora As Integer
    Private mblnVigente As Boolean

    Public ReadOnly Property Modalidad() As Integer
        Get
            Return mintCodModalidad
        End Get
    End Property
    Public ReadOnly Property ValorHora() As Integer
        Get
            Return mintValorHora
        End Get
    End Property
    Public ReadOnly Property Vigente() As Boolean
        Get
            Return mblnVigente
        End Get
    End Property

    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return Me.mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXml = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property
    Public ReadOnly Property CodSence() As String
        Get
            Return mstrCodSence
        End Get
    End Property
    Public ReadOnly Property NombreCurso() As String
        Get
            Return mstrNombreCurso
        End Get
    End Property
    Public ReadOnly Property RutOtec() As Long
        Get
            Return mlngRutOtec
        End Get
    End Property
    Public ReadOnly Property Area() As String
        Get
            Return mstrArea
        End Get
    End Property
    Public ReadOnly Property Especialidad() As String
        Get
            Return mstrEspecialidad
        End Get
    End Property
    Public ReadOnly Property DurCursoTeorico() As Long
        Get
            Return mlngDurCursoTeorico
        End Get
    End Property
    Public ReadOnly Property DurCursoPractico() As Long
        Get
            Return mlngDurCursoPractico
        End Get
    End Property
    'Public Property DurCurso() As Long
    '    Get
    '        DurCurso = mlngDurCursoTeorico + mlngDurCursoPractico
    '    End Get
    '    Set(ByVal value As Long)
    '        value = (Me.mlngDurCursoTeorico + Me.mlngDurCursoPractico)
    '    End Set
    'End Property
    Public Property DurCurso() As Long
        Get
            DurCurso = mlngDurCursoTeorico + mlngDurCursoPractico + mlngDurCurElearning
        End Get
        Set(ByVal value As Long)
            DurCurso = value
        End Set
    End Property

    'Public ReadOnly Property DurCurso() As Long
    '    Get
    '        DurCurso = mlngDurCursoTeorico + mlngDurCursoPractico
    '    End Get
    'End Property
    Public ReadOnly Property NumMaxParticip() As Long
        Get
            Return mlngNumMaxParticip
        End Get
    End Property
    Public ReadOnly Property NombreSede() As String
        Get
            Return mstrNombreSede
        End Get
    End Property
    Public ReadOnly Property FonoSede() As String
        Get
            Return mstrFonoSede
        End Get
    End Property
    Public ReadOnly Property Direccion() As String
        Get
            Return mstrDireccion
        End Get
    End Property
    Public ReadOnly Property CodComuna() As Long
        Get
            Return mlngCodComuna
        End Get
    End Property
    Public ReadOnly Property Comuna() As String
        Get
            Return mstrComuna
        End Get
    End Property
    Public ReadOnly Property Pendiente() As Boolean
        Get
            Return mblnPendiente
        End Get
    End Property
    Public ReadOnly Property ValorCurso() As Long
        Get
            Return mlngValorCurso
        End Get
    End Property
    Public ReadOnly Property LookUpComunas() As DataTable
        Get
            LookUpComunas = mdtLookUpComunas
        End Get
    End Property
    Public ReadOnly Property Otec() As COtec
        Get
            Return mobjOtec
        End Get
    End Property
    Public ReadOnly Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
    End Property
    Public ReadOnly Property Elearning() As Boolean
        Get
            Return mblnElearning
        End Get
    End Property
    Public Property DurCurElearning() As Long
        Get
            Return mlngDurCurElearning
        End Get
        Set(ByVal value As Long)
            mlngDurCurElearning = value
        End Set
    End Property

    Public Sub New()
        

        mstrCodSence = ""
        mstrNombreCurso = ""
        mlngRutOtec = 0
        mstrArea = ""
        mstrEspecialidad = ""
        mlngDurCursoTeorico = 0
        mlngDurCursoPractico = 0
        mlngDurCurElearning = 0
        mlngNumMaxParticip = 0
        mstrNombreSede = ""
        mstrFonoSede = ""
        mstrDireccion = ""
        mlngCodComuna = 0
        mstrComuna = ""
        mblnPendiente = False
        mblnElearning = False


        mintCodModalidad = 1
        mintValorHora = 0
        mblnVigente = False

        Exit Sub

Class_InitializeErr:
        EnviaError("cCurso:Class_Initialize Method")
    End Sub
    Sub Carga_Lookup()
        mdtLookUpComunas = mobjSql.s_comunas_todos
    End Sub

    'inicialización del objeto
    Public Sub Inicializar0(ByRef objSql As CSql, _
                            ByVal lngRutUsuario As Long)
        mobjSql = objSql
        Call Carga_Lookup()
        If lngRutUsuario <= 0 Then
            EnviaError("cCurso:Inicializar0 Method - Usuario desconocido")
            Exit Sub
        End If
        mlngRutUsuario = lngRutUsuario
    End Sub

    'constructor de curso con código sence. Retorna True si existe
    Public Function Inicializar1(ByVal strCodSence As String) As Boolean
        Try
            Dim dtCurso As DataTable
            dtCurso = mobjSql.s_curso_1(strCodSence)

            'If TamanoArreglo2(dtCurso) = 0 Then
            '    Inicializar1 = False
            '    Exit Function
            'End If

            If mobjSql.Registros Then
                'asignación de valores
                mstrCodSence = strCodSence
                mstrNombreCurso = dtCurso.Rows(0)(0)
                mlngRutOtec = dtCurso.Rows(0)(1)
                mstrArea = dtCurso.Rows(0)(2)
                mstrEspecialidad = dtCurso.Rows(0)(3)
                mlngDurCursoTeorico = dtCurso.Rows(0)(4)
                mlngDurCursoPractico = dtCurso.Rows(0)(5)
                mlngNumMaxParticip = dtCurso.Rows(0)(6)
                mstrNombreSede = dtCurso.Rows(0)(7)
                mstrFonoSede = Trim(dtCurso.Rows(0)(8))
                mstrDireccion = dtCurso.Rows(0)(9)
                mlngCodComuna = dtCurso.Rows(0)(10)
                mblnPendiente = dtCurso.Rows(0)(11)
                mstrComuna = dtCurso.Rows(0)(12)
                mlngValorCurso = dtCurso.Rows(0)(13)
                'mblnElearning = dtCurso.Rows(0)(14)
                mintCodModalidad = dtCurso.Rows(0)(15)
                mintValorHora = dtCurso.Rows(0)(14)
                'mblnVigente = dtCurso.Rows(0)(15)
                mlngDurCurElearning = dtCurso.Rows(0)(16)



                mobjOtec = New COtec
                mobjOtec.Inicializar0(mobjSql, mlngRutUsuario)
                mobjOtec.Inicializar1(RutLngAUsr(mlngRutOtec))


                Inicializar1 = True
                Exit Function
            End If
        Catch ex As Exception
            EnviaError("cCurso:Inicializar1-->" & ex.Message)
        End Try

    End Function

    Public Function Inicializar2(ByVal strCodSence As String, ByVal strNombreCurso As String, _
                             ByVal strRutotec As String, ByVal strArea As String, _
                             ByVal strEspecialidad As String, ByVal lngDurCursoTeo As Long, _
                             ByVal lngDurCursoPrac As Long, _
                             ByVal lngNMaxPart As Long, ByVal strNombreSede As String, _
                             ByVal strFonoSede As String, ByVal strDireccion As String, _
                             ByVal lngCodComuna As Long, ByVal lngValorCurso As Long, _
                             ByVal intCodModalidad As Integer, ByVal lngDurCurElearning As Long, _
                             ByVal intValorHora As Integer) As Boolean


        Dim objVal As New CValidaciones

        Call objVal.Inicializar(mobjSql)

        If Not objVal.EsOtec(strRutotec) Then
            Inicializar2 = False
            Exit Function
        End If

        objVal = Nothing

        mstrCodSence = strCodSence
        mstrNombreCurso = strNombreCurso
        mlngRutOtec = RutUsrALng(strRutotec)
        mstrArea = strArea
        mstrEspecialidad = strEspecialidad
        mlngDurCursoTeorico = lngDurCursoTeo
        mlngDurCursoPractico = lngDurCursoPrac
        mlngNumMaxParticip = lngNMaxPart
        mstrNombreSede = strNombreSede
        mstrFonoSede = strFonoSede
        mstrDireccion = strDireccion
        mlngCodComuna = lngCodComuna
        mblnPendiente = False
        mlngValorCurso = lngValorCurso
        mlngDurCurElearning = lngDurCurElearning
        mintCodModalidad = intCodModalidad
        mintValorHora = intValorHora

        If mobjOtec Is Nothing Then
            mobjOtec = New COtec
        End If
        Call mobjOtec.Inicializar(mobjSql)
        If Not mobjOtec.Inicializar1(strRutotec) Then
            Inicializar2 = False
            Exit Function
        End If

        Inicializar2 = True
        Exit Function
Inicializar2Err:
        EnviaError("cCurso:Inicializar2 Method")
    End Function
    'graba el curso en la base de datos
    Public Function Grabar() As Boolean
       

        'abrir transaccion
        mobjSql.InicioTransaccion()



        Call mobjSql.i_cursos(mstrCodSence, mstrNombreCurso, mlngRutOtec, _
                              mstrArea, mstrEspecialidad, mlngDurCursoTeorico, mlngDurCursoPractico, _
                              mlngNumMaxParticip, mstrNombreSede, mstrFonoSede, mstrDireccion, _
                              mlngCodComuna, mblnPendiente, mlngValorCurso, mblnElearning, mintCodModalidad, _
                              mlngDurCurElearning, mintValorHora)

        mobjSql.FinTransaccion()

        Grabar = True
        Exit Function
GrabarErr:
        Grabar = False
        Call mobjSql.RollBackTransaccion()
        EnviaError("cCurso:Grabar Method")
    End Function

    'modifica los datos del curso en la BD
    Public Function Modificar() As Boolean
      

        'abrir transaccion
        mobjSql.InicioTransaccion()


        Call mobjSql.u_Cursos(mstrCodSence, mstrNombreCurso, mlngRutOtec, _
                              mstrArea, mstrEspecialidad, mlngDurCursoTeorico, mlngDurCursoPractico, _
                              mlngNumMaxParticip, mstrNombreSede, mstrFonoSede, mstrDireccion, _
                              mlngCodComuna, mblnPendiente, mlngValorCurso, mblnElearning, mintCodModalidad, _
                              mlngDurCurElearning, mintValorHora)

        mobjSql.FinTransaccion()
        Modificar = True
        Exit Function
ModificarErr:
        Modificar = False
        Call mobjSql.RollBackTransaccion()
        EnviaError("cCurso:Modificar Method")
    End Function




    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar


        Try

        Catch ex As Exception
            EnviaError("CFichaActividad->Consultar" & ex.Message)
        End Try
    End Function






End Class

