Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Namespace Clases
    Public Class CAporte
#Region "Declaraciones"
        Private mobjSql As New CSql
        'objeto con procedimentos para insetar en la base de datos temporal
        'Private mobjDatosTemporal As CDatosTemporal

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
        Private mlngMontoTotal As Long
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
        Private mstrNroCuentaBanco As String
        Private mintCodTipoDoc As Integer
        Private mstrNroDoc As String
        Private mstrBanco As String
        Private mdtmFechaVenc As Date  'es fecha, pero puede ser nula
        Private mdtmFechaCobro As Date 'puede ser nula
        Private mintAgnoAporte As Integer

        'observaciones
        Private mstrObservaciones As String

        'rut del usuario conectado
        Private mlngRutUsuario As Long
        Private mblnBajarHtml As Boolean
        Private mstrDireccionArchivo As String
        Private mstrRutaArchivoVirtual As String
        Private objGeneraAporte As CGeneraComprobanteAporte
        Private objCliente As CCliente
#End Region
#Region "Propiedades"
        Public Property RutUsuario() As Long
            Get
                Return mlngRutUsuario
            End Get
            Set(ByVal value As Long)
                mlngRutUsuario = value
            End Set
        End Property

        Public ReadOnly Property NumAporte() As Long
            Get
                Return mlngNumAporte
            End Get
        End Property

        Public ReadOnly Property NumAporteSiguiente() As Long
            Get
                Return mobjSql.s_num_aporte_siguiente
            End Get
        End Property

        Public Property CodAporte() As Long
            Get
                Return mlngCodAporte
            End Get
            Set(ByVal value As Long)
                mlngCodAporte = value
            End Set
        End Property
        Public ReadOnly Property AgnoAporte() As Integer
            Get
                Return mintAgnoAporte
            End Get
        End Property

        Public Property RutCliente() As String
            Get
                Return RutLngAUsr(mlngRutCliente)
            End Get
            Set(ByVal value As String)
                mlngRutCliente = value
            End Set
        End Property

        Public ReadOnly Property CodCuenta() As Integer
            Get
                Return mintCodCuenta
            End Get
        End Property
        'correlativo o folio
        Public ReadOnly Property Correlativo() As Long
            Get
                Return mlngCorrelativo
            End Get
        End Property
        'monto
        Public ReadOnly Property MontoCuenta() As Long
            Get
                Return mlngMontoNeto
            End Get
        End Property
        'monto admin
        Public ReadOnly Property MontoAdmin() As Long
            Get
                Return FormatoMonto(mlngMontoAdmin)
            End Get
        End Property
        'porcentaje
        Public ReadOnly Property PorcentajeAdmin() As Double
            Get
                Return FormatoMonto(mdblPorcentajeAdm)
            End Get
        End Property
        'total
        Public ReadOnly Property MontoTotal() As Long
            Get
                Return FormatoMonto(mlngMontoTotal) 'MontoTotal = FormatoMonto(mlngMontoNeto + mlngMontoAdmin)
            End Get
        End Property

        'fecha contable de ingreso del aporte
        Public ReadOnly Property FechaContableIngreso() As String
            Get
                FechaContableIngreso = FechaVbAUsr(mdtmFechaContableIngreso)
            End Get
        End Property

        'estado del aporte
        Public ReadOnly Property CodEstado() As Integer
            Get
                Return mintEstado
            End Get
        End Property
        'nombre del estado
        Public ReadOnly Property NombreEstado() As String
            Get
                Return mstrNombreEstado
            End Get
        End Property
        'cuenta de banco
        Public ReadOnly Property NroCuentaBanco() As String
            Get
                Return mstrNroCuentaBanco
            End Get
        End Property
        'banco
        Public ReadOnly Property NombreBanco() As String
            Get
                Return mstrBanco
            End Get
        End Property

        'tipo del documento
        Public ReadOnly Property CodTipoDocumento() As Integer
            Get
                Return mintCodTipoDoc
            End Get
        End Property
        'Número del documento
        Public ReadOnly Property NroDocumento() As String
            Get
                Return mstrNroDoc
            End Get
        End Property
        'nombre del banco
        '##ModelId=3C3F40790366
        Public ReadOnly Property BancoDoc() As String
            Get
                Return mstrBanco
            End Get
        End Property
        'fecha de vencimiento
        Public ReadOnly Property FechaVencDoc() As String
            Get
                If mdtmFechaVenc <> FechaMinSistema() Then
                    FechaVencDoc = FechaVbAUsr(mdtmFechaVenc)
                Else
                    FechaVencDoc = FechaMinSistema()
                End If
            End Get
        End Property
        'fecha de cobro del aporte
        Public ReadOnly Property FechaCobro() As String
            Get
                If mdtmFechaCobro <> FechaMinSistema() Then
                    FechaCobro = FechaVbAUsr(mdtmFechaCobro)
                Else
                    FechaCobro = FechaMinSistema()
                End If
            End Get
        End Property

        'origen del aporte
        Public ReadOnly Property Origen() As String
            Get
                Return "Interno"      'OJO: falta completar, Dionel, 24/01
            End Get
        End Property

        'observaciones del aporte
        Public ReadOnly Property Observaciones() As String
            Get
                Return mstrObservaciones
            End Get
        End Property
        Public Property BajarHtml() As Boolean
            Get
                Return mblnBajarHtml
            End Get
            Set(ByVal value As Boolean)
                mblnBajarHtml = value
            End Set
        End Property
        Public Property DireccionArchivo() As String
            Get
                Return mstrDireccionArchivo
            End Get
            Set(ByVal value As String)
                mstrDireccionArchivo = value
            End Set
        End Property
        Public Property RutaArchivoVirtual() As String
            Get
                Return mstrRutaArchivoVirtual
            End Get
            Set(ByVal value As String)
                mstrRutaArchivoVirtual = value
            End Set
        End Property
