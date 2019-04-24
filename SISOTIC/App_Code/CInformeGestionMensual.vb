Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CInformeGestionMensual
#Region "declaraciones"
    'objeto con consultas
    Private mobjSql As CSql

    'rut del usuario conectado
    Private mlngRutUsuario As Long
    'rut de la empresa y flag que indica si es Holding
    Private mlngRutCliente As Long
    Private mblnHolding As Boolean
    Private mintAgno As Integer
    'código de la sucursal seleccionada
    Private mintCodSucursal As Integer ' todos = 0
    'rut del ejecutivo
    Private mlngRutEjecutivo As Long ' todos = 0
    'periodo: 0=todos los meses, 1-12 mes del año
    Private mintPeriodo As Integer
    'factor de división de montos
    Private Const MM = 1000000

    '
    'datos de resultado
    '
    Private mintContPeriodo1 As Integer
    Private mintContPeriodo2 As Integer
    Private mintContPeriodo3 As Integer
    Private mintContPeriodo4 As Integer

    Private mintNroPeriodos As Integer
    'Años consultados
    Private mdtPeriodo As DataTable
    'costos
    Private mdtCostoOticReal As Long
    Private mdtCostoOticExc As Long
    Private mdtCostoAdmin As Long
    Private mdtGastoEmpresa As Long
    'aportes
    Private mdtAportesEnterados As Long
    Private mdtAportesPendientes As Long
    'facturas
    Private mdtFacturasPagadas As Long
    Private mdtFacturasPorPagar As Long
    'cuentas
    Private mdtCtaCap As Long
    Private mdtExcCap As Long
    Private mdtPagoATerceros As Long
    Private mdtPagoDeTerceros As Long

    Private mdtCostoOticReal1 As Long
    Private mdtCostoOticExc1 As Long
    Private mdtCostoAdmin1 As Long
    Private mdtGastoEmpresa1 As Long
    'aportes
    Private mdtAportesEnterados1 As Long
    Private mdtAportesPendientes1 As Long
    'facturas
    Private mdtFacturasPagadas1 As Long
    Private mdtFacturasPorPagar1 As Long
    'cuentas
    Private mdtCtaCap1 As Long
    Private mdtExcCap1 As Long
    Private mdtPagoATerceros1 As Long
    Private mdtPagoDeTerceros1 As Long

    'meses del año
    Private mdtMeses As DataTable
    'totales
    Private mdclTotalCostoOticReal As Long
    Private mdclTotalCostoOticExc As Long
    Private mdclTotalCostoAdmin As Long
    Private mdclTotalAportesEnt As Long
    Private mdclTotalAportesPend As Long
    Private mdclFacturasPagadas As Long
    Private mdclFacturasPorPagar As Long
    Private mdclCtaCap As Long
    Private mdclCtaExcCap As Long
    Private mdclATerceros As Long
    Private mdclDeTerceros As Long

    Private mdtCostoOticReal2 As Long
    Private mdtCostoOticExc2 As Long
    Private mdtCostoAdmin2 As Long
    Private mdtGastoEmpresa2 As Long
    'aportes
    Private mdtAportesEnterados2 As Long
    Private mdtAportesPendientes2 As Long
    'facturas
    Private mdtFacturasPagadas2 As Long
    Private mdtFacturasPorPagar2 As Long
    'cuentas
    Private mdtCtaCap2 As Long
    Private mdtExcCap2 As Long
    Private mdtPagoATerceros2 As Long
    Private mdtPagoDeTerceros2 As Long

    Private mdtCostoOticReal3 As Long
    Private mdtCostoOticExc3 As Long
    Private mdtCostoAdmin3 As Long
    Private mdtGastoEmpresa3 As Long
    'aportes
    Private mdtAportesEnterados3 As Long
    Private mdtAportesPendientes3 As Long
    'facturas
    Private mdtFacturasPagadas3 As Long
    Private mdtFacturasPorPagar3 As Long
    'cuentas
    Private mdtCtaCap3 As Long
    Private mdtExcCap3 As Long
    Private mdtPagoATerceros3 As Long
    Private mdtPagoDeTerceros3 As Long

    Private mdtCostoOticReal4 As Long
    Private mdtCostoOticExc4 As Long
    Private mdtCostoAdmin4 As Long
    Private mdtGastoEmpresa4 As Long
    'aportes
    Private mdtAportesEnterados4 As Long
    Private mdtAportesPendientes4 As Long
    'facturas
    Private mdtFacturasPagadas4 As Long
    Private mdtFacturasPorPagar4 As Long
    'cuentas
    Private mdtCtaCap4 As Long
    Private mdtExcCap4 As Long
    Private mdtPagoATerceros4 As Long
    Private mdtPagoDeTerceros4 As Long

    Private mdtCostoOticReal5 As Long
    Private mdtCostoOticExc5 As Long
    Private mdtCostoAdmin5 As Long
    Private mdtGastoEmpresa5 As Long
    'aportes
    Private mdtAportesEnterados5 As Long
    Private mdtAportesPendientes5 As Long
    'facturas
    Private mdtFacturasPagadas5 As Long
    Private mdtFacturasPorPagar5 As Long
    'cuentas
    Private mdtCtaCap5 As Long
    Private mdtExcCap5 As Long
    Private mdtPagoATerceros5 As Long
    Private mdtPagoDeTerceros5 As Long

    Private mdtCostoOticReal6 As Long
    Private mdtCostoOticExc6 As Long
    Private mdtCostoAdmin6 As Long
    Private mdtGastoEmpresa6 As Long
    'aportes
    Private mdtAportesEnterados6 As Long
    Private mdtAportesPendientes6 As Long
    'facturas
    Private mdtFacturasPagadas6 As Long
    Private mdtFacturasPorPagar6 As Long
    'cuentas
    Private mdtCtaCap6 As Long
    Private mdtExcCap6 As Long
    Private mdtPagoATerceros6 As Long
    Private mdtPagoDeTerceros6 As Long

    Private mdtCostoOticReal7 As Long
    Private mdtCostoOticExc7 As Long
    Private mdtCostoAdmin7 As Long
    Private mdtGastoEmpresa7 As Long
    'aportes
    Private mdtAportesEnterados7 As Long
    Private mdtAportesPendientes7 As Long
    'facturas
    Private mdtFacturasPagadas7 As Long
    Private mdtFacturasPorPagar7 As Long
    'cuentas
    Private mdtCtaCap7 As Long
    Private mdtExcCap7 As Long
    Private mdtPagoATerceros7 As Long
    Private mdtPagoDeTerceros7 As Long

    Private mdtCostoOticReal8 As Long
    Private mdtCostoOticExc8 As Long
    Private mdtCostoAdmin8 As Long
    Private mdtGastoEmpresa8 As Long
    'aportes
    Private mdtAportesEnterados8 As Long
    Private mdtAportesPendientes8 As Long
    'facturas
    Private mdtFacturasPagadas8 As Long
    Private mdtFacturasPorPagar8 As Long
    'cuentas
    Private mdtCtaCap8 As Long
    Private mdtExcCap8 As Long
    Private mdtPagoATerceros8 As Long
    Private mdtPagoDeTerceros8 As Long

    Private mdtCostoOticReal9 As Long
    Private mdtCostoOticExc9 As Long
    Private mdtCostoAdmin9 As Long
    Private mdtGastoEmpresa9 As Long
    'aportes
    Private mdtAportesEnterados9 As Long
    Private mdtAportesPendientes9 As Long
    'facturas
    Private mdtFacturasPagadas9 As Long
    Private mdtFacturasPorPagar9 As Long
    'cuentas
    Private mdtCtaCap9 As Long
    Private mdtExcCap9 As Long
    Private mdtPagoATerceros9 As Long
    Private mdtPagoDeTerceros9 As Long

    Private mdtCostoOticReal10 As Long
    Private mdtCostoOticExc10 As Long
    Private mdtCostoAdmin10 As Long
    Private mdtGastoEmpresa10 As Long
    'aportes
    Private mdtAportesEnterados10 As Long
    Private mdtAportesPendientes10 As Long
    'facturas
    Private mdtFacturasPagadas10 As Long
    Private mdtFacturasPorPagar10 As Long
    'cuentas
    Private mdtCtaCap10 As Long
    Private mdtExcCap10 As Long
    Private mdtPagoATerceros10 As Long
    Private mdtPagoDeTerceros10 As Long

    Private mdtCostoOticReal11 As Long
    Private mdtCostoOticExc11 As Long
    Private mdtCostoAdmin11 As Long
    Private mdtGastoEmpresa11 As Long
    'aportes
    Private mdtAportesEnterados11 As Long
    Private mdtAportesPendientes11 As Long
    'facturas
    Private mdtFacturasPagadas11 As Long
    Private mdtFacturasPorPagar11 As Long
    'cuentas
    Private mdtCtaCap11 As Long
    Private mdtExcCap11 As Long
    Private mdtPagoATerceros11 As Long
    Private mdtPagoDeTerceros11 As Long

    Private mdtCostoOticReal12 As Long
    Private mdtCostoOticExc12 As Long
    Private mdtCostoAdmin12 As Long
    Private mdtGastoEmpresa12 As Long
    'aportes
    Private mdtAportesEnterados12 As Long
    Private mdtAportesPendientes12 As Long
    'facturas
    Private mdtFacturasPagadas12 As Long
    Private mdtFacturasPorPagar12 As Long
    'cuentas
    Private mdtCtaCap12 As Long
    Private mdtExcCap12 As Long
    Private mdtPagoATerceros12 As Long
    Private mdtPagoDeTerceros12 As Long


    'meses del año
    Private mdtMeses2 As DataTable
    'totales
    Private mdclTotalCostoOticReal2 As Long
    Private mdclTotalCostoOticExc2 As Long
    Private mdclTotalCostoAdmin2 As Long
    Private mdclTotalAportesEnt2 As Long
    Private mdclTotalAportesPend2 As Long
    Private mdclFacturasPagadas2 As Long
    Private mdclFacturasPorPagar2 As Long
    Private mdclCtaCap2 As Long
    Private mdclCtaExcCap2 As Long
    Private mdclATerceros2 As Long
    Private mdclDeTerceros2 As Long
