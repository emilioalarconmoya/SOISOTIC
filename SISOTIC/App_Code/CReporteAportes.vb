Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteAportes
#Region "Declaraciones"

    Private objSession As New CSession
    Private mobjCSql As New CSql
    Private mstrXml As String
    Private mstrXmlSence As String
    Private mstrXmlTxt As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mblnBajarXmlSence As Boolean
    Private mblnBajarXmlTxt As Boolean
    Private mstrArchivo As String
    'lista de ruts. Se utiliza para obtener los aportes de holdings
    Private mstrListaRuts As String
    'estado de los aportes: lista de códigos separada por comas
    Private mstrEstados As String
    Private mlngCodEstado As Long
    Private mlngRutCliente As Long
    'Criterios de búsqueda
    'Número aporte
    Private mlngNumAporte As Long
    'Rut empresa
    Private mlngRutEmp As Long
    'Código de la cuenta
    Private mintCodCuenta As Integer
    'Nombre empresa
    Private mstrNombreEmpresa As String
    'Condición del número de aporte
    Private mstrCondNumAporte As String
    'Conjdición del rut de empresa
    Private mstrCondRutEmp As String
    'año
    Private mintAgno As Integer
    'sumas
    Private mdblSumaMonto As Double
    Private mdblSumaAdm As Double
    'fecha inicial y final del período
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date
    'totales
    Dim mdblTotalAporteNeto As Double
    Dim mdblTotalAdministracion As Double
    Dim mdblTotalAporteTotal As Double
    'listado de filiales
    Private mdtFiliales As DataTable
    'lista de ruts de filiales, separados por coma
    Private mstrListaRutsHolding As String
    'Rut holding
    Private mlngRutHolding As Long
    'información consolidada
    Private mblnInfoConsolidada As Boolean
    'datatable para el reporte sence
    Private mdtReporteSence As DataTable

    Private mstrWhere As String
    Private mstrBusqueda As String
    Private mlngCorrelativo As Long

    Public Property strWhere() As String
        Get
            Return mstrWhere
        End Get
        Set(ByVal value As String)
            mstrWhere = value
        End Set
    End Property

    Public Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property



#End Region
#Region "propiedades"
    Public Property CodEstado() As Long
        Get
            Return mlngCodEstado
        End Get
        Set(ByVal value As Long)
            mlngCodEstado = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String
        Get
            Return Me.mstrXml
        End Get
    End Property
    Public ReadOnly Property ArchivoXmlSence() As String
        Get
            Return Me.mstrXmlSence
        End Get
    End Property
    Public ReadOnly Property ArchivoXmlTxt() As String
        Get
            Return Me.mstrXmlTxt
        End Get
    End Property
    Public Property BajarXml() As Boolean
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXml = value
        End Set
    End Property
    Public Property BajarXmlSence() As Boolean
        Get
            Return mblnBajarXmlSence
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXmlSence = value
        End Set
    End Property
    Public Property BajarXmlTxt() As Boolean
        Get
            Return mblnBajarXmlTxt
        End Get
        Set(ByVal value As Boolean)
            Me.mblnBajarXmlTxt = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer
        Get
            Return mlngFilas
        End Get
    End Property
    Property Archivo() As String
        Get
            Return mstrArchivo
        End Get
        Set(ByVal value As String)
            mstrArchivo = value
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
    'indica si las cartolas se muestran consolidadas
    Public Property InfoConsolidada() As Boolean
        Get
            InfoConsolidada = mblnInfoConsolidada
        End Get
        Set(ByVal value As Boolean)
            mblnInfoConsolidada = value
        End Set
    End Property
    Property ListaRuts() As String
        Get
            Return mstrListaRuts
        End Get
        Set(ByVal value As String)
            mstrListaRuts = value
        End Set
    End Property
    Property Estados() As String
        Get
            Return mstrEstados
        End Get
        Set(ByVal value As String)
            mstrEstados = value
        End Set
    End Property
    Property NombreEmpresa() As String
        Get
            Return mstrNombreEmpresa
        End Get
        Set(ByVal value As String)
            mstrNombreEmpresa = value
        End Set
    End Property
    Property CondNumAporte() As String
        Get
            Return mstrCondNumAporte
        End Get
        Set(ByVal value As String)
            mstrCondNumAporte = value
        End Set
    End Property
    Property CondRutEmp() As String
        Get
            Return mstrCondRutEmp
        End Get
        Set(ByVal value As String)
            mstrCondRutEmp = value
        End Set
    End Property
    Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Property NumAporte() As Long
        Get
            Return mlngNumAporte
        End Get
        Set(ByVal value As Long)
            mlngNumAporte = value
        End Set
    End Property
    Property RutEmp() As Long
        Get
            Return mlngRutEmp
        End Get
        Set(ByVal value As Long)
            mlngRutEmp = value
        End Set
    End Property
    Property CodCuenta() As Integer
        Get
            Return mintCodCuenta
        End Get
        Set(ByVal value As Integer)
            mintCodCuenta = value
        End Set
    End Property
    Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Property SumaMonto() As Double
        Get
            Return mdblSumaMonto
        End Get
        Set(ByVal value As Double)
            mdblSumaMonto = value
        End Set
    End Property
    Property SumaAdm() As Double
        Get
            Return FormatoMonto(mdblSumaAdm)
        End Get
        Set(ByVal value As Double)
            mdblSumaAdm = value
        End Set
    End Property
    Public Property FechaIni() As String
        Get
            Return MostrarFecha(mdtmFechaIni)
        End Get
        Set(ByVal value As String)
            mdtmFechaIni = value
        End Set
    End Property
    Public Property FechaFin() As String
        Get
            Return MostrarFecha(mdtmFechaFin)
        End Get
        Set(ByVal value As String)
            mdtmFechaFin = value
        End Set
    End Property
    Property TotalAporteNeto() As Double
        Get
            Return FormatoMonto(mdblTotalAporteNeto)
        End Get
        Set(ByVal value As Double)
            mdblTotalAporteNeto = FormatoMonto(value)
        End Set
    End Property
    Property TotalAdministracion() As Double
        Get
            Return FormatoMonto(mdblTotalAdministracion)
        End Get
        Set(ByVal value As Double)
            mdblTotalAdministracion = FormatoMonto(value)
        End Set
    End Property
    Property TotalAporteTotal() As Double
        Get
            Return FormatoMonto(mdblTotalAporteTotal)
        End Get
        Set(ByVal value As Double)
            mdblTotalAporteTotal = FormatoMonto(value)
        End Set
    End Property
