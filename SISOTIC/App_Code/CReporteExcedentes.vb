Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CReporteExcedentes
    Implements IReporte
    Private mlngRutCliente As Long
    Private mstrRutClientes As String
    'Nombre de la empresa
    Private mstrNombreEmpresa As String
    'rut ejecutivo
    Private mlngRutEjecutivo As Long '= 6776083
    'nombre ejecutivo
    Private mstrNombreEjecutivo As String
    'codigo de la sucursal
    Private mintCodSucursal As Integer '= 1
    'nombre sucursal
    Private mstrNombreSucursal As String
    'año de asignacion de excedentes
    Private mintAgno As Integer '= 2009
    'saldo capacitacion
    Private mlngSaldoCap As Long
    'saldo reparto
    Private mlngSaldoRep As Long
    'saldo administracion
    Private mlngSaldoAdm As Long
    'saldo exc. capacitacion
    Private mlngSaldoExCap As Long
    'saldo exc. reparto
    Private mlngSaldoExRep As Long
    'abono exc. capacitacion
    Private mlngAbonoExCap As Long
    'abono exc. reparto
    Private mlngAbonoExRep As Long
    'abono administracion
    Private mlngAbonoAdm As Long
    'procentaje administacion
    Private mdblPorcAdm As Double
    'abono becas
    Private mlngAbonoBeca As Long
    'saldo de exc de capacitacion al final del año anterior
    Private mlngSaldoExcCapAnt As Long
    'asldo de exc. de reparto al final del año anterior
    Private mlngSaldoExcRepAnt As Long
    'costo otic par el año actual
    Private mlngCostoOticCompl As Long
    Private mlngTotalAsignar As Long
    Private mlngMontoTraspasable As Long
    Private mlngMontoNoTraspasable As Long
    Private mlngSaldoPorAsignar As Long
    'Listado de excedentes para guardar en la base de datos
    Private mdtListadoExcedentes As DataTable
    Private mobjSql As CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property RutClientes() As Long
        Get
            Return mstrRutClientes
        End Get
        Set(ByVal value As Long)
            mstrRutClientes = value
        End Set
    End Property
    Public Property NombreEmpresa() As String
        Get
            Return mstrNombreEmpresa
        End Get
        Set(ByVal value As String)
            mstrNombreEmpresa = value
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
    Public Property NombreEjecutivo() As String
        Get
            Return mstrNombreEjecutivo
        End Get
        Set(ByVal value As String)
            mstrNombreEjecutivo = value
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
    Public Property NombreSucursal() As String
        Get
            Return mstrNombreSucursal
        End Get
        Set(ByVal value As String)
            mstrNombreSucursal = value
        End Set
    End Property
    Public Property SaldoCap() As Long
        Get
            Return mlngSaldoCap
        End Get
        Set(ByVal value As Long)
            mlngSaldoCap = value
        End Set
    End Property
    Public Property SaldoRep() As Long
        Get
            Return mlngSaldoRep
        End Get
        Set(ByVal value As Long)
            mlngSaldoRep = value
        End Set
    End Property
    Public Property SaldoAdm() As Long
        Get
            Return mlngSaldoAdm
        End Get
        Set(ByVal value As Long)
            mlngSaldoAdm = value
        End Set
    End Property
    Public Property SaldoExCap() As Long
        Get
            Return mlngSaldoExCap
        End Get
        Set(ByVal value As Long)
            mlngSaldoExCap = value
        End Set
    End Property
    Public Property SaldoExRep() As Long
        Get
            SaldoExRep = mlngSaldoExcCapAnt
        End Get
        Set(ByVal value As Long)
            mlngSaldoExRep = value
        End Set
    End Property
    Public Property AbonoExCap() As Long
        Get
            Return mlngAbonoExCap
        End Get
        Set(ByVal value As Long)
            mlngAbonoExCap = value
        End Set
    End Property
    Public Property AbonoExRep() As Long
        Get
            Return mlngAbonoExRep
        End Get
        Set(ByVal value As Long)
            mlngAbonoExRep = value
        End Set
    End Property
    Public Property AbonoAdm() As Long
        Get
            Return mlngAbonoAdm
        End Get
        Set(ByVal value As Long)
            mlngAbonoAdm = value
        End Set
    End Property
    Public Property PorcAdm() As Double
        Get
            Return mdblPorcAdm * 100
        End Get
        Set(ByVal value As Double)
            mdblPorcAdm = value
        End Set
    End Property
    Public Property AbonoBeca() As Long
        Get
            Return mlngAbonoBeca
        End Get
        Set(ByVal value As Long)
            mlngAbonoBeca = value
        End Set
    End Property
    Public Property SaldoExcCapAnt() As Long
        Get
            Return mlngSaldoExcCapAnt
        End Get
        Set(ByVal value As Long)
            mlngSaldoExcCapAnt = value
        End Set
    End Property
    Public Property SaldoExcRepAnt() As Long
        Get
            Return mlngSaldoExcRepAnt
        End Get
        Set(ByVal value As Long)
            mlngSaldoExcRepAnt = value
        End Set
    End Property
    Public Property CostoOticCompl() As Long
        Get
            Return mlngCostoOticCompl
        End Get
        Set(ByVal value As Long)
            mlngCostoOticCompl = value
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
    Public Property ListadoExcedentes() As DataTable
        Get
            Return mdtListadoExcedentes
        End Get
        Set(ByVal value As DataTable)
            mdtListadoExcedentes = value
        End Set
    End Property
    Public Property TotalAsignar() As Long
        Get
            Return mlngTotalAsignar
        End Get
        Set(ByVal value As Long)
            mlngTotalAsignar = value
        End Set
    End Property
    Public Property MontoTraspasable() As Long
        Get
            Return mlngMontoTraspasable
        End Get
        Set(ByVal value As Long)
            mlngMontoTraspasable = value
        End Set
    End Property
    Public Property MontoNoTraspasable() As Long
        Get
            Return mlngMontoNoTraspasable
        End Get
        Set(ByVal value As Long)
            mlngMontoNoTraspasable = value
        End Set
    End Property
    Public Property SaldoPorAsignar() As Long
        Get
            Return mlngSaldoPorAsignar
        End Get
        Set(ByVal value As Long)
            mlngSaldoPorAsignar = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property
    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim dtConsulta As DataTable
            Dim i As Integer
            Dim intFilas As Integer
            Dim dtmInicio As Date
            Dim strNombreArchivo As String
            Dim dtmFin As Date
            'Dim lngCostoOticCompl As Long

            dtmInicio = DateSerial(mintAgno + 1, 1, 1)
            dtmFin = DateSerial(mintAgno + 1, 12, 31)

            mobjSql = New CSql


            dtConsulta = mobjSql.s_reporte_excedentes_para_otic_banca(mlngRutCliente, _
                                                       mstrNombreEmpresa, _
                                                       mintCodSucursal, _
                                                       mlngRutEjecutivo, _
                                                       mintAgno)
            intFilas = mobjSql.Registros

            If intFilas > 0 Then
                dtConsulta.Columns.Add("CostoOticCompl")
                dtConsulta.Columns.Add("MontoTraspasable")
                dtConsulta.Columns.Add("MontoNoTraspasable")
                dtConsulta.Columns.Add("TotalAsignar")
                dtConsulta.Columns.Add("SaldoPorAsignar")
                Dim dr As DataRow
                For Each dr In dtConsulta.Rows
                    mstrNombreEmpresa = dr("razon_social")
                    ' mlngRutCliente = RutLngAUsr(dr("rut_cliente"))
                    dr("rut_cliente") = RutLngAUsr(dr("rut_cliente"))
                    mstrNombreEjecutivo = dr("ejecutivo")
                    mstrNombreSucursal = dr("sucursal")
                    mlngSaldoCap = dr("SaldoCap")
                    mlngSaldoRep = dr("SaldoRep")
                    mlngSaldoAdm = dr("SaldoAdm")
                    mlngSaldoExCap = dr("SaldoExCap")
                    mlngSaldoExRep = dr("SaldoExRep")
                    mlngAbonoExCap = dr("AbonoExCap")
                    mlngAbonoExRep = dr("AbonoExRep")
                    mlngAbonoAdm = dr("AbonoAdm")
                    mdblPorcAdm = dr("PorcAdm")
                    mlngAbonoBeca = dr("AbonoBeca")
                    mlngSaldoExcCapAnt = dr("SaldoExcCapAnt")
                    mlngSaldoExcRepAnt = dr("SaldoExcRepAnt")
                    mlngCostoOticCompl = mobjSql.s_suma_costos_cursos_compl("costo_otic", mlngRutCliente, mintCodSucursal, mlngRutEjecutivo, dtmInicio, dtmFin)
                    'mlngCostoOticCompl = mobjSql.s_suma_costos_cursos_compl("costo_otic", CStr(dtConsulta.Rows(i)(1)), mintCodSucursal, mlngRutEjecutivo, dtmInicio, dtmFin)
                    dr("CostoOticCompl") = mlngCostoOticCompl
                    If dr("SaldoExcCapAnt") + dr("SaldoExcRepAnt") <= dr("CostoOticCompl") Then
                        dr("MontoTraspasable") = dr("SaldoExcCapAnt") + dr("SaldoExcRepAnt")
                        dr("MontoNoTraspasable") = 0
                    Else
                        dr("MontoTraspasable") = dr("CostoOticCompl")
                        dr("MontoNoTraspasable") = dr("SaldoExcCapAnt") + dr("SaldoExcRepAnt") - dr("CostoOticCompl")
                    End If
                    mlngMontoTraspasable = dr("MontoTraspasable")
                    mlngMontoNoTraspasable = dr("MontoNoTraspasable")
                    dr("TotalAsignar") = dr("SaldoCap") + dr("SaldoRep") + dr("SaldoAdm") + dr("MontoTraspasable") + dr("MontoNoTraspasable")
                    mlngTotalAsignar = dr("TotalAsignar")
                    'dr("SaldoPorAsignar") = dr("TotalAsignar") - (mlngAbonoExCap + mlngAbonoExRep + mlngAbonoAdm + mlngAbonoBeca)
                    dr("SaldoPorAsignar") = dr("TotalAsignar") - (dr("AbonoExCap") + dr("AbonoExRep") + dr("AbonoAdm") + dr("AbonoBeca"))
                    mlngSaldoPorAsignar = dr("SaldoPorAsignar")
                Next


                'dtConsulta.Rows(i)(0)("CostoOticCompl") = mlngCostoOticCompl   'Costo Otic estimado para el año actual
            End If
            'lngCostoOticCompl = mobjSql.s_suma_costos_cursos_compl("costo_otic", CStr(dtConsulta.Rows(i)(1)), 0, 0, dtmInicio, dtmFin)
            'dtConsulta.Rows(i)(0)("CostoOticCompl") = lngCostoOticCompl   'Costo Otic estimado para el año actual
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtConsulta.TableName = "Reporte Cursos Consolidado"
                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

            Return dtConsulta

            'ReDim dtReporte(intFilas - 1)
            ''asignar el resultado de la consulta al arreglo con campos
            'For i = 0 To intFilas - 1

            '    dtReporte(i) = CreateObject("Scripting.Dictionary")
            '    dtReporte(i).item("RazonSocial") = arrConsulta(0, i)
            '    dtReporte(i).item("RutCliente") = RutLngAUsr(arrConsulta(1, i))
            '    dtReporte(i).item("Ejecutivo") = arrConsulta(2, i)
            '    dtReporte(i).item("Sucursal") = arrConsulta(3, i)
            '    dtReporte(i).item("SaldoCap") = arrConsulta(4, i)      'Saldo al final del año anterior
            '    dtReporte(i).item("SaldoRep") = arrConsulta(5, i)      'Saldo al final del año anterior
            '    dtReporte(i).item("SaldoAdm") = arrConsulta(6, i)      'Saldo al final del año anterior
            '    dtReporte(i).item("SaldoExCap") = arrConsulta(7, i)    'Saldo actual
            '    dtReporte(i).item("SaldoExRep") = arrConsulta(8, i)    'Saldo actual
            '    dtReporte(i).item("AbonoExCap") = arrConsulta(9, i)    'Traspaso por excedente a excedentes de capacitacion
            '    dtReporte(i).item("AbonoExRep") = arrConsulta(10, i)   'Traspaso por excedente a excedentes de reparto
            '    dtReporte(i).item("AbonoAdm") = arrConsulta(11, i)     'Traspaso por excedente a administración
            '    dtReporte(i).item("TotalAsignar") = CDbl(arrConsulta(4, i)) + CDbl(arrConsulta(5, i)) + CDbl(arrConsulta(6, i)) + CDbl(arrConsulta(14, i)) + CDbl(arrConsulta(15, i))
            '    If CDbl(arrConsulta(12, i)) >= 0 And CDbl(arrConsulta(12, i)) <= 1 Then
            '        dtReporte(i).item("PorcAdm") = CDbl(arrConsulta(12, i)) * 100     'porc. administración
            '    Else
            '        dtReporte(i).item("PorcAdm") = CDbl(arrConsulta(12, i))
            '    End If
            '    'dtReporte(i).item("AbonoBeca") = arrConsulta(13, i)    'Traspaso por excedentes a becas
            '    '**|** Se muestra la cuenta beca real, cuenta 6
            '    dtReporte(i).item("AbonoBeca") = arrConsulta(13, i)    'Traspaso por excedentes a becas
            '    dtReporte(i).item("SaldoExcCapAnt") = arrConsulta(14, i)   'Saldo en excedenetes de capacitación al final del año anterior
            '    dtReporte(i).item("SaldoExcRepAnt") = arrConsulta(15, i)   'Saldo en excedenetes de reparto al final del año anterior
            '    'costo otic comprometido para el próximo año
            'lngCostoOticCompl = mobjSql.s_suma_costos_cursos_compl("costo_otic", CStr(dtConsulta.Rows(i)(1)), 0, 0, dtmInicio, dtmFin)
            'dtReporte.Rows(i)(0)("CostoOticCompl") = lngCostoOticCompl   'Costo Otic estimado para el año actual

            '    Next
            'Else
            '    dtReporte = Array()
            'End If

            'Consultar = dtReporte

        Catch ex As Exception
            EnviaError("CReporteExcedentes.vb:Consultar-->" & ex.Message)
        End Try
    End Function
  

    'Esta función inserta los datos de asignación de excedentes ingresada por el usuario
    Public Function GrabarDatos() As Boolean
        Try
            Dim i As Integer
            Dim lngFilas As Long
            Dim transaccion As DataTable
            'Datos de la transacción
            Dim nro_tran As Long
            Dim intCodCuenta As Integer
            Dim intCodTipoTran As Integer
            Dim intEstado As Integer
            Dim lngMonto As Long
            Dim lngAdmAsignacion As Long
            Dim strDescripcion As String
            Dim dtmFechaHora As Date
            Dim intNumTransaccion As Integer

            lngFilas = mdtListadoExcedentes.Rows.Count
            mobjSql = New CSql

            'abrir transacción
            Call mobjSql.InicioTransaccion()

            For i = 0 To lngFilas - 1
                'Pregunto si al menos uno de los tres valores es mayor que cero (Asignación a ExCap o ExRep o Adm o Beca)
                'If CLng(marrListadoExcedentes(i, 0)) > 0 Or CLng(marrListadoExcedentes(i, 1)) > 0 _
                '    Or CLng(marrListadoExcedentes(i, 2)) Or CLng(marrListadoExcedentes(i, 7)) > 0 Then
                '
                'Ingreso de abonos por excedentes
                '
                'NUEVO PERIODO
                dtmFechaHora = FechaMinAgno(mintAgno + 1)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "4") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                If intNumTransaccion = 0 Then 'No hay transaccion, insertar
                    If CLng(mlngAbonoExCap) > 0 Then
                        'If CLng(mdtListadoExcedentes.Rows(i)(9)) > 0 Then '(i, 0)' El monto de excedentes de cap. es mayor que cero
                        intCodCuenta = 4        'Cuenta Excedente de capacitacion
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mlngAbonoExCap) '(i, 0)
                        'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(9)) '(i, 0)
                        strDescripcion = "Abono por excedentes de capacitación"
                        dtmFechaHora = FechaMinAgno(mintAgno + 1)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mlngAbonoExCap) '(i, 0)
                    'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(9)) '(i, 0)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto) '(0, 0)
                End If
                dtmFechaHora = FechaMinAgno(mintAgno + 1)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "5") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then  'No hay transaccion, insertar
                    If CLng(mlngAbonoExRep) > 0 Then
                        'If CLng(mdtListadoExcedentes.Rows(i)(10)) > 0 Then '(i, 1) ' El monto de excedente de rep. es mayor que cero
                        intCodCuenta = 5        'Cuenta Excedente de reparto
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mlngAbonoExRep) '(i, 1)
                        'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(10)) '(i, 1)
                        strDescripcion = "Abono por excedentes de reparto"
                        dtmFechaHora = FechaMinAgno(mintAgno + 1)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mlngAbonoExRep) '(i, 1)
                    'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(10)) '(i, 1)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                '**|**Cuenta Becas (6)
                dtmFechaHora = FechaMinAgno(mintAgno + 1)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "6") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then 'No hay transaccion, insertar
                    If CLng(mlngAbonoBeca) > 0 Then
                        'If CLng(mdtListadoExcedentes.Rows(i)(13)) > 0 Then  '(i, 7)' El monto de becas es mayor que cero
                        intCodCuenta = 6        'Cuenta Becas
                        intCodTipoTran = 3      'Ingreso de Becas
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mlngAbonoBeca) '(i, 7)
                        'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(13)) '(i, 7)
                        strDescripcion = "Abono por traspaso de excedentes"
                        dtmFechaHora = FechaMinAgno(mintAgno + 1)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mlngAbonoBeca) '(i, 7)
                    'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(13)) '(i, 7)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If

                '
                'becas y administración de asignación(No he quitado la asignación de becas **|**)
                'Se asigna cero en el campo beca **|**, pasó a transacción
                transaccion = mobjSql.s_beca(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), mintAgno + 1) '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then  'No hay beca ingrsada en ese año, insertar
                    If CLng(mlngAbonoAdm) > 0 Then
                        'If CLng(mdtListadoExcedentes.Rows(i)(11)) > 0 Then '(i, 2)' El monto de ing. por excedente a becas es mayor que cero
                        lngMonto = CLng(mlngAbonoBeca) '(i, 7)
                        'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(13)) '(i, 7)
                        lngAdmAsignacion = CLng(mlngAbonoAdm) '(i, 2)
                        'lngAdmAsignacion = CLng(mdtListadoExcedentes.Rows(i)(11)) '(i, 2)
                        Call mobjSql.i_beca(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), mintAgno + 1, 0, lngAdmAsignacion) '(i, 6)
                    End If
                Else 'Si hay becas asignadas ese año, modifico
                    lngMonto = CLng(mlngAbonoBeca) '(i, 7)
                    lngAdmAsignacion = CLng(mlngAbonoAdm) '(i, 2)
                    'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(13)) '(i, 7)
                    'lngAdmAsignacion = CLng(mdtListadoExcedentes.Rows(i)(11)) '(i, 2)
                    Call mobjSql.u_monto_beca(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), mintAgno + 1, 0, lngAdmAsignacion) '(i, 6)
                End If

                '
                'Ingreso de cargos por excedentes
                '
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "1") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then  'No hay transaccion, insertar
                    If CLng(mlngSaldoCap) > 0 Then
                        'If CLng(mdtListadoExcedentes.Rows(i)(4)) > 0 Then ' El monto de saldo de cap. es mayor que cero '(i, 3)
                        intCodCuenta = 1        'Cuenta de capacitación
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mlngSaldoCap) * -1 '(i, 3)
                        'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(4)) * -1 '(i, 3)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mlngSaldoCap) * -1 '(i, 3)
                    'lngMonto = CLng(mdtListadoExcedentes.Rows(i)(4)) * -1 '(i, 3)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "2") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then  'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(i)(5)) > 0 Then ' El monto de saldo de rep. es mayor que cero '(i, 4)
                        intCodCuenta = 2        'Cuenta Excedente de reparto
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(i)(5)) * -1 '(i, 4)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(i)(5)) * -1 '(i, 4)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "3") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then  'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(i)(6)) > 0 Then ' El monto de saldo de adm es mayor que cero '(i, 5)
                        intCodCuenta = 3        'Cuenta administración
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(i)(6)) * -1 '(i, 5)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(i)(6)) * -1 '(i, 5)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "4") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(i)(14)) > 0 Then '(i, 8)' El monto de saldo de exc de cap es mayor que cero
                        intCodCuenta = 4        'Cuenta Exc.Cap
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(i)(14)) * -1 '(i, 8)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(i)(14)) * -1 '(i, 8)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), dtmFechaHora, "5") '(i, 6)
                intNumTransaccion = mobjSql.Registros
                'If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                If intNumTransaccion = 0 Then  'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(i)(15)) > 0 Then '(i, 9) ' El monto de saldo de exc de rep es mayor que cero
                        intCodCuenta = 5        'Cuenta Exc.Rep
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(i)(15)) * -1 '(i, 9)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(i)(1)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(i)(15)) * -1 '(i, 9)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                'End If
            Next

            'commit
            Call mobjSql.FinTransaccion()

            GrabarDatos = True
            Exit Function


        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CReporteExcedentes.vb:Consultar-->" & ex.Message)
        End Try
       
    End Function
    Public Function GrabarDatos2() As Boolean
        Try
            Dim i As Integer
            Dim lngFilas As Long
            Dim transaccion As DataTable
            'Datos de la transacción
            Dim nro_tran As Long
            Dim intCodCuenta As Integer
            Dim intCodTipoTran As Integer
            Dim intEstado As Integer
            Dim lngMonto As Long
            Dim lngAdmAsignacion As Long
            Dim strDescripcion As String
            Dim dtmFechaHora As Date
            lngFilas = mdtListadoExcedentes.Rows.Count
            mobjSql = New CSql

            'abrir transacción
            Call mobjSql.InicioTransaccion()

            For i = 0 To lngFilas - 1
                'Pregunto si al menos uno de los tres valores es mayor que cero (Asignación a ExCap o ExRep o Adm o Beca)
                'If CLng(marrListadoExcedentes(i, 0)) > 0 Or CLng(marrListadoExcedentes(i, 1)) > 0 _
                '    Or CLng(marrListadoExcedentes(i, 2)) Or CLng(marrListadoExcedentes(i, 7)) > 0 Then
                '
                'Ingreso de abonos por excedentes
                '
                'NUEVO PERIODO
                dtmFechaHora = FechaMinAgno(mintAgno + 1)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "4") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(0)(i)) > 0 Then '(i, 0)' El monto de excedentes de cap. es mayor que cero
                        intCodCuenta = 4        'Cuenta Excedente de capacitacion
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(0)(i)) '(i, 0)
                        strDescripcion = "Abono por excedentes de capacitación"
                        dtmFechaHora = FechaMinAgno(mintAgno + 1)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(0)(i)) '(i, 0)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto) '(0, 0)
                End If
                dtmFechaHora = FechaMinAgno(mintAgno + 1)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "5") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(1)(i)) > 0 Then '(i, 1) ' El monto de excedente de rep. es mayor que cero
                        intCodCuenta = 5        'Cuenta Excedente de reparto
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(1)(i)) '(i, 1)
                        strDescripcion = "Abono por excedentes de reparto"
                        dtmFechaHora = FechaMinAgno(mintAgno + 1)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(1)(i)) '(i, 1)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                '**|**Cuenta Becas (6)
                dtmFechaHora = FechaMinAgno(mintAgno + 1)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "6") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(7)(i)) > 0 Then  '(i, 7)' El monto de becas es mayor que cero
                        intCodCuenta = 6        'Cuenta Becas
                        intCodTipoTran = 3      'Ingreso de Becas
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(7)(i)) '(i, 7)
                        strDescripcion = "Abono por traspaso de excedentes"
                        dtmFechaHora = FechaMinAgno(mintAgno + 1)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(7)(i)) '(i, 7)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If

                '
                'becas y administración de asignación(No he quitado la asignación de becas **|**)
                'Se asigna cero en el campo beca **|**, pasó a transacción
                transaccion = mobjSql.s_beca(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), mintAgno + 1) '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay beca ingrsada en ese año, insertar
                    If CLng(mdtListadoExcedentes.Rows(2)(i)) > 0 Then '(i, 2)' El monto de ing. por excedente a becas es mayor que cero
                        lngMonto = CLng(mdtListadoExcedentes.Rows(7)(i)) '(i, 7)
                        lngAdmAsignacion = CLng(mdtListadoExcedentes.Rows(2)(i)) '(i, 2)
                        Call mobjSql.i_beca(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), mintAgno + 1, 0, lngAdmAsignacion) '(i, 6)
                    End If
                Else 'Si hay becas asignadas ese año, modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(7)(i)) '(i, 7)
                    lngAdmAsignacion = CLng(mdtListadoExcedentes.Rows(2)(i)) '(i, 2)
                    Call mobjSql.u_monto_beca(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), mintAgno + 1, 0, lngAdmAsignacion) '(i, 6)
                End If

                '
                'Ingreso de cargos por excedentes
                '
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "1") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(3)(i)) > 0 Then ' El monto de saldo de cap. es mayor que cero '(i, 3)
                        intCodCuenta = 1        'Cuenta de capacitación
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(3)(i)) * -1 '(i, 3)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(3)(i)) * -1 '(i, 3)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "2") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(4)(i)) > 0 Then ' El monto de saldo de rep. es mayor que cero '(i, 4)
                        intCodCuenta = 2        'Cuenta Excedente de reparto
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(4)(i)) * -1 '(i, 4)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(4)(i)) * -1 '(i, 4)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "3") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(5)(i)) > 0 Then ' El monto de saldo de adm es mayor que cero '(i, 5)
                        intCodCuenta = 3        'Cuenta administración
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(5)(i)) * -1 '(i, 5)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(5)(i)) * -1 '(i, 5)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "4") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(8)(i)) > 0 Then '(i, 8)' El monto de saldo de exc de cap es mayor que cero
                        intCodCuenta = 4        'Cuenta Exc.Cap
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(8)(i)) * -1 '(i, 8)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(8)(i)) * -1 '(i, 8)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                dtmFechaHora = FechaMaxAgno(mintAgno)
                transaccion = mobjSql.s_transaccion_excedente(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), dtmFechaHora, "5") '(i, 6)
                If TamanoArreglo1(transaccion) = 0 Then 'No hay transaccion, insertar
                    If CLng(mdtListadoExcedentes.Rows(9)(i)) > 0 Then '(i, 9) ' El monto de saldo de exc de rep es mayor que cero
                        intCodCuenta = 5        'Cuenta Exc.Rep
                        intCodTipoTran = 3      'Ingreso de excedentes
                        intEstado = 2           'Autorizada
                        lngMonto = CLng(mdtListadoExcedentes.Rows(9)(i)) * -1 '(i, 9)
                        strDescripcion = "Traspaso a excedentes"
                        dtmFechaHora = FechaMaxAgno(mintAgno)
                        nro_tran = mobjSql.i_transaccion(RutUsrALng(mdtListadoExcedentes.Rows(6)(i)), intCodCuenta, intCodTipoTran, _
                                      intEstado, lngMonto, strDescripcion, 0, _
                                      0, dtmFechaHora) '(i, 6)
                    End If
                Else 'Si hay transacción la modifico
                    lngMonto = CLng(mdtListadoExcedentes.Rows(9)(i)) * -1 '(i, 9)
                    Call mobjSql.u_monto_transaccion(CLng(transaccion.Rows(0)(0)), lngMonto)
                End If
                'End If
            Next

            'commit
            Call mobjSql.FinTransaccion()

            GrabarDatos2 = True
            Exit Function


        Catch ex As Exception
            Call mobjSql.RollBackTransaccion()
            EnviaError("CReporteExcedentes.vb:Consultar-->" & ex.Message)
        End Try

    End Function

    
End Class
