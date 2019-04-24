Imports Clases
Imports Modulos
Imports System.Data

Public Class CMantenedorFeriados
    Private mobjCsql As CSql

    Private mintAgno As Integer
    Private mdtFeriados As DataTable

    Public WriteOnly Property Agno() As Integer
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public Property Feriados() As DataTable
        Get
            Return mdtFeriados
        End Get
        Set(ByVal value As DataTable)
            mdtFeriados = value
        End Set
    End Property
    Public Sub Inicializar()
        Try
            mobjCsql = New CSql
            'mintAgno = Now.Year
            mdtFeriados = New DataTable
            mdtFeriados.Columns.Add("fecha")
            mdtFeriados.Columns.Add("motivo")
        Catch ex As Exception
            EnviaError("CMantenedorFeriados:Inicializar-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        Try
            Dim dt As New DataTable
            dt = mobjCsql.s_feriados(mintAgno)
            mdtFeriados = dt
        Catch ex As Exception
            EnviaError("CMantenedorFeriados:Consultar-->" & ex.Message)
        End Try
    End Sub
    Public Sub AplicarCambios()
        Try
            mobjCsql.InicioTransaccion()
            mobjCsql.d_feriados(mintAgno)
            Dim dr As DataRow
            If Not mdtFeriados Is Nothing Then
                For Each dr In mdtFeriados.Rows
                    mobjCsql.i_feriados(dr("fecha"), dr("motivo"))
                Next
            End If
            mobjCsql.FinTransaccion()
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            EnviaError("CMantenedorFeriados:AplicarCambios-->" & ex.Message)
        End Try
    End Sub
End Class
