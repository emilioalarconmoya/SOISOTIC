Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorRubros
    Implements IMantenedor
    Private mobjCsql As CSql
    Private mlngCodRubro As Long
    Private mstrNombre As String
    Public Property CodRubro() As Long
        Get
            Return mlngCodRubro
        End Get
        Set(ByVal value As Long)
            mlngCodRubro = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return mstrNombre
        End Get
        Set(ByVal value As String)
            mstrNombre = value
        End Set
    End Property
    Public Function Insertar() As Boolean Implements Clases.IMantenedor.Insertar
        Try
            mobjCsql = New CSql
            mobjCsql.i_Rubro(mstrNombre)
            Return True
            mobjCsql = Nothing
        Catch ex As Exception
            Return False
            mobjCsql = Nothing
        End Try
    End Function
    Public Function Actualizar() As Boolean Implements Clases.IMantenedor.Actualizar
        Try
            mobjCsql = New CSql
            mobjCsql.u_Rubro(mlngCodRubro, mstrNombre)
            mobjCsql = Nothing
            Return True
        Catch ex As Exception
            Return False
            mobjCsql = Nothing
        End Try
    End Function
    Public Function Eliminar() As Boolean Implements Clases.IMantenedor.Eliminar
        Try
            mobjCsql = New CSql
            mobjCsql.d_Rubro(mlngCodRubro)
            Return True
            mobjCsql = Nothing
        Catch ex As Exception
            Return False
            mobjCsql = Nothing
        End Try
    End Function
    Public Function Consultar() As System.Data.DataTable Implements Clases.IMantenedor.Consultar
        Dim dtRubros As DataTable
        Try
            mobjCsql = New CSql
            dtRubros = mobjCsql.s_rubros(mlngCodRubro, mstrNombre)
            mlngCodRubro = dtRubros.Rows(0)("cod_rubro")
            mstrNombre = dtRubros.Rows(0)("nombre")
            Return dtRubros
            mobjCsql = Nothing
        Catch ex As Exception
            mobjCsql = Nothing
        End Try
    End Function
    Public ReadOnly Property Filas() As Integer Implements Clases.IMantenedor.Filas
        Get

        End Get
    End Property
    Public Sub InicializarNuevo() Implements Clases.IMantenedor.InicializarNuevo

    End Sub
    Public Property colEliminacion() As System.Collections.ArrayList Implements Clases.IMantenedor.colEliminacion
        Get

        End Get
        Set(ByVal value As System.Collections.ArrayList)

        End Set
    End Property
End Class
