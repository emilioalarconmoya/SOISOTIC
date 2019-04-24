Imports Microsoft.VisualBasic
Imports Modulos
Imports System.Data
Imports Clases
Public Class CFichaAporteIngresado
    Implements IReporte
    Private objSession As New CSession
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    

    'objeto con procedimentos para insetar en la base de datos temporal
    'Private mobjDatosTemporal As CDatosTemporal

    'objeto global
    'Private mobjGlobal As cGlobal

    'código del aporte
    Private mlngCodAporte As Long
    Private mlngCorrelativo As Long
    Private mlngNumAporte As Long

    'cliente
    Private mlngRutCliente As Long

    'código de la cuenta: 1-cap, 2-reparto, 3-adm, 4-exc cap, 5-exc cap
    Private mintCodCuenta As Integer

    'datos del aporte
    Private mlngMontoNeto As Long
    Private mlngMontoAdmin As Long
    Private mdblPorcentajeAdm As Double

    'fecha legal del ingreso del aporte
    Private mdtmFechaContableIngreso As Date

    'Origen: cliente o sistema
    Private mintOrigen As Integer
    Private mstrOrigen As String

    'Estado del aporte
    Private mintEstado As Integer
    Private mstrNombreEstado As String

    'Arreglo con los estados del aporte
    Private marrEstadosAporte() As Object

    'datos del documento de aporte
    Private mstrNumCuentaBanco As String
    Private mintCodTipoDoc As Integer
    Private mstrNumDoc As String
    Private mstrBanco As String
    Private mdtmFechaVenc As Date  'es fecha, pero puede ser nula
    Private mdtmFechaCobro As Date 'puede ser nula
    Private mintAgnoAporte As Integer

    'observaciones
    Private mstrObservaciones As String

    'rut del usuario conectado
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
    Property Archivo() As String
        Get
            Return mstrArchivo
        End Get
        Set(ByVal value As String)
            mstrArchivo = value
        End Set
    End Property
    Property CodAporte() As Long
        Get
            Return mlngCodAporte
        End Get
        Set(ByVal value As Long)
            mlngCodAporte = value
        End Set
    End Property
    Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    Property NumAporte() As Long
        Get
            Return mlngNumAporte
        End Get
        Set(ByVal value As Long)
            mlngNumAporte = value
        End Set
    End Property
    Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Property CodCuenta() As Integer
        Get
            Return mintCodCuenta
        End Get
        Set(ByVal value As Integer)
            mintCodCuenta = value
        End Set
    End Property
    Property MontoNeto() As Long
        Get
            Return mlngMontoNeto
        End Get
        Set(ByVal value As Long)
            mlngMontoNeto = value
        End Set
    End Property
    Property MontoAdmin() As Long
        Get
            Return mlngMontoAdmin
        End Get
        Set(ByVal value As Long)
            mlngMontoAdmin = value
        End Set
    End Property
    Property PorcentajeAdm() As Double
        Get
            Return mdblPorcentajeAdm
        End Get
        Set(ByVal value As Double)
            mdblPorcentajeAdm = value
        End Set
    End Property
    Public Property FechaContableIngreso() As Date
        Get
            Return mdtmFechaContableIngreso
        End Get
        Set(ByVal value As Date)
            mdtmFechaContableIngreso = value
        End Set
    End Property
   

    Property Origen() As Integer
        Get
            Return mintOrigen
        End Get
        Set(ByVal value As Integer)
            mintOrigen = value
        End Set
    End Property
    Property NombreEstado() As String
        Get
            Return mstrNombreEstado
        End Get
        Set(ByVal value As String)
            mstrNombreEstado = value
        End Set
    End Property
    Property NumCuentaBanco() As String
        Get
            Return mstrNumCuentaBanco
        End Get
        Set(ByVal value As String)
            mstrNumCuentaBanco = value
        End Set
    End Property
    Property CodTipoDoc() As Integer
        Get
            Return mintCodTipoDoc
        End Get
        Set(ByVal value As Integer)
            mintCodTipoDoc = value
        End Set
    End Property
    Property NumDoc() As String
        Get
            Return mstrNumDoc
        End Get
        Set(ByVal value As String)
            mstrNumDoc = value
        End Set
    End Property
    Property banco() As String
        Get
            Return mstrBanco
        End Get
        Set(ByVal value As String)
            mstrBanco = value
        End Set
    End Property
    Public Property FechaVenc() As Date
        Get
            Return mdtmFechaVenc
        End Get
        Set(ByVal value As Date)
            mdtmFechaVenc = value
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
    Public Property AgnoAporte() As Integer
        Get
            Return mintAgnoAporte
        End Get
        Set(ByVal value As Integer)
            mintAgnoAporte = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return mstrObservaciones
        End Get
        Set(ByVal value As String)
            mstrObservaciones = value
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


    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar

    End Function





   

  

    ''inicialización del objeto
    'Public Sub Inicializar0(ByRef objGlobal As cGlobal)
    '    If objGlobal.Usuario.Rut <= 0 Then
    '        Call RaiseError(MyUnhandledError, "cAporte:Inicializar0 Method - Usuario desconocido")
    '        Exit Sub
    '    End If
    '    mlngRutUsuario = objGlobal.Usuario.Rut
    '    mobjSql = objGlobal.SQL
    '    mobjGlobal = objGlobal
    'End Sub
    'Public Function ProponeNumAporte(ByVal lngNumeroAporte As Long) As Long
    '    Dim salida As Long
    '    salida = lngNumeroAporte
    '    Do While mobjSql.s_existe_numero_aporte(salida)
    '        salida = salida + 1
    '    Loop
    '    ProponeNumAporte = salida
    'End Function

    'Creación de un nuevo aporte
    '    Public Function Inicializar1(ByVal strRutCliente As String, _
    '                            ByVal intCuenta As Integer, _
    '                            ByVal lngMontoNeto As Long, _
    '                            ByVal lngMontoAdm As Long, _
    '                            ByVal strFechaContable As String, _
    '                            ByVal intCodTipoDoc As Integer, _
    '                            ByVal strNroDoc As String, _
    '                            ByVal strBanco As String, _
    '                            ByVal strFechaVenc As String, _
    '                            ByVal lngNumAporte As Long, _
    '                            ByVal strObs As String) As Integer
    '        If ActivarOnError Then
    '            On Error GoTo Inicializar1Err
    '        End If
    '        Dim lngRutCliente


    '        'abrir transaccion
    '        Call mobjSql.AbrirConexionTransaccion() 'Abro la transaccion aca para que nadie toem el numero de aporte

    '        If mobjSql.s_existe_numero_aporte(lngNumAporte) Then
    '            'cerrar transaccion
    '            Call mobjSql.CommitTranCerrarConexion()
    '            Inicializar1 = 1
    '            Exit Function
    '        End If
    '        lngRutCliente = RutUsrALng(strRutCliente)
    '        mdtmFechaContableIngreso = FechaUsrAVb(strFechaContable)
    '        mdtmFechaVenc = FechaNulaUsrAVb(strFechaVenc)

    '        'determinar el estado del aporte y de la transaccion
    '        Dim intEstadoAporte, intEstadoTransaccion As Integer
    '        If intCodTipoDoc = 1 Or intCodTipoDoc = 2 Then  'efectivo o cheque a fecha
    '            intEstadoAporte = 2  'cobrado
    '            intEstadoTransaccion = 2  'autorizada
    '            mdtmFechaVenc = mdtmFechaContableIngreso
    '            mdtmFechaCobro = mdtmFechaContableIngreso
    '        Else
    '            intEstadoAporte = 1  'ingresado
    '            intEstadoTransaccion = 1  'pendiente
    '            mdtmFechaCobro = FechaMinSistema()
    '        End If

    '        If ActivarWebContab Then
    '            'ingresar al comprobante en WebContab
    '            Dim objComprobante As Object
    '            objComprobante = mobjGlobal.ComprobanteContable

    '            objComprobante.Origen = 1  'operaciones
    '            objComprobante.TipoEntidad = "AP"
    '            objComprobante.NroDocumento = lngNumAporte
    '            objComprobante.RutCliente = lngRutCliente
    '            objComprobante.TipoDocPago = intCodTipoDoc
    '            objComprobante.FechaDoc = mdtmFechaVenc
    '            Call objComprobante.NuevaCabecera()
    '        End If



    '        'insertar en la tabla de aportes. Recuperamos el código
    '        mlngCodAporte = mobjSql.i_aporte(lngRutCliente, intCuenta, mdtmFechaContableIngreso, lngMontoNeto, lngMontoAdm, _
    '                                         intCodTipoDoc, strNroDoc, strBanco, mdtmFechaVenc, mdtmFechaCobro, lngNumAporte, _
    '                                         intEstadoAporte, strObs)
    '        'insertar en la tabla de Transacciones: monto
    '        Call mobjSql.i_transaccion(lngRutCliente, intCuenta, 1, intEstadoTransaccion, lngMontoNeto, _
    '                                   "Aporte neto, Nro. " & lngNumAporte, -1, mlngCodAporte, mdtmFechaContableIngreso)
    '        If ActivarWebContab Then  'agregar asiento contable
    '            'Call objComprobante.NuevoAsiento(intCuenta, lngMontoNeto, mdtmFechaVenc, "Ingreso", intCodTipoDoc)
    '            Call objComprobante.NuevoAsiento(intCuenta, lngMontoNeto)
    '        End If

    '        'insertar en la tabla de Transacciones: monto administracion
    '        intCuenta = 3  'código de cuenta de adm
    '        Call mobjSql.i_transaccion(lngRutCliente, intCuenta, 1, intEstadoTransaccion, lngMontoAdm, _
    '                                   "Aporte administración, Nro. " & lngNumAporte, -1, mlngCodAporte, mdtmFechaContableIngreso)

    '        If ActivarWebContab Then  'grabar comprobante contable
    '            Call objComprobante.NuevoAsiento(intCuenta, lngMontoAdm)
    '            If Not objComprobante.Grabar Then GoTo Inicializar1Err
    '            objComprobante = Nothing
    '        End If

    '        Call mobjSql.i_bitacora(mlngRutUsuario, "Ingresado", _
    '                                "Ingreso de aporte cliente " & RutLngAUsr(lngRutCliente), 2, mlngCodAporte)

    '        'cerrar transaccion
    '        Call mobjSql.CommitTranCerrarConexion()

    '        'obtener los datos desde la base
    '        Call Inicializar2(mlngCodAporte)

    '        Inicializar1 = 0 ' no hay error
    '        Exit Function
    'Inicializar1Err:
    '        Inicializar1 = -1
    '        Call mobjSql.RollBackTransaccion()
    '        Call RaiseError(MyUnhandledError, "cAporte:Inicializar1 Method")
    '    End Function

    '    'Cambia el estado del aporte a anulado
    '    Public Sub Anular(ByVal strGlosa As String, ByVal objUsuario As CUsuario)
    '        If ActivarOnError Then
    '            On Error GoTo AnularErr
    '        End If
    '        Dim dtmFechaHora As Date

    '        ' genero la fecha de la transaccion correcta dependiendo del año
    '        dtmFechaHora = FechaTransaccion()

    '        If ActivarWebContab Then
    '            'ingresar al comprobante en WebContab
    '            Dim objComprobante As Object
    '            objComprobante = mobjGlobal.ComprobanteContable

    '            objComprobante.Origen = 1  'operaciones
    '            objComprobante.TipoEntidad = "AP"
    '            objComprobante.NroDocumento = mlngNumAporte
    '            objComprobante.RutCliente = mlngRutCliente
    '            objComprobante.TipoDocPago = mintCodTipoDoc
    '            objComprobante.FechaDoc = mdtmFechaVenc
    '            Call objComprobante.NuevaCabecera()
    '            '        Call objComprobante.NuevoComprobante("AP", mintCodTipoDoc, mlngNumAporte, _
    '            '            mlngRutCliente, 0, dtmFechaHora)
    '        End If

    '        'abrir transacción
    '        Call mobjSql.AbrirConexionTransaccion()

    '        Call mobjSql.u_anular_aporte(mlngCodAporte)

    '        'Anular transacción
    '        Call mobjSql.i_transaccion(mlngRutCliente, mintCodCuenta, 1, 4, -mlngMontoNeto, _
    '                                   "Anulación de Aporte Nro. " & mlngNumAporte, -1, mlngCodAporte, dtmFechaHora)
    '        If ActivarWebContab Then  'agregar asiento contable
    '            Call objComprobante.NuevoAsiento(mintCodCuenta, -mlngMontoNeto)
    '        End If

    '        'anular transacción cuenta de administración
    '        Call mobjSql.i_transaccion(mlngRutCliente, 3, 1, 4, -mlngMontoAdmin, _
    '                                   "Anulación de Aporte Nro. " & mlngNumAporte, -1, mlngCodAporte, dtmFechaHora)
    '        If ActivarWebContab Then  'grabar comprobante contable
    '            Call objComprobante.NuevoAsiento(3, -mlngMontoAdmin)
    '            If Not objComprobante.Grabar Then GoTo AnularErr
    '            objComprobante = Nothing
    '        End If

    '        Call mobjSql.i_bitacora(objUsuario.Rut, "Anulado", _
    '                                "Nulidad de aporte. Cliente:" _
    '                                & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, 2, mlngCodAporte)

    '        'cerrar transaccion y conexión
    '        Call mobjSql.CommitTranCerrarConexion()

    '        Exit Sub
    'AnularErr:
    '        Call mobjSql.RollBackTransaccion()
    '        Call RaiseError(MyUnhandledError, "cAporte:Anular Method")
    '    End Sub

    '    'Creación de un objeto aporte a partir de uno existente.
    '    'Retorna True si existe el código de aporte
    '    Public Function Inicializar2(ByVal lngCodAporte As Long) As Boolean
    '        If ActivarOnError Then
    '            On Error GoTo Inicializar2Err
    '        End If
    '        mlngCodAporte = -1  'inicialización

    '        'consulta los datos del aporte
    '        Dim arrAporte()
    '        arrAporte = mobjSql.s_aporte_1(lngCodAporte)
    '        If TamanoArreglo2(arrAporte) = 0 Then
    '            Call Class_Initialize()
    '            Inicializar2 = False
    '            Exit Function
    '        End If

    '        mlngCodAporte = lngCodAporte
    '        mlngRutCliente = arrAporte(0, 0)
    '        mintCodCuenta = arrAporte(1, 0)
    '        mintAgnoAporte = arrAporte(2, 0)
    '        mlngCorrelativo = arrAporte(3, 0)
    '        mdtmFechaContableIngreso = arrAporte(4, 0)
    '        mintEstado = arrAporte(5, 0)
    '        mlngMontoNeto = arrAporte(6, 0)
    '        mlngMontoAdmin = arrAporte(7, 0)
    '        mintCodTipoDoc = arrAporte(8, 0)
    '        mstrNroDoc = arrAporte(9, 0)
    '        mstrBanco = arrAporte(10, 0)
    '        If Not IsNull(arrAporte(11, 0)) Then
    '            mdtmFechaVenc = arrAporte(11, 0)
    '        Else
    '            mdtmFechaVenc = FechaMinSistema()
    '        End If
    '        If Not IsNull(arrAporte(12, 0)) Then
    '            mdtmFechaCobro = arrAporte(12, 0)
    '        Else
    '            mdtmFechaCobro = FechaMinSistema()
    '        End If
    '        mlngNumAporte = arrAporte(13, 0)
    '        mstrObservaciones = Trim(arrAporte(14, 0))

    '        If mlngMontoNeto > 0 Then
    '            mdblPorcentajeAdm = CDbl(mlngMontoAdmin) / CDbl(Me.MontoTotal) * 100
    '        Else
    '            mdblPorcentajeAdm = -1
    '        End If

    '        Inicializar2 = True

    '        Exit Function
    'Inicializar2Err:
    '        Call RaiseError(MyUnhandledError, "cAporte:Inicializar2 Method")
    '    End Function


    '    'inicialización del objeto vacío
    '    Private Sub Class_Initialize()
    '        mlngCodAporte = -1
    '        mlngRutCliente = 0
    '        mintCodCuenta = 0
    '        mlngCorrelativo = -1
    '        mdtmFechaContableIngreso = FechaMinSistema()
    '        mintEstado = 0
    '        mlngMontoNeto = -1
    '        mlngMontoAdmin = -1
    '        mintCodTipoDoc = 0
    '        mstrNroDoc = 0
    '        mstrBanco = ""
    '        mdtmFechaVenc = FechaMinSistema()
    '        mdblPorcentajeAdm = -1
    '        mlngNumAporte = 0
    '        mstrObservaciones = ""
    '    End Sub

    '    'modificación de aportes
    '    Public Sub Modificar(ByVal intCuenta As Integer, _
    '                         ByVal lngMontoCuenta As Long, _
    '                         ByVal lngMontoAdm As Long, _
    '                         ByVal strFechaContable As String, _
    '                         ByVal intCodTipoDoc As Integer, _
    '                         ByVal strNroDoc As String, _
    '                         ByVal strBanco As String, _
    '                         ByVal strFechaVenc As String, _
    '                         ByVal strFechaCobro As String, _
    '                         ByVal intEstadoAporte As Integer, _
    '                         ByVal lngNumAporte As Long, _
    '                         ByVal strObs As String)
    '        If ActivarOnError Then
    '            On Error GoTo ModificarErr
    '        End If
    '        Dim mblnEstaAnulado As Boolean
    '        If ActivarWebContab Then
    '            'ingresar al comprobante en WebContab
    '            Dim objComprobante As Object
    '            objComprobante = mobjGlobal.ComprobanteContable
    '            'tipo de documento nuevo y antiguo, para poder hacer la anulación correspondiente
    '            objComprobante.Origen = 1  'operaciones
    '            objComprobante.TipoEntidad = "AP"
    '            objComprobante.NroDocumento = lngNumAporte
    '            objComprobante.RutCliente = mlngRutCliente
    '            Call objComprobante.NuevaCabecera()
    '            '        Call objComprobante.NuevoComprobante("AP", intCodTipoDoc, lngNumAporte, _
    '            '            mlngRutCliente, 0, FechaTransaccion)
    '        End If

    '        'abrir transacción
    '        Call mobjSql.AbrirConexionTransaccion()
    '        mblnEstaAnulado = mobjSql.s_esta_aporte_anulado(mlngCodAporte)
    '        'registro
    '        Call mobjSql.u_aporte(mlngCodAporte, mlngRutCliente, intCuenta, _
    '                FechaUsrAVb(strFechaContable), _
    '                intEstadoAporte, lngMontoCuenta, lngMontoAdm, intCodTipoDoc, _
    '                strNroDoc, strBanco, _
    '                FechaNulaUsrAVb(strFechaVenc), _
    '                FechaNulaUsrAVb(strFechaCobro), lngNumAporte, strObs)
    '        'cambio de estado de la transaccion
    '        If intEstadoAporte = 1 Then   'aporte ingresado
    '            Call mobjSql.u_transaccion_aporte_estado(mlngCodAporte, 1)   'pendiente
    '        ElseIf intEstadoAporte = 2 Then   'aporte cobrado
    '            Call mobjSql.u_transaccion_aporte_estado(mlngCodAporte, 2)   'autorizada
    '        End If
    '        '
    '        ' Esto está comentado porque no es necesario actualizar las transacciones si no
    '        ' se actualizan los montos o las cuentas. Dionel, 21/03/2002
    '        '
    '        '    'Anular transacción
    '        '    Call mobjSql.i_transaccion(mlngRutCliente, mintCodCuenta, 1, 4, (0 - mlngMontoNeto), _
    '                               "Anulación de Aporte.", -1, mlngCodAporte)
    '        '    'anular transacción cuenta de administración
    '        '    Call mobjSql.i_transaccion(mlngRutCliente, 3, 1, 4, (0 - mlngMontoAdmin), _
    '                               "Anulación de Aporte." & lngNumAporte, -1, mlngCodAporte)

    '        '    'insertar en la tabla de Transacciones: monto
    '        '    Call mobjSql.i_transaccion(mlngRutCliente, intCuenta, 1, 1, lngMontoCuenta, _
    '                               "Aporte neto, Nro. " & lngNumAporte, -1, mlngCodAporte)
    '        '    'insertar en la tabla de Transacciones: monto administracion
    '        '        Call mobjSql.i_transaccion(mlngRutCliente, 3, 1, 1, lngMontoAdm, _
    '                               "Aporte administración, Nro. " & lngNumAporte, -1, mlngCodAporte)

    '        ' Anular transaccion antigua y ingresar una nueva si el monto cambia
    '        Call ModificarTransaccion(mlngRutCliente, mlngCodAporte, _
    '                                  mlngMontoNeto, lngMontoCuenta, _
    '                                  intCuenta, lngNumAporte, mintCodCuenta, objComprobante, _
    '                                  FechaNulaUsrAVb(strFechaVenc), intCodTipoDoc, mblnEstaAnulado)
    '        ' Cuenta Administracion
    '        Call ModificarTransaccion(mlngRutCliente, mlngCodAporte, _
    '                                  mlngMontoAdmin, lngMontoAdm, _
    '                                  3, lngNumAporte, 3, objComprobante, _
    '                                  FechaNulaUsrAVb(strFechaVenc), intCodTipoDoc, mblnEstaAnulado)

    '        If ActivarWebContab Then  'grabar comprobante contable
    '            If Not objComprobante.Grabar Then GoTo ModificarErr
    '            objComprobante = Nothing
    '        End If

    '        'registro en la bitácora
    '        Call mobjSql.i_bitacora(mlngRutUsuario, "Modificado - Estado " & intEstadoAporte, _
    '                                "Modificación de aporte cliente " & RutLngAUsr(mlngRutCliente), 2, mlngCodAporte)
    '        'commit
    '        Call mobjSql.CommitTranCerrarConexion()

    '        'lee los datos desde la base
    '        Call Inicializar2(mlngCodAporte)
    '        Exit Sub
    'ModificarErr:
    '        Call mobjSql.RollBackTransaccion()
    '        Call RaiseError(MyUnhandledError, "cAporte:Modificar Method")
    '    End Sub
    '    'comprobante aporte
    '    Public Sub GeneraComprobanteAporte(ByVal lngIdSesion As Long, ByVal dtmFecha As Date)

    '        Dim strNombreEmpresa As String
    '        Dim strRutEmpresa As String
    '        Dim strDireccion As String
    '        Dim strCiudad As String
    '        Dim strAporte As String
    '        Dim strAportePalabras As String
    '        Dim strMontoCtaCapacitacion As String
    '        Dim strMontoCtaReparto As String
    '        Dim strEmpresaDestino As String
    '        Dim strEmpresaDestino1 As String
    '        Dim strRutEmpresaDestino As String
    '        Dim strMontoCtaAdministracion As String
    '        Dim strTotal As String
    '        Dim strEfectivo As String
    '        Dim strNumDocumento As String
    '        Dim strNombreBanco As String
    '        Dim intDia As Integer
    '        Dim strMes As String
    '        Dim intAgno As Integer
    '        Dim intPorcentajeAdm As Integer
    '        Dim lngNumeroAporte As Long



    '        'variables de la sesion


    '        Dim objCliente As cCliente


    '        objCliente = mobjGlobal.Cliente
    '        Call objCliente.Inicializar1(RutLngAUsr(mlngRutCliente))

    '        strNombreEmpresa = objCliente.RazonSocial
    '        strRutEmpresa = RutLngAUsr(mlngRutCliente)
    '        strDireccion = objCliente.Direccion
    '        strCiudad = objCliente.Ciudad

    '        objCliente = Nothing

    '        strAporte = FormatoNumeroEntero(CStr(mlngMontoNeto + mlngMontoAdmin)) & ".-"
    '        strAportePalabras = UnNumero(CStr(mlngMontoNeto + mlngMontoAdmin)) & " pesos"
    '        If mintCodCuenta = 1 Then
    '            strMontoCtaCapacitacion = FormatoNumeroEntero(CStr(mlngMontoNeto)) & ".-"
    '            strMontoCtaReparto = ""
    '        ElseIf mintCodCuenta = 2 Then
    '            strMontoCtaCapacitacion = ""
    '            strMontoCtaReparto = FormatoNumeroEntero(CStr(mlngMontoNeto)) & ".-"
    '        End If

    '        If mlngMontoAdmin > 0 Then
    '            strMontoCtaAdministracion = FormatoNumeroEntero(CStr(mlngMontoAdmin)) & ".-"
    '        Else
    '            strMontoCtaAdministracion = ""
    '        End If

    '        strTotal = FormatoNumeroEntero(CStr(mlngMontoNeto + mlngMontoAdmin)) & ".-"

    '        If mintCodTipoDoc = 1 Then
    '            strEfectivo = FormatoNumeroEntero(CStr(mlngMontoNeto + mlngMontoAdmin)) & ".-"
    '            strNumDocumento = ""
    '            strNombreBanco = ""
    '        Else
    '            strEfectivo = ""
    '            strNumDocumento = mstrNroDoc
    '            strNombreBanco = mstrBanco
    '        End If

    '        intDia = Day(Of Date)()
    '        strMes = NombreMes(Month(Of Date))
    '        intAgno = Year(Of Date)()
    '        If mdblPorcentajeAdm > 0 And mdblPorcentajeAdm < 1 Then
    '            intPorcentajeAdm = Round(mdblPorcentajeAdm * 100, 0)
    '        ElseIf mdblPorcentajeAdm < 100 Then
    '            intPorcentajeAdm = Round(mdblPorcentajeAdm, 0)
    '        End If
    '        lngNumeroAporte = mlngNumAporte

    '        strEmpresaDestino = ""
    '        strEmpresaDestino1 = ""
    '        strRutEmpresaDestino = ""

    '        mobjDatosTemporal = New CDatosTemporal
    '        Call mobjDatosTemporal.i_comprobante_aporte(strNombreEmpresa, strRutEmpresa, strDireccion, strCiudad, _
    '                                                    strAporte, strAportePalabras, strMontoCtaCapacitacion, _
    '                                                    strMontoCtaReparto, strEmpresaDestino, strEmpresaDestino1, _
    '                                                    strRutEmpresaDestino, strMontoCtaAdministracion, _
    '                                                    strTotal, strEfectivo, strNumDocumento, strNombreBanco, intDia, _
    '                                                    strMes, intAgno, intPorcentajeAdm, lngNumeroAporte, lngIdSesion, dtmFecha)
    '        mobjDatosTemporal = Nothing

    '    End Sub
    '    'modificación de transacciones de aportes
    '    Private Sub ModificarTransaccion(ByVal lngRut As Long, _
    '                                     ByVal lngCodAporte As Long, _
    '                                     ByVal lngMontoAntiguo As Long, _
    '                                     ByVal lngMontoNuevo As Long, _
    '                                     ByVal intCodCuenta As Integer, _
    '                                     ByVal lngNumAporte As Long, _
    '                                     ByVal intCodCuentaAnt As Integer, _
    '                                     ByRef objComprobante As Object, _
    '                                     ByVal dtmFechaVencNueva As Date, _
    '                                     ByVal intCodTipoDocNuevo As Integer, _
    '                                     ByVal blnEstaAnulado As Boolean)

    '        Dim Texto As String
    '        Dim textoAnula As String
    '        Dim dtmFechaHora As Date


    '        dtmFechaHora = FechaTransaccion()

    '        If intCodCuenta = 3 Then
    '            Texto = "Aporte administración, Nro. " & lngNumAporte
    '            textoAnula = "Anulación de Aporte." & lngNumAporte
    '        Else
    '            Texto = "Aporte neto, Nro. " & lngNumAporte
    '            textoAnula = "Anulación de Aporte."
    '        End If
    '        If lngMontoAntiguo = lngMontoNuevo And intCodCuenta = intCodCuentaAnt And Not blnEstaAnulado Then
    '            Exit Sub
    '        Else
    '            If Not blnEstaAnulado Then
    '                'Anular transacción
    '                Call mobjSql.i_transaccion(lngRut, _
    '                                           intCodCuentaAnt, 1, 4, -lngMontoAntiguo, _
    '                                           textoAnula, -1, lngCodAporte, dtmFechaHora)
    '            End If
    '            If ActivarWebContab Then  'agregar asiento contable de anulación
    '                objComprobante.TipoDocPago = mintCodTipoDoc
    '                objComprobante.FechaDoc = mdtmFechaVenc
    '                Call objComprobante.NuevoAsiento(intCodCuentaAnt, -lngMontoAntiguo)
    '            End If

    '            'insertar en la tabla de Transacciones
    '            Call mobjSql.i_transaccion(lngRut, intCodCuenta, 1, 1, lngMontoNuevo, _
    '                                       Texto, -1, lngCodAporte, dtmFechaHora)
    '            If ActivarWebContab Then  'agregar asiento contable con el nuevo documento
    '                objComprobante.TipoDocPago = intCodTipoDocNuevo
    '                objComprobante.FechaDoc = dtmFechaVencNueva
    '                Call objComprobante.NuevoAsiento(intCodCuenta, lngMontoNuevo)
    '            End If

    '        End If
    '    End Sub
    '    'Genera la fecha de la transacción, si el año actual es igual al de la transacción entonces retorna la fecha actual, si es mayor o menor retorna el primer o ultimo instante del año segun corresponda
    '    Function FechaTransaccion() As Date
    '        Dim dtmFechaHora As Date

    '        If Year(mdtmFechaContableIngreso) < Year(Of Date)() Then
    '            dtmFechaHora = FechaMaxAgno(Year(mdtmFechaContableIngreso))
    '        ElseIf Year(mdtmFechaContableIngreso) > Year(Of Date)() Then
    '            dtmFechaHora = FechaMinAgno(Year(mdtmFechaContableIngreso))
    '        Else
    '            dtmFechaHora = Now
    '        End If
    '        FechaTransaccion = dtmFechaHora
    '    End Function


    '    'transformar una fecha que puede venir vacía en una variable de tipo date
    '    Private Function FechaNulaUsrAVb(ByVal strFechaVenc As String) As Date
    '        If Trim(strFechaVenc) <> "" Then
    '            FechaNulaUsrAVb = FechaUsrAVb(strFechaVenc)
    '        Else
    '            FechaNulaUsrAVb = FechaMinSistema()
    '        End If
    '    End Function

    '    'destruir objetos
    '    Private Sub Class_Terminate()
    '        mobjSql = Nothing
    '        mobjGlobal = Nothing
    '    End Sub



End Class
