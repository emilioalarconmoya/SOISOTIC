Imports Microsoft.VisualBasic
Imports Clases
Imports modulos
Imports System.data

Public Class CSolicitud
    Implements IReporte
#Region "declaraciones"
    'consultas sql y objetos de conexion
    Private mobjSql As CSql
    'rut del usuario conectado

    Private mlngRutUsuario As Long
    Private mlngCodSolicitud As Long
    Private mintCodEstadoSolicitud As Integer
    Private mlngRutBenefactor As Long
    Private mlngRutBeneficiado As Long
    Private mlngCodCurso As Long
    Private mdtmFechaIngreso As Date
    Private mlngMontoCtaReparto As Long
    Private mlngMontoCtaExcRep As Long
    Private mlngMontoCtaAdm As Long
    Private mlngNroTransCtaRep As Long
    Private mlngNroTransCtaExcRep As Long
    Private mintCodEstadoTransCtaRep As Integer
    Private mintCodEstadoTransCtaExcRep As Integer
    Private mlngSaldoCtaRep As Long
    Private mlngSaldoCtaExcRep As Long
    Private mlngMontoSolicitud As Long
    'porcentaje de administración del cliente
    Private mdblPorcAdm As Double
    Private mintCodigoCuenta As Integer
#End Region
#Region "propiedades"
    
    Public ReadOnly Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
    End Property
    Public ReadOnly Property CodSolicitud() As Long
        Get
            Return mlngCodSolicitud
        End Get
    End Property
    Public ReadOnly Property CodEstadoSolicitud() As Long
        Get
            Return mintCodEstadoSolicitud
        End Get
    End Property
    Public Property RutBenefactor() As Long
        Get
            Return mlngRutBenefactor
        End Get
        Set(ByVal value As Long)
            mlngRutBenefactor = value
        End Set
    End Property
    Public Property RutBenefactorLng() As Long
        Get
            Return mlngRutBenefactor
        End Get
        Set(ByVal value As Long)
            mlngRutBenefactor = value
        End Set
    End Property
    'Public ReadOnly Property RutBenefactor() As Long
    '    Get
    '        Return mlngRutBenefactor
    '    End Get
    'End Property
    Public Property RutBeneficiado() As Long
        Get
            Return mlngRutBeneficiado
        End Get
        Set(ByVal value As Long)
            mlngRutBeneficiado = value
        End Set
    End Property
    'Public ReadOnly Property RutBeneficiado() As Long
    '    Get
    '        Return mlngRutBeneficiado
    '    End Get
    'End Property
    Public ReadOnly Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
    End Property
    Public ReadOnly Property FechaIngreso() As Date
        Get
            FechaIngreso = FechaVbAUsr(mdtmFechaIngreso)
        End Get
    End Property
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
    Public Property NroTransCtaRep() As Long
        Get
            Return mlngNroTransCtaRep
        End Get
        Set(ByVal value As Long)
            mlngNroTransCtaRep = value
        End Set
    End Property
    Public ReadOnly Property NroTransCtaExcRep() As Long
        Get
            Return mlngNroTransCtaExcRep
        End Get
    End Property
    Public ReadOnly Property CodEstadoTransCtaRep() As Integer
        Get
            Return mintCodEstadoTransCtaRep
        End Get
    End Property
    Public ReadOnly Property CodEstadoTransCtaExcRep() As Integer
        Get
            Return mintCodEstadoTransCtaExcRep
        End Get
    End Property
    Public ReadOnly Property SaldoCtaRep() As Long
        Get
            Return mlngSaldoCtaRep
        End Get
    End Property
    Public ReadOnly Property SaldoCtaExcRep() As Long
        Get
            Return mlngSaldoCtaExcRep
        End Get
    End Property
    Public ReadOnly Property MontoSolicitud() As Long
        Get
            Return mlngMontoSolicitud
        End Get
    End Property
    Public ReadOnly Property PorcAdm() As Double
        Get
            Return mdblPorcAdm
        End Get
    End Property
    Public ReadOnly Property CodigoCuenta() As Integer
        Get
            Return mintCodigoCuenta
        End Get
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

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar

    End Function

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get

        End Get
    End Property