#End Region

#Region "propiedades"
    'Public ReadOnly Property RutUsuario() As Long
    '    Get
    '        Return mlngRutUsuario
    '    End Get
    'End Property
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
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
    Public Property Holding() As Boolean
        Get
            Return mblnHolding
        End Get
        Set(ByVal value As Boolean)
            mblnHolding = value
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
    Public Property CodSucursal() As Integer
        Get
            Return mintCodSucursal
        End Get
        Set(ByVal value As Integer)
            mintCodSucursal = value
        End Set
    End Property
    Public Property RutEjecutivo() As Long
        Get
            Return mlngRutEjecutivo
        End Get
        Set(ByVal value As Long)
            mlngRutEjecutivo = value
        End Set
    End Property
    Public Property PeriodoInt() As Integer
        Get
            Return mintPeriodo
        End Get
        Set(ByVal value As Integer)
            mintPeriodo = value
        End Set
    End Property
    Public Property NroPeriodos() As Integer
        Get
            Return mintNroPeriodos
        End Get
        Set(ByVal value As Integer)
            mintNroPeriodos = value
        End Set
    End Property

    Public Property ContPeriodo1() As Integer
        Get
            Return mintContPeriodo1
        End Get
        Set(ByVal value As Integer)
            mintContPeriodo1 = value
        End Set
    End Property
    Public Property ContPeriodo2() As Integer
        Get
            Return mintContPeriodo2
        End Get
        Set(ByVal value As Integer)
            mintContPeriodo2 = value
        End Set
    End Property
    Public Property ContPeriodo3() As Integer
        Get
            Return mintContPeriodo3
        End Get
        Set(ByVal value As Integer)
            mintContPeriodo3 = value
        End Set
    End Property
    Public Property ContPeriodo4() As Integer
        Get
            Return mintContPeriodo4
        End Get
        Set(ByVal value As Integer)
            mintContPeriodo4 = value
        End Set
    End Property
    Public Property PeriodoData() As DataTable
        Get
            Return mdtPeriodo
        End Get
        Set(ByVal value As DataTable)
            mdtPeriodo = value
        End Set
    End Property
    Public Property CostoOticReal() As Long
        Get
            Return mdtCostoOticReal
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal = value
        End Set
    End Property
    Public Property CostoOticExc() As Long
        Get
            Return mdtCostoOticExc
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc = value
        End Set
    End Property
    Public Property CostoAdmin() As Long
        Get
            Return mdtCostoAdmin
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin = value
        End Set
    End Property
    Public Property AportesEnterados() As Long
        Get
            Return mdtAportesEnterados
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados = value
        End Set
    End Property
    Public Property AportesPendientes() As Long
        Get
            Return mdtAportesPendientes
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes = value
        End Set
    End Property
    Public Property FacturasPagadasData() As Long
        Get
            Return mdtFacturasPagadas
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas = value
        End Set
    End Property
    Public Property FacturasPorPagarData() As Long
        Get
            Return mdtFacturasPorPagar
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar = value
        End Set
    End Property
    Public Property CtaCapData() As Long
        Get
            Return mdtCtaCap
        End Get
        Set(ByVal value As Long)
            mdtCtaCap = value
        End Set
    End Property
    Public Property ExcCap() As Long
        Get
            Return mdtExcCap
        End Get
        Set(ByVal value As Long)
            mdtExcCap = value
        End Set
    End Property
    Public Property PagoATerceros() As Long
        Get
            Return mdtPagoATerceros
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros = value
        End Set
    End Property
    Public Property PagoDeTerceros() As Long
        Get
            Return mdtPagoDeTerceros
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros = value
        End Set
    End Property
    Public Property Meses() As DataTable
        Get
            Return mdtMeses
        End Get
        Set(ByVal value As DataTable)
            mdtMeses = value
        End Set
    End Property
    Public Property TotalCostoOticReal() As Long
        Get
            Return mdclTotalCostoOticReal
        End Get
        Set(ByVal value As Long)
            mdclTotalCostoOticReal = value
        End Set
    End Property
    Public Property TotalCostoOticExc() As Long
        Get
            Return mdclTotalCostoOticExc
        End Get
        Set(ByVal value As Long)
            mdclTotalCostoOticExc = value
        End Set
    End Property
    Public Property TotalCostoAdmin() As Long
        Get
            Return mdclTotalCostoAdmin
        End Get
        Set(ByVal value As Long)
            mdclTotalCostoAdmin = value
        End Set
    End Property
    Public Property TotalAportesEnt() As Long
        Get
            Return mdclTotalAportesEnt
        End Get
        Set(ByVal value As Long)
            mdclTotalAportesEnt = value
        End Set
    End Property
    Public Property TotalAportesPend() As Long
        Get
            Return mdclTotalAportesPend
        End Get
        Set(ByVal value As Long)
            mdclTotalAportesPend = value
        End Set
    End Property
    Public Property FacturasPagadas() As Long
        Get
            Return mdclFacturasPagadas
        End Get
        Set(ByVal value As Long)
            mdclFacturasPagadas = value
        End Set
    End Property
    Public Property FacturasPorPagar() As Long
        Get
            Return mdclFacturasPorPagar
        End Get
        Set(ByVal value As Long)
            mdclFacturasPorPagar = value
        End Set
    End Property
    Public Property CtaCap() As Long
        Get
            Return mdclCtaCap
        End Get
        Set(ByVal value As Long)
            mdclCtaCap = value
        End Set
    End Property
    Public Property CtaExcCap() As Long
        Get
            Return mdclCtaExcCap
        End Get
        Set(ByVal value As Long)
            mdclCtaExcCap = value
        End Set
    End Property
    Public Property ATerceros() As Long
        Get
            Return mdclATerceros
        End Get
        Set(ByVal value As Long)
            mdclATerceros = value
        End Set
    End Property
    Public Property DeTerceros() As Long
        Get
            Return mdclDeTerceros
        End Get
        Set(ByVal value As Long)
            mdclDeTerceros = value
        End Set
    End Property
    Public Property ListaCostoOticMasAdm() As Long
        Get
            ListaCostoOticMasAdm = mdtCostoOticReal + mdtCostoAdmin
        End Get
        Set(ByVal value As Long)

        End Set
    End Property
    Public Property CostoOticReal1() As Long
        Get
            Return mdtCostoOticReal1
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal1 = value
        End Set
    End Property
    Public Property CostoOticExc1() As Long
        Get
            Return mdtCostoOticExc1
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc1 = value
        End Set
    End Property
    Public Property CostoAdmin1() As Long
        Get
            Return mdtCostoAdmin1
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin1 = value
        End Set
    End Property
    Public Property AportesEnterados1() As Long
        Get
            Return mdtAportesEnterados1
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados1 = value
        End Set
    End Property
    Public Property AportesPendientes1() As Long
        Get
            Return mdtAportesPendientes1
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes1 = value
        End Set
    End Property
    Public Property FacturasPagadasData1() As Long
        Get
            Return mdtFacturasPagadas1
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas1 = value
        End Set
    End Property
    Public Property FacturasPorPagarData1() As Long
        Get
            Return mdtFacturasPorPagar1
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar1 = value
        End Set
    End Property
    Public Property CtaCapData1() As Long
        Get
            Return mdtCtaCap1
        End Get
        Set(ByVal value As Long)
            mdtCtaCap1 = value
        End Set
    End Property
    Public Property ExcCap1() As Long
        Get
            Return mdtExcCap1
        End Get
        Set(ByVal value As Long)
            mdtExcCap1 = value
        End Set
    End Property
    Public Property PagoATerceros1() As Long
        Get
            Return mdtPagoATerceros1
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros1 = value
        End Set
    End Property
    Public Property PagoDeTerceros1() As Long
        Get
            Return mdtPagoDeTerceros1
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros1 = value
        End Set
    End Property


    Public Property CostoOticReal2() As Long
        Get
            Return mdtCostoOticReal2
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal2 = value
        End Set
    End Property
    Public Property CostoOticExc2() As Long
        Get
            Return mdtCostoOticExc2
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc2 = value
        End Set
    End Property
    Public Property CostoAdmin2() As Long
        Get
            Return mdtCostoAdmin2
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin2 = value
        End Set
    End Property
    Public Property AportesEnterados2() As Long
        Get
            Return mdtAportesEnterados2
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados2 = value
        End Set
    End Property
    Public Property AportesPendientes2() As Long
        Get
            Return mdtAportesPendientes2
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes2 = value
        End Set
    End Property
    Public Property FacturasPagadasData2() As Long
        Get
            Return mdtFacturasPagadas2
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas2 = value
        End Set
    End Property
    Public Property FacturasPorPagarData2() As Long
        Get
            Return mdtFacturasPorPagar2
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar2 = value
        End Set
    End Property
    Public Property CtaCapData2() As Long
        Get
            Return mdtCtaCap2
        End Get
        Set(ByVal value As Long)
            mdtCtaCap2 = value
        End Set
    End Property
    Public Property ExcCap2() As Long
        Get
            Return mdtExcCap2
        End Get
        Set(ByVal value As Long)
            mdtExcCap2 = value
        End Set
    End Property
    Public Property PagoATerceros2() As Long
        Get
            Return mdtPagoATerceros2
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros2 = value
        End Set
    End Property
    Public Property PagoDeTerceros2() As Long
        Get
            Return mdtPagoDeTerceros2
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros2 = value
        End Set
    End Property
    Public Property Meses2() As DataTable
        Get
            Return mdtMeses2
        End Get
        Set(ByVal value As DataTable)
            mdtMeses2 = value
        End Set
    End Property
    Public Property TotalCostoOticReal2() As Long
        Get
            Return mdclTotalCostoOticReal2
        End Get
        Set(ByVal value As Long)
            mdclTotalCostoOticReal2 = value
        End Set
    End Property
    Public Property TotalCostoOticExc2() As Long
        Get
            Return mdclTotalCostoOticExc2
        End Get
        Set(ByVal value As Long)
            mdclTotalCostoOticExc2 = value
        End Set
    End Property
    Public Property TotalCostoAdmin2() As Long
        Get
            Return mdclTotalCostoAdmin
        End Get
        Set(ByVal value As Long)
            mdclTotalCostoAdmin2 = value
        End Set
    End Property
    Public Property TotalAportesEnt2() As Long
        Get
            Return mdclTotalAportesEnt
        End Get
        Set(ByVal value As Long)
            mdclTotalAportesEnt2 = value
        End Set
    End Property
    Public Property TotalAportesPend2() As Long
        Get
            Return mdclTotalAportesPend2
        End Get
        Set(ByVal value As Long)
            mdclTotalAportesPend2 = value
        End Set
    End Property
    Public Property FacturasPagadas2() As Long
        Get
            Return mdclFacturasPagadas
        End Get
        Set(ByVal value As Long)
            mdclFacturasPagadas2 = value
        End Set
    End Property
    Public Property FacturasPorPagar2() As Long
        Get
            Return mdclFacturasPorPagar2
        End Get
        Set(ByVal value As Long)
            mdclFacturasPorPagar2 = value
        End Set
    End Property
    Public Property CtaCap2() As Long
        Get
            Return mdclCtaCap2
        End Get
        Set(ByVal value As Long)
            mdclCtaCap2 = value
        End Set
    End Property
    Public Property CtaExcCap2() As Long
        Get
            Return mdclCtaExcCap2
        End Get
        Set(ByVal value As Long)
            mdclCtaExcCap2 = value
        End Set
    End Property
    Public Property ATerceros2() As Long
        Get
            Return mdclATerceros2
        End Get
        Set(ByVal value As Long)
            mdclATerceros2 = value
        End Set
    End Property
    Public Property DeTerceros2() As Long
        Get
            Return mdclDeTerceros2
        End Get
        Set(ByVal value As Long)
            mdclDeTerceros2 = value
        End Set
    End Property
    Public Property CostoOticReal3() As Long
        Get
            Return mdtCostoOticReal3
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal3 = value
        End Set
    End Property
    Public Property CostoOticExc3() As Long
        Get
            Return mdtCostoOticExc3
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc3 = value
        End Set
    End Property
    Public Property CostoAdmin3() As Long
        Get
            Return mdtCostoAdmin3
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin3 = value
        End Set
    End Property
    Public Property AportesEnterados3() As Long
        Get
            Return mdtAportesEnterados3
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados3 = value
        End Set
    End Property
    Public Property AportesPendientes3() As Long
        Get
            Return mdtAportesPendientes3
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes3 = value
        End Set
    End Property
    Public Property FacturasPagadasData3() As Long
        Get
            Return mdtFacturasPagadas3
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas3 = value
        End Set
    End Property
    Public Property FacturasPorPagarData3() As Long
        Get
            Return mdtFacturasPorPagar3
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar3 = value
        End Set
    End Property
    Public Property CtaCapData3() As Long
        Get
            Return mdtCtaCap3
        End Get
        Set(ByVal value As Long)
            mdtCtaCap3 = value
        End Set
    End Property
    Public Property ExcCap3() As Long
        Get
            Return mdtExcCap3
        End Get
        Set(ByVal value As Long)
            mdtExcCap3 = value
        End Set
    End Property
    Public Property PagoATerceros3() As Long
        Get
            Return mdtPagoATerceros3
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros3 = value
        End Set
    End Property
    Public Property PagoDeTerceros3() As Long
        Get
            Return mdtPagoDeTerceros3
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros3 = value
        End Set
    End Property

    Public Property CostoOticReal4() As Long
        Get
            Return mdtCostoOticReal4
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal4 = value
        End Set
    End Property
    Public Property CostoOticExc4() As Long
        Get
            Return mdtCostoOticExc4
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc4 = value
        End Set
    End Property
    Public Property CostoAdmin4() As Long
        Get
            Return mdtCostoAdmin4
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin4 = value
        End Set
    End Property
    Public Property AportesEnterados4() As Long
        Get
            Return mdtAportesEnterados4
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados4 = value
        End Set
    End Property
    Public Property AportesPendientes4() As Long
        Get
            Return mdtAportesPendientes4
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes4 = value
        End Set
    End Property
    Public Property FacturasPagadasData4() As Long
        Get
            Return mdtFacturasPagadas4
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas4 = value
        End Set
    End Property
    Public Property FacturasPorPagarData4() As Long
        Get
            Return mdtFacturasPorPagar4
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar4 = value
        End Set
    End Property
    Public Property CtaCapData4() As Long
        Get
            Return mdtCtaCap4
        End Get
        Set(ByVal value As Long)
            mdtCtaCap4 = value
        End Set
    End Property
    Public Property ExcCap4() As Long
        Get
            Return mdtExcCap4
        End Get
        Set(ByVal value As Long)
            mdtExcCap4 = value
        End Set
    End Property
    Public Property PagoATerceros4() As Long
        Get
            Return mdtPagoATerceros4
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros4 = value
        End Set
    End Property
    Public Property PagoDeTerceros4() As Long
        Get
            Return mdtPagoDeTerceros4
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros4 = value
        End Set
    End Property


    Public Property CostoOticReal5() As Long
        Get
            Return mdtCostoOticReal5
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal5 = value
        End Set
    End Property
    Public Property CostoOticExc5() As Long
        Get
            Return mdtCostoOticExc5
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc5 = value
        End Set
    End Property
    Public Property CostoAdmin5() As Long
        Get
            Return mdtCostoAdmin5
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin5 = value
        End Set
    End Property
    Public Property AportesEnterados5() As Long
        Get
            Return mdtAportesEnterados5
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados5 = value
        End Set
    End Property
    Public Property AportesPendientes5() As Long
        Get
            Return mdtAportesPendientes5
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes5 = value
        End Set
    End Property
    Public Property FacturasPagadasData5() As Long
        Get
            Return mdtFacturasPagadas5
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas5 = value
        End Set
    End Property
    Public Property FacturasPorPagarData5() As Long
        Get
            Return mdtFacturasPorPagar5
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar5 = value
        End Set
    End Property
    Public Property CtaCapData5() As Long
        Get
            Return mdtCtaCap5
        End Get
        Set(ByVal value As Long)
            mdtCtaCap5 = value
        End Set
    End Property
    Public Property ExcCap5() As Long
        Get
            Return mdtExcCap5
        End Get
        Set(ByVal value As Long)
            mdtExcCap5 = value
        End Set
    End Property
    Public Property PagoATerceros5() As Long
        Get
            Return mdtPagoATerceros5
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros5 = value
        End Set
    End Property
    Public Property PagoDeTerceros5() As Long
        Get
            Return mdtPagoDeTerceros5
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros5 = value
        End Set
    End Property

    Public Property CostoOticReal6() As Long
        Get
            Return mdtCostoOticReal6
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal6 = value
        End Set
    End Property
    Public Property CostoOticExc6() As Long
        Get
            Return mdtCostoOticExc6
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc6 = value
        End Set
    End Property
    Public Property CostoAdmin6() As Long
        Get
            Return mdtCostoAdmin6
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin6 = value
        End Set
    End Property
    Public Property AportesEnterados6() As Long
        Get
            Return mdtAportesEnterados6
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados6 = value
        End Set
    End Property
    Public Property AportesPendientes6() As Long
        Get
            Return mdtAportesPendientes6
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes6 = value
        End Set
    End Property
    Public Property FacturasPagadasData6() As Long
        Get
            Return mdtFacturasPagadas6
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas6 = value
        End Set
    End Property
    Public Property FacturasPorPagarData6() As Long
        Get
            Return mdtFacturasPorPagar6
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar6 = value
        End Set
    End Property
    Public Property CtaCapData6() As Long
        Get
            Return mdtCtaCap6
        End Get
        Set(ByVal value As Long)
            mdtCtaCap6 = value
        End Set
    End Property
    Public Property ExcCap6() As Long
        Get
            Return mdtExcCap6
        End Get
        Set(ByVal value As Long)
            mdtExcCap6 = value
        End Set
    End Property
    Public Property PagoATerceros6() As Long
        Get
            Return mdtPagoATerceros6
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros6 = value
        End Set
    End Property
    Public Property PagoDeTerceros6() As Long
        Get
            Return mdtPagoDeTerceros6
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros6 = value
        End Set
    End Property

    Public Property CostoOticReal7() As Long
        Get
            Return mdtCostoOticReal7
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal7 = value
        End Set
    End Property
    Public Property CostoOticExc7() As Long
        Get
            Return mdtCostoOticExc7
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc7 = value
        End Set
    End Property
    Public Property CostoAdmin7() As Long
        Get
            Return mdtCostoAdmin7
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin7 = value
        End Set
    End Property
    Public Property AportesEnterados7() As Long
        Get
            Return mdtAportesEnterados7
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados7 = value
        End Set
    End Property
    Public Property AportesPendientes7() As Long
        Get
            Return mdtAportesPendientes7
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes7 = value
        End Set
    End Property
    Public Property FacturasPagadasData7() As Long
        Get
            Return mdtFacturasPagadas7
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas7 = value
        End Set
    End Property
    Public Property FacturasPorPagarData7() As Long
        Get
            Return mdtFacturasPorPagar7
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar7 = value
        End Set
    End Property
    Public Property CtaCapData7() As Long
        Get
            Return mdtCtaCap7
        End Get
        Set(ByVal value As Long)
            mdtCtaCap7 = value
        End Set
    End Property
    Public Property ExcCap7() As Long
        Get
            Return mdtExcCap7
        End Get
        Set(ByVal value As Long)
            mdtExcCap7 = value
        End Set
    End Property
    Public Property PagoATerceros7() As Long
        Get
            Return mdtPagoATerceros7
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros7 = value
        End Set
    End Property
    Public Property PagoDeTerceros7() As Long
        Get
            Return mdtPagoDeTerceros7
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros7 = value
        End Set
    End Property

    Public Property CostoOticReal8() As Long
        Get
            Return mdtCostoOticReal8
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal8 = value
        End Set
    End Property
    Public Property CostoOticExc8() As Long
        Get
            Return mdtCostoOticExc8
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc8 = value
        End Set
    End Property
    Public Property CostoAdmin8() As Long
        Get
            Return mdtCostoAdmin8
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin8 = value
        End Set
    End Property
    Public Property AportesEnterados8() As Long
        Get
            Return mdtAportesEnterados8
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados8 = value
        End Set
    End Property
    Public Property AportesPendientes8() As Long
        Get
            Return mdtAportesPendientes8
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes8 = value
        End Set
    End Property
    Public Property FacturasPagadasData8() As Long
        Get
            Return mdtFacturasPagadas8
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas8 = value
        End Set
    End Property
    Public Property FacturasPorPagarData8() As Long
        Get
            Return mdtFacturasPorPagar8
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar8 = value
        End Set
    End Property
    Public Property CtaCapData8() As Long
        Get
            Return mdtCtaCap8
        End Get
        Set(ByVal value As Long)
            mdtCtaCap8 = value
        End Set
    End Property
    Public Property ExcCap8() As Long
        Get
            Return mdtExcCap8
        End Get
        Set(ByVal value As Long)
            mdtExcCap8 = value
        End Set
    End Property
    Public Property PagoATerceros8() As Long
        Get
            Return mdtPagoATerceros8
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros8 = value
        End Set
    End Property
    Public Property PagoDeTerceros8() As Long
        Get
            Return mdtPagoDeTerceros8
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros8 = value
        End Set
    End Property

    Public Property CostoOticReal9() As Long
        Get
            Return mdtCostoOticReal9
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal9 = value
        End Set
    End Property
    Public Property CostoOticExc9() As Long
        Get
            Return mdtCostoOticExc9
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc9 = value
        End Set
    End Property
    Public Property CostoAdmin9() As Long
        Get
            Return mdtCostoAdmin9
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin9 = value
        End Set
    End Property
    Public Property AportesEnterados9() As Long
        Get
            Return mdtAportesEnterados9
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados9 = value
        End Set
    End Property
    Public Property AportesPendientes9() As Long
        Get
            Return mdtAportesPendientes9
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes9 = value
        End Set
    End Property
    Public Property FacturasPagadasData9() As Long
        Get
            Return mdtFacturasPagadas9
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas9 = value
        End Set
    End Property
    Public Property FacturasPorPagarData9() As Long
        Get
            Return mdtFacturasPorPagar9
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar9 = value
        End Set
    End Property
    Public Property CtaCapData9() As Long
        Get
            Return mdtCtaCap9
        End Get
        Set(ByVal value As Long)
            mdtCtaCap9 = value
        End Set
    End Property
    Public Property ExcCap9() As Long
        Get
            Return mdtExcCap9
        End Get
        Set(ByVal value As Long)
            mdtExcCap9 = value
        End Set
    End Property
    Public Property PagoATerceros9() As Long
        Get
            Return mdtPagoATerceros9
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros9 = value
        End Set
    End Property
    Public Property PagoDeTerceros9() As Long
        Get
            Return mdtPagoDeTerceros9
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros9 = value
        End Set
    End Property

    Public Property CostoOticReal10() As Long
        Get
            Return mdtCostoOticReal10
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal10 = value
        End Set
    End Property
    Public Property CostoOticExc10() As Long
        Get
            Return mdtCostoOticExc10
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc10 = value
        End Set
    End Property
    Public Property CostoAdmin10() As Long
        Get
            Return mdtCostoAdmin10
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin10 = value
        End Set
    End Property
    Public Property AportesEnterados10() As Long
        Get
            Return mdtAportesEnterados10
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados10 = value
        End Set
    End Property
    Public Property AportesPendientes10() As Long
        Get
            Return mdtAportesPendientes10
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes10 = value
        End Set
    End Property
    Public Property FacturasPagadasData10() As Long
        Get
            Return mdtFacturasPagadas10
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas10 = value
        End Set
    End Property
    Public Property FacturasPorPagarData10() As Long
        Get
            Return mdtFacturasPorPagar10
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar10 = value
        End Set
    End Property
    Public Property CtaCapData10() As Long
        Get
            Return mdtCtaCap10
        End Get
        Set(ByVal value As Long)
            mdtCtaCap10 = value
        End Set
    End Property
    Public Property ExcCap10() As Long
        Get
            Return mdtExcCap10
        End Get
        Set(ByVal value As Long)
            mdtExcCap10 = value
        End Set
    End Property
    Public Property PagoATerceros10() As Long
        Get
            Return mdtPagoATerceros10
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros10 = value
        End Set
    End Property
    Public Property PagoDeTerceros10() As Long
        Get
            Return mdtPagoDeTerceros10
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros10 = value
        End Set
    End Property

    Public Property CostoOticReal11() As Long
        Get
            Return mdtCostoOticReal11
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal11 = value
        End Set
    End Property
    Public Property CostoOticExc11() As Long
        Get
            Return mdtCostoOticExc11
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc11 = value
        End Set
    End Property
    Public Property CostoAdmin11() As Long
        Get
            Return mdtCostoAdmin11
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin11 = value
        End Set
    End Property
    Public Property AportesEnterados11() As Long
        Get
            Return mdtAportesEnterados11
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados11 = value
        End Set
    End Property
    Public Property AportesPendientes11() As Long
        Get
            Return mdtAportesPendientes11
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes11 = value
        End Set
    End Property
    Public Property FacturasPagadasData11() As Long
        Get
            Return mdtFacturasPagadas11
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas11 = value
        End Set
    End Property
    Public Property FacturasPorPagarData11() As Long
        Get
            Return mdtFacturasPorPagar11
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar11 = value
        End Set
    End Property
    Public Property CtaCapData11() As Long
        Get
            Return mdtCtaCap11
        End Get
        Set(ByVal value As Long)
            mdtCtaCap11 = value
        End Set
    End Property
    Public Property ExcCap11() As Long
        Get
            Return mdtExcCap11
        End Get
        Set(ByVal value As Long)
            mdtExcCap11 = value
        End Set
    End Property
    Public Property PagoATerceros11() As Long
        Get
            Return mdtPagoATerceros11
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros11 = value
        End Set
    End Property
    Public Property PagoDeTerceros11() As Long
        Get
            Return mdtPagoDeTerceros11
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros11 = value
        End Set
    End Property

    Public Property CostoOticReal12() As Long
        Get
            Return mdtCostoOticReal12
        End Get
        Set(ByVal value As Long)
            mdtCostoOticReal12 = value
        End Set
    End Property
    Public Property CostoOticExc12() As Long
        Get
            Return mdtCostoOticExc12
        End Get
        Set(ByVal value As Long)
            mdtCostoOticExc12 = value
        End Set
    End Property
    Public Property CostoAdmin12() As Long
        Get
            Return mdtCostoAdmin12
        End Get
        Set(ByVal value As Long)
            mdtCostoAdmin12 = value
        End Set
    End Property
    Public Property AportesEnterados12() As Long
        Get
            Return mdtAportesEnterados12
        End Get
        Set(ByVal value As Long)
            mdtAportesEnterados12 = value
        End Set
    End Property
    Public Property AportesPendientes12() As Long
        Get
            Return mdtAportesPendientes12
        End Get
        Set(ByVal value As Long)
            mdtAportesPendientes12 = value
        End Set
    End Property
    Public Property FacturasPagadasData12() As Long
        Get
            Return mdtFacturasPagadas12
        End Get
        Set(ByVal value As Long)
            mdtFacturasPagadas12 = value
        End Set
    End Property
    Public Property FacturasPorPagarData12() As Long
        Get
            Return mdtFacturasPorPagar12
        End Get
        Set(ByVal value As Long)
            mdtFacturasPorPagar12 = value
        End Set
    End Property
    Public Property CtaCapData12() As Long
        Get
            Return mdtCtaCap12
        End Get
        Set(ByVal value As Long)
            mdtCtaCap12 = value
        End Set
    End Property
    Public Property ExcCap12() As Long
        Get
            Return mdtExcCap12
        End Get
        Set(ByVal value As Long)
            mdtExcCap12 = value
        End Set
    End Property
    Public Property PagoATerceros12() As Long
        Get
            Return mdtPagoATerceros12
        End Get
        Set(ByVal value As Long)
            mdtPagoATerceros12 = value
        End Set
    End Property
    Public Property PagoDeTerceros12() As Long
        Get
            Return mdtPagoDeTerceros12
        End Get
        Set(ByVal value As Long)
            mdtPagoDeTerceros12 = value
        End Set
    End Property
