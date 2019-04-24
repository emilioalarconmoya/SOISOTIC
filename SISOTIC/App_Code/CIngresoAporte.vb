Imports Clases
Imports Modulos
Imports System.Data
Imports System

Public Class CIngresoAporte
    Private mobjCsql As CSql
    Private mobjCliente As CCliente
    Private mobjAporte As CAporte

    Private mlngRutUsuario As Long

    ' EMPRESA
    Private mlngRut As Long
    Private mintAgno As Integer
    Private mstrNombre As String
    ' SALDOS
    Private mlngSaldoCap As Long
    Private mlngSaldoRep As Long
    Private mlngSaldoCer As Long
    Private mlngSaldoBec As Long
    Private mstrObservaciones As String
    ' APORTES
    Private mlngCodAporte As Long
    Private mlngNumAporte As Long
    Private mlngCorrelativo As Long
    Private mlngTotalAporte As Long
    Private mintCodCuenta As Integer
    Private mlngMontoNeto As Long
    Private mlngMontoAdm As Long
    Private mdblPorcAdmin As Double
    Private mlngAdmNoLineal As Long
    Private mdtmFechaIngreso As Date
    ' DOCUMENTOS
    Private mintCodTipoDocto As Integer
    Private mstrNumDocto As String
    Private mstrBanco As String
    Private mdtmFechaVenc As Date
    Private mintCodEstado As Integer
    Private mdtmFechaCobro As Date
    Private mstrEstado As String
    Private mstrOrigen As String

    Private mstrGlosa As String

    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property

    Public Property Rut() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
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
    Public Property Nombre() As String
        Get
            Return mstrNombre.Trim
        End Get
        Set(ByVal value As String)
            mstrNombre = value.Trim
        End Set
    End Property
    Public Property SaldoCap() As Long
        Get
            Return mlngSaldoCap
        End Get
        Set(ByVal value As Long)
            mlngSaldoCap = value
        End Set
    End Property
    Public Property SaldoRep() As Long
        Get
            Return mlngSaldoRep
        End Get
        Set(ByVal value As Long)
            mlngSaldoRep = value
        End Set
    End Property
    Public Property SaldoCer() As Long
        Get
            Return mlngSaldoCer
        End Get
        Set(ByVal value As Long)
            mlngSaldoCer = value
        End Set
    End Property
    Public Property SaldoBec() As Long
        Get
            Return mlngSaldoBec
        End Get
        Set(ByVal value As Long)
            mlngSaldoBec = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return mstrObservaciones.Trim
        End Get
        Set(ByVal value As String)
            mstrObservaciones = value.Trim
        End Set
    End Property
    Public Property CodAporte() As Long
        Get
            Return mlngCodAporte
        End Get
        Set(ByVal value As Long)
            mlngCodAporte = value
        End Set
    End Property
    Public Property NumAporte() As Long
        Get
            Return mlngNumAporte
        End Get
        Set(ByVal value As Long)
            mlngNumAporte = value
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
    Public Property TotalAporte() As Long
        Get
            Return mlngTotalAporte
        End Get
        Set(ByVal value As Long)
            mlngTotalAporte = value
        End Set
    End Property
    Public Property CodCuenta() As Integer
        Get
            Return mintCodCuenta
        End Get
        Set(ByVal value As Integer)
            mintCodCuenta = value
        End Set
    End Property
    Public Property MontoNeto() As Long
        Get
            Return mlngMontoNeto
        End Get
        Set(ByVal value As Long)
            mlngMontoNeto = value
        End Set
    End Property
    Public Property MontoAdm() As Long
        Get
            Return mlngMontoAdm
        End Get
        Set(ByVal value As Long)
            mlngMontoAdm = value
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
    Public Property AdmNoLineal() As Long
        Get
            Return mlngAdmNoLineal
        End Get
        Set(ByVal value As Long)
            mlngAdmNoLineal = value
        End Set
    End Property
    Public Property FechaIngreso() As Date
        Get
            Return FechaVbAUsr(mdtmFechaIngreso)
        End Get
        Set(ByVal value As Date)
            mdtmFechaIngreso = value
        End Set
    End Property
    Public Property CodTipoDocto() As Integer
        Get
            Return mintCodTipoDocto
        End Get
        Set(ByVal value As Integer)
            mintCodTipoDocto = value
        End Set
    End Property
    Public Property NumDocto() As String
        Get
            Return mstrNumDocto.Trim
        End Get
        Set(ByVal value As String)
            mstrNumDocto = value.Trim
        End Set
    End Property
    Public Property Banco() As String
        Get
            Return mstrBanco.Trim
        End Get
        Set(ByVal value As String)
            mstrBanco = value.Trim
        End Set
    End Property
    Public Property FechaVenc() As Date
        Get
            Return FechaVbAUsr(mdtmFechaVenc)
        End Get
        Set(ByVal value As Date)
            mdtmFechaVenc = value
        End Set
    End Property
    Public Property CodEstado() As Integer
        Get
            Return mintCodEstado
        End Get
        Set(ByVal value As Integer)
            mintCodEstado = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return mstrEstado
        End Get
        Set(ByVal value As String)
            mstrEstado = value
        End Set
    End Property
    Public Property Origen() As String
        Get
            Return mstrOrigen
        End Get
        Set(ByVal value As String)
            mstrOrigen = value
        End Set
    End Property
    Public Property FechaCobro() As Date
        Get
            Return mdtmFechaCobro
        End Get
        Set(ByVal value As Date)
            mdtmFechaCobro = value
        End Set
    End Property
    Public Property Glosa() As String
        Get
            Return mstrGlosa
        End Get
        Set(ByVal value As String)
            mstrGlosa = value
        End Set
    End Property
    Public Sub Inicializar()
        Try
            mobjCsql = New CSql
            mobjCliente = New CCliente
            mobjAporte = New CAporte

            mlngRutUsuario = 0

            ' EMPRESA
            mlngRut = 0
            mintAgno = 0
            mstrNombre = ""
            ' SALDOS
            mlngSaldoCap = 0
            mlngSaldoRep = 0
            mlngSaldoCer = 0
            mlngSaldoBec = 0
            mstrObservaciones = ""
            ' APORTES
            mlngNumAporte = 0
            mlngCodAporte = 0
            mlngCorrelativo = 0
            mlngTotalAporte = 0
            mintCodCuenta = 0
            mlngMontoNeto = 0
            mlngMontoAdm = 0
            mdblPorcAdmin = 0.0
            mdtmFechaIngreso = Now
            ' DOCUMENTOS
            mintCodTipoDocto = 0
            mstrNumDocto = ""
            mstrBanco = ""
            mdtmFechaVenc = Now
            mintCodEstado = 0
            mdtmFechaCobro = Now
            mstrEstado = ""
            mstrOrigen = ""
            mstrGlosa = ""
        Catch ex As Exception
            EnviaError("CIngresoAporte:Inicializar-->" & ex.Message)
        End Try
    End Sub
    Public Sub CargaEmpresa()
        Try
            mobjCliente.Agno = mintAgno
            mobjCliente.RutUsuario = mlngRutUsuario
            mobjCliente.Inicializar(mobjCsql)
            If Not mobjCliente.Inicializar1(RutLngAUsr(mlngRut)) Then
                Exit Sub
            End If
            mlngRut = mobjCliente.Rut
            mstrNombre = mobjCliente.RazonSocial

            mlngSaldoCap = mobjCliente.ObjCuentaCap.SaldoActual
            mlngSaldoRep = mobjCliente.ObjCuentaRep.SaldoActual
            mlngSaldoCer = mobjCliente.ObjCuentaCertificacion.SaldoActual
            mlngSaldoBec = mobjCliente.ObjCuentaRep.SaldoActual
            mdblPorcAdmin = mobjCliente.CostoAdm
            mlngAdmNoLineal = mobjCliente.AdmNoLineal

            mlngNumAporte = mobjAporte.NumAporteSiguiente
        Catch ex As Exception
            EnviaError("CIngresoAporte:CargaEmpresa-->" & ex.Message)
        End Try
    End Sub
    Public Sub CargarAporte()
        Try
            mobjAporte.Inicializar2(mlngCodAporte)
            mlngRut = RutUsrALng(mobjAporte.RutCliente)
            mintAgno = mobjAporte.AgnoAporte
            CargaEmpresa()
            mstrObservaciones = mobjAporte.Observaciones
            ' APORTES
            mlngCodAporte = mobjAporte.CodAporte
            mlngNumAporte = mobjAporte.NumAporte
            mlngCorrelativo = mobjAporte.Correlativo
            mlngTotalAporte = mobjAporte.MontoTotal
            mintCodCuenta = mobjAporte.CodCuenta
            mlngMontoNeto = mobjAporte.MontoCuenta
            mlngMontoAdm = mobjAporte.MontoAdmin
            mdtmFechaIngreso = mobjAporte.FechaContableIngreso
            ' DOCUMENTOS
            mintCodTipoDocto = mobjAporte.CodTipoDocumento
            mstrNumDocto = mobjAporte.NroDocumento
            mstrBanco = mobjAporte.NombreBanco
            mdtmFechaVenc = mobjAporte.FechaVencDoc
            mintCodEstado = mobjAporte.CodEstado
            mdtmFechaCobro = mobjAporte.FechaCobro
            mstrEstado = mobjAporte.NombreEstado
            mstrOrigen = mobjAporte.Origen
        Catch ex As Exception
            EnviaError("CIngresoAporte:CargarAporte-->" & ex.Message)
        End Try
    End Sub
    Public Sub NuevoAporte()
        Try
            mobjAporte.RutUsuario = mlngRutUsuario
            mobjAporte.Inicializar1(RutLngAUsr(Me.mlngRut), Me.mintCodCuenta, Me.mlngMontoNeto, Me.mlngMontoAdm, Me.mdtmFechaIngreso, Me.mintCodTipoDocto, _
                                    Me.mstrNumDocto, Me.mstrBanco, Me.mdtmFechaVenc, Me.mdtmFechaCobro, Me.mlngNumAporte, Me.mstrObservaciones, mintCodEstado)
            mlngNumAporte = mobjAporte.CodAporte
        Catch ex As Exception
            EnviaError("CIngresoAporte:NuevoAporte-->" & ex.Message)
        End Try
    End Sub
    Public Sub ModificarAporte()
        Try
            mobjAporte.RutUsuario = mlngRutUsuario
            mobjAporte.Inicializar2(mlngCodAporte)
            mobjAporte.Modificar(Me.mintCodCuenta, Me.mlngMontoNeto, Me.mlngMontoAdm, Me.mdtmFechaIngreso, Me.mintCodTipoDocto, _
                                     Me.mstrNumDocto, Me.mstrBanco, Me.mdtmFechaVenc, Me.mdtmFechaCobro, Me.mintCodEstado, Me.mlngNumAporte, Me.mstrObservaciones)
            mlngNumAporte = mobjAporte.CodAporte
        Catch ex As Exception
            EnviaError("CIngresoAporte:NuevoAporte-->" & ex.Message)
        End Try
    End Sub
    Public Sub AnularAporte()
        Try
            mobjAporte.RutUsuario = mlngRutUsuario
            mobjAporte.Inicializar2(mlngCodAporte)
            mobjAporte.Anular(Me.mstrGlosa, mlngRutUsuario)
        Catch ex As Exception
            EnviaError("CIngresoAporte:NuevoAporte-->" & ex.Message)
        End Try
    End Sub
End Class
