Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data


Public Class CReporteAlumnos
    Implements IReporte
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mstrXmlCliente As String
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
    Private mblnAnulados As Boolean
    Private mblnEliminados As Boolean

    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
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
    Public ReadOnly Property ArchivoXmlCliente() As String
        Get
            Return Me.mstrXmlCliente
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
    Public Property CursosAnulados() As Boolean
        Get
            Return mblnAnulados
        End Get
        Set(ByVal value As Boolean)
            mblnAnulados = value
        End Set
    End Property
    Public Property CursoEliminados() As Boolean
        Get
            Return mblnEliminados
        End Get
        Set(ByVal value As Boolean)
            mblnEliminados = value
        End Set
    End Property
    
    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try

            Dim dtReporteCliente As New DataTable
            dtReporteCliente.Columns.Add("nFila")
            dtReporteCliente.Columns.Add("tipo_alumno")
            dtReporteCliente.Columns.Add("rut_alumno")
            dtReporteCliente.Columns.Add("dig_verif_alumno")
            dtReporteCliente.Columns.Add("nombre")
            dtReporteCliente.Columns.Add("apellido_paterno")
            dtReporteCliente.Columns.Add("apellido_materno")
            dtReporteCliente.Columns.Add("fecha_nacim")
            dtReporteCliente.Columns.Add("sexo")
            dtReporteCliente.Columns.Add("porc_franquicia")
            dtReporteCliente.Columns.Add("direccion_curso")
            dtReporteCliente.Columns.Add("cod_region")
            dtReporteCliente.Columns.Add("razon_social")
            dtReporteCliente.Columns.Add("Correlativo")
            dtReporteCliente.Columns.Add("codigo_sence")
            dtReporteCliente.Columns.Add("nro_registro")
            dtReporteCliente.Columns.Add("correlativo_empresa")
            dtReporteCliente.Columns.Add("nombre_curso")
            dtReporteCliente.Columns.Add("modalidad")
            dtReporteCliente.Columns.Add("tipo_actividad")
            dtReporteCliente.Columns.Add("comite_bipartito")
            dtReporteCliente.Columns.Add("CFT")
            dtReporteCliente.Columns.Add("DNC")
            dtReporteCliente.Columns.Add("rut_otec")
            dtReporteCliente.Columns.Add("dig_verif_otec")
            dtReporteCliente.Columns.Add("nombre_otec")
            dtReporteCliente.Columns.Add("horas")
            dtReporteCliente.Columns.Add("año")
            dtReporteCliente.Columns.Add("fecha_inicio")
            dtReporteCliente.Columns.Add("fecha_termino")
            dtReporteCliente.Columns.Add("estado_curso")
            dtReporteCliente.Columns.Add("porc_asistencia")
            dtReporteCliente.Columns.Add("estado_aprobacion")
            dtReporteCliente.Columns.Add("evaluacion")
            dtReporteCliente.Columns.Add("valor_mercado")
            dtReporteCliente.Columns.Add("costo_otic_curso")
            dtReporteCliente.Columns.Add("gasto_empresa_curso")
            dtReporteCliente.Columns.Add("viatico_total")
            dtReporteCliente.Columns.Add("viatico_otic")
            dtReporteCliente.Columns.Add("viatico_ge")
            dtReporteCliente.Columns.Add("traslado_total")
            dtReporteCliente.Columns.Add("traslado_otic")
            dtReporteCliente.Columns.Add("traslado_ge")
            dtReporteCliente.Columns.Add("total_otic")
            dtReporteCliente.Columns.Add("total_empresa")
            dtReporteCliente.Columns.Add("total_alumno")


            Dim mstrRuts As String
            'inicialización de lista de ruts de filiales
            mdtFiliales = New DataTable
            mdtFiliales.Columns.Add("RutFilial")
            mdtFiliales.Columns.Add("Nombre")
            mdtFiliales.Columns.Add("Nivel")
            mdtFiliales.Columns.Add("DigitoVerif")
            Dim dtFiliales As DataTable
            'Dim intFilas As Integer
            'Dim i As Integer
            dtFiliales = mobjSql.s_clientes_asociados(mlngRutCliente)
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
                mstrRuts = CStr(mlngRutCliente)
            Else
                mstrRuts = mstrListaRutsHolding
            End If
            Dim dtconsulta As DataTable
            Dim c, lngDescuento As Long
            Dim lngValorMercado, lngHoras, lngHorasCompl, lngCodCursoCompl As Long
            Dim dblGastoEmpresaAlumno As Double, dblCostoOticAlumno As Double
            Dim dblValHoraCurso, dblPorcAdm, dblPorcFranquicia As Double
            Dim intCodEstadoCurso, intIndAcuComBip, intIndDescPorc As Integer
            Dim intNumAlumnos As Integer
            Dim dblValHoraSence As Double
            Dim strNombreArchivo As String
            Dim strNombreArchivoCliente As String
            'lngValHoraSence = mobjSql.s_val_hora_sence
            dtconsulta = mobjSql.s_union_alumnos(mstrRuts, mlngRutAlumno, mstrNombreAlumno, mdtmFechaIni, mdtmFechaFin, mblnAlumnoInterno, mblnAlumnoSence, mblnAnulados, mblnEliminados)
            Dim dtCsv As DataTable
            dtCsv = dtconsulta
            Me.mlngFilas = Me.mobjSql.Registros
            If Not dtconsulta Is Nothing Then
                If Me.mlngFilas > 0 Then
                    Dim drCliente As DataRow
                    Dim dr As DataRow
                    mdblTotalOtic = 0
                    mdblTotalEmp = 0
                    mdblTotalViat = 0
                    mdblTotalTras = 0
                    mdblTotal = 0
                    For Each dr In dtconsulta.Rows
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
                            dr("par/compl") = "P" '"C"
                        Else
                            If dr("cod_curso_parcial") <> 0 Then
                                dr("par/compl") = "C" '"P"
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
                        drCliente = dtReporteCliente.NewRow
                        drCliente("nFila") = dr("nFila")
                        drCliente("tipo_alumno") = dr("tipo_alumno")
                        drCliente("rut_alumno") = dr("rut_alumno")
                        drCliente("dig_verif_alumno") = dr("dig_verif_alumno")
                        drCliente("nombre") = dr("nombre")
                        drCliente("apellido_paterno") = dr("apellido_paterno")
                        drCliente("apellido_materno") = dr("apellido_materno")
                        drCliente("fecha_nacim") = FechaVbAUsr(dr("fecha_nacim"))
                        drCliente("sexo") = dr("sexo")
                        drCliente("cod_region") = dr("cod_region")
                        drCliente("porc_franquicia") = dr("porc_franquicia") '/ 100
                        drCliente("porc_asistencia") = dr("porc_asistencia") '/ 100
                        drCliente("evaluacion") = "" 'dr("evaluacion")
                        drCliente("razon_social") = dr("razon_social")
                        drCliente("direccion_curso") = dr("direccion_curso")
                        drCliente("viatico_otic") = dr("viatico_otic")
                        drCliente("traslado_otic") = dr("traslado_otic")
                        drCliente("viatico_ge") = dr("viatico_ge")
                        drCliente("traslado_ge") = dr("traslado_Ge")

                        drCliente("valor_mercado") = dr("valor_mercado")
                        drCliente("viatico_total") = dr("viatico_total")
                        drCliente("traslado_total") = dr("traslado_total")
                        drCliente("total_otic") = dr("total_otic")
                        drCliente("total_empresa") = dr("total_empresa")

                        drCliente("nombre_curso") = dr("nombre_curso")

                        drCliente("modalidad") = dr("modalidad")
                        drCliente("tipo_actividad") = dr("tipo_actividad")
                        drCliente("comite_bipartito") = dr("comite_bipartito")
                        drCliente("CFT") = dr("CFT")
                        drCliente("DNC") = dr("DNC")


                        drCliente("estado_curso") = dr("estado_curso")
                        drCliente("codigo_sence") = dr("codigo_sence")
                        drCliente("Correlativo") = dr("Correlativo")
                        drCliente("nro_registro") = dr("nro_registro")
                        drCliente("correlativo_empresa") = dr("correlativo_empresa")
                        drCliente("fecha_inicio") = FechaVbAUsr(dr("fecha_inicio"))
                        drCliente("fecha_termino") = FechaVbAUsr(dr("fecha_termino"))
                        drCliente("año") = dr("año")
                        drCliente("nombre_otec") = dr("nombre_otec")
                        drCliente("rut_otec") = dr("rut_otec")
                        drCliente("dig_verif_otec") = dr("dig_verif_otec")
                        drCliente("horas") = dr("horas")
                        drCliente("costo_otic_curso") = dr("costo_otic_curso")
                        drCliente("gasto_empresa_curso") = dr("gasto_emp_curso")
                        If dr("tipo_alumno") = "Sence" Then
                            drCliente("total_alumno") = dr("total_alumno") 'dr("gasto_emp_curso") + dr("costo_otic_curso")
                        Else
                            drCliente("total_alumno") = CLng(dr("valor_mercado") / dr("num_alumnos"))
                        End If
                        drCliente("estado_aprobacion") = dr("estado_aprobacion")
                        dtReporteCliente.Rows.Add(drCliente)
                    Next
                    dtconsulta.Columns.Remove("num_alumnos")
                    If Me.mblnBajarXml Then
                        strNombreArchivo = NombreArchivoTmp("csv")
                        dtconsulta.TableName = "Reporte de Alumnos"
                        ConvierteDTaCSV(dtCsv, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo


                        strNombreArchivoCliente = NombreArchivoTmp("csv")
                        dtReporteCliente.TableName = "Reporte de Alumnos"
                        ConvierteDTaCSV(dtReporteCliente, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivoCliente)
                        Me.mstrXmlCliente = "~" & "/contenido/tmp/" & strNombreArchivoCliente


                    End If
                End If
            End If
            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteAlumnos:Consultar->" & ex.Message)
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
