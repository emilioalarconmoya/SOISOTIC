Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Imports System

Public Class CInformePorFranquicia
    'objeto con consultas
    Private mobjSql As New CSql
    Private mintAgno As Integer
    Private mlngRutCliente As Long
    Private mstrGifArchivo As String
    Private mdtResultado As DataTable
    Private mdtResultadoHH As DataTable
    Private mdtFranquicia As DataTable
    Private mdtFiliales As DataTable
    'lista de ruts de filiales, separados por coma
    Private mstrListaRutsHolding As String
    'información consolidada
    Private mblnInfoConsolidada As Boolean
    Private mlngFilas As Long
   
    Public ReadOnly Property Filas() As Integer
        Get
            Return mlngFilas
        End Get
    End Property

    Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public ReadOnly Property GifArchivo() As String
        Get
            Return mstrGifArchivo
        End Get
    End Property

    Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public ReadOnly Property Resultado() As DataTable
        Get
            Return mdtResultado
        End Get
    End Property
    Public ReadOnly Property ResultadoHH() As DataTable
        Get
            Return mdtResultadoHH
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
    'indica si las cartolas se muestran consolidadas
    Public Property InfoConsolidada() As Boolean
        Get
            InfoConsolidada = mblnInfoConsolidada
        End Get
        Set(ByVal value As Boolean)
            mblnInfoConsolidada = value
        End Set
    End Property




    'Generación del reporte
    Public Function Consultar() As DataTable
        Try
            'asignación de variables seleccionadas
            Dim dtTmp As DataTable
            Dim dtConsulta As DataTable
            Dim dtDatos As DataTable
            Dim intLargo As Integer
            Dim i As Integer
            Dim lngCuentCantPart As Long
            Dim lngTotalHH As Long
            Dim lngDiv As Long
            Dim strRuts As String

          
            Dim dt As New DataTable
            Dim x As Integer = 0
            Dim franq As Integer
            dtConsulta = New DataTable
            dtConsulta.Columns.Add("franquicia")
            dtConsulta.Columns.Add("cant_tramo")
            dtConsulta.Columns.Add("HH")
            For x = 0 To 2
                Select Case x
                    Case 0
                        franq = 100
                    Case 1
                        franq = 50
                    Case 2
                        franq = 15
                End Select
                dt = mobjSql.s_resumen_por_franquicia(mlngRutCliente, mintAgno, franq)
                If mobjSql.Registros > 0 Then
                    Dim dr As DataRow
                    dr = dtConsulta.NewRow
                    dr("franquicia") = dt.Rows(0).Item(0)
                    dr("cant_tramo") = dt.Rows(0).Item(1)
                    dr("HH") = dt.Rows(0).Item(2)
                    dtConsulta.Rows.Add(dr)
                Else
                    Dim dr As DataRow
                    dr = dtConsulta.NewRow
                    dr("franquicia") = franq
                    dr("cant_tramo") = 0
                    dr("HH") = 0
                    dtConsulta.Rows.Add(dr)
                End If
            Next
            intLargo = TamanoArreglo2(dtConsulta)
            Me.mlngFilas = 2
            mdtResultado = New DataTable
            If Me.mlngFilas > 0 Then
                dtConsulta.Columns.Add("porcentaje_alumno")
                dtConsulta.Columns.Add("porcentaje_horas")
                Dim lngCant As Long
                Dim lngCantH As Long
                Dim drConsulta As DataRow
                Dim drC As DataRow
                Dim drH As DataRow
                For Each drConsulta In dtConsulta.Rows
                    lngCuentCantPart = lngCuentCantPart + drConsulta("cant_tramo")
                    lngTotalHH = lngTotalHH + drConsulta("HH")
                Next
                For Each drC In dtConsulta.Rows
                    lngCant = drC("cant_tramo")
                    If lngCant <= 0 Then
                        lngCant = drC("cant_tramo")
                    End If
                    drC("porcentaje_alumno") = Math.Round((lngCant * 100) / lngCuentCantPart, 1)
                Next
                For Each drH In dtConsulta.Rows
                    lngCantH = drH("HH")
                    If lngCantH <= 0 Then
                        lngCantH = drH("HH")
                    End If
                    drH("porcentaje_horas") = Math.Round((lngCantH * 100) / lngTotalHH, 1)
                Next
            End If
            If Me.mlngFilas > 0 Then
                mdtResultado.Columns.Add("0")
                mdtResultado.Columns.Add("1")
                Dim dr As DataRow
                Dim drDatos As DataRow
                For Each dr In dtConsulta.Rows
                    drDatos = mdtResultado.NewRow
                    drDatos("0") = "Tramo Franq. (" & dr("franquicia") & ") "
                    lngDiv = dr("cant_tramo")
                    If lngDiv <= 0 Then
                        lngDiv = dr("cant_tramo") '1
                    End If
                    drDatos("1") = (lngDiv * 100) / lngCuentCantPart '(lngCuentCantPart / lngDiv) * 100 '  '
                    mdtResultado.Rows.Add(drDatos)
                Next
            End If
            If Me.mlngFilas > 0 Then
                mdtResultadoHH = New DataTable
                mdtResultadoHH.Columns.Add("0")
                mdtResultadoHH.Columns.Add("1")
                Dim dr As DataRow
                Dim drDatos As DataRow
                For Each dr In dtConsulta.Rows
                    drDatos = mdtResultadoHH.NewRow
                    drDatos("0") = "Tramo Franq. (" & dr("franquicia") & ") "

                    lngDiv = dr("HH")
                    If lngDiv <= 0 Then
                        lngDiv = dr("HH") '1
                    End If
                    drDatos("1") = (lngDiv * 100) / lngTotalHH '(lngCuentCantPart / lngDiv) * 100 '  '
                    mdtResultadoHH.Rows.Add(drDatos)
                Next
            End If
            Return dtConsulta


        Catch ex As Exception
            EnviaError("CReporteAporte:Cargar->" & ex.Message)
        End Try

    End Function
    'inicialización de variables
    Private Sub Inicializar()
        Try
            mlngRutCliente = 0
            mintAgno = (Now.Year)  'año actual
        Catch ex As Exception
            EnviaError("CReporteAporte:Inicializar->" & ex.Message)
        End Try

    End Sub
    'constructor del objeto
    Public Sub Inicializar0(ByRef objSql As CSql)
        Try
            mobjSql = objSql
        Catch ex As Exception
            EnviaError("CReporteAporte:Inicializar0->" & ex.Message)
        End Try

    End Sub

End Class
