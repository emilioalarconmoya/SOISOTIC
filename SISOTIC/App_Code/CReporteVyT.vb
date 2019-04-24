Imports Microsoft.VisualBasic
Imports System.Data
Imports Modulos
Namespace Clases
    
    Public Class CReporteVyT

        Private mobjCSql As New CSql
        Private mstrXml As String
        Private mlngFilas As Long
        Private mblnBajarXml As Boolean
        Private mstrArchivo As String
        '
        'Parámetros del reporte
        '
        'rut del cliente
        Private mlngRutCliente As Long
        'fecha inicial y final del período
        Private mdtmFechaIni As Date
        Private mdtmFechaFin As Date
        'listado de filiales
        Private mdtFiliales As DataTable
        'ruts filiales
        Private mstrListaRut As String
        'Indica si la información es consolidada o no
        Private mblnInfoConsolidada As Boolean
        ' total viatico para un cliente en un período
        Private mlngTotalViatico As Long
        ' total traslado para un cliente en un período
        Private mlngTotalTraslado As Long
        'Franquicia actual del cliente
        Private mlngFranquicia As Long
        '10 % de la franquicia (para viaticos y traslado)
        Private mlngSaldo As Long
        'lista de ruts de filiales, separados por coma
        Private mstrListaRutsHolding As String
        'Rut holding
        Private mlngRutHolding As Long
        Private mdblPorcFranquicia As Double
        Private mobjCliente As CCliente

        Public ReadOnly Property Filas() As Integer
            Get
                Return mlngFilas
            End Get
        End Property

        'fecha de inicio

        Public Property FechaInicio() As String
            Get
                Return mdtmFechaIni
            End Get
            Set(ByVal value As String)
                mdtmFechaIni = value
            End Set
        End Property
        'fecha de fin del periodo
        Public Property FechaFin() As String
            Get
                Return mdtmFechaFin
            End Get
            Set(ByVal value As String)
                mdtmFechaFin = value
            End Set
        End Property

        'rut del cliente
        Public Property RutCliente() As String
            Get
                Return mlngRutCliente
            End Get
            Set(ByVal value As String)
                mlngRutCliente = value
            End Set
        End Property
        Public Property TotalViat() As Long
            Get
                Return mlngTotalViatico
            End Get
            Set(ByVal value As Long)
                mlngTotalViatico = value
            End Set
        End Property
        Public Property TotalTras() As Long
            Get
                Return mlngTotalTraslado
            End Get
            Set(ByVal value As Long)
                mlngTotalTraslado = value
            End Set
        End Property
        Public Property Saldo() As Long
            Get
                Return mlngSaldo
            End Get
            Set(ByVal value As Long)
                mlngSaldo = value
            End Set
        End Property
        Public Property PorcentajeFranquicia() As Double
            Get
                Return mdblPorcFranquicia
            End Get
            Set(ByVal value As Double)
                mdblPorcFranquicia = value
            End Set
        End Property
        'filiales
        Public ReadOnly Property Filiales() As DataTable
            Get
                Return mdtFiliales
            End Get
        End Property

        Public ReadOnly Property TieneFiliales() As Boolean
            Get
                If Not mdtFiliales Is Nothing Then
                    If mdtFiliales.Rows.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
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

        Public ReadOnly Property ArchivoXml() As String
            Get
                Return Me.mstrXml
            End Get
        End Property

        Public Property BajarXml() As Boolean
            Get
                Return mblnBajarXml
            End Get
            Set(ByVal value As Boolean)
                mblnBajarXml = value
            End Set
        End Property

        Public Function Consultar() As System.Data.DataTable
            Try
                Dim dtConsulta As DataTable
                Dim dtConsultaFiliales As DataTable
                Dim strRuts As String
                Dim strNombreArchivo As String
                Dim saldotemp As Long
                dtConsultaFiliales = mobjCSql.s_clientes_asociados(mlngRutCliente)
                Me.mlngFilas = Me.mobjCSql.Registros
                If Me.mlngFilas > 0 Then
                    mdtFiliales = New DataTable
                    mdtFiliales.Columns.Add("RutFilial")
                    mdtFiliales.Columns.Add("Nombre")
                    mdtFiliales.Columns.Add("Nivel")
                    mdtFiliales.Columns.Add("DigitoVerif")
                    Dim dr As DataRow
                    Dim drFiliales As DataRow
                    For Each dr In dtConsultaFiliales.Rows
                        drFiliales = mdtFiliales.NewRow
                        drFiliales("RutFilial") = dr.Item(0)
                        drFiliales("Nombre") = dr.Item(1)
                        drFiliales("Nivel") = dr.Item(3)
                        drFiliales("DigitoVerif") = digito_verificador(dr.Item(0))
                        mdtFiliales.Rows.Add(drFiliales)
                    Next
                End If
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
                mobjCliente = New CCliente
                Call mobjCliente.Inicializar(mobjCSql)
                mobjCliente.InfoConsolidada = mblnInfoConsolidada
                Call mobjCliente.Inicializar1(RutLngAUsr(mlngRutCliente))
                mlngFranquicia = mobjCSql.s_franquicia_actual(strRuts, Now.Year)
                If mobjCliente.SaldoFranquicia <= 0 Then
                    mdblPorcFranquicia = 0
                    mlngSaldo = 0

                ElseIf mobjCliente.SaldoFranquiciaPorc <= 90 Then
                    mdblPorcFranquicia = 10
                    mlngSaldo = Math.Round(mlngFranquicia * 0.1)
                Else
                    mdblPorcFranquicia = mobjCliente.SaldoFranquiciaPorc
                    mlngSaldo = mobjCliente.SaldoFranquicia
                End If
                saldotemp = mlngSaldo
                mobjCliente = Nothing
                dtConsulta = mobjCSql.s_reporte_vyt(strRuts, mdtmFechaIni, mdtmFechaFin)
                Me.mlngFilas = Me.mobjCSql.Registros
                If Me.mlngFilas > 0 Then
                    mlngTotalViatico = 0
                    mlngTotalTraslado = 0
                    dtConsulta.Columns.Add("saldo")
                    dtConsulta.Columns.Add("descripcion")
                    Dim drConsulta As DataRow
                    For Each drConsulta In dtConsulta.Rows
                        drConsulta("saldo") = saldotemp - (CLng(drConsulta("total_viatico")) + CLng(drConsulta("total_traslado")))
                        saldotemp = saldotemp - (CLng(drConsulta("total_viatico")) + CLng(drConsulta("total_traslado")))
                        drConsulta("descripcion") = drConsulta("nombre") & ", " & drConsulta("correlativo")
                        mlngTotalViatico = mlngTotalViatico + drConsulta("total_viatico")
                        mlngTotalTraslado = mlngTotalTraslado + drConsulta("total_traslado")
                    Next
                End If
                mlngSaldo = saldotemp
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtConsulta.TableName = "Reporte Cursos Consolidado"
                    ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
                Return dtConsulta
            Catch ex As Exception
                EnviaError("CReporteVyT:Consultar->" & ex.Message)
            End Try
        End Function

        ''inicialización del objeto
        'Public Sub Inicializar(ByRef objSql As CSql)
        '    mobjSql = objSql
        'End Sub

        'inicialización de variables
        'Public Sub New()
        '    mlngRutCliente = 0
        '    mlngTotalViatico = 0
        '    mlngTotalTraslado = 0
        '    mstrListaRut = ""
        '    mdtmFechaIni = DateSerial(Now.Year, 1, 1)  'primer día del año
        '    mdtmFechaFin = Date.Now   'hoy
        'End Sub


    End Class
End Namespace