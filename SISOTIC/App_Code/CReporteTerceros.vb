Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Imports System

Public Class CReporteTerceros
    Implements IReporte
#Region "Declaraciones"
    Private objSession As New CSession
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    'rut del cliente
    Private mlngRutBenefactor As Long
    'rut del usuario
    Private mlngRutUsuario As Long
    'estado de los aportes: lista de códigos separada por comas
    Private mstrEstados As String
    'lista de ruts separados por comas
    Private mstrListaRutsCliente As String
    'fecha inicial y final del período
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date
    Private mlngTotalValor As Long
    Private mlngTotalOtic As Long
    Private mlngTotalEmpresa As Long
    Private mlngTotalRep As Long
    Private mlngTotalExcRep As Long
    Private mlngTotalAdm As Long
    Private mlngTotalBecas As Long
    'listado de filiales
    Private mdtFiliales As DataTable
    'lista de ruts de filiales, separados por coma
    Private mstrListaRutsHolding As String
    'Rut holding
    Private mlngRutHolding As Long
    'información consolidada
    Private mblnInfoConsolidada As Boolean
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
    'indica si las cartolas se muestran consolidadas
    Public Property InfoConsolidada() As Boolean
        Get
            InfoConsolidada = mblnInfoConsolidada
        End Get
        Set(ByVal value As Boolean)
            mblnInfoConsolidada = value
        End Set
    End Property


    'rut del cliente que hizo el aporte
    Public Property RutBenefactor() As Long
        Get
            Return mlngRutBenefactor
        End Get
        Set(ByVal value As Long)
            mlngRutBenefactor = value
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
    Public ReadOnly Property TotalValor() As Long
        Get
            Return mlngTotalValor
        End Get
    End Property
    Public ReadOnly Property TotalOtic() As Long
        Get
            Return mlngTotalOtic
        End Get
    End Property
    Public ReadOnly Property TotalEmpresa() As Long
        Get
            Return mlngTotalEmpresa
        End Get
    End Property
    Public ReadOnly Property TotalRep() As Long
        Get
            Return mlngTotalRep
        End Get
    End Property
    Public ReadOnly Property TotalExcRep() As Long
        Get
            Return mlngTotalExcRep
        End Get
    End Property
    Public ReadOnly Property TotalAdm() As Long
        Get
            Return mlngTotalAdm
        End Get
    End Property
    Public ReadOnly Property TotalBecas() As Long
        Get
            Return mlngTotalBecas
        End Get
    End Property
#End Region

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim dtconsulta As DataTable
            Dim strNombreArchivo As String
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
            dtFiliales = mobjSql.s_clientes_asociados(mlngRutBenefactor)
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
                strRuts = CStr(mlngRutBenefactor)
            Else
                strRuts = mstrListaRutsHolding
            End If
            dtconsulta = mobjSql.s_curso_terceros(strRuts, mstrEstados, mdtmFechaIni, mdtmFechaFin)
            Me.mlngFilas = Me.mobjSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow
                dtconsulta.Columns.Add("diferenciacionCurso")
                dtconsulta.Columns.Add("valor_curso")
                For Each dr In dtconsulta.Rows
                    If dr("cod_curso_compl") > 0 Then
                        dr("diferenciacionCurso") = "P"
                    ElseIf dr("cod_curso_parcial") > 0 Then
                        dr("diferenciacionCurso") = "C"
                    Else
                        dr("diferenciacionCurso") = ""
                    End If
                    dr("monto_rep") = NumeroNulo(dr("monto_rep"))
                    dr("costo_otic") = NumeroNulo(dr("costo_otic"))
                    dr("gasto_empresa") = NumeroNulo(dr("gasto_empresa"))
                    dr("valor_curso") = NumeroNulo(dr("gasto_empresa")) + NumeroNulo(dr("costo_otic")) + NumeroNulo(dr("costo_adm"))
                    dr("monto_exc_rep") = NumeroNulo(dr("monto_exc_rep"))
                    dr("costo_adm") = NumeroNulo(dr("costo_adm"))
                    dr("monto_becas") = NumeroNulo(dr("monto_becas"))
                Next
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtconsulta.TableName = "Reporte Terceros"
                    ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
            End If
            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteTerceros:Consultar->" & ex.Message)
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