#End Region

    Public Sub Inicializar(ByRef objSql As CSql)
        mobjCSql = mobjCSql
    End Sub
    Property ReporteSence() As DataTable
        Get
            Return mdtReporteSence
        End Get
        Set(ByVal value As DataTable)
            mdtReporteSence = value
        End Set
    End Property

    Public Property Busqueda() As String
        Get
            Return mstrBusqueda
        End Get
        Set(ByVal value As String)
            mstrBusqueda = value
        End Set
    End Property

    Public Function Consultar() As System.Data.DataTable
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
            dtFiliales = mobjCSql.s_clientes_asociados(mlngRutCliente)
            If mobjCSql.Registros > 0 Then
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
            dtconsulta = mobjCSql.s_reporte_aporte(mstrEstados, strRuts, mlngNumAporte, _
                                                  mlngRutEmp, mintCodCuenta, mstrNombreEmpresa, _
                                                  mstrCondNumAporte, mstrCondRutEmp, mdtmFechaIni, mdtmFechaFin)
            Me.mlngFilas = Me.mobjCSql.Registros
            If Me.mlngFilas > 0 Then
                dtconsulta.Columns.Add("aporte_total")
                Dim dr As DataRow
                mdblTotalAporteNeto = 0
                mdblTotalAdministracion = 0
                mdblTotalAporteTotal = 0
                For Each dr In dtconsulta.Rows
                    mlngNumAporte = dr("num_aporte")
                    dr("aporte_total") = dr("monto_neto") + dr("monto_adm")
                    mdblTotalAporteNeto = mdblTotalAporteNeto + dr("monto_neto")
                    mdblTotalAdministracion = mdblTotalAdministracion + dr("monto_adm")
                    mdblTotalAporteTotal = mdblTotalAporteTotal + dr("aporte_total")
                Next

            End If
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtconsulta.TableName = "Reporte Aporte"
                ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteAporte:Consultar->" & ex.Message)
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

    'consulta por el listado de aportes
    Public Function ConsultarAportes() As System.Data.DataTable
        Try
            Dim dtconsulta As DataTable
            Dim strNombreArchivo As String
            Dim strRuts As String

            dtconsulta = mobjCSql.s_listado_aporte(mlngRutCliente, mintAgno, mintCodCuenta, mstrBusqueda)
            Me.mlngFilas = Me.mobjCSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dtconsulta.Rows

                Next

            End If
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtconsulta.TableName = "Reporte Aporte"
                ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

            If Me.mblnBajarXmlTxt Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtconsulta.TableName = "Reporte Aporte .txt"
                ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXmlTxt = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

            If Me.mblnBajarXmlSence Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtconsulta.TableName = "Reporte Aporte sence"
                ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXmlSence = "~" & "/contenido/tmp/" & strNombreArchivo
            End If


            Return dtconsulta

        Catch ex As Exception
            EnviaError("CReporteAporte:ConsultarAportes->" & ex.Message)
        End Try
    End Function

    Public Function CargaFormatoSence() As DataTable
        Try
            'inicialización de totales
            'mcurSumaMonto = 0
            'mcurSumaAdm = 0
            Dim strNombreArchivoSence As String
            Dim dtConsulta As DataTable
            Dim dtConsultaSence As DataTable

            Dim i As Integer, intFilas As Integer

            Dim dtmFin As Date
            'a la fecha de termino se le suma un dia para realizar el select correctamente ya que en la base de datos las fechas estan con hora:minutos:segundos
            dtmFin = DateAdd("d", 1, mdtmFechaFin)

            Dim strRuts As String
            If mstrListaRuts = "" Then
                strRuts = Str(mlngRutCliente)
            Else
                strRuts = mstrListaRuts
            End If

            dtConsulta = mobjCSql.s_listado_aporte_Sence(mlngRutCliente, mintAgno, mintCodCuenta)

            intFilas = mobjCSql.Registros

            If intFilas > 0 Then
                'dtConsultaSence.Columns.Add("porc_adm")
                Dim dr As DataRow
                For Each dr In dtConsulta.Rows
                    'dr("porc_adm") = (dr("monto_adm") * 100) / (dr("monto_neto") + dr("monto_adm"))
                Next
                dtConsultaSence = New DataTable
                dtConsultaSence.Columns.Add(New DataColumn("num_aporte", GetType(Long)))
                dtConsultaSence.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
                dtConsultaSence.Columns.Add(New DataColumn("cod_cuenta", GetType(Long)))
                dtConsultaSence.Columns.Add(New DataColumn("monto_total", GetType(Long)))
                dtConsultaSence.Columns.Add(New DataColumn("porc_adm", GetType(Double)))
                dtConsultaSence.Columns.Add(New DataColumn("fecha", GetType(Date)))
                Dim drSence As DataRow
                For i = 0 To intFilas - 1
                    'For Each drSence In dtConsulta.Rows
                    drSence = dtConsultaSence.NewRow()
                    drSence("num_aporte") = dtConsulta.Rows(i)(0)
                    drSence("rut_cliente") = RutLngAUsr(dtConsulta.Rows(i)(1))
                    drSence("cod_cuenta") = dtConsulta.Rows(i)(2)
                    drSence("monto_total") = dtConsulta.Rows(i)(3) + dtConsulta.Rows(i)(4)
                    drSence("porc_adm") = Math.Round((dtConsulta.Rows(i)(4) * 100) / drSence("monto_total"), 0)
                    drSence("fecha") = FechaVbAUsr(dtConsulta.Rows(i)(5))
                    dtConsultaSence.Rows.Add(drSence)

                    'drSence("num_aporte") = dr("num_aporte")
                    'drSence("rut_cliente") = dr("rut_cliente")
                    'drSence("cod_cuenta") = dr("cod_cuenta")
                    'drSence("monto_total") = dr("monto_neto") + dr("monto_adm")
                    'drSence("porc_adm") = (dr("monto_adm") * 100) / drSence("monto_total")
                    'drSence("fecha") = FechaVbAUsr(dr("fecha"))
                Next
                mdtReporteSence = dtConsultaSence


            End If
            If Me.mblnBajarXmlSence Then
                strNombreArchivoSence = NombreArchivoTmp("csv")
                mdtReporteSence.TableName = "Reporte Aporte Sence"
                ConvierteDTaCSV(mdtReporteSence, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivoSence)
                Me.mstrXmlSence = "~" & "/contenido/tmp/" & strNombreArchivoSence
            End If

        Catch ex As Exception

        End Try


    End Function
    'consulta por el listado de aportes
    Public Function ConsultarAportes2() As System.Data.DataTable
        Try
            Dim dtconsulta As DataTable
            Dim strNombreArchivo As String
            Dim strRuts As String

            dtconsulta = mobjCSql.s_listado_aporte2(mstrWhere)
            Me.mlngFilas = Me.mobjCSql.Registros
            If Me.mlngFilas > 0 Then
                mlngCodEstado = dtconsulta.Rows(0)(2)
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtconsulta.TableName = "Reporte Aporte"
                    ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
            End If
            
            Return dtconsulta

        Catch ex As Exception
            EnviaError("CReporteAporte:ConsultarAportes->" & ex.Message)
        End Try
    End Function
    Public Function Consultar2() As System.Data.DataTable
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
            dtFiliales = mobjCSql.s_clientes_asociados(mlngRutCliente)
            If mobjCSql.Registros > 0 Then
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
            dtconsulta = mobjCSql.s_reporte_aporte2(mlngCorrelativo)
            Me.mlngFilas = Me.mobjCSql.Registros
            If Me.mlngFilas > 0 Then
                dtconsulta.Columns.Add("aporte_total")
                Dim dr As DataRow
                mdblTotalAporteNeto = 0
                mdblTotalAdministracion = 0
                mdblTotalAporteTotal = 0
                For Each dr In dtconsulta.Rows
                    mlngNumAporte = dr("num_aporte")
                    dr("aporte_total") = dr("monto_neto") + dr("monto_adm")
                    mdblTotalAporteNeto = mdblTotalAporteNeto + dr("monto_neto")
                    mdblTotalAdministracion = mdblTotalAdministracion + dr("monto_adm")
                    mdblTotalAporteTotal = mdblTotalAporteTotal + dr("aporte_total")
                Next

            End If
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dtconsulta.TableName = "Reporte Aporte"
                ConvierteDTaCSV(dtconsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteAporte:Consultar->" & ex.Message)
        End Try
    End Function

End Class
