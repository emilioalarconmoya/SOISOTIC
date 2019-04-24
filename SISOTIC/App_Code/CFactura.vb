Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CFactura

    Private objSession As New CSession
    'consultas sql y objetos de conexion
    Private mblnBajarXml As Boolean
    Private mstrXml As String
    Private mlngFilas As Long
    'objeto de coneccion a bd y de implements ireporte
    Private mobjSql As CSql

    'código del curso de la factura
    Private mlngCodCurso As Long

    ' Código del estado de la factura
    Private mintCodEstadoFactura As Integer

    'numero de factura
    Private mlngNumFactura As Long

    Private mdtmFecha As Date

    Private mdtmFechaRecepcion As Date

    Private mdtmFechaPago As Date

    Private mlngMonto As Long

    Private mlngNroVoucher As Long

    'rut del usuario conectado
    Private mlngRutUsuario As Long
    Private mstrObservacion As String


    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property
    Public Property BajarXml() As Boolean
        Get
            Return Me.mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXml = value
        End Set
    End Property
    Public ReadOnly Property Filas() As Integer
        Get
            Return mlngFilas
        End Get
    End Property
    Public ReadOnly Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
    End Property
    Public ReadOnly Property NumFactura() As Long
        Get
            Return mlngNumFactura
        End Get
    End Property
    Public ReadOnly Property Monto() As Long
        Get
            Return mlngMonto
        End Get
    End Property
    Public Property NroVoucher() As Long
        Get
            Return mlngNroVoucher
        End Get
        Set(ByVal value As Long)
            mlngNroVoucher = value
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
    Public ReadOnly Property Fecha() As Date
        Get
            Return mdtmFecha
        End Get
    End Property
    Public ReadOnly Property FechaRecepcion() As Date
        Get
            Return mdtmFechaRecepcion
        End Get
    End Property
    Public ReadOnly Property FechaPago() As Date
        Get
            Return mdtmFechaPago
        End Get
    End Property
    Public ReadOnly Property CodEstadoFactura() As Integer
        Get
            Return mintCodEstadoFactura
        End Get
    End Property
    Public Property Observacion() As String
        Get
            Observacion = mstrObservacion
        End Get
        Set(ByVal value As String)
            mstrObservacion = value
        End Set
    End Property
    'inicialización del objeto vacío
    Public Sub New()
        mlngCodCurso = -1
        mintCodEstadoFactura = 0
        mlngNumFactura = -1
        mdtmFecha = FechaMinSistema()
        mdtmFechaRecepcion = FechaMinSistema()
        mdtmFechaPago = FechaMinSistema()
        mlngMonto = -1
        mlngNroVoucher = 0
    End Sub

    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    Public Sub Inicializar0(ByRef objSql As CSql, _
                        ByVal lngRutUsuario As Long)
        mobjSql = objSql
        If lngRutUsuario <= 0 Then
            Call EnviaError("CFactura:Inicializar0 Method - Usuario desconocido")
            Exit Sub
        End If
        mlngRutUsuario = lngRutUsuario
    End Sub

    'Creacion de una nueva factura, si la factura del curso existe, actualiza
    'los datos con los nuevos valores
    '##ModelId=3C3F407A0028
    Public Sub Inicializar1(ByVal lngCodCurso As Long, _
                            ByVal intCodEstadoFactura As Integer, _
                            ByVal lngNumFactura As Long, _
                            ByVal strFecha As String, _
                            ByVal strFechaRecepcion As String, _
                            ByVal strFechaPago As String, _
                            ByVal lngMonto As Long, _
                            ByVal lngNumVoucher As String, _
                            ByVal strObservacion As String)


        Try
            mobjSql = New CSql
            Dim dtmFechaTemp As Date
            If Trim(strFechaPago) = "" Then
                dtmFechaTemp = FechaMaxSistema()
            Else
                dtmFechaTemp = FechaUsrAVb(strFechaPago)
            End If
            'abrir transaccion
            mobjSql.InicioTransaccion()

            If Not Inicializar2(lngCodCurso) Then
                Call mobjSql.i_factura(lngCodCurso, intCodEstadoFactura, lngNumFactura, FechaUsrAVb(strFecha), _
                                        FechaUsrAVb(strFechaRecepcion), dtmFechaTemp,lngMonto, lngNumVoucher, strObservacion)
                Call mobjSql.i_bitacora(mlngRutUsuario, "Ingresada", _
                        "Ingreso de factura. " & strObservacion & "/ nro de factura: " & lngNumFactura, 3, lngCodCurso)
            Else
                Call Modificar(lngCodCurso, intCodEstadoFactura, lngNumFactura, _
                FechaUsrAVb(strFecha), FechaUsrAVb(strFechaRecepcion), _
                dtmFechaTemp, lngMonto, lngNumVoucher, strObservacion)
                Call mobjSql.i_bitacora(mlngRutUsuario, "Modificada - Estado " & intCodEstadoFactura, _
                                "Modificación de factura. " & strObservacion, 3, mlngCodCurso)
            End If

            'cerrar transaccion
            mobjSql.FinTransaccion()

            mlngCodCurso = lngCodCurso
            mintCodEstadoFactura = intCodEstadoFactura
            mlngNumFactura = lngNumFactura
            mdtmFecha = FechaUsrAVb(strFecha)
            mdtmFechaRecepcion = FechaUsrAVb(strFechaRecepcion)
            If Trim(strFechaPago) = "" Then
                mdtmFechaPago = FechaMaxSistema()
            Else
                mdtmFechaPago = FechaUsrAVb(strFechaPago)
            End If
            mlngMonto = lngMonto
            Exit Sub
        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorFactura.vb:GrabarDatos-->" & ex.Message)
        End Try
    End Sub
    'Creación de un objeto factura a partir de uno existente.
    'Retorna True si existe el código del curso
    Public Function Inicializar2(ByVal lngCodCurso As Long) As Boolean
        Try
            mlngCodCurso = -1  'inicialización
            Dim intTamArr2 As Integer

            'consulta los datos de la factura
            Dim dtFactura As DataTable
            dtFactura = mobjSql.s_factura(lngCodCurso)
            intTamArr2 = mobjSql.Registros  'TamanoArreglo2(dtFactura)

            If intTamArr2 = 0 Then
                'Call Class_Initialize()
                Inicializar2 = False
                Exit Function
            End If
            mlngCodCurso = lngCodCurso
            mintCodEstadoFactura = dtFactura.Rows(0)(1)
            mlngNumFactura = dtFactura.Rows(0)(2)
            mdtmFecha = dtFactura.Rows(0)(3)
            mdtmFechaRecepcion = dtFactura.Rows(0)(4)
            mdtmFechaPago = dtFactura.Rows(0)(5)
            mlngMonto = dtFactura.Rows(0)(6)
            mlngNroVoucher = dtFactura.Rows(0)(7)
            mstrObservacion = dtFactura.Rows(0)(8)
            Inicializar2 = True
            Exit Function
        Catch ex As Exception
            EnviaError("cAporte:Inicializar2-->" & ex.Message)
        End Try
    End Function
    'modificación de factura
    Public Sub Modificar(ByVal lngCodCurso As Long, _
                            ByVal intCodEstadoFactura As Integer, _
                            ByVal lngNumFactura As Long, _
                            ByVal dtmFecha As Date, _
                            ByVal dtmFechaRecepcion As Date, _
                            ByVal dtmFechaPago As Date, _
                            ByVal lngMonto As Long, _
                            ByVal lngNumVoucher As String, _
                            ByVal strObservacion As String)
        Try
            mobjSql = New CSql

            mobjSql.u_factura(lngCodCurso, intCodEstadoFactura, lngNumFactura, _
                    dtmFecha, dtmFechaRecepcion, dtmFechaPago, lngMonto, lngNumVoucher, strObservacion)
            Call mobjSql.i_bitacora(mlngRutUsuario, "Modificada - Estado " & intCodEstadoFactura, _
                                "Modificación de factura. " & strObservacion, 3, lngCodCurso)
        Catch ex As Exception
            EnviaError("CFactura.aspx.vb:Modificar-->" & ex.Message)
        End Try
    End Sub

End Class

