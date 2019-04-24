Imports Microsoft.VisualBasic
Imports Modulos
Imports Clases
Imports System.Data
Imports System.Math

Public Class CInformeCartera
    Private mobjCSql As CSql
    Private mlngRutUsuario As Long
    Private mintCodSucursal As Integer
    Private mlngRutEjecutivo As Long
    Private mintAgno As Integer
    Private mintMes As Integer
    Private mlngNumEmpresas As Long
    Private mlngConAportes As Long
    Private mlngConActividadesIni As Long
    Private mlngConAportesPend As Long
    Private mlngConSaldoExcCap As Long
    Private mlngConSaldoExcRep As Long
    Private mlngFranqOcup50 As Long
    Private mlngFranqOcup25 As Long
    'nombre del archivo con el gráfico generado
    Private mstrGifArchivo As String
    Private mintPorcConAportes As Integer
    Private mintPorcConActividadesIni As Integer
    Private mintPorcConAportesPend As Integer
    Private mintPorcConSaldoExcCap As Long
    Private mintPorcConSaldoExcRep As Long
    Private mintPorcFranqOcup50 As Integer
    Private mintPorcFranqOcup25 As Integer
    Private mdtTorta As DataTable

#Region "propiedades"
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property CodSucursal() As Integer
        Get
            Return mintCodSucursal
        End Get
        Set(ByVal value As Integer)
            mintCodSucursal = value
        End Set
    End Property
    Public Property RutEjecutivo() As Long
        Get
            Return mlngRutEjecutivo
        End Get
        Set(ByVal value As Long)
            mlngRutEjecutivo = value
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
    Public Property Mes() As Integer
        Get
            Return mintMes
        End Get
        Set(ByVal value As Integer)
            mintMes = value
        End Set
    End Property
    Public Property NumEmpresas() As Long
        Get
            Return mlngNumEmpresas
        End Get
        Set(ByVal value As Long)
            mlngNumEmpresas = value
        End Set
    End Property
    Public Property ConAportes() As Long
        Get
            Return mlngConAportes
        End Get
        Set(ByVal value As Long)
            mlngConAportes = value
        End Set
    End Property
    Public Property ConActividadesIni() As Long
        Get
            Return mlngConActividadesIni
        End Get
        Set(ByVal value As Long)
            mlngConAportes = value
        End Set
    End Property
    Public Property ConAportesPend() As Long
        Get
            Return mlngConAportesPend
        End Get
        Set(ByVal value As Long)
            mlngConAportesPend = value
        End Set
    End Property
    Public Property ConSaldoExcCap() As Long
        Get
            Return mlngConSaldoExcCap
        End Get
        Set(ByVal value As Long)
            mlngConSaldoExcCap = value
        End Set
    End Property
    Public Property ConSaldoExcRep() As Long
        Get
            Return mlngConSaldoExcRep
        End Get
        Set(ByVal value As Long)
            mlngConSaldoExcRep = value
        End Set
    End Property
    Public Property FranqOcup50() As Long
        Get
            Return mlngFranqOcup50
        End Get
        Set(ByVal value As Long)
            mlngFranqOcup50 = value
        End Set
    End Property
    Public Property FranqOcup25() As Long
        Get
            Return mlngFranqOcup25
        End Get
        Set(ByVal value As Long)
            mlngFranqOcup25 = value
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
    Public Property PorcConAportes() As Integer
        Get
            Return mintPorcConAportes
        End Get
        Set(ByVal value As Integer)
            mintPorcConAportes = value
        End Set
    End Property
    Public Property PorcConActividadesIni() As Integer
        Get
            Return mintPorcConActividadesIni
        End Get
        Set(ByVal value As Integer)
            mintPorcConActividadesIni = value
        End Set
    End Property
    Public Property PorcConAportesPend() As Integer
        Get
            Return mintPorcConAportesPend
        End Get
        Set(ByVal value As Integer)
            mintPorcConAportesPend = value
        End Set
    End Property
    Public Property PorcConSaldoExcCap() As Long
        Get
            Return mintPorcConSaldoExcCap
        End Get
        Set(ByVal value As Long)
            mintPorcConSaldoExcCap = value
        End Set
    End Property
    Public Property PorcConSaldoExcRep() As Long
        Get
            Return mintPorcConSaldoExcRep
        End Get
        Set(ByVal value As Long)
            mintPorcConSaldoExcRep = value
        End Set
    End Property
    Public Property PorcFranqOcup50() As Integer
        Get
            Return mintPorcFranqOcup50
        End Get
        Set(ByVal value As Integer)
            mintPorcFranqOcup50 = value
        End Set
    End Property
    Public Property PorcFranqOcup25() As Integer
        Get
            Return mintPorcFranqOcup25
        End Get
        Set(ByVal value As Integer)
            mintPorcFranqOcup25 = value
        End Set
    End Property

    Public Property Torta() As DataTable
        Get
            Return mdtTorta
        End Get
        Set(ByVal value As DataTable)
            mdtTorta = value
        End Set
    End Property