#End Region
    Public Sub Inicializar0(ByRef objSql As CSql, _
                        ByVal lngRutUsuario As Long)
        mobjSql = objSql
        If lngRutUsuario <= 0 Then
            EnviaError("cSolicitud:Inicializar0 - Usuario desconocido")
            Exit Sub
        End If
        mlngRutUsuario = lngRutUsuario
    End Sub
    'inicialización de variables
    Public Sub New()
        mlngRutBenefactor = -1
        mlngRutBeneficiado = -1
        mlngCodCurso = -1
        mlngMontoCtaReparto = -1
        mlngMontoCtaExcRep = -1
        mlngNroTransCtaRep = -1
        mlngNroTransCtaExcRep = -1
        mintCodEstadoTransCtaRep = -1
        mintCodEstadoTransCtaExcRep = -1
        mintCodEstadoSolicitud = 1
        mdblPorcAdm = 0
        mlngMontoCtaAdm = 0
    End Sub

    Public Function Inicializar1(ByVal lngCodCurso As Long, ByVal lngRutBenefactor As Long, _
                                 ByVal lngRutBeneficiado As Long) As Boolean

        Try
            Dim dtTemporal As DataTable
            Dim dtTempTrans As DataTable
            Dim dtCodCta As DataTable
            Dim dtCodEstadoT As DataTable
            Dim i, intTamArr1, intTamArr2 As Integer
            Dim lngNroTranTemp As Long
            Dim objCurso As CCursoContratado

            Dim objCliente As CCliente
            Dim objCtaRep, objCtaExcRep As CCuenta

            Dim blnInicCliente As Boolean
            mobjSql = New CSql
            objCliente = New CCliente
            objCliente.Inicializar0(mobjSql, mlngRutUsuario)
            objCurso = New CCursoContratado
            objCurso.Inicializar0(mobjSql, mlngRutUsuario)

            'objCurso.Inicializar1(mlngCodCurso)
            'objCurso.ObtenerSolPagoTerc(CodCurso, RutBenefactor)
            'objCurso.ObtenerInfoCuentas()
            'objCtaRep = New CCuenta
            'objCtaRep.Inicializar(mlngRutUsuario, mintCodigoCuenta)

            If objCurso.Inicializar1(lngCodCurso) Then
                objCliente.Agno = objCurso.Agno
            End If
            objCurso = Nothing
            blnInicCliente = objCliente.Inicializar1(RutLngAUsr(lngRutBenefactor))
            If blnInicCliente Then
                objCtaRep = objCliente.ObjCuentaRep
                objCtaExcRep = objCliente.ObjCuentaExcRep
                mlngSaldoCtaRep = objCtaRep.SaldoActual
                mlngSaldoCtaExcRep = objCtaExcRep.SaldoActual
                mdblPorcAdm = objCliente.CostoAdm

                objCtaRep = Nothing
                objCtaExcRep = Nothing
                objCliente = Nothing
            Else
                Inicializar1 = False
                Exit Function
            End If

            dtTemporal = mobjSql.s_sol_pago_terc(lngCodCurso, lngRutBenefactor)

            intTamArr1 = mobjSql.Registros 'TamanoArreglo1(dtTemporal)
            'intTamArr2 = mobjSql.Registros2 ' TamanoArreglo2(dtTemporal)

            'If intTamArr1 = 0 Or intTamArr2 = 0 Then
            '    Inicializar1 = False
            '    Exit Function
            'Else
            If IsDBNull(dtTemporal.Rows(0)(5)) Then
                dtTemporal.Rows(0)(5) = -1
            End If
            mlngCodSolicitud = dtTemporal.Rows(0)(0)
            mlngRutBenefactor = lngRutBenefactor
            mlngRutBeneficiado = lngRutBeneficiado
            mlngCodCurso = lngCodCurso
            mdtmFechaIngreso = dtTemporal.Rows(0)(3)
            mlngMontoSolicitud = dtTemporal.Rows(0)(4)
            lngNroTranTemp = dtTemporal.Rows(0)(5)
            mintCodEstadoSolicitud = dtTemporal.Rows(0)(6)
            mlngMontoCtaAdm = dtTemporal.Rows(0)(7)
            'If lngNroTranTemp > -1 Then
                dtTempTrans = mobjSql.s_cta_est_tran1(lngNroTranTemp)
                If mobjSql.Registros <> 0 Then
                    'If TamanoArreglo2(dtTempTrans) <> 0 And TamanoArreglo1(dtTempTrans) <> 0 Then
                If dtTempTrans.Rows(0)(0) = 2 Then
                    mlngMontoCtaReparto = dtTemporal.Rows(0)(4)
                    mlngMontoCtaExcRep = 0
                    mlngNroTransCtaRep = dtTemporal.Rows(0)(5)
                    mlngNroTransCtaExcRep = -1
                    mintCodEstadoTransCtaRep = dtTemporal.Rows(0)(1)
                    mintCodEstadoTransCtaExcRep = -1
                ElseIf dtTempTrans.Rows(0)(0) = 5 Then
                    mlngMontoCtaReparto = 0
                    mlngMontoCtaExcRep = dtTemporal.Rows(0)(4)
                    mlngNroTransCtaRep = -1
                    mlngNroTransCtaExcRep = dtTemporal.Rows(0)(5)
                    mintCodEstadoTransCtaRep = -1
                    mintCodEstadoTransCtaExcRep = dtTemporal.Rows(0)(1)
                End If
                End If
            'Else
            dtTempTrans = mobjSql.s_cta_est_tran2(mlngRutBenefactor, mlngCodCurso)
                intTamArr1 = mobjSql.Registros
                ' intTamArr1 = TamanoArreglo2(dtTempTrans)
                If intTamArr1 = 1 Then
                    If dtTempTrans.Rows(0)(0) = 2 Then
                        mlngMontoCtaReparto = dtTemporal.Rows(0)(4)
                        mlngMontoCtaExcRep = 0
                        mlngNroTransCtaRep = dtTemporal.Rows(0)(5)
                        mlngNroTransCtaExcRep = -1
                        mintCodEstadoTransCtaRep = dtTempTrans.Rows(0)(1)
                        mintCodEstadoTransCtaExcRep = -1
                    ElseIf dtTempTrans.Rows(0)(0) = 5 Then
                        mlngMontoCtaReparto = 0
                        mlngMontoCtaExcRep = dtTemporal.Rows(0)(4)
                        mlngNroTransCtaRep = -1
                        mlngNroTransCtaExcRep = dtTemporal.Rows(0)(5)
                        mintCodEstadoTransCtaRep = -1
                        mintCodEstadoTransCtaExcRep = dtTempTrans.Rows(0)(1)
                    End If
                ElseIf intTamArr1 > 1 Then
                    'ElseIf intTamArr2 > 1 Then
                    mlngMontoCtaReparto = 0
                    mlngMontoCtaExcRep = 0
                    For i = 0 To (intTamArr2 - 1)
                        If dtTempTrans.Rows(i)(0) = 2 And dtTempTrans.Rows(0)(1) = 3 Then
                            mlngMontoCtaReparto = mlngMontoCtaReparto + dtTempTrans.Rows(0)(2)
                            mintCodEstadoTransCtaRep = dtTempTrans.Rows(0)(1)
                            mintCodEstadoTransCtaExcRep = -1
                        ElseIf dtTempTrans.Rows(i)(0) = 5 And dtTempTrans.Rows(0)(1) = 3 Then
                            mlngMontoCtaExcRep = mlngMontoCtaExcRep + dtTempTrans.Rows(0)(2)
                            mintCodEstadoTransCtaRep = -1
                            mintCodEstadoTransCtaExcRep = dtTempTrans.Rows(0)(1)
                        End If
                    Next
                    mlngNroTransCtaRep = -1
                    mlngNroTransCtaExcRep = -1
                End If
            'End If
            'End If

            Inicializar1 = True
        Catch ex As Exception
            EnviaError("CSolicitud:inicializar1-->" & ex.Message)
        End Try
    End Function
    Public Function Inicializar2(ByVal lngRutBeneficiado As Long, _
                             ByVal lngRutBenefactor As Long, _
                             ByVal lngCodCurso As Long, _
                             ByVal lngMonto As Long, _
                             ByVal lngNroTransaccion As Long) As Boolean

        Try
            Dim objCliente As CCliente
            Dim objCtaRep, objCtaExcRep As CCuenta
            Dim objCurso As CCursoContratado
            Dim blnInicCliente As Boolean

            objCliente = New CCliente
            Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
            objCurso = New CCursoContratado
            Call objCurso.Inicializar0(mobjSql, mlngRutUsuario)
            If objCurso.Inicializar1(lngCodCurso) Then
                objCliente.Agno = objCurso.Agno
            End If
            objCurso = Nothing
            blnInicCliente = objCliente.Inicializar1(RutLngAUsr(lngRutBenefactor))
            If blnInicCliente Then
                objCtaRep = objCliente.ObjCuentaRep
                objCtaExcRep = objCliente.ObjCuentaExcRep
                mlngSaldoCtaRep = objCtaRep.SaldoActual
                mlngSaldoCtaExcRep = objCtaExcRep.SaldoActual
                mdblPorcAdm = objCliente.CostoAdm

                objCtaRep = Nothing
                objCtaExcRep = Nothing
                objCliente = Nothing
            Else
                Inicializar2 = False
                Exit Function
            End If


            'Por defecto se le asigna la transaccion a la cuenta de reparto del benefactor
            mlngRutBenefactor = lngRutBenefactor
            mlngRutBeneficiado = lngRutBeneficiado
            mlngCodCurso = lngCodCurso

            mlngMontoCtaReparto = lngMonto
            mlngMontoCtaExcRep = 0
            mlngNroTransCtaRep = lngNroTransaccion
            mlngNroTransCtaExcRep = -1
            mintCodEstadoTransCtaRep = 3    '3: Estado de Transaccion Solicitada
            mintCodEstadoTransCtaExcRep = -1
            mintCodEstadoSolicitud = 1
            Inicializar2 = True

        Catch ex As Exception

        End Try

    End Function
    Public Sub Grabar()
        Try
            Call mobjSql.i_sol_pago_terc(mlngRutBenefactor, mlngCodCurso, mlngMontoCtaReparto, mlngNroTransCtaRep, mlngMontoCtaAdm)

            Exit Sub
        Catch ex As Exception
            'Call mobjSql.RollBackTransaccion()
        End Try
    End Sub
    Public Sub Modificar()
        Try
            Call mobjSql.u_sol_pago_ter(mlngRutBenefactor, mlngCodCurso, mlngMontoCtaReparto, mlngNroTransCtaRep, mlngCodSolicitud, mlngMontoCtaAdm, mintCodEstadoSolicitud)


        Catch ex As Exception
