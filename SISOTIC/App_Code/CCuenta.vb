Imports Clases
Imports Modulos
Imports System.Data

Public Class CCuenta
    'objeto con consultas a la base
    Private mobjSql As CSql
    'Rut Cliente
    Private mlngRut As Long
    'lista de ruts del holding, separados por comas
    Private mstrListaRutsHolding As String
    'Codigo Cuenta
    Private mintCodCuenta As Integer
    'Calculo Saldo actual de un cliente tabla cuenta_cliente
    Private mlngSaldoActual As Long
    'Suma Aportes, suma de los aportes... esto ya no -> y los excedentes POSITIVOS (Los negativos son los que se asignan a final de año)
    Private mlngSumaAportes As Long
    'Suma Cursos, suma de los cargos que corresponden solo a cursos
    Private mlngSumaCursos As Long
    'Suma Abono
    Private mlngSumaAbono As Long
    'suma abono por mandato
    Private mlngSumaAbonoXMandato As Long
    'Suma Cargo
    Private mlngSumaCargo As Long
    'Saldo Anterior a la fecha de inicio
    Private mlngSaldoAnterior As Long
    'Suma V&T, suma los cargos que corresponden sólo a V&T
    Private mlngSumaVyT As Long
    'Aportes por cobrar
    Private mlngAportePorCobrar As Long
    'Este saldo considera el saldo actual - aportes por cobrar del respectivo año (-1 para excedentes)
    '(-2 para becas). Define Morosidad
    Private mlngSaldoMorosidad As Long
    'Flag que setea y realiza la consulta (default FALSE)
    Private mblnConsultarSaldoMorosidad As Boolean
    'Año del período
    Private mintAgno As Integer
    'fecha inicial y final del período
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date
    'arreglo
    Private marrCuenta As DataTable
    Private mlngGastosCursosCompletos As Long
    Private mlngGastosCursosParciales As Long
    Private mlngGastosCursosComplementarios As Long
    Private mlngAporteTotal As Long
    Private mlngSumavtCursosPropiosAgnoAnterior As Long
    Private mlngSumaRepartoRecibido As Long
    Private mlngSumaExcRepartoRecibido As Long

    Public Property SumaRepartoRecibido() As Long
        Get
            Return mlngSumaRepartoRecibido
        End Get
        Set(ByVal value As Long)
            mlngSumaRepartoRecibido = value
        End Set
    End Property
    Public Property SumaExcRepartoRecibido() As Long
        Get
            Return mlngSumaExcRepartoRecibido
        End Get
        Set(ByVal value As Long)
            mlngSumaExcRepartoRecibido = value
        End Set
    End Property
    Public Property SumavtCursosPropiosAgnoAnterior() As Long
        Get
            Return mlngSumavtCursosPropiosAgnoAnterior
        End Get
        Set(ByVal value As Long)
            mlngSumavtCursosPropiosAgnoAnterior = value
        End Set
    End Property
    Public Property AporteTotal() As Long
        Get
            Return mlngAporteTotal
        End Get
        Set(ByVal value As Long)
            mlngAporteTotal = value
        End Set
    End Property


    'fecha de inicio
    Public Property FechaInicio() As String
        Get
            Return FechaVbAUsr(mdtmFechaIni)
        End Get
        Set(ByVal value As String)
            mdtmFechaIni = FechaUsrAVb(value)
        End Set
    End Property

    'año período
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property

    'fecha de fin del periodo
    Public Property FechaFin() As String
        Get
            Return FechaVbAUsr(mdtmFechaFin)
        End Get
        Set(ByVal value As String)
            mdtmFechaFin = FechaVbAUsr(value)
        End Set
    End Property

    'arreglo con todos los registros con las cuentas de un cliente y una cuenta en particular
    Public ReadOnly Property ArregloCuenta() As DataTable
        Get
            Return marrCuenta
        End Get
    End Property

    'Saldo Actual Cuenta Cliente tabla Cuenta_Cliente
    Public ReadOnly Property SaldoActual() As Long
        Get
            Return mlngSaldoActual
        End Get
    End Property
    Public ReadOnly Property SumaAbonoXMandato() As Long
        Get
            Return mlngSumaAbonoXMandato
        End Get
    End Property
    'Saldo Anterior a la fecha dada como inicio
    Public ReadOnly Property SaldoAnterior() As Long
        Get
            Return mlngSaldoAnterior
        End Get
    End Property

    'Codigo Cuenta Cliente
    Public Property CodCuenta() As Integer
        Get
            Return mintCodCuenta
        End Get
        Set(ByVal value As Integer)
            mintCodCuenta = value
        End Set
    End Property

    'Rut Cliente
    Public Property RutCliente() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
        End Set
    End Property
    'lista de ruts del holding separados por comas
    Public WriteOnly Property ListaRutsHolding() As String
        Set(ByVal value As String)
            mstrListaRutsHolding = value
        End Set
    End Property

    'Sumatoria de los Abonos de un Cliente
    Public ReadOnly Property SumaAbono() As Long
        Get
            Return mlngSumaAbono
        End Get
    End Property

    'Sumatoria de los Aportes de un Cliente, considerando solo los aportes y excedentes positivos
    Public ReadOnly Property SumaAporte() As Long
        Get
            Return mlngSumaAportes
        End Get
    End Property

    'Suma Cargo
    Public ReadOnly Property SumaCargoCursos() As Long
        Get
            Return mlngSumaCursos
        End Get
    End Property

    'Suma Cargo por V&T
    Public ReadOnly Property SumaCargoVyT() As Long
        Get
            Return mlngSumaVyT
        End Get
    End Property

    'Suma Cargo
    Public ReadOnly Property SumaCargo() As Long
        Get
            Return mlngSumaCargo
        End Get
    End Property


    'Suma Saldo
    Public ReadOnly Property SumaSaldo() As Long
        Get
            SumaSaldo = mlngSumaAbono - mlngSumaCargo
        End Get
    End Property
    'Suma Saldo pendiente
    Public ReadOnly Property SumaSaldoPend() As Long
        Get
            SumaSaldoPend = mlngSumaAportes - mlngSumaCursos
        End Get
    End Property

    'Saldo de morosidad, respectivo al periodo de pago
    Public ReadOnly Property SaldoMorosidad() As Long
        Get
            Return mlngSaldoMorosidad
        End Get
    End Property
    'Flag para consultar los saldos de morosidad
    Public WriteOnly Property ConsultarSaldoMorosidad() As Boolean
        Set(ByVal value As Boolean)
            mblnConsultarSaldoMorosidad = value
        End Set
    End Property

    'Valor Total cursos completos en el año
    Public ReadOnly Property GastosCursosCompletos() As Long
        Get
            Return mlngGastosCursosCompletos
        End Get
    End Property
    Public ReadOnly Property GastosCursosParciales() As Long
        Get
            Return mlngGastosCursosParciales
        End Get
    End Property
    Public ReadOnly Property GastosCursosComplementarios() As Long
        Get
            Return mlngGastosCursosComplementarios
        End Get
    End Property

    'inicialización del objeto
    Public Sub inicializarCsql(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    'Inicilizar entrega la cartola para un cliente y una cuenta especifica
    Public Sub Inicializar(ByVal lngRutCliente As Long, _
                            ByVal intCodigoCuenta As Integer, _
                            Optional ByVal strListaRuts As String = "")
        Try
            Dim lngAporteTemp As Long, intCodCuentaTemp As Integer
            lngAporteTemp = 0

            mlngRut = lngRutCliente
            mintCodCuenta = intCodigoCuenta
            mstrListaRutsHolding = strListaRuts
            'asigna Saldo Actual Cliente, parece que esto no se usa
            'mlngSaldoActual = mobjSql.s_saldo_cuenta(lngRutCliente, intCodigoCuenta)
            'cartola del año
            Dim dtmIni As Date, dtmFin As Date
            Dim dtmIniTemp As Date, dtmFinTemp As Date
            dtmIni = DateSerial(mintAgno, 1, 1)
            dtmFin = DateSerial(mintAgno, 12, 31)


            'Esto se hace para obtener los aportes pendientes del periodo respectivo,
            'de forma de obtener el verdadero saldo contra documentos que no han sido cobrados efectivamente
            'aportes pendientes (cheques y docs. a fecha no cobrados)
            Select Case mintCodCuenta
                Case 1, 2, 3, 7, 10, 11
                    'Se consula por los aportes del año
                    marrCuenta = Cartola(FechaVbAUsr(dtmIni), FechaVbAUsr(dtmFin))
                    mlngSaldoActual = SumaSaldo
                    mlngSaldoMorosidad = mlngSaldoActual - mlngAportePorCobrar
                Case 4, 5
                    'Si está seteado el flag se realiza esta consulta
                    If mblnConsultarSaldoMorosidad Then

                        'Registro el código de la cuenta EXC.,
                        'por que debo consultar los aportes de cta. 1 o 2 del año anterior
                        intCodCuentaTemp = mintCodCuenta
                        If mintCodCuenta = 4 Then
                            mintCodCuenta = 1
                        Else            '= 5
                            mintCodCuenta = 2
                        End If
                        'Se consulta por los aportes del año anterior pendientes
                        dtmIniTemp = DateSerial(mintAgno - 1, 1, 1)
                        dtmFinTemp = DateSerial(mintAgno - 1, 12, 31)

                        marrCuenta = Cartola(FechaVbAUsr(dtmIniTemp), FechaVbAUsr(dtmFinTemp))
                        mlngSaldoActual = SumaSaldo

                        lngAporteTemp = mlngAportePorCobrar
                        mintCodCuenta = intCodCuentaTemp

                    End If

                    'CARTOLA REAL-------------------------------------------------
                    'Acá se consulta por los saldos del periodo correspondiente
                    marrCuenta = Cartola(FechaVbAUsr(dtmIni), FechaVbAUsr(dtmFin))
                    mlngSaldoActual = SumaSaldo

                    mlngSaldoMorosidad = mlngSaldoActual - lngAporteTemp
                    '-------------------------------------------------------------
                Case 6
                    'Si está seteado el flag se realiza esta consulta
                    If mblnConsultarSaldoMorosidad Then

                        'Se consulta por los aportes de dos años pendientes
                        dtmIniTemp = DateSerial(mintAgno - 2, 1, 1)
                        dtmFinTemp = DateSerial(mintAgno - 2, 12, 31)

                        marrCuenta = Cartola(FechaVbAUsr(dtmIniTemp), FechaVbAUsr(dtmFinTemp))
                        mlngSaldoActual = SumaSaldo

                        lngAporteTemp = mlngAportePorCobrar

                    End If

                    'CARTOLA REAL-------------------------------------------------
                    'Acá se consulta por los saldos del periodo correspondiente
                    marrCuenta = Cartola(FechaVbAUsr(dtmIni), FechaVbAUsr(dtmFin))
                    mlngSaldoActual = SumaSaldo

                    mlngSaldoMorosidad = mlngSaldoActual - lngAporteTemp
                    '-------------------------------------------------------------
            End Select

            mlngGastosCursosCompletos = mobjSql.s_gastos_cursos_completos(lngRutCliente, intCodigoCuenta, mintAgno)
            mlngGastosCursosParciales = mobjSql.s_gastos_cursos_parciales(lngRutCliente, intCodigoCuenta, mintAgno)
            mlngGastosCursosComplementarios = mobjSql.s_gastos_cursos_complementarios(lngRutCliente, intCodigoCuenta, mintAgno)



        Catch ex As Exception
            EnviaError("CCuenta:Inicializar-->" & ex.Message)
        End Try
    End Sub



    'Entrega Cartola para un cliente y una cuenta  especifica
    'entre fechas determinadas de inicio y termino
    Public Function Cartola(ByVal dtmFechaIni As String, _
                            ByVal dtmFechaTer As String) As DataTable
        Try
            'arreglo con las cuentas
            Dim dtCuentas As New DataTable
            dtCuentas.Columns.Add("NumTransaccion")
            dtCuentas.Columns.Add("CodTipoTran")
            dtCuentas.Columns.Add("DescripcionTipoTran")
            dtCuentas.Columns.Add("CodEstadoTran")
            dtCuentas.Columns.Add("NombreEstadoTran")
            dtCuentas.Columns.Add("FechaHora")
            dtCuentas.Columns.Add("Abono")
            dtCuentas.Columns.Add("Cargo")
            dtCuentas.Columns.Add("Saldo")
            dtCuentas.Columns.Add("CodCurso")
            dtCuentas.Columns.Add("CodAporte")
            Dim drCuentas As DataRow

            'transformar las fechas al formato usuario
            Dim dtInicioAgno As Date

            mdtmFechaIni = FechaUsrAVb(dtmFechaIni)
            mdtmFechaFin = FechaUsrAVb(dtmFechaTer)

            'primer día del año
            dtInicioAgno = DateSerial(Year(mdtmFechaIni), 1, 1)

            'a la fecha de termino se le suma un dia para realizar el select correctamente ya que en la base de datos las fechas estan con hora:minutos:segundos
            mdtmFechaFin = DateAdd("d", 1, mdtmFechaFin)
            'mdtmFechaFin = mdtmFechaFin & " 23:59:59.000"

            'entrega las cuentas entre un rango de fechas
            Dim dtDatos As New DataTable
            dtDatos = mobjSql.s_busqueda_cuentas(mlngRut, mintCodCuenta, _
                                                  dtInicioAgno, mdtmFechaFin, _
                                                  mstrListaRutsHolding)
            Dim intFilas As Integer, i, j As Integer
            Dim lngSaldo, lngSaldoXMandato As Long
            Dim lngMonto As Long, lngAbono As Long, lngCargo, lngAbonoXMandato As Long
            Dim lngAportes As Long ' Suma solo de los aportes ... esto ya no -> y los excedentes positivos (sin considerar los excedentes negativos por asignacion de excedentes)
            Dim lngCargoCursos As Long  ' Suma solo los cargos por cursos (no considera los excedentes)
            Dim intTipoTran As Integer
            Dim dtmFechaTran As Date
            Dim blnFechaAnterior As Boolean  'indica si la fecha es anterior a la consultada
            Dim intIdxBase As Integer  'primer registro consultado
            Dim intEstadoTrans As Integer 'estado de la transacción
            Dim lngAportesPendiente As Long
            Dim lngAporteTotal As Long

            intFilas = mobjSql.Registros
            mlngSaldoAnterior = 0
            lngSaldo = 0
            mlngSumaAbono = 0
            mlngSumaCargo = 0
            mlngSumaAportes = 0
            blnFechaAnterior = True
            lngAportes = 0
            lngCargoCursos = 0
            intEstadoTrans = 0
            lngAportesPendiente = 0
            mlngSumaVyT = 0
            mlngSaldoActual = 0
            lngAporteTotal = 0

            'asignar el resultado de la consulta al arreglo con campos
            If intFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dtDatos.Rows
                    ' según el tipo de la transaccion, asignar abono o cargo
                    '
                    lngMonto = dr.Item(6)
                    intTipoTran = dr.Item(1)
                    intEstadoTrans = dr.Item(3)

                    lngAbono = 0
                    lngCargo = 0

                    'revisar si la transaccion es abono o cargo
                    If intTipoTran = 2 Then 'cargo por curso
                        lngCargo = lngMonto
                        lngCargoCursos = (lngCargoCursos + lngMonto)
                    ElseIf intTipoTran = 5 Then
                        lngCargo = lngMonto


                        lngCargoCursos = (lngCargoCursos + lngMonto)
                        mlngSumaVyT = (mlngSumaVyT + lngMonto)
                    ElseIf (intTipoTran = 1) Then   '1: aportes
                        lngAbono = lngMonto
                        lngAportes = (lngAportes + lngMonto)
                        lngAporteTotal = (lngAportes + lngMonto)
                        'Los aportes pendientes - por cobrar del periodo (cheques y docs. a fecha)
                        'Se deben restar al total de aportes, para obtener el Saldo Real de la Cuenta
                        If intEstadoTrans = 1 Then
                            lngAportesPendiente = (lngAportesPendiente + lngMonto)
                        End If
                    ElseIf intTipoTran = 4 Then     'traspaso de fondos
                        If mintCodCuenta = 6 Then
                            lngAbonoXMandato = lngMonto
                        ElseIf mintCodCuenta = 1 And lngMonto < 0 Then
                            'lngAbono = -(lngMonto)
                            'If lngMonto > 0 Then
                            'lngAbono = lngMonto
                            'Else
                            'lngCargo = -lngMonto
                            'End If
                            lngAportes = (lngAportes + lngAbono)
                        Else

                            'If lngMonto > 0 Then
                            lngAbono = lngMonto
                            'Else
                            'lngCargo = -lngMonto
                            'End If
                            lngAportes = (lngAportes + lngMonto)
                        End If

                    Else  'otros tipos de transacción movimientos, intTipoTran = 3 ó 4
                        If lngMonto > 0 Then
                            lngAbono = lngMonto
                            If mintCodCuenta = 4 Or mintCodCuenta = 5 Then 'Pregunto si son excedentes ya que la administracion puede tener asignacion de excedentes y no debe ser considerada en la cartola resumen, y en los excedentes si
                                lngAportes = (lngAportes + lngMonto)
                            End If
                        Else
                            lngCargo = -lngMonto
                        End If
                    End If

                    If mintCodCuenta = 6 And intTipoTran = 4 Then
                        lngSaldoXMandato = (lngSaldoXMandato + lngAbonoXMandato)
                        'lngSaldo = (lngSaldo - lngCargo)
                    Else
                        'calcular totales
                        lngSaldo = (lngSaldo + lngAbono)
                        lngSaldo = (lngSaldo - lngCargo)
                    End If
                    ''calcular totales
                    'lngSaldo = lngSaldo + lngAbono - lngCargo
                    ''lngSaldo = (lngSaldo + lngAbono)
                    ''lngSaldo = (lngSaldo - lngCargo)
                    '**************************************************
                    'si la transaccion es anterior al período consultado,
                    'sumarla al saldo anterior
                    dtmFechaTran = dr.Item(5)
                    If dtmFechaTran < mdtmFechaIni Then
                        mlngSaldoAnterior = ((mlngSaldoAnterior + lngAbono) - lngCargo)
                    End If

                    'esta condición sólo se cumple con la primera transacción del período
                    If dtmFechaTran >= mdtmFechaIni And blnFechaAnterior Then
                        'intIdxBase = i  'asignar el índice base
                        'ReDim arrCuentas(intFilas - intIdxBase - 1)
                        blnFechaAnterior = False
                    End If


                    'transacciones que se muestran en la consulta
                    '
                    If Not blnFechaAnterior Then
                        drCuentas = dtCuentas.NewRow
                        drCuentas("NumTransaccion") = dr.Item(0)
                        drCuentas("CodTipoTran") = intTipoTran
                        drCuentas("DescripcionTipoTran") = Trim(dr.Item(2)) & ". " & Trim(dr.Item(9))
                        drCuentas("CodEstadoTran") = dr.Item(3)
                        drCuentas("NombreEstadoTran") = dr.Item(4)
                        drCuentas("FechaHora") = FechaVbAUsr(dtmFechaTran)
                        drCuentas("Abono") = lngAbono
                        drCuentas("Cargo") = lngCargo
                        drCuentas("Saldo") = lngSaldo
                        drCuentas("CodCurso") = dr.Item(7)
                        drCuentas("CodAporte") = dr.Item(8)
                        dtCuentas.Rows.Add(drCuentas)

                        'Aporte
                        If intTipoTran = 1 Then
                            drCuentas("CodCurso") = dr.Item(7)
                        End If
                        'Curso
                        If intTipoTran = 2 Then
                            drCuentas("CodAporte") = dr.Item(8)
                        End If

                        If mintCodCuenta = 6 And intTipoTran = 4 Then
                            mlngSumaAbonoXMandato = mlngSumaAbonoXMandato + lngAbonoXMandato
                            'mlngSumaCargo = mlngSumaCargo + lngCargo
                        Else
                            mlngSumaAbono = mlngSumaAbono + lngAbono
                            mlngSumaCargo = mlngSumaCargo + lngCargo
                        End If

                    End If  'registros consultados
                Next
            End If

            'mlngSumaAportes = mobjSql.s_aporte_total(Me.mlngRut, Me.mintAgno)  'lngAportes
            mlngSumaAportes = lngAportes
            mlngSumaCursos = lngCargoCursos
            mlngAportePorCobrar = lngAportesPendiente
            mlngAporteTotal = mobjSql.s_aporte_total(Me.mlngRut, Me.mintAgno, mstrListaRutsHolding)
            mlngSumavtCursosPropiosAgnoAnterior = mobjSql.s_suma_vyt_agno_anterior_consolidado(Me.mlngRut, Me.mintAgno - 1, mstrListaRutsHolding)
            mlngSumaRepartoRecibido = mobjSql.s_suma_reparto_recibido(Me.mlngRut, Me.mintAgno, mstrListaRutsHolding)
            mlngSumaExcRepartoRecibido = mobjSql.s_suma_excedente_reparto_recibido(Me.mlngRut, Me.mintAgno, mstrListaRutsHolding)

            Cartola = dtCuentas
        Catch ex As Exception
            EnviaError("CCuenta:Cartola-->" & ex.Message)
        End Try
    End Function

    'Actualizar Saldo
    Public Sub Actualizar_Saldo()
        Try
            If mlngRut = 0 Or mintCodCuenta = 0 Then
                EnviaError("CCuenta:Actualizar_Saldo - Cuenta no inicializada")
            End If
            'mobjSql.InicioTransaccion()
            'este procedimiento trae la cartola del año y calcula cargos e ingresos
            ' inicializarCsql(mobjSql)
            Inicializar(mlngRut, mintCodCuenta)

            mobjSql.u_SaldoCuentaCliente(mlngRut, mintCodCuenta, mlngSaldoActual)
            'mobjSql.FinTransaccion()
        Catch ex As Exception
            'mobjSql.RollBackTransaccion()
            EnviaError("" & ex.Message)
        End Try
    End Sub

    'inicializacion
    Public Sub New()
        LimpiarVariables()
    End Sub

    Private Sub LimpiarVariables()
        mlngRut = 0
        mintCodCuenta = 0
        mlngSaldoActual = 0
        mlngSumaAbono = 0
        mlngSumaCargo = 0

        mdtmFechaIni = FechaMinSistema()
        mdtmFechaFin = FechaMaxSistema()
        mintAgno = Now.Year()

        mblnConsultarSaldoMorosidad = False
        mlngAportePorCobrar = 0
        mlngSaldoMorosidad = 0
    End Sub

End Class