#End Region

        Public Function ProponeNumAporte(ByVal lngNumeroAporte As Long) As Long
            Dim salida As Long
            salida = lngNumeroAporte
            Do While mobjSql.s_existe_numero_aporte(salida)
                salida = salida + 1
            Loop
            ProponeNumAporte = salida
        End Function
        Public Function Inicializar2(ByVal lngCodAporte As Long) As Boolean
            Try
                mlngCodAporte = -1  'inicialización
                'consulta los datos del aporte
                Dim dtAporte As DataTable
                dtAporte = mobjSql.s_aporte_1(lngCodAporte)
                If IsDBNull(dtAporte) Then
                    Nuevo()
                    Inicializar2 = False
                    Exit Function
                End If
                Dim dr As DataRow
                For Each dr In dtAporte.Rows
                    mlngCodAporte = lngCodAporte
                    mlngRutCliente = dr("rut_cliente")
                    mintCodCuenta = dr("cod_cuenta")
                    mintAgnoAporte = dr("agno")
                    mlngCorrelativo = dr("correlativo")
                    mdtmFechaContableIngreso = dr("fecha")
                    mintEstado = dr("cod_estado")
                    Select Case mintEstado
                        Case 1
                            mstrNombreEstado = "Por cobrar"
                        Case 2
                            mstrNombreEstado = "Cobrado"
                        Case 3
                            mstrNombreEstado = "Anulado"
                    End Select
                    mlngMontoNeto = dr("monto_neto")
                    mlngMontoAdmin = dr("monto_adm")
                    mlngMontoTotal = dr("monto_total")
                    mintCodTipoDoc = dr("cod_tipo_doc")
                    mstrNroDoc = dr("nro_documento")
                    mstrBanco = dr("banco")
                    If Not IsDBNull(dr("fecha_venc_doc")) Then
                        mdtmFechaVenc = dr("fecha_venc_doc")
                    Else
                        mdtmFechaVenc = FechaMinSistema()
                    End If
                    If Not IsDBNull(dr("fecha_cobro")) Then
                        mdtmFechaCobro = dr("fecha_cobro")
                    Else
                        mdtmFechaCobro = FechaMinSistema()
                    End If
                    mlngNumAporte = dr("num_aporte")
                    mstrObservaciones = Trim(dr("observaciones"))

                    If mlngMontoNeto > 0 Then
                        mdblPorcentajeAdm = CDbl(mlngMontoAdmin) / CDbl(Me.MontoTotal) * 100
                    Else
                        mdblPorcentajeAdm = -1
                    End If
                    Inicializar2 = True
                Next
                'objCliente = New CCliente
                'objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                'objCliente.Inicializar1(mlngRutUsuario)

                'objGeneraAporte = New CGeneraComprobanteAporte
                'objGeneraAporte.GenerarComprobanteAporte(mlngNumAporte, mdtmFechaContableIngreso, objCliente.RazonSocial.Trim, mlngRutCliente, objCliente.Direccion, _
                '                                        mlngMontoTotal, mstrNroDoc, mstrBanco, mdtmFechaCobro, mstrObservaciones)
            Catch ex As Exception
                EnviaError("CAporte:Inicializar2->" & ex.Message)
            End Try
        End Function
        Public Function GenerarAportePDF(ByVal lngCodAporte As Long) As Boolean
            Try
                mlngCodAporte = -1  'inicialización
                'consulta los datos del aporte
                Dim dtAporte As DataTable
                dtAporte = mobjSql.s_aporte_1(lngCodAporte)
                If IsDBNull(dtAporte) Then
                    Nuevo()
                    GenerarAportePDF = False
                    Exit Function
                End If
                Dim dr As DataRow
                For Each dr In dtAporte.Rows
                    mlngCodAporte = lngCodAporte
                    mlngRutCliente = dr("rut_cliente")
                    mintCodCuenta = dr("cod_cuenta")
                    mintAgnoAporte = dr("agno")
                    mlngCorrelativo = dr("correlativo")
                    mdtmFechaContableIngreso = dr("fecha")
                    mintEstado = dr("cod_estado")
                    Select Case mintEstado
                        Case 1
                            mstrNombreEstado = "Por cobrar"
                        Case 2
                            mstrNombreEstado = "Cobrado"
                        Case 3
                            mstrNombreEstado = "Anulado"
                    End Select
                    mlngMontoNeto = dr("monto_neto")
                    mlngMontoAdmin = dr("monto_adm")
                    mlngMontoTotal = dr("monto_total")
                    mintCodTipoDoc = dr("cod_tipo_doc")
                    mstrNroDoc = dr("nro_documento")
                    mstrBanco = dr("banco")
                    If Not IsDBNull(dr("fecha_venc_doc")) Then
                        mdtmFechaVenc = dr("fecha_venc_doc")
                    Else
                        mdtmFechaVenc = FechaMinSistema()
                    End If
                    If Not IsDBNull(dr("fecha_cobro")) Then
                        mdtmFechaCobro = dr("fecha_cobro")
                    Else
                        mdtmFechaCobro = FechaMinSistema()
                    End If
                    mlngNumAporte = dr("num_aporte")
                    mstrObservaciones = Trim(dr("observaciones"))

                    If mlngMontoNeto > 0 Then
                        mdblPorcentajeAdm = CDbl(mlngMontoAdmin) / CDbl(Me.MontoTotal) * 100
                    Else
                        mdblPorcentajeAdm = -1
                    End If
                    GenerarAportePDF = True
                Next
                objCliente = New CCliente
                objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                objCliente.Inicializar1(RutLngAUsr(mlngRutCliente))

                objGeneraAporte = New CGeneraComprobanteAporte
                objGeneraAporte.GenerarComprobanteAporte(mlngNumAporte, mdtmFechaContableIngreso, objCliente.RazonSocial.Trim, mlngRutCliente, objCliente.Direccion, _
                                                        mlngMontoTotal, mstrNroDoc, mstrBanco, mdtmFechaCobro, mstrObservaciones)

                mstrDireccionArchivo = objGeneraAporte.RutaArchivo
                mstrRutaArchivoVirtual = objGeneraAporte.RutaArchivoVirtual
            Catch ex As Exception
                EnviaError("CAporte:GenerarAportePDF->" & ex.Message)
            End Try
        End Function


        'inicialización del objeto vacío
        Private Sub Nuevo()
            mlngCodAporte = -1
            mlngRutCliente = 0
            mintCodCuenta = 0
            mlngCorrelativo = -1
            mdtmFechaContableIngreso = FechaMinSistema()
            mintEstado = 0
            mlngMontoNeto = -1
            mlngMontoAdmin = -1
            mintCodTipoDoc = 0
            mstrNroDoc = 0
            mstrBanco = ""
            mdtmFechaVenc = FechaMinSistema()
            mdblPorcentajeAdm = -1
            mlngNumAporte = 0
            mstrObservaciones = ""
        End Sub
        'transformar una fecha que puede venir vacía en una variable de tipo date
        Private Function FechaNulaUsrAVb(ByVal strFechaVenc As String) As Date
            If Trim(strFechaVenc) <> "" Then
                FechaNulaUsrAVb = FechaUsrAVb(strFechaVenc)
            Else
                FechaNulaUsrAVb = FechaMinSistema
            End If
        End Function
        'Creación de un nuevo aporte
        Public Function Inicializar1(ByVal strRutCliente As String, _
                                ByVal intCuenta As Integer, _
                                ByVal lngMontoNeto As Long, _
                                ByVal lngMontoAdm As Long, _
                                ByVal strFechaContable As String, _
                                ByVal intCodTipoDoc As Integer, _
                                ByVal strNroDoc As String, _
                                ByVal strBanco As String, _
                                ByVal strFechaVenc As String, _
                                ByVal strFechaCobro As String, _
                                ByVal lngNumAporte As Long, _
                                ByVal strObs As String, _
                                ByVal intEstadoAporte As Integer) As Integer
            Try
                Dim lngRutCliente
                'abrir transaccion
                Call mobjSql.InicioTransaccion()  'Abro la transaccion aca para que nadie toem el numero de aporte
                If mobjSql.s_existe_numero_aporte(lngNumAporte) Then
                    'cerrar transaccion
                    Call mobjSql.RollBackTransaccion()
                    Inicializar1 = 1
                    Exit Function
                End If
                lngRutCliente = RutUsrALng(strRutCliente)
                mdtmFechaContableIngreso = FechaUsrAVb(strFechaContable)
                mdtmFechaVenc = FechaNulaUsrAVb(strFechaVenc)
                'determinar el estado del aporte y de la transaccion
                Dim intEstadoTransaccion As Integer
                'If intCodTipoDoc = 1 Or intCodTipoDoc = 2 Then  'efectivo o cheque a fecha
                'intEstadoAporte = 2  'cobrado
                intEstadoTransaccion = 2  'autorizada
                mdtmFechaVenc = mdtmFechaContableIngreso
                'mdtmFechaCobro = mdtmFechaContableIngreso
                'Else
                'intEstadoAporte = 1  'ingresado
                'intEstadoTransaccion = 1  'pendiente
                'mdtmFechaCobro = FechaMinSistema()
                'End If
                'insertar en la tabla de aportes. Recuperamos el código
                mlngCodAporte = mobjSql.i_aporte(lngRutCliente, intCuenta, mdtmFechaContableIngreso, lngMontoNeto, lngMontoAdm, _
                                                 intCodTipoDoc, strNroDoc, strBanco, strFechaVenc, strFechaCobro, lngNumAporte, _
                                                 intEstadoAporte, strObs)
                'insertar en la tabla de Transacciones: monto
                Call mobjSql.i_transaccion(lngRutCliente, intCuenta, 1, intEstadoTransaccion, lngMontoNeto, _
                                           "Aporte neto, Nro. " & lngNumAporte, -1, mlngCodAporte, mdtmFechaContableIngreso)
                Call mobjSql.i_transaccion(lngRutCliente, 3, 1, intEstadoTransaccion, lngMontoAdm, _
                                           "Aporte administración, Nro. " & lngNumAporte, -1, mlngCodAporte, mdtmFechaContableIngreso)
                Call mobjSql.i_bitacora(mlngRutUsuario, "Ingresado", _
                                        "Ingreso de aporte cliente " & RutLngAUsr(lngRutCliente), 2, mlngCodAporte)
                'obtener los datos desde la base
                Call Inicializar2(mlngCodAporte)
                mobjSql.FinTransaccion()
                Inicializar1 = 0
            Catch ex As Exception
                mobjSql.RollBackTransaccion()
                Inicializar1 = -1
            End Try
        End Function
        'modificación de aportes
        Public Sub Modificar(ByVal intCuenta As Integer, _
                             ByVal lngMontoCuenta As Long, _
                             ByVal lngMontoAdm As Long, _
                             ByVal strFechaContable As String, _
                             ByVal intCodTipoDoc As Integer, _
                             ByVal strNroDoc As String, _
                             ByVal strBanco As String, _
                             ByVal strFechaVenc As String, _
                             ByVal strFechaCobro As String, _
                             ByVal intEstadoAporte As Integer, _
                             ByVal lngNumAporte As Long, _
                             ByVal strObs As String)
            
            Dim mblnEstaAnulado As Boolean
            

            mobjSql.InicioTransaccion()

            mblnEstaAnulado = mobjSql.s_esta_aporte_anulado(mlngCodAporte)
            'registro
            Call mobjSql.u_aporte(mlngCodAporte, mlngRutCliente, intCuenta, _
                    FechaUsrAVb(strFechaContable), _
                    intEstadoAporte, lngMontoCuenta, lngMontoAdm, intCodTipoDoc, _
                    strNroDoc, strBanco, _
                    FechaNulaUsrAVb(strFechaVenc), _
                    FechaNulaUsrAVb(strFechaCobro), lngNumAporte, strObs)
            'cambio de estado de la transaccion
            If intEstadoAporte = 1 Then   'aporte ingresado
                Call mobjSql.u_transaccion_aporte_estado(mlngCodAporte, 1)   'pendiente
            ElseIf intEstadoAporte = 2 Then   'aporte cobrado
                Call mobjSql.u_transaccion_aporte_estado(mlngCodAporte, 2)   'autorizada
            End If
            

            ' Anular transaccion antigua e ingresar una nueva si el monto cambia
            Call ModificarTransaccion(mlngRutCliente, mlngCodAporte, _
                                      mlngMontoNeto, lngMontoCuenta, _
                                      intCuenta, lngNumAporte, mintCodCuenta, _
                                      FechaNulaUsrAVb(strFechaVenc), intCodTipoDoc, mblnEstaAnulado)
            ' Cuenta Administracion
            Call ModificarTransaccion(mlngRutCliente, mlngCodAporte, _
                                      mlngMontoAdmin, lngMontoAdm, _
                                      3, lngNumAporte, 3, _
                                      FechaNulaUsrAVb(strFechaVenc), intCodTipoDoc, mblnEstaAnulado)

        
            'registro en la bitácora
            Call mobjSql.i_bitacora(mlngRutUsuario, "Modificado - Estado " & intEstadoAporte, _
                                    "Modificación de aporte cliente " & RutLngAUsr(mlngRutCliente), 2, mlngCodAporte)
            'commit
            mobjSql.FinTransaccion()

            'lee los datos desde la base
            Inicializar2(mlngCodAporte)


            Try

            Catch ex As Exception
                mobjSql.RollBackTransaccion()
                EnviaError("" & ex.Message)
            End Try
        End Sub
        'modificación de transacciones de aportes
        Private Sub ModificarTransaccion(ByVal lngRut As Long, _
                                         ByVal lngCodAporte As Long, _
                                         ByVal lngMontoAntiguo As Long, _
                                         ByVal lngMontoNuevo As Long, _
                                         ByVal intCodCuenta As Integer, _
                                         ByVal lngNumAporte As Long, _
                                         ByVal intCodCuentaAnt As Integer, _
                                         ByVal dtmFechaVencNueva As Date, _
                                         ByVal intCodTipoDocNuevo As Integer, _
                                         ByVal blnEstaAnulado As Boolean)
            Try
                Dim Texto As String
                Dim textoAnula As String
                Dim dtmFechaHora As Date
                dtmFechaHora = FechaTransaccion()
                If intCodCuenta = 3 Then
                    Texto = "Aporte administración, Nro. " & lngNumAporte
                    textoAnula = "Anulación de Aporte." & lngNumAporte
                Else
                    Texto = "Aporte neto, Nro. " & lngNumAporte
                    textoAnula = "Anulación de Aporte."
                End If
                If lngMontoAntiguo = lngMontoNuevo And intCodCuenta = intCodCuentaAnt And Not blnEstaAnulado Then
                    Exit Sub
                Else
                    If Not blnEstaAnulado Then
                        'Anular transacción
                        mobjSql.i_transaccion(lngRut, intCodCuentaAnt, 1, 4, -lngMontoAntiguo, _
                                                   textoAnula, -1, lngCodAporte, dtmFechaHora)
                    End If
                    'insertar en la tabla de Transacciones
                    mobjSql.i_transaccion(lngRut, intCodCuenta, 1, 1, lngMontoNuevo, _
                                               Texto, -1, lngCodAporte, dtmFechaHora)
                End If
            Catch ex As Exception
                mobjSql.RollBackTransaccion()
                EnviaError("" & ex.Message)
            End Try
        End Sub
        'Genera la fecha de la transacción, si el año actual es igual al de la transacción entonces retorna la fecha actual, si es mayor o menor retorna el primer o ultimo instante del año segun corresponda
        Function FechaTransaccion() As Date
            Dim dtmFechaHora As Date
            If Year(mdtmFechaContableIngreso) < Now.Year Then
                dtmFechaHora = FechaMaxAgno(Year(mdtmFechaContableIngreso))
            ElseIf Year(mdtmFechaContableIngreso) > Now.Year Then
                dtmFechaHora = FechaMinAgno(Year(mdtmFechaContableIngreso))
            Else
                dtmFechaHora = Now
            End If
            FechaTransaccion = dtmFechaHora
        End Function

        'Cambia el estado del aporte a anulado
        Public Sub Anular(ByVal strGlosa As String, ByVal RutUsuario As Long)
            Try
                Dim dtmFechaHora As Date

                ' genero la fecha de la transaccion correcta dependiendo del año
                dtmFechaHora = FechaTransaccion()


                'abrir transacción
                mobjSql.InicioTransaccion()

                Call mobjSql.u_anular_aporte(mlngCodAporte)

                'Anular transacción
                Call mobjSql.i_transaccion(mlngRutCliente, mintCodCuenta, 1, 4, -mlngMontoNeto, _
                                           "Anulación de Aporte Nro. " & mlngNumAporte, -1, mlngCodAporte, dtmFechaHora)


                'anular transacción cuenta de administración
                Call mobjSql.i_transaccion(mlngRutCliente, 3, 1, 4, -mlngMontoAdmin, _
                                           "Anulación de Aporte Nro. " & mlngNumAporte, -1, mlngCodAporte, dtmFechaHora)

                Call mobjSql.i_bitacora(RutUsuario, "Anulado", _
                                        "Nulidad de aporte. Cliente:" _
                                        & RutLngAUsr(mlngRutCliente) & ". " & strGlosa, 2, mlngCodAporte)

                'cerrar transaccion y conexión
                mobjSql.FinTransaccion()
            Catch ex As Exception
                mobjSql.RollBackTransaccion()
                EnviaError("" & ex.Message)
            End Try

        End Sub

    End Class
End Namespace
