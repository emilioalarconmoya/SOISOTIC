Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CMantenedorSucursales
    'Implements IMantenedor
    Private mobjSql As New CSql
    Private mcolEliminacion As System.Collections.ArrayList
    Private mlngFilas As Long
    Private mintCodSucursal As Integer
    'Private mintCodAtributo As Integer
    Private mstrNomSucursal As String
    Private mstrNomCaracteristica As String
    Private mstrMensaje As String
    Private mstrXml As String
    'Private mlngFilas As Long
    Private mblnBajarXml As Boolean

#Region "Propiedades"
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
    Public Property colEliminacion() As System.Collections.ArrayList
        Get
            Return mcolEliminacion
        End Get
        Set(ByVal value As System.Collections.ArrayList)
            mcolEliminacion = value
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
    'Public Property CodAtributo() As Integer
    '    Get
    '        Return mintCodAtributo
    '    End Get
    '    Set(ByVal value As Integer)
    '        mintCodAtributo = value
    '    End Set
    'End Property
    Public Property NomSucursal() As String
        Get
            Return mstrNomSucursal
        End Get
        Set(ByVal value As String)
            mstrNomSucursal = value
        End Set
    End Property
    'Public Property NombreCaracteristica() As String
    '    Get
    '        Return mstrNomCaracteristica
    '    End Get
    '    Set(ByVal value As String)
    '        mstrNomCaracteristica = value
    '    End Set
    'End Property
    Public Property Mensaje() As String
        Get
            Return mstrMensaje
        End Get
        Set(ByVal value As String)
            mstrMensaje = value
        End Set
    End Property
#End Region

    Public Function Actualizar() As Boolean
        Dim intCodAtrib As Integer
        Try
            mobjSql.InicioTransaccion()
            mobjSql.u_sucursal(mintCodSucursal, mstrNomSucursal)
            'Propiedad que envia el texto del mensaje a la alerta que visualiza el usuario
            Mensaje = "Los datos fueron Modificados"
            mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorSucursales:Actualizar->" & ex.Message)
        End Try
    End Function

    Public Function Consultar() As System.Data.DataTable
        
        Try
            Dim dt As DataTable
            Dim strNombreArchivo As String
            mobjSql = New CSql
            dt = mobjSql.s_sucursales_todos3(mstrNomSucursal)
            mlngFilas = mobjSql.Registros
            Consultar = dt
            mobjSql = Nothing
            If Me.mblnBajarXml Then
                strNombreArchivo = NombreArchivoTmp("csv")
                dt.TableName = "Reporte Cursos"
                ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
            End If

        Catch ex As Exception
            EnviaError("CMantenedorSucursales:Consultar->" & ex.Message)
        End Try
    End Function

    Public Function Eliminar() As Boolean
        'Dim strAtrCar As AtriCaracteristicas
        Try
            mobjSql.InicioTransaccion()
            'For Each codAtributo In mcolEliminacion
            'For Each strAtrCar In mcolEliminacion
            mobjSql.d_sucursal(mintCodSucursal)
            'mobjSql.d_atributo(strAtrCar.mintCodCaracteristica, strAtrCar.mintCodAtributo)
            'Next
            mobjSql.FinTransaccion()
            Mensaje = "Los datos fueron Eliminados!"
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorSucursales:Eliminar->" & ex.Message)
        End Try
    End Function

    Public Sub InicializarNuevo()
        mintCodSucursal = 0
        mstrNomSucursal = ""
    End Sub
    Public Sub Inicializar()
        Dim dt As DataTable
        Try
            mobjSql = New CSql
            dt = mobjSql.s_sucursales_todos2()

            mintCodSucursal = dt.Rows(0)("cod_sucursal")
            mstrNomSucursal = dt.Rows(0)("nombre")

        Catch ex As Exception
            EnviaError("CMantenedorSucursales:Inicializar->" & ex.Message)
        End Try
    End Sub

    Public Function Insertar() As Boolean
        Dim intMaxCod As Integer
        Try
            mobjSql.InicioTransaccion()

            mobjSql.i_sucursal(mintCodSucursal, mstrNomSucursal)
            Mensaje = "Los datos fueron ingresados!"

            mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorSucursales:Insertar->" & ex.Message)
        End Try
    End Function

End Class
