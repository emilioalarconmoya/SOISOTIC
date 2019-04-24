Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorUsuarioSucursal
    Private mobjSql As New CSql
    Private mlngRutDirector As Long
    Private mstrNombreDir As String
    Private mlngCodSucursal As Integer
    Private mstrNombreSuc As String
    Private mdtSucursales As DataTable
    Private mdtUsuarios As DataTable
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean

    Public Property RutDirector() As Long
        Get
            Return mlngRutDirector
        End Get
        Set(ByVal value As Long)
            mlngRutDirector = value
        End Set
    End Property
    Public Property NombreDir() As String
        Get
            Return mstrNombreDir
        End Get
        Set(ByVal value As String)
            mstrNombreDir = value
        End Set
    End Property
    Public Property CodSucursal() As Integer
        Get
            Return mlngCodSucursal
        End Get
        Set(ByVal value As Integer)
            mlngCodSucursal = value
        End Set
    End Property
    Public Property NombreSuc() As String
        Get
            Return mstrNombreSuc
        End Get
        Set(ByVal value As String)
            mstrNombreSuc = value
        End Set
    End Property
    Public Property Sucursales() As DataTable
        Get
            Return mdtSucursales
        End Get
        Set(ByVal value As DataTable)
            mdtSucursales = value
        End Set
    End Property
    Public Property Usuarios() As DataTable
        Get
            Return mdtUsuarios
        End Get
        Set(ByVal value As DataTable)
            mdtUsuarios = value
        End Set
    End Property
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
    Public ReadOnly Property Filas() As Long
        Get
            Return mlngFilas
        End Get
    End Property
    Public Function Consultar()
        Try
            Dim dt As DataTable
            Dim strNombreArchivo As String
            mobjSql = New CSql
            dt = mobjSql.s_director_sucursal(mlngRutDirector, mstrNombreDir, mlngCodSucursal, mstrNombreSuc)
            mlngFilas = mobjSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    mlngRutDirector = dr("rut")
                    mstrNombreDir = dr("nombres")
                    mlngCodSucursal = dr("cod_sucursal")
                    mstrNombreSuc = dr("nombre")
                Next
            End If
            Consultar = dt
            mobjSql = Nothing
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dt.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

        Catch ex As Exception
            EnviaError("CMantenedorUsuarioSucursal:Consultar->" & ex.Message)
        End Try
    End Function
    Public Function Eliminar() As Boolean
        Dim respuesta As Boolean
        Try
            mobjSql = New CSql
            mobjSql.InicioTransaccion()
            mobjSql.d_director_suc(mlngRutDirector, mlngCodSucursal)
            respuesta = True
            mobjSql.FinTransaccion()
            mobjSql = Nothing
            Return respuesta
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            mobjSql = Nothing
            EnviaError("CMantenedorUsuarioYPerfil.vb:EliminarSupervisor-->" & ex.Message)
        End Try

    End Function



End Class
