Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CTraspasoSaldosManual
    Private mobjSql As New CSql
    Private mlngRutUsuario As Long
    Private mlngCodTraspaso As Long
    Private mlngRutEmpresa As Long
    Private mdtmFechaContTraspaso As Date
    Private mintCodCtaOrigen As Integer
    Private mintCodCtaDestino As Integer
    Private mlngMontoTraspaso As Long
    Private mstrObservacion As String
    Private mdtmFechaHoraTraspaso As Date
    Private mintAgno As Integer
    Private objCliente As New CCliente
    Private blnInsertarExitoso As Boolean
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property CodTraspaso() As Long
        Get
            Return mlngCodTraspaso
        End Get
        Set(ByVal value As Long)
            mlngCodTraspaso = value
        End Set
    End Property
    Public Property RutEmpresa() As Long
        Get
            Return mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property
    Public Property FechaContTraspaso() As Date
        Get
            Return mdtmFechaContTraspaso
        End Get
        Set(ByVal value As Date)
            mdtmFechaContTraspaso = value
        End Set
    End Property
    Public Property CodCtaOrigen() As Integer
        Get
            Return mintCodCtaOrigen
        End Get
        Set(ByVal value As Integer)
            mintCodCtaOrigen = value
        End Set
    End Property
    Public Property CodCtaDestino() As Integer
        Get
            Return mintCodCtaDestino
        End Get
        Set(ByVal value As Integer)
            mintCodCtaDestino = value
        End Set
    End Property
    Public Property MontoTraspaso() As Long
        Get
            Return mlngMontoTraspaso
        End Get
        Set(ByVal value As Long)
            mlngMontoTraspaso = value
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
    Public Property FechaHoraTraspaso() As Date
        Get
            Return mdtmFechaHoraTraspaso
        End Get
        Set(ByVal value As Date)
            mdtmFechaHoraTraspaso = value
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
    Public ReadOnly Property Cliente() As CCliente
        Get
            Return Me.objCliente
        End Get
    End Property
    Public ReadOnly Property InsertarExitoso() As Boolean
        Get
            Return Me.blnInsertarExitoso
        End Get
    End Property
    Public Function InsertarTraspaso() As Boolean
        Try

        

            Dim lngSerial1, lngSerial2, lngSerial3 As Long
            Dim strOrigen, strDestino As String
            strOrigen = mobjSql.s_nombre_cuenta(mintCodCtaOrigen)
            strDestino = mobjSql.s_nombre_cuenta(mintCodCtaDestino)

            'transaccion
            Call mobjSql.InicioTransaccion()

            lngSerial1 = mobjSql.i_traspaso_manual(mlngRutEmpresa, mdtmFechaContTraspaso, _
                                                mintCodCtaOrigen, mintCodCtaDestino, _
                                                mlngMontoTraspaso, mstrObservacion, _
                                                mlngRutUsuario)
            If lngSerial1 <= 0 Then
                InsertarTraspaso = False
                Call mobjSql.RollBackTransaccion()
            Else
                lngSerial2 = mobjSql.i_transaccion(mlngRutEmpresa, mintCodCtaOrigen, 4, 2, -mlngMontoTraspaso, _
                                                    "Traspaso de fondos hacia Cuenta " & Trim(strDestino), 0, 0, mdtmFechaContTraspaso, lngSerial1)

                If mintCodCtaDestino = 6 Then
                    mdtmFechaContTraspaso = mdtmFechaContTraspaso.AddYears(1)
                End If
                lngSerial3 = mobjSql.i_transaccion(mlngRutEmpresa, mintCodCtaDestino, 4, 2, mlngMontoTraspaso, _
                                                    "Traspaso de fondos desde Cuenta " & Trim(strOrigen) & " - " & Now.Date, 0, 0, mdtmFechaContTraspaso, lngSerial1)

                mobjSql.i_bitacora(mlngRutUsuario, "Traspaso de fondos", "Traspaso de fondos de la cuenta " & Trim(strOrigen) & " hacia la Cuenta " & Trim(strDestino) & " - " & Now.Date, _
                                   4, lngSerial1)
            End If

            If lngSerial2 <= 0 Or lngSerial3 <= 0 Then
                InsertarTraspaso = False
                blnInsertarExitoso = InsertarTraspaso
                Call mobjSql.RollBackTransaccion()
            Else
                InsertarTraspaso = True
                blnInsertarExitoso = InsertarTraspaso
                'commit y cerrar conexion
                Call mobjSql.FinTransaccion()
            End If

        Catch ex As Exception
            EnviaError("CTraspasoSaldosManual: InsertarTraspaso -->" & ex.Message)
        End Try

    End Function
    Sub inicializarCliente()
        objCliente.Inicializar0(Me.mobjSql, Me.mlngRutUsuario)
    End Sub


End Class
