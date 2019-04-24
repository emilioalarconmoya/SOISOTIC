Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorFactura
    Private mobjCsql As CSql
    Private mobjReporteFactura As CReporteFactura
    Private mobjFactura As CFactura
    'rut del usuario
    Private mlngRutUsuario As Long
    'estado de las facturas
    Private mstrEstadoFac As String

    'Criterios de búsqueda
    'Estado Factura
    Private mintCodEstadoFactura As Integer
    'Rut Empresa
    Private mlngRutEmpresa As Long
    'Rut Otec
    Private mlngRutOtec As Long
    'Número Factura
    Private mlngNumFactura As Long
    'año de consulta
    Private mintAgno As Integer
    'arreglo para el lookup de estados facturas
    Private mdtLookUpEstadosFac As DataTable
    'Arreglo con las Etiquetas para impresion
    Private mdtEtiquetas As DataTable
    'objeto con consultas SQL
    Private mobjSql As CSql
    Private mlngCorrelativo As Long
    Private mlngNroRegistro As Long
    Private mlngCodigoSence As Long
    Private mstrNombreCurso As String
    Private mstrNombreOtec As String
    Private mintCodEstadoCurso As Integer
    Private mstrNombreEstadoCurso As String
    Private mlngRutCliente As Long
    Private mstrNombreCliente As String
    Private mdtmFechaInicio As Date
    Private mdtmFechaTermino As Date
    Private mlngNumAlumnos As Long
    Private mstrCorrEmpresa As String
    Private mlngMontoFactura As Long
    Private mdtmFechaFactura As Date
    Private mdtmFechaRecepcion As Date
    Private mdtmFechaPago As Date
    Private mlngNroPerfil As Long
    Private mstrModo As String
    Private mlngCodCurso As Long
    Private mstrObservaciones As String
    Private mlngValorComunicado As Long
    Private mlngNroVoucher As Long
    Private mlngNotaCredito As Long
    Private mstrNroEgreso As String
    Public Property ValorComunicado() As Long
        Get
            Return mlngValorComunicado
        End Get
        Set(ByVal value As Long)
            mlngValorComunicado = value
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
    Public Property NroEgreso() As String
        Get
            Return mstrNroEgreso
        End Get
        Set(ByVal value As String)
            mstrNroEgreso = value
        End Set
    End Property

    Public Property FechaPago() As Date
        Get
            Return mdtmFechaPago
        End Get
        Set(ByVal value As Date)
            mdtmFechaPago = value
        End Set
    End Property
    Public Property FechaRecepcion() As Date
        Get
            Return mdtmFechaRecepcion
        End Get
        Set(ByVal value As Date)
            mdtmFechaRecepcion = value
        End Set
    End Property
    Public Property FechaFactura() As Date
        Get
            Return mdtmFechaFactura
        End Get
        Set(ByVal value As Date)
            mdtmFechaFactura = value
        End Set
    End Property
    Public Property MontoFactura() As Long
        Get
            Return mlngMontoFactura
        End Get
        Set(ByVal value As Long)
            mlngMontoFactura = value
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
    Public Property NumAlumnos() As Long
        Get
            Return mlngNumAlumnos
        End Get
        Set(ByVal value As Long)
            mlngNumAlumnos = value
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
    Public Property FechaInicio() As Date
        Get
            Return mdtmFechaInicio
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = value
        End Set
    End Property
    Public Property NombreCliente() As String
        Get
            Return mstrNombreCliente
        End Get
        Set(ByVal value As String)
            mstrNombreCliente = value
        End Set
    End Property
    Public Property NroVoucher() As Long
        Get
            Return mlngNroVoucher
        End Get
        Set(ByVal value As Long)
            mlngNroVoucher = value
        End Set
    End Property
    Public Property NotaCredito() As Long
        Get
            Return mlngNotaCredito
        End Get
        Set(ByVal value As Long)
            mlngNotaCredito = value
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
    Public Property NombreEstadoCurso() As String
        Get
            Return mstrNombreEstadoCurso
        End Get
        Set(ByVal value As String)
            mstrNombreEstadoCurso = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Observacion = mstrObservaciones
        End Get
        Set(ByVal value As String)
            mstrObservaciones = value
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
    Public Property NombreOtec() As String
        Get
            Return mstrNombreOtec
        End Get
        Set(ByVal value As String)
            mstrNombreOtec = value
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
    Public Property NroPerfil() As Long
        Get
            Return mlngNroPerfil
        End Get
        Set(ByVal value As Long)
            mlngNroPerfil = value
        End Set
    End Property
    Public Property CodigoSence() As Long
        Get
            Return mlngCodigoSence
        End Get
        Set(ByVal value As Long)
            mlngCodigoSence = value
        End Set
    End Property
    Public Property NroRegistro() As Long
        Get
            Return mlngNroRegistro
        End Get
        Set(ByVal value As Long)
            mlngNroRegistro = value
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
    Public Property RutUsuario() As Long
        Get
            RutUsuario = mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property EstadoFac() As String
        Get
            EstadoFac = mstrEstadoFac
        End Get
        Set(ByVal value As String)
            mstrEstadoFac = value
        End Set
    End Property
    Public Property CodEstadoFactura() As Integer
        Get
            CodEstadoFactura = mintCodEstadoFactura
        End Get
        Set(ByVal value As Integer)
            mintCodEstadoFactura = value
        End Set
    End Property
    Public Property RutEmpresa() As Long
        Get
            RutEmpresa = mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property
    Public Property RutOtec() As Long
        Get
            RutOtec = mlngRutOtec
        End Get
        Set(ByVal value As Long)
            mlngRutOtec = value
        End Set
    End Property
    Public Property NumFactura() As Long
        Get
            NumFactura = mlngNumFactura
        End Get
        Set(ByVal value As Long)
            mlngNumFactura = value
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
    Public ReadOnly Property LookUpEstadosFac() As DataTable
        Get
            LookUpEstadosFac = mdtLookUpEstadosFac
        End Get
    End Property
    Public Property Etiquetas() As DataTable
        Get
            Etiquetas = mdtEtiquetas
        End Get
        Set(ByVal value As DataTable)
            mdtEtiquetas = value
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
    Public Sub Inicializar()
        mlngCodCurso = gValorNumNulo
        mlngCorrelativo = gValorNumNulo
        mlngNroRegistro = gValorNumNulo
        mlngCodigoSence = gValorNumNulo
        mstrNombreCurso = ""
        mlngRutOtec = gValorNumNulo
        mstrNombreOtec = ""
        mintCodEstadoCurso = gValorNumNulo
        mstrNombreEstadoCurso = ""
        mlngRutCliente = gValorNumNulo
        mstrNombreCliente = ""
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaTermino = FechaMinSistema()
        mlngNumAlumnos = gValorNumNulo
        mstrCorrEmpresa = ""
        mlngNumFactura = gValorNumNulo
        mlngMontoFactura = gValorNumNulo
        mdtmFechaFactura = FechaMinSistema()
        mdtmFechaRecepcion = FechaMinSistema()
        mdtmFechaPago = FechaMinSistema()
        mstrEstadoFac = ""
        mlngNroPerfil = gValorNumNulo
        mstrObservaciones = ""
        mlngNroVoucher = 0
        mstrNroEgreso = ""
    End Sub

    Public Sub CargarDatos()
        Try
            mobjSql = New CSql
            Dim mobjCursoContratado As New CCursoContratado
            mobjReporteFactura = New CReporteFactura
            'mlngCodCurso = mobjReporteFactura.CodCurso
            'mlngRutUsuario = mobjReporteFactura.RutUsuario
            mobjReporteFactura.Inicializar0(mobjSql)
            mobjReporteFactura.Consultar()
            mobjCursoContratado.Inicializar0(mobjSql, mlngRutUsuario)
            mobjCursoContratado.Inicializar1(mlngCodCurso)

            mlngValorComunicado = mobjCursoContratado.ValorComunicado




            mlngCodCurso = mobjReporteFactura.CodCurso
            mlngCorrelativo = mobjReporteFactura.Correlativo
            mlngNroRegistro = mobjReporteFactura.Nroregistro
            mlngCodigoSence = mobjReporteFactura.CodigoSence
            mstrNombreCurso = mobjReporteFactura.NombreCurso
            mlngRutOtec = mobjReporteFactura.RutOtec
            mstrNombreOtec = mobjReporteFactura.NombreOtec
            mintCodEstadoCurso = mobjReporteFactura.CodEstadoCurso
            mstrNombreEstadoCurso = mobjReporteFactura.NombreEstadoCurso
            mlngRutCliente = mobjReporteFactura.RutCliente
            mstrNombreCliente = mobjReporteFactura.NombreCliente
            mdtmFechaInicio = mobjReporteFactura.FechaInicio
            mdtmFechaTermino = mobjReporteFactura.FechaTermino
            mlngNumAlumnos = mobjReporteFactura.NumAlumnos
            mstrCorrEmpresa = mobjReporteFactura.CorrEmpresa
            mlngNumFactura = mobjReporteFactura.NumFactura
            mlngMontoFactura = mobjReporteFactura.MontoFactura
            mdtmFechaFactura = mobjReporteFactura.FechaFactura
            mdtmFechaRecepcion = mobjReporteFactura.FechaRecepcion
            mdtmFechaPago = mobjReporteFactura.FechaPago
            mstrEstadoFac = mobjReporteFactura.EstadoFac
            mlngNroPerfil = mobjReporteFactura.NroPerfil
            mstrNroEgreso = mobjReporteFactura.NroEgreso
        Catch ex As Exception
            EnviaError("CMantenedorFactura.vb:CargarDatos-->" & ex.Message)
        End Try
    End Sub
    Public Sub GrabarDatos()
        Try
            mobjReporteFactura = New CReporteFactura
            mobjFactura = New CFactura
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjReporteFactura.Inicializar0(mobjCsql)
            mobjReporteFactura.Consultar()
            mobjReporteFactura.CodCurso = mlngCodCurso
            mobjReporteFactura.Correlativo = mlngCorrelativo
            mobjReporteFactura.Nroregistro = mlngNroRegistro
            mobjReporteFactura.CodigoSence = mlngCodigoSence
            mobjReporteFactura.NombreCurso = mstrNombreCurso
            mobjReporteFactura.RutOtec = mlngRutOtec
            mobjReporteFactura.NombreOtec = mstrNombreOtec
            mobjReporteFactura.CodEstadoCurso = mintCodEstadoCurso
            mobjReporteFactura.NombreEstadoCurso = mstrNombreEstadoCurso
            mobjReporteFactura.RutCliente = mlngRutCliente
            mobjReporteFactura.NombreCliente = mstrNombreCliente
            mobjReporteFactura.FechaInicio = mdtmFechaInicio
            mobjReporteFactura.FechaTermino = mdtmFechaTermino
            mobjReporteFactura.NumAlumnos = mlngNumAlumnos
            mobjReporteFactura.CorrEmpresa = mstrCorrEmpresa
            mobjReporteFactura.NumFactura = mlngNumFactura
            mobjReporteFactura.MontoFactura = mlngMontoFactura
            mobjReporteFactura.FechaFactura = mdtmFechaFactura
            mobjReporteFactura.FechaRecepcion = mdtmFechaRecepcion
            mobjReporteFactura.FechaPago = mdtmFechaPago
            mobjReporteFactura.EstadoFac = mstrEstadoFac
            mobjReporteFactura.NroPerfil = mlngNroPerfil
            mobjReporteFactura.Observacion = mstrObservaciones
            mobjReporteFactura.NroVoucher = mlngNroVoucher
            mobjReporteFactura.NotaCredito = mlngNotaCredito
            mobjReporteFactura.NroEgreso = mstrNroEgreso
            mobjFactura.RutUsuario = mlngRutUsuario
            mobjFactura.Inicializar(mobjCsql)
            mobjFactura.Modificar(mlngCodCurso, mintCodEstadoFactura, mlngNumFactura, mdtmFechaFactura, mdtmFechaRecepcion, mdtmFechaPago, _
                                  mlngMontoFactura, mlngNroVoucher, mstrObservaciones)
            CargarDatos()
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorFactura.vb:GrabarDatos-->" & ex.Message)
        End Try
    End Sub
    Public Sub InsertarDatos()
        Try
            mobjReporteFactura = New CReporteFactura
            mobjFactura = New CFactura
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            mobjReporteFactura.Inicializar(mobjCsql)
            mobjReporteFactura.Consultar()
            mobjReporteFactura.CodCurso = mlngCodCurso
            mobjReporteFactura.Correlativo = mlngCorrelativo
            mobjReporteFactura.Nroregistro = mlngNroRegistro
            mobjReporteFactura.CodigoSence = mlngCodigoSence
            mobjReporteFactura.NombreCurso = mstrNombreCurso
            mobjReporteFactura.RutOtec = mlngRutOtec
            mobjReporteFactura.NombreOtec = mstrNombreOtec
            mobjReporteFactura.CodEstadoCurso = mintCodEstadoCurso
            mobjReporteFactura.NombreEstadoCurso = mstrNombreEstadoCurso
            mobjReporteFactura.RutCliente = mlngRutCliente
            mobjReporteFactura.NombreCliente = mstrNombreCliente
            mobjReporteFactura.FechaInicio = mdtmFechaInicio
            mobjReporteFactura.FechaTermino = mdtmFechaTermino
            mobjReporteFactura.NumAlumnos = mlngNumAlumnos
            mobjReporteFactura.CorrEmpresa = mstrCorrEmpresa
            mobjReporteFactura.NumFactura = mlngNumFactura
            mobjReporteFactura.MontoFactura = mlngMontoFactura
            mobjReporteFactura.FechaFactura = mdtmFechaFactura
            mobjReporteFactura.FechaRecepcion = mdtmFechaRecepcion
            mobjReporteFactura.FechaPago = mdtmFechaPago
            mobjReporteFactura.EstadoFac = mstrEstadoFac
            mobjReporteFactura.NroPerfil = mlngNroPerfil
            mobjReporteFactura.Observacion = mstrObservaciones
            mobjReporteFactura.NroVoucher = mlngNroVoucher
            mobjReporteFactura.NotaCredito = mlngNotaCredito
            mobjReporteFactura.NroEgreso = mstrNroEgreso
            mobjFactura.RutUsuario = mlngRutUsuario

            mobjFactura.Inicializar1(mlngCodCurso, mintCodEstadoFactura, mlngNumFactura, mdtmFechaFactura, mdtmFechaRecepcion, mdtmFechaPago, _
                                     mlngMontoFactura, mlngNroVoucher, mstrObservaciones)
            CargarDatos()
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CMantenedorFactura.vb:GrabarDatos-->" & ex.Message)
        End Try
    End Sub
End Class
