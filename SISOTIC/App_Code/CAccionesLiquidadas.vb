Imports Clases
Imports Modulos
Imports System.Data
Imports System

Public Class CAccionesLiquidadas
    Private mobjSql As New CSql
    Private mintAgno As Integer
    Private msrtRuta As String

    Public WriteOnly Property Agno() As Integer
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public ReadOnly Property Ruta() As String
        Get
            Return msrtRuta
        End Get
    End Property
    Public Sub Consultar()
        Try
            Dim dt As DataTable = mobjSql.s_acciones_liquidadas(mintAgno)
            Dim dr As DataRow
            For Each dr In dt.Rows
                dr("digv_otic") = digito_verificador(dr("rut_otic"))
                dr("digv_empresa") = digito_verificador(dr("rut_empresa"))
            Next

            Dim strNombreArchivo As String = NombreArchivoTmp("csv")
            dt.TableName = "Acciones Liquidadas"
            ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
            Me.msrtRuta = "~" & "/contenido/tmp/" & strNombreArchivo

        Catch ex As Exception

        End Try
    End Sub
End Class
