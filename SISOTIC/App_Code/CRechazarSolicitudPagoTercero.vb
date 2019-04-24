Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CRechazarSolicitudPagoTercero
    Implements IReporte


    'consultas sql y objetos de conexion
    Private mobjSql As New CSql
    Private mobjSolicitud As CSolicitud
    Private mlngFilas As Long
    Private mlngRutUsuario As Long
    Private mlngRutBenefactor As Long
    Private mstrNombreBenefactor As String
    Private mlngCorrelativo As Long
    Private mstrNombreBeneficiado As String
    Private mlngRutCliente As Long
    Private mdtmFechaIngreso As Date
    Private mdtmFechaInicio As Date
    Private mlngMontoSolicitud As Long
    Private mlngSaldoCtaRep As Long
    Private mlngSaldoCtaExcRep As Long
    Private mdblPorcAdmin As Double
    Private mlngCodCurso As Long
    Private mlngNroTransaccion As Long
    Private mblnRechaza As Boolean

    Public Property RutBenefactor() As Long
        Get
            Return mlngRutBenefactor
        End Get
        Set(ByVal value As Long)
            mlngRutBenefactor = value
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
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property NombreBenefactor() As String
        Get
            Return mstrNombreBenefactor
        End Get
        Set(ByVal value As String)
            mstrNombreBenefactor = value
        End Set
    End Property
    Public Property NombreBeneficiado() As String
        Get
            Return mstrNombreBeneficiado
        End Get
        Set(ByVal value As String)
            mstrNombreBeneficiado = value
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
    Public Property RutBeneficiado() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property FechaIngreso() As Date
        Get
            Return mdtmFechaIngreso
        End Get
        Set(ByVal value As Date)
            mdtmFechaIngreso = value
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
    Public Property MontoSolicitud() As Long
        Get
            Return mlngMontoSolicitud
        End Get
        Set(ByVal value As Long)
            mlngMontoSolicitud = value
        End Set
    End Property
    Public Property SaldoCtaRep() As Long
        Get
            Return mlngSaldoCtaRep
        End Get
        Set(ByVal value As Long)
            mlngSaldoCtaRep = value
        End Set
    End Property
    Public Property SaldoCtaExcRep() As Long
        Get
            Return mlngSaldoCtaExcRep
        End Get
        Set(ByVal value As Long)
            mlngSaldoCtaExcRep = value
        End Set
    End Property
    Public Property PorcAdmin() As Double
        Get
            Return mdblPorcAdmin
        End Get
        Set(ByVal value As Double)
            mdblPorcAdmin = value
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
    Public Property NroTransaccion() As Long
        Get
            Return mlngNroTransaccion
        End Get
        Set(ByVal value As Long)
            mlngNroTransaccion = value
        End Set
    End Property
    Public Property Rechaza() As Boolean
        Get
            Return mblnRechaza
        End Get
        Set(ByVal value As Boolean)
            mblnRechaza = value
        End Set
    End Property




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
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    Public Function Consultar() As System.Data.DataTable
        Try
            mobjSql = New CSql
            Dim solicitud As New CReporteSolicitudes
            Dim CCursoContratado As New CCursoContratado
            Dim solicita As New CSolicitud
            Dim cliente As New CCliente
            CCursoContratado.Inicializar0(mobjSql, Me.mlngRutBenefactor)
            CCursoContratado.Inicializar1(mlngCodCurso)
            CCursoContratado.ObtenerInfoCuentas()
            CCursoContratado.ObtenerSolPagoTerc(CodCurso, RutBenefactor)


            solicita.Inicializar0(mobjSql, Me.RutBenefactor)

            solicita.Inicializar1(Me.CodCurso, Me.RutBenefactor, Me.RutBeneficiado)
            'solicita.Inicializar2(mlngRutCliente, mlngRutBenefactor, mlngCodCurso, mlngMontoSolicitud, mlngNroTransaccion)
            solicita.RechazarSolPago()
            ' CCursoContratado.EntregarSolPagoTerc(solicita)
            'cliente.Inicializar0(mobjSql, Me.RutBenefactor)
            'solicitud.RutCliente = Me.mlngRutBenefactor
            'solicitud.Consultar()

            Me.mblnRechaza = solicita.RechazarSolPago()

        Catch ex As Exception

        End Try



    End Function

    Public Function Consultar1() As System.Data.DataTable Implements Clases.IReporte.Consultar

    End Function
End Class
