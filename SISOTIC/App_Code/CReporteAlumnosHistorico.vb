Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteAlumnosHistorico
    Implements IReporte
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    '
    'Parámetros del reporte
    '
    'rut del cliente
    Private mlngRutCliente As Long

    'Rut del Alumno usado para la consulta
    Private mlngRutAlumno As Long

    'Nombre del alumno usado para la consulta
    Private mstrNombreAlumno As String

    'fecha inicial y final del período
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date

    'rut usuario
    Private mlngRutUsuario As Long

    'ruts filiales
    Private mstrListaRut As String

    'Indica si la información es consolidada o no
    Private mblnInfoConsolidada As Boolean
    Private mdblTotalOtic As Double
    Private mdblTotalEmp As Double
    Private mdblTotalViat As Double
    Private mdblTotalTras As Double
    Private mdblTotales As Double
    Private mstrCodClasificador As String
    Private mdblCostoOtic As Double
    Private mdblGastoEmpresa As Double
    Private mdblVitatico As Double
    Private mdblTraslado As Double
    Private mdblTotal As Double
    Private mblnAlumnoInterno As Boolean
    Private mblnAlumnoSence As Boolean
    'listado de filiales
    Private mdtFiliales As DataTable
    'lista de ruts de filiales, separados por coma
    Private mstrListaRutsHolding As String
    'Rut holding
    Private mlngRutHolding As Long
    Private mlngCodCurso As Long
    Private mintAgno As Integer
    Private mintCorrelativo As Integer

    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
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
    Public Property Correlativo() As Integer
        Get
            Return mintCorrelativo
        End Get
        Set(ByVal value As Integer)
            mintCorrelativo = value
        End Set
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
    Public Property AlumnoInterno() As Boolean
        Get
            Return mblnAlumnoInterno
        End Get
        Set(ByVal value As Boolean)
            mblnAlumnoInterno = value
        End Set
    End Property
    Public Property AlumnoSence() As Boolean
        Get
            Return mblnAlumnoSence
        End Get
        Set(ByVal value As Boolean)
            mblnAlumnoSence = value
        End Set
    End Property
    'fecha de inicio
    Public Property FechaInicio() As String
        Get
            Return mdtmFechaIni
        End Get
        Set(ByVal value As String)
            mdtmFechaIni = FechaUsrAVb(value)
        End Set
    End Property
    'fecha de fin del periodo
    Public Property FechaFin() As String
        Get
            Return mdtmFechaFin
        End Get
        Set(ByVal value As String)
            mdtmFechaFin = FechaVbAUsr(value)
        End Set
    End Property
    'Rut ALumno
    Public Property RutAlumno() As String
        Get
            Return mlngRutAlumno
        End Get
        Set(ByVal value As String)
            mlngRutAlumno = RutUsrALng(value)
        End Set
    End Property
    'Nombre ALumno
    Public Property NombreAlumno() As String
        Get
            Return mstrNombreAlumno
        End Get
        Set(ByVal value As String)
            mstrNombreAlumno = value
        End Set
    End Property
    'rut del cliente
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    'rut del usuario
    Public Property RutUsuario() As String
        Get
            Return RutLngAUsr(mlngRutUsuario)
        End Get
        Set(ByVal value As String)
            mlngRutUsuario = RutLngAUsr(value)
        End Set
    End Property
    'información consolidada
    Public Property InfoConsolidada() As Boolean
        Get
            Return mblnInfoConsolidada
        End Get
        Set(ByVal value As Boolean)
            mblnInfoConsolidada = value
        End Set
    End Property
    Public Property TotalOtic() As Double
        Get
            Return mdblTotalOtic
        End Get
        Set(ByVal value As Double)
            mdblTotalOtic = value
        End Set
    End Property
    Public Property TotalEmp() As Double
        Get
            Return mdblTotalEmp
        End Get
        Set(ByVal value As Double)
            mdblTotalEmp = value
        End Set
    End Property
    Public Property TotalViat() As Double
        Get
            Return mdblTotalViat
        End Get
        Set(ByVal value As Double)
            mdblTotalViat = value
        End Set
    End Property
    Public Property TotalTras() As Double
        Get
            Return mdblTotalTras
        End Get
        Set(ByVal value As Double)
            mdblTotalTras = value
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return mdblTotal
        End Get
        Set(ByVal value As Double)
            mdblTotal = value
        End Set
    End Property
    Public Property Totales() As Double
        Get
            Return mdblTotales
        End Get
        Set(ByVal value As Double)
            mdblTotales = value
        End Set
    End Property
    Public Property Vitatico() As Double
        Get
            Return mdblVitatico
        End Get
        Set(ByVal value As Double)
            mdblVitatico = value
        End Set
    End Property
    Public Property Traslado() As Double
        Get
            Return mdblTraslado
        End Get
        Set(ByVal value As Double)
            mdblTraslado = value
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
    Public Property CostoOtic() As Double
        Get
            Return mdblCostoOtic
        End Get
        Set(ByVal value As Double)
            mdblCostoOtic = value
        End Set
    End Property
    Public Property GastoEmpresa() As Double
        Get
            Return mdblGastoEmpresa
        End Get
        Set(ByVal value As Double)
            mdblGastoEmpresa = value
        End Set
    End Property

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Dim strError As String = ""
        Try
            Dim mstrRuts As String
            'inicialización de lista de ruts de filiales
            mdtFiliales = New DataTable
            mdtFiliales.Columns.Add("RutFilial")
            mdtFiliales.Columns.Add("Nombre")
            mdtFiliales.Columns.Add("Nivel")
            mdtFiliales.Columns.Add("DigitoVerif")

            Dim dtconsulta As DataTable
            Dim c, lngDescuento As Long
            Dim lngValorMercado, lngHoras, lngHorasCompl, lngCodCursoCompl As Long
            Dim dblGastoEmpresaAlumno As Double, dblCostoOticAlumno As Double
            Dim dblValHoraCurso, dblPorcAdm, dblPorcFranquicia As Double
            Dim intCodEstadoCurso, intIndAcuComBip, intIndDescPorc As Integer
            Dim intNumAlumnos As Integer
            'Dim lngValHoraSence As Long
            Dim dblValHoraSence As Double
            Dim strNombreArchivo As String
            'lngValHoraSence = mobjSql.s_val_hora_sence
            dtconsulta = mobjSql.s_union_alumnos3(mstrRuts, mlngRutAlumno, mstrNombreAlumno, mdtmFechaIni, mdtmFechaFin, mblnAlumnoInterno, mblnAlumnoSence, mintCorrelativo, False, False)
            Me.mlngFilas = Me.mobjSql.Registros
            If Not dtconsulta Is Nothing Then


                If Me.mlngFilas > 0 Then
                    'dtconsulta.Columns.Add("gasto_otic")
                    'dtconsulta.Columns.Add("gasto_emp")
                    'dtconsulta.Columns.Add("total")
                    Dim dr As DataRow
                    mdblTotalOtic = 0
                    mdblTotalEmp = 0
                    mdblTotalViat = 0
                    mdblTotalTras = 0
                    mdblTotal = 0

                    Dim drCliente As DataRow
                    'Dim dr As DataRow
                    mdblTotalOtic = 0
                    mdblTotalEmp = 0
                    mdblTotalViat = 0
                    mdblTotalTras = 0
                    mdblTotal = 0
                    For Each dr In dtconsulta.Rows
                        strError = dr("rut_alumno") & " " & dr("cod_curso")
                        mstrNombreAlumno = dr("nombre") + " " + dr("apellido_paterno") + " " + dr("apellido_materno")
                        mlngRutAlumno = dr("rut_alumno")
                        dr("total_alumno") = 0
                        intCodEstadoCurso = CInt(dr("cod_estado_curso"))
                        lngValorMercado = CLng(dr("valor_mercado"))
                        'lngDescuento = CInt(dr("Descuento"))
                        dblPorcAdm = CDbl(dr("porc_adm"))
                        lngHoras = CLng(dr("horas"))
                        lngHorasCompl = CLng(dr("horas_compl"))
                        If dr("comite_bipartito") = "SI" Then
                            intIndAcuComBip = 1
                        Else
                            intIndAcuComBip = 0
                        End If
                        'intIndDescPorc = CInt(dr("porcentaje_decuento"))
                        intNumAlumnos = CInt(dr("num_alumnos"))
                        If Not IsDBNull(dr("cod_curso_compl")) Then
                            lngCodCursoCompl = CLng(dr("cod_curso_compl"))
                        Else
                            lngCodCursoCompl = -1
                        End If
                        '______________________________________________________________
                        If dr("cod_curso_compl") <> 0 Then
                            dr("par/compl") = "P"
                        Else
                            If dr("cod_curso_parcial") <> 0 Then
                                dr("par/compl") = "C"
                            Else
                                dr("par/compl") = "-"
                            End If
                        End If
                        '______________________________________________________________
                        If CDbl(dr("porc_franquicia")) >= 0 And CDbl(dr("porc_franquicia")) <= 1 Then
                            dblPorcFranquicia = dr("porc_franquicia")
                        ElseIf CDbl(dr("porc_franquicia")) > 1 And CDbl(dr("porc_franquicia")) <= 100 Then
                            dblPorcFranquicia = dr("porc_franquicia") / 100
                        End If
                        dblValHoraSence = mobjSql.s_val_hora_curso(dr("cod_curso"))
                        dblCostoOticAlumno = CalcularCostoOticAlumno(lngHoras, _
                                                            dblValHoraSence, intIndAcuComBip, _
                                                            lngHorasCompl, (lngValorMercado * intNumAlumnos), _
                                                            intIndDescPorc, _
                                                            lngDescuento, intNumAlumnos, _
                                                            CDbl(dr("porc_asistencia")), _
                                                            intCodEstadoCurso, _
                                                            dblGastoEmpresaAlumno, _
                                                            dblPorcFranquicia)
                        If lngValorMercado <> 0 Then
                            dr("gasto_emp_curso") = CLng(dblGastoEmpresaAlumno)
                        Else
                            dr("gasto_emp_curso") = 0
                        End If

                        dr("costo_otic_curso") = CLng(dblCostoOticAlumno)
                        mdblCostoOtic = CLng(dblCostoOticAlumno)
                        If lngValorMercado <> 0 Then
                            mdblGastoEmpresa = CLng(dblGastoEmpresaAlumno)
                        Else
                            mdblGastoEmpresa = 0
                        End If

                        mdblVitatico = NumeroNulo(dr("viatico_otic"))
                        mdblTraslado = NumeroNulo(dr("traslado_otic"))
                        mdblTotal = mdblCostoOtic + mdblGastoEmpresa + mdblVitatico + mdblTraslado
                        mdblTotalOtic = mdblTotalOtic + dr("costo_otic_curso")
                        mdblTotalEmp = mdblTotalEmp + dr("gasto_emp_curso")
                        mdblTotalViat = mdblTotalViat + NumeroNulo(dr("viatico_otic"))
                        mdblTotalTras = mdblTotalTras + NumeroNulo(dr("traslado_otic"))
                        mdblTotales = mdblTotalOtic + mdblTotalEmp + mdblTotalViat + mdblTotalTras
                        If intCodEstadoCurso = 5 Or intCodEstadoCurso = 9 Or intCodEstadoCurso = 11 Then
                            If dr("porc_asistencia") < 75 Then
                                dr("viatico_ge") = dr("viatico_ge") + dr("viatico_otic")
                                dr("traslado_Ge") = dr("traslado_Ge") + dr("traslado_otic")
                                dr("viatico_otic") = 0
                                dr("traslado_otic") = 0
                            End If
                        End If
                        dr("total_otic") = dr("total_otic") + NumeroNulo(dr("costo_otic_curso")) + NumeroNulo(dr("viatico_otic")) + NumeroNulo(dr("traslado_otic"))
                        dr("total_empresa") = dr("total_empresa") + NumeroNulo(dr("gasto_emp_curso")) + NumeroNulo(dr("viatico_ge")) + NumeroNulo(dr("traslado_Ge"))
                        dr("total_alumno") = dr("total_alumno") + NumeroNulo(dr("costo_otic_curso")) + NumeroNulo(dr("gasto_emp_curso")) + NumeroNulo(dr("viatico_otic")) + NumeroNulo(dr("traslado_otic")) + NumeroNulo(dr("viatico_ge")) + NumeroNulo(dr("traslado_Ge"))
                        dr("porc_asistencia") = dr("porc_asistencia") / 100
                        dr("porc_franquicia") = dr("porc_franquicia") / 100
                        dr("porc_adm") = dr("porc_adm") / 100
                    Next
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        dtconsulta.TableName = "Reporte de Alumnos"
                        ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                    End If
                End If
            End If
            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteAlumnos:Consultar->" & ex.Message & " - " & strError)
        End Try
    End Function

    Private Function NumeroNulo(ByVal lngValor As Object) As Long
        If IsDBNull(lngValor) Then
            NumeroNulo = 0
        Else
            NumeroNulo = lngValor
        End If
    End Function
End Class
