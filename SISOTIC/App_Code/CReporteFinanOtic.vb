Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CReporteFinanOtic
    'Parámetros del reporte
    Implements IReporte
    Private mstrXml As String
    Private mblnBajarXml As Boolean
    'Agno
    Private mintAgno As Integer
    'Rut cliente (empresa)
    Private mlngRutCliente As Long
    'Fecha Inicio
    Private mdtmFechaInicio As Date
    'Fecha Fin
    Private mdtmFechaFin As Date
    'Total
    Private mlngSumTotal As Long
    'Etiquetas para el archivo
    Private mdtEtiquetas As DataTable
    'objeto con consultas SQL
    Private mobjSql As CSql

    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
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
    Public Property FechaInicio() As Date
        Get
            Return mdtmFechaInicio
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = value
        End Set
    End Property
    Public Property FechaFin() As Date
        Get
            Return mdtmFechaFin
        End Get
        Set(ByVal value As Date)
            mdtmFechaFin = value
        End Set
    End Property
    Public Property SumTotal() As Long
        Get
            Return mlngSumTotal
        End Get
        Set(ByVal value As Long)
            mlngSumTotal = value
        End Set
    End Property
    Public Property Etiqueta() As DataTable
        Get
            Return mdtEtiquetas
        End Get
        Set(ByVal value As DataTable)
            mdtEtiquetas = value
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
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    '
    ' Consulta
    '
    Public Function Consultar() As DataTable
        Try
            Dim dtConsulta As DataTable
            Dim i As Integer, intFilas As Integer
            Dim lngSumTotal As Long
            Dim strNombreArchivo As String


            mobjSql = New CSql
            dtConsulta = mobjSql.s_saldo_cuenta_finanOtic(mintAgno)
            intFilas = mobjSql.Registros
            lngSumTotal = 0
            If intFilas > 0 Then
                'dtConsulta.Columns.Add("total")
                Dim dr As DataRow
                mlngSumTotal = 0
                For Each dr In dtConsulta.Rows
                    'dr("total") = dr("total_monto")
                    mlngSumTotal = mlngSumTotal + dr("total_monto")
                Next
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtConsulta.TableName = "Reporte Cursos"
                    ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
                
            End If
           
            Return dtConsulta
        Catch ex As Exception
            EnviaError("CReporteFinanOtic.vb:Consultar-->" & ex.Message)
        End Try

    End Function



    'inicialización de variables
    Private Sub Initializa()
        mlngSumTotal = 0
        mintAgno = Year(Now)
        mlngRutCliente = -1
        mdtmFechaInicio = FechaMinSistema()
        mdtmFechaFin = FechaMaxSistema()
        'Llenado de las Etiquetas para Impresión
        'ReDim marrEtiquetas(2)
        'marrEtiquetas(0) = "Rut Cliente"
        'marrEtiquetas(1) = "Nombre Cliente"
        'marrEtiquetas(2) = "Saldo en cuenta Financiamiento Otic"
    End Sub

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


    Public Function Consultar1() As System.Data.DataTable Implements Clases.IReporte.Consultar

    End Function

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get

        End Get
    End Property
End Class
