Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CParamGen
    Private mobjSql As New CSql
    Private mstrNombreOtic As String
    Private mstrRazonSocialOtic As String
    Private mlngRutOtic As Long
    Private mstrDireccOtic As String
    Private mstrFonoCobranza As String

    Public ReadOnly Property NombreOtic() As String
        Get
            Return mstrNombreOtic
        End Get
    End Property
    Public ReadOnly Property RazonSocialOtic() As String
        Get
            Return mstrRazonSocialOtic
        End Get
    End Property
    Public ReadOnly Property RutOtic() As String
        Get
            Return RutLngAUsr(mlngRutOtic)
        End Get
    End Property
    Public ReadOnly Property DireccionOtic() As String
        Get
            Return mstrDireccOtic
        End Get
    End Property
    Public ReadOnly Property FonoCobranza() As String
        Get
            Return mstrFonoCobranza
        End Get
    End Property
    Public Function Inicializar()
        Try
            Dim dtParam As DataTable
            dtParam = mobjSql.s_param_gen
            Dim dr As DataRow
            For Each dr In dtParam.Rows
                'mstrNombreOtic = dr("nombre_otic")
                'mstrRazonSocialOtic = dr("razon_social_otic")
                mlngRutOtic = RutUsrALng(dr("rut_otic"))
                'mstrDireccOtic = dr("direccion_otic")
                'mstrFonoCobranza = dr("fono_cobranza_otic")
            Next
        Catch ex As Exception

        End Try
    End Function
End Class
