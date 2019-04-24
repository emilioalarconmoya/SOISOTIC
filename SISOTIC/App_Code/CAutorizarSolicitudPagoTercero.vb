Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CAutorizarSolicitudPagoTercero
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
    Private mblnAutoriza As Boolean
    Private mlngMontoCtaReparto As Long
    Private mlngMontoCtaExcRep As Long
    Private mlngMontoCtaAdm As Long
    Public Property MontoCtaReparto() As Long
        Get
            Return mlngMontoCtaReparto
        End Get
        Set(ByVal value As Long)
            mlngMontoCtaReparto = value
        End Set
    End Property
    Public Property MontoCtaExcRep() As Long
        Get
            Return mlngMontoCtaExcRep
        End Get
        Set(ByVal value As Long)
            mlngMontoCtaExcRep = value
        End Set
    End Property
    Public Property MontoCtaAdm() As Long
        Get
            Return mlngMontoCtaAdm
        End Get
        Set(ByVal value As Long)
            mlngMontoCtaAdm = value
        End Set
    End Property

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
    Public Property Autoriza() As Boolean
        Get
            Return mblnAutoriza
        End Get
        Set(ByVal value As Boolean)
            mblnAutoriza = value
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

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            mobjSql = New CSql
            Dim solicitud As New CReporteSolicitudes
            Dim CCursoContratado As New CCursoContratado
            Dim solicita As New CSolicitud
            Dim cliente As New CCliente
            CCursoContratado.Inicializar0(mobjSql, Me.mlngRutBenefactor)
            CCursoContratado.Inicializar1(mlngCodCurso)
            CCursoContratado.ObtenerSolPagoTerc(CodCurso, RutBenefactor)
            CCursoContratado.ObtenerInfoCuentas()
            'CCursoContratado.EntregarSolPagoTerc(solicita)
            solicita.Inicializar0(mobjSql, Me.RutBenefactor)
            solicita.Inicializar1(Me.CodCurso, Me.RutBenefactor, Me.RutBeneficiado)
            cliente.Inicializar0(mobjSql, Me.RutBenefactor)
            solicitud.RutCliente = Me.mlngRutBenefactor
            solicitud.CodCurso = Me.mlngCodCurso

            solicitud.Consultar()

            Me.RutBenefactor = solicitud.RutBenefactor
            Me.NombreBenefactor = solicitud.NombreBenefactor
            Me.Correlativo = solicitud.Correlativo
            Me.RutBeneficiado = solicitud.RutCliente
            Me.mstrNombreBeneficiado = solicitud.NombreBeneficiado
            Me.FechaIngreso = solicitud.FechaIngreso
            Me.FechaInicio = solicitud.FechaInicio
            Me.MontoSolicitud = solicitud.MontoSolicitud
            Me.SaldoCtaRep = solicita.SaldoCtaRep
            Me.SaldoCtaExcRep = solicita.SaldoCtaExcRep
            Me.PorcAdmin = solicita.PorcAdm
            Me.CodCurso = solicitud.CodCurso

        Catch ex As Exception

        End Try

    End Function


    Public Function Consultar2() As System.Data.DataTable 
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
            solicita.MontoCtaReparto = Me.mlngMontoCtaReparto
            solicita.MontoCtaExcRep = Me.mlngMontoCtaExcRep
            solicita.MontoCtaAdm = Me.mlngMontoCtaAdm
    
            Me.mblnAutoriza = solicita.AutorizarSolPago()
            CCursoContratado.EntregarSolPagoTerc(solicita)
            cliente.Inicializar0(mobjSql, Me.RutBenefactor)
         
        Catch ex As Exception

        End Try

    End Function


    'Public Function Consultar3() As System.Data.DataTable
    '    Try
    '        mobjSql = New CSql
    '        Dim solicitud As New CReporteSolicitudes
    '        Dim CCursoContratado As New CCursoContratado
    '        Dim solicita As New CSolicitud
    '        Dim cliente As New CCliente
    '        CCursoContratado.Inicializar0(mobjSql, Me.mlngRutBenefactor)
    '        CCursoContratado.Inicializar1(mlngCodCurso)
    '        CCursoContratado.ObtenerSolPagoTerc(CodCurso, RutBenefactor)
    '        CCursoContratado.ObtenerInfoCuentas()
    '        CCursoContratado.EntregarSolPagoTerc(solicita)
    '        solicita.Inicializar0(mobjSql, Me.RutBenefactor)

    '        solicita.Inicializar1(Me.CodCurso, Me.RutBenefactor, Me.RutBeneficiado)
    '        'solicita.Inicializar2(mlngRutCliente, mlngRutBenefactor, mlngCodCurso, mlngMontoSolicitud, mlngNroTransaccion)
    '        solicita.RechazarSolPago()
    '        'cliente.Inicializar0(mobjSql, Me.RutBenefactor)
    '        'solicitud.RutCliente = Me.mlngRutBenefactor
    '        'solicitud.Consultar()
    '    Catch ex As Exception

    '    End Try



    'End Function


End Class
