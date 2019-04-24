Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteCursos
    Implements IReporte
#Region "Declaraciones"
    Private objSession As New CSession
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mstrXmlCliente As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    'rut del cliente
    Private mlngRutCliente As Long
    'rut del usuario
    Private mlngRutUsuario As Long
    'estado de los aportes: lista de códigos separada por comas
    Private mstrEstados As String
    'lista de ruts separados por comas
    Private mstrListaRutsCliente As String
    'Curso Interno o Sence
    Private mblnCursoInteno As Boolean
    Private mblnCursoSence As Boolean
    'fecha inicial y final del período
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date
    ' Año de cursos
    Private mintAgno As Integer

    Private mstrCorrelativo As String
    Private mlngTotalValor As Long
    Private mlngTotalOtic As Long
    Private mlngTotalEmpresa As Long
    Private mlngTotalCapacitacion As Long
    Private mlngTotalExcCapacitacion As Long
    Private mlngTotalTerceros As Long
    Private mlngTotalAdministracion As Long
    Private mlngTotalBecas As Long
    Private mlngTotalVyT As Long
    Private mlngTotalOticVyT As Long
    Private mlngTotalEmpresaVyT As Long
    'listado de filiales
    Private mdtFiliales As DataTable
    'lista de ruts de filiales, separados por coma
    Private mstrListaRutsHolding As String
    'Rut holding
    Private mlngRutHolding As Long
    'información consolidada
    Private mblnInfoConsolidada As Boolean
    Private mblnAnulados As Boolean
    Private mblnEliminados As Boolean

#End Region

#Region "Inicializacion de variables"
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub
#End Region

#Region "Propiedades"
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

    'rut del cliente que hizo el aporte
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property

    'estados: lista de códigos de estados separadas por comas
    Public Property Estados() As String
        Get
            Return mstrEstados
        End Get
        Set(ByVal value As String)
            mstrEstados = value
        End Set
    End Property
    'lista de ruts de clientes, separados por comas
    Public Property ListaRutsCliente() As String
        Get
            Return mstrListaRutsCliente
        End Get
        Set(ByVal value As String)
            mstrListaRutsCliente = value
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
    'indica si las cartolas se muestran consolidadas
    Public Property InfoConsolidada() As Boolean
        Get
            InfoConsolidada = mblnInfoConsolidada
        End Get
        Set(ByVal value As Boolean)
            mblnInfoConsolidada = value
        End Set
    End Property

    'fecha de inicio
    Public Property FechaInicio() As String
        Get
            Return MostrarFecha(mdtmFechaIni)
        End Get
        Set(ByVal value As String)
            mdtmFechaIni = value
        End Set
    End Property

    'fecha de fin del periodo
    Public Property FechaFin() As String
        Get
            Return MostrarFecha(mdtmFechaFin)
        End Get
        Set(ByVal value As String)
            mdtmFechaFin = value
        End Set
    End Property

    ' Año cursos
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    'correlativo
    Public Property Correlativo() As String
        Get
            Return mstrCorrelativo
        End Get
        Set(ByVal value As String)
            mstrCorrelativo = value
        End Set
    End Property
    Public Property TotalValor() As Long
        Get
            Return mlngTotalValor
        End Get
        Set(ByVal value As Long)
            mlngTotalValor = value
        End Set
    End Property
    Public Property TotalOtic() As Long
        Get
            Return mlngTotalOtic
        End Get
        Set(ByVal value As Long)
            mlngTotalOtic = value
        End Set
    End Property
    Public Property TotalEmpresa() As Long
        Get
            Return mlngTotalEmpresa
        End Get
        Set(ByVal value As Long)
            mlngTotalEmpresa = value
        End Set
    End Property
    Public Property TotalCapacitacion() As Long
        Get
            Return mlngTotalCapacitacion
        End Get
        Set(ByVal value As Long)
            mlngTotalCapacitacion = value
        End Set
    End Property
    Public Property TotalExcCapacitacion() As Long
        Get
            Return mlngTotalExcCapacitacion
        End Get
        Set(ByVal value As Long)
            mlngTotalExcCapacitacion = value
        End Set
    End Property
    Public Property TotalTerceros() As Long
        Get
            Return mlngTotalTerceros
        End Get
        Set(ByVal value As Long)
            mlngTotalTerceros = value
        End Set
    End Property
    Public Property TotalAdministracion() As Long
        Get
            Return mlngTotalAdministracion
        End Get
        Set(ByVal value As Long)
            mlngTotalAdministracion = value
        End Set
    End Property
    Public Property TotalBecas() As Long
        Get
            Return mlngTotalBecas
        End Get
        Set(ByVal value As Long)
            mlngTotalBecas = value
        End Set
    End Property
    Public Property TotalVyT() As Long
        Get
            Return mlngTotalVyT
        End Get
        Set(ByVal value As Long)
            mlngTotalVyT = value
        End Set
    End Property
    Public Property TotalOticVyT() As Long
        Get
            Return mlngTotalOticVyT
        End Get
        Set(ByVal value As Long)
            mlngTotalOticVyT = value
        End Set
    End Property
    Public Property TotalEmpresaVyT() As Long
        Get
            Return mlngTotalEmpresaVyT
        End Get
        Set(ByVal value As Long)
            mlngTotalEmpresaVyT = value
        End Set
    End Property
    Public Property CursoInterno() As Boolean
        Get
            Return mblnCursoInteno
        End Get
        Set(ByVal value As Boolean)
            mblnCursoInteno = value
        End Set
    End Property
    Public Property CursoSence() As Boolean
        Get
            Return mblnCursoSence
        End Get
        Set(ByVal value As Boolean)
            mblnCursoSence = value
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

    Public ReadOnly Property TieneFiliales() As Boolean
        Get
            If mdtFiliales.Rows.Count > 1 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
