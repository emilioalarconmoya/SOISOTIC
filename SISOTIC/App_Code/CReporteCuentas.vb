Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Imports System

Public Class CReporteCuentas
    Implements IReporte
    Private objSession As New CSession
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    'rut del usuario
    Private mlngRutUsuario As Long
    'Codigo Cuenta
    Private mlngCodCuenta As Long
    'lista de ruts separados por comas
    Private mstrListaRutsCliente As String
    'fecha inicial y final del período
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date
    'Año del período
    Private mintAgno As Integer
    Private mlngSaldoAnterior As Long
    'Suma Abono
    Private mlngSumaAbono As Long
    'Suma Cargo
    Private mlngSumaCargo As Long
    'Suma Aportes, suma de los aportes... esto ya no -> y los excedentes POSITIVOS (Los negativos son los que se asignan a final de año)
    Private mlngSumaAportes As Long
    'Suma V&T, suma los cargos que corresponden sólo a V&T
    Private mlngSumaVyT As Long
    'Calculo Saldo actual de un cliente tabla cuenta_cliente
    Private mlngSaldoActual As Long
    'Suma Cursos, suma de los cargos que corresponden solo a cursos
    Private mlngSumaCursos As Long
    'Aportes por cobrar
    Private mlngAportePorCobrar As Long
    'listado de filiales
    Private mdtFiliales As DataTable
    'lista de ruts de filiales, separados por coma
    Private mstrListaRutsHolding As String
    'Rut holding
    Private mlngRutHolding As Long
    'información consolidada
    Private mblnInfoConsolidada As Boolean


    'indica si las cartolas se muestran consolidadas
    Public Property InfoConsolidada() As Boolean
        Get
            InfoConsolidada = mblnInfoConsolidada
        End Get
        Set(ByVal value As Boolean)
            mblnInfoConsolidada = value
        End Set
    End Property
    'Rut Holding
    Public ReadOnly Property RutHolding() As String
        Get
            If mlngRutHolding = -1 Then
                Return ""
            Else
                Return RutLngAUsr(mlngRutHolding)
            End If
        End Get
    End Property
    Public ReadOnly Property TieneFiliales() As Boolean
        Get
            If mdtFiliales.Rows.Count > 1 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public Property AportePorCobrar() As Long
        Get
            Return mlngAportePorCobrar
        End Get
        Set(ByVal value As Long)
            mlngAportePorCobrar = value
        End Set
    End Property
    'Suma Cargo
    Public Property SumaCargoCursos() As Long
        Get
            Return mlngSumaCursos
        End Get
        Set(ByVal value As Long)
            mlngSumaCursos = value
        End Set
    End Property
    'Saldo Anterior a la fecha dada como inicio
    Public Property SaldoAnterior() As Long
        Get
            Return mlngSaldoAnterior
        End Get
        Set(ByVal value As Long)
            mlngSaldoAnterior = value
        End Set
    End Property
    'Sumatoria de los Abonos de un Cliente
    Public Property SumaAbono() As Long
        Get
            Return mlngSumaAbono
        End Get
        Set(ByVal value As Long)
            mlngSumaAbono = value
        End Set
    End Property

    'Suma Cargo
    Public Property SumaCargo() As Long
        Get
            Return mlngSumaCargo
        End Get
        Set(ByVal value As Long)
            mlngSumaCargo = value
        End Set
    End Property
    'Sumatoria de los Aportes de un Cliente, considerando solo los aportes y excedentes positivos
    Public Property SumaAporte() As Long
        Get
            Return mlngSumaAportes
        End Get
        Set(ByVal value As Long)
            mlngSumaAportes = value
        End Set
    End Property
    'Suma Cargo por V&T
    Public Property SumaCargoVyT() As Long
        Get
            Return mlngSumaVyT
        End Get
        Set(ByVal value As Long)
            mlngSumaVyT = value
        End Set
    End Property
    'Saldo Actual Cuenta Cliente tabla Cuenta_Cliente
    Public Property SaldoActual() As Long
        Get
            Return mlngSaldoActual
        End Get
        Set(ByVal value As Long)
            mlngSaldoActual = value
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

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
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
    Public Property CodCuenta() As Long
        Get
            Return mlngCodCuenta
        End Get
        Set(ByVal value As Long)
            mlngCodCuenta = value
        End Set
    End Property
    Public Property FechaInicial() As String
        Get
            Return mdtmFechaIni
        End Get
        Set(ByVal value As String)
            mdtmFechaIni = value
        End Set
    End Property
    Public Property FechaFin() As String
        Get
            Return mdtmFechaFin
        End Get
        Set(ByVal value As String)
            mdtmFechaFin = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim dtconsulta As DataTable
            Dim strNombreArchivo As String
            Dim dtInicioAgno As Date
            Dim strRuts As String
            'inicialización de lista de ruts de filiales
            mdtFiliales = New DataTable
            mdtFiliales.Columns.Add("RutFilial")
            mdtFiliales.Columns.Add("Nombre")
            mdtFiliales.Columns.Add("Nivel")
            mdtFiliales.Columns.Add("DigitoVerif")
            Dim dtFiliales As DataTable
            'Dim intFilas As Integer
            'Dim i As Integer
            dtFiliales = mobjSql.s_clientes_asociados(mlngRutUsuario)
            If mobjSql.Registros > 0 Then
                'asignar el resultado de la consulta al arreglo con campos
                Dim dr As DataRow
                Dim drFiliales As DataRow
                For Each dr In dtFiliales.Rows
                    drFiliales = mdtFiliales.NewRow
                    drFiliales("RutFilial") = dr.Item(0)
                    drFiliales("Nombre") = dr.Item(1)
                    drFiliales("Nivel") = dr.Item(3)
                    drFiliales("DigitoVerif") = digito_verificador(dr.Item(0))
                    mdtFiliales.Rows.Add(drFiliales)
                Next
            End If
            'si hay que consolidar y tiene filiales, generar lista de ruts
            mstrListaRutsHolding = ""
            If mblnInfoConsolidada And TieneFiliales Then
                Dim dr As DataRow
                For Each dr In mdtFiliales.Rows
                    'If mstrListaRutsHolding <> "" Then
                    mstrListaRutsHolding = mstrListaRutsHolding & dr("RutFilial") & ","
                    'Else
                    '    mstrListaRutsHolding = mstrListaRutsHolding & dr("RutFilial")
                    'End If
                Next
                mstrListaRutsHolding = Left(mstrListaRutsHolding, mstrListaRutsHolding.Length - 1)
            End If

            If mstrListaRutsHolding = "" Then
                strRuts = CStr(mlngRutUsuario)
            Else
                strRuts = mstrListaRutsHolding
            End If
            mdtmFechaIni = FechaUsrAVb(mdtmFechaIni)
            mdtmFechaFin = FechaUsrAVb(mdtmFechaFin)
            mstrListaRutsCliente = ""
            'primer día del año
            dtInicioAgno = DateSerial(Year(mdtmFechaIni), 1, 1)
            'a la fecha de termino se le suma un dia para realizar el select correctamente ya que en la base de datos las fechas estan con hora:minutos:segundos
            mdtmFechaFin = DateAdd("d", 1, mdtmFechaFin)
            dtconsulta = mobjSql.s_busqueda_cuentas(mlngRutUsuario, mlngCodCuenta, mdtmFechaIni, mdtmFechaFin, strRuts)
            Dim j As Integer
            Dim lngSaldo As Long
            Dim lngMonto As Long, lngAbono As Long, lngCargo As Long
            Dim lngAportes As Long ' Suma solo de los aportes ... esto ya no -> y los excedentes positivos (sin considerar los excedentes negativos por asignacion de excedentes)
            Dim lngCargoCursos As Long  ' Suma solo los cargos por cursos (no considera los excedentes)
            Dim intTipoTran As Integer
            Dim dtmFechaTran As Date
            Dim blnFechaAnterior As Boolean  'indica si la fecha es anterior a la consultada
            Dim intIdxBase As Integer  'primer registro consultado
            Dim intEstadoTrans As Integer 'estado de la transacción
            Dim lngAportesPendiente As Long

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
            Me.mlngFilas = Me.mobjSql.Registros
            If Me.mlngFilas > 0 Then
                'agregando columnas al datatable
                dtconsulta.Columns.Add("NumTransaccion")
                dtconsulta.Columns.Add("CodTipoTran")
                dtconsulta.Columns.Add("DescripcionTipoTran")
                dtconsulta.Columns.Add("CodEstadoTran")
                dtconsulta.Columns.Add("NombreEstadoTran")
                dtconsulta.Columns.Add("FechaHora")
                dtconsulta.Columns.Add("Abono")
                dtconsulta.Columns.Add("Cargo")
                dtconsulta.Columns.Add("Saldo")
                dtconsulta.Columns.Add("CodCurso")
                dtconsulta.Columns.Add("CodAporte")
                Dim dr As DataRow
                For Each dr In dtconsulta.Rows
                    lngMonto = dr("monto")
                    intTipoTran = dr("cod_tipo_tran")
                    intEstadoTrans = dr("cod_estado_tran")
                    lngAbono = 0
                    lngCargo = 0
                    'revisar si la transaccion es abono o cargo
                    If intTipoTran = 2 Then 'cargo por curso
                        lngCargo = lngMonto
                        lngCargoCursos = lngCargoCursos + lngMonto
                    ElseIf intTipoTran = 5 Then
                        lngCargo = lngMonto
                        lngCargoCursos = lngCargoCursos + lngMonto
                        mlngSumaVyT = mlngSumaVyT + lngMonto
                    ElseIf (intTipoTran = 1) Then   '1: aportes
                        lngAbono = lngMonto
                        lngAportes = lngAportes + lngMonto
                        'Los aportes pendientes - por cobrar del periodo (cheques y docs. a fecha)
                        'Se deben restar al total de aportes, para obtener el Saldo Real de la Cuenta
                        If intEstadoTrans = 1 Then
                            lngAportesPendiente = lngAportesPendiente + lngMonto
                        End If
                    ElseIf intTipoTran = 4 Then     'traspaso de fondos
                        If lngMonto > 0 Then
                            lngAbono = lngMonto
                        Else
                            lngCargo = -lngMonto
                        End If
                        lngAportes = lngAportes + lngMonto
                    Else  'otros tipos de transacción movimientos, intTipoTran = 3 ó 4
                        If lngMonto > 0 Then
                            lngAbono = lngMonto
                            If mlngCodCuenta = 4 Or mlngCodCuenta = 5 Then 'Pregunto si son excedentes ya que la administracion puede tener asignacion de excedentes y no debe ser considerada en la cartola resumen, y en los excedentes si
                                lngAportes = lngAportes + lngMonto
                            End If
                        Else
                            lngCargo = -lngMonto
                        End If
                    End If
                    'calcular totales
                    lngSaldo = lngSaldo + lngAbono - lngCargo

                    'si la transaccion es anterior al período consultado,
                    'sumarla al saldo anterior
                    dtmFechaTran = dr("fecha_hora")
                    If dtmFechaTran < mdtmFechaIni Then
                        mlngSaldoAnterior = mlngSaldoAnterior + lngAbono - lngCargo
                    End If

                    If dtmFechaTran >= mdtmFechaIni And blnFechaAnterior Then
                        'intIdxBase = i  'asignar el índice base
                        'dtCuentas(intFilas - intIdxBase - 1))
                        blnFechaAnterior = False
                    End If
                    If Not blnFechaAnterior Then
                        dr("NumTransaccion") = dr("nro_transaccion")
                        dr("CodTipoTran") = intTipoTran
                        dr("DescripcionTipoTran") = Trim(dr("nom_transaccion")) & ". " & Trim(dr("descripcion"))
                        dr("CodEstadoTran") = dr("cod_estado_tran")
                        dr("NombreEstadoTran") = dr("estado_transaccion")
                        dr("FechaHora") = FechaVbAUsr(dtmFechaTran)
                        dr("Abono") = lngAbono
                        dr("Cargo") = lngCargo
                        dr("Saldo") = lngSaldo
                        dr("CodCurso") = dr("cod_curso")
                        dr("CodAporte") = dr("cod_aporte")
                        'Aporte
                        If intTipoTran = 1 Then
                            dr("CodCurso") = dr("cod_curso")
                        End If
                        'Curso
                        If intTipoTran = 2 Then
                            dr("CodAporte") = dr("cod_aporte")
                        End If

                        mlngSumaAbono = mlngSumaAbono + lngAbono
                        mlngSumaCargo = mlngSumaCargo + lngCargo
                        mlngSaldoActual = dr("Saldo")

                    End If
                Next
            End If
            mlngSumaAportes = lngAportes
            mlngSumaCursos = lngCargoCursos
            mlngAportePorCobrar = lngAportesPendiente
            'muestra reporte 
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtconsulta.TableName = "Reporte Cuentas"
                ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If
            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteCuentas:Consultar->" & ex.Message)
        End Try
    End Function

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property
End Class
