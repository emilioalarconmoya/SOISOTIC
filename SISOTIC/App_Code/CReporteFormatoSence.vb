Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteFormatoSence
    Implements IReporte
    Private mobjSql As CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mintTipo As Integer
    Private mlngAgno As Long
    Private mdtCapacitacion As DataTable
    Private mdtReparto As DataTable
    Private mdtExcCapacitacion As DataTable
    Private mdtExcReparto As DataTable
    Private mdtBecas As DataTable
    Private mdtAportes As DataTable
    Private mdtEmpresas As DataTable
    Public Property Agno() As Long
        Get
            Return mlngAgno
        End Get
        Set(ByVal value As Long)
            mlngAgno = value
        End Set
    End Property
    Public Property Capacitacion() As DataTable
        Get
            Return mdtCapacitacion
        End Get
        Set(ByVal value As DataTable)
            mdtCapacitacion = value
        End Set
    End Property
    Public Property Reparto() As DataTable
        Get
            Return mdtReparto
        End Get
        Set(ByVal value As DataTable)
            mdtReparto = value
        End Set
    End Property
    Public Property ExcCapacitacion() As DataTable
        Get
            Return mdtExcCapacitacion
        End Get
        Set(ByVal value As DataTable)
            mdtExcCapacitacion = value
        End Set
    End Property
    Public Property ExcReparto() As DataTable
        Get
            Return mdtExcReparto
        End Get
        Set(ByVal value As DataTable)
            mdtReparto = value
        End Set
    End Property
    Public Property Becas() As DataTable
        Get
            Return mdtBecas
        End Get
        Set(ByVal value As DataTable)
            mdtBecas = value
        End Set
    End Property
    Public Property Aportes() As DataTable
        Get
            Return mdtAportes
        End Get
        Set(ByVal value As DataTable)
            mdtAportes = value
        End Set
    End Property
    Public Property Tipo() As Integer
        Get
            Return mintTipo
        End Get
        Set(ByVal value As Integer)
            mintTipo = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return mstrXml
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
        Dim lngPorcentaje, lngSumar, lngFilas, lngGastoAdm, lngPorcAdm, lngAportesNetos, lngTotal, lngSaldoIni, _
        lngExcedentes, lngCompletos, lngParciales, lngComplemen, lngGastosVyT, lngCantCursosCompletos, _
        lngCantCursosParciales, lngCantCursosComplementarios, lngSaldoAnterior As Long
        Dim dtmInicioAgno As Date
        Dim strNombreArchivo As String
        Dim dtAdmAnual As DataTable
        Dim dr, drCalculos, drCapacitacion, drReparto, drExcCapacitacion, drExcReparto, drBecas, drAportes As DataRow
        Select Case mintTipo
            Case 1
                mobjSql = New CSql
                mdtCapacitacion = New DataTable
                mdtCapacitacion.Columns.Add("RUT EMPRESA")
                mdtCapacitacion.Columns.Add("D.V.")
                mdtCapacitacion.Columns.Add("RAZON SOCIAL EMPRESA")
                mdtCapacitacion.Columns.Add("TOTAL APORTES DEL PERIODO")
                mdtCapacitacion.Columns.Add("OTROS INGRESOS")
                mdtCapacitacion.Columns.Add("MONTO GASTOS ADMINIST. DEL PERIODO")
                mdtCapacitacion.Columns.Add("% GASTOS ADMIN. DEL PERIODO")
                mdtCapacitacion.Columns.Add("CANTIDAD DE CURSOS NORMALES")
                mdtCapacitacion.Columns.Add("GASTO CURSOS NORMALES DEL PERIODO")
                mdtCapacitacion.Columns.Add("CANTIDAD DE CURSOS PARCIALES")
                mdtCapacitacion.Columns.Add("GASTO CURSOS PARCIALES DEL PERIODO")
                mdtCapacitacion.Columns.Add("CANTIDAD DE CURSOS COMPLEMENTARIOS")
                mdtCapacitacion.Columns.Add("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO")
                mdtCapacitacion.Columns.Add("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO")
                mdtCapacitacion.Columns.Add("TOTAL GASTOS DE CUENTA CAPACITACION DEL PERIODO")
                mdtCapacitacion.Columns.Add("TRASPASOS DIRECTOS A BECAS")
                mdtCapacitacion.Columns.Add("OTROS GASTOS")
                mdtCapacitacion.Columns.Add("SALDO FINAL =  EXCEDENTES  CAPACITACION   DEL PERIODO")
                mdtEmpresas = mobjSql.s_empresas_con_mov(mlngAgno)
                mlngFilas = mobjSql.Registros
                If mlngFilas > 0 Then
                    For Each dr In mdtEmpresas.Rows
                        dtAdmAnual = mobjSql.s_porc_adm_anual_aportes(mlngAgno, dr("rut"), 1)
                        lngFilas = mobjSql.Registros
                        If lngFilas > 0 Then
                            For Each drCalculos In dtAdmAnual.Rows
                                lngPorcentaje = (drCalculos.Item(0) * 100) / drCalculos.Item(1)
                                lngSumar = lngSumar + lngPorcentaje
                                lngGastoAdm = lngGastoAdm + drCalculos.Item(0)
                                lngAportesNetos = lngAportesNetos + drCalculos.Item(2)
                            Next
                            lngPorcAdm = (lngSumar) / lngFilas
                            lngPorcAdm = FormatNumber(lngPorcAdm, 2)
                        Else
                            lngPorcAdm = 0
                        End If
                        lngCantCursosCompletos = mobjSql.s_suma_cursos_completos_sin_vyt(dr("rut"), 1, mlngAgno)
                        lngCantCursosParciales = mobjSql.s_suma_cursos_parciales_sin_vyt(dr("rut"), 1, mlngAgno)
                        lngCantCursosComplementarios = mobjSql.s_suma_cursos_complementarios_sin_vyt(dr("rut"), 1, mlngAgno)
                        lngCompletos = mobjSql.s_gastos_cursos_completos_sin_vyt(dr("rut"), 1, mlngAgno)
                        lngParciales = mobjSql.s_gastos_cursos_parciales_sin_vyt(dr("rut"), 1, mlngAgno)
                        lngComplemen = mobjSql.s_gastos_cursos_complementarios_sin_vyt(dr("rut"), 1, mlngAgno)
                        lngGastosVyT = mobjSql.s_gastos_vyt(dr("rut"), 1, mlngAgno)
                        lngTotal = lngCompletos + lngParciales + lngComplemen + lngGastosVyT
                        lngExcedentes = lngAportesNetos - lngTotal
                        drCapacitacion = mdtCapacitacion.NewRow
                        drCapacitacion("RUT EMPRESA") = dr("rut")
                        drCapacitacion("D.V.") = digito_verificador(dr("rut"))
                        drCapacitacion("RAZON SOCIAL EMPRESA") = mobjSql.s_razon_social_cliente(dr("rut"))
                        drCapacitacion("TOTAL APORTES DEL PERIODO") = lngAportesNetos
                        drCapacitacion("OTROS INGRESOS") = 0
                        drCapacitacion("MONTO GASTOS ADMINIST. DEL PERIODO") = lngGastoAdm
                        drCapacitacion("% GASTOS ADMIN. DEL PERIODO") = lngPorcAdm
                        drCapacitacion("CANTIDAD DE CURSOS NORMALES") = lngCantCursosCompletos
                        drCapacitacion("GASTO CURSOS NORMALES DEL PERIODO") = lngCompletos
                        drCapacitacion("CANTIDAD DE CURSOS PARCIALES") = lngCantCursosParciales
                        drCapacitacion("GASTO CURSOS PARCIALES DEL PERIODO") = lngParciales
                        drCapacitacion("CANTIDAD DE CURSOS COMPLEMENTARIOS") = lngCantCursosComplementarios
                        drCapacitacion("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO") = lngComplemen
                        drCapacitacion("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO") = lngGastosVyT
                        drCapacitacion("TOTAL GASTOS DE CUENTA CAPACITACION DEL PERIODO") = lngTotal
                        drCapacitacion("TRASPASOS DIRECTOS A BECAS") = 0
                        drCapacitacion("OTROS GASTOS") = 0
                        drCapacitacion("SALDO FINAL =  EXCEDENTES  CAPACITACION   DEL PERIODO") = lngExcedentes
                        mdtCapacitacion.Rows.Add(drCapacitacion)
                        lngPorcentaje = 0
                        lngSumar = 0
                        lngGastoAdm = 0
                        lngAportesNetos = 0
                        lngPorcAdm = 0
                    Next
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        mdtCapacitacion.TableName = "Comportamiento cuenta de capacitación"
                        ConvierteDTaCSV(mdtCapacitacion, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
                mobjSql = Nothing
            Case 2
                mobjSql = New CSql
                mdtReparto = New DataTable
                mdtReparto.Columns.Add("RUT EMPRESA")
                mdtReparto.Columns.Add("D.V.")
                mdtReparto.Columns.Add("RAZON SOCIAL EMPRESA")
                mdtReparto.Columns.Add("TOTAL APORTES DEL PERIODO")
                mdtReparto.Columns.Add("OTROS INGRESOS")
                mdtReparto.Columns.Add("MONTO GASTOS ADMINIST. DEL PERIODO")
                mdtReparto.Columns.Add("% GASTOS ADMIN. DEL PERIODO")
                mdtReparto.Columns.Add("CANTIDAD DE CURSOS NORMALES")
                mdtReparto.Columns.Add("GASTO CURSOS NORMALES DEL PERIODO")
                mdtReparto.Columns.Add("CANTIDAD DE CURSOS PARCIALES")
                mdtReparto.Columns.Add("GASTO CURSOS PARCIALES DEL PERIODO")
                mdtReparto.Columns.Add("CANTIDAD DE CURSOS COMPLEMENTARIOS")
                mdtReparto.Columns.Add("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO")
                mdtReparto.Columns.Add("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO")
                mdtReparto.Columns.Add("TOTAL GASTOS DE CUENTA REPARTO  DEL PERIODO")
                mdtReparto.Columns.Add("EMPRESA BENEFICIADAS")
                mdtReparto.Columns.Add("SALDO FINAL = EXCEDENTES CUENTA DE REPARTO DEL PERIODO")
                mdtEmpresas = mobjSql.s_empresas_con_mov(mlngAgno)
                mlngFilas = mobjSql.Registros
                If mlngFilas > 0 Then
                    For Each dr In mdtEmpresas.Rows
                        dtAdmAnual = mobjSql.s_porc_adm_anual_aportes(mlngAgno, dr("rut"), 2)
                        lngFilas = mobjSql.Registros
                        If lngFilas > 0 Then
                            For Each drCalculos In dtAdmAnual.Rows
                                lngPorcentaje = (drCalculos.Item(0) * 100) / drCalculos.Item(1)
                                lngSumar = lngSumar + lngPorcentaje
                                lngGastoAdm = lngGastoAdm + drCalculos.Item(0)
                                lngAportesNetos = lngAportesNetos + drCalculos.Item(2)
                            Next
                            lngPorcAdm = (lngSumar) / lngFilas
                            lngPorcAdm = FormatNumber(lngPorcAdm, 2)
                        Else
                            lngPorcAdm = 0
                        End If
                        lngCantCursosCompletos = mobjSql.s_suma_cursos_completos_sin_vyt(dr("rut"), 2, mlngAgno)
                        lngCantCursosParciales = mobjSql.s_suma_cursos_parciales_sin_vyt(dr("rut"), 2, mlngAgno)
                        lngCantCursosComplementarios = mobjSql.s_suma_cursos_complementarios_sin_vyt(dr("rut"), 2, mlngAgno)
                        lngCompletos = mobjSql.s_gastos_cursos_completos_sin_vyt(dr("rut"), 2, mlngAgno)
                        lngParciales = mobjSql.s_gastos_cursos_parciales_sin_vyt(dr("rut"), 2, mlngAgno)
                        lngComplemen = mobjSql.s_gastos_cursos_complementarios_sin_vyt(dr("rut"), 2, mlngAgno)
                        lngGastosVyT = mobjSql.s_gastos_vyt(dr("rut"), 2, mlngAgno)
                        lngTotal = lngCompletos + lngParciales + lngComplemen + lngGastosVyT
                        lngExcedentes = lngAportesNetos - lngTotal
                        drReparto = mdtReparto.NewRow
                        drReparto("RUT EMPRESA") = dr("rut")
                        drReparto("D.V.") = digito_verificador(dr("rut"))
                        drReparto("RAZON SOCIAL EMPRESA") = mobjSql.s_razon_social_cliente(dr("rut"))
                        drReparto("TOTAL APORTES DEL PERIODO") = lngAportesNetos
                        drReparto("OTROS INGRESOS") = 0
                        drReparto("MONTO GASTOS ADMINIST. DEL PERIODO") = lngGastoAdm
                        drReparto("% GASTOS ADMIN. DEL PERIODO") = lngPorcAdm
                        drReparto("CANTIDAD DE CURSOS NORMALES") = lngCantCursosCompletos
                        drReparto("GASTO CURSOS NORMALES DEL PERIODO") = lngCompletos
                        drReparto("CANTIDAD DE CURSOS PARCIALES") = lngCantCursosParciales
                        drReparto("GASTO CURSOS PARCIALES DEL PERIODO") = lngParciales
                        drReparto("CANTIDAD DE CURSOS COMPLEMENTARIOS") = lngCantCursosComplementarios
                        drReparto("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO") = lngComplemen
                        drReparto("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO") = lngGastosVyT
                        drReparto("TOTAL GASTOS DE CUENTA REPARTO  DEL PERIODO") = lngTotal
                        drReparto("EMPRESA BENEFICIADAS") = ""
                        drReparto("SALDO FINAL = EXCEDENTES CUENTA DE REPARTO DEL PERIODO") = lngExcedentes
                        mdtReparto.Rows.Add(drReparto)
                        lngPorcentaje = 0
                        lngSumar = 0
                        lngGastoAdm = 0
                        lngAportesNetos = 0
                        lngPorcAdm = 0
                    Next
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        mdtReparto.TableName = "Comportamiento cuenta de reparto"
                        ConvierteDTaCSV(mdtReparto, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
                mobjSql = Nothing
            Case 3
                mobjSql = New CSql
                mdtExcCapacitacion = New DataTable
                mdtExcCapacitacion.Columns.Add("RUT EMPRESA")
                mdtExcCapacitacion.Columns.Add("D.V.")
                mdtExcCapacitacion.Columns.Add("RAZON SOCIAL EMPRESA")
                mdtExcCapacitacion.Columns.Add("SALDO INICIAL CTA. DE EXCEDENTES")
                mdtExcCapacitacion.Columns.Add("OTROS INGRESOS")
                mdtExcCapacitacion.Columns.Add("CANTIDAD DE CURSOS NORMALES")
                mdtExcCapacitacion.Columns.Add("GASTO CURSOS NORMALES DEL PERIODO")
                mdtExcCapacitacion.Columns.Add("CANTIDAD DE CURSOS PARCIALES")
                mdtExcCapacitacion.Columns.Add("GASTO CURSOS PARCIALES DEL PERIODO")
                mdtExcCapacitacion.Columns.Add("CANTIDAD DE CURSOS COMPLEMENTARIOS")
                mdtExcCapacitacion.Columns.Add("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO")
                mdtExcCapacitacion.Columns.Add("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO")
                mdtExcCapacitacion.Columns.Add("TOTAL GASTOS EXCEDENTES CAPACITACION DEL PERIODO")
                mdtExcCapacitacion.Columns.Add("SALDO FINAL PARA BECAS DE CAPACITACION PROXIMO PERIODO")
                mdtEmpresas = mobjSql.s_empresas_con_mov(mlngAgno)
                mlngFilas = mobjSql.Registros
                If mlngFilas > 0 Then
                    For Each dr In mdtEmpresas.Rows
                        lngCantCursosCompletos = mobjSql.s_suma_cursos_completos_sin_vyt(dr("rut"), 4, mlngAgno)
                        lngCantCursosParciales = mobjSql.s_suma_cursos_parciales_sin_vyt(dr("rut"), 4, mlngAgno)
                        lngCantCursosComplementarios = mobjSql.s_suma_cursos_complementarios_sin_vyt(dr("rut"), 4, mlngAgno)
                        lngCompletos = mobjSql.s_gastos_cursos_completos_sin_vyt(dr("rut"), 4, mlngAgno)
                        lngParciales = mobjSql.s_gastos_cursos_parciales_sin_vyt(dr("rut"), 4, mlngAgno)
                        lngComplemen = mobjSql.s_gastos_cursos_complementarios_sin_vyt(dr("rut"), 4, mlngAgno)
                        lngGastosVyT = mobjSql.s_gastos_vyt(dr("rut"), 4, mlngAgno)
                        lngTotal = lngCompletos + lngParciales + lngComplemen + lngGastosVyT
                        'Consulta por el saldo al 01/01
                        dtmInicioAgno = DateSerial(mlngAgno, 1, 1)
                        lngSaldoIni = mobjSql.s_saldo_inicial_por_cuenta(4, dr("rut"), dtmInicioAgno)
                        lngExcedentes = lngSaldoIni - lngTotal
                        drExcCapacitacion = mdtExcCapacitacion.NewRow
                        drExcCapacitacion("RUT EMPRESA") = dr("rut")
                        drExcCapacitacion("D.V.") = digito_verificador(dr("rut"))
                        drExcCapacitacion("RAZON SOCIAL EMPRESA") = mobjSql.s_razon_social_cliente(dr("rut"))
                        drExcCapacitacion("SALDO INICIAL CTA. DE EXCEDENTES") = lngSaldoIni
                        drExcCapacitacion("OTROS INGRESOS") = 0
                        drExcCapacitacion("CANTIDAD DE CURSOS NORMALES") = lngCantCursosCompletos
                        drExcCapacitacion("GASTO CURSOS NORMALES DEL PERIODO") = lngCompletos
                        drExcCapacitacion("CANTIDAD DE CURSOS PARCIALES") = lngCantCursosParciales
                        drExcCapacitacion("GASTO CURSOS PARCIALES DEL PERIODO") = lngParciales
                        drExcCapacitacion("CANTIDAD DE CURSOS COMPLEMENTARIOS") = lngCantCursosComplementarios
                        drExcCapacitacion("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO") = lngComplemen
                        drExcCapacitacion("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO") = lngGastosVyT
                        drExcCapacitacion("TOTAL GASTOS EXCEDENTES CAPACITACION DEL PERIODO") = lngTotal
                        drExcCapacitacion("SALDO FINAL PARA BECAS DE CAPACITACION PROXIMO PERIODO") = lngExcedentes
                        mdtExcCapacitacion.Rows.Add(drExcCapacitacion)
                    Next
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        mdtExcCapacitacion.TableName = "Comportamiento cuenta de excedente capacitación"
                        ConvierteDTaCSV(mdtExcCapacitacion, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
                mobjSql = Nothing
            Case 4
                mobjSql = New CSql
                mdtExcReparto = New DataTable
                mdtExcReparto.Columns.Add("RUT EMPRESA")
                mdtExcReparto.Columns.Add("D.V.")
                mdtExcReparto.Columns.Add("RAZON SOCIAL EMPRESA")
                mdtExcReparto.Columns.Add("SALDO INICIAL DE EXCEDENTES DEL  PERIODO")
                mdtExcReparto.Columns.Add("OTROS INGRESOS")
                mdtExcReparto.Columns.Add("CANTIDAD DE CURSOS NORMALES")
                mdtExcReparto.Columns.Add("GASTO CURSOS NORMALES DEL PERIODO")
                mdtExcReparto.Columns.Add("CANTIDAD DE CURSOS PARCIALES")
                mdtExcReparto.Columns.Add("GASTO CURSOS PARCIALES DEL PERIODO")
                mdtExcReparto.Columns.Add("CANTIDAD DE CURSOS COMPLEMENTARIOS")
                mdtExcReparto.Columns.Add("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO")
                mdtExcReparto.Columns.Add("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO")
                mdtExcReparto.Columns.Add("TOTAL GASTOS EXCEDENTES DE REPARTO DEL PERIODO")
                mdtExcReparto.Columns.Add("RUT EMPRESA BENEFICIADA")
                mdtExcReparto.Columns.Add("SALDO FINAL PARA BECAS DE CAPACITACION PROXIMO PERIODO")
                mdtEmpresas = mobjSql.s_empresas_con_mov(mlngAgno)
                mlngFilas = mobjSql.Registros
                If mlngFilas > 0 Then
                    For Each dr In mdtEmpresas.Rows
                        lngCantCursosCompletos = mobjSql.s_suma_cursos_completos_sin_vyt(dr("rut"), 5, mlngAgno)
                        lngCantCursosParciales = mobjSql.s_suma_cursos_parciales_sin_vyt(dr("rut"), 5, mlngAgno)
                        lngCantCursosComplementarios = mobjSql.s_suma_cursos_complementarios_sin_vyt(dr("rut"), 5, mlngAgno)
                        lngCompletos = mobjSql.s_gastos_cursos_completos_sin_vyt(dr("rut"), 5, mlngAgno)
                        lngParciales = mobjSql.s_gastos_cursos_parciales_sin_vyt(dr("rut"), 5, mlngAgno)
                        lngComplemen = mobjSql.s_gastos_cursos_complementarios_sin_vyt(dr("rut"), 5, mlngAgno)
                        lngGastosVyT = mobjSql.s_gastos_vyt(dr("rut"), 5, mlngAgno)
                        lngTotal = lngCompletos + lngParciales + lngComplemen + lngGastosVyT
                        dtmInicioAgno = DateSerial(mlngAgno, 1, 1)
                        lngSaldoIni = mobjSql.s_saldo_inicial_por_cuenta(5, dr("rut"), dtmInicioAgno)
                        lngExcedentes = lngSaldoIni - lngTotal
                        drExcReparto = mdtExcReparto.NewRow
                        drExcReparto("RUT EMPRESA") = dr("rut")
                        drExcReparto("D.V.") = digito_verificador(dr("rut"))
                        drExcReparto("RAZON SOCIAL EMPRESA") = mobjSql.s_razon_social_cliente(dr("rut"))
                        drExcReparto("SALDO INICIAL DE EXCEDENTES DEL  PERIODO") = lngSaldoIni
                        drExcReparto("OTROS INGRESOS") = 0
                        drExcReparto("CANTIDAD DE CURSOS NORMALES") = lngCantCursosCompletos
                        drExcReparto("GASTO CURSOS NORMALES DEL PERIODO") = lngCompletos
                        drExcReparto("CANTIDAD DE CURSOS PARCIALES") = lngCantCursosParciales
                        drExcReparto("GASTO CURSOS PARCIALES DEL PERIODO") = lngParciales
                        drExcReparto("CANTIDAD DE CURSOS COMPLEMENTARIOS") = lngCantCursosComplementarios
                        drExcReparto("GASTO CURSOS COMPLEMENTARIOS DEL PERIODO") = lngComplemen
                        drExcReparto("GASTOS POR VIATICOS Y TRASLADOS DEL PERIODO") = lngGastosVyT
                        drExcReparto("TOTAL GASTOS EXCEDENTES DE REPARTO DEL PERIODO") = lngTotal
                        drExcReparto("RUT EMPRESA BENEFICIADA") = ""
                        drExcReparto("SALDO FINAL PARA BECAS DE CAPACITACION PROXIMO PERIODO") = lngExcedentes
                        mdtExcReparto.Rows.Add(drExcReparto)
                    Next
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        mdtExcReparto.TableName = "Comportamiento cuenta de excedente de reparto"
                        ConvierteDTaCSV(mdtExcReparto, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
                mobjSql = Nothing
            Case 5
                mobjSql = New CSql
                mdtBecas = New DataTable
                mdtBecas.Columns.Add("RUT EMPRESA")
                mdtBecas.Columns.Add("D.V.")
                mdtBecas.Columns.Add("RAZON SOCIAL EMPRESA")
                mdtBecas.Columns.Add("SALDO AÑOS ANTERIORES")
                mdtBecas.Columns.Add("SALDO CTA. EXCEDENTE CAP.")
                mdtBecas.Columns.Add("SALDO CTA. EXCEDENTE REP.")
                mdtBecas.Columns.Add("TRASPASOS POR MANDATO")
                mdtBecas.Columns.Add("TOTAL SALDO DISPONIBLE")
                mdtBecas.Columns.Add("TOTAL GASTOS DEL PERIODO")
                mdtBecas.Columns.Add("SALDO FINAL DEL PERIODO")
                mdtEmpresas = mobjSql.s_empresas_con_mov(mlngAgno)
                mlngFilas = mobjSql.Registros
                If mlngFilas > 0 Then
                    For Each dr In mdtEmpresas.Rows
                        lngSaldoAnterior = mobjSql.s_saldo_anual_por_cuenta_aportes_traspasos(6, dr("rut"), mlngAgno - 1)
                        lngSaldoIni = mobjSql.s_saldo_anual_por_cuenta_aportes_traspasos(6, dr("rut"), mlngAgno)
                        drBecas = mdtBecas.NewRow
                        drBecas("RUT EMPRESA") = dr("rut")
                        drBecas("D.V.") = digito_verificador(dr("rut"))
                        drBecas("RAZON SOCIAL EMPRESA") = mobjSql.s_razon_social_cliente(dr("rut"))
                        drBecas("SALDO AÑOS ANTERIORES") = lngSaldoAnterior
                        drBecas("SALDO CTA. EXCEDENTE CAP.") = 0
                        drBecas("SALDO CTA. EXCEDENTE REP.") = 0
                        drBecas("TRASPASOS POR MANDATO") = 0
                        drBecas("TOTAL SALDO DISPONIBLE") = lngSaldoIni
                        drBecas("TOTAL GASTOS DEL PERIODO") = 0
                        drBecas("SALDO FINAL DEL PERIODO") = lngSaldoIni
                        mdtBecas.Rows.Add(drBecas)
                    Next
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        mdtBecas.TableName = "Comportamiento cuenta de becas"
                        ConvierteDTaCSV(mdtBecas, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
                mobjSql = Nothing
            Case 6
                mobjSql = New CSql
                mdtAportes = New DataTable
                mdtAportes.Columns.Add("FECHA DEL APORTE")
                mdtAportes.Columns.Add("CORRELATIVO DEL APORTE")
                mdtAportes.Columns.Add("RUT DE LA EMPRESA")
                mdtAportes.Columns.Add("DIGITO VERIFICADOR")
                mdtAportes.Columns.Add("NOMBRE DE LA EMPRESA")
                mdtAportes.Columns.Add("MONTO TOTAL DEL APORTE")
                Dim dtAportes As DataTable = mobjSql.s_aportes_anuales(mlngAgno)
                mlngFilas = mobjSql.Registros
                If mlngFilas > 0 Then
                    For Each dr In dtAportes.Rows
                        drAportes = mdtAportes.NewRow
                        drAportes("FECHA DEL APORTE") = FechaVbAUsr(dr(0))
                        drAportes("CORRELATIVO DEL APORTE") = dr(1)
                        drAportes("RUT DE LA EMPRESA") = dr(2)
                        drAportes("DIGITO VERIFICADOR") = digito_verificador(dr(2))
                        drAportes("NOMBRE DE LA EMPRESA") = dr(4)
                        drAportes("MONTO TOTAL DEL APORTE") = dr(3)
                        mdtAportes.Rows.Add(drAportes)
                    Next
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        mdtAportes.TableName = "Comportamiento cuenta de aportes"
                        ConvierteDTaCSV(mdtAportes, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
                mobjSql = Nothing
            Case 7
                mobjSql = New CSql
                Dim dtAportes As DataTable = mobjSql.s_aportes_anuales_sence(mlngAgno)
                dtAportes.Columns.Add("DIGITO_VERIFICADOR")
                mlngFilas = mobjSql.Registros
                mdtAportes = New DataTable
                If mlngFilas > 0 Then
                    For Each dr In dtAportes.Rows
                        dr("DIGITO_VERIFICADOR") = digito_verificador(dr(1))
                    Next
                    dtAportes.Columns(40).SetOrdinal(2)
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        dtAportes.TableName = "Comportamiento cuenta de aportes"
                        ConvierteDTaCSV(dtAportes, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
                mobjSql = Nothing
        End Select


    End Function
End Class