#End Region
    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try

            Dim dtReporteCliente As New DataTable
            dtReporteCliente.Columns.Add("nFila")
            dtReporteCliente.Columns.Add("tipo_curso")
            dtReporteCliente.Columns.Add("cod_curso")
            dtReporteCliente.Columns.Add("correlativo")
            dtReporteCliente.Columns.Add("codigo_sence")
            dtReporteCliente.Columns.Add("correlativo_empresa")
            dtReporteCliente.Columns.Add("nombre_curso")
            dtReporteCliente.Columns.Add("area")
            dtReporteCliente.Columns.Add("especialidad")
            dtReporteCliente.Columns.Add("modalidad")
            dtReporteCliente.Columns.Add("tipo_actividad")
            dtReporteCliente.Columns.Add("comite_bipartito")
            dtReporteCliente.Columns.Add("curso_cft")
            dtReporteCliente.Columns.Add("direccion_curso")
            dtReporteCliente.Columns.Add("horario_curso")
            dtReporteCliente.Columns.Add("rut_otec")
            dtReporteCliente.Columns.Add("razon_social_otec")
            dtReporteCliente.Columns.Add("rut_empresa")
            dtReporteCliente.Columns.Add("razon_social")
            dtReporteCliente.Columns.Add("año")
            dtReporteCliente.Columns.Add("fecha_inicio")
            dtReporteCliente.Columns.Add("fecha_termino")
            dtReporteCliente.Columns.Add("estado")
            dtReporteCliente.Columns.Add("horas")
            dtReporteCliente.Columns.Add("numero_alumnos")
            dtReporteCliente.Columns.Add("HH")
            dtReporteCliente.Columns.Add("valor_mercado")
            dtReporteCliente.Columns.Add("costo_otic")
            dtReporteCliente.Columns.Add("cuenta_adm")
            dtReporteCliente.Columns.Add("gasto_empresa")
            dtReporteCliente.Columns.Add("total_vyt")
            dtReporteCliente.Columns.Add("costo_otic_vyt")
            dtReporteCliente.Columns.Add("total_gasto_empresa_vyt")
            dtReporteCliente.Columns.Add("cuenta_capacitacion")
            dtReporteCliente.Columns.Add("cuenta_exc_capacitacion")


            Dim dtconsulta As DataTable
            Dim strRuts As String
            Dim strNombreArchivo As String
            Dim strNombreArchivoCliente As String
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
                strRuts = CStr(mlngRutCliente)
            Else
                strRuts = mstrListaRutsHolding
            End If
            dtconsulta = mobjSql.s_cursos_consolidado2(strRuts, mstrEstados, mdtmFechaIni, mdtmFechaFin, mblnCursoInteno, mblnCursoSence, mblnAnulados, mblnEliminados)
            'dtconsulta = mobjSql.s_cursos_consolidado2(strRuts, mstrEstados, mintAgno, mblnCursoInteno, mblnCursoSence)


            If Not dtconsulta Is Nothing Then
                Me.mlngFilas = Me.mobjSql.Registros
                If Me.mlngFilas > 0 Then
                    Dim drCliente As DataRow
                    'dtconsulta = mobjSql.s_cursos_consolidado2(strRuts, mstrEstados, mdtmFechaIni, mdtmFechaFin, mblnCursoInteno, mblnCursoSence)
                    Dim dr As DataRow
                    dtconsulta.Columns.Add("diferenciacionCurso")
                    mlngTotalValor = 0
                    mlngTotalOtic = 0
                    mlngTotalEmpresa = 0
                    mlngTotalCapacitacion = 0
                    mlngTotalExcCapacitacion = 0
                    mlngTotalTerceros = 0
                    mlngTotalAdministracion = 0
                    mlngTotalBecas = 0
                    mlngTotalVyT = 0
                    mlngTotalOticVyT = 0
                    mlngTotalEmpresaVyT = 0
                    For Each dr In dtconsulta.Rows

                        If dr("cod_curso_compl") > 0 Then
                            dr("diferenciacionCurso") = "P"
                        ElseIf dr("cod_curso_parcial") > 0 Then
                            dr("diferenciacionCurso") = "C"
                        Else
                            dr("diferenciacionCurso") = ""
                        End If

                        mlngTotalOtic = mlngTotalOtic + NumeroNulo(dr("costo_otic"))
                        mlngTotalEmpresa = mlngTotalEmpresa + NumeroNulo(dr("gasto_empresa"))
                        mlngTotalCapacitacion = mlngTotalCapacitacion + NumeroNulo(dr("cuenta_capacitacion"))
                        mlngTotalExcCapacitacion = mlngTotalExcCapacitacion + NumeroNulo(dr("cuenta_exc_capacitacion"))
                        mlngTotalTerceros = mlngTotalTerceros + NumeroNulo(dr("cuenta_reparto") + NumeroNulo(dr("cuenta_exc_reparto")))
                        mlngTotalAdministracion = mlngTotalAdministracion + NumeroNulo(dr("cuenta_adm"))
                        mlngTotalBecas = mlngTotalBecas + NumeroNulo(dr("cuenta_becas"))
                        mlngTotalVyT = mlngTotalVyT + NumeroNulo(dr("total_vyt"))
                        mlngTotalOticVyT = mlngTotalOticVyT + NumeroNulo(dr("costo_otic_vyt"))
                        dr("total_gasto_empresa_vyt") = CLng(dr("total_vyt")) - CLng(dr("costo_otic_vyt"))
                        mlngTotalEmpresaVyT = mlngTotalEmpresaVyT + NumeroNulo(dr("total_gasto_empresa_vyt"))
                        mlngTotalValor = mlngTotalValor + NumeroNulo(dr("valor_mercado"))

                        If CDbl(dr("porcentaje_adm")) >= 0 And CDbl(dr("porcentaje_adm")) <= 1 Then
                            dr("porcentaje_adm") = dr("porcentaje_adm")
                        ElseIf CDbl(dr("porcentaje_adm")) > 1 And CDbl(dr("porcentaje_adm")) <= 100 Then
                            dr("porcentaje_adm") = dr("porcentaje_adm") / 100
                        End If
                        dr("valor_mercado") = dr("valor_mercado")

                        drCliente = dtReporteCliente.NewRow
                        drCliente("nFila") = dr("nFila")
                        drCliente("tipo_curso") = dr("tipo_curso")
                        drCliente("cod_curso") = dr("cod_curso")
                        drCliente("correlativo") = dr("correlativo")
                        drCliente("codigo_sence") = dr("codigo_sence")
                        drCliente("nombre_curso") = dr("nombre_curso")
                        drCliente("correlativo_empresa") = dr("correlativo_empresa")
                        drCliente("horario_curso") = dr("horario_curso")
                        drCliente("area") = dr("area")
                        drCliente("especialidad") = dr("especialidad")
                        drCliente("razon_social_otec") = dr("razon_social_otec")
                        drCliente("rut_otec") = CStr(dr("rut_otec")) + "-" + CStr(dr("dig_verif_otec"))
                        drCliente("direccion_curso") = CStr(dr("direccion_curso"))
                        drCliente("estado") = dr("estado_curso")
                        drCliente("razon_social") = dr("razon_social")
                        drCliente("rut_empresa") = CStr(dr("rut_cliente")) + "-" + CStr(dr("dig_verif_cliente"))
                        drCliente("fecha_inicio") = FechaVbAUsr(dr("fecha_inicio"))
                        drCliente("fecha_termino") = FechaVbAUsr(dr("fecha_termino"))
                        drCliente("año") = dr("año")
                        drCliente("numero_alumnos") = dr("numero_alumnos")
                        drCliente("valor_mercado") = dr("valor_mercado")
                        drCliente("costo_otic") = NumeroNulo(dr("costo_otic"))
                        drCliente("cuenta_adm") = NumeroNulo(dr("cuenta_adm"))
                        drCliente("gasto_empresa") = NumeroNulo(dr("gasto_empresa"))
                        drCliente("cuenta_capacitacion") = NumeroNulo(dr("cuenta_capacitacion"))
                        drCliente("cuenta_exc_capacitacion") = NumeroNulo(dr("cuenta_exc_capacitacion"))
                        drCliente("costo_otic_vyt") = NumeroNulo(dr("costo_otic_vyt"))
                        drCliente("total_vyt") = NumeroNulo(dr("total_vyt"))
                        drCliente("total_gasto_empresa_vyt") = NumeroNulo(dr("total_gasto_empresa_vyt"))
                        drCliente("horas") = dr("horas")
                        drCliente("HH") = dr("HH")
                        drCliente("modalidad") = dr("modalidad")
                        drCliente("tipo_actividad") = dr("tipo_actividad")
                        drCliente("comite_bipartito") = dr("comite_bipartito")
                        drCliente("curso_cft") = dr("curso_cft")
                        dtReporteCliente.Rows.Add(drCliente)
                    Next


                    If Me.mblnBajarXml Then
                        Dim dt As DataTable
                        dt = dtconsulta

                        strNombreArchivo = NombreArchivoTmp("csv")
                        dt.TableName = "Reporte Cursos Consolidado"
                        ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo

                        strNombreArchivoCliente = NombreArchivoTmp("csv")
                        dtReporteCliente.TableName = "Reporte Cursos Consolidado"
                        ConvierteDTaCSV(dtReporteCliente, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivoCliente)
                        Me.mstrXmlCliente = "~" & "/contenido/tmp/" & strNombreArchivoCliente
                    End If

                End If
            End If
            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteCursos:Consultar->" & ex.Message)
        End Try

    End Function

    'función para mostrar una fecha en formato usuario, puede recibir Null
    Private Function MostrarFecha(ByVal vntFecha As Object) As String
        If IsDBNull(vntFecha) Then
            MostrarFecha = ""
        ElseIf IsDate(vntFecha) Then
            MostrarFecha = FechaVbAUsr(vntFecha)
        Else
            MostrarFecha = "Error en la fecha!"
        End If
    End Function
    'devuelve un cero si es nulo, en caso contrario retorna el número
    Private Function NumeroNulo(ByVal lngValor As Object) As Long
        If IsDBNull(lngValor) Then
            NumeroNulo = 0
        Else
            NumeroNulo = lngValor
        End If
    End Function

End Class
