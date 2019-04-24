Imports Microsoft.VisualBasic

Imports Clases
Imports Modulos
Imports System.Data

Public Class CFichaCursoInterno
    Implements IReporte
    Private objSession As New CSession
    'consultas sql y objetos de conexion
    Private mblnBajarXml As Boolean
    Private mstrXml As String
    Private mlngFilas As Long
    'consultas sql y objetos de conexion
    Private mobjSql As CSql
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
    Private mobjCliente As CCliente
    'Declaracion de un arreglo de Alumnos
    Private mdtAlumnos As DataTable
    Private mcolAlumnos As Collection
    Private mstrRazonSocial As String
    Private mstrNombreComuna As String
    Private mlngCodCurso As Long
    Private mintHoras As Integer

    'Comunes
    Private mobjCsql As New CSql
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get

        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get

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
    Public ReadOnly Property NombreCurso() As String
        Get
            Return mstrNombreCurso
        End Get
    End Property
    Public Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    Public ReadOnly Property NroPerfil() As Long
        Get
            Return mlngNroPerfil
        End Get
    End Property
    Public ReadOnly Property Ejecutor() As String
        Get
            Return mstrEjecutor
        End Get
    End Property
    Public ReadOnly Property Horario() As String
        Get
            Return mstrHorario
        End Get
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
            If mdtmFechaInicio = FechaMinSistema() Then
                FechaInicio = ""
            Else
                FechaInicio = FechaVbAUsr(mdtmFechaInicio)
            End If
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = value
        End Set
    End Property
    Public Property FechaTermino() As Date
        Get
            If mdtmFechaTermino = FechaMaxSistema() Then
                FechaTermino = ""
            Else
                FechaTermino = FechaVbAUsr(mdtmFechaTermino)
            End If
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
    Public ReadOnly Property NomRegion() As String
        Get
            Return mstrNomRegion
        End Get
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
    Public ReadOnly Property Cliente() As CCliente
        Get
            Cliente = mobjCliente
        End Get
    End Property
    'Public Property Alumnos() As DataTable
    '    Get
    '        Alumnos = mdtAlumnos
    '    End Get
    '    Set(ByVal value As DataTable)
    '        If mlngNumAlumnos >= 0 Then
    '            ReDim Preserve mdtAlumnos(mlngNumAlumnos)
    '        End If
    '        mdtAlumnos = value
    '    End Set
    'End Property
    Public Property Alumnos() As Collection
        Get
            Return Me.mcolAlumnos
        End Get
        Set(ByVal value As Collection)
            mcolAlumnos = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return Me.mstrRazonSocial
        End Get
        Set(ByVal value As String)
            Me.mstrRazonSocial = value
        End Set
    End Property
    Property NombreComuna() As String
        Get
            Return Me.mstrNombreComuna
        End Get
        Set(ByVal value As String)
            Me.mstrNombreComuna = value
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
    Public Property Horas() As Integer
        Get
            Return mintHoras
        End Get
        Set(ByVal value As Integer)

            mintHoras = value
        End Set
    End Property


    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            mobjSql = New CSql
            Dim CursoInterno As New CCursoInterno
            'Dim objcliente As New CCliente
            CursoInterno.Inicializar0(mobjCsql, Me.mlngRutCliente)
            CursoInterno.Inicializar1(mlngCodCurso, mintAgno)

            'DC
            Me.mlngRutUsuario = CursoInterno.RutCliente
            Me.mstrRazonSocial = CursoInterno.Cliente.RazonSocial
            Me.mstrDireccionCurso = CursoInterno.Cliente.Direccion
            Me.mstrNombreComuna = CursoInterno.Cliente.Comuna
            Me.mstrNomRegion = CursoInterno.Cliente.Ciudad

            'DCI
            Me.mlngCorrelativo = CursoInterno.Correlativo
            Me.mintCodEstadoCurso = CursoInterno.CodEstadoCurso
            Me.mstrNombreCurso = CursoInterno.NombreCurso
            Me.mstrEjecutor = CursoInterno.Ejecutor
            Me.mlngNumAlumnos = CursoInterno.NumAlumnos
            Me.mstrCorrEmpresa = CursoInterno.CorrEmpresa
            Me.mstrHorario = CursoInterno.Horario
            Me.mintHoras = CursoInterno.Horas
            Me.mstrObservacion = CursoInterno.Observacion
            Me.mlngValorCurso = FormatoMonto(CursoInterno.ValorCurso)
        Catch ex As Exception

        End Try

    End Function


End Class