ModificarErr:
            Call mobjSql.RollBackTransaccion()
        End Try
    End Sub

    Public Sub CambiarEstAutorizada()
        Try
            mintCodEstadoSolicitud = 2
            Call mobjSql.u_estado_sol_pago_ter(mlngCodCurso, 2, mlngRutBenefactor)

            If mlngMontoCtaAdm > 0 Then
                Call mobjSql.u_monto_adm_sol(mlngCodCurso, mlngRutBenefactor, mlngMontoCtaAdm)
            End If
        Catch ex As Exception
CambiarEstAutorizadaErr:
            Call mobjSql.RollBackTransaccion()
        End Try

    End Sub
    Public Sub CambiarEstPendiente()
        Try
            mintCodEstadoSolicitud = 1
            Call mobjSql.u_estado_sol_pago_ter(mlngCodCurso, 1, mlngRutBenefactor)
            If mlngMontoCtaAdm > 0 Then
                Call mobjSql.u_monto_adm_sol(mlngCodCurso, mlngRutBenefactor, 0)
                mlngMontoCtaAdm = 0
            End If
        Catch ex As Exception
CambiarEstPendienteErr:
            Call mobjSql.RollBackTransaccion()
        End Try
    End Sub

    Public Sub Borrar()
        Try
            Call mobjSql.d_sol_pago_terc(mlngRutBenefactor, mlngCodCurso)

        Catch ex As Exception
