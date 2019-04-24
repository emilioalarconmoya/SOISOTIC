Imports Clases
Imports modulos
Imports System.data

Public Class CClienteInfo
    ' objeto global
    Private mobjSql As CSql
    'franquicia del año actual
    Private mlngFranquiciaActual As Long
    'Costo Otic Cursos Complementarios año siguiente al actual
    Private mlngCostoOticCompl As Long
    'Gasto Empresa Cursos año siguiente al actual
    Private mlngGastoEmpresaCompl As Long
    'gasto empresa
    Private mlngGastoEmpresaAgno As Long
    'gastos empresa prorrateados por cuenta
    Private mlngGastoEmpCap As Long
    Private mlngGastoEmpExcCap As Long
    Private mlngGastoEmpTerceros As Long
    Private mlngCantidadDeCursos As Long
    Private mlngCantidadDeCursosAnulados As Long
    Private mlngCantidadDeCursosEliminados As Long
    Private mlngAlumnosCapacitados As Long
    Private mlngAlumnosCapacitadosSR As Long
    Private mlngAlumnosCapacitadosCero As Long
    Private mlngAlumnosCapacitadosSRCero As Long
    Private mlngAlumnosCapacitadosPresencial As Long
    Private mlngAlumnosCapacitadosElearning As Long
    Private mlngAlumnosCapacitadosAutoInstruccion As Long
    Private mlngAlumnosCapacitadosDistancia As Long

    Private mlngAlumnosInternosCapacitados As Long
    Private mlngAlumnosInternosCapacitadosSR As Long

    Private mlngHorasHombreCapacitacion As Long
    Private mlngHorasHombreCapacitacionCero As Long
    Private mlngHorasHombreCapacitacion75 As Long
    'Valor cursos internos - no sence
    Private mlngTotalCursosInternos As Long
    Private mlngCantCursosInternos As Long
    'costo otic de todos los cursos del cliente, incluyendo los pagos de terceros
    Private mlngCostoOticCursos As Long
    'tiene aportes por cobrar
    Private mblnTieneAportesPorCobrar As Boolean
    Private mdblPromHorasParticipantes As Double
    Private mdblSumaHorasPresencial As Double
    Private mdblSumaHorasElearning As Double
    Private mdblSumaHorasAutoInstruccion As Double
    Private mdblSumaHorasAdistancia As Double
    Private mdtHorasHombreAgno As DataTable
    Private mdtCostosAnuales As DataTable
    'suma de becas por aportes
    Private mlngSumaAbonosAporteBecas As Long
    Private mlngCostosTotalesCursos As Long

    Private mlngValorMercadoCap As Long
    Private mlngValorMercadoExcCap As Long
    Private mlngValorMercadoTerceros As Long

    Private mlngRutCliente As Long
    Private mintAgno As Integer

    Public ReadOnly Property ValorMercadoCap() As Long
        Get
            Return mlngValorMercadoCap
        End Get
    End Property
    Public ReadOnly Property ValorMercadoExcCap() As Long
        Get
            Return mlngValorMercadoExcCap
        End Get
    End Property
    Public ReadOnly Property ValorMercadoTerceros() As Long
        Get
            Return mlngValorMercadoTerceros
        End Get
    End Property
    Public ReadOnly Property SumaAbonosAporteBecas() As Long
        Get
            Return mlngSumaAbonosAporteBecas
        End Get
    End Property

    Public ReadOnly Property PromHorasParticipantes() As Double
        Get
            'Return FormatNumber(mdblPromHorasParticipantes, 1)
            Return mdblPromHorasParticipantes
        End Get
    End Property
    Public ReadOnly Property SumaHorasPresencial() As Double
        Get
            Return mdblSumaHorasPresencial
        End Get
    End Property
    Public ReadOnly Property SumaHorasElearning() As Double
        Get
            Return mdblSumaHorasElearning
        End Get
    End Property
    Public ReadOnly Property SumaHorasAutoInstruccion() As Double
        Get
            Return mdblSumaHorasAutoInstruccion
        End Get
    End Property
    Public ReadOnly Property SumaHorasAdistancia() As Double
        Get
            Return mdblSumaHorasAdistancia
        End Get
    End Property

    'Valor Total cursos int.
    Public ReadOnly Property TotalCursosInternos() As Long
        Get
            Return mlngTotalCursosInternos
        End Get
    End Property
    Public ReadOnly Property CantCursosInternos() As Long
        Get
            Return mlngCantCursosInternos
        End Get
    End Property

    'Cantidad de cursos
    Public ReadOnly Property CantidadDeCursos() As Long
        Get
            Return mlngCantidadDeCursos
        End Get
    End Property
    'Cantidad de cursos
    Public ReadOnly Property CantidadDeCursosAnulados() As Long
        Get
            Return mlngCantidadDeCursosAnulados
        End Get
    End Property
    'Cantidad de cursos
    Public ReadOnly Property CantidadDeCursosEliminados() As Long
        Get
            Return mlngCantidadDeCursosEliminados
        End Get
    End Property
    'Cantidad de alumnos capacitados
    Public ReadOnly Property AlumnosCapacitados() As Long
        Get
            Return mlngAlumnosCapacitados
        End Get
    End Property
    Public ReadOnly Property AlumnosCapacitadosSR() As Long
        Get
            Return mlngAlumnosCapacitadosSR
        End Get
    End Property
    Public ReadOnly Property AlumnosCapacitadosCero() As Long
        Get
            Return mlngAlumnosCapacitadosCero
        End Get
    End Property
    Public ReadOnly Property AlumnosCapacitadosSRCero() As Long
        Get
            Return mlngAlumnosCapacitadosSRCero
        End Get
    End Property
    Public ReadOnly Property AlumnosCapacitadosPresencial() As Long
        Get
            Return mlngAlumnosCapacitadosPresencial
        End Get
    End Property
    Public ReadOnly Property AlumnosCapacitadosElearning() As Long
        Get
            Return mlngAlumnosCapacitadosElearning
        End Get
    End Property
    Public ReadOnly Property AlumnosCapacitadosAutoInstruccion() As Long
        Get
            Return mlngAlumnosCapacitadosAutoInstruccion
        End Get
    End Property
    Public ReadOnly Property AlumnosCapacitadosDistancia() As Long
        Get
            Return mlngAlumnosCapacitadosDistancia
        End Get
    End Property
    'Cantidad de alumnos internos capacitados 
    Public ReadOnly Property AlumnosInternosCapacitados() As Long
        Get
            Return mlngAlumnosInternosCapacitados
        End Get
    End Property
    Public ReadOnly Property AlumnosInternosCapacitadosSR() As Long
        Get
            Return mlngAlumnosInternosCapacitadosSR
        End Get
    End Property

    'Horas hombre de capacitacion
    Public ReadOnly Property HorasHombreDeCapacitacion() As Long
        Get
            Return mlngHorasHombreCapacitacion
        End Get
    End Property
    Public ReadOnly Property HorasHombreDeCapacitacionCero() As Long
        Get
            Return mlngHorasHombreCapacitacionCero
        End Get
    End Property
    Public ReadOnly Property HorasHombreDeCapacitacion75() As Long
        Get
            Return mlngHorasHombreCapacitacion75
        End Get
    End Property
    'Franquicia año actual
    Public ReadOnly Property FranquiciaActual() As Long
        Get
            Return mlngFranquiciaActual
        End Get
    End Property

    'suma del gasto empresa del año actual
    Public ReadOnly Property GastoEmpresaAcumulado() As Long
        Get
            Return mlngGastoEmpresaAgno
        End Get
    End Property

    'Costo Otic Cursos Complementarios año siguiente al actual
    Public ReadOnly Property CostoOticComplementario() As Long
        Get
            Return mlngCostoOticCompl
        End Get
    End Property

    'Gasto Empresa Cursos Complementarios año siguiente al actual
    Public ReadOnly Property GastoEmpresaComplementario() As Long
        Get
            Return mlngGastoEmpresaCompl
        End Get
    End Property

    'indica si un cliente tiene aportes por cobrar
    Public ReadOnly Property TieneAportesPorCobrar() As Long
        Get
            Return mblnTieneAportesPorCobrar
        End Get
    End Property
    '
    'Gastos Empresa prorrateados por tipo de pago: cap, exc cap, terceros
    Public ReadOnly Property GastoEmpresaCap() As Long
        Get
            Return mlngGastoEmpCap
        End Get
    End Property
    Public ReadOnly Property GastoEmpresaExcCap() As Long
        Get
            Return mlngGastoEmpExcCap
        End Get
    End Property
    Public ReadOnly Property GastoEmpresaTerceros() As Long
        Get
            Return mlngGastoEmpTerceros
        End Get
    End Property
    Public ReadOnly Property HorasHombreAgno() As DataTable
        Get
            Return mdtHorasHombreAgno
        End Get
    End Property
    Public ReadOnly Property CostosAnuales() As DataTable
        Get
            Return mdtCostosAnuales
        End Get
    End Property
    Public ReadOnly Property CostosTotalesCursos() As Long
        Get
            Return mlngCostosTotalesCursos
        End Get
    End Property

    Public Sub New()
        mlngCantidadDeCursos = 0
        mlngCantidadDeCursosEliminados = 0
        mlngCantidadDeCursosAnulados = 0
        mlngAlumnosCapacitados = 0
        mlngAlumnosCapacitadosSR = 0
        mlngAlumnosCapacitadosCero = 0
        mlngAlumnosCapacitadosSRCero = 0
        mlngAlumnosCapacitadosPresencial = 0
        mlngAlumnosCapacitadosElearning = 0
        mlngAlumnosCapacitadosAutoInstruccion = 0
        mlngAlumnosCapacitadosDistancia = 0
        mlngHorasHombreCapacitacion = 0
        mlngHorasHombreCapacitacionCero = 0
        mlngHorasHombreCapacitacion75 = 0
        mdblSumaHorasPresencial = 0
        mdblSumaHorasElearning = 0
        mdblSumaHorasAutoInstruccion = 0
        mlngSumaAbonosAporteBecas = 0
        mdblSumaHorasAdistancia = 0
        mlngAlumnosInternosCapacitados = 0
        mlngAlumnosInternosCapacitadosSR = 0
    End Sub


    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql, ByVal lngRutCliente As Long, _
                           ByVal lngMontoCap As Long, ByVal lngMontoExcCap As Long, _
                           ByVal strListaRutsHolding As String, ByVal intagno As Integer)
        Try
            If lngRutCliente <= 0 Then
                EnviaError("cClienteInfo:Inicializar Method - Usuario desconocido")
                Exit Sub
            End If

            Dim strRuts As String
            If strListaRutsHolding = "" Then
                strRuts = Str(lngRutCliente)
            Else
                strRuts = strListaRutsHolding
            End If

            mlngRutCliente = lngRutCliente
            mintAgno = intagno

            'año en que se quieren los datos
            Dim dtmInicio As Date, dtmFin As Date, intAgnoActual As Integer
            intAgnoActual = intagno
            dtmInicio = DateSerial(intAgnoActual, 1, 1)
            dtmFin = DateSerial(intAgnoActual, 12, 31)

            'Franquicia año en que se quieren los datos
            mlngFranquiciaActual = objSql.s_franquicia_actual(strRuts, intAgnoActual)
            'gasto empresa
            mlngGastoEmpresaAgno = objSql.s_suma_costos_cursos("gasto_empresa", strRuts, 0, 0, dtmInicio, dtmFin)

            'costo otic de todos los cursos del año en que se quieren los datos
            mlngCostoOticCursos = objSql.s_suma_costos_cursos("costo_otic", strRuts, 0, 0, dtmInicio, dtmFin)

            'Suma de la cantidad de cursos tomados por uuna empresa y sus filiales
            mlngCantidadDeCursos = objSql.s_suma_cursos_cliente(strRuts, dtmInicio, dtmFin)
            'suma cursos anulados
            mlngCantidadDeCursosAnulados = objSql.s_suma_cursos_anulados_cliente(strRuts, dtmInicio, dtmFin)
            'suma cursos eliminados
            mlngCantidadDeCursosEliminados = objSql.s_suma_cursos_eliminados_cliente(strRuts, dtmInicio, dtmFin)
            'Suma de alumnos capacitados
            mlngAlumnosCapacitados = objSql.suma_alumnos_capacitados_cliente(strRuts, dtmInicio, dtmFin)
            mlngAlumnosCapacitadosSR = objSql.suma_alumnos_capacitados_SR(strRuts, dtmInicio, dtmFin)

            mlngAlumnosCapacitadosCero = objSql.suma_alumnos_capacitados_cliente_mayor_a_cero(strRuts, dtmInicio, dtmFin)
            mlngAlumnosCapacitadosSRCero = objSql.suma_alumnos_capacitados_SR_mayor_a_cero(strRuts, dtmInicio, dtmFin)

            mlngAlumnosCapacitadosPresencial = objSql.suma_alumnos_capacitados_presencial(strRuts, dtmInicio, dtmFin)
            mlngAlumnosCapacitadosElearning = objSql.suma_alumnos_capacitados_elearning(strRuts, dtmInicio, dtmFin)
            mlngAlumnosCapacitadosAutoInstruccion = objSql.suma_alumnos_capacitados_autoinstruccion(strRuts, dtmInicio, dtmFin)
            mlngAlumnosCapacitadosDistancia = objSql.suma_alumnos_capacitados_a_distancia(strRuts, dtmInicio, dtmFin)


            'Suma de alumnos capacitados
            mlngAlumnosInternosCapacitados = objSql.suma_alumnos_internos_capacitados_cliente(strRuts, dtmInicio, dtmFin)
            mlngAlumnosInternosCapacitadosSR = objSql.suma_alumnos_internos_capacitados_SR(strRuts, dtmInicio, dtmFin)

            'Suma de Horas Hombre de capacitación
           
            mlngHorasHombreCapacitacion = objSql.s_suma_horas_de_capacitacion_cliente(strRuts, dtmInicio, dtmFin)
            mlngHorasHombreCapacitacionCero = objSql.s_suma_horas_de_capacitacion_cliente_cero(strRuts, dtmInicio, dtmFin)
            mlngHorasHombreCapacitacion75 = objSql.s_suma_horas_de_capacitacion_cliente2(strRuts, dtmInicio, dtmFin)

            mdtHorasHombreAgno = objSql.s_hh_anuales_cursos_sence(strRuts)
            mdtCostosAnuales = objSql.s_monto_cursos_anuales(strRuts)
            mlngCostosTotalesCursos = objSql.s_monto_cursos(strRuts, intAgnoActual)
            'Promedio horas por hombre
            If mlngHorasHombreCapacitacion > 0 Then
                mdblPromHorasParticipantes = FormatNumber(mlngHorasHombreCapacitacion / mlngAlumnosCapacitados, 1)
            Else
                mdblPromHorasParticipantes = 0
            End If
            'HH x Modalidades(% de horas)
            Dim lng1 As Double, lng2 As Double, lng3 As Double, lng4 As Double
            lng1 = objSql.s_suma_horas_modalidad(strRuts, dtmInicio, dtmFin, 1)
            lng2 = objSql.s_suma_horas_modalidad(strRuts, dtmInicio, dtmFin, 2)
            lng3 = objSql.s_suma_horas_modalidad(strRuts, dtmInicio, dtmFin, 3)
            lng4 = objSql.s_suma_horas_modalidad(strRuts, dtmInicio, dtmFin, 4)

            If lng1 > 0 Then
                mdblSumaHorasPresencial = (lng1 / mlngHorasHombreCapacitacion) * 100
            Else
                mdblSumaHorasPresencial = 0
            End If
            If lng2 > 0 Then
                mdblSumaHorasElearning = (lng2 / mlngHorasHombreCapacitacion) * 100
            Else
                mdblSumaHorasElearning = 0
            End If
            If lng3 > 0 Then
                mdblSumaHorasAutoInstruccion = (lng3 / mlngHorasHombreCapacitacion) * 100
            Else
                mdblSumaHorasAutoInstruccion = 0
            End If
            If lng4 > 0 Then
                mdblSumaHorasAdistancia = (lng4 / mlngHorasHombreCapacitacion) * 100
            Else
                mdblSumaHorasAdistancia = 0
            End If

            'Cursos Internos - No Sence
            Dim vntTemp As Object
            vntTemp = objSql.s_suma_cursos_internos(strRuts, dtmInicio, dtmFin, 1)
            mlngCantCursosInternos = IIf(IsDBNull(vntTemp), 0, vntTemp)
            vntTemp = objSql.s_suma_valor_cursos_internos(strRuts, dtmInicio, dtmFin, 1)
            mlngTotalCursosInternos = IIf(IsDBNull(vntTemp), 0, vntTemp)


            'año siguiente
            dtmInicio = DateSerial(intAgnoActual + 1, 1, 1)
            dtmFin = DateSerial(intAgnoActual + 1, 12, 31)

            'costo otic comprometido para el próximo año
            mlngCostoOticCompl = objSql.s_suma_costos_cursos_compl("costo_otic", strRuts, 0, 0, dtmInicio, dtmFin)
            'Suma el gasto empresa de los cursos de un cliente para el siguiente año
            mlngGastoEmpresaCompl = objSql.s_suma_costos_cursos_compl("gasto_empresa", strRuts, 0, 0, dtmInicio, dtmFin)

            'chequear si tiene aportes por cobrar
            Dim intCntApPorCobrar As Integer
            intCntApPorCobrar = objSql.s_aportes_por_cobrar(strRuts, intAgnoActual)

            mlngSumaAbonosAporteBecas = objSql.s_aportes_costo_otic(strRuts, intAgnoActual, 6)

            mblnTieneAportesPorCobrar = (intCntApPorCobrar > 0)

            'cálculo de los gastos empresas, prorrateados según la cuenta con que se pagaron
            If mlngCostoOticCursos > 0 Then
                'mlngGastoEmpCap = (CDbl(lngMontoCap) / CDbl(mlngCostoOticCursos))
                'mlngGastoEmpCap = (mlngGastoEmpCap * CDbl(mlngGastoEmpresaAgno))
                'mlngGastoEmpExcCap = (CDbl(lngMontoExcCap) / CDbl(mlngCostoOticCursos))
                'mlngGastoEmpExcCap = (mlngGastoEmpExcCap * CDbl(mlngGastoEmpresaAgno))
                'mlngGastoEmpTerceros = CDbl((mlngCostoOticCursos - lngMontoCap - lngMontoExcCap))
                'mlngGastoEmpTerceros = (mlngGastoEmpTerceros / CDbl(mlngCostoOticCursos))
                'mlngGastoEmpTerceros = (mlngGastoEmpTerceros * CDbl(mlngGastoEmpresaAgno))

                'mlngGastoEmpCap = CDbl(lngMontoCap) / CDbl(mlngCostoOticCursos) * CDbl(mlngGastoEmpresaAgno)
                'mlngGastoEmpExcCap = CDbl(lngMontoExcCap) / CDbl(mlngCostoOticCursos) * CDbl(mlngGastoEmpresaAgno)
                'mlngGastoEmpTerceros = CDbl((mlngCostoOticCursos - lngMontoCap - lngMontoExcCap)) / _
                '                       CDbl(mlngCostoOticCursos) * CDbl(mlngGastoEmpresaAgno)


                Dim dtGE As New DataTable
                dtGE = objSql.s_gasto_empresa_por_cuenta(strRuts, mintAgno)
                If Not dtGE Is Nothing Then
                    If dtGE.Rows.Count > 0 Then
                        Dim dr As DataRow
                        For Each dr In dtGE.Rows
                            mlngGastoEmpCap = mlngGastoEmpCap + dr("CAP")
                            mlngGastoEmpExcCap = mlngGastoEmpExcCap + dr("EXCAP")
                            mlngGastoEmpTerceros = mlngGastoEmpTerceros + dr("TERC")
                        Next
                        
                    Else
                        mlngGastoEmpCap = 0
                        mlngGastoEmpExcCap = 0
                        mlngGastoEmpTerceros = 0
                    End If
                Else
                    mlngGastoEmpCap = 0
                    mlngGastoEmpExcCap = 0
                    mlngGastoEmpTerceros = 0
                End If



            Else
                mlngGastoEmpCap = 0
                mlngGastoEmpExcCap = 0
                mlngGastoEmpTerceros = 0
            End If
        Catch ex As Exception
            EnviaError("CClienteInfo:Inicializar-->" & ex.Message)
        End Try
    End Sub
End Class

