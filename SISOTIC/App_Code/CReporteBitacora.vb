Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteBitacora
    Implements IReporte
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    Private mlngTipoReferencia As Long
    Private mdtmFechaInicio As Date
    Private mdtmFechaTermino As Date
    Private mlngRutUsuario As Long
    Private mlngCodCurso As Long
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
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
    Public Property TipoReferencia() As Long
        Get
            Return mlngTipoReferencia
        End Get
        Set(ByVal value As Long)
            mlngTipoReferencia = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim dtBitacora As DataTable
            dtBitacora = mobjSql.s_bitacora(mlngRutUsuario, mdtmFechaInicio, mdtmFechaTermino, mlngTipoReferencia, mlngCodCurso)
            Return dtBitacora
        Catch ex As Exception
        End Try
    End Function
End Class