BorrarErr:
            Call mobjSql.RollBackTransaccion()
        End Try
    End Sub

    Private Sub CambiarEstRechazada()
        Try
            mintCodEstadoSolicitud = 3
            Call mobjSql.u_estado_sol_pago_ter(mlngCodCurso, 3, mlngRutBenefactor)
            If mlngMontoCtaAdm > 0 Then
                Call mobjSql.u_monto_adm_sol(mlngCodCurso, mlngRutBenefactor, 0)
                mlngMontoCtaAdm = 0
            End If
        Catch ex As Exception
            EnviaError("CSolicitud:CambiarestRechazada----->" & ex.Message)
            Call mobjSql.RollBackTransaccion()
        End Try
    End Sub

    'Autorizar solicitud de pago
    Public Function AutorizarSolPago() As Boolean
        Try
            Dim objCliente As CCliente
            Dim objCtaRep, objCtaExcRep, objCtaAdm As CCuenta

            Dim lngSaldoCtaExcRep, serial_trans As Long
            Dim blnEsCliente As Boolean, blnBorraTr1 As Boolean, blnBorraTr2 As Boolean
            Dim FechaTransaccion As Date
            Dim objCurso As CCursoContratado
            Dim intAgnoInicioCurso As Integer
            Dim intCodCuenta, intTipoTrans, intEstadoTrans As Integer

            If mlngRutBeneficiado > 0 Then
                objCliente = New CCliente
                Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                blnEsCliente = objCliente.EsCliente(mlngRutBeneficiado)
                objCliente = Nothing
                If Not blnEsCliente Then
                    AutorizarSolPago = False
                    Exit Function
                End If
            Else
                AutorizarSolPago = False
                Exit Function
            End If
            If mlngRutBenefactor > 0 Then
                objCliente = New CCliente
                Call objCliente.Inicializar0(mobjSql, mlngRutUsuario)
                blnEsCliente = objCliente.EsCliente(mlngRutBenefactor)
                If Not blnEsCliente Then
                    AutorizarSolPago = False
                    Exit Function
                End If
            Else
                AutorizarSolPago = False
                Exit Function
            End If
            objCurso = New CCursoContratado
            Call objCurso.Inicializar0(mobjSql, mlngRutUsuario)
            If objCurso.Inicializar1(mlngCodCurso) Then
                intAgnoInicioCurso = objCurso.Agno
            Else
                intAgnoInicioCurso = Now.Year
            End If
            objCurso = Nothing
            objCliente.Agno = intAgnoInicioCurso
            blnEsCliente = objCliente.Inicializar1(RutLngAUsr(mlngRutBenefactor))
            mdblPorcAdm = objCliente.CostoAdm

            objCtaRep = objCliente.ObjCuentaRep
            objCtaExcRep = objCliente.ObjCuentaExcRep
            objCtaAdm = objCliente.ObjCuentaAdm
            lngSaldoCtaExcRep = objCtaExcRep.SaldoActual

            If mlngMontoCtaExcRep > lngSaldoCtaExcRep Then
                AutorizarSolPago = False
                Exit Function
            End If

            Dim arrTemporal As DataTable
            arrTemporal = mobjSql.s_sol_pago_terc(mlngCodCurso, mlngRutBenefactor)
            mlngCodSolicitud = arrTemporal.Rows(0)(0) '(0, 0)

            'abrir transaccion
            mobjSql.InicioTransaccion()


            CambiarEstAutorizada()

            mintCodEstadoSolicitud = 2
            intCodCuenta = 2      '2 es el codigo de la cuenta de reparto
            blnBorraTr1 = mobjSql.d_transaccion(mlngRutBenefactor, mlngCodCurso, intCodCuenta) ' reparto
            blnBorraTr2 = mobjSql.d_transaccion(mlngRutBenefactor, mlngCodCurso, 5) ' Excedente de reparto
            If Not blnBorraTr1 And Not blnBorraTr2 Then
                'rollback
                Call mobjSql.RollBackTransaccion()
                AutorizarSolPago = False    'Error, no habia transaccion solicitada
                Exit Function
            End If
            If Now.Year < intAgnoInicioCurso Then
                FechaTransaccion = DateSerial(intAgnoInicioCurso, 1, 1)
            ElseIf Now.Year > intAgnoInicioCurso Then
                FechaTransaccion = DateSerial(intAgnoInicioCurso, 12, 31)
            Else
                FechaTransaccion = Now
            End If
            If mlngMontoCtaReparto > 0 Then
                intCodCuenta = 2      '2 es el codigo de la cuenta de reparto
                intTipoTrans = 2      '2 es el codigo del ingreso de un monto
                intEstadoTrans = 1    '1 es el codigo de una transaccion pendiente
                'cta de reparto
                serial_trans = mobjSql.i_transaccion(mlngRutBenefactor, intCodCuenta, intTipoTrans, _
                                                     intEstadoTrans, mlngMontoCtaReparto, "Pago a terceros, cta. reparto", mlngCodCurso, 0, FechaTransaccion)
                Call mobjSql.u_nro_trans_solicitud_pago_ter(mlngCodSolicitud, serial_trans)
                Call objCtaRep.Actualizar_Saldo()
                'cta de administración
                'Dim lngMontoAdmin As Long
                'lngMontoAdmin = mdblPorcAdm * mlngMontoCtaReparto / 100
                serial_trans = mobjSql.i_transaccion(mlngRutBenefactor, 3, intTipoTrans, _
                                                     intEstadoTrans, mlngMontoCtaAdm, "Pago a terceros, cta. adm", mlngCodCurso, 0, FechaTransaccion)
                Call objCtaAdm.Actualizar_Saldo()
                mintCodEstadoTransCtaRep = 1
            End If
            If mlngMontoCtaExcRep > 0 Then
                intCodCuenta = 5      '5 es el codigo de la cuenta de excedentes de reparto
                intTipoTrans = 2      '2 es el codigo del ingreso de un monto
                intEstadoTrans = 1    '1 es el codigo de una transaccion pendiente
                serial_trans = mobjSql.i_transaccion(mlngRutBenefactor, intCodCuenta, intTipoTrans, _
                                                     intEstadoTrans, mlngMontoCtaExcRep, "Pago a terceros", mlngCodCurso, 0, FechaTransaccion)
                Call mobjSql.u_nro_trans_solicitud_pago_ter(mlngCodSolicitud, serial_trans)
                Call objCtaExcRep.Actualizar_Saldo()
                mintCodEstadoTransCtaExcRep = 1
            End If

            If mlngMontoCtaReparto > 0 Or mlngMontoCtaExcRep > 0 Then
                'cerrar transaccion
                mobjSql.FinTransaccion()
                AutorizarSolPago = True
            Else
                'rollback
                Call mobjSql.RollBackTransaccion()
                AutorizarSolPago = False
            End If
            objCliente = Nothing
            objCtaRep = Nothing
            objCtaExcRep = Nothing
        Catch ex As Exception