#End Region
    Public Sub Inicializar()
        Try
            'mlngRutUsuario = 0
            mintCodSucursal = 0
            mlngRutEjecutivo = 0
            mintAgno = 0
            mintMes = 0
            mlngNumEmpresas = 0
            mlngConAportes = 0
            mlngConActividadesIni = 0
            mlngConAportesPend = 0
            mlngConSaldoExcCap = 0
            mlngConSaldoExcRep = 0
            mlngFranqOcup50 = 0
            mlngFranqOcup25 = 0
            mstrGifArchivo = ""
            mintPorcConAportes = 0
            mintPorcConActividadesIni = 0
            mintPorcConAportesPend = 0
            mintPorcConSaldoExcCap = 0
            mintPorcConSaldoExcRep = 0
            mintPorcFranqOcup50 = 0
            mintPorcFranqOcup25 = 0
        Catch ex As Exception
            EnviaError("cInformeCartera.aspx.vb -->Inicializar-->" & ex.Message)
        End Try
    End Sub
    Public Function cargar(ByVal CodSucursal As Integer, ByVal RutEjecutivo As Long, ByVal Agno As Integer, ByVal Mes As Integer)
        Try
            mobjCSql = New CSql
            mintCodSucursal = CodSucursal
            mlngRutEjecutivo = RutEjecutivo
            mintAgno = Agno
            mintMes = Mes
            'mlngRutUsuario = RutUsuario
            Dim dtmIni, dtmFin As Date

            If mintMes = 0 Then
                dtmIni = DateSerial(mintAgno, 1, 1)
                dtmFin = DateSerial(mintAgno, 12, 31)
            Else
                dtmIni = DateSerial(mintAgno, mintMes, 1)
                dtmFin = DateSerial(mintAgno, mintMes + 1, 0)
            End If
            mlngNumEmpresas = mobjCSql.s_nro_clientes(mintCodSucursal, mlngRutEjecutivo, mlngRutUsuario)

            If mlngNumEmpresas > 0 Then
                mlngConAportes = mobjCSql.s_clientes_con_aporte(mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario)
                mlngConAportesPend = mobjCSql.s_cuenta_cliente_deuda(mintCodSucursal, mlngRutEjecutivo, mlngRutUsuario)
                mlngConActividadesIni = mobjCSql.s_clientes_cursos_ini(mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario)

                mintPorcConAportes = Round((mlngConAportes / mlngNumEmpresas) * 100, 0)
                mintPorcConAportesPend = Round((mlngConAportesPend / mlngNumEmpresas) * 100, 0)
                mintPorcConActividadesIni = Round((mlngConActividadesIni / mlngNumEmpresas) * 100, 0)

                mlngConSaldoExcCap = mobjCSql.s_cuenta_cliente_saldo_positivo(4, mintCodSucursal, mlngRutEjecutivo, mlngRutUsuario)
                mlngConSaldoExcRep = mobjCSql.s_cuenta_cliente_saldo_positivo(5, mintCodSucursal, mlngRutEjecutivo, mlngRutUsuario)
                mintPorcConSaldoExcCap = Round((mlngConSaldoExcCap / mlngNumEmpresas) * 100, 0)
                mintPorcConSaldoExcRep = Round((mlngConSaldoExcRep / mlngNumEmpresas) * 100, 0)

                Dim dtDatosFranq As DataTable
                'Dim dr1 As DataRow
                'dtDatosFranq.Columns.Add(New DataColumn("datos", GetType(Long)))
                'dr1 = mdtTorta.NewRow
                'dr1("datos") = mobjCSql.s_clientes_franquicia(mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario)
                'dtDatosFranq.Rows.Add(dr1)
                dtDatosFranq = mobjCSql.s_clientes_franquicia(mintCodSucursal, mlngRutEjecutivo, dtmIni, dtmFin, mlngRutUsuario)
                mlngFranqOcup50 = NroClienteConFranquiciaOcupadaMenorQue(50, dtDatosFranq)
                mlngFranqOcup25 = NroClienteConFranquiciaOcupadaMenorQue(25, dtDatosFranq)
                mintPorcFranqOcup50 = Round((mlngFranqOcup50 / mlngNumEmpresas) * 100, 0)
                mintPorcFranqOcup25 = Round((mlngFranqOcup25 / mlngNumEmpresas) * 100, 0)
            Else
                mlngConAportes = 0
                mlngConAportesPend = 0
                mlngConActividadesIni = 0
                mintPorcConAportes = 0
                mintPorcConAportesPend = 0
                mintPorcConActividadesIni = 0
                mlngConSaldoExcCap = 0
                mlngConSaldoExcRep = 0
                mintPorcConSaldoExcCap = 0
                mintPorcConSaldoExcRep = 0
                mlngFranqOcup50 = 0
                mlngFranqOcup25 = 0
                mintPorcFranqOcup50 = 0
                mintPorcFranqOcup25 = 0
            End If
            mdtTorta = New DataTable
            Dim dr As DataRow
            If mlngNumEmpresas > 0 Then

                mdtTorta.Columns.Add(New DataColumn("nombre", GetType(String)))
                mdtTorta.Columns.Add(New DataColumn("valor", GetType(Long)))
                dr = mdtTorta.NewRow
                dr("nombre") = "Activas"
                'dr("valor") = Round(mintPorcConActividadesIni)
                dr("valor") = mlngConActividadesIni
                mdtTorta.Rows.Add(dr)
                dr = mdtTorta.NewRow
                dr("nombre") = "Pasivas"
                'dr("valor") = (((mlngNumEmpresas - mlngConActividadesIni) * 100) / mlngNumEmpresas)
                dr("valor") = (mlngNumEmpresas - mlngConActividadesIni)
                mdtTorta.Rows.Add(dr)
            Else
                mdtTorta.Columns.Add(New DataColumn("nombre", GetType(String)))
                mdtTorta.Columns.Add(New DataColumn("valor", GetType(Long)))
                dr = mdtTorta.NewRow
                dr("nombre") = "Activas"
                dr("valor") = 0
                mdtTorta.Rows.Add(dr)
                dr = mdtTorta.NewRow
                dr("nombre") = "Pasivas"
                dr("valor") = 0
                mdtTorta.Rows.Add(dr)
            End If
            mobjCSql = Nothing
        Catch ex As Exception
            EnviaError("cInformeCartera.aspx.vb -->Cargar-->" & ex.Message)
        End Try
    End Function
    Private Function NroClienteConFranquiciaOcupadaMenorQue( _
    ByVal intPorcFranqOcup As Integer, ByRef arrDatosFranq As Object) As Long
        Dim i As Integer, lngCnt As Integer
        lngCnt = 0
        For i = 0 To TamanoArreglo2(arrDatosFranq) - 1
            If CDbl(arrDatosFranq(1, i)) * (CDbl(intPorcFranqOcup) / CDbl(100)) > CDbl(arrDatosFranq(2, i) + arrDatosFranq(3, i)) Then
                lngCnt = lngCnt + 1
            End If
        Next
        NroClienteConFranquiciaOcupadaMenorQue = lngCnt
    End Function
End Class