Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CFichaCursoSence
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
    'total duracion curso
    Private mlngDurCurso As Long
    'número máximo de participantes
    Private mlngNumMaxParticip As Long
    'Nombre sede
    Private mstrNombreSede As String
    'Fono sede
    Private mstrFonoSede As String
    Private mstrFax As String

    Private mstrEmail As String
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
    Public Property CodSence() As String
        Get
            Return mstrCodSence
        End Get
        Set(ByVal value As String)
            mstrCodSence = value
        End Set
    End Property
    'Public ReadOnly Property CodSence() As String
    '    Get
    '        Return mstrCodSence
    '    End Get
    'End Property
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
    'Public ReadOnly Property DurCurso() As Long
    '    Get
    '        DurCurso = mlngDurCursoTeorico + mlngDurCursoPractico
    '    End Get
    'End Property
    Public Property DurCurso() As Long
        Get
            Return mlngDurCurso '= mlngDurCursoTeorico + mlngDurCursoPractico
        End Get
        Set(ByVal value As Long)
            mlngDurCurso = value
        End Set
    End Property
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
    Public ReadOnly Property Fax() As String
        Get
            Return mstrFax
        End Get
    End Property
    Public ReadOnly Property Email() As String
        Get
            Return mstrEmail
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
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    'Public ReadOnly Property RutUsuario() As Long
    '    Get
    '        Return mlngRutUsuario
    '    End Get
    'End Property
    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            mobjSql = New CSql
            Dim otec As New COtec
            Dim CursoSence As New CCurso
            CursoSence.Inicializar0(mobjSql, Me.RutUsuario)
            CursoSence.Inicializar1(mstrCodSence)

            Me.mstrNombreCurso = CursoSence.NombreCurso
            Me.mstrCodSence = CursoSence.CodSence
            Me.mlngDurCurso = CursoSence.DurCurso 'CursoSence.DurCurso = (Me.mlngDurCursoPractico + Me.mlngDurCursoTeorico)
            Me.mstrArea = CursoSence.Area
            Me.mstrEspecialidad = CursoSence.Especialidad
            Me.mstrNombreSede = CursoSence.Otec.NombreFantasia
            Me.mlngRutOtec = CursoSence.Otec.RutFormateadoOtec
            Me.mstrFonoSede = CursoSence.Otec.Fono
            Me.mstrFax = CursoSence.Otec.Fax
            Me.mstrEmail = CursoSence.Otec.Email


        Catch ex As Exception

        End Try
    End Function

End Class