AutorizarSolPagoErr:
            mobjSql.RollBackTransaccion()
            EnviaError("cSolicitud:AutorizarSolPago--->" & ex.Message)
        End Try


    End Function

    Public Function RechazarSolPago() As Boolean
        Try
            Dim objCliente As CCliente
            Dim objCtaRep, objCtaExcRep As CCuenta
            Dim lngSaldoCtaRep, lngSaldoCtaExcRep, serial_trans As Long
            Dim blnEsCliente, blnBorraTr As Boolean
            Dim intCodCuenta, intTipoTrans, intEstadoTrans As Integer

            mobjSql.InicioTransaccion()
            CambiarEstRechazada()
            mobjSql.FinTransaccion()

            'intCodCuenta = 2      '2 es el codigo de la cuenta de reparto
            'blnBorraTr = mobjSql.d_transaccion(mlngRutBenefactor, mlngCodCurso, intCodCuenta)
            'If Not blnBorraTr Then
            '    RechazarSolPago = False    'Error, no habia transaccion solicitada
            '    Exit Function
            'Else
            '    Call mobjSql.u_nro_trans_solicitud_pago_ter(mlngCodSolicitud, -1)
            '    mintCodEstadoTransCtaRep = 4
            '    RechazarSolPago = True
            'End If
            RechazarSolPago = True

        Catch ex As Exception
            EnviaError("cSolicitud:RechazarSolPag--->" & ex.Message)
        End Try

    End Function



End Class