#End Region



    'constructor del objeto
    Public Sub Inicializar0(ByRef objSql As CSql, ByVal lngRutUsuario As Long)
        Try
            mobjSql = objSql
            mlngRutUsuario = lngRutUsuario
        Catch ex As Exception
            EnviaError("CInformeGestionAnual.vb:Inicializar0-->" & ex.Message)
        End Try

    End Sub

    'Procedimiento para consultar los datos desde la base
    'intPeriodo: 0=todos los meses, 1-12 mes indicado
    Public Sub Cargar(ByVal blnEsHolding As Boolean, ByVal strRutCliente As String, _
                      ByVal intCodSucursal As Integer, ByVal lngRutEj As Long, _
                      ByVal intPeriodo As Integer)
        Try
            mobjSql = New CSql
            'asignación de variables seleccionadas
            mblnHolding = blnEsHolding
            mintCodSucursal = intCodSucursal
            mlngRutEjecutivo = lngRutEj
            mintPeriodo = intPeriodo

            If Trim(strRutCliente) = "" Then
                mlngRutCliente = 0
            Else
                mlngRutCliente = RutUsrALng(strRutCliente)
            End If

            'periodo consultado
            Dim intContPeriodo As Integer
            Dim dtmIni As Date, dtmFin As Date
            Dim dtmHoy As Date
            dtmHoy = Now.Date
            If mintPeriodo < 1900 Then
                mintNroPeriodos = 4   'número de años consultados
                intContPeriodo = Year(dtmHoy) - (mintNroPeriodos - 1)   'año inicial

                If mintPeriodo = 0 Then  'año completo
                    dtmIni = DateSerial(intContPeriodo, 1, 1)
                    dtmFin = DateSerial(intContPeriodo, 12, 31)
                Else  'un solo mes
                    dtmIni = DateSerial(intContPeriodo, mintPeriodo, 1)
                    dtmFin = DateSerial(intContPeriodo, mintPeriodo + 1, 0)
                End If
            Else  'mintPeriodo indica el año
                mintNroPeriodos = 12 'meses del año
                intContPeriodo = 1  'mes inicial
                dtmIni = DateSerial(mintPeriodo, 1, 1)
                dtmFin = DateSerial(mintPeriodo, 1, 31)
            End If

            ''número de periodos del reportes
            ''ReDim marrPeriodo(mintNroPeriodos) As Variant
            ''costos()
            ''ReDim marrCostoOticReal(mintNroPeriodos) As Decimal
            ''ReDim marrCostoOticExc(mintNroPeriodos) As Decimal
            ''ReDim marrCostoAdmin(mintNroPeriodos) As Decimal
            ''aportes()
            ''ReDim marrAportesEnterados(mintNroPeriodos) As Decimal
            ''ReDim marrAportesPendientes(mintNroPeriodos) As Decimal
            ''facturas()
            ''ReDim marrFacturasPagadas(mintNroPeriodos) As Decimal
            ''ReDim marrFacturasPorPagar(mintNroPeriodos) As Decimal
            ''cuentas()
            ''ReDim marrCtaCap(mintNroPeriodos) As Decimal
            ''ReDim marrExcCap(mintNroPeriodos) As Decimal
            ''ReDim marrPagoATerceros(mintNroPeriodos) As Decimal
            ''ReDim marrPagoDeTerceros(mintNroPeriodos) As Decimal

            Dim i As Integer
            'listado de ruts asociados a una empresa
            Dim strRuts As String
            If mlngRutCliente = 0 Then
                strRuts = ""
            Else
                strRuts = Trim(mlngRutCliente)
                If mblnHolding Then  'si hay que buscar las filiales
                    Dim dtRut As DataTable
                    dtRut = mobjSql.s_clientes_asociados(mlngRutCliente)
                    For i = 0 To TamanoArreglo2(dtRut) - 1
                        strRuts = strRuts & "," & Trim(dtRut.Rows(i)(0))
                    Next
                End If
            End If

            'inicialización de totales
            mdclTotalCostoOticReal = 0
            mdclTotalCostoOticExc = 0
            mdclTotalCostoAdmin = 0
            mdclTotalAportesEnt = 0
            mdclTotalAportesPend = 0
            mdclFacturasPagadas = 0
            mdclFacturasPorPagar = 0
            mdclCtaCap = 0
            mdclCtaExcCap = 0
            mdclATerceros = 0
            mdclDeTerceros = 0

            If mintPeriodo >= 1900 Then
                'arreglo indexado por Ruts, con los costos acumulados por empresa
                Dim objCostoOticAcumEmpresa As DataTable
                Dim lngRutEmpresa As Long
                Dim curAcum0 As Decimal
                Dim curAcum1 As Decimal
                'objCostoOticAcumEmpresa = CreateObject("Scripting.Dictionary")
            End If

            For i = 0 To mintNroPeriodos - 1

                mdtPeriodo = New DataTable
                mdtPeriodo.Columns.Add("0")
                mdtPeriodo.Columns.Add("1")
                If mintPeriodo < 1900 Then   'años
                    'Dim drPeriodo As DataRow
                    'For Each drPeriodo In mdtPeriodo.Rows
                    '    drPeriodo("0") = intContPeriodo
                    'Next
                    ' mdtPeriodo = intContPeriodo
                Else
                    mdtPeriodo = mdtMeses
                End If

                'costos
                Dim arrTemp As DataTable, curFranq As Decimal, curCostoOtic As Decimal, j As Integer, filas As Integer
                arrTemp = mobjSql.s_clientes_franquicia(mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario, strRuts)
                filas = mobjSql.Registros
                mdtCostoOticReal = 0
                mdtCostoOticExc = 0  'cursos + (viaticos + traslados)


                'el costo otic excedido se suma sólo si el costo otic es mayor que
                'la franquicia de cada empresa
                Dim dr As DataRow
                If filas > 0 Then
                    For Each dr In arrTemp.Rows
                        ' For j = 0 To TamanoArreglo2(arrTemp) - 1
                        curFranq = CLng(arrTemp.Rows(j)(1)) '(1, j)
                        curCostoOtic = CLng(arrTemp.Rows(j)(2)) + CLng(arrTemp.Rows(j)(3)) '(2, j)(3, j)

                        'el cálculo del costo excedido por mes es diferente al de un año
                        Dim lngRutEmpresa As Long
                        Dim objCostoOticAcumEmpresa As DataTable
                        Dim curAcum0 As Decimal
                        Dim curAcum1 As Decimal
                        If mintPeriodo < 1900 Then

                            If curFranq >= curCostoOtic Then
                                mdtCostoOticReal = mdtCostoOticReal + curCostoOtic
                            Else
                                mdtCostoOticReal = mdtCostoOticReal + curFranq
                                mdtCostoOticExc = mdtCostoOticExc + (curCostoOtic - curFranq)
                            End If
                        Else
                            'año completo, por meses
                            lngRutEmpresa = CLng(arrTemp.Rows(j)(0))
                            'If IsDBNull(objCostoOticAcumEmpresa(lngRutEmpresa)) Then
                            '    objCostoOticAcumEmpresa(lngRutEmpresa) = 0  'inicializar valor
                            'End If
                            'curAcum0 = objCostoOticAcumEmpresa(lngRutEmpresa)
                            'curAcum1 = objCostoOticAcumEmpresa(lngRutEmpresa) + curCostoOtic
                            If curFranq >= curAcum0 And curFranq >= curAcum1 Then
                                'cliente no estaba excedido y no quedará execedido
                                mdtCostoOticReal = mdtCostoOticReal + curCostoOtic
                            ElseIf curFranq >= curAcum0 And curFranq < curAcum1 Then
                                'cliente no estaba excedido pero quedará excedido
                                mdtCostoOticReal = mdtCostoOticReal + (curFranq - curAcum0)
                                mdtCostoOticExc = mdtCostoOticExc + (curAcum1 - curFranq)
                            ElseIf curFranq < curAcum0 And curFranq >= curAcum1 Then
                                ' cliente estaba excedido, pero queda sin exceso ( porque costo otic mensual es negativo)
                                mdtCostoOticReal = mdtCostoOticReal - (curFranq - curAcum1)
                                mdtCostoOticExc = mdtCostoOticExc - (curAcum0 - curFranq)
                            Else
                                'cliente estaba excedido y sigue excedido
                                'sumar todo al exceso
                                mdtCostoOticExc = mdtCostoOticExc + curCostoOtic
                            End If
                            'objCostoOticAcumEmpresa(lngRutEmpresa) = curAcum1
                        End If

                        'If curFranq >= curCostoOtic Then
                        '    mdtCostoOticReal = mdtCostoOticReal + curCostoOtic
                        'Else
                        '    mdtCostoOticReal = mdtCostoOticReal + curFranq
                        '    mdtCostoOticExc = mdtCostoOticExc + (curCostoOtic - curFranq)
                        'End If
                    Next
                End If
                Dim num As Long


                mdtCostoAdmin = CLng(mobjSql.s_suma_costos_cursos("costo_adm", strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))

                ' mdtGastoEmpresa = CLng(mobjSql.s_suma_costos_cursos("costo_adm", strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))

                'aportes: neto y adm
                mdtAportesEnterados = CLng(mobjSql.s_suma_aportes("monto_neto+monto_adm", strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))

                mdtAportesPendientes = 0


                'facturas
                mdtFacturasPagadas = CLng(mobjSql.s_factura_cont(2, strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))
                'dtTabla.Rows(i)(5) = mdtFacturasPagadas
                mdtFacturasPorPagar = CLng(mobjSql.s_factura_cont(1, strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))
                'dtTabla.Rows(i)(6) = mdtFacturasPorPagar
                ' cuentas
                mdtCtaCap = CDec(mobjSql.s_transaccion_suma_cuenta("1", strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))

                mdtExcCap = CLng(mobjSql.s_transaccion_suma_cuenta("4", strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))

                mdtPagoATerceros = CLng(mobjSql.s_transaccion_suma_cuenta("2,5", strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))

                mdtPagoDeTerceros = CLng(mobjSql.s_transaccion_suma_de_terceros(strRuts, mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario))

                'sumar un año o un mes, segun corresponda
                Select Case i
                    Case 0
                        mintContPeriodo1 = intContPeriodo
                    Case 1
                        mintContPeriodo2 = intContPeriodo + 1
                    Case 2
                        mintContPeriodo3 = intContPeriodo + 2
                    Case 3
                        mintContPeriodo4 = intContPeriodo + 3
                End Select
                'intContPeriodo = intContPeriodo + 1
                If mintPeriodo < 1900 Then  'año siguiente
                    dtmIni = DateAdd("yyyy", 1, dtmIni)
                    dtmFin = DateAdd("yyyy", 1, dtmFin)
                Else  'mes siguiente
                    dtmIni = DateSerial(mintPeriodo, intContPeriodo, 1)
                    dtmFin = DateSerial(mintPeriodo, intContPeriodo + 1, 0)
                End If

                '    'totales()
                mdclTotalCostoOticReal = mdclTotalCostoOticReal + CLng(mdtCostoOticReal)
                mdclTotalCostoOticExc = mdclTotalCostoOticExc + CLng(mdtCostoOticExc)
                mdclTotalCostoAdmin = mdclTotalCostoAdmin + CLng(mdtCostoAdmin)
                mdclTotalAportesEnt = mdclTotalAportesEnt + CLng(mdtAportesEnterados)
                mdclTotalAportesPend = mdclTotalAportesPend + CLng(mdtAportesPendientes)
                mdclFacturasPagadas = mdclFacturasPagadas + CLng(mdtFacturasPagadas)
                mdclFacturasPorPagar = mdclFacturasPorPagar + CLng(mdtFacturasPorPagar)
                mdclCtaCap = mdclCtaCap + CLng(mdtCtaCap)
                mdclCtaExcCap = mdclCtaExcCap + CLng(mdtExcCap)
                mdclATerceros = mdclATerceros + CLng(mdtPagoATerceros)
                mdclDeTerceros = mdclDeTerceros + CLng(mdtPagoDeTerceros)
                Select Case i
                    Case 0
                        ' transformar los montos a Millones de pesos
                        mdtCostoOticReal1 = mdtCostoOticReal / MM
                        mdtCostoOticExc1 = mdtCostoOticExc / MM
                        mdtCostoAdmin1 = mdtCostoAdmin / MM
                        mdtAportesEnterados1 = mdtAportesEnterados / MM
                        mdtAportesPendientes1 = mdtAportesPendientes / MM
                        mdtFacturasPagadas1 = mdtFacturasPagadas
                        mdtFacturasPorPagar1 = mdtFacturasPorPagar
                        mdtCtaCap1 = mdtCtaCap / MM
                        mdtExcCap1 = mdtExcCap / MM
                        mdtPagoATerceros1 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros1 = mdtPagoDeTerceros / MM
                    Case 1
                        mdtCostoOticReal2 = mdtCostoOticReal / MM
                        mdtCostoOticExc2 = mdtCostoOticExc / MM
                        mdtCostoAdmin2 = mdtCostoAdmin / MM
                        mdtAportesEnterados2 = mdtAportesEnterados / MM
                        mdtAportesPendientes2 = mdtAportesPendientes / MM
                        mdtFacturasPagadas2 = mdtFacturasPagadas
                        mdtFacturasPorPagar2 = mdtFacturasPorPagar
                        mdtCtaCap2 = mdtCtaCap / MM
                        mdtExcCap2 = mdtExcCap / MM
                        mdtPagoATerceros2 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros2 = mdtPagoDeTerceros / MM
                    Case 2
                        mdtCostoOticReal3 = mdtCostoOticReal / MM
                        mdtCostoOticExc3 = mdtCostoOticExc / MM
                        mdtCostoAdmin3 = mdtCostoAdmin / MM
                        mdtAportesEnterados3 = mdtAportesEnterados / MM
                        mdtAportesPendientes3 = mdtAportesPendientes / MM
                        mdtFacturasPagadas3 = mdtFacturasPagadas
                        mdtFacturasPorPagar3 = mdtFacturasPorPagar
                        mdtCtaCap3 = mdtCtaCap / MM
                        mdtExcCap3 = mdtExcCap / MM
                        mdtPagoATerceros3 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros3 = mdtPagoDeTerceros / MM
                    Case 3
                        mdtCostoOticReal4 = mdtCostoOticReal / MM
                        mdtCostoOticExc4 = mdtCostoOticExc / MM
                        mdtCostoAdmin4 = mdtCostoAdmin / MM
                        mdtAportesEnterados4 = mdtAportesEnterados / MM
                        mdtAportesPendientes4 = mdtAportesPendientes / MM
                        mdtFacturasPagadas4 = mdtFacturasPagadas
                        mdtFacturasPorPagar4 = mdtFacturasPorPagar
                        mdtCtaCap4 = mdtCtaCap / MM
                        mdtExcCap4 = mdtExcCap / MM
                        mdtPagoATerceros4 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros4 = mdtPagoDeTerceros / MM
                    Case 4
                        mdtCostoOticReal5 = mdtCostoOticReal / MM
                        mdtCostoOticExc5 = mdtCostoOticExc / MM
                        mdtCostoAdmin5 = mdtCostoAdmin / MM
                        mdtAportesEnterados5 = mdtAportesEnterados / MM
                        mdtAportesPendientes5 = mdtAportesPendientes / MM
                        mdtFacturasPagadas5 = mdtFacturasPagadas
                        mdtFacturasPorPagar5 = mdtFacturasPorPagar
                        mdtCtaCap5 = mdtCtaCap / MM
                        mdtExcCap5 = mdtExcCap / MM
                        mdtPagoATerceros5 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros5 = mdtPagoDeTerceros / MM
                    Case 5
                        mdtCostoOticReal6 = mdtCostoOticReal / MM
                        mdtCostoOticExc6 = mdtCostoOticExc / MM
                        mdtCostoAdmin6 = mdtCostoAdmin / MM
                        mdtAportesEnterados6 = mdtAportesEnterados / MM
                        mdtAportesPendientes6 = mdtAportesPendientes / MM
                        mdtFacturasPagadas6 = mdtFacturasPagadas
                        mdtFacturasPorPagar6 = mdtFacturasPorPagar
                        mdtCtaCap6 = mdtCtaCap / MM
                        mdtExcCap6 = mdtExcCap / MM
                        mdtPagoATerceros6 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros6 = mdtPagoDeTerceros / MM
                    Case 6
                        mdtCostoOticReal7 = mdtCostoOticReal / MM
                        mdtCostoOticExc7 = mdtCostoOticExc / MM
                        mdtCostoAdmin7 = mdtCostoAdmin / MM
                        mdtAportesEnterados7 = mdtAportesEnterados / MM
                        mdtAportesPendientes7 = mdtAportesPendientes / MM
                        mdtFacturasPagadas7 = mdtFacturasPagadas
                        mdtFacturasPorPagar7 = mdtFacturasPorPagar
                        mdtCtaCap7 = mdtCtaCap / MM
                        mdtExcCap7 = mdtExcCap / MM
                        mdtPagoATerceros7 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros7 = mdtPagoDeTerceros / MM
                    Case 7
                        mdtCostoOticReal8 = mdtCostoOticReal / MM
                        mdtCostoOticExc8 = mdtCostoOticExc / MM
                        mdtCostoAdmin8 = mdtCostoAdmin / MM
                        mdtAportesEnterados8 = mdtAportesEnterados / MM
                        mdtAportesPendientes8 = mdtAportesPendientes / MM
                        mdtFacturasPagadas8 = mdtFacturasPagadas
                        mdtFacturasPorPagar8 = mdtFacturasPorPagar
                        mdtCtaCap8 = mdtCtaCap / MM
                        mdtExcCap8 = mdtExcCap / MM
                        mdtPagoATerceros8 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros8 = mdtPagoDeTerceros / MM
                    Case 8
                        mdtCostoOticReal9 = mdtCostoOticReal / MM
                        mdtCostoOticExc9 = mdtCostoOticExc / MM
                        mdtCostoAdmin9 = mdtCostoAdmin / MM
                        mdtAportesEnterados9 = mdtAportesEnterados / MM
                        mdtAportesPendientes9 = mdtAportesPendientes / MM
                        mdtFacturasPagadas9 = mdtFacturasPagadas
                        mdtFacturasPorPagar9 = mdtFacturasPorPagar
                        mdtCtaCap9 = mdtCtaCap / MM
                        mdtExcCap9 = mdtExcCap / MM
                        mdtPagoATerceros9 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros9 = mdtPagoDeTerceros / MM
                    Case 9
                        mdtCostoOticReal10 = mdtCostoOticReal / MM
                        mdtCostoOticExc10 = mdtCostoOticExc / MM
                        mdtCostoAdmin10 = mdtCostoAdmin / MM
                        mdtAportesEnterados10 = mdtAportesEnterados / MM
                        mdtAportesPendientes10 = mdtAportesPendientes / MM
                        mdtFacturasPagadas10 = mdtFacturasPagadas
                        mdtFacturasPorPagar10 = mdtFacturasPorPagar
                        mdtCtaCap10 = mdtCtaCap / MM
                        mdtExcCap10 = mdtExcCap / MM
                        mdtPagoATerceros10 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros10 = mdtPagoDeTerceros / MM
                    Case 10
                        mdtCostoOticReal11 = mdtCostoOticReal / MM
                        mdtCostoOticExc11 = mdtCostoOticExc / MM
                        mdtCostoAdmin11 = mdtCostoAdmin / MM
                        mdtAportesEnterados11 = mdtAportesEnterados / MM
                        mdtAportesPendientes11 = mdtAportesPendientes / MM
                        mdtFacturasPagadas11 = mdtFacturasPagadas
                        mdtFacturasPorPagar11 = mdtFacturasPorPagar
                        mdtCtaCap11 = mdtCtaCap / MM
                        mdtExcCap11 = mdtExcCap / MM
                        mdtPagoATerceros11 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros11 = mdtPagoDeTerceros / MM
                    Case 11
                        mdtCostoOticReal12 = mdtCostoOticReal / MM
                        mdtCostoOticExc12 = mdtCostoOticExc / MM
                        mdtCostoAdmin12 = mdtCostoAdmin / MM
                        mdtAportesEnterados12 = mdtAportesEnterados / MM
                        mdtAportesPendientes12 = mdtAportesPendientes / MM
                        mdtFacturasPagadas12 = mdtFacturasPagadas
                        mdtFacturasPorPagar12 = mdtFacturasPorPagar
                        mdtCtaCap12 = mdtCtaCap / MM
                        mdtExcCap12 = mdtExcCap / MM
                        mdtPagoATerceros12 = mdtPagoATerceros / MM
                        mdtPagoDeTerceros12 = mdtPagoDeTerceros / MM

                End Select
                '' transformar los montos a Millones de pesos
                'mdtCostoOticReal = mdtCostoOticReal / MM
                'dtTabla.Rows(i)(0) = mdtCostoOticReal
                'mdtCostoOticExc = mdtCostoOticExc / MM
                'dtTabla.Rows(i)(1) = mdtCostoOticExc
                'mdtCostoAdmin = mdtCostoAdmin / MM
                'dtTabla.Rows(i)(2) = mdtCostoAdmin
                'mdtAportesEnterados = mdtAportesEnterados / MM
                'dtTabla.Rows(i)(3) = mdtAportesEnterados
                'mdtAportesPendientes = mdtAportesPendientes / MM
                'dtTabla.Rows(i)(4) = mdtAportesPendientes
                'mdtCtaCap = mdtCtaCap / MM
                'dtTabla.Rows(i)(7) = mdtCtaCap
                'mdtExcCap = mdtExcCap / MM
                'dtTabla.Rows(i)(8) = mdtExcCap
                'mdtPagoATerceros = mdtPagoATerceros / MM
                'dtTabla.Rows(i)(9) = mdtPagoATerceros
                'mdtPagoDeTerceros = mdtPagoDeTerceros / MM
                'dtTabla.Rows(i)(10) = mdtPagoDeTerceros
            Next

            'totales
            mdclTotalCostoOticReal = mdclTotalCostoOticReal / MM

            mdclTotalCostoOticExc = mdclTotalCostoOticExc / MM
            mdclTotalCostoAdmin = mdclTotalCostoAdmin / MM
            mdclTotalAportesEnt = mdclTotalAportesEnt / MM
            mdclTotalAportesPend = mdclTotalAportesPend / MM
            mdclFacturasPagadas = mdclFacturasPagadas / MM
            mdclFacturasPorPagar = mdclFacturasPorPagar / MM
            mdclCtaCap = mdclCtaCap / MM
            mdclCtaExcCap = mdclCtaExcCap / MM
            mdclATerceros = mdclATerceros / MM
            mdclDeTerceros = mdclDeTerceros / MM

        Catch ex As Exception
            EnviaError("CInformeGestionAnual.vb:Cargar-->" & ex.Message)
        End Try

    End Sub

    Public Function Consultar() As System.Data.DataTable
        Dim dtConsulta As DataTable

    End Function

    'inicialización de variables
    Public Sub Inicializar()
        Try
            mlngRutCliente = 0
            mblnHolding = False

            mintCodSucursal = 0
            mlngRutEjecutivo = 0
            mintPeriodo = 0  'año completo
            mdtMeses = New DataTable
            mdtMeses.Columns.Add("Ene")
            mdtMeses.Columns.Add("Feb")
            mdtMeses.Columns.Add("Mar")
            mdtMeses.Columns.Add("Abr")
            mdtMeses.Columns.Add("May")
            mdtMeses.Columns.Add("Jun")
            mdtMeses.Columns.Add("Jul")
            mdtMeses.Columns.Add("Ago")
            mdtMeses.Columns.Add("Sep")
            mdtMeses.Columns.Add("Oct")
            mdtMeses.Columns.Add("Nov")
            mdtMeses.Columns.Add("Dic")
            'mdtMeses = Array("Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic")
            Exit Sub
        Catch ex As Exception
            EnviaError("CInformeGestionAnual.vb:Inicializar0-->" & ex.Message)
        End Try

    End Sub

End Class

