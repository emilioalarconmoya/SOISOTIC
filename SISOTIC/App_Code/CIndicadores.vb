Imports Clases
Imports Modulos
Imports System.Data

Public Class CIndicadores
    Private mobjCsql As CSql
    Private mbolCursosPropios As Boolean
    Private mintAgno As Integer
    Private mlngRutEjecutivo As Long
    Private mlngRutUsuario As Long 'En caso de venir el valor 1 seran cursos propios y de venir el valor 2 se mostra los cursos de todos los ejecutivos
    Private mdtGrafico1 As DataTable
    Private mdtGrafico2 As DataTable
    Private mlngTotalCursos As Long
    Private mlngRutCliente As Long
    'estados 1:Blanco del combobox , 2: Todos los ejecutivos de la persona conectada
    Private mintEstados As Integer
    'Indica si se buscaran los cursos propios de un ejecutivo(true) o no (false)
    Private mstrCursosPropios As String
    'Número de cursos en estado incompleto
    Private mlngIncompletos As Long
    'Número de cursos en estado ingresado
    Private mlngIngresados As Long
    'Número de cursos en estado rechazado
    Private mlngRechazados As Long
    'Número de cursos en estado autorizados
    Private mlngAutorizados As Long
    'Número de cursos en estado comunicado
    Private mlngComunicados As Long
    'Número de cursos en estado liquidado
    Private mlngLiquidados As Long
    'Número de cursos en estado pago por autorizar
    Private mlngPagoPorAutorizar As Long
    'Número de cursos en estado en comunicación
    Private mlngEnComunicacion As Long
    'Número de cursos en estado en liquidación
    Private mlngEnLiquidacion As Long
    'Número de cursos en estado eliminado
    Private mlngEliminados As Long
    'Número de cursos en estado anulado
    Private mlngAnulados As Long
    'Número de cursos con complemento
    Private mlngConComplemento As Long
    'número de cursos complementarios
    Private mlngComplementarios As Long
    'Número de cursos que ya se iniciaron pero que aún no se comunican al sence
    Private mlngCursosIniNoCom As Long
    'Número de cursos que ya se iniciaron pero que aún no se autorizan
    Private mlngCursosIniNoAut As Long
    'Número de cursos terminados sin asistencia
    Private mlngCursosTerSinAsis As Long
    'Número de cursos terminados con asistencia sin liquidar
    Private mlngCursosTerConAsisSinLiq As Long
    'Número de cursos que tienen más de 50 días pasada la fecha de término y no han sido liquidados
    Private mlngCursosTerNoLiq As Long
    'Número de cursos que tienen PreContrato
    Private mlngCursosPreContrato As Long
    'Número de cursos que tienen PostContrato
    Private mlngCursosPostContrato As Long
    'Número de aportes en estado ingresado (estado = 1)
    Private mlngAportesIngresados As Long
    'Número de aportes en estado cobrado (estado = 2)
    Private mlngAportesCobrados As Long
    'Número de aportes en estado anulado (estado = 3)
    Private mlngAportesAnulados As Long
    'Total aportes
    Private mlngTotalAportes As Long
    'Número de aportes pendientes (ingresados) donde el tipo de documento es letra
    Private mlngAportesPendientesLetras As Long
    'Número de aportes pendientes (ingresados) donde el tipo de documento es cheque a fecha
    Private mlngAportesPendientesChequeAFecha As Long
    'Número de solicitudes de pago a terceros en estado Pendiente (estado = 1)
    Private mlngSolicitudesPendientes As Long
    'Número de solicitudes de pago a terceros en estado Autorizada (estado = 2)
    Private mlngSolicitudesAutorizadas As Long
    'Número de solicitudes de pago a terceros en estado Rechazada (estado = 3)
    Private mlngSolicitudesRechazadas As Long
    'Total de solicitudes de pago a terceros
    Private mlngTotalSolicitudes As Long
    'Número de cursos con comunicación atrasada
    Private mlngCursosAtrasados As Long
    'Número de cursos con fecha de término mayor o igual a la de hoy + 55 dias corridos
    Private mlngCursosFechaTermino As Long
    'Número de cursos con pago de terceros
    Private mlngCursosPagoTerceros As Long
    'Número de cursos Pagados solo con cuenta de Capacitación
    Private mlngCursosPagadosCtaCap As Long
    'Número de cursos Pagados solo con cuenta de Excedentes de Capacitación
    Private mlngCursosPagadosCtaExcCap As Long
    'Número de cursos con viáticos o traslado
    Private mlngCursosViaticoYTraslado As Long
    'garfico aportes
    Private mdtGraficoAportes As DataTable
    'grafico solicitudes
    Private mdtGraficoSolicitudes As DataTable
    'filas
    Private mintFilas As Integer

    

    Public Property CursosPropios() As Boolean
        Get
            CursosPropios = mbolCursosPropios
        End Get
        Set(ByVal value As Boolean)
            mbolCursosPropios = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Agno = mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public Property RutEjecutivo() As Long
        Get
            RutEjecutivo = mlngRutEjecutivo
        End Get
        Set(ByVal value As Long)
            mlngRutEjecutivo = value
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
    Public Property Grafico1() As DataTable
        Get
            Grafico1 = mdtGrafico1
        End Get
        Set(ByVal value As DataTable)
            mdtGrafico1 = value
        End Set
    End Property
    Public Property Grafico2() As DataTable
        Get
            Grafico2 = mdtGrafico2
        End Get
        Set(ByVal value As DataTable)
            mdtGrafico2 = value
        End Set
    End Property
    Public Property TotalCursos() As Long
        Get
            TotalCursos = mlngTotalCursos
        End Get
        Set(ByVal value As Long)
            mlngTotalCursos = value
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
    Public Property AportesIngresados() As Long
        Get
            Return mlngAportesIngresados
        End Get
        Set(ByVal value As Long)
            mlngAportesIngresados = value
        End Set
    End Property
    Public Property AportesCobrados() As Long
        Get
            Return mlngAportesCobrados
        End Get
        Set(ByVal value As Long)
            mlngAportesCobrados = value
        End Set
    End Property
    Public Property AportesAnulados() As Long
        Get
            Return mlngAportesAnulados
        End Get
        Set(ByVal value As Long)
            mlngAportesAnulados = value
        End Set
    End Property
    Public Property TotalAportes() As Long
        Get
            Return mlngTotalAportes
        End Get
        Set(ByVal value As Long)
            mlngTotalAportes = value
        End Set
    End Property
    Public Property AportesPendientesLetras() As Long
        Get
            Return mlngAportesPendientesLetras
        End Get
        Set(ByVal value As Long)
            mlngAportesPendientesLetras = value
        End Set
    End Property

    Public Property AportesPendientesChequeAFecha() As Long
        Get
            Return mlngAportesPendientesChequeAFecha
        End Get
        Set(ByVal value As Long)
            mlngAportesPendientesChequeAFecha = value
        End Set
    End Property
    Public Property SolicitudesPendientes() As Long
        Get
            Return mlngSolicitudesPendientes
        End Get
        Set(ByVal value As Long)
            mlngSolicitudesPendientes = value
        End Set
    End Property
    Public Property SolicitudesAutorizadas() As Long
        Get
            Return mlngSolicitudesAutorizadas
        End Get
        Set(ByVal value As Long)
            mlngSolicitudesAutorizadas = value
        End Set
    End Property
    Public Property SolicitudesRechazadas() As Long
        Get
            Return mlngSolicitudesRechazadas
        End Get
        Set(ByVal value As Long)
            mlngSolicitudesRechazadas = value
        End Set
    End Property
    Public Property TotalSolicitudes() As Long
        Get
            Return mlngTotalSolicitudes
        End Get
        Set(ByVal value As Long)
            mlngTotalSolicitudes = value
        End Set
    End Property
    Public Property GraficoAportes() As DataTable
        Get
            Return mdtGraficoAportes
        End Get
        Set(ByVal value As DataTable)
            mdtGraficoAportes = value
        End Set
    End Property
    Public Property GraficoSolicitudes() As DataTable
        Get
            Return mdtGraficoSolicitudes
        End Get
        Set(ByVal value As DataTable)
            mdtGraficoSolicitudes = value
        End Set
    End Property
    Public Property Filas() As Integer
        Get
            Return mintFilas
        End Get
        Set(ByVal value As Integer)
            mintFilas = value
        End Set
    End Property

    Public Sub CargaIndicadores()
        Try
            mobjCsql = New CSql
            mdtGrafico1 = mobjCsql.s_indicadores1(mlngRutEjecutivo, mintAgno, mlngRutUsuario)
            mintFilas = mobjCsql.Registros
            Dim dr As datarow
            mlngTotalCursos = 0
            For Each dr In mdtGrafico1.rows
                mlngTotalCursos = mlngTotalCursos + dr("cantidad")
            Next
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CIndicadores:CargaIndicadores->" & ex.Message)
        End Try
    End Sub
    Public Sub CargaIndicadores2()
        Try
            mobjCsql = New CSql
            mdtGrafico2 = mobjCsql.s_indicadores2(mintAgno, mlngRutUsuario, mlngRutEjecutivo)
            mobjCsql = Nothing
        Catch ex As Exception
            EnviaError("CIndicadores:CargaIndicadores2->" & ex.Message)
        End Try
    End Sub
    Public Sub CargarIndicadores3()
        Try
            mobjCsql = New CSql
            mlngAportesIngresados = mobjCsql.s_aportes_3(mlngRutUsuario, mlngRutCliente, 1, 0, mintAgno)
            mlngAportesCobrados = mobjCsql.s_aportes_3(mlngRutUsuario, mlngRutCliente, 2, 0, mintAgno)
            mlngAportesAnulados = mobjCsql.s_aportes_3(mlngRutUsuario, mlngRutCliente, 3, 0, mintAgno)
            mlngTotalAportes = mlngAportesIngresados + mlngAportesCobrados + mlngAportesAnulados
            mlngAportesPendientesLetras = mobjCsql.s_aportes_3(mlngRutUsuario, mlngRutCliente, 1, 4, mintAgno)
            mlngAportesPendientesChequeAFecha = mobjCsql.s_aportes_3(mlngRutUsuario, mlngRutCliente, 1, 3, mintAgno)
            mlngSolicitudesPendientes = mobjCsql.s_sol_pago_terc1(mlngRutUsuario, mlngRutCliente, 1, mintAgno)
            mlngSolicitudesAutorizadas = mobjCsql.s_sol_pago_terc1(mlngRutUsuario, mlngRutCliente, 2, mintAgno)
            mlngSolicitudesRechazadas = mobjCsql.s_sol_pago_terc1(mlngRutUsuario, mlngRutCliente, 3, mintAgno)
            mlngTotalSolicitudes = mlngSolicitudesPendientes + mlngSolicitudesAutorizadas + _
                                    mlngSolicitudesRechazadas


            Dim dtAportes As DataTable
            dtAportes = New DataTable
            dtAportes.Columns.Add(New DataColumn("Indicador", GetType(String)))
            dtAportes.Columns.Add(New DataColumn("Valor", GetType(Long)))
           
            'dt.TableName = "Detalle"
            Dim drGraf As DataRow
            drGraf = dtAportes.NewRow()
            drGraf("Indicador") = "Aportes Ingresados"
            drGraf("Valor") = mlngAportesIngresados
            dtAportes.Rows.Add(drGraf)
            drGraf = dtAportes.NewRow()
            drGraf("Indicador") = "Aportes Cobrados"
            drGraf("Valor") = mlngAportesCobrados
            dtAportes.Rows.Add(drGraf)
            drGraf = dtAportes.NewRow()
            drGraf("Indicador") = "Aportes Anulados"
            drGraf("Valor") = mlngAportesAnulados
            dtAportes.Rows.Add(drGraf)
            'drGraf = dtAportes.NewRow()
            'drGraf("Indicador") = "Aportes Pendientes (Letra)"
            'drGraf("Valor") = mlngAportesPendientesLetras
            'dtAportes.Rows.Add(drGraf)
            'drGraf = dtAportes.NewRow()
            'drGraf("Indicador") = "Aportes Pendientes (Cheque a fecha)"
            'drGraf("Valor") = mlngAportesPendientesChequeAFecha
            'dtAportes.Rows.Add(drGraf)
            drGraf = dtAportes.NewRow()
            drGraf("Indicador") = "Total Aportes"
            drGraf("Valor") = mlngTotalAportes
            dtAportes.Rows.Add(drGraf)
            mdtGraficoAportes = dtAportes

            Dim dtSolicitudes As DataTable
            dtSolicitudes = New DataTable
            dtSolicitudes.Columns.Add(New DataColumn("Indicador", GetType(String)))
            dtSolicitudes.Columns.Add(New DataColumn("Valor", GetType(Long)))

            'dt.TableName = "Detalle"
            Dim drGrafi As DataRow
            drGrafi = dtSolicitudes.NewRow()
            drGrafi("Indicador") = "Solicitudes Autorizadas "
            drGrafi("Valor") = mlngSolicitudesAutorizadas
            dtSolicitudes.Rows.Add(drGrafi)
            drGrafi = dtSolicitudes.NewRow()
            drGrafi("Indicador") = "Solicitudes Rechazadas"
            drGrafi("Valor") = mlngSolicitudesRechazadas
            dtSolicitudes.Rows.Add(drGrafi)
            drGrafi = dtSolicitudes.NewRow()
            drGrafi("Indicador") = "Solicitudes Pendientes"
            drGrafi("Valor") = mlngSolicitudesPendientes
            dtSolicitudes.Rows.Add(drGrafi)
            drGrafi = dtSolicitudes.NewRow()
            drGrafi("Indicador") = "Total Solicitudes"
            drGrafi("Valor") = mlngTotalSolicitudes
            dtSolicitudes.Rows.Add(drGrafi)
            
            mdtGraficoSolicitudes = dtSolicitudes

        Catch ex As Exception
            EnviaError("CIndicadores:CargarIndicadores3->" & ex.Message)
        End Try
    End Sub
End Class
