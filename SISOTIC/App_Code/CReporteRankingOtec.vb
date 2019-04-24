Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CReporteRankingOtec
    Implements IReporte
    Private mstrXml As String
    Private mblnBajarXml As Boolean
    Private mintFilas As Integer
    '*******************'
    Private mobjSql As CSql
    '*******************'
    Private mstrNombreFantasia As String
    Private mstrRutOtec As String
    Private mbolParticipantes As Boolean
    Private mbolParticipaciones As Boolean
    Private mbolGastoEmpresa As Boolean
    Private mbolHoras As Boolean
    Private mintAgno As Integer
    Private mlngRutUsuario As Long
    Private mdtRangos As DataTable
    Private mdtHoras As DataTable
    Private mdtGasto As DataTable
    Private mdtParticipaciones As DataTable
    Private mdtParticipantes As DataTable
    Private mintRango As Integer
    Private mstrCriterio As String
    Private mstrGifArchivo As String
    Private mlngTotal As Long

    Public Property NombreFantasia() As String
        Get
            Return mstrNombreFantasia
        End Get
        Set(ByVal value As String)
            mstrNombreFantasia = value
        End Set
    End Property
    Public Property RutOtec() As String
        Get
            Return mstrRutOtec
        End Get
        Set(ByVal value As String)
            mstrRutOtec = value
        End Set
    End Property
    Public Property Participantes() As Boolean
        Get
            Return mbolParticipantes
        End Get
        Set(ByVal value As Boolean)
            mbolParticipantes = value
        End Set
    End Property
    Public Property Participaciones() As Boolean
        Get
            Return mbolParticipaciones
        End Get
        Set(ByVal value As Boolean)
            mbolParticipaciones = value
        End Set
    End Property
    Public Property GastoEmpresa() As Boolean
        Get
            Return mbolGastoEmpresa
        End Get
        Set(ByVal value As Boolean)
            mbolGastoEmpresa = value
        End Set
    End Property
    Public Property Horas() As Boolean
        Get
            Return mbolHoras
        End Get
        Set(ByVal value As Boolean)
            mbolHoras = value
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
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property Rangos() As DataTable
        Get
            Return mdtRangos
        End Get
        Set(ByVal value As DataTable)
            mdtRangos = value
        End Set
    End Property
    Public Property HorasData() As DataTable
        Get
            Return mdtHoras
        End Get
        Set(ByVal value As DataTable)
            mdtHoras = value
        End Set
    End Property
    Public Property Gasto() As DataTable
        Get
            Return mdtGasto
        End Get
        Set(ByVal value As DataTable)
            mdtGasto = value
        End Set
    End Property
    Public Property ParticipacionesData() As DataTable
        Get
            Return mdtParticipaciones
        End Get
        Set(ByVal value As DataTable)
            mdtParticipaciones = value
        End Set
    End Property
    Public Property ParticipantesData() As DataTable
        Get
            Return mdtParticipantes
        End Get
        Set(ByVal value As DataTable)
            mdtParticipantes = value
        End Set
    End Property
    Public Property Rango() As Integer
        Get
            Return mintRango
        End Get
        Set(ByVal value As Integer)
            mintRango = value
        End Set
    End Property
    Public Property Criterio() As String
        Get
            Return mstrCriterio
        End Get
        Set(ByVal value As String)
            mstrCriterio = value
        End Set
    End Property
    Public Property GifArchivo() As String
        Get
            Return mstrGifArchivo
        End Get
        Set(ByVal value As String)
            mstrGifArchivo = value
        End Set
    End Property
    Public Property Suma() As Long
        Get
            Return mlngTotal
        End Get
        Set(ByVal value As Long)
            mlngTotal = value
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
            Return mintFilas
        End Get
    End Property
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim i, j, k, L As Integer
            Dim dtTempo As DataTable
            mstrCriterio = "Ranking por Horas"

            If mbolHoras Then
                Call ConsultarHoras()
                If mintRango > 0 Then
                    k = mintRango
                    j = ((k * 10) - 10)
                Else
                    k = 1
                    j = 0
                End If
                L = 0
                For i = j To (j + 9)
                    If i <= mintFilas - 1 Then
                        '    Dim drConsulta As DataRow

                        '    For Each drConsulta In mdtHoras.Rows
                        '        mlngTotal = drConsulta("total")
                        '        mstrNombreFantasia = drConsulta("razon_social")

                        '    Next


                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = marrHoras(i).item("Suma")
                        'arrTempo(L).item("Razon_social") = marrHoras(i).item("Razon_social")
                        'arrTempo(L).item("RUT") = marrHoras(i).item("RUT")
                        'L = L + 1
                    Else
                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = ""
                        'arrTempo(L).item("Razon_social") = ""
                        'arrTempo(L).item("RUT") = ""
                        'L = L + 1
                    End If
                Next
                'If Me.mintFilas > 0 Then
                '    Dim lngDiv As Long
                '    mdtHoras.Columns.Add("0")
                '    mdtHoras.Columns.Add("1")
                '    Dim dr As DataRow
                '    Dim drDatos As DataRow
                '    For Each dr In mdtHoras.Rows
                '        drDatos = mdtHoras.NewRow
                '        drDatos("0") = dr("razon_social")
                '        lngDiv = dr("total")
                '        If lngDiv <= 0 Then
                '            lngDiv = dr("total") '1
                '        End If
                '        drDatos("1") = dr("total")
                '        mdtHoras.Rows.Add(drDatos)
                '    Next
                'End If

                Consultar = ConsultarHoras()
                mstrCriterio = "Ranking por Horas"
            End If

            If mbolGastoEmpresa Then
                Call ConsultarGasto()
                If Me.Rango > 0 Then
                    k = mintRango
                    j = ((k * 10) - 10)
                Else
                    k = 1
                    j = 0
                End If
                L = 0
                For i = j To (j + 9)
                    If i <= mintFilas - 1 Then
                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = marrGasto(i).item("Suma")
                        'arrTempo(L).item("Razon_social") = marrGasto(i).item("Razon_social")
                        'arrTempo(L).item("RUT") = marrGasto(i).item("RUT")
                        'L = L + 1
                    Else
                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = ""
                        'arrTempo(L).item("Razon_social") = ""
                        'arrTempo(L).item("RUT") = ""
                        'L = L + 1
                    End If
                Next i
                Consultar = ConsultarGasto()
                mstrCriterio = "Ranking por Gasto Empresa"
            End If

            If mbolParticipaciones Then
                Call ConsultarParticipaciones()
                If mintRango > 0 Then
                    k = mintRango
                    j = ((k * 10) - 10)
                    L = 0
                Else
                    k = 1
                    j = 0
                End If
                For i = j To (j + 9)
                    If i <= mintFilas - 1 Then
                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = marrParticipaciones(i).item("Suma")
                        'arrTempo(L).item("Razon_social") = marrParticipaciones(i).item("Razon_social")
                        'arrTempo(L).item("RUT") = marrParticipaciones(i).item("RUT")
                        'L = L + 1
                    Else
                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = ""
                        'arrTempo(L).item("Razon_social") = ""
                        'arrTempo(L).item("RUT") = ""
                        'L = L + 1
                    End If
                Next i
                Consultar = ConsultarParticipaciones()
                mstrCriterio = "Ranking por Participaciones"
            End If

            If mbolParticipantes Then
                Call ConsultarParticipantes()
                If mintRango > 0 Then
                    k = mintRango
                    j = ((k * 10) - 10)
                Else
                    k = 1
                    j = 0
                End If
                L = 0
                For i = j To (j + 9)
                    If i <= mintFilas - 1 Then
                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = marrParticipantes(i).item("Suma")
                        'arrTempo(L).item("Razon_social") = marrParticipantes(i).item("Razon_social")
                        'arrTempo(L).item("RUT") = marrParticipantes(i).item("RUT")
                        'L = L + 1
                    Else
                        'arrTempo(L) = CreateObject("Scripting.Dictionary")
                        'arrTempo(L).item("Suma") = ""
                        'arrTempo(L).item("Razon_social") = ""
                        'arrTempo(L).item("RUT") = ""
                        'L = L + 1
                    End If
                Next i
                Consultar = ConsultarParticipantes()
                mstrCriterio = "Ranking por Participantes"
            End If


        Catch ex As Exception
            EnviaError("CReporteRankingOtec.vb:Consultar-->" & ex.Message)
        End Try
    End Function
    Public Function ConsultarHoras() As DataTable
        Try
            Dim dtConsulta As DataTable
            Dim i, j, k, L As Integer ', intFilas As Integer
            'intFilas = 0
            Dim lngDiv As Long
            mobjSql = New CSql
            dtConsulta = mobjSql.s_rankingotec_horas(mintAgno)
            mintFilas = mobjSql.Registros
            Me.mintFilas = Me.mobjSql.Registros
            mdtHoras = New DataTable
            If Me.mintFilas > 0 Then
                
                Dim drConsulta As DataRow

                For Each drConsulta In dtConsulta.Rows
                    mlngTotal = drConsulta("total")
                    mstrNombreFantasia = drConsulta("razon_social")
                   
                Next
               
            End If
            If Me.mintFilas > 0 Then
                mdtHoras.Columns.Add("0")
                mdtHoras.Columns.Add("1")
                Dim dr As DataRow
                Dim drDatos As DataRow
                For Each dr In dtConsulta.Rows
                    drDatos = mdtHoras.NewRow
                    drDatos("0") = dr("razon_social")
                    lngDiv = dr("total")
                    If lngDiv <= 0 Then
                        lngDiv = dr("total") '1
                    End If
                    drDatos("1") = dr("total")
                    mdtHoras.Rows.Add(drDatos)
                Next
            End If
           
            Return dtConsulta
            
        Catch ex As Exception
            EnviaError("CReporteRankingOtec.vb:ConsultarHoras-->" & ex.Message)
        End Try
    End Function
    Public Function ConsultarGasto() As DataTable
        Try
            Dim dtConsulta As DataTable


            Dim i, j, k As Integer ', intFilas As Integer
            Dim strrang As String
            Dim lngDiv As Long
            'intFilas = 0
            mobjSql = New CSql
            dtConsulta = mobjSql.s_rankingotec_gasto(mintAgno)
            mintFilas = mobjSql.Registros
            mdtGasto = New DataTable
            If Me.mintFilas > 0 Then
              
                Dim drConsulta As DataRow
              
                For Each drConsulta In dtConsulta.Rows
                    mlngTotal = drConsulta("total")
                    mstrNombreFantasia = drConsulta("razon_social")
                   
                Next
               
            End If
            If Me.mintFilas > 0 Then
                mdtGasto.Columns.Add("0")
                mdtGasto.Columns.Add("1")
                Dim dr As DataRow
                Dim drDatos As DataRow
                For Each dr In dtConsulta.Rows
                    drDatos = mdtGasto.NewRow
                    drDatos("0") = dr("razon_social")
                    lngDiv = dr("total")
                    If lngDiv <= 0 Then
                        lngDiv = dr("total")
                    End If
                    drDatos("1") = dr("total")
                    mdtGasto.Rows.Add(drDatos)
                Next
            End If
            Return dtConsulta

        Catch ex As Exception
            EnviaError("CReporteRankingOtec.vb:ConsultarGasto-->" & ex.Message)
        End Try
    End Function
    Public Function ConsultarParticipaciones() As DataTable
        Try
            Dim dtConsulta As DataTable
            Dim i, j, k As Integer ', intFilas As Integer
            Dim lngDiv As Long
            'intFilas = 0
            mobjSql = New CSql
            dtConsulta = mobjSql.s_rankingotec_participaciones(mintAgno)
            mintFilas = mobjSql.Registros
            mdtParticipaciones = New DataTable
            If Me.mintFilas > 0 Then

                Dim drConsulta As DataRow

                For Each drConsulta In dtConsulta.Rows
                    mlngTotal = drConsulta("total")
                    mstrNombreFantasia = drConsulta("razon_social")

                Next

            End If
            If Me.mintFilas > 0 Then
                mdtParticipaciones.Columns.Add("0")
                mdtParticipaciones.Columns.Add("1")
                Dim dr As DataRow
                Dim drDatos As DataRow
                For Each dr In dtConsulta.Rows
                    drDatos = mdtParticipaciones.NewRow
                    drDatos("0") = dr("razon_social")
                    lngDiv = dr("total")
                    If lngDiv <= 0 Then
                        lngDiv = dr("total") '1
                    End If
                    drDatos("1") = dr("total")
                    mdtParticipaciones.Rows.Add(drDatos)
                Next
            End If
            Return dtConsulta
        Catch ex As Exception
            EnviaError("CReporteRankingOtec.vb:ConsultarParticipaciones-->" & ex.Message)
        End Try
        

    End Function

    Public Function ConsultarParticipantes() As DataTable
        Try
            Dim dtConsulta As DataTable
            Dim i, j, k As Integer 'intFilas As Integer
            Dim lngDiv As Long
            'intFilas = 0
            mobjSql = New CSql
            dtConsulta = mobjSql.s_rankingotec_participantes(mintAgno)
            mintFilas = mobjSql.Registros
            mdtParticipantes = New DataTable
            If Me.mintFilas > 0 Then

                Dim drConsulta As DataRow

                For Each drConsulta In dtConsulta.Rows
                    mlngTotal = drConsulta("total")
                    mstrNombreFantasia = drConsulta("razon_social")

                Next

            End If
            If Me.mintFilas > 0 Then
                mdtParticipantes.Columns.Add("0")
                mdtParticipantes.Columns.Add("1")
                Dim dr As DataRow
                Dim drDatos As DataRow
                For Each dr In dtConsulta.Rows
                    drDatos = mdtParticipantes.NewRow
                    drDatos("0") = dr("razon_social")
                    lngDiv = dr("total")
                    If lngDiv <= 0 Then
                        lngDiv = dr("total") '1
                    End If
                    drDatos("1") = dr("total")
                    mdtParticipantes.Rows.Add(drDatos)
                Next
            End If
            Return dtConsulta
        Catch ex As Exception
            EnviaError("CReporteRankingOtec.vb:ConsultarParticipantes-->" & ex.Message)
        End Try
        

    End Function

    
End